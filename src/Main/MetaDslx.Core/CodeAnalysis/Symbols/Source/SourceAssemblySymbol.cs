using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Symbols.CSharp;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceAssemblySymbol : MetadataOrSourceAssemblySymbol, ISourceAssemblySymbol
    {
        /// <summary>
        /// A Compilation the assembly is created for.
        /// </summary>
        private readonly LanguageCompilation _compilation;

        private SymbolCompletionState _state;

        /// <summary>
        /// Assembly's identity.
        /// </summary>
        internal AssemblyIdentity _lazyAssemblyIdentity;

        private readonly string _assemblySimpleName;

        /// <summary>
        /// A list of modules the assembly consists of. 
        /// The first (index=0) module is a SourceModuleSymbol, which is a primary module, the rest are net-modules.
        /// </summary>
        private readonly ImmutableArray<ModuleSymbol> _modules;

        private ImmutableArray<Location> _lazyLocations;

        internal SourceAssemblySymbol(
            LanguageCompilation compilation,
            string assemblySimpleName,
            string moduleName,
            ImmutableArray<ModuleSymbol> netModules)
        {
            Debug.Assert(compilation != null);
            Debug.Assert(assemblySimpleName != null);
            Debug.Assert(!String.IsNullOrWhiteSpace(moduleName));
            Debug.Assert(!netModules.IsDefault);

            _compilation = compilation;
            _assemblySimpleName = assemblySimpleName;

            ArrayBuilder<ModuleSymbol> moduleBuilder = new ArrayBuilder<ModuleSymbol>(1 + netModules.Length);
            moduleBuilder.Add(new SourceModuleSymbol(this, compilation.Declarations, moduleName));
            moduleBuilder.AddRange(netModules);
            _modules = moduleBuilder.ToImmutableAndFree();

            _state = SymbolCompletionState.Create(compilation.Language);
        }

        public override string Name => _assemblySimpleName;

        /// <remarks>
        /// This override is essential - it's a base case of the recursive definition.
        /// </remarks>
        internal sealed override LanguageCompilation DeclaringCompilation => _compilation;

        public override bool IsInteractive => _compilation.IsSubmission;

        public override AssemblyIdentity Identity
        {
            get
            {
                if (_lazyAssemblyIdentity == null)
                    Interlocked.CompareExchange(ref _lazyAssemblyIdentity, ComputeIdentity(), null);

                return _lazyAssemblyIdentity;
            }
        }

        public override ImmutableArray<ModuleSymbol> Modules => _modules;

        //TODO: cache
        public override ImmutableArray<Location> Locations
        {
            get
            {
                if (_lazyLocations.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyLocations, this.Modules.SelectMany(m => m.Locations).AsImmutable());
                }
                return _lazyLocations;
            }
        }

        internal SourceModuleSymbol SourceModule
        {
            get { return (SourceModuleSymbol)this.Modules[0]; }
        }

        public override bool RequiresCompletion
        {
            get { return true; }
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.Module)
                {
                    SourceModule.ForceComplete(locationOpt, cancellationToken);
                    if (SourceModule.HasComplete(CompletionPart.MembersCompleted))
                    {
                        _state.NotePartComplete(CompletionPart.Module);
                    }
                    else
                    {
                        Debug.Assert(locationOpt != null, "If no location was specified, then the module members should be completed");
                        // this is the last completion part we can handle if there is a location.
                        return;
                    }
                }
                else if (incompletePart == CompletionPart.StartValidatingAddedModules || incompletePart == CompletionPart.FinishValidatingAddedModules)
                {
                    if (_state.NotePartComplete(CompletionPart.StartValidatingAddedModules))
                    {
                        ReportDiagnosticsForAddedModules();
                        var thisThreadCompleted = _state.NotePartComplete(CompletionPart.FinishValidatingAddedModules);
                        Debug.Assert(thisThreadCompleted);
                    }
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionPart.AssemblySymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        }

        private void ReportDiagnosticsForAddedModules()
        {
            var diagnostics = DiagnosticBag.GetInstance();

            foreach (var pair in _compilation.GetBoundReferenceManager().ReferencedModuleIndexMap)
            {
                var fileRef = pair.Key as PortableExecutableReference;

                if ((object)fileRef != null && (object)fileRef.FilePath != null)
                {
                    string fileName = FileNameUtilities.GetFileName(fileRef.FilePath);
                    string moduleName = _modules[pair.Value].Name;

                    if (!string.Equals(fileName, moduleName, StringComparison.OrdinalIgnoreCase))
                    {
                        // Used to be ERR_ALinkFailed
                        diagnostics.Add(InternalErrorCode.ERR_NetModuleNameMismatch, NoLocation.Singleton, moduleName, fileName);
                    }
                }
            }

            // Alink performed these checks only when emitting an assembly.
            if (_modules.Length > 1 && !_compilation.Options.OutputKind.IsNetModule())
            {
                var knownModuleNames = new HashSet<String>(StringComparer.OrdinalIgnoreCase);

                for (int i = 1; i < _modules.Length; i++)
                {
                    ModuleSymbol m = _modules[i];
                    if (!knownModuleNames.Add(m.Name))
                    {
                        diagnostics.Add(InternalErrorCode.ERR_NetModuleNameMustBeUnique, NoLocation.Singleton, m.Name);
                    }
                }

                // Assembly main module must explicitly reference all the modules referenced by other assembly 
                // modules, i.e. all modules from transitive closure must be referenced explicitly here
                for (int i = 1; i < _modules.Length; i++)
                {
                    var csm = _modules[i] as CSharpModuleSymbol;
                    var m = csm?.CSharpModule as Microsoft.CodeAnalysis.CSharp.Symbols.Metadata.PE.PEModuleSymbol;

                    try
                    {
                        foreach (var referencedModuleName in m.Module.GetReferencedManagedModulesOrThrow())
                        {
                            // Do not report error for this module twice
                            if (knownModuleNames.Add(referencedModuleName))
                            {
                                diagnostics.Add(InternalErrorCode.ERR_MissingNetModuleReference, NoLocation.Singleton, referencedModuleName);
                            }
                        }
                    }
                    catch (BadImageFormatException)
                    {
                        diagnostics.Add(new LanguageDiagnosticInfo(InternalErrorCode.ERR_BindToBogus, m), NoLocation.Singleton);
                    }
                }
            }

            ReportNameCollisionDiagnosticsForAddedModules(this.GlobalNamespace, diagnostics);

            _compilation.DeclarationDiagnostics.AddRange(diagnostics);
            diagnostics.Free();
        }

        private void ReportNameCollisionDiagnosticsForAddedModules(NamespaceSymbol ns, DiagnosticBag diagnostics)
        {
            var mergedNs = ns as MergedNamespaceSymbol;

            if ((object)mergedNs == null)
            {
                return;
            }

            ImmutableArray<NamespaceSymbol> constituent = mergedNs.ConstituentNamespaces;

            if (constituent.Length > 2 || (constituent.Length == 2 && constituent[0].ContainingModule.Ordinal != 0 && constituent[1].ContainingModule.Ordinal != 0))
            {
                var topLevelTypesFromModules = ArrayBuilder<NamedTypeSymbol>.GetInstance();

                foreach (var moduleNs in constituent)
                {
                    Debug.Assert(moduleNs.Extent.Kind == NamespaceKind.Module);

                    if (moduleNs.ContainingModule.Ordinal != 0)
                    {
                        topLevelTypesFromModules.AddRange(moduleNs.GetTypeMembers());
                    }
                }

                topLevelTypesFromModules.Sort(NameCollisionForAddedModulesTypeComparer.Singleton);

                bool reportedAnError = false;

                for (int i = 0; i < topLevelTypesFromModules.Count - 1; i++)
                {
                    NamedTypeSymbol x = topLevelTypesFromModules[i];
                    NamedTypeSymbol y = topLevelTypesFromModules[i + 1];

                    if (x.Arity == y.Arity && x.Name == y.Name)
                    {
                        if (!reportedAnError)
                        {
                            // Skip synthetic <Module> type which every .NET module has.
                            if (x.Arity != 0 || !x.ContainingNamespace.IsGlobalNamespace || x.Name != "<Module>")
                            {
                                diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInNS, y.Locations[0],
                                                y.ToDisplayString(SymbolDisplayFormat.ShortFormat),
                                                y.ContainingNamespace);
                            }

                            reportedAnError = true;
                        }
                    }
                    else
                    {
                        reportedAnError = false;
                    }
                }

                topLevelTypesFromModules.Free();

                // Descent into child namespaces.
                foreach (Symbol member in mergedNs.GetMembers())
                {
                    if (member.Kind == SymbolKind.Namespace)
                    {
                        ReportNameCollisionDiagnosticsForAddedModules((NamespaceSymbol)member, diagnostics);
                    }
                }
            }
        }

        private class NameCollisionForAddedModulesTypeComparer : IComparer<NamedTypeSymbol>
        {
            public static readonly NameCollisionForAddedModulesTypeComparer Singleton = new NameCollisionForAddedModulesTypeComparer();

            private NameCollisionForAddedModulesTypeComparer() { }

            public int Compare(NamedTypeSymbol x, NamedTypeSymbol y)
            {
                int result = String.CompareOrdinal(x.Name, y.Name);

                if (result == 0)
                {
                    result = x.Arity - y.Arity;

                    if (result == 0)
                    {
                        result = x.ContainingModule.Ordinal - y.ContainingModule.Ordinal;
                    }
                }

                return result;
            }
        }


        private AssemblyIdentity ComputeIdentity()
        {
            return new AssemblyIdentity(_assemblySimpleName);
        }

        public override AssemblyMetadata GetMetadata() => null;

        Compilation ISourceAssemblySymbol.Compilation => _compilation;

        public override ICollection<string> TypeNames => throw new NotImplementedException();

        public override ICollection<string> NamespaceNames => throw new NotImplementedException();

        /// <summary>
        /// Lookup a type within the assembly using the canonical CLR metadata name of the type.
        /// </summary>
        /// <param name="fullyQualifiedMetadataName">Type name.</param>
        /// <returns>Symbol for the type or null if type cannot be found or is ambiguous. </returns>
        public override NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            if (fullyQualifiedMetadataName == null)
            {
                throw new ArgumentNullException(nameof(fullyQualifiedMetadataName));
            }

            return this.GetTypeByMetadataName(fullyQualifiedMetadataName, includeReferences: false, isWellKnownType: false, conflicts: out var _);
        }

        /// <summary>
        /// Lookup a type within the assembly using its canonical CLR metadata name.
        /// </summary>
        /// <param name="metadataName"></param>
        /// <param name="includeReferences">
        /// If search within assembly fails, lookup in assemblies referenced by the primary module.
        /// For source assembly, this is equivalent to all assembly references given to compilation.
        /// </param>
        /// <param name="isWellKnownType">
        /// Extra restrictions apply when searching for a well-known type.  In particular, the type must be public.
        /// </param>
        /// <param name="useCLSCompliantNameArityEncoding">
        /// While resolving the name, consider only types following CLS-compliant generic type names and arity encoding (ECMA-335, section 10.7.2).
        /// I.e. arity is inferred from the name and matching type must have the same emitted name and arity.
        /// </param>
        /// <param name="warnings">
        /// A diagnostic bag to receive warnings if we should allow multiple definitions and pick one.
        /// </param>
        /// <param name="ignoreCorLibraryDuplicatedTypes">
        /// In case duplicate types are found, ignore the one from corlib. This is useful for any kind of compilation at runtime
        /// (EE/scripting/Powershell) using a type that is being migrated to corlib.
        /// </param>
        /// <param name="conflicts">
        /// In cases a type could not be found because of ambiguity, we return two of the candidates that caused the ambiguity.
        /// </param>
        /// <returns>Null if the type can't be found.</returns>
        internal NamedTypeSymbol GetTypeByMetadataName(
            string metadataName,
            bool includeReferences,
            bool isWellKnownType,
            out (AssemblySymbol, AssemblySymbol) conflicts,
            bool useCLSCompliantNameArityEncoding = false,
            DiagnosticBag warnings = null,
            bool ignoreCorLibraryDuplicatedTypes = false)
        {
            NamedTypeSymbol type;
            MetadataTypeName mdName;

            if (metadataName.IndexOf('+') >= 0)
            {
                var parts = metadataName.Split(s_nestedTypeNameSeparators);
                Debug.Assert(parts.Length > 0);
                mdName = MetadataTypeName.FromFullName(parts[0], useCLSCompliantNameArityEncoding);
                type = GetTopLevelTypeByMetadataName(ref mdName, assemblyOpt: null, includeReferences: includeReferences, isWellKnownType: isWellKnownType,
                    conflicts: out conflicts, warnings: warnings, ignoreCorLibraryDuplicatedTypes: ignoreCorLibraryDuplicatedTypes);

                for (int i = 1; (object)type != null && !type.IsErrorType() && i < parts.Length; i++)
                {
                    mdName = MetadataTypeName.FromTypeName(parts[i]);
                    NamedTypeSymbol temp = type.LookupMetadataType(ref mdName);
                    type = (!isWellKnownType || IsValidWellKnownType(temp)) ? temp : null;
                }
            }
            else
            {
                mdName = MetadataTypeName.FromFullName(metadataName, useCLSCompliantNameArityEncoding);
                type = GetTopLevelTypeByMetadataName(ref mdName, assemblyOpt: null, includeReferences: includeReferences, isWellKnownType: isWellKnownType,
                    conflicts: out conflicts, warnings: warnings, ignoreCorLibraryDuplicatedTypes: ignoreCorLibraryDuplicatedTypes);
            }

            return ((object)type == null || type.IsErrorType()) ? null : type;
        }

        private static readonly char[] s_nestedTypeNameSeparators = new char[] { '+' };

        private bool IsValidWellKnownType(NamedTypeSymbol result)
        {
            if ((object)result == null || result.TypeKind == TypeKind.Error)
            {
                return false;
            }

            Debug.Assert((object)result.ContainingType == null || IsValidWellKnownType(result.ContainingType),
                "Checking the containing type is the caller's responsibility.");

            return result.DeclaredAccessibility == Accessibility.Public;
        }

        /*
        /// <summary>
        /// Lookup a type within the assembly using the canonical CLR metadata name of the type.
        /// </summary>
        /// <param name="fullyQualifiedMetadataName">Type name.</param>
        /// <returns>Symbol for the type or null if type cannot be found or is ambiguous. </returns>
        public override NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            if (fullyQualifiedMetadataName == null)
            {
                throw new ArgumentNullException(nameof(fullyQualifiedMetadataName));
            }
            var parts = fullyQualifiedMetadataName.Split('.');
            if (parts.Length == 0)
            {
                throw new ArgumentException("Invalid metadata name.", nameof(fullyQualifiedMetadataName));
            }
            var mdName = parts[0];
            IEnumerable<NamespaceOrTypeSymbol> members = this.GlobalNamespace.GetMembers(mdName).OfType<NamespaceOrTypeSymbol>();
            for (int i = 1; members.Any() && i < parts.Length; i++)
            {
                mdName = parts[i];
                members = members.SelectMany(m => m.GetMembers(mdName)).OfType<NamespaceOrTypeSymbol>();
            }
            NamedTypeSymbol[] typeArray = members.OfType<NamedTypeSymbol>().ToArray();
            if (typeArray.Length == 0 || typeArray.Length > 1 || (object)typeArray[0] == null || typeArray[0].IsErrorType()) return null;
            else return typeArray[0];
        }*/

        /// <summary>
        /// Resolves <see cref="System.Type"/> to a <see cref="TypeSymbol"/> available in this assembly
        /// its referenced assemblies.
        /// </summary>
        /// <param name="type">The type to resolve.</param>
        /// <param name="includeReferences">Use referenced assemblies for resolution.</param>
        /// <returns>The resolved symbol if successful or null on failure.</returns>
        internal TypeSymbol GetTypeByReflectionType(Type type, bool includeReferences)
        {
            System.Reflection.TypeInfo typeInfo = type.GetTypeInfo();

            Debug.Assert(!typeInfo.IsByRef);

            // not supported (we don't accept open types as submission results nor host types):
            Debug.Assert(!typeInfo.ContainsGenericParameters);

            if (typeInfo.IsArray)
            {
                throw new NotImplementedException("TODO:MetaDslx");
            }
            else if (typeInfo.IsPointer)
            {
                throw new NotImplementedException("TODO:MetaDslx");
            }
            else if (typeInfo.DeclaringType != null)
            {
                Debug.Assert(!typeInfo.IsArray);

                var currentTypeInfo = typeInfo.IsGenericType ? typeInfo.GetGenericTypeDefinition().GetTypeInfo() : typeInfo;
                var nestedTypes = ArrayBuilder<System.Reflection.TypeInfo>.GetInstance();
                while (true)
                {
                    Debug.Assert(currentTypeInfo.IsGenericTypeDefinition || !currentTypeInfo.IsGenericType);

                    nestedTypes.Add(currentTypeInfo);
                    if (currentTypeInfo.DeclaringType == null)
                    {
                        break;
                    }

                    currentTypeInfo = currentTypeInfo.DeclaringType.GetTypeInfo();
                }

                int i = nestedTypes.Count - 1;
                var symbol = (NamedTypeSymbol)GetTypeByReflectionType(nestedTypes[i].AsType(), includeReferences);
                if ((object)symbol == null)
                {
                    return null;
                }

                while (--i >= 0)
                {
                    int forcedArity = nestedTypes[i].GenericTypeParameters.Length - nestedTypes[i + 1].GenericTypeParameters.Length;
                    MetadataTypeName mdName = MetadataTypeName.FromTypeName(nestedTypes[i].Name, forcedArity: forcedArity);

                    symbol = symbol.LookupMetadataType(ref mdName);
                    if ((object)symbol == null || symbol.IsErrorType())
                    {
                        return null;
                    }
                }

                nestedTypes.Free();
                return symbol;
            }
            else
            {
                AssemblyIdentity assemblyId = AssemblyIdentity.FromAssemblyDefinition(typeInfo.Assembly);

                MetadataTypeName mdName = MetadataTypeName.FromNamespaceAndTypeName(
                    typeInfo.Namespace ?? string.Empty,
                    typeInfo.Name,
                    forcedArity: typeInfo.GenericTypeArguments.Length);

                NamedTypeSymbol symbol = GetTopLevelTypeByMetadataName(ref mdName, assemblyId, includeReferences, isWellKnownType: false, conflicts: out var _);

                if ((object)symbol == null || symbol.IsErrorType())
                {
                    return null;
                }
                return symbol;
            }
        }

        internal NamedTypeSymbol GetTopLevelTypeByMetadataName(
            ref MetadataTypeName metadataName,
            AssemblyIdentity assemblyOpt,
            bool includeReferences,
            bool isWellKnownType,
            out (AssemblySymbol, AssemblySymbol) conflicts,
            DiagnosticBag warnings = null,
            bool ignoreCorLibraryDuplicatedTypes = false)
        {
            conflicts = default;
            NamedTypeSymbol result;

            // First try this assembly
            result = GetTopLevelTypeByMetadataName(this, ref metadataName, assemblyOpt);

            if (isWellKnownType && !IsValidWellKnownType(result))
            {
                result = null;
            }

            // ignore any types of the same name that might be in referenced assemblies (prefer the current assembly):
            if ((object)result != null || !includeReferences)
            {
                return result;
            }

            Debug.Assert(this is SourceAssemblySymbol,
                "Never include references for a non-source assembly, because they don't know about aliases.");

            var assemblies = ArrayBuilder<AssemblySymbol>.GetInstance();

            // ignore reference aliases if searching for a type from a specific assembly:
            if (assemblyOpt != null)
            {
                assemblies.AddRange(DeclaringCompilation.GetBoundReferenceManager().ReferencedAssemblies);
            }
            else
            {
                DeclaringCompilation.GetUnaliasedReferencedAssemblies(assemblies);
            }

            // Lookup in references
            foreach (var assembly in assemblies)
            {
                Debug.Assert(!(this is SourceAssemblySymbol && assembly.IsMissing)); // Non-source assemblies can have missing references

                NamedTypeSymbol candidate = GetTopLevelTypeByMetadataName(assembly, ref metadataName, assemblyOpt);

                if (isWellKnownType && !IsValidWellKnownType(candidate))
                {
                    candidate = null;
                }

                if ((object)candidate == null)
                {
                    continue;
                }

                Debug.Assert(!TypeSymbol.Equals(candidate, result, TypeCompareKind.ConsiderEverything2));

                if ((object)result != null)
                {
                    // duplicate
                    if (ignoreCorLibraryDuplicatedTypes)
                    {
                        if (IsInCorLib(candidate))
                        {
                            // ignore candidate
                            continue;
                        }
                        if (IsInCorLib(result))
                        {
                            // drop previous result
                            result = candidate;
                            continue;
                        }
                    }

                    if (warnings == null)
                    {
                        conflicts = (result.ContainingAssembly, candidate.ContainingAssembly);
                        result = null;
                    }
                    else
                    {
                        // The predefined type '{0}' is defined in multiple assemblies in the global alias; using definition from '{1}'
                        warnings.Add(InternalErrorCode.WRN_MultiplePredefTypes, NoLocation.Singleton, result, result.ContainingAssembly);
                    }

                    break;
                }

                result = candidate;
            }

            assemblies.Free();
            return result;
        }

        private bool IsInCorLib(NamedTypeSymbol type)
        {
            return (object)type.ContainingAssembly == CorLibrary;
        }

        private static NamedTypeSymbol GetTopLevelTypeByMetadataName(AssemblySymbol assembly, ref MetadataTypeName metadataName, AssemblyIdentity assemblyOpt)
        {
            var result = assembly.LookupTopLevelMetadataType(ref metadataName, digThroughForwardedTypes: false);
            if (!IsAcceptableMatchForGetTypeByMetadataName(result))
            {
                return null;
            }

            if (assemblyOpt != null && !assemblyOpt.Equals(assembly.Identity))
            {
                return null;
            }

            return result;
        }

        private static bool IsAcceptableMatchForGetTypeByMetadataName(NamedTypeSymbol candidate)
        {
            return candidate.Kind != SymbolKind.ErrorType || !(candidate is MissingMetadataTypeSymbol);
        }

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            throw new NotImplementedException();
        }

        public override NamedTypeSymbol GetDeclaredSpecialType(SpecialType type)
        {
            throw new NotImplementedException();
        }

        public override bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            throw new NotImplementedException();
        }
    }
}

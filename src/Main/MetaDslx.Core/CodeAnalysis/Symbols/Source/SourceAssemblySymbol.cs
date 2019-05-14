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
        private readonly Microsoft.CodeAnalysis.CSharp.Symbols.SourceAssemblySymbol _csharpSourceAssembly;

        /// <summary>
        /// A Compilation the assembly is created for.
        /// </summary>
        private readonly LanguageCompilation _compilation;

        private SymbolCompletionState _state;

        /// <summary>
        /// Assembly's identity.
        /// </summary>
        private AssemblyIdentity _lazyAssemblyIdentity;
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


        internal SourceAssemblySymbol(
            LanguageCompilation compilation,
            string assemblySimpleName,
            string moduleName,
            ImmutableArray<PEModule> netModules)
        {
            Debug.Assert(compilation != null);
            Debug.Assert(assemblySimpleName != null);
            Debug.Assert(!String.IsNullOrWhiteSpace(moduleName));
            Debug.Assert(!netModules.IsDefault);

            _compilation = compilation;
            _assemblySimpleName = assemblySimpleName;

            _csharpSourceAssembly = new Microsoft.CodeAnalysis.CSharp.Symbols.SourceAssemblySymbol(compilation.CSharpCompilationForReferencedModules, assemblySimpleName, moduleName, netModules);

            ArrayBuilder<ModuleSymbol> moduleBuilder = new ArrayBuilder<ModuleSymbol>(1 + netModules.Length);

            moduleBuilder.Add(new SourceModuleSymbol(this, compilation.Declarations, moduleName));

            var importOptions = (compilation.Options.MetadataImportOptions == MetadataImportOptions.All) ?
                MetadataImportOptions.All : MetadataImportOptions.Internal;

            for (int i = 0; i < netModules.Length; i++)
            {
                moduleBuilder.Add(CSharpModuleSymbol.FromCSharp(this, _csharpSourceAssembly.Modules[i]));
            }

            _modules = moduleBuilder.ToImmutableAndFree();
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

        internal Microsoft.CodeAnalysis.CSharp.Symbols.SourceAssemblySymbol CSharpSourceAssembly => _csharpSourceAssembly;

        internal bool MightContainNoPiaLocalTypes()
        {
            if (_csharpSourceAssembly.MightContainNoPiaLocalTypes()) return true;
            return SourceModule.MightContainNoPiaLocalTypes();
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

        internal bool DeclaresTheObjectClass
        {
            get
            {
                if ((object)this.CorLibrary != (object)this)
                {
                    return false;
                }

                var obj = GetSpecialType(SpecialType.System_Object);

                return !obj.IsErrorType() && obj.DeclaredAccessibility == Accessibility.Public;
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

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            throw new NotImplementedException();
        }

        public override NamedTypeSymbol GetDeclaredSpecialType(SpecialType type)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<AssemblySymbol> GetNoPiaResolutionAssemblies()
        {
            return _modules[0].ReferencedAssemblySymbols;
        }

        internal override void SetNoPiaResolutionAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override ImmutableArray<AssemblySymbol> GetLinkedReferencedAssemblies()
        {
            // SourceAssemblySymbol is never used directly as a reference
            // when it is or any of its references is linked.
            return default(ImmutableArray<AssemblySymbol>);
        }

        internal override void SetLinkedReferencedAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            // SourceAssemblySymbol is never used directly as a reference
            // when it is or any of its references is linked.
            throw ExceptionUtilities.Unreachable;
        }

        public override bool IsLinked
        {
            get
            {
                return false;
            }
        }

        public override IEnumerable<ImmutableArray<byte>> GetInternalsVisibleToPublicKeys(string simpleName)
        {
            throw new NotImplementedException();
        }

        public override bool AreInternalsVisibleToThisAssembly(AssemblySymbol potentialGiverOfAccess)
        {
            throw new NotImplementedException();
        }
    }
}

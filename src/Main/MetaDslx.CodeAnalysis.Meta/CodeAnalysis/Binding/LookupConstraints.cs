using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class LookupConstraints
    {
        public readonly LanguageCompilation Compilation;
        public readonly DeclaredSymbol QualifierOpt;
        public readonly string Name;
        public readonly string MetadataName;
        public readonly ImmutableArray<Type> Types;
        public readonly ConsList<TypeSymbol> BasesBeingResolved;
        public readonly LookupOptions Options;
        public readonly bool Diagnose;
        public readonly Binder OriginalBinder;
        public readonly TypeSymbol AccessThroughType;

        public LookupConstraints(
            LanguageCompilation compilation,
            string name = null,
            string metadataName = null,
            ImmutableArray<Type> types = default,
            DeclaredSymbol qualifierOpt = null,
            ConsList<TypeSymbol> basesBeingResolved = null,
            Binder originalBinder = null,
            TypeSymbol accessThroughType = null,
            LookupOptions options = LookupOptions.Default,
            bool diagnose = true)
        {
            Compilation = compilation;
            QualifierOpt = qualifierOpt;
            Name = name;
            Types = types;
            MetadataName = metadataName ?? name;
            BasesBeingResolved = basesBeingResolved;
            OriginalBinder = originalBinder;
            AccessThroughType = accessThroughType;
            Options = options;
            Diagnose = diagnose;
        }

        protected virtual LookupConstraints Update(
            string name,
            string metadataName,
            ImmutableArray<Type> types,
            DeclaredSymbol qualifierOpt,
            ConsList<TypeSymbol> basesBeingResolved,
            Binder originalBinder,
            TypeSymbol accessThroughType,
            LookupOptions options,
            bool diagnose)
        {
            if (!ReferenceEquals(qualifierOpt, this.QualifierOpt) || name != this.Name || metadataName != this.MetadataName || types != this.Types ||
                !ReferenceEquals(basesBeingResolved, this.BasesBeingResolved) || !ReferenceEquals(originalBinder, this.OriginalBinder) ||
                !ReferenceEquals(accessThroughType, this.AccessThroughType) ||
                options != this.Options || diagnose != this.Diagnose)
            {
                return new LookupConstraints(Compilation, name, metadataName, types, qualifierOpt, basesBeingResolved, originalBinder, accessThroughType, options, diagnose);
            }
            return this;
        }

        public LookupConstraints WithName(string name, string metadataName = null)
        {
            return Update(name, metadataName ?? name, this.Types, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, this.Diagnose);
        }

        public LookupConstraints WithTypes(ImmutableArray<Type> types)
        {
            return Update(this.Name, this.MetadataName, types, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, this.Diagnose);
        }

        public LookupConstraints WithQualifier(DeclaredSymbol qualifierOpt)
        {
            return Update(this.Name, this.MetadataName, this.Types, qualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, this.Diagnose);
        }

        public LookupConstraints WithOptions(LookupOptions options)
        {
            return Update(this.Name, this.MetadataName, this.Types, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, options, this.Diagnose);
        }

        public LookupConstraints WithDiagnose(bool diagnose)
        {
            return Update(this.Name, this.MetadataName, this.Types, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, diagnose);
        }

        public LookupConstraints WithDiagnoseAndOriginalBinder(bool diagnose, Binder originalBinder)
        {
            return Update(this.Name, this.MetadataName, this.Types, this.QualifierOpt, this.BasesBeingResolved, originalBinder, this.AccessThroughType, this.Options, diagnose);
        }

        public LookupConstraints WithOriginalBinder(Binder originalBinder)
        {
            return Update(this.Name, this.MetadataName, this.Types, this.QualifierOpt, this.BasesBeingResolved, originalBinder, this.AccessThroughType, this.Options, this.Diagnose);
        }

        public LookupConstraints WithAccessThroughType(TypeSymbol accessThroughType)
        {
            return Update(this.Name, this.MetadataName, this.Types, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, accessThroughType, this.Options, this.Diagnose);
        }

        public LookupConstraints WithQualifierAndAccessThroughType(NamespaceOrTypeSymbol qualifierOpt, TypeSymbol accessThroughType)
        {
            return Update(this.Name, this.MetadataName, this.Types, qualifierOpt, this.BasesBeingResolved, this.OriginalBinder, accessThroughType, this.Options, this.Diagnose);
        }

        public virtual bool AreValid()
        {
            return this.Options.AreValid();
        }

        public bool IsMemberLookup
        {
            get { return (object)this.QualifierOpt != null; }
        }

        public bool CanConsiderMembers()
        {
            return this.Options.CanConsiderMembers();
        }

        public bool CanConsiderLocals()
        {
            return this.Options.CanConsiderLocals();
        }

        public bool CanConsiderTypes()
        {
            return this.Options.CanConsiderTypes();
        }

        public bool CanConsiderNamespaces()
        {
            return this.Options.CanConsiderNamespaces();
        }

        public bool IsAttributeTypeLookup()
        {
            return this.Options.IsAttributeTypeLookup();
        }

        public bool IsVerbatimNameAttributeTypeLookup()
        {
            return this.Options.IsVerbatimNameAttributeTypeLookup();
        }

        public static DeclaredSymbol UnwrapAlias(DeclaredSymbol symbol, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            if (symbol.Kind == LanguageSymbolKind.Alias)
            {
                return ((AliasSymbol)symbol).GetAliasTarget(basesBeingResolved);
            }
            return symbol;
        }

        public virtual bool IsViable(Symbol symbol)
        {
            if (symbol == null) return false;
            if (Types.IsDefaultOrEmpty) return true;
            if (symbol is MergedNamespaceSymbol mns)
            {
                if (Types.Any(t => t.IsAssignableFrom(mns.GetType()))) return true;
                foreach (var ns in mns.ConstituentNamespaces)
                {
                    if (ns is IModelSymbol nms)
                    {
                        var mtype = nms.ModelObjectType;
                        return mtype != null && Types.Any(t => t.IsAssignableFrom(mtype));
                    }
                }
                return false;
            }
            else if (symbol is CSharpNamedTypeSymbol cnts)
            {
                return Types.Any(t => t == typeof(Type) || t.IsAssignableFrom(cnts.GetType()));
            }
            if (symbol is IModelSymbol ms)
            {
                var mtype = ms.ModelObjectType;
                return mtype != null && Types.Any(t => t.IsAssignableFrom(mtype));
            }
            return false;
        }

        /// <remarks>
        /// Distinguish from <see cref="CanAddLookupSymbolInfo"/>, which performs an analogous task for Add*LookupSymbolsInfo*.
        /// </remarks>
        public virtual SingleLookupResult CheckViability(Binder binder, DeclaredSymbol symbol, LookupConstraints constraints, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            bool inaccessibleViaQualifier;
            DiagnosticInfo diagInfo;

            // General pattern: checks and diagnostics refer to unwrapped symbol,
            // but lookup results refer to symbol.

            var unwrappedSymbol = symbol.Kind == LanguageSymbolKind.Alias
                ? ((AliasSymbol)symbol).GetAliasTarget(constraints.BasesBeingResolved)
                : symbol;

            if (WrongArity(symbol, constraints.MetadataName, constraints.Diagnose, constraints.Options, out diagInfo))
            {
                return LookupResult.WrongArity(symbol, diagInfo);
            }
            else if (!unwrappedSymbol.CanBeReferencedByName)
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_CantCallSpecialMethod, unwrappedSymbol) : null;
                return LookupResult.NotReferencable(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.NamespacesOrTypesOnly) != 0 && !(unwrappedSymbol is NamespaceOrTypeSymbol))
            {
                return LookupResult.NotTypeOrNamespace(unwrappedSymbol, symbol, constraints.Diagnose);
            }
            else if ((constraints.Options & LookupOptions.MustBeInvocableIfMember) != 0
                && IsNonInvocableMember(unwrappedSymbol))
            {
                return LookupResult.NotInvocable(unwrappedSymbol, symbol, constraints.Diagnose);
            }
            else if (!binder.Flags.Includes(BinderFlags.IgnoreAccessibility) && 
                     !this.IsAccessible(unwrappedSymbol,
                                        ref useSiteDiagnostics,
                                        RefineAccessThroughType(constraints.Options, constraints.AccessThroughType),
                                        out inaccessibleViaQualifier,
                                        constraints.BasesBeingResolved))
            {
                if (!constraints.Diagnose)
                {
                    diagInfo = null;
                }
                else if (inaccessibleViaQualifier)
                {
                    diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_BadProtectedAccess, unwrappedSymbol, constraints.AccessThroughType, binder.ContainingType);
                }
                else if (IsBadIvtSpecification())
                {
                    diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_FriendRefNotEqualToThis, unwrappedSymbol.ContainingAssembly.Identity.ToString(), AssemblyIdentity.PublicKeyToString(this.Compilation.Assembly.PublicKey));
                }
                else
                {
                    diagInfo = new SymbolDiagnosticInfo(ImmutableArray.Create<ISymbol>(unwrappedSymbol), ImmutableArray<Location>.Empty, InternalErrorCode.ERR_BadAccess, unwrappedSymbol);
                }

                return LookupResult.Inaccessible(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.MustBeInstance) != 0 && !IsInstance(unwrappedSymbol))
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_ObjectRequired, unwrappedSymbol) : null;
                return LookupResult.StaticInstanceMismatch(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.MustNotBeInstance) != 0 && IsInstance(unwrappedSymbol))
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_ObjectProhibited, unwrappedSymbol) : null;
                return LookupResult.StaticInstanceMismatch(symbol, diagInfo);
            }
            else if ((constraints.Options & LookupOptions.MustNotBeNamespace) != 0 && unwrappedSymbol.Kind == LanguageSymbolKind.Namespace)
            {
                diagInfo = constraints.Diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_BadSKunknown, unwrappedSymbol, unwrappedSymbol.GetKindText()) : null;
                return LookupResult.NotTypeOrNamespace(symbol, diagInfo);
            }
            /*else if ((options & LookupOptions.LabelsOnly) != 0 && unwrappedSymbol.Kind != LanguageSymbolKind.Label)
            {
                diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_LabelNotFound, unwrappedSymbol.Name) : null;
                return LookupResult.NotLabel(symbol, diagInfo);
            }*/
            else if (!constraints.IsViable(symbol))
            {
                return LookupResult.WrongSymbol(symbol, symbol, constraints.Types, true);
            }
            else
            {
                return LookupResult.Good(symbol);
            }

            bool IsBadIvtSpecification()
            {
                // Ensures that during binding we don't ask for public key which results in attribute binding and stack overflow.
                // If looking up attributes, don't ask for public key.
                if ((unwrappedSymbol.DeclaredAccessibility == Accessibility.Internal ||
                    unwrappedSymbol.DeclaredAccessibility == Accessibility.ProtectedAndInternal ||
                    unwrappedSymbol.DeclaredAccessibility == Accessibility.ProtectedOrInternal)
                    && !constraints.Options.IsAttributeTypeLookup())
                {
                    var assemblyName = this.Compilation.AssemblyName;
                    if (assemblyName == null)
                    {
                        return false;
                    }
                    var keys = unwrappedSymbol.ContainingAssembly.GetInternalsVisibleToPublicKeys(assemblyName);
                    if (!keys.Any())
                    {
                        return false;
                    }
                    foreach (ImmutableArray<byte> key in keys)
                    {
                        if (key.SequenceEqual(this.Compilation.Assembly.Identity.PublicKey))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        public void CheckViability<TSymbol>(Binder binder, LookupResult result, ImmutableArray<TSymbol> symbols, LookupConstraints constraints, ref HashSet<DiagnosticInfo> useSiteDiagnostics) where TSymbol : DeclaredSymbol
        {
            foreach (var symbol in symbols)
            {
                var res = this.CheckViability(binder, symbol, constraints, ref useSiteDiagnostics);
                result.MergeEqual(res);
            }
        }


        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType".
        /// </summary>
        public bool IsAccessible(DeclaredSymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, TypeSymbol accessThroughType = null, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            bool failedThroughTypeCheck;
            return IsAccessible(symbol, ref useSiteDiagnostics, accessThroughType, out failedThroughTypeCheck, basesBeingResolved);
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType", and sets "failedThroughTypeCheck" if fails
        /// the protected access check.
        /// </summary>
        protected virtual bool IsAccessible(DeclaredSymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ConsList<TypeSymbol> basesBeingResolved = null)
        {
            failedThroughTypeCheck = false;
            return true;
        }

        public bool IsNonInvocableMember(DeclaredSymbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.Member:
                case LanguageSymbolKind.NamedType:
                    return !IsInvocableMember(symbol);

                default:
                    return false;
            }
        }

        private bool IsInvocableMember(DeclaredSymbol symbol)
        {
            // If a member is a method or event, or if it is a constant, field or property of 
            // either a delegate type or the type dynamic, then the member is said to be invocable.

            TypeSymbol type = null;

            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.Member:
                    return ((MemberSymbol)symbol).MemberKind == MemberKind.Method;
            }

            // TODO:MetaDslx - delegate typed members

            return (object)type != null && type.IsDynamic();
        }

        private static bool IsInstance(DeclaredSymbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.Member:
                    return !symbol.IsStatic;
                default:
                    return false;
            }
        }

        // Check if the given symbol can be accessed with the given metadataName. If OK, return false.
        // If not OK, return true and return a diagnosticinfo. Note that methods with type arguments
        // can be accesses with metadataName zero due to type inference (but non types).
        private static bool WrongArity(Symbol symbol, string metadataName, bool diagnose, LookupOptions options, out DiagnosticInfo diagInfo)
        {
            if (symbol.MetadataName != metadataName)
            {
                diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_TypeArgsNotAllowed, symbol, symbol.MetadataName) : null;
                return true;
            }
            diagInfo = null;
            return false;
        }

        private static TypeSymbol RefineAccessThroughType(LookupOptions options, TypeSymbol accessThroughType)
        {
            // Normally, when we access a protected instance member, we need to know the type of the receiver so we
            // can determine whether the member is actually accessible in the containing type.  There is one exception:
            // If the receiver is "base", then it's okay if the receiver type isn't derived from the containing type.
            return ((options & LookupOptions.UseBaseReferenceAccessibility) != 0)
                ? null
                : accessThroughType;
        }

        // return the type or namespace symbol in a lookup result, or report an error.
        public virtual DeclaredSymbol ResultSymbol(
            LookupResult result,
            SyntaxNodeOrToken where,
            DiagnosticBag diagnostics,
            bool suppressUseSiteDiagnostics,
            out bool wasError)
        {
            Debug.Assert(diagnostics != null);

            var syntaxFacts = Compilation.Language.SyntaxFacts;
            var symbols = result.Symbols;
            wasError = false;

            if (result.IsMultiViable)
            {
                if (symbols.Count > 1)
                {
                    // symbols cannot conflict with using alias names
                    var imports = this.OriginalBinder?.GetImports(this.BasesBeingResolved);
                    if (imports != null && imports.IsUsingAlias(this.Name, this.OriginalBinder.IsSemanticModelBinder))
                    {
                        LanguageDiagnosticInfo diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_ConflictAliasAndMember, this.Name, this.QualifierOpt);
                        return new ExtendedErrorTypeSymbol((DeclaredSymbol)null, this.Name, this.MetadataName, diagInfo, unreported: true);
                    }

                    // gracefully handle symbols.Count > 2
                    symbols.Sort(ConsistentSymbolOrder.Instance);

                    var originalSymbols = symbols.ToImmutable();
                    var errorSymbols = StaticCast<ISymbol>.From(originalSymbols);

                    for (int i = 0; i < symbols.Count; i++)
                    {
                        symbols[i] = UnwrapAlias(symbols[i]);
                    }

                    BestSymbolInfo secondBest;
                    BestSymbolInfo best = GetBestSymbolInfo(symbols, out secondBest);

                    Debug.Assert(!best.IsNone);
                    Debug.Assert(!secondBest.IsNone);

                    if (best.IsFromCompilation && !secondBest.IsFromCompilation)
                    {
                        var srcSymbol = symbols[best.Index];
                        var mdSymbol = symbols[secondBest.Index];

                        object arg0;

                        if (best.IsFromSourceModule)
                        {
                            arg0 = srcSymbol.Locations.First().SourceTree.FilePath;
                        }
                        else
                        {
                            Debug.Assert(best.IsFromAddedModule);
                            arg0 = srcSymbol.ContainingModule;
                        }

                        //if names match, arities match, and containing symbols match (recursively), ...
                        if (srcSymbol.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat) ==
                            mdSymbol.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat))
                        {
                            if (srcSymbol.Kind == LanguageSymbolKind.Namespace && mdSymbol.Kind == LanguageSymbolKind.NamedType)
                            {
                                // InternalErrorCode.WRN_SameFullNameThisNsAgg: The namespace '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the namespace defined in '{0}'.
                                diagnostics.Add(errorSymbols, InternalErrorCode.WRN_SameFullNameThisNsAgg, where.GetLocation(),
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.ContainingAssembly,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol.Kind == LanguageSymbolKind.NamedType && mdSymbol.Kind == LanguageSymbolKind.Namespace)
                            {
                                // InternalErrorCode.WRN_SameFullNameThisAggNs: The type '{1}' in '{0}' conflicts with the imported namespace '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(errorSymbols, InternalErrorCode.WRN_SameFullNameThisAggNs, where.GetLocation(),
                                    arg0,
                                    srcSymbol,
                                    GetContainingAssembly(mdSymbol),
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol.Kind == LanguageSymbolKind.NamedType && mdSymbol.Kind == LanguageSymbolKind.NamedType)
                            {
                                // WRN_SameFullNameThisAggAgg: The type '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(errorSymbols, InternalErrorCode.WRN_SameFullNameThisAggAgg, where.GetLocation(),
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.ContainingAssembly,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else
                            {
                                // namespace would be merged with the source namespace:
                                Debug.Assert(!(srcSymbol.Kind == LanguageSymbolKind.Namespace && mdSymbol.Kind == LanguageSymbolKind.Namespace));
                            }
                        }
                    }

                    var first = symbols[best.Index];
                    var second = symbols[secondBest.Index];

                    Debug.Assert(originalSymbols[best.Index] != originalSymbols[secondBest.Index] || Options.IsAttributeTypeLookup(),
                        "This kind of ambiguity is only possible for attributes.");

                    Debug.Assert(first != second || originalSymbols[best.Index] != originalSymbols[secondBest.Index],
                        "Why does the LookupResult contain the same symbol twice?");

                    LanguageDiagnosticInfo info;
                    bool reportError;

                    //if names match, arities match, and containing symbols match (recursively), ...
                    if (first != second &&
                        first.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat) ==
                            second.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat))
                    {
                        // suppress reporting the error if we found multiple symbols from source module
                        // since an error has already been reported from the declaration
                        reportError = !(best.IsFromSourceModule && secondBest.IsFromSourceModule);

                        if (first.Kind == LanguageSymbolKind.NamedType && second.Kind == LanguageSymbolKind.NamedType)
                        {
                            if (first.OriginalDefinition == second.OriginalDefinition)
                            {
                                // We imported different generic instantiations of the same generic type
                                // and have an ambiguous reference to a type nested in it
                                reportError = true;

                                // '{0}' is an ambiguous reference between '{1}' and '{2}'
                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbigContext,
                                        syntaxFacts.ExtractErrorDisplayName(where) ?? Name,
                                        new FormattedSymbol(first, SymbolDisplayFormat.CSharpErrorMessageFormat),
                                        new FormattedSymbol(second, SymbolDisplayFormat.CSharpErrorMessageFormat));
                            }
                            else
                            {
                                Debug.Assert(!best.IsFromCorLibrary);

                                // InternalErrorCode.ERR_SameFullNameAggAgg: The type '{1}' exists in both '{0}' and '{2}'
                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_SameFullNameAggAgg, first.ContainingAssembly, first, second.ContainingAssembly);

                                // Do not report this error if the first is declared in source and the second is declared in added module,
                                // we already reported declaration error about this name collision.
                                // Do not report this error if both are declared in added modules,
                                // we will report assembly level declaration error about this name collision.
                                if (secondBest.IsFromAddedModule)
                                {
                                    Debug.Assert(best.IsFromCompilation);
                                    reportError = false;
                                }
                                else if (OriginalBinder != null && OriginalBinder.Flags.Includes(BinderFlags.IgnoreCorLibraryDuplicatedTypes) &&
                                    secondBest.IsFromCorLibrary)
                                {
                                    // Ignore duplicate types from the cor library if necessary.
                                    // (Specifically the framework assemblies loaded at runtime in
                                    // the EE may contain types also available from mscorlib.dll.)
                                    return first;
                                }
                                else if (OriginalBinder != null && OriginalBinder.Flags.Includes(BinderFlags.IgnoreMetaLibraryDuplicatedTypes) &&
                                    secondBest.IsFromMetaLibrary)
                                {
                                    // Ignore duplicate types from the cor library if necessary.
                                    // (Specifically the framework assemblies loaded at runtime in
                                    // the EE may contain types also available from mscorlib.dll.)
                                    return first;
                                }
                            }
                        }
                        else if (first.Kind == LanguageSymbolKind.Namespace && second.Kind == LanguageSymbolKind.NamedType)
                        {
                            // InternalErrorCode.ERR_SameFullNameNsAgg: The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'
                            info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_SameFullNameNsAgg, GetContainingAssembly(first), first, second.ContainingAssembly, second);

                            // Do not report this error if namespace is declared in source and the type is declared in added module,
                            // we already reported declaration error about this name collision.
                            if (best.IsFromSourceModule && secondBest.IsFromAddedModule)
                            {
                                reportError = false;
                            }
                        }
                        else if (first.Kind == LanguageSymbolKind.NamedType && second.Kind == LanguageSymbolKind.Namespace)
                        {
                            if (!secondBest.IsFromCompilation || secondBest.IsFromSourceModule)
                            {
                                // InternalErrorCode.ERR_SameFullNameNsAgg: The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'
                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_SameFullNameNsAgg, GetContainingAssembly(second), second, first.ContainingAssembly, first);
                            }
                            else
                            {
                                Debug.Assert(secondBest.IsFromAddedModule);

                                // InternalErrorCode.ERR_SameFullNameThisAggThisNs: The type '{1}' in '{0}' conflicts with the namespace '{3}' in '{2}'
                                object arg0;

                                if (best.IsFromSourceModule)
                                {
                                    arg0 = first.Locations.First().SourceTree.FilePath;
                                }
                                else
                                {
                                    Debug.Assert(best.IsFromAddedModule);
                                    arg0 = first.ContainingModule;
                                }

                                ModuleSymbol arg2 = second.ContainingModule;

                                // Merged namespaces that span multiple modules don't have a containing module,
                                // so just use module with the smallest ordinal from the containing assembly.
                                if ((object)arg2 == null)
                                {
                                    foreach (NamespaceSymbol ns in ((NamespaceSymbol)second).ConstituentNamespaces)
                                    {
                                        if (ns.ContainingAssembly == Compilation.Assembly)
                                        {
                                            ModuleSymbol module = ns.ContainingModule;

                                            if ((object)arg2 == null || arg2.Ordinal > module.Ordinal)
                                            {
                                                arg2 = module;
                                            }
                                        }
                                    }
                                }

                                Debug.Assert(arg2.ContainingAssembly == Compilation.Assembly);

                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_SameFullNameThisAggThisNs, arg0, first, arg2, second);
                            }
                        }
                        /*else if (first.Kind == SymbolKind.RangeVariable && second.Kind == SymbolKind.RangeVariable)
                        {
                            // We will already have reported a conflicting range variable declaration.
                            info = new LanguageDiagnosticInfo(InternalErrorCode.ERR_AmbigMember, originalSymbols,
                                new object[] { first, second });
                        }*/
                        else
                        {
                            // TODO: this is not an appropriate error message here, but used as a fallback until the
                            // appropriate diagnostics are implemented.
                            // '{0}' is an ambiguous reference between '{1}' and '{2}'
                            //info = diagnostics.Add(InternalErrorCode.ERR_AmbigContext, location, readOnlySymbols,
                            //    whereText,
                            //    first,
                            //    second);

                            // CS0229: Ambiguity between '{0}' and '{1}'
                            info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbigMember, first, second);

                            reportError = true;
                        }
                    }
                    else
                    {
                        Debug.Assert(originalSymbols[best.Index].Name != originalSymbols[secondBest.Index].Name ||
                                     originalSymbols[best.Index] != originalSymbols[secondBest.Index],
                            "Why was the lookup result viable if it contained non-equal symbols with the same name?");

                        reportError = true;

                        if (first is NamespaceOrTypeSymbol && second is NamespaceOrTypeSymbol)
                        {
                            if (Options.IsAttributeTypeLookup() &&
                                first.Kind == LanguageSymbolKind.NamedType &&
                                second.Kind == LanguageSymbolKind.NamedType &&
                                originalSymbols[best.Index].Name != originalSymbols[secondBest.Index].Name && // Use alias names, if available.
                                Compilation.IsAttributeType((NamedTypeSymbol)first) &&
                                Compilation.IsAttributeType((NamedTypeSymbol)second))
                            {
                                //  SPEC:   If an attribute class is found both with and without Attribute suffix, an ambiguity 
                                //  SPEC:   is present, and a compile-time error results.

                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbiguousAttribute,
                                    syntaxFacts.ExtractErrorDisplayName(where) ?? Name, first, second);
                            }
                            else
                            {
                                // '{0}' is an ambiguous reference between '{1}' and '{2}'
                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbigContext,
                                        syntaxFacts.ExtractErrorDisplayName(where) ?? Name,
                                        new FormattedSymbol(first, SymbolDisplayFormat.CSharpErrorMessageFormat),
                                        new FormattedSymbol(second, SymbolDisplayFormat.CSharpErrorMessageFormat));
                            }
                        }
                        else
                        {
                            // CS0229: Ambiguity between '{0}' and '{1}'
                            info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbigMember, first, second);
                        }
                    }

                    wasError = true;

                    if (reportError)
                    {
                        diagnostics.Add(info, where.GetLocation());
                    }

                    return new ExtendedErrorTypeSymbol(
                        GetContainingNamespaceOrType(originalSymbols[0]),
                        originalSymbols,
                        LookupResultKind.Ambiguous,
                        info,
                        MetadataName);
                }
                else
                {
                    // Single viable result.
                    var singleResult = symbols[0];

                    // Cannot reference System.Void directly.
                    var singleType = singleResult as TypeSymbol;
                    if ((object)singleType != null && singleType.PrimitiveTypeCode == Cci.PrimitiveTypeCode.Void && Name == "Void")
                    {
                        wasError = true;
                        var errorInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_SystemVoid);
                        diagnostics.Add(errorInfo, where.GetLocation());
                        singleResult = new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(singleResult), singleResult, LookupResultKind.NotReferencable, errorInfo); // UNDONE: Review resultkind.
                    }
                    // Check for bad symbol.
                    else
                    {
                        if (!suppressUseSiteDiagnostics)
                        {
                            wasError = ReportUseSiteDiagnostics(singleResult, diagnostics, where);
                        }
                        else if (singleResult.Kind == LanguageSymbolKind.ErrorType)
                        {
                            // We want to report ERR_CircularBase error on the spot to make sure 
                            // that the right location is used for it.
                            var errorType = (ErrorTypeSymbol)singleResult;

                            if (errorType.Unreported)
                            {
                                DiagnosticInfo errorInfo = errorType.ErrorInfo;

                                if (errorInfo != null && errorInfo.HasErrorCode(InternalErrorCode.ERR_CircularBase))
                                {
                                    wasError = true;
                                    diagnostics.Add(errorInfo, where.GetLocation());
                                    singleResult = new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(errorType), errorType.Name, errorType.MetadataName, errorInfo, unreported: false);
                                }
                            }
                        }
                    }

                    return singleResult;
                }
            }

            // Below here is the error case; no viable symbols found (but maybe one or more non-viable.)
            wasError = true;

            if (result.Kind == LookupResultKind.Empty)
            {
                LanguageDiagnosticInfo info = NotFound(where, Name, MetadataName, syntaxFacts.ExtractErrorDisplayName(where) ?? Name, diagnostics, aliasOpt: null, QualifierOpt, Options);
                return new ExtendedErrorTypeSymbol(QualifierOpt ?? Compilation.Assembly.GlobalNamespace, Name, MetadataName, info);
            }

            Debug.Assert(symbols.Count > 0);

            // Report any errors we encountered with the symbol we looked up.
            if (!suppressUseSiteDiagnostics)
            {
                for (int i = 0; i < symbols.Count; i++)
                {
                    ReportUseSiteDiagnostics(symbols[i], diagnostics, where);
                }
            }

            // result.Error might be null if we have already generated parser errors,
            // e.g. when generic name is used for attribute name.
            if (result.Error != null &&
                ((object)QualifierOpt == null || QualifierOpt.Kind != LanguageSymbolKind.ErrorType)) // Suppress cascading.
            {
                diagnostics.Add(result.Error, where.GetLocation());
            }

            if ((symbols.Count > 1) || (symbols[0] is NamespaceOrTypeSymbol || symbols[0] is AliasSymbol) ||
                result.Kind == LookupResultKind.NotATypeOrNamespace || result.Kind == LookupResultKind.NotAnAttributeType)
            {
                // Bad type or namespace (or things expected as types/namespaces) are packaged up as error types, preserving the symbols and the result kind.
                // We do this if there are multiple symbols too, because just returning one would be losing important information, and they might
                // be of different kinds.
                return new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(symbols[0]), symbols.ToImmutable(), result.Kind, result.Error, MetadataName);
            }
            else
            {
                // It's a single non-type-or-namespace; error was already reported, so just return it.
                return symbols[0];
            }
        }

        /// <summary>
        /// The immediately containing namespace or named type, or the global
        /// namespace if containing symbol is neither a namespace or named type.
        /// </summary>
        private NamespaceOrTypeSymbol GetContainingNamespaceOrType(Symbol symbol)
        {
            return symbol.ContainingNamespaceOrType() ?? this.Compilation.Assembly.GlobalNamespace;
        }

        /// <remarks>
        /// This is only intended to be called when the type isn't found (i.e. not when it is found but is inaccessible, has the wrong arity, etc).
        /// </remarks>
        protected LanguageDiagnosticInfo NotFound(SyntaxNodeOrToken where, string simpleName, string metadataName, string whereText, DiagnosticBag diagnostics, SyntaxNodeOrToken aliasOpt, DeclaredSymbol declaredSymbolQualifierOpt, LookupOptions options)
        {
            var syntaxFacts = Compilation.Language.SyntaxFacts;
            var location = where.GetLocation();
            var qualifierOpt = declaredSymbolQualifierOpt as NamespaceOrTypeSymbol;
            // Lookup totally ignores type forwarders, but we want the type lookup diagnostics
            // to distinguish between a type that can't be found and a type that is only present
            // as a type forwarder.  We'll look for type forwarders in the containing and
            // referenced assemblies and report more specific diagnostics if they are found.
            AssemblySymbol forwardedToAssembly;

            // for attributes, suggest both, but not for verbatim name
            if (options.IsAttributeTypeLookup() && !options.IsVerbatimNameAttributeTypeLookup())
            {
                // just recurse one level, so cheat and OR verbatim name option :)
                NotFound(where, simpleName, metadataName, whereText + "Attribute", diagnostics, aliasOpt, qualifierOpt, options | LookupOptions.VerbatimNameAttributeTypeOnly);
            }

            if ((object)qualifierOpt != null)
            {
                if (qualifierOpt.IsType)
                {
                    var errorQualifier = qualifierOpt as ErrorTypeSymbol;
                    if ((object)errorQualifier != null && errorQualifier.ErrorInfo != null)
                    {
                        return (LanguageDiagnosticInfo)errorQualifier.ErrorInfo;
                    }

                    return diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInAgg, location, whereText, qualifierOpt);
                }
                else
                {
                    Debug.Assert(qualifierOpt.IsNamespace);

                    forwardedToAssembly = GetForwardedToAssembly(simpleName, metadataName, ref qualifierOpt, diagnostics, location);

                    if (ReferenceEquals(qualifierOpt, Compilation.GlobalNamespace))
                    {
                        Debug.Assert(aliasOpt == null || syntaxFacts.IsGlobalAlias(aliasOpt));
                        return (object)forwardedToAssembly == null
                            ? diagnostics.Add(InternalErrorCode.ERR_GlobalSingleTypeNameNotFound, location, whereText, qualifierOpt)
                            : diagnostics.Add(InternalErrorCode.ERR_GlobalSingleTypeNameNotFoundFwd, location, whereText, forwardedToAssembly);
                    }
                    else
                    {
                        object container = qualifierOpt;

                        // If there was an alias (e.g. A::C) and the given qualifier is the global namespace of the alias,
                        // then use the alias name in the error message, since it's more helpful than "<global namespace>".
                        if (aliasOpt != null && qualifierOpt.IsNamespace && ((NamespaceSymbol)qualifierOpt).IsGlobalNamespace)
                        {
                            container = aliasOpt;
                        }

                        return (object)forwardedToAssembly == null
                            ? diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInNS, location, whereText, container)
                            : diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInNSFwd, location, whereText, container, forwardedToAssembly);
                    }
                }
            }

            if (options == LookupOptions.NamespaceAliasesOnly)
            {
                return diagnostics.Add(InternalErrorCode.ERR_AliasNotFound, location, whereText);
            }

            if (syntaxFacts.IsVarTypeDeclaration(where))
            {
                var code = InternalErrorCode.ERR_TypeVarNotFound;
                return diagnostics.Add(code, location);
            }

            forwardedToAssembly = GetForwardedToAssembly(simpleName, metadataName, ref qualifierOpt, diagnostics, location);

            if ((object)forwardedToAssembly != null)
            {
                return qualifierOpt == null
                    ? diagnostics.Add(InternalErrorCode.ERR_SingleTypeNameNotFoundFwd, location, whereText, forwardedToAssembly)
                    : diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInNSFwd, location, whereText, qualifierOpt, forwardedToAssembly);
            }

            return diagnostics.Add(InternalErrorCode.ERR_SingleTypeNameNotFound, location, whereText);
        }

        protected virtual AssemblySymbol GetForwardedToAssemblyInUsingNamespaces(string metadataName, ref NamespaceOrTypeSymbol qualifierOpt, DiagnosticBag diagnostics, Location location)
        {
            return null;
        }

        protected AssemblySymbol GetForwardedToAssembly(string fullName, DiagnosticBag diagnostics, Location location)
        {
            var metadataName = MetadataTypeName.FromFullName(fullName);
            foreach (var referencedAssembly in
                Compilation.Assembly.Modules[0].ReferencedAssemblySymbols)
            {
                var forwardedType =
                    referencedAssembly.TryLookupForwardedMetadataType(ref metadataName);
                if ((object)forwardedType != null)
                {
                    if (forwardedType.Kind == LanguageSymbolKind.ErrorType)
                    {
                        DiagnosticInfo diagInfo = ((ErrorTypeSymbol)forwardedType).ErrorInfo;

                        if (diagInfo.HasErrorCode(InternalErrorCode.ERR_CycleInTypeForwarder))
                        {
                            Debug.Assert((object)forwardedType.ContainingAssembly != null, "How did we find a cycle if there was no forwarding?");
                            diagnostics.Add(InternalErrorCode.ERR_CycleInTypeForwarder, location, fullName, forwardedType.ContainingAssembly.Name);
                        }
                        else if (diagInfo.HasErrorCode(InternalErrorCode.ERR_TypeForwardedToMultipleAssemblies))
                        {
                            diagnostics.Add(diagInfo, location);
                            return null; // Cannot determine a suitable forwarding assembly
                        }
                    }

                    return forwardedType.ContainingAssembly;
                }
            }

            return null;
        }

        /// <summary>
        /// Look for a type forwarder for the given type in the containing assembly and any referenced assemblies.
        /// </summary>
        /// <param name="name">The name of the (potentially) forwarded type.</param>
        /// <param name="arity">The arity of the forwarded type.</param>
        /// <param name="qualifierOpt">The namespace of the potentially forwarded type. If none is provided, will
        /// try Usings of the current import for eligible namespaces and return the namespace of the found forwarder, 
        /// if any.</param>
        /// <param name="diagnostics">Will be used to report non-fatal errors during look up.</param>
        /// <param name="location">Location to report errors on.</param>
        /// <returns>Returns the Assembly to which the type is forwarded, or null if none is found.</returns>
        /// <remarks>
        /// Since this method is intended to be used for error reporting, it stops as soon as it finds
        /// any type forwarder (or an error to report). It does not check other assemblies for consistency or better results.
        /// </remarks>
        protected AssemblySymbol GetForwardedToAssembly(string name, string metadataName, ref NamespaceOrTypeSymbol qualifierOpt, DiagnosticBag diagnostics, Location location)
        {
            // If we are in the process of binding assembly level attributes, we might get into an infinite cycle
            // if any of the referenced assemblies forwards type to this assembly. Since forwarded types
            // are specified through assembly level attributes, an attempt to resolve the forwarded type
            // might require us to examine types forwarded by this assembly, thus binding assembly level 
            // attributes again. And the cycle continues. 
            // So, we won't do the analysis in this case, at the expense of better diagnostics.

            /* TODO:MetaDslx
            if ((this.Flags & BinderFlags.InContextualAttributeBinder) != 0)
            {
                var current = this;

                do
                {
                    var contextualAttributeBinder = current as ContextualAttributeBinder;

                    if (contextualAttributeBinder != null)
                    {
                        if ((object)contextualAttributeBinder.AttributeTarget != null &&
                            contextualAttributeBinder.AttributeTarget.Kind == SymbolKind.Assembly)
                        {
                            return null;
                        }

                        break;
                    }

                    current = current.Next;
                }
                while (current != null);
            }*/

            // NOTE: This won't work if the type isn't using CLS-style generic naming (i.e. `arity), but this code is
            // only intended to improve diagnostic messages, so false negatives in corner cases aren't a big deal.
            var fullMetadataName = MetadataHelpers.BuildQualifiedName(qualifierOpt?.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat), metadataName);
            var result = GetForwardedToAssembly(fullMetadataName, diagnostics, location);
            if ((object)result != null)
            {
                return result;
            }

            if ((object)qualifierOpt == null)
            {
                return GetForwardedToAssemblyInUsingNamespaces(metadataName, ref qualifierOpt, diagnostics, location);
            }

            return null;
        }

        private static AssemblySymbol GetContainingAssembly(Symbol symbol)
        {
            // Merged namespaces that span multiple assemblies don't have a containing assembly,
            // so just use the containing assembly of the first constituent.
            return symbol.ContainingAssembly ?? ((NamespaceSymbol)symbol).ConstituentNamespaces.First().ContainingAssembly;
        }

        [Flags]
        private enum BestSymbolLocation
        {
            None,
            FromSourceModule,
            FromAddedModule,
            FromReferencedAssembly,
            FromCorLibrary,
            FromMetaLibrary
        }

        [DebuggerDisplay("Location = {_location}, Index = {_index}")]
        private struct BestSymbolInfo
        {
            private readonly BestSymbolLocation _location;
            private readonly int _index;

            /// <summary>
            /// Returns -1 if None.
            /// </summary>
            public int Index
            {
                get
                {
                    return IsNone ? -1 : _index;
                }
            }

            public bool IsFromSourceModule
            {
                get
                {
                    return _location == BestSymbolLocation.FromSourceModule;
                }
            }

            public bool IsFromAddedModule
            {
                get
                {
                    return _location == BestSymbolLocation.FromAddedModule;
                }
            }

            public bool IsFromMetaLibrary
            {
                get
                {
                    return _location == BestSymbolLocation.FromMetaLibrary;
                }
            }

            public bool IsFromCompilation
            {
                get
                {
                    return (_location == BestSymbolLocation.FromSourceModule) || (_location == BestSymbolLocation.FromAddedModule) || (_location == BestSymbolLocation.FromMetaLibrary);
                }
            }

            public bool IsNone
            {
                get
                {
                    return _location == BestSymbolLocation.None;
                }
            }

            public bool IsFromCorLibrary
            {
                get
                {
                    return _location == BestSymbolLocation.FromCorLibrary;
                }
            }

            public BestSymbolInfo(BestSymbolLocation location, int index)
            {
                Debug.Assert(location != BestSymbolLocation.None);
                _location = location;
                _index = index;
            }

            /// <summary>
            /// Prefers symbols from source module, then from added modules, then from referenced assemblies.
            /// Returns true if values were swapped.
            /// </summary>
            public static bool Sort(ref BestSymbolInfo first, ref BestSymbolInfo second)
            {
                if (IsSecondLocationBetter(first._location, second._location))
                {
                    BestSymbolInfo temp = first;
                    first = second;
                    second = temp;
                    return true;
                }

                return false;
            }

            /// <summary>
            /// Returns true if the second is a better location than the first.
            /// </summary>
            public static bool IsSecondLocationBetter(BestSymbolLocation firstLocation, BestSymbolLocation secondLocation)
            {
                Debug.Assert(secondLocation != 0);
                return (firstLocation == BestSymbolLocation.None) || (firstLocation > secondLocation);
            }
        }

        /// <summary>
        /// Prefer symbols from source module, then from added modules, then from referenced assemblies.
        /// </summary>
        private BestSymbolInfo GetBestSymbolInfo(ArrayBuilder<DeclaredSymbol> symbols, out BestSymbolInfo secondBest)
        {
            BestSymbolInfo first = default(BestSymbolInfo);
            BestSymbolInfo second = default(BestSymbolInfo);

            for (int i = 0; i < symbols.Count; i++)
            {
                var symbol = symbols[i];
                BestSymbolLocation location;

                if (symbol.Kind == LanguageSymbolKind.Namespace)
                {
                    location = BestSymbolLocation.None;
                    foreach (var ns in ((NamespaceSymbol)symbol).ConstituentNamespaces)
                    {
                        var current = GetLocation(Compilation, ns);
                        if (BestSymbolInfo.IsSecondLocationBetter(location, current))
                        {
                            location = current;
                            if (location == BestSymbolLocation.FromSourceModule)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    location = GetLocation(Compilation, symbol);
                }

                var third = new BestSymbolInfo(location, i);
                if (BestSymbolInfo.Sort(ref second, ref third))
                {
                    BestSymbolInfo.Sort(ref first, ref second);
                }
            }

            Debug.Assert(!first.IsNone);
            Debug.Assert(!second.IsNone);

            secondBest = second;
            return first;
        }

        private static BestSymbolLocation GetLocation(LanguageCompilation compilation, Symbol symbol)
        {
            var containingAssembly = symbol.ContainingAssembly;
            if (containingAssembly == compilation.SourceAssembly)
            {
                return (symbol.ContainingModule == compilation.SourceModule) ?
                    BestSymbolLocation.FromSourceModule :
                    symbol.Language.SymbolFacts.ContainsObject(MetaInstance.MModel, (symbol as IModelSymbol).ModelObject) ?
                    BestSymbolLocation.FromMetaLibrary :
                    BestSymbolLocation.FromAddedModule;
            }
            else
            {
                return (containingAssembly == containingAssembly.CorLibrary) ?
                    BestSymbolLocation.FromCorLibrary :
                    BestSymbolLocation.FromReferencedAssembly;
            }
        }

        /// <summary>
        /// Reports use-site diagnostics for the specified symbol.
        /// </summary>
        /// <returns>
        /// True if there was an error among the reported diagnostics
        /// </returns>
        internal static bool ReportUseSiteDiagnostics(Symbol symbol, DiagnosticBag diagnostics, SyntaxNode node)
        {
            DiagnosticInfo info = symbol.GetUseSiteDiagnostic();
            return info != null && Symbol.ReportUseSiteDiagnostic(info, diagnostics, node.Location);
        }

        internal static bool ReportUseSiteDiagnostics(Symbol symbol, DiagnosticBag diagnostics, SyntaxToken token)
        {
            DiagnosticInfo info = symbol.GetUseSiteDiagnostic();
            return info != null && Symbol.ReportUseSiteDiagnostic(info, diagnostics, token.GetLocation());
        }

        internal static bool ReportUseSiteDiagnostics(Symbol symbol, DiagnosticBag diagnostics, SyntaxNodeOrToken nodeOrToken)
        {
            DiagnosticInfo info = symbol.GetUseSiteDiagnostic();
            return info != null && Symbol.ReportUseSiteDiagnostic(info, diagnostics, nodeOrToken.GetLocation());
        }

        /// <summary>
        /// Reports use-site diagnostics for the specified symbol.
        /// </summary>
        /// <returns>
        /// True if there was an error among the reported diagnostics
        /// </returns>
        internal static bool ReportUseSiteDiagnostics(Symbol symbol, DiagnosticBag diagnostics, Location location)
        {
            DiagnosticInfo info = symbol.GetUseSiteDiagnostic();
            return info != null && Symbol.ReportUseSiteDiagnostic(info, diagnostics, location);
        }

        private class ConsistentSymbolOrder : IComparer<Symbol>
        {
            public static readonly ConsistentSymbolOrder Instance = new ConsistentSymbolOrder();
            public int Compare(Symbol fst, Symbol snd)
            {
                if (snd == fst) return 0;
                if ((object)fst == null) return -1;
                if ((object)snd == null) return 1;
                if (snd.Name != fst.Name) return string.CompareOrdinal(fst.Name, snd.Name);
                if (snd.Kind != fst.Kind) return (int)fst.Kind - (int)snd.Kind;
                int aLocationsCount = !snd.Locations.IsDefault ? snd.Locations.Length : 0;
                int bLocationsCount = fst.Locations.Length;
                if (aLocationsCount != bLocationsCount) return aLocationsCount - bLocationsCount;
                if (aLocationsCount == 0 && bLocationsCount == 0) return Compare(fst.ContainingSymbol, snd.ContainingSymbol);
                Location la = snd.Locations[0];
                Location lb = fst.Locations[0];
                if (la.IsInSource != lb.IsInSource) return la.IsInSource ? 1 : -1;
                int containerResult = Compare(fst.ContainingSymbol, snd.ContainingSymbol);
                if (!la.IsInSource) return containerResult;
                if (containerResult == 0 && la.SourceTree == lb.SourceTree) return lb.SourceSpan.Start - la.SourceSpan.Start;
                return containerResult;
            }
        }
    }
}

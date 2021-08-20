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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.CodeAnalysis.Symbols.Internal;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class LookupConstraints
    {
        private readonly string[] _viableNames;
        public readonly Binder OriginalBinder;
        public readonly DeclaredSymbol? QualifierOpt;
        public readonly string? Name;
        public readonly string? MetadataName;
        public readonly string? AutomaticNamePrefix;
        public readonly string? AutomaticNameSuffix;
        public readonly ImmutableArray<ILookupValidator> Validators;
        public readonly ConsList<TypeSymbol>? BasesBeingResolved;
        public readonly TypeSymbol? AccessThroughType;
        public readonly bool Diagnose;
        public readonly bool InUsing;
        public readonly bool IsLookup;

        public LookupConstraints(
            Binder originalBinder,
            string? name = null,
            string? metadataName = null,
            DeclaredSymbol? qualifierOpt = null,
            string? automaticNamePrefix = null,
            string? automaticNameSuffix = null,
            ImmutableArray<ILookupValidator> validators = default,
            ConsList<TypeSymbol>? basesBeingResolved = null,
            TypeSymbol? accessThroughType = null,
            bool diagnose = true,
            bool inUsing = false,
            bool isLookup = false)
        {
            OriginalBinder = originalBinder;
            QualifierOpt = qualifierOpt;
            Name = name;
            MetadataName = metadataName;
            AutomaticNamePrefix = automaticNamePrefix;
            AutomaticNameSuffix = automaticNameSuffix;
            Validators = validators.IsDefault ? ImmutableArray<ILookupValidator>.Empty : validators;
            BasesBeingResolved = basesBeingResolved;
            AccessThroughType = accessThroughType;
            Diagnose = diagnose;
            InUsing = inUsing;
            IsLookup = isLookup;
            if (this.Name != null && this.IsAutomaticNameLookup)
            {
                if (this.AutomaticNamePrefix != null && this.AutomaticNameSuffix != null)
                {
                    _viableNames = new string[] { this.Name, this.AutomaticNamePrefix + this.Name, this.Name + this.AutomaticNameSuffix, this.AutomaticNamePrefix + this.Name + this.AutomaticNameSuffix };
                }
                else if (this.AutomaticNamePrefix != null)
                {
                    _viableNames = new string[] { this.Name, this.AutomaticNamePrefix + this.Name };
                }
                else if (this.AutomaticNameSuffix != null)
                {
                    _viableNames = new string[] { this.Name, this.Name + this.AutomaticNameSuffix };
                }
            }
        }

        protected virtual LookupConstraints Update(
            Binder originalBinder,
            string name,
            string metadataName,
            DeclaredSymbol qualifierOpt,
            string automaticNamePrefix,
            string automaticNameSuffix,
            ImmutableArray<ILookupValidator> validators,
            ConsList<TypeSymbol> basesBeingResolved,
            TypeSymbol accessThroughType,
            bool diagnose,
            bool inUsing,
            bool isLookup)
        {
            if (!ReferenceEquals(originalBinder, this.OriginalBinder)
                || name != this.Name || metadataName != this.MetadataName
                || !ReferenceEquals(qualifierOpt, this.QualifierOpt)
                || validators != this.Validators
                || automaticNamePrefix != this.AutomaticNamePrefix || automaticNameSuffix != this.AutomaticNameSuffix
                || !ReferenceEquals(basesBeingResolved, this.BasesBeingResolved)
                || !ReferenceEquals(accessThroughType, this.AccessThroughType)
                || diagnose != this.Diagnose
                || inUsing != this.InUsing
                || isLookup != this.IsLookup)
            {
                return new LookupConstraints(originalBinder, name, metadataName, qualifierOpt, automaticNamePrefix, automaticNameSuffix, validators, basesBeingResolved, accessThroughType, diagnose, inUsing, isLookup);
            }
            return this;
        }

        public LookupConstraints WithQualifier(DeclaredSymbol qualifierOpt)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, qualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithName(string name, string metadataName = null)
        {
            return Update(this.OriginalBinder, name, metadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithAutomaticName(string namePrefix, string nameSuffix)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, namePrefix, nameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithOriginalBinder(Binder originalBinder)
        {
            return Update(originalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithAccessThroughType(TypeSymbol accessThroughType)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, accessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithQualifierAndAccessThroughType(NamespaceOrTypeSymbol qualifierOpt, TypeSymbol accessThroughType)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, qualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, accessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithAdditionalValidators(params ILookupValidator[] validators)
        {
            var newValidators = this.Validators;
            foreach (var validator in validators)
            {
                if (!newValidators.Contains(validator))
                {
                    newValidators = newValidators.Add(validator);
                }
            }
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, newValidators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints ClearValidators()
        {
            if (this.Validators.IsDefaultOrEmpty) return this;
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, default, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithDiagnose(bool diagnose)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, diagnose, this.InUsing, this.IsLookup);
        }

        public LookupConstraints WithInUsing(bool inUsing)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, inUsing, this.IsLookup);
        }

        public LookupConstraints WithIsLookup(bool isLookup)
        {
            return Update(this.OriginalBinder, this.Name, this.MetadataName, this.QualifierOpt, this.AutomaticNamePrefix, this.AutomaticNameSuffix, this.Validators, this.BasesBeingResolved, this.AccessThroughType, this.Diagnose, this.InUsing, isLookup);
        }

        public LanguageCompilation Compilation => this.OriginalBinder.Compilation;
        public SymbolFactory SymbolFactory => Compilation.SourceModule.SymbolFactory;
        public SyntaxNodeOrToken Syntax => this.OriginalBinder.Syntax;

        public virtual bool AreValid()
        {
            return true;
        }

        public bool IsMemberLookup
        {
            get { return (object)this.QualifierOpt != null; }
        }

        public bool IsAutomaticNameLookup
        {
            get { return this.AutomaticNamePrefix != null || this.AutomaticNameSuffix != null; }
        }

        public static DeclaredSymbol UnwrapAlias(DeclaredSymbol symbol, LookupConstraints recursionConstraint)
        {
            if (symbol is AliasSymbol aliasSymbol)
            {
                return aliasSymbol.GetAliasTarget(recursionConstraint);
            }
            return symbol;
        }

        public virtual bool IsViable(DeclaredSymbol symbol)
        {
            if (symbol == null) return false;
            if (this.IsAutomaticNameLookup)
            {
                if (!_viableNames.Contains(symbol.Name)) return false;
            }
            else
            {
                if (symbol.Name != this.Name) return false;
            }
            if (this.MetadataName != null && symbol.MetadataName != this.MetadataName) return false;
            if (!this.Validators.IsDefaultOrEmpty)
            {
                foreach (var validator in this.Validators)
                {
                    if (!validator.IsViable(symbol, this)) return false;
                }
            }
            return true;
        }

        public virtual SingleLookupResult CheckSingleResultViability(DeclaredSymbol symbol)
        {
            // General pattern: checks and diagnostics refer to unwrapped symbol,
            // but lookup results refer to symbol.

            var unwrappedSymbol = UnwrapAlias(symbol, this);
            var result = LookupResult.Good(unwrappedSymbol);
            if (!this.Validators.IsDefaultOrEmpty)
            {
                foreach (var validator in this.Validators)
                {
                    result = validator.CheckSingleResultViability(result, symbol as AliasSymbol, this);
                    if (result.Kind != LookupResultKind.Viable) return result;
                }
            }
            return result;
        }


        public virtual void CheckFinalResultViability(LookupResult result)
        {
            if (!this.Validators.IsDefaultOrEmpty)
            {
                foreach (var validator in this.Validators)
                {
                    validator.CheckFinalResultViability(result, this);
                    if (!result.IsMultiViable) return;
                }
            }
        }

        // Merge resultHidden into resultHiding, whereby viable results in resultHiding should hide results
        // in resultHidden if the owner of the symbol in resultHiding is a subtype of the owner of the symbol
        // in resultHidden.
        public void MergeHidingLookupCandidates(LookupCandidates resultHiding, LookupCandidates resultHidden)
        {
            // Methods hide non-methods, non-methods hide everything.

            if (!resultHiding.IsClear && !resultHidden.IsClear)
            {
                // Check if resultHiding has any non-methods. If so, it hides everything in resultHidden.
                var hidingSymbols = resultHiding.Symbols;
                var hiddenSymbols = resultHidden.Symbols;
                foreach (var sym in hiddenSymbols.ToList())
                {
                    var hiddenContainer = sym.ContainingType;

                    // see if sym is hidden
                    bool symIsHidden = false;
                    foreach (var hidingSym in hidingSymbols)
                    {
                        var hiddenIsSystemObject = hiddenContainer.IsSpecialSymbol(SpecialType.System_Object);
                        var hidingContainer = hidingSym.ContainingType;
                        if (!IsDerivedType(baseType: hiddenContainer, derivedType: hidingContainer, useSiteDiagnostics: resultHiding.UseSiteDiagnostics) &&
                            (hiddenContainer == null || !hiddenIsSystemObject))
                        {
                            continue; // not in inheritance relationship, so it cannot hide
                        }

                        if (HidesSymbol(hidingSym, sym))
                        {
                            symIsHidden = true;
                            break;
                        }

                        // Note: We do not implement hiding by signature in non-interfaces here; that is handled later in overload lookup.
                    }

                    if (!symIsHidden) hidingSymbols.Add(sym); // not hidden
                }
            }
            else
            {
                resultHiding.Merge(resultHidden);
            }
        }

        public virtual bool HidesSymbol(DeclaredSymbol hidingSymbol, DeclaredSymbol hiddenSymbol)
        {
            if (hiddenSymbol.Name != hidingSymbol.Name) return false;
            if (hiddenSymbol is IModelSymbol hiddenModelSymbol && hidingSymbol is IModelSymbol hidingModelSymbol)
            {
                return hiddenModelSymbol.ModelObjectType == hidingModelSymbol.ModelObjectType;
            }
            else
            {
                return false;
            }
        }

        private static bool IsDerivedType(NamedTypeSymbol baseType, NamedTypeSymbol derivedType, HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (TypeSymbol.Equals(baseType, derivedType, TypeCompareKind.ConsiderEverything2)) return false;
            foreach (var b in derivedType.AllBaseTypesWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics))
            {
                if (TypeSymbol.Equals(b, baseType, TypeCompareKind.ConsiderEverything2)) return true;
            }
            return derivedType.AllBaseTypesWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics).Contains(baseType);
        }

        // return the type or namespace symbol in a lookup result, or report an error.
        public virtual DeclaredSymbol ResultSymbol(
            LookupResult result,
            DiagnosticBag diagnostics,
            bool suppressUseSiteDiagnostics,
            out bool wasError)
        {
            Debug.Assert(diagnostics != null);

            CheckFinalResultViability(result);

            var syntaxFacts = Compilation.Language.SyntaxFacts;
            var symbols = result.Symbols;
            var where = this.Syntax;
            wasError = false;

            if (result.IsMultiViable)
            {
                if (symbols.Count > 1)
                {
                    // gracefully handle symbols.Count > 2
                    symbols.Sort(ConsistentSymbolOrder.Instance);

                    var originalSymbols = symbols.ToImmutable();
                    var errorSymbols = StaticCast<Symbol>.From(originalSymbols);

                    for (int i = 0; i < symbols.Count; i++)
                    {
                        symbols[i] = UnwrapAlias(symbols[i], this);
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
                            if (srcSymbol is NamespaceSymbol && mdSymbol is NamedTypeSymbol)
                            {
                                // InternalErrorCode.WRN_SameFullNameThisNsAgg: The namespace '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the namespace defined in '{0}'.
                                diagnostics.Add(errorSymbols, InternalErrorCode.WRN_SameFullNameThisNsAgg, where.GetLocation(),
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.ContainingAssembly,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol is NamedTypeSymbol && mdSymbol is NamespaceSymbol)
                            {
                                // InternalErrorCode.WRN_SameFullNameThisAggNs: The type '{1}' in '{0}' conflicts with the imported namespace '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(errorSymbols, InternalErrorCode.WRN_SameFullNameThisAggNs, where.GetLocation(),
                                    arg0,
                                    srcSymbol,
                                    GetContainingAssembly(mdSymbol),
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol is NamedTypeSymbol && mdSymbol is NamedTypeSymbol)
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
                                Debug.Assert(!(srcSymbol is NamespaceSymbol && mdSymbol is NamespaceSymbol));
                            }
                        }
                    }

                    var first = symbols[best.Index];
                    var second = symbols[secondBest.Index];

                    Debug.Assert(originalSymbols[best.Index] != originalSymbols[secondBest.Index] || this.IsAutomaticNameLookup,
                        "This kind of ambiguity is only possible for automatic name lookup.");

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

                        if (first is NamedTypeSymbol && second is NamedTypeSymbol)
                        {
                            if (first.OriginalDefinition == second.OriginalDefinition)
                            {
                                // We imported different generic instantiations of the same generic type
                                // and have an ambiguous reference to a type nested in it
                                reportError = true;

                                // '{0}' is an ambiguous reference between '{1}' and '{2}'
                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbigContext, this.Name, first.QualifiedName, second.QualifiedName);
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
                        else if (first is NamespaceSymbol && second is NamedTypeSymbol)
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
                        else if (first is NamedTypeSymbol && second is NamespaceSymbol)
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
                            if (this.IsAutomaticNameLookup &&
                                first is NamedTypeSymbol &&
                                second is NamedTypeSymbol &&
                                originalSymbols[best.Index].Name != originalSymbols[secondBest.Index].Name && // Use alias names, if available.
                                Compilation.IsAttributeType((NamedTypeSymbol)first) &&
                                Compilation.IsAttributeType((NamedTypeSymbol)second))
                            {
                                //  SPEC:   If an attribute class is found both with and without Attribute suffix, an ambiguity 
                                //  SPEC:   is present, and a compile-time error results.

                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbiguousAttribute,
                                    this.Name, first, second);
                            }
                            else
                            {
                                // '{0}' is an ambiguous reference between '{1}' and '{2}'
                                info = new SymbolDiagnosticInfo(errorSymbols, InternalErrorCode.ERR_AmbigContext, this.Name, first.QualifiedName, second.QualifiedName);
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

                    return this.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>(GetContainingDeclaration(originalSymbols[0]), Name, MetadataName, ErrorKind.Ambiguous, info, originalSymbols.Cast<DeclaredSymbol, Symbol>());
                }
                else
                {
                    // Single viable result.
                    var singleResult = symbols[0];

                    // Cannot reference System.Void directly.
                    var singleType = singleResult as TypeSymbol;
                    if ((object)singleType != null && singleType.PrimitiveTypeCode == Microsoft.Cci.PrimitiveTypeCode.Void && Name == "Void")
                    {
                        wasError = true;
                        var errorInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_SystemVoid);
                        diagnostics.Add(errorInfo, where.GetLocation());
                        singleResult = this.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>(GetContainingDeclaration(singleResult), Name, MetadataName, ErrorKind.Invalid, errorInfo, ImmutableArray.Create<Symbol>(singleResult));
                    }
                    // Check for bad symbol.
                    else
                    {
                        if (!suppressUseSiteDiagnostics)
                        {
                            wasError = ReportUseSiteDiagnostics(singleResult, diagnostics, where);
                        }
                        else if (singleResult.IsError)
                        {
                            // We want to report ERR_CircularBase error on the spot to make sure 
                            // that the right location is used for it.
                            var errorType = singleResult as IErrorSymbol;

                            if (errorType.IsUnreported)
                            {
                                DiagnosticInfo errorInfo = errorType.ErrorInfo;

                                if (errorInfo != null && errorInfo.HasErrorCode(InternalErrorCode.ERR_CircularBase))
                                {
                                    wasError = true;
                                    diagnostics.Add(errorInfo, where.GetLocation());
                                    singleResult = (DeclaredSymbol)errorType.AsReported();
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
                LanguageDiagnosticInfo info = NotFound(Name, this.AutomaticNamePrefix, this.AutomaticNameSuffix, diagnostics);
                return this.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>(QualifierOpt ?? Compilation.Assembly.GlobalNamespace, Name, MetadataName, ErrorKind.Missing, errorInfo: info);
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
                ((object)QualifierOpt == null || !QualifierOpt.IsError)) // Suppress cascading.
            {
                diagnostics.Add(result.Error, where.GetLocation());
            }

            if ((symbols.Count > 1) || (symbols[0] is NamespaceOrTypeSymbol || symbols[0] is AliasSymbol) ||
                result.Kind == LookupResultKind.NotATypeOrNamespace || result.Kind == LookupResultKind.NotAnAttributeType)
            {
                // Bad type or namespace (or things expected as types/namespaces) are packaged up as error types, preserving the symbols and the result kind.
                // We do this if there are multiple symbols too, because just returning one would be losing important information, and they might
                // be of different kinds.
                return this.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>(GetContainingDeclaration(symbols[0]), result.Kind.ToErrorKind(), result.Error);
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
        private DeclaredSymbol GetContainingDeclaration(Symbol symbol)
        {
            return symbol.ContainingDeclaration ?? this.Compilation.Assembly.GlobalNamespace;
        }

        /// <remarks>
        /// This is only intended to be called when the type isn't found (i.e. not when it is found but is inaccessible, has the wrong arity, etc).
        /// </remarks>
        protected LanguageDiagnosticInfo NotFound(string whereText, string prefix, string suffix, DiagnosticBag diagnostics)
        {
            SyntaxNodeOrToken aliasOpt = null; // TODO:MetaDslx
            var where = this.Syntax;
            var syntaxFacts = Compilation.Language.SyntaxFacts;
            var location = where.GetLocation();
            var qualifierOpt = this.QualifierOpt as NamespaceOrTypeSymbol;
            // Lookup totally ignores type forwarders, but we want the type lookup diagnostics
            // to distinguish between a type that can't be found and a type that is only present
            // as a type forwarder.  We'll look for type forwarders in the containing and
            // referenced assemblies and report more specific diagnostics if they are found.
            AssemblySymbol forwardedToAssembly;

            // for attributes, suggest both, but not for verbatim name
            if (this.IsAutomaticNameLookup)
            {
                if (!string.IsNullOrEmpty(prefix))
                {
                    // just recurse one level, so cheat and OR verbatim name option :)
                    NotFound(prefix + whereText, null, suffix, diagnostics);
                }
                if (!string.IsNullOrEmpty(suffix))
                {
                    // just recurse one level, so cheat and OR verbatim name option :)
                    NotFound(whereText + suffix, null, null, diagnostics);
                }
            }

            if ((object)qualifierOpt != null)
            {
                if (qualifierOpt is TypeSymbol)
                {
                    if (qualifierOpt is IErrorSymbol errorQualifier && errorQualifier.ErrorInfo != null)
                    {
                        return (LanguageDiagnosticInfo)errorQualifier.ErrorInfo;
                    }

                    return diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInAgg, location, whereText, qualifierOpt);
                }
                else
                {
                    Debug.Assert(qualifierOpt is NamespaceSymbol);

                    forwardedToAssembly = GetForwardedToAssembly(Name, MetadataName, ref qualifierOpt, diagnostics, location);

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
                        if (aliasOpt != null && qualifierOpt is NamespaceSymbol qualifierNs && qualifierNs.IsGlobalNamespace)
                        {
                            container = aliasOpt;
                        }

                        return (object)forwardedToAssembly == null
                            ? diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInNS, location, whereText, container)
                            : diagnostics.Add(InternalErrorCode.ERR_DottedTypeNameNotFoundInNSFwd, location, whereText, container, forwardedToAssembly);
                    }
                }
            }

            /*if (options == LookupOptions.NamespaceAliasesOnly)
            {
                return diagnostics.Add(InternalErrorCode.ERR_AliasNotFound, location, whereText);
            }*/

            if (syntaxFacts.IsVarTypeDeclaration(where))
            {
                var code = InternalErrorCode.ERR_TypeVarNotFound;
                return diagnostics.Add(code, location);
            }

            forwardedToAssembly = GetForwardedToAssembly(Name, MetadataName, ref qualifierOpt, diagnostics, location);

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
                    if (forwardedType.IsError)
                    {
                        DiagnosticInfo diagInfo = ((IErrorSymbol)forwardedType).ErrorInfo;

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

                if (symbol is NamespaceSymbol namespaceSymbol)
                {
                    location = BestSymbolLocation.None;
                    foreach (var ns in namespaceSymbol.ConstituentNamespaces)
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
                if (snd.GetKindText() != fst.GetKindText()) return string.CompareOrdinal(fst.GetKindText(), snd.GetKindText());
                //if (snd.Kind != fst.Kind) return (int)fst.Kind - (int)snd.Kind;
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

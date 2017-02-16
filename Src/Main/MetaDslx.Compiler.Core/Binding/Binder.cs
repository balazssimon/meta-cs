using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// A Binder converts names to symbols and syntax nodes into bound trees. It is context
    /// dependent, relative to a location in source code.
    /// </summary>
    public abstract class Binder
    {
        public CompilationBase Compilation { get; }
        private readonly Binder _next;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(CompilationBase compilation)
        {
            Debug.Assert(compilation != null);
            this.Compilation = compilation;

            _bindVisitorPool = new ObjectPool<BindVisitor>(() => compilation.Language.CompilationFactory.CreateBindVisitor(this), 64);
        }

        public Binder(Binder next)
        {
            Debug.Assert(next != null);
            _next = next;
            this.Compilation = next.Compilation;

            _bindVisitorPool = new ObjectPool<BindVisitor>(() => this.Compilation.Language.CompilationFactory.CreateBindVisitor(this), 64);
        }

        // In a typing scenario, Bind is regularly called with a non-zero position.
        // This results in a lot of allocations of BindVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BindVisitor> _bindVisitorPool;

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        public Binder Next
        {
            get
            {
                return _next;
            }
        }

        private Conversions _lazyConversions;
        public Conversions Conversions
        {
            get
            {
                if (_lazyConversions == null)
                {
                    Interlocked.CompareExchange(ref _lazyConversions, new Conversions(this), null);
                }

                return _lazyConversions;
            }
        }

        private OverloadResolution _lazyOverloadResolution;
        public OverloadResolution OverloadResolution
        {
            get
            {
                if (_lazyOverloadResolution == null)
                {
                    Interlocked.CompareExchange(ref _lazyOverloadResolution, new OverloadResolution(this), null);
                }

                return _lazyOverloadResolution;
            }
        }

        public virtual Imports GetImports(ConsList<IMetaSymbol> basesBeingResolved)
        {
            return Imports.Empty;
        }

        /// <summary>
        /// The member containing the binding context.  Note that for the purposes of the compiler,
        /// a lambda expression is considered a "member" of its enclosing method, field, or lambda.
        /// </summary>
        public virtual IMetaSymbol ContainingSymbol
        {
            get
            {
                return Next.ContainingSymbol;
            }
        }

        public virtual bool IsSemanticModelBinder
        {
            get { return true; }
        }

        public virtual bool IgnoreAccessibility
        {
            get { return true; }
        }

        public virtual ImmutableArray<object> Bind(RedNode node, DiagnosticBag diagnostics)
        {
            BindVisitor visitor = _bindVisitorPool.Allocate();
            try
            {
                visitor.Reset(diagnostics, node);
                ImmutableArray<object> result = visitor.Bind();
                visitor.Free();
                return result;
            }
            finally
            {
                _bindVisitorPool.Free(visitor);
            }
        }

        /*
        public virtual IMetaSymbol Bind(SyntaxNode node, ImmutableArray<NameQualifier> qualifiedName, BindingOptions options, DiagnosticBag diagnostics)
        {
            LookupResult result = LookupResult.GetInstance();
            try
            {
                IMetaSymbol resultSymbol = null;
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                for (int i = 0; i < qualifiedName.Length; i++)
                {
                    bool wasError;
                    BindingOptions currentOptions = i < qualifiedName.Length - 1 ? BindingOptions.Default : options;
                    var name = qualifiedName[i];
                    result.Clear();
                    this.LookupSymbolsWithFallback(result, name.Name, null, currentOptions, ref useSiteDiagnostics);
                    diagnostics.Add(node, useSiteDiagnostics);
                    resultSymbol = ResultSymbol(result, node, name.Name, currentOptions, diagnostics, false, out wasError);
                    if (wasError) break;
                }
                return resultSymbol;
            }
            finally
            {
                result.Free();
            }
        }*/

        /// <summary>
        /// Look for names in scope
        /// </summary>
        public void AddLookupSymbolsInfo(ArrayBuilder<IMetaSymbol> result, BindingOptions options)
        {
            for (var scope = this; scope != null; scope = scope.Next)
            {
                scope.AddLookupSymbolsInfoInSingleBinder(result, options, originalBinder: this);
            }
        }

        protected virtual void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<IMetaSymbol> result, BindingOptions options, Binder originalBinder)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Look for names of members
        /// </summary>
        public virtual void AddMemberLookupSymbolsInfo(ArrayBuilder<IMetaSymbol> result, IMetaSymbol container, BindingOptions options, Binder originalBinder)
        {
            // overridden in other binders
        }


        /// <summary>
        /// Look for any symbols in scope with the given name.
        /// </summary>
        public Binder LookupSymbols(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this.LookupSymbolsCore(result, name, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
        }

        /// <summary>
        /// Look for any symbols in scope with the given name.
        /// </summary>
        /// <remarks>
        /// Makes a second attempt if the results are not viable, in order to produce more detailed failure information (symbols and diagnostics).
        /// </remarks>
        public Binder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // don't create diagnosis instances unless lookup fails
            var binder = this.LookupSymbolsCore(result, name, basesBeingResolved, options, diagnose: false, useSiteDiagnostics: ref useSiteDiagnostics);
            Debug.Assert((binder != null) || result.IsClear);

            if (result.Kind != LookupResultKind.Viable && result.Kind != LookupResultKind.Empty)
            {
                result.Clear();
                // retry to get diagnosis
                var otherBinder = this.LookupSymbolsCore(result, name, basesBeingResolved, options, diagnose: true, useSiteDiagnostics: ref useSiteDiagnostics);
                Debug.Assert(binder == otherBinder);
            }

            Debug.Assert(result.IsMultiViable || result.IsClear || result.Error != null);
            return binder;
        }

        protected virtual Binder LookupSymbolsCore(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(result.IsClear);

            Binder binder = null;
            for (var scope = this; scope != null && !result.IsMultiViable; scope = scope.Next)
            {
                if (binder != null)
                {
                    var tmp = LookupResult.GetInstance();
                    scope.LookupSymbolsInSingleBinder(tmp, name, basesBeingResolved, options, this, diagnose, ref useSiteDiagnostics);
                    result.MergeEqual(tmp);
                    tmp.Free();
                }
                else
                {
                    scope.LookupSymbolsInSingleBinder(result, name, basesBeingResolved, options, this, diagnose, ref useSiteDiagnostics);
                    if (!result.IsClear)
                    {
                        binder = scope;
                    }
                }
            }
            return binder;

        }

        protected virtual void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Look for any symbols in scope with the given name.
        /// </summary>
        public void LookupMembers(LookupResult result, IMetaSymbol qualifierOpt, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            this.LookupMembersCore(result, qualifierOpt, name, basesBeingResolved, options, null, diagnose, ref useSiteDiagnostics);
        }

        /// <summary>
        /// Look for any members in scope with the given name.
        /// </summary>
        /// <remarks>
        /// Makes a second attempt if the results are not viable, in order to produce more detailed failure information (symbols and diagnostics).
        /// </remarks>
        public void LookupMembersWithFallback(LookupResult result, IMetaSymbol qualifierOpt, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // don't create diagnosis instances unless lookup fails
            this.LookupMembersCore(result, qualifierOpt, name, basesBeingResolved, options, null, diagnose: false, useSiteDiagnostics: ref useSiteDiagnostics);

            if (result.Kind != LookupResultKind.Viable && result.Kind != LookupResultKind.Empty)
            {
                result.Clear();
                // retry to get diagnosis
                this.LookupMembersCore(result, qualifierOpt, name, basesBeingResolved, options, null, diagnose: true, useSiteDiagnostics: ref useSiteDiagnostics);
            }

            Debug.Assert(result.IsMultiViable || result.IsClear || result.Error != null);
        }

        protected virtual void LookupMembersCore(LookupResult result, IMetaSymbol qualifierOpt, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType".
        /// </summary>
        public bool IsAccessible(IMetaSymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, IMetaSymbol accessThroughType = null, ConsList<IMetaSymbol> basesBeingResolved = null)
        {
            bool failedThroughTypeCheck;
            return IsAccessible(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType", and sets "failedThroughTypeCheck" if fails
        /// the protected access check.
        /// </summary>
        public bool IsAccessible(IMetaSymbol symbol, IMetaSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<IMetaSymbol> basesBeingResolved = null)
        {
            if (this.IgnoreAccessibility)
            {
                failedThroughTypeCheck = false;
                return true;
            }

            return IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <remarks>
        /// Should only be called by <see cref="IsAccessible(Symbol, TypeSymbol, out bool, ref HashSet{DiagnosticInfo}, ConsList{Symbol})"/>,
        /// which will already have checked for <see cref="BindingOptions.IgnoreAccessibility"/>.
        /// </remarks>
        protected virtual bool IsAccessibleHelper(IMetaSymbol symbol, IMetaSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<IMetaSymbol> basesBeingResolved)
        {
            // By default, just delegate to containing binder.
            return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        public virtual SingleLookupResult CheckViability(IMetaSymbol symbol, BindingOptions options, IMetaSymbol accessThroughType, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            DiagnosticInfo kindError;
            DiagnosticInfo typeError;
            bool isViableKind = this.IsViableKind(symbol, options, diagnose, out kindError);
            bool isViableType = this.IsViableType(symbol, options, diagnose, out typeError);
            if (!isViableKind)
            {
                return LookupResult.Wrong(symbol, kindError);
            }
            else if (!isViableType)
            {
                return LookupResult.Wrong(symbol, typeError);
            }
            else
            {
                return LookupResult.Good(symbol);
            }
        }

        protected virtual bool IsViableKind(IMetaSymbol symbol, BindingOptions options, bool diagnose, out DiagnosticInfo error)
        {
            error = null;
            bool isType = symbol.MIsType;
            bool isMember = !symbol.MIsScope && !symbol.MIsType;
            bool isNamespace = symbol.MIsScope && !symbol.MIsType;
            bool isViableKind = (isNamespace && options.LookupNamespaces) || (isType && options.LookupTypes) || (isMember && (options.LookupInstanceMembers || options.LookupStaticMembers));
            if (diagnose && !isViableKind)
            {
                ArrayBuilder<string> expected = ArrayBuilder<string>.GetInstance();
                if (isNamespace) expected.Add("namespace");
                if (isType) expected.Add("type");
                if (isMember) expected.Add("member");
                string message = this.ConstructErrorMessage(expected);
                expected.Free();
                error = new DefaultDiagnosticInfo(this.Compilation.MessageProvider, ErrorCode.ERR_WrongSymbolKind, symbol, message);
            }
            return isViableKind;
        }

        protected virtual bool IsViableType(IMetaSymbol symbol, BindingOptions options, bool diagnose, out DiagnosticInfo error)
        {
            error = null;
            bool isViableType = true;
            if (options.SymbolTypes != null)
            {
                isViableType = false;
                foreach (var symbolType in options.SymbolTypes)
                {
                    if (symbolType.IsAssignableFrom(symbol.MId.SymbolInfo.ImmutableType))
                    {
                        isViableType = true;
                        break;
                    }
                }
            }
            if (diagnose && !isViableType)
            {
                ArrayBuilder<string> expected = ArrayBuilder<string>.GetInstance();
                foreach (var symbolType in options.SymbolTypes)
                {
                    expected.Add(symbolType.Name);
                }
                string message = this.ConstructErrorMessage(expected);
                expected.Free();
                error = new DefaultDiagnosticInfo(this.Compilation.MessageProvider, ErrorCode.ERR_WrongSymbolType, symbol, message);
            }
            return isViableType;
        }

        private string ConstructErrorMessage(ArrayBuilder<string> expected)
        {
            if (expected.Count == 0) return string.Empty;
            if (expected.Count == 1) return expected[0] + " expected";
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < expected.Count; i++)
            {
                if (i > 0)
                {
                    if (i < expected.Count - 1) message.Append(", ");
                    else message.Append(" or ");
                }
                message.Append(expected[i]);
            }
            message.Append(" expected");
            return message.ToString();
        }


        // return the type or namespace symbol in a lookup result, or report an error.
        protected IMetaSymbol ResultSymbol(
            LookupResult result,
            SyntaxNode where,
            string simpleName,
            BindingOptions options,
            DiagnosticBag diagnostics,
            bool suppressUseSiteDiagnostics,
            out bool wasError)
        {
            Debug.Assert(where != null);
            Debug.Assert(diagnostics != null);
            wasError = false;

            return result.SingleSymbolOrDefault;
            /*
            var symbols = result.Symbols;

            if (result.IsMultiViable)
            {
                if (symbols.Count > 1)
                {
                    // gracefully handle symbols.Count > 2
                    symbols.Sort(ConsistentSymbolOrder.Instance);

                    var originalSymbols = symbols.ToImmutable();

                    for (int i = 0; i < symbols.Count; i++)
                    {
                        symbols[i] = UnwrapAlias(symbols[i], diagnostics, where);
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
                            if (srcSymbol.Kind == SymbolKind.Namespace && mdSymbol.Kind == SymbolKind.NamedType)
                            {
                                // ErrorCode.WRN_SameFullNameThisNsAgg: The namespace '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the namespace defined in '{0}'.
                                diagnostics.Add(ErrorCode.WRN_SameFullNameThisNsAgg, where.Location, originalSymbols,
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.ContainingAssembly,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol.Kind == SymbolKind.NamedType && mdSymbol.Kind == SymbolKind.Namespace)
                            {
                                // ErrorCode.WRN_SameFullNameThisAggNs: The type '{1}' in '{0}' conflicts with the imported namespace '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(ErrorCode.WRN_SameFullNameThisAggNs, where.Location, originalSymbols,
                                    arg0,
                                    srcSymbol,
                                    GetContainingAssembly(mdSymbol),
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol.Kind == SymbolKind.NamedType && mdSymbol.Kind == SymbolKind.NamedType)
                            {
                                // WRN_SameFullNameThisAggAgg: The type '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(ErrorCode.WRN_SameFullNameThisAggAgg, where.Location, originalSymbols,
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.ContainingAssembly,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else
                            {
                                // namespace would be merged with the source namespace:
                                Debug.Assert(!(srcSymbol.Kind == SymbolKind.Namespace && mdSymbol.Kind == SymbolKind.Namespace));
                            }
                        }
                    }

                    var first = symbols[best.Index];
                    var second = symbols[secondBest.Index];

                    Debug.Assert(originalSymbols[best.Index] != originalSymbols[secondBest.Index] || options.IsAttributeTypeLookup(),
                        "This kind of ambiguity is only possible for attributes.");

                    Debug.Assert(first != second || originalSymbols[best.Index] != originalSymbols[secondBest.Index],
                        "Why does the LookupResult contain the same symbol twice?");

                    CSDiagnosticInfo info;
                    bool reportError;

                    //if names match, arities match, and containing symbols match (recursively), ...
                    if (first != second &&
                        first.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat) ==
                            second.ToDisplayString(SymbolDisplayFormat.QualifiedNameArityFormat))
                    {
                        // suppress reporting the error if we found multiple symbols from source module
                        // since an error has already been reported from the declaration
                        reportError = !(best.IsFromSourceModule && secondBest.IsFromSourceModule);

                        if (first.Kind == SymbolKind.NamedType && second.Kind == SymbolKind.NamedType)
                        {
                            if (first.OriginalDefinition == second.OriginalDefinition)
                            {
                                // We imported different generic instantiations of the same generic type
                                // and have an ambiguous reference to a type nested in it
                                reportError = true;

                                // '{0}' is an ambiguous reference between '{1}' and '{2}'
                                info = new CSDiagnosticInfo(ErrorCode.ERR_AmbigContext, originalSymbols,
                                    new object[] {
                                        (where as NameSyntax)?.ErrorDisplayName() ?? simpleName,
                                        new FormattedSymbol(first, SymbolDisplayFormat.CSharpErrorMessageFormat),
                                        new FormattedSymbol(second, SymbolDisplayFormat.CSharpErrorMessageFormat) });
                            }
                            else
                            {
                                Debug.Assert(!best.IsFromCorLibrary);

                                // ErrorCode.ERR_SameFullNameAggAgg: The type '{1}' exists in both '{0}' and '{2}'
                                info = new CSDiagnosticInfo(ErrorCode.ERR_SameFullNameAggAgg, originalSymbols,
                                    new object[] { first.ContainingAssembly, first, second.ContainingAssembly });

                                // Do not report this error if the first is declared in source and the second is declared in added module,
                                // we already reported declaration error about this name collision.
                                // Do not report this error if both are declared in added modules,
                                // we will report assembly level declaration error about this name collision.
                                if (secondBest.IsFromAddedModule)
                                {
                                    Debug.Assert(best.IsFromCompilation);
                                    reportError = false;
                                }
                                else if (this.Flags.Includes(BinderFlags.IgnoreCorLibraryDuplicatedTypes) &&
                                    secondBest.IsFromCorLibrary)
                                {
                                    // Ignore duplicate types from the cor library if necessary.
                                    // (Specifically the framework assemblies loaded at runtime in
                                    // the EE may contain types also available from mscorlib.dll.)
                                    return first;
                                }
                            }
                        }
                        else if (first.Kind == SymbolKind.Namespace && second.Kind == SymbolKind.NamedType)
                        {
                            // ErrorCode.ERR_SameFullNameNsAgg: The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'
                            info = new CSDiagnosticInfo(ErrorCode.ERR_SameFullNameNsAgg, originalSymbols,
                                new object[] { GetContainingAssembly(first), first, second.ContainingAssembly, second });

                            // Do not report this error if namespace is declared in source and the type is declared in added module,
                            // we already reported declaration error about this name collision.
                            if (best.IsFromSourceModule && secondBest.IsFromAddedModule)
                            {
                                reportError = false;
                            }
                        }
                        else if (first.Kind == SymbolKind.NamedType && second.Kind == SymbolKind.Namespace)
                        {
                            if (!secondBest.IsFromCompilation || secondBest.IsFromSourceModule)
                            {
                                // ErrorCode.ERR_SameFullNameNsAgg: The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'
                                info = new CSDiagnosticInfo(ErrorCode.ERR_SameFullNameNsAgg, originalSymbols,
                                    new object[] { GetContainingAssembly(second), second, first.ContainingAssembly, first });
                            }
                            else
                            {
                                Debug.Assert(secondBest.IsFromAddedModule);

                                // ErrorCode.ERR_SameFullNameThisAggThisNs: The type '{1}' in '{0}' conflicts with the namespace '{3}' in '{2}'
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

                                info = new CSDiagnosticInfo(ErrorCode.ERR_SameFullNameThisAggThisNs, originalSymbols,
                                    new object[] { arg0, first, arg2, second });
                            }
                        }
                        else if (first.Kind == SymbolKind.RangeVariable && second.Kind == SymbolKind.RangeVariable)
                        {
                            // We will already have reported a conflicting range variable declaration.
                            info = new CSDiagnosticInfo(ErrorCode.ERR_AmbigMember, originalSymbols,
                                new object[] { first, second });
                        }
                        else
                        {
                            // TODO: this is not an appropriate error message here, but used as a fallback until the
                            // appropriate diagnostics are implemented.
                            // '{0}' is an ambiguous reference between '{1}' and '{2}'
                            //info = diagnostics.Add(ErrorCode.ERR_AmbigContext, location, readOnlySymbols,
                            //    whereText,
                            //    first,
                            //    second);

                            // CS0229: Ambiguity between '{0}' and '{1}'
                            info = new CSDiagnosticInfo(ErrorCode.ERR_AmbigMember, originalSymbols,
                                new object[] { first, second });

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
                            if (options.IsAttributeTypeLookup() &&
                                first.Kind == SymbolKind.NamedType &&
                                second.Kind == SymbolKind.NamedType &&
                                originalSymbols[best.Index].Name != originalSymbols[secondBest.Index].Name && // Use alias names, if available.
                                Compilation.IsAttributeType((NamedTypeSymbol)first) &&
                                Compilation.IsAttributeType((NamedTypeSymbol)second))
                            {
                                //  SPEC:   If an attribute class is found both with and without Attribute suffix, an ambiguity 
                                //  SPEC:   is present, and a compile-time error results.

                                info = new CSDiagnosticInfo(ErrorCode.ERR_AmbiguousAttribute, originalSymbols,
                                    new object[] { (where as NameSyntax)?.ErrorDisplayName() ?? simpleName, first, second });
                            }
                            else
                            {
                                // '{0}' is an ambiguous reference between '{1}' and '{2}'
                                info = new CSDiagnosticInfo(ErrorCode.ERR_AmbigContext, originalSymbols,
                                    new object[] {
                                        (where as NameSyntax)?.ErrorDisplayName() ?? simpleName,
                                        new FormattedSymbol(first, SymbolDisplayFormat.CSharpErrorMessageFormat),
                                        new FormattedSymbol(second, SymbolDisplayFormat.CSharpErrorMessageFormat) });
                            }
                        }
                        else
                        {
                            // CS0229: Ambiguity between '{0}' and '{1}'
                            info = new CSDiagnosticInfo(ErrorCode.ERR_AmbigMember, originalSymbols,
                                new object[] { first, second });
                        }
                    }

                    wasError = true;

                    if (reportError)
                    {
                        diagnostics.Add(info, where.Location);
                    }

                    return new ExtendedErrorTypeSymbol(
                        GetContainingNamespaceOrType(originalSymbols[0]),
                        originalSymbols,
                        LookupResultKind.Ambiguous,
                        info,
                        arity);
                }
                else
                {
                    // Single viable result.
                    var singleResult = symbols[0];

                    // Cannot reference System.Void directly.
                    var singleType = singleResult as TypeSymbol;
                    if ((object)singleType != null && singleType.PrimitiveTypeCode == Cci.PrimitiveTypeCode.Void && simpleName == "Void")
                    {
                        wasError = true;
                        var errorInfo = new CSDiagnosticInfo(ErrorCode.ERR_SystemVoid);
                        diagnostics.Add(errorInfo, where.Location);
                        singleResult = new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(singleResult), singleResult, LookupResultKind.NotReferencable, errorInfo); // UNDONE: Review resultkind.
                    }
                    // Check for bad symbol.
                    else
                    {
                        if (singleResult.Kind == SymbolKind.NamedType &&
                            ((SourceModuleSymbol)this.Compilation.SourceModule).AnyReferencedAssembliesAreLinked)
                        {
                            // Complain about unembeddable types from linked assemblies.
                            Emit.NoPia.EmbeddedTypesManager.IsValidEmbeddableType((NamedTypeSymbol)singleResult, where, diagnostics);
                        }

                        if (!suppressUseSiteDiagnostics)
                        {
                            wasError = ReportUseSiteDiagnostics(singleResult, diagnostics, where);
                        }
                        else if (singleResult.Kind == SymbolKind.ErrorType)
                        {
                            // We want to report ERR_CircularBase error on the spot to make sure 
                            // that the right location is used for it.
                            var errorType = (ErrorTypeSymbol)singleResult;

                            if (errorType.Unreported)
                            {
                                DiagnosticInfo errorInfo = errorType.ErrorInfo;

                                if (errorInfo != null && errorInfo.Code == (int)ErrorCode.ERR_CircularBase)
                                {
                                    wasError = true;
                                    diagnostics.Add(errorInfo, where.Location);
                                    singleResult = new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(errorType), errorType.Name, errorType.Arity, errorInfo, unreported: false);
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
                string aliasOpt = null;
                CSharpSyntaxNode node = where;
                while (node is ExpressionSyntax)
                {
                    if (node.Kind() == SyntaxKind.AliasQualifiedName)
                    {
                        aliasOpt = ((AliasQualifiedNameSyntax)node).Alias.Identifier.ValueText;
                        break;
                    }
                    node = node.Parent;
                }

                CSDiagnosticInfo info = NotFound(where, simpleName, arity, (where as NameSyntax)?.ErrorDisplayName() ?? simpleName, diagnostics, aliasOpt, qualifierOpt, options);
                return new ExtendedErrorTypeSymbol(qualifierOpt ?? Compilation.Assembly.GlobalNamespace, simpleName, arity, info);
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
                ((object)qualifierOpt == null || qualifierOpt.Kind != SymbolKind.ErrorType)) // Suppress cascading.
            {
                diagnostics.Add(new CSDiagnostic(result.Error, where.Location));
            }

            if ((symbols.Count > 1) || (symbols[0] is NamespaceOrTypeSymbol || symbols[0] is AliasSymbol) ||
                result.Kind == LookupResultKind.NotATypeOrNamespace || result.Kind == LookupResultKind.NotAnAttributeType)
            {
                // Bad type or namespace (or things expected as types/namespaces) are packaged up as error types, preserving the symbols and the result kind.
                // We do this if there are multiple symbols too, because just returning one would be losing important information, and they might
                // be of different kinds.
                return new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(symbols[0]), symbols.ToImmutable(), result.Kind, result.Error, arity);
            }
            else
            {
                // It's a single non-type-or-namespace; error was already reported, so just return it.
                return symbols[0];
            }*/
        }


#if DEBUG
        // Helper to allow displaying the binder hierarchy in the debugger.
        public Binder[] GetAllBinders()
        {
            var binders = ArrayBuilder<Binder>.GetInstance();
            for (var binder = this; binder != null; binder = binder.Next)
            {
                binders.Add(binder);
            }
            return binders.ToArrayAndFree();
        }
#endif
    }
}

﻿using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    /// <summary>
    /// A Binder converts names to symbols and syntax nodes into bound trees. It is context
    /// dependent, relative to a location in source code.
    /// </summary>
    public abstract class Binder
    {
        protected static Func<Binder, bool> ReturnTrue = (Binder b) => true;
        protected static Func<Binder, bool> ReturnFalse = (Binder b) => false;

        public CompilationBase Compilation { get; }
        private readonly Binder _next;
        private readonly RedNode _node;
        private ImmutableArray<Binder> _lazyPreviousBinders;
        private Conversions _lazyConversions;
        private OverloadResolution _lazyOverloadResolution;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(CompilationBase compilation)
        {
            Debug.Assert(compilation != null);
            this.Compilation = compilation;
        }

        public Binder(Binder next, RedNode node)
        {
            Debug.Assert(next != null);
            _next = next;
            _node = node;
            this.Compilation = next.Compilation;
        }

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

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        public ImmutableArray<Binder> Previous
        {
            get
            {
                if (_lazyPreviousBinders == null)
                {
                    ImmutableInterlocked.InterlockedExchange(ref _lazyPreviousBinders, this.CollectPreviousBinders());
                }
                return _lazyPreviousBinders;
            }
        }

        private ImmutableArray<Binder> CollectPreviousBinders()
        {
            ImmutableArray<Binder> result = ImmutableArray<Binder>.Empty;
            ArrayBuilder<Binder> resultBuilder = ArrayBuilder<Binder>.GetInstance();
            try
            {
                Stack<RedNode> nodeStack = new Stack<RedNode>();
                nodeStack.Push(_node);
                while (nodeStack.Count > 0)
                {
                    RedNode currentNode = nodeStack.Pop();
                    Binder childBinder = this.Compilation.GetBinder(currentNode);
                    //Debug.Assert(childBinder != null);
                    if (childBinder != this)
                    {
                        Binder currentBinder = childBinder;
                        while (currentBinder != null && currentBinder.Next != this)
                        {
                            currentBinder = currentBinder.Next;
                        }
                        if (currentBinder != null)
                        {
                            resultBuilder.Add(currentBinder);
                        }
                        else
                        {
                            //Debug.Assert(false);
                        }
                    }
                    else
                    {
                        SyntaxNode currentSyntax = currentNode as SyntaxNode;
                        if (currentSyntax != null)
                        {
                            foreach (var child in currentSyntax.ChildNodesAndTokens().Reverse())
                            {
                                nodeStack.Push(child);
                            }
                        }
                    }
                }
            }
            finally
            {
                result = resultBuilder.ToImmutableAndFree();
            }
            return result;
        }

        /// <summary>
        /// Get the node to which this binder was attached to.
        /// </summary>
        public RedNode Node
        {
            get
            {
                return _node;
            }
        }

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

        public virtual Imports GetImports(ConsList<ISymbol> basesBeingResolved)
        {
            return Imports.Empty;
        }

        /// <summary>
        /// The member containing the binding context.  Note that for the purposes of the compiler,
        /// a lambda expression is considered a "member" of its enclosing method, field, or lambda.
        /// </summary>
        public virtual ISymbol ContainingSymbol
        {
            get
            {
                return Next.ContainingSymbol;
            }
        }

        public virtual BindingOptions BindingOptions
        {
            get
            {
                return Next.BindingOptions;
            }
        }

        public virtual BindingOptions NestingBindingOptions
        {
            get
            {
                return Next.NestingBindingOptions;
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

        protected Binder GetBinder(RedNode node)
        {
            return this.Compilation.GetBinder(node);
        }

        public TBinder FindAncestorBinder<TBinder>()
            where TBinder : class
        {
            return this.FindAncestorBinder<TBinder>(false, b => true, ReturnFalse);
        }

        public Binder FindAncestorBinder(Func<Binder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
        {
            return this.FindAncestorBinder<Binder>(false, selectBinder, stepIntoBinder);
        }

        public TBinder FindAncestorBinder<TBinder>(Func<TBinder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
            where TBinder : class
        {
            return this.FindAncestorBinder<TBinder>(false, selectBinder, stepIntoBinder);
        }

        public TBinder FindAncestorAndSelfBinder<TBinder>()
            where TBinder : class
        {
            return this.FindAncestorBinder<TBinder>(true, b => true, ReturnFalse);
        }

        public Binder FindAncestorAndSelfBinder(Func<Binder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
        {
            return this.FindAncestorBinder<Binder>(true, selectBinder, stepIntoBinder);
        }

        public TBinder FindAncestorAndSelfBinder<TBinder>(Func<TBinder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
            where TBinder : class
        {
            return this.FindAncestorBinder<TBinder>(true, selectBinder, stepIntoBinder);
        }

        private TBinder FindAncestorBinder<TBinder>(bool includeSelf, Func<TBinder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
            where TBinder : class
        {
            Binder currentBinder = includeSelf ? this : this._next;
            while (currentBinder != null)
            {
                TBinder typedBinder = currentBinder as TBinder;
                if (typedBinder != null && selectBinder(typedBinder))
                {
                    return typedBinder;
                }
                if (stepIntoBinder(currentBinder) || currentBinder is ICustomBinder)
                {
                    currentBinder = currentBinder._next;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public ImmutableArray<Binder> FindDescendantBinders()
        {
            return this.FindDescendantBinders(false, ReturnTrue, ReturnFalse);
        }

        public ImmutableArray<TBinder> FindDescendantBinders<TBinder>()
            where TBinder : class
        {
            return this.FindDescendantBinders<TBinder>(false, (TBinder b) => true, ReturnFalse);
        }

        public ImmutableArray<Binder> FindDescendantBinders(Func<Binder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
        {
            return this.FindDescendantBinders<Binder>(false, selectBinder, stepIntoBinder);
        }

        public ImmutableArray<TBinder> FindDescendantBinders<TBinder>(Func<TBinder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
            where TBinder : class
        {
            return this.FindDescendantBinders<TBinder>(false, selectBinder, stepIntoBinder);
        }

        public ImmutableArray<Binder> FindDescendantAndSelfBinders()
        {
            return this.FindDescendantBinders(true, ReturnTrue, ReturnFalse);
        }

        public ImmutableArray<TBinder> FindDescendantAndSelfBinders<TBinder>()
            where TBinder : class
        {
            return this.FindDescendantBinders<TBinder>(true, (TBinder b) => true, ReturnFalse);
        }

        public ImmutableArray<Binder> FindDescendantAndSelfBinders(Func<Binder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
        {
            return this.FindDescendantBinders<Binder>(true, selectBinder, stepIntoBinder);
        }

        public ImmutableArray<TBinder> FindDescendantAndSelfBinders<TBinder>(Func<TBinder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
            where TBinder : class
        {
            return this.FindDescendantBinders<TBinder>(true, selectBinder, stepIntoBinder);
        }

        private ImmutableArray<TBinder> FindDescendantBinders<TBinder>(bool includeSelf, Func<TBinder, bool> selectBinder, Func<Binder, bool> stepIntoBinder)
            where TBinder : class
        {
            ImmutableArray<TBinder> result = ImmutableArray<TBinder>.Empty;
            ArrayBuilder<TBinder> resultBuilder = ArrayBuilder<TBinder>.GetInstance();
            try
            {
                Stack<Binder> binderStack = new Stack<Binder>();
                binderStack.Push(this);
                while (binderStack.Count > 0)
                {
                    Binder currentBinder = binderStack.Pop();
                    if (includeSelf || currentBinder != this)
                    {
                        TBinder typedBinder = currentBinder as TBinder;
                        if (typedBinder != null && selectBinder(typedBinder))
                        {
                            resultBuilder.Add(typedBinder);
                        }
                    }
                    if ((!includeSelf && currentBinder == this) || ((includeSelf || currentBinder != this) && (stepIntoBinder(currentBinder) || currentBinder is ICustomBinder)))
                    {
                        var childBinders = currentBinder.Previous;
                        for (int i = childBinders.Length - 1; i >= 0; --i)
                        {
                            binderStack.Push(childBinders[i]);
                        }
                    }
                }
            }
            finally
            {
                result = resultBuilder.ToImmutableAndFree();
            }
            return result;
        }

        public virtual ImmutableArray<object> Bind(SyntaxNode node, DiagnosticBag diagnostics)
        {
            var binder = this.GetBinder(node);
            if (binder != null && binder is ISymbolDefBinder)
            {
                return ((ISymbolDefBinder)binder).DefinedSymbols.CastArray<object>();
            }
            if (binder != null && binder is INameBinder)
            {
                return ((INameBinder)binder).DefinedSymbols.CastArray<object>();
            }
            if (binder != null && binder is IValueBinder)
            {
                return ((IValueBinder)binder).GetValues();
            }
            return ImmutableArray<object>.Empty;
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
        public void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, BindingOptions options)
        {
            for (var scope = this; scope != null; scope = scope.Next)
            {
                scope.AddLookupSymbolsInfoInSingleBinder(result, options, originalBinder: this);
            }
        }

        protected virtual void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<ISymbol> result, BindingOptions options, Binder originalBinder)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Look for names of members
        /// </summary>
        public virtual void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, BindingOptions options, Binder originalBinder)
        {
            // overridden in other binders
        }


        /// <summary>
        /// Look for any symbols in scope with the given name.
        /// </summary>
        public Binder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this.LookupSymbolsCore(result, name, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
        }

        /// <summary>
        /// Look for any symbols in scope with the given name.
        /// </summary>
        /// <remarks>
        /// Makes a second attempt if the results are not viable, in order to produce more detailed failure information (symbols and diagnostics).
        /// </remarks>
        public Binder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
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

        protected virtual Binder LookupSymbolsCore(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
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

        protected virtual void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Look for any symbols in scope with the given name.
        /// </summary>
        public void LookupMembers(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            this.LookupMembersCore(result, qualifierOpt, name, basesBeingResolved, options, null, diagnose, ref useSiteDiagnostics);
        }

        /// <summary>
        /// Look for any members in scope with the given name.
        /// </summary>
        /// <remarks>
        /// Makes a second attempt if the results are not viable, in order to produce more detailed failure information (symbols and diagnostics).
        /// </remarks>
        public void LookupMembersWithFallback(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
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

        protected virtual void LookupMembersCore(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // overridden in other binders
            if (qualifierOpt != null)
            {
                this.Next.LookupMembersCore(result, qualifierOpt, name, basesBeingResolved, options, originalBinder, diagnose, ref useSiteDiagnostics);
            }
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType".
        /// </summary>
        public bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null)
        {
            bool failedThroughTypeCheck;
            return IsAccessible(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType", and sets "failedThroughTypeCheck" if fails
        /// the protected access check.
        /// </summary>
        public bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null)
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
        protected virtual bool IsAccessibleHelper(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved)
        {
            // By default, just delegate to containing binder.
            return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        public virtual SingleLookupResult CheckViability(ISymbol symbol, BindingOptions options, ISymbol accessThroughType, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
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

        protected virtual bool IsViableKind(ISymbol symbol, BindingOptions options, bool diagnose, out DiagnosticInfo error)
        {
            error = null;
            bool isNamespace = symbol.MIsNamespace;
            bool isType = symbol.MIsType;
            bool isMember = !symbol.MIsNamespace && !symbol.MIsType;
            bool isViableKind = (isNamespace && options.LookupNamespaces) || (isType && options.LookupTypes) || (isMember && (options.LookupInstanceMembers || options.LookupStaticMembers));
            if (diagnose && !isViableKind)
            {
                ArrayBuilder<string> expected = ArrayBuilder<string>.GetInstance();
                if (isNamespace) expected.Add("namespace");
                if (isType) expected.Add("type");
                if (isMember) expected.Add("member");
                string message = this.ConstructErrorMessage(expected);
                expected.Free();
                error = new DiagnosticInfo(CompilerErrorCode.ERR_WrongSymbolKind, symbol, message);
            }
            return isViableKind;
        }

        protected virtual bool IsViableType(ISymbol symbol, BindingOptions options, bool diagnose, out DiagnosticInfo error)
        {
            error = null;
            bool isViableType = true;
            if (options.SymbolTypes != null && options.SymbolTypes.Length > 0)
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
                error = new DiagnosticInfo(CompilerErrorCode.ERR_WrongSymbolType, symbol, message);
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

        protected virtual ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where)
        {
            return alias;
        }

        private Location GetLocation(ISymbol symbol)
        {
            ImmutableArray<SyntaxReference> refs = (ImmutableArray<SyntaxReference>)(symbol.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty) ?? ImmutableArray<SyntaxReference>.Empty);
            return refs.FirstOrDefault()?.GetLocation() ?? Location.None;
        }

        protected virtual string ToDisplayString(ISymbol symbol)
        {
            string result = string.Empty;
            ISymbol current = symbol;
            while (current != null)
            {
                if (result.Length > 0) result = "." + result;
                result = current.MName + result;
                current = current.MParent;
            }
            return result;
        }

        protected virtual bool GetOriginalDefinition(ISymbol symbol)
        {
            return symbol.MIsType && !string.IsNullOrEmpty(symbol.MName);
        }

        // return the type or namespace symbol in a lookup result, or report an error.
        protected ISymbol ResultSymbol(
            LookupResult result,
            RedNode where,
            ISymbol qualifierOpt,
            string simpleName,
            BindingOptions options,
            DiagnosticBag diagnostics,
            bool suppressUseSiteDiagnostics,
            out bool wasError)
        {
            Debug.Assert(where != null);
            Debug.Assert(diagnostics != null);
            wasError = false;

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
                            ImmutableArray<SyntaxReference> refs = (ImmutableArray<SyntaxReference>)srcSymbol.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
                            arg0 = refs.First().SyntaxTree.FilePath;
                        }
                        else
                        {
                            Debug.Assert(best.IsFromAddedModule);
                            arg0 = srcSymbol.MModel;
                        }

                        //if names match, arities match, and containing symbols match (recursively), ...
                        if (this.ToDisplayString(srcSymbol) == this.ToDisplayString(mdSymbol))
                        {
                            if (srcSymbol.MIsNamespace && mdSymbol.MIsNamedType)
                            {
                                // ErrorCode.WRN_SameFullNameThisNsAgg: The namespace '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the namespace defined in '{0}'.
                                diagnostics.Add(where.GetLocation(), CompilerErrorCode.WRN_SameFullNameThisNsAgg, originalSymbols,
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.MModel,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol.MIsNamedType && mdSymbol.MIsNamespace)
                            {
                                // ErrorCode.WRN_SameFullNameThisAggNs: The type '{1}' in '{0}' conflicts with the imported namespace '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(where.GetLocation(), CompilerErrorCode.WRN_SameFullNameThisAggNs, originalSymbols,
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.MModel,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else if (srcSymbol.MIsNamedType && mdSymbol.MIsNamedType)
                            {
                                // WRN_SameFullNameThisAggAgg: The type '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the type defined in '{0}'.
                                diagnostics.Add(where.GetLocation(), CompilerErrorCode.WRN_SameFullNameThisAggAgg, originalSymbols,
                                    arg0,
                                    srcSymbol,
                                    mdSymbol.MModel,
                                    mdSymbol);

                                return originalSymbols[best.Index];
                            }
                            else
                            {
                                // namespace would be merged with the source namespace:
                                Debug.Assert(!(srcSymbol.MIsNamespace && mdSymbol.MIsNamespace));
                            }
                        }
                    }

                    var first = symbols[best.Index];
                    var second = symbols[secondBest.Index];

                    Debug.Assert(originalSymbols[best.Index] != originalSymbols[secondBest.Index],
                        "This kind of ambiguity is only possible for attributes.");

                    Debug.Assert(first != second || originalSymbols[best.Index] != originalSymbols[secondBest.Index],
                        "Why does the LookupResult contain the same symbol twice?");

                    DiagnosticInfo info;
                    bool reportError;

                    //if names match, arities match, and containing symbols match (recursively), ...
                    if (first != second && this.ToDisplayString(first) == this.ToDisplayString(second))
                    {
                        // suppress reporting the error if we found multiple symbols from source module
                        // since an error has already been reported from the declaration
                        reportError = !(best.IsFromSourceModule && secondBest.IsFromSourceModule);

                        if (first.MIsNamedType && second.MIsNamedType)
                        {
                            // ErrorCode.ERR_SameFullNameAggAgg: The type '{1}' exists in both '{0}' and '{2}'
                            info = new DiagnosticInfo(CompilerErrorCode.ERR_SameFullNameAggAgg, originalSymbols,
                                new object[] { first.MModel, first, second.MModel });

                            // Do not report this error if the first is declared in source and the second is declared in added module,
                            // we already reported declaration error about this name collision.
                            // Do not report this error if both are declared in added modules,
                            // we will report assembly level declaration error about this name collision.
                            if (secondBest.IsFromAddedModule)
                            {
                                Debug.Assert(best.IsFromCompilation);
                                reportError = false;
                            }
                        }
                        else if (first.MIsNamespace && second.MIsNamedType)
                        {
                            // ErrorCode.ERR_SameFullNameNsAgg: The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'
                            info = new DiagnosticInfo(CompilerErrorCode.ERR_SameFullNameNsAgg, originalSymbols,
                                new object[] { first.MModel, first, second.MModel, second });

                            // Do not report this error if namespace is declared in source and the type is declared in added module,
                            // we already reported declaration error about this name collision.
                            if (best.IsFromSourceModule && secondBest.IsFromAddedModule)
                            {
                                reportError = false;
                            }
                        }
                        else if (first.MIsNamedType && second.MIsNamespace)
                        {
                            if (!secondBest.IsFromCompilation || secondBest.IsFromSourceModule)
                            {
                                // ErrorCode.ERR_SameFullNameNsAgg: The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'
                                info = new DiagnosticInfo(CompilerErrorCode.ERR_SameFullNameNsAgg, originalSymbols,
                                    new object[] { second.MModel, second, first.MModel, first });
                            }
                            else
                            {
                                Debug.Assert(secondBest.IsFromAddedModule);

                                // ErrorCode.ERR_SameFullNameThisAggThisNs: The type '{1}' in '{0}' conflicts with the namespace '{3}' in '{2}'
                                object arg0;

                                if (best.IsFromSourceModule)
                                {
                                    ImmutableArray<SyntaxReference> refs = (ImmutableArray<SyntaxReference>)first.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
                                    arg0 = refs.First().SyntaxTree.FilePath;
                                }
                                else
                                {
                                    Debug.Assert(best.IsFromAddedModule);
                                    arg0 = first.MModel;
                                }

                                IModel arg2 = second.MModel;

                                // Merged namespaces that span multiple modules don't have a containing module,
                                // so just use module with the smallest ordinal from the containing assembly.
                                /*if ((object)arg2 == null)
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

                                Debug.Assert(arg2.ContainingAssembly == Compilation.Assembly);*/

                                info = new DiagnosticInfo(CompilerErrorCode.ERR_SameFullNameThisAggThisNs, originalSymbols,
                                    new object[] { arg0, first, arg2, second });
                            }
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
                            info = new DiagnosticInfo(CompilerErrorCode.ERR_AmbigMember, originalSymbols,
                                new object[] { first, second });

                            reportError = true;
                        }
                    }
                    else
                    {
                        Debug.Assert(originalSymbols[best.Index].MName != originalSymbols[secondBest.Index].MName ||
                                     originalSymbols[best.Index] != originalSymbols[secondBest.Index],
                            "Why was the lookup result viable if it contained non-equal symbols with the same name?");

                        reportError = true;

                        // CS0229: Ambiguity between '{0}' and '{1}'
                        info = new DiagnosticInfo(CompilerErrorCode.ERR_AmbigMember, originalSymbols,
                            new object[] { first, second });
                    }

                    wasError = true;

                    if (reportError)
                    {
                        diagnostics.Add(where.GetLocation(), info);
                    }

                    return this.Compilation.ErrorSymbol;
                    /*return new ExtendedErrorTypeSymbol(
                        GetContainingNamespaceOrType(originalSymbols[0]),
                        originalSymbols,
                        LookupResultKind.Ambiguous,
                        info,
                        arity);*/
                }
                else
                {
                    // Single viable result.
                    var singleResult = symbols[0];

                    // Check for bad symbol.
                    if (!suppressUseSiteDiagnostics)
                    {
                        wasError = ReportUseSiteDiagnostics(singleResult, diagnostics, where);
                    }
                    /*else if (singleResult.Kind == SymbolKind.ErrorType)
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
                                diagnostics.Add(errorInfo, where.GetLocation());
                                singleResult = new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(errorType), errorType.Name, errorType.Arity, errorInfo, unreported: false);
                            }
                        }
                    }*/

                    return singleResult;
                }
            }

            // Below here is the error case; no viable symbols found (but maybe one or more non-viable.)
            wasError = true;

            if (result.Kind == LookupResultKind.Empty)
            {
                /*string aliasOpt = null;
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
                return new ExtendedErrorTypeSymbol(qualifierOpt ?? Compilation.Assembly.GlobalNamespace, simpleName, arity, info);*/

                diagnostics.Add(where.GetLocation(), CompilerErrorCode.ERR_NotFound, simpleName);
                return this.Compilation.ErrorSymbol;
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
                ((object)qualifierOpt == null || qualifierOpt != this.Compilation.ErrorSymbol)) // Suppress cascading.
            {
                diagnostics.Add(where.GetLocation(), result.Error);
            }

            if ((symbols.Count > 1) || (symbols[0].MIsNamespace || symbols[0].MIsNamedType))
            {
                // Bad type or namespace (or things expected as types/namespaces) are packaged up as error types, preserving the symbols and the result kind.
                // We do this if there are multiple symbols too, because just returning one would be losing important information, and they might
                // be of different kinds.
                //return new ExtendedErrorTypeSymbol(GetContainingNamespaceOrType(symbols[0]), symbols.ToImmutable(), result.Kind, result.Error, arity);
                return this.Compilation.ErrorSymbol;
            }
            else
            {
                // It's a single non-type-or-namespace; error was already reported, so just return it.
                return symbols[0];
            }
        }

        private bool ReportUseSiteDiagnostics(ISymbol metaSymbol, DiagnosticBag diagnostics, RedNode where)
        {
            DiagnosticInfo symbolDiagnostic = (DiagnosticInfo)metaSymbol.MGet(CompilerAttachedProperties.UseSiteDiagnosticProperty);
            return this.ReportUseSiteDiagnostic(symbolDiagnostic, diagnostics, where.GetLocation());
        }

        private bool ReportUseSiteDiagnostic(DiagnosticInfo info, DiagnosticBag diagnostics, Location location)
        {
            if (info == null) return false;
            diagnostics.Add(location, info);
            return info.Severity == DiagnosticSeverity.Error;
        }

        private class ConsistentSymbolOrder : IComparer<ISymbol>
        {
            public static readonly ConsistentSymbolOrder Instance = new ConsistentSymbolOrder();
            public int Compare(ISymbol fst, ISymbol snd)
            {
                if (snd == fst) return 0;
                if ((object)fst == null) return -1;
                if ((object)snd == null) return 1;
                if (snd.MName != fst.MName) return string.CompareOrdinal(fst.MName, snd.MName);
                if (snd.MMetaClass != fst.MMetaClass) return string.CompareOrdinal(fst.MMetaClass.MId.Id, snd.MMetaClass.MId.Id);
                ImmutableArray<SyntaxReference> fstReferences = (ImmutableArray<SyntaxReference>)(fst.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty) ?? ImmutableArray<SyntaxReference>.Empty);
                ImmutableArray<SyntaxReference> sndReferences = (ImmutableArray<SyntaxReference>)(snd.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty) ?? ImmutableArray<SyntaxReference>.Empty);
                int aLocationsCount = fstReferences.Length;
                int bLocationsCount = sndReferences.Length;
                if (aLocationsCount != bLocationsCount) return aLocationsCount - bLocationsCount;
                if (aLocationsCount == 0 && bLocationsCount == 0) return Compare(fst.MParent, snd.MParent);
                Location la = sndReferences[0].GetLocation();
                Location lb = fstReferences[0].GetLocation();
                if (la.IsInSource != lb.IsInSource) return la.IsInSource ? 1 : -1;
                int containerResult = Compare(fst.MParent, snd.MParent);
                if (!la.IsInSource) return containerResult;
                if (containerResult == 0 && la.SourceTree == lb.SourceTree) return lb.SourceSpan.Start - la.SourceSpan.Start;
                return containerResult;
            }
        }

        [Flags]
        private enum BestSymbolLocation
        {
            None,
            FromSourceModule,
            FromAddedModule,
            FromReferencedAssembly,
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

            public bool IsFromCompilation
            {
                get
                {
                    return (_location == BestSymbolLocation.FromSourceModule) || (_location == BestSymbolLocation.FromAddedModule);
                }
            }

            public bool IsNone
            {
                get
                {
                    return _location == BestSymbolLocation.None;
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
        private BestSymbolInfo GetBestSymbolInfo(ArrayBuilder<ISymbol> symbols, out BestSymbolInfo secondBest)
        {
            BestSymbolInfo first = default(BestSymbolInfo);
            BestSymbolInfo second = default(BestSymbolInfo);
            var compilation = this.Compilation;

            for (int i = 0; i < symbols.Count; i++)
            {
                var symbol = symbols[i];
                BestSymbolLocation location;

                /*if (symbol.Kind == SymbolKind.Namespace)
                {
                    location = BestSymbolLocation.None;
                    foreach (var ns in ((NamespaceSymbol)symbol).ConstituentNamespaces)
                    {
                        var current = GetLocation(compilation, ns);
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
                {*/
                    location = GetLocation(compilation, symbol);
                //}

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

        private static BestSymbolLocation GetLocation(CompilationBase compilation, ISymbol symbol)
        {
            if (compilation.ModelBuilder.ContainsSymbol(symbol.MId))
            {
                return BestSymbolLocation.FromSourceModule;
            }
            else if (compilation.ModelGroupBuilder.ResolveSymbol(symbol.MId) != null)
            {
                return BestSymbolLocation.FromAddedModule;
            }
            else
            {
                return BestSymbolLocation.FromReferencedAssembly;
            }
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
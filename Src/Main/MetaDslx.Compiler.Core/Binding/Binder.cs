using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// A Binder converts names in to symbols and syntax nodes into bound trees. It is context
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
        }

        public Binder(Binder next)
        {
            Debug.Assert(next != null);
            _next = next;
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

        public virtual IMetaSymbol Bind(SyntaxNode node, DiagnosticBag diagnostics)
        {
            LookupResult result = LookupResult.GetInstance();
            try
            {
                string name = node.ToString();
                HashSet<DiagnosticInfo> discardedDiagnostics = null;
                this.LookupSymbols(result, name, null, BindingOptions.Default, false, ref discardedDiagnostics);
                if (result.IsSingleViable)
                {
                    return result.SingleSymbolOrDefault;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                result.Free();
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
        public Binder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
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
            if (options is SimpleSymbolBindingOptions)
            {
                var soptions = (SimpleSymbolBindingOptions)options;
                if (soptions.SymbolTypes != null)
                {
                    isViableType = false;
                    foreach (var symbolType in soptions.SymbolTypes)
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
                    foreach (var symbolType in soptions.SymbolTypes)
                    {
                        expected.Add(symbolType.Name);
                    }
                    string message = this.ConstructErrorMessage(expected);
                    expected.Free();
                    error = new DefaultDiagnosticInfo(this.Compilation.MessageProvider, ErrorCode.ERR_WrongSymbolType, symbol, message);
                }
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

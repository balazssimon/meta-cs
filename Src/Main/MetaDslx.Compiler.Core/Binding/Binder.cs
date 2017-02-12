﻿using MetaDslx.Compiler.Diagnostics;
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
        public Compilation Compilation { get; }
        private readonly Binder _next;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(Compilation compilation)
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

        protected virtual void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<IMetaSymbol> info, BindingOptions options, Binder originalBinder)
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


        internal Binder LookupSymbols(LookupResult result, string name, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(result.IsClear);

            Binder binder = null;
            for (var scope = this; scope != null && !result.IsMultiViable; scope = scope.Next)
            {
                if (binder != null)
                {
                    var tmp = LookupResult.GetInstance();
                    scope.LookupSymbolsInSingleBinder(tmp, name, options, this, diagnose, ref useSiteDiagnostics);
                    result.MergeEqual(tmp);
                    tmp.Free();
                }
                else
                {
                    scope.LookupSymbolsInSingleBinder(result, name, options, this, diagnose, ref useSiteDiagnostics);
                    if (!result.IsClear)
                    {
                        binder = scope;
                    }
                }
            }
            return binder;
        }

        internal virtual void LookupSymbolsInSingleBinder(LookupResult result, string name, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
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

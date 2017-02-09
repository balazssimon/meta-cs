using MetaDslx.Compiler.Diagnostics;
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
        internal Binder(Compilation compilation)
        {
            Debug.Assert(compilation != null);
            this.Compilation = compilation;
        }

        internal Binder(Binder next)
        {
            Debug.Assert(next != null);
            _next = next;
            this.Compilation = next.Compilation;
        }

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        internal protected Binder Next
        {
            get
            {
                return _next;
            }
        }

        private Conversions _lazyConversions;
        internal Conversions Conversions
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
        internal OverloadResolution OverloadResolution
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
        public virtual IMetaSymbol ContainingMember
        {
            get
            {
                return Next.ContainingMember;
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
        public void AddLookupSymbolsInfo(ArrayBuilder<IMetaSymbol> result, LookupOptions options)
        {
            for (var scope = this; scope != null; scope = scope.Next)
            {
                scope.AddLookupSymbolsInfoInSingleBinder(result, options, originalBinder: this);
            }
        }

        protected virtual void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<IMetaSymbol> info, LookupOptions options, Binder originalBinder)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Look for names of members
        /// </summary>
        public virtual void AddMemberLookupSymbolsInfo(ArrayBuilder<IMetaSymbol> result, IMetaSymbol nsOrType, LookupOptions options, Binder originalBinder)
        {
            // overridden in other binders
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType".
        /// </summary>
        internal bool IsAccessible(IMetaSymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, IMetaSymbol accessThroughType = null, ConsList<IMetaSymbol> basesBeingResolved = null)
        {
            bool failedThroughTypeCheck;
            return IsAccessible(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        /// <summary>
        /// Check whether "symbol" is accessible from this binder.
        /// Also checks protected access via "accessThroughType", and sets "failedThroughTypeCheck" if fails
        /// the protected access check.
        /// </summary>
        internal bool IsAccessible(IMetaSymbol symbol, IMetaSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<IMetaSymbol> basesBeingResolved = null)
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
        /// which will already have checked for <see cref="BinderFlags.IgnoreAccessibility"/>.
        /// </remarks>
        internal virtual bool IsAccessibleHelper(IMetaSymbol symbol, IMetaSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<IMetaSymbol> basesBeingResolved)
        {
            // By default, just delegate to containing binder.
            return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }
    }
}

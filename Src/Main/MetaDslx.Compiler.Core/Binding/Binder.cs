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

        private NameResolution _lazyNameResolution;
        internal NameResolution NameResolution
        {
            get
            {
                if (_lazyNameResolution == null)
                {
                    Interlocked.CompareExchange(ref _lazyNameResolution, new NameResolution(this), null);
                }

                return _lazyNameResolution;
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
    }
}

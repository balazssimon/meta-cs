using MetaDslx.Compiler.Diagnostics;
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
    /// A BinderPart implements a part of a binder. A binder is a very large class,
    /// binder parts help to separate various aspects of a binder into smaller parts.
    /// </summary>
    public abstract class BinderPart<TBinder>
        where TBinder: Binder<TBinder>
    {
        private TBinder _binder;

        public BinderPart(TBinder binder)
        {
            Debug.Assert(binder != null);
            this._binder = binder;
        }

        public TBinder Binder
        {
            get { return _binder; }
        }

        public Compilation Compilation
        {
            get { return _binder.Compilation; }
        }

        public TBinder Next
        {
            get { return (TBinder)_binder.Next; }
        }

        public RedNode Node
        {
            get { return _binder.Node; }
        }

        public virtual BindingOptions BindingOptions
        {
            get
            {
                return _binder.BindingOptions;
            }
        }

        public virtual BindingOptions NestingBindingOptions
        {
            get
            {
                return _binder.NestingBindingOptions;
            }
        }

        public virtual bool IsSemanticModelBinder
        {
            get { return _binder.IsSemanticModelBinder; }
        }

        protected TBinder GetBinder(RedNode node)
        {
            return _binder.GetBinder(node);
        }

    }
}

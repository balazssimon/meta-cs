using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// A Binder converts names to symbols and syntax nodes into bound trees. It is context
    /// dependent, relative to a location in source code.
    /// </summary>
    public abstract class Binder<TBinder>
        where TBinder : Binder<TBinder>
    {
        protected static Func<TBinder, bool> ReturnTrue = (TBinder b) => true;
        protected static Func<TBinder, bool> ReturnFalse = (TBinder b) => false;

        private readonly CompilationBase _compilation;
        private readonly TBinder _next;
        private readonly RedNode _node;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(CompilationBase compilation)
        {
            Debug.Assert(compilation != null);
            _compilation = compilation;
        }

        public Binder(TBinder next, RedNode node)
        {
            Debug.Assert(next != null);
            _next = next;
            _node = node;
            _compilation = next.Compilation;
        }

        public CompilationBase Compilation
        {
            get
            {
                return _compilation;
            }
        }

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        public TBinder Next
        {
            get
            {
                return _next;
            }
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

        public TBinder GetBinder(RedNode node)
        {
            return this.Compilation.GetBinder(node);
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

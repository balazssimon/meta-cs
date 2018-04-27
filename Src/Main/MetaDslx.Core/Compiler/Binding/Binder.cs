using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Binding.SymbolBinding;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// A Binder converts names to symbols and syntax nodes into bound trees. It is context
    /// dependent, relative to a location in source code.
    /// </summary>
    public abstract class Binder : IBinder
    {
        protected static Func<Binder, bool> ReturnTrue = (Binder b) => true;
        protected static Func<Binder, bool> ReturnFalse = (Binder b) => false;

        private readonly CompilationBase _compilation;
        private readonly Binder _next;
        private BoundNode _boundNode;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(CompilationBase compilation)
        {
            Debug.Assert(compilation != null);
            _compilation = compilation;
        }

        public Binder(Binder next)
        {
            Debug.Assert(next != null);
            _next = next;
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
        public IBinder Next
        {
            get
            {
                return _next;
            }
        }

        public virtual bool IsSemanticModelBinder
        {
            get { return true; }
        }

        public BoundTree BoundTree
        {
            get { return this.BoundNode?.BoundTree; }
        }

        public BoundNode BoundNode
        {
            get { return _boundNode; }
        }

        protected DiagnosticBag DiagnosticBag
        {
            get { return this.BoundTree?.DiagnosticBag; }
        }

        internal void InternalBind(BoundNode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (node.Compilation != this.Compilation) throw new ArgumentException("The node is from a different compilation.");
            Interlocked.Exchange(ref _boundNode, node);
            this.Bind();
        }

        public abstract void Bind();

        public Binder GetBinder(RedNode node)
        {
            return this.Compilation.GetBinder(node);
        }

        public TBinder AsBinder<TBinder>()
            where TBinder : class
        {
            var result = this as TBinder;
            if (result != null) return result;
            else return this.GetNextBinder<TBinder>();
        }

        protected TBinder GetNextBinder<TBinder>()
            where TBinder : class
        {
            IBinder next = this.Next;
            while (next != null)
            {
                var result = next as TBinder;
                if (result != null) return result;
                next = next.Next;
            }
            return this.Compilation.DefaultBinder as TBinder;
        }

#if DEBUG
        // Helper to allow displaying the binder hierarchy in the debugger.
        public IBinder[] GetAllBinders()
        {
            var binders = ArrayBuilder<IBinder>.GetInstance();
            for (IBinder binder = this; binder != null; binder = binder.Next)
            {
                binders.Add(binder);
            }
            return binders.ToArrayAndFree();
        }
#endif
    }

    public abstract class Binder<TBinder> : Binder
        where TBinder: class
    {
        public Binder(CompilationBase compilation) 
            : base(compilation)
        {
        }

        public Binder(Binder next) 
            : base(next)
        {
        }

        public new TBinder Next
        {
            get
            {
                return this.GetNextBinder<TBinder>();
            }
        }

        public bool ExecuteCurrent(Func<TBinder, bool> action)
        {
            return this.BoundNode?.ExecuteCurrent(this, action) ?? false;
        }

        public bool ExecuteCurrentOrInherited(Func<TBinder, bool> action)
        {
            return this.BoundNode?.ExecuteInherited(this, action) ?? false;
        }

        public bool ExecuteInherited(Func<TBinder, bool> action)
        {
            return this.BoundNode?.ExecuteInherited(this.Next as Binder, action) ?? false;
        }

        public bool ExecuteCurrentOrSynthesized(Func<TBinder, bool> action)
        {
            return this.BoundNode?.ExecuteCurrentOrSynthesized(this, action) ?? false;
        }

        public bool ExecuteSynthesized(Func<TBinder, bool> action)
        {
            return this.BoundNode?.ExecuteCurrentOrSynthesized(this.BoundNode?.GetPreviousBinderInNode(this), action) ?? false;
        }

    }
}

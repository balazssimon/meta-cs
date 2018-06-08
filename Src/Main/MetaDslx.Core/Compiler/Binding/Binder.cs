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
        private readonly Binder _parent;

        private RedNode _redNode;
        private int _index;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(CompilationBase compilation)
        {
            Debug.Assert(compilation != null);
            _compilation = compilation;
            _parent = null;
            _redNode = null;
            _index = -1;
        }

        public Binder(Binder parent)
        {
            Debug.Assert(parent != null);
            _parent = parent;
            _compilation = parent.Compilation;
            _redNode = null;
            _index = -1;
        }

        internal void InitializeByBinderFactory(RedNode syntaxNode, int index)
        {
            if (_index >= 0)
            {
                Debug.Assert(_redNode == syntaxNode);
                Debug.Assert(_index == index);
                return;
            }
            _redNode = syntaxNode;
            _index = index;
        }

        public CompilationBase Compilation
        {
            get
            {
                return _compilation;
            }
        }

        public IBinder Parent
        {
            get
            {
                return _parent;
            }
        }

        public virtual bool IsSemanticModelBinder
        {
            get { return true; }
        }

        public RedNode RedNode
        {
            get
            {
                return _redNode;
            }
        }

        internal int Index
        {
            get { return _index; }
        }

        public BoundNode BoundNode
        {
            get
            {
                return _compilation.Bind(_redNode);
            }
        }

        public TBinder GetDefaultBinder<TBinder>()
            where TBinder : class
        {
            return this.Compilation.GetDefaultBinder<TBinder>();
        }

        public TBinder GetBinder<TBinder>()
            where TBinder : class
        {
            return this.GetBinderOfType<TBinder>(this, b => true);
        }

        public TBinder GetBinder<TBinder>(Func<TBinder, bool> condition)
            where TBinder : class
        {
            return this.GetBinderOfType<TBinder>(this, condition);
        }

        public TBinder GetParentBinder<TBinder>()
            where TBinder : class
        {
            return this.GetBinderOfType<TBinder>(this.Parent, b => true);
        }

        public TBinder GetParentBinder<TBinder>(Func<TBinder, bool> condition)
            where TBinder : class
        {
            return this.GetBinderOfType<TBinder>(this.Parent, condition);
        }

        private TBinder GetBinderOfType<TBinder>(IBinder next, Func<TBinder, bool> condition)
            where TBinder: class
        {
            while (next != null)
            {
                var result = next as TBinder;
                if (result != null && condition(result)) return result;
                next = next.Parent;
            }
            return this.GetDefaultBinder<TBinder>();
        }

        public ImmutableArray<TBinder> GetChildBinders<TBinder>()
            where TBinder : class
        {
            ArrayBuilder<TBinder> builder = ArrayBuilder<TBinder>.GetInstance();
            try
            {
                this.ExecuteSynthesized<TBinder>(
                    b => {
                        builder.Add(b);
                        return true;
                    });
                return builder.ToImmutableAndFree();
            }
            finally
            {
                builder.Free();
            }
        }

        public ImmutableArray<TBinder> GetChildBinders<TBinder>(Func<TBinder, bool> condition)
            where TBinder : class
        {
            ArrayBuilder<TBinder> builder = ArrayBuilder<TBinder>.GetInstance();
            try
            {
                this.ExecuteSynthesized<TBinder>(false, condition,
                    b => {
                        builder.Add(b);
                        return true;
                    });
                return builder.ToImmutableAndFree();
            }
            finally
            {
                builder.Free();
            }
        }

        public bool ExecuteCurrentOrInherited<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteInherited<TBinder>(true, action);
        }

        public bool ExecuteInherited<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteInherited<TBinder>(false, action);
        }

        private bool ExecuteInherited<TBinder>(bool includeCurrentBinder, Func<TBinder, bool> action)
            where TBinder : class
        {
            IBinder currentBinder = includeCurrentBinder ? this : this.Parent;
            while (currentBinder != null)
            {
                if (this.TryExecute(currentBinder, b => true, action))
                {
                    return true;
                }
                currentBinder = currentBinder.Parent;
            }
            return false;
        }

        public bool ExecuteCurrentOrSynthesized<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteSynthesized<TBinder>(true, b => true, action);
        }

        public bool ExecuteSynthesized<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteSynthesized<TBinder>(false, b => true, action);
        }

        private bool ExecuteSynthesized<TBinder>(bool includeCurrentBinder, Func<TBinder, bool> condition, Func<TBinder, bool> action)
            where TBinder : class
        {
            if (includeCurrentBinder)
            {
                if (this.TryExecute(this, condition, action))
                {
                    return true;
                }
            }
            if (_index >= 0 && _redNode != null)
            {
                var currentBinders = this.Compilation.GetBinders(_redNode);
                if (currentBinders.Length > 0)
                {
                    int index = _index + 1;
                    while (index < currentBinders.Length)
                    {
                        if (this.TryExecute(currentBinders[index], condition, action))
                        {
                            return true;
                        }
                        ++index;
                    }
                }
            }
            bool success = false;
            Stack<RedNode> nodeStack = new Stack<RedNode>();
            nodeStack.Push(_redNode);
            while (nodeStack.Count > 0)
            {
                RedNode currentNode = nodeStack.Pop();
                if (currentNode == null) continue;
                bool stop = false;
                if (currentNode != _redNode)
                {
                    var binders = this.Compilation.GetBinders(currentNode);
                    for (int i = 0; i < binders.Length; i++)
                    {
                        if (this.TryExecute(binders[i], condition, action))
                        {
                            stop = true;
                            success = true;
                        }
                    }
                }
                if (!stop && (currentNode is SyntaxNode))
                {
                    foreach (var child in ((SyntaxNode)currentNode).ChildNodesAndTokens())
                    {
                        nodeStack.Push(child);
                    }
                }
            }
            return success;
        }

        private bool TryExecute<TBinder>(IBinder binder, Func<TBinder, bool> condition, Func<TBinder, bool> action)
            where TBinder : class
        {
            TBinder typedBinder = binder as TBinder;
            if (typedBinder != null && condition(typedBinder))
            {
                return action(typedBinder);
            }
            return false;
        }

#if DEBUG
        // Helper to allow displaying the binder hierarchy in the debugger.
        public IBinder[] GetAllBinders()
        {
            var binders = ArrayBuilder<IBinder>.GetInstance();
            for (IBinder binder = this; binder != null; binder = binder.Parent)
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

        public new TBinder Parent
        {
            get
            {
                return this.GetParentBinder<TBinder>();
            }
        }

        public TBinder GetParentBinder()
        {
            return base.GetParentBinder<TBinder>();
        }

        public TBinder GetParentBinder(Func<TBinder, bool> condition)
        {
            return base.GetParentBinder<TBinder>(condition);
        }

        public ImmutableArray<TBinder> GetChildBinders()
        {
            return base.GetChildBinders<TBinder>();
        }

        public ImmutableArray<TBinder> GetChildBinders(Func<TBinder, bool> condition)
        {
            return base.GetChildBinders<TBinder>(condition);
        }

        public bool ExecuteCurrentOrInherited(Func<TBinder, bool> action)
        {
            return base.ExecuteInherited<TBinder>(action);
        }

        public bool ExecuteInherited(Func<TBinder, bool> action)
        {
            return base.ExecuteInherited<TBinder>(action);
        }

        public bool ExecuteCurrentOrSynthesized(Func<TBinder, bool> action)
        {
            return base.ExecuteSynthesized<TBinder>(action);
        }

        public bool ExecuteSynthesized(Func<TBinder, bool> action)
        {
            return base.ExecuteSynthesized<TBinder>(action);
        }
    }
}

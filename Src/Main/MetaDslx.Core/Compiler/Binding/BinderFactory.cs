using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public abstract class BinderFactory
    {
        private readonly Compilation _compilation;
        private readonly SyntaxTree _syntaxTree;

        // In a typing scenario, Bind is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _binderFactoryVisitorPool;
        private readonly ObjectPool<ArrayBuilder<Binder>> _binderArrayBuilderPool;

        internal BinderFactory(CompilationBase compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;

            _binderFactoryVisitorPool = new ObjectPool<BinderFactoryVisitor>(() => compilation.Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);
            _binderArrayBuilderPool = ArrayBuilder<Binder>.CreatePool();
        }

        public CompilationBase Compilation
        {
            get { return (CompilationBase)_compilation; }
        }

        public Binder DefaultBinder
        {
            get { return (Binder)this.Compilation.GetDefaultBinder<IBinder>(); }
        }

        public SyntaxTree SyntaxTree
        {
            get
            {
                return _syntaxTree;
            }
        }

        public bool InScript
        {
            get
            {
                return _syntaxTree.Options.Kind == SourceCodeKind.Script;
            }
        }

        public TBinder GetBinder<TBinder>(RedNode node)
            where TBinder : class
        {
            var currentNode = node;
            while (currentNode != null)
            {
                var binders = this.GetBinders(node);
                var binder = binders.FirstOrDefault();
                if (binder != null) return binder.GetBinder<TBinder>();
                currentNode = currentNode.Parent;
            }
            return null;
        }

        public ImmutableArray<Binder> GetBinders(RedNode node)
        {
            int position = node.SpanStart;
            var syntaxNode = node as SyntaxNode;
            if (syntaxNode != null)
            {
                return this.GetBinders(syntaxNode, position, false);
            }
            else
            {
                return this.GetBinders(node.Parent, position, true);
            }
        }

        private ImmutableArray<Binder> GetBinders(SyntaxNode node, int position, bool bindChild)
        {
            Debug.Assert(node != null);
            BinderFactoryVisitor visitor = _binderFactoryVisitorPool.Allocate();
            ArrayBuilder<Binder> binders = _binderArrayBuilderPool.Allocate();
            try
            {
                visitor.Reset(position, bindChild, binders);
                node.Accept(visitor);
                return binders.ToImmutable();
            }
            finally
            {
                _binderFactoryVisitorPool.Free(visitor);
                _binderArrayBuilderPool.Free(binders);
            }
        }

        public bool TryGetBinders(RedNode node, object usage, out ImmutableArray<Binder> binders)
        {
            BinderCacheKey key = new BinderCacheKey(node, usage);
            return this.TryGetBinders(key, out binders);
        }

        public bool TryAddBinders(RedNode node, object usage, ref ImmutableArray<Binder> binders)
        {
            BinderCacheKey key = new BinderCacheKey(node, usage);
            if (this.TryAddBinders(key, ref binders))
            {
                for (int i = 0; i < binders.Length; i++)
                {
                    binders[i].InitializeByBinderFactory(node, i);
                }
                return true;
            }
            return false;
        }

        protected virtual bool TryGetBinders(BinderCacheKey key, out ImmutableArray<Binder> binders)
        {
            binders = ImmutableArray<Binder>.Empty;
            return false;
        }

        protected virtual bool TryAddBinders(BinderCacheKey key, ref ImmutableArray<Binder> binders)
        {
            return false;
        }


        // PERF: we are not using ValueTuple because its Equals is relatively slow.
        protected struct BinderCacheKey : IEquatable<BinderCacheKey>
        {
            public readonly RedNode syntaxNode;
            public readonly object usage;

            public BinderCacheKey(RedNode syntaxNode, object usage)
            {
                this.syntaxNode = syntaxNode;
                this.usage = usage;
            }

            bool IEquatable<BinderCacheKey>.Equals(BinderCacheKey other)
            {
                return syntaxNode == other.syntaxNode && this.usage == other.usage;
            }

            public override int GetHashCode()
            {
                return Hash.Combine(syntaxNode.GetHashCode(), (int)usage);
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }
        }
    }
}

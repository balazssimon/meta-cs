using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public sealed class BinderFactory
    {
        // key in the binder cache.
        // PERF: we are not using ValueTuple because its Equals is relatively slow.
        internal struct BinderCacheKey : IEquatable<BinderCacheKey>
        {
            private static object GeneralUsage = new object();

            public readonly SyntaxNode syntaxNode;
            public readonly object usage;

            public BinderCacheKey(SyntaxNode syntaxNode, object usage)
            {
                this.syntaxNode = syntaxNode;
                this.usage = usage ?? GeneralUsage;
            }

            bool IEquatable<BinderCacheKey>.Equals(BinderCacheKey other)
            {
                return syntaxNode == other.syntaxNode && this.usage == other.usage;
            }

            public override int GetHashCode()
            {
                return Hash.Combine(syntaxNode.GetHashCode(), usage.GetHashCode());
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }
        }


        // This dictionary stores contexts so we don't have to recreate them, which can be
        // expensive. 
        private readonly ConcurrentCache<BinderCacheKey, Binder> _binderCache;
        private readonly Compilation _compilation;
        private readonly SyntaxTree _syntaxTree;
        private readonly BuckStopsHereBinder _buckStopsHereBinder;

        // In a typing scenario, GetBinder is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _binderFactoryVisitorPool;

        internal BinderFactory(Compilation compilation, SyntaxTree syntaxTree)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;

            _binderFactoryVisitorPool = new ObjectPool<BinderFactoryVisitor>(() => compilation.Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);

            // 50 is more or less a guess, but it seems to work fine for scenarios that I tried.
            // we need something big enough to keep binders for most classes and some methods 
            // in a typical syntax tree.
            // On the other side, note that the whole factory is weakly referenced and therefore short lived, 
            // making this cache big is not very useful.
            // I noticed that while compiling Roslyn C# compiler most caches never see 
            // more than 50 items added before getting collected.
            _binderCache = new ConcurrentCache<BinderCacheKey, Binder>(50);

            _buckStopsHereBinder = new BuckStopsHereBinder(compilation);
        }

        public CompilationBase Compilation
        {
            get { return (CompilationBase)_compilation; }
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

        public BuckStopsHereBinder BuckStopsHereBinder
        {
            get
            {
                return _buckStopsHereBinder;
            }
        }

        /// <summary>
        /// Note, there is no guarantee that the factory always gives back the same binder instance for the same <param name="node"/>.
        /// </summary>
        public Binder GetBinder(RedNode node)
        {
            int position = node.SpanStart;

            // Special case: In interactive code, we may be trying to retrieve a binder for global statements
            // at the *very* top-level (i.e. in a completely empty file). In this case, we use the compilation unit
            // directly since it's parent would be null.
            if (InScript && node.Parent == null)
            {
                SyntaxNode rootNode = node as SyntaxNode;
                if (rootNode != null)
                {
                    return GetBinder(rootNode, position);
                }
                else
                {
                    return null;
                }
            }

            return GetBinder(node.Parent, position);
        }

        public Binder GetBinder(SyntaxNode node, int position)
        {
            Debug.Assert(node != null);

            Binder result = null;

            BinderFactoryVisitor visitor = _binderFactoryVisitorPool.Allocate();
            try
            {
                visitor.Reset(position);
                result = node.Accept(visitor);
            }
            finally
            {
                _binderFactoryVisitorPool.Free(visitor);
            }

            return result;
        }

        public bool TryGetBinder(SyntaxNode node, object usage, out Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            return _binderCache.TryGetValue(key, out binder);
        }

        public void TryAddBinder(SyntaxNode node, object usage, Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            _binderCache.TryAdd(key, binder);
        }
    }
}

using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    internal sealed class CachingBinderFactory : BinderFactory
    {
        // key in the binder cache.
        // PERF: we are not using ValueTuple because its Equals is relatively slow.
        internal struct BinderCacheKey : IEquatable<BinderCacheKey>
        {
            private static object GeneralUsage = new object();

            public readonly RedNode syntaxNode;
            public readonly object usage;

            public BinderCacheKey(RedNode syntaxNode, object usage)
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

        // In a typing scenario, GetBinder is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _binderFactoryVisitorPool;

        internal CachingBinderFactory(CompilationBase compilation, SyntaxTree syntaxTree)
            : base(compilation, syntaxTree)
        {
            _binderFactoryVisitorPool = new ObjectPool<BinderFactoryVisitor>(() => compilation.Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);

            // 50 is more or less a guess, but it seems to work fine for scenarios that I tried.
            // we need something big enough to keep binders for most classes and some methods 
            // in a typical syntax tree.
            // On the other side, note that the whole factory is weakly referenced and therefore short lived, 
            // making this cache big is not very useful.
            // I noticed that while compiling Roslyn C# compiler most caches never see 
            // more than 50 items added before getting collected.
            _binderCache = new ConcurrentCache<BinderCacheKey, Binder>(50);
        }

        public override bool TryGetBinder(RedNode node, object usage, out Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            return _binderCache.TryGetValue(key, out binder);
        }

        public override bool TryAddBinder(RedNode node, object usage, ref Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            if (!_binderCache.TryAdd(key, binder))
            {
                return _binderCache.TryGetValue(key, out binder);
            }
            return true;
        }

    }
}

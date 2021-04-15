using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal sealed class CachingBinderFactory : BinderFactory
    {
        // This dictionary stores contexts so we don't have to recreate them, which can be
        // expensive. 
        private readonly ConcurrentCache<BinderCacheKey, Binder> _binderCache;

        internal CachingBinderFactory(LanguageCompilation compilation, SyntaxTree syntaxTree)
            : base(compilation, syntaxTree)
        {
            // 50 is more or less a guess, but it seems to work fine for scenarios that I tried.
            // we need something big enough to keep binders for most classes and some methods 
            // in a typical syntax tree.
            // On the other side, note that the whole factory is weakly referenced and therefore short lived, 
            // making this cache big is not very useful.
            // I noticed that while compiling Roslyn C# compiler most caches never see 
            // more than 50 items added before getting collected.
            _binderCache = new ConcurrentCache<BinderCacheKey, Binder>(50);
        }

        public override bool TryGetBinder(LanguageSyntaxNode node, object usage, out Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            return _binderCache.TryGetValue(key, out binder);
        }

        public override bool TryAddBinder(LanguageSyntaxNode node, object usage, ref Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            if (!_binderCache.TryAdd(key, binder))
            {
                if (_binderCache.TryGetValue(key, out Binder oldBinder))
                {
                    binder = oldBinder;
                }
                return false;
            }
            return true;
        }

    }
}

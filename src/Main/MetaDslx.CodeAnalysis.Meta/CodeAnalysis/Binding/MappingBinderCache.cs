using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal sealed class MappingBinderCache : BinderCache
    {
        private ConcurrentDictionary<BinderCacheKey, Binder> _map;

        internal MappingBinderCache(LanguageCompilation compilation, LanguageSyntaxTree syntaxTree, bool ignoreAccessibility) 
            : base(compilation, syntaxTree)
        {
            _map = new ConcurrentDictionary<BinderCacheKey, Binder>();
        }

        public override bool TryGetBinder(LanguageSyntaxNode node, object usage, out Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            return _map.TryGetValue(key, out binder);
        }

        public override bool TryAddBinder(LanguageSyntaxNode node, object usage, ref Binder binder)
        {
            var key = new BinderCacheKey(node, usage);
            if (!_map.TryAdd(key, binder))
            {
                if (_map.TryGetValue(key, out Binder oldBinder))
                {
                    binder = oldBinder;
                }
                return false;
            }
            return true;
        }
    }
}
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Compiler.Binding
{
    public class CachingBinderFactory : BinderFactory
    {
        private readonly ConcurrentCache<BinderCacheKey, ImmutableArray<Binder>> _map;

        internal CachingBinderFactory(CompilationBase compilation, SyntaxTree syntaxTree)
            : base(compilation, syntaxTree)
        {
            // 50 is more or less a guess, but it seems to work fine for scenarios that I tried.
            // we need something big enough to keep binders for most classes and some methods 
            // in a typical syntax tree.
            // On the other side, note that the whole factory is weakly referenced and therefore short lived, 
            // making this cache big is not very useful.
            // I noticed that while compiling Roslyn C# compiler most caches never see 
            // more than 50 items added before getting collected.
            _map = new ConcurrentCache<BinderCacheKey, ImmutableArray<Binder>>(50);
        }

        protected override bool TryGetBinders(BinderCacheKey key, out ImmutableArray<Binder> binders)
        {
            return _map.TryGetValue(key, out binders);
        }

        protected override bool TryAddBinders(BinderCacheKey key, ref ImmutableArray<Binder> binders)
        {
            if (!_map.TryAdd(key, binders))
            {
                return _map.TryGetValue(key, out binders);
            }
            return true;
        }
    }
}

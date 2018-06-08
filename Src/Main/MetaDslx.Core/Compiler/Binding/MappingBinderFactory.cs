using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    internal sealed class MappingBinderFactory : BinderFactory
    {
        private ConcurrentDictionary<BinderCacheKey, ImmutableArray<Binder>> _map;

        internal MappingBinderFactory(CompilationBase compilation, SyntaxTree syntaxTree) 
            : base(compilation, syntaxTree)
        {
            _map = new ConcurrentDictionary<BinderCacheKey, ImmutableArray<Binder>>();
        }

        protected override bool TryGetBinders(BinderCacheKey key, out ImmutableArray<Binder> binders)
        {
            return _map.TryGetValue(key, out binders);
        }

        protected override bool TryAddBinders(BinderCacheKey key, ref ImmutableArray<Binder> binders)
        {
            if (!_map.TryAdd(key, binders))
            {
                ImmutableInterlocked.InterlockedExchange(ref binders, _map[key]);
                return true;
            }
            return true;
        }
    }
}

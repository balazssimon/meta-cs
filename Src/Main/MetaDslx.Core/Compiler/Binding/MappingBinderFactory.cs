using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    internal sealed class MappingBinderFactory<TBinder> : BinderFactory<TBinder>
        where TBinder: Binder<TBinder>
    {
        private ConcurrentDictionary<RedNode, TBinder> _map;

        internal MappingBinderFactory(CompilationBase compilation, SyntaxTree syntaxTree) 
            : base(compilation, syntaxTree)
        {
            _map = new ConcurrentDictionary<RedNode, TBinder>();
        }

        public override bool TryGetBinder(RedNode node, object usage, out TBinder binder)
        {
            if (usage == null)
            {
                return _map.TryGetValue(node, out binder);
            }
            else
            {
                binder = null;
                return false;
            }
        }

        public override bool TryAddBinder(RedNode node, object usage, ref TBinder binder)
        {
            if (usage == null)
            {
                if (!_map.TryAdd(node, binder))
                {
                    binder = _map[node];
                    return true;
                }
                return true;
            }
            return false;
        }
    }
}

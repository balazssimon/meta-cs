using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    internal sealed class MappingBinderFactory : BinderFactory
    {
        private ConcurrentDictionary<RedNode, Binder> _map;

        internal MappingBinderFactory(CompilationBase compilation, SyntaxTree syntaxTree) 
            : base(compilation, syntaxTree)
        {
            _map = new ConcurrentDictionary<RedNode, Binder>();
        }

        public override bool TryGetBinder(RedNode node, object usage, out Binder binder)
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

        public override bool TryAddBinder(RedNode node, object usage, ref Binder binder)
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

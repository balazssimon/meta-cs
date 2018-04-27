using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    internal sealed class MappingBinderFactory : BinderFactory
    {
        private ConcurrentDictionary<RedNode, BoundNode> _map;

        internal MappingBinderFactory(CompilationBase compilation, SyntaxTree syntaxTree) 
            : base(compilation, syntaxTree)
        {
            _map = new ConcurrentDictionary<RedNode, BoundNode>();
        }

        public override bool TryGetBoundNode(RedNode node, out BoundNode boundNode)
        {
            return _map.TryGetValue(node, out boundNode);
        }

        public override bool TryAddBoundNode(RedNode node, ref BoundNode boundNode)
        {
            if (!_map.TryAdd(node, boundNode))
            {
                Interlocked.Exchange(ref boundNode, _map[node]);
                return true;
            }
            return true;
        }
    }
}

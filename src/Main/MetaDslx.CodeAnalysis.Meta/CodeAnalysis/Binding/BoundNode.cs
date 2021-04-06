using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class BoundNode
    {
        private BoundTree _boundTree;
        private BoundNode _parent;
        internal int _index;
        private SyntaxNodeOrToken _syntax;
        private ConcurrentDictionary<SyntaxNodeOrToken, BoundNode> _children;

        public BoundNode(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public BoundNode()
        {
        }

        public BoundTree BoundTree => _boundTree;

        public BoundNode ParentBoundNode => _parent;

        public SyntaxNodeOrToken Syntax => _syntax;

        public virtual ImmutableArray<Diagnostic> Diagnostics => ImmutableArray<Diagnostic>.Empty;

        public Binder GetBinder()
        {
            var lowestBinder = _boundTree.Compilation.GetBinder(_syntax);
            var result = lowestBinder;
            while (result != null && result._index != _index)
            {
                result = result.Next;
            }
            return result;
        }

        internal BoundNode GetChild(SyntaxNodeOrToken syntax)
        {
            if (_children != null && _children.TryGetValue(syntax, out var result)) return result;
            else return null;
        }

        internal BoundNode TryAddChild(SyntaxNodeOrToken syntax, BoundNode child)
        {
            if (_children == null)
            {
                Interlocked.CompareExchange(ref _children, new ConcurrentDictionary<SyntaxNodeOrToken, BoundNode>(), null);
            }
            child._syntax = syntax;
            child._parent = this;
            child._boundTree = this._boundTree;
            _children.TryAdd(syntax, child);
            var result = _children[syntax];
            return result;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}

using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
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
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class BoundNode
    {
        private BoundTree _boundTree;
        private BoundNode _parent;
        private SyntaxNodeOrToken _syntax;
        private ConcurrentDictionary<SyntaxNodeOrToken, BoundNode> _children;

        public BoundNode(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public BoundNode(SyntaxNodeOrToken syntax, BoundNode parent)
        {
            Debug.Assert(parent != null);
            _boundTree = parent._boundTree;
            _parent = parent;
            _syntax = syntax;
        }

        public BoundTree BoundTree => _boundTree;

        public BoundNode ParentBoundNode => _parent;

        public SyntaxNodeOrToken Syntax => _syntax;

        public Binder GetBinder()
        {
            var result = _boundTree.Compilation.GetBinder(_syntax);
            while (result != null && result.BoundNode != this) result = result.Next;
            return result;
        }

        internal BoundNode GetChild(SyntaxNodeOrToken syntax)
        {
            if (_children != null && _children.TryGetValue(syntax, out var result)) return result;
            else return null;
        }

        internal bool TryAddChild(SyntaxNodeOrToken syntax, BoundNode child)
        {
            if (_children == null) _children = new ConcurrentDictionary<SyntaxNodeOrToken, BoundNode>();
            return _children.TryAdd(syntax, child);
        }
    }
}

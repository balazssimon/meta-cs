using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal class IncrementalSyntaxNode
    {
        private readonly int _lookaheadBefore;
        private readonly int _lookaheadAfter;
        private readonly object _state;
        private readonly ImmutableArray<IncrementalSyntaxNode> _children;

#if DEBUG
        private int _version;
#endif

#if DEBUG
        public IncrementalSyntaxNode(int lookaheadBefore, int lookaheadAfter, object state, ImmutableArray<IncrementalSyntaxNode> children, int version)
#else
        public IncrementalSyntaxNode(int lookaheadBefore, int lookaheadAfter, object state, ImmutableArray<IncrementalSyntaxNode> children)
#endif
        {
            _lookaheadBefore = lookaheadBefore;
            _lookaheadAfter = lookaheadAfter;
            _state = state;
            _children = children;
            _version = version;
        }

        public int LookaheadBefore => _lookaheadBefore;
        public int LookaheadAfter => _lookaheadAfter;
        public object State => _state;
        public ImmutableArray<IncrementalSyntaxNode> Children => _children;
#if DEBUG
        private int Version => _version;
#endif

    }
}

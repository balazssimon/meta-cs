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
        private readonly ParserState _stateBefore;
        private readonly ParserState _stateAfter;
        private readonly ImmutableArray<object> _children;

#if DEBUG
        private int _version;
#endif

#if DEBUG
        public IncrementalSyntaxNode(int lookaheadBefore, int lookaheadAfter, ParserState stateBefore, ParserState stateAfter, ImmutableArray<object> children, int version)
#else
        public IncrementalSyntaxNode(int lookaheadBefore, int lookaheadAfter, ParserState stateBefore, ParserState stateAfter, ImmutableArray<object> children)
#endif
        {
            _lookaheadBefore = lookaheadBefore;
            _lookaheadAfter = lookaheadAfter;
            _stateBefore = stateBefore;
            _stateAfter = stateAfter;
            _children = children;
            _version = version;
        }

        public int LookaheadBefore => _lookaheadBefore;
        public int LookaheadAfter => _lookaheadAfter;
        public ParserState StateBefore => _stateBefore;
        public ParserState StateAfter => _stateAfter;
        public ImmutableArray<object> Children => _children;
#if DEBUG
        public int Version => _version;
#endif

    }
}

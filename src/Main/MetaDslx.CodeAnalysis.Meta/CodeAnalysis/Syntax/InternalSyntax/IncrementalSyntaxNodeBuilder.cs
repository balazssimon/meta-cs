using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal class IncrementalSyntaxNodeBuilder
    {
        private readonly ParserState _stateBefore;
        private readonly ArrayBuilder<object> _children;

#if DEBUG
        private int _version;
#endif

#if DEBUG
        public IncrementalSyntaxNodeBuilder(ParserState stateBefore, int version)
#else
        public IncrementalSyntaxNodeBuilder(ParserState stateBefore)
#endif
        {
            _stateBefore = stateBefore;
            _children = ArrayBuilder<object>.GetInstance();
            _version = version;
            LookaheadBefore = int.MaxValue;
            LookaheadAfter = int.MinValue;
        }

        public int LookaheadBefore { get; set; }
        public int LookaheadAfter { get; set; }
        public ParserState StateBefore => _stateBefore;
        public ArrayBuilder<object> Children => _children;
#if DEBUG
        public int Version => _version;
#endif

        public IncrementalSyntaxNode ToImmutable(ParserState stateAfter)
        {
#if DEBUG
            return new IncrementalSyntaxNode(LookaheadBefore, LookaheadAfter, _stateBefore, stateAfter, _children.ToImmutable(), _version);
#else
            return new IncrementalSyntaxNode(LookaheadBefore, LookaheadAfter, _stateBefore, stateAfter, _children.ToImmutable());
#endif
        }
    }
}

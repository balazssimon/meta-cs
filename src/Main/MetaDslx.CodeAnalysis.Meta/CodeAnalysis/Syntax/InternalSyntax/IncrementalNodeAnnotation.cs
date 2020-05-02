using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public sealed class IncrementalNodeAnnotation
    {
        public readonly ParserState State;
        public readonly int LookaheadBefore;
        public readonly int LookaheadAfter;
#if DEBUG
        public readonly int Version;
#endif

#if DEBUG
        public IncrementalNodeAnnotation(ParserState state, int lookaheadBefore, int lookaheadAfter, int version)
#else
        public IncrementalNodeAnnotation(ParserState state, int lookaheadBefore, int lookaheadAfter)
#endif
        {
            State = state;
            LookaheadBefore = lookaheadBefore;
            LookaheadAfter = lookaheadAfter;
#if DEBUG
            Version = version;
#endif
        }
    }
}

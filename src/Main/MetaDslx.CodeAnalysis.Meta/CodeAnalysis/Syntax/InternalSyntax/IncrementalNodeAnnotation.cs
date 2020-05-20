using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public sealed class IncrementalNodeAnnotation
    {
        public readonly ParserState StartState;
        public readonly ParserState EndState;
        public readonly int LookaheadBefore;
        public readonly int LookaheadAfter;
#if DEBUG
        public readonly int Version;
#endif

#if DEBUG
        public IncrementalNodeAnnotation(ParserState startState, ParserState endState, int lookaheadBefore, int lookaheadAfter, int version)
#else
        public IncrementalNodeAnnotation(ParserState startState, ParserState endState,  int lookaheadBefore, int lookaheadAfter)
#endif
        {
            StartState = startState;
            EndState = endState;
            LookaheadBefore = lookaheadBefore;
            LookaheadAfter = lookaheadAfter;
#if DEBUG
            Version = version;
#endif
        }
    }
}

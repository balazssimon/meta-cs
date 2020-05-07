using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class IncrementalTreeAnnotation
    {
        public readonly LexerMode StartMode;
        public readonly ParserState StartState;
        public readonly LexerMode EndMode;
        public readonly ParserState EndState;

        public readonly int MinLexerLookahead;
        public readonly int MaxLexerLookahead;

        public IncrementalTreeAnnotation(LexerMode startMode, ParserState startState, LexerMode endMode, ParserState endState, int minLexerLookahead, int maxLexerLookahead)
        {
            StartMode = startMode;
            StartState = startState;
            EndMode = endMode;
            EndState = endState;
            MinLexerLookahead = minLexerLookahead;
            MaxLexerLookahead = maxLexerLookahead;
        }
    }
}

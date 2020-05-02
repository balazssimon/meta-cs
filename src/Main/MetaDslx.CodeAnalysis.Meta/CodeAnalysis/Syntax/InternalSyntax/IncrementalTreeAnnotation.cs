using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class IncrementalTreeAnnotation
    {
        public readonly int MinLexerLookahead;
        public readonly int MaxLexerLookahead;

        public IncrementalTreeAnnotation(int minLexerLookahead, int maxLexerLookahead)
        {
            MinLexerLookahead = minLexerLookahead;
            MaxLexerLookahead = maxLexerLookahead;
        }
    }
}

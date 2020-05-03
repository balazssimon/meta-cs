using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4ParserState : ParserState
    {
        public readonly int State;

        public Antlr4ParserState(int state)
        {
            State = state;
        }
    }
}

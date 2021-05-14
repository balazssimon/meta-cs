﻿using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4ParserState : ParserState
    {
        public readonly int State;

        public Antlr4ParserState(int hashCode, int state)
            : base(hashCode)
        {
            State = state;
        }

        public override string ToString()
        {
            return $"state={State}";
        }
    }
}

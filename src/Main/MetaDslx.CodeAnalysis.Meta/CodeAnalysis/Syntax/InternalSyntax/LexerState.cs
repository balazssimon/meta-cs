using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class LexerState : State
    {
        public LexerState(int hashCode)
            : base(hashCode)
        {
        }
    }
}

using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public interface IAntlr4Lexer
    {
        Lexer Lexer { get; }
    }
}

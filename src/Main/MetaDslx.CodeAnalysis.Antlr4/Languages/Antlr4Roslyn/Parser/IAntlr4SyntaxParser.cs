using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public interface IAntlr4SyntaxParser
    {
        Language Language { get; }
        IReadOnlyList<IToken> Tokens { get; }
        Antlr4.Runtime.Lexer Lexer { get; }
        Antlr4.Runtime.Parser Parser { get; }
    }
}

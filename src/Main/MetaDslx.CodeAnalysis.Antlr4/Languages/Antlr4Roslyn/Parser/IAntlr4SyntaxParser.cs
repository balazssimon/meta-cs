using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Parser
{
    public interface IAntlr4SyntaxParser
    {
        Language Language { get; }
        IReadOnlyList<IToken> Tokens { get; }
        Lexer Lexer { get; }
        Antlr4.Runtime.Parser Parser { get; }
    }
}

using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn
{
    public interface IAntlr4SyntaxFactory
    {
        Lexer CreateAntlr4Lexer(ICharStream input);
        Parser CreateAntlr4Parser(ITokenStream input);
    }
}

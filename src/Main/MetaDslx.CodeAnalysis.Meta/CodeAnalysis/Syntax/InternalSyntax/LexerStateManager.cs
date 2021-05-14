using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class LexerStateManager : StateManager<LexerState>
    {
        private readonly SyntaxLexer _lexer;

        public LexerStateManager(SyntaxLexer lexer)
        {
            _lexer = lexer;
        }

        protected SyntaxLexer Lexer => _lexer;

    }
}

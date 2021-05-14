using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class ParserStateManager : StateManager<ParserState>
    {
        private readonly SyntaxParser _parser;

        public ParserStateManager(SyntaxParser parser)
        {
            _parser = parser;
        }

        protected SyntaxParser Parser => _parser;

    }
}

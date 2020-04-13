using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class IncrementalLexer : Lexer
    {
        private readonly IncrementalLexer _oldLexer;
        private readonly ImmutableArray<TextChangeRange> _changes;

        public IncrementalLexer(Language language, SourceText text, IncrementalLexer oldLexer, ImmutableArray<TextChangeRange> changes) 
            : base(language, text)
        {
            _oldLexer = oldLexer;
            _changes = changes;
        }
    }
}

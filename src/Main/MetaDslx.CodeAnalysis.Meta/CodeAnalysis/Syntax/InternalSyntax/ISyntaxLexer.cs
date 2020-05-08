using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public interface ISyntaxLexer
    {
        Language Language { get; }
        SourceText Text { get; }
        LanguageParseOptions Options { get; }
        LexerMode Mode { get; }
        DirectiveStack Directives { get; }
        int Position { get; }
        void Reset(int position, DirectiveStack directives);
        InternalSyntaxToken Lex(ref LexerMode mode);
    }
}

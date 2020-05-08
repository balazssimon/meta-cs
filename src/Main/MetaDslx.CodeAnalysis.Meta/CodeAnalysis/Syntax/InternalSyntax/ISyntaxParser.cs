using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public interface ISyntaxParser
    {
        Language Language { get; }
        SourceText Text { get; }
        bool IsScript { get; }
        LanguageParseOptions Options { get; }
        ParserState State { get; }
        LanguageSyntaxNode Parse();
    }
}

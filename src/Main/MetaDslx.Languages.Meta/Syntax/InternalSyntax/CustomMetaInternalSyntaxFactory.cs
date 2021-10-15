using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    internal class CustomMetaInternalSyntaxFactory : MetaInternalSyntaxFactory
    {
        public CustomMetaInternalSyntaxFactory(MetaSyntaxFacts syntaxFacts) 
            : base(syntaxFacts)
        {
        }

        public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions? options)
        {
            return new CustomMetaSyntaxLexer(text, options != null ? (MetaParseOptions)options : MetaParseOptions.Default);
        }
    }
}

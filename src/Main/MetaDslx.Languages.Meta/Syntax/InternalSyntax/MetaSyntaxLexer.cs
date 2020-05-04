// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    public class MetaSyntaxLexer : Antlr4SyntaxLexer
    {
        public MetaSyntaxLexer(SourceText text, MetaParseOptions options) 
            : base(MetaLanguage.Instance, text, options)
        {
        }
        protected override InternalSyntaxToken CreateToken(GreenNode leadingTrivia, SyntaxKind kind, string text, GreenNode trailingTrivia)
        {
            return MetaLanguage.Instance.InternalSyntaxFactory.Token(leadingTrivia, kind, text, trailingTrivia);
        }
        protected override InternalSyntaxTrivia CreateTrivia(SyntaxKind kind, string text)
        {
            return MetaLanguage.Instance.InternalSyntaxFactory.Trivia(kind, text);
        }
    }
}


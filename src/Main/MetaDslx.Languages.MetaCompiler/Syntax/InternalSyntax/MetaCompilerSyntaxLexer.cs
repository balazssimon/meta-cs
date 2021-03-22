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
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Text;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
namespace MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax
{
    public class MetaCompilerSyntaxLexer : Antlr4SyntaxLexer
    {
        public MetaCompilerSyntaxLexer(SourceText text, MetaCompilerParseOptions options) 
            : base(MetaCompilerLanguage.Instance, text, options)
        {
        }
        protected override InternalSyntaxToken CreateToken(GreenNode leadingTrivia, SyntaxKind kind, string text, GreenNode trailingTrivia)
        {
            return MetaCompilerLanguage.Instance.InternalSyntaxFactory.Token(leadingTrivia, kind, text, trailingTrivia);
        }
        protected override InternalSyntaxTrivia CreateTrivia(SyntaxKind kind, string text)
        {
            return MetaCompilerLanguage.Instance.InternalSyntaxFactory.Trivia(kind, text);
        }
    }
}


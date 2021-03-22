using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpInternalSyntaxFactory : InternalSyntaxFactory
    {
        public CSharpInternalSyntaxFactory(SyntaxFacts syntaxFacts) 
            : base(syntaxFacts)
        {
        }

        public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxTrivia ConflictMarker(string text)
        {
            throw new NotImplementedException();
        }

        public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
        {
            throw new NotImplementedException();
        }

        public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxTrivia DisabledText(string text)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken MissingToken(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken Token(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
        {
            throw new NotImplementedException();
        }

        public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
        {
            return new CSharpInternalSyntaxTrivia(kind, text);
        }

        private class CSharpInternalSyntaxTrivia : InternalSyntaxTrivia
        {
            public CSharpInternalSyntaxTrivia(SyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null) 
                : base(kind, text, diagnostics, annotations)
            {
            }

            public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
            {
                return this;
            }

            public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
            {
                throw new NotImplementedException();
            }
        }
    }
}

using MetaDslx.CodeAnalysis.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpSyntaxFacts : SyntaxFacts
    {
        public CSharpSyntaxFacts() : base(typeof(SyntaxKind))
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => SyntaxKind.SkippedTokensTrivia;

        public override SyntaxKind DefaultEndOfLineKind => SyntaxKind.SkippedTokensTrivia;

        public override SyntaxKind DefaultSeparatorKind => SyntaxKind.SkippedTokensTrivia;

        public override SyntaxKind DefaultIdentifierKind => SyntaxKind.SkippedTokensTrivia;

        public override SyntaxKind GetContextualKeywordKind(string text)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SyntaxKind> GetContextualKeywordKinds()
        {
            throw new NotImplementedException();
        }

        public override SyntaxKind GetFixedTokenKind(string text)
        {
            throw new NotImplementedException();
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
            throw new NotImplementedException();
        }

        public override string GetText(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsContextualKeyword(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsDocumentationCommentTrivia(SyntaxKind rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsFixedToken(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsGeneralCommentTrivia(SyntaxKind rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsIdentifier(SyntaxKind rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorContextualKeyword(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorDirective(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorKeyword(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsReservedKeyword(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsToken(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTrivia(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }
    }
}

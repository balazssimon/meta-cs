using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    public class MetaModelSyntaxFacts : SyntaxFacts
    {
        private sealed class SyntaxKindEqualityComparer : IEqualityComparer<SyntaxKind>
        {
            public bool Equals(SyntaxKind x, SyntaxKind y)
            {
                return x == y;
            }

            public int GetHashCode(SyntaxKind obj)
            {
                return (int)obj;
            }
        }

        /// <summary>
        /// A custom equality comparer for <see cref="SyntaxKind"/>
        /// </summary>
        /// <remarks>
        /// PERF: The framework specializes EqualityComparer for enums, but only if the underlying type is System.Int32
        /// Since SyntaxKind's underlying type is System.UInt16, ObjectEqualityComparer will be chosen instead.
        /// </remarks>
        public static IEqualityComparer<SyntaxKind> EqualityComparer { get; } = new SyntaxKindEqualityComparer();

        public override bool IsToken(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsFixedToken(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTrivia(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsReservedKeyword(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsContextualKeyword(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorKeyword(SyntaxKind kind)
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

        public override SyntaxKind ToLanguageSyntaxKind(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsIdentifier(SyntaxKind rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsGeneralCommentTrivia(SyntaxKind rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsDocumentationCommentTrivia(SyntaxKind rawKind)
        {
            throw new NotImplementedException();
        }

        public override string GetText(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
            throw new NotImplementedException();
        }

        public override SyntaxKind GetContextualKeywordKind(string text)
        {
            throw new NotImplementedException();
        }

        public override SyntaxKind GetFixedTokenKind(string text)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SyntaxKind> GetContextualKeywordKinds()
        {
            throw new NotImplementedException();
        }

        public override bool IsInNamespaceOrTypeContext(SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        public override bool IsStatement(SyntaxNode syntax)
        {
            throw new NotImplementedException();
        }

        public override bool IsExpression(SyntaxNode node)
        {
            throw new NotImplementedException();
        }
    }
}

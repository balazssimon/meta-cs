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

        public override bool IsName(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPredefinedType(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsType(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTypeDeclaration(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsGlobalMemberDeclaration(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsNamespaceMemberDeclaration(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsIdentifier(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsGeneralCommentTrivia(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsDocumentationCommentTrivia(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override string GetKindText(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override string GetText(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        public override int GetReservedKeywordKind(string text)
        {
            throw new NotImplementedException();
        }

        public override int GetContextualKeywordKind(string text)
        {
            throw new NotImplementedException();
        }

        public override int GetPreprocessorKeywordKind(string text)
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

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

        public bool IsToken(SyntaxKind kind)
        {
            return this.IsToken((int)kind);
        }

        public bool IsIdentifier(SyntaxKind kind)
        {
            return this.IsIdentifier((int)kind);
        }

        public override bool IsToken(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsFixedToken(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTrivia(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsReservedKeyword(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsContextualKeyword(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorKeyword(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorContextualKeyword(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPreprocessorDirective(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsName(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsPredefinedType(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsType(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTypeDeclaration(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsGlobalMemberDeclaration(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsNamespaceMemberDeclaration(int kind)
        {
            throw new NotImplementedException();
        }

        public override bool IsIdentifier(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsGeneralCommentTrivia(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsDocumentationCommentTrivia(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override bool IsTriviaWithEndOfLine(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override string GetKindText(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override string GetText(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(int rawKind)
        {
            throw new NotImplementedException();
        }

        public override int GetKeywordKind(string text)
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

        public override IEnumerable<int> GetReservedKeywordKinds()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<int> GetContextualKeywordKinds()
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public static class SyntaxFacts
    {
        public static bool HasRelatedDirectives(SyntaxNode directive)
        {
            return false;
        }

        internal static bool IsDocumentationCommentTrivia(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        internal static bool IsAnyToken(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }

        internal static string GetText(SyntaxKind kind)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public abstract class SyntaxFacts
    {
        internal abstract string GetKindText(int rawKind);
        internal abstract bool IsDocumentationCommentTrivia(int rawKind);
        internal abstract bool IsTriviaWithEndOfLine(int rawKind);
        internal abstract string GetText(int rawKind);
        internal abstract object GetValue(int rawKind);
    }
}

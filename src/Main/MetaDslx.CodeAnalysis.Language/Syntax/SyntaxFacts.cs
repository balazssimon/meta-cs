using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public abstract class SyntaxFacts
    {
        // Maximum size of tokens/trivia that we cache and use in quick scanner.
        // From what I see in our own codebase, tokens longer then 40-50 chars are 
        // not very common. 
        // So it seems reasonable to limit the sizes to some round number like 42.
        public virtual int MaxCachedTokenSize => 42;

        public abstract bool IsAnyToken(int rawKind);
        public abstract bool IsIdentifier(int rawKind);
        public abstract bool IsDocumentationCommentTrivia(int rawKind);
        public abstract bool IsTriviaWithEndOfLine(int rawKind);
        public abstract string GetKindText(int rawKind);
        public abstract string GetText(int rawKind);
        public abstract object GetValue(int rawKind);
    }
}

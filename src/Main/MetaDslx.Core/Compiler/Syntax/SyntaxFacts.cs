using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxFacts
    {

        internal int DefaultWhitespaceSyntaxKind
        {
            get { return this.DefaultEndOfLineSyntaxKindCore; }
        }

        protected abstract int DefaultWhitespaceSyntaxKindCore
        {
            get;
        }

        internal int DefaultEndOfLineSyntaxKind
        {
            get { return this.DefaultEndOfLineSyntaxKindCore; }
        }

        protected abstract int DefaultEndOfLineSyntaxKindCore
        {
            get;
        }

        public abstract string GetKindText(int rawKind);
        public abstract string GetText(int rawKind);
        public abstract bool IsToken(int rawKind);
        public abstract bool IsFixedToken(int rawKind);
        public abstract bool EndsWithLineBreak(int rawKind);
        public abstract bool IsComment(int rawKind);
        public abstract bool IsDocumentationComment(int rawKind);
        public abstract bool IsLineBreak(int rawKind);
        public abstract bool IsWhiteSpace(int rawKind);
        public abstract bool IsStructuredToken(int rawKind);
        public abstract bool IsStructuredTrivia(int rawKind);
        public virtual bool IsStructuredTokenOrTrivia(int rawKind)
        {
            return IsStructuredToken(rawKind) || IsStructuredTrivia(rawKind);
        }

        public abstract bool IsPreprocessorDirective(int rawKind);
    }
}

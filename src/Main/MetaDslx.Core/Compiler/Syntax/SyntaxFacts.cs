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
        public abstract bool IsTriviaWithEndOfLine(int rawKind);
        internal abstract bool IsWhiteSpaceTrivia(int rawKind);
    }
}

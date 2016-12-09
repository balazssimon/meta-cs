using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Core.Diagnostics;
using MetaDslx.Compiler.Core.Utilities;
using System.Diagnostics;

namespace MetaDslx.Compiler.Core.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxTrivia : GreenNode
    {
        private string text;

        protected InternalSyntaxTrivia(int kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations) 
            : base(kind, text.Length, diagnostics, annotations)
        {
            this.text = text;
        }

        public override bool IsTrivia
        {
            get { return true; }
        }

        public virtual string Text
        {
            get { return this.text; }
        }

        public override string ToFullString()
        {
            return this.Text;
        }

        public override string ToString()
        {
            return this.Text;
        }

        public override GreenNode GetSlot(int index)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override int Width
        {
            get
            {
                Debug.Assert(this.FullWidth == this.text.Length);
                return this.FullWidth;
            }
        }

        public override int GetLeadingTriviaWidth()
        {
            return 0;
        }

        public override int GetTrailingTriviaWidth()
        {
            return 0;
        }

        public override bool IsEquivalentTo(GreenNode other)
        {
            if (!base.IsEquivalentTo(other))
            {
                return false;
            }

            if (this.Text != ((InternalSyntaxTrivia)other).Text)
            {
                return false;
            }

            return true;
        }

        public override RedNode CreateRed(SyntaxNode parent, int position)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}

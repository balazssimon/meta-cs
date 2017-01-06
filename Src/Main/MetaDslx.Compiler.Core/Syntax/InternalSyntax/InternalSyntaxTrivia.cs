using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using System.Diagnostics;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
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

        public override int SlotCount
        {
            get { return 0; }
        }

        public override GreenNode GetSlot(int index)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            Debug.Assert(parent is SyntaxToken, "parent must be a SyntaxToken");
            return this.CreateRed(parent as SyntaxToken, position, index);
        }

        public abstract SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index);

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
    }
}

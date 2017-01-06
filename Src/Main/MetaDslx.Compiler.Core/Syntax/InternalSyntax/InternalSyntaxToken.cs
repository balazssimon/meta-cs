using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using System.Diagnostics;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxToken : GreenNode
    {
        protected InternalSyntaxToken(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, 0, diagnostics, annotations)
        {
            FullWidth = this.Text.Length;
        }

        protected InternalSyntaxToken(int kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations) 
            : base(kind, fullWidth, diagnostics, annotations)
        {
        }

        public override bool IsToken
        {
            get { return true; }
        }

        public virtual string Text
        {
            get { return this.Language.SyntaxFacts.GetText(this.RawKind); }
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
            Debug.Assert(parent is SyntaxNode, "parent must be a SyntaxNode");
            return this.CreateRed(parent as SyntaxNode, position, index);
        }

        public abstract SyntaxToken CreateRed(SyntaxNode parent, int position, int index);

        /// <summary>
        /// Returns the string representation of this token, not including its leading and trailing trivia.
        /// </summary>
        /// <returns>The string representation of this token, not including its leading and trailing trivia.</returns>
        /// <remarks>The length of the returned string is always the same as Span.Length</remarks>
        public override string ToString()
        {
            return this.Text;
        }

        public virtual object Value
        {
            get { return this.Text; }
        }

        public virtual string ValueText
        {
            get { return this.Text; }
        }

        public override int Width
        {
            get { return this.Text.Length; }
        }

        public override int GetLeadingTriviaWidth()
        {
            var leading = this.GetLeadingTrivia();
            return leading != null ? leading.FullWidth : 0;
        }

        public override int GetTrailingTriviaWidth()
        {
            var trailing = this.GetTrailingTrivia();
            return trailing != null ? trailing.FullWidth : 0;
        }

        protected internal override void WriteTo(System.IO.TextWriter writer, bool leading, bool trailing)
        {
            if (leading)
            {
                var trivia = this.GetLeadingTrivia();
                if (trivia != null)
                {
                    trivia.WriteTo(writer, true, true);
                }
            }

            writer.Write(this.Text);

            if (trailing)
            {
                var trivia = this.GetTrailingTrivia();
                if (trivia != null)
                {
                    trivia.WriteTo(writer, true, true);
                }
            }
        }

        public override bool IsEquivalentTo(GreenNode other)
        {
            if (!base.IsEquivalentTo(other))
            {
                return false;
            }

            var otherToken = (InternalSyntaxToken)other;

            if (this.Text != otherToken.Text)
            {
                return false;
            }

            var thisLeading = this.GetLeadingTrivia();
            var otherLeading = otherToken.GetLeadingTrivia();
            if (thisLeading != otherLeading)
            {
                if (thisLeading == null || otherLeading == null)
                {
                    return false;
                }

                if (!thisLeading.IsEquivalentTo(otherLeading))
                {
                    return false;
                }
            }

            var thisTrailing = this.GetTrailingTrivia();
            var otherTrailing = otherToken.GetTrailingTrivia();
            if (thisTrailing != otherTrailing)
            {
                if (thisTrailing == null || otherTrailing == null)
                {
                    return false;
                }

                if (!thisTrailing.IsEquivalentTo(otherTrailing))
                {
                    return false;
                }
            }

            return true;
        }

        public virtual GreenNode GetLeadingTrivia() { return null; }
        public virtual GreenNode GetTrailingTrivia() { return null; }

        public virtual InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
        {
            return this;
        }

        public virtual InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
        {
            return this;
        }
    }

}

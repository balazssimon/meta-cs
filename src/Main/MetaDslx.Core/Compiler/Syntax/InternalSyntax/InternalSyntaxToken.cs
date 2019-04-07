// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxToken : InternalSyntaxNode
    {
        protected InternalSyntaxToken(int kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations, fullWidth)
        {
            this.flags |= NodeFlags.IsNotMissing; //note: cleared by subclasses representing missing tokens
        }

        internal InternalSyntaxToken(ObjectReader reader)
            : base(reader)
        {
            var text = this.Text;
            if (text != null)
            {
                FullWidth = text.Length;
            }

            this.flags |= NodeFlags.IsNotMissing;  //note: cleared by subclasses representing missing tokens
        }

        internal override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
                                                             FullWidth < GreenNode.MaxCachedTokenSize;

        //====================

        public override bool IsToken => true;

        public virtual string Text
        {
            get { return this.Language.SyntaxFacts.GetText(this.RawKind); }
        }

        internal override GreenNode GetSlot(int index)
        {
            throw ExceptionUtilities.Unreachable;
        }

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

        public override object GetValue()
        {
            return this.Value;
        }

        public virtual string ValueText
        {
            get { return this.Text; }
        }

        public override string GetValueText()
        {
            return this.ValueText;
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

        public SyntaxList<InternalSyntaxNode> LeadingTrivia
        {
            get { return new SyntaxList<InternalSyntaxNode>(this.GetLeadingTrivia()); }
        }

        public SyntaxList<InternalSyntaxNode> TrailingTrivia
        {
            get { return new SyntaxList<InternalSyntaxNode>(this.GetTrailingTrivia()); }
        }

        public sealed override GreenNode WithLeadingTrivia(GreenNode trivia)
        {
            return TokenWithLeadingTrivia(trivia);
        }

        public abstract InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia);

        public sealed override GreenNode WithTrailingTrivia(GreenNode trivia)
        {
            return TokenWithTrailingTrivia(trivia);
        }

        public abstract InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia);

        public override DirectiveStack ApplyDirectives(DirectiveStack stack)
        {
            if (this.ContainsDirectives)
            {
                stack = ApplyDirectivesToTrivia(this.GetLeadingTrivia(), stack);
                stack = ApplyDirectivesToTrivia(this.GetTrailingTrivia(), stack);
            }

            return stack;
        }

        private static DirectiveStack ApplyDirectivesToTrivia(GreenNode triviaList, DirectiveStack stack)
        {
            if (triviaList != null && triviaList.ContainsDirectives)
            {
                return ApplyDirectivesToListOrNode(triviaList, stack);
            }

            return stack;
        }

        public override TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitToken(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor)
        {
            visitor.VisitToken(this);
        }

        protected override void WriteTokenTo(System.IO.TextWriter writer, bool leading, bool trailing)
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

        internal override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}

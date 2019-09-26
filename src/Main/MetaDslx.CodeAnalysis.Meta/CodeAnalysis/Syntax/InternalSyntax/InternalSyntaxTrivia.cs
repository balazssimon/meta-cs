// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxTrivia : InternalSyntaxNode
    {
        public readonly string Text;

        protected InternalSyntaxTrivia(SyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, diagnostics, annotations, text.Length)
        {
            this.Text = text;
        }

        protected InternalSyntaxTrivia(ObjectReader reader)
            : base(reader)
        {
            this.Text = reader.ReadString();
            this.FullWidth = this.Text.Length;
        }

        protected override Language LanguageCore => throw ExceptionUtilities.Unreachable;

        public override bool IsTrivia => true;

        public override string ToFullString()
        {
            return this.Text;
        }

        public override string ToString()
        {
            return this.Text;
        }

        protected override GreenNode GetSlot(int index)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override int Width
        {
            get
            {
                Debug.Assert(this.FullWidth == this.Text.Length);
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

        public override TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitTrivia(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor)
        {
            visitor.VisitTrivia(this);
        }

        protected override void WriteTriviaTo(System.IO.TextWriter writer)
        {
            writer.Write(Text);
        }

        public static implicit operator SyntaxTrivia(InternalSyntaxTrivia trivia)
        {
            return new SyntaxTrivia(default(SyntaxToken), trivia, position: 0, index: 0);
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

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}

// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    internal partial class SyntaxToken
    {
        internal class SyntaxIdentifier : SyntaxToken
        {
            static SyntaxIdentifier()
            {
                ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifier), r => new SyntaxIdentifier(r));
            }

            protected readonly string TextField;

            internal SyntaxIdentifier(SyntaxKind kind, string text)
                : base(kind, text.Length)
            {
                this.TextField = text;
            }

            internal SyntaxIdentifier(SyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
                : base(kind, text.Length, diagnostics, annotations)
            {
                this.TextField = text;
            }

            internal SyntaxIdentifier(ObjectReader reader)
                : base(reader)
            {
                this.TextField = reader.ReadString();
                this.FullWidth = this.TextField.Length;
            }

            protected override void WriteTo(ObjectWriter writer)
            {
                base.WriteTo(writer);
                writer.WriteString(this.TextField);
            }

            public override string Text
            {
                get { return this.TextField; }
            }

            public override object Value
            {
                get { return this.TextField; }
            }

            public override string ValueText
            {
                get { return this.TextField; }
            }

            public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
            {
                return new SyntaxIdentifierWithTrivia(this.Kind, this.ContextualKind, this.TextField, this.TextField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
            {
                return new SyntaxIdentifierWithTrivia(this.Kind, this.ContextualKind, this.TextField, this.TextField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override CSharpSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
            {
                return new SyntaxIdentifier(this.Kind, this.Text, diagnostics, this.GetAnnotations());
            }

            public override CSharpSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
            {
                return new SyntaxIdentifier(this.Kind, this.Text, this.GetDiagnostics(), annotations);
            }
        }
    }
}

﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    internal partial class SyntaxToken
    {
        internal class SyntaxIdentifierExtended : SyntaxIdentifier
        {
            protected readonly SyntaxKind contextualKind;
            protected readonly string valueText;

            internal SyntaxIdentifierExtended(SyntaxKind kind, SyntaxKind contextualKind, string text, string valueText)
                : base(kind, text)
            {
                this.contextualKind = contextualKind;
                this.valueText = valueText;
            }

            internal SyntaxIdentifierExtended(SyntaxKind kind, SyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
                : base(kind, text, diagnostics, annotations)
            {
                this.contextualKind = contextualKind;
                this.valueText = valueText;
            }

            internal SyntaxIdentifierExtended(ObjectReader reader)
                : base(reader)
            {
                this.contextualKind = (SyntaxKind)reader.ReadInt16();
                this.valueText = reader.ReadString();
            }

            static SyntaxIdentifierExtended()
            {
                ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifierExtended), r => new SyntaxIdentifierExtended(r));
            }

            protected override void WriteTo(ObjectWriter writer)
            {
                base.WriteTo(writer);
                writer.WriteInt16((short)this.contextualKind);
                writer.WriteString(this.valueText);
            }

            public override SyntaxKind ContextualKind
            {
                get { return this.contextualKind; }
            }

            public override string ValueText
            {
                get { return this.valueText; }
            }

            public override object Value
            {
                get { return this.valueText; }
            }

            public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
            {
                return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
            {
                return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override CSharpSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
            {
                return new SyntaxIdentifierExtended(this.Kind, this.contextualKind, this.TextField, this.valueText, diagnostics, this.GetAnnotations());
            }

            public override CSharpSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
            {
                return new SyntaxIdentifierExtended(this.Kind, this.contextualKind, this.TextField, this.valueText, this.GetDiagnostics(), annotations);
            }
        }
    }
}

﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Syntax;

namespace MetaDslx.Languages.MetaModel.Syntax.InternalSyntax
{
    internal partial class GreenSyntaxToken
    {
        internal class SyntaxIdentifierWithTrailingTrivia : SyntaxIdentifier
        {
            private readonly GreenNode _trailing;

            internal SyntaxIdentifierWithTrailingTrivia(SyntaxKind kind, string text, GreenNode trailing)
                : base(kind, text)
            {
                if (trailing != null)
                {
                    this.AdjustFlagsAndWidth(trailing);
                    _trailing = trailing;
                }
            }

            internal SyntaxIdentifierWithTrailingTrivia(SyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
                : base(kind, text, diagnostics, annotations)
            {
                if (trailing != null)
                {
                    this.AdjustFlagsAndWidth(trailing);
                    _trailing = trailing;
                }
            }

            internal SyntaxIdentifierWithTrailingTrivia(ObjectReader reader)
                : base(reader)
            {
                var trailing = (GreenNode)reader.ReadValue();
                if (trailing != null)
                {
                    this.AdjustFlagsAndWidth(trailing);
                    _trailing = trailing;
                }
            }

            static SyntaxIdentifierWithTrailingTrivia()
            {
                ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifierWithTrailingTrivia), r => new SyntaxIdentifierWithTrailingTrivia(r));
            }

            protected override void WriteTo(ObjectWriter writer)
            {
                base.WriteTo(writer);
                writer.WriteValue(_trailing);
            }

            public override GreenNode GetTrailingTrivia()
            {
                return _trailing;
            }

            public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
            {
                return new SyntaxIdentifierWithTrivia(this.Kind, this.ContextualKind, this.TextField, this.TextField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
            {
                return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, trivia, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
            {
                return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, _trailing, diagnostics, this.GetAnnotations());
            }

            public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
            {
                return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, _trailing, this.GetDiagnostics(), annotations);
            }
        }
    }
}

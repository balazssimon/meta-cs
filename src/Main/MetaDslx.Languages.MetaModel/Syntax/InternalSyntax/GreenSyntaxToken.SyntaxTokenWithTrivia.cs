// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Syntax;

namespace MetaDslx.Languages.MetaModel.Syntax.InternalSyntax
{
    internal partial class GreenSyntaxToken
    {
        internal class SyntaxTokenWithTrivia : GreenSyntaxToken
        {
            static SyntaxTokenWithTrivia()
            {
                ObjectBinder.RegisterTypeReader(typeof(SyntaxTokenWithTrivia), r => new SyntaxTokenWithTrivia(r));
            }

            protected readonly GreenNode LeadingField;
            protected readonly GreenNode TrailingField;

            internal SyntaxTokenWithTrivia(SyntaxKind kind, GreenNode leading, GreenNode trailing)
                : base(kind)
            {
                if (leading != null)
                {
                    this.AdjustFlagsAndWidth(leading);
                    this.LeadingField = leading;
                }
                if (trailing != null)
                {
                    this.AdjustFlagsAndWidth(trailing);
                    this.TrailingField = trailing;
                }
            }

            internal SyntaxTokenWithTrivia(SyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
                : base(kind, diagnostics, annotations)
            {
                if (leading != null)
                {
                    this.AdjustFlagsAndWidth(leading);
                    this.LeadingField = leading;
                }
                if (trailing != null)
                {
                    this.AdjustFlagsAndWidth(trailing);
                    this.TrailingField = trailing;
                }
            }

            internal SyntaxTokenWithTrivia(ObjectReader reader)
                : base(reader)
            {
                var leading = (GreenNode)reader.ReadValue();
                if (leading != null)
                {
                    this.AdjustFlagsAndWidth(leading);
                    this.LeadingField = leading;
                }
                var trailing = (GreenNode)reader.ReadValue();
                if (trailing != null)
                {
                    this.AdjustFlagsAndWidth(trailing);
                    this.TrailingField = trailing;
                }
            }

            protected override void WriteTo(ObjectWriter writer)
            {
                base.WriteTo(writer);
                writer.WriteValue(this.LeadingField);
                writer.WriteValue(this.TrailingField);
            }

            public override GreenNode GetLeadingTrivia()
            {
                return this.LeadingField;
            }

            public override GreenNode GetTrailingTrivia()
            {
                return this.TrailingField;
            }

            public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
            {
                return new SyntaxTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
            {
                return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
            }

            public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
            {
                return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
            }

            public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
            {
                return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
            }
        }
    }
}

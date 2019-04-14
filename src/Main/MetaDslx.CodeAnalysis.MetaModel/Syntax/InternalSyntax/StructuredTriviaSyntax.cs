using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    internal class StructuredTriviaSyntax : SyntaxNode
    {
        protected StructuredTriviaSyntax(int kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, diagnostics, annotations)
        {
            this.Initialize();
        }

        protected StructuredTriviaSyntax(ObjectReader reader)
            : base(reader)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.flags |= NodeFlags.ContainsStructuredTrivia;

            if (this.Kind == SyntaxKind.SkippedTokensTrivia)
            {
                this.flags |= NodeFlags.ContainsSkippedText;
            }
        }

        public override bool IsStructuredTrivia
        {
            get
            {
                return true;
            }
        }
    }
}

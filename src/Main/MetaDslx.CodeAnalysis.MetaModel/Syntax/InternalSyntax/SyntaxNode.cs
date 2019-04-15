using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;

    internal abstract class SyntaxNode : CSharpSyntaxNode
    {
        protected SyntaxNode(int kind)
            : base(kind)
        {
        }

        protected SyntaxNode(int kind, int fullWidth)
            : base(kind, fullWidth)
        {
        }

        protected SyntaxNode(int kind, DiagnosticInfo[] diagnostics)
            : base(kind, diagnostics)
        {
        }

        protected SyntaxNode(int kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base(kind, diagnostics, fullWidth)
        {
        }

        protected SyntaxNode(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations)
        {
        }

        protected SyntaxNode(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind, diagnostics, annotations, fullWidth)
        {
        }

        protected SyntaxNode(ObjectReader reader)
            : base(reader)
        {
        }

        public new MetaModelLanguage Language => MetaModelLanguage.Instance;
        protected override Language LanguageCore => MetaModelLanguage.Instance;

        public SyntaxKind Kind => (SyntaxKind)this.RawKind;
    }
}

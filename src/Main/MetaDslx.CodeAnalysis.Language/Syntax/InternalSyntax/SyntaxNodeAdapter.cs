using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax
{
    public abstract class SyntaxNodeAdapter : GreenNode
    {
        internal SyntaxNodeAdapter(int kind)
            : base(kind)
        {
            GreenStats.NoteGreen(this);
        }

        internal SyntaxNodeAdapter(int kind, int fullWidth)
            : base(kind, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal SyntaxNodeAdapter(int kind, DiagnosticInfo[] diagnostics)
            : base(kind, diagnostics)
        {
            GreenStats.NoteGreen(this);
        }

        internal SyntaxNodeAdapter(int kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base(kind, diagnostics, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal SyntaxNodeAdapter(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations)
        {
            GreenStats.NoteGreen(this);
        }

        internal SyntaxNodeAdapter(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind, diagnostics, annotations, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal SyntaxNodeAdapter(ObjectReader reader)
            : base(reader)
        {
        }

        public sealed override string Language
        {
            get { return this.LanguageCore.Name; }
        }

        protected abstract Language LanguageCore { get; }

        internal protected new virtual void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
        }
    }
}

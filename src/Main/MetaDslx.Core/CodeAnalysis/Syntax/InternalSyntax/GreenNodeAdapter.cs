using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class GreenNodeAdapter : GreenNode
    {
        internal GreenNodeAdapter(int kind)
            : base(kind)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(int kind, int fullWidth)
            : base(kind, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(int kind, DiagnosticInfo[] diagnostics)
            : base(kind, diagnostics)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(int kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base(kind, diagnostics, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind, diagnostics, annotations, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(ObjectReader reader)
            : base(reader)
        {
        }

        public sealed override string Language
        {
            get { return this.LanguageCore.Name; }
        }

        protected abstract Language LanguageCore { get; }

        public SyntaxKind Kind => EnumObject.FromIntUnsafe<SyntaxKind>(this.RawKind);

        public override string KindText => Kind.GetName();

        internal protected new virtual void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
        }
    }
}

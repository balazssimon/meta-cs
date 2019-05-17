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
        internal GreenNodeAdapter(SyntaxKind kind)
            : base(kind.GetValue())
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, int fullWidth)
            : base(kind.GetValue(), fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics)
            : base(kind.GetValue(), diagnostics)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base(kind.GetValue(), diagnostics, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind.GetValue(), diagnostics, annotations)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind.GetValue(), diagnostics, annotations, fullWidth)
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

        public virtual SyntaxKind Kind => EnumObject.FromIntUnsafe<SyntaxKind>(this.RawKind);

        public override string KindText => Kind.GetName();

        internal protected new virtual void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
        }
    }
}

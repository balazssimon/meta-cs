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
            : base((ushort)kind.GetValue())
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, int fullWidth)
            : base((ushort)kind.GetValue(), fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics)
            : base((ushort)kind.GetValue(), diagnostics)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base((ushort)kind.GetValue(), diagnostics, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((ushort)kind.GetValue(), diagnostics, annotations)
        {
            GreenStats.NoteGreen(this);
        }

        internal GreenNodeAdapter(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base((ushort)kind.GetValue(), diagnostics, annotations, fullWidth)
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

        public SyntaxKind Kind => this.KindCore;

        protected virtual SyntaxKind KindCore => (SyntaxKind)EnumObject.FromIntUnsafe(LanguageCore.SyntaxFacts.SyntaxKindType, this.RawKind);

        protected virtual new bool ShouldReuseInSerialization => base.ShouldReuseInSerialization;

        public SyntaxKind ContextualKind => this.ContextualKindCore;

        protected virtual SyntaxKind ContextualKindCore => (SyntaxKind)EnumObject.FromIntUnsafe(LanguageCore.SyntaxFacts.SyntaxKindType, this.RawContextualKind);

        public override string KindText => Kind.GetName();

        internal override GreenNode GetSlot(int index)
        {
            return this.GetSlotCore(index);
        }

        protected abstract GreenNode GetSlotCore(int index);

        internal override SyntaxNode CreateRed(SyntaxNode parent, int position)
        {
            return this.CreateRedCore(parent, position);
        }

        protected abstract SyntaxNode CreateRedCore(SyntaxNode parent, int position);

        public virtual GreenNode Clone() => throw new NotImplementedException("TODO: make it abstract");

        protected new DiagnosticInfo[] GetDiagnostics()
        {
            return base.GetDiagnostics();
        }

        internal protected new virtual void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
        }
    }
}

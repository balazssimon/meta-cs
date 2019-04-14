using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    internal class SyntaxTrivia : Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax.SyntaxTrivia
    {
        internal SyntaxTrivia(SyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        internal SyntaxTrivia(ObjectReader reader)
            : base(reader)
        {
        }

        static SyntaxTrivia()
        {
            ObjectBinder.RegisterTypeReader(typeof(SyntaxTrivia), r => new SyntaxTrivia(r));
        }

        protected override Language LanguageCore => MetaModelLanguage.Instance;

        public SyntaxKind Kind => (SyntaxKind)this.RawKind;

        public override bool IsTrivia => true;

        internal override bool ShouldReuseInSerialization => this.Kind == SyntaxKind.WhitespaceTrivia &&
                                                             FullWidth < Lexer.MaxCachedTokenSize;

        internal protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static SyntaxTrivia Create(SyntaxKind kind, string text)
        {
            return new SyntaxTrivia(kind, text);
        }

        public override GreenNode SetDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new SyntaxTrivia(this.Kind, this.Text, diagnostics, GetAnnotations());
        }

        public override GreenNode SetAnnotations(SyntaxAnnotation[] annotations)
        {
            return new SyntaxTrivia(this.Kind, this.Text, GetDiagnostics(), annotations);
        }

        public static implicit operator Microsoft.CodeAnalysis.SyntaxTrivia(SyntaxTrivia trivia)
        {
            return new Microsoft.CodeAnalysis.SyntaxTrivia(default(Microsoft.CodeAnalysis.SyntaxToken), trivia, position: 0, index: 0);
        }
    }
}

using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;

    internal partial class SyntaxToken : InternalSyntaxToken
    {
        //====================
        // Optimization: Normally, we wouldn't accept this much duplicate code, but these constructors
        // are called A LOT and we want to keep them as short and simple as possible and increase the
        // likelihood that they will be inlined.

        internal SyntaxToken(SyntaxKind kind)
            : base((int)kind)
        {
        }

        internal SyntaxToken(SyntaxKind kind, DiagnosticInfo[] diagnostics)
            : base((int)kind, diagnostics)
        {
        }

        internal SyntaxToken(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, diagnostics, annotations)
        {
        }

        internal SyntaxToken(SyntaxKind kind, int fullWidth)
            : base((int)kind, fullWidth)
        {
        }

        internal SyntaxToken(SyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
            : base((int)kind, fullWidth, diagnostics)
        {
        }

        internal SyntaxToken(SyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, fullWidth, diagnostics, annotations)
        {
        }

        internal SyntaxToken(ObjectReader reader)
            : base(reader)
        {
            var text = this.Text;
            if (text != null)
            {
                FullWidth = text.Length;
            }

            this.flags |= NodeFlags.IsNotMissing;  //note: cleared by subclasses representing missing tokens
        }

        public new MetaModelLanguage Language => MetaModelLanguage.Instance;
        protected override Language LanguageCore => MetaModelLanguage.Instance;

        protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        //====================

        internal static SyntaxToken Create(SyntaxKind kind)
        {
            if (kind > LastTokenWithWellKnownText)
            {
                if (!MetaModelLanguage.Instance.SyntaxFacts.IsToken(kind))
                {
                    throw new ArgumentException(string.Format("Invalid SyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
                }

                return CreateMissing(kind, null, null);
            }

            return s_tokensWithNoTrivia[(int)kind].Value;
        }

        internal static SyntaxToken Create(SyntaxKind kind, GreenNode leading, GreenNode trailing)
        {
            if (kind > LastTokenWithWellKnownText)
            {
                if (!MetaModelLanguage.Instance.SyntaxFacts.IsToken(kind))
                {
                    throw new ArgumentException(string.Format("Invalid SyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
                }

                return CreateMissing(kind, leading, trailing);
            }

            if (leading == null)
            {
                if (trailing == null)
                {
                    return s_tokensWithNoTrivia[(int)kind].Value;
                }
                else if (trailing == MetaModelLanguage.Instance.InternalSyntaxFactory.Space)
                {
                    return s_tokensWithSingleTrailingSpace[(int)kind].Value;
                }
                else if (trailing == MetaModelLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
                {
                    return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
                }
            }

            if (leading == MetaModelLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == MetaModelLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
            {
                return s_tokensWithElasticTrivia[(int)kind].Value;
            }

            return new SyntaxTokenWithTrivia(kind, leading, trailing);
        }

        internal static SyntaxToken CreateMissing(SyntaxKind kind, GreenNode leading, GreenNode trailing)
        {
            return new MissingTokenWithTrivia(kind, leading, trailing);
        }

        internal const SyntaxKind FirstTokenWithWellKnownText = SyntaxKind.FirstTokenWithWellKnownText;
        internal const SyntaxKind LastTokenWithWellKnownText = SyntaxKind.LastTokenWithWellKnownText;

        // TODO: eliminate the blank space before the first interesting element?
        private static readonly ArrayElement<SyntaxToken>[] s_tokensWithNoTrivia = new ArrayElement<SyntaxToken>[(int)LastTokenWithWellKnownText + 1];
        private static readonly ArrayElement<SyntaxToken>[] s_tokensWithElasticTrivia = new ArrayElement<SyntaxToken>[(int)LastTokenWithWellKnownText + 1];
        private static readonly ArrayElement<SyntaxToken>[] s_tokensWithSingleTrailingSpace = new ArrayElement<SyntaxToken>[(int)LastTokenWithWellKnownText + 1];
        private static readonly ArrayElement<SyntaxToken>[] s_tokensWithSingleTrailingCRLF = new ArrayElement<SyntaxToken>[(int)LastTokenWithWellKnownText + 1];

        static SyntaxToken()
        {
            ObjectBinder.RegisterTypeReader(typeof(SyntaxToken), r => new SyntaxToken(r));

            for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
            {
                s_tokensWithNoTrivia[(int)kind].Value = new SyntaxToken(kind);
                s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia(kind, MetaModelLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, MetaModelLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace);
                s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia(kind, null, MetaModelLanguage.Instance.InternalSyntaxFactory.Space);
                s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia(kind, null, MetaModelLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed);
            }
        }

        internal static IEnumerable<SyntaxToken> GetWellKnownTokens()
        {
            foreach (var element in s_tokensWithNoTrivia)
            {
                if (element.Value != null)
                {
                    yield return element.Value;
                }
            }

            foreach (var element in s_tokensWithElasticTrivia)
            {
                if (element.Value != null)
                {
                    yield return element.Value;
                }
            }

            foreach (var element in s_tokensWithSingleTrailingSpace)
            {
                if (element.Value != null)
                {
                    yield return element.Value;
                }
            }

            foreach (var element in s_tokensWithSingleTrailingCRLF)
            {
                if (element.Value != null)
                {
                    yield return element.Value;
                }
            }
        }

        internal static SyntaxToken Identifier(SyntaxKind kind, string text)
        {
            return new SyntaxIdentifier(kind, text);
        }

        internal static SyntaxToken Identifier(SyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
        {
            if (leading == null)
            {
                if (trailing == null)
                {
                    return Identifier(kind, text);
                }
                else
                {
                    return new SyntaxIdentifierWithTrailingTrivia(kind, text, trailing);
                }
            }

            return new SyntaxIdentifierWithTrivia(kind, kind, text, text, leading, trailing);
        }

        internal static SyntaxToken Identifier(SyntaxKind kind, SyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
        {
            if (contextualKind == kind && valueText == text)
            {
                return Identifier(kind, leading, text, trailing);
            }

            return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
        }

        internal static SyntaxToken WithValue<T>(SyntaxKind kind, string text, T value)
        {
            return new SyntaxTokenWithValue<T>(kind, text, value);
        }

        internal static SyntaxToken WithValue<T>(SyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
        {
            return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
        }

        public SyntaxKind Kind => (SyntaxKind)this.RawKind;

        public virtual SyntaxKind ContextualKind
        {
            get
            {
                return this.Kind;
            }
        }

        public override int RawContextualKind
        {
            get
            {
                return (int)this.ContextualKind;
            }
        }

        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
        {
            return new SyntaxTokenWithTrivia(this.Kind, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
        }

        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
        {
            return new SyntaxTokenWithTrivia(this.Kind, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
        }

        public override CSharpSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            System.Diagnostics.Debug.Assert(this.GetType() == typeof(SyntaxToken));
            return new SyntaxToken(this.Kind, this.FullWidth, diagnostics, this.GetAnnotations());
        }

        public override CSharpSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            System.Diagnostics.Debug.Assert(this.GetType() == typeof(SyntaxToken));
            return new SyntaxToken(this.Kind, this.FullWidth, this.GetDiagnostics(), annotations);
        }

        public override TResult Accept<TResult>(CSharpSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitToken(this);
        }

        public override void Accept(CSharpSyntaxVisitor visitor)
        {
            visitor.VisitToken(this);
        }

        protected override void WriteTokenTo(System.IO.TextWriter writer, bool leading, bool trailing)
        {
            if (leading)
            {
                var trivia = this.GetLeadingTrivia();
                if (trivia != null)
                {
                    trivia.WriteTo(writer);
                }
            }

            writer.Write(this.Text);

            if (trailing)
            {
                var trivia = this.GetTrailingTrivia();
                if (trivia != null)
                {
                    trivia.WriteTo(writer);
                }
            }
        }
    }
}

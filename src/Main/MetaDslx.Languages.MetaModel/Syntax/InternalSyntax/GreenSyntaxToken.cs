using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaModel.Syntax.InternalSyntax
{
    using MetaDslx.CodeAnalysis.Syntax;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using Microsoft.CodeAnalysis;

    internal partial class GreenSyntaxToken : InternalSyntaxToken
    {
        //====================
        // Optimization: Normally, we wouldn't accept this much duplicate code, but these constructors
        // are called A LOT and we want to keep them as short and simple as possible and increase the
        // likelihood that they will be inlined.

        internal GreenSyntaxToken(SyntaxKind kind)
            : base(kind)
        {
        }

        internal GreenSyntaxToken(SyntaxKind kind, DiagnosticInfo[] diagnostics)
            : base(kind, diagnostics)
        {
        }

        internal GreenSyntaxToken(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations)
        {
        }

        internal GreenSyntaxToken(SyntaxKind kind, int fullWidth)
            : base(kind, fullWidth)
        {
        }

        internal GreenSyntaxToken(SyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
            : base(kind, fullWidth, diagnostics)
        {
        }

        internal GreenSyntaxToken(SyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, fullWidth, diagnostics, annotations)
        {
        }

        internal GreenSyntaxToken(ObjectReader reader)
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

        internal static GreenSyntaxToken Create(SyntaxKind kind)
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

        internal static GreenSyntaxToken Create(SyntaxKind kind, GreenNode leading, GreenNode trailing)
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

        internal static GreenSyntaxToken CreateMissing(SyntaxKind kind, GreenNode leading, GreenNode trailing)
        {
            return new MissingTokenWithTrivia(kind, leading, trailing);
        }

        internal static readonly MetaModelSyntaxKind FirstTokenWithWellKnownText;
        internal static readonly MetaModelSyntaxKind LastTokenWithWellKnownText;

        // TODO: eliminate the blank space before the first interesting element?
        private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
        private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
        private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
        private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;

        static GreenSyntaxToken()
        {
            ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));

            FirstTokenWithWellKnownText = MetaModelSyntaxKind.FirstTokenWithWellKnownText;
            LastTokenWithWellKnownText = MetaModelSyntaxKind.LastTokenWithWellKnownText;

            s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
            s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
            s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
            s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
            for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
            {
                s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((MetaModelSyntaxKind)kind);
                s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((MetaModelSyntaxKind)kind, MetaModelLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, MetaModelLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace);
                s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((MetaModelSyntaxKind)kind, null, MetaModelLanguage.Instance.InternalSyntaxFactory.Space);
                s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((MetaModelSyntaxKind)kind, null, MetaModelLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed);
            }
        }

        internal static IEnumerable<GreenSyntaxToken> GetWellKnownTokens()
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

        internal static GreenSyntaxToken Identifier(SyntaxKind kind, string text)
        {
            return new SyntaxIdentifier(kind, text);
        }

        internal static GreenSyntaxToken Identifier(SyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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

        internal static GreenSyntaxToken Identifier(SyntaxKind kind, SyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
        {
            if (contextualKind == kind && valueText == text)
            {
                return Identifier(kind, leading, text, trailing);
            }

            return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
        }

        internal static GreenSyntaxToken WithValue<T>(SyntaxKind kind, string text, T value)
        {
            return new SyntaxTokenWithValue<T>(kind, text, value);
        }

        internal static GreenSyntaxToken WithValue<T>(SyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
        {
            return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
        }

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

        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            System.Diagnostics.Debug.Assert(this.GetType() == typeof(GreenSyntaxToken));
            return new GreenSyntaxToken(this.Kind, this.FullWidth, diagnostics, this.GetAnnotations());
        }

        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            System.Diagnostics.Debug.Assert(this.GetType() == typeof(GreenSyntaxToken));
            return new GreenSyntaxToken(this.Kind, this.FullWidth, this.GetDiagnostics(), annotations);
        }

        public override TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitToken(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor)
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

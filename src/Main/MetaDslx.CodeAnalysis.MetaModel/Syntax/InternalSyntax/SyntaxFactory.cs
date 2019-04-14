using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    using BaseInternal = Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;

    internal class SyntaxFactory : BaseInternal.SyntaxFactory
    {
        public override Language Language => MetaModelLanguage.Instance;

        public override BaseInternal.SyntaxTrivia Trivia(int kind, string text, bool elastic = false)
        {
            var trivia = SyntaxTrivia.Create((SyntaxKind)kind, text);
            if (!elastic)
            {
                return trivia;
            }
            return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public override BaseInternal.SyntaxTrivia ConflictMarker(string text)
        {
            return SyntaxTrivia.Create(SyntaxKind.ConflictMarkerTrivia, text);
        }

        public override BaseInternal.SyntaxTrivia DisabledText(string text)
        {
            return SyntaxTrivia.Create(SyntaxKind.DisabledTextTrivia, text);
        }

        public override BaseInternal.SyntaxToken Token(int kind)
        {
            return SyntaxToken.Create((SyntaxKind)kind);
        }

        public override BaseInternal.SyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
        {
            return SyntaxToken.Create((SyntaxKind)kind, leading, trailing);
        }

        public override BaseInternal.SyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
        {
            Debug.Assert(MetaModelLanguage.Instance.SyntaxFacts.IsAnyToken(kind));
            return kind >= (int)SyntaxToken.FirstTokenWithWellKnownText && kind <= (int)SyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
                ? Token(leading, kind, trailing)
                : SyntaxToken.Identifier((SyntaxKind)kind, leading, text, trailing);
        }

        public override BaseInternal.SyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
        {
            Debug.Assert(MetaModelLanguage.Instance.SyntaxFacts.IsAnyToken(kind));
            string defaultText = MetaModelLanguage.Instance.SyntaxFacts.GetText(kind);
            return kind >= (int)SyntaxToken.FirstTokenWithWellKnownText && kind <= (int)SyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
                ? Token(leading, kind, trailing)
                : SyntaxToken.WithValue((SyntaxKind)kind, leading, text, valueText, trailing);
        }

        public override BaseInternal.SyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
        {
            Debug.Assert(MetaModelLanguage.Instance.SyntaxFacts.IsAnyToken(kind));
            return kind >= (int)SyntaxToken.FirstTokenWithWellKnownText && kind <= (int)SyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
                ? Token(leading, kind, trailing)
                : SyntaxToken.WithValue((SyntaxKind)kind, leading, text, value, trailing);
        }

        public override BaseInternal.SyntaxToken MissingToken(int kind)
        {
            return SyntaxToken.CreateMissing((SyntaxKind)kind, null, null);
        }

        public override BaseInternal.SyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
        {
            return SyntaxToken.CreateMissing((SyntaxKind)kind, leading, trailing);
        }

        public override BaseInternal.SyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
        {
            return SyntaxToken.WithValue((SyntaxKind)SyntaxKind.BadToken, leading, text, text, trailing);
        }

        internal override IEnumerable<SyntaxToken> GetWellKnownTokens()
        {
            return SyntaxToken.GetWellKnownTokens();
        }
    }
}

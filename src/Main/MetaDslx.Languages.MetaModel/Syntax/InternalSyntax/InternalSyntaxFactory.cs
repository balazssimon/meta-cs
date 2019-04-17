using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.Languages.MetaModel.Syntax.InternalSyntax
{
    using MetaDslx.CodeAnalysis;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using Microsoft.CodeAnalysis;

    internal class MetaModelInternalSyntaxFactory : InternalSyntaxFactory
    {
        public override Language Language => MetaModelLanguage.Instance;

        public override InternalSyntaxTrivia Trivia(int kind, string text, bool elastic = false)
        {
            var trivia = GreenSyntaxTrivia.Create((SyntaxKind)kind, text);
            if (!elastic)
            {
                return trivia;
            }
            return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public override InternalSyntaxTrivia ConflictMarker(string text)
        {
            return GreenSyntaxTrivia.Create(SyntaxKind.ConflictMarkerTrivia, text);
        }

        public override InternalSyntaxTrivia DisabledText(string text)
        {
            return GreenSyntaxTrivia.Create(SyntaxKind.DisabledTextTrivia, text);
        }

        public override InternalSyntaxToken Token(int kind)
        {
            return GreenSyntaxToken.Create((SyntaxKind)kind);
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
        {
            return GreenSyntaxToken.Create((SyntaxKind)kind, leading, trailing);
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
        {
            Debug.Assert(MetaModelLanguage.Instance.SyntaxFacts.IsToken(kind));
            string defaultText = MetaModelLanguage.Instance.SyntaxFacts.GetText(kind);
            return kind >= (int)GreenSyntaxToken.FirstTokenWithWellKnownText && kind <= (int)GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
                ? Token(leading, kind, trailing)
                : GreenSyntaxToken.Identifier((SyntaxKind)kind, leading, text, trailing);
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
        {
            Debug.Assert(MetaModelLanguage.Instance.SyntaxFacts.IsToken(kind));
            string defaultText = MetaModelLanguage.Instance.SyntaxFacts.GetText(kind);
            return kind >= (int)GreenSyntaxToken.FirstTokenWithWellKnownText && kind <= (int)GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
                ? Token(leading, kind, trailing)
                : GreenSyntaxToken.WithValue((SyntaxKind)kind, leading, text, valueText, trailing);
        }

        public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
        {
            Debug.Assert(MetaModelLanguage.Instance.SyntaxFacts.IsToken(kind));
            string defaultText = MetaModelLanguage.Instance.SyntaxFacts.GetText(kind);
            return kind >= (int)GreenSyntaxToken.FirstTokenWithWellKnownText && kind <= (int)GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
                ? Token(leading, kind, trailing)
                : GreenSyntaxToken.WithValue((SyntaxKind)kind, leading, text, value, trailing);
        }

        public override InternalSyntaxToken MissingToken(int kind)
        {
            return GreenSyntaxToken.CreateMissing((SyntaxKind)kind, null, null);
        }

        public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
        {
            return GreenSyntaxToken.CreateMissing((SyntaxKind)kind, leading, trailing);
        }

        public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
        {
            return GreenSyntaxToken.WithValue((SyntaxKind)SyntaxKind.BadToken, leading, text, text, trailing);
        }

        public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
        {
            return GreenSyntaxToken.GetWellKnownTokens();
        }
    }
}

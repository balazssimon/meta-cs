using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Meta.Classification
{
    internal class MetaClassifier : Antlr4LexerClassifier
    {
        private readonly MetaSyntaxFacts _syntaxFacts;

        internal MetaClassifier(ITextBuffer textBuffer, MetaDslxMefServices mefServices)
            : base(textBuffer, mefServices, new MetaLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
            _syntaxFacts = MetaLanguage.Instance.SyntaxFacts;
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            var syntaxKind = tokenType.FromAntlr4(_syntaxFacts.SyntaxKindType);
            MetaTokenKind tokenKind = _syntaxFacts.GetTokenKind(syntaxKind);
            if (tokenKind == MetaTokenKind.None)
            {
                tokenKind = _syntaxFacts.GetModeTokenKind(mode);
            }
            switch (tokenKind)
            {
                case MetaTokenKind.GeneralComment:
                case MetaTokenKind.DocumentationCommentTrivia:
                case MetaTokenKind.GeneralCommentTrivia:
                    return StandardClassificationService.Comment;
                case MetaTokenKind.Identifier:
                    return StandardClassificationService.Identifier;
                case MetaTokenKind.ReservedKeyword:
                case MetaTokenKind.ContextualKeyword:
                    return StandardClassificationService.Keyword;
                case MetaTokenKind.Number:
                    return StandardClassificationService.NumberLiteral;
                case MetaTokenKind.String:
                    return StandardClassificationService.StringLiteral;
                default:
                    return StandardClassificationService.Other;
            }

        }

    }

    /*    internal class MetaClassifier : TokenClassifier
        {
            private readonly MetaSyntaxFacts _syntaxFacts;

            internal MetaClassifier(ITextBuffer textBuffer, MetaDslxMefServices mefServices)
                : base(textBuffer, mefServices)
            {
                _syntaxFacts = MetaLanguage.Instance.SyntaxFacts;
            }

            protected override IClassificationType GetClassificationType(SyntaxKind syntaxKind)
            {
                MetaTokenKind tokenKind = _syntaxFacts.GetTokenKind(syntaxKind);
                switch (tokenKind)
                {
                    case MetaTokenKind.GeneralComment:
                    case MetaTokenKind.DocumentationCommentTrivia:
                    case MetaTokenKind.GeneralCommentTrivia:
                        return StandardClassificationService.Comment;
                    case MetaTokenKind.Identifier:
                        return StandardClassificationService.Identifier;
                    case MetaTokenKind.ReservedKeyword:
                    case MetaTokenKind.ContextualKeyword:
                        return StandardClassificationService.Keyword;
                    case MetaTokenKind.Number:
                        return StandardClassificationService.NumberLiteral;
                    case MetaTokenKind.String:
                        return StandardClassificationService.StringLiteral;
                    default:
                        return StandardClassificationService.Other;
                }

            }

        }*/


}

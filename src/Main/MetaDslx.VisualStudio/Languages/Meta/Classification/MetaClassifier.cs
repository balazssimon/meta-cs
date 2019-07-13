using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.VisualStudio.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Meta.Classification
{
    internal class MetaClassifier : Antlr4LexerClassifier
    {
        private MetaSyntaxFacts _syntaxFacts;

        internal MetaClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
            : base(textBuffer, classificationRegistryService, new MetaLexer(Antlr4LexerClassifier.EmptyCharStream))
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
            switch ((MetaTokenKind)tokenKind)
            {
                case MetaTokenKind.GeneralComment:
                case MetaTokenKind.DocumentationCommentTrivia:
                case MetaTokenKind.GeneralCommentTrivia:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Comment);
                case MetaTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Identifier);
                case MetaTokenKind.ReservedKeyword:
                case MetaTokenKind.ContextualKeyword:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Keyword);
                case MetaTokenKind.Number:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Number);
                case MetaTokenKind.String:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.String);
                default:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.None);
            }

        }

    }
}

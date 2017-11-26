using Antlr4.Runtime;
using MetaDslx.Languages.Soal.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Soal.Classification
{
    internal class SoalClassifier : Antlr4LexerClassifier
    {
        internal SoalClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
            : base(textBuffer, classificationRegistryService, new MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            SoalTokenKind tokenKind = SoalSyntaxFacts.Instance.GetTokenKind(tokenType);
            if (tokenKind == SoalTokenKind.None)
            {
                tokenKind = SoalSyntaxFacts.Instance.GetModeTokenKind(mode);
            }
            switch ((SoalTokenKind)tokenKind)
            {
                case SoalTokenKind.Comment:
                    return classificationRegistryService.GetClassificationType(SoalClassificationTypes.Comment);
                case SoalTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(SoalClassificationTypes.Identifier);
                case SoalTokenKind.Keyword:
                    return classificationRegistryService.GetClassificationType(SoalClassificationTypes.Keyword);
                case SoalTokenKind.Number:
                    return classificationRegistryService.GetClassificationType(SoalClassificationTypes.Number);
                case SoalTokenKind.String:
                    return classificationRegistryService.GetClassificationType(SoalClassificationTypes.String);
                default:
                    return classificationRegistryService.GetClassificationType(SoalClassificationTypes.None);
            }

        }

    }
}

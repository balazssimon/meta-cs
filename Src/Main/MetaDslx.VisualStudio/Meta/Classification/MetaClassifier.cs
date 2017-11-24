using Antlr4.Runtime;
using MetaDslx.Languages.Meta.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Meta.Classification
{
    internal class MetaClassifier : Antlr4LexerClassifier
    {
        internal MetaClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
            : base(textBuffer, classificationRegistryService, new MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetaLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            MetaTokenKind tokenKind = MetaSyntaxFacts.Instance.GetTokenKind(tokenType);
            if (tokenKind == MetaTokenKind.None)
            {
                tokenKind = MetaSyntaxFacts.Instance.GetModeTokenKind(mode);
            }
            switch ((MetaTokenKind)tokenKind)
            {
                case MetaTokenKind.Comment:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Comment);
                case MetaTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(MetaClassificationTypes.Identifier);
                case MetaTokenKind.Keyword:
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

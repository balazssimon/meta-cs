using Antlr4.Runtime;
using MetaDslx.Languages.Antlr4Roslyn.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Antlr4Roslyn.Classification
{
    internal class Antlr4RoslynClassifier : Antlr4LexerClassifier
    {
        internal Antlr4RoslynClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
            : base(textBuffer, classificationRegistryService, new MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.Antlr4RoslynLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            Antlr4RoslynTokenKind tokenKind = Antlr4RoslynSyntaxFacts.Instance.GetTokenKind(tokenType);
            if (tokenKind == Antlr4RoslynTokenKind.None)
            {
                tokenKind = Antlr4RoslynSyntaxFacts.Instance.GetModeTokenKind(mode);
            }
            switch ((Antlr4RoslynTokenKind)tokenKind)
            {
                case Antlr4RoslynTokenKind.Comment:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Comment);
                case Antlr4RoslynTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Identifier);
                case Antlr4RoslynTokenKind.Keyword:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Keyword);
                case Antlr4RoslynTokenKind.Number:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Number);
                case Antlr4RoslynTokenKind.String:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.String);
                case Antlr4RoslynTokenKind.Antlr4Action:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Action);
                case Antlr4RoslynTokenKind.Antlr4Options:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Options);
                case Antlr4RoslynTokenKind.Antlr4Rule:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Rule);
                case Antlr4RoslynTokenKind.Antlr4Token:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Token);
                default:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.None);
            }

        }

    }
}

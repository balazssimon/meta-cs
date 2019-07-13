using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax;
using MetaDslx.VisualStudio.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Antlr4Roslyn.Classification
{
    internal class Antlr4RoslynClassifier : Antlr4LexerClassifier
    {
        private Antlr4RoslynTokensSyntaxFacts _syntaxFacts;

        internal Antlr4RoslynClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
            : base(textBuffer, classificationRegistryService, new MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.Antlr4RoslynLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
            _syntaxFacts = new Antlr4RoslynTokensSyntaxFacts();
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            var syntaxKind = (Antlr4RoslynTokensSyntaxKind)tokenType.FromAntlr4(_syntaxFacts.SyntaxKindType);
            var tokenKind = _syntaxFacts.GetTokenKind(syntaxKind);
            if (tokenKind == Antlr4RoslynTokenKind.None)
            {
                tokenKind = _syntaxFacts.GetModeTokenKind((Antlr4RoslynLexerMode)mode);
            }
            switch (tokenKind)
            {
                case Antlr4RoslynTokenKind.Comment:
                case Antlr4RoslynTokenKind.DocComment:
                case Antlr4RoslynTokenKind.DocumentationCommentTrivia:
                case Antlr4RoslynTokenKind.GeneralComment:
                case Antlr4RoslynTokenKind.GeneralCommentTrivia:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Comment);
                case Antlr4RoslynTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(Antlr4RoslynClassificationTypes.Identifier);
                case Antlr4RoslynTokenKind.ReservedKeyword:
                case Antlr4RoslynTokenKind.ContextualKeyword:
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

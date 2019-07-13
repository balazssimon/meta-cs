using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.MetaGenerator.Syntax;
using MetaDslx.VisualStudio.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Classification
{
    internal class MetaGeneratorClassifier : Antlr4LexerClassifier
    {
        private MetaGeneratorSyntaxFacts _syntaxFacts;

        internal MetaGeneratorClassifier(ITextBuffer textBuffer, IClassificationTypeRegistryService classificationRegistryService)
            : base(textBuffer, classificationRegistryService, new MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax.MetaGeneratorLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
            _syntaxFacts = new MetaGeneratorSyntaxFacts();
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            var syntaxKind = (MetaGeneratorSyntaxKind)tokenType.FromAntlr4(_syntaxFacts.SyntaxKindType);
            var tokenKind = _syntaxFacts.GetTokenKind(syntaxKind);
            if (tokenKind == MetaGeneratorTokenKind.None)
            {
                tokenKind = _syntaxFacts.GetModeTokenKind(mode);
            }
            switch (tokenKind)
            {
                case MetaGeneratorTokenKind.DocumentationCommentTrivia:
                case MetaGeneratorTokenKind.GeneralComment:
                case MetaGeneratorTokenKind.GeneralCommentTrivia:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.Comment);
                case MetaGeneratorTokenKind.Identifier:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.Identifier);
                case MetaGeneratorTokenKind.ReservedKeyword:
                case MetaGeneratorTokenKind.ContextualKeyword:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.Keyword);
                case MetaGeneratorTokenKind.Number:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.Number);
                case MetaGeneratorTokenKind.String:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.String);
                case MetaGeneratorTokenKind.TemplateControl:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.TemplateControl);
                case MetaGeneratorTokenKind.TemplateOutput:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.TemplateOutput);
                default:
                    return classificationRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.None);
            }

        }

        protected override LexerState SaveLexerState()
        {
            return new MetaGeneratorLexerState(this.lexer);
        }

        private class MetaGeneratorLexerState : LexerState
        {
            private int templateBrackets;
            private int templateParenthesis;

            public MetaGeneratorLexerState(Lexer lexer)
                : base(lexer)
            {
                var typedLexer = lexer as MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax.MetaGeneratorLexer;
                if (lexer != null)
                {
                    this.templateBrackets = typedLexer._templateBrackets;
                    this.templateParenthesis = typedLexer._templateParenthesis;
                }
            }

            public override void Restore(Lexer lexer)
            {
                base.Restore(lexer);
                var typedLexer = lexer as MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax.MetaGeneratorLexer;
                if (lexer != null)
                {
                    typedLexer._templateBrackets = this.templateBrackets;
                    typedLexer._templateParenthesis = this.templateParenthesis;
                }
            }

            public override bool Equals(LexerState obj)
            {
                if (!base.Equals(obj)) return false;
                MetaGeneratorLexerState other = obj as MetaGeneratorLexerState;
                if (other != null)
                {
                    return this.templateBrackets == other.templateBrackets &&
                        this.templateParenthesis == other.templateParenthesis;
                }
                return false;
            }
        }
    }
}

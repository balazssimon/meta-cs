﻿using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.MetaGenerator.Syntax;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Utilities;
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
        private MetaGeneratorTokensSyntaxFacts _syntaxFacts;

        internal MetaGeneratorClassifier(ITextBuffer textBuffer, MetaDslxMefServices mefServices)
            : base(textBuffer, mefServices, new MetaGeneratorLexer(Antlr4LexerClassifier.EmptyCharStream))
        {
            _syntaxFacts = new MetaGeneratorTokensSyntaxFacts();
        }

        protected override IClassificationType GetClassificationType(int tokenType, int mode)
        {
            var syntaxKind = (MetaGeneratorTokensSyntaxKind)tokenType.FromAntlr4(_syntaxFacts.SyntaxKindType);
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
                    return StandardClassificationService.Comment;
                case MetaGeneratorTokenKind.Identifier:
                    return StandardClassificationService.Identifier;
                case MetaGeneratorTokenKind.ReservedKeyword:
                case MetaGeneratorTokenKind.ContextualKeyword:
                    return StandardClassificationService.Keyword;
                case MetaGeneratorTokenKind.Number:
                    return StandardClassificationService.NumberLiteral;
                case MetaGeneratorTokenKind.String:
                    return StandardClassificationService.StringLiteral;
                case MetaGeneratorTokenKind.TemplateControl:
                    return ClassificationTypeRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.TemplateControl);
                case MetaGeneratorTokenKind.TemplateOutput:
                    return ClassificationTypeRegistryService.GetClassificationType(MetaGeneratorClassificationTypes.TemplateOutput);
                default:
                    return StandardClassificationService.Other;
            }

        }

        protected override LexerState SaveLexerState()
        {
            return new MetaGeneratorLexerState(this.Lexer);
        }

        private class MetaGeneratorLexerState : LexerState
        {
            private int templateBrackets;
            private int templateParenthesis;

            public MetaGeneratorLexerState(Lexer lexer)
                : base(lexer)
            {
                var typedLexer = lexer as MetaGeneratorLexer;
                if (lexer != null)
                {
                    this.templateBrackets = typedLexer._templateBrackets;
                    this.templateParenthesis = typedLexer._templateParenthesis;
                }
            }

            public override void Restore(Lexer lexer)
            {
                base.Restore(lexer);
                var typedLexer = lexer as MetaGeneratorLexer;
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

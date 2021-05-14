using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax
{
    internal class CustomTestLexerModeInternalSyntaxFactory : TestLexerModeInternalSyntaxFactory
    {
        public CustomTestLexerModeInternalSyntaxFactory(TestLexerModeSyntaxFacts syntaxFacts) 
            : base(syntaxFacts)
        {
        }

        public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
        {
            return new CustomTestLexerModeSyntaxLexer(text, (TestLexerModeParseOptions)options);
        }
    }

    public class CustomTestLexerModeSyntaxLexer : TestLexerModeSyntaxLexer
    {
        public CustomTestLexerModeSyntaxLexer(SourceText text, TestLexerModeParseOptions options) 
            : base(text, options)
        {
        }

        protected override Antlr4LexerStateManager CreateStateManager()
        {
            return new CustomLexerStateManager(this);
        }

        protected class CustomLexerStateManager : Antlr4LexerStateManager
        {
            public CustomLexerStateManager(Antlr4SyntaxLexer lexer) 
                : base(lexer)
            {
            }

            public new TestLexerModeLexer Antlr4Lexer => (TestLexerModeLexer)base.Antlr4Lexer;

            protected override int ComputeStateHash()
            {
                return Hash.Combine(Antlr4Lexer._templateBrackets, Hash.Combine(Antlr4Lexer._templateParenthesis, base.ComputeStateHash()));
            }

            protected override bool IsInState(LexerState? state)
            {
                if (!base.IsInState(state)) return false;
                var antlr4Lexer = Antlr4Lexer;
                var customState = state as CustomLexerState;
                if (customState == null) return antlr4Lexer._templateParenthesis == 0 && antlr4Lexer._templateBrackets == 0;
                if (customState.TemplateParenthesis != antlr4Lexer._templateParenthesis) return false;
                if (customState.TemplateBrackets != antlr4Lexer._templateBrackets) return false;
                return true;
            }

            protected override LexerState? SaveState(int hashCode)
            {
                var antlr4Lexer = Antlr4Lexer;
                return new CustomLexerState(hashCode, antlr4Lexer.CurrentMode, antlr4Lexer.ModeStack.Count == 0 ? null : antlr4Lexer.ModeStack.ToArray(), antlr4Lexer._templateParenthesis, antlr4Lexer._templateBrackets);
            }

            protected override void RestoreState(LexerState? state)
            {
                base.RestoreState(state);
                var antlr4Lexer = Antlr4Lexer;
                var customState = state as CustomLexerState;
                if (customState == null)
                {
                    antlr4Lexer._templateParenthesis = 0;
                    antlr4Lexer._templateBrackets = 0;
                }
                else
                {
                    antlr4Lexer._templateParenthesis = customState.TemplateParenthesis;
                    antlr4Lexer._templateBrackets = customState.TemplateBrackets;
                }
            }
        }

    }

    public class CustomLexerState : Antlr4LexerState
    {
        private int _templateParenthesis = 0;
        private int _templateBrackets = 0;

        public CustomLexerState(int hashCode, int mode, int[]? modeStackReversed, int templateParenthesis, int templateBrackets)
            : base(hashCode, mode, modeStackReversed)
        {
            _templateParenthesis = templateParenthesis;
            _templateBrackets = templateBrackets;
        }

        public int TemplateParenthesis => _templateParenthesis;
        public int TemplateBrackets => _templateBrackets;

        public override string ToString()
        {
            return $"[{base.ToString()}, p={_templateParenthesis}, b={_templateBrackets}]";
        }
    }
}

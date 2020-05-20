using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
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

        protected override Antlr4LexerMode CreateAntlr4LexerModeSnapshot()
        {
            var antlr4Lexer = (TestLexerModeLexer)this.Antlr4Lexer;
            return new CustomLexerMode(this, antlr4Lexer._templateParenthesis, antlr4Lexer._templateBrackets);
        }

        protected override void RestoreAntlr4LexerMode(Antlr4LexerMode mode)
        {
            base.RestoreAntlr4LexerMode(mode);
            var customMode = (CustomLexerMode)mode;
            var antlr4Lexer = (TestLexerModeLexer)this.Antlr4Lexer;
            antlr4Lexer._templateParenthesis = customMode?.TemplateParenthesis ?? 0;
            antlr4Lexer._templateBrackets = customMode?.TemplateBrackets ?? 0;
            CallLogger.Instance.Call(mode);
            CallLogger.Instance.Log("  Lexer mode: " + CreateAntlr4LexerModeSnapshot());
        }
    }

    public class CustomLexerMode : Antlr4LexerMode, IEquatable<CustomLexerMode>
    {
        private int _templateParenthesis = 0;
        private int _templateBrackets = 0;

        public CustomLexerMode(IAntlr4Lexer lexer, int templateParenthesis, int templateBrackets)
            : base(lexer)
        {
            _templateParenthesis = templateParenthesis;
            _templateBrackets = templateBrackets;
        }

        public int TemplateParenthesis => _templateParenthesis;
        public int TemplateBrackets => _templateBrackets;

        public override bool HasChanged(IAntlr4Lexer lexer)
        {
            if (base.HasChanged(lexer)) return true;
            var antlr4Lexer = (TestLexerModeLexer)lexer.Antlr4Lexer;
            if (antlr4Lexer._templateParenthesis != _templateParenthesis) return true;
            if (antlr4Lexer._templateBrackets != _templateBrackets) return true;
            return false;
        }

        public bool Equals(CustomLexerMode other)
        {
            if (!base.Equals((Antlr4LexerMode)other)) return false;
            if (other == null) return _templateParenthesis == 0 && _templateBrackets == 0;
            if (other._templateParenthesis != _templateParenthesis) return false;
            if (other._templateBrackets != _templateBrackets) return false;
            return true;
        }

        public override bool Equals(Antlr4LexerMode other)
        {
            return this.Equals(other as CustomLexerMode);
        }

        public override string ToString()
        {
            return $"[{base.ToString()}, p={_templateParenthesis}, b={_templateBrackets}]";
        }
    }
}

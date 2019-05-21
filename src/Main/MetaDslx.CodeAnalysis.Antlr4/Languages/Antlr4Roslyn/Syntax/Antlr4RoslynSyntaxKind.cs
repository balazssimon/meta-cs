// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax
{
	public class Antlr4RoslynSyntaxKind : SyntaxKind
	{
        public static readonly int __FirstAntlr4TokenValue;
        public static readonly int __LastAntlr4TokenValue;
        public static readonly int __FirstAntlr4RuleValue;
        public static readonly int __LastAntlr4RuleValue;
        
        // Tokens:
        public const string TOKEN_REF = nameof(TOKEN_REF);
        public const string RULE_REF = nameof(RULE_REF);
        public const string LEXER_CHAR_SET = nameof(LEXER_CHAR_SET);
        public const string LINE_COMMENT = nameof(LINE_COMMENT);
        public const string INT = nameof(INT);
        public const string STRING_LITERAL = nameof(STRING_LITERAL);
        public const string UNTERMINATED_STRING_LITERAL = nameof(UNTERMINATED_STRING_LITERAL);
        public const string BEGIN_ARGUMENT = nameof(BEGIN_ARGUMENT);
        public const string BEGIN_ACTION = nameof(BEGIN_ACTION);
        public const string OPTIONS = nameof(OPTIONS);
        public const string TOKENS = nameof(TOKENS);
        public const string CHANNELS = nameof(CHANNELS);
        public const string IMPORT = nameof(IMPORT);
        public const string FRAGMENT = nameof(FRAGMENT);
        public const string LEXER = nameof(LEXER);
        public const string PARSER = nameof(PARSER);
        public const string GRAMMAR = nameof(GRAMMAR);
        public const string PROTECTED = nameof(PROTECTED);
        public const string PUBLIC = nameof(PUBLIC);
        public const string PRIVATE = nameof(PRIVATE);
        public const string RETURNS = nameof(RETURNS);
        public const string LOCALS = nameof(LOCALS);
        public const string THROWS = nameof(THROWS);
        public const string CATCH = nameof(CATCH);
        public const string FINALLY = nameof(FINALLY);
        public const string MODE = nameof(MODE);
        public const string TRUE = nameof(TRUE);
        public const string FALSE = nameof(FALSE);
        public const string NULL = nameof(NULL);
        public const string COLON = nameof(COLON);
        public const string COLONCOLON = nameof(COLONCOLON);
        public const string COMMA = nameof(COMMA);
        public const string SEMI = nameof(SEMI);
        public const string LPAREN = nameof(LPAREN);
        public const string RPAREN = nameof(RPAREN);
        public const string LBRACE = nameof(LBRACE);
        public const string RBRACE = nameof(RBRACE);
        public const string RARROW = nameof(RARROW);
        public const string LT = nameof(LT);
        public const string GT = nameof(GT);
        public const string ASSIGN = nameof(ASSIGN);
        public const string QUESTION = nameof(QUESTION);
        public const string STAR = nameof(STAR);
        public const string PLUS_ASSIGN = nameof(PLUS_ASSIGN);
        public const string PLUS = nameof(PLUS);
        public const string OR = nameof(OR);
        public const string DOLLAR = nameof(DOLLAR);
        public const string RANGE = nameof(RANGE);
        public const string DOT = nameof(DOT);
        public const string AT = nameof(AT);
        public const string POUND = nameof(POUND);
        public const string NOT = nameof(NOT);
        public const string ID = nameof(ID);
        public const string WS = nameof(WS);
        public const string ERRCHAR = nameof(ERRCHAR);
        public const string END_ARGUMENT = nameof(END_ARGUMENT);
        public const string UNTERMINATED_ARGUMENT = nameof(UNTERMINATED_ARGUMENT);
        public const string ARGUMENT_CONTENT = nameof(ARGUMENT_CONTENT);
        public const string END_ACTION = nameof(END_ACTION);
        public const string UNTERMINATED_ACTION = nameof(UNTERMINATED_ACTION);
        public const string ACTION_CONTENT = nameof(ACTION_CONTENT);
        public const string UNTERMINATED_CHAR_SET = nameof(UNTERMINATED_CHAR_SET);
        public const string DOC_COMMENT = nameof(DOC_COMMENT);
        public const string BLOCK_COMMENT = nameof(BLOCK_COMMENT);
        public const string DOC_COMMENT_START = nameof(DOC_COMMENT_START);
        public const string COMMENT_START = nameof(COMMENT_START);
        public const string DOC_COMMENT_STAR = nameof(DOC_COMMENT_STAR);

        // Rules:

        protected Antlr4RoslynSyntaxKind(string name)
            : base(name)
        {
        }

        protected Antlr4RoslynSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static Antlr4RoslynSyntaxKind()
        {
            EnumObject.AutoInit<Antlr4RoslynSyntaxKind>();
            __FirstAntlr4TokenValue = TOKEN_REF.AsEnum<Antlr4RoslynSyntaxKind>().GetValue();
            __LastAntlr4TokenValue = DOC_COMMENT_STAR.AsEnum<Antlr4RoslynSyntaxKind>().GetValue();
            __FirstAntlr4RuleValue = -1;
            __LastAntlr4RuleValue = -1;
        }

        public static implicit operator Antlr4RoslynSyntaxKind(string name)
        {
            return FromString<Antlr4RoslynSyntaxKind>(name);
        }

        public static explicit operator Antlr4RoslynSyntaxKind(int value)
        {
            return FromIntUnsafe<Antlr4RoslynSyntaxKind>(value);
        }

    }
}


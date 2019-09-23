// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax
{
	public class Antlr4RoslynTokensSyntaxKind : SyntaxKind
	{
        public static readonly Antlr4RoslynTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly Antlr4RoslynTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly Antlr4RoslynTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly Antlr4RoslynTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string TOKEN_REF = nameof(TOKEN_REF); // 1
		public const string RULE_REF = nameof(RULE_REF); // 2
		public const string LEXER_CHAR_SET = nameof(LEXER_CHAR_SET); // 3
		public const string DUMMY_TO_FIX_LEX_BASIC_GENERATION_ERROR = nameof(DUMMY_TO_FIX_LEX_BASIC_GENERATION_ERROR); // 4
		public const string LINE_COMMENT = nameof(LINE_COMMENT); // 5
		public const string INT = nameof(INT); // 6
		public const string STRING_LITERAL = nameof(STRING_LITERAL); // 7
		public const string UNTERMINATED_STRING_LITERAL = nameof(UNTERMINATED_STRING_LITERAL); // 8
		public const string BEGIN_ARGUMENT = nameof(BEGIN_ARGUMENT); // 9
		public const string BEGIN_ACTION = nameof(BEGIN_ACTION); // 10
		public const string OPTIONS = nameof(OPTIONS); // 11
		public const string TOKENS = nameof(TOKENS); // 12
		public const string CHANNELS = nameof(CHANNELS); // 13
		public const string IMPORT = nameof(IMPORT); // 14
		public const string FRAGMENT = nameof(FRAGMENT); // 15
		public const string LEXER = nameof(LEXER); // 16
		public const string PARSER = nameof(PARSER); // 17
		public const string GRAMMAR = nameof(GRAMMAR); // 18
		public const string PROTECTED = nameof(PROTECTED); // 19
		public const string PUBLIC = nameof(PUBLIC); // 20
		public const string PRIVATE = nameof(PRIVATE); // 21
		public const string RETURNS = nameof(RETURNS); // 22
		public const string LOCALS = nameof(LOCALS); // 23
		public const string THROWS = nameof(THROWS); // 24
		public const string CATCH = nameof(CATCH); // 25
		public const string FINALLY = nameof(FINALLY); // 26
		public const string MODE = nameof(MODE); // 27
		public const string TRUE = nameof(TRUE); // 28
		public const string FALSE = nameof(FALSE); // 29
		public const string NULL = nameof(NULL); // 30
		public const string COLON = nameof(COLON); // 31
		public const string COLONCOLON = nameof(COLONCOLON); // 32
		public const string COMMA = nameof(COMMA); // 33
		public const string SEMI = nameof(SEMI); // 34
		public const string LPAREN = nameof(LPAREN); // 35
		public const string RPAREN = nameof(RPAREN); // 36
		public const string LBRACE = nameof(LBRACE); // 37
		public const string RBRACE = nameof(RBRACE); // 38
		public const string RARROW = nameof(RARROW); // 39
		public const string LT = nameof(LT); // 40
		public const string GT = nameof(GT); // 41
		public const string ASSIGN = nameof(ASSIGN); // 42
		public const string QUESTION = nameof(QUESTION); // 43
		public const string STAR = nameof(STAR); // 44
		public const string PLUS_ASSIGN = nameof(PLUS_ASSIGN); // 45
		public const string PLUS = nameof(PLUS); // 46
		public const string OR = nameof(OR); // 47
		public const string DOLLAR = nameof(DOLLAR); // 48
		public const string RANGE = nameof(RANGE); // 49
		public const string DOT = nameof(DOT); // 50
		public const string AT = nameof(AT); // 51
		public const string POUND = nameof(POUND); // 52
		public const string NOT = nameof(NOT); // 53
		public const string ID = nameof(ID); // 54
		public const string WS = nameof(WS); // 55
		public const string ERRCHAR = nameof(ERRCHAR); // 56
		public const string END_ARGUMENT = nameof(END_ARGUMENT); // 57
		public const string UNTERMINATED_ARGUMENT = nameof(UNTERMINATED_ARGUMENT); // 58
		public const string ARGUMENT_CONTENT = nameof(ARGUMENT_CONTENT); // 59
		public const string END_ACTION = nameof(END_ACTION); // 60
		public const string UNTERMINATED_ACTION = nameof(UNTERMINATED_ACTION); // 61
		public const string ACTION_CONTENT = nameof(ACTION_CONTENT); // 62
		public const string UNTERMINATED_CHAR_SET = nameof(UNTERMINATED_CHAR_SET); // 63
		public const string DOC_COMMENT = nameof(DOC_COMMENT); // 64
		public const string BLOCK_COMMENT = nameof(BLOCK_COMMENT); // 65
		public const string DOC_COMMENT_START = nameof(DOC_COMMENT_START); // 66
		public const string COMMENT_START = nameof(COMMENT_START); // 67
		public const string DOC_COMMENT_STAR = nameof(DOC_COMMENT_STAR); // 68

		protected Antlr4RoslynTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected Antlr4RoslynTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static Antlr4RoslynTokensSyntaxKind()
        {
            EnumObject.AutoInit<Antlr4RoslynTokensSyntaxKind>();
            __FirstToken = TOKEN_REF;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = DOC_COMMENT_STAR;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = OPTIONS;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = NULL;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator Antlr4RoslynTokensSyntaxKind(string name)
        {
            return FromString<Antlr4RoslynTokensSyntaxKind>(name);
        }

        public static explicit operator Antlr4RoslynTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<Antlr4RoslynTokensSyntaxKind>(value);
        }

	}
}


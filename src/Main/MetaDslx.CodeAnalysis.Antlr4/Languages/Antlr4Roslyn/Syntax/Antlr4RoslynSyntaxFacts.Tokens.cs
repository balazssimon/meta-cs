// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax
{
	public enum Antlr4RoslynTokenKind : int
	{
		None = 0,
		Antlr4Action,
		Antlr4Options,
		Antlr4Rule,
		Antlr4Token,
		Comment,
		ContextualKeyword,
		DocComment,
		DocumentationCommentTrivia,
		ExternAliasDirective,
		FixedToken,
		GeneralComment,
		GeneralCommentTrivia,
		Identifier,
		Number,
		Operator,
		PreprocessorContextualKeyword,
		PreprocessorDirective,
		PreprocessorKeyword,
		ReservedKeyword,
		String,
		Token,
		Trivia,
		Whitespace
	}

	public enum Antlr4RoslynLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		Argument = 1,
		ActionMode = 2,
		Options = 3,
		Tokens = 4,
		Channels = 5,
		LexerCharSet = 6,
		DOC_COMMENT_MODE = 7,
		BLOCK_COMMENT_MODE = 8,
		ACTION_DOC_COMMENT_MODE = 9,
		ACTION_BLOCK_COMMENT_MODE = 10
	}

	public class Antlr4RoslynTokensSyntaxFacts : SyntaxFacts
	{
        public Antlr4RoslynTokensSyntaxFacts() 
            : base(typeof(Antlr4RoslynTokensSyntaxKind))
        {
        }

        protected Antlr4RoslynTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (Antlr4RoslynTokensSyntaxKind)Antlr4RoslynTokensSyntaxKind.WS;
        public override SyntaxKind DefaultEndOfLineKind => (Antlr4RoslynTokensSyntaxKind)Antlr4RoslynTokensSyntaxKind.WS;
        public override SyntaxKind DefaultSeparatorKind => (Antlr4RoslynTokensSyntaxKind)Antlr4RoslynTokensSyntaxKind.COMMA;
        public override SyntaxKind DefaultIdentifierKind => (Antlr4RoslynTokensSyntaxKind)Antlr4RoslynTokensSyntaxKind.ID;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.Eof:
				case Antlr4RoslynTokensSyntaxKind.TOKEN_REF:
				case Antlr4RoslynTokensSyntaxKind.RULE_REF:
				case Antlr4RoslynTokensSyntaxKind.LEXER_CHAR_SET:
				case Antlr4RoslynTokensSyntaxKind.DUMMY_TO_FIX_LEX_BASIC_GENERATION_ERROR:
				case Antlr4RoslynTokensSyntaxKind.LINE_COMMENT:
				case Antlr4RoslynTokensSyntaxKind.INT:
				case Antlr4RoslynTokensSyntaxKind.STRING_LITERAL:
				case Antlr4RoslynTokensSyntaxKind.UNTERMINATED_STRING_LITERAL:
				case Antlr4RoslynTokensSyntaxKind.BEGIN_ARGUMENT:
				case Antlr4RoslynTokensSyntaxKind.BEGIN_ACTION:
				case Antlr4RoslynTokensSyntaxKind.OPTIONS:
				case Antlr4RoslynTokensSyntaxKind.TOKENS:
				case Antlr4RoslynTokensSyntaxKind.CHANNELS:
				case Antlr4RoslynTokensSyntaxKind.IMPORT:
				case Antlr4RoslynTokensSyntaxKind.FRAGMENT:
				case Antlr4RoslynTokensSyntaxKind.LEXER:
				case Antlr4RoslynTokensSyntaxKind.PARSER:
				case Antlr4RoslynTokensSyntaxKind.GRAMMAR:
				case Antlr4RoslynTokensSyntaxKind.PROTECTED:
				case Antlr4RoslynTokensSyntaxKind.PUBLIC:
				case Antlr4RoslynTokensSyntaxKind.PRIVATE:
				case Antlr4RoslynTokensSyntaxKind.RETURNS:
				case Antlr4RoslynTokensSyntaxKind.LOCALS:
				case Antlr4RoslynTokensSyntaxKind.THROWS:
				case Antlr4RoslynTokensSyntaxKind.CATCH:
				case Antlr4RoslynTokensSyntaxKind.FINALLY:
				case Antlr4RoslynTokensSyntaxKind.MODE:
				case Antlr4RoslynTokensSyntaxKind.TRUE:
				case Antlr4RoslynTokensSyntaxKind.FALSE:
				case Antlr4RoslynTokensSyntaxKind.NULL:
				case Antlr4RoslynTokensSyntaxKind.COLON:
				case Antlr4RoslynTokensSyntaxKind.COLONCOLON:
				case Antlr4RoslynTokensSyntaxKind.COMMA:
				case Antlr4RoslynTokensSyntaxKind.SEMI:
				case Antlr4RoslynTokensSyntaxKind.LPAREN:
				case Antlr4RoslynTokensSyntaxKind.RPAREN:
				case Antlr4RoslynTokensSyntaxKind.LBRACE:
				case Antlr4RoslynTokensSyntaxKind.RBRACE:
				case Antlr4RoslynTokensSyntaxKind.RARROW:
				case Antlr4RoslynTokensSyntaxKind.LT:
				case Antlr4RoslynTokensSyntaxKind.GT:
				case Antlr4RoslynTokensSyntaxKind.ASSIGN:
				case Antlr4RoslynTokensSyntaxKind.QUESTION:
				case Antlr4RoslynTokensSyntaxKind.STAR:
				case Antlr4RoslynTokensSyntaxKind.PLUS_ASSIGN:
				case Antlr4RoslynTokensSyntaxKind.PLUS:
				case Antlr4RoslynTokensSyntaxKind.OR:
				case Antlr4RoslynTokensSyntaxKind.DOLLAR:
				case Antlr4RoslynTokensSyntaxKind.RANGE:
				case Antlr4RoslynTokensSyntaxKind.DOT:
				case Antlr4RoslynTokensSyntaxKind.AT:
				case Antlr4RoslynTokensSyntaxKind.POUND:
				case Antlr4RoslynTokensSyntaxKind.NOT:
				case Antlr4RoslynTokensSyntaxKind.ID:
				case Antlr4RoslynTokensSyntaxKind.WS:
				case Antlr4RoslynTokensSyntaxKind.ERRCHAR:
				case Antlr4RoslynTokensSyntaxKind.END_ARGUMENT:
				case Antlr4RoslynTokensSyntaxKind.UNTERMINATED_ARGUMENT:
				case Antlr4RoslynTokensSyntaxKind.ARGUMENT_CONTENT:
				case Antlr4RoslynTokensSyntaxKind.END_ACTION:
				case Antlr4RoslynTokensSyntaxKind.UNTERMINATED_ACTION:
				case Antlr4RoslynTokensSyntaxKind.ACTION_CONTENT:
				case Antlr4RoslynTokensSyntaxKind.UNTERMINATED_CHAR_SET:
				case Antlr4RoslynTokensSyntaxKind.DOC_COMMENT:
				case Antlr4RoslynTokensSyntaxKind.BLOCK_COMMENT:
				case Antlr4RoslynTokensSyntaxKind.DOC_COMMENT_START:
				case Antlr4RoslynTokensSyntaxKind.COMMENT_START:
				case Antlr4RoslynTokensSyntaxKind.DOC_COMMENT_STAR:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.OPTIONS:
				case Antlr4RoslynTokensSyntaxKind.TOKENS:
				case Antlr4RoslynTokensSyntaxKind.CHANNELS:
				case Antlr4RoslynTokensSyntaxKind.IMPORT:
				case Antlr4RoslynTokensSyntaxKind.FRAGMENT:
				case Antlr4RoslynTokensSyntaxKind.LEXER:
				case Antlr4RoslynTokensSyntaxKind.PARSER:
				case Antlr4RoslynTokensSyntaxKind.GRAMMAR:
				case Antlr4RoslynTokensSyntaxKind.PROTECTED:
				case Antlr4RoslynTokensSyntaxKind.PUBLIC:
				case Antlr4RoslynTokensSyntaxKind.PRIVATE:
				case Antlr4RoslynTokensSyntaxKind.RETURNS:
				case Antlr4RoslynTokensSyntaxKind.LOCALS:
				case Antlr4RoslynTokensSyntaxKind.THROWS:
				case Antlr4RoslynTokensSyntaxKind.CATCH:
				case Antlr4RoslynTokensSyntaxKind.FINALLY:
				case Antlr4RoslynTokensSyntaxKind.MODE:
				case Antlr4RoslynTokensSyntaxKind.TRUE:
				case Antlr4RoslynTokensSyntaxKind.FALSE:
				case Antlr4RoslynTokensSyntaxKind.NULL:
					return true;
				default:
					return false;
			}
		}

		public override SyntaxKind GetFixedTokenKind(string text)
		{
			switch (text)
			{
				case "options":
					return Antlr4RoslynTokensSyntaxKind.OPTIONS;
				case "tokens":
					return Antlr4RoslynTokensSyntaxKind.TOKENS;
				case "channels":
					return Antlr4RoslynTokensSyntaxKind.CHANNELS;
				case "import":
					return Antlr4RoslynTokensSyntaxKind.IMPORT;
				case "fragment":
					return Antlr4RoslynTokensSyntaxKind.FRAGMENT;
				case "lexer":
					return Antlr4RoslynTokensSyntaxKind.LEXER;
				case "parser":
					return Antlr4RoslynTokensSyntaxKind.PARSER;
				case "grammar":
					return Antlr4RoslynTokensSyntaxKind.GRAMMAR;
				case "protected":
					return Antlr4RoslynTokensSyntaxKind.PROTECTED;
				case "public":
					return Antlr4RoslynTokensSyntaxKind.PUBLIC;
				case "private":
					return Antlr4RoslynTokensSyntaxKind.PRIVATE;
				case "returns":
					return Antlr4RoslynTokensSyntaxKind.RETURNS;
				case "locals":
					return Antlr4RoslynTokensSyntaxKind.LOCALS;
				case "throws":
					return Antlr4RoslynTokensSyntaxKind.THROWS;
				case "catch":
					return Antlr4RoslynTokensSyntaxKind.CATCH;
				case "finally":
					return Antlr4RoslynTokensSyntaxKind.FINALLY;
				case "mode":
					return Antlr4RoslynTokensSyntaxKind.MODE;
				case "true":
					return Antlr4RoslynTokensSyntaxKind.TRUE;
				case "false":
					return Antlr4RoslynTokensSyntaxKind.FALSE;
				case "null":
					return Antlr4RoslynTokensSyntaxKind.NULL;
				default:
					return Antlr4RoslynTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.OPTIONS:
					return "options";
				case Antlr4RoslynTokensSyntaxKind.TOKENS:
					return "tokens";
				case Antlr4RoslynTokensSyntaxKind.CHANNELS:
					return "channels";
				case Antlr4RoslynTokensSyntaxKind.IMPORT:
					return "import";
				case Antlr4RoslynTokensSyntaxKind.FRAGMENT:
					return "fragment";
				case Antlr4RoslynTokensSyntaxKind.LEXER:
					return "lexer";
				case Antlr4RoslynTokensSyntaxKind.PARSER:
					return "parser";
				case Antlr4RoslynTokensSyntaxKind.GRAMMAR:
					return "grammar";
				case Antlr4RoslynTokensSyntaxKind.PROTECTED:
					return "protected";
				case Antlr4RoslynTokensSyntaxKind.PUBLIC:
					return "public";
				case Antlr4RoslynTokensSyntaxKind.PRIVATE:
					return "private";
				case Antlr4RoslynTokensSyntaxKind.RETURNS:
					return "returns";
				case Antlr4RoslynTokensSyntaxKind.LOCALS:
					return "locals";
				case Antlr4RoslynTokensSyntaxKind.THROWS:
					return "throws";
				case Antlr4RoslynTokensSyntaxKind.CATCH:
					return "catch";
				case Antlr4RoslynTokensSyntaxKind.FINALLY:
					return "finally";
				case Antlr4RoslynTokensSyntaxKind.MODE:
					return "mode";
				case Antlr4RoslynTokensSyntaxKind.TRUE:
					return "true";
				case Antlr4RoslynTokensSyntaxKind.FALSE:
					return "false";
				case Antlr4RoslynTokensSyntaxKind.NULL:
					return "null";
				default:
					return string.Empty;
			}
		}

		public Antlr4RoslynTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<Antlr4RoslynTokensSyntaxKind>(rawKind));
		}

		public Antlr4RoslynTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.TOKEN_REF:
					return Antlr4RoslynTokenKind.Antlr4Token;
				case Antlr4RoslynTokensSyntaxKind.RULE_REF:
					return Antlr4RoslynTokenKind.Antlr4Rule;
				case Antlr4RoslynTokensSyntaxKind.LEXER_CHAR_SET:
					return Antlr4RoslynTokenKind.Operator;
				case Antlr4RoslynTokensSyntaxKind.LINE_COMMENT:
					return Antlr4RoslynTokenKind.GeneralComment;
				case Antlr4RoslynTokensSyntaxKind.INT:
					return Antlr4RoslynTokenKind.Number;
				case Antlr4RoslynTokensSyntaxKind.STRING_LITERAL:
					return Antlr4RoslynTokenKind.String;
				case Antlr4RoslynTokensSyntaxKind.UNTERMINATED_STRING_LITERAL:
					return Antlr4RoslynTokenKind.String;
				case Antlr4RoslynTokensSyntaxKind.BEGIN_ACTION:
					return Antlr4RoslynTokenKind.Antlr4Action;
				case Antlr4RoslynTokensSyntaxKind.OPTIONS:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynTokensSyntaxKind.TOKENS:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynTokensSyntaxKind.CHANNELS:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynTokensSyntaxKind.IMPORT:
				case Antlr4RoslynTokensSyntaxKind.FRAGMENT:
				case Antlr4RoslynTokensSyntaxKind.LEXER:
				case Antlr4RoslynTokensSyntaxKind.PARSER:
				case Antlr4RoslynTokensSyntaxKind.GRAMMAR:
				case Antlr4RoslynTokensSyntaxKind.PROTECTED:
				case Antlr4RoslynTokensSyntaxKind.PUBLIC:
				case Antlr4RoslynTokensSyntaxKind.PRIVATE:
				case Antlr4RoslynTokensSyntaxKind.RETURNS:
				case Antlr4RoslynTokensSyntaxKind.LOCALS:
				case Antlr4RoslynTokensSyntaxKind.THROWS:
				case Antlr4RoslynTokensSyntaxKind.CATCH:
				case Antlr4RoslynTokensSyntaxKind.FINALLY:
				case Antlr4RoslynTokensSyntaxKind.MODE:
				case Antlr4RoslynTokensSyntaxKind.TRUE:
				case Antlr4RoslynTokensSyntaxKind.FALSE:
				case Antlr4RoslynTokensSyntaxKind.NULL:
					return Antlr4RoslynTokenKind.ReservedKeyword;
				case Antlr4RoslynTokensSyntaxKind.ID:
					return Antlr4RoslynTokenKind.Identifier;
				case Antlr4RoslynTokensSyntaxKind.WS:
					return Antlr4RoslynTokenKind.Whitespace;
				case Antlr4RoslynTokensSyntaxKind.DOC_COMMENT:
					return Antlr4RoslynTokenKind.Comment;
				case Antlr4RoslynTokensSyntaxKind.BLOCK_COMMENT:
					return Antlr4RoslynTokenKind.Comment;
				default:
					return Antlr4RoslynTokenKind.None;
			}
		}

		public Antlr4RoslynTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((Antlr4RoslynLexerMode)rawKind);
		}

		public Antlr4RoslynTokenKind GetModeTokenKind(Antlr4RoslynLexerMode kind)
		{
			switch(kind)
			{
				case Antlr4RoslynLexerMode.ActionMode:
					return Antlr4RoslynTokenKind.Antlr4Action;
				case Antlr4RoslynLexerMode.Options:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynLexerMode.Tokens:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynLexerMode.Channels:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynLexerMode.DOC_COMMENT_MODE:
					return Antlr4RoslynTokenKind.DocComment;
				case Antlr4RoslynLexerMode.BLOCK_COMMENT_MODE:
					return Antlr4RoslynTokenKind.Comment;
				case Antlr4RoslynLexerMode.ACTION_DOC_COMMENT_MODE:
					return Antlr4RoslynTokenKind.DocComment;
				case Antlr4RoslynLexerMode.ACTION_BLOCK_COMMENT_MODE:
					return Antlr4RoslynTokenKind.Comment;
				default:
					return Antlr4RoslynTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}

		public override bool IsTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsReservedKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.IMPORT:
				case Antlr4RoslynTokensSyntaxKind.FRAGMENT:
				case Antlr4RoslynTokensSyntaxKind.LEXER:
				case Antlr4RoslynTokensSyntaxKind.PARSER:
				case Antlr4RoslynTokensSyntaxKind.GRAMMAR:
				case Antlr4RoslynTokensSyntaxKind.PROTECTED:
				case Antlr4RoslynTokensSyntaxKind.PUBLIC:
				case Antlr4RoslynTokensSyntaxKind.PRIVATE:
				case Antlr4RoslynTokensSyntaxKind.RETURNS:
				case Antlr4RoslynTokensSyntaxKind.LOCALS:
				case Antlr4RoslynTokensSyntaxKind.THROWS:
				case Antlr4RoslynTokensSyntaxKind.CATCH:
				case Antlr4RoslynTokensSyntaxKind.FINALLY:
				case Antlr4RoslynTokensSyntaxKind.MODE:
				case Antlr4RoslynTokensSyntaxKind.TRUE:
				case Antlr4RoslynTokensSyntaxKind.FALSE:
				case Antlr4RoslynTokensSyntaxKind.NULL:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return Antlr4RoslynTokensSyntaxKind.IMPORT;
				yield return Antlr4RoslynTokensSyntaxKind.FRAGMENT;
				yield return Antlr4RoslynTokensSyntaxKind.LEXER;
				yield return Antlr4RoslynTokensSyntaxKind.PARSER;
				yield return Antlr4RoslynTokensSyntaxKind.GRAMMAR;
				yield return Antlr4RoslynTokensSyntaxKind.PROTECTED;
				yield return Antlr4RoslynTokensSyntaxKind.PUBLIC;
				yield return Antlr4RoslynTokensSyntaxKind.PRIVATE;
				yield return Antlr4RoslynTokensSyntaxKind.RETURNS;
				yield return Antlr4RoslynTokensSyntaxKind.LOCALS;
				yield return Antlr4RoslynTokensSyntaxKind.THROWS;
				yield return Antlr4RoslynTokensSyntaxKind.CATCH;
				yield return Antlr4RoslynTokensSyntaxKind.FINALLY;
				yield return Antlr4RoslynTokensSyntaxKind.MODE;
				yield return Antlr4RoslynTokensSyntaxKind.TRUE;
				yield return Antlr4RoslynTokensSyntaxKind.FALSE;
				yield return Antlr4RoslynTokensSyntaxKind.NULL;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "import":
					return Antlr4RoslynTokensSyntaxKind.IMPORT;
				case "fragment":
					return Antlr4RoslynTokensSyntaxKind.FRAGMENT;
				case "lexer":
					return Antlr4RoslynTokensSyntaxKind.LEXER;
				case "parser":
					return Antlr4RoslynTokensSyntaxKind.PARSER;
				case "grammar":
					return Antlr4RoslynTokensSyntaxKind.GRAMMAR;
				case "protected":
					return Antlr4RoslynTokensSyntaxKind.PROTECTED;
				case "public":
					return Antlr4RoslynTokensSyntaxKind.PUBLIC;
				case "private":
					return Antlr4RoslynTokensSyntaxKind.PRIVATE;
				case "returns":
					return Antlr4RoslynTokensSyntaxKind.RETURNS;
				case "locals":
					return Antlr4RoslynTokensSyntaxKind.LOCALS;
				case "throws":
					return Antlr4RoslynTokensSyntaxKind.THROWS;
				case "catch":
					return Antlr4RoslynTokensSyntaxKind.CATCH;
				case "finally":
					return Antlr4RoslynTokensSyntaxKind.FINALLY;
				case "mode":
					return Antlr4RoslynTokensSyntaxKind.MODE;
				case "true":
					return Antlr4RoslynTokensSyntaxKind.TRUE;
				case "false":
					return Antlr4RoslynTokensSyntaxKind.FALSE;
				case "null":
					return Antlr4RoslynTokensSyntaxKind.NULL;
				default:
					return SyntaxKind.None;
			}
        }
		public override bool IsContextualKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetContextualKeywordKinds()
        {
			yield break;
        }

        public override SyntaxKind GetContextualKeywordKind(string text)
        {
			switch(text)
			{
				default:
					return SyntaxKind.None;
			}
        }
		public override bool IsPreprocessorKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsPreprocessorContextualKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsPreprocessorDirective(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsIdentifier(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.ID:
					return true;
				default:
					return false;
			}
		}
		public override bool IsGeneralCommentTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsDocumentationCommentTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public bool IsAntlr4Token(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.TOKEN_REF:
					return true;
				default:
					return false;
			}
		}
		public override bool IsExternAliasDirective(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public bool IsAntlr4Rule(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.RULE_REF:
					return true;
				default:
					return false;
			}
		}
		public bool IsOperator(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.LEXER_CHAR_SET:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.LINE_COMMENT:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.INT:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.STRING_LITERAL:
					return true;
				case Antlr4RoslynTokensSyntaxKind.UNTERMINATED_STRING_LITERAL:
					return true;
				default:
					return false;
			}
		}
		public bool IsAntlr4Action(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.BEGIN_ACTION:
					return true;
				default:
					return false;
			}
		}
		public bool IsAntlr4Options(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.OPTIONS:
					return true;
				case Antlr4RoslynTokensSyntaxKind.TOKENS:
					return true;
				case Antlr4RoslynTokensSyntaxKind.CHANNELS:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.WS:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case Antlr4RoslynTokensSyntaxKind.DOC_COMMENT:
					return true;
				case Antlr4RoslynTokensSyntaxKind.BLOCK_COMMENT:
					return true;
				default:
					return false;
			}
		}
		public bool IsDocComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
	}
}


using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

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
		DocComment,
		Identifier,
		Keyword,
		Number,
		Operator,
		String
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

	public class Antlr4RoslynSyntaxFacts : SyntaxFacts
	{
		public static readonly Antlr4RoslynSyntaxFacts Instance = new Antlr4RoslynSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)Antlr4RoslynSyntaxKind.None; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)Antlr4RoslynSyntaxKind.None; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsToken(Antlr4RoslynSyntaxKind kind)
		{
			switch (kind)
			{
				case Antlr4RoslynSyntaxKind.Eof:
				case Antlr4RoslynSyntaxKind.TOKEN_REF:
				case Antlr4RoslynSyntaxKind.RULE_REF:
				case Antlr4RoslynSyntaxKind.LEXER_CHAR_SET:
				case Antlr4RoslynSyntaxKind.LINE_COMMENT:
				case Antlr4RoslynSyntaxKind.INT:
				case Antlr4RoslynSyntaxKind.STRING_LITERAL:
				case Antlr4RoslynSyntaxKind.UNTERMINATED_STRING_LITERAL:
				case Antlr4RoslynSyntaxKind.BEGIN_ARGUMENT:
				case Antlr4RoslynSyntaxKind.BEGIN_ACTION:
				case Antlr4RoslynSyntaxKind.OPTIONS:
				case Antlr4RoslynSyntaxKind.TOKENS:
				case Antlr4RoslynSyntaxKind.CHANNELS:
				case Antlr4RoslynSyntaxKind.IMPORT:
				case Antlr4RoslynSyntaxKind.FRAGMENT:
				case Antlr4RoslynSyntaxKind.LEXER:
				case Antlr4RoslynSyntaxKind.PARSER:
				case Antlr4RoslynSyntaxKind.GRAMMAR:
				case Antlr4RoslynSyntaxKind.PROTECTED:
				case Antlr4RoslynSyntaxKind.PUBLIC:
				case Antlr4RoslynSyntaxKind.PRIVATE:
				case Antlr4RoslynSyntaxKind.RETURNS:
				case Antlr4RoslynSyntaxKind.LOCALS:
				case Antlr4RoslynSyntaxKind.THROWS:
				case Antlr4RoslynSyntaxKind.CATCH:
				case Antlr4RoslynSyntaxKind.FINALLY:
				case Antlr4RoslynSyntaxKind.MODE:
				case Antlr4RoslynSyntaxKind.TRUE:
				case Antlr4RoslynSyntaxKind.FALSE:
				case Antlr4RoslynSyntaxKind.NULL:
				case Antlr4RoslynSyntaxKind.COLON:
				case Antlr4RoslynSyntaxKind.COLONCOLON:
				case Antlr4RoslynSyntaxKind.COMMA:
				case Antlr4RoslynSyntaxKind.SEMI:
				case Antlr4RoslynSyntaxKind.LPAREN:
				case Antlr4RoslynSyntaxKind.RPAREN:
				case Antlr4RoslynSyntaxKind.LBRACE:
				case Antlr4RoslynSyntaxKind.RBRACE:
				case Antlr4RoslynSyntaxKind.RARROW:
				case Antlr4RoslynSyntaxKind.LT:
				case Antlr4RoslynSyntaxKind.GT:
				case Antlr4RoslynSyntaxKind.ASSIGN:
				case Antlr4RoslynSyntaxKind.QUESTION:
				case Antlr4RoslynSyntaxKind.STAR:
				case Antlr4RoslynSyntaxKind.PLUS_ASSIGN:
				case Antlr4RoslynSyntaxKind.PLUS:
				case Antlr4RoslynSyntaxKind.OR:
				case Antlr4RoslynSyntaxKind.DOLLAR:
				case Antlr4RoslynSyntaxKind.RANGE:
				case Antlr4RoslynSyntaxKind.DOT:
				case Antlr4RoslynSyntaxKind.AT:
				case Antlr4RoslynSyntaxKind.POUND:
				case Antlr4RoslynSyntaxKind.NOT:
				case Antlr4RoslynSyntaxKind.ID:
				case Antlr4RoslynSyntaxKind.WS:
				case Antlr4RoslynSyntaxKind.ERRCHAR:
				case Antlr4RoslynSyntaxKind.END_ARGUMENT:
				case Antlr4RoslynSyntaxKind.UNTERMINATED_ARGUMENT:
				case Antlr4RoslynSyntaxKind.ARGUMENT_CONTENT:
				case Antlr4RoslynSyntaxKind.END_ACTION:
				case Antlr4RoslynSyntaxKind.UNTERMINATED_ACTION:
				case Antlr4RoslynSyntaxKind.ACTION_CONTENT:
				case Antlr4RoslynSyntaxKind.UNTERMINATED_CHAR_SET:
				case Antlr4RoslynSyntaxKind.DOC_COMMENT:
				case Antlr4RoslynSyntaxKind.BLOCK_COMMENT:
				case Antlr4RoslynSyntaxKind.DOC_COMMENT_START:
				case Antlr4RoslynSyntaxKind.COMMENT_START:
				case Antlr4RoslynSyntaxKind.DOC_COMMENT_STAR:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsFixedToken(Antlr4RoslynSyntaxKind kind)
		{
			switch (kind)
			{
				case Antlr4RoslynSyntaxKind.Eof:
				case Antlr4RoslynSyntaxKind.OPTIONS:
				case Antlr4RoslynSyntaxKind.TOKENS:
				case Antlr4RoslynSyntaxKind.CHANNELS:
				case Antlr4RoslynSyntaxKind.IMPORT:
				case Antlr4RoslynSyntaxKind.FRAGMENT:
				case Antlr4RoslynSyntaxKind.LEXER:
				case Antlr4RoslynSyntaxKind.PARSER:
				case Antlr4RoslynSyntaxKind.GRAMMAR:
				case Antlr4RoslynSyntaxKind.PROTECTED:
				case Antlr4RoslynSyntaxKind.PUBLIC:
				case Antlr4RoslynSyntaxKind.PRIVATE:
				case Antlr4RoslynSyntaxKind.RETURNS:
				case Antlr4RoslynSyntaxKind.LOCALS:
				case Antlr4RoslynSyntaxKind.THROWS:
				case Antlr4RoslynSyntaxKind.CATCH:
				case Antlr4RoslynSyntaxKind.FINALLY:
				case Antlr4RoslynSyntaxKind.MODE:
				case Antlr4RoslynSyntaxKind.TRUE:
				case Antlr4RoslynSyntaxKind.FALSE:
				case Antlr4RoslynSyntaxKind.NULL:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((Antlr4RoslynSyntaxKind)rawKind);
		}

		public string GetText(Antlr4RoslynSyntaxKind kind)
		{
			switch (kind)
			{
				case Antlr4RoslynSyntaxKind.OPTIONS:
					return "options";
				case Antlr4RoslynSyntaxKind.TOKENS:
					return "tokens";
				case Antlr4RoslynSyntaxKind.CHANNELS:
					return "channels";
				case Antlr4RoslynSyntaxKind.IMPORT:
					return "import";
				case Antlr4RoslynSyntaxKind.FRAGMENT:
					return "fragment";
				case Antlr4RoslynSyntaxKind.LEXER:
					return "lexer";
				case Antlr4RoslynSyntaxKind.PARSER:
					return "parser";
				case Antlr4RoslynSyntaxKind.GRAMMAR:
					return "grammar";
				case Antlr4RoslynSyntaxKind.PROTECTED:
					return "protected";
				case Antlr4RoslynSyntaxKind.PUBLIC:
					return "public";
				case Antlr4RoslynSyntaxKind.PRIVATE:
					return "private";
				case Antlr4RoslynSyntaxKind.RETURNS:
					return "returns";
				case Antlr4RoslynSyntaxKind.LOCALS:
					return "locals";
				case Antlr4RoslynSyntaxKind.THROWS:
					return "throws";
				case Antlr4RoslynSyntaxKind.CATCH:
					return "catch";
				case Antlr4RoslynSyntaxKind.FINALLY:
					return "finally";
				case Antlr4RoslynSyntaxKind.MODE:
					return "mode";
				case Antlr4RoslynSyntaxKind.TRUE:
					return "true";
				case Antlr4RoslynSyntaxKind.FALSE:
					return "false";
				case Antlr4RoslynSyntaxKind.NULL:
					return "null";
				default:
					return string.Empty;
			}
		}

		public Antlr4RoslynSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case "options":
					return Antlr4RoslynSyntaxKind.OPTIONS;
				case "tokens":
					return Antlr4RoslynSyntaxKind.TOKENS;
				case "channels":
					return Antlr4RoslynSyntaxKind.CHANNELS;
				case "import":
					return Antlr4RoslynSyntaxKind.IMPORT;
				case "fragment":
					return Antlr4RoslynSyntaxKind.FRAGMENT;
				case "lexer":
					return Antlr4RoslynSyntaxKind.LEXER;
				case "parser":
					return Antlr4RoslynSyntaxKind.PARSER;
				case "grammar":
					return Antlr4RoslynSyntaxKind.GRAMMAR;
				case "protected":
					return Antlr4RoslynSyntaxKind.PROTECTED;
				case "public":
					return Antlr4RoslynSyntaxKind.PUBLIC;
				case "private":
					return Antlr4RoslynSyntaxKind.PRIVATE;
				case "returns":
					return Antlr4RoslynSyntaxKind.RETURNS;
				case "locals":
					return Antlr4RoslynSyntaxKind.LOCALS;
				case "throws":
					return Antlr4RoslynSyntaxKind.THROWS;
				case "catch":
					return Antlr4RoslynSyntaxKind.CATCH;
				case "finally":
					return Antlr4RoslynSyntaxKind.FINALLY;
				case "mode":
					return Antlr4RoslynSyntaxKind.MODE;
				case "true":
					return Antlr4RoslynSyntaxKind.TRUE;
				case "false":
					return Antlr4RoslynSyntaxKind.FALSE;
				case "null":
					return Antlr4RoslynSyntaxKind.NULL;
				default:
					return Antlr4RoslynSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((Antlr4RoslynSyntaxKind)rawKind);
		}

		public string GetKindText(Antlr4RoslynSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return false;
			}
		}

		public bool IsAntlr4Token(int rawKind)
		{
			return this.IsAntlr4Token((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsAntlr4Token(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.TOKEN_REF:
					return true;
				default:
					return false;
			}
		}
		public bool IsAntlr4Rule(int rawKind)
		{
			return this.IsAntlr4Rule((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsAntlr4Rule(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.RULE_REF:
					return true;
				default:
					return false;
			}
		}
		public bool IsOperator(int rawKind)
		{
			return this.IsOperator((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsOperator(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.LEXER_CHAR_SET:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsComment(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.LINE_COMMENT:
					return true;
				case Antlr4RoslynSyntaxKind.DOC_COMMENT:
					return true;
				case Antlr4RoslynSyntaxKind.BLOCK_COMMENT:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsNumber(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.INT:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(int rawKind)
		{
			return this.IsString((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsString(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.STRING_LITERAL:
					return true;
				case Antlr4RoslynSyntaxKind.UNTERMINATED_STRING_LITERAL:
					return true;
				default:
					return false;
			}
		}
		public bool IsAntlr4Action(int rawKind)
		{
			return this.IsAntlr4Action((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsAntlr4Action(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.BEGIN_ACTION:
					return true;
				default:
					return false;
			}
		}
		public bool IsAntlr4Options(int rawKind)
		{
			return this.IsAntlr4Options((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsAntlr4Options(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.OPTIONS:
					return true;
				case Antlr4RoslynSyntaxKind.TOKENS:
					return true;
				case Antlr4RoslynSyntaxKind.CHANNELS:
					return true;
				default:
					return false;
			}
		}
		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsKeyword(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.IMPORT:
				case Antlr4RoslynSyntaxKind.FRAGMENT:
				case Antlr4RoslynSyntaxKind.LEXER:
				case Antlr4RoslynSyntaxKind.PARSER:
				case Antlr4RoslynSyntaxKind.GRAMMAR:
				case Antlr4RoslynSyntaxKind.PROTECTED:
				case Antlr4RoslynSyntaxKind.PUBLIC:
				case Antlr4RoslynSyntaxKind.PRIVATE:
				case Antlr4RoslynSyntaxKind.RETURNS:
				case Antlr4RoslynSyntaxKind.LOCALS:
				case Antlr4RoslynSyntaxKind.THROWS:
				case Antlr4RoslynSyntaxKind.CATCH:
				case Antlr4RoslynSyntaxKind.FINALLY:
				case Antlr4RoslynSyntaxKind.MODE:
				case Antlr4RoslynSyntaxKind.TRUE:
				case Antlr4RoslynSyntaxKind.FALSE:
				case Antlr4RoslynSyntaxKind.NULL:
					return true;
				default:
					return false;
			}
		}
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsIdentifier(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.ID:
					return true;
				default:
					return false;
			}
		}
		public bool IsDocComment(int rawKind)
		{
			return this.IsDocComment((Antlr4RoslynSyntaxKind)rawKind);
		}

		public bool IsDocComment(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return false;
			}
		}

		public Antlr4RoslynTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((Antlr4RoslynSyntaxKind)rawKind);
		}

		public Antlr4RoslynTokenKind GetTokenKind(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				case Antlr4RoslynSyntaxKind.TOKEN_REF:
					return Antlr4RoslynTokenKind.Antlr4Token;
				case Antlr4RoslynSyntaxKind.RULE_REF:
					return Antlr4RoslynTokenKind.Antlr4Rule;
				case Antlr4RoslynSyntaxKind.LEXER_CHAR_SET:
					return Antlr4RoslynTokenKind.Operator;
				case Antlr4RoslynSyntaxKind.LINE_COMMENT:
					return Antlr4RoslynTokenKind.Comment;
				case Antlr4RoslynSyntaxKind.INT:
					return Antlr4RoslynTokenKind.Number;
				case Antlr4RoslynSyntaxKind.STRING_LITERAL:
					return Antlr4RoslynTokenKind.String;
				case Antlr4RoslynSyntaxKind.UNTERMINATED_STRING_LITERAL:
					return Antlr4RoslynTokenKind.String;
				case Antlr4RoslynSyntaxKind.BEGIN_ACTION:
					return Antlr4RoslynTokenKind.Antlr4Action;
				case Antlr4RoslynSyntaxKind.OPTIONS:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynSyntaxKind.TOKENS:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynSyntaxKind.CHANNELS:
					return Antlr4RoslynTokenKind.Antlr4Options;
				case Antlr4RoslynSyntaxKind.IMPORT:
				case Antlr4RoslynSyntaxKind.FRAGMENT:
				case Antlr4RoslynSyntaxKind.LEXER:
				case Antlr4RoslynSyntaxKind.PARSER:
				case Antlr4RoslynSyntaxKind.GRAMMAR:
				case Antlr4RoslynSyntaxKind.PROTECTED:
				case Antlr4RoslynSyntaxKind.PUBLIC:
				case Antlr4RoslynSyntaxKind.PRIVATE:
				case Antlr4RoslynSyntaxKind.RETURNS:
				case Antlr4RoslynSyntaxKind.LOCALS:
				case Antlr4RoslynSyntaxKind.THROWS:
				case Antlr4RoslynSyntaxKind.CATCH:
				case Antlr4RoslynSyntaxKind.FINALLY:
				case Antlr4RoslynSyntaxKind.MODE:
				case Antlr4RoslynSyntaxKind.TRUE:
				case Antlr4RoslynSyntaxKind.FALSE:
				case Antlr4RoslynSyntaxKind.NULL:
					return Antlr4RoslynTokenKind.Keyword;
				case Antlr4RoslynSyntaxKind.ID:
					return Antlr4RoslynTokenKind.Identifier;
				case Antlr4RoslynSyntaxKind.DOC_COMMENT:
					return Antlr4RoslynTokenKind.Comment;
				case Antlr4RoslynSyntaxKind.BLOCK_COMMENT:
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
	}
}


using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax
{
	public enum Antlr4RoslynTokenKind : int
	{
		None = 0,
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


		public Antlr4RoslynTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((Antlr4RoslynSyntaxKind)rawKind);
		}

		public Antlr4RoslynTokenKind GetTokenKind(Antlr4RoslynSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return Antlr4RoslynTokenKind.None;
			}
		}
	}
}


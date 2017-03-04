using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Languages.Calculator.Syntax
{
	public enum CalculatorTokenKind : int
	{
		None = 0,
	}

	public enum CalculatorLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0
	}

	public class CalculatorSyntaxFacts : SyntaxFacts
	{
		public static readonly CalculatorSyntaxFacts Instance = new CalculatorSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)CalculatorSyntaxKind.None; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)CalculatorSyntaxKind.None; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((CalculatorSyntaxKind)rawKind);
		}

		public bool IsToken(CalculatorSyntaxKind kind)
		{
			switch (kind)
			{
				case CalculatorSyntaxKind.Eof:
				case CalculatorSyntaxKind.TSemicolon:
				case CalculatorSyntaxKind.TOpenParen:
				case CalculatorSyntaxKind.TCloseParen:
				case CalculatorSyntaxKind.TComma:
				case CalculatorSyntaxKind.TAssign:
				case CalculatorSyntaxKind.TAdd:
				case CalculatorSyntaxKind.TSub:
				case CalculatorSyntaxKind.TMul:
				case CalculatorSyntaxKind.TDiv:
				case CalculatorSyntaxKind.KPrint:
				case CalculatorSyntaxKind.LString:
				case CalculatorSyntaxKind.LId:
				case CalculatorSyntaxKind.LInt:
				case CalculatorSyntaxKind.LUtf8Bom:
				case CalculatorSyntaxKind.LWhitespace:
				case CalculatorSyntaxKind.LEndl:
				case CalculatorSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((CalculatorSyntaxKind)rawKind);
		}

		public bool IsFixedToken(CalculatorSyntaxKind kind)
		{
			switch (kind)
			{
				case CalculatorSyntaxKind.Eof:
				case CalculatorSyntaxKind.TSemicolon:
				case CalculatorSyntaxKind.TOpenParen:
				case CalculatorSyntaxKind.TCloseParen:
				case CalculatorSyntaxKind.TComma:
				case CalculatorSyntaxKind.TAssign:
				case CalculatorSyntaxKind.TAdd:
				case CalculatorSyntaxKind.TSub:
				case CalculatorSyntaxKind.TMul:
				case CalculatorSyntaxKind.TDiv:
				case CalculatorSyntaxKind.KPrint:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((CalculatorSyntaxKind)rawKind);
		}

		public string GetText(CalculatorSyntaxKind kind)
		{
			switch (kind)
			{
				case CalculatorSyntaxKind.TSemicolon:
					return ";";
				case CalculatorSyntaxKind.TOpenParen:
					return "(";
				case CalculatorSyntaxKind.TCloseParen:
					return ")";
				case CalculatorSyntaxKind.TComma:
					return ",";
				case CalculatorSyntaxKind.TAssign:
					return "=";
				case CalculatorSyntaxKind.TAdd:
					return "+";
				case CalculatorSyntaxKind.TSub:
					return "-";
				case CalculatorSyntaxKind.TMul:
					return "*";
				case CalculatorSyntaxKind.TDiv:
					return "/";
				case CalculatorSyntaxKind.KPrint:
					return "print";
				default:
					return string.Empty;
			}
		}

		public CalculatorSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case ";":
					return CalculatorSyntaxKind.TSemicolon;
				case "(":
					return CalculatorSyntaxKind.TOpenParen;
				case ")":
					return CalculatorSyntaxKind.TCloseParen;
				case ",":
					return CalculatorSyntaxKind.TComma;
				case "=":
					return CalculatorSyntaxKind.TAssign;
				case "+":
					return CalculatorSyntaxKind.TAdd;
				case "-":
					return CalculatorSyntaxKind.TSub;
				case "*":
					return CalculatorSyntaxKind.TMul;
				case "/":
					return CalculatorSyntaxKind.TDiv;
				case "print":
					return CalculatorSyntaxKind.KPrint;
				default:
					return CalculatorSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((CalculatorSyntaxKind)rawKind);
		}

		public string GetKindText(CalculatorSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((CalculatorSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(CalculatorSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return false;
			}
		}


		public CalculatorTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((CalculatorSyntaxKind)rawKind);
		}

		public CalculatorTokenKind GetTokenKind(CalculatorSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return CalculatorTokenKind.None;
			}
		}

		public CalculatorTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((CalculatorLexerMode)rawKind);
		}

		public CalculatorTokenKind GetModeTokenKind(CalculatorLexerMode kind)
		{
			switch(kind)
			{
				default:
					return CalculatorTokenKind.None;
			}
		}
	}
}


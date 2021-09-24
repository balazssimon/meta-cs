// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Compiler.Syntax
{
	public enum CompilerTokenKind : int
	{
		None = 0,
		ContextualKeyword,
		DocumentationCommentTrivia,
		ExternAliasDirective,
		FixedToken,
		GeneralComment,
		GeneralCommentTrivia,
		Identifier,
		Number,
		PreprocessorContextualKeyword,
		PreprocessorDirective,
		PreprocessorKeyword,
		ReservedKeyword,
		String,
		Token,
		Trivia,
		Whitespace
	}

	public enum CompilerLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0
	}

	public class CompilerTokensSyntaxFacts : SyntaxFacts
	{
        public CompilerTokensSyntaxFacts() 
            : base(typeof(CompilerTokensSyntaxKind))
        {
        }

        protected CompilerTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (CompilerTokensSyntaxKind)CompilerTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (CompilerTokensSyntaxKind)CompilerTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (CompilerTokensSyntaxKind)CompilerTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (CompilerTokensSyntaxKind)CompilerTokensSyntaxKind.LexerIdentifier;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case CompilerTokensSyntaxKind.Eof:
				case CompilerTokensSyntaxKind.KNamespace:
				case CompilerTokensSyntaxKind.KGrammar:
				case CompilerTokensSyntaxKind.KOptions:
				case CompilerTokensSyntaxKind.KFragment:
				case CompilerTokensSyntaxKind.KHidden:
				case CompilerTokensSyntaxKind.KTrue:
				case CompilerTokensSyntaxKind.KFalse:
				case CompilerTokensSyntaxKind.KNull:
				case CompilerTokensSyntaxKind.KEof:
				case CompilerTokensSyntaxKind.TSemicolon:
				case CompilerTokensSyntaxKind.TArrow:
				case CompilerTokensSyntaxKind.TDot:
				case CompilerTokensSyntaxKind.TNonGreedyZeroOrOne:
				case CompilerTokensSyntaxKind.TNonGreedyZeroOrMore:
				case CompilerTokensSyntaxKind.TNonGreedyOneOrMore:
				case CompilerTokensSyntaxKind.TZeroOrOne:
				case CompilerTokensSyntaxKind.TZeroOrMore:
				case CompilerTokensSyntaxKind.TOneOrMore:
				case CompilerTokensSyntaxKind.TNegate:
				case CompilerTokensSyntaxKind.TAssign:
				case CompilerTokensSyntaxKind.TQuestionAssign:
				case CompilerTokensSyntaxKind.TNegatedAssign:
				case CompilerTokensSyntaxKind.TPlusAssign:
				case CompilerTokensSyntaxKind.TBar:
				case CompilerTokensSyntaxKind.TAmpersand:
				case CompilerTokensSyntaxKind.TColon:
				case CompilerTokensSyntaxKind.TComma:
				case CompilerTokensSyntaxKind.TOpenParen:
				case CompilerTokensSyntaxKind.TCloseParen:
				case CompilerTokensSyntaxKind.TOpenBracket:
				case CompilerTokensSyntaxKind.TCloseBracket:
				case CompilerTokensSyntaxKind.TOpenBrace:
				case CompilerTokensSyntaxKind.TCloseBrace:
				case CompilerTokensSyntaxKind.TLessThan:
				case CompilerTokensSyntaxKind.TGreaterThan:
				case CompilerTokensSyntaxKind.LexerIdentifier:
				case CompilerTokensSyntaxKind.ParserIdentifier:
				case CompilerTokensSyntaxKind.LInteger:
				case CompilerTokensSyntaxKind.LDecimal:
				case CompilerTokensSyntaxKind.LScientific:
				case CompilerTokensSyntaxKind.LString:
				case CompilerTokensSyntaxKind.LUtf8Bom:
				case CompilerTokensSyntaxKind.LWhiteSpace:
				case CompilerTokensSyntaxKind.LCrLf:
				case CompilerTokensSyntaxKind.LLineEnd:
				case CompilerTokensSyntaxKind.LSingleLineComment:
				case CompilerTokensSyntaxKind.LMultilineComment:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case CompilerTokensSyntaxKind.KNamespace:
				case CompilerTokensSyntaxKind.KGrammar:
				case CompilerTokensSyntaxKind.KOptions:
				case CompilerTokensSyntaxKind.KFragment:
				case CompilerTokensSyntaxKind.KHidden:
				case CompilerTokensSyntaxKind.KTrue:
				case CompilerTokensSyntaxKind.KFalse:
				case CompilerTokensSyntaxKind.KNull:
				case CompilerTokensSyntaxKind.KEof:
				case CompilerTokensSyntaxKind.TSemicolon:
				case CompilerTokensSyntaxKind.TArrow:
				case CompilerTokensSyntaxKind.TDot:
				case CompilerTokensSyntaxKind.TNonGreedyZeroOrOne:
				case CompilerTokensSyntaxKind.TNonGreedyZeroOrMore:
				case CompilerTokensSyntaxKind.TNonGreedyOneOrMore:
				case CompilerTokensSyntaxKind.TZeroOrOne:
				case CompilerTokensSyntaxKind.TZeroOrMore:
				case CompilerTokensSyntaxKind.TOneOrMore:
				case CompilerTokensSyntaxKind.TNegate:
				case CompilerTokensSyntaxKind.TAssign:
				case CompilerTokensSyntaxKind.TQuestionAssign:
				case CompilerTokensSyntaxKind.TNegatedAssign:
				case CompilerTokensSyntaxKind.TPlusAssign:
				case CompilerTokensSyntaxKind.TBar:
				case CompilerTokensSyntaxKind.TAmpersand:
				case CompilerTokensSyntaxKind.TColon:
				case CompilerTokensSyntaxKind.TComma:
				case CompilerTokensSyntaxKind.TOpenParen:
				case CompilerTokensSyntaxKind.TCloseParen:
				case CompilerTokensSyntaxKind.TOpenBracket:
				case CompilerTokensSyntaxKind.TCloseBracket:
				case CompilerTokensSyntaxKind.TOpenBrace:
				case CompilerTokensSyntaxKind.TCloseBrace:
				case CompilerTokensSyntaxKind.TLessThan:
				case CompilerTokensSyntaxKind.TGreaterThan:
					return true;
				default:
					return false;
			}
		}

		public override SyntaxKind GetFixedTokenKind(string text)
		{
			switch (text)
			{
				case "namespace":
					return CompilerTokensSyntaxKind.KNamespace;
				case "grammar":
					return CompilerTokensSyntaxKind.KGrammar;
				case "options":
					return CompilerTokensSyntaxKind.KOptions;
				case "fragment":
					return CompilerTokensSyntaxKind.KFragment;
				case "hidden":
					return CompilerTokensSyntaxKind.KHidden;
				case "true":
					return CompilerTokensSyntaxKind.KTrue;
				case "false":
					return CompilerTokensSyntaxKind.KFalse;
				case "null":
					return CompilerTokensSyntaxKind.KNull;
				case "EOF":
					return CompilerTokensSyntaxKind.KEof;
				case ";":
					return CompilerTokensSyntaxKind.TSemicolon;
				case "->":
					return CompilerTokensSyntaxKind.TArrow;
				case ".":
					return CompilerTokensSyntaxKind.TDot;
				case "??":
					return CompilerTokensSyntaxKind.TNonGreedyZeroOrOne;
				case "*?":
					return CompilerTokensSyntaxKind.TNonGreedyZeroOrMore;
				case "+?":
					return CompilerTokensSyntaxKind.TNonGreedyOneOrMore;
				case "?":
					return CompilerTokensSyntaxKind.TZeroOrOne;
				case "*":
					return CompilerTokensSyntaxKind.TZeroOrMore;
				case "+":
					return CompilerTokensSyntaxKind.TOneOrMore;
				case "~":
					return CompilerTokensSyntaxKind.TNegate;
				case "=":
					return CompilerTokensSyntaxKind.TAssign;
				case "?=":
					return CompilerTokensSyntaxKind.TQuestionAssign;
				case "!=":
					return CompilerTokensSyntaxKind.TNegatedAssign;
				case "+=":
					return CompilerTokensSyntaxKind.TPlusAssign;
				case "|":
					return CompilerTokensSyntaxKind.TBar;
				case "&":
					return CompilerTokensSyntaxKind.TAmpersand;
				case ":":
					return CompilerTokensSyntaxKind.TColon;
				case ",":
					return CompilerTokensSyntaxKind.TComma;
				case "(":
					return CompilerTokensSyntaxKind.TOpenParen;
				case ")":
					return CompilerTokensSyntaxKind.TCloseParen;
				case "[":
					return CompilerTokensSyntaxKind.TOpenBracket;
				case "]":
					return CompilerTokensSyntaxKind.TCloseBracket;
				case "{":
					return CompilerTokensSyntaxKind.TOpenBrace;
				case "}":
					return CompilerTokensSyntaxKind.TCloseBrace;
				case "<":
					return CompilerTokensSyntaxKind.TLessThan;
				case ">":
					return CompilerTokensSyntaxKind.TGreaterThan;
				default:
					return CompilerTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case CompilerTokensSyntaxKind.KNamespace:
					return "namespace";
				case CompilerTokensSyntaxKind.KGrammar:
					return "grammar";
				case CompilerTokensSyntaxKind.KOptions:
					return "options";
				case CompilerTokensSyntaxKind.KFragment:
					return "fragment";
				case CompilerTokensSyntaxKind.KHidden:
					return "hidden";
				case CompilerTokensSyntaxKind.KTrue:
					return "true";
				case CompilerTokensSyntaxKind.KFalse:
					return "false";
				case CompilerTokensSyntaxKind.KNull:
					return "null";
				case CompilerTokensSyntaxKind.KEof:
					return "EOF";
				case CompilerTokensSyntaxKind.TSemicolon:
					return ";";
				case CompilerTokensSyntaxKind.TArrow:
					return "->";
				case CompilerTokensSyntaxKind.TDot:
					return ".";
				case CompilerTokensSyntaxKind.TNonGreedyZeroOrOne:
					return "??";
				case CompilerTokensSyntaxKind.TNonGreedyZeroOrMore:
					return "*?";
				case CompilerTokensSyntaxKind.TNonGreedyOneOrMore:
					return "+?";
				case CompilerTokensSyntaxKind.TZeroOrOne:
					return "?";
				case CompilerTokensSyntaxKind.TZeroOrMore:
					return "*";
				case CompilerTokensSyntaxKind.TOneOrMore:
					return "+";
				case CompilerTokensSyntaxKind.TNegate:
					return "~";
				case CompilerTokensSyntaxKind.TAssign:
					return "=";
				case CompilerTokensSyntaxKind.TQuestionAssign:
					return "?=";
				case CompilerTokensSyntaxKind.TNegatedAssign:
					return "!=";
				case CompilerTokensSyntaxKind.TPlusAssign:
					return "+=";
				case CompilerTokensSyntaxKind.TBar:
					return "|";
				case CompilerTokensSyntaxKind.TAmpersand:
					return "&";
				case CompilerTokensSyntaxKind.TColon:
					return ":";
				case CompilerTokensSyntaxKind.TComma:
					return ",";
				case CompilerTokensSyntaxKind.TOpenParen:
					return "(";
				case CompilerTokensSyntaxKind.TCloseParen:
					return ")";
				case CompilerTokensSyntaxKind.TOpenBracket:
					return "[";
				case CompilerTokensSyntaxKind.TCloseBracket:
					return "]";
				case CompilerTokensSyntaxKind.TOpenBrace:
					return "{";
				case CompilerTokensSyntaxKind.TCloseBrace:
					return "}";
				case CompilerTokensSyntaxKind.TLessThan:
					return "<";
				case CompilerTokensSyntaxKind.TGreaterThan:
					return ">";
				default:
					return string.Empty;
			}
		}

		public CompilerTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<CompilerTokensSyntaxKind>(rawKind));
		}

		public CompilerTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CompilerTokensSyntaxKind.KNamespace:
				case CompilerTokensSyntaxKind.KGrammar:
				case CompilerTokensSyntaxKind.KOptions:
				case CompilerTokensSyntaxKind.KFragment:
				case CompilerTokensSyntaxKind.KHidden:
				case CompilerTokensSyntaxKind.KTrue:
				case CompilerTokensSyntaxKind.KFalse:
				case CompilerTokensSyntaxKind.KNull:
				case CompilerTokensSyntaxKind.KEof:
					return CompilerTokenKind.ReservedKeyword;
				case CompilerTokensSyntaxKind.LexerIdentifier:
					return CompilerTokenKind.Identifier;
				case CompilerTokensSyntaxKind.ParserIdentifier:
					return CompilerTokenKind.Identifier;
				case CompilerTokensSyntaxKind.LInteger:
					return CompilerTokenKind.Number;
				case CompilerTokensSyntaxKind.LDecimal:
					return CompilerTokenKind.Number;
				case CompilerTokensSyntaxKind.LScientific:
					return CompilerTokenKind.Number;
				case CompilerTokensSyntaxKind.LString:
					return CompilerTokenKind.String;
				case CompilerTokensSyntaxKind.LUtf8Bom:
					return CompilerTokenKind.Whitespace;
				case CompilerTokensSyntaxKind.LWhiteSpace:
					return CompilerTokenKind.Whitespace;
				case CompilerTokensSyntaxKind.LCrLf:
					return CompilerTokenKind.Whitespace;
				case CompilerTokensSyntaxKind.LLineEnd:
					return CompilerTokenKind.Whitespace;
				case CompilerTokensSyntaxKind.LSingleLineComment:
					return CompilerTokenKind.GeneralComment;
				case CompilerTokensSyntaxKind.LMultilineComment:
					return CompilerTokenKind.GeneralComment;
				default:
					return CompilerTokenKind.None;
			}
		}

		public CompilerTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((CompilerLexerMode)rawKind);
		}

		public CompilerTokenKind GetModeTokenKind(CompilerLexerMode kind)
		{
			switch(kind)
			{
				default:
					return CompilerTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CompilerTokensSyntaxKind.LCrLf:
					return true;
				case CompilerTokensSyntaxKind.LLineEnd:
					return true;
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
				case CompilerTokensSyntaxKind.KNamespace:
				case CompilerTokensSyntaxKind.KGrammar:
				case CompilerTokensSyntaxKind.KOptions:
				case CompilerTokensSyntaxKind.KFragment:
				case CompilerTokensSyntaxKind.KHidden:
				case CompilerTokensSyntaxKind.KTrue:
				case CompilerTokensSyntaxKind.KFalse:
				case CompilerTokensSyntaxKind.KNull:
				case CompilerTokensSyntaxKind.KEof:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return CompilerTokensSyntaxKind.KNamespace;
				yield return CompilerTokensSyntaxKind.KGrammar;
				yield return CompilerTokensSyntaxKind.KOptions;
				yield return CompilerTokensSyntaxKind.KFragment;
				yield return CompilerTokensSyntaxKind.KHidden;
				yield return CompilerTokensSyntaxKind.KTrue;
				yield return CompilerTokensSyntaxKind.KFalse;
				yield return CompilerTokensSyntaxKind.KNull;
				yield return CompilerTokensSyntaxKind.KEof;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return CompilerTokensSyntaxKind.KNamespace;
				case "grammar":
					return CompilerTokensSyntaxKind.KGrammar;
				case "options":
					return CompilerTokensSyntaxKind.KOptions;
				case "fragment":
					return CompilerTokensSyntaxKind.KFragment;
				case "hidden":
					return CompilerTokensSyntaxKind.KHidden;
				case "true":
					return CompilerTokensSyntaxKind.KTrue;
				case "false":
					return CompilerTokensSyntaxKind.KFalse;
				case "null":
					return CompilerTokensSyntaxKind.KNull;
				case "EOF":
					return CompilerTokensSyntaxKind.KEof;
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
				case CompilerTokensSyntaxKind.LexerIdentifier:
					return true;
				case CompilerTokensSyntaxKind.ParserIdentifier:
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
		public bool IsNumber(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CompilerTokensSyntaxKind.LInteger:
					return true;
				case CompilerTokensSyntaxKind.LDecimal:
					return true;
				case CompilerTokensSyntaxKind.LScientific:
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
		public bool IsString(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CompilerTokensSyntaxKind.LString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CompilerTokensSyntaxKind.LUtf8Bom:
					return true;
				case CompilerTokensSyntaxKind.LWhiteSpace:
					return true;
				case CompilerTokensSyntaxKind.LCrLf:
					return true;
				case CompilerTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CompilerTokensSyntaxKind.LSingleLineComment:
					return true;
				case CompilerTokensSyntaxKind.LMultilineComment:
					return true;
				default:
					return false;
			}
		}
	}
}


// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax
{
	public enum TestLangOneTokenKind : int
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

	public enum TestLangOneLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class TestLangOneTokensSyntaxFacts : SyntaxFacts
	{
        public TestLangOneTokensSyntaxFacts() 
            : base(typeof(TestLangOneTokensSyntaxKind))
        {
        }

        protected TestLangOneTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (TestLangOneTokensSyntaxKind)TestLangOneTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (TestLangOneTokensSyntaxKind)TestLangOneTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (TestLangOneTokensSyntaxKind)TestLangOneTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (TestLangOneTokensSyntaxKind)TestLangOneTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.Eof:
				case TestLangOneTokensSyntaxKind.KNamespace:
				case TestLangOneTokensSyntaxKind.KScope:
				case TestLangOneTokensSyntaxKind.KMember:
				case TestLangOneTokensSyntaxKind.KClass:
				case TestLangOneTokensSyntaxKind.KVertex:
				case TestLangOneTokensSyntaxKind.KOptional:
				case TestLangOneTokensSyntaxKind.KArrow:
				case TestLangOneTokensSyntaxKind.KStatic:
				case TestLangOneTokensSyntaxKind.KTrue:
				case TestLangOneTokensSyntaxKind.KFalse:
				case TestLangOneTokensSyntaxKind.KNull:
				case TestLangOneTokensSyntaxKind.TSemicolon:
				case TestLangOneTokensSyntaxKind.TColon:
				case TestLangOneTokensSyntaxKind.TDot:
				case TestLangOneTokensSyntaxKind.TComma:
				case TestLangOneTokensSyntaxKind.TAssign:
				case TestLangOneTokensSyntaxKind.TOpenParen:
				case TestLangOneTokensSyntaxKind.TCloseParen:
				case TestLangOneTokensSyntaxKind.TOpenBracket:
				case TestLangOneTokensSyntaxKind.TCloseBracket:
				case TestLangOneTokensSyntaxKind.TOpenBrace:
				case TestLangOneTokensSyntaxKind.TCloseBrace:
				case TestLangOneTokensSyntaxKind.TLessThan:
				case TestLangOneTokensSyntaxKind.TGreaterThan:
				case TestLangOneTokensSyntaxKind.TQuestion:
				case TestLangOneTokensSyntaxKind.TQuestionQuestion:
				case TestLangOneTokensSyntaxKind.TAmpersand:
				case TestLangOneTokensSyntaxKind.THat:
				case TestLangOneTokensSyntaxKind.TBar:
				case TestLangOneTokensSyntaxKind.TAndAlso:
				case TestLangOneTokensSyntaxKind.TOrElse:
				case TestLangOneTokensSyntaxKind.TPlusPlus:
				case TestLangOneTokensSyntaxKind.TMinusMinus:
				case TestLangOneTokensSyntaxKind.TPlus:
				case TestLangOneTokensSyntaxKind.TMinus:
				case TestLangOneTokensSyntaxKind.TTilde:
				case TestLangOneTokensSyntaxKind.TExclamation:
				case TestLangOneTokensSyntaxKind.TSlash:
				case TestLangOneTokensSyntaxKind.TAsterisk:
				case TestLangOneTokensSyntaxKind.TPercent:
				case TestLangOneTokensSyntaxKind.TLessThanOrEqual:
				case TestLangOneTokensSyntaxKind.TGreaterThanOrEqual:
				case TestLangOneTokensSyntaxKind.TEqual:
				case TestLangOneTokensSyntaxKind.TNotEqual:
				case TestLangOneTokensSyntaxKind.TAsteriskAssign:
				case TestLangOneTokensSyntaxKind.TSlashAssign:
				case TestLangOneTokensSyntaxKind.TPercentAssign:
				case TestLangOneTokensSyntaxKind.TPlusAssign:
				case TestLangOneTokensSyntaxKind.TMinusAssign:
				case TestLangOneTokensSyntaxKind.TLeftShiftAssign:
				case TestLangOneTokensSyntaxKind.TRightShiftAssign:
				case TestLangOneTokensSyntaxKind.TAmpersandAssign:
				case TestLangOneTokensSyntaxKind.THatAssign:
				case TestLangOneTokensSyntaxKind.TBarAssign:
				case TestLangOneTokensSyntaxKind.TArrow:
				case TestLangOneTokensSyntaxKind.IUri:
				case TestLangOneTokensSyntaxKind.IdentifierNormal:
				case TestLangOneTokensSyntaxKind.IdentifierVerbatim:
				case TestLangOneTokensSyntaxKind.LInteger:
				case TestLangOneTokensSyntaxKind.LDecimal:
				case TestLangOneTokensSyntaxKind.LScientific:
				case TestLangOneTokensSyntaxKind.LDateTimeOffset:
				case TestLangOneTokensSyntaxKind.LDateTime:
				case TestLangOneTokensSyntaxKind.LDate:
				case TestLangOneTokensSyntaxKind.LTime:
				case TestLangOneTokensSyntaxKind.LRegularString:
				case TestLangOneTokensSyntaxKind.LGuid:
				case TestLangOneTokensSyntaxKind.LUtf8Bom:
				case TestLangOneTokensSyntaxKind.LWhiteSpace:
				case TestLangOneTokensSyntaxKind.LCrLf:
				case TestLangOneTokensSyntaxKind.LLineEnd:
				case TestLangOneTokensSyntaxKind.LSingleLineComment:
				case TestLangOneTokensSyntaxKind.LComment:
				case TestLangOneTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestLangOneTokensSyntaxKind.LSingleQuoteVerbatimString:
				case TestLangOneTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestLangOneTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case TestLangOneTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.KNamespace:
				case TestLangOneTokensSyntaxKind.KScope:
				case TestLangOneTokensSyntaxKind.KMember:
				case TestLangOneTokensSyntaxKind.KClass:
				case TestLangOneTokensSyntaxKind.KVertex:
				case TestLangOneTokensSyntaxKind.KOptional:
				case TestLangOneTokensSyntaxKind.KArrow:
				case TestLangOneTokensSyntaxKind.KStatic:
				case TestLangOneTokensSyntaxKind.KTrue:
				case TestLangOneTokensSyntaxKind.KFalse:
				case TestLangOneTokensSyntaxKind.KNull:
				case TestLangOneTokensSyntaxKind.TSemicolon:
				case TestLangOneTokensSyntaxKind.TColon:
				case TestLangOneTokensSyntaxKind.TDot:
				case TestLangOneTokensSyntaxKind.TComma:
				case TestLangOneTokensSyntaxKind.TAssign:
				case TestLangOneTokensSyntaxKind.TOpenParen:
				case TestLangOneTokensSyntaxKind.TCloseParen:
				case TestLangOneTokensSyntaxKind.TOpenBracket:
				case TestLangOneTokensSyntaxKind.TCloseBracket:
				case TestLangOneTokensSyntaxKind.TOpenBrace:
				case TestLangOneTokensSyntaxKind.TCloseBrace:
				case TestLangOneTokensSyntaxKind.TLessThan:
				case TestLangOneTokensSyntaxKind.TGreaterThan:
				case TestLangOneTokensSyntaxKind.TQuestion:
				case TestLangOneTokensSyntaxKind.TQuestionQuestion:
				case TestLangOneTokensSyntaxKind.TAmpersand:
				case TestLangOneTokensSyntaxKind.THat:
				case TestLangOneTokensSyntaxKind.TBar:
				case TestLangOneTokensSyntaxKind.TAndAlso:
				case TestLangOneTokensSyntaxKind.TOrElse:
				case TestLangOneTokensSyntaxKind.TPlusPlus:
				case TestLangOneTokensSyntaxKind.TMinusMinus:
				case TestLangOneTokensSyntaxKind.TPlus:
				case TestLangOneTokensSyntaxKind.TMinus:
				case TestLangOneTokensSyntaxKind.TTilde:
				case TestLangOneTokensSyntaxKind.TExclamation:
				case TestLangOneTokensSyntaxKind.TSlash:
				case TestLangOneTokensSyntaxKind.TPercent:
				case TestLangOneTokensSyntaxKind.TLessThanOrEqual:
				case TestLangOneTokensSyntaxKind.TGreaterThanOrEqual:
				case TestLangOneTokensSyntaxKind.TEqual:
				case TestLangOneTokensSyntaxKind.TNotEqual:
				case TestLangOneTokensSyntaxKind.TAsteriskAssign:
				case TestLangOneTokensSyntaxKind.TSlashAssign:
				case TestLangOneTokensSyntaxKind.TPercentAssign:
				case TestLangOneTokensSyntaxKind.TPlusAssign:
				case TestLangOneTokensSyntaxKind.TMinusAssign:
				case TestLangOneTokensSyntaxKind.TLeftShiftAssign:
				case TestLangOneTokensSyntaxKind.TRightShiftAssign:
				case TestLangOneTokensSyntaxKind.TAmpersandAssign:
				case TestLangOneTokensSyntaxKind.THatAssign:
				case TestLangOneTokensSyntaxKind.TBarAssign:
				case TestLangOneTokensSyntaxKind.TArrow:
				case TestLangOneTokensSyntaxKind.IUri:
				case TestLangOneTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestLangOneTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case TestLangOneTokensSyntaxKind.LCommentStart:
				case TestLangOneTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestLangOneTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return TestLangOneTokensSyntaxKind.KNamespace;
				case "scope":
					return TestLangOneTokensSyntaxKind.KScope;
				case "member":
					return TestLangOneTokensSyntaxKind.KMember;
				case "class":
					return TestLangOneTokensSyntaxKind.KClass;
				case "vertex":
					return TestLangOneTokensSyntaxKind.KVertex;
				case "optional":
					return TestLangOneTokensSyntaxKind.KOptional;
				case "arrow":
					return TestLangOneTokensSyntaxKind.KArrow;
				case "static":
					return TestLangOneTokensSyntaxKind.KStatic;
				case "true":
					return TestLangOneTokensSyntaxKind.KTrue;
				case "false":
					return TestLangOneTokensSyntaxKind.KFalse;
				case "null":
					return TestLangOneTokensSyntaxKind.KNull;
				case ";":
					return TestLangOneTokensSyntaxKind.TSemicolon;
				case ":":
					return TestLangOneTokensSyntaxKind.TColon;
				case ".":
					return TestLangOneTokensSyntaxKind.TDot;
				case ",":
					return TestLangOneTokensSyntaxKind.TComma;
				case "=":
					return TestLangOneTokensSyntaxKind.TAssign;
				case "(":
					return TestLangOneTokensSyntaxKind.TOpenParen;
				case ")":
					return TestLangOneTokensSyntaxKind.TCloseParen;
				case "[":
					return TestLangOneTokensSyntaxKind.TOpenBracket;
				case "]":
					return TestLangOneTokensSyntaxKind.TCloseBracket;
				case "{":
					return TestLangOneTokensSyntaxKind.TOpenBrace;
				case "}":
					return TestLangOneTokensSyntaxKind.TCloseBrace;
				case "<":
					return TestLangOneTokensSyntaxKind.TLessThan;
				case ">":
					return TestLangOneTokensSyntaxKind.TGreaterThan;
				case "?":
					return TestLangOneTokensSyntaxKind.TQuestion;
				case "??":
					return TestLangOneTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return TestLangOneTokensSyntaxKind.TAmpersand;
				case "^":
					return TestLangOneTokensSyntaxKind.THat;
				case "|":
					return TestLangOneTokensSyntaxKind.TBar;
				case "&&":
					return TestLangOneTokensSyntaxKind.TAndAlso;
				case "||":
					return TestLangOneTokensSyntaxKind.TOrElse;
				case "++":
					return TestLangOneTokensSyntaxKind.TPlusPlus;
				case "--":
					return TestLangOneTokensSyntaxKind.TMinusMinus;
				case "+":
					return TestLangOneTokensSyntaxKind.TPlus;
				case "-":
					return TestLangOneTokensSyntaxKind.TMinus;
				case "~":
					return TestLangOneTokensSyntaxKind.TTilde;
				case "!":
					return TestLangOneTokensSyntaxKind.TExclamation;
				case "/":
					return TestLangOneTokensSyntaxKind.TSlash;
				case "%":
					return TestLangOneTokensSyntaxKind.TPercent;
				case "<=":
					return TestLangOneTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return TestLangOneTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return TestLangOneTokensSyntaxKind.TEqual;
				case "!=":
					return TestLangOneTokensSyntaxKind.TNotEqual;
				case "*=":
					return TestLangOneTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return TestLangOneTokensSyntaxKind.TSlashAssign;
				case "%=":
					return TestLangOneTokensSyntaxKind.TPercentAssign;
				case "+=":
					return TestLangOneTokensSyntaxKind.TPlusAssign;
				case "-=":
					return TestLangOneTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return TestLangOneTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return TestLangOneTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return TestLangOneTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return TestLangOneTokensSyntaxKind.THatAssign;
				case "|=":
					return TestLangOneTokensSyntaxKind.TBarAssign;
				case "->":
					return TestLangOneTokensSyntaxKind.TArrow;
				case "Uri":
					return TestLangOneTokensSyntaxKind.IUri;
				case "@\"":
					return TestLangOneTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return TestLangOneTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return TestLangOneTokensSyntaxKind.LCommentStart;
				case "\"":
					return TestLangOneTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return TestLangOneTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return TestLangOneTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.KNamespace:
					return "namespace";
				case TestLangOneTokensSyntaxKind.KScope:
					return "scope";
				case TestLangOneTokensSyntaxKind.KMember:
					return "member";
				case TestLangOneTokensSyntaxKind.KClass:
					return "class";
				case TestLangOneTokensSyntaxKind.KVertex:
					return "vertex";
				case TestLangOneTokensSyntaxKind.KOptional:
					return "optional";
				case TestLangOneTokensSyntaxKind.KArrow:
					return "arrow";
				case TestLangOneTokensSyntaxKind.KStatic:
					return "static";
				case TestLangOneTokensSyntaxKind.KTrue:
					return "true";
				case TestLangOneTokensSyntaxKind.KFalse:
					return "false";
				case TestLangOneTokensSyntaxKind.KNull:
					return "null";
				case TestLangOneTokensSyntaxKind.TSemicolon:
					return ";";
				case TestLangOneTokensSyntaxKind.TColon:
					return ":";
				case TestLangOneTokensSyntaxKind.TDot:
					return ".";
				case TestLangOneTokensSyntaxKind.TComma:
					return ",";
				case TestLangOneTokensSyntaxKind.TAssign:
					return "=";
				case TestLangOneTokensSyntaxKind.TOpenParen:
					return "(";
				case TestLangOneTokensSyntaxKind.TCloseParen:
					return ")";
				case TestLangOneTokensSyntaxKind.TOpenBracket:
					return "[";
				case TestLangOneTokensSyntaxKind.TCloseBracket:
					return "]";
				case TestLangOneTokensSyntaxKind.TOpenBrace:
					return "{";
				case TestLangOneTokensSyntaxKind.TCloseBrace:
					return "}";
				case TestLangOneTokensSyntaxKind.TLessThan:
					return "<";
				case TestLangOneTokensSyntaxKind.TGreaterThan:
					return ">";
				case TestLangOneTokensSyntaxKind.TQuestion:
					return "?";
				case TestLangOneTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case TestLangOneTokensSyntaxKind.TAmpersand:
					return "&";
				case TestLangOneTokensSyntaxKind.THat:
					return "^";
				case TestLangOneTokensSyntaxKind.TBar:
					return "|";
				case TestLangOneTokensSyntaxKind.TAndAlso:
					return "&&";
				case TestLangOneTokensSyntaxKind.TOrElse:
					return "||";
				case TestLangOneTokensSyntaxKind.TPlusPlus:
					return "++";
				case TestLangOneTokensSyntaxKind.TMinusMinus:
					return "--";
				case TestLangOneTokensSyntaxKind.TPlus:
					return "+";
				case TestLangOneTokensSyntaxKind.TMinus:
					return "-";
				case TestLangOneTokensSyntaxKind.TTilde:
					return "~";
				case TestLangOneTokensSyntaxKind.TExclamation:
					return "!";
				case TestLangOneTokensSyntaxKind.TSlash:
					return "/";
				case TestLangOneTokensSyntaxKind.TPercent:
					return "%";
				case TestLangOneTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case TestLangOneTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case TestLangOneTokensSyntaxKind.TEqual:
					return "==";
				case TestLangOneTokensSyntaxKind.TNotEqual:
					return "!=";
				case TestLangOneTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case TestLangOneTokensSyntaxKind.TSlashAssign:
					return "/=";
				case TestLangOneTokensSyntaxKind.TPercentAssign:
					return "%=";
				case TestLangOneTokensSyntaxKind.TPlusAssign:
					return "+=";
				case TestLangOneTokensSyntaxKind.TMinusAssign:
					return "-=";
				case TestLangOneTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case TestLangOneTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case TestLangOneTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case TestLangOneTokensSyntaxKind.THatAssign:
					return "^=";
				case TestLangOneTokensSyntaxKind.TBarAssign:
					return "|=";
				case TestLangOneTokensSyntaxKind.TArrow:
					return "->";
				case TestLangOneTokensSyntaxKind.IUri:
					return "Uri";
				case TestLangOneTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case TestLangOneTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case TestLangOneTokensSyntaxKind.LCommentStart:
					return "/*";
				case TestLangOneTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case TestLangOneTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public TestLangOneTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<TestLangOneTokensSyntaxKind>(rawKind));
		}

		public TestLangOneTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.KNamespace:
				case TestLangOneTokensSyntaxKind.KScope:
				case TestLangOneTokensSyntaxKind.KMember:
				case TestLangOneTokensSyntaxKind.KClass:
				case TestLangOneTokensSyntaxKind.KVertex:
				case TestLangOneTokensSyntaxKind.KOptional:
				case TestLangOneTokensSyntaxKind.KArrow:
				case TestLangOneTokensSyntaxKind.KStatic:
					return TestLangOneTokenKind.ReservedKeyword;
				case TestLangOneTokensSyntaxKind.IdentifierNormal:
					return TestLangOneTokenKind.Identifier;
				case TestLangOneTokensSyntaxKind.LInteger:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LDecimal:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LScientific:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LDateTimeOffset:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LDateTime:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LDate:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LTime:
					return TestLangOneTokenKind.Number;
				case TestLangOneTokensSyntaxKind.LRegularString:
					return TestLangOneTokenKind.String;
				case TestLangOneTokensSyntaxKind.LGuid:
					return TestLangOneTokenKind.String;
				case TestLangOneTokensSyntaxKind.LUtf8Bom:
					return TestLangOneTokenKind.Whitespace;
				case TestLangOneTokensSyntaxKind.LWhiteSpace:
					return TestLangOneTokenKind.Whitespace;
				case TestLangOneTokensSyntaxKind.LCrLf:
					return TestLangOneTokenKind.Whitespace;
				case TestLangOneTokensSyntaxKind.LLineEnd:
					return TestLangOneTokenKind.Whitespace;
				case TestLangOneTokensSyntaxKind.LSingleLineComment:
					return TestLangOneTokenKind.GeneralComment;
				case TestLangOneTokensSyntaxKind.LComment:
					return TestLangOneTokenKind.GeneralComment;
				case TestLangOneTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return TestLangOneTokenKind.String;
				case TestLangOneTokensSyntaxKind.LSingleQuoteVerbatimString:
					return TestLangOneTokenKind.String;
				default:
					return TestLangOneTokenKind.None;
			}
		}

		public TestLangOneTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((TestLangOneLexerMode)rawKind);
		}

		public TestLangOneTokenKind GetModeTokenKind(TestLangOneLexerMode kind)
		{
			switch(kind)
			{
				case TestLangOneLexerMode.LMultilineComment:
					return TestLangOneTokenKind.GeneralComment;
				case TestLangOneLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return TestLangOneTokenKind.String;
				case TestLangOneLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return TestLangOneTokenKind.String;
				default:
					return TestLangOneTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.LCrLf:
					return true;
				case TestLangOneTokensSyntaxKind.LLineEnd:
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
				case TestLangOneTokensSyntaxKind.KNamespace:
				case TestLangOneTokensSyntaxKind.KScope:
				case TestLangOneTokensSyntaxKind.KMember:
				case TestLangOneTokensSyntaxKind.KClass:
				case TestLangOneTokensSyntaxKind.KVertex:
				case TestLangOneTokensSyntaxKind.KOptional:
				case TestLangOneTokensSyntaxKind.KArrow:
				case TestLangOneTokensSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return TestLangOneTokensSyntaxKind.KNamespace;
				yield return TestLangOneTokensSyntaxKind.KScope;
				yield return TestLangOneTokensSyntaxKind.KMember;
				yield return TestLangOneTokensSyntaxKind.KClass;
				yield return TestLangOneTokensSyntaxKind.KVertex;
				yield return TestLangOneTokensSyntaxKind.KOptional;
				yield return TestLangOneTokensSyntaxKind.KArrow;
				yield return TestLangOneTokensSyntaxKind.KStatic;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return TestLangOneTokensSyntaxKind.KNamespace;
				case "scope":
					return TestLangOneTokensSyntaxKind.KScope;
				case "member":
					return TestLangOneTokensSyntaxKind.KMember;
				case "class":
					return TestLangOneTokensSyntaxKind.KClass;
				case "vertex":
					return TestLangOneTokensSyntaxKind.KVertex;
				case "optional":
					return TestLangOneTokensSyntaxKind.KOptional;
				case "arrow":
					return TestLangOneTokensSyntaxKind.KArrow;
				case "static":
					return TestLangOneTokensSyntaxKind.KStatic;
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
				case TestLangOneTokensSyntaxKind.IdentifierNormal:
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
				case TestLangOneTokensSyntaxKind.LInteger:
					return true;
				case TestLangOneTokensSyntaxKind.LDecimal:
					return true;
				case TestLangOneTokensSyntaxKind.LScientific:
					return true;
				case TestLangOneTokensSyntaxKind.LDateTimeOffset:
					return true;
				case TestLangOneTokensSyntaxKind.LDateTime:
					return true;
				case TestLangOneTokensSyntaxKind.LDate:
					return true;
				case TestLangOneTokensSyntaxKind.LTime:
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
				case TestLangOneTokensSyntaxKind.LRegularString:
					return true;
				case TestLangOneTokensSyntaxKind.LGuid:
					return true;
				case TestLangOneTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case TestLangOneTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.LUtf8Bom:
					return true;
				case TestLangOneTokensSyntaxKind.LWhiteSpace:
					return true;
				case TestLangOneTokensSyntaxKind.LCrLf:
					return true;
				case TestLangOneTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLangOneTokensSyntaxKind.LSingleLineComment:
					return true;
				case TestLangOneTokensSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}
	}
}


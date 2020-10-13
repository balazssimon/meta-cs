// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax
{
	public enum TestLanguageAnnotationsTokenKind : int
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

	public enum TestLanguageAnnotationsLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class TestLanguageAnnotationsTokensSyntaxFacts : SyntaxFacts
	{
        public TestLanguageAnnotationsTokensSyntaxFacts() 
            : base(typeof(TestLanguageAnnotationsTokensSyntaxKind))
        {
        }

        protected TestLanguageAnnotationsTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (TestLanguageAnnotationsTokensSyntaxKind)TestLanguageAnnotationsTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (TestLanguageAnnotationsTokensSyntaxKind)TestLanguageAnnotationsTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (TestLanguageAnnotationsTokensSyntaxKind)TestLanguageAnnotationsTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (TestLanguageAnnotationsTokensSyntaxKind)TestLanguageAnnotationsTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.Eof:
				case TestLanguageAnnotationsTokensSyntaxKind.KNamespace:
				case TestLanguageAnnotationsTokensSyntaxKind.KScope:
				case TestLanguageAnnotationsTokensSyntaxKind.KMember:
				case TestLanguageAnnotationsTokensSyntaxKind.KClass:
				case TestLanguageAnnotationsTokensSyntaxKind.KVertex:
				case TestLanguageAnnotationsTokensSyntaxKind.KOptional:
				case TestLanguageAnnotationsTokensSyntaxKind.KArrow:
				case TestLanguageAnnotationsTokensSyntaxKind.KStatic:
				case TestLanguageAnnotationsTokensSyntaxKind.KTrue:
				case TestLanguageAnnotationsTokensSyntaxKind.KFalse:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest01:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest02:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest03:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest04:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest05:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest06:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest07:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest08:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest09:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest10:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest11:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest12:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest13:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest14:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest15:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest16:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest17:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest18:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest19:
				case TestLanguageAnnotationsTokensSyntaxKind.KNull:
				case TestLanguageAnnotationsTokensSyntaxKind.TSemicolon:
				case TestLanguageAnnotationsTokensSyntaxKind.TColon:
				case TestLanguageAnnotationsTokensSyntaxKind.TDot:
				case TestLanguageAnnotationsTokensSyntaxKind.TComma:
				case TestLanguageAnnotationsTokensSyntaxKind.TAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenParen:
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseParen:
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenBracket:
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseBracket:
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenBrace:
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseBrace:
				case TestLanguageAnnotationsTokensSyntaxKind.TLessThan:
				case TestLanguageAnnotationsTokensSyntaxKind.TGreaterThan:
				case TestLanguageAnnotationsTokensSyntaxKind.TQuestion:
				case TestLanguageAnnotationsTokensSyntaxKind.TQuestionQuestion:
				case TestLanguageAnnotationsTokensSyntaxKind.TAmpersand:
				case TestLanguageAnnotationsTokensSyntaxKind.THat:
				case TestLanguageAnnotationsTokensSyntaxKind.TBar:
				case TestLanguageAnnotationsTokensSyntaxKind.TAndAlso:
				case TestLanguageAnnotationsTokensSyntaxKind.TOrElse:
				case TestLanguageAnnotationsTokensSyntaxKind.TPlusPlus:
				case TestLanguageAnnotationsTokensSyntaxKind.TMinusMinus:
				case TestLanguageAnnotationsTokensSyntaxKind.TPlus:
				case TestLanguageAnnotationsTokensSyntaxKind.TMinus:
				case TestLanguageAnnotationsTokensSyntaxKind.TTilde:
				case TestLanguageAnnotationsTokensSyntaxKind.TExclamation:
				case TestLanguageAnnotationsTokensSyntaxKind.TSlash:
				case TestLanguageAnnotationsTokensSyntaxKind.TAsterisk:
				case TestLanguageAnnotationsTokensSyntaxKind.TPercent:
				case TestLanguageAnnotationsTokensSyntaxKind.TLessThanOrEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TGreaterThanOrEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TNotEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TAsteriskAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TSlashAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TPercentAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TPlusAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TMinusAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TLeftShiftAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TRightShiftAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TAmpersandAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.THatAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TBarAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TArrow:
				case TestLanguageAnnotationsTokensSyntaxKind.IUri:
				case TestLanguageAnnotationsTokensSyntaxKind.IdentifierNormal:
				case TestLanguageAnnotationsTokensSyntaxKind.IdentifierVerbatim:
				case TestLanguageAnnotationsTokensSyntaxKind.LInteger:
				case TestLanguageAnnotationsTokensSyntaxKind.LDecimal:
				case TestLanguageAnnotationsTokensSyntaxKind.LScientific:
				case TestLanguageAnnotationsTokensSyntaxKind.LDateTimeOffset:
				case TestLanguageAnnotationsTokensSyntaxKind.LDateTime:
				case TestLanguageAnnotationsTokensSyntaxKind.LDate:
				case TestLanguageAnnotationsTokensSyntaxKind.LTime:
				case TestLanguageAnnotationsTokensSyntaxKind.LRegularString:
				case TestLanguageAnnotationsTokensSyntaxKind.LGuid:
				case TestLanguageAnnotationsTokensSyntaxKind.LUtf8Bom:
				case TestLanguageAnnotationsTokensSyntaxKind.LWhiteSpace:
				case TestLanguageAnnotationsTokensSyntaxKind.LCrLf:
				case TestLanguageAnnotationsTokensSyntaxKind.LLineEnd:
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleLineComment:
				case TestLanguageAnnotationsTokensSyntaxKind.LComment:
				case TestLanguageAnnotationsTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleQuoteVerbatimString:
				case TestLanguageAnnotationsTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestLanguageAnnotationsTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case TestLanguageAnnotationsTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.KNamespace:
				case TestLanguageAnnotationsTokensSyntaxKind.KScope:
				case TestLanguageAnnotationsTokensSyntaxKind.KMember:
				case TestLanguageAnnotationsTokensSyntaxKind.KClass:
				case TestLanguageAnnotationsTokensSyntaxKind.KVertex:
				case TestLanguageAnnotationsTokensSyntaxKind.KOptional:
				case TestLanguageAnnotationsTokensSyntaxKind.KArrow:
				case TestLanguageAnnotationsTokensSyntaxKind.KStatic:
				case TestLanguageAnnotationsTokensSyntaxKind.KTrue:
				case TestLanguageAnnotationsTokensSyntaxKind.KFalse:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest01:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest02:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest03:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest04:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest05:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest06:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest07:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest08:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest09:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest10:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest11:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest12:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest13:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest14:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest15:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest16:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest17:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest18:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest19:
				case TestLanguageAnnotationsTokensSyntaxKind.KNull:
				case TestLanguageAnnotationsTokensSyntaxKind.TSemicolon:
				case TestLanguageAnnotationsTokensSyntaxKind.TColon:
				case TestLanguageAnnotationsTokensSyntaxKind.TDot:
				case TestLanguageAnnotationsTokensSyntaxKind.TComma:
				case TestLanguageAnnotationsTokensSyntaxKind.TAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenParen:
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseParen:
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenBracket:
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseBracket:
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenBrace:
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseBrace:
				case TestLanguageAnnotationsTokensSyntaxKind.TLessThan:
				case TestLanguageAnnotationsTokensSyntaxKind.TGreaterThan:
				case TestLanguageAnnotationsTokensSyntaxKind.TQuestion:
				case TestLanguageAnnotationsTokensSyntaxKind.TQuestionQuestion:
				case TestLanguageAnnotationsTokensSyntaxKind.TAmpersand:
				case TestLanguageAnnotationsTokensSyntaxKind.THat:
				case TestLanguageAnnotationsTokensSyntaxKind.TBar:
				case TestLanguageAnnotationsTokensSyntaxKind.TAndAlso:
				case TestLanguageAnnotationsTokensSyntaxKind.TOrElse:
				case TestLanguageAnnotationsTokensSyntaxKind.TPlusPlus:
				case TestLanguageAnnotationsTokensSyntaxKind.TMinusMinus:
				case TestLanguageAnnotationsTokensSyntaxKind.TPlus:
				case TestLanguageAnnotationsTokensSyntaxKind.TMinus:
				case TestLanguageAnnotationsTokensSyntaxKind.TTilde:
				case TestLanguageAnnotationsTokensSyntaxKind.TExclamation:
				case TestLanguageAnnotationsTokensSyntaxKind.TSlash:
				case TestLanguageAnnotationsTokensSyntaxKind.TPercent:
				case TestLanguageAnnotationsTokensSyntaxKind.TLessThanOrEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TGreaterThanOrEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TNotEqual:
				case TestLanguageAnnotationsTokensSyntaxKind.TAsteriskAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TSlashAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TPercentAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TPlusAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TMinusAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TLeftShiftAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TRightShiftAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TAmpersandAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.THatAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TBarAssign:
				case TestLanguageAnnotationsTokensSyntaxKind.TArrow:
				case TestLanguageAnnotationsTokensSyntaxKind.IUri:
				case TestLanguageAnnotationsTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestLanguageAnnotationsTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case TestLanguageAnnotationsTokensSyntaxKind.LCommentStart:
				case TestLanguageAnnotationsTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return TestLanguageAnnotationsTokensSyntaxKind.KNamespace;
				case "scope":
					return TestLanguageAnnotationsTokensSyntaxKind.KScope;
				case "member":
					return TestLanguageAnnotationsTokensSyntaxKind.KMember;
				case "class":
					return TestLanguageAnnotationsTokensSyntaxKind.KClass;
				case "vertex":
					return TestLanguageAnnotationsTokensSyntaxKind.KVertex;
				case "optional":
					return TestLanguageAnnotationsTokensSyntaxKind.KOptional;
				case "arrow":
					return TestLanguageAnnotationsTokensSyntaxKind.KArrow;
				case "static":
					return TestLanguageAnnotationsTokensSyntaxKind.KStatic;
				case "true":
					return TestLanguageAnnotationsTokensSyntaxKind.KTrue;
				case "false":
					return TestLanguageAnnotationsTokensSyntaxKind.KFalse;
				case "test01":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest01;
				case "test02":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest02;
				case "test03":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest03;
				case "test04":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest04;
				case "test05":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest05;
				case "test06":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest06;
				case "test07":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest07;
				case "test08":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest08;
				case "test09":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest09;
				case "test10":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest10;
				case "test11":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest11;
				case "test12":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest12;
				case "test13":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest13;
				case "test14":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest14;
				case "test15":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest15;
				case "test16":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest16;
				case "test17":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest17;
				case "test18":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest18;
				case "test19":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest19;
				case "null":
					return TestLanguageAnnotationsTokensSyntaxKind.KNull;
				case ";":
					return TestLanguageAnnotationsTokensSyntaxKind.TSemicolon;
				case ":":
					return TestLanguageAnnotationsTokensSyntaxKind.TColon;
				case ".":
					return TestLanguageAnnotationsTokensSyntaxKind.TDot;
				case ",":
					return TestLanguageAnnotationsTokensSyntaxKind.TComma;
				case "=":
					return TestLanguageAnnotationsTokensSyntaxKind.TAssign;
				case "(":
					return TestLanguageAnnotationsTokensSyntaxKind.TOpenParen;
				case ")":
					return TestLanguageAnnotationsTokensSyntaxKind.TCloseParen;
				case "[":
					return TestLanguageAnnotationsTokensSyntaxKind.TOpenBracket;
				case "]":
					return TestLanguageAnnotationsTokensSyntaxKind.TCloseBracket;
				case "{":
					return TestLanguageAnnotationsTokensSyntaxKind.TOpenBrace;
				case "}":
					return TestLanguageAnnotationsTokensSyntaxKind.TCloseBrace;
				case "<":
					return TestLanguageAnnotationsTokensSyntaxKind.TLessThan;
				case ">":
					return TestLanguageAnnotationsTokensSyntaxKind.TGreaterThan;
				case "?":
					return TestLanguageAnnotationsTokensSyntaxKind.TQuestion;
				case "??":
					return TestLanguageAnnotationsTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return TestLanguageAnnotationsTokensSyntaxKind.TAmpersand;
				case "^":
					return TestLanguageAnnotationsTokensSyntaxKind.THat;
				case "|":
					return TestLanguageAnnotationsTokensSyntaxKind.TBar;
				case "&&":
					return TestLanguageAnnotationsTokensSyntaxKind.TAndAlso;
				case "||":
					return TestLanguageAnnotationsTokensSyntaxKind.TOrElse;
				case "++":
					return TestLanguageAnnotationsTokensSyntaxKind.TPlusPlus;
				case "--":
					return TestLanguageAnnotationsTokensSyntaxKind.TMinusMinus;
				case "+":
					return TestLanguageAnnotationsTokensSyntaxKind.TPlus;
				case "-":
					return TestLanguageAnnotationsTokensSyntaxKind.TMinus;
				case "~":
					return TestLanguageAnnotationsTokensSyntaxKind.TTilde;
				case "!":
					return TestLanguageAnnotationsTokensSyntaxKind.TExclamation;
				case "/":
					return TestLanguageAnnotationsTokensSyntaxKind.TSlash;
				case "%":
					return TestLanguageAnnotationsTokensSyntaxKind.TPercent;
				case "<=":
					return TestLanguageAnnotationsTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return TestLanguageAnnotationsTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return TestLanguageAnnotationsTokensSyntaxKind.TEqual;
				case "!=":
					return TestLanguageAnnotationsTokensSyntaxKind.TNotEqual;
				case "*=":
					return TestLanguageAnnotationsTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return TestLanguageAnnotationsTokensSyntaxKind.TSlashAssign;
				case "%=":
					return TestLanguageAnnotationsTokensSyntaxKind.TPercentAssign;
				case "+=":
					return TestLanguageAnnotationsTokensSyntaxKind.TPlusAssign;
				case "-=":
					return TestLanguageAnnotationsTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return TestLanguageAnnotationsTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return TestLanguageAnnotationsTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return TestLanguageAnnotationsTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return TestLanguageAnnotationsTokensSyntaxKind.THatAssign;
				case "|=":
					return TestLanguageAnnotationsTokensSyntaxKind.TBarAssign;
				case "->":
					return TestLanguageAnnotationsTokensSyntaxKind.TArrow;
				case "Uri":
					return TestLanguageAnnotationsTokensSyntaxKind.IUri;
				case "@\"":
					return TestLanguageAnnotationsTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return TestLanguageAnnotationsTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return TestLanguageAnnotationsTokensSyntaxKind.LCommentStart;
				case "\"":
					return TestLanguageAnnotationsTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return TestLanguageAnnotationsTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return TestLanguageAnnotationsTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.KNamespace:
					return "namespace";
				case TestLanguageAnnotationsTokensSyntaxKind.KScope:
					return "scope";
				case TestLanguageAnnotationsTokensSyntaxKind.KMember:
					return "member";
				case TestLanguageAnnotationsTokensSyntaxKind.KClass:
					return "class";
				case TestLanguageAnnotationsTokensSyntaxKind.KVertex:
					return "vertex";
				case TestLanguageAnnotationsTokensSyntaxKind.KOptional:
					return "optional";
				case TestLanguageAnnotationsTokensSyntaxKind.KArrow:
					return "arrow";
				case TestLanguageAnnotationsTokensSyntaxKind.KStatic:
					return "static";
				case TestLanguageAnnotationsTokensSyntaxKind.KTrue:
					return "true";
				case TestLanguageAnnotationsTokensSyntaxKind.KFalse:
					return "false";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest01:
					return "test01";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest02:
					return "test02";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest03:
					return "test03";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest04:
					return "test04";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest05:
					return "test05";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest06:
					return "test06";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest07:
					return "test07";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest08:
					return "test08";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest09:
					return "test09";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest10:
					return "test10";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest11:
					return "test11";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest12:
					return "test12";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest13:
					return "test13";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest14:
					return "test14";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest15:
					return "test15";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest16:
					return "test16";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest17:
					return "test17";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest18:
					return "test18";
				case TestLanguageAnnotationsTokensSyntaxKind.KTest19:
					return "test19";
				case TestLanguageAnnotationsTokensSyntaxKind.KNull:
					return "null";
				case TestLanguageAnnotationsTokensSyntaxKind.TSemicolon:
					return ";";
				case TestLanguageAnnotationsTokensSyntaxKind.TColon:
					return ":";
				case TestLanguageAnnotationsTokensSyntaxKind.TDot:
					return ".";
				case TestLanguageAnnotationsTokensSyntaxKind.TComma:
					return ",";
				case TestLanguageAnnotationsTokensSyntaxKind.TAssign:
					return "=";
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenParen:
					return "(";
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseParen:
					return ")";
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenBracket:
					return "[";
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseBracket:
					return "]";
				case TestLanguageAnnotationsTokensSyntaxKind.TOpenBrace:
					return "{";
				case TestLanguageAnnotationsTokensSyntaxKind.TCloseBrace:
					return "}";
				case TestLanguageAnnotationsTokensSyntaxKind.TLessThan:
					return "<";
				case TestLanguageAnnotationsTokensSyntaxKind.TGreaterThan:
					return ">";
				case TestLanguageAnnotationsTokensSyntaxKind.TQuestion:
					return "?";
				case TestLanguageAnnotationsTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case TestLanguageAnnotationsTokensSyntaxKind.TAmpersand:
					return "&";
				case TestLanguageAnnotationsTokensSyntaxKind.THat:
					return "^";
				case TestLanguageAnnotationsTokensSyntaxKind.TBar:
					return "|";
				case TestLanguageAnnotationsTokensSyntaxKind.TAndAlso:
					return "&&";
				case TestLanguageAnnotationsTokensSyntaxKind.TOrElse:
					return "||";
				case TestLanguageAnnotationsTokensSyntaxKind.TPlusPlus:
					return "++";
				case TestLanguageAnnotationsTokensSyntaxKind.TMinusMinus:
					return "--";
				case TestLanguageAnnotationsTokensSyntaxKind.TPlus:
					return "+";
				case TestLanguageAnnotationsTokensSyntaxKind.TMinus:
					return "-";
				case TestLanguageAnnotationsTokensSyntaxKind.TTilde:
					return "~";
				case TestLanguageAnnotationsTokensSyntaxKind.TExclamation:
					return "!";
				case TestLanguageAnnotationsTokensSyntaxKind.TSlash:
					return "/";
				case TestLanguageAnnotationsTokensSyntaxKind.TPercent:
					return "%";
				case TestLanguageAnnotationsTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case TestLanguageAnnotationsTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case TestLanguageAnnotationsTokensSyntaxKind.TEqual:
					return "==";
				case TestLanguageAnnotationsTokensSyntaxKind.TNotEqual:
					return "!=";
				case TestLanguageAnnotationsTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case TestLanguageAnnotationsTokensSyntaxKind.TSlashAssign:
					return "/=";
				case TestLanguageAnnotationsTokensSyntaxKind.TPercentAssign:
					return "%=";
				case TestLanguageAnnotationsTokensSyntaxKind.TPlusAssign:
					return "+=";
				case TestLanguageAnnotationsTokensSyntaxKind.TMinusAssign:
					return "-=";
				case TestLanguageAnnotationsTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case TestLanguageAnnotationsTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case TestLanguageAnnotationsTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case TestLanguageAnnotationsTokensSyntaxKind.THatAssign:
					return "^=";
				case TestLanguageAnnotationsTokensSyntaxKind.TBarAssign:
					return "|=";
				case TestLanguageAnnotationsTokensSyntaxKind.TArrow:
					return "->";
				case TestLanguageAnnotationsTokensSyntaxKind.IUri:
					return "Uri";
				case TestLanguageAnnotationsTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case TestLanguageAnnotationsTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case TestLanguageAnnotationsTokensSyntaxKind.LCommentStart:
					return "/*";
				case TestLanguageAnnotationsTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public TestLanguageAnnotationsTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<TestLanguageAnnotationsTokensSyntaxKind>(rawKind));
		}

		public TestLanguageAnnotationsTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.KNamespace:
				case TestLanguageAnnotationsTokensSyntaxKind.KScope:
				case TestLanguageAnnotationsTokensSyntaxKind.KMember:
				case TestLanguageAnnotationsTokensSyntaxKind.KClass:
				case TestLanguageAnnotationsTokensSyntaxKind.KVertex:
				case TestLanguageAnnotationsTokensSyntaxKind.KOptional:
				case TestLanguageAnnotationsTokensSyntaxKind.KArrow:
				case TestLanguageAnnotationsTokensSyntaxKind.KStatic:
				case TestLanguageAnnotationsTokensSyntaxKind.KTrue:
				case TestLanguageAnnotationsTokensSyntaxKind.KFalse:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest01:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest02:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest03:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest04:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest05:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest06:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest07:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest08:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest09:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest10:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest11:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest12:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest13:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest14:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest15:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest16:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest17:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest18:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest19:
				case TestLanguageAnnotationsTokensSyntaxKind.KNull:
					return TestLanguageAnnotationsTokenKind.ReservedKeyword;
				case TestLanguageAnnotationsTokensSyntaxKind.IdentifierNormal:
					return TestLanguageAnnotationsTokenKind.Identifier;
				case TestLanguageAnnotationsTokensSyntaxKind.LInteger:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LDecimal:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LScientific:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LDateTimeOffset:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LDateTime:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LDate:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LTime:
					return TestLanguageAnnotationsTokenKind.Number;
				case TestLanguageAnnotationsTokensSyntaxKind.LRegularString:
					return TestLanguageAnnotationsTokenKind.String;
				case TestLanguageAnnotationsTokensSyntaxKind.LGuid:
					return TestLanguageAnnotationsTokenKind.String;
				case TestLanguageAnnotationsTokensSyntaxKind.LUtf8Bom:
					return TestLanguageAnnotationsTokenKind.Whitespace;
				case TestLanguageAnnotationsTokensSyntaxKind.LWhiteSpace:
					return TestLanguageAnnotationsTokenKind.Whitespace;
				case TestLanguageAnnotationsTokensSyntaxKind.LCrLf:
					return TestLanguageAnnotationsTokenKind.Whitespace;
				case TestLanguageAnnotationsTokensSyntaxKind.LLineEnd:
					return TestLanguageAnnotationsTokenKind.Whitespace;
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleLineComment:
					return TestLanguageAnnotationsTokenKind.GeneralComment;
				case TestLanguageAnnotationsTokensSyntaxKind.LComment:
					return TestLanguageAnnotationsTokenKind.GeneralComment;
				case TestLanguageAnnotationsTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return TestLanguageAnnotationsTokenKind.String;
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleQuoteVerbatimString:
					return TestLanguageAnnotationsTokenKind.String;
				default:
					return TestLanguageAnnotationsTokenKind.None;
			}
		}

		public TestLanguageAnnotationsTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((TestLanguageAnnotationsLexerMode)rawKind);
		}

		public TestLanguageAnnotationsTokenKind GetModeTokenKind(TestLanguageAnnotationsLexerMode kind)
		{
			switch(kind)
			{
				case TestLanguageAnnotationsLexerMode.LMultilineComment:
					return TestLanguageAnnotationsTokenKind.GeneralComment;
				case TestLanguageAnnotationsLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return TestLanguageAnnotationsTokenKind.String;
				case TestLanguageAnnotationsLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return TestLanguageAnnotationsTokenKind.String;
				default:
					return TestLanguageAnnotationsTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.LCrLf:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LLineEnd:
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
				case TestLanguageAnnotationsTokensSyntaxKind.KNamespace:
				case TestLanguageAnnotationsTokensSyntaxKind.KScope:
				case TestLanguageAnnotationsTokensSyntaxKind.KMember:
				case TestLanguageAnnotationsTokensSyntaxKind.KClass:
				case TestLanguageAnnotationsTokensSyntaxKind.KVertex:
				case TestLanguageAnnotationsTokensSyntaxKind.KOptional:
				case TestLanguageAnnotationsTokensSyntaxKind.KArrow:
				case TestLanguageAnnotationsTokensSyntaxKind.KStatic:
				case TestLanguageAnnotationsTokensSyntaxKind.KTrue:
				case TestLanguageAnnotationsTokensSyntaxKind.KFalse:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest01:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest02:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest03:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest04:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest05:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest06:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest07:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest08:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest09:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest10:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest11:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest12:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest13:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest14:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest15:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest16:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest17:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest18:
				case TestLanguageAnnotationsTokensSyntaxKind.KTest19:
				case TestLanguageAnnotationsTokensSyntaxKind.KNull:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return TestLanguageAnnotationsTokensSyntaxKind.KNamespace;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KScope;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KMember;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KClass;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KVertex;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KOptional;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KArrow;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KStatic;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTrue;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KFalse;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest01;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest02;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest03;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest04;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest05;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest06;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest07;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest08;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest09;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest10;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest11;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest12;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest13;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest14;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest15;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest16;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest17;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest18;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KTest19;
				yield return TestLanguageAnnotationsTokensSyntaxKind.KNull;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return TestLanguageAnnotationsTokensSyntaxKind.KNamespace;
				case "scope":
					return TestLanguageAnnotationsTokensSyntaxKind.KScope;
				case "member":
					return TestLanguageAnnotationsTokensSyntaxKind.KMember;
				case "class":
					return TestLanguageAnnotationsTokensSyntaxKind.KClass;
				case "vertex":
					return TestLanguageAnnotationsTokensSyntaxKind.KVertex;
				case "optional":
					return TestLanguageAnnotationsTokensSyntaxKind.KOptional;
				case "arrow":
					return TestLanguageAnnotationsTokensSyntaxKind.KArrow;
				case "static":
					return TestLanguageAnnotationsTokensSyntaxKind.KStatic;
				case "true":
					return TestLanguageAnnotationsTokensSyntaxKind.KTrue;
				case "false":
					return TestLanguageAnnotationsTokensSyntaxKind.KFalse;
				case "test01":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest01;
				case "test02":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest02;
				case "test03":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest03;
				case "test04":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest04;
				case "test05":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest05;
				case "test06":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest06;
				case "test07":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest07;
				case "test08":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest08;
				case "test09":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest09;
				case "test10":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest10;
				case "test11":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest11;
				case "test12":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest12;
				case "test13":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest13;
				case "test14":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest14;
				case "test15":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest15;
				case "test16":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest16;
				case "test17":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest17;
				case "test18":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest18;
				case "test19":
					return TestLanguageAnnotationsTokensSyntaxKind.KTest19;
				case "null":
					return TestLanguageAnnotationsTokensSyntaxKind.KNull;
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
				case TestLanguageAnnotationsTokensSyntaxKind.IdentifierNormal:
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
				case TestLanguageAnnotationsTokensSyntaxKind.LInteger:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LDecimal:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LScientific:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LDateTimeOffset:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LDateTime:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LDate:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LTime:
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
				case TestLanguageAnnotationsTokensSyntaxKind.LRegularString:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LGuid:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.LUtf8Bom:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LWhiteSpace:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LCrLf:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLanguageAnnotationsTokensSyntaxKind.LSingleLineComment:
					return true;
				case TestLanguageAnnotationsTokensSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}
	}
}


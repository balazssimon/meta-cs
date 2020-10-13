// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax
{
	public enum TestLexerModeTokenKind : int
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
		Operator,
		PreprocessorContextualKeyword,
		PreprocessorDirective,
		PreprocessorKeyword,
		ReservedKeyword,
		String,
		TemplateControl,
		TemplateOutput,
		Token,
		Trivia,
		Whitespace
	}

	public enum TestLexerModeLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		MULTILINE_COMMENT = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		TEMPLATE_HEADER = 3,
		TEMPLATE_OUTPUT = 4,
		TEMPLATE_STATEMENT = 5,
		TEMPLATE_STATEMENT_COMMENT = 6
	}

	public class TestLexerModeTokensSyntaxFacts : SyntaxFacts
	{
        public TestLexerModeTokensSyntaxFacts() 
            : base(typeof(TestLexerModeTokensSyntaxKind))
        {
        }

        protected TestLexerModeTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (TestLexerModeTokensSyntaxKind)TestLexerModeTokensSyntaxKind.LWhitespace;
        public override SyntaxKind DefaultEndOfLineKind => (TestLexerModeTokensSyntaxKind)TestLexerModeTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (TestLexerModeTokensSyntaxKind)TestLexerModeTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (TestLexerModeTokensSyntaxKind)TestLexerModeTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.Eof:
				case TestLexerModeTokensSyntaxKind.KNamespace:
				case TestLexerModeTokensSyntaxKind.KGenerator:
				case TestLexerModeTokensSyntaxKind.KUsing:
				case TestLexerModeTokensSyntaxKind.KConfiguration:
				case TestLexerModeTokensSyntaxKind.KProperties:
				case TestLexerModeTokensSyntaxKind.KTemplate:
				case TestLexerModeTokensSyntaxKind.KFunction:
				case TestLexerModeTokensSyntaxKind.KExtern:
				case TestLexerModeTokensSyntaxKind.KReturn:
				case TestLexerModeTokensSyntaxKind.KSwitch:
				case TestLexerModeTokensSyntaxKind.KCase:
				case TestLexerModeTokensSyntaxKind.KType:
				case TestLexerModeTokensSyntaxKind.KVoid:
				case TestLexerModeTokensSyntaxKind.KEnd:
				case TestLexerModeTokensSyntaxKind.KFor:
				case TestLexerModeTokensSyntaxKind.KForEach:
				case TestLexerModeTokensSyntaxKind.KIn:
				case TestLexerModeTokensSyntaxKind.KIf:
				case TestLexerModeTokensSyntaxKind.KElse:
				case TestLexerModeTokensSyntaxKind.KRepeat:
				case TestLexerModeTokensSyntaxKind.KUntil:
				case TestLexerModeTokensSyntaxKind.KWhile:
				case TestLexerModeTokensSyntaxKind.KLoop:
				case TestLexerModeTokensSyntaxKind.KHasLoop:
				case TestLexerModeTokensSyntaxKind.KWhere:
				case TestLexerModeTokensSyntaxKind.KOrderBy:
				case TestLexerModeTokensSyntaxKind.KDescending:
				case TestLexerModeTokensSyntaxKind.KSeparator:
				case TestLexerModeTokensSyntaxKind.KNull:
				case TestLexerModeTokensSyntaxKind.KTrue:
				case TestLexerModeTokensSyntaxKind.KFalse:
				case TestLexerModeTokensSyntaxKind.KBool:
				case TestLexerModeTokensSyntaxKind.KByte:
				case TestLexerModeTokensSyntaxKind.KChar:
				case TestLexerModeTokensSyntaxKind.KDecimal:
				case TestLexerModeTokensSyntaxKind.KDouble:
				case TestLexerModeTokensSyntaxKind.KFloat:
				case TestLexerModeTokensSyntaxKind.KInt:
				case TestLexerModeTokensSyntaxKind.KLong:
				case TestLexerModeTokensSyntaxKind.KObject:
				case TestLexerModeTokensSyntaxKind.KSByte:
				case TestLexerModeTokensSyntaxKind.KShort:
				case TestLexerModeTokensSyntaxKind.KString:
				case TestLexerModeTokensSyntaxKind.KUInt:
				case TestLexerModeTokensSyntaxKind.KULong:
				case TestLexerModeTokensSyntaxKind.KUShort:
				case TestLexerModeTokensSyntaxKind.KThis:
				case TestLexerModeTokensSyntaxKind.KNew:
				case TestLexerModeTokensSyntaxKind.KIs:
				case TestLexerModeTokensSyntaxKind.KAs:
				case TestLexerModeTokensSyntaxKind.KTypeof:
				case TestLexerModeTokensSyntaxKind.KDefault:
				case TestLexerModeTokensSyntaxKind.TSemicolon:
				case TestLexerModeTokensSyntaxKind.TColon:
				case TestLexerModeTokensSyntaxKind.TDot:
				case TestLexerModeTokensSyntaxKind.TComma:
				case TestLexerModeTokensSyntaxKind.TAssign:
				case TestLexerModeTokensSyntaxKind.TAssignPlus:
				case TestLexerModeTokensSyntaxKind.TAssignMinus:
				case TestLexerModeTokensSyntaxKind.TAssignAsterisk:
				case TestLexerModeTokensSyntaxKind.TAssignSlash:
				case TestLexerModeTokensSyntaxKind.TAssignPercent:
				case TestLexerModeTokensSyntaxKind.TAssignAmp:
				case TestLexerModeTokensSyntaxKind.TAssignPipe:
				case TestLexerModeTokensSyntaxKind.TAssignHat:
				case TestLexerModeTokensSyntaxKind.TAssignLeftShift:
				case TestLexerModeTokensSyntaxKind.TAssignRightShift:
				case TestLexerModeTokensSyntaxKind.TOpenParenthesis:
				case TestLexerModeTokensSyntaxKind.TCloseParenthesis:
				case TestLexerModeTokensSyntaxKind.TOpenBracket:
				case TestLexerModeTokensSyntaxKind.TCloseBracket:
				case TestLexerModeTokensSyntaxKind.TOpenBrace:
				case TestLexerModeTokensSyntaxKind.TCloseBrace:
				case TestLexerModeTokensSyntaxKind.TEquals:
				case TestLexerModeTokensSyntaxKind.TNotEquals:
				case TestLexerModeTokensSyntaxKind.TArrow:
				case TestLexerModeTokensSyntaxKind.TSingleArrow:
				case TestLexerModeTokensSyntaxKind.TLessThan:
				case TestLexerModeTokensSyntaxKind.TGreaterThan:
				case TestLexerModeTokensSyntaxKind.TLessThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TGreaterThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TQuestion:
				case TestLexerModeTokensSyntaxKind.TPlus:
				case TestLexerModeTokensSyntaxKind.TMinus:
				case TestLexerModeTokensSyntaxKind.TExclamation:
				case TestLexerModeTokensSyntaxKind.TTilde:
				case TestLexerModeTokensSyntaxKind.TAsterisk:
				case TestLexerModeTokensSyntaxKind.TSlash:
				case TestLexerModeTokensSyntaxKind.TPercent:
				case TestLexerModeTokensSyntaxKind.TPlusPlus:
				case TestLexerModeTokensSyntaxKind.TMinusMinus:
				case TestLexerModeTokensSyntaxKind.TColonColon:
				case TestLexerModeTokensSyntaxKind.TAmp:
				case TestLexerModeTokensSyntaxKind.THat:
				case TestLexerModeTokensSyntaxKind.TPipe:
				case TestLexerModeTokensSyntaxKind.TAnd:
				case TestLexerModeTokensSyntaxKind.TXor:
				case TestLexerModeTokensSyntaxKind.TOr:
				case TestLexerModeTokensSyntaxKind.TQuestionQuestion:
				case TestLexerModeTokensSyntaxKind.IdentifierNormal:
				case TestLexerModeTokensSyntaxKind.LInteger:
				case TestLexerModeTokensSyntaxKind.LDecimal:
				case TestLexerModeTokensSyntaxKind.LScientific:
				case TestLexerModeTokensSyntaxKind.LDateTimeOffset:
				case TestLexerModeTokensSyntaxKind.LDateTime:
				case TestLexerModeTokensSyntaxKind.LDate:
				case TestLexerModeTokensSyntaxKind.LTime:
				case TestLexerModeTokensSyntaxKind.LChar:
				case TestLexerModeTokensSyntaxKind.LRegularString:
				case TestLexerModeTokensSyntaxKind.LGuid:
				case TestLexerModeTokensSyntaxKind.LUtf8Bom:
				case TestLexerModeTokensSyntaxKind.LWhitespace:
				case TestLexerModeTokensSyntaxKind.LCrLf:
				case TestLexerModeTokensSyntaxKind.LLineBreak:
				case TestLexerModeTokensSyntaxKind.LLineComment:
				case TestLexerModeTokensSyntaxKind.LMultiLineComment:
				case TestLexerModeTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestLexerModeTokensSyntaxKind.TH_TOpenParenthesis:
				case TestLexerModeTokensSyntaxKind.TH_TCloseParenthesis:
				case TestLexerModeTokensSyntaxKind.KEndTemplate:
				case TestLexerModeTokensSyntaxKind.LTemplateLineControl:
				case TestLexerModeTokensSyntaxKind.LTemplateOutput:
				case TestLexerModeTokensSyntaxKind.LTemplateCrLf:
				case TestLexerModeTokensSyntaxKind.LTemplateLineBreak:
				case TestLexerModeTokensSyntaxKind.TTemplateStatementStart:
				case TestLexerModeTokensSyntaxKind.TTemplateStatementEnd:
				case TestLexerModeTokensSyntaxKind.TS_TOpenBracket:
				case TestLexerModeTokensSyntaxKind.TS_TCloseBracket:
				case TestLexerModeTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestLexerModeTokensSyntaxKind.COMMENT_START:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.KNamespace:
				case TestLexerModeTokensSyntaxKind.KGenerator:
				case TestLexerModeTokensSyntaxKind.KUsing:
				case TestLexerModeTokensSyntaxKind.KConfiguration:
				case TestLexerModeTokensSyntaxKind.KProperties:
				case TestLexerModeTokensSyntaxKind.KTemplate:
				case TestLexerModeTokensSyntaxKind.KFunction:
				case TestLexerModeTokensSyntaxKind.KExtern:
				case TestLexerModeTokensSyntaxKind.KReturn:
				case TestLexerModeTokensSyntaxKind.KSwitch:
				case TestLexerModeTokensSyntaxKind.KCase:
				case TestLexerModeTokensSyntaxKind.KType:
				case TestLexerModeTokensSyntaxKind.KVoid:
				case TestLexerModeTokensSyntaxKind.KEnd:
				case TestLexerModeTokensSyntaxKind.KFor:
				case TestLexerModeTokensSyntaxKind.KForEach:
				case TestLexerModeTokensSyntaxKind.KIn:
				case TestLexerModeTokensSyntaxKind.KIf:
				case TestLexerModeTokensSyntaxKind.KElse:
				case TestLexerModeTokensSyntaxKind.KRepeat:
				case TestLexerModeTokensSyntaxKind.KUntil:
				case TestLexerModeTokensSyntaxKind.KWhile:
				case TestLexerModeTokensSyntaxKind.KLoop:
				case TestLexerModeTokensSyntaxKind.KHasLoop:
				case TestLexerModeTokensSyntaxKind.KWhere:
				case TestLexerModeTokensSyntaxKind.KOrderBy:
				case TestLexerModeTokensSyntaxKind.KDescending:
				case TestLexerModeTokensSyntaxKind.KSeparator:
				case TestLexerModeTokensSyntaxKind.KNull:
				case TestLexerModeTokensSyntaxKind.KTrue:
				case TestLexerModeTokensSyntaxKind.KFalse:
				case TestLexerModeTokensSyntaxKind.KBool:
				case TestLexerModeTokensSyntaxKind.KByte:
				case TestLexerModeTokensSyntaxKind.KChar:
				case TestLexerModeTokensSyntaxKind.KDecimal:
				case TestLexerModeTokensSyntaxKind.KDouble:
				case TestLexerModeTokensSyntaxKind.KFloat:
				case TestLexerModeTokensSyntaxKind.KInt:
				case TestLexerModeTokensSyntaxKind.KLong:
				case TestLexerModeTokensSyntaxKind.KObject:
				case TestLexerModeTokensSyntaxKind.KSByte:
				case TestLexerModeTokensSyntaxKind.KShort:
				case TestLexerModeTokensSyntaxKind.KString:
				case TestLexerModeTokensSyntaxKind.KUInt:
				case TestLexerModeTokensSyntaxKind.KULong:
				case TestLexerModeTokensSyntaxKind.KUShort:
				case TestLexerModeTokensSyntaxKind.KThis:
				case TestLexerModeTokensSyntaxKind.KNew:
				case TestLexerModeTokensSyntaxKind.KIs:
				case TestLexerModeTokensSyntaxKind.KAs:
				case TestLexerModeTokensSyntaxKind.KTypeof:
				case TestLexerModeTokensSyntaxKind.KDefault:
				case TestLexerModeTokensSyntaxKind.TSemicolon:
				case TestLexerModeTokensSyntaxKind.TColon:
				case TestLexerModeTokensSyntaxKind.TDot:
				case TestLexerModeTokensSyntaxKind.TComma:
				case TestLexerModeTokensSyntaxKind.TAssign:
				case TestLexerModeTokensSyntaxKind.TAssignPlus:
				case TestLexerModeTokensSyntaxKind.TAssignMinus:
				case TestLexerModeTokensSyntaxKind.TAssignAsterisk:
				case TestLexerModeTokensSyntaxKind.TAssignSlash:
				case TestLexerModeTokensSyntaxKind.TAssignPercent:
				case TestLexerModeTokensSyntaxKind.TAssignAmp:
				case TestLexerModeTokensSyntaxKind.TAssignPipe:
				case TestLexerModeTokensSyntaxKind.TAssignHat:
				case TestLexerModeTokensSyntaxKind.TAssignLeftShift:
				case TestLexerModeTokensSyntaxKind.TAssignRightShift:
				case TestLexerModeTokensSyntaxKind.TOpenParenthesis:
				case TestLexerModeTokensSyntaxKind.TCloseParenthesis:
				case TestLexerModeTokensSyntaxKind.TCloseBracket:
				case TestLexerModeTokensSyntaxKind.TOpenBrace:
				case TestLexerModeTokensSyntaxKind.TCloseBrace:
				case TestLexerModeTokensSyntaxKind.TEquals:
				case TestLexerModeTokensSyntaxKind.TNotEquals:
				case TestLexerModeTokensSyntaxKind.TArrow:
				case TestLexerModeTokensSyntaxKind.TSingleArrow:
				case TestLexerModeTokensSyntaxKind.TLessThan:
				case TestLexerModeTokensSyntaxKind.TGreaterThan:
				case TestLexerModeTokensSyntaxKind.TLessThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TGreaterThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TQuestion:
				case TestLexerModeTokensSyntaxKind.TPlus:
				case TestLexerModeTokensSyntaxKind.TMinus:
				case TestLexerModeTokensSyntaxKind.TExclamation:
				case TestLexerModeTokensSyntaxKind.TTilde:
				case TestLexerModeTokensSyntaxKind.TSlash:
				case TestLexerModeTokensSyntaxKind.TPercent:
				case TestLexerModeTokensSyntaxKind.TPlusPlus:
				case TestLexerModeTokensSyntaxKind.TMinusMinus:
				case TestLexerModeTokensSyntaxKind.TColonColon:
				case TestLexerModeTokensSyntaxKind.TAmp:
				case TestLexerModeTokensSyntaxKind.THat:
				case TestLexerModeTokensSyntaxKind.TPipe:
				case TestLexerModeTokensSyntaxKind.TAnd:
				case TestLexerModeTokensSyntaxKind.TXor:
				case TestLexerModeTokensSyntaxKind.TOr:
				case TestLexerModeTokensSyntaxKind.TQuestionQuestion:
				case TestLexerModeTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestLexerModeTokensSyntaxKind.LDoubleQuoteVerbatimString:
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
					return TestLexerModeTokensSyntaxKind.KNamespace;
				case "generator":
					return TestLexerModeTokensSyntaxKind.KGenerator;
				case "using":
					return TestLexerModeTokensSyntaxKind.KUsing;
				case "configuration":
					return TestLexerModeTokensSyntaxKind.KConfiguration;
				case "properties":
					return TestLexerModeTokensSyntaxKind.KProperties;
				case "template":
					return TestLexerModeTokensSyntaxKind.KTemplate;
				case "function":
					return TestLexerModeTokensSyntaxKind.KFunction;
				case "extern":
					return TestLexerModeTokensSyntaxKind.KExtern;
				case "return":
					return TestLexerModeTokensSyntaxKind.KReturn;
				case "switch":
					return TestLexerModeTokensSyntaxKind.KSwitch;
				case "case":
					return TestLexerModeTokensSyntaxKind.KCase;
				case "type":
					return TestLexerModeTokensSyntaxKind.KType;
				case "void":
					return TestLexerModeTokensSyntaxKind.KVoid;
				case "end":
					return TestLexerModeTokensSyntaxKind.KEnd;
				case "for":
					return TestLexerModeTokensSyntaxKind.KFor;
				case "foreach":
					return TestLexerModeTokensSyntaxKind.KForEach;
				case "in":
					return TestLexerModeTokensSyntaxKind.KIn;
				case "if":
					return TestLexerModeTokensSyntaxKind.KIf;
				case "else":
					return TestLexerModeTokensSyntaxKind.KElse;
				case "repeat":
					return TestLexerModeTokensSyntaxKind.KRepeat;
				case "until":
					return TestLexerModeTokensSyntaxKind.KUntil;
				case "while":
					return TestLexerModeTokensSyntaxKind.KWhile;
				case "loop":
					return TestLexerModeTokensSyntaxKind.KLoop;
				case "hasloop":
					return TestLexerModeTokensSyntaxKind.KHasLoop;
				case "where":
					return TestLexerModeTokensSyntaxKind.KWhere;
				case "orderby":
					return TestLexerModeTokensSyntaxKind.KOrderBy;
				case "descending":
					return TestLexerModeTokensSyntaxKind.KDescending;
				case "separator":
					return TestLexerModeTokensSyntaxKind.KSeparator;
				case "null":
					return TestLexerModeTokensSyntaxKind.KNull;
				case "true":
					return TestLexerModeTokensSyntaxKind.KTrue;
				case "false":
					return TestLexerModeTokensSyntaxKind.KFalse;
				case "bool":
					return TestLexerModeTokensSyntaxKind.KBool;
				case "byte":
					return TestLexerModeTokensSyntaxKind.KByte;
				case "char":
					return TestLexerModeTokensSyntaxKind.KChar;
				case "decimal":
					return TestLexerModeTokensSyntaxKind.KDecimal;
				case "double":
					return TestLexerModeTokensSyntaxKind.KDouble;
				case "float":
					return TestLexerModeTokensSyntaxKind.KFloat;
				case "int":
					return TestLexerModeTokensSyntaxKind.KInt;
				case "long":
					return TestLexerModeTokensSyntaxKind.KLong;
				case "object":
					return TestLexerModeTokensSyntaxKind.KObject;
				case "sbyte":
					return TestLexerModeTokensSyntaxKind.KSByte;
				case "short":
					return TestLexerModeTokensSyntaxKind.KShort;
				case "string":
					return TestLexerModeTokensSyntaxKind.KString;
				case "uint":
					return TestLexerModeTokensSyntaxKind.KUInt;
				case "ulong":
					return TestLexerModeTokensSyntaxKind.KULong;
				case "ushort":
					return TestLexerModeTokensSyntaxKind.KUShort;
				case "this":
					return TestLexerModeTokensSyntaxKind.KThis;
				case "new":
					return TestLexerModeTokensSyntaxKind.KNew;
				case "is":
					return TestLexerModeTokensSyntaxKind.KIs;
				case "as":
					return TestLexerModeTokensSyntaxKind.KAs;
				case "typeof":
					return TestLexerModeTokensSyntaxKind.KTypeof;
				case "default":
					return TestLexerModeTokensSyntaxKind.KDefault;
				case ";":
					return TestLexerModeTokensSyntaxKind.TSemicolon;
				case ":":
					return TestLexerModeTokensSyntaxKind.TColon;
				case ".":
					return TestLexerModeTokensSyntaxKind.TDot;
				case ",":
					return TestLexerModeTokensSyntaxKind.TComma;
				case "=":
					return TestLexerModeTokensSyntaxKind.TAssign;
				case "+=":
					return TestLexerModeTokensSyntaxKind.TAssignPlus;
				case "-=":
					return TestLexerModeTokensSyntaxKind.TAssignMinus;
				case "*=":
					return TestLexerModeTokensSyntaxKind.TAssignAsterisk;
				case "/=":
					return TestLexerModeTokensSyntaxKind.TAssignSlash;
				case "%=":
					return TestLexerModeTokensSyntaxKind.TAssignPercent;
				case "&=":
					return TestLexerModeTokensSyntaxKind.TAssignAmp;
				case "|=":
					return TestLexerModeTokensSyntaxKind.TAssignPipe;
				case "^=":
					return TestLexerModeTokensSyntaxKind.TAssignHat;
				case "<<=":
					return TestLexerModeTokensSyntaxKind.TAssignLeftShift;
				case ">>=":
					return TestLexerModeTokensSyntaxKind.TAssignRightShift;
				case "(":
					return TestLexerModeTokensSyntaxKind.TOpenParenthesis;
				case ")":
					return TestLexerModeTokensSyntaxKind.TCloseParenthesis;
				case "]":
					return TestLexerModeTokensSyntaxKind.TCloseBracket;
				case "{":
					return TestLexerModeTokensSyntaxKind.TOpenBrace;
				case "}":
					return TestLexerModeTokensSyntaxKind.TCloseBrace;
				case "==":
					return TestLexerModeTokensSyntaxKind.TEquals;
				case "!=":
					return TestLexerModeTokensSyntaxKind.TNotEquals;
				case "=>":
					return TestLexerModeTokensSyntaxKind.TArrow;
				case "->":
					return TestLexerModeTokensSyntaxKind.TSingleArrow;
				case "<":
					return TestLexerModeTokensSyntaxKind.TLessThan;
				case ">":
					return TestLexerModeTokensSyntaxKind.TGreaterThan;
				case "<=":
					return TestLexerModeTokensSyntaxKind.TLessThanOrEquals;
				case ">=":
					return TestLexerModeTokensSyntaxKind.TGreaterThanOrEquals;
				case "?":
					return TestLexerModeTokensSyntaxKind.TQuestion;
				case "+":
					return TestLexerModeTokensSyntaxKind.TPlus;
				case "-":
					return TestLexerModeTokensSyntaxKind.TMinus;
				case "!":
					return TestLexerModeTokensSyntaxKind.TExclamation;
				case "~":
					return TestLexerModeTokensSyntaxKind.TTilde;
				case "/":
					return TestLexerModeTokensSyntaxKind.TSlash;
				case "%":
					return TestLexerModeTokensSyntaxKind.TPercent;
				case "++":
					return TestLexerModeTokensSyntaxKind.TPlusPlus;
				case "--":
					return TestLexerModeTokensSyntaxKind.TMinusMinus;
				case "::":
					return TestLexerModeTokensSyntaxKind.TColonColon;
				case "&":
					return TestLexerModeTokensSyntaxKind.TAmp;
				case "^":
					return TestLexerModeTokensSyntaxKind.THat;
				case "|":
					return TestLexerModeTokensSyntaxKind.TPipe;
				case "&&":
					return TestLexerModeTokensSyntaxKind.TAnd;
				case "^^":
					return TestLexerModeTokensSyntaxKind.TXor;
				case "||":
					return TestLexerModeTokensSyntaxKind.TOr;
				case "??":
					return TestLexerModeTokensSyntaxKind.TQuestionQuestion;
				case "@\"":
					return TestLexerModeTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "\"":
					return TestLexerModeTokensSyntaxKind.LDoubleQuoteVerbatimString;
				default:
					return TestLexerModeTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.KNamespace:
					return "namespace";
				case TestLexerModeTokensSyntaxKind.KGenerator:
					return "generator";
				case TestLexerModeTokensSyntaxKind.KUsing:
					return "using";
				case TestLexerModeTokensSyntaxKind.KConfiguration:
					return "configuration";
				case TestLexerModeTokensSyntaxKind.KProperties:
					return "properties";
				case TestLexerModeTokensSyntaxKind.KTemplate:
					return "template";
				case TestLexerModeTokensSyntaxKind.KFunction:
					return "function";
				case TestLexerModeTokensSyntaxKind.KExtern:
					return "extern";
				case TestLexerModeTokensSyntaxKind.KReturn:
					return "return";
				case TestLexerModeTokensSyntaxKind.KSwitch:
					return "switch";
				case TestLexerModeTokensSyntaxKind.KCase:
					return "case";
				case TestLexerModeTokensSyntaxKind.KType:
					return "type";
				case TestLexerModeTokensSyntaxKind.KVoid:
					return "void";
				case TestLexerModeTokensSyntaxKind.KEnd:
					return "end";
				case TestLexerModeTokensSyntaxKind.KFor:
					return "for";
				case TestLexerModeTokensSyntaxKind.KForEach:
					return "foreach";
				case TestLexerModeTokensSyntaxKind.KIn:
					return "in";
				case TestLexerModeTokensSyntaxKind.KIf:
					return "if";
				case TestLexerModeTokensSyntaxKind.KElse:
					return "else";
				case TestLexerModeTokensSyntaxKind.KRepeat:
					return "repeat";
				case TestLexerModeTokensSyntaxKind.KUntil:
					return "until";
				case TestLexerModeTokensSyntaxKind.KWhile:
					return "while";
				case TestLexerModeTokensSyntaxKind.KLoop:
					return "loop";
				case TestLexerModeTokensSyntaxKind.KHasLoop:
					return "hasloop";
				case TestLexerModeTokensSyntaxKind.KWhere:
					return "where";
				case TestLexerModeTokensSyntaxKind.KOrderBy:
					return "orderby";
				case TestLexerModeTokensSyntaxKind.KDescending:
					return "descending";
				case TestLexerModeTokensSyntaxKind.KSeparator:
					return "separator";
				case TestLexerModeTokensSyntaxKind.KNull:
					return "null";
				case TestLexerModeTokensSyntaxKind.KTrue:
					return "true";
				case TestLexerModeTokensSyntaxKind.KFalse:
					return "false";
				case TestLexerModeTokensSyntaxKind.KBool:
					return "bool";
				case TestLexerModeTokensSyntaxKind.KByte:
					return "byte";
				case TestLexerModeTokensSyntaxKind.KChar:
					return "char";
				case TestLexerModeTokensSyntaxKind.KDecimal:
					return "decimal";
				case TestLexerModeTokensSyntaxKind.KDouble:
					return "double";
				case TestLexerModeTokensSyntaxKind.KFloat:
					return "float";
				case TestLexerModeTokensSyntaxKind.KInt:
					return "int";
				case TestLexerModeTokensSyntaxKind.KLong:
					return "long";
				case TestLexerModeTokensSyntaxKind.KObject:
					return "object";
				case TestLexerModeTokensSyntaxKind.KSByte:
					return "sbyte";
				case TestLexerModeTokensSyntaxKind.KShort:
					return "short";
				case TestLexerModeTokensSyntaxKind.KString:
					return "string";
				case TestLexerModeTokensSyntaxKind.KUInt:
					return "uint";
				case TestLexerModeTokensSyntaxKind.KULong:
					return "ulong";
				case TestLexerModeTokensSyntaxKind.KUShort:
					return "ushort";
				case TestLexerModeTokensSyntaxKind.KThis:
					return "this";
				case TestLexerModeTokensSyntaxKind.KNew:
					return "new";
				case TestLexerModeTokensSyntaxKind.KIs:
					return "is";
				case TestLexerModeTokensSyntaxKind.KAs:
					return "as";
				case TestLexerModeTokensSyntaxKind.KTypeof:
					return "typeof";
				case TestLexerModeTokensSyntaxKind.KDefault:
					return "default";
				case TestLexerModeTokensSyntaxKind.TSemicolon:
					return ";";
				case TestLexerModeTokensSyntaxKind.TColon:
					return ":";
				case TestLexerModeTokensSyntaxKind.TDot:
					return ".";
				case TestLexerModeTokensSyntaxKind.TComma:
					return ",";
				case TestLexerModeTokensSyntaxKind.TAssign:
					return "=";
				case TestLexerModeTokensSyntaxKind.TAssignPlus:
					return "+=";
				case TestLexerModeTokensSyntaxKind.TAssignMinus:
					return "-=";
				case TestLexerModeTokensSyntaxKind.TAssignAsterisk:
					return "*=";
				case TestLexerModeTokensSyntaxKind.TAssignSlash:
					return "/=";
				case TestLexerModeTokensSyntaxKind.TAssignPercent:
					return "%=";
				case TestLexerModeTokensSyntaxKind.TAssignAmp:
					return "&=";
				case TestLexerModeTokensSyntaxKind.TAssignPipe:
					return "|=";
				case TestLexerModeTokensSyntaxKind.TAssignHat:
					return "^=";
				case TestLexerModeTokensSyntaxKind.TAssignLeftShift:
					return "<<=";
				case TestLexerModeTokensSyntaxKind.TAssignRightShift:
					return ">>=";
				case TestLexerModeTokensSyntaxKind.TOpenParenthesis:
					return "(";
				case TestLexerModeTokensSyntaxKind.TCloseParenthesis:
					return ")";
				case TestLexerModeTokensSyntaxKind.TCloseBracket:
					return "]";
				case TestLexerModeTokensSyntaxKind.TOpenBrace:
					return "{";
				case TestLexerModeTokensSyntaxKind.TCloseBrace:
					return "}";
				case TestLexerModeTokensSyntaxKind.TEquals:
					return "==";
				case TestLexerModeTokensSyntaxKind.TNotEquals:
					return "!=";
				case TestLexerModeTokensSyntaxKind.TArrow:
					return "=>";
				case TestLexerModeTokensSyntaxKind.TSingleArrow:
					return "->";
				case TestLexerModeTokensSyntaxKind.TLessThan:
					return "<";
				case TestLexerModeTokensSyntaxKind.TGreaterThan:
					return ">";
				case TestLexerModeTokensSyntaxKind.TLessThanOrEquals:
					return "<=";
				case TestLexerModeTokensSyntaxKind.TGreaterThanOrEquals:
					return ">=";
				case TestLexerModeTokensSyntaxKind.TQuestion:
					return "?";
				case TestLexerModeTokensSyntaxKind.TPlus:
					return "+";
				case TestLexerModeTokensSyntaxKind.TMinus:
					return "-";
				case TestLexerModeTokensSyntaxKind.TExclamation:
					return "!";
				case TestLexerModeTokensSyntaxKind.TTilde:
					return "~";
				case TestLexerModeTokensSyntaxKind.TSlash:
					return "/";
				case TestLexerModeTokensSyntaxKind.TPercent:
					return "%";
				case TestLexerModeTokensSyntaxKind.TPlusPlus:
					return "++";
				case TestLexerModeTokensSyntaxKind.TMinusMinus:
					return "--";
				case TestLexerModeTokensSyntaxKind.TColonColon:
					return "::";
				case TestLexerModeTokensSyntaxKind.TAmp:
					return "&";
				case TestLexerModeTokensSyntaxKind.THat:
					return "^";
				case TestLexerModeTokensSyntaxKind.TPipe:
					return "|";
				case TestLexerModeTokensSyntaxKind.TAnd:
					return "&&";
				case TestLexerModeTokensSyntaxKind.TXor:
					return "^^";
				case TestLexerModeTokensSyntaxKind.TOr:
					return "||";
				case TestLexerModeTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case TestLexerModeTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case TestLexerModeTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				default:
					return string.Empty;
			}
		}

		public TestLexerModeTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<TestLexerModeTokensSyntaxKind>(rawKind));
		}

		public TestLexerModeTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.KNamespace:
				case TestLexerModeTokensSyntaxKind.KGenerator:
				case TestLexerModeTokensSyntaxKind.KUsing:
				case TestLexerModeTokensSyntaxKind.KConfiguration:
				case TestLexerModeTokensSyntaxKind.KProperties:
				case TestLexerModeTokensSyntaxKind.KTemplate:
				case TestLexerModeTokensSyntaxKind.KFunction:
				case TestLexerModeTokensSyntaxKind.KExtern:
				case TestLexerModeTokensSyntaxKind.KReturn:
				case TestLexerModeTokensSyntaxKind.KSwitch:
				case TestLexerModeTokensSyntaxKind.KCase:
				case TestLexerModeTokensSyntaxKind.KType:
				case TestLexerModeTokensSyntaxKind.KVoid:
				case TestLexerModeTokensSyntaxKind.KEnd:
				case TestLexerModeTokensSyntaxKind.KFor:
				case TestLexerModeTokensSyntaxKind.KForEach:
				case TestLexerModeTokensSyntaxKind.KIn:
				case TestLexerModeTokensSyntaxKind.KIf:
				case TestLexerModeTokensSyntaxKind.KElse:
				case TestLexerModeTokensSyntaxKind.KRepeat:
				case TestLexerModeTokensSyntaxKind.KUntil:
				case TestLexerModeTokensSyntaxKind.KWhile:
				case TestLexerModeTokensSyntaxKind.KLoop:
				case TestLexerModeTokensSyntaxKind.KHasLoop:
				case TestLexerModeTokensSyntaxKind.KWhere:
				case TestLexerModeTokensSyntaxKind.KOrderBy:
				case TestLexerModeTokensSyntaxKind.KDescending:
				case TestLexerModeTokensSyntaxKind.KSeparator:
				case TestLexerModeTokensSyntaxKind.KNull:
				case TestLexerModeTokensSyntaxKind.KTrue:
				case TestLexerModeTokensSyntaxKind.KFalse:
				case TestLexerModeTokensSyntaxKind.KBool:
				case TestLexerModeTokensSyntaxKind.KByte:
				case TestLexerModeTokensSyntaxKind.KChar:
				case TestLexerModeTokensSyntaxKind.KDecimal:
				case TestLexerModeTokensSyntaxKind.KDouble:
				case TestLexerModeTokensSyntaxKind.KFloat:
				case TestLexerModeTokensSyntaxKind.KInt:
				case TestLexerModeTokensSyntaxKind.KLong:
				case TestLexerModeTokensSyntaxKind.KObject:
				case TestLexerModeTokensSyntaxKind.KSByte:
				case TestLexerModeTokensSyntaxKind.KShort:
				case TestLexerModeTokensSyntaxKind.KString:
				case TestLexerModeTokensSyntaxKind.KUInt:
				case TestLexerModeTokensSyntaxKind.KULong:
				case TestLexerModeTokensSyntaxKind.KUShort:
				case TestLexerModeTokensSyntaxKind.KThis:
				case TestLexerModeTokensSyntaxKind.KNew:
				case TestLexerModeTokensSyntaxKind.KIs:
				case TestLexerModeTokensSyntaxKind.KAs:
				case TestLexerModeTokensSyntaxKind.KTypeof:
				case TestLexerModeTokensSyntaxKind.KDefault:
					return TestLexerModeTokenKind.ReservedKeyword;
				case TestLexerModeTokensSyntaxKind.TSemicolon:
				case TestLexerModeTokensSyntaxKind.TColon:
				case TestLexerModeTokensSyntaxKind.TDot:
				case TestLexerModeTokensSyntaxKind.TComma:
				case TestLexerModeTokensSyntaxKind.TAssign:
				case TestLexerModeTokensSyntaxKind.TAssignPlus:
				case TestLexerModeTokensSyntaxKind.TAssignMinus:
				case TestLexerModeTokensSyntaxKind.TAssignAsterisk:
				case TestLexerModeTokensSyntaxKind.TAssignSlash:
				case TestLexerModeTokensSyntaxKind.TAssignPercent:
				case TestLexerModeTokensSyntaxKind.TAssignAmp:
				case TestLexerModeTokensSyntaxKind.TAssignPipe:
				case TestLexerModeTokensSyntaxKind.TAssignHat:
				case TestLexerModeTokensSyntaxKind.TAssignLeftShift:
				case TestLexerModeTokensSyntaxKind.TAssignRightShift:
				case TestLexerModeTokensSyntaxKind.TOpenParenthesis:
				case TestLexerModeTokensSyntaxKind.TCloseParenthesis:
				case TestLexerModeTokensSyntaxKind.TOpenBracket:
				case TestLexerModeTokensSyntaxKind.TCloseBracket:
				case TestLexerModeTokensSyntaxKind.TOpenBrace:
				case TestLexerModeTokensSyntaxKind.TCloseBrace:
				case TestLexerModeTokensSyntaxKind.TEquals:
				case TestLexerModeTokensSyntaxKind.TNotEquals:
				case TestLexerModeTokensSyntaxKind.TArrow:
				case TestLexerModeTokensSyntaxKind.TSingleArrow:
				case TestLexerModeTokensSyntaxKind.TLessThan:
				case TestLexerModeTokensSyntaxKind.TGreaterThan:
				case TestLexerModeTokensSyntaxKind.TLessThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TGreaterThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TQuestion:
				case TestLexerModeTokensSyntaxKind.TPlus:
				case TestLexerModeTokensSyntaxKind.TMinus:
				case TestLexerModeTokensSyntaxKind.TExclamation:
				case TestLexerModeTokensSyntaxKind.TTilde:
				case TestLexerModeTokensSyntaxKind.TAsterisk:
				case TestLexerModeTokensSyntaxKind.TSlash:
				case TestLexerModeTokensSyntaxKind.TPercent:
				case TestLexerModeTokensSyntaxKind.TPlusPlus:
				case TestLexerModeTokensSyntaxKind.TMinusMinus:
				case TestLexerModeTokensSyntaxKind.TColonColon:
				case TestLexerModeTokensSyntaxKind.TAmp:
				case TestLexerModeTokensSyntaxKind.THat:
				case TestLexerModeTokensSyntaxKind.TPipe:
				case TestLexerModeTokensSyntaxKind.TAnd:
				case TestLexerModeTokensSyntaxKind.TXor:
				case TestLexerModeTokensSyntaxKind.TOr:
				case TestLexerModeTokensSyntaxKind.TQuestionQuestion:
					return TestLexerModeTokenKind.Operator;
				case TestLexerModeTokensSyntaxKind.IdentifierNormal:
					return TestLexerModeTokenKind.Identifier;
				case TestLexerModeTokensSyntaxKind.LInteger:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LDecimal:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LScientific:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LDateTimeOffset:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LDateTime:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LDate:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LTime:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LChar:
					return TestLexerModeTokenKind.String;
				case TestLexerModeTokensSyntaxKind.LRegularString:
					return TestLexerModeTokenKind.String;
				case TestLexerModeTokensSyntaxKind.LGuid:
					return TestLexerModeTokenKind.Number;
				case TestLexerModeTokensSyntaxKind.LWhitespace:
					return TestLexerModeTokenKind.Whitespace;
				case TestLexerModeTokensSyntaxKind.LCrLf:
					return TestLexerModeTokenKind.Whitespace;
				case TestLexerModeTokensSyntaxKind.LLineComment:
					return TestLexerModeTokenKind.GeneralComment;
				case TestLexerModeTokensSyntaxKind.LMultiLineComment:
					return TestLexerModeTokenKind.GeneralComment;
				case TestLexerModeTokensSyntaxKind.TH_TCloseParenthesis:
					return TestLexerModeTokenKind.Operator;
				case TestLexerModeTokensSyntaxKind.KEndTemplate:
					return TestLexerModeTokenKind.ReservedKeyword;
				case TestLexerModeTokensSyntaxKind.LTemplateLineControl:
					return TestLexerModeTokenKind.TemplateControl;
				case TestLexerModeTokensSyntaxKind.LTemplateOutput:
					return TestLexerModeTokenKind.TemplateOutput;
				case TestLexerModeTokensSyntaxKind.LTemplateCrLf:
					return TestLexerModeTokenKind.TemplateOutput;
				case TestLexerModeTokensSyntaxKind.LTemplateLineBreak:
					return TestLexerModeTokenKind.TemplateOutput;
				case TestLexerModeTokensSyntaxKind.TTemplateStatementStart:
					return TestLexerModeTokenKind.TemplateControl;
				case TestLexerModeTokensSyntaxKind.TTemplateStatementEnd:
					return TestLexerModeTokenKind.TemplateControl;
				default:
					return TestLexerModeTokenKind.None;
			}
		}

		public TestLexerModeTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((TestLexerModeLexerMode)rawKind);
		}

		public TestLexerModeTokenKind GetModeTokenKind(TestLexerModeLexerMode kind)
		{
			switch(kind)
			{
				case TestLexerModeLexerMode.MULTILINE_COMMENT:
					return TestLexerModeTokenKind.GeneralComment;
				case TestLexerModeLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return TestLexerModeTokenKind.String;
				case TestLexerModeLexerMode.TEMPLATE_OUTPUT:
					return TestLexerModeTokenKind.TemplateOutput;
				case TestLexerModeLexerMode.TEMPLATE_STATEMENT_COMMENT:
					return TestLexerModeTokenKind.GeneralComment;
				default:
					return TestLexerModeTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LCrLf:
					return true;
				case TestLexerModeTokensSyntaxKind.LLineComment:
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
				case TestLexerModeTokensSyntaxKind.KNamespace:
				case TestLexerModeTokensSyntaxKind.KGenerator:
				case TestLexerModeTokensSyntaxKind.KUsing:
				case TestLexerModeTokensSyntaxKind.KConfiguration:
				case TestLexerModeTokensSyntaxKind.KProperties:
				case TestLexerModeTokensSyntaxKind.KTemplate:
				case TestLexerModeTokensSyntaxKind.KFunction:
				case TestLexerModeTokensSyntaxKind.KExtern:
				case TestLexerModeTokensSyntaxKind.KReturn:
				case TestLexerModeTokensSyntaxKind.KSwitch:
				case TestLexerModeTokensSyntaxKind.KCase:
				case TestLexerModeTokensSyntaxKind.KType:
				case TestLexerModeTokensSyntaxKind.KVoid:
				case TestLexerModeTokensSyntaxKind.KEnd:
				case TestLexerModeTokensSyntaxKind.KFor:
				case TestLexerModeTokensSyntaxKind.KForEach:
				case TestLexerModeTokensSyntaxKind.KIn:
				case TestLexerModeTokensSyntaxKind.KIf:
				case TestLexerModeTokensSyntaxKind.KElse:
				case TestLexerModeTokensSyntaxKind.KRepeat:
				case TestLexerModeTokensSyntaxKind.KUntil:
				case TestLexerModeTokensSyntaxKind.KWhile:
				case TestLexerModeTokensSyntaxKind.KLoop:
				case TestLexerModeTokensSyntaxKind.KHasLoop:
				case TestLexerModeTokensSyntaxKind.KWhere:
				case TestLexerModeTokensSyntaxKind.KOrderBy:
				case TestLexerModeTokensSyntaxKind.KDescending:
				case TestLexerModeTokensSyntaxKind.KSeparator:
				case TestLexerModeTokensSyntaxKind.KNull:
				case TestLexerModeTokensSyntaxKind.KTrue:
				case TestLexerModeTokensSyntaxKind.KFalse:
				case TestLexerModeTokensSyntaxKind.KBool:
				case TestLexerModeTokensSyntaxKind.KByte:
				case TestLexerModeTokensSyntaxKind.KChar:
				case TestLexerModeTokensSyntaxKind.KDecimal:
				case TestLexerModeTokensSyntaxKind.KDouble:
				case TestLexerModeTokensSyntaxKind.KFloat:
				case TestLexerModeTokensSyntaxKind.KInt:
				case TestLexerModeTokensSyntaxKind.KLong:
				case TestLexerModeTokensSyntaxKind.KObject:
				case TestLexerModeTokensSyntaxKind.KSByte:
				case TestLexerModeTokensSyntaxKind.KShort:
				case TestLexerModeTokensSyntaxKind.KString:
				case TestLexerModeTokensSyntaxKind.KUInt:
				case TestLexerModeTokensSyntaxKind.KULong:
				case TestLexerModeTokensSyntaxKind.KUShort:
				case TestLexerModeTokensSyntaxKind.KThis:
				case TestLexerModeTokensSyntaxKind.KNew:
				case TestLexerModeTokensSyntaxKind.KIs:
				case TestLexerModeTokensSyntaxKind.KAs:
				case TestLexerModeTokensSyntaxKind.KTypeof:
				case TestLexerModeTokensSyntaxKind.KDefault:
					return true;
				case TestLexerModeTokensSyntaxKind.KEndTemplate:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return TestLexerModeTokensSyntaxKind.KNamespace;
				yield return TestLexerModeTokensSyntaxKind.KGenerator;
				yield return TestLexerModeTokensSyntaxKind.KUsing;
				yield return TestLexerModeTokensSyntaxKind.KConfiguration;
				yield return TestLexerModeTokensSyntaxKind.KProperties;
				yield return TestLexerModeTokensSyntaxKind.KTemplate;
				yield return TestLexerModeTokensSyntaxKind.KFunction;
				yield return TestLexerModeTokensSyntaxKind.KExtern;
				yield return TestLexerModeTokensSyntaxKind.KReturn;
				yield return TestLexerModeTokensSyntaxKind.KSwitch;
				yield return TestLexerModeTokensSyntaxKind.KCase;
				yield return TestLexerModeTokensSyntaxKind.KType;
				yield return TestLexerModeTokensSyntaxKind.KVoid;
				yield return TestLexerModeTokensSyntaxKind.KEnd;
				yield return TestLexerModeTokensSyntaxKind.KFor;
				yield return TestLexerModeTokensSyntaxKind.KForEach;
				yield return TestLexerModeTokensSyntaxKind.KIn;
				yield return TestLexerModeTokensSyntaxKind.KIf;
				yield return TestLexerModeTokensSyntaxKind.KElse;
				yield return TestLexerModeTokensSyntaxKind.KRepeat;
				yield return TestLexerModeTokensSyntaxKind.KUntil;
				yield return TestLexerModeTokensSyntaxKind.KWhile;
				yield return TestLexerModeTokensSyntaxKind.KLoop;
				yield return TestLexerModeTokensSyntaxKind.KHasLoop;
				yield return TestLexerModeTokensSyntaxKind.KWhere;
				yield return TestLexerModeTokensSyntaxKind.KOrderBy;
				yield return TestLexerModeTokensSyntaxKind.KDescending;
				yield return TestLexerModeTokensSyntaxKind.KSeparator;
				yield return TestLexerModeTokensSyntaxKind.KNull;
				yield return TestLexerModeTokensSyntaxKind.KTrue;
				yield return TestLexerModeTokensSyntaxKind.KFalse;
				yield return TestLexerModeTokensSyntaxKind.KBool;
				yield return TestLexerModeTokensSyntaxKind.KByte;
				yield return TestLexerModeTokensSyntaxKind.KChar;
				yield return TestLexerModeTokensSyntaxKind.KDecimal;
				yield return TestLexerModeTokensSyntaxKind.KDouble;
				yield return TestLexerModeTokensSyntaxKind.KFloat;
				yield return TestLexerModeTokensSyntaxKind.KInt;
				yield return TestLexerModeTokensSyntaxKind.KLong;
				yield return TestLexerModeTokensSyntaxKind.KObject;
				yield return TestLexerModeTokensSyntaxKind.KSByte;
				yield return TestLexerModeTokensSyntaxKind.KShort;
				yield return TestLexerModeTokensSyntaxKind.KString;
				yield return TestLexerModeTokensSyntaxKind.KUInt;
				yield return TestLexerModeTokensSyntaxKind.KULong;
				yield return TestLexerModeTokensSyntaxKind.KUShort;
				yield return TestLexerModeTokensSyntaxKind.KThis;
				yield return TestLexerModeTokensSyntaxKind.KNew;
				yield return TestLexerModeTokensSyntaxKind.KIs;
				yield return TestLexerModeTokensSyntaxKind.KAs;
				yield return TestLexerModeTokensSyntaxKind.KTypeof;
				yield return TestLexerModeTokensSyntaxKind.KDefault;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return TestLexerModeTokensSyntaxKind.KNamespace;
				case "generator":
					return TestLexerModeTokensSyntaxKind.KGenerator;
				case "using":
					return TestLexerModeTokensSyntaxKind.KUsing;
				case "configuration":
					return TestLexerModeTokensSyntaxKind.KConfiguration;
				case "properties":
					return TestLexerModeTokensSyntaxKind.KProperties;
				case "template":
					return TestLexerModeTokensSyntaxKind.KTemplate;
				case "function":
					return TestLexerModeTokensSyntaxKind.KFunction;
				case "extern":
					return TestLexerModeTokensSyntaxKind.KExtern;
				case "return":
					return TestLexerModeTokensSyntaxKind.KReturn;
				case "switch":
					return TestLexerModeTokensSyntaxKind.KSwitch;
				case "case":
					return TestLexerModeTokensSyntaxKind.KCase;
				case "type":
					return TestLexerModeTokensSyntaxKind.KType;
				case "void":
					return TestLexerModeTokensSyntaxKind.KVoid;
				case "end":
					return TestLexerModeTokensSyntaxKind.KEnd;
				case "for":
					return TestLexerModeTokensSyntaxKind.KFor;
				case "foreach":
					return TestLexerModeTokensSyntaxKind.KForEach;
				case "in":
					return TestLexerModeTokensSyntaxKind.KIn;
				case "if":
					return TestLexerModeTokensSyntaxKind.KIf;
				case "else":
					return TestLexerModeTokensSyntaxKind.KElse;
				case "repeat":
					return TestLexerModeTokensSyntaxKind.KRepeat;
				case "until":
					return TestLexerModeTokensSyntaxKind.KUntil;
				case "while":
					return TestLexerModeTokensSyntaxKind.KWhile;
				case "loop":
					return TestLexerModeTokensSyntaxKind.KLoop;
				case "hasloop":
					return TestLexerModeTokensSyntaxKind.KHasLoop;
				case "where":
					return TestLexerModeTokensSyntaxKind.KWhere;
				case "orderby":
					return TestLexerModeTokensSyntaxKind.KOrderBy;
				case "descending":
					return TestLexerModeTokensSyntaxKind.KDescending;
				case "separator":
					return TestLexerModeTokensSyntaxKind.KSeparator;
				case "null":
					return TestLexerModeTokensSyntaxKind.KNull;
				case "true":
					return TestLexerModeTokensSyntaxKind.KTrue;
				case "false":
					return TestLexerModeTokensSyntaxKind.KFalse;
				case "bool":
					return TestLexerModeTokensSyntaxKind.KBool;
				case "byte":
					return TestLexerModeTokensSyntaxKind.KByte;
				case "char":
					return TestLexerModeTokensSyntaxKind.KChar;
				case "decimal":
					return TestLexerModeTokensSyntaxKind.KDecimal;
				case "double":
					return TestLexerModeTokensSyntaxKind.KDouble;
				case "float":
					return TestLexerModeTokensSyntaxKind.KFloat;
				case "int":
					return TestLexerModeTokensSyntaxKind.KInt;
				case "long":
					return TestLexerModeTokensSyntaxKind.KLong;
				case "object":
					return TestLexerModeTokensSyntaxKind.KObject;
				case "sbyte":
					return TestLexerModeTokensSyntaxKind.KSByte;
				case "short":
					return TestLexerModeTokensSyntaxKind.KShort;
				case "string":
					return TestLexerModeTokensSyntaxKind.KString;
				case "uint":
					return TestLexerModeTokensSyntaxKind.KUInt;
				case "ulong":
					return TestLexerModeTokensSyntaxKind.KULong;
				case "ushort":
					return TestLexerModeTokensSyntaxKind.KUShort;
				case "this":
					return TestLexerModeTokensSyntaxKind.KThis;
				case "new":
					return TestLexerModeTokensSyntaxKind.KNew;
				case "is":
					return TestLexerModeTokensSyntaxKind.KIs;
				case "as":
					return TestLexerModeTokensSyntaxKind.KAs;
				case "typeof":
					return TestLexerModeTokensSyntaxKind.KTypeof;
				case "default":
					return TestLexerModeTokensSyntaxKind.KDefault;
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
				case TestLexerModeTokensSyntaxKind.IdentifierNormal:
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
		public bool IsOperator(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.TSemicolon:
				case TestLexerModeTokensSyntaxKind.TColon:
				case TestLexerModeTokensSyntaxKind.TDot:
				case TestLexerModeTokensSyntaxKind.TComma:
				case TestLexerModeTokensSyntaxKind.TAssign:
				case TestLexerModeTokensSyntaxKind.TAssignPlus:
				case TestLexerModeTokensSyntaxKind.TAssignMinus:
				case TestLexerModeTokensSyntaxKind.TAssignAsterisk:
				case TestLexerModeTokensSyntaxKind.TAssignSlash:
				case TestLexerModeTokensSyntaxKind.TAssignPercent:
				case TestLexerModeTokensSyntaxKind.TAssignAmp:
				case TestLexerModeTokensSyntaxKind.TAssignPipe:
				case TestLexerModeTokensSyntaxKind.TAssignHat:
				case TestLexerModeTokensSyntaxKind.TAssignLeftShift:
				case TestLexerModeTokensSyntaxKind.TAssignRightShift:
				case TestLexerModeTokensSyntaxKind.TOpenParenthesis:
				case TestLexerModeTokensSyntaxKind.TCloseParenthesis:
				case TestLexerModeTokensSyntaxKind.TOpenBracket:
				case TestLexerModeTokensSyntaxKind.TCloseBracket:
				case TestLexerModeTokensSyntaxKind.TOpenBrace:
				case TestLexerModeTokensSyntaxKind.TCloseBrace:
				case TestLexerModeTokensSyntaxKind.TEquals:
				case TestLexerModeTokensSyntaxKind.TNotEquals:
				case TestLexerModeTokensSyntaxKind.TArrow:
				case TestLexerModeTokensSyntaxKind.TSingleArrow:
				case TestLexerModeTokensSyntaxKind.TLessThan:
				case TestLexerModeTokensSyntaxKind.TGreaterThan:
				case TestLexerModeTokensSyntaxKind.TLessThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TGreaterThanOrEquals:
				case TestLexerModeTokensSyntaxKind.TQuestion:
				case TestLexerModeTokensSyntaxKind.TPlus:
				case TestLexerModeTokensSyntaxKind.TMinus:
				case TestLexerModeTokensSyntaxKind.TExclamation:
				case TestLexerModeTokensSyntaxKind.TTilde:
				case TestLexerModeTokensSyntaxKind.TAsterisk:
				case TestLexerModeTokensSyntaxKind.TSlash:
				case TestLexerModeTokensSyntaxKind.TPercent:
				case TestLexerModeTokensSyntaxKind.TPlusPlus:
				case TestLexerModeTokensSyntaxKind.TMinusMinus:
				case TestLexerModeTokensSyntaxKind.TColonColon:
				case TestLexerModeTokensSyntaxKind.TAmp:
				case TestLexerModeTokensSyntaxKind.THat:
				case TestLexerModeTokensSyntaxKind.TPipe:
				case TestLexerModeTokensSyntaxKind.TAnd:
				case TestLexerModeTokensSyntaxKind.TXor:
				case TestLexerModeTokensSyntaxKind.TOr:
				case TestLexerModeTokensSyntaxKind.TQuestionQuestion:
					return true;
				case TestLexerModeTokensSyntaxKind.TH_TCloseParenthesis:
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
		public bool IsNumber(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LInteger:
					return true;
				case TestLexerModeTokensSyntaxKind.LDecimal:
					return true;
				case TestLexerModeTokensSyntaxKind.LScientific:
					return true;
				case TestLexerModeTokensSyntaxKind.LDateTimeOffset:
					return true;
				case TestLexerModeTokensSyntaxKind.LDateTime:
					return true;
				case TestLexerModeTokensSyntaxKind.LDate:
					return true;
				case TestLexerModeTokensSyntaxKind.LTime:
					return true;
				case TestLexerModeTokensSyntaxKind.LGuid:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LChar:
					return true;
				case TestLexerModeTokensSyntaxKind.LRegularString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LWhitespace:
					return true;
				case TestLexerModeTokensSyntaxKind.LCrLf:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LLineComment:
					return true;
				case TestLexerModeTokensSyntaxKind.LMultiLineComment:
					return true;
				default:
					return false;
			}
		}
		public bool IsTemplateControl(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LTemplateLineControl:
					return true;
				case TestLexerModeTokensSyntaxKind.TTemplateStatementStart:
					return true;
				case TestLexerModeTokensSyntaxKind.TTemplateStatementEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsTemplateOutput(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestLexerModeTokensSyntaxKind.LTemplateOutput:
					return true;
				case TestLexerModeTokensSyntaxKind.LTemplateCrLf:
					return true;
				case TestLexerModeTokensSyntaxKind.LTemplateLineBreak:
					return true;
				default:
					return false;
			}
		}
	}
}


// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaGenerator.Syntax
{
	public enum MetaGeneratorTokenKind : int
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

	public enum MetaGeneratorLexerMode : int
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

	public class MetaGeneratorTokensSyntaxFacts : SyntaxFacts
	{
        public MetaGeneratorTokensSyntaxFacts() 
            : base(typeof(MetaGeneratorTokensSyntaxKind))
        {
        }

        protected MetaGeneratorTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (MetaGeneratorTokensSyntaxKind)MetaGeneratorTokensSyntaxKind.LWhitespace;
        public override SyntaxKind DefaultEndOfLineKind => (MetaGeneratorTokensSyntaxKind)MetaGeneratorTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (MetaGeneratorTokensSyntaxKind)MetaGeneratorTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (MetaGeneratorTokensSyntaxKind)MetaGeneratorTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.Eof:
				case MetaGeneratorTokensSyntaxKind.KNamespace:
				case MetaGeneratorTokensSyntaxKind.KGenerator:
				case MetaGeneratorTokensSyntaxKind.KUsing:
				case MetaGeneratorTokensSyntaxKind.KConfiguration:
				case MetaGeneratorTokensSyntaxKind.KProperties:
				case MetaGeneratorTokensSyntaxKind.KTemplate:
				case MetaGeneratorTokensSyntaxKind.KFunction:
				case MetaGeneratorTokensSyntaxKind.KExtern:
				case MetaGeneratorTokensSyntaxKind.KReturn:
				case MetaGeneratorTokensSyntaxKind.KSwitch:
				case MetaGeneratorTokensSyntaxKind.KCase:
				case MetaGeneratorTokensSyntaxKind.KType:
				case MetaGeneratorTokensSyntaxKind.KVoid:
				case MetaGeneratorTokensSyntaxKind.KEnd:
				case MetaGeneratorTokensSyntaxKind.KFor:
				case MetaGeneratorTokensSyntaxKind.KForEach:
				case MetaGeneratorTokensSyntaxKind.KIn:
				case MetaGeneratorTokensSyntaxKind.KIf:
				case MetaGeneratorTokensSyntaxKind.KElse:
				case MetaGeneratorTokensSyntaxKind.KRepeat:
				case MetaGeneratorTokensSyntaxKind.KUntil:
				case MetaGeneratorTokensSyntaxKind.KWhile:
				case MetaGeneratorTokensSyntaxKind.KLoop:
				case MetaGeneratorTokensSyntaxKind.KHasLoop:
				case MetaGeneratorTokensSyntaxKind.KWhere:
				case MetaGeneratorTokensSyntaxKind.KOrderBy:
				case MetaGeneratorTokensSyntaxKind.KDescending:
				case MetaGeneratorTokensSyntaxKind.KSeparator:
				case MetaGeneratorTokensSyntaxKind.KNull:
				case MetaGeneratorTokensSyntaxKind.KTrue:
				case MetaGeneratorTokensSyntaxKind.KFalse:
				case MetaGeneratorTokensSyntaxKind.KBool:
				case MetaGeneratorTokensSyntaxKind.KByte:
				case MetaGeneratorTokensSyntaxKind.KChar:
				case MetaGeneratorTokensSyntaxKind.KDecimal:
				case MetaGeneratorTokensSyntaxKind.KDouble:
				case MetaGeneratorTokensSyntaxKind.KFloat:
				case MetaGeneratorTokensSyntaxKind.KInt:
				case MetaGeneratorTokensSyntaxKind.KLong:
				case MetaGeneratorTokensSyntaxKind.KObject:
				case MetaGeneratorTokensSyntaxKind.KSByte:
				case MetaGeneratorTokensSyntaxKind.KShort:
				case MetaGeneratorTokensSyntaxKind.KString:
				case MetaGeneratorTokensSyntaxKind.KUInt:
				case MetaGeneratorTokensSyntaxKind.KULong:
				case MetaGeneratorTokensSyntaxKind.KUShort:
				case MetaGeneratorTokensSyntaxKind.KThis:
				case MetaGeneratorTokensSyntaxKind.KNew:
				case MetaGeneratorTokensSyntaxKind.KIs:
				case MetaGeneratorTokensSyntaxKind.KAs:
				case MetaGeneratorTokensSyntaxKind.KTypeof:
				case MetaGeneratorTokensSyntaxKind.KDefault:
				case MetaGeneratorTokensSyntaxKind.TSemicolon:
				case MetaGeneratorTokensSyntaxKind.TColon:
				case MetaGeneratorTokensSyntaxKind.TDot:
				case MetaGeneratorTokensSyntaxKind.TComma:
				case MetaGeneratorTokensSyntaxKind.TAssign:
				case MetaGeneratorTokensSyntaxKind.TAssignPlus:
				case MetaGeneratorTokensSyntaxKind.TAssignMinus:
				case MetaGeneratorTokensSyntaxKind.TAssignAsterisk:
				case MetaGeneratorTokensSyntaxKind.TAssignSlash:
				case MetaGeneratorTokensSyntaxKind.TAssignPercent:
				case MetaGeneratorTokensSyntaxKind.TAssignAmp:
				case MetaGeneratorTokensSyntaxKind.TAssignPipe:
				case MetaGeneratorTokensSyntaxKind.TAssignHat:
				case MetaGeneratorTokensSyntaxKind.TAssignLeftShift:
				case MetaGeneratorTokensSyntaxKind.TAssignRightShift:
				case MetaGeneratorTokensSyntaxKind.TOpenParenthesis:
				case MetaGeneratorTokensSyntaxKind.TCloseParenthesis:
				case MetaGeneratorTokensSyntaxKind.TOpenBracket:
				case MetaGeneratorTokensSyntaxKind.TCloseBracket:
				case MetaGeneratorTokensSyntaxKind.TOpenBrace:
				case MetaGeneratorTokensSyntaxKind.TCloseBrace:
				case MetaGeneratorTokensSyntaxKind.TEquals:
				case MetaGeneratorTokensSyntaxKind.TNotEquals:
				case MetaGeneratorTokensSyntaxKind.TArrow:
				case MetaGeneratorTokensSyntaxKind.TSingleArrow:
				case MetaGeneratorTokensSyntaxKind.TLessThan:
				case MetaGeneratorTokensSyntaxKind.TGreaterThan:
				case MetaGeneratorTokensSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TQuestion:
				case MetaGeneratorTokensSyntaxKind.TPlus:
				case MetaGeneratorTokensSyntaxKind.TMinus:
				case MetaGeneratorTokensSyntaxKind.TExclamation:
				case MetaGeneratorTokensSyntaxKind.TTilde:
				case MetaGeneratorTokensSyntaxKind.TAsterisk:
				case MetaGeneratorTokensSyntaxKind.TSlash:
				case MetaGeneratorTokensSyntaxKind.TPercent:
				case MetaGeneratorTokensSyntaxKind.TPlusPlus:
				case MetaGeneratorTokensSyntaxKind.TMinusMinus:
				case MetaGeneratorTokensSyntaxKind.TColonColon:
				case MetaGeneratorTokensSyntaxKind.TAmp:
				case MetaGeneratorTokensSyntaxKind.THat:
				case MetaGeneratorTokensSyntaxKind.TPipe:
				case MetaGeneratorTokensSyntaxKind.TAnd:
				case MetaGeneratorTokensSyntaxKind.TXor:
				case MetaGeneratorTokensSyntaxKind.TOr:
				case MetaGeneratorTokensSyntaxKind.TQuestionQuestion:
				case MetaGeneratorTokensSyntaxKind.IdentifierNormal:
				case MetaGeneratorTokensSyntaxKind.IntegerLiteral:
				case MetaGeneratorTokensSyntaxKind.DecimalLiteral:
				case MetaGeneratorTokensSyntaxKind.ScientificLiteral:
				case MetaGeneratorTokensSyntaxKind.DateTimeOffsetLiteral:
				case MetaGeneratorTokensSyntaxKind.DateTimeLiteral:
				case MetaGeneratorTokensSyntaxKind.DateLiteral:
				case MetaGeneratorTokensSyntaxKind.TimeLiteral:
				case MetaGeneratorTokensSyntaxKind.CharLiteral:
				case MetaGeneratorTokensSyntaxKind.RegularStringLiteral:
				case MetaGeneratorTokensSyntaxKind.GuidLiteral:
				case MetaGeneratorTokensSyntaxKind.LUtf8Bom:
				case MetaGeneratorTokensSyntaxKind.LWhitespace:
				case MetaGeneratorTokensSyntaxKind.LCrLf:
				case MetaGeneratorTokensSyntaxKind.LLineBreak:
				case MetaGeneratorTokensSyntaxKind.LLineComment:
				case MetaGeneratorTokensSyntaxKind.LMultiLineComment:
				case MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteral:
				case MetaGeneratorTokensSyntaxKind.TH_TOpenParenthesis:
				case MetaGeneratorTokensSyntaxKind.TH_TCloseParenthesis:
				case MetaGeneratorTokensSyntaxKind.KEndTemplate:
				case MetaGeneratorTokensSyntaxKind.TemplateLineControl:
				case MetaGeneratorTokensSyntaxKind.TemplateOutput:
				case MetaGeneratorTokensSyntaxKind.TemplateCrLf:
				case MetaGeneratorTokensSyntaxKind.TemplateLineBreak:
				case MetaGeneratorTokensSyntaxKind.TemplateStatementStart:
				case MetaGeneratorTokensSyntaxKind.TemplateStatementEnd:
				case MetaGeneratorTokensSyntaxKind.TS_TOpenBracket:
				case MetaGeneratorTokensSyntaxKind.TS_TCloseBracket:
				case MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaGeneratorTokensSyntaxKind.COMMENT_START:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.KNamespace:
				case MetaGeneratorTokensSyntaxKind.KGenerator:
				case MetaGeneratorTokensSyntaxKind.KUsing:
				case MetaGeneratorTokensSyntaxKind.KConfiguration:
				case MetaGeneratorTokensSyntaxKind.KProperties:
				case MetaGeneratorTokensSyntaxKind.KTemplate:
				case MetaGeneratorTokensSyntaxKind.KFunction:
				case MetaGeneratorTokensSyntaxKind.KExtern:
				case MetaGeneratorTokensSyntaxKind.KReturn:
				case MetaGeneratorTokensSyntaxKind.KSwitch:
				case MetaGeneratorTokensSyntaxKind.KCase:
				case MetaGeneratorTokensSyntaxKind.KType:
				case MetaGeneratorTokensSyntaxKind.KVoid:
				case MetaGeneratorTokensSyntaxKind.KEnd:
				case MetaGeneratorTokensSyntaxKind.KFor:
				case MetaGeneratorTokensSyntaxKind.KForEach:
				case MetaGeneratorTokensSyntaxKind.KIn:
				case MetaGeneratorTokensSyntaxKind.KIf:
				case MetaGeneratorTokensSyntaxKind.KElse:
				case MetaGeneratorTokensSyntaxKind.KRepeat:
				case MetaGeneratorTokensSyntaxKind.KUntil:
				case MetaGeneratorTokensSyntaxKind.KWhile:
				case MetaGeneratorTokensSyntaxKind.KLoop:
				case MetaGeneratorTokensSyntaxKind.KHasLoop:
				case MetaGeneratorTokensSyntaxKind.KWhere:
				case MetaGeneratorTokensSyntaxKind.KOrderBy:
				case MetaGeneratorTokensSyntaxKind.KDescending:
				case MetaGeneratorTokensSyntaxKind.KSeparator:
				case MetaGeneratorTokensSyntaxKind.KNull:
				case MetaGeneratorTokensSyntaxKind.KTrue:
				case MetaGeneratorTokensSyntaxKind.KFalse:
				case MetaGeneratorTokensSyntaxKind.KBool:
				case MetaGeneratorTokensSyntaxKind.KByte:
				case MetaGeneratorTokensSyntaxKind.KChar:
				case MetaGeneratorTokensSyntaxKind.KDecimal:
				case MetaGeneratorTokensSyntaxKind.KDouble:
				case MetaGeneratorTokensSyntaxKind.KFloat:
				case MetaGeneratorTokensSyntaxKind.KInt:
				case MetaGeneratorTokensSyntaxKind.KLong:
				case MetaGeneratorTokensSyntaxKind.KObject:
				case MetaGeneratorTokensSyntaxKind.KSByte:
				case MetaGeneratorTokensSyntaxKind.KShort:
				case MetaGeneratorTokensSyntaxKind.KString:
				case MetaGeneratorTokensSyntaxKind.KUInt:
				case MetaGeneratorTokensSyntaxKind.KULong:
				case MetaGeneratorTokensSyntaxKind.KUShort:
				case MetaGeneratorTokensSyntaxKind.KThis:
				case MetaGeneratorTokensSyntaxKind.KNew:
				case MetaGeneratorTokensSyntaxKind.KIs:
				case MetaGeneratorTokensSyntaxKind.KAs:
				case MetaGeneratorTokensSyntaxKind.KTypeof:
				case MetaGeneratorTokensSyntaxKind.KDefault:
				case MetaGeneratorTokensSyntaxKind.TSemicolon:
				case MetaGeneratorTokensSyntaxKind.TColon:
				case MetaGeneratorTokensSyntaxKind.TDot:
				case MetaGeneratorTokensSyntaxKind.TComma:
				case MetaGeneratorTokensSyntaxKind.TAssign:
				case MetaGeneratorTokensSyntaxKind.TAssignPlus:
				case MetaGeneratorTokensSyntaxKind.TAssignMinus:
				case MetaGeneratorTokensSyntaxKind.TAssignAsterisk:
				case MetaGeneratorTokensSyntaxKind.TAssignSlash:
				case MetaGeneratorTokensSyntaxKind.TAssignPercent:
				case MetaGeneratorTokensSyntaxKind.TAssignAmp:
				case MetaGeneratorTokensSyntaxKind.TAssignPipe:
				case MetaGeneratorTokensSyntaxKind.TAssignHat:
				case MetaGeneratorTokensSyntaxKind.TAssignLeftShift:
				case MetaGeneratorTokensSyntaxKind.TAssignRightShift:
				case MetaGeneratorTokensSyntaxKind.TOpenParenthesis:
				case MetaGeneratorTokensSyntaxKind.TCloseParenthesis:
				case MetaGeneratorTokensSyntaxKind.TCloseBracket:
				case MetaGeneratorTokensSyntaxKind.TOpenBrace:
				case MetaGeneratorTokensSyntaxKind.TCloseBrace:
				case MetaGeneratorTokensSyntaxKind.TEquals:
				case MetaGeneratorTokensSyntaxKind.TNotEquals:
				case MetaGeneratorTokensSyntaxKind.TArrow:
				case MetaGeneratorTokensSyntaxKind.TSingleArrow:
				case MetaGeneratorTokensSyntaxKind.TLessThan:
				case MetaGeneratorTokensSyntaxKind.TGreaterThan:
				case MetaGeneratorTokensSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TQuestion:
				case MetaGeneratorTokensSyntaxKind.TPlus:
				case MetaGeneratorTokensSyntaxKind.TMinus:
				case MetaGeneratorTokensSyntaxKind.TExclamation:
				case MetaGeneratorTokensSyntaxKind.TTilde:
				case MetaGeneratorTokensSyntaxKind.TSlash:
				case MetaGeneratorTokensSyntaxKind.TPercent:
				case MetaGeneratorTokensSyntaxKind.TPlusPlus:
				case MetaGeneratorTokensSyntaxKind.TMinusMinus:
				case MetaGeneratorTokensSyntaxKind.TColonColon:
				case MetaGeneratorTokensSyntaxKind.TAmp:
				case MetaGeneratorTokensSyntaxKind.THat:
				case MetaGeneratorTokensSyntaxKind.TPipe:
				case MetaGeneratorTokensSyntaxKind.TAnd:
				case MetaGeneratorTokensSyntaxKind.TXor:
				case MetaGeneratorTokensSyntaxKind.TOr:
				case MetaGeneratorTokensSyntaxKind.TQuestionQuestion:
				case MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteral:
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
					return MetaGeneratorTokensSyntaxKind.KNamespace;
				case "generator":
					return MetaGeneratorTokensSyntaxKind.KGenerator;
				case "using":
					return MetaGeneratorTokensSyntaxKind.KUsing;
				case "configuration":
					return MetaGeneratorTokensSyntaxKind.KConfiguration;
				case "properties":
					return MetaGeneratorTokensSyntaxKind.KProperties;
				case "template":
					return MetaGeneratorTokensSyntaxKind.KTemplate;
				case "function":
					return MetaGeneratorTokensSyntaxKind.KFunction;
				case "extern":
					return MetaGeneratorTokensSyntaxKind.KExtern;
				case "return":
					return MetaGeneratorTokensSyntaxKind.KReturn;
				case "switch":
					return MetaGeneratorTokensSyntaxKind.KSwitch;
				case "case":
					return MetaGeneratorTokensSyntaxKind.KCase;
				case "type":
					return MetaGeneratorTokensSyntaxKind.KType;
				case "void":
					return MetaGeneratorTokensSyntaxKind.KVoid;
				case "end":
					return MetaGeneratorTokensSyntaxKind.KEnd;
				case "for":
					return MetaGeneratorTokensSyntaxKind.KFor;
				case "foreach":
					return MetaGeneratorTokensSyntaxKind.KForEach;
				case "in":
					return MetaGeneratorTokensSyntaxKind.KIn;
				case "if":
					return MetaGeneratorTokensSyntaxKind.KIf;
				case "else":
					return MetaGeneratorTokensSyntaxKind.KElse;
				case "repeat":
					return MetaGeneratorTokensSyntaxKind.KRepeat;
				case "until":
					return MetaGeneratorTokensSyntaxKind.KUntil;
				case "while":
					return MetaGeneratorTokensSyntaxKind.KWhile;
				case "loop":
					return MetaGeneratorTokensSyntaxKind.KLoop;
				case "hasloop":
					return MetaGeneratorTokensSyntaxKind.KHasLoop;
				case "where":
					return MetaGeneratorTokensSyntaxKind.KWhere;
				case "orderby":
					return MetaGeneratorTokensSyntaxKind.KOrderBy;
				case "descending":
					return MetaGeneratorTokensSyntaxKind.KDescending;
				case "separator":
					return MetaGeneratorTokensSyntaxKind.KSeparator;
				case "null":
					return MetaGeneratorTokensSyntaxKind.KNull;
				case "true":
					return MetaGeneratorTokensSyntaxKind.KTrue;
				case "false":
					return MetaGeneratorTokensSyntaxKind.KFalse;
				case "bool":
					return MetaGeneratorTokensSyntaxKind.KBool;
				case "byte":
					return MetaGeneratorTokensSyntaxKind.KByte;
				case "char":
					return MetaGeneratorTokensSyntaxKind.KChar;
				case "decimal":
					return MetaGeneratorTokensSyntaxKind.KDecimal;
				case "double":
					return MetaGeneratorTokensSyntaxKind.KDouble;
				case "float":
					return MetaGeneratorTokensSyntaxKind.KFloat;
				case "int":
					return MetaGeneratorTokensSyntaxKind.KInt;
				case "long":
					return MetaGeneratorTokensSyntaxKind.KLong;
				case "object":
					return MetaGeneratorTokensSyntaxKind.KObject;
				case "sbyte":
					return MetaGeneratorTokensSyntaxKind.KSByte;
				case "short":
					return MetaGeneratorTokensSyntaxKind.KShort;
				case "string":
					return MetaGeneratorTokensSyntaxKind.KString;
				case "uint":
					return MetaGeneratorTokensSyntaxKind.KUInt;
				case "ulong":
					return MetaGeneratorTokensSyntaxKind.KULong;
				case "ushort":
					return MetaGeneratorTokensSyntaxKind.KUShort;
				case "this":
					return MetaGeneratorTokensSyntaxKind.KThis;
				case "new":
					return MetaGeneratorTokensSyntaxKind.KNew;
				case "is":
					return MetaGeneratorTokensSyntaxKind.KIs;
				case "as":
					return MetaGeneratorTokensSyntaxKind.KAs;
				case "typeof":
					return MetaGeneratorTokensSyntaxKind.KTypeof;
				case "default":
					return MetaGeneratorTokensSyntaxKind.KDefault;
				case ";":
					return MetaGeneratorTokensSyntaxKind.TSemicolon;
				case ":":
					return MetaGeneratorTokensSyntaxKind.TColon;
				case ".":
					return MetaGeneratorTokensSyntaxKind.TDot;
				case ",":
					return MetaGeneratorTokensSyntaxKind.TComma;
				case "=":
					return MetaGeneratorTokensSyntaxKind.TAssign;
				case "+=":
					return MetaGeneratorTokensSyntaxKind.TAssignPlus;
				case "-=":
					return MetaGeneratorTokensSyntaxKind.TAssignMinus;
				case "*=":
					return MetaGeneratorTokensSyntaxKind.TAssignAsterisk;
				case "/=":
					return MetaGeneratorTokensSyntaxKind.TAssignSlash;
				case "%=":
					return MetaGeneratorTokensSyntaxKind.TAssignPercent;
				case "&=":
					return MetaGeneratorTokensSyntaxKind.TAssignAmp;
				case "|=":
					return MetaGeneratorTokensSyntaxKind.TAssignPipe;
				case "^=":
					return MetaGeneratorTokensSyntaxKind.TAssignHat;
				case "<<=":
					return MetaGeneratorTokensSyntaxKind.TAssignLeftShift;
				case ">>=":
					return MetaGeneratorTokensSyntaxKind.TAssignRightShift;
				case "(":
					return MetaGeneratorTokensSyntaxKind.TOpenParenthesis;
				case ")":
					return MetaGeneratorTokensSyntaxKind.TCloseParenthesis;
				case "]":
					return MetaGeneratorTokensSyntaxKind.TCloseBracket;
				case "{":
					return MetaGeneratorTokensSyntaxKind.TOpenBrace;
				case "}":
					return MetaGeneratorTokensSyntaxKind.TCloseBrace;
				case "==":
					return MetaGeneratorTokensSyntaxKind.TEquals;
				case "!=":
					return MetaGeneratorTokensSyntaxKind.TNotEquals;
				case "=>":
					return MetaGeneratorTokensSyntaxKind.TArrow;
				case "->":
					return MetaGeneratorTokensSyntaxKind.TSingleArrow;
				case "<":
					return MetaGeneratorTokensSyntaxKind.TLessThan;
				case ">":
					return MetaGeneratorTokensSyntaxKind.TGreaterThan;
				case "<=":
					return MetaGeneratorTokensSyntaxKind.TLessThanOrEquals;
				case ">=":
					return MetaGeneratorTokensSyntaxKind.TGreaterThanOrEquals;
				case "?":
					return MetaGeneratorTokensSyntaxKind.TQuestion;
				case "+":
					return MetaGeneratorTokensSyntaxKind.TPlus;
				case "-":
					return MetaGeneratorTokensSyntaxKind.TMinus;
				case "!":
					return MetaGeneratorTokensSyntaxKind.TExclamation;
				case "~":
					return MetaGeneratorTokensSyntaxKind.TTilde;
				case "/":
					return MetaGeneratorTokensSyntaxKind.TSlash;
				case "%":
					return MetaGeneratorTokensSyntaxKind.TPercent;
				case "++":
					return MetaGeneratorTokensSyntaxKind.TPlusPlus;
				case "--":
					return MetaGeneratorTokensSyntaxKind.TMinusMinus;
				case "::":
					return MetaGeneratorTokensSyntaxKind.TColonColon;
				case "&":
					return MetaGeneratorTokensSyntaxKind.TAmp;
				case "^":
					return MetaGeneratorTokensSyntaxKind.THat;
				case "|":
					return MetaGeneratorTokensSyntaxKind.TPipe;
				case "&&":
					return MetaGeneratorTokensSyntaxKind.TAnd;
				case "^^":
					return MetaGeneratorTokensSyntaxKind.TXor;
				case "||":
					return MetaGeneratorTokensSyntaxKind.TOr;
				case "??":
					return MetaGeneratorTokensSyntaxKind.TQuestionQuestion;
				case "@\"":
					return MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "\"":
					return MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteral;
				default:
					return MetaGeneratorTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.KNamespace:
					return "namespace";
				case MetaGeneratorTokensSyntaxKind.KGenerator:
					return "generator";
				case MetaGeneratorTokensSyntaxKind.KUsing:
					return "using";
				case MetaGeneratorTokensSyntaxKind.KConfiguration:
					return "configuration";
				case MetaGeneratorTokensSyntaxKind.KProperties:
					return "properties";
				case MetaGeneratorTokensSyntaxKind.KTemplate:
					return "template";
				case MetaGeneratorTokensSyntaxKind.KFunction:
					return "function";
				case MetaGeneratorTokensSyntaxKind.KExtern:
					return "extern";
				case MetaGeneratorTokensSyntaxKind.KReturn:
					return "return";
				case MetaGeneratorTokensSyntaxKind.KSwitch:
					return "switch";
				case MetaGeneratorTokensSyntaxKind.KCase:
					return "case";
				case MetaGeneratorTokensSyntaxKind.KType:
					return "type";
				case MetaGeneratorTokensSyntaxKind.KVoid:
					return "void";
				case MetaGeneratorTokensSyntaxKind.KEnd:
					return "end";
				case MetaGeneratorTokensSyntaxKind.KFor:
					return "for";
				case MetaGeneratorTokensSyntaxKind.KForEach:
					return "foreach";
				case MetaGeneratorTokensSyntaxKind.KIn:
					return "in";
				case MetaGeneratorTokensSyntaxKind.KIf:
					return "if";
				case MetaGeneratorTokensSyntaxKind.KElse:
					return "else";
				case MetaGeneratorTokensSyntaxKind.KRepeat:
					return "repeat";
				case MetaGeneratorTokensSyntaxKind.KUntil:
					return "until";
				case MetaGeneratorTokensSyntaxKind.KWhile:
					return "while";
				case MetaGeneratorTokensSyntaxKind.KLoop:
					return "loop";
				case MetaGeneratorTokensSyntaxKind.KHasLoop:
					return "hasloop";
				case MetaGeneratorTokensSyntaxKind.KWhere:
					return "where";
				case MetaGeneratorTokensSyntaxKind.KOrderBy:
					return "orderby";
				case MetaGeneratorTokensSyntaxKind.KDescending:
					return "descending";
				case MetaGeneratorTokensSyntaxKind.KSeparator:
					return "separator";
				case MetaGeneratorTokensSyntaxKind.KNull:
					return "null";
				case MetaGeneratorTokensSyntaxKind.KTrue:
					return "true";
				case MetaGeneratorTokensSyntaxKind.KFalse:
					return "false";
				case MetaGeneratorTokensSyntaxKind.KBool:
					return "bool";
				case MetaGeneratorTokensSyntaxKind.KByte:
					return "byte";
				case MetaGeneratorTokensSyntaxKind.KChar:
					return "char";
				case MetaGeneratorTokensSyntaxKind.KDecimal:
					return "decimal";
				case MetaGeneratorTokensSyntaxKind.KDouble:
					return "double";
				case MetaGeneratorTokensSyntaxKind.KFloat:
					return "float";
				case MetaGeneratorTokensSyntaxKind.KInt:
					return "int";
				case MetaGeneratorTokensSyntaxKind.KLong:
					return "long";
				case MetaGeneratorTokensSyntaxKind.KObject:
					return "object";
				case MetaGeneratorTokensSyntaxKind.KSByte:
					return "sbyte";
				case MetaGeneratorTokensSyntaxKind.KShort:
					return "short";
				case MetaGeneratorTokensSyntaxKind.KString:
					return "string";
				case MetaGeneratorTokensSyntaxKind.KUInt:
					return "uint";
				case MetaGeneratorTokensSyntaxKind.KULong:
					return "ulong";
				case MetaGeneratorTokensSyntaxKind.KUShort:
					return "ushort";
				case MetaGeneratorTokensSyntaxKind.KThis:
					return "this";
				case MetaGeneratorTokensSyntaxKind.KNew:
					return "new";
				case MetaGeneratorTokensSyntaxKind.KIs:
					return "is";
				case MetaGeneratorTokensSyntaxKind.KAs:
					return "as";
				case MetaGeneratorTokensSyntaxKind.KTypeof:
					return "typeof";
				case MetaGeneratorTokensSyntaxKind.KDefault:
					return "default";
				case MetaGeneratorTokensSyntaxKind.TSemicolon:
					return ";";
				case MetaGeneratorTokensSyntaxKind.TColon:
					return ":";
				case MetaGeneratorTokensSyntaxKind.TDot:
					return ".";
				case MetaGeneratorTokensSyntaxKind.TComma:
					return ",";
				case MetaGeneratorTokensSyntaxKind.TAssign:
					return "=";
				case MetaGeneratorTokensSyntaxKind.TAssignPlus:
					return "+=";
				case MetaGeneratorTokensSyntaxKind.TAssignMinus:
					return "-=";
				case MetaGeneratorTokensSyntaxKind.TAssignAsterisk:
					return "*=";
				case MetaGeneratorTokensSyntaxKind.TAssignSlash:
					return "/=";
				case MetaGeneratorTokensSyntaxKind.TAssignPercent:
					return "%=";
				case MetaGeneratorTokensSyntaxKind.TAssignAmp:
					return "&=";
				case MetaGeneratorTokensSyntaxKind.TAssignPipe:
					return "|=";
				case MetaGeneratorTokensSyntaxKind.TAssignHat:
					return "^=";
				case MetaGeneratorTokensSyntaxKind.TAssignLeftShift:
					return "<<=";
				case MetaGeneratorTokensSyntaxKind.TAssignRightShift:
					return ">>=";
				case MetaGeneratorTokensSyntaxKind.TOpenParenthesis:
					return "(";
				case MetaGeneratorTokensSyntaxKind.TCloseParenthesis:
					return ")";
				case MetaGeneratorTokensSyntaxKind.TCloseBracket:
					return "]";
				case MetaGeneratorTokensSyntaxKind.TOpenBrace:
					return "{";
				case MetaGeneratorTokensSyntaxKind.TCloseBrace:
					return "}";
				case MetaGeneratorTokensSyntaxKind.TEquals:
					return "==";
				case MetaGeneratorTokensSyntaxKind.TNotEquals:
					return "!=";
				case MetaGeneratorTokensSyntaxKind.TArrow:
					return "=>";
				case MetaGeneratorTokensSyntaxKind.TSingleArrow:
					return "->";
				case MetaGeneratorTokensSyntaxKind.TLessThan:
					return "<";
				case MetaGeneratorTokensSyntaxKind.TGreaterThan:
					return ">";
				case MetaGeneratorTokensSyntaxKind.TLessThanOrEquals:
					return "<=";
				case MetaGeneratorTokensSyntaxKind.TGreaterThanOrEquals:
					return ">=";
				case MetaGeneratorTokensSyntaxKind.TQuestion:
					return "?";
				case MetaGeneratorTokensSyntaxKind.TPlus:
					return "+";
				case MetaGeneratorTokensSyntaxKind.TMinus:
					return "-";
				case MetaGeneratorTokensSyntaxKind.TExclamation:
					return "!";
				case MetaGeneratorTokensSyntaxKind.TTilde:
					return "~";
				case MetaGeneratorTokensSyntaxKind.TSlash:
					return "/";
				case MetaGeneratorTokensSyntaxKind.TPercent:
					return "%";
				case MetaGeneratorTokensSyntaxKind.TPlusPlus:
					return "++";
				case MetaGeneratorTokensSyntaxKind.TMinusMinus:
					return "--";
				case MetaGeneratorTokensSyntaxKind.TColonColon:
					return "::";
				case MetaGeneratorTokensSyntaxKind.TAmp:
					return "&";
				case MetaGeneratorTokensSyntaxKind.THat:
					return "^";
				case MetaGeneratorTokensSyntaxKind.TPipe:
					return "|";
				case MetaGeneratorTokensSyntaxKind.TAnd:
					return "&&";
				case MetaGeneratorTokensSyntaxKind.TXor:
					return "^^";
				case MetaGeneratorTokensSyntaxKind.TOr:
					return "||";
				case MetaGeneratorTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case MetaGeneratorTokensSyntaxKind.DoubleQuoteVerbatimStringLiteral:
					return "\"";
				default:
					return string.Empty;
			}
		}

		public MetaGeneratorTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<MetaGeneratorTokensSyntaxKind>(rawKind));
		}

		public MetaGeneratorTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.KNamespace:
				case MetaGeneratorTokensSyntaxKind.KGenerator:
				case MetaGeneratorTokensSyntaxKind.KUsing:
				case MetaGeneratorTokensSyntaxKind.KConfiguration:
				case MetaGeneratorTokensSyntaxKind.KProperties:
				case MetaGeneratorTokensSyntaxKind.KTemplate:
				case MetaGeneratorTokensSyntaxKind.KFunction:
				case MetaGeneratorTokensSyntaxKind.KExtern:
				case MetaGeneratorTokensSyntaxKind.KReturn:
				case MetaGeneratorTokensSyntaxKind.KSwitch:
				case MetaGeneratorTokensSyntaxKind.KCase:
				case MetaGeneratorTokensSyntaxKind.KType:
				case MetaGeneratorTokensSyntaxKind.KVoid:
				case MetaGeneratorTokensSyntaxKind.KEnd:
				case MetaGeneratorTokensSyntaxKind.KFor:
				case MetaGeneratorTokensSyntaxKind.KForEach:
				case MetaGeneratorTokensSyntaxKind.KIn:
				case MetaGeneratorTokensSyntaxKind.KIf:
				case MetaGeneratorTokensSyntaxKind.KElse:
				case MetaGeneratorTokensSyntaxKind.KRepeat:
				case MetaGeneratorTokensSyntaxKind.KUntil:
				case MetaGeneratorTokensSyntaxKind.KWhile:
				case MetaGeneratorTokensSyntaxKind.KLoop:
				case MetaGeneratorTokensSyntaxKind.KHasLoop:
				case MetaGeneratorTokensSyntaxKind.KWhere:
				case MetaGeneratorTokensSyntaxKind.KOrderBy:
				case MetaGeneratorTokensSyntaxKind.KDescending:
				case MetaGeneratorTokensSyntaxKind.KSeparator:
				case MetaGeneratorTokensSyntaxKind.KNull:
				case MetaGeneratorTokensSyntaxKind.KTrue:
				case MetaGeneratorTokensSyntaxKind.KFalse:
				case MetaGeneratorTokensSyntaxKind.KBool:
				case MetaGeneratorTokensSyntaxKind.KByte:
				case MetaGeneratorTokensSyntaxKind.KChar:
				case MetaGeneratorTokensSyntaxKind.KDecimal:
				case MetaGeneratorTokensSyntaxKind.KDouble:
				case MetaGeneratorTokensSyntaxKind.KFloat:
				case MetaGeneratorTokensSyntaxKind.KInt:
				case MetaGeneratorTokensSyntaxKind.KLong:
				case MetaGeneratorTokensSyntaxKind.KObject:
				case MetaGeneratorTokensSyntaxKind.KSByte:
				case MetaGeneratorTokensSyntaxKind.KShort:
				case MetaGeneratorTokensSyntaxKind.KString:
				case MetaGeneratorTokensSyntaxKind.KUInt:
				case MetaGeneratorTokensSyntaxKind.KULong:
				case MetaGeneratorTokensSyntaxKind.KUShort:
				case MetaGeneratorTokensSyntaxKind.KThis:
				case MetaGeneratorTokensSyntaxKind.KNew:
				case MetaGeneratorTokensSyntaxKind.KIs:
				case MetaGeneratorTokensSyntaxKind.KAs:
				case MetaGeneratorTokensSyntaxKind.KTypeof:
				case MetaGeneratorTokensSyntaxKind.KDefault:
					return MetaGeneratorTokenKind.ReservedKeyword;
				case MetaGeneratorTokensSyntaxKind.TSemicolon:
				case MetaGeneratorTokensSyntaxKind.TColon:
				case MetaGeneratorTokensSyntaxKind.TDot:
				case MetaGeneratorTokensSyntaxKind.TComma:
				case MetaGeneratorTokensSyntaxKind.TAssign:
				case MetaGeneratorTokensSyntaxKind.TAssignPlus:
				case MetaGeneratorTokensSyntaxKind.TAssignMinus:
				case MetaGeneratorTokensSyntaxKind.TAssignAsterisk:
				case MetaGeneratorTokensSyntaxKind.TAssignSlash:
				case MetaGeneratorTokensSyntaxKind.TAssignPercent:
				case MetaGeneratorTokensSyntaxKind.TAssignAmp:
				case MetaGeneratorTokensSyntaxKind.TAssignPipe:
				case MetaGeneratorTokensSyntaxKind.TAssignHat:
				case MetaGeneratorTokensSyntaxKind.TAssignLeftShift:
				case MetaGeneratorTokensSyntaxKind.TAssignRightShift:
				case MetaGeneratorTokensSyntaxKind.TOpenParenthesis:
				case MetaGeneratorTokensSyntaxKind.TCloseParenthesis:
				case MetaGeneratorTokensSyntaxKind.TOpenBracket:
				case MetaGeneratorTokensSyntaxKind.TCloseBracket:
				case MetaGeneratorTokensSyntaxKind.TOpenBrace:
				case MetaGeneratorTokensSyntaxKind.TCloseBrace:
				case MetaGeneratorTokensSyntaxKind.TEquals:
				case MetaGeneratorTokensSyntaxKind.TNotEquals:
				case MetaGeneratorTokensSyntaxKind.TArrow:
				case MetaGeneratorTokensSyntaxKind.TSingleArrow:
				case MetaGeneratorTokensSyntaxKind.TLessThan:
				case MetaGeneratorTokensSyntaxKind.TGreaterThan:
				case MetaGeneratorTokensSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TQuestion:
				case MetaGeneratorTokensSyntaxKind.TPlus:
				case MetaGeneratorTokensSyntaxKind.TMinus:
				case MetaGeneratorTokensSyntaxKind.TExclamation:
				case MetaGeneratorTokensSyntaxKind.TTilde:
				case MetaGeneratorTokensSyntaxKind.TAsterisk:
				case MetaGeneratorTokensSyntaxKind.TSlash:
				case MetaGeneratorTokensSyntaxKind.TPercent:
				case MetaGeneratorTokensSyntaxKind.TPlusPlus:
				case MetaGeneratorTokensSyntaxKind.TMinusMinus:
				case MetaGeneratorTokensSyntaxKind.TColonColon:
				case MetaGeneratorTokensSyntaxKind.TAmp:
				case MetaGeneratorTokensSyntaxKind.THat:
				case MetaGeneratorTokensSyntaxKind.TPipe:
				case MetaGeneratorTokensSyntaxKind.TAnd:
				case MetaGeneratorTokensSyntaxKind.TXor:
				case MetaGeneratorTokensSyntaxKind.TOr:
				case MetaGeneratorTokensSyntaxKind.TQuestionQuestion:
					return MetaGeneratorTokenKind.Operator;
				case MetaGeneratorTokensSyntaxKind.IdentifierNormal:
					return MetaGeneratorTokenKind.Identifier;
				case MetaGeneratorTokensSyntaxKind.IntegerLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.DecimalLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.ScientificLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.DateTimeOffsetLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.DateTimeLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.DateLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.TimeLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.CharLiteral:
					return MetaGeneratorTokenKind.String;
				case MetaGeneratorTokensSyntaxKind.RegularStringLiteral:
					return MetaGeneratorTokenKind.String;
				case MetaGeneratorTokensSyntaxKind.GuidLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorTokensSyntaxKind.LWhitespace:
					return MetaGeneratorTokenKind.Whitespace;
				case MetaGeneratorTokensSyntaxKind.LCrLf:
					return MetaGeneratorTokenKind.Whitespace;
				case MetaGeneratorTokensSyntaxKind.LLineComment:
					return MetaGeneratorTokenKind.GeneralComment;
				case MetaGeneratorTokensSyntaxKind.LMultiLineComment:
					return MetaGeneratorTokenKind.GeneralComment;
				case MetaGeneratorTokensSyntaxKind.TH_TCloseParenthesis:
					return MetaGeneratorTokenKind.Operator;
				case MetaGeneratorTokensSyntaxKind.KEndTemplate:
					return MetaGeneratorTokenKind.ReservedKeyword;
				case MetaGeneratorTokensSyntaxKind.TemplateLineControl:
					return MetaGeneratorTokenKind.TemplateControl;
				case MetaGeneratorTokensSyntaxKind.TemplateOutput:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorTokensSyntaxKind.TemplateCrLf:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorTokensSyntaxKind.TemplateLineBreak:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorTokensSyntaxKind.TemplateStatementStart:
					return MetaGeneratorTokenKind.TemplateControl;
				case MetaGeneratorTokensSyntaxKind.TemplateStatementEnd:
					return MetaGeneratorTokenKind.TemplateControl;
				default:
					return MetaGeneratorTokenKind.None;
			}
		}

		public MetaGeneratorTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((MetaGeneratorLexerMode)rawKind);
		}

		public MetaGeneratorTokenKind GetModeTokenKind(MetaGeneratorLexerMode kind)
		{
			switch(kind)
			{
				case MetaGeneratorLexerMode.MULTILINE_COMMENT:
					return MetaGeneratorTokenKind.GeneralComment;
				case MetaGeneratorLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return MetaGeneratorTokenKind.String;
				case MetaGeneratorLexerMode.TEMPLATE_OUTPUT:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorLexerMode.TEMPLATE_STATEMENT_COMMENT:
					return MetaGeneratorTokenKind.GeneralComment;
				default:
					return MetaGeneratorTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.LCrLf:
					return true;
				case MetaGeneratorTokensSyntaxKind.LLineComment:
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
				case MetaGeneratorTokensSyntaxKind.KNamespace:
				case MetaGeneratorTokensSyntaxKind.KGenerator:
				case MetaGeneratorTokensSyntaxKind.KUsing:
				case MetaGeneratorTokensSyntaxKind.KConfiguration:
				case MetaGeneratorTokensSyntaxKind.KProperties:
				case MetaGeneratorTokensSyntaxKind.KTemplate:
				case MetaGeneratorTokensSyntaxKind.KFunction:
				case MetaGeneratorTokensSyntaxKind.KExtern:
				case MetaGeneratorTokensSyntaxKind.KReturn:
				case MetaGeneratorTokensSyntaxKind.KSwitch:
				case MetaGeneratorTokensSyntaxKind.KCase:
				case MetaGeneratorTokensSyntaxKind.KType:
				case MetaGeneratorTokensSyntaxKind.KVoid:
				case MetaGeneratorTokensSyntaxKind.KEnd:
				case MetaGeneratorTokensSyntaxKind.KFor:
				case MetaGeneratorTokensSyntaxKind.KForEach:
				case MetaGeneratorTokensSyntaxKind.KIn:
				case MetaGeneratorTokensSyntaxKind.KIf:
				case MetaGeneratorTokensSyntaxKind.KElse:
				case MetaGeneratorTokensSyntaxKind.KRepeat:
				case MetaGeneratorTokensSyntaxKind.KUntil:
				case MetaGeneratorTokensSyntaxKind.KWhile:
				case MetaGeneratorTokensSyntaxKind.KLoop:
				case MetaGeneratorTokensSyntaxKind.KHasLoop:
				case MetaGeneratorTokensSyntaxKind.KWhere:
				case MetaGeneratorTokensSyntaxKind.KOrderBy:
				case MetaGeneratorTokensSyntaxKind.KDescending:
				case MetaGeneratorTokensSyntaxKind.KSeparator:
				case MetaGeneratorTokensSyntaxKind.KNull:
				case MetaGeneratorTokensSyntaxKind.KTrue:
				case MetaGeneratorTokensSyntaxKind.KFalse:
				case MetaGeneratorTokensSyntaxKind.KBool:
				case MetaGeneratorTokensSyntaxKind.KByte:
				case MetaGeneratorTokensSyntaxKind.KChar:
				case MetaGeneratorTokensSyntaxKind.KDecimal:
				case MetaGeneratorTokensSyntaxKind.KDouble:
				case MetaGeneratorTokensSyntaxKind.KFloat:
				case MetaGeneratorTokensSyntaxKind.KInt:
				case MetaGeneratorTokensSyntaxKind.KLong:
				case MetaGeneratorTokensSyntaxKind.KObject:
				case MetaGeneratorTokensSyntaxKind.KSByte:
				case MetaGeneratorTokensSyntaxKind.KShort:
				case MetaGeneratorTokensSyntaxKind.KString:
				case MetaGeneratorTokensSyntaxKind.KUInt:
				case MetaGeneratorTokensSyntaxKind.KULong:
				case MetaGeneratorTokensSyntaxKind.KUShort:
				case MetaGeneratorTokensSyntaxKind.KThis:
				case MetaGeneratorTokensSyntaxKind.KNew:
				case MetaGeneratorTokensSyntaxKind.KIs:
				case MetaGeneratorTokensSyntaxKind.KAs:
				case MetaGeneratorTokensSyntaxKind.KTypeof:
				case MetaGeneratorTokensSyntaxKind.KDefault:
					return true;
				case MetaGeneratorTokensSyntaxKind.KEndTemplate:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return MetaGeneratorTokensSyntaxKind.KNamespace;
				yield return MetaGeneratorTokensSyntaxKind.KGenerator;
				yield return MetaGeneratorTokensSyntaxKind.KUsing;
				yield return MetaGeneratorTokensSyntaxKind.KConfiguration;
				yield return MetaGeneratorTokensSyntaxKind.KProperties;
				yield return MetaGeneratorTokensSyntaxKind.KTemplate;
				yield return MetaGeneratorTokensSyntaxKind.KFunction;
				yield return MetaGeneratorTokensSyntaxKind.KExtern;
				yield return MetaGeneratorTokensSyntaxKind.KReturn;
				yield return MetaGeneratorTokensSyntaxKind.KSwitch;
				yield return MetaGeneratorTokensSyntaxKind.KCase;
				yield return MetaGeneratorTokensSyntaxKind.KType;
				yield return MetaGeneratorTokensSyntaxKind.KVoid;
				yield return MetaGeneratorTokensSyntaxKind.KEnd;
				yield return MetaGeneratorTokensSyntaxKind.KFor;
				yield return MetaGeneratorTokensSyntaxKind.KForEach;
				yield return MetaGeneratorTokensSyntaxKind.KIn;
				yield return MetaGeneratorTokensSyntaxKind.KIf;
				yield return MetaGeneratorTokensSyntaxKind.KElse;
				yield return MetaGeneratorTokensSyntaxKind.KRepeat;
				yield return MetaGeneratorTokensSyntaxKind.KUntil;
				yield return MetaGeneratorTokensSyntaxKind.KWhile;
				yield return MetaGeneratorTokensSyntaxKind.KLoop;
				yield return MetaGeneratorTokensSyntaxKind.KHasLoop;
				yield return MetaGeneratorTokensSyntaxKind.KWhere;
				yield return MetaGeneratorTokensSyntaxKind.KOrderBy;
				yield return MetaGeneratorTokensSyntaxKind.KDescending;
				yield return MetaGeneratorTokensSyntaxKind.KSeparator;
				yield return MetaGeneratorTokensSyntaxKind.KNull;
				yield return MetaGeneratorTokensSyntaxKind.KTrue;
				yield return MetaGeneratorTokensSyntaxKind.KFalse;
				yield return MetaGeneratorTokensSyntaxKind.KBool;
				yield return MetaGeneratorTokensSyntaxKind.KByte;
				yield return MetaGeneratorTokensSyntaxKind.KChar;
				yield return MetaGeneratorTokensSyntaxKind.KDecimal;
				yield return MetaGeneratorTokensSyntaxKind.KDouble;
				yield return MetaGeneratorTokensSyntaxKind.KFloat;
				yield return MetaGeneratorTokensSyntaxKind.KInt;
				yield return MetaGeneratorTokensSyntaxKind.KLong;
				yield return MetaGeneratorTokensSyntaxKind.KObject;
				yield return MetaGeneratorTokensSyntaxKind.KSByte;
				yield return MetaGeneratorTokensSyntaxKind.KShort;
				yield return MetaGeneratorTokensSyntaxKind.KString;
				yield return MetaGeneratorTokensSyntaxKind.KUInt;
				yield return MetaGeneratorTokensSyntaxKind.KULong;
				yield return MetaGeneratorTokensSyntaxKind.KUShort;
				yield return MetaGeneratorTokensSyntaxKind.KThis;
				yield return MetaGeneratorTokensSyntaxKind.KNew;
				yield return MetaGeneratorTokensSyntaxKind.KIs;
				yield return MetaGeneratorTokensSyntaxKind.KAs;
				yield return MetaGeneratorTokensSyntaxKind.KTypeof;
				yield return MetaGeneratorTokensSyntaxKind.KDefault;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return MetaGeneratorTokensSyntaxKind.KNamespace;
				case "generator":
					return MetaGeneratorTokensSyntaxKind.KGenerator;
				case "using":
					return MetaGeneratorTokensSyntaxKind.KUsing;
				case "configuration":
					return MetaGeneratorTokensSyntaxKind.KConfiguration;
				case "properties":
					return MetaGeneratorTokensSyntaxKind.KProperties;
				case "template":
					return MetaGeneratorTokensSyntaxKind.KTemplate;
				case "function":
					return MetaGeneratorTokensSyntaxKind.KFunction;
				case "extern":
					return MetaGeneratorTokensSyntaxKind.KExtern;
				case "return":
					return MetaGeneratorTokensSyntaxKind.KReturn;
				case "switch":
					return MetaGeneratorTokensSyntaxKind.KSwitch;
				case "case":
					return MetaGeneratorTokensSyntaxKind.KCase;
				case "type":
					return MetaGeneratorTokensSyntaxKind.KType;
				case "void":
					return MetaGeneratorTokensSyntaxKind.KVoid;
				case "end":
					return MetaGeneratorTokensSyntaxKind.KEnd;
				case "for":
					return MetaGeneratorTokensSyntaxKind.KFor;
				case "foreach":
					return MetaGeneratorTokensSyntaxKind.KForEach;
				case "in":
					return MetaGeneratorTokensSyntaxKind.KIn;
				case "if":
					return MetaGeneratorTokensSyntaxKind.KIf;
				case "else":
					return MetaGeneratorTokensSyntaxKind.KElse;
				case "repeat":
					return MetaGeneratorTokensSyntaxKind.KRepeat;
				case "until":
					return MetaGeneratorTokensSyntaxKind.KUntil;
				case "while":
					return MetaGeneratorTokensSyntaxKind.KWhile;
				case "loop":
					return MetaGeneratorTokensSyntaxKind.KLoop;
				case "hasloop":
					return MetaGeneratorTokensSyntaxKind.KHasLoop;
				case "where":
					return MetaGeneratorTokensSyntaxKind.KWhere;
				case "orderby":
					return MetaGeneratorTokensSyntaxKind.KOrderBy;
				case "descending":
					return MetaGeneratorTokensSyntaxKind.KDescending;
				case "separator":
					return MetaGeneratorTokensSyntaxKind.KSeparator;
				case "null":
					return MetaGeneratorTokensSyntaxKind.KNull;
				case "true":
					return MetaGeneratorTokensSyntaxKind.KTrue;
				case "false":
					return MetaGeneratorTokensSyntaxKind.KFalse;
				case "bool":
					return MetaGeneratorTokensSyntaxKind.KBool;
				case "byte":
					return MetaGeneratorTokensSyntaxKind.KByte;
				case "char":
					return MetaGeneratorTokensSyntaxKind.KChar;
				case "decimal":
					return MetaGeneratorTokensSyntaxKind.KDecimal;
				case "double":
					return MetaGeneratorTokensSyntaxKind.KDouble;
				case "float":
					return MetaGeneratorTokensSyntaxKind.KFloat;
				case "int":
					return MetaGeneratorTokensSyntaxKind.KInt;
				case "long":
					return MetaGeneratorTokensSyntaxKind.KLong;
				case "object":
					return MetaGeneratorTokensSyntaxKind.KObject;
				case "sbyte":
					return MetaGeneratorTokensSyntaxKind.KSByte;
				case "short":
					return MetaGeneratorTokensSyntaxKind.KShort;
				case "string":
					return MetaGeneratorTokensSyntaxKind.KString;
				case "uint":
					return MetaGeneratorTokensSyntaxKind.KUInt;
				case "ulong":
					return MetaGeneratorTokensSyntaxKind.KULong;
				case "ushort":
					return MetaGeneratorTokensSyntaxKind.KUShort;
				case "this":
					return MetaGeneratorTokensSyntaxKind.KThis;
				case "new":
					return MetaGeneratorTokensSyntaxKind.KNew;
				case "is":
					return MetaGeneratorTokensSyntaxKind.KIs;
				case "as":
					return MetaGeneratorTokensSyntaxKind.KAs;
				case "typeof":
					return MetaGeneratorTokensSyntaxKind.KTypeof;
				case "default":
					return MetaGeneratorTokensSyntaxKind.KDefault;
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
				case MetaGeneratorTokensSyntaxKind.IdentifierNormal:
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
				case MetaGeneratorTokensSyntaxKind.TSemicolon:
				case MetaGeneratorTokensSyntaxKind.TColon:
				case MetaGeneratorTokensSyntaxKind.TDot:
				case MetaGeneratorTokensSyntaxKind.TComma:
				case MetaGeneratorTokensSyntaxKind.TAssign:
				case MetaGeneratorTokensSyntaxKind.TAssignPlus:
				case MetaGeneratorTokensSyntaxKind.TAssignMinus:
				case MetaGeneratorTokensSyntaxKind.TAssignAsterisk:
				case MetaGeneratorTokensSyntaxKind.TAssignSlash:
				case MetaGeneratorTokensSyntaxKind.TAssignPercent:
				case MetaGeneratorTokensSyntaxKind.TAssignAmp:
				case MetaGeneratorTokensSyntaxKind.TAssignPipe:
				case MetaGeneratorTokensSyntaxKind.TAssignHat:
				case MetaGeneratorTokensSyntaxKind.TAssignLeftShift:
				case MetaGeneratorTokensSyntaxKind.TAssignRightShift:
				case MetaGeneratorTokensSyntaxKind.TOpenParenthesis:
				case MetaGeneratorTokensSyntaxKind.TCloseParenthesis:
				case MetaGeneratorTokensSyntaxKind.TOpenBracket:
				case MetaGeneratorTokensSyntaxKind.TCloseBracket:
				case MetaGeneratorTokensSyntaxKind.TOpenBrace:
				case MetaGeneratorTokensSyntaxKind.TCloseBrace:
				case MetaGeneratorTokensSyntaxKind.TEquals:
				case MetaGeneratorTokensSyntaxKind.TNotEquals:
				case MetaGeneratorTokensSyntaxKind.TArrow:
				case MetaGeneratorTokensSyntaxKind.TSingleArrow:
				case MetaGeneratorTokensSyntaxKind.TLessThan:
				case MetaGeneratorTokensSyntaxKind.TGreaterThan:
				case MetaGeneratorTokensSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorTokensSyntaxKind.TQuestion:
				case MetaGeneratorTokensSyntaxKind.TPlus:
				case MetaGeneratorTokensSyntaxKind.TMinus:
				case MetaGeneratorTokensSyntaxKind.TExclamation:
				case MetaGeneratorTokensSyntaxKind.TTilde:
				case MetaGeneratorTokensSyntaxKind.TAsterisk:
				case MetaGeneratorTokensSyntaxKind.TSlash:
				case MetaGeneratorTokensSyntaxKind.TPercent:
				case MetaGeneratorTokensSyntaxKind.TPlusPlus:
				case MetaGeneratorTokensSyntaxKind.TMinusMinus:
				case MetaGeneratorTokensSyntaxKind.TColonColon:
				case MetaGeneratorTokensSyntaxKind.TAmp:
				case MetaGeneratorTokensSyntaxKind.THat:
				case MetaGeneratorTokensSyntaxKind.TPipe:
				case MetaGeneratorTokensSyntaxKind.TAnd:
				case MetaGeneratorTokensSyntaxKind.TXor:
				case MetaGeneratorTokensSyntaxKind.TOr:
				case MetaGeneratorTokensSyntaxKind.TQuestionQuestion:
					return true;
				case MetaGeneratorTokensSyntaxKind.TH_TCloseParenthesis:
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
				case MetaGeneratorTokensSyntaxKind.IntegerLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.DecimalLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.ScientificLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.DateTimeOffsetLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.DateTimeLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.DateLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.TimeLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.GuidLiteral:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.CharLiteral:
					return true;
				case MetaGeneratorTokensSyntaxKind.RegularStringLiteral:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.LWhitespace:
					return true;
				case MetaGeneratorTokensSyntaxKind.LCrLf:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.LLineComment:
					return true;
				case MetaGeneratorTokensSyntaxKind.LMultiLineComment:
					return true;
				default:
					return false;
			}
		}
		public bool IsTemplateControl(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.TemplateLineControl:
					return true;
				case MetaGeneratorTokensSyntaxKind.TemplateStatementStart:
					return true;
				case MetaGeneratorTokensSyntaxKind.TemplateStatementEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsTemplateOutput(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorTokensSyntaxKind.TemplateOutput:
					return true;
				case MetaGeneratorTokensSyntaxKind.TemplateCrLf:
					return true;
				case MetaGeneratorTokensSyntaxKind.TemplateLineBreak:
					return true;
				default:
					return false;
			}
		}
	}
}


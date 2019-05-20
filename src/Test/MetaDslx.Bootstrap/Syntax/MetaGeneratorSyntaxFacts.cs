using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Bootstrap.MetaGenerator.Syntax
{
	public enum MetaGeneratorTokenKind : int
	{
		None = 0,
		Comment,
		ContextualKeyword,
		DocumentationCommentTrivia,
		FixedToken,
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
		Trivia
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

	public class MetaGeneratorSyntaxFacts : SyntaxFacts
	{
		public static readonly MetaGeneratorSyntaxFacts Instance = new MetaGeneratorSyntaxFacts();

        public override SyntaxKind ToLanguageSyntaxKind(SyntaxKind kind)
        {
            return kind.CastUp<MetaGeneratorSyntaxKind>();
        }

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaGeneratorSyntaxKind.KNamespace:
				case MetaGeneratorSyntaxKind.KGenerator:
				case MetaGeneratorSyntaxKind.KUsing:
				case MetaGeneratorSyntaxKind.KConfiguration:
				case MetaGeneratorSyntaxKind.KProperties:
				case MetaGeneratorSyntaxKind.KTemplate:
				case MetaGeneratorSyntaxKind.KFunction:
				case MetaGeneratorSyntaxKind.KExtern:
				case MetaGeneratorSyntaxKind.KReturn:
				case MetaGeneratorSyntaxKind.KSwitch:
				case MetaGeneratorSyntaxKind.KCase:
				case MetaGeneratorSyntaxKind.KType:
				case MetaGeneratorSyntaxKind.KVoid:
				case MetaGeneratorSyntaxKind.KEnd:
				case MetaGeneratorSyntaxKind.KFor:
				case MetaGeneratorSyntaxKind.KForEach:
				case MetaGeneratorSyntaxKind.KIn:
				case MetaGeneratorSyntaxKind.KIf:
				case MetaGeneratorSyntaxKind.KElse:
				case MetaGeneratorSyntaxKind.KRepeat:
				case MetaGeneratorSyntaxKind.KUntil:
				case MetaGeneratorSyntaxKind.KWhile:
				case MetaGeneratorSyntaxKind.KLoop:
				case MetaGeneratorSyntaxKind.KHasLoop:
				case MetaGeneratorSyntaxKind.KWhere:
				case MetaGeneratorSyntaxKind.KOrderBy:
				case MetaGeneratorSyntaxKind.KDescending:
				case MetaGeneratorSyntaxKind.KSeparator:
				case MetaGeneratorSyntaxKind.KNull:
				case MetaGeneratorSyntaxKind.KTrue:
				case MetaGeneratorSyntaxKind.KFalse:
				case MetaGeneratorSyntaxKind.KBool:
				case MetaGeneratorSyntaxKind.KByte:
				case MetaGeneratorSyntaxKind.KChar:
				case MetaGeneratorSyntaxKind.KDecimal:
				case MetaGeneratorSyntaxKind.KDouble:
				case MetaGeneratorSyntaxKind.KFloat:
				case MetaGeneratorSyntaxKind.KInt:
				case MetaGeneratorSyntaxKind.KLong:
				case MetaGeneratorSyntaxKind.KObject:
				case MetaGeneratorSyntaxKind.KSByte:
				case MetaGeneratorSyntaxKind.KShort:
				case MetaGeneratorSyntaxKind.KString:
				case MetaGeneratorSyntaxKind.KUInt:
				case MetaGeneratorSyntaxKind.KULong:
				case MetaGeneratorSyntaxKind.KUShort:
				case MetaGeneratorSyntaxKind.KThis:
				case MetaGeneratorSyntaxKind.KNew:
				case MetaGeneratorSyntaxKind.KIs:
				case MetaGeneratorSyntaxKind.KAs:
				case MetaGeneratorSyntaxKind.KTypeof:
				case MetaGeneratorSyntaxKind.KDefault:
				case MetaGeneratorSyntaxKind.TSemicolon:
				case MetaGeneratorSyntaxKind.TColon:
				case MetaGeneratorSyntaxKind.TDot:
				case MetaGeneratorSyntaxKind.TComma:
				case MetaGeneratorSyntaxKind.TAssign:
				case MetaGeneratorSyntaxKind.TAssignPlus:
				case MetaGeneratorSyntaxKind.TAssignMinus:
				case MetaGeneratorSyntaxKind.TAssignAsterisk:
				case MetaGeneratorSyntaxKind.TAssignSlash:
				case MetaGeneratorSyntaxKind.TAssignPercent:
				case MetaGeneratorSyntaxKind.TAssignAmp:
				case MetaGeneratorSyntaxKind.TAssignPipe:
				case MetaGeneratorSyntaxKind.TAssignHat:
				case MetaGeneratorSyntaxKind.TAssignLeftShift:
				case MetaGeneratorSyntaxKind.TAssignRightShift:
				case MetaGeneratorSyntaxKind.TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TCloseParenthesis:
				case MetaGeneratorSyntaxKind.TOpenBracket:
				case MetaGeneratorSyntaxKind.TCloseBracket:
				case MetaGeneratorSyntaxKind.TOpenBrace:
				case MetaGeneratorSyntaxKind.TCloseBrace:
				case MetaGeneratorSyntaxKind.TEquals:
				case MetaGeneratorSyntaxKind.TNotEquals:
				case MetaGeneratorSyntaxKind.TArrow:
				case MetaGeneratorSyntaxKind.TSingleArrow:
				case MetaGeneratorSyntaxKind.TLessThan:
				case MetaGeneratorSyntaxKind.TGreaterThan:
				case MetaGeneratorSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorSyntaxKind.TQuestion:
				case MetaGeneratorSyntaxKind.TPlus:
				case MetaGeneratorSyntaxKind.TMinus:
				case MetaGeneratorSyntaxKind.TExclamation:
				case MetaGeneratorSyntaxKind.TTilde:
				case MetaGeneratorSyntaxKind.TAsterisk:
				case MetaGeneratorSyntaxKind.TSlash:
				case MetaGeneratorSyntaxKind.TPercent:
				case MetaGeneratorSyntaxKind.TPlusPlus:
				case MetaGeneratorSyntaxKind.TMinusMinus:
				case MetaGeneratorSyntaxKind.TColonColon:
				case MetaGeneratorSyntaxKind.TAmp:
				case MetaGeneratorSyntaxKind.THat:
				case MetaGeneratorSyntaxKind.TPipe:
				case MetaGeneratorSyntaxKind.TAnd:
				case MetaGeneratorSyntaxKind.TXor:
				case MetaGeneratorSyntaxKind.TOr:
				case MetaGeneratorSyntaxKind.TQuestionQuestion:
				case MetaGeneratorSyntaxKind.IdentifierNormal:
				case MetaGeneratorSyntaxKind.IntegerLiteral:
				case MetaGeneratorSyntaxKind.DecimalLiteral:
				case MetaGeneratorSyntaxKind.ScientificLiteral:
				case MetaGeneratorSyntaxKind.DateTimeOffsetLiteral:
				case MetaGeneratorSyntaxKind.DateTimeLiteral:
				case MetaGeneratorSyntaxKind.DateLiteral:
				case MetaGeneratorSyntaxKind.TimeLiteral:
				case MetaGeneratorSyntaxKind.CharLiteral:
				case MetaGeneratorSyntaxKind.RegularStringLiteral:
				case MetaGeneratorSyntaxKind.GuidLiteral:
				case MetaGeneratorSyntaxKind.LUtf8Bom:
				case MetaGeneratorSyntaxKind.LWhitespace:
				case MetaGeneratorSyntaxKind.LCrLf:
				case MetaGeneratorSyntaxKind.LLineBreak:
				case MetaGeneratorSyntaxKind.LLineComment:
				case MetaGeneratorSyntaxKind.LMultiLineComment:
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteral:
				case MetaGeneratorSyntaxKind.TH_TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TH_TCloseParenthesis:
				case MetaGeneratorSyntaxKind.KEndTemplate:
				case MetaGeneratorSyntaxKind.TemplateLineControl:
				case MetaGeneratorSyntaxKind.TemplateOutput:
				case MetaGeneratorSyntaxKind.TemplateCrLf:
				case MetaGeneratorSyntaxKind.TemplateLineBreak:
				case MetaGeneratorSyntaxKind.TemplateStatementStart:
				case MetaGeneratorSyntaxKind.TemplateStatementEnd:
				case MetaGeneratorSyntaxKind.TS_TOpenBracket:
				case MetaGeneratorSyntaxKind.TS_TCloseBracket:
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaGeneratorSyntaxKind.COMMENT_START:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaGeneratorSyntaxKind.KNamespace:
				case MetaGeneratorSyntaxKind.KGenerator:
				case MetaGeneratorSyntaxKind.KUsing:
				case MetaGeneratorSyntaxKind.KConfiguration:
				case MetaGeneratorSyntaxKind.KProperties:
				case MetaGeneratorSyntaxKind.KTemplate:
				case MetaGeneratorSyntaxKind.KFunction:
				case MetaGeneratorSyntaxKind.KExtern:
				case MetaGeneratorSyntaxKind.KReturn:
				case MetaGeneratorSyntaxKind.KSwitch:
				case MetaGeneratorSyntaxKind.KCase:
				case MetaGeneratorSyntaxKind.KType:
				case MetaGeneratorSyntaxKind.KVoid:
				case MetaGeneratorSyntaxKind.KEnd:
				case MetaGeneratorSyntaxKind.KFor:
				case MetaGeneratorSyntaxKind.KForEach:
				case MetaGeneratorSyntaxKind.KIn:
				case MetaGeneratorSyntaxKind.KIf:
				case MetaGeneratorSyntaxKind.KElse:
				case MetaGeneratorSyntaxKind.KRepeat:
				case MetaGeneratorSyntaxKind.KUntil:
				case MetaGeneratorSyntaxKind.KWhile:
				case MetaGeneratorSyntaxKind.KLoop:
				case MetaGeneratorSyntaxKind.KHasLoop:
				case MetaGeneratorSyntaxKind.KWhere:
				case MetaGeneratorSyntaxKind.KOrderBy:
				case MetaGeneratorSyntaxKind.KDescending:
				case MetaGeneratorSyntaxKind.KSeparator:
				case MetaGeneratorSyntaxKind.KNull:
				case MetaGeneratorSyntaxKind.KTrue:
				case MetaGeneratorSyntaxKind.KFalse:
				case MetaGeneratorSyntaxKind.KBool:
				case MetaGeneratorSyntaxKind.KByte:
				case MetaGeneratorSyntaxKind.KChar:
				case MetaGeneratorSyntaxKind.KDecimal:
				case MetaGeneratorSyntaxKind.KDouble:
				case MetaGeneratorSyntaxKind.KFloat:
				case MetaGeneratorSyntaxKind.KInt:
				case MetaGeneratorSyntaxKind.KLong:
				case MetaGeneratorSyntaxKind.KObject:
				case MetaGeneratorSyntaxKind.KSByte:
				case MetaGeneratorSyntaxKind.KShort:
				case MetaGeneratorSyntaxKind.KString:
				case MetaGeneratorSyntaxKind.KUInt:
				case MetaGeneratorSyntaxKind.KULong:
				case MetaGeneratorSyntaxKind.KUShort:
				case MetaGeneratorSyntaxKind.KThis:
				case MetaGeneratorSyntaxKind.KNew:
				case MetaGeneratorSyntaxKind.KIs:
				case MetaGeneratorSyntaxKind.KAs:
				case MetaGeneratorSyntaxKind.KTypeof:
				case MetaGeneratorSyntaxKind.KDefault:
				case MetaGeneratorSyntaxKind.TSemicolon:
				case MetaGeneratorSyntaxKind.TColon:
				case MetaGeneratorSyntaxKind.TDot:
				case MetaGeneratorSyntaxKind.TComma:
				case MetaGeneratorSyntaxKind.TAssign:
				case MetaGeneratorSyntaxKind.TAssignPlus:
				case MetaGeneratorSyntaxKind.TAssignMinus:
				case MetaGeneratorSyntaxKind.TAssignAsterisk:
				case MetaGeneratorSyntaxKind.TAssignSlash:
				case MetaGeneratorSyntaxKind.TAssignPercent:
				case MetaGeneratorSyntaxKind.TAssignAmp:
				case MetaGeneratorSyntaxKind.TAssignPipe:
				case MetaGeneratorSyntaxKind.TAssignHat:
				case MetaGeneratorSyntaxKind.TAssignLeftShift:
				case MetaGeneratorSyntaxKind.TAssignRightShift:
				case MetaGeneratorSyntaxKind.TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TCloseParenthesis:
				case MetaGeneratorSyntaxKind.TCloseBracket:
				case MetaGeneratorSyntaxKind.TOpenBrace:
				case MetaGeneratorSyntaxKind.TCloseBrace:
				case MetaGeneratorSyntaxKind.TEquals:
				case MetaGeneratorSyntaxKind.TNotEquals:
				case MetaGeneratorSyntaxKind.TArrow:
				case MetaGeneratorSyntaxKind.TSingleArrow:
				case MetaGeneratorSyntaxKind.TLessThan:
				case MetaGeneratorSyntaxKind.TGreaterThan:
				case MetaGeneratorSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorSyntaxKind.TQuestion:
				case MetaGeneratorSyntaxKind.TPlus:
				case MetaGeneratorSyntaxKind.TMinus:
				case MetaGeneratorSyntaxKind.TExclamation:
				case MetaGeneratorSyntaxKind.TTilde:
				case MetaGeneratorSyntaxKind.TSlash:
				case MetaGeneratorSyntaxKind.TPercent:
				case MetaGeneratorSyntaxKind.TPlusPlus:
				case MetaGeneratorSyntaxKind.TMinusMinus:
				case MetaGeneratorSyntaxKind.TColonColon:
				case MetaGeneratorSyntaxKind.TAmp:
				case MetaGeneratorSyntaxKind.THat:
				case MetaGeneratorSyntaxKind.TPipe:
				case MetaGeneratorSyntaxKind.TAnd:
				case MetaGeneratorSyntaxKind.TXor:
				case MetaGeneratorSyntaxKind.TOr:
				case MetaGeneratorSyntaxKind.TQuestionQuestion:
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteral:
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
					return MetaGeneratorSyntaxKind.KNamespace;
				case "generator":
					return MetaGeneratorSyntaxKind.KGenerator;
				case "using":
					return MetaGeneratorSyntaxKind.KUsing;
				case "configuration":
					return MetaGeneratorSyntaxKind.KConfiguration;
				case "properties":
					return MetaGeneratorSyntaxKind.KProperties;
				case "template":
					return MetaGeneratorSyntaxKind.KTemplate;
				case "function":
					return MetaGeneratorSyntaxKind.KFunction;
				case "extern":
					return MetaGeneratorSyntaxKind.KExtern;
				case "return":
					return MetaGeneratorSyntaxKind.KReturn;
				case "switch":
					return MetaGeneratorSyntaxKind.KSwitch;
				case "case":
					return MetaGeneratorSyntaxKind.KCase;
				case "type":
					return MetaGeneratorSyntaxKind.KType;
				case "void":
					return MetaGeneratorSyntaxKind.KVoid;
				case "end":
					return MetaGeneratorSyntaxKind.KEnd;
				case "for":
					return MetaGeneratorSyntaxKind.KFor;
				case "foreach":
					return MetaGeneratorSyntaxKind.KForEach;
				case "in":
					return MetaGeneratorSyntaxKind.KIn;
				case "if":
					return MetaGeneratorSyntaxKind.KIf;
				case "else":
					return MetaGeneratorSyntaxKind.KElse;
				case "repeat":
					return MetaGeneratorSyntaxKind.KRepeat;
				case "until":
					return MetaGeneratorSyntaxKind.KUntil;
				case "while":
					return MetaGeneratorSyntaxKind.KWhile;
				case "loop":
					return MetaGeneratorSyntaxKind.KLoop;
				case "hasloop":
					return MetaGeneratorSyntaxKind.KHasLoop;
				case "where":
					return MetaGeneratorSyntaxKind.KWhere;
				case "orderby":
					return MetaGeneratorSyntaxKind.KOrderBy;
				case "descending":
					return MetaGeneratorSyntaxKind.KDescending;
				case "separator":
					return MetaGeneratorSyntaxKind.KSeparator;
				case "null":
					return MetaGeneratorSyntaxKind.KNull;
				case "true":
					return MetaGeneratorSyntaxKind.KTrue;
				case "false":
					return MetaGeneratorSyntaxKind.KFalse;
				case "bool":
					return MetaGeneratorSyntaxKind.KBool;
				case "byte":
					return MetaGeneratorSyntaxKind.KByte;
				case "char":
					return MetaGeneratorSyntaxKind.KChar;
				case "decimal":
					return MetaGeneratorSyntaxKind.KDecimal;
				case "double":
					return MetaGeneratorSyntaxKind.KDouble;
				case "float":
					return MetaGeneratorSyntaxKind.KFloat;
				case "int":
					return MetaGeneratorSyntaxKind.KInt;
				case "long":
					return MetaGeneratorSyntaxKind.KLong;
				case "object":
					return MetaGeneratorSyntaxKind.KObject;
				case "sbyte":
					return MetaGeneratorSyntaxKind.KSByte;
				case "short":
					return MetaGeneratorSyntaxKind.KShort;
				case "string":
					return MetaGeneratorSyntaxKind.KString;
				case "uint":
					return MetaGeneratorSyntaxKind.KUInt;
				case "ulong":
					return MetaGeneratorSyntaxKind.KULong;
				case "ushort":
					return MetaGeneratorSyntaxKind.KUShort;
				case "this":
					return MetaGeneratorSyntaxKind.KThis;
				case "new":
					return MetaGeneratorSyntaxKind.KNew;
				case "is":
					return MetaGeneratorSyntaxKind.KIs;
				case "as":
					return MetaGeneratorSyntaxKind.KAs;
				case "typeof":
					return MetaGeneratorSyntaxKind.KTypeof;
				case "default":
					return MetaGeneratorSyntaxKind.KDefault;
				case ";":
					return MetaGeneratorSyntaxKind.TSemicolon;
				case ":":
					return MetaGeneratorSyntaxKind.TColon;
				case ".":
					return MetaGeneratorSyntaxKind.TDot;
				case ",":
					return MetaGeneratorSyntaxKind.TComma;
				case "=":
					return MetaGeneratorSyntaxKind.TAssign;
				case "+=":
					return MetaGeneratorSyntaxKind.TAssignPlus;
				case "-=":
					return MetaGeneratorSyntaxKind.TAssignMinus;
				case "*=":
					return MetaGeneratorSyntaxKind.TAssignAsterisk;
				case "/=":
					return MetaGeneratorSyntaxKind.TAssignSlash;
				case "%=":
					return MetaGeneratorSyntaxKind.TAssignPercent;
				case "&=":
					return MetaGeneratorSyntaxKind.TAssignAmp;
				case "|=":
					return MetaGeneratorSyntaxKind.TAssignPipe;
				case "^=":
					return MetaGeneratorSyntaxKind.TAssignHat;
				case "<<=":
					return MetaGeneratorSyntaxKind.TAssignLeftShift;
				case ">>=":
					return MetaGeneratorSyntaxKind.TAssignRightShift;
				case "(":
					return MetaGeneratorSyntaxKind.TOpenParenthesis;
				case ")":
					return MetaGeneratorSyntaxKind.TCloseParenthesis;
				case "]":
					return MetaGeneratorSyntaxKind.TCloseBracket;
				case "{":
					return MetaGeneratorSyntaxKind.TOpenBrace;
				case "}":
					return MetaGeneratorSyntaxKind.TCloseBrace;
				case "==":
					return MetaGeneratorSyntaxKind.TEquals;
				case "!=":
					return MetaGeneratorSyntaxKind.TNotEquals;
				case "=>":
					return MetaGeneratorSyntaxKind.TArrow;
				case "->":
					return MetaGeneratorSyntaxKind.TSingleArrow;
				case "<":
					return MetaGeneratorSyntaxKind.TLessThan;
				case ">":
					return MetaGeneratorSyntaxKind.TGreaterThan;
				case "<=":
					return MetaGeneratorSyntaxKind.TLessThanOrEquals;
				case ">=":
					return MetaGeneratorSyntaxKind.TGreaterThanOrEquals;
				case "?":
					return MetaGeneratorSyntaxKind.TQuestion;
				case "+":
					return MetaGeneratorSyntaxKind.TPlus;
				case "-":
					return MetaGeneratorSyntaxKind.TMinus;
				case "!":
					return MetaGeneratorSyntaxKind.TExclamation;
				case "~":
					return MetaGeneratorSyntaxKind.TTilde;
				case "/":
					return MetaGeneratorSyntaxKind.TSlash;
				case "%":
					return MetaGeneratorSyntaxKind.TPercent;
				case "++":
					return MetaGeneratorSyntaxKind.TPlusPlus;
				case "--":
					return MetaGeneratorSyntaxKind.TMinusMinus;
				case "::":
					return MetaGeneratorSyntaxKind.TColonColon;
				case "&":
					return MetaGeneratorSyntaxKind.TAmp;
				case "^":
					return MetaGeneratorSyntaxKind.THat;
				case "|":
					return MetaGeneratorSyntaxKind.TPipe;
				case "&&":
					return MetaGeneratorSyntaxKind.TAnd;
				case "^^":
					return MetaGeneratorSyntaxKind.TXor;
				case "||":
					return MetaGeneratorSyntaxKind.TOr;
				case "??":
					return MetaGeneratorSyntaxKind.TQuestionQuestion;
				case "@\"":
					return MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "\"":
					return MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteral;
				default:
					return MetaGeneratorSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaGeneratorSyntaxKind.KNamespace:
					return "namespace";
				case MetaGeneratorSyntaxKind.KGenerator:
					return "generator";
				case MetaGeneratorSyntaxKind.KUsing:
					return "using";
				case MetaGeneratorSyntaxKind.KConfiguration:
					return "configuration";
				case MetaGeneratorSyntaxKind.KProperties:
					return "properties";
				case MetaGeneratorSyntaxKind.KTemplate:
					return "template";
				case MetaGeneratorSyntaxKind.KFunction:
					return "function";
				case MetaGeneratorSyntaxKind.KExtern:
					return "extern";
				case MetaGeneratorSyntaxKind.KReturn:
					return "return";
				case MetaGeneratorSyntaxKind.KSwitch:
					return "switch";
				case MetaGeneratorSyntaxKind.KCase:
					return "case";
				case MetaGeneratorSyntaxKind.KType:
					return "type";
				case MetaGeneratorSyntaxKind.KVoid:
					return "void";
				case MetaGeneratorSyntaxKind.KEnd:
					return "end";
				case MetaGeneratorSyntaxKind.KFor:
					return "for";
				case MetaGeneratorSyntaxKind.KForEach:
					return "foreach";
				case MetaGeneratorSyntaxKind.KIn:
					return "in";
				case MetaGeneratorSyntaxKind.KIf:
					return "if";
				case MetaGeneratorSyntaxKind.KElse:
					return "else";
				case MetaGeneratorSyntaxKind.KRepeat:
					return "repeat";
				case MetaGeneratorSyntaxKind.KUntil:
					return "until";
				case MetaGeneratorSyntaxKind.KWhile:
					return "while";
				case MetaGeneratorSyntaxKind.KLoop:
					return "loop";
				case MetaGeneratorSyntaxKind.KHasLoop:
					return "hasloop";
				case MetaGeneratorSyntaxKind.KWhere:
					return "where";
				case MetaGeneratorSyntaxKind.KOrderBy:
					return "orderby";
				case MetaGeneratorSyntaxKind.KDescending:
					return "descending";
				case MetaGeneratorSyntaxKind.KSeparator:
					return "separator";
				case MetaGeneratorSyntaxKind.KNull:
					return "null";
				case MetaGeneratorSyntaxKind.KTrue:
					return "true";
				case MetaGeneratorSyntaxKind.KFalse:
					return "false";
				case MetaGeneratorSyntaxKind.KBool:
					return "bool";
				case MetaGeneratorSyntaxKind.KByte:
					return "byte";
				case MetaGeneratorSyntaxKind.KChar:
					return "char";
				case MetaGeneratorSyntaxKind.KDecimal:
					return "decimal";
				case MetaGeneratorSyntaxKind.KDouble:
					return "double";
				case MetaGeneratorSyntaxKind.KFloat:
					return "float";
				case MetaGeneratorSyntaxKind.KInt:
					return "int";
				case MetaGeneratorSyntaxKind.KLong:
					return "long";
				case MetaGeneratorSyntaxKind.KObject:
					return "object";
				case MetaGeneratorSyntaxKind.KSByte:
					return "sbyte";
				case MetaGeneratorSyntaxKind.KShort:
					return "short";
				case MetaGeneratorSyntaxKind.KString:
					return "string";
				case MetaGeneratorSyntaxKind.KUInt:
					return "uint";
				case MetaGeneratorSyntaxKind.KULong:
					return "ulong";
				case MetaGeneratorSyntaxKind.KUShort:
					return "ushort";
				case MetaGeneratorSyntaxKind.KThis:
					return "this";
				case MetaGeneratorSyntaxKind.KNew:
					return "new";
				case MetaGeneratorSyntaxKind.KIs:
					return "is";
				case MetaGeneratorSyntaxKind.KAs:
					return "as";
				case MetaGeneratorSyntaxKind.KTypeof:
					return "typeof";
				case MetaGeneratorSyntaxKind.KDefault:
					return "default";
				case MetaGeneratorSyntaxKind.TSemicolon:
					return ";";
				case MetaGeneratorSyntaxKind.TColon:
					return ":";
				case MetaGeneratorSyntaxKind.TDot:
					return ".";
				case MetaGeneratorSyntaxKind.TComma:
					return ",";
				case MetaGeneratorSyntaxKind.TAssign:
					return "=";
				case MetaGeneratorSyntaxKind.TAssignPlus:
					return "+=";
				case MetaGeneratorSyntaxKind.TAssignMinus:
					return "-=";
				case MetaGeneratorSyntaxKind.TAssignAsterisk:
					return "*=";
				case MetaGeneratorSyntaxKind.TAssignSlash:
					return "/=";
				case MetaGeneratorSyntaxKind.TAssignPercent:
					return "%=";
				case MetaGeneratorSyntaxKind.TAssignAmp:
					return "&=";
				case MetaGeneratorSyntaxKind.TAssignPipe:
					return "|=";
				case MetaGeneratorSyntaxKind.TAssignHat:
					return "^=";
				case MetaGeneratorSyntaxKind.TAssignLeftShift:
					return "<<=";
				case MetaGeneratorSyntaxKind.TAssignRightShift:
					return ">>=";
				case MetaGeneratorSyntaxKind.TOpenParenthesis:
					return "(";
				case MetaGeneratorSyntaxKind.TCloseParenthesis:
					return ")";
				case MetaGeneratorSyntaxKind.TCloseBracket:
					return "]";
				case MetaGeneratorSyntaxKind.TOpenBrace:
					return "{";
				case MetaGeneratorSyntaxKind.TCloseBrace:
					return "}";
				case MetaGeneratorSyntaxKind.TEquals:
					return "==";
				case MetaGeneratorSyntaxKind.TNotEquals:
					return "!=";
				case MetaGeneratorSyntaxKind.TArrow:
					return "=>";
				case MetaGeneratorSyntaxKind.TSingleArrow:
					return "->";
				case MetaGeneratorSyntaxKind.TLessThan:
					return "<";
				case MetaGeneratorSyntaxKind.TGreaterThan:
					return ">";
				case MetaGeneratorSyntaxKind.TLessThanOrEquals:
					return "<=";
				case MetaGeneratorSyntaxKind.TGreaterThanOrEquals:
					return ">=";
				case MetaGeneratorSyntaxKind.TQuestion:
					return "?";
				case MetaGeneratorSyntaxKind.TPlus:
					return "+";
				case MetaGeneratorSyntaxKind.TMinus:
					return "-";
				case MetaGeneratorSyntaxKind.TExclamation:
					return "!";
				case MetaGeneratorSyntaxKind.TTilde:
					return "~";
				case MetaGeneratorSyntaxKind.TSlash:
					return "/";
				case MetaGeneratorSyntaxKind.TPercent:
					return "%";
				case MetaGeneratorSyntaxKind.TPlusPlus:
					return "++";
				case MetaGeneratorSyntaxKind.TMinusMinus:
					return "--";
				case MetaGeneratorSyntaxKind.TColonColon:
					return "::";
				case MetaGeneratorSyntaxKind.TAmp:
					return "&";
				case MetaGeneratorSyntaxKind.THat:
					return "^";
				case MetaGeneratorSyntaxKind.TPipe:
					return "|";
				case MetaGeneratorSyntaxKind.TAnd:
					return "&&";
				case MetaGeneratorSyntaxKind.TXor:
					return "^^";
				case MetaGeneratorSyntaxKind.TOr:
					return "||";
				case MetaGeneratorSyntaxKind.TQuestionQuestion:
					return "??";
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteral:
					return "\"";
				default:
					return string.Empty;
			}
		}

		public MetaGeneratorTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<MetaGeneratorSyntaxKind>(rawKind));
		}

		public MetaGeneratorTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorSyntaxKind.KNamespace:
				case MetaGeneratorSyntaxKind.KGenerator:
				case MetaGeneratorSyntaxKind.KUsing:
				case MetaGeneratorSyntaxKind.KConfiguration:
				case MetaGeneratorSyntaxKind.KProperties:
				case MetaGeneratorSyntaxKind.KTemplate:
				case MetaGeneratorSyntaxKind.KFunction:
				case MetaGeneratorSyntaxKind.KExtern:
				case MetaGeneratorSyntaxKind.KReturn:
				case MetaGeneratorSyntaxKind.KSwitch:
				case MetaGeneratorSyntaxKind.KCase:
				case MetaGeneratorSyntaxKind.KType:
				case MetaGeneratorSyntaxKind.KVoid:
				case MetaGeneratorSyntaxKind.KEnd:
				case MetaGeneratorSyntaxKind.KFor:
				case MetaGeneratorSyntaxKind.KForEach:
				case MetaGeneratorSyntaxKind.KIn:
				case MetaGeneratorSyntaxKind.KIf:
				case MetaGeneratorSyntaxKind.KElse:
				case MetaGeneratorSyntaxKind.KRepeat:
				case MetaGeneratorSyntaxKind.KUntil:
				case MetaGeneratorSyntaxKind.KWhile:
				case MetaGeneratorSyntaxKind.KLoop:
				case MetaGeneratorSyntaxKind.KHasLoop:
				case MetaGeneratorSyntaxKind.KWhere:
				case MetaGeneratorSyntaxKind.KOrderBy:
				case MetaGeneratorSyntaxKind.KDescending:
				case MetaGeneratorSyntaxKind.KSeparator:
				case MetaGeneratorSyntaxKind.KNull:
				case MetaGeneratorSyntaxKind.KTrue:
				case MetaGeneratorSyntaxKind.KFalse:
				case MetaGeneratorSyntaxKind.KBool:
				case MetaGeneratorSyntaxKind.KByte:
				case MetaGeneratorSyntaxKind.KChar:
				case MetaGeneratorSyntaxKind.KDecimal:
				case MetaGeneratorSyntaxKind.KDouble:
				case MetaGeneratorSyntaxKind.KFloat:
				case MetaGeneratorSyntaxKind.KInt:
				case MetaGeneratorSyntaxKind.KLong:
				case MetaGeneratorSyntaxKind.KObject:
				case MetaGeneratorSyntaxKind.KSByte:
				case MetaGeneratorSyntaxKind.KShort:
				case MetaGeneratorSyntaxKind.KString:
				case MetaGeneratorSyntaxKind.KUInt:
				case MetaGeneratorSyntaxKind.KULong:
				case MetaGeneratorSyntaxKind.KUShort:
				case MetaGeneratorSyntaxKind.KThis:
				case MetaGeneratorSyntaxKind.KNew:
				case MetaGeneratorSyntaxKind.KIs:
				case MetaGeneratorSyntaxKind.KAs:
				case MetaGeneratorSyntaxKind.KTypeof:
				case MetaGeneratorSyntaxKind.KDefault:
					return MetaGeneratorTokenKind.ReservedKeyword;
				case MetaGeneratorSyntaxKind.TSemicolon:
				case MetaGeneratorSyntaxKind.TColon:
				case MetaGeneratorSyntaxKind.TDot:
				case MetaGeneratorSyntaxKind.TComma:
				case MetaGeneratorSyntaxKind.TAssign:
				case MetaGeneratorSyntaxKind.TAssignPlus:
				case MetaGeneratorSyntaxKind.TAssignMinus:
				case MetaGeneratorSyntaxKind.TAssignAsterisk:
				case MetaGeneratorSyntaxKind.TAssignSlash:
				case MetaGeneratorSyntaxKind.TAssignPercent:
				case MetaGeneratorSyntaxKind.TAssignAmp:
				case MetaGeneratorSyntaxKind.TAssignPipe:
				case MetaGeneratorSyntaxKind.TAssignHat:
				case MetaGeneratorSyntaxKind.TAssignLeftShift:
				case MetaGeneratorSyntaxKind.TAssignRightShift:
				case MetaGeneratorSyntaxKind.TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TCloseParenthesis:
				case MetaGeneratorSyntaxKind.TOpenBracket:
				case MetaGeneratorSyntaxKind.TCloseBracket:
				case MetaGeneratorSyntaxKind.TOpenBrace:
				case MetaGeneratorSyntaxKind.TCloseBrace:
				case MetaGeneratorSyntaxKind.TEquals:
				case MetaGeneratorSyntaxKind.TNotEquals:
				case MetaGeneratorSyntaxKind.TArrow:
				case MetaGeneratorSyntaxKind.TSingleArrow:
				case MetaGeneratorSyntaxKind.TLessThan:
				case MetaGeneratorSyntaxKind.TGreaterThan:
				case MetaGeneratorSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorSyntaxKind.TQuestion:
				case MetaGeneratorSyntaxKind.TPlus:
				case MetaGeneratorSyntaxKind.TMinus:
				case MetaGeneratorSyntaxKind.TExclamation:
				case MetaGeneratorSyntaxKind.TTilde:
				case MetaGeneratorSyntaxKind.TAsterisk:
				case MetaGeneratorSyntaxKind.TSlash:
				case MetaGeneratorSyntaxKind.TPercent:
				case MetaGeneratorSyntaxKind.TPlusPlus:
				case MetaGeneratorSyntaxKind.TMinusMinus:
				case MetaGeneratorSyntaxKind.TColonColon:
				case MetaGeneratorSyntaxKind.TAmp:
				case MetaGeneratorSyntaxKind.THat:
				case MetaGeneratorSyntaxKind.TPipe:
				case MetaGeneratorSyntaxKind.TAnd:
				case MetaGeneratorSyntaxKind.TXor:
				case MetaGeneratorSyntaxKind.TOr:
				case MetaGeneratorSyntaxKind.TQuestionQuestion:
					return MetaGeneratorTokenKind.Operator;
				case MetaGeneratorSyntaxKind.IdentifierNormal:
					return MetaGeneratorTokenKind.Identifier;
				case MetaGeneratorSyntaxKind.IntegerLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.DecimalLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.ScientificLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.DateTimeOffsetLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.DateTimeLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.DateLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.TimeLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.CharLiteral:
					return MetaGeneratorTokenKind.String;
				case MetaGeneratorSyntaxKind.RegularStringLiteral:
					return MetaGeneratorTokenKind.String;
				case MetaGeneratorSyntaxKind.GuidLiteral:
					return MetaGeneratorTokenKind.Number;
				case MetaGeneratorSyntaxKind.LLineComment:
					return MetaGeneratorTokenKind.Comment;
				case MetaGeneratorSyntaxKind.LMultiLineComment:
					return MetaGeneratorTokenKind.Comment;
				case MetaGeneratorSyntaxKind.TH_TCloseParenthesis:
					return MetaGeneratorTokenKind.Operator;
				case MetaGeneratorSyntaxKind.KEndTemplate:
					return MetaGeneratorTokenKind.ReservedKeyword;
				case MetaGeneratorSyntaxKind.TemplateLineControl:
					return MetaGeneratorTokenKind.TemplateControl;
				case MetaGeneratorSyntaxKind.TemplateOutput:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorSyntaxKind.TemplateCrLf:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorSyntaxKind.TemplateLineBreak:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorSyntaxKind.TemplateStatementStart:
					return MetaGeneratorTokenKind.TemplateControl;
				case MetaGeneratorSyntaxKind.TemplateStatementEnd:
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
					return MetaGeneratorTokenKind.Comment;
				case MetaGeneratorLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return MetaGeneratorTokenKind.String;
				case MetaGeneratorLexerMode.TEMPLATE_OUTPUT:
					return MetaGeneratorTokenKind.TemplateOutput;
				case MetaGeneratorLexerMode.TEMPLATE_STATEMENT_COMMENT:
					return MetaGeneratorTokenKind.Comment;
				default:
					return MetaGeneratorTokenKind.None;
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
				case MetaGeneratorSyntaxKind.KNamespace:
				case MetaGeneratorSyntaxKind.KGenerator:
				case MetaGeneratorSyntaxKind.KUsing:
				case MetaGeneratorSyntaxKind.KConfiguration:
				case MetaGeneratorSyntaxKind.KProperties:
				case MetaGeneratorSyntaxKind.KTemplate:
				case MetaGeneratorSyntaxKind.KFunction:
				case MetaGeneratorSyntaxKind.KExtern:
				case MetaGeneratorSyntaxKind.KReturn:
				case MetaGeneratorSyntaxKind.KSwitch:
				case MetaGeneratorSyntaxKind.KCase:
				case MetaGeneratorSyntaxKind.KType:
				case MetaGeneratorSyntaxKind.KVoid:
				case MetaGeneratorSyntaxKind.KEnd:
				case MetaGeneratorSyntaxKind.KFor:
				case MetaGeneratorSyntaxKind.KForEach:
				case MetaGeneratorSyntaxKind.KIn:
				case MetaGeneratorSyntaxKind.KIf:
				case MetaGeneratorSyntaxKind.KElse:
				case MetaGeneratorSyntaxKind.KRepeat:
				case MetaGeneratorSyntaxKind.KUntil:
				case MetaGeneratorSyntaxKind.KWhile:
				case MetaGeneratorSyntaxKind.KLoop:
				case MetaGeneratorSyntaxKind.KHasLoop:
				case MetaGeneratorSyntaxKind.KWhere:
				case MetaGeneratorSyntaxKind.KOrderBy:
				case MetaGeneratorSyntaxKind.KDescending:
				case MetaGeneratorSyntaxKind.KSeparator:
				case MetaGeneratorSyntaxKind.KNull:
				case MetaGeneratorSyntaxKind.KTrue:
				case MetaGeneratorSyntaxKind.KFalse:
				case MetaGeneratorSyntaxKind.KBool:
				case MetaGeneratorSyntaxKind.KByte:
				case MetaGeneratorSyntaxKind.KChar:
				case MetaGeneratorSyntaxKind.KDecimal:
				case MetaGeneratorSyntaxKind.KDouble:
				case MetaGeneratorSyntaxKind.KFloat:
				case MetaGeneratorSyntaxKind.KInt:
				case MetaGeneratorSyntaxKind.KLong:
				case MetaGeneratorSyntaxKind.KObject:
				case MetaGeneratorSyntaxKind.KSByte:
				case MetaGeneratorSyntaxKind.KShort:
				case MetaGeneratorSyntaxKind.KString:
				case MetaGeneratorSyntaxKind.KUInt:
				case MetaGeneratorSyntaxKind.KULong:
				case MetaGeneratorSyntaxKind.KUShort:
				case MetaGeneratorSyntaxKind.KThis:
				case MetaGeneratorSyntaxKind.KNew:
				case MetaGeneratorSyntaxKind.KIs:
				case MetaGeneratorSyntaxKind.KAs:
				case MetaGeneratorSyntaxKind.KTypeof:
				case MetaGeneratorSyntaxKind.KDefault:
					return true;
				case MetaGeneratorSyntaxKind.KEndTemplate:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return MetaGeneratorSyntaxKind.KNamespace;
				yield return MetaGeneratorSyntaxKind.KGenerator;
				yield return MetaGeneratorSyntaxKind.KUsing;
				yield return MetaGeneratorSyntaxKind.KConfiguration;
				yield return MetaGeneratorSyntaxKind.KProperties;
				yield return MetaGeneratorSyntaxKind.KTemplate;
				yield return MetaGeneratorSyntaxKind.KFunction;
				yield return MetaGeneratorSyntaxKind.KExtern;
				yield return MetaGeneratorSyntaxKind.KReturn;
				yield return MetaGeneratorSyntaxKind.KSwitch;
				yield return MetaGeneratorSyntaxKind.KCase;
				yield return MetaGeneratorSyntaxKind.KType;
				yield return MetaGeneratorSyntaxKind.KVoid;
				yield return MetaGeneratorSyntaxKind.KEnd;
				yield return MetaGeneratorSyntaxKind.KFor;
				yield return MetaGeneratorSyntaxKind.KForEach;
				yield return MetaGeneratorSyntaxKind.KIn;
				yield return MetaGeneratorSyntaxKind.KIf;
				yield return MetaGeneratorSyntaxKind.KElse;
				yield return MetaGeneratorSyntaxKind.KRepeat;
				yield return MetaGeneratorSyntaxKind.KUntil;
				yield return MetaGeneratorSyntaxKind.KWhile;
				yield return MetaGeneratorSyntaxKind.KLoop;
				yield return MetaGeneratorSyntaxKind.KHasLoop;
				yield return MetaGeneratorSyntaxKind.KWhere;
				yield return MetaGeneratorSyntaxKind.KOrderBy;
				yield return MetaGeneratorSyntaxKind.KDescending;
				yield return MetaGeneratorSyntaxKind.KSeparator;
				yield return MetaGeneratorSyntaxKind.KNull;
				yield return MetaGeneratorSyntaxKind.KTrue;
				yield return MetaGeneratorSyntaxKind.KFalse;
				yield return MetaGeneratorSyntaxKind.KBool;
				yield return MetaGeneratorSyntaxKind.KByte;
				yield return MetaGeneratorSyntaxKind.KChar;
				yield return MetaGeneratorSyntaxKind.KDecimal;
				yield return MetaGeneratorSyntaxKind.KDouble;
				yield return MetaGeneratorSyntaxKind.KFloat;
				yield return MetaGeneratorSyntaxKind.KInt;
				yield return MetaGeneratorSyntaxKind.KLong;
				yield return MetaGeneratorSyntaxKind.KObject;
				yield return MetaGeneratorSyntaxKind.KSByte;
				yield return MetaGeneratorSyntaxKind.KShort;
				yield return MetaGeneratorSyntaxKind.KString;
				yield return MetaGeneratorSyntaxKind.KUInt;
				yield return MetaGeneratorSyntaxKind.KULong;
				yield return MetaGeneratorSyntaxKind.KUShort;
				yield return MetaGeneratorSyntaxKind.KThis;
				yield return MetaGeneratorSyntaxKind.KNew;
				yield return MetaGeneratorSyntaxKind.KIs;
				yield return MetaGeneratorSyntaxKind.KAs;
				yield return MetaGeneratorSyntaxKind.KTypeof;
				yield return MetaGeneratorSyntaxKind.KDefault;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return MetaGeneratorSyntaxKind.KNamespace;
				case "generator":
					return MetaGeneratorSyntaxKind.KGenerator;
				case "using":
					return MetaGeneratorSyntaxKind.KUsing;
				case "configuration":
					return MetaGeneratorSyntaxKind.KConfiguration;
				case "properties":
					return MetaGeneratorSyntaxKind.KProperties;
				case "template":
					return MetaGeneratorSyntaxKind.KTemplate;
				case "function":
					return MetaGeneratorSyntaxKind.KFunction;
				case "extern":
					return MetaGeneratorSyntaxKind.KExtern;
				case "return":
					return MetaGeneratorSyntaxKind.KReturn;
				case "switch":
					return MetaGeneratorSyntaxKind.KSwitch;
				case "case":
					return MetaGeneratorSyntaxKind.KCase;
				case "type":
					return MetaGeneratorSyntaxKind.KType;
				case "void":
					return MetaGeneratorSyntaxKind.KVoid;
				case "end":
					return MetaGeneratorSyntaxKind.KEnd;
				case "for":
					return MetaGeneratorSyntaxKind.KFor;
				case "foreach":
					return MetaGeneratorSyntaxKind.KForEach;
				case "in":
					return MetaGeneratorSyntaxKind.KIn;
				case "if":
					return MetaGeneratorSyntaxKind.KIf;
				case "else":
					return MetaGeneratorSyntaxKind.KElse;
				case "repeat":
					return MetaGeneratorSyntaxKind.KRepeat;
				case "until":
					return MetaGeneratorSyntaxKind.KUntil;
				case "while":
					return MetaGeneratorSyntaxKind.KWhile;
				case "loop":
					return MetaGeneratorSyntaxKind.KLoop;
				case "hasloop":
					return MetaGeneratorSyntaxKind.KHasLoop;
				case "where":
					return MetaGeneratorSyntaxKind.KWhere;
				case "orderby":
					return MetaGeneratorSyntaxKind.KOrderBy;
				case "descending":
					return MetaGeneratorSyntaxKind.KDescending;
				case "separator":
					return MetaGeneratorSyntaxKind.KSeparator;
				case "null":
					return MetaGeneratorSyntaxKind.KNull;
				case "true":
					return MetaGeneratorSyntaxKind.KTrue;
				case "false":
					return MetaGeneratorSyntaxKind.KFalse;
				case "bool":
					return MetaGeneratorSyntaxKind.KBool;
				case "byte":
					return MetaGeneratorSyntaxKind.KByte;
				case "char":
					return MetaGeneratorSyntaxKind.KChar;
				case "decimal":
					return MetaGeneratorSyntaxKind.KDecimal;
				case "double":
					return MetaGeneratorSyntaxKind.KDouble;
				case "float":
					return MetaGeneratorSyntaxKind.KFloat;
				case "int":
					return MetaGeneratorSyntaxKind.KInt;
				case "long":
					return MetaGeneratorSyntaxKind.KLong;
				case "object":
					return MetaGeneratorSyntaxKind.KObject;
				case "sbyte":
					return MetaGeneratorSyntaxKind.KSByte;
				case "short":
					return MetaGeneratorSyntaxKind.KShort;
				case "string":
					return MetaGeneratorSyntaxKind.KString;
				case "uint":
					return MetaGeneratorSyntaxKind.KUInt;
				case "ulong":
					return MetaGeneratorSyntaxKind.KULong;
				case "ushort":
					return MetaGeneratorSyntaxKind.KUShort;
				case "this":
					return MetaGeneratorSyntaxKind.KThis;
				case "new":
					return MetaGeneratorSyntaxKind.KNew;
				case "is":
					return MetaGeneratorSyntaxKind.KIs;
				case "as":
					return MetaGeneratorSyntaxKind.KAs;
				case "typeof":
					return MetaGeneratorSyntaxKind.KTypeof;
				case "default":
					return MetaGeneratorSyntaxKind.KDefault;
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
				case MetaGeneratorSyntaxKind.IdentifierNormal:
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
				case MetaGeneratorSyntaxKind.TSemicolon:
				case MetaGeneratorSyntaxKind.TColon:
				case MetaGeneratorSyntaxKind.TDot:
				case MetaGeneratorSyntaxKind.TComma:
				case MetaGeneratorSyntaxKind.TAssign:
				case MetaGeneratorSyntaxKind.TAssignPlus:
				case MetaGeneratorSyntaxKind.TAssignMinus:
				case MetaGeneratorSyntaxKind.TAssignAsterisk:
				case MetaGeneratorSyntaxKind.TAssignSlash:
				case MetaGeneratorSyntaxKind.TAssignPercent:
				case MetaGeneratorSyntaxKind.TAssignAmp:
				case MetaGeneratorSyntaxKind.TAssignPipe:
				case MetaGeneratorSyntaxKind.TAssignHat:
				case MetaGeneratorSyntaxKind.TAssignLeftShift:
				case MetaGeneratorSyntaxKind.TAssignRightShift:
				case MetaGeneratorSyntaxKind.TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TCloseParenthesis:
				case MetaGeneratorSyntaxKind.TOpenBracket:
				case MetaGeneratorSyntaxKind.TCloseBracket:
				case MetaGeneratorSyntaxKind.TOpenBrace:
				case MetaGeneratorSyntaxKind.TCloseBrace:
				case MetaGeneratorSyntaxKind.TEquals:
				case MetaGeneratorSyntaxKind.TNotEquals:
				case MetaGeneratorSyntaxKind.TArrow:
				case MetaGeneratorSyntaxKind.TSingleArrow:
				case MetaGeneratorSyntaxKind.TLessThan:
				case MetaGeneratorSyntaxKind.TGreaterThan:
				case MetaGeneratorSyntaxKind.TLessThanOrEquals:
				case MetaGeneratorSyntaxKind.TGreaterThanOrEquals:
				case MetaGeneratorSyntaxKind.TQuestion:
				case MetaGeneratorSyntaxKind.TPlus:
				case MetaGeneratorSyntaxKind.TMinus:
				case MetaGeneratorSyntaxKind.TExclamation:
				case MetaGeneratorSyntaxKind.TTilde:
				case MetaGeneratorSyntaxKind.TAsterisk:
				case MetaGeneratorSyntaxKind.TSlash:
				case MetaGeneratorSyntaxKind.TPercent:
				case MetaGeneratorSyntaxKind.TPlusPlus:
				case MetaGeneratorSyntaxKind.TMinusMinus:
				case MetaGeneratorSyntaxKind.TColonColon:
				case MetaGeneratorSyntaxKind.TAmp:
				case MetaGeneratorSyntaxKind.THat:
				case MetaGeneratorSyntaxKind.TPipe:
				case MetaGeneratorSyntaxKind.TAnd:
				case MetaGeneratorSyntaxKind.TXor:
				case MetaGeneratorSyntaxKind.TOr:
				case MetaGeneratorSyntaxKind.TQuestionQuestion:
					return true;
				case MetaGeneratorSyntaxKind.TH_TCloseParenthesis:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorSyntaxKind.IntegerLiteral:
					return true;
				case MetaGeneratorSyntaxKind.DecimalLiteral:
					return true;
				case MetaGeneratorSyntaxKind.ScientificLiteral:
					return true;
				case MetaGeneratorSyntaxKind.DateTimeOffsetLiteral:
					return true;
				case MetaGeneratorSyntaxKind.DateTimeLiteral:
					return true;
				case MetaGeneratorSyntaxKind.DateLiteral:
					return true;
				case MetaGeneratorSyntaxKind.TimeLiteral:
					return true;
				case MetaGeneratorSyntaxKind.GuidLiteral:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorSyntaxKind.CharLiteral:
					return true;
				case MetaGeneratorSyntaxKind.RegularStringLiteral:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorSyntaxKind.LLineComment:
					return true;
				case MetaGeneratorSyntaxKind.LMultiLineComment:
					return true;
				default:
					return false;
			}
		}
		public bool IsTemplateControl(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorSyntaxKind.TemplateLineControl:
					return true;
				case MetaGeneratorSyntaxKind.TemplateStatementStart:
					return true;
				case MetaGeneratorSyntaxKind.TemplateStatementEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsTemplateOutput(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaGeneratorSyntaxKind.TemplateOutput:
					return true;
				case MetaGeneratorSyntaxKind.TemplateCrLf:
					return true;
				case MetaGeneratorSyntaxKind.TemplateLineBreak:
					return true;
				default:
					return false;
			}
		}

        public override bool IsInNamespaceOrTypeContext(SyntaxNode node)
        {
            return false;
        }

        public override bool IsStatement(SyntaxNode syntax)
        {
            return false;
        }

        public override bool IsExpression(SyntaxNode node)
        {
            return false;
        }
}
}


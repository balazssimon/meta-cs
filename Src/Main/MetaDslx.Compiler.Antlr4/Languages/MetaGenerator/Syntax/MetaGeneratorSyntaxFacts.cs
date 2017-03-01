using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Languages.MetaGenerator.Syntax
{
	public enum MetaGeneratorTokenKind : int
	{
		None = 0,
		Comment,
		Identifier,
		Keyword,
		MetaGeneratorTemplateControl,
		MetaGeneratorTemplateOutput,
		Number,
		Operator,
		String
	}

	public class MetaGeneratorSyntaxFacts : SyntaxFacts
	{
		public static readonly MetaGeneratorSyntaxFacts Instance = new MetaGeneratorSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)MetaGeneratorSyntaxKind.None; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)MetaGeneratorSyntaxKind.None; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsToken(MetaGeneratorSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaGeneratorSyntaxKind.Eof:
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
				case MetaGeneratorSyntaxKind.UTF8BOM:
				case MetaGeneratorSyntaxKind.WHITESPACE:
				case MetaGeneratorSyntaxKind.CRLF:
				case MetaGeneratorSyntaxKind.LINEBREAK:
				case MetaGeneratorSyntaxKind.LINE_COMMENT:
				case MetaGeneratorSyntaxKind.COMMENT:
				case MetaGeneratorSyntaxKind.DoubleQuoteVerbatimStringLiteral:
				case MetaGeneratorSyntaxKind.TH_CRLF:
				case MetaGeneratorSyntaxKind.TH_LINEBREAK:
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
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsFixedToken(MetaGeneratorSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaGeneratorSyntaxKind.Eof:
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
				case MetaGeneratorSyntaxKind.KLoop:
				case MetaGeneratorSyntaxKind.KHasLoop:
				case MetaGeneratorSyntaxKind.KWhere:
				case MetaGeneratorSyntaxKind.KOrderBy:
				case MetaGeneratorSyntaxKind.KDescending:
				case MetaGeneratorSyntaxKind.KSeparator:
				case MetaGeneratorSyntaxKind.KNull:
				case MetaGeneratorSyntaxKind.KTrue:
				case MetaGeneratorSyntaxKind.KFalse:
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

		public override string GetText(int rawKind)
		{
			return this.GetText((MetaGeneratorSyntaxKind)rawKind);
		}

		public string GetText(MetaGeneratorSyntaxKind kind)
		{
			switch (kind)
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

		public MetaGeneratorSyntaxKind GetKind(string text)
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

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((MetaGeneratorSyntaxKind)rawKind);
		}

		public string GetKindText(MetaGeneratorSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return false;
			}
		}

		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsKeyword(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
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
		public bool IsOperator(int rawKind)
		{
			return this.IsOperator((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsOperator(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
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
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsIdentifier(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaGeneratorSyntaxKind.IdentifierNormal:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsNumber(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
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
		public bool IsString(int rawKind)
		{
			return this.IsString((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsString(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaGeneratorSyntaxKind.CharLiteral:
					return true;
				case MetaGeneratorSyntaxKind.RegularStringLiteral:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsComment(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaGeneratorSyntaxKind.LINE_COMMENT:
					return true;
				case MetaGeneratorSyntaxKind.COMMENT:
					return true;
				default:
					return false;
			}
		}
		public bool IsMetaGeneratorTemplateControl(int rawKind)
		{
			return this.IsMetaGeneratorTemplateControl((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsMetaGeneratorTemplateControl(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
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
		public bool IsMetaGeneratorTemplateOutput(int rawKind)
		{
			return this.IsMetaGeneratorTemplateOutput((MetaGeneratorSyntaxKind)rawKind);
		}

		public bool IsMetaGeneratorTemplateOutput(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
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

		public MetaGeneratorTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((MetaGeneratorSyntaxKind)rawKind);
		}

		public MetaGeneratorTokenKind GetTokenKind(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
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
					return MetaGeneratorTokenKind.Keyword;
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
				case MetaGeneratorSyntaxKind.LINE_COMMENT:
					return MetaGeneratorTokenKind.Comment;
				case MetaGeneratorSyntaxKind.COMMENT:
					return MetaGeneratorTokenKind.Comment;
				case MetaGeneratorSyntaxKind.TH_TCloseParenthesis:
					return MetaGeneratorTokenKind.Operator;
				case MetaGeneratorSyntaxKind.KEndTemplate:
					return MetaGeneratorTokenKind.Keyword;
				case MetaGeneratorSyntaxKind.TemplateLineControl:
					return MetaGeneratorTokenKind.MetaGeneratorTemplateControl;
				case MetaGeneratorSyntaxKind.TemplateOutput:
					return MetaGeneratorTokenKind.MetaGeneratorTemplateOutput;
				case MetaGeneratorSyntaxKind.TemplateCrLf:
					return MetaGeneratorTokenKind.MetaGeneratorTemplateOutput;
				case MetaGeneratorSyntaxKind.TemplateLineBreak:
					return MetaGeneratorTokenKind.MetaGeneratorTemplateOutput;
				case MetaGeneratorSyntaxKind.TemplateStatementStart:
					return MetaGeneratorTokenKind.MetaGeneratorTemplateControl;
				case MetaGeneratorSyntaxKind.TemplateStatementEnd:
					return MetaGeneratorTokenKind.MetaGeneratorTemplateControl;
				default:
					return MetaGeneratorTokenKind.None;
			}
		}
	}
}


using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Languages.MetaGenerator.Syntax
{
	public enum MetaGeneratorTokenKind : int
	{
		None = 0,
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
				case MetaGeneratorSyntaxKind.TH_WHITESPACE:
				case MetaGeneratorSyntaxKind.TH_KEnd:
				case MetaGeneratorSyntaxKind.TH_KFor:
				case MetaGeneratorSyntaxKind.TH_KForEach:
				case MetaGeneratorSyntaxKind.TH_KIn:
				case MetaGeneratorSyntaxKind.TH_KIf:
				case MetaGeneratorSyntaxKind.TH_KElse:
				case MetaGeneratorSyntaxKind.TH_KLoop:
				case MetaGeneratorSyntaxKind.TH_KHasLoop:
				case MetaGeneratorSyntaxKind.TH_KWhere:
				case MetaGeneratorSyntaxKind.TH_KOrderBy:
				case MetaGeneratorSyntaxKind.TH_KDescending:
				case MetaGeneratorSyntaxKind.TH_KSeparator:
				case MetaGeneratorSyntaxKind.TH_KNull:
				case MetaGeneratorSyntaxKind.TH_KTrue:
				case MetaGeneratorSyntaxKind.TH_KFalse:
				case MetaGeneratorSyntaxKind.TH_KBool:
				case MetaGeneratorSyntaxKind.TH_KByte:
				case MetaGeneratorSyntaxKind.TH_KChar:
				case MetaGeneratorSyntaxKind.TH_KDecimal:
				case MetaGeneratorSyntaxKind.TH_KDouble:
				case MetaGeneratorSyntaxKind.TH_KFloat:
				case MetaGeneratorSyntaxKind.TH_KInt:
				case MetaGeneratorSyntaxKind.TH_KLong:
				case MetaGeneratorSyntaxKind.TH_KObject:
				case MetaGeneratorSyntaxKind.TH_KSByte:
				case MetaGeneratorSyntaxKind.TH_KShort:
				case MetaGeneratorSyntaxKind.TH_KString:
				case MetaGeneratorSyntaxKind.TH_KUInt:
				case MetaGeneratorSyntaxKind.TH_KULong:
				case MetaGeneratorSyntaxKind.TH_KUShort:
				case MetaGeneratorSyntaxKind.TH_KThis:
				case MetaGeneratorSyntaxKind.TH_KNew:
				case MetaGeneratorSyntaxKind.TH_KIs:
				case MetaGeneratorSyntaxKind.TH_KAs:
				case MetaGeneratorSyntaxKind.TH_KTypeof:
				case MetaGeneratorSyntaxKind.TH_KDefault:
				case MetaGeneratorSyntaxKind.TH_TSemicolon:
				case MetaGeneratorSyntaxKind.TH_TColon:
				case MetaGeneratorSyntaxKind.TH_TDot:
				case MetaGeneratorSyntaxKind.TH_TComma:
				case MetaGeneratorSyntaxKind.TH_TAssign:
				case MetaGeneratorSyntaxKind.TH_TAssignPlus:
				case MetaGeneratorSyntaxKind.TH_TAssignMinus:
				case MetaGeneratorSyntaxKind.TH_TAssignAsterisk:
				case MetaGeneratorSyntaxKind.TH_TAssignSlash:
				case MetaGeneratorSyntaxKind.TH_TAssignPercent:
				case MetaGeneratorSyntaxKind.TH_TAssignAmp:
				case MetaGeneratorSyntaxKind.TH_TAssignPipe:
				case MetaGeneratorSyntaxKind.TH_TAssignHat:
				case MetaGeneratorSyntaxKind.TH_TAssignLeftShift:
				case MetaGeneratorSyntaxKind.TH_TAssignRightShift:
				case MetaGeneratorSyntaxKind.TH_TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TH_TCloseParenthesis:
				case MetaGeneratorSyntaxKind.TH_TOpenBracket:
				case MetaGeneratorSyntaxKind.TH_TCloseBracket:
				case MetaGeneratorSyntaxKind.TH_TOpenBrace:
				case MetaGeneratorSyntaxKind.TH_TCloseBrace:
				case MetaGeneratorSyntaxKind.TH_TEquals:
				case MetaGeneratorSyntaxKind.TH_TNotEquals:
				case MetaGeneratorSyntaxKind.TH_TArrow:
				case MetaGeneratorSyntaxKind.TH_TSingleArrow:
				case MetaGeneratorSyntaxKind.TH_TLessThan:
				case MetaGeneratorSyntaxKind.TH_TGreaterThan:
				case MetaGeneratorSyntaxKind.TH_TLessThanOrEquals:
				case MetaGeneratorSyntaxKind.TH_TGreaterThanOrEquals:
				case MetaGeneratorSyntaxKind.TH_TQuestion:
				case MetaGeneratorSyntaxKind.TH_TPlus:
				case MetaGeneratorSyntaxKind.TH_TMinus:
				case MetaGeneratorSyntaxKind.TH_TExclamation:
				case MetaGeneratorSyntaxKind.TH_TTilde:
				case MetaGeneratorSyntaxKind.TH_TAsterisk:
				case MetaGeneratorSyntaxKind.TH_TSlash:
				case MetaGeneratorSyntaxKind.TH_TPercent:
				case MetaGeneratorSyntaxKind.TH_TPlusPlus:
				case MetaGeneratorSyntaxKind.TH_TMinusMinus:
				case MetaGeneratorSyntaxKind.TH_TColonColon:
				case MetaGeneratorSyntaxKind.TH_TAmp:
				case MetaGeneratorSyntaxKind.TH_THat:
				case MetaGeneratorSyntaxKind.TH_TPipe:
				case MetaGeneratorSyntaxKind.TH_TAnd:
				case MetaGeneratorSyntaxKind.TH_TXor:
				case MetaGeneratorSyntaxKind.TH_TOr:
				case MetaGeneratorSyntaxKind.TH_TQuestionQuestion:
				case MetaGeneratorSyntaxKind.TH_IdentifierNormal:
				case MetaGeneratorSyntaxKind.TH_IntegerLiteral:
				case MetaGeneratorSyntaxKind.TH_DecimalLiteral:
				case MetaGeneratorSyntaxKind.TH_ScientificLiteral:
				case MetaGeneratorSyntaxKind.TH_DateTimeOffsetLiteral:
				case MetaGeneratorSyntaxKind.TH_DateTimeLiteral:
				case MetaGeneratorSyntaxKind.TH_DateLiteral:
				case MetaGeneratorSyntaxKind.TH_TimeLiteral:
				case MetaGeneratorSyntaxKind.TH_CharLiteral:
				case MetaGeneratorSyntaxKind.TH_RegularStringLiteral:
				case MetaGeneratorSyntaxKind.TH_GuidLiteral:
				case MetaGeneratorSyntaxKind.KEndTemplate:
				case MetaGeneratorSyntaxKind.TemplateLineControl:
				case MetaGeneratorSyntaxKind.TemplateOutput:
				case MetaGeneratorSyntaxKind.TemplateCrLf:
				case MetaGeneratorSyntaxKind.TemplateLineBreak:
				case MetaGeneratorSyntaxKind.TemplateStatementStart:
				case MetaGeneratorSyntaxKind.TemplateStatementCrLf:
				case MetaGeneratorSyntaxKind.TemplateStatementLineBreak:
				case MetaGeneratorSyntaxKind.TemplateStatementEnd:
				case MetaGeneratorSyntaxKind.TemplateStatement_WHITESPACE:
				case MetaGeneratorSyntaxKind.TS_KSwitch:
				case MetaGeneratorSyntaxKind.TS_KCase:
				case MetaGeneratorSyntaxKind.TS_KType:
				case MetaGeneratorSyntaxKind.TS_KEnd:
				case MetaGeneratorSyntaxKind.TS_KFor:
				case MetaGeneratorSyntaxKind.TS_KForEach:
				case MetaGeneratorSyntaxKind.TS_KIn:
				case MetaGeneratorSyntaxKind.TS_KIf:
				case MetaGeneratorSyntaxKind.TS_KElse:
				case MetaGeneratorSyntaxKind.TS_KLoop:
				case MetaGeneratorSyntaxKind.TS_KHasLoop:
				case MetaGeneratorSyntaxKind.TS_KWhere:
				case MetaGeneratorSyntaxKind.TS_KOrderBy:
				case MetaGeneratorSyntaxKind.TS_KDescending:
				case MetaGeneratorSyntaxKind.TS_KSeparator:
				case MetaGeneratorSyntaxKind.TS_KNull:
				case MetaGeneratorSyntaxKind.TS_KTrue:
				case MetaGeneratorSyntaxKind.TS_KFalse:
				case MetaGeneratorSyntaxKind.TS_KBool:
				case MetaGeneratorSyntaxKind.TS_KByte:
				case MetaGeneratorSyntaxKind.TS_KChar:
				case MetaGeneratorSyntaxKind.TS_KDecimal:
				case MetaGeneratorSyntaxKind.TS_KDouble:
				case MetaGeneratorSyntaxKind.TS_KFloat:
				case MetaGeneratorSyntaxKind.TS_KInt:
				case MetaGeneratorSyntaxKind.TS_KLong:
				case MetaGeneratorSyntaxKind.TS_KObject:
				case MetaGeneratorSyntaxKind.TS_KSByte:
				case MetaGeneratorSyntaxKind.TS_KShort:
				case MetaGeneratorSyntaxKind.TS_KString:
				case MetaGeneratorSyntaxKind.TS_KUInt:
				case MetaGeneratorSyntaxKind.TS_KULong:
				case MetaGeneratorSyntaxKind.TS_KUShort:
				case MetaGeneratorSyntaxKind.TS_KThis:
				case MetaGeneratorSyntaxKind.TS_KNew:
				case MetaGeneratorSyntaxKind.TS_KIs:
				case MetaGeneratorSyntaxKind.TS_KAs:
				case MetaGeneratorSyntaxKind.TS_KTypeof:
				case MetaGeneratorSyntaxKind.TS_KDefault:
				case MetaGeneratorSyntaxKind.TS_TSemicolon:
				case MetaGeneratorSyntaxKind.TS_TColon:
				case MetaGeneratorSyntaxKind.TS_TDot:
				case MetaGeneratorSyntaxKind.TS_TComma:
				case MetaGeneratorSyntaxKind.TS_TAssign:
				case MetaGeneratorSyntaxKind.TS_TAssignPlus:
				case MetaGeneratorSyntaxKind.TS_TAssignMinus:
				case MetaGeneratorSyntaxKind.TS_TAssignAsterisk:
				case MetaGeneratorSyntaxKind.TS_TAssignSlash:
				case MetaGeneratorSyntaxKind.TS_TAssignPercent:
				case MetaGeneratorSyntaxKind.TS_TAssignAmp:
				case MetaGeneratorSyntaxKind.TS_TAssignPipe:
				case MetaGeneratorSyntaxKind.TS_TAssignHat:
				case MetaGeneratorSyntaxKind.TS_TAssignLeftShift:
				case MetaGeneratorSyntaxKind.TS_TAssignRightShift:
				case MetaGeneratorSyntaxKind.TS_TOpenParenthesis:
				case MetaGeneratorSyntaxKind.TS_TCloseParenthesis:
				case MetaGeneratorSyntaxKind.TS_TOpenBracket:
				case MetaGeneratorSyntaxKind.TS_TCloseBracket:
				case MetaGeneratorSyntaxKind.TS_TOpenBrace:
				case MetaGeneratorSyntaxKind.TS_TCloseBrace:
				case MetaGeneratorSyntaxKind.TS_TEquals:
				case MetaGeneratorSyntaxKind.TS_TNotEquals:
				case MetaGeneratorSyntaxKind.TS_TArrow:
				case MetaGeneratorSyntaxKind.TS_TSingleArrow:
				case MetaGeneratorSyntaxKind.TS_TLessThan:
				case MetaGeneratorSyntaxKind.TS_TGreaterThan:
				case MetaGeneratorSyntaxKind.TS_TLessThanOrEquals:
				case MetaGeneratorSyntaxKind.TS_TGreaterThanOrEquals:
				case MetaGeneratorSyntaxKind.TS_TQuestion:
				case MetaGeneratorSyntaxKind.TS_TPlus:
				case MetaGeneratorSyntaxKind.TS_TMinus:
				case MetaGeneratorSyntaxKind.TS_TExclamation:
				case MetaGeneratorSyntaxKind.TS_TTilde:
				case MetaGeneratorSyntaxKind.TS_TAsterisk:
				case MetaGeneratorSyntaxKind.TS_TSlash:
				case MetaGeneratorSyntaxKind.TS_TPercent:
				case MetaGeneratorSyntaxKind.TS_TPlusPlus:
				case MetaGeneratorSyntaxKind.TS_TMinusMinus:
				case MetaGeneratorSyntaxKind.TS_TColonColon:
				case MetaGeneratorSyntaxKind.TS_TAmp:
				case MetaGeneratorSyntaxKind.TS_THat:
				case MetaGeneratorSyntaxKind.TS_TPipe:
				case MetaGeneratorSyntaxKind.TS_TAnd:
				case MetaGeneratorSyntaxKind.TS_TXor:
				case MetaGeneratorSyntaxKind.TS_TOr:
				case MetaGeneratorSyntaxKind.TS_TQuestionQuestion:
				case MetaGeneratorSyntaxKind.TS_IdentifierNormal:
				case MetaGeneratorSyntaxKind.TS_IntegerLiteral:
				case MetaGeneratorSyntaxKind.TS_DecimalLiteral:
				case MetaGeneratorSyntaxKind.TS_ScientificLiteral:
				case MetaGeneratorSyntaxKind.TS_DateTimeOffsetLiteral:
				case MetaGeneratorSyntaxKind.TS_DateTimeLiteral:
				case MetaGeneratorSyntaxKind.TS_DateLiteral:
				case MetaGeneratorSyntaxKind.TS_TimeLiteral:
				case MetaGeneratorSyntaxKind.TS_CharLiteral:
				case MetaGeneratorSyntaxKind.TS_RegularStringLiteral:
				case MetaGeneratorSyntaxKind.TS_GuidLiteral:
				case MetaGeneratorSyntaxKind.TemplateStatement_COMMENT_CRLF:
				case MetaGeneratorSyntaxKind.TemplateStatement_COMMENT_LINEBREAK:
				case MetaGeneratorSyntaxKind.TemplateStatement_COMMENT:
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
				case MetaGeneratorSyntaxKind.TOpenBracket:
					return "[";
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
				case MetaGeneratorSyntaxKind.TAsterisk:
					return "*";
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
				case "[":
					return MetaGeneratorSyntaxKind.TOpenBracket;
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
				case "*":
					return MetaGeneratorSyntaxKind.TAsterisk;
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


		public MetaGeneratorTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((MetaGeneratorSyntaxKind)rawKind);
		}

		public MetaGeneratorTokenKind GetTokenKind(MetaGeneratorSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return MetaGeneratorTokenKind.None;
			}
		}
	}
}


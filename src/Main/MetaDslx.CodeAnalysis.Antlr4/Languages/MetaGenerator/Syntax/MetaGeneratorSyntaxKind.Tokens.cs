// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaGenerator.Syntax
{
	public class MetaGeneratorTokensSyntaxKind : SyntaxKind
	{
        public static readonly MetaGeneratorTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly MetaGeneratorTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly MetaGeneratorTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly MetaGeneratorTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KGenerator = nameof(KGenerator); // 2
		public const string KUsing = nameof(KUsing); // 3
		public const string KConfiguration = nameof(KConfiguration); // 4
		public const string KProperties = nameof(KProperties); // 5
		public const string KTemplate = nameof(KTemplate); // 6
		public const string KFunction = nameof(KFunction); // 7
		public const string KExtern = nameof(KExtern); // 8
		public const string KReturn = nameof(KReturn); // 9
		public const string KSwitch = nameof(KSwitch); // 10
		public const string KCase = nameof(KCase); // 11
		public const string KType = nameof(KType); // 12
		public const string KVoid = nameof(KVoid); // 13
		public const string KEnd = nameof(KEnd); // 14
		public const string KFor = nameof(KFor); // 15
		public const string KForEach = nameof(KForEach); // 16
		public const string KIn = nameof(KIn); // 17
		public const string KIf = nameof(KIf); // 18
		public const string KElse = nameof(KElse); // 19
		public const string KRepeat = nameof(KRepeat); // 20
		public const string KUntil = nameof(KUntil); // 21
		public const string KWhile = nameof(KWhile); // 22
		public const string KLoop = nameof(KLoop); // 23
		public const string KHasLoop = nameof(KHasLoop); // 24
		public const string KWhere = nameof(KWhere); // 25
		public const string KOrderBy = nameof(KOrderBy); // 26
		public const string KDescending = nameof(KDescending); // 27
		public const string KSeparator = nameof(KSeparator); // 28
		public const string KNull = nameof(KNull); // 29
		public const string KTrue = nameof(KTrue); // 30
		public const string KFalse = nameof(KFalse); // 31
		public const string KBool = nameof(KBool); // 32
		public const string KByte = nameof(KByte); // 33
		public const string KChar = nameof(KChar); // 34
		public const string KDecimal = nameof(KDecimal); // 35
		public const string KDouble = nameof(KDouble); // 36
		public const string KFloat = nameof(KFloat); // 37
		public const string KInt = nameof(KInt); // 38
		public const string KLong = nameof(KLong); // 39
		public const string KObject = nameof(KObject); // 40
		public const string KSByte = nameof(KSByte); // 41
		public const string KShort = nameof(KShort); // 42
		public const string KString = nameof(KString); // 43
		public const string KUInt = nameof(KUInt); // 44
		public const string KULong = nameof(KULong); // 45
		public const string KUShort = nameof(KUShort); // 46
		public const string KThis = nameof(KThis); // 47
		public const string KNew = nameof(KNew); // 48
		public const string KIs = nameof(KIs); // 49
		public const string KAs = nameof(KAs); // 50
		public const string KTypeof = nameof(KTypeof); // 51
		public const string KDefault = nameof(KDefault); // 52
		public const string TSemicolon = nameof(TSemicolon); // 53
		public const string TColon = nameof(TColon); // 54
		public const string TDot = nameof(TDot); // 55
		public const string TComma = nameof(TComma); // 56
		public const string TAssign = nameof(TAssign); // 57
		public const string TAssignPlus = nameof(TAssignPlus); // 58
		public const string TAssignMinus = nameof(TAssignMinus); // 59
		public const string TAssignAsterisk = nameof(TAssignAsterisk); // 60
		public const string TAssignSlash = nameof(TAssignSlash); // 61
		public const string TAssignPercent = nameof(TAssignPercent); // 62
		public const string TAssignAmp = nameof(TAssignAmp); // 63
		public const string TAssignPipe = nameof(TAssignPipe); // 64
		public const string TAssignHat = nameof(TAssignHat); // 65
		public const string TAssignLeftShift = nameof(TAssignLeftShift); // 66
		public const string TAssignRightShift = nameof(TAssignRightShift); // 67
		public const string TOpenParenthesis = nameof(TOpenParenthesis); // 68
		public const string TCloseParenthesis = nameof(TCloseParenthesis); // 69
		public const string TOpenBracket = nameof(TOpenBracket); // 70
		public const string TCloseBracket = nameof(TCloseBracket); // 71
		public const string TOpenBrace = nameof(TOpenBrace); // 72
		public const string TCloseBrace = nameof(TCloseBrace); // 73
		public const string TEquals = nameof(TEquals); // 74
		public const string TNotEquals = nameof(TNotEquals); // 75
		public const string TArrow = nameof(TArrow); // 76
		public const string TSingleArrow = nameof(TSingleArrow); // 77
		public const string TLessThan = nameof(TLessThan); // 78
		public const string TGreaterThan = nameof(TGreaterThan); // 79
		public const string TLessThanOrEquals = nameof(TLessThanOrEquals); // 80
		public const string TGreaterThanOrEquals = nameof(TGreaterThanOrEquals); // 81
		public const string TQuestion = nameof(TQuestion); // 82
		public const string TPlus = nameof(TPlus); // 83
		public const string TMinus = nameof(TMinus); // 84
		public const string TExclamation = nameof(TExclamation); // 85
		public const string TTilde = nameof(TTilde); // 86
		public const string TAsterisk = nameof(TAsterisk); // 87
		public const string TSlash = nameof(TSlash); // 88
		public const string TPercent = nameof(TPercent); // 89
		public const string TPlusPlus = nameof(TPlusPlus); // 90
		public const string TMinusMinus = nameof(TMinusMinus); // 91
		public const string TColonColon = nameof(TColonColon); // 92
		public const string TAmp = nameof(TAmp); // 93
		public const string THat = nameof(THat); // 94
		public const string TPipe = nameof(TPipe); // 95
		public const string TAnd = nameof(TAnd); // 96
		public const string TXor = nameof(TXor); // 97
		public const string TOr = nameof(TOr); // 98
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 99
		public const string IdentifierNormal = nameof(IdentifierNormal); // 100
		public const string IntegerLiteral = nameof(IntegerLiteral); // 101
		public const string DecimalLiteral = nameof(DecimalLiteral); // 102
		public const string ScientificLiteral = nameof(ScientificLiteral); // 103
		public const string DateTimeOffsetLiteral = nameof(DateTimeOffsetLiteral); // 104
		public const string DateTimeLiteral = nameof(DateTimeLiteral); // 105
		public const string DateLiteral = nameof(DateLiteral); // 106
		public const string TimeLiteral = nameof(TimeLiteral); // 107
		public const string CharLiteral = nameof(CharLiteral); // 108
		public const string RegularStringLiteral = nameof(RegularStringLiteral); // 109
		public const string GuidLiteral = nameof(GuidLiteral); // 110
		public const string LUtf8Bom = nameof(LUtf8Bom); // 111
		public const string LWhitespace = nameof(LWhitespace); // 112
		public const string LCrLf = nameof(LCrLf); // 113
		public const string LLineBreak = nameof(LLineBreak); // 114
		public const string LLineComment = nameof(LLineComment); // 115
		public const string LMultiLineComment = nameof(LMultiLineComment); // 116
		public const string DoubleQuoteVerbatimStringLiteral = nameof(DoubleQuoteVerbatimStringLiteral); // 117
		public const string TH_TOpenParenthesis = nameof(TH_TOpenParenthesis); // 118
		public const string TH_TCloseParenthesis = nameof(TH_TCloseParenthesis); // 119
		public const string KEndTemplate = nameof(KEndTemplate); // 120
		public const string TemplateLineControl = nameof(TemplateLineControl); // 121
		public const string TemplateOutput = nameof(TemplateOutput); // 122
		public const string TemplateCrLf = nameof(TemplateCrLf); // 123
		public const string TemplateLineBreak = nameof(TemplateLineBreak); // 124
		public const string TemplateStatementStart = nameof(TemplateStatementStart); // 125
		public const string TemplateStatementEnd = nameof(TemplateStatementEnd); // 126
		public const string TS_TOpenBracket = nameof(TS_TOpenBracket); // 127
		public const string TS_TCloseBracket = nameof(TS_TCloseBracket); // 128
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 129
		public const string COMMENT_START = nameof(COMMENT_START); // 130

		protected MetaGeneratorTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected MetaGeneratorTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaGeneratorTokensSyntaxKind()
        {
            EnumObject.AutoInit<MetaGeneratorTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = COMMENT_START;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = DoubleQuoteVerbatimStringLiteralStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator MetaGeneratorTokensSyntaxKind(string name)
        {
            return FromString<MetaGeneratorTokensSyntaxKind>(name);
        }

        public static explicit operator MetaGeneratorTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<MetaGeneratorTokensSyntaxKind>(value);
        }

	}
}


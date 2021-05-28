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
		public const string KStandalone = nameof(KStandalone); // 2
		public const string KGenerator = nameof(KGenerator); // 3
		public const string KUsing = nameof(KUsing); // 4
		public const string KConfiguration = nameof(KConfiguration); // 5
		public const string KProperties = nameof(KProperties); // 6
		public const string KTemplate = nameof(KTemplate); // 7
		public const string KFunction = nameof(KFunction); // 8
		public const string KExtern = nameof(KExtern); // 9
		public const string KReturn = nameof(KReturn); // 10
		public const string KSwitch = nameof(KSwitch); // 11
		public const string KCase = nameof(KCase); // 12
		public const string KType = nameof(KType); // 13
		public const string KVoid = nameof(KVoid); // 14
		public const string KEnd = nameof(KEnd); // 15
		public const string KFor = nameof(KFor); // 16
		public const string KForEach = nameof(KForEach); // 17
		public const string KIn = nameof(KIn); // 18
		public const string KIf = nameof(KIf); // 19
		public const string KElse = nameof(KElse); // 20
		public const string KRepeat = nameof(KRepeat); // 21
		public const string KUntil = nameof(KUntil); // 22
		public const string KWhile = nameof(KWhile); // 23
		public const string KLoop = nameof(KLoop); // 24
		public const string KHasLoop = nameof(KHasLoop); // 25
		public const string KWhere = nameof(KWhere); // 26
		public const string KOrderBy = nameof(KOrderBy); // 27
		public const string KDescending = nameof(KDescending); // 28
		public const string KSeparator = nameof(KSeparator); // 29
		public const string KNull = nameof(KNull); // 30
		public const string KTrue = nameof(KTrue); // 31
		public const string KFalse = nameof(KFalse); // 32
		public const string KBool = nameof(KBool); // 33
		public const string KByte = nameof(KByte); // 34
		public const string KChar = nameof(KChar); // 35
		public const string KDecimal = nameof(KDecimal); // 36
		public const string KDouble = nameof(KDouble); // 37
		public const string KFloat = nameof(KFloat); // 38
		public const string KInt = nameof(KInt); // 39
		public const string KLong = nameof(KLong); // 40
		public const string KObject = nameof(KObject); // 41
		public const string KSByte = nameof(KSByte); // 42
		public const string KShort = nameof(KShort); // 43
		public const string KString = nameof(KString); // 44
		public const string KUInt = nameof(KUInt); // 45
		public const string KULong = nameof(KULong); // 46
		public const string KUShort = nameof(KUShort); // 47
		public const string KThis = nameof(KThis); // 48
		public const string KNew = nameof(KNew); // 49
		public const string KIs = nameof(KIs); // 50
		public const string KAs = nameof(KAs); // 51
		public const string KTypeof = nameof(KTypeof); // 52
		public const string KDefault = nameof(KDefault); // 53
		public const string TSemicolon = nameof(TSemicolon); // 54
		public const string TColon = nameof(TColon); // 55
		public const string TDot = nameof(TDot); // 56
		public const string TQuestionDot = nameof(TQuestionDot); // 57
		public const string TComma = nameof(TComma); // 58
		public const string TAssign = nameof(TAssign); // 59
		public const string TAssignPlus = nameof(TAssignPlus); // 60
		public const string TAssignMinus = nameof(TAssignMinus); // 61
		public const string TAssignAsterisk = nameof(TAssignAsterisk); // 62
		public const string TAssignSlash = nameof(TAssignSlash); // 63
		public const string TAssignPercent = nameof(TAssignPercent); // 64
		public const string TAssignAmp = nameof(TAssignAmp); // 65
		public const string TAssignPipe = nameof(TAssignPipe); // 66
		public const string TAssignHat = nameof(TAssignHat); // 67
		public const string TAssignLeftShift = nameof(TAssignLeftShift); // 68
		public const string TAssignRightShift = nameof(TAssignRightShift); // 69
		public const string TOpenParenthesis = nameof(TOpenParenthesis); // 70
		public const string TCloseParenthesis = nameof(TCloseParenthesis); // 71
		public const string TOpenBracket = nameof(TOpenBracket); // 72
		public const string TCloseBracket = nameof(TCloseBracket); // 73
		public const string TOpenBrace = nameof(TOpenBrace); // 74
		public const string TCloseBrace = nameof(TCloseBrace); // 75
		public const string TEquals = nameof(TEquals); // 76
		public const string TNotEquals = nameof(TNotEquals); // 77
		public const string TArrow = nameof(TArrow); // 78
		public const string TSingleArrow = nameof(TSingleArrow); // 79
		public const string TLessThan = nameof(TLessThan); // 80
		public const string TGreaterThan = nameof(TGreaterThan); // 81
		public const string TLessThanOrEquals = nameof(TLessThanOrEquals); // 82
		public const string TGreaterThanOrEquals = nameof(TGreaterThanOrEquals); // 83
		public const string TQuestion = nameof(TQuestion); // 84
		public const string TPlus = nameof(TPlus); // 85
		public const string TMinus = nameof(TMinus); // 86
		public const string TExclamation = nameof(TExclamation); // 87
		public const string TTilde = nameof(TTilde); // 88
		public const string TAsterisk = nameof(TAsterisk); // 89
		public const string TSlash = nameof(TSlash); // 90
		public const string TPercent = nameof(TPercent); // 91
		public const string TPlusPlus = nameof(TPlusPlus); // 92
		public const string TMinusMinus = nameof(TMinusMinus); // 93
		public const string TColonColon = nameof(TColonColon); // 94
		public const string TAmp = nameof(TAmp); // 95
		public const string THat = nameof(THat); // 96
		public const string TPipe = nameof(TPipe); // 97
		public const string TAnd = nameof(TAnd); // 98
		public const string TXor = nameof(TXor); // 99
		public const string TOr = nameof(TOr); // 100
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 101
		public const string IdentifierNormal = nameof(IdentifierNormal); // 102
		public const string LInteger = nameof(LInteger); // 103
		public const string LDecimal = nameof(LDecimal); // 104
		public const string LScientific = nameof(LScientific); // 105
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 106
		public const string LDateTime = nameof(LDateTime); // 107
		public const string LDate = nameof(LDate); // 108
		public const string LTime = nameof(LTime); // 109
		public const string LChar = nameof(LChar); // 110
		public const string LRegularString = nameof(LRegularString); // 111
		public const string LGuid = nameof(LGuid); // 112
		public const string LUtf8Bom = nameof(LUtf8Bom); // 113
		public const string LWhitespace = nameof(LWhitespace); // 114
		public const string LCrLf = nameof(LCrLf); // 115
		public const string LLineBreak = nameof(LLineBreak); // 116
		public const string LLineComment = nameof(LLineComment); // 117
		public const string LMultiLineComment = nameof(LMultiLineComment); // 118
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 119
		public const string TH_TOpenParenthesis = nameof(TH_TOpenParenthesis); // 120
		public const string TH_TCloseParenthesis = nameof(TH_TCloseParenthesis); // 121
		public const string KEndTemplate = nameof(KEndTemplate); // 122
		public const string LTemplateLineControl = nameof(LTemplateLineControl); // 123
		public const string LTemplateOutput = nameof(LTemplateOutput); // 124
		public const string LTemplateCrLf = nameof(LTemplateCrLf); // 125
		public const string LTemplateLineBreak = nameof(LTemplateLineBreak); // 126
		public const string TTemplateStatementStart = nameof(TTemplateStatementStart); // 127
		public const string TTemplateStatementEnd = nameof(TTemplateStatementEnd); // 128
		public const string TS_TOpenBracket = nameof(TS_TOpenBracket); // 129
		public const string TS_TCloseBracket = nameof(TS_TCloseBracket); // 130
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 131
		public const string COMMENT_START = nameof(COMMENT_START); // 132

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


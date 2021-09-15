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

namespace MetaDslx.Languages.Core.Syntax
{
	public class CoreTokensSyntaxKind : SyntaxKind
	{
        public static readonly CoreTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly CoreTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly CoreTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly CoreTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KUsing = nameof(KUsing); // 2
		public const string KExtern = nameof(KExtern); // 3
		public const string KAbstract = nameof(KAbstract); // 4
		public const string KInterface = nameof(KInterface); // 5
		public const string KClass = nameof(KClass); // 6
		public const string KStruct = nameof(KStruct); // 7
		public const string KEnum = nameof(KEnum); // 8
		public const string KNew = nameof(KNew); // 9
		public const string KNull = nameof(KNull); // 10
		public const string KTrue = nameof(KTrue); // 11
		public const string KFalse = nameof(KFalse); // 12
		public const string KDynamic = nameof(KDynamic); // 13
		public const string KObject = nameof(KObject); // 14
		public const string KVoid = nameof(KVoid); // 15
		public const string KBool = nameof(KBool); // 16
		public const string KChar = nameof(KChar); // 17
		public const string KSByte = nameof(KSByte); // 18
		public const string KByte = nameof(KByte); // 19
		public const string KShort = nameof(KShort); // 20
		public const string KUShort = nameof(KUShort); // 21
		public const string KInt = nameof(KInt); // 22
		public const string KUInt = nameof(KUInt); // 23
		public const string KLong = nameof(KLong); // 24
		public const string KULong = nameof(KULong); // 25
		public const string KDecimal = nameof(KDecimal); // 26
		public const string KFloat = nameof(KFloat); // 27
		public const string KDouble = nameof(KDouble); // 28
		public const string KString = nameof(KString); // 29
		public const string KTypeof = nameof(KTypeof); // 30
		public const string KNameof = nameof(KNameof); // 31
		public const string KSizeof = nameof(KSizeof); // 32
		public const string KDefault = nameof(KDefault); // 33
		public const string KChecked = nameof(KChecked); // 34
		public const string KUnchecked = nameof(KUnchecked); // 35
		public const string KAs = nameof(KAs); // 36
		public const string KIs = nameof(KIs); // 37
		public const string KNot = nameof(KNot); // 38
		public const string KThis = nameof(KThis); // 39
		public const string KBase = nameof(KBase); // 40
		public const string KAsync = nameof(KAsync); // 41
		public const string KAwait = nameof(KAwait); // 42
		public const string KConst = nameof(KConst); // 43
		public const string KReadonly = nameof(KReadonly); // 44
		public const string KDiscard = nameof(KDiscard); // 45
		public const string KThrow = nameof(KThrow); // 46
		public const string KStatic = nameof(KStatic); // 47
		public const string TSemicolon = nameof(TSemicolon); // 48
		public const string TColon = nameof(TColon); // 49
		public const string TDot = nameof(TDot); // 50
		public const string TComma = nameof(TComma); // 51
		public const string TAssign = nameof(TAssign); // 52
		public const string TOpenParen = nameof(TOpenParen); // 53
		public const string TCloseParen = nameof(TCloseParen); // 54
		public const string TOpenBracket = nameof(TOpenBracket); // 55
		public const string TCloseBracket = nameof(TCloseBracket); // 56
		public const string TOpenBrace = nameof(TOpenBrace); // 57
		public const string TCloseBrace = nameof(TCloseBrace); // 58
		public const string TLessThan = nameof(TLessThan); // 59
		public const string TGreaterThan = nameof(TGreaterThan); // 60
		public const string TQuestion = nameof(TQuestion); // 61
		public const string TQuestionDot = nameof(TQuestionDot); // 62
		public const string TQuestionOpenBracket = nameof(TQuestionOpenBracket); // 63
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 64
		public const string TAmpersand = nameof(TAmpersand); // 65
		public const string THat = nameof(THat); // 66
		public const string TBar = nameof(TBar); // 67
		public const string TAndAlso = nameof(TAndAlso); // 68
		public const string TOrElse = nameof(TOrElse); // 69
		public const string TPlusPlus = nameof(TPlusPlus); // 70
		public const string TMinusMinus = nameof(TMinusMinus); // 71
		public const string TPlus = nameof(TPlus); // 72
		public const string TMinus = nameof(TMinus); // 73
		public const string TTilde = nameof(TTilde); // 74
		public const string TExclamation = nameof(TExclamation); // 75
		public const string TSlash = nameof(TSlash); // 76
		public const string TAsterisk = nameof(TAsterisk); // 77
		public const string TPercent = nameof(TPercent); // 78
		public const string TArrow = nameof(TArrow); // 79
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 80
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 81
		public const string TEqual = nameof(TEqual); // 82
		public const string TNotEqual = nameof(TNotEqual); // 83
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 84
		public const string TSlashAssign = nameof(TSlashAssign); // 85
		public const string TPercentAssign = nameof(TPercentAssign); // 86
		public const string TPlusAssign = nameof(TPlusAssign); // 87
		public const string TMinusAssign = nameof(TMinusAssign); // 88
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 89
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 90
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 91
		public const string THatAssign = nameof(THatAssign); // 92
		public const string TBarAssign = nameof(TBarAssign); // 93
		public const string IdentifierNormal = nameof(IdentifierNormal); // 94
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 95
		public const string LInteger = nameof(LInteger); // 96
		public const string LDecimal = nameof(LDecimal); // 97
		public const string LScientific = nameof(LScientific); // 98
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 99
		public const string LDateTime = nameof(LDateTime); // 100
		public const string LDate = nameof(LDate); // 101
		public const string LTime = nameof(LTime); // 102
		public const string LRegularString = nameof(LRegularString); // 103
		public const string LGuid = nameof(LGuid); // 104
		public const string LUtf8Bom = nameof(LUtf8Bom); // 105
		public const string LWhiteSpace = nameof(LWhiteSpace); // 106
		public const string LCrLf = nameof(LCrLf); // 107
		public const string LLineEnd = nameof(LLineEnd); // 108
		public const string LSingleLineComment = nameof(LSingleLineComment); // 109
		public const string LComment = nameof(LComment); // 110
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 111
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 112
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 113
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 114
		public const string LCommentStart = nameof(LCommentStart); // 115

		protected CoreTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected CoreTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static CoreTokensSyntaxKind()
        {
            EnumObject.AutoInit<CoreTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LCommentStart;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = LCommentStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator CoreTokensSyntaxKind(string name)
        {
            return FromString<CoreTokensSyntaxKind>(name);
        }

        public static explicit operator CoreTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<CoreTokensSyntaxKind>(value);
        }

	}
}


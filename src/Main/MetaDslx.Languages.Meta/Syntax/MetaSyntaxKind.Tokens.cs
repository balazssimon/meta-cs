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

namespace MetaDslx.Languages.Meta.Syntax
{
	public class MetaTokensSyntaxKind : SyntaxKind
	{
        public static readonly MetaTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly MetaTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly MetaTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly MetaTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KUsing = nameof(KUsing); // 2
		public const string KMetamodel = nameof(KMetamodel); // 3
		public const string KExtern = nameof(KExtern); // 4
		public const string KTypeDef = nameof(KTypeDef); // 5
		public const string KAbstract = nameof(KAbstract); // 6
		public const string KClass = nameof(KClass); // 7
		public const string KStruct = nameof(KStruct); // 8
		public const string KEnum = nameof(KEnum); // 9
		public const string KAssociation = nameof(KAssociation); // 10
		public const string KContainment = nameof(KContainment); // 11
		public const string KWith = nameof(KWith); // 12
		public const string KNew = nameof(KNew); // 13
		public const string KNull = nameof(KNull); // 14
		public const string KTrue = nameof(KTrue); // 15
		public const string KFalse = nameof(KFalse); // 16
		public const string KVoid = nameof(KVoid); // 17
		public const string KObject = nameof(KObject); // 18
		public const string KString = nameof(KString); // 19
		public const string KInt = nameof(KInt); // 20
		public const string KLong = nameof(KLong); // 21
		public const string KFloat = nameof(KFloat); // 22
		public const string KDouble = nameof(KDouble); // 23
		public const string KByte = nameof(KByte); // 24
		public const string KBool = nameof(KBool); // 25
		public const string KList = nameof(KList); // 26
		public const string KAny = nameof(KAny); // 27
		public const string KNone = nameof(KNone); // 28
		public const string KError = nameof(KError); // 29
		public const string KSet = nameof(KSet); // 30
		public const string KMultiList = nameof(KMultiList); // 31
		public const string KMultiSet = nameof(KMultiSet); // 32
		public const string KThis = nameof(KThis); // 33
		public const string KTypeof = nameof(KTypeof); // 34
		public const string KAs = nameof(KAs); // 35
		public const string KIs = nameof(KIs); // 36
		public const string KBase = nameof(KBase); // 37
		public const string KConst = nameof(KConst); // 38
		public const string KRedefines = nameof(KRedefines); // 39
		public const string KSubsets = nameof(KSubsets); // 40
		public const string KReadonly = nameof(KReadonly); // 41
		public const string KLazy = nameof(KLazy); // 42
		public const string KDerived = nameof(KDerived); // 43
		public const string KUnion = nameof(KUnion); // 44
		public const string KBuilder = nameof(KBuilder); // 45
		public const string KSymbol = nameof(KSymbol); // 46
		public const string KExpression = nameof(KExpression); // 47
		public const string KStatement = nameof(KStatement); // 48
		public const string KType = nameof(KType); // 49
		public const string KProperty = nameof(KProperty); // 50
		public const string KStatic = nameof(KStatic); // 51
		public const string TSemicolon = nameof(TSemicolon); // 52
		public const string TColon = nameof(TColon); // 53
		public const string TDot = nameof(TDot); // 54
		public const string TComma = nameof(TComma); // 55
		public const string TAssign = nameof(TAssign); // 56
		public const string TOpenParen = nameof(TOpenParen); // 57
		public const string TCloseParen = nameof(TCloseParen); // 58
		public const string TOpenBracket = nameof(TOpenBracket); // 59
		public const string TCloseBracket = nameof(TCloseBracket); // 60
		public const string TOpenBrace = nameof(TOpenBrace); // 61
		public const string TCloseBrace = nameof(TCloseBrace); // 62
		public const string TLessThan = nameof(TLessThan); // 63
		public const string TGreaterThan = nameof(TGreaterThan); // 64
		public const string TQuestion = nameof(TQuestion); // 65
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 66
		public const string TAmpersand = nameof(TAmpersand); // 67
		public const string THat = nameof(THat); // 68
		public const string TBar = nameof(TBar); // 69
		public const string TAndAlso = nameof(TAndAlso); // 70
		public const string TOrElse = nameof(TOrElse); // 71
		public const string TPlusPlus = nameof(TPlusPlus); // 72
		public const string TMinusMinus = nameof(TMinusMinus); // 73
		public const string TPlus = nameof(TPlus); // 74
		public const string TMinus = nameof(TMinus); // 75
		public const string TTilde = nameof(TTilde); // 76
		public const string TExclamation = nameof(TExclamation); // 77
		public const string TSlash = nameof(TSlash); // 78
		public const string TAsterisk = nameof(TAsterisk); // 79
		public const string TPercent = nameof(TPercent); // 80
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 81
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 82
		public const string TEqual = nameof(TEqual); // 83
		public const string TNotEqual = nameof(TNotEqual); // 84
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 85
		public const string TSlashAssign = nameof(TSlashAssign); // 86
		public const string TPercentAssign = nameof(TPercentAssign); // 87
		public const string TPlusAssign = nameof(TPlusAssign); // 88
		public const string TMinusAssign = nameof(TMinusAssign); // 89
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 90
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 91
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 92
		public const string THatAssign = nameof(THatAssign); // 93
		public const string TBarAssign = nameof(TBarAssign); // 94
		public const string IUri = nameof(IUri); // 95
		public const string IPrefix = nameof(IPrefix); // 96
		public const string IVersion = nameof(IVersion); // 97
		public const string IdentifierNormal = nameof(IdentifierNormal); // 98
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 99
		public const string LInteger = nameof(LInteger); // 100
		public const string LDecimal = nameof(LDecimal); // 101
		public const string LScientific = nameof(LScientific); // 102
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 103
		public const string LDateTime = nameof(LDateTime); // 104
		public const string LDate = nameof(LDate); // 105
		public const string LTime = nameof(LTime); // 106
		public const string LRegularString = nameof(LRegularString); // 107
		public const string LGuid = nameof(LGuid); // 108
		public const string LUtf8Bom = nameof(LUtf8Bom); // 109
		public const string LWhiteSpace = nameof(LWhiteSpace); // 110
		public const string LCrLf = nameof(LCrLf); // 111
		public const string LLineEnd = nameof(LLineEnd); // 112
		public const string LSingleLineComment = nameof(LSingleLineComment); // 113
		public const string LComment = nameof(LComment); // 114
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 115
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 116
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 117
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 118
		public const string LCommentStart = nameof(LCommentStart); // 119

		protected MetaTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected MetaTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaTokensSyntaxKind()
        {
            EnumObject.AutoInit<MetaTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LCommentStart;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = LCommentStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator MetaTokensSyntaxKind(string name)
        {
            return FromString<MetaTokensSyntaxKind>(name);
        }

        public static explicit operator MetaTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<MetaTokensSyntaxKind>(value);
        }

	}
}


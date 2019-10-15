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
		public const string KSymbol = nameof(KSymbol); // 19
		public const string KString = nameof(KString); // 20
		public const string KInt = nameof(KInt); // 21
		public const string KLong = nameof(KLong); // 22
		public const string KFloat = nameof(KFloat); // 23
		public const string KDouble = nameof(KDouble); // 24
		public const string KByte = nameof(KByte); // 25
		public const string KBool = nameof(KBool); // 26
		public const string KList = nameof(KList); // 27
		public const string KAny = nameof(KAny); // 28
		public const string KNone = nameof(KNone); // 29
		public const string KError = nameof(KError); // 30
		public const string KSet = nameof(KSet); // 31
		public const string KMultiList = nameof(KMultiList); // 32
		public const string KMultiSet = nameof(KMultiSet); // 33
		public const string KThis = nameof(KThis); // 34
		public const string KTypeof = nameof(KTypeof); // 35
		public const string KAs = nameof(KAs); // 36
		public const string KIs = nameof(KIs); // 37
		public const string KBase = nameof(KBase); // 38
		public const string KConst = nameof(KConst); // 39
		public const string KRedefines = nameof(KRedefines); // 40
		public const string KSubsets = nameof(KSubsets); // 41
		public const string KReadonly = nameof(KReadonly); // 42
		public const string KLazy = nameof(KLazy); // 43
		public const string KSynthetized = nameof(KSynthetized); // 44
		public const string KInherited = nameof(KInherited); // 45
		public const string KDerived = nameof(KDerived); // 46
		public const string KUnion = nameof(KUnion); // 47
		public const string KStatic = nameof(KStatic); // 48
		public const string TSemicolon = nameof(TSemicolon); // 49
		public const string TColon = nameof(TColon); // 50
		public const string TDot = nameof(TDot); // 51
		public const string TComma = nameof(TComma); // 52
		public const string TAssign = nameof(TAssign); // 53
		public const string TOpenParen = nameof(TOpenParen); // 54
		public const string TCloseParen = nameof(TCloseParen); // 55
		public const string TOpenBracket = nameof(TOpenBracket); // 56
		public const string TCloseBracket = nameof(TCloseBracket); // 57
		public const string TOpenBrace = nameof(TOpenBrace); // 58
		public const string TCloseBrace = nameof(TCloseBrace); // 59
		public const string TLessThan = nameof(TLessThan); // 60
		public const string TGreaterThan = nameof(TGreaterThan); // 61
		public const string TQuestion = nameof(TQuestion); // 62
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 63
		public const string TAmpersand = nameof(TAmpersand); // 64
		public const string THat = nameof(THat); // 65
		public const string TBar = nameof(TBar); // 66
		public const string TAndAlso = nameof(TAndAlso); // 67
		public const string TOrElse = nameof(TOrElse); // 68
		public const string TPlusPlus = nameof(TPlusPlus); // 69
		public const string TMinusMinus = nameof(TMinusMinus); // 70
		public const string TPlus = nameof(TPlus); // 71
		public const string TMinus = nameof(TMinus); // 72
		public const string TTilde = nameof(TTilde); // 73
		public const string TExclamation = nameof(TExclamation); // 74
		public const string TSlash = nameof(TSlash); // 75
		public const string TAsterisk = nameof(TAsterisk); // 76
		public const string TPercent = nameof(TPercent); // 77
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 78
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 79
		public const string TEqual = nameof(TEqual); // 80
		public const string TNotEqual = nameof(TNotEqual); // 81
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 82
		public const string TSlashAssign = nameof(TSlashAssign); // 83
		public const string TPercentAssign = nameof(TPercentAssign); // 84
		public const string TPlusAssign = nameof(TPlusAssign); // 85
		public const string TMinusAssign = nameof(TMinusAssign); // 86
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 87
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 88
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 89
		public const string THatAssign = nameof(THatAssign); // 90
		public const string TBarAssign = nameof(TBarAssign); // 91
		public const string IUri = nameof(IUri); // 92
		public const string IdentifierNormal = nameof(IdentifierNormal); // 93
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 94
		public const string LInteger = nameof(LInteger); // 95
		public const string LDecimal = nameof(LDecimal); // 96
		public const string LScientific = nameof(LScientific); // 97
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 98
		public const string LDateTime = nameof(LDateTime); // 99
		public const string LDate = nameof(LDate); // 100
		public const string LTime = nameof(LTime); // 101
		public const string LRegularString = nameof(LRegularString); // 102
		public const string LGuid = nameof(LGuid); // 103
		public const string LUtf8Bom = nameof(LUtf8Bom); // 104
		public const string LWhiteSpace = nameof(LWhiteSpace); // 105
		public const string LCrLf = nameof(LCrLf); // 106
		public const string LLineEnd = nameof(LLineEnd); // 107
		public const string LSingleLineComment = nameof(LSingleLineComment); // 108
		public const string LComment = nameof(LComment); // 109
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 110
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 111
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 112
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 113
		public const string LCommentStart = nameof(LCommentStart); // 114

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


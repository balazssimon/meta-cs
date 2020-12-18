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

namespace MetaDslx.Languages.MetaCompiler.Syntax
{
	public class MetaCompilerTokensSyntaxKind : SyntaxKind
	{
        public static readonly MetaCompilerTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly MetaCompilerTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly MetaCompilerTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly MetaCompilerTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KUsing = nameof(KUsing); // 2
		public const string KCompiler = nameof(KCompiler); // 3
		public const string KSymbol = nameof(KSymbol); // 4
		public const string KBinder = nameof(KBinder); // 5
		public const string KExtern = nameof(KExtern); // 6
		public const string KTypeDef = nameof(KTypeDef); // 7
		public const string KAbstract = nameof(KAbstract); // 8
		public const string KPrivate = nameof(KPrivate); // 9
		public const string KProtected = nameof(KProtected); // 10
		public const string KPublic = nameof(KPublic); // 11
		public const string KInternal = nameof(KInternal); // 12
		public const string KVirtual = nameof(KVirtual); // 13
		public const string KOverride = nameof(KOverride); // 14
		public const string KSealed = nameof(KSealed); // 15
		public const string KPartial = nameof(KPartial); // 16
		public const string KMeta = nameof(KMeta); // 17
		public const string KSource = nameof(KSource); // 18
		public const string KVisit = nameof(KVisit); // 19
		public const string KClass = nameof(KClass); // 20
		public const string KStruct = nameof(KStruct); // 21
		public const string KEnum = nameof(KEnum); // 22
		public const string KContainment = nameof(KContainment); // 23
		public const string KNew = nameof(KNew); // 24
		public const string KNull = nameof(KNull); // 25
		public const string KTrue = nameof(KTrue); // 26
		public const string KFalse = nameof(KFalse); // 27
		public const string KVoid = nameof(KVoid); // 28
		public const string KObject = nameof(KObject); // 29
		public const string KString = nameof(KString); // 30
		public const string KInt = nameof(KInt); // 31
		public const string KLong = nameof(KLong); // 32
		public const string KFloat = nameof(KFloat); // 33
		public const string KDouble = nameof(KDouble); // 34
		public const string KByte = nameof(KByte); // 35
		public const string KBool = nameof(KBool); // 36
		public const string KThis = nameof(KThis); // 37
		public const string KTypeof = nameof(KTypeof); // 38
		public const string KAs = nameof(KAs); // 39
		public const string KIs = nameof(KIs); // 40
		public const string KBase = nameof(KBase); // 41
		public const string KConst = nameof(KConst); // 42
		public const string KReadonly = nameof(KReadonly); // 43
		public const string KLazy = nameof(KLazy); // 44
		public const string KDerived = nameof(KDerived); // 45
		public const string KLocked = nameof(KLocked); // 46
		public const string KPhase = nameof(KPhase); // 47
		public const string KJoins = nameof(KJoins); // 48
		public const string KAfter = nameof(KAfter); // 49
		public const string KBefore = nameof(KBefore); // 50
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
		public const string TRightArrow = nameof(TRightArrow); // 66
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 67
		public const string TAmpersand = nameof(TAmpersand); // 68
		public const string THat = nameof(THat); // 69
		public const string TBar = nameof(TBar); // 70
		public const string TAndAlso = nameof(TAndAlso); // 71
		public const string TOrElse = nameof(TOrElse); // 72
		public const string TPlusPlus = nameof(TPlusPlus); // 73
		public const string TMinusMinus = nameof(TMinusMinus); // 74
		public const string TPlus = nameof(TPlus); // 75
		public const string TMinus = nameof(TMinus); // 76
		public const string TTilde = nameof(TTilde); // 77
		public const string TExclamation = nameof(TExclamation); // 78
		public const string TSlash = nameof(TSlash); // 79
		public const string TAsterisk = nameof(TAsterisk); // 80
		public const string TPercent = nameof(TPercent); // 81
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 82
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 83
		public const string TEqual = nameof(TEqual); // 84
		public const string TNotEqual = nameof(TNotEqual); // 85
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 86
		public const string TSlashAssign = nameof(TSlashAssign); // 87
		public const string TPercentAssign = nameof(TPercentAssign); // 88
		public const string TPlusAssign = nameof(TPlusAssign); // 89
		public const string TMinusAssign = nameof(TMinusAssign); // 90
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 91
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 92
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 93
		public const string THatAssign = nameof(THatAssign); // 94
		public const string TBarAssign = nameof(TBarAssign); // 95
		public const string IdentifierNormal = nameof(IdentifierNormal); // 96
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 97
		public const string LInteger = nameof(LInteger); // 98
		public const string LDecimal = nameof(LDecimal); // 99
		public const string LScientific = nameof(LScientific); // 100
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 101
		public const string LDateTime = nameof(LDateTime); // 102
		public const string LDate = nameof(LDate); // 103
		public const string LTime = nameof(LTime); // 104
		public const string LRegularString = nameof(LRegularString); // 105
		public const string LGuid = nameof(LGuid); // 106
		public const string LUtf8Bom = nameof(LUtf8Bom); // 107
		public const string LWhiteSpace = nameof(LWhiteSpace); // 108
		public const string LCrLf = nameof(LCrLf); // 109
		public const string LLineEnd = nameof(LLineEnd); // 110
		public const string LSingleLineComment = nameof(LSingleLineComment); // 111
		public const string LComment = nameof(LComment); // 112
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 113
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 114
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 115
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 116
		public const string LCommentStart = nameof(LCommentStart); // 117

		protected MetaCompilerTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected MetaCompilerTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaCompilerTokensSyntaxKind()
        {
            EnumObject.AutoInit<MetaCompilerTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LCommentStart;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = LCommentStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator MetaCompilerTokensSyntaxKind(string name)
        {
            return FromString<MetaCompilerTokensSyntaxKind>(name);
        }

        public static explicit operator MetaCompilerTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<MetaCompilerTokensSyntaxKind>(value);
        }

	}
}


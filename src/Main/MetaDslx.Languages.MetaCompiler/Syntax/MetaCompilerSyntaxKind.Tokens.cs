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
		public const string KFixed = nameof(KFixed); // 17
		public const string KClass = nameof(KClass); // 18
		public const string KStruct = nameof(KStruct); // 19
		public const string KEnum = nameof(KEnum); // 20
		public const string KContainment = nameof(KContainment); // 21
		public const string KNew = nameof(KNew); // 22
		public const string KNull = nameof(KNull); // 23
		public const string KTrue = nameof(KTrue); // 24
		public const string KFalse = nameof(KFalse); // 25
		public const string KVoid = nameof(KVoid); // 26
		public const string KObject = nameof(KObject); // 27
		public const string KString = nameof(KString); // 28
		public const string KInt = nameof(KInt); // 29
		public const string KLong = nameof(KLong); // 30
		public const string KFloat = nameof(KFloat); // 31
		public const string KDouble = nameof(KDouble); // 32
		public const string KByte = nameof(KByte); // 33
		public const string KBool = nameof(KBool); // 34
		public const string KThis = nameof(KThis); // 35
		public const string KTypeof = nameof(KTypeof); // 36
		public const string KAs = nameof(KAs); // 37
		public const string KIs = nameof(KIs); // 38
		public const string KBase = nameof(KBase); // 39
		public const string KConst = nameof(KConst); // 40
		public const string KReadonly = nameof(KReadonly); // 41
		public const string KLazy = nameof(KLazy); // 42
		public const string KDerived = nameof(KDerived); // 43
		public const string KLocked = nameof(KLocked); // 44
		public const string KPhase = nameof(KPhase); // 45
		public const string KJoins = nameof(KJoins); // 46
		public const string KAfter = nameof(KAfter); // 47
		public const string KBefore = nameof(KBefore); // 48
		public const string KStatic = nameof(KStatic); // 49
		public const string TSemicolon = nameof(TSemicolon); // 50
		public const string TColon = nameof(TColon); // 51
		public const string TDot = nameof(TDot); // 52
		public const string TComma = nameof(TComma); // 53
		public const string TAssign = nameof(TAssign); // 54
		public const string TOpenParen = nameof(TOpenParen); // 55
		public const string TCloseParen = nameof(TCloseParen); // 56
		public const string TOpenBracket = nameof(TOpenBracket); // 57
		public const string TCloseBracket = nameof(TCloseBracket); // 58
		public const string TOpenBrace = nameof(TOpenBrace); // 59
		public const string TCloseBrace = nameof(TCloseBrace); // 60
		public const string TLessThan = nameof(TLessThan); // 61
		public const string TGreaterThan = nameof(TGreaterThan); // 62
		public const string TQuestion = nameof(TQuestion); // 63
		public const string TRightArrow = nameof(TRightArrow); // 64
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 65
		public const string TAmpersand = nameof(TAmpersand); // 66
		public const string THat = nameof(THat); // 67
		public const string TBar = nameof(TBar); // 68
		public const string TAndAlso = nameof(TAndAlso); // 69
		public const string TOrElse = nameof(TOrElse); // 70
		public const string TPlusPlus = nameof(TPlusPlus); // 71
		public const string TMinusMinus = nameof(TMinusMinus); // 72
		public const string TPlus = nameof(TPlus); // 73
		public const string TMinus = nameof(TMinus); // 74
		public const string TTilde = nameof(TTilde); // 75
		public const string TExclamation = nameof(TExclamation); // 76
		public const string TSlash = nameof(TSlash); // 77
		public const string TAsterisk = nameof(TAsterisk); // 78
		public const string TPercent = nameof(TPercent); // 79
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


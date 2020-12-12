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
		public const string KClass = nameof(KClass); // 9
		public const string KStruct = nameof(KStruct); // 10
		public const string KEnum = nameof(KEnum); // 11
		public const string KContainment = nameof(KContainment); // 12
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
		public const string KThis = nameof(KThis); // 26
		public const string KTypeof = nameof(KTypeof); // 27
		public const string KAs = nameof(KAs); // 28
		public const string KIs = nameof(KIs); // 29
		public const string KBase = nameof(KBase); // 30
		public const string KConst = nameof(KConst); // 31
		public const string KReadonly = nameof(KReadonly); // 32
		public const string KLazy = nameof(KLazy); // 33
		public const string KDerived = nameof(KDerived); // 34
		public const string KLocked = nameof(KLocked); // 35
		public const string KPhase = nameof(KPhase); // 36
		public const string KJoins = nameof(KJoins); // 37
		public const string KAfter = nameof(KAfter); // 38
		public const string KBefore = nameof(KBefore); // 39
		public const string KStatic = nameof(KStatic); // 40
		public const string TSemicolon = nameof(TSemicolon); // 41
		public const string TColon = nameof(TColon); // 42
		public const string TDot = nameof(TDot); // 43
		public const string TComma = nameof(TComma); // 44
		public const string TAssign = nameof(TAssign); // 45
		public const string TOpenParen = nameof(TOpenParen); // 46
		public const string TCloseParen = nameof(TCloseParen); // 47
		public const string TOpenBracket = nameof(TOpenBracket); // 48
		public const string TCloseBracket = nameof(TCloseBracket); // 49
		public const string TOpenBrace = nameof(TOpenBrace); // 50
		public const string TCloseBrace = nameof(TCloseBrace); // 51
		public const string TLessThan = nameof(TLessThan); // 52
		public const string TGreaterThan = nameof(TGreaterThan); // 53
		public const string TQuestion = nameof(TQuestion); // 54
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 55
		public const string TAmpersand = nameof(TAmpersand); // 56
		public const string THat = nameof(THat); // 57
		public const string TBar = nameof(TBar); // 58
		public const string TAndAlso = nameof(TAndAlso); // 59
		public const string TOrElse = nameof(TOrElse); // 60
		public const string TPlusPlus = nameof(TPlusPlus); // 61
		public const string TMinusMinus = nameof(TMinusMinus); // 62
		public const string TPlus = nameof(TPlus); // 63
		public const string TMinus = nameof(TMinus); // 64
		public const string TTilde = nameof(TTilde); // 65
		public const string TExclamation = nameof(TExclamation); // 66
		public const string TSlash = nameof(TSlash); // 67
		public const string TAsterisk = nameof(TAsterisk); // 68
		public const string TPercent = nameof(TPercent); // 69
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 70
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 71
		public const string TEqual = nameof(TEqual); // 72
		public const string TNotEqual = nameof(TNotEqual); // 73
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 74
		public const string TSlashAssign = nameof(TSlashAssign); // 75
		public const string TPercentAssign = nameof(TPercentAssign); // 76
		public const string TPlusAssign = nameof(TPlusAssign); // 77
		public const string TMinusAssign = nameof(TMinusAssign); // 78
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 79
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 80
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 81
		public const string THatAssign = nameof(THatAssign); // 82
		public const string TBarAssign = nameof(TBarAssign); // 83
		public const string IdentifierNormal = nameof(IdentifierNormal); // 84
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 85
		public const string LInteger = nameof(LInteger); // 86
		public const string LDecimal = nameof(LDecimal); // 87
		public const string LScientific = nameof(LScientific); // 88
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 89
		public const string LDateTime = nameof(LDateTime); // 90
		public const string LDate = nameof(LDate); // 91
		public const string LTime = nameof(LTime); // 92
		public const string LRegularString = nameof(LRegularString); // 93
		public const string LGuid = nameof(LGuid); // 94
		public const string LUtf8Bom = nameof(LUtf8Bom); // 95
		public const string LWhiteSpace = nameof(LWhiteSpace); // 96
		public const string LCrLf = nameof(LCrLf); // 97
		public const string LLineEnd = nameof(LLineEnd); // 98
		public const string LSingleLineComment = nameof(LSingleLineComment); // 99
		public const string LComment = nameof(LComment); // 100
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 101
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 102
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 103
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 104
		public const string LCommentStart = nameof(LCommentStart); // 105

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


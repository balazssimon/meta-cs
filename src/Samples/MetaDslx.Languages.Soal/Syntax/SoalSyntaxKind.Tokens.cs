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

namespace MetaDslx.Languages.Soal.Syntax
{
	public class SoalTokensSyntaxKind : SyntaxKind
	{
        public static readonly SoalTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly SoalTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly SoalTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly SoalTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KEnum = nameof(KEnum); // 2
		public const string KException = nameof(KException); // 3
		public const string KStruct = nameof(KStruct); // 4
		public const string KInterface = nameof(KInterface); // 5
		public const string KThrows = nameof(KThrows); // 6
		public const string KOneway = nameof(KOneway); // 7
		public const string KReturn = nameof(KReturn); // 8
		public const string KBinding = nameof(KBinding); // 9
		public const string KTransport = nameof(KTransport); // 10
		public const string KEncoding = nameof(KEncoding); // 11
		public const string KProtocol = nameof(KProtocol); // 12
		public const string KEndpoint = nameof(KEndpoint); // 13
		public const string KAddress = nameof(KAddress); // 14
		public const string KDatabase = nameof(KDatabase); // 15
		public const string KEntity = nameof(KEntity); // 16
		public const string KAbstract = nameof(KAbstract); // 17
		public const string KComponent = nameof(KComponent); // 18
		public const string KComposite = nameof(KComposite); // 19
		public const string KReference = nameof(KReference); // 20
		public const string KService = nameof(KService); // 21
		public const string KWire = nameof(KWire); // 22
		public const string KTo = nameof(KTo); // 23
		public const string KImplementation = nameof(KImplementation); // 24
		public const string KLanguage = nameof(KLanguage); // 25
		public const string KAssembly = nameof(KAssembly); // 26
		public const string KDeployment = nameof(KDeployment); // 27
		public const string KEnvironment = nameof(KEnvironment); // 28
		public const string KRuntime = nameof(KRuntime); // 29
		public const string KNull = nameof(KNull); // 30
		public const string KTrue = nameof(KTrue); // 31
		public const string KFalse = nameof(KFalse); // 32
		public const string KObject = nameof(KObject); // 33
		public const string KString = nameof(KString); // 34
		public const string KInt = nameof(KInt); // 35
		public const string KLong = nameof(KLong); // 36
		public const string KFloat = nameof(KFloat); // 37
		public const string KDouble = nameof(KDouble); // 38
		public const string KByte = nameof(KByte); // 39
		public const string KBool = nameof(KBool); // 40
		public const string KAny = nameof(KAny); // 41
		public const string KTypeof = nameof(KTypeof); // 42
		public const string KVoid = nameof(KVoid); // 43
		public const string TSemicolon = nameof(TSemicolon); // 44
		public const string TColon = nameof(TColon); // 45
		public const string TDot = nameof(TDot); // 46
		public const string TComma = nameof(TComma); // 47
		public const string TAssign = nameof(TAssign); // 48
		public const string TOpenParen = nameof(TOpenParen); // 49
		public const string TCloseParen = nameof(TCloseParen); // 50
		public const string TOpenBracket = nameof(TOpenBracket); // 51
		public const string TCloseBracket = nameof(TCloseBracket); // 52
		public const string TOpenBrace = nameof(TOpenBrace); // 53
		public const string TCloseBrace = nameof(TCloseBrace); // 54
		public const string TLessThan = nameof(TLessThan); // 55
		public const string TGreaterThan = nameof(TGreaterThan); // 56
		public const string TQuestion = nameof(TQuestion); // 57
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 58
		public const string TAmpersand = nameof(TAmpersand); // 59
		public const string THat = nameof(THat); // 60
		public const string TBar = nameof(TBar); // 61
		public const string TAndAlso = nameof(TAndAlso); // 62
		public const string TOrElse = nameof(TOrElse); // 63
		public const string TPlusPlus = nameof(TPlusPlus); // 64
		public const string TMinusMinus = nameof(TMinusMinus); // 65
		public const string TPlus = nameof(TPlus); // 66
		public const string TMinus = nameof(TMinus); // 67
		public const string TTilde = nameof(TTilde); // 68
		public const string TExclamation = nameof(TExclamation); // 69
		public const string TSlash = nameof(TSlash); // 70
		public const string TAsterisk = nameof(TAsterisk); // 71
		public const string TPercent = nameof(TPercent); // 72
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 73
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 74
		public const string TEqual = nameof(TEqual); // 75
		public const string TNotEqual = nameof(TNotEqual); // 76
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 77
		public const string TSlashAssign = nameof(TSlashAssign); // 78
		public const string TPercentAssign = nameof(TPercentAssign); // 79
		public const string TPlusAssign = nameof(TPlusAssign); // 80
		public const string TMinusAssign = nameof(TMinusAssign); // 81
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 82
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 83
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 84
		public const string THatAssign = nameof(THatAssign); // 85
		public const string TBarAssign = nameof(TBarAssign); // 86
		public const string IDate = nameof(IDate); // 87
		public const string ITime = nameof(ITime); // 88
		public const string IDateTime = nameof(IDateTime); // 89
		public const string ITimeSpan = nameof(ITimeSpan); // 90
		public const string IVersion = nameof(IVersion); // 91
		public const string IStyle = nameof(IStyle); // 92
		public const string IMTOM = nameof(IMTOM); // 93
		public const string ISSL = nameof(ISSL); // 94
		public const string IHTTP = nameof(IHTTP); // 95
		public const string IREST = nameof(IREST); // 96
		public const string IWebSocket = nameof(IWebSocket); // 97
		public const string ISOAP = nameof(ISOAP); // 98
		public const string IXML = nameof(IXML); // 99
		public const string IJSON = nameof(IJSON); // 100
		public const string IClientAuthentication = nameof(IClientAuthentication); // 101
		public const string IWsAddressing = nameof(IWsAddressing); // 102
		public const string IdentifierNormal = nameof(IdentifierNormal); // 103
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 104
		public const string LInteger = nameof(LInteger); // 105
		public const string LDecimal = nameof(LDecimal); // 106
		public const string LScientific = nameof(LScientific); // 107
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 108
		public const string LDateTime = nameof(LDateTime); // 109
		public const string LDate = nameof(LDate); // 110
		public const string LTime = nameof(LTime); // 111
		public const string LRegularString = nameof(LRegularString); // 112
		public const string LGuid = nameof(LGuid); // 113
		public const string LUtf8Bom = nameof(LUtf8Bom); // 114
		public const string LWhiteSpace = nameof(LWhiteSpace); // 115
		public const string LCrLf = nameof(LCrLf); // 116
		public const string LLineEnd = nameof(LLineEnd); // 117
		public const string LSingleLineComment = nameof(LSingleLineComment); // 118
		public const string LMultiLineComment = nameof(LMultiLineComment); // 119
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 120
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 121
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 122
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 123
		public const string LCommentStart = nameof(LCommentStart); // 124

		protected SoalTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected SoalTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SoalTokensSyntaxKind()
        {
            EnumObject.AutoInit<SoalTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LCommentStart;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = LCommentStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator SoalTokensSyntaxKind(string name)
        {
            return FromString<SoalTokensSyntaxKind>(name);
        }

        public static explicit operator SoalTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<SoalTokensSyntaxKind>(value);
        }

	}
}


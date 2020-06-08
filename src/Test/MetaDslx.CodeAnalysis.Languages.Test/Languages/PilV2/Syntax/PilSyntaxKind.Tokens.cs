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

namespace PilV2.Syntax
{
	public class PilTokensSyntaxKind : SyntaxKind
	{
        public static readonly PilTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly PilTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly PilTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly PilTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KTypeDef = nameof(KTypeDef); // 1
		public const string KEnum = nameof(KEnum); // 2
		public const string KFunction = nameof(KFunction); // 3
		public const string KEndFunction = nameof(KEndFunction); // 4
		public const string KResult = nameof(KResult); // 5
		public const string KFork = nameof(KFork); // 6
		public const string KEndFork = nameof(KEndFork); // 7
		public const string KCase = nameof(KCase); // 8
		public const string KElse = nameof(KElse); // 9
		public const string KIf = nameof(KIf); // 10
		public const string KEndIf = nameof(KEndIf); // 11
		public const string KQuery = nameof(KQuery); // 12
		public const string KEndQuery = nameof(KEndQuery); // 13
		public const string KPulse = nameof(KPulse); // 14
		public const string KStatic = nameof(KStatic); // 15
		public const string KObject = nameof(KObject); // 16
		public const string KEndObject = nameof(KEndObject); // 17
		public const string KTrigger = nameof(KTrigger); // 18
		public const string KInput = nameof(KInput); // 19
		public const string KOnAccepted = nameof(KOnAccepted); // 20
		public const string KOnRefused = nameof(KOnRefused); // 21
		public const string KOnCancel = nameof(KOnCancel); // 22
		public const string KAssert = nameof(KAssert); // 23
		public const string KRequest = nameof(KRequest); // 24
		public const string KAccept = nameof(KAccept); // 25
		public const string KRefuse = nameof(KRefuse); // 26
		public const string KCancel = nameof(KCancel); // 27
		public const string KVar = nameof(KVar); // 28
		public const string KParam = nameof(KParam); // 29
		public const string KUndo = nameof(KUndo); // 30
		public const string KTrue = nameof(KTrue); // 31
		public const string KFalse = nameof(KFalse); // 32
		public const string KInt = nameof(KInt); // 33
		public const string KBool = nameof(KBool); // 34
		public const string KString = nameof(KString); // 35
		public const string KObjectType = nameof(KObjectType); // 36
		public const string KIn = nameof(KIn); // 37
		public const string KNull = nameof(KNull); // 38
		public const string TSemicolon = nameof(TSemicolon); // 39
		public const string TColon = nameof(TColon); // 40
		public const string TDot = nameof(TDot); // 41
		public const string TComma = nameof(TComma); // 42
		public const string TAssign = nameof(TAssign); // 43
		public const string TOpenParen = nameof(TOpenParen); // 44
		public const string TCloseParen = nameof(TCloseParen); // 45
		public const string TOpenBracket = nameof(TOpenBracket); // 46
		public const string TCloseBracket = nameof(TCloseBracket); // 47
		public const string TOpenBrace = nameof(TOpenBrace); // 48
		public const string TCloseBrace = nameof(TCloseBrace); // 49
		public const string TLessThan = nameof(TLessThan); // 50
		public const string TGreaterThan = nameof(TGreaterThan); // 51
		public const string TQuestion = nameof(TQuestion); // 52
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 53
		public const string TAmpersand = nameof(TAmpersand); // 54
		public const string THat = nameof(THat); // 55
		public const string TBar = nameof(TBar); // 56
		public const string TAndAlso = nameof(TAndAlso); // 57
		public const string TOrElse = nameof(TOrElse); // 58
		public const string TPlusPlus = nameof(TPlusPlus); // 59
		public const string TMinusMinus = nameof(TMinusMinus); // 60
		public const string TPlus = nameof(TPlus); // 61
		public const string TMinus = nameof(TMinus); // 62
		public const string TTilde = nameof(TTilde); // 63
		public const string TExclamation = nameof(TExclamation); // 64
		public const string TSlash = nameof(TSlash); // 65
		public const string TAsterisk = nameof(TAsterisk); // 66
		public const string TPercent = nameof(TPercent); // 67
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 68
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 69
		public const string TEqual = nameof(TEqual); // 70
		public const string TNotEqual = nameof(TNotEqual); // 71
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 72
		public const string TSlashAssign = nameof(TSlashAssign); // 73
		public const string TPercentAssign = nameof(TPercentAssign); // 74
		public const string TPlusAssign = nameof(TPlusAssign); // 75
		public const string TMinusAssign = nameof(TMinusAssign); // 76
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 77
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 78
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 79
		public const string THatAssign = nameof(THatAssign); // 80
		public const string TBarAssign = nameof(TBarAssign); // 81
		public const string LIdentifier = nameof(LIdentifier); // 82
		public const string LInteger = nameof(LInteger); // 83
		public const string LDecimal = nameof(LDecimal); // 84
		public const string LScientific = nameof(LScientific); // 85
		public const string LString = nameof(LString); // 86
		public const string LUtf8Bom = nameof(LUtf8Bom); // 87
		public const string LWhiteSpace = nameof(LWhiteSpace); // 88
		public const string LCrLf = nameof(LCrLf); // 89
		public const string LLineEnd = nameof(LLineEnd); // 90
		public const string LSingleLineComment = nameof(LSingleLineComment); // 91
		public const string LMultiLineComment = nameof(LMultiLineComment); // 92

		protected PilTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected PilTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static PilTokensSyntaxKind()
        {
            EnumObject.AutoInit<PilTokensSyntaxKind>();
            __FirstToken = KTypeDef;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LMultiLineComment;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KTypeDef;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = TBarAssign;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator PilTokensSyntaxKind(string name)
        {
            return FromString<PilTokensSyntaxKind>(name);
        }

        public static explicit operator PilTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<PilTokensSyntaxKind>(value);
        }

	}
}


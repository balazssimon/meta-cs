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

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax
{
	public class TestLangOneTokensSyntaxKind : SyntaxKind
	{
        public static readonly TestLangOneTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly TestLangOneTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly TestLangOneTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly TestLangOneTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KScope = nameof(KScope); // 2
		public const string KMember = nameof(KMember); // 3
		public const string KClass = nameof(KClass); // 4
		public const string KVertex = nameof(KVertex); // 5
		public const string KOptional = nameof(KOptional); // 6
		public const string KArrow = nameof(KArrow); // 7
		public const string KStatic = nameof(KStatic); // 8
		public const string KTrue = nameof(KTrue); // 9
		public const string KFalse = nameof(KFalse); // 10
		public const string KNull = nameof(KNull); // 11
		public const string TSemicolon = nameof(TSemicolon); // 12
		public const string TColon = nameof(TColon); // 13
		public const string TDot = nameof(TDot); // 14
		public const string TComma = nameof(TComma); // 15
		public const string TAssign = nameof(TAssign); // 16
		public const string TOpenParen = nameof(TOpenParen); // 17
		public const string TCloseParen = nameof(TCloseParen); // 18
		public const string TOpenBracket = nameof(TOpenBracket); // 19
		public const string TCloseBracket = nameof(TCloseBracket); // 20
		public const string TOpenBrace = nameof(TOpenBrace); // 21
		public const string TCloseBrace = nameof(TCloseBrace); // 22
		public const string TLessThan = nameof(TLessThan); // 23
		public const string TGreaterThan = nameof(TGreaterThan); // 24
		public const string TQuestion = nameof(TQuestion); // 25
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 26
		public const string TAmpersand = nameof(TAmpersand); // 27
		public const string THat = nameof(THat); // 28
		public const string TBar = nameof(TBar); // 29
		public const string TAndAlso = nameof(TAndAlso); // 30
		public const string TOrElse = nameof(TOrElse); // 31
		public const string TPlusPlus = nameof(TPlusPlus); // 32
		public const string TMinusMinus = nameof(TMinusMinus); // 33
		public const string TPlus = nameof(TPlus); // 34
		public const string TMinus = nameof(TMinus); // 35
		public const string TTilde = nameof(TTilde); // 36
		public const string TExclamation = nameof(TExclamation); // 37
		public const string TSlash = nameof(TSlash); // 38
		public const string TAsterisk = nameof(TAsterisk); // 39
		public const string TPercent = nameof(TPercent); // 40
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 41
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 42
		public const string TEqual = nameof(TEqual); // 43
		public const string TNotEqual = nameof(TNotEqual); // 44
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 45
		public const string TSlashAssign = nameof(TSlashAssign); // 46
		public const string TPercentAssign = nameof(TPercentAssign); // 47
		public const string TPlusAssign = nameof(TPlusAssign); // 48
		public const string TMinusAssign = nameof(TMinusAssign); // 49
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 50
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 51
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 52
		public const string THatAssign = nameof(THatAssign); // 53
		public const string TBarAssign = nameof(TBarAssign); // 54
		public const string TArrow = nameof(TArrow); // 55
		public const string IUri = nameof(IUri); // 56
		public const string IdentifierNormal = nameof(IdentifierNormal); // 57
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 58
		public const string LInteger = nameof(LInteger); // 59
		public const string LDecimal = nameof(LDecimal); // 60
		public const string LScientific = nameof(LScientific); // 61
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 62
		public const string LDateTime = nameof(LDateTime); // 63
		public const string LDate = nameof(LDate); // 64
		public const string LTime = nameof(LTime); // 65
		public const string LRegularString = nameof(LRegularString); // 66
		public const string LGuid = nameof(LGuid); // 67
		public const string LUtf8Bom = nameof(LUtf8Bom); // 68
		public const string LWhiteSpace = nameof(LWhiteSpace); // 69
		public const string LCrLf = nameof(LCrLf); // 70
		public const string LLineEnd = nameof(LLineEnd); // 71
		public const string LSingleLineComment = nameof(LSingleLineComment); // 72
		public const string LComment = nameof(LComment); // 73
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 74
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 75
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 76
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 77
		public const string LCommentStart = nameof(LCommentStart); // 78

		protected TestLangOneTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected TestLangOneTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestLangOneTokensSyntaxKind()
        {
            EnumObject.AutoInit<TestLangOneTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LCommentStart;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = LCommentStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator TestLangOneTokensSyntaxKind(string name)
        {
            return FromString<TestLangOneTokensSyntaxKind>(name);
        }

        public static explicit operator TestLangOneTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<TestLangOneTokensSyntaxKind>(value);
        }

	}
}


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
		public const string KTest01 = nameof(KTest01); // 11
		public const string KTest02 = nameof(KTest02); // 12
		public const string KTest03 = nameof(KTest03); // 13
		public const string KTest04 = nameof(KTest04); // 14
		public const string KTest05 = nameof(KTest05); // 15
		public const string KTest06 = nameof(KTest06); // 16
		public const string KTest07 = nameof(KTest07); // 17
		public const string KTest08 = nameof(KTest08); // 18
		public const string KTest09 = nameof(KTest09); // 19
		public const string KTest10 = nameof(KTest10); // 20
		public const string KTest11 = nameof(KTest11); // 21
		public const string KTest12 = nameof(KTest12); // 22
		public const string KTest13 = nameof(KTest13); // 23
		public const string KTest14 = nameof(KTest14); // 24
		public const string KTest15 = nameof(KTest15); // 25
		public const string KTest16 = nameof(KTest16); // 26
		public const string KTest17 = nameof(KTest17); // 27
		public const string KTest18 = nameof(KTest18); // 28
		public const string KTest19 = nameof(KTest19); // 29
		public const string KNull = nameof(KNull); // 30
		public const string TSemicolon = nameof(TSemicolon); // 31
		public const string TColon = nameof(TColon); // 32
		public const string TDot = nameof(TDot); // 33
		public const string TComma = nameof(TComma); // 34
		public const string TAssign = nameof(TAssign); // 35
		public const string TOpenParen = nameof(TOpenParen); // 36
		public const string TCloseParen = nameof(TCloseParen); // 37
		public const string TOpenBracket = nameof(TOpenBracket); // 38
		public const string TCloseBracket = nameof(TCloseBracket); // 39
		public const string TOpenBrace = nameof(TOpenBrace); // 40
		public const string TCloseBrace = nameof(TCloseBrace); // 41
		public const string TLessThan = nameof(TLessThan); // 42
		public const string TGreaterThan = nameof(TGreaterThan); // 43
		public const string TQuestion = nameof(TQuestion); // 44
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 45
		public const string TAmpersand = nameof(TAmpersand); // 46
		public const string THat = nameof(THat); // 47
		public const string TBar = nameof(TBar); // 48
		public const string TAndAlso = nameof(TAndAlso); // 49
		public const string TOrElse = nameof(TOrElse); // 50
		public const string TPlusPlus = nameof(TPlusPlus); // 51
		public const string TMinusMinus = nameof(TMinusMinus); // 52
		public const string TPlus = nameof(TPlus); // 53
		public const string TMinus = nameof(TMinus); // 54
		public const string TTilde = nameof(TTilde); // 55
		public const string TExclamation = nameof(TExclamation); // 56
		public const string TSlash = nameof(TSlash); // 57
		public const string TAsterisk = nameof(TAsterisk); // 58
		public const string TPercent = nameof(TPercent); // 59
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 60
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 61
		public const string TEqual = nameof(TEqual); // 62
		public const string TNotEqual = nameof(TNotEqual); // 63
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 64
		public const string TSlashAssign = nameof(TSlashAssign); // 65
		public const string TPercentAssign = nameof(TPercentAssign); // 66
		public const string TPlusAssign = nameof(TPlusAssign); // 67
		public const string TMinusAssign = nameof(TMinusAssign); // 68
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 69
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 70
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 71
		public const string THatAssign = nameof(THatAssign); // 72
		public const string TBarAssign = nameof(TBarAssign); // 73
		public const string TArrow = nameof(TArrow); // 74
		public const string IUri = nameof(IUri); // 75
		public const string IdentifierNormal = nameof(IdentifierNormal); // 76
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 77
		public const string LInteger = nameof(LInteger); // 78
		public const string LDecimal = nameof(LDecimal); // 79
		public const string LScientific = nameof(LScientific); // 80
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 81
		public const string LDateTime = nameof(LDateTime); // 82
		public const string LDate = nameof(LDate); // 83
		public const string LTime = nameof(LTime); // 84
		public const string LRegularString = nameof(LRegularString); // 85
		public const string LGuid = nameof(LGuid); // 86
		public const string LUtf8Bom = nameof(LUtf8Bom); // 87
		public const string LWhiteSpace = nameof(LWhiteSpace); // 88
		public const string LCrLf = nameof(LCrLf); // 89
		public const string LLineEnd = nameof(LLineEnd); // 90
		public const string LSingleLineComment = nameof(LSingleLineComment); // 91
		public const string LComment = nameof(LComment); // 92
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 93
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 94
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 95
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 96
		public const string LCommentStart = nameof(LCommentStart); // 97

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


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

namespace MetaDslx.Languages.Compiler.Syntax
{
	public class CompilerTokensSyntaxKind : SyntaxKind
	{
        public static readonly CompilerTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly CompilerTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly CompilerTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly CompilerTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KGrammar = nameof(KGrammar); // 2
		public const string KOptions = nameof(KOptions); // 3
		public const string KFragment = nameof(KFragment); // 4
		public const string KHidden = nameof(KHidden); // 5
		public const string KTrue = nameof(KTrue); // 6
		public const string KFalse = nameof(KFalse); // 7
		public const string KNull = nameof(KNull); // 8
		public const string KEof = nameof(KEof); // 9
		public const string TSemicolon = nameof(TSemicolon); // 10
		public const string TArrow = nameof(TArrow); // 11
		public const string TDot = nameof(TDot); // 12
		public const string TNonGreedyZeroOrOne = nameof(TNonGreedyZeroOrOne); // 13
		public const string TNonGreedyZeroOrMore = nameof(TNonGreedyZeroOrMore); // 14
		public const string TNonGreedyOneOrMore = nameof(TNonGreedyOneOrMore); // 15
		public const string TZeroOrOne = nameof(TZeroOrOne); // 16
		public const string TZeroOrMore = nameof(TZeroOrMore); // 17
		public const string TOneOrMore = nameof(TOneOrMore); // 18
		public const string TNegate = nameof(TNegate); // 19
		public const string TAssign = nameof(TAssign); // 20
		public const string TQuestionAssign = nameof(TQuestionAssign); // 21
		public const string TNegatedAssign = nameof(TNegatedAssign); // 22
		public const string TPlusAssign = nameof(TPlusAssign); // 23
		public const string TBar = nameof(TBar); // 24
		public const string TAmpersand = nameof(TAmpersand); // 25
		public const string TColon = nameof(TColon); // 26
		public const string TComma = nameof(TComma); // 27
		public const string TOpenParen = nameof(TOpenParen); // 28
		public const string TCloseParen = nameof(TCloseParen); // 29
		public const string TOpenBracket = nameof(TOpenBracket); // 30
		public const string TCloseBracket = nameof(TCloseBracket); // 31
		public const string TOpenBrace = nameof(TOpenBrace); // 32
		public const string TCloseBrace = nameof(TCloseBrace); // 33
		public const string TLessThan = nameof(TLessThan); // 34
		public const string TGreaterThan = nameof(TGreaterThan); // 35
		public const string LexerIdentifier = nameof(LexerIdentifier); // 36
		public const string ParserIdentifier = nameof(ParserIdentifier); // 37
		public const string LInteger = nameof(LInteger); // 38
		public const string LDecimal = nameof(LDecimal); // 39
		public const string LScientific = nameof(LScientific); // 40
		public const string LString = nameof(LString); // 41
		public const string LUtf8Bom = nameof(LUtf8Bom); // 42
		public const string LWhiteSpace = nameof(LWhiteSpace); // 43
		public const string LCrLf = nameof(LCrLf); // 44
		public const string LLineEnd = nameof(LLineEnd); // 45
		public const string LSingleLineComment = nameof(LSingleLineComment); // 46
		public const string LMultilineComment = nameof(LMultilineComment); // 47

		protected CompilerTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected CompilerTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static CompilerTokensSyntaxKind()
        {
            EnumObject.AutoInit<CompilerTokensSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LMultilineComment;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = TGreaterThan;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator CompilerTokensSyntaxKind(string name)
        {
            return FromString<CompilerTokensSyntaxKind>(name);
        }

        public static explicit operator CompilerTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<CompilerTokensSyntaxKind>(value);
        }

	}
}


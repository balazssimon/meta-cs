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

namespace WebSequenceDiagramsModel.Syntax
{
	public class SequenceTokensSyntaxKind : SyntaxKind
	{
        public static readonly SequenceTokensSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly SequenceTokensSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly SequenceTokensSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly SequenceTokensSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;

		// Tokens:
		public const string KTitle = nameof(KTitle); // 1
		public const string KNote = nameof(KNote); // 2
		public const string KDestroy = nameof(KDestroy); // 3
		public const string KAlt = nameof(KAlt); // 4
		public const string KElse = nameof(KElse); // 5
		public const string KEnd = nameof(KEnd); // 6
		public const string KOpt = nameof(KOpt); // 7
		public const string KLoop = nameof(KLoop); // 8
		public const string KRef = nameof(KRef); // 9
		public const string LSingleLineComment = nameof(LSingleLineComment); // 10
		public const string LCommentStart = nameof(LCommentStart); // 11
		public const string TCreate = nameof(TCreate); // 12
		public const string TSync = nameof(TSync); // 13
		public const string TAsync = nameof(TAsync); // 14
		public const string TReturn = nameof(TReturn); // 15
		public const string LUtf8Bom = nameof(LUtf8Bom); // 16
		public const string LWhiteSpace = nameof(LWhiteSpace); // 17
		public const string LCrLf = nameof(LCrLf); // 18
		public const string LLineEnd = nameof(LLineEnd); // 19
		public const string LIdentifier = nameof(LIdentifier); // 20
		public const string NoteWhiteSpace = nameof(NoteWhiteSpace); // 21
		public const string NoteLinesWhiteSpace = nameof(NoteLinesWhiteSpace); // 22
		public const string KEndNote = nameof(KEndNote); // 23
		public const string RefWhiteSpace = nameof(RefWhiteSpace); // 24
		public const string RefLinesWhiteSpace = nameof(RefLinesWhiteSpace); // 25
		public const string KEndRef = nameof(KEndRef); // 26
		public const string RefEndWhiteSpace = nameof(RefEndWhiteSpace); // 27
		public const string LineEndWhiteSpace = nameof(LineEndWhiteSpace); // 28
		public const string ArrowEndWhiteSpace = nameof(ArrowEndWhiteSpace); // 29
		public const string TColon = nameof(TColon); // 30
		public const string TMinus = nameof(TMinus); // 31
		public const string ArrowEndR = nameof(ArrowEndR); // 32

		protected SequenceTokensSyntaxKind(string name)
            : base(name)
        {
        }

        protected SequenceTokensSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SequenceTokensSyntaxKind()
        {
            EnumObject.AutoInit<SequenceTokensSyntaxKind>();
            __FirstToken = KTitle;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = ArrowEndR;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KTitle;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = ArrowEndR;
			__LastFixedTokenValue = (int)__LastFixedToken;
        }

        public static implicit operator SequenceTokensSyntaxKind(string name)
        {
            return FromString<SequenceTokensSyntaxKind>(name);
        }

        public static explicit operator SequenceTokensSyntaxKind(int value)
        {
            return FromIntUnsafe<SequenceTokensSyntaxKind>(value);
        }

	}
}


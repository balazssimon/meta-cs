// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace WebSequenceDiagramsModel.Syntax
{
	public enum SequenceTokenKind : int
	{
		None = 0,
		ContextualKeyword,
		DocumentationCommentTrivia,
		ExternAliasDirective,
		FixedToken,
		GeneralComment,
		GeneralCommentTrivia,
		Identifier,
		PreprocessorContextualKeyword,
		PreprocessorDirective,
		PreprocessorKeyword,
		ReservedKeyword,
		Token,
		Trivia,
		Whitespace
	}

	public enum SequenceLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		NoteId = 1,
		NoteLines = 2,
		RefId = 3,
		RefLines = 4,
		RefEnd = 5,
		LineEndText = 6,
		ArrowEndText = 7
	}

	public class SequenceTokensSyntaxFacts : SyntaxFacts
	{
        public SequenceTokensSyntaxFacts() 
            : base(typeof(SequenceTokensSyntaxKind))
        {
        }

        protected SequenceTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (SequenceTokensSyntaxKind)SequenceTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (SequenceTokensSyntaxKind)SequenceTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (SequenceTokensSyntaxKind)SequenceTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultIdentifierKind => (SequenceTokensSyntaxKind)SequenceTokensSyntaxKind.LIdentifier;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case SequenceTokensSyntaxKind.Eof:
				case SequenceTokensSyntaxKind.KTitle:
				case SequenceTokensSyntaxKind.KNote:
				case SequenceTokensSyntaxKind.KDestroy:
				case SequenceTokensSyntaxKind.KAlt:
				case SequenceTokensSyntaxKind.KElse:
				case SequenceTokensSyntaxKind.KEnd:
				case SequenceTokensSyntaxKind.KOpt:
				case SequenceTokensSyntaxKind.KLoop:
				case SequenceTokensSyntaxKind.KRef:
				case SequenceTokensSyntaxKind.LSingleLineComment:
				case SequenceTokensSyntaxKind.LCommentStart:
				case SequenceTokensSyntaxKind.TCreate:
				case SequenceTokensSyntaxKind.TSync:
				case SequenceTokensSyntaxKind.TAsync:
				case SequenceTokensSyntaxKind.TReturn:
				case SequenceTokensSyntaxKind.LUtf8Bom:
				case SequenceTokensSyntaxKind.LWhiteSpace:
				case SequenceTokensSyntaxKind.LCrLf:
				case SequenceTokensSyntaxKind.LLineEnd:
				case SequenceTokensSyntaxKind.LIdentifier:
				case SequenceTokensSyntaxKind.NoteWhiteSpace:
				case SequenceTokensSyntaxKind.NoteLinesWhiteSpace:
				case SequenceTokensSyntaxKind.KEndNote:
				case SequenceTokensSyntaxKind.RefWhiteSpace:
				case SequenceTokensSyntaxKind.RefLinesWhiteSpace:
				case SequenceTokensSyntaxKind.KEndRef:
				case SequenceTokensSyntaxKind.RefEndWhiteSpace:
				case SequenceTokensSyntaxKind.LineEndWhiteSpace:
				case SequenceTokensSyntaxKind.ArrowEndWhiteSpace:
				case SequenceTokensSyntaxKind.TColon:
				case SequenceTokensSyntaxKind.TMinus:
				case SequenceTokensSyntaxKind.ArrowEndR:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case SequenceTokensSyntaxKind.KTitle:
				case SequenceTokensSyntaxKind.KNote:
				case SequenceTokensSyntaxKind.KDestroy:
				case SequenceTokensSyntaxKind.KAlt:
				case SequenceTokensSyntaxKind.KElse:
				case SequenceTokensSyntaxKind.KEnd:
				case SequenceTokensSyntaxKind.KOpt:
				case SequenceTokensSyntaxKind.KLoop:
				case SequenceTokensSyntaxKind.KRef:
				case SequenceTokensSyntaxKind.TSync:
				case SequenceTokensSyntaxKind.TAsync:
				case SequenceTokensSyntaxKind.KEndNote:
				case SequenceTokensSyntaxKind.KEndRef:
				case SequenceTokensSyntaxKind.TColon:
				case SequenceTokensSyntaxKind.ArrowEndR:
					return true;
				default:
					return false;
			}
		}

		public override SyntaxKind GetFixedTokenKind(string text)
		{
			switch (text)
			{
				case "title":
					return SequenceTokensSyntaxKind.KTitle;
				case "note":
					return SequenceTokensSyntaxKind.KNote;
				case "destroy":
					return SequenceTokensSyntaxKind.KDestroy;
				case "alt":
					return SequenceTokensSyntaxKind.KAlt;
				case "else":
					return SequenceTokensSyntaxKind.KElse;
				case "end":
					return SequenceTokensSyntaxKind.KEnd;
				case "opt":
					return SequenceTokensSyntaxKind.KOpt;
				case "loop":
					return SequenceTokensSyntaxKind.KLoop;
				case "ref":
					return SequenceTokensSyntaxKind.KRef;
				case "->":
					return SequenceTokensSyntaxKind.TSync;
				case "->>":
					return SequenceTokensSyntaxKind.TAsync;
				case "end note":
					return SequenceTokensSyntaxKind.KEndNote;
				case "end ref":
					return SequenceTokensSyntaxKind.KEndRef;
				case ":":
					return SequenceTokensSyntaxKind.TColon;
				case "r":
					return SequenceTokensSyntaxKind.ArrowEndR;
				default:
					return SequenceTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case SequenceTokensSyntaxKind.KTitle:
					return "title";
				case SequenceTokensSyntaxKind.KNote:
					return "note";
				case SequenceTokensSyntaxKind.KDestroy:
					return "destroy";
				case SequenceTokensSyntaxKind.KAlt:
					return "alt";
				case SequenceTokensSyntaxKind.KElse:
					return "else";
				case SequenceTokensSyntaxKind.KEnd:
					return "end";
				case SequenceTokensSyntaxKind.KOpt:
					return "opt";
				case SequenceTokensSyntaxKind.KLoop:
					return "loop";
				case SequenceTokensSyntaxKind.KRef:
					return "ref";
				case SequenceTokensSyntaxKind.TSync:
					return "->";
				case SequenceTokensSyntaxKind.TAsync:
					return "->>";
				case SequenceTokensSyntaxKind.KEndNote:
					return "end note";
				case SequenceTokensSyntaxKind.KEndRef:
					return "end ref";
				case SequenceTokensSyntaxKind.TColon:
					return ":";
				case SequenceTokensSyntaxKind.ArrowEndR:
					return "r";
				default:
					return string.Empty;
			}
		}

		public SequenceTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<SequenceTokensSyntaxKind>(rawKind));
		}

		public SequenceTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SequenceTokensSyntaxKind.KTitle:
				case SequenceTokensSyntaxKind.KNote:
				case SequenceTokensSyntaxKind.KDestroy:
				case SequenceTokensSyntaxKind.KAlt:
				case SequenceTokensSyntaxKind.KElse:
				case SequenceTokensSyntaxKind.KEnd:
				case SequenceTokensSyntaxKind.KOpt:
				case SequenceTokensSyntaxKind.KLoop:
					return SequenceTokenKind.ReservedKeyword;
				case SequenceTokensSyntaxKind.LSingleLineComment:
					return SequenceTokenKind.GeneralComment;
				case SequenceTokensSyntaxKind.LCommentStart:
					return SequenceTokenKind.GeneralComment;
				case SequenceTokensSyntaxKind.LUtf8Bom:
					return SequenceTokenKind.Whitespace;
				case SequenceTokensSyntaxKind.LWhiteSpace:
					return SequenceTokenKind.Whitespace;
				case SequenceTokensSyntaxKind.LCrLf:
					return SequenceTokenKind.Whitespace;
				case SequenceTokensSyntaxKind.LLineEnd:
					return SequenceTokenKind.Whitespace;
				default:
					return SequenceTokenKind.None;
			}
		}

		public SequenceTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((SequenceLexerMode)rawKind);
		}

		public SequenceTokenKind GetModeTokenKind(SequenceLexerMode kind)
		{
			switch(kind)
			{
				default:
					return SequenceTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SequenceTokensSyntaxKind.LCrLf:
					return true;
				case SequenceTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public override bool IsTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsReservedKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SequenceTokensSyntaxKind.KTitle:
				case SequenceTokensSyntaxKind.KNote:
				case SequenceTokensSyntaxKind.KDestroy:
				case SequenceTokensSyntaxKind.KAlt:
				case SequenceTokensSyntaxKind.KElse:
				case SequenceTokensSyntaxKind.KEnd:
				case SequenceTokensSyntaxKind.KOpt:
				case SequenceTokensSyntaxKind.KLoop:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return SequenceTokensSyntaxKind.KTitle;
				yield return SequenceTokensSyntaxKind.KNote;
				yield return SequenceTokensSyntaxKind.KDestroy;
				yield return SequenceTokensSyntaxKind.KAlt;
				yield return SequenceTokensSyntaxKind.KElse;
				yield return SequenceTokensSyntaxKind.KEnd;
				yield return SequenceTokensSyntaxKind.KOpt;
				yield return SequenceTokensSyntaxKind.KLoop;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "title":
					return SequenceTokensSyntaxKind.KTitle;
				case "note":
					return SequenceTokensSyntaxKind.KNote;
				case "destroy":
					return SequenceTokensSyntaxKind.KDestroy;
				case "alt":
					return SequenceTokensSyntaxKind.KAlt;
				case "else":
					return SequenceTokensSyntaxKind.KElse;
				case "end":
					return SequenceTokensSyntaxKind.KEnd;
				case "opt":
					return SequenceTokensSyntaxKind.KOpt;
				case "loop":
					return SequenceTokensSyntaxKind.KLoop;
				default:
					return SyntaxKind.None;
			}
        }
		public override bool IsContextualKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetContextualKeywordKinds()
        {
			yield break;
        }

        public override SyntaxKind GetContextualKeywordKind(string text)
        {
			switch(text)
			{
				default:
					return SyntaxKind.None;
			}
        }
		public override bool IsPreprocessorKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsPreprocessorContextualKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsPreprocessorDirective(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsIdentifier(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsGeneralCommentTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsDocumentationCommentTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SequenceTokensSyntaxKind.LSingleLineComment:
					return true;
				case SequenceTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}
		public override bool IsExternAliasDirective(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SequenceTokensSyntaxKind.LUtf8Bom:
					return true;
				case SequenceTokensSyntaxKind.LWhiteSpace:
					return true;
				case SequenceTokensSyntaxKind.LCrLf:
					return true;
				case SequenceTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
	}
}


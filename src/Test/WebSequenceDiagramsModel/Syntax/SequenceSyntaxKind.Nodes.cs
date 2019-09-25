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
	public class SequenceSyntaxKind : SequenceTokensSyntaxKind
	{
        public static new readonly SequenceSyntaxKind __FirstToken;
        public static new readonly SequenceSyntaxKind __LastToken;
        public static new readonly SequenceSyntaxKind __FirstFixedToken;
        public static new readonly SequenceSyntaxKind __LastFixedToken;
        public static readonly SequenceSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly SequenceSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Interaction = nameof(Interaction);
		public const string Line = nameof(Line);
		public const string Declaration = nameof(Declaration);
		public const string Title = nameof(Title);
		public const string Arrow = nameof(Arrow);
		public const string Destroy = nameof(Destroy);
		public const string Alt = nameof(Alt);
		public const string AltFragment = nameof(AltFragment);
		public const string ElseFragment = nameof(ElseFragment);
		public const string Loop = nameof(Loop);
		public const string LoopFragment = nameof(LoopFragment);
		public const string Opt = nameof(Opt);
		public const string OptFragment = nameof(OptFragment);
		public const string Ref = nameof(Ref);
		public const string SimpleRefFragment = nameof(SimpleRefFragment);
		public const string MessageRefFragment = nameof(MessageRefFragment);
		public const string RefInput = nameof(RefInput);
		public const string RefOutput = nameof(RefOutput);
		public const string FragmentBody = nameof(FragmentBody);
		public const string End = nameof(End);
		public const string Note = nameof(Note);
		public const string SingleLineNote = nameof(SingleLineNote);
		public const string MultiLineNote = nameof(MultiLineNote);
		public const string SimpleBody = nameof(SimpleBody);
		public const string SimpleLine = nameof(SimpleLine);
		public const string ArrowType = nameof(ArrowType);
		public const string LifeLineName = nameof(LifeLineName);
		public const string Name = nameof(Name);
		public const string Identifier = nameof(Identifier);
		public const string Text = nameof(Text);
		public const string IdentifierPart = nameof(IdentifierPart);

		protected SequenceSyntaxKind(string name)
            : base(name)
        {
        }

        protected SequenceSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SequenceSyntaxKind()
        {
            EnumObject.AutoInit<SequenceSyntaxKind>();
            __FirstToken = KTitle;
            __LastToken = ArrowEndR;
            __FirstFixedToken = KTitle;
            __LastFixedToken = ArrowEndR;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = IdentifierPart;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator SequenceSyntaxKind(string name)
        {
            return FromString<SequenceSyntaxKind>(name);
        }

        public static explicit operator SequenceSyntaxKind(int value)
        {
            return FromIntUnsafe<SequenceSyntaxKind>(value);
        }

	}
}


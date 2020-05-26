// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax
{
    using System.Runtime.CompilerServices;
    using MetaDslx.CodeAnalysis;
    using MetaDslx.CodeAnalysis.Syntax;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
    using Microsoft.CodeAnalysis.Text;
    using Roslyn.Utilities;
    using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;

	internal abstract class GreenSyntaxNode : InternalSyntaxNode
    {
        protected GreenSyntaxNode(SyntaxKind kind)
            : base(kind)
        {
        }

        protected GreenSyntaxNode(SyntaxKind kind, int fullWidth)
            : base(kind, fullWidth)
        {
        }

        protected GreenSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics)
            : base(kind, diagnostics)
        {
        }

        protected GreenSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base(kind, diagnostics, fullWidth)
        {
        }

        protected GreenSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations)
        {
        }

        protected GreenSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind, diagnostics, annotations, fullWidth)
        {
        }

        protected GreenSyntaxNode(ObjectReader reader)
            : base(reader)
        {
        }

        public override TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor)
        {
            if (visitor is TestLexerModeSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is TestLexerModeSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor);
        public abstract void Accept(TestLexerModeSyntaxVisitor visitor);

        public new TestLexerModeLanguage Language => TestLexerModeLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestLexerModeSyntaxKind Kind => (TestLexerModeSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

		// Use conditional weak table so we always return same identity for structured trivia
		private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
			= new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

		/// <summary>
		/// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
		/// determine if this trivia has structure.
		/// </summary>
		/// <returns>
		/// A TestLexerModeSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
		/// If this trivia node does not have structure, returns null.
		/// </returns>
		/// <remarks>
		/// Some types of trivia have structure that can be accessed as additional syntax nodes.
		/// These forms of trivia include: 
		///   directives, where the structure describes the structure of the directive.
		///   documentation comments, where the structure describes the XML structure of the comment.
		///   skipped tokens, where the structure describes the tokens that were skipped by the parser.
		/// </remarks>
		public override SyntaxNode GetStructure(Microsoft.CodeAnalysis.SyntaxTrivia trivia)
		{
			if (trivia.HasStructure)
			{
				var parent = trivia.Token.Parent;
				if (parent != null)
				{
					SyntaxNode structure;
					var structsInParent = s_structuresTable.GetOrCreateValue(parent);
					lock (structsInParent)
					{
						if (!structsInParent.TryGetValue(trivia, out structure))
						{
							structure = TestLexerModeStructuredTriviaSyntax.Create(trivia);
							structsInParent.Add(trivia, structure);
						}
					}

					return structure;
				}
				else
				{
					return TestLexerModeStructuredTriviaSyntax.Create(trivia);
				}
			}

			return null;
		}

	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(TestLexerModeSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, text, diagnostics, annotations)
        {
        }

        internal GreenSyntaxTrivia(ObjectReader reader)
            : base(reader)
        {
        }

        static GreenSyntaxTrivia()
        {
            ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxTrivia), r => new GreenSyntaxTrivia(r));
        }

        public new TestLexerModeLanguage Language => TestLexerModeLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestLexerModeSyntaxKind Kind => EnumObject.FromIntUnsafe<TestLexerModeSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(TestLexerModeSyntaxKind kind, string text)
        {
            return new GreenSyntaxTrivia(kind, text);
        }

        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new GreenSyntaxTrivia(this.Kind, this.Text, diagnostics, GetAnnotations());
        }

        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new GreenSyntaxTrivia(this.Kind, this.Text, GetDiagnostics(), annotations);
        }

        public static implicit operator SyntaxTrivia(GreenSyntaxTrivia trivia)
        {
            return new SyntaxTrivia(default, trivia, position: 0, index: 0);
        }
    }

    internal abstract class GreenStructuredTriviaSyntax : GreenSyntaxNode
    {
        internal GreenStructuredTriviaSyntax(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, diagnostics, annotations)
        {
            this.Initialize();
        }

        internal GreenStructuredTriviaSyntax(ObjectReader reader)
            : base(reader)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.flags |= NodeFlags.ContainsStructuredTrivia;

            if (this.Kind == SyntaxKind.SkippedTokensTrivia)
            {
                this.flags |= NodeFlags.ContainsSkippedText;
            }
        }

        public override bool IsStructuredTrivia => true;
    }

    internal sealed partial class GreenSkippedTokensTriviaSyntax : GreenStructuredTriviaSyntax
    {
        internal readonly GreenNode tokens;

        internal GreenSkippedTokensTriviaSyntax(TestLexerModeSyntaxKind kind, GreenNode tokens, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, diagnostics, annotations)
        {
            this.SlotCount = 1;
            if (tokens != null)
            {
                this.AdjustFlagsAndWidth(tokens);
                this.tokens = tokens;
            }
        }

        public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> Tokens => new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken>(this.tokens);

        protected override GreenNode GetSlot(int index)
        {
            switch (index)
            {
                case 0: return this.tokens;
                default: return null;
            }
        }

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position) => new TestLexerModeSkippedTokensTriviaSyntax(this, (TestLexerModeSyntaxNode)parent, position);

        public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSkippedTokensTrivia(this);

        public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSkippedTokensTrivia(this);

        public GreenSkippedTokensTriviaSyntax Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> tokens)
        {
            if (tokens != this.Tokens)
            {
                var newNode = Language.InternalSyntaxFactory.SkippedTokensTrivia(tokens.Node);
                var diags = this.GetDiagnostics();
                if (diags != null && diags.Length > 0)
                    newNode = newNode.WithDiagnosticsGreen(diags);
                var annotations = this.GetAnnotations();
                if (annotations != null && annotations.Length > 0)
                    newNode = newNode.WithAnnotationsGreen(annotations);
                return (GreenSkippedTokensTriviaSyntax)newNode;
            }
            return this;
        }

		public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
		{
			return new GreenSkippedTokensTriviaSyntax(this.Kind, this.tokens, diagnostics, GetAnnotations());
		}

		public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
		{
			return new GreenSkippedTokensTriviaSyntax(this.Kind, this.tokens, GetDiagnostics(), annotations);
		}

        internal GreenSkippedTokensTriviaSyntax(ObjectReader reader)
            : base(reader)
        {
            this.SlotCount = 1;
            var tokens = (GreenNode)reader.ReadValue();
            if (tokens != null)
            {
                AdjustFlagsAndWidth(tokens);
                this.tokens = tokens;
            }
        }

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteValue(this.tokens);
        }

        static GreenSkippedTokensTriviaSyntax()
        {
            ObjectBinder.RegisterTypeReader(typeof(GreenSkippedTokensTriviaSyntax), r => new GreenSkippedTokensTriviaSyntax(r));
        }
    }

	internal partial class GreenSyntaxToken : InternalSyntaxToken
	{
	    //====================
	    // Optimization: Normally, we wouldn't accept this much duplicate code, but these constructors
	    // are called A LOT and we want to keep them as short and simple as possible and increase the
	    // likelihood that they will be inlined.
	    internal GreenSyntaxToken(TestLexerModeSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(TestLexerModeSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(TestLexerModeSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(TestLexerModeSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, fullWidth, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(ObjectReader reader)
	        : base(reader)
	    {
	        var text = this.Text;
	        if (text != null)
	        {
	            FullWidth = text.Length;
	        }
	        this.flags |= NodeFlags.IsNotMissing;  //note: cleared by subclasses representing missing tokens
	    }
	    public new TestLexerModeLanguage Language => TestLexerModeLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new TestLexerModeSyntaxKind Kind => EnumObject.FromIntUnsafe<TestLexerModeSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(TestLexerModeSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!TestLexerModeLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid TestLexerModeSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(TestLexerModeSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!TestLexerModeLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid TestLexerModeSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == TestLexerModeLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == TestLexerModeLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(TestLexerModeSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly TestLexerModeSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly TestLexerModeSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = TestLexerModeSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = TestLexerModeSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = TestLexerModeLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((TestLexerModeSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((TestLexerModeSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((TestLexerModeSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((TestLexerModeSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
	        }
	    }
	    internal static IEnumerable<GreenSyntaxToken> GetWellKnownTokens()
	    {
	        foreach (var element in s_tokensWithNoTrivia)
	        {
	            if (element.Value != null)
	            {
	                yield return element.Value;
	            }
	        }
	        foreach (var element in s_tokensWithElasticTrivia)
	        {
	            if (element.Value != null)
	            {
	                yield return element.Value;
	            }
	        }
	        foreach (var element in s_tokensWithSingleTrailingSpace)
	        {
	            if (element.Value != null)
	            {
	                yield return element.Value;
	            }
	        }
	        foreach (var element in s_tokensWithSingleTrailingCRLF)
	        {
	            if (element.Value != null)
	            {
	                yield return element.Value;
	            }
	        }
	    }
	    internal static GreenSyntaxToken Identifier(TestLexerModeSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(TestLexerModeSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
	    {
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return Identifier(kind, text);
	            }
	            else
	            {
	                return new SyntaxIdentifierWithTrailingTrivia(kind, text, trailing);
	            }
	        }
	        return new SyntaxIdentifierWithTrivia(kind, kind, text, text, leading, trailing);
	    }
	    internal static GreenSyntaxToken Identifier(TestLexerModeSyntaxKind kind, TestLexerModeSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(TestLexerModeSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(TestLexerModeSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual TestLexerModeSyntaxKind ContextualKind => this.Kind;
	    public override int RawContextualKind => (int)this.ContextualKind;
	    public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	    {
	        return new SyntaxTokenWithTrivia(this.Kind, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	    }
	    public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	    {
	        return new SyntaxTokenWithTrivia(this.Kind, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	    }
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        System.Diagnostics.Debug.Assert(this.GetType() == typeof(GreenSyntaxToken));
	        return new GreenSyntaxToken(this.Kind, this.FullWidth, diagnostics, this.GetAnnotations());
	    }
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        System.Diagnostics.Debug.Assert(this.GetType() == typeof(GreenSyntaxToken));
	        return new GreenSyntaxToken(this.Kind, this.FullWidth, this.GetDiagnostics(), annotations);
	    }
	    public override TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitToken(this);
	    }
	    public override void Accept(InternalSyntaxVisitor visitor)
	    {
	        visitor.VisitToken(this);
	    }
	    protected override void WriteTokenTo(System.IO.TextWriter writer, bool leading, bool trailing)
	    {
	        if (leading)
	        {
	            var trivia = this.GetLeadingTrivia();
	            if (trivia != null)
	            {
	                trivia.WriteTo(writer);
	            }
	        }
	        writer.Write(this.Text);
	        if (trailing)
	        {
	            var trivia = this.GetTrailingTrivia();
	            if (trivia != null)
	            {
	                trivia.WriteTo(writer);
	            }
	        }
	    }
	
	    internal class MissingTokenWithTrivia : SyntaxTokenWithTrivia
	    {
	        internal MissingTokenWithTrivia(TestLexerModeSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(TestLexerModeSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, leading, trailing, diagnostics, annotations)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(ObjectReader reader)
	            : base(reader)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        static MissingTokenWithTrivia()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(MissingTokenWithTrivia), r => new MissingTokenWithTrivia(r));
	        }
	        public override string Text
	        {
	            get { return string.Empty; }
	        }
	        public override object Value
	        {
	            get
	            {
	                if (Language.SyntaxFacts.IsIdentifier(this.Kind)) return string.Empty;
	                else return null;
	            }
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new MissingTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    internal class SyntaxIdentifier : GreenSyntaxToken
	    {
	        static SyntaxIdentifier()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifier), r => new SyntaxIdentifier(r));
	        }
	        protected readonly string TextField;
	        internal SyntaxIdentifier(TestLexerModeSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(TestLexerModeSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text.Length, diagnostics, annotations)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(ObjectReader reader)
	            : base(reader)
	        {
	            this.TextField = reader.ReadString();
	            this.FullWidth = this.TextField.Length;
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteString(this.TextField);
	        }
	        public override string Text
	        {
	            get { return this.TextField; }
	        }
	        public override object Value
	        {
	            get { return this.TextField; }
	        }
	        public override string ValueText
	        {
	            get { return this.TextField; }
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.ContextualKind, this.TextField, this.TextField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.ContextualKind, this.TextField, this.TextField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxIdentifier(this.Kind, this.Text, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxIdentifier(this.Kind, this.Text, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    internal class SyntaxIdentifierExtended : SyntaxIdentifier
	    {
	        protected readonly TestLexerModeSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(TestLexerModeSyntaxKind kind, TestLexerModeSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(TestLexerModeSyntaxKind kind, TestLexerModeSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<TestLexerModeSyntaxKind>(reader.ReadInt32());
	            this.valueText = reader.ReadString();
	        }
	        static SyntaxIdentifierExtended()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifierExtended), r => new SyntaxIdentifierExtended(r));
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteInt32((int)this.contextualKind);
	            writer.WriteString(this.valueText);
	        }
	        public override TestLexerModeSyntaxKind ContextualKind
	        {
	            get { return this.contextualKind; }
	        }
	        public override string ValueText
	        {
	            get { return this.valueText; }
	        }
	        public override object Value
	        {
	            get { return this.valueText; }
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxIdentifierExtended(this.Kind, this.contextualKind, this.TextField, this.valueText, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxIdentifierExtended(this.Kind, this.contextualKind, this.TextField, this.valueText, this.GetDiagnostics(), annotations);
	        }
	    }
	
		internal class SyntaxIdentifierWithTrailingTrivia : SyntaxIdentifier
	    {
	        private readonly GreenNode _trailing;
	        internal SyntaxIdentifierWithTrailingTrivia(TestLexerModeSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(TestLexerModeSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(ObjectReader reader)
	            : base(reader)
	        {
	            var trailing = (GreenNode)reader.ReadValue();
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        static SyntaxIdentifierWithTrailingTrivia()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifierWithTrailingTrivia), r => new SyntaxIdentifierWithTrailingTrivia(r));
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteValue(_trailing);
	        }
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.ContextualKind, this.TextField, this.TextField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, _trailing, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    internal class SyntaxIdentifierWithTrivia : SyntaxIdentifierExtended
	    {
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	        internal SyntaxIdentifierWithTrivia(
	            TestLexerModeSyntaxKind kind,
	            TestLexerModeSyntaxKind contextualKind,
	            string text,
	            string valueText,
	            GreenNode leading,
	            GreenNode trailing)
	            : base(kind, contextualKind, text, valueText)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrivia(
	            TestLexerModeSyntaxKind kind,
	            TestLexerModeSyntaxKind contextualKind,
	            string text,
	            string valueText,
	            GreenNode leading,
	            GreenNode trailing,
	            DiagnosticInfo[] diagnostics,
	            SyntaxAnnotation[] annotations)
	            : base(kind, contextualKind, text, valueText, diagnostics, annotations)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrivia(ObjectReader reader)
	            : base(reader)
	        {
	            var leading = (GreenNode)reader.ReadValue();
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            var trailing = (GreenNode)reader.ReadValue();
	            if (trailing != null)
	            {
	                _trailing = trailing;
	                this.AdjustFlagsAndWidth(trailing);
	            }
	        }
	        static SyntaxIdentifierWithTrivia()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifierWithTrivia), r => new SyntaxIdentifierWithTrivia(r));
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteValue(_leading);
	            writer.WriteValue(_trailing);
	        }
	        public override GreenNode GetLeadingTrivia()
	        {
	            return _leading;
	        }
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, _leading, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, _leading, _trailing, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, _leading, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    internal class SyntaxTokenWithValue<T> : GreenSyntaxToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	        internal SyntaxTokenWithValue(TestLexerModeSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(TestLexerModeSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text.Length, diagnostics, annotations)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(ObjectReader reader)
	            : base(reader)
	        {
	            this.TextField = reader.ReadString();
	            this.FullWidth = this.TextField.Length;
	            this.ValueField = (T)reader.ReadValue();
	        }
	        static SyntaxTokenWithValue()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxTokenWithValue<T>), r => new SyntaxTokenWithValue<T>(r));
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteString(this.TextField);
	            writer.WriteValue(this.ValueField);
	        }
	        public override string Text
	        {
	            get
	            {
	                return this.TextField;
	            }
	        }
	        public override object Value
	        {
	            get
	            {
	                return this.ValueField;
	            }
	        }
	        public override string ValueText
	        {
	            get
	            {
	                return Convert.ToString(this.ValueField, CultureInfo.InvariantCulture);
	            }
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    internal class SyntaxTokenWithValueAndTrivia<T> : SyntaxTokenWithValue<T>
	    {
	        static SyntaxTokenWithValueAndTrivia()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxTokenWithValueAndTrivia<T>), r => new SyntaxTokenWithValueAndTrivia<T>(r));
	        }
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	        internal SyntaxTokenWithValueAndTrivia(TestLexerModeSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
	            : base(kind, text, value)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxTokenWithValueAndTrivia(
	            TestLexerModeSyntaxKind kind,
	            string text,
	            T value,
	            GreenNode leading,
	            GreenNode trailing,
	            DiagnosticInfo[] diagnostics,
	            SyntaxAnnotation[] annotations)
	            : base(kind, text, value, diagnostics, annotations)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxTokenWithValueAndTrivia(ObjectReader reader)
	            : base(reader)
	        {
	            var leading = (GreenNode)reader.ReadValue();
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            var trailing = (GreenNode)reader.ReadValue();
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteValue(_leading);
	            writer.WriteValue(_trailing);
	        }
	        public override GreenNode GetLeadingTrivia()
	        {
	            return _leading;
	        }
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    internal class SyntaxTokenWithTrivia : GreenSyntaxToken
	    {
	        static SyntaxTokenWithTrivia()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxTokenWithTrivia), r => new SyntaxTokenWithTrivia(r));
	        }
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	        internal SyntaxTokenWithTrivia(TestLexerModeSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                this.LeadingField = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                this.TrailingField = trailing;
	            }
	        }
	        internal SyntaxTokenWithTrivia(TestLexerModeSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, diagnostics, annotations)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                this.LeadingField = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                this.TrailingField = trailing;
	            }
	        }
	        internal SyntaxTokenWithTrivia(ObjectReader reader)
	            : base(reader)
	        {
	            var leading = (GreenNode)reader.ReadValue();
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                this.LeadingField = leading;
	            }
	            var trailing = (GreenNode)reader.ReadValue();
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                this.TrailingField = trailing;
	            }
	        }
	        protected override void WriteTo(ObjectWriter writer)
	        {
	            base.WriteTo(writer);
	            writer.WriteValue(this.LeadingField);
	            writer.WriteValue(this.TrailingField);
	        }
	        public override GreenNode GetLeadingTrivia()
	        {
	            return this.LeadingField;
	        }
	        public override GreenNode GetTrailingTrivia()
	        {
	            return this.TrailingField;
	        }
	        public override InternalSyntaxToken TokenWithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxToken TokenWithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
	        }
	        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
	        }
	    }
	}
	
	internal class MainGreen : GreenSyntaxNode
	{
	    internal static readonly MainGreen __Missing = new MainGreen();
	    private NamespaceDeclarationGreen namespaceDeclaration;
	    private GeneratorDeclarationGreen generatorDeclaration;
	    private GreenNode usingDeclaration;
	    private ConfigDeclarationGreen configDeclaration;
	    private GreenNode methodDeclaration;
	    private InternalSyntaxToken eOF;
	
	    public MainGreen(TestLexerModeSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, GeneratorDeclarationGreen generatorDeclaration, GreenNode usingDeclaration, ConfigDeclarationGreen configDeclaration, GreenNode methodDeclaration, InternalSyntaxToken eOF)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (namespaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration);
				this.namespaceDeclaration = namespaceDeclaration;
			}
			if (generatorDeclaration != null)
			{
				this.AdjustFlagsAndWidth(generatorDeclaration);
				this.generatorDeclaration = generatorDeclaration;
			}
			if (usingDeclaration != null)
			{
				this.AdjustFlagsAndWidth(usingDeclaration);
				this.usingDeclaration = usingDeclaration;
			}
			if (configDeclaration != null)
			{
				this.AdjustFlagsAndWidth(configDeclaration);
				this.configDeclaration = configDeclaration;
			}
			if (methodDeclaration != null)
			{
				this.AdjustFlagsAndWidth(methodDeclaration);
				this.methodDeclaration = methodDeclaration;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
	    public MainGreen(TestLexerModeSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, GeneratorDeclarationGreen generatorDeclaration, GreenNode usingDeclaration, ConfigDeclarationGreen configDeclaration, GreenNode methodDeclaration, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (namespaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration);
				this.namespaceDeclaration = namespaceDeclaration;
			}
			if (generatorDeclaration != null)
			{
				this.AdjustFlagsAndWidth(generatorDeclaration);
				this.generatorDeclaration = generatorDeclaration;
			}
			if (usingDeclaration != null)
			{
				this.AdjustFlagsAndWidth(usingDeclaration);
				this.usingDeclaration = usingDeclaration;
			}
			if (configDeclaration != null)
			{
				this.AdjustFlagsAndWidth(configDeclaration);
				this.configDeclaration = configDeclaration;
			}
			if (methodDeclaration != null)
			{
				this.AdjustFlagsAndWidth(methodDeclaration);
				this.methodDeclaration = methodDeclaration;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
		private MainGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NamespaceDeclarationGreen NamespaceDeclaration { get { return this.namespaceDeclaration; } }
	    public GeneratorDeclarationGreen GeneratorDeclaration { get { return this.generatorDeclaration; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen> UsingDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen>(this.usingDeclaration); } }
	    public ConfigDeclarationGreen ConfigDeclaration { get { return this.configDeclaration; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MethodDeclarationGreen> MethodDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MethodDeclarationGreen>(this.methodDeclaration); } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.MainSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.namespaceDeclaration;
	            case 1: return this.generatorDeclaration;
	            case 2: return this.usingDeclaration;
	            case 3: return this.configDeclaration;
	            case 4: return this.methodDeclaration;
	            case 5: return this.eOF;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.generatorDeclaration, this.usingDeclaration, this.configDeclaration, this.methodDeclaration, this.eOF, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.generatorDeclaration, this.usingDeclaration, this.configDeclaration, this.methodDeclaration, this.eOF, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(NamespaceDeclarationGreen namespaceDeclaration, GeneratorDeclarationGreen generatorDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen> usingDeclaration, ConfigDeclarationGreen configDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MethodDeclarationGreen> methodDeclaration, InternalSyntaxToken eOF)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.GeneratorDeclaration != generatorDeclaration ||
				this.UsingDeclaration != usingDeclaration ||
				this.ConfigDeclaration != configDeclaration ||
				this.MethodDeclaration != methodDeclaration ||
				this.EndOfFileToken != eOF)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, generatorDeclaration, usingDeclaration, configDeclaration, methodDeclaration, eOF);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclarationGreen __Missing = new NamespaceDeclarationGreen();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public NamespaceDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kNamespace != null)
			{
				this.AdjustFlagsAndWidth(kNamespace);
				this.kNamespace = kNamespace;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public NamespaceDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kNamespace != null)
			{
				this.AdjustFlagsAndWidth(kNamespace);
				this.kNamespace = kNamespace;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private NamespaceDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NamespaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.NamespaceDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.kNamespace, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.kNamespace, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclarationGreen Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(kNamespace, qualifiedName, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GeneratorDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly GeneratorDeclarationGreen __Missing = new GeneratorDeclarationGreen();
	    private InternalSyntaxToken kGenerator;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken kFor;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tSemicolon;
	
	    public GeneratorDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kGenerator, IdentifierGreen identifier, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, InternalSyntaxToken kFor, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (kGenerator != null)
			{
				this.AdjustFlagsAndWidth(kGenerator);
				this.kGenerator = kGenerator;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (kFor != null)
			{
				this.AdjustFlagsAndWidth(kFor);
				this.kFor = kFor;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public GeneratorDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kGenerator, IdentifierGreen identifier, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, InternalSyntaxToken kFor, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (kGenerator != null)
			{
				this.AdjustFlagsAndWidth(kGenerator);
				this.kGenerator = kGenerator;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (kFor != null)
			{
				this.AdjustFlagsAndWidth(kFor);
				this.kFor = kFor;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private GeneratorDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GeneratorDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KGenerator { get { return this.kGenerator; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken KFor { get { return this.kFor; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.GeneratorDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kGenerator;
	            case 1: return this.identifier;
	            case 2: return this.tColon;
	            case 3: return this.qualifiedName;
	            case 4: return this.kFor;
	            case 5: return this.typeReference;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitGeneratorDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitGeneratorDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GeneratorDeclarationGreen(this.Kind, this.kGenerator, this.identifier, this.tColon, this.qualifiedName, this.kFor, this.typeReference, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GeneratorDeclarationGreen(this.Kind, this.kGenerator, this.identifier, this.tColon, this.qualifiedName, this.kFor, this.typeReference, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public GeneratorDeclarationGreen Update(InternalSyntaxToken kGenerator, IdentifierGreen identifier, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, InternalSyntaxToken kFor, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KGenerator != kGenerator ||
				this.Identifier != identifier ||
				this.TColon != tColon ||
				this.QualifiedName != qualifiedName ||
				this.KFor != kFor ||
				this.TypeReference != typeReference ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.GeneratorDeclaration(kGenerator, identifier, tColon, qualifiedName, kFor, typeReference, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GeneratorDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class UsingDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly UsingDeclarationGreen __Missing = UsingNamespaceDeclarationGreen.__Missing;
	
	    public UsingDeclarationGreen(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class UsingNamespaceDeclarationGreen : UsingDeclarationGreen
	{
	    internal static new readonly UsingNamespaceDeclarationGreen __Missing = new UsingNamespaceDeclarationGreen();
	    private InternalSyntaxToken kUsing;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public UsingNamespaceDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kUsing, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kUsing != null)
			{
				this.AdjustFlagsAndWidth(kUsing);
				this.kUsing = kUsing;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public UsingNamespaceDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kUsing, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kUsing != null)
			{
				this.AdjustFlagsAndWidth(kUsing);
				this.kUsing = kUsing;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private UsingNamespaceDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UsingNamespaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KUsing { get { return this.kUsing; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.UsingNamespaceDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kUsing;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitUsingNamespaceDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitUsingNamespaceDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UsingNamespaceDeclarationGreen(this.Kind, this.kUsing, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UsingNamespaceDeclarationGreen(this.Kind, this.kUsing, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public UsingNamespaceDeclarationGreen Update(InternalSyntaxToken kUsing, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.QualifiedName != qualifiedName ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.UsingNamespaceDeclaration(kUsing, qualifiedName, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UsingGeneratorDeclarationGreen : UsingDeclarationGreen
	{
	    internal static new readonly UsingGeneratorDeclarationGreen __Missing = new UsingGeneratorDeclarationGreen();
	    private InternalSyntaxToken kUsing;
	    private InternalSyntaxToken kGenerator;
	    private QualifiedNameGreen qualifiedName;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public UsingGeneratorDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kUsing, InternalSyntaxToken kGenerator, QualifiedNameGreen qualifiedName, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kUsing != null)
			{
				this.AdjustFlagsAndWidth(kUsing);
				this.kUsing = kUsing;
			}
			if (kGenerator != null)
			{
				this.AdjustFlagsAndWidth(kGenerator);
				this.kGenerator = kGenerator;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public UsingGeneratorDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kUsing, InternalSyntaxToken kGenerator, QualifiedNameGreen qualifiedName, IdentifierGreen identifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kUsing != null)
			{
				this.AdjustFlagsAndWidth(kUsing);
				this.kUsing = kUsing;
			}
			if (kGenerator != null)
			{
				this.AdjustFlagsAndWidth(kGenerator);
				this.kGenerator = kGenerator;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private UsingGeneratorDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UsingGeneratorDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KUsing { get { return this.kUsing; } }
	    public InternalSyntaxToken KGenerator { get { return this.kGenerator; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.UsingGeneratorDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kUsing;
	            case 1: return this.kGenerator;
	            case 2: return this.qualifiedName;
	            case 3: return this.identifier;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitUsingGeneratorDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitUsingGeneratorDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UsingGeneratorDeclarationGreen(this.Kind, this.kUsing, this.kGenerator, this.qualifiedName, this.identifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UsingGeneratorDeclarationGreen(this.Kind, this.kUsing, this.kGenerator, this.qualifiedName, this.identifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public UsingGeneratorDeclarationGreen Update(InternalSyntaxToken kUsing, InternalSyntaxToken kGenerator, QualifiedNameGreen qualifiedName, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.KGenerator != kGenerator ||
				this.QualifiedName != qualifiedName ||
				this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.UsingGeneratorDeclaration(kUsing, kGenerator, qualifiedName, identifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingGeneratorDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ConfigDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ConfigDeclarationGreen __Missing = new ConfigDeclarationGreen();
	    private InternalSyntaxToken startProperties;
	    private IdentifierGreen identifier;
	    private GreenNode configProperty;
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken endProperties;
	
	    public ConfigDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken startProperties, IdentifierGreen identifier, GreenNode configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (startProperties != null)
			{
				this.AdjustFlagsAndWidth(startProperties);
				this.startProperties = startProperties;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (configProperty != null)
			{
				this.AdjustFlagsAndWidth(configProperty);
				this.configProperty = configProperty;
			}
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (endProperties != null)
			{
				this.AdjustFlagsAndWidth(endProperties);
				this.endProperties = endProperties;
			}
	    }
	
	    public ConfigDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken startProperties, IdentifierGreen identifier, GreenNode configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (startProperties != null)
			{
				this.AdjustFlagsAndWidth(startProperties);
				this.startProperties = startProperties;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (configProperty != null)
			{
				this.AdjustFlagsAndWidth(configProperty);
				this.configProperty = configProperty;
			}
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (endProperties != null)
			{
				this.AdjustFlagsAndWidth(endProperties);
				this.endProperties = endProperties;
			}
	    }
	
		private ConfigDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ConfigDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken StartProperties { get { return this.startProperties; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen> ConfigProperty { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen>(this.configProperty); } }
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken EndProperties { get { return this.endProperties; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ConfigDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.startProperties;
	            case 1: return this.identifier;
	            case 2: return this.configProperty;
	            case 3: return this.kEnd;
	            case 4: return this.endProperties;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitConfigDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitConfigDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConfigDeclarationGreen(this.Kind, this.startProperties, this.identifier, this.configProperty, this.kEnd, this.endProperties, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConfigDeclarationGreen(this.Kind, this.startProperties, this.identifier, this.configProperty, this.kEnd, this.endProperties, this.GetDiagnostics(), annotations);
	    }
	
	    public ConfigDeclarationGreen Update(InternalSyntaxToken startProperties, IdentifierGreen identifier, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen> configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties)
	    {
	        if (this.StartProperties != startProperties ||
				this.Identifier != identifier ||
				this.ConfigProperty != configProperty ||
				this.KEnd != kEnd ||
				this.EndProperties != endProperties)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConfigDeclaration(startProperties, identifier, configProperty, kEnd, endProperties);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConfigDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ConfigPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly ConfigPropertyGreen __Missing = ConfigPropertyDeclarationGreen.__Missing;
	
	    public ConfigPropertyGreen(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ConfigPropertyDeclarationGreen : ConfigPropertyGreen
	{
	    internal static new readonly ConfigPropertyDeclarationGreen __Missing = new ConfigPropertyDeclarationGreen();
	    private TypeReferenceGreen typeReference;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tSemicolon;
	
	    public ConfigPropertyDeclarationGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ConfigPropertyDeclarationGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ConfigPropertyDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ConfigPropertyDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ConfigPropertyDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.identifier;
	            case 2: return this.tAssign;
	            case 3: return this.expression;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitConfigPropertyDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitConfigPropertyDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConfigPropertyDeclarationGreen(this.Kind, this.typeReference, this.identifier, this.tAssign, this.expression, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConfigPropertyDeclarationGreen(this.Kind, this.typeReference, this.identifier, this.tAssign, this.expression, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ConfigPropertyDeclarationGreen Update(TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConfigPropertyDeclaration(typeReference, identifier, tAssign, expression, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConfigPropertyDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ConfigPropertyGroupDeclarationGreen : ConfigPropertyGreen
	{
	    internal static new readonly ConfigPropertyGroupDeclarationGreen __Missing = new ConfigPropertyGroupDeclarationGreen();
	    private InternalSyntaxToken startProperties;
	    private IdentifierGreen identifier;
	    private GreenNode configProperty;
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken endProperties;
	
	    public ConfigPropertyGroupDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken startProperties, IdentifierGreen identifier, GreenNode configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (startProperties != null)
			{
				this.AdjustFlagsAndWidth(startProperties);
				this.startProperties = startProperties;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (configProperty != null)
			{
				this.AdjustFlagsAndWidth(configProperty);
				this.configProperty = configProperty;
			}
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (endProperties != null)
			{
				this.AdjustFlagsAndWidth(endProperties);
				this.endProperties = endProperties;
			}
	    }
	
	    public ConfigPropertyGroupDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken startProperties, IdentifierGreen identifier, GreenNode configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (startProperties != null)
			{
				this.AdjustFlagsAndWidth(startProperties);
				this.startProperties = startProperties;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (configProperty != null)
			{
				this.AdjustFlagsAndWidth(configProperty);
				this.configProperty = configProperty;
			}
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (endProperties != null)
			{
				this.AdjustFlagsAndWidth(endProperties);
				this.endProperties = endProperties;
			}
	    }
	
		private ConfigPropertyGroupDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ConfigPropertyGroupDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken StartProperties { get { return this.startProperties; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen> ConfigProperty { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen>(this.configProperty); } }
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken EndProperties { get { return this.endProperties; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ConfigPropertyGroupDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.startProperties;
	            case 1: return this.identifier;
	            case 2: return this.configProperty;
	            case 3: return this.kEnd;
	            case 4: return this.endProperties;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitConfigPropertyGroupDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitConfigPropertyGroupDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConfigPropertyGroupDeclarationGreen(this.Kind, this.startProperties, this.identifier, this.configProperty, this.kEnd, this.endProperties, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConfigPropertyGroupDeclarationGreen(this.Kind, this.startProperties, this.identifier, this.configProperty, this.kEnd, this.endProperties, this.GetDiagnostics(), annotations);
	    }
	
	    public ConfigPropertyGroupDeclarationGreen Update(InternalSyntaxToken startProperties, IdentifierGreen identifier, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen> configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties)
	    {
	        if (this.StartProperties != startProperties ||
				this.Identifier != identifier ||
				this.ConfigProperty != configProperty ||
				this.KEnd != kEnd ||
				this.EndProperties != endProperties)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConfigPropertyGroupDeclaration(startProperties, identifier, configProperty, kEnd, endProperties);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConfigPropertyGroupDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MethodDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly MethodDeclarationGreen __Missing = new MethodDeclarationGreen();
	    private FunctionDeclarationGreen functionDeclaration;
	    private TemplateDeclarationGreen templateDeclaration;
	    private ExternFunctionDeclarationGreen externFunctionDeclaration;
	
	    public MethodDeclarationGreen(TestLexerModeSyntaxKind kind, FunctionDeclarationGreen functionDeclaration, TemplateDeclarationGreen templateDeclaration, ExternFunctionDeclarationGreen externFunctionDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
			if (templateDeclaration != null)
			{
				this.AdjustFlagsAndWidth(templateDeclaration);
				this.templateDeclaration = templateDeclaration;
			}
			if (externFunctionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externFunctionDeclaration);
				this.externFunctionDeclaration = externFunctionDeclaration;
			}
	    }
	
	    public MethodDeclarationGreen(TestLexerModeSyntaxKind kind, FunctionDeclarationGreen functionDeclaration, TemplateDeclarationGreen templateDeclaration, ExternFunctionDeclarationGreen externFunctionDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
			if (templateDeclaration != null)
			{
				this.AdjustFlagsAndWidth(templateDeclaration);
				this.templateDeclaration = templateDeclaration;
			}
			if (externFunctionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externFunctionDeclaration);
				this.externFunctionDeclaration = externFunctionDeclaration;
			}
	    }
	
		private MethodDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MethodDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FunctionDeclarationGreen FunctionDeclaration { get { return this.functionDeclaration; } }
	    public TemplateDeclarationGreen TemplateDeclaration { get { return this.templateDeclaration; } }
	    public ExternFunctionDeclarationGreen ExternFunctionDeclaration { get { return this.externFunctionDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.MethodDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.functionDeclaration;
	            case 1: return this.templateDeclaration;
	            case 2: return this.externFunctionDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitMethodDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitMethodDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MethodDeclarationGreen(this.Kind, this.functionDeclaration, this.templateDeclaration, this.externFunctionDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MethodDeclarationGreen(this.Kind, this.functionDeclaration, this.templateDeclaration, this.externFunctionDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public MethodDeclarationGreen Update(FunctionDeclarationGreen functionDeclaration)
	    {
	        if (this.functionDeclaration != functionDeclaration)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.MethodDeclaration(functionDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MethodDeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public MethodDeclarationGreen Update(TemplateDeclarationGreen templateDeclaration)
	    {
	        if (this.templateDeclaration != templateDeclaration)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.MethodDeclaration(templateDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MethodDeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public MethodDeclarationGreen Update(ExternFunctionDeclarationGreen externFunctionDeclaration)
	    {
	        if (this.externFunctionDeclaration != externFunctionDeclaration)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.MethodDeclaration(externFunctionDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MethodDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExternFunctionDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ExternFunctionDeclarationGreen __Missing = new ExternFunctionDeclarationGreen();
	    private InternalSyntaxToken kExtern;
	    private FunctionSignatureGreen functionSignature;
	
	    public ExternFunctionDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kExtern, FunctionSignatureGreen functionSignature)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kExtern != null)
			{
				this.AdjustFlagsAndWidth(kExtern);
				this.kExtern = kExtern;
			}
			if (functionSignature != null)
			{
				this.AdjustFlagsAndWidth(functionSignature);
				this.functionSignature = functionSignature;
			}
	    }
	
	    public ExternFunctionDeclarationGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kExtern, FunctionSignatureGreen functionSignature, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kExtern != null)
			{
				this.AdjustFlagsAndWidth(kExtern);
				this.kExtern = kExtern;
			}
			if (functionSignature != null)
			{
				this.AdjustFlagsAndWidth(functionSignature);
				this.functionSignature = functionSignature;
			}
	    }
	
		private ExternFunctionDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExternFunctionDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KExtern { get { return this.kExtern; } }
	    public FunctionSignatureGreen FunctionSignature { get { return this.functionSignature; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ExternFunctionDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kExtern;
	            case 1: return this.functionSignature;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitExternFunctionDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitExternFunctionDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExternFunctionDeclarationGreen(this.Kind, this.kExtern, this.functionSignature, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExternFunctionDeclarationGreen(this.Kind, this.kExtern, this.functionSignature, this.GetDiagnostics(), annotations);
	    }
	
	    public ExternFunctionDeclarationGreen Update(InternalSyntaxToken kExtern, FunctionSignatureGreen functionSignature)
	    {
	        if (this.KExtern != kExtern ||
				this.FunctionSignature != functionSignature)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExternFunctionDeclaration(kExtern, functionSignature);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExternFunctionDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FunctionDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly FunctionDeclarationGreen __Missing = new FunctionDeclarationGreen();
	    private FunctionSignatureGreen functionSignature;
	    private BodyGreen body;
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken kFunction;
	
	    public FunctionDeclarationGreen(TestLexerModeSyntaxKind kind, FunctionSignatureGreen functionSignature, BodyGreen body, InternalSyntaxToken kEnd, InternalSyntaxToken kFunction)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (functionSignature != null)
			{
				this.AdjustFlagsAndWidth(functionSignature);
				this.functionSignature = functionSignature;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kFunction != null)
			{
				this.AdjustFlagsAndWidth(kFunction);
				this.kFunction = kFunction;
			}
	    }
	
	    public FunctionDeclarationGreen(TestLexerModeSyntaxKind kind, FunctionSignatureGreen functionSignature, BodyGreen body, InternalSyntaxToken kEnd, InternalSyntaxToken kFunction, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (functionSignature != null)
			{
				this.AdjustFlagsAndWidth(functionSignature);
				this.functionSignature = functionSignature;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kFunction != null)
			{
				this.AdjustFlagsAndWidth(kFunction);
				this.kFunction = kFunction;
			}
	    }
	
		private FunctionDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.FunctionDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FunctionSignatureGreen FunctionSignature { get { return this.functionSignature; } }
	    public BodyGreen Body { get { return this.body; } }
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken KFunction { get { return this.kFunction; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.FunctionDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.functionSignature;
	            case 1: return this.body;
	            case 2: return this.kEnd;
	            case 3: return this.kFunction;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitFunctionDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionDeclarationGreen(this.Kind, this.functionSignature, this.body, this.kEnd, this.kFunction, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionDeclarationGreen(this.Kind, this.functionSignature, this.body, this.kEnd, this.kFunction, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionDeclarationGreen Update(FunctionSignatureGreen functionSignature, BodyGreen body, InternalSyntaxToken kEnd, InternalSyntaxToken kFunction)
	    {
	        if (this.FunctionSignature != functionSignature ||
				this.Body != body ||
				this.KEnd != kEnd ||
				this.KFunction != kFunction)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.FunctionDeclaration(functionSignature, body, kEnd, kFunction);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FunctionSignatureGreen : GreenSyntaxNode
	{
	    internal static readonly FunctionSignatureGreen __Missing = new FunctionSignatureGreen();
	    private InternalSyntaxToken kFunction;
	    private ReturnTypeGreen returnType;
	    private IdentifierGreen identifier;
	    private TypeArgumentListGreen typeArgumentList;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ParamListGreen paramList;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public FunctionSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kFunction, ReturnTypeGreen returnType, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (kFunction != null)
			{
				this.AdjustFlagsAndWidth(kFunction);
				this.kFunction = kFunction;
			}
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (paramList != null)
			{
				this.AdjustFlagsAndWidth(paramList);
				this.paramList = paramList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public FunctionSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kFunction, ReturnTypeGreen returnType, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (kFunction != null)
			{
				this.AdjustFlagsAndWidth(kFunction);
				this.kFunction = kFunction;
			}
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (paramList != null)
			{
				this.AdjustFlagsAndWidth(paramList);
				this.paramList = paramList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private FunctionSignatureGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.FunctionSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KFunction { get { return this.kFunction; } }
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ParamListGreen ParamList { get { return this.paramList; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.FunctionSignatureSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kFunction;
	            case 1: return this.returnType;
	            case 2: return this.identifier;
	            case 3: return this.typeArgumentList;
	            case 4: return this.tOpenParenthesis;
	            case 5: return this.paramList;
	            case 6: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionSignatureGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitFunctionSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionSignatureGreen(this.Kind, this.kFunction, this.returnType, this.identifier, this.typeArgumentList, this.tOpenParenthesis, this.paramList, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionSignatureGreen(this.Kind, this.kFunction, this.returnType, this.identifier, this.typeArgumentList, this.tOpenParenthesis, this.paramList, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionSignatureGreen Update(InternalSyntaxToken kFunction, ReturnTypeGreen returnType, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KFunction != kFunction ||
				this.ReturnType != returnType ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ParamList != paramList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.FunctionSignature(kFunction, returnType, identifier, typeArgumentList, tOpenParenthesis, paramList, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParamListGreen : GreenSyntaxNode
	{
	    internal static readonly ParamListGreen __Missing = new ParamListGreen();
	    private GreenNode parameter;
	
	    public ParamListGreen(TestLexerModeSyntaxKind kind, GreenNode parameter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
	    public ParamListGreen(TestLexerModeSyntaxKind kind, GreenNode parameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
		private ParamListGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ParamList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> Parameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen>(this.parameter); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ParamListSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parameter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitParamListGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitParamListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParamListGreen(this.Kind, this.parameter, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParamListGreen(this.Kind, this.parameter, this.GetDiagnostics(), annotations);
	    }
	
	    public ParamListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
	    {
	        if (this.Parameter != parameter)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ParamList(parameter);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParamListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParameterGreen : GreenSyntaxNode
	{
	    internal static readonly ParameterGreen __Missing = new ParameterGreen();
	    private TypeReferenceGreen typeReference;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	
	    public ParameterGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ParameterGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private ParameterGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Parameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ParameterSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.identifier;
	            case 2: return this.tAssign;
	            case 3: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitParameterGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterGreen(this.Kind, this.typeReference, this.identifier, this.tAssign, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterGreen(this.Kind, this.typeReference, this.identifier, this.tAssign, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterGreen Update(TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Parameter(typeReference, identifier, tAssign, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BodyGreen : GreenSyntaxNode
	{
	    internal static readonly BodyGreen __Missing = new BodyGreen();
	    private GreenNode statement;
	
	    public BodyGreen(TestLexerModeSyntaxKind kind, GreenNode statement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
	    }
	
	    public BodyGreen(TestLexerModeSyntaxKind kind, GreenNode statement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
	    }
	
		private BodyGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Body, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> Statement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen>(this.statement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.BodySyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.statement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitBodyGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BodyGreen(this.Kind, this.statement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BodyGreen(this.Kind, this.statement, this.GetDiagnostics(), annotations);
	    }
	
	    public BodyGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement)
	    {
	        if (this.Statement != statement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Body(statement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StatementGreen : GreenSyntaxNode
	{
	    internal static readonly StatementGreen __Missing = new StatementGreen();
	    private SingleStatementSemicolonGreen singleStatementSemicolon;
	    private IfStatementGreen ifStatement;
	    private ForStatementGreen forStatement;
	    private WhileStatementGreen whileStatement;
	    private RepeatStatementGreen repeatStatement;
	    private LoopStatementGreen loopStatement;
	    private SwitchStatementGreen switchStatement;
	
	    public StatementGreen(TestLexerModeSyntaxKind kind, SingleStatementSemicolonGreen singleStatementSemicolon, IfStatementGreen ifStatement, ForStatementGreen forStatement, WhileStatementGreen whileStatement, RepeatStatementGreen repeatStatement, LoopStatementGreen loopStatement, SwitchStatementGreen switchStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (singleStatementSemicolon != null)
			{
				this.AdjustFlagsAndWidth(singleStatementSemicolon);
				this.singleStatementSemicolon = singleStatementSemicolon;
			}
			if (ifStatement != null)
			{
				this.AdjustFlagsAndWidth(ifStatement);
				this.ifStatement = ifStatement;
			}
			if (forStatement != null)
			{
				this.AdjustFlagsAndWidth(forStatement);
				this.forStatement = forStatement;
			}
			if (whileStatement != null)
			{
				this.AdjustFlagsAndWidth(whileStatement);
				this.whileStatement = whileStatement;
			}
			if (repeatStatement != null)
			{
				this.AdjustFlagsAndWidth(repeatStatement);
				this.repeatStatement = repeatStatement;
			}
			if (loopStatement != null)
			{
				this.AdjustFlagsAndWidth(loopStatement);
				this.loopStatement = loopStatement;
			}
			if (switchStatement != null)
			{
				this.AdjustFlagsAndWidth(switchStatement);
				this.switchStatement = switchStatement;
			}
	    }
	
	    public StatementGreen(TestLexerModeSyntaxKind kind, SingleStatementSemicolonGreen singleStatementSemicolon, IfStatementGreen ifStatement, ForStatementGreen forStatement, WhileStatementGreen whileStatement, RepeatStatementGreen repeatStatement, LoopStatementGreen loopStatement, SwitchStatementGreen switchStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (singleStatementSemicolon != null)
			{
				this.AdjustFlagsAndWidth(singleStatementSemicolon);
				this.singleStatementSemicolon = singleStatementSemicolon;
			}
			if (ifStatement != null)
			{
				this.AdjustFlagsAndWidth(ifStatement);
				this.ifStatement = ifStatement;
			}
			if (forStatement != null)
			{
				this.AdjustFlagsAndWidth(forStatement);
				this.forStatement = forStatement;
			}
			if (whileStatement != null)
			{
				this.AdjustFlagsAndWidth(whileStatement);
				this.whileStatement = whileStatement;
			}
			if (repeatStatement != null)
			{
				this.AdjustFlagsAndWidth(repeatStatement);
				this.repeatStatement = repeatStatement;
			}
			if (loopStatement != null)
			{
				this.AdjustFlagsAndWidth(loopStatement);
				this.loopStatement = loopStatement;
			}
			if (switchStatement != null)
			{
				this.AdjustFlagsAndWidth(switchStatement);
				this.switchStatement = switchStatement;
			}
	    }
	
		private StatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Statement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SingleStatementSemicolonGreen SingleStatementSemicolon { get { return this.singleStatementSemicolon; } }
	    public IfStatementGreen IfStatement { get { return this.ifStatement; } }
	    public ForStatementGreen ForStatement { get { return this.forStatement; } }
	    public WhileStatementGreen WhileStatement { get { return this.whileStatement; } }
	    public RepeatStatementGreen RepeatStatement { get { return this.repeatStatement; } }
	    public LoopStatementGreen LoopStatement { get { return this.loopStatement; } }
	    public SwitchStatementGreen SwitchStatement { get { return this.switchStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.StatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.singleStatementSemicolon;
	            case 1: return this.ifStatement;
	            case 2: return this.forStatement;
	            case 3: return this.whileStatement;
	            case 4: return this.repeatStatement;
	            case 5: return this.loopStatement;
	            case 6: return this.switchStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StatementGreen(this.Kind, this.singleStatementSemicolon, this.ifStatement, this.forStatement, this.whileStatement, this.repeatStatement, this.loopStatement, this.switchStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StatementGreen(this.Kind, this.singleStatementSemicolon, this.ifStatement, this.forStatement, this.whileStatement, this.repeatStatement, this.loopStatement, this.switchStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public StatementGreen Update(SingleStatementSemicolonGreen singleStatementSemicolon)
	    {
	        if (this.singleStatementSemicolon != singleStatementSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(singleStatementSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public StatementGreen Update(IfStatementGreen ifStatement)
	    {
	        if (this.ifStatement != ifStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(ifStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public StatementGreen Update(ForStatementGreen forStatement)
	    {
	        if (this.forStatement != forStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(forStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public StatementGreen Update(WhileStatementGreen whileStatement)
	    {
	        if (this.whileStatement != whileStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(whileStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public StatementGreen Update(RepeatStatementGreen repeatStatement)
	    {
	        if (this.repeatStatement != repeatStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(repeatStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public StatementGreen Update(LoopStatementGreen loopStatement)
	    {
	        if (this.loopStatement != loopStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(loopStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public StatementGreen Update(SwitchStatementGreen switchStatement)
	    {
	        if (this.switchStatement != switchStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement(switchStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SingleStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SingleStatementGreen __Missing = new SingleStatementGreen();
	    private VariableDeclarationStatementGreen variableDeclarationStatement;
	    private ReturnStatementGreen returnStatement;
	    private ExpressionStatementGreen expressionStatement;
	
	    public SingleStatementGreen(TestLexerModeSyntaxKind kind, VariableDeclarationStatementGreen variableDeclarationStatement, ReturnStatementGreen returnStatement, ExpressionStatementGreen expressionStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (variableDeclarationStatement != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationStatement);
				this.variableDeclarationStatement = variableDeclarationStatement;
			}
			if (returnStatement != null)
			{
				this.AdjustFlagsAndWidth(returnStatement);
				this.returnStatement = returnStatement;
			}
			if (expressionStatement != null)
			{
				this.AdjustFlagsAndWidth(expressionStatement);
				this.expressionStatement = expressionStatement;
			}
	    }
	
	    public SingleStatementGreen(TestLexerModeSyntaxKind kind, VariableDeclarationStatementGreen variableDeclarationStatement, ReturnStatementGreen returnStatement, ExpressionStatementGreen expressionStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (variableDeclarationStatement != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationStatement);
				this.variableDeclarationStatement = variableDeclarationStatement;
			}
			if (returnStatement != null)
			{
				this.AdjustFlagsAndWidth(returnStatement);
				this.returnStatement = returnStatement;
			}
			if (expressionStatement != null)
			{
				this.AdjustFlagsAndWidth(expressionStatement);
				this.expressionStatement = expressionStatement;
			}
	    }
	
		private SingleStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationStatementGreen VariableDeclarationStatement { get { return this.variableDeclarationStatement; } }
	    public ReturnStatementGreen ReturnStatement { get { return this.returnStatement; } }
	    public ExpressionStatementGreen ExpressionStatement { get { return this.expressionStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SingleStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclarationStatement;
	            case 1: return this.returnStatement;
	            case 2: return this.expressionStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSingleStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSingleStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SingleStatementGreen(this.Kind, this.variableDeclarationStatement, this.returnStatement, this.expressionStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SingleStatementGreen(this.Kind, this.variableDeclarationStatement, this.returnStatement, this.expressionStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public SingleStatementGreen Update(VariableDeclarationStatementGreen variableDeclarationStatement)
	    {
	        if (this.variableDeclarationStatement != variableDeclarationStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatement(variableDeclarationStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public SingleStatementGreen Update(ReturnStatementGreen returnStatement)
	    {
	        if (this.returnStatement != returnStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatement(returnStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public SingleStatementGreen Update(ExpressionStatementGreen expressionStatement)
	    {
	        if (this.expressionStatement != expressionStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatement(expressionStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SingleStatementSemicolonGreen : GreenSyntaxNode
	{
	    internal static readonly SingleStatementSemicolonGreen __Missing = new SingleStatementSemicolonGreen();
	    private SingleStatementGreen singleStatement;
	    private InternalSyntaxToken tSemicolon;
	
	    public SingleStatementSemicolonGreen(TestLexerModeSyntaxKind kind, SingleStatementGreen singleStatement, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (singleStatement != null)
			{
				this.AdjustFlagsAndWidth(singleStatement);
				this.singleStatement = singleStatement;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public SingleStatementSemicolonGreen(TestLexerModeSyntaxKind kind, SingleStatementGreen singleStatement, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (singleStatement != null)
			{
				this.AdjustFlagsAndWidth(singleStatement);
				this.singleStatement = singleStatement;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private SingleStatementSemicolonGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleStatementSemicolon, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SingleStatementGreen SingleStatement { get { return this.singleStatement; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SingleStatementSemicolonSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.singleStatement;
	            case 1: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSingleStatementSemicolonGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSingleStatementSemicolonGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SingleStatementSemicolonGreen(this.Kind, this.singleStatement, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SingleStatementSemicolonGreen(this.Kind, this.singleStatement, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SingleStatementSemicolonGreen Update(SingleStatementGreen singleStatement, InternalSyntaxToken tSemicolon)
	    {
	        if (this.SingleStatement != singleStatement ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatementSemicolon(singleStatement, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementSemicolonGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VariableDeclarationStatementGreen : GreenSyntaxNode
	{
	    internal static readonly VariableDeclarationStatementGreen __Missing = new VariableDeclarationStatementGreen();
	    private VariableDeclarationExpressionGreen variableDeclarationExpression;
	
	    public VariableDeclarationStatementGreen(TestLexerModeSyntaxKind kind, VariableDeclarationExpressionGreen variableDeclarationExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (variableDeclarationExpression != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationExpression);
				this.variableDeclarationExpression = variableDeclarationExpression;
			}
	    }
	
	    public VariableDeclarationStatementGreen(TestLexerModeSyntaxKind kind, VariableDeclarationExpressionGreen variableDeclarationExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (variableDeclarationExpression != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationExpression);
				this.variableDeclarationExpression = variableDeclarationExpression;
			}
	    }
	
		private VariableDeclarationStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableDeclarationStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationExpressionGreen VariableDeclarationExpression { get { return this.variableDeclarationExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.VariableDeclarationStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclarationExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitVariableDeclarationStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitVariableDeclarationStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableDeclarationStatementGreen(this.Kind, this.variableDeclarationExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableDeclarationStatementGreen(this.Kind, this.variableDeclarationExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableDeclarationStatementGreen Update(VariableDeclarationExpressionGreen variableDeclarationExpression)
	    {
	        if (this.VariableDeclarationExpression != variableDeclarationExpression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableDeclarationStatement(variableDeclarationExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VariableDeclarationExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly VariableDeclarationExpressionGreen __Missing = new VariableDeclarationExpressionGreen();
	    private TypeReferenceGreen typeReference;
	    private GreenNode variableDeclarationItem;
	
	    public VariableDeclarationExpressionGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, GreenNode variableDeclarationItem)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (variableDeclarationItem != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationItem);
				this.variableDeclarationItem = variableDeclarationItem;
			}
	    }
	
	    public VariableDeclarationExpressionGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, GreenNode variableDeclarationItem, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (variableDeclarationItem != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationItem);
				this.variableDeclarationItem = variableDeclarationItem;
			}
	    }
	
		private VariableDeclarationExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableDeclarationExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableDeclarationItemGreen> VariableDeclarationItem { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableDeclarationItemGreen>(this.variableDeclarationItem); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.VariableDeclarationExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.variableDeclarationItem;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitVariableDeclarationExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitVariableDeclarationExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableDeclarationExpressionGreen(this.Kind, this.typeReference, this.variableDeclarationItem, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableDeclarationExpressionGreen(this.Kind, this.typeReference, this.variableDeclarationItem, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableDeclarationExpressionGreen Update(TypeReferenceGreen typeReference, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableDeclarationItemGreen> variableDeclarationItem)
	    {
	        if (this.TypeReference != typeReference ||
				this.VariableDeclarationItem != variableDeclarationItem)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableDeclarationExpression(typeReference, variableDeclarationItem);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VariableDeclarationItemGreen : GreenSyntaxNode
	{
	    internal static readonly VariableDeclarationItemGreen __Missing = new VariableDeclarationItemGreen();
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	
	    public VariableDeclarationItemGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public VariableDeclarationItemGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private VariableDeclarationItemGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableDeclarationItem, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.VariableDeclarationItemSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.tAssign;
	            case 2: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitVariableDeclarationItemGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitVariableDeclarationItemGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableDeclarationItemGreen(this.Kind, this.identifier, this.tAssign, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableDeclarationItemGreen(this.Kind, this.identifier, this.tAssign, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableDeclarationItemGreen Update(IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	        if (this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableDeclarationItem(identifier, tAssign, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationItemGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VoidStatementGreen : GreenSyntaxNode
	{
	    internal static readonly VoidStatementGreen __Missing = new VoidStatementGreen();
	    private InternalSyntaxToken kVoid;
	    private ExpressionGreen expression;
	
	    public VoidStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kVoid, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public VoidStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kVoid, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private VoidStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VoidStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.VoidStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitVoidStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitVoidStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VoidStatementGreen(this.Kind, this.kVoid, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VoidStatementGreen(this.Kind, this.kVoid, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public VoidStatementGreen Update(InternalSyntaxToken kVoid, ExpressionGreen expression)
	    {
	        if (this.KVoid != kVoid ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.VoidStatement(kVoid, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnStatementGreen __Missing = new ReturnStatementGreen();
	    private InternalSyntaxToken kReturn;
	    private ExpressionGreen expression;
	
	    public ReturnStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kReturn, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kReturn != null)
			{
				this.AdjustFlagsAndWidth(kReturn);
				this.kReturn = kReturn;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ReturnStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kReturn, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kReturn != null)
			{
				this.AdjustFlagsAndWidth(kReturn);
				this.kReturn = kReturn;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private ReturnStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ReturnStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KReturn { get { return this.kReturn; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ReturnStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kReturn;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitReturnStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitReturnStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnStatementGreen(this.Kind, this.kReturn, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnStatementGreen(this.Kind, this.kReturn, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnStatementGreen Update(InternalSyntaxToken kReturn, ExpressionGreen expression)
	    {
	        if (this.KReturn != kReturn ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ReturnStatement(kReturn, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExpressionStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ExpressionStatementGreen __Missing = new ExpressionStatementGreen();
	    private ExpressionGreen expression;
	
	    public ExpressionStatementGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ExpressionStatementGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private ExpressionStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExpressionStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ExpressionStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitExpressionStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitExpressionStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExpressionStatementGreen(this.Kind, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExpressionStatementGreen(this.Kind, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public ExpressionStatementGreen Update(ExpressionGreen expression)
	    {
	        if (this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExpressionStatement(expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IfStatementGreen : GreenSyntaxNode
	{
	    internal static readonly IfStatementGreen __Missing = new IfStatementGreen();
	    private IfStatementBeginGreen ifStatementBegin;
	    private BodyGreen body;
	    private GreenNode elseIfStatementBody;
	    private IfStatementElseBodyGreen ifStatementElseBody;
	    private IfStatementEndGreen ifStatementEnd;
	
	    public IfStatementGreen(TestLexerModeSyntaxKind kind, IfStatementBeginGreen ifStatementBegin, BodyGreen body, GreenNode elseIfStatementBody, IfStatementElseBodyGreen ifStatementElseBody, IfStatementEndGreen ifStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (ifStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(ifStatementBegin);
				this.ifStatementBegin = ifStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (elseIfStatementBody != null)
			{
				this.AdjustFlagsAndWidth(elseIfStatementBody);
				this.elseIfStatementBody = elseIfStatementBody;
			}
			if (ifStatementElseBody != null)
			{
				this.AdjustFlagsAndWidth(ifStatementElseBody);
				this.ifStatementElseBody = ifStatementElseBody;
			}
			if (ifStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(ifStatementEnd);
				this.ifStatementEnd = ifStatementEnd;
			}
	    }
	
	    public IfStatementGreen(TestLexerModeSyntaxKind kind, IfStatementBeginGreen ifStatementBegin, BodyGreen body, GreenNode elseIfStatementBody, IfStatementElseBodyGreen ifStatementElseBody, IfStatementEndGreen ifStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (ifStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(ifStatementBegin);
				this.ifStatementBegin = ifStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (elseIfStatementBody != null)
			{
				this.AdjustFlagsAndWidth(elseIfStatementBody);
				this.elseIfStatementBody = elseIfStatementBody;
			}
			if (ifStatementElseBody != null)
			{
				this.AdjustFlagsAndWidth(ifStatementElseBody);
				this.ifStatementElseBody = ifStatementElseBody;
			}
			if (ifStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(ifStatementEnd);
				this.ifStatementEnd = ifStatementEnd;
			}
	    }
	
		private IfStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IfStatementBeginGreen IfStatementBegin { get { return this.ifStatementBegin; } }
	    public BodyGreen Body { get { return this.body; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfStatementBodyGreen> ElseIfStatementBody { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfStatementBodyGreen>(this.elseIfStatementBody); } }
	    public IfStatementElseBodyGreen IfStatementElseBody { get { return this.ifStatementElseBody; } }
	    public IfStatementEndGreen IfStatementEnd { get { return this.ifStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IfStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.ifStatementBegin;
	            case 1: return this.body;
	            case 2: return this.elseIfStatementBody;
	            case 3: return this.ifStatementElseBody;
	            case 4: return this.ifStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIfStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIfStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfStatementGreen(this.Kind, this.ifStatementBegin, this.body, this.elseIfStatementBody, this.ifStatementElseBody, this.ifStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfStatementGreen(this.Kind, this.ifStatementBegin, this.body, this.elseIfStatementBody, this.ifStatementElseBody, this.ifStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public IfStatementGreen Update(IfStatementBeginGreen ifStatementBegin, BodyGreen body, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfStatementBodyGreen> elseIfStatementBody, IfStatementElseBodyGreen ifStatementElseBody, IfStatementEndGreen ifStatementEnd)
	    {
	        if (this.IfStatementBegin != ifStatementBegin ||
				this.Body != body ||
				this.ElseIfStatementBody != elseIfStatementBody ||
				this.IfStatementElseBody != ifStatementElseBody ||
				this.IfStatementEnd != ifStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatement(ifStatementBegin, body, elseIfStatementBody, ifStatementElseBody, ifStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElseIfStatementBodyGreen : GreenSyntaxNode
	{
	    internal static readonly ElseIfStatementBodyGreen __Missing = new ElseIfStatementBodyGreen();
	    private ElseIfStatementGreen elseIfStatement;
	    private BodyGreen body;
	
	    public ElseIfStatementBodyGreen(TestLexerModeSyntaxKind kind, ElseIfStatementGreen elseIfStatement, BodyGreen body)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (elseIfStatement != null)
			{
				this.AdjustFlagsAndWidth(elseIfStatement);
				this.elseIfStatement = elseIfStatement;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
	    public ElseIfStatementBodyGreen(TestLexerModeSyntaxKind kind, ElseIfStatementGreen elseIfStatement, BodyGreen body, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (elseIfStatement != null)
			{
				this.AdjustFlagsAndWidth(elseIfStatement);
				this.elseIfStatement = elseIfStatement;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
		private ElseIfStatementBodyGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ElseIfStatementBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ElseIfStatementGreen ElseIfStatement { get { return this.elseIfStatement; } }
	    public BodyGreen Body { get { return this.body; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ElseIfStatementBodySyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.elseIfStatement;
	            case 1: return this.body;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitElseIfStatementBodyGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitElseIfStatementBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElseIfStatementBodyGreen(this.Kind, this.elseIfStatement, this.body, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElseIfStatementBodyGreen(this.Kind, this.elseIfStatement, this.body, this.GetDiagnostics(), annotations);
	    }
	
	    public ElseIfStatementBodyGreen Update(ElseIfStatementGreen elseIfStatement, BodyGreen body)
	    {
	        if (this.ElseIfStatement != elseIfStatement ||
				this.Body != body)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElseIfStatementBody(elseIfStatement, body);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseIfStatementBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IfStatementElseBodyGreen : GreenSyntaxNode
	{
	    internal static readonly IfStatementElseBodyGreen __Missing = new IfStatementElseBodyGreen();
	    private IfStatementElseGreen ifStatementElse;
	    private BodyGreen body;
	
	    public IfStatementElseBodyGreen(TestLexerModeSyntaxKind kind, IfStatementElseGreen ifStatementElse, BodyGreen body)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (ifStatementElse != null)
			{
				this.AdjustFlagsAndWidth(ifStatementElse);
				this.ifStatementElse = ifStatementElse;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
	    public IfStatementElseBodyGreen(TestLexerModeSyntaxKind kind, IfStatementElseGreen ifStatementElse, BodyGreen body, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (ifStatementElse != null)
			{
				this.AdjustFlagsAndWidth(ifStatementElse);
				this.ifStatementElse = ifStatementElse;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
		private IfStatementElseBodyGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementElseBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IfStatementElseGreen IfStatementElse { get { return this.ifStatementElse; } }
	    public BodyGreen Body { get { return this.body; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IfStatementElseBodySyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.ifStatementElse;
	            case 1: return this.body;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIfStatementElseBodyGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIfStatementElseBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfStatementElseBodyGreen(this.Kind, this.ifStatementElse, this.body, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfStatementElseBodyGreen(this.Kind, this.ifStatementElse, this.body, this.GetDiagnostics(), annotations);
	    }
	
	    public IfStatementElseBodyGreen Update(IfStatementElseGreen ifStatementElse, BodyGreen body)
	    {
	        if (this.IfStatementElse != ifStatementElse ||
				this.Body != body)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementElseBody(ifStatementElse, body);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementElseBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IfStatementBeginGreen : GreenSyntaxNode
	{
	    internal static readonly IfStatementBeginGreen __Missing = new IfStatementBeginGreen();
	    private InternalSyntaxToken kIf;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public IfStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public IfStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private IfStatementBeginGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementBegin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KIf { get { return this.kIf; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IfStatementBeginSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kIf;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.expression;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIfStatementBeginGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIfStatementBeginGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfStatementBeginGreen(this.Kind, this.kIf, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfStatementBeginGreen(this.Kind, this.kIf, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public IfStatementBeginGreen Update(InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KIf != kIf ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementBegin(kIf, tOpenParenthesis, expression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementBeginGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElseIfStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ElseIfStatementGreen __Missing = new ElseIfStatementGreen();
	    private InternalSyntaxToken kElse;
	    private InternalSyntaxToken kIf;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public ElseIfStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kElse, InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public ElseIfStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kElse, InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private ElseIfStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ElseIfStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KElse { get { return this.kElse; } }
	    public InternalSyntaxToken KIf { get { return this.kIf; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ElseIfStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kElse;
	            case 1: return this.kIf;
	            case 2: return this.tOpenParenthesis;
	            case 3: return this.expression;
	            case 4: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitElseIfStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitElseIfStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElseIfStatementGreen(this.Kind, this.kElse, this.kIf, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElseIfStatementGreen(this.Kind, this.kElse, this.kIf, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public ElseIfStatementGreen Update(InternalSyntaxToken kElse, InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KElse != kElse ||
				this.KIf != kIf ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElseIfStatement(kElse, kIf, tOpenParenthesis, expression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseIfStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IfStatementElseGreen : GreenSyntaxNode
	{
	    internal static readonly IfStatementElseGreen __Missing = new IfStatementElseGreen();
	    private InternalSyntaxToken kElse;
	
	    public IfStatementElseGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kElse)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
	    }
	
	    public IfStatementElseGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kElse, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
	    }
	
		private IfStatementElseGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementElse, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KElse { get { return this.kElse; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IfStatementElseSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kElse;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIfStatementElseGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIfStatementElseGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfStatementElseGreen(this.Kind, this.kElse, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfStatementElseGreen(this.Kind, this.kElse, this.GetDiagnostics(), annotations);
	    }
	
	    public IfStatementElseGreen Update(InternalSyntaxToken kElse)
	    {
	        if (this.KElse != kElse)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementElse(kElse);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementElseGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IfStatementEndGreen : GreenSyntaxNode
	{
	    internal static readonly IfStatementEndGreen __Missing = new IfStatementEndGreen();
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken kIf;
	
	    public IfStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kIf)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
	    }
	
	    public IfStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kIf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
	    }
	
		private IfStatementEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken KIf { get { return this.kIf; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IfStatementEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnd;
	            case 1: return this.kIf;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIfStatementEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIfStatementEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfStatementEndGreen(this.Kind, this.kEnd, this.kIf, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfStatementEndGreen(this.Kind, this.kEnd, this.kIf, this.GetDiagnostics(), annotations);
	    }
	
	    public IfStatementEndGreen Update(InternalSyntaxToken kEnd, InternalSyntaxToken kIf)
	    {
	        if (this.KEnd != kEnd ||
				this.KIf != kIf)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementEnd(kEnd, kIf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ForStatementGreen __Missing = new ForStatementGreen();
	    private ForStatementBeginGreen forStatementBegin;
	    private BodyGreen body;
	    private ForStatementEndGreen forStatementEnd;
	
	    public ForStatementGreen(TestLexerModeSyntaxKind kind, ForStatementBeginGreen forStatementBegin, BodyGreen body, ForStatementEndGreen forStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (forStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(forStatementBegin);
				this.forStatementBegin = forStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (forStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(forStatementEnd);
				this.forStatementEnd = forStatementEnd;
			}
	    }
	
	    public ForStatementGreen(TestLexerModeSyntaxKind kind, ForStatementBeginGreen forStatementBegin, BodyGreen body, ForStatementEndGreen forStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (forStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(forStatementBegin);
				this.forStatementBegin = forStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (forStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(forStatementEnd);
				this.forStatementEnd = forStatementEnd;
			}
	    }
	
		private ForStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ForStatementBeginGreen ForStatementBegin { get { return this.forStatementBegin; } }
	    public BodyGreen Body { get { return this.body; } }
	    public ForStatementEndGreen ForStatementEnd { get { return this.forStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ForStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.forStatementBegin;
	            case 1: return this.body;
	            case 2: return this.forStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitForStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitForStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForStatementGreen(this.Kind, this.forStatementBegin, this.body, this.forStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForStatementGreen(this.Kind, this.forStatementBegin, this.body, this.forStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public ForStatementGreen Update(ForStatementBeginGreen forStatementBegin, BodyGreen body, ForStatementEndGreen forStatementEnd)
	    {
	        if (this.ForStatementBegin != forStatementBegin ||
				this.Body != body ||
				this.ForStatementEnd != forStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForStatement(forStatementBegin, body, forStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForStatementBeginGreen : GreenSyntaxNode
	{
	    internal static readonly ForStatementBeginGreen __Missing = new ForStatementBeginGreen();
	    private InternalSyntaxToken kFor;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ForInitStatementGreen forInitStatement;
	    private InternalSyntaxToken semi1;
	    private ExpressionListGreen endExpression;
	    private InternalSyntaxToken semi2;
	    private ExpressionListGreen stepExpression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public ForStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kFor, InternalSyntaxToken tOpenParenthesis, ForInitStatementGreen forInitStatement, InternalSyntaxToken semi1, ExpressionListGreen endExpression, InternalSyntaxToken semi2, ExpressionListGreen stepExpression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (kFor != null)
			{
				this.AdjustFlagsAndWidth(kFor);
				this.kFor = kFor;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (forInitStatement != null)
			{
				this.AdjustFlagsAndWidth(forInitStatement);
				this.forInitStatement = forInitStatement;
			}
			if (semi1 != null)
			{
				this.AdjustFlagsAndWidth(semi1);
				this.semi1 = semi1;
			}
			if (endExpression != null)
			{
				this.AdjustFlagsAndWidth(endExpression);
				this.endExpression = endExpression;
			}
			if (semi2 != null)
			{
				this.AdjustFlagsAndWidth(semi2);
				this.semi2 = semi2;
			}
			if (stepExpression != null)
			{
				this.AdjustFlagsAndWidth(stepExpression);
				this.stepExpression = stepExpression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public ForStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kFor, InternalSyntaxToken tOpenParenthesis, ForInitStatementGreen forInitStatement, InternalSyntaxToken semi1, ExpressionListGreen endExpression, InternalSyntaxToken semi2, ExpressionListGreen stepExpression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (kFor != null)
			{
				this.AdjustFlagsAndWidth(kFor);
				this.kFor = kFor;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (forInitStatement != null)
			{
				this.AdjustFlagsAndWidth(forInitStatement);
				this.forInitStatement = forInitStatement;
			}
			if (semi1 != null)
			{
				this.AdjustFlagsAndWidth(semi1);
				this.semi1 = semi1;
			}
			if (endExpression != null)
			{
				this.AdjustFlagsAndWidth(endExpression);
				this.endExpression = endExpression;
			}
			if (semi2 != null)
			{
				this.AdjustFlagsAndWidth(semi2);
				this.semi2 = semi2;
			}
			if (stepExpression != null)
			{
				this.AdjustFlagsAndWidth(stepExpression);
				this.stepExpression = stepExpression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private ForStatementBeginGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForStatementBegin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KFor { get { return this.kFor; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ForInitStatementGreen ForInitStatement { get { return this.forInitStatement; } }
	    public InternalSyntaxToken Semi1 { get { return this.semi1; } }
	    public ExpressionListGreen EndExpression { get { return this.endExpression; } }
	    public InternalSyntaxToken Semi2 { get { return this.semi2; } }
	    public ExpressionListGreen StepExpression { get { return this.stepExpression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ForStatementBeginSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kFor;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.forInitStatement;
	            case 3: return this.semi1;
	            case 4: return this.endExpression;
	            case 5: return this.semi2;
	            case 6: return this.stepExpression;
	            case 7: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitForStatementBeginGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitForStatementBeginGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForStatementBeginGreen(this.Kind, this.kFor, this.tOpenParenthesis, this.forInitStatement, this.semi1, this.endExpression, this.semi2, this.stepExpression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForStatementBeginGreen(this.Kind, this.kFor, this.tOpenParenthesis, this.forInitStatement, this.semi1, this.endExpression, this.semi2, this.stepExpression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public ForStatementBeginGreen Update(InternalSyntaxToken kFor, InternalSyntaxToken tOpenParenthesis, ForInitStatementGreen forInitStatement, InternalSyntaxToken semi1, ExpressionListGreen endExpression, InternalSyntaxToken semi2, ExpressionListGreen stepExpression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KFor != kFor ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ForInitStatement != forInitStatement ||
				this.Semi1 != semi1 ||
				this.EndExpression != endExpression ||
				this.Semi2 != semi2 ||
				this.StepExpression != stepExpression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForStatementBegin(kFor, tOpenParenthesis, forInitStatement, semi1, endExpression, semi2, stepExpression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForStatementBeginGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForStatementEndGreen : GreenSyntaxNode
	{
	    internal static readonly ForStatementEndGreen __Missing = new ForStatementEndGreen();
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken kFor;
	
	    public ForStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kFor)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kFor != null)
			{
				this.AdjustFlagsAndWidth(kFor);
				this.kFor = kFor;
			}
	    }
	
	    public ForStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kFor, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kFor != null)
			{
				this.AdjustFlagsAndWidth(kFor);
				this.kFor = kFor;
			}
	    }
	
		private ForStatementEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForStatementEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken KFor { get { return this.kFor; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ForStatementEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnd;
	            case 1: return this.kFor;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitForStatementEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitForStatementEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForStatementEndGreen(this.Kind, this.kEnd, this.kFor, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForStatementEndGreen(this.Kind, this.kEnd, this.kFor, this.GetDiagnostics(), annotations);
	    }
	
	    public ForStatementEndGreen Update(InternalSyntaxToken kEnd, InternalSyntaxToken kFor)
	    {
	        if (this.KEnd != kEnd ||
				this.KFor != kFor)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForStatementEnd(kEnd, kFor);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForStatementEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForInitStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ForInitStatementGreen __Missing = new ForInitStatementGreen();
	    private VariableDeclarationExpressionGreen variableDeclarationExpression;
	    private ExpressionListGreen expressionList;
	
	    public ForInitStatementGreen(TestLexerModeSyntaxKind kind, VariableDeclarationExpressionGreen variableDeclarationExpression, ExpressionListGreen expressionList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (variableDeclarationExpression != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationExpression);
				this.variableDeclarationExpression = variableDeclarationExpression;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
	    }
	
	    public ForInitStatementGreen(TestLexerModeSyntaxKind kind, VariableDeclarationExpressionGreen variableDeclarationExpression, ExpressionListGreen expressionList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (variableDeclarationExpression != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationExpression);
				this.variableDeclarationExpression = variableDeclarationExpression;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
	    }
	
		private ForInitStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForInitStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationExpressionGreen VariableDeclarationExpression { get { return this.variableDeclarationExpression; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ForInitStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclarationExpression;
	            case 1: return this.expressionList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitForInitStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitForInitStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForInitStatementGreen(this.Kind, this.variableDeclarationExpression, this.expressionList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForInitStatementGreen(this.Kind, this.variableDeclarationExpression, this.expressionList, this.GetDiagnostics(), annotations);
	    }
	
	    public ForInitStatementGreen Update(VariableDeclarationExpressionGreen variableDeclarationExpression)
	    {
	        if (this.variableDeclarationExpression != variableDeclarationExpression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForInitStatement(variableDeclarationExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForInitStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ForInitStatementGreen Update(ExpressionListGreen expressionList)
	    {
	        if (this.expressionList != expressionList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForInitStatement(expressionList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForInitStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WhileStatementGreen : GreenSyntaxNode
	{
	    internal static readonly WhileStatementGreen __Missing = new WhileStatementGreen();
	    private WhileStatementBeginGreen whileStatementBegin;
	    private BodyGreen body;
	    private WhileStatementEndGreen whileStatementEnd;
	
	    public WhileStatementGreen(TestLexerModeSyntaxKind kind, WhileStatementBeginGreen whileStatementBegin, BodyGreen body, WhileStatementEndGreen whileStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (whileStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(whileStatementBegin);
				this.whileStatementBegin = whileStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (whileStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(whileStatementEnd);
				this.whileStatementEnd = whileStatementEnd;
			}
	    }
	
	    public WhileStatementGreen(TestLexerModeSyntaxKind kind, WhileStatementBeginGreen whileStatementBegin, BodyGreen body, WhileStatementEndGreen whileStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (whileStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(whileStatementBegin);
				this.whileStatementBegin = whileStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (whileStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(whileStatementEnd);
				this.whileStatementEnd = whileStatementEnd;
			}
	    }
	
		private WhileStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public WhileStatementBeginGreen WhileStatementBegin { get { return this.whileStatementBegin; } }
	    public BodyGreen Body { get { return this.body; } }
	    public WhileStatementEndGreen WhileStatementEnd { get { return this.whileStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.WhileStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.whileStatementBegin;
	            case 1: return this.body;
	            case 2: return this.whileStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitWhileStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitWhileStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WhileStatementGreen(this.Kind, this.whileStatementBegin, this.body, this.whileStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WhileStatementGreen(this.Kind, this.whileStatementBegin, this.body, this.whileStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public WhileStatementGreen Update(WhileStatementBeginGreen whileStatementBegin, BodyGreen body, WhileStatementEndGreen whileStatementEnd)
	    {
	        if (this.WhileStatementBegin != whileStatementBegin ||
				this.Body != body ||
				this.WhileStatementEnd != whileStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileStatement(whileStatementBegin, body, whileStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WhileStatementBeginGreen : GreenSyntaxNode
	{
	    internal static readonly WhileStatementBeginGreen __Missing = new WhileStatementBeginGreen();
	    private InternalSyntaxToken kWhile;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public WhileStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kWhile, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kWhile != null)
			{
				this.AdjustFlagsAndWidth(kWhile);
				this.kWhile = kWhile;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public WhileStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kWhile, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kWhile != null)
			{
				this.AdjustFlagsAndWidth(kWhile);
				this.kWhile = kWhile;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private WhileStatementBeginGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileStatementBegin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KWhile { get { return this.kWhile; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.WhileStatementBeginSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kWhile;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.expression;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitWhileStatementBeginGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitWhileStatementBeginGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WhileStatementBeginGreen(this.Kind, this.kWhile, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WhileStatementBeginGreen(this.Kind, this.kWhile, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public WhileStatementBeginGreen Update(InternalSyntaxToken kWhile, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KWhile != kWhile ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileStatementBegin(kWhile, tOpenParenthesis, expression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileStatementBeginGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WhileStatementEndGreen : GreenSyntaxNode
	{
	    internal static readonly WhileStatementEndGreen __Missing = new WhileStatementEndGreen();
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken kWhile;
	
	    public WhileStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kWhile)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kWhile != null)
			{
				this.AdjustFlagsAndWidth(kWhile);
				this.kWhile = kWhile;
			}
	    }
	
	    public WhileStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kWhile, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kWhile != null)
			{
				this.AdjustFlagsAndWidth(kWhile);
				this.kWhile = kWhile;
			}
	    }
	
		private WhileStatementEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileStatementEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken KWhile { get { return this.kWhile; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.WhileStatementEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnd;
	            case 1: return this.kWhile;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitWhileStatementEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitWhileStatementEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WhileStatementEndGreen(this.Kind, this.kEnd, this.kWhile, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WhileStatementEndGreen(this.Kind, this.kEnd, this.kWhile, this.GetDiagnostics(), annotations);
	    }
	
	    public WhileStatementEndGreen Update(InternalSyntaxToken kEnd, InternalSyntaxToken kWhile)
	    {
	        if (this.KEnd != kEnd ||
				this.KWhile != kWhile)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileStatementEnd(kEnd, kWhile);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileStatementEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WhileRunExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly WhileRunExpressionGreen __Missing = new WhileRunExpressionGreen();
	    private SeparatorStatementGreen separatorStatement;
	
	    public WhileRunExpressionGreen(TestLexerModeSyntaxKind kind, SeparatorStatementGreen separatorStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (separatorStatement != null)
			{
				this.AdjustFlagsAndWidth(separatorStatement);
				this.separatorStatement = separatorStatement;
			}
	    }
	
	    public WhileRunExpressionGreen(TestLexerModeSyntaxKind kind, SeparatorStatementGreen separatorStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (separatorStatement != null)
			{
				this.AdjustFlagsAndWidth(separatorStatement);
				this.separatorStatement = separatorStatement;
			}
	    }
	
		private WhileRunExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileRunExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SeparatorStatementGreen SeparatorStatement { get { return this.separatorStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.WhileRunExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.separatorStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitWhileRunExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitWhileRunExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WhileRunExpressionGreen(this.Kind, this.separatorStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WhileRunExpressionGreen(this.Kind, this.separatorStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public WhileRunExpressionGreen Update(SeparatorStatementGreen separatorStatement)
	    {
	        if (this.SeparatorStatement != separatorStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileRunExpression(separatorStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileRunExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RepeatStatementGreen : GreenSyntaxNode
	{
	    internal static readonly RepeatStatementGreen __Missing = new RepeatStatementGreen();
	    private RepeatStatementBeginGreen repeatStatementBegin;
	    private BodyGreen body;
	    private RepeatStatementEndGreen repeatStatementEnd;
	
	    public RepeatStatementGreen(TestLexerModeSyntaxKind kind, RepeatStatementBeginGreen repeatStatementBegin, BodyGreen body, RepeatStatementEndGreen repeatStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (repeatStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementBegin);
				this.repeatStatementBegin = repeatStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (repeatStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementEnd);
				this.repeatStatementEnd = repeatStatementEnd;
			}
	    }
	
	    public RepeatStatementGreen(TestLexerModeSyntaxKind kind, RepeatStatementBeginGreen repeatStatementBegin, BodyGreen body, RepeatStatementEndGreen repeatStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (repeatStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementBegin);
				this.repeatStatementBegin = repeatStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (repeatStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementEnd);
				this.repeatStatementEnd = repeatStatementEnd;
			}
	    }
	
		private RepeatStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public RepeatStatementBeginGreen RepeatStatementBegin { get { return this.repeatStatementBegin; } }
	    public BodyGreen Body { get { return this.body; } }
	    public RepeatStatementEndGreen RepeatStatementEnd { get { return this.repeatStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RepeatStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.repeatStatementBegin;
	            case 1: return this.body;
	            case 2: return this.repeatStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRepeatStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRepeatStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RepeatStatementGreen(this.Kind, this.repeatStatementBegin, this.body, this.repeatStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RepeatStatementGreen(this.Kind, this.repeatStatementBegin, this.body, this.repeatStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public RepeatStatementGreen Update(RepeatStatementBeginGreen repeatStatementBegin, BodyGreen body, RepeatStatementEndGreen repeatStatementEnd)
	    {
	        if (this.RepeatStatementBegin != repeatStatementBegin ||
				this.Body != body ||
				this.RepeatStatementEnd != repeatStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatStatement(repeatStatementBegin, body, repeatStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RepeatStatementBeginGreen : GreenSyntaxNode
	{
	    internal static readonly RepeatStatementBeginGreen __Missing = new RepeatStatementBeginGreen();
	    private InternalSyntaxToken kRepeat;
	
	    public RepeatStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kRepeat)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kRepeat != null)
			{
				this.AdjustFlagsAndWidth(kRepeat);
				this.kRepeat = kRepeat;
			}
	    }
	
	    public RepeatStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kRepeat, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kRepeat != null)
			{
				this.AdjustFlagsAndWidth(kRepeat);
				this.kRepeat = kRepeat;
			}
	    }
	
		private RepeatStatementBeginGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatStatementBegin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRepeat { get { return this.kRepeat; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RepeatStatementBeginSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRepeat;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRepeatStatementBeginGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRepeatStatementBeginGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RepeatStatementBeginGreen(this.Kind, this.kRepeat, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RepeatStatementBeginGreen(this.Kind, this.kRepeat, this.GetDiagnostics(), annotations);
	    }
	
	    public RepeatStatementBeginGreen Update(InternalSyntaxToken kRepeat)
	    {
	        if (this.KRepeat != kRepeat)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatStatementBegin(kRepeat);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatStatementBeginGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RepeatStatementEndGreen : GreenSyntaxNode
	{
	    internal static readonly RepeatStatementEndGreen __Missing = new RepeatStatementEndGreen();
	    private InternalSyntaxToken kUntil;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public RepeatStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kUntil, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kUntil != null)
			{
				this.AdjustFlagsAndWidth(kUntil);
				this.kUntil = kUntil;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public RepeatStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kUntil, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kUntil != null)
			{
				this.AdjustFlagsAndWidth(kUntil);
				this.kUntil = kUntil;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private RepeatStatementEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatStatementEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KUntil { get { return this.kUntil; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RepeatStatementEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kUntil;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.expression;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRepeatStatementEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRepeatStatementEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RepeatStatementEndGreen(this.Kind, this.kUntil, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RepeatStatementEndGreen(this.Kind, this.kUntil, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public RepeatStatementEndGreen Update(InternalSyntaxToken kUntil, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KUntil != kUntil ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatStatementEnd(kUntil, tOpenParenthesis, expression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatStatementEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RepeatRunExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly RepeatRunExpressionGreen __Missing = new RepeatRunExpressionGreen();
	    private SeparatorStatementGreen separatorStatement;
	
	    public RepeatRunExpressionGreen(TestLexerModeSyntaxKind kind, SeparatorStatementGreen separatorStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (separatorStatement != null)
			{
				this.AdjustFlagsAndWidth(separatorStatement);
				this.separatorStatement = separatorStatement;
			}
	    }
	
	    public RepeatRunExpressionGreen(TestLexerModeSyntaxKind kind, SeparatorStatementGreen separatorStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (separatorStatement != null)
			{
				this.AdjustFlagsAndWidth(separatorStatement);
				this.separatorStatement = separatorStatement;
			}
	    }
	
		private RepeatRunExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatRunExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SeparatorStatementGreen SeparatorStatement { get { return this.separatorStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RepeatRunExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.separatorStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRepeatRunExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRepeatRunExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RepeatRunExpressionGreen(this.Kind, this.separatorStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RepeatRunExpressionGreen(this.Kind, this.separatorStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public RepeatRunExpressionGreen Update(SeparatorStatementGreen separatorStatement)
	    {
	        if (this.SeparatorStatement != separatorStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatRunExpression(separatorStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatRunExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopStatementGreen : GreenSyntaxNode
	{
	    internal static readonly LoopStatementGreen __Missing = new LoopStatementGreen();
	    private LoopStatementBeginGreen loopStatementBegin;
	    private BodyGreen body;
	    private LoopStatementEndGreen loopStatementEnd;
	
	    public LoopStatementGreen(TestLexerModeSyntaxKind kind, LoopStatementBeginGreen loopStatementBegin, BodyGreen body, LoopStatementEndGreen loopStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (loopStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(loopStatementBegin);
				this.loopStatementBegin = loopStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (loopStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(loopStatementEnd);
				this.loopStatementEnd = loopStatementEnd;
			}
	    }
	
	    public LoopStatementGreen(TestLexerModeSyntaxKind kind, LoopStatementBeginGreen loopStatementBegin, BodyGreen body, LoopStatementEndGreen loopStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (loopStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(loopStatementBegin);
				this.loopStatementBegin = loopStatementBegin;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
			if (loopStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(loopStatementEnd);
				this.loopStatementEnd = loopStatementEnd;
			}
	    }
	
		private LoopStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LoopStatementBeginGreen LoopStatementBegin { get { return this.loopStatementBegin; } }
	    public BodyGreen Body { get { return this.body; } }
	    public LoopStatementEndGreen LoopStatementEnd { get { return this.loopStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.loopStatementBegin;
	            case 1: return this.body;
	            case 2: return this.loopStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopStatementGreen(this.Kind, this.loopStatementBegin, this.body, this.loopStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopStatementGreen(this.Kind, this.loopStatementBegin, this.body, this.loopStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopStatementGreen Update(LoopStatementBeginGreen loopStatementBegin, BodyGreen body, LoopStatementEndGreen loopStatementEnd)
	    {
	        if (this.LoopStatementBegin != loopStatementBegin ||
				this.Body != body ||
				this.LoopStatementEnd != loopStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopStatement(loopStatementBegin, body, loopStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopStatementBeginGreen : GreenSyntaxNode
	{
	    internal static readonly LoopStatementBeginGreen __Missing = new LoopStatementBeginGreen();
	    private InternalSyntaxToken kLoop;
	    private InternalSyntaxToken tOpenParenthesis;
	    private LoopChainGreen loopChain;
	    private LoopWhereExpressionGreen loopWhereExpression;
	    private LoopRunExpressionGreen loopRunExpression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public LoopStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, LoopRunExpressionGreen loopRunExpression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kLoop != null)
			{
				this.AdjustFlagsAndWidth(kLoop);
				this.kLoop = kLoop;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (loopChain != null)
			{
				this.AdjustFlagsAndWidth(loopChain);
				this.loopChain = loopChain;
			}
			if (loopWhereExpression != null)
			{
				this.AdjustFlagsAndWidth(loopWhereExpression);
				this.loopWhereExpression = loopWhereExpression;
			}
			if (loopRunExpression != null)
			{
				this.AdjustFlagsAndWidth(loopRunExpression);
				this.loopRunExpression = loopRunExpression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public LoopStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, LoopRunExpressionGreen loopRunExpression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kLoop != null)
			{
				this.AdjustFlagsAndWidth(kLoop);
				this.kLoop = kLoop;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (loopChain != null)
			{
				this.AdjustFlagsAndWidth(loopChain);
				this.loopChain = loopChain;
			}
			if (loopWhereExpression != null)
			{
				this.AdjustFlagsAndWidth(loopWhereExpression);
				this.loopWhereExpression = loopWhereExpression;
			}
			if (loopRunExpression != null)
			{
				this.AdjustFlagsAndWidth(loopRunExpression);
				this.loopRunExpression = loopRunExpression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private LoopStatementBeginGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopStatementBegin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KLoop { get { return this.kLoop; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public LoopChainGreen LoopChain { get { return this.loopChain; } }
	    public LoopWhereExpressionGreen LoopWhereExpression { get { return this.loopWhereExpression; } }
	    public LoopRunExpressionGreen LoopRunExpression { get { return this.loopRunExpression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopStatementBeginSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kLoop;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.loopChain;
	            case 3: return this.loopWhereExpression;
	            case 4: return this.loopRunExpression;
	            case 5: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopStatementBeginGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopStatementBeginGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopStatementBeginGreen(this.Kind, this.kLoop, this.tOpenParenthesis, this.loopChain, this.loopWhereExpression, this.loopRunExpression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopStatementBeginGreen(this.Kind, this.kLoop, this.tOpenParenthesis, this.loopChain, this.loopWhereExpression, this.loopRunExpression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopStatementBeginGreen Update(InternalSyntaxToken kLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, LoopRunExpressionGreen loopRunExpression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KLoop != kLoop ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.LoopChain != loopChain ||
				this.LoopWhereExpression != loopWhereExpression ||
				this.LoopRunExpression != loopRunExpression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopStatementBegin(kLoop, tOpenParenthesis, loopChain, loopWhereExpression, loopRunExpression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopStatementBeginGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopStatementEndGreen : GreenSyntaxNode
	{
	    internal static readonly LoopStatementEndGreen __Missing = new LoopStatementEndGreen();
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken kLoop;
	
	    public LoopStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kLoop)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kLoop != null)
			{
				this.AdjustFlagsAndWidth(kLoop);
				this.kLoop = kLoop;
			}
	    }
	
	    public LoopStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kLoop, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kLoop != null)
			{
				this.AdjustFlagsAndWidth(kLoop);
				this.kLoop = kLoop;
			}
	    }
	
		private LoopStatementEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopStatementEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken KLoop { get { return this.kLoop; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopStatementEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnd;
	            case 1: return this.kLoop;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopStatementEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopStatementEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopStatementEndGreen(this.Kind, this.kEnd, this.kLoop, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopStatementEndGreen(this.Kind, this.kEnd, this.kLoop, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopStatementEndGreen Update(InternalSyntaxToken kEnd, InternalSyntaxToken kLoop)
	    {
	        if (this.KEnd != kEnd ||
				this.KLoop != kLoop)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopStatementEnd(kEnd, kLoop);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopStatementEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopChainGreen : GreenSyntaxNode
	{
	    internal static readonly LoopChainGreen __Missing = new LoopChainGreen();
	    private GreenNode loopChainItem;
	
	    public LoopChainGreen(TestLexerModeSyntaxKind kind, GreenNode loopChainItem)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (loopChainItem != null)
			{
				this.AdjustFlagsAndWidth(loopChainItem);
				this.loopChainItem = loopChainItem;
			}
	    }
	
	    public LoopChainGreen(TestLexerModeSyntaxKind kind, GreenNode loopChainItem, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (loopChainItem != null)
			{
				this.AdjustFlagsAndWidth(loopChainItem);
				this.loopChainItem = loopChainItem;
			}
	    }
	
		private LoopChainGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChain, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LoopChainItemGreen> LoopChainItem { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LoopChainItemGreen>(this.loopChainItem); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopChainSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.loopChainItem;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopChainGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopChainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopChainGreen(this.Kind, this.loopChainItem, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopChainGreen(this.Kind, this.loopChainItem, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopChainGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LoopChainItemGreen> loopChainItem)
	    {
	        if (this.LoopChainItem != loopChainItem)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChain(loopChainItem);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopChainItemGreen : GreenSyntaxNode
	{
	    internal static readonly LoopChainItemGreen __Missing = new LoopChainItemGreen();
	    private TypeReferenceGreen typeReference;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tColon;
	    private LoopChainExpressionGreen loopChainExpression;
	
	    public LoopChainItemGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tColon, LoopChainExpressionGreen loopChainExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (loopChainExpression != null)
			{
				this.AdjustFlagsAndWidth(loopChainExpression);
				this.loopChainExpression = loopChainExpression;
			}
	    }
	
	    public LoopChainItemGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tColon, LoopChainExpressionGreen loopChainExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (loopChainExpression != null)
			{
				this.AdjustFlagsAndWidth(loopChainExpression);
				this.loopChainExpression = loopChainExpression;
			}
	    }
	
		private LoopChainItemGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChainItem, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public LoopChainExpressionGreen LoopChainExpression { get { return this.loopChainExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopChainItemSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.identifier;
	            case 2: return this.tColon;
	            case 3: return this.loopChainExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopChainItemGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopChainItemGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopChainItemGreen(this.Kind, this.typeReference, this.identifier, this.tColon, this.loopChainExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopChainItemGreen(this.Kind, this.typeReference, this.identifier, this.tColon, this.loopChainExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopChainItemGreen Update(TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tColon, LoopChainExpressionGreen loopChainExpression)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier ||
				this.TColon != tColon ||
				this.LoopChainExpression != loopChainExpression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainItem(typeReference, identifier, tColon, loopChainExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainItemGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class LoopChainExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly LoopChainExpressionGreen __Missing = LoopChainTypeofExpressionGreen.__Missing;
	
	    public LoopChainExpressionGreen(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class LoopChainTypeofExpressionGreen : LoopChainExpressionGreen
	{
	    internal static new readonly LoopChainTypeofExpressionGreen __Missing = new LoopChainTypeofExpressionGreen();
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParenthesis;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public LoopChainTypeofExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public LoopChainTypeofExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private LoopChainTypeofExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChainTypeofExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopChainTypeofExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeof;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.typeReference;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopChainTypeofExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopChainTypeofExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopChainTypeofExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopChainTypeofExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopChainTypeofExpressionGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainTypeofExpression(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainTypeofExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopChainIdentifierExpressionGreen : LoopChainExpressionGreen
	{
	    internal static new readonly LoopChainIdentifierExpressionGreen __Missing = new LoopChainIdentifierExpressionGreen();
	    private IdentifierGreen identifier;
	    private TypeArgumentListGreen typeArgumentList;
	
	    public LoopChainIdentifierExpressionGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
	    public LoopChainIdentifierExpressionGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
		private LoopChainIdentifierExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChainIdentifierExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopChainIdentifierExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.typeArgumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopChainIdentifierExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopChainIdentifierExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopChainIdentifierExpressionGreen(this.Kind, this.identifier, this.typeArgumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopChainIdentifierExpressionGreen(this.Kind, this.identifier, this.typeArgumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopChainIdentifierExpressionGreen Update(IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	        if (this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainIdentifierExpression(identifier, typeArgumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainIdentifierExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopChainMemberAccessExpressionGreen : LoopChainExpressionGreen
	{
	    internal static new readonly LoopChainMemberAccessExpressionGreen __Missing = new LoopChainMemberAccessExpressionGreen();
	    private LoopChainExpressionGreen loopChainExpression;
	    private InternalSyntaxToken tDot;
	    private IdentifierGreen identifier;
	    private TypeArgumentListGreen typeArgumentList;
	
	    public LoopChainMemberAccessExpressionGreen(TestLexerModeSyntaxKind kind, LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (loopChainExpression != null)
			{
				this.AdjustFlagsAndWidth(loopChainExpression);
				this.loopChainExpression = loopChainExpression;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
	    public LoopChainMemberAccessExpressionGreen(TestLexerModeSyntaxKind kind, LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (loopChainExpression != null)
			{
				this.AdjustFlagsAndWidth(loopChainExpression);
				this.loopChainExpression = loopChainExpression;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
		private LoopChainMemberAccessExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChainMemberAccessExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LoopChainExpressionGreen LoopChainExpression { get { return this.loopChainExpression; } }
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopChainMemberAccessExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.loopChainExpression;
	            case 1: return this.tDot;
	            case 2: return this.identifier;
	            case 3: return this.typeArgumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopChainMemberAccessExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopChainMemberAccessExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopChainMemberAccessExpressionGreen(this.Kind, this.loopChainExpression, this.tDot, this.identifier, this.typeArgumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopChainMemberAccessExpressionGreen(this.Kind, this.loopChainExpression, this.tDot, this.identifier, this.typeArgumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopChainMemberAccessExpressionGreen Update(LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	        if (this.LoopChainExpression != loopChainExpression ||
				this.TDot != tDot ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainMemberAccessExpression(loopChainExpression, tDot, identifier, typeArgumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainMemberAccessExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopChainMethodCallExpressionGreen : LoopChainExpressionGreen
	{
	    internal static new readonly LoopChainMethodCallExpressionGreen __Missing = new LoopChainMethodCallExpressionGreen();
	    private LoopChainExpressionGreen loopChainExpression;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public LoopChainMethodCallExpressionGreen(TestLexerModeSyntaxKind kind, LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (loopChainExpression != null)
			{
				this.AdjustFlagsAndWidth(loopChainExpression);
				this.loopChainExpression = loopChainExpression;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public LoopChainMethodCallExpressionGreen(TestLexerModeSyntaxKind kind, LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (loopChainExpression != null)
			{
				this.AdjustFlagsAndWidth(loopChainExpression);
				this.loopChainExpression = loopChainExpression;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private LoopChainMethodCallExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChainMethodCallExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LoopChainExpressionGreen LoopChainExpression { get { return this.loopChainExpression; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopChainMethodCallExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.loopChainExpression;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.expressionList;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopChainMethodCallExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopChainMethodCallExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopChainMethodCallExpressionGreen(this.Kind, this.loopChainExpression, this.tOpenParenthesis, this.expressionList, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopChainMethodCallExpressionGreen(this.Kind, this.loopChainExpression, this.tOpenParenthesis, this.expressionList, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopChainMethodCallExpressionGreen Update(LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.LoopChainExpression != loopChainExpression ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ExpressionList != expressionList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainMethodCallExpression(loopChainExpression, tOpenParenthesis, expressionList, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainMethodCallExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopWhereExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly LoopWhereExpressionGreen __Missing = new LoopWhereExpressionGreen();
	    private InternalSyntaxToken kWhere;
	    private ExpressionGreen expression;
	
	    public LoopWhereExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kWhere, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kWhere != null)
			{
				this.AdjustFlagsAndWidth(kWhere);
				this.kWhere = kWhere;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public LoopWhereExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kWhere, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kWhere != null)
			{
				this.AdjustFlagsAndWidth(kWhere);
				this.kWhere = kWhere;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private LoopWhereExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopWhereExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KWhere { get { return this.kWhere; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopWhereExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kWhere;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopWhereExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopWhereExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopWhereExpressionGreen(this.Kind, this.kWhere, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopWhereExpressionGreen(this.Kind, this.kWhere, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopWhereExpressionGreen Update(InternalSyntaxToken kWhere, ExpressionGreen expression)
	    {
	        if (this.KWhere != kWhere ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopWhereExpression(kWhere, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopWhereExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopRunExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly LoopRunExpressionGreen __Missing = new LoopRunExpressionGreen();
	    private SeparatorStatementGreen separatorStatement;
	
	    public LoopRunExpressionGreen(TestLexerModeSyntaxKind kind, SeparatorStatementGreen separatorStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (separatorStatement != null)
			{
				this.AdjustFlagsAndWidth(separatorStatement);
				this.separatorStatement = separatorStatement;
			}
	    }
	
	    public LoopRunExpressionGreen(TestLexerModeSyntaxKind kind, SeparatorStatementGreen separatorStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (separatorStatement != null)
			{
				this.AdjustFlagsAndWidth(separatorStatement);
				this.separatorStatement = separatorStatement;
			}
	    }
	
		private LoopRunExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopRunExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SeparatorStatementGreen SeparatorStatement { get { return this.separatorStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LoopRunExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.separatorStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLoopRunExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLoopRunExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopRunExpressionGreen(this.Kind, this.separatorStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopRunExpressionGreen(this.Kind, this.separatorStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopRunExpressionGreen Update(SeparatorStatementGreen separatorStatement)
	    {
	        if (this.SeparatorStatement != separatorStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopRunExpression(separatorStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopRunExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SeparatorStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SeparatorStatementGreen __Missing = new SeparatorStatementGreen();
	    private InternalSyntaxToken tSemicolon;
	    private InternalSyntaxToken kSeparator;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public SeparatorStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tSemicolon, InternalSyntaxToken kSeparator, IdentifierGreen identifier, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (kSeparator != null)
			{
				this.AdjustFlagsAndWidth(kSeparator);
				this.kSeparator = kSeparator;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public SeparatorStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tSemicolon, InternalSyntaxToken kSeparator, IdentifierGreen identifier, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (kSeparator != null)
			{
				this.AdjustFlagsAndWidth(kSeparator);
				this.kSeparator = kSeparator;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
		private SeparatorStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SeparatorStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public InternalSyntaxToken KSeparator { get { return this.kSeparator; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SeparatorStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            case 1: return this.kSeparator;
	            case 2: return this.identifier;
	            case 3: return this.tAssign;
	            case 4: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSeparatorStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSeparatorStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SeparatorStatementGreen(this.Kind, this.tSemicolon, this.kSeparator, this.identifier, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SeparatorStatementGreen(this.Kind, this.tSemicolon, this.kSeparator, this.identifier, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public SeparatorStatementGreen Update(InternalSyntaxToken tSemicolon, InternalSyntaxToken kSeparator, IdentifierGreen identifier, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.TSemicolon != tSemicolon ||
				this.KSeparator != kSeparator ||
				this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SeparatorStatement(tSemicolon, kSeparator, identifier, tAssign, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SeparatorStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchStatementGreen __Missing = new SwitchStatementGreen();
	    private SwitchStatementBeginGreen switchStatementBegin;
	    private GreenNode switchBranchStatement;
	    private SwitchDefaultStatementGreen switchDefaultStatement;
	    private SwitchStatementEndGreen switchStatementEnd;
	
	    public SwitchStatementGreen(TestLexerModeSyntaxKind kind, SwitchStatementBeginGreen switchStatementBegin, GreenNode switchBranchStatement, SwitchDefaultStatementGreen switchDefaultStatement, SwitchStatementEndGreen switchStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (switchStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(switchStatementBegin);
				this.switchStatementBegin = switchStatementBegin;
			}
			if (switchBranchStatement != null)
			{
				this.AdjustFlagsAndWidth(switchBranchStatement);
				this.switchBranchStatement = switchBranchStatement;
			}
			if (switchDefaultStatement != null)
			{
				this.AdjustFlagsAndWidth(switchDefaultStatement);
				this.switchDefaultStatement = switchDefaultStatement;
			}
			if (switchStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(switchStatementEnd);
				this.switchStatementEnd = switchStatementEnd;
			}
	    }
	
	    public SwitchStatementGreen(TestLexerModeSyntaxKind kind, SwitchStatementBeginGreen switchStatementBegin, GreenNode switchBranchStatement, SwitchDefaultStatementGreen switchDefaultStatement, SwitchStatementEndGreen switchStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (switchStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(switchStatementBegin);
				this.switchStatementBegin = switchStatementBegin;
			}
			if (switchBranchStatement != null)
			{
				this.AdjustFlagsAndWidth(switchBranchStatement);
				this.switchBranchStatement = switchBranchStatement;
			}
			if (switchDefaultStatement != null)
			{
				this.AdjustFlagsAndWidth(switchDefaultStatement);
				this.switchDefaultStatement = switchDefaultStatement;
			}
			if (switchStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(switchStatementEnd);
				this.switchStatementEnd = switchStatementEnd;
			}
	    }
	
		private SwitchStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SwitchStatementBeginGreen SwitchStatementBegin { get { return this.switchStatementBegin; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchBranchStatementGreen> SwitchBranchStatement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchBranchStatementGreen>(this.switchBranchStatement); } }
	    public SwitchDefaultStatementGreen SwitchDefaultStatement { get { return this.switchDefaultStatement; } }
	    public SwitchStatementEndGreen SwitchStatementEnd { get { return this.switchStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.switchStatementBegin;
	            case 1: return this.switchBranchStatement;
	            case 2: return this.switchDefaultStatement;
	            case 3: return this.switchStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchStatementGreen(this.Kind, this.switchStatementBegin, this.switchBranchStatement, this.switchDefaultStatement, this.switchStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchStatementGreen(this.Kind, this.switchStatementBegin, this.switchBranchStatement, this.switchDefaultStatement, this.switchStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchStatementGreen Update(SwitchStatementBeginGreen switchStatementBegin, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchBranchStatementGreen> switchBranchStatement, SwitchDefaultStatementGreen switchDefaultStatement, SwitchStatementEndGreen switchStatementEnd)
	    {
	        if (this.SwitchStatementBegin != switchStatementBegin ||
				this.SwitchBranchStatement != switchBranchStatement ||
				this.SwitchDefaultStatement != switchDefaultStatement ||
				this.SwitchStatementEnd != switchStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchStatement(switchStatementBegin, switchBranchStatement, switchDefaultStatement, switchStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchStatementBeginGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchStatementBeginGreen __Missing = new SwitchStatementBeginGreen();
	    private InternalSyntaxToken kSwitch;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public SwitchStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kSwitch, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kSwitch != null)
			{
				this.AdjustFlagsAndWidth(kSwitch);
				this.kSwitch = kSwitch;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public SwitchStatementBeginGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kSwitch, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kSwitch != null)
			{
				this.AdjustFlagsAndWidth(kSwitch);
				this.kSwitch = kSwitch;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private SwitchStatementBeginGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchStatementBegin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KSwitch { get { return this.kSwitch; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchStatementBeginSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSwitch;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.expression;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchStatementBeginGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchStatementBeginGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchStatementBeginGreen(this.Kind, this.kSwitch, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchStatementBeginGreen(this.Kind, this.kSwitch, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchStatementBeginGreen Update(InternalSyntaxToken kSwitch, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KSwitch != kSwitch ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchStatementBegin(kSwitch, tOpenParenthesis, expression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchStatementBeginGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchStatementEndGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchStatementEndGreen __Missing = new SwitchStatementEndGreen();
	    private InternalSyntaxToken kEnd;
	    private InternalSyntaxToken kSwitch;
	
	    public SwitchStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kSwitch)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kSwitch != null)
			{
				this.AdjustFlagsAndWidth(kSwitch);
				this.kSwitch = kSwitch;
			}
	    }
	
	    public SwitchStatementEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kEnd, InternalSyntaxToken kSwitch, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (kSwitch != null)
			{
				this.AdjustFlagsAndWidth(kSwitch);
				this.kSwitch = kSwitch;
			}
	    }
	
		private SwitchStatementEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchStatementEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public InternalSyntaxToken KSwitch { get { return this.kSwitch; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchStatementEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnd;
	            case 1: return this.kSwitch;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchStatementEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchStatementEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchStatementEndGreen(this.Kind, this.kEnd, this.kSwitch, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchStatementEndGreen(this.Kind, this.kEnd, this.kSwitch, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchStatementEndGreen Update(InternalSyntaxToken kEnd, InternalSyntaxToken kSwitch)
	    {
	        if (this.KEnd != kEnd ||
				this.KSwitch != kSwitch)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchStatementEnd(kEnd, kSwitch);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchStatementEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchBranchStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchBranchStatementGreen __Missing = new SwitchBranchStatementGreen();
	    private SwitchBranchHeadStatementGreen switchBranchHeadStatement;
	    private BodyGreen body;
	
	    public SwitchBranchStatementGreen(TestLexerModeSyntaxKind kind, SwitchBranchHeadStatementGreen switchBranchHeadStatement, BodyGreen body)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (switchBranchHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchBranchHeadStatement);
				this.switchBranchHeadStatement = switchBranchHeadStatement;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
	    public SwitchBranchStatementGreen(TestLexerModeSyntaxKind kind, SwitchBranchHeadStatementGreen switchBranchHeadStatement, BodyGreen body, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (switchBranchHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchBranchHeadStatement);
				this.switchBranchHeadStatement = switchBranchHeadStatement;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
		private SwitchBranchStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchBranchStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SwitchBranchHeadStatementGreen SwitchBranchHeadStatement { get { return this.switchBranchHeadStatement; } }
	    public BodyGreen Body { get { return this.body; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchBranchStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.switchBranchHeadStatement;
	            case 1: return this.body;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchBranchStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchBranchStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchBranchStatementGreen(this.Kind, this.switchBranchHeadStatement, this.body, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchBranchStatementGreen(this.Kind, this.switchBranchHeadStatement, this.body, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchBranchStatementGreen Update(SwitchBranchHeadStatementGreen switchBranchHeadStatement, BodyGreen body)
	    {
	        if (this.SwitchBranchHeadStatement != switchBranchHeadStatement ||
				this.Body != body)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchBranchStatement(switchBranchHeadStatement, body);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchBranchStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchBranchHeadStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchBranchHeadStatementGreen __Missing = new SwitchBranchHeadStatementGreen();
	    private SwitchCaseOrTypeIsHeadStatementsGreen switchCaseOrTypeIsHeadStatements;
	    private SwitchTypeAsHeadStatementGreen switchTypeAsHeadStatement;
	
	    public SwitchBranchHeadStatementGreen(TestLexerModeSyntaxKind kind, SwitchCaseOrTypeIsHeadStatementsGreen switchCaseOrTypeIsHeadStatements, SwitchTypeAsHeadStatementGreen switchTypeAsHeadStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (switchCaseOrTypeIsHeadStatements != null)
			{
				this.AdjustFlagsAndWidth(switchCaseOrTypeIsHeadStatements);
				this.switchCaseOrTypeIsHeadStatements = switchCaseOrTypeIsHeadStatements;
			}
			if (switchTypeAsHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchTypeAsHeadStatement);
				this.switchTypeAsHeadStatement = switchTypeAsHeadStatement;
			}
	    }
	
	    public SwitchBranchHeadStatementGreen(TestLexerModeSyntaxKind kind, SwitchCaseOrTypeIsHeadStatementsGreen switchCaseOrTypeIsHeadStatements, SwitchTypeAsHeadStatementGreen switchTypeAsHeadStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (switchCaseOrTypeIsHeadStatements != null)
			{
				this.AdjustFlagsAndWidth(switchCaseOrTypeIsHeadStatements);
				this.switchCaseOrTypeIsHeadStatements = switchCaseOrTypeIsHeadStatements;
			}
			if (switchTypeAsHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchTypeAsHeadStatement);
				this.switchTypeAsHeadStatement = switchTypeAsHeadStatement;
			}
	    }
	
		private SwitchBranchHeadStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchBranchHeadStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SwitchCaseOrTypeIsHeadStatementsGreen SwitchCaseOrTypeIsHeadStatements { get { return this.switchCaseOrTypeIsHeadStatements; } }
	    public SwitchTypeAsHeadStatementGreen SwitchTypeAsHeadStatement { get { return this.switchTypeAsHeadStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchBranchHeadStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.switchCaseOrTypeIsHeadStatements;
	            case 1: return this.switchTypeAsHeadStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchBranchHeadStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchBranchHeadStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchBranchHeadStatementGreen(this.Kind, this.switchCaseOrTypeIsHeadStatements, this.switchTypeAsHeadStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchBranchHeadStatementGreen(this.Kind, this.switchCaseOrTypeIsHeadStatements, this.switchTypeAsHeadStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchBranchHeadStatementGreen Update(SwitchCaseOrTypeIsHeadStatementsGreen switchCaseOrTypeIsHeadStatements)
	    {
	        if (this.switchCaseOrTypeIsHeadStatements != switchCaseOrTypeIsHeadStatements)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchBranchHeadStatement(switchCaseOrTypeIsHeadStatements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchBranchHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public SwitchBranchHeadStatementGreen Update(SwitchTypeAsHeadStatementGreen switchTypeAsHeadStatement)
	    {
	        if (this.switchTypeAsHeadStatement != switchTypeAsHeadStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchBranchHeadStatement(switchTypeAsHeadStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchBranchHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchCaseOrTypeIsHeadStatementsGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchCaseOrTypeIsHeadStatementsGreen __Missing = new SwitchCaseOrTypeIsHeadStatementsGreen();
	    private GreenNode switchCaseOrTypeIsHeadStatement;
	
	    public SwitchCaseOrTypeIsHeadStatementsGreen(TestLexerModeSyntaxKind kind, GreenNode switchCaseOrTypeIsHeadStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (switchCaseOrTypeIsHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchCaseOrTypeIsHeadStatement);
				this.switchCaseOrTypeIsHeadStatement = switchCaseOrTypeIsHeadStatement;
			}
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementsGreen(TestLexerModeSyntaxKind kind, GreenNode switchCaseOrTypeIsHeadStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (switchCaseOrTypeIsHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchCaseOrTypeIsHeadStatement);
				this.switchCaseOrTypeIsHeadStatement = switchCaseOrTypeIsHeadStatement;
			}
	    }
	
		private SwitchCaseOrTypeIsHeadStatementsGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatements, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchCaseOrTypeIsHeadStatementGreen> SwitchCaseOrTypeIsHeadStatement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchCaseOrTypeIsHeadStatementGreen>(this.switchCaseOrTypeIsHeadStatement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchCaseOrTypeIsHeadStatementsSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.switchCaseOrTypeIsHeadStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchCaseOrTypeIsHeadStatementsGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchCaseOrTypeIsHeadStatementsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchCaseOrTypeIsHeadStatementsGreen(this.Kind, this.switchCaseOrTypeIsHeadStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchCaseOrTypeIsHeadStatementsGreen(this.Kind, this.switchCaseOrTypeIsHeadStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchCaseOrTypeIsHeadStatementGreen> switchCaseOrTypeIsHeadStatement)
	    {
	        if (this.SwitchCaseOrTypeIsHeadStatement != switchCaseOrTypeIsHeadStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseOrTypeIsHeadStatements(switchCaseOrTypeIsHeadStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseOrTypeIsHeadStatementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchCaseOrTypeIsHeadStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchCaseOrTypeIsHeadStatementGreen __Missing = new SwitchCaseOrTypeIsHeadStatementGreen();
	    private SwitchCaseHeadStatementGreen switchCaseHeadStatement;
	    private SwitchTypeIsHeadStatementGreen switchTypeIsHeadStatement;
	
	    public SwitchCaseOrTypeIsHeadStatementGreen(TestLexerModeSyntaxKind kind, SwitchCaseHeadStatementGreen switchCaseHeadStatement, SwitchTypeIsHeadStatementGreen switchTypeIsHeadStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (switchCaseHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchCaseHeadStatement);
				this.switchCaseHeadStatement = switchCaseHeadStatement;
			}
			if (switchTypeIsHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchTypeIsHeadStatement);
				this.switchTypeIsHeadStatement = switchTypeIsHeadStatement;
			}
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementGreen(TestLexerModeSyntaxKind kind, SwitchCaseHeadStatementGreen switchCaseHeadStatement, SwitchTypeIsHeadStatementGreen switchTypeIsHeadStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (switchCaseHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchCaseHeadStatement);
				this.switchCaseHeadStatement = switchCaseHeadStatement;
			}
			if (switchTypeIsHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchTypeIsHeadStatement);
				this.switchTypeIsHeadStatement = switchTypeIsHeadStatement;
			}
	    }
	
		private SwitchCaseOrTypeIsHeadStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SwitchCaseHeadStatementGreen SwitchCaseHeadStatement { get { return this.switchCaseHeadStatement; } }
	    public SwitchTypeIsHeadStatementGreen SwitchTypeIsHeadStatement { get { return this.switchTypeIsHeadStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchCaseOrTypeIsHeadStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.switchCaseHeadStatement;
	            case 1: return this.switchTypeIsHeadStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchCaseOrTypeIsHeadStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchCaseOrTypeIsHeadStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchCaseOrTypeIsHeadStatementGreen(this.Kind, this.switchCaseHeadStatement, this.switchTypeIsHeadStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchCaseOrTypeIsHeadStatementGreen(this.Kind, this.switchCaseHeadStatement, this.switchTypeIsHeadStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementGreen Update(SwitchCaseHeadStatementGreen switchCaseHeadStatement)
	    {
	        if (this.switchCaseHeadStatement != switchCaseHeadStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseOrTypeIsHeadStatement(switchCaseHeadStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseOrTypeIsHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementGreen Update(SwitchTypeIsHeadStatementGreen switchTypeIsHeadStatement)
	    {
	        if (this.switchTypeIsHeadStatement != switchTypeIsHeadStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseOrTypeIsHeadStatement(switchTypeIsHeadStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseOrTypeIsHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchCaseHeadStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchCaseHeadStatementGreen __Missing = new SwitchCaseHeadStatementGreen();
	    private InternalSyntaxToken kCase;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tColon;
	
	    public SwitchCaseHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kCase, ExpressionListGreen expressionList, InternalSyntaxToken tColon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
	    public SwitchCaseHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kCase, ExpressionListGreen expressionList, InternalSyntaxToken tColon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
		private SwitchCaseHeadStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseHeadStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCase { get { return this.kCase; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchCaseHeadStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCase;
	            case 1: return this.expressionList;
	            case 2: return this.tColon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchCaseHeadStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchCaseHeadStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchCaseHeadStatementGreen(this.Kind, this.kCase, this.expressionList, this.tColon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchCaseHeadStatementGreen(this.Kind, this.kCase, this.expressionList, this.tColon, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchCaseHeadStatementGreen Update(InternalSyntaxToken kCase, ExpressionListGreen expressionList, InternalSyntaxToken tColon)
	    {
	        if (this.KCase != kCase ||
				this.ExpressionList != expressionList ||
				this.TColon != tColon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseHeadStatement(kCase, expressionList, tColon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchTypeIsHeadStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchTypeIsHeadStatementGreen __Missing = new SwitchTypeIsHeadStatementGreen();
	    private InternalSyntaxToken kType;
	    private InternalSyntaxToken kIs;
	    private TypeReferenceListGreen typeReferenceList;
	    private InternalSyntaxToken tColon;
	
	    public SwitchTypeIsHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kType, InternalSyntaxToken kIs, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tColon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kType != null)
			{
				this.AdjustFlagsAndWidth(kType);
				this.kType = kType;
			}
			if (kIs != null)
			{
				this.AdjustFlagsAndWidth(kIs);
				this.kIs = kIs;
			}
			if (typeReferenceList != null)
			{
				this.AdjustFlagsAndWidth(typeReferenceList);
				this.typeReferenceList = typeReferenceList;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
	    public SwitchTypeIsHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kType, InternalSyntaxToken kIs, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tColon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kType != null)
			{
				this.AdjustFlagsAndWidth(kType);
				this.kType = kType;
			}
			if (kIs != null)
			{
				this.AdjustFlagsAndWidth(kIs);
				this.kIs = kIs;
			}
			if (typeReferenceList != null)
			{
				this.AdjustFlagsAndWidth(typeReferenceList);
				this.typeReferenceList = typeReferenceList;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
		private SwitchTypeIsHeadStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchTypeIsHeadStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KType { get { return this.kType; } }
	    public InternalSyntaxToken KIs { get { return this.kIs; } }
	    public TypeReferenceListGreen TypeReferenceList { get { return this.typeReferenceList; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchTypeIsHeadStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kType;
	            case 1: return this.kIs;
	            case 2: return this.typeReferenceList;
	            case 3: return this.tColon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchTypeIsHeadStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchTypeIsHeadStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchTypeIsHeadStatementGreen(this.Kind, this.kType, this.kIs, this.typeReferenceList, this.tColon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchTypeIsHeadStatementGreen(this.Kind, this.kType, this.kIs, this.typeReferenceList, this.tColon, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchTypeIsHeadStatementGreen Update(InternalSyntaxToken kType, InternalSyntaxToken kIs, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tColon)
	    {
	        if (this.KType != kType ||
				this.KIs != kIs ||
				this.TypeReferenceList != typeReferenceList ||
				this.TColon != tColon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchTypeIsHeadStatement(kType, kIs, typeReferenceList, tColon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchTypeIsHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchTypeAsHeadStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchTypeAsHeadStatementGreen __Missing = new SwitchTypeAsHeadStatementGreen();
	    private InternalSyntaxToken kType;
	    private InternalSyntaxToken kAs;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tColon;
	
	    public SwitchTypeAsHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kType, InternalSyntaxToken kAs, TypeReferenceGreen typeReference, InternalSyntaxToken tColon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kType != null)
			{
				this.AdjustFlagsAndWidth(kType);
				this.kType = kType;
			}
			if (kAs != null)
			{
				this.AdjustFlagsAndWidth(kAs);
				this.kAs = kAs;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
	    public SwitchTypeAsHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kType, InternalSyntaxToken kAs, TypeReferenceGreen typeReference, InternalSyntaxToken tColon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kType != null)
			{
				this.AdjustFlagsAndWidth(kType);
				this.kType = kType;
			}
			if (kAs != null)
			{
				this.AdjustFlagsAndWidth(kAs);
				this.kAs = kAs;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
		private SwitchTypeAsHeadStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchTypeAsHeadStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KType { get { return this.kType; } }
	    public InternalSyntaxToken KAs { get { return this.kAs; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchTypeAsHeadStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kType;
	            case 1: return this.kAs;
	            case 2: return this.typeReference;
	            case 3: return this.tColon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchTypeAsHeadStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchTypeAsHeadStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchTypeAsHeadStatementGreen(this.Kind, this.kType, this.kAs, this.typeReference, this.tColon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchTypeAsHeadStatementGreen(this.Kind, this.kType, this.kAs, this.typeReference, this.tColon, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchTypeAsHeadStatementGreen Update(InternalSyntaxToken kType, InternalSyntaxToken kAs, TypeReferenceGreen typeReference, InternalSyntaxToken tColon)
	    {
	        if (this.KType != kType ||
				this.KAs != kAs ||
				this.TypeReference != typeReference ||
				this.TColon != tColon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchTypeAsHeadStatement(kType, kAs, typeReference, tColon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchTypeAsHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchDefaultStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchDefaultStatementGreen __Missing = new SwitchDefaultStatementGreen();
	    private SwitchDefaultHeadStatementGreen switchDefaultHeadStatement;
	    private BodyGreen body;
	
	    public SwitchDefaultStatementGreen(TestLexerModeSyntaxKind kind, SwitchDefaultHeadStatementGreen switchDefaultHeadStatement, BodyGreen body)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (switchDefaultHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchDefaultHeadStatement);
				this.switchDefaultHeadStatement = switchDefaultHeadStatement;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
	    public SwitchDefaultStatementGreen(TestLexerModeSyntaxKind kind, SwitchDefaultHeadStatementGreen switchDefaultHeadStatement, BodyGreen body, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (switchDefaultHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchDefaultHeadStatement);
				this.switchDefaultHeadStatement = switchDefaultHeadStatement;
			}
			if (body != null)
			{
				this.AdjustFlagsAndWidth(body);
				this.body = body;
			}
	    }
	
		private SwitchDefaultStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchDefaultStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SwitchDefaultHeadStatementGreen SwitchDefaultHeadStatement { get { return this.switchDefaultHeadStatement; } }
	    public BodyGreen Body { get { return this.body; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchDefaultStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.switchDefaultHeadStatement;
	            case 1: return this.body;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchDefaultStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchDefaultStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchDefaultStatementGreen(this.Kind, this.switchDefaultHeadStatement, this.body, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchDefaultStatementGreen(this.Kind, this.switchDefaultHeadStatement, this.body, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchDefaultStatementGreen Update(SwitchDefaultHeadStatementGreen switchDefaultHeadStatement, BodyGreen body)
	    {
	        if (this.SwitchDefaultHeadStatement != switchDefaultHeadStatement ||
				this.Body != body)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchDefaultStatement(switchDefaultHeadStatement, body);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchDefaultStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SwitchDefaultHeadStatementGreen : GreenSyntaxNode
	{
	    internal static readonly SwitchDefaultHeadStatementGreen __Missing = new SwitchDefaultHeadStatementGreen();
	    private InternalSyntaxToken kDefault;
	    private InternalSyntaxToken tColon;
	
	    public SwitchDefaultHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kDefault, InternalSyntaxToken tColon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kDefault != null)
			{
				this.AdjustFlagsAndWidth(kDefault);
				this.kDefault = kDefault;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
	    public SwitchDefaultHeadStatementGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kDefault, InternalSyntaxToken tColon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kDefault != null)
			{
				this.AdjustFlagsAndWidth(kDefault);
				this.kDefault = kDefault;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
	    }
	
		private SwitchDefaultHeadStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchDefaultHeadStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDefault { get { return this.kDefault; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SwitchDefaultHeadStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDefault;
	            case 1: return this.tColon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSwitchDefaultHeadStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSwitchDefaultHeadStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SwitchDefaultHeadStatementGreen(this.Kind, this.kDefault, this.tColon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SwitchDefaultHeadStatementGreen(this.Kind, this.kDefault, this.tColon, this.GetDiagnostics(), annotations);
	    }
	
	    public SwitchDefaultHeadStatementGreen Update(InternalSyntaxToken kDefault, InternalSyntaxToken tColon)
	    {
	        if (this.KDefault != kDefault ||
				this.TColon != tColon)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchDefaultHeadStatement(kDefault, tColon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchDefaultHeadStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateDeclarationGreen __Missing = new TemplateDeclarationGreen();
	    private TemplateSignatureGreen templateSignature;
	    private TemplateBodyGreen templateBody;
	    private InternalSyntaxToken kEndTemplate;
	
	    public TemplateDeclarationGreen(TestLexerModeSyntaxKind kind, TemplateSignatureGreen templateSignature, TemplateBodyGreen templateBody, InternalSyntaxToken kEndTemplate)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (templateSignature != null)
			{
				this.AdjustFlagsAndWidth(templateSignature);
				this.templateSignature = templateSignature;
			}
			if (templateBody != null)
			{
				this.AdjustFlagsAndWidth(templateBody);
				this.templateBody = templateBody;
			}
			if (kEndTemplate != null)
			{
				this.AdjustFlagsAndWidth(kEndTemplate);
				this.kEndTemplate = kEndTemplate;
			}
	    }
	
	    public TemplateDeclarationGreen(TestLexerModeSyntaxKind kind, TemplateSignatureGreen templateSignature, TemplateBodyGreen templateBody, InternalSyntaxToken kEndTemplate, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (templateSignature != null)
			{
				this.AdjustFlagsAndWidth(templateSignature);
				this.templateSignature = templateSignature;
			}
			if (templateBody != null)
			{
				this.AdjustFlagsAndWidth(templateBody);
				this.templateBody = templateBody;
			}
			if (kEndTemplate != null)
			{
				this.AdjustFlagsAndWidth(kEndTemplate);
				this.kEndTemplate = kEndTemplate;
			}
	    }
	
		private TemplateDeclarationGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TemplateSignatureGreen TemplateSignature { get { return this.templateSignature; } }
	    public TemplateBodyGreen TemplateBody { get { return this.templateBody; } }
	    public InternalSyntaxToken KEndTemplate { get { return this.kEndTemplate; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateDeclarationSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.templateSignature;
	            case 1: return this.templateBody;
	            case 2: return this.kEndTemplate;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateDeclarationGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateDeclarationGreen(this.Kind, this.templateSignature, this.templateBody, this.kEndTemplate, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateDeclarationGreen(this.Kind, this.templateSignature, this.templateBody, this.kEndTemplate, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateDeclarationGreen Update(TemplateSignatureGreen templateSignature, TemplateBodyGreen templateBody, InternalSyntaxToken kEndTemplate)
	    {
	        if (this.TemplateSignature != templateSignature ||
				this.TemplateBody != templateBody ||
				this.KEndTemplate != kEndTemplate)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateDeclaration(templateSignature, templateBody, kEndTemplate);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateSignatureGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateSignatureGreen __Missing = new TemplateSignatureGreen();
	    private InternalSyntaxToken kTemplate;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ParamListGreen paramList;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public TemplateSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTemplate, IdentifierGreen identifier, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kTemplate != null)
			{
				this.AdjustFlagsAndWidth(kTemplate);
				this.kTemplate = kTemplate;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (paramList != null)
			{
				this.AdjustFlagsAndWidth(paramList);
				this.paramList = paramList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public TemplateSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTemplate, IdentifierGreen identifier, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kTemplate != null)
			{
				this.AdjustFlagsAndWidth(kTemplate);
				this.kTemplate = kTemplate;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (paramList != null)
			{
				this.AdjustFlagsAndWidth(paramList);
				this.paramList = paramList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private TemplateSignatureGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTemplate { get { return this.kTemplate; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ParamListGreen ParamList { get { return this.paramList; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateSignatureSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTemplate;
	            case 1: return this.identifier;
	            case 2: return this.tOpenParenthesis;
	            case 3: return this.paramList;
	            case 4: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateSignatureGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateSignatureGreen(this.Kind, this.kTemplate, this.identifier, this.tOpenParenthesis, this.paramList, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateSignatureGreen(this.Kind, this.kTemplate, this.identifier, this.tOpenParenthesis, this.paramList, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateSignatureGreen Update(InternalSyntaxToken kTemplate, IdentifierGreen identifier, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KTemplate != kTemplate ||
				this.Identifier != identifier ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ParamList != paramList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateSignature(kTemplate, identifier, tOpenParenthesis, paramList, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateBodyGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateBodyGreen __Missing = new TemplateBodyGreen();
	    private GreenNode templateContentLine;
	
	    public TemplateBodyGreen(TestLexerModeSyntaxKind kind, GreenNode templateContentLine)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (templateContentLine != null)
			{
				this.AdjustFlagsAndWidth(templateContentLine);
				this.templateContentLine = templateContentLine;
			}
	    }
	
	    public TemplateBodyGreen(TestLexerModeSyntaxKind kind, GreenNode templateContentLine, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (templateContentLine != null)
			{
				this.AdjustFlagsAndWidth(templateContentLine);
				this.templateContentLine = templateContentLine;
			}
	    }
	
		private TemplateBodyGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentLineGreen> TemplateContentLine { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentLineGreen>(this.templateContentLine); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateBodySyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.templateContentLine;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateBodyGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateBodyGreen(this.Kind, this.templateContentLine, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateBodyGreen(this.Kind, this.templateContentLine, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateBodyGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentLineGreen> templateContentLine)
	    {
	        if (this.TemplateContentLine != templateContentLine)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateBody(templateContentLine);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateContentLineGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateContentLineGreen __Missing = new TemplateContentLineGreen();
	    private GreenNode templateContent;
	    private TemplateLineEndGreen templateLineEnd;
	
	    public TemplateContentLineGreen(TestLexerModeSyntaxKind kind, GreenNode templateContent, TemplateLineEndGreen templateLineEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (templateContent != null)
			{
				this.AdjustFlagsAndWidth(templateContent);
				this.templateContent = templateContent;
			}
			if (templateLineEnd != null)
			{
				this.AdjustFlagsAndWidth(templateLineEnd);
				this.templateLineEnd = templateLineEnd;
			}
	    }
	
	    public TemplateContentLineGreen(TestLexerModeSyntaxKind kind, GreenNode templateContent, TemplateLineEndGreen templateLineEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (templateContent != null)
			{
				this.AdjustFlagsAndWidth(templateContent);
				this.templateContent = templateContent;
			}
			if (templateLineEnd != null)
			{
				this.AdjustFlagsAndWidth(templateLineEnd);
				this.templateLineEnd = templateLineEnd;
			}
	    }
	
		private TemplateContentLineGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateContentLine, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentGreen> TemplateContent { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentGreen>(this.templateContent); } }
	    public TemplateLineEndGreen TemplateLineEnd { get { return this.templateLineEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateContentLineSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.templateContent;
	            case 1: return this.templateLineEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateContentLineGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateContentLineGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateContentLineGreen(this.Kind, this.templateContent, this.templateLineEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateContentLineGreen(this.Kind, this.templateContent, this.templateLineEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateContentLineGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentGreen> templateContent, TemplateLineEndGreen templateLineEnd)
	    {
	        if (this.TemplateContent != templateContent ||
				this.TemplateLineEnd != templateLineEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateContentLine(templateContent, templateLineEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateContentLineGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateContentGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateContentGreen __Missing = new TemplateContentGreen();
	    private TemplateOutputGreen templateOutput;
	    private TemplateStatementStartEndGreen templateStatementStartEnd;
	
	    public TemplateContentGreen(TestLexerModeSyntaxKind kind, TemplateOutputGreen templateOutput, TemplateStatementStartEndGreen templateStatementStartEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (templateOutput != null)
			{
				this.AdjustFlagsAndWidth(templateOutput);
				this.templateOutput = templateOutput;
			}
			if (templateStatementStartEnd != null)
			{
				this.AdjustFlagsAndWidth(templateStatementStartEnd);
				this.templateStatementStartEnd = templateStatementStartEnd;
			}
	    }
	
	    public TemplateContentGreen(TestLexerModeSyntaxKind kind, TemplateOutputGreen templateOutput, TemplateStatementStartEndGreen templateStatementStartEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (templateOutput != null)
			{
				this.AdjustFlagsAndWidth(templateOutput);
				this.templateOutput = templateOutput;
			}
			if (templateStatementStartEnd != null)
			{
				this.AdjustFlagsAndWidth(templateStatementStartEnd);
				this.templateStatementStartEnd = templateStatementStartEnd;
			}
	    }
	
		private TemplateContentGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateContent, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TemplateOutputGreen TemplateOutput { get { return this.templateOutput; } }
	    public TemplateStatementStartEndGreen TemplateStatementStartEnd { get { return this.templateStatementStartEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateContentSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.templateOutput;
	            case 1: return this.templateStatementStartEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateContentGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateContentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateContentGreen(this.Kind, this.templateOutput, this.templateStatementStartEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateContentGreen(this.Kind, this.templateOutput, this.templateStatementStartEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateContentGreen Update(TemplateOutputGreen templateOutput)
	    {
	        if (this.templateOutput != templateOutput)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateContent(templateOutput);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateContentGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateContentGreen Update(TemplateStatementStartEndGreen templateStatementStartEnd)
	    {
	        if (this.templateStatementStartEnd != templateStatementStartEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateContent(templateStatementStartEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateContentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateOutputGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateOutputGreen __Missing = new TemplateOutputGreen();
	    private InternalSyntaxToken lTemplateOutput;
	
	    public TemplateOutputGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lTemplateOutput)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lTemplateOutput != null)
			{
				this.AdjustFlagsAndWidth(lTemplateOutput);
				this.lTemplateOutput = lTemplateOutput;
			}
	    }
	
	    public TemplateOutputGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lTemplateOutput, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lTemplateOutput != null)
			{
				this.AdjustFlagsAndWidth(lTemplateOutput);
				this.lTemplateOutput = lTemplateOutput;
			}
	    }
	
		private TemplateOutputGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateOutput, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LTemplateOutput { get { return this.lTemplateOutput; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateOutputSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lTemplateOutput;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateOutputGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateOutputGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateOutputGreen(this.Kind, this.lTemplateOutput, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateOutputGreen(this.Kind, this.lTemplateOutput, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateOutputGreen Update(InternalSyntaxToken lTemplateOutput)
	    {
	        if (this.LTemplateOutput != lTemplateOutput)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateOutput(lTemplateOutput);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateOutputGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateLineEndGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateLineEndGreen __Missing = new TemplateLineEndGreen();
	    private InternalSyntaxToken templateLineEnd;
	
	    public TemplateLineEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken templateLineEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (templateLineEnd != null)
			{
				this.AdjustFlagsAndWidth(templateLineEnd);
				this.templateLineEnd = templateLineEnd;
			}
	    }
	
	    public TemplateLineEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken templateLineEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (templateLineEnd != null)
			{
				this.AdjustFlagsAndWidth(templateLineEnd);
				this.templateLineEnd = templateLineEnd;
			}
	    }
	
		private TemplateLineEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateLineEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TemplateLineEnd { get { return this.templateLineEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateLineEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.templateLineEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateLineEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateLineEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateLineEndGreen(this.Kind, this.templateLineEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateLineEndGreen(this.Kind, this.templateLineEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateLineEndGreen Update(InternalSyntaxToken templateLineEnd)
	    {
	        if (this.TemplateLineEnd != templateLineEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateLineEnd(templateLineEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateLineEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateStatementStartEndGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateStatementStartEndGreen __Missing = new TemplateStatementStartEndGreen();
	    private InternalSyntaxToken tTemplateStatementStart;
	    private TemplateStatementGreen templateStatement;
	    private InternalSyntaxToken tTemplateStatementEnd;
	
	    public TemplateStatementStartEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tTemplateStatementStart, TemplateStatementGreen templateStatement, InternalSyntaxToken tTemplateStatementEnd)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tTemplateStatementStart != null)
			{
				this.AdjustFlagsAndWidth(tTemplateStatementStart);
				this.tTemplateStatementStart = tTemplateStatementStart;
			}
			if (templateStatement != null)
			{
				this.AdjustFlagsAndWidth(templateStatement);
				this.templateStatement = templateStatement;
			}
			if (tTemplateStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(tTemplateStatementEnd);
				this.tTemplateStatementEnd = tTemplateStatementEnd;
			}
	    }
	
	    public TemplateStatementStartEndGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tTemplateStatementStart, TemplateStatementGreen templateStatement, InternalSyntaxToken tTemplateStatementEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tTemplateStatementStart != null)
			{
				this.AdjustFlagsAndWidth(tTemplateStatementStart);
				this.tTemplateStatementStart = tTemplateStatementStart;
			}
			if (templateStatement != null)
			{
				this.AdjustFlagsAndWidth(templateStatement);
				this.templateStatement = templateStatement;
			}
			if (tTemplateStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(tTemplateStatementEnd);
				this.tTemplateStatementEnd = tTemplateStatementEnd;
			}
	    }
	
		private TemplateStatementStartEndGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateStatementStartEnd, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TTemplateStatementStart { get { return this.tTemplateStatementStart; } }
	    public TemplateStatementGreen TemplateStatement { get { return this.templateStatement; } }
	    public InternalSyntaxToken TTemplateStatementEnd { get { return this.tTemplateStatementEnd; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateStatementStartEndSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTemplateStatementStart;
	            case 1: return this.templateStatement;
	            case 2: return this.tTemplateStatementEnd;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateStatementStartEndGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateStatementStartEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateStatementStartEndGreen(this.Kind, this.tTemplateStatementStart, this.templateStatement, this.tTemplateStatementEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateStatementStartEndGreen(this.Kind, this.tTemplateStatementStart, this.templateStatement, this.tTemplateStatementEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateStatementStartEndGreen Update(InternalSyntaxToken tTemplateStatementStart, TemplateStatementGreen templateStatement, InternalSyntaxToken tTemplateStatementEnd)
	    {
	        if (this.TTemplateStatementStart != tTemplateStatementStart ||
				this.TemplateStatement != templateStatement ||
				this.TTemplateStatementEnd != tTemplateStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatementStartEnd(tTemplateStatementStart, templateStatement, tTemplateStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementStartEndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TemplateStatementGreen : GreenSyntaxNode
	{
	    internal static readonly TemplateStatementGreen __Missing = new TemplateStatementGreen();
	    private VoidStatementGreen voidStatement;
	    private VariableDeclarationStatementGreen variableDeclarationStatement;
	    private ExpressionStatementGreen expressionStatement;
	    private IfStatementBeginGreen ifStatementBegin;
	    private ElseIfStatementGreen elseIfStatement;
	    private IfStatementElseGreen ifStatementElse;
	    private IfStatementEndGreen ifStatementEnd;
	    private ForStatementBeginGreen forStatementBegin;
	    private ForStatementEndGreen forStatementEnd;
	    private WhileStatementBeginGreen whileStatementBegin;
	    private WhileStatementEndGreen whileStatementEnd;
	    private RepeatStatementBeginGreen repeatStatementBegin;
	    private RepeatStatementEndGreen repeatStatementEnd;
	    private LoopStatementBeginGreen loopStatementBegin;
	    private LoopStatementEndGreen loopStatementEnd;
	    private SwitchStatementBeginGreen switchStatementBegin;
	    private SwitchStatementEndGreen switchStatementEnd;
	    private SwitchBranchHeadStatementGreen switchBranchHeadStatement;
	    private SwitchDefaultHeadStatementGreen switchDefaultHeadStatement;
	
	    public TemplateStatementGreen(TestLexerModeSyntaxKind kind, VoidStatementGreen voidStatement, VariableDeclarationStatementGreen variableDeclarationStatement, ExpressionStatementGreen expressionStatement, IfStatementBeginGreen ifStatementBegin, ElseIfStatementGreen elseIfStatement, IfStatementElseGreen ifStatementElse, IfStatementEndGreen ifStatementEnd, ForStatementBeginGreen forStatementBegin, ForStatementEndGreen forStatementEnd, WhileStatementBeginGreen whileStatementBegin, WhileStatementEndGreen whileStatementEnd, RepeatStatementBeginGreen repeatStatementBegin, RepeatStatementEndGreen repeatStatementEnd, LoopStatementBeginGreen loopStatementBegin, LoopStatementEndGreen loopStatementEnd, SwitchStatementBeginGreen switchStatementBegin, SwitchStatementEndGreen switchStatementEnd, SwitchBranchHeadStatementGreen switchBranchHeadStatement, SwitchDefaultHeadStatementGreen switchDefaultHeadStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 19;
			if (voidStatement != null)
			{
				this.AdjustFlagsAndWidth(voidStatement);
				this.voidStatement = voidStatement;
			}
			if (variableDeclarationStatement != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationStatement);
				this.variableDeclarationStatement = variableDeclarationStatement;
			}
			if (expressionStatement != null)
			{
				this.AdjustFlagsAndWidth(expressionStatement);
				this.expressionStatement = expressionStatement;
			}
			if (ifStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(ifStatementBegin);
				this.ifStatementBegin = ifStatementBegin;
			}
			if (elseIfStatement != null)
			{
				this.AdjustFlagsAndWidth(elseIfStatement);
				this.elseIfStatement = elseIfStatement;
			}
			if (ifStatementElse != null)
			{
				this.AdjustFlagsAndWidth(ifStatementElse);
				this.ifStatementElse = ifStatementElse;
			}
			if (ifStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(ifStatementEnd);
				this.ifStatementEnd = ifStatementEnd;
			}
			if (forStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(forStatementBegin);
				this.forStatementBegin = forStatementBegin;
			}
			if (forStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(forStatementEnd);
				this.forStatementEnd = forStatementEnd;
			}
			if (whileStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(whileStatementBegin);
				this.whileStatementBegin = whileStatementBegin;
			}
			if (whileStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(whileStatementEnd);
				this.whileStatementEnd = whileStatementEnd;
			}
			if (repeatStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementBegin);
				this.repeatStatementBegin = repeatStatementBegin;
			}
			if (repeatStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementEnd);
				this.repeatStatementEnd = repeatStatementEnd;
			}
			if (loopStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(loopStatementBegin);
				this.loopStatementBegin = loopStatementBegin;
			}
			if (loopStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(loopStatementEnd);
				this.loopStatementEnd = loopStatementEnd;
			}
			if (switchStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(switchStatementBegin);
				this.switchStatementBegin = switchStatementBegin;
			}
			if (switchStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(switchStatementEnd);
				this.switchStatementEnd = switchStatementEnd;
			}
			if (switchBranchHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchBranchHeadStatement);
				this.switchBranchHeadStatement = switchBranchHeadStatement;
			}
			if (switchDefaultHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchDefaultHeadStatement);
				this.switchDefaultHeadStatement = switchDefaultHeadStatement;
			}
	    }
	
	    public TemplateStatementGreen(TestLexerModeSyntaxKind kind, VoidStatementGreen voidStatement, VariableDeclarationStatementGreen variableDeclarationStatement, ExpressionStatementGreen expressionStatement, IfStatementBeginGreen ifStatementBegin, ElseIfStatementGreen elseIfStatement, IfStatementElseGreen ifStatementElse, IfStatementEndGreen ifStatementEnd, ForStatementBeginGreen forStatementBegin, ForStatementEndGreen forStatementEnd, WhileStatementBeginGreen whileStatementBegin, WhileStatementEndGreen whileStatementEnd, RepeatStatementBeginGreen repeatStatementBegin, RepeatStatementEndGreen repeatStatementEnd, LoopStatementBeginGreen loopStatementBegin, LoopStatementEndGreen loopStatementEnd, SwitchStatementBeginGreen switchStatementBegin, SwitchStatementEndGreen switchStatementEnd, SwitchBranchHeadStatementGreen switchBranchHeadStatement, SwitchDefaultHeadStatementGreen switchDefaultHeadStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 19;
			if (voidStatement != null)
			{
				this.AdjustFlagsAndWidth(voidStatement);
				this.voidStatement = voidStatement;
			}
			if (variableDeclarationStatement != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationStatement);
				this.variableDeclarationStatement = variableDeclarationStatement;
			}
			if (expressionStatement != null)
			{
				this.AdjustFlagsAndWidth(expressionStatement);
				this.expressionStatement = expressionStatement;
			}
			if (ifStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(ifStatementBegin);
				this.ifStatementBegin = ifStatementBegin;
			}
			if (elseIfStatement != null)
			{
				this.AdjustFlagsAndWidth(elseIfStatement);
				this.elseIfStatement = elseIfStatement;
			}
			if (ifStatementElse != null)
			{
				this.AdjustFlagsAndWidth(ifStatementElse);
				this.ifStatementElse = ifStatementElse;
			}
			if (ifStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(ifStatementEnd);
				this.ifStatementEnd = ifStatementEnd;
			}
			if (forStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(forStatementBegin);
				this.forStatementBegin = forStatementBegin;
			}
			if (forStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(forStatementEnd);
				this.forStatementEnd = forStatementEnd;
			}
			if (whileStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(whileStatementBegin);
				this.whileStatementBegin = whileStatementBegin;
			}
			if (whileStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(whileStatementEnd);
				this.whileStatementEnd = whileStatementEnd;
			}
			if (repeatStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementBegin);
				this.repeatStatementBegin = repeatStatementBegin;
			}
			if (repeatStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(repeatStatementEnd);
				this.repeatStatementEnd = repeatStatementEnd;
			}
			if (loopStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(loopStatementBegin);
				this.loopStatementBegin = loopStatementBegin;
			}
			if (loopStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(loopStatementEnd);
				this.loopStatementEnd = loopStatementEnd;
			}
			if (switchStatementBegin != null)
			{
				this.AdjustFlagsAndWidth(switchStatementBegin);
				this.switchStatementBegin = switchStatementBegin;
			}
			if (switchStatementEnd != null)
			{
				this.AdjustFlagsAndWidth(switchStatementEnd);
				this.switchStatementEnd = switchStatementEnd;
			}
			if (switchBranchHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchBranchHeadStatement);
				this.switchBranchHeadStatement = switchBranchHeadStatement;
			}
			if (switchDefaultHeadStatement != null)
			{
				this.AdjustFlagsAndWidth(switchDefaultHeadStatement);
				this.switchDefaultHeadStatement = switchDefaultHeadStatement;
			}
	    }
	
		private TemplateStatementGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VoidStatementGreen VoidStatement { get { return this.voidStatement; } }
	    public VariableDeclarationStatementGreen VariableDeclarationStatement { get { return this.variableDeclarationStatement; } }
	    public ExpressionStatementGreen ExpressionStatement { get { return this.expressionStatement; } }
	    public IfStatementBeginGreen IfStatementBegin { get { return this.ifStatementBegin; } }
	    public ElseIfStatementGreen ElseIfStatement { get { return this.elseIfStatement; } }
	    public IfStatementElseGreen IfStatementElse { get { return this.ifStatementElse; } }
	    public IfStatementEndGreen IfStatementEnd { get { return this.ifStatementEnd; } }
	    public ForStatementBeginGreen ForStatementBegin { get { return this.forStatementBegin; } }
	    public ForStatementEndGreen ForStatementEnd { get { return this.forStatementEnd; } }
	    public WhileStatementBeginGreen WhileStatementBegin { get { return this.whileStatementBegin; } }
	    public WhileStatementEndGreen WhileStatementEnd { get { return this.whileStatementEnd; } }
	    public RepeatStatementBeginGreen RepeatStatementBegin { get { return this.repeatStatementBegin; } }
	    public RepeatStatementEndGreen RepeatStatementEnd { get { return this.repeatStatementEnd; } }
	    public LoopStatementBeginGreen LoopStatementBegin { get { return this.loopStatementBegin; } }
	    public LoopStatementEndGreen LoopStatementEnd { get { return this.loopStatementEnd; } }
	    public SwitchStatementBeginGreen SwitchStatementBegin { get { return this.switchStatementBegin; } }
	    public SwitchStatementEndGreen SwitchStatementEnd { get { return this.switchStatementEnd; } }
	    public SwitchBranchHeadStatementGreen SwitchBranchHeadStatement { get { return this.switchBranchHeadStatement; } }
	    public SwitchDefaultHeadStatementGreen SwitchDefaultHeadStatement { get { return this.switchDefaultHeadStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TemplateStatementSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.voidStatement;
	            case 1: return this.variableDeclarationStatement;
	            case 2: return this.expressionStatement;
	            case 3: return this.ifStatementBegin;
	            case 4: return this.elseIfStatement;
	            case 5: return this.ifStatementElse;
	            case 6: return this.ifStatementEnd;
	            case 7: return this.forStatementBegin;
	            case 8: return this.forStatementEnd;
	            case 9: return this.whileStatementBegin;
	            case 10: return this.whileStatementEnd;
	            case 11: return this.repeatStatementBegin;
	            case 12: return this.repeatStatementEnd;
	            case 13: return this.loopStatementBegin;
	            case 14: return this.loopStatementEnd;
	            case 15: return this.switchStatementBegin;
	            case 16: return this.switchStatementEnd;
	            case 17: return this.switchBranchHeadStatement;
	            case 18: return this.switchDefaultHeadStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTemplateStatementGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTemplateStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TemplateStatementGreen(this.Kind, this.voidStatement, this.variableDeclarationStatement, this.expressionStatement, this.ifStatementBegin, this.elseIfStatement, this.ifStatementElse, this.ifStatementEnd, this.forStatementBegin, this.forStatementEnd, this.whileStatementBegin, this.whileStatementEnd, this.repeatStatementBegin, this.repeatStatementEnd, this.loopStatementBegin, this.loopStatementEnd, this.switchStatementBegin, this.switchStatementEnd, this.switchBranchHeadStatement, this.switchDefaultHeadStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TemplateStatementGreen(this.Kind, this.voidStatement, this.variableDeclarationStatement, this.expressionStatement, this.ifStatementBegin, this.elseIfStatement, this.ifStatementElse, this.ifStatementEnd, this.forStatementBegin, this.forStatementEnd, this.whileStatementBegin, this.whileStatementEnd, this.repeatStatementBegin, this.repeatStatementEnd, this.loopStatementBegin, this.loopStatementEnd, this.switchStatementBegin, this.switchStatementEnd, this.switchBranchHeadStatement, this.switchDefaultHeadStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public TemplateStatementGreen Update(VoidStatementGreen voidStatement)
	    {
	        if (this.voidStatement != voidStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(voidStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(VariableDeclarationStatementGreen variableDeclarationStatement)
	    {
	        if (this.variableDeclarationStatement != variableDeclarationStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(variableDeclarationStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(ExpressionStatementGreen expressionStatement)
	    {
	        if (this.expressionStatement != expressionStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(expressionStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(IfStatementBeginGreen ifStatementBegin)
	    {
	        if (this.ifStatementBegin != ifStatementBegin)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(ifStatementBegin);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(ElseIfStatementGreen elseIfStatement)
	    {
	        if (this.elseIfStatement != elseIfStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(elseIfStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(IfStatementElseGreen ifStatementElse)
	    {
	        if (this.ifStatementElse != ifStatementElse)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(ifStatementElse);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(IfStatementEndGreen ifStatementEnd)
	    {
	        if (this.ifStatementEnd != ifStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(ifStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(ForStatementBeginGreen forStatementBegin)
	    {
	        if (this.forStatementBegin != forStatementBegin)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(forStatementBegin);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(ForStatementEndGreen forStatementEnd)
	    {
	        if (this.forStatementEnd != forStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(forStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(WhileStatementBeginGreen whileStatementBegin)
	    {
	        if (this.whileStatementBegin != whileStatementBegin)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(whileStatementBegin);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(WhileStatementEndGreen whileStatementEnd)
	    {
	        if (this.whileStatementEnd != whileStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(whileStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(RepeatStatementBeginGreen repeatStatementBegin)
	    {
	        if (this.repeatStatementBegin != repeatStatementBegin)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(repeatStatementBegin);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(RepeatStatementEndGreen repeatStatementEnd)
	    {
	        if (this.repeatStatementEnd != repeatStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(repeatStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(LoopStatementBeginGreen loopStatementBegin)
	    {
	        if (this.loopStatementBegin != loopStatementBegin)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(loopStatementBegin);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(LoopStatementEndGreen loopStatementEnd)
	    {
	        if (this.loopStatementEnd != loopStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(loopStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(SwitchStatementBeginGreen switchStatementBegin)
	    {
	        if (this.switchStatementBegin != switchStatementBegin)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(switchStatementBegin);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(SwitchStatementEndGreen switchStatementEnd)
	    {
	        if (this.switchStatementEnd != switchStatementEnd)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(switchStatementEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(SwitchBranchHeadStatementGreen switchBranchHeadStatement)
	    {
	        if (this.switchBranchHeadStatement != switchBranchHeadStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(switchBranchHeadStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementGreen Update(SwitchDefaultHeadStatementGreen switchDefaultHeadStatement)
	    {
	        if (this.switchDefaultHeadStatement != switchDefaultHeadStatement)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement(switchDefaultHeadStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeArgumentListGreen : GreenSyntaxNode
	{
	    internal static readonly TypeArgumentListGreen __Missing = new TypeArgumentListGreen();
	    private InternalSyntaxToken tLessThan;
	    private TypeReferenceListGreen typeReferenceList;
	    private InternalSyntaxToken tGreaterThan;
	
	    public TypeArgumentListGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tLessThan, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (typeReferenceList != null)
			{
				this.AdjustFlagsAndWidth(typeReferenceList);
				this.typeReferenceList = typeReferenceList;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
	    public TypeArgumentListGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tLessThan, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (typeReferenceList != null)
			{
				this.AdjustFlagsAndWidth(typeReferenceList);
				this.typeReferenceList = typeReferenceList;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
		private TypeArgumentListGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeArgumentList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TLessThan { get { return this.tLessThan; } }
	    public TypeReferenceListGreen TypeReferenceList { get { return this.typeReferenceList; } }
	    public InternalSyntaxToken TGreaterThan { get { return this.tGreaterThan; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypeArgumentListSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tLessThan;
	            case 1: return this.typeReferenceList;
	            case 2: return this.tGreaterThan;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypeArgumentListGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypeArgumentListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeArgumentListGreen(this.Kind, this.tLessThan, this.typeReferenceList, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeArgumentListGreen(this.Kind, this.tLessThan, this.typeReferenceList, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeArgumentListGreen Update(InternalSyntaxToken tLessThan, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.TLessThan != tLessThan ||
				this.TypeReferenceList != typeReferenceList ||
				this.TGreaterThan != tGreaterThan)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeArgumentList(tLessThan, typeReferenceList, tGreaterThan);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeArgumentListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PredefinedTypeGreen : GreenSyntaxNode
	{
	    internal static readonly PredefinedTypeGreen __Missing = new PredefinedTypeGreen();
	    private InternalSyntaxToken predefinedType;
	
	    public PredefinedTypeGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken predefinedType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (predefinedType != null)
			{
				this.AdjustFlagsAndWidth(predefinedType);
				this.predefinedType = predefinedType;
			}
	    }
	
	    public PredefinedTypeGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken predefinedType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (predefinedType != null)
			{
				this.AdjustFlagsAndWidth(predefinedType);
				this.predefinedType = predefinedType;
			}
	    }
	
		private PredefinedTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.PredefinedType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken PredefinedType { get { return this.predefinedType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.PredefinedTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.predefinedType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitPredefinedTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitPredefinedTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PredefinedTypeGreen(this.Kind, this.predefinedType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PredefinedTypeGreen(this.Kind, this.predefinedType, this.GetDiagnostics(), annotations);
	    }
	
	    public PredefinedTypeGreen Update(InternalSyntaxToken predefinedType)
	    {
	        if (this.PredefinedType != predefinedType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.PredefinedType(predefinedType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PredefinedTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeReferenceListGreen : GreenSyntaxNode
	{
	    internal static readonly TypeReferenceListGreen __Missing = new TypeReferenceListGreen();
	    private GreenNode typeReference;
	
	    public TypeReferenceListGreen(TestLexerModeSyntaxKind kind, GreenNode typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypeReferenceListGreen(TestLexerModeSyntaxKind kind, GreenNode typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private TypeReferenceListGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeReferenceList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen> TypeReference { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen>(this.typeReference); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypeReferenceListSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceListGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypeReferenceListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceListGreen(this.Kind, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceListGreen(this.Kind, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen> typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReferenceList(typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly TypeReferenceGreen __Missing = new TypeReferenceGreen();
	    private ArrayTypeGreen arrayType;
	    private NullableTypeGreen nullableType;
	    private GenericTypeGreen genericType;
	    private SimpleTypeGreen simpleType;
	
	    public TypeReferenceGreen(TestLexerModeSyntaxKind kind, ArrayTypeGreen arrayType, NullableTypeGreen nullableType, GenericTypeGreen genericType, SimpleTypeGreen simpleType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
	    public TypeReferenceGreen(TestLexerModeSyntaxKind kind, ArrayTypeGreen arrayType, NullableTypeGreen nullableType, GenericTypeGreen genericType, SimpleTypeGreen simpleType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
		private TypeReferenceGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArrayTypeGreen ArrayType { get { return this.arrayType; } }
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public GenericTypeGreen GenericType { get { return this.genericType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypeReferenceSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arrayType;
	            case 1: return this.nullableType;
	            case 2: return this.genericType;
	            case 3: return this.simpleType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.arrayType, this.nullableType, this.genericType, this.simpleType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.arrayType, this.nullableType, this.genericType, this.simpleType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(ArrayTypeGreen arrayType)
	    {
	        if (this.arrayType != arrayType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference(arrayType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceGreen)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceGreen Update(NullableTypeGreen nullableType)
	    {
	        if (this.nullableType != nullableType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference(nullableType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceGreen)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceGreen Update(GenericTypeGreen genericType)
	    {
	        if (this.genericType != genericType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference(genericType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceGreen)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceGreen Update(SimpleTypeGreen simpleType)
	    {
	        if (this.simpleType != simpleType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ArrayTypeGreen __Missing = new ArrayTypeGreen();
	    private ArrayItemTypeGreen arrayItemType;
	    private RankSpecifiersGreen rankSpecifiers;
	
	    public ArrayTypeGreen(TestLexerModeSyntaxKind kind, ArrayItemTypeGreen arrayItemType, RankSpecifiersGreen rankSpecifiers)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (arrayItemType != null)
			{
				this.AdjustFlagsAndWidth(arrayItemType);
				this.arrayItemType = arrayItemType;
			}
			if (rankSpecifiers != null)
			{
				this.AdjustFlagsAndWidth(rankSpecifiers);
				this.rankSpecifiers = rankSpecifiers;
			}
	    }
	
	    public ArrayTypeGreen(TestLexerModeSyntaxKind kind, ArrayItemTypeGreen arrayItemType, RankSpecifiersGreen rankSpecifiers, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (arrayItemType != null)
			{
				this.AdjustFlagsAndWidth(arrayItemType);
				this.arrayItemType = arrayItemType;
			}
			if (rankSpecifiers != null)
			{
				this.AdjustFlagsAndWidth(rankSpecifiers);
				this.rankSpecifiers = rankSpecifiers;
			}
	    }
	
		private ArrayTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArrayItemTypeGreen ArrayItemType { get { return this.arrayItemType; } }
	    public RankSpecifiersGreen RankSpecifiers { get { return this.rankSpecifiers; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ArrayTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arrayItemType;
	            case 1: return this.rankSpecifiers;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitArrayTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrayTypeGreen(this.Kind, this.arrayItemType, this.rankSpecifiers, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrayTypeGreen(this.Kind, this.arrayItemType, this.rankSpecifiers, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrayTypeGreen Update(ArrayItemTypeGreen arrayItemType, RankSpecifiersGreen rankSpecifiers)
	    {
	        if (this.ArrayItemType != arrayItemType ||
				this.RankSpecifiers != rankSpecifiers)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayType(arrayItemType, rankSpecifiers);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrayItemTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ArrayItemTypeGreen __Missing = new ArrayItemTypeGreen();
	    private NullableTypeGreen nullableType;
	    private GenericTypeGreen genericType;
	    private SimpleTypeGreen simpleType;
	
	    public ArrayItemTypeGreen(TestLexerModeSyntaxKind kind, NullableTypeGreen nullableType, GenericTypeGreen genericType, SimpleTypeGreen simpleType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
	    public ArrayItemTypeGreen(TestLexerModeSyntaxKind kind, NullableTypeGreen nullableType, GenericTypeGreen genericType, SimpleTypeGreen simpleType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
		private ArrayItemTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ArrayItemType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public GenericTypeGreen GenericType { get { return this.genericType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ArrayItemTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nullableType;
	            case 1: return this.genericType;
	            case 2: return this.simpleType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitArrayItemTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitArrayItemTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrayItemTypeGreen(this.Kind, this.nullableType, this.genericType, this.simpleType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrayItemTypeGreen(this.Kind, this.nullableType, this.genericType, this.simpleType, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrayItemTypeGreen Update(NullableTypeGreen nullableType)
	    {
	        if (this.nullableType != nullableType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayItemType(nullableType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayItemTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public ArrayItemTypeGreen Update(GenericTypeGreen genericType)
	    {
	        if (this.genericType != genericType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayItemType(genericType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayItemTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public ArrayItemTypeGreen Update(SimpleTypeGreen simpleType)
	    {
	        if (this.simpleType != simpleType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayItemType(simpleType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayItemTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NullableTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NullableTypeGreen __Missing = new NullableTypeGreen();
	    private NullableItemTypeGreen nullableItemType;
	    private InternalSyntaxToken tQuestion;
	
	    public NullableTypeGreen(TestLexerModeSyntaxKind kind, NullableItemTypeGreen nullableItemType, InternalSyntaxToken tQuestion)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (nullableItemType != null)
			{
				this.AdjustFlagsAndWidth(nullableItemType);
				this.nullableItemType = nullableItemType;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
	    public NullableTypeGreen(TestLexerModeSyntaxKind kind, NullableItemTypeGreen nullableItemType, InternalSyntaxToken tQuestion, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (nullableItemType != null)
			{
				this.AdjustFlagsAndWidth(nullableItemType);
				this.nullableItemType = nullableItemType;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
		private NullableTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullableType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NullableItemTypeGreen NullableItemType { get { return this.nullableItemType; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.NullableTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nullableItemType;
	            case 1: return this.tQuestion;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableTypeGreen(this.Kind, this.nullableItemType, this.tQuestion, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableTypeGreen(this.Kind, this.nullableItemType, this.tQuestion, this.GetDiagnostics(), annotations);
	    }
	
	    public NullableTypeGreen Update(NullableItemTypeGreen nullableItemType, InternalSyntaxToken tQuestion)
	    {
	        if (this.NullableItemType != nullableItemType ||
				this.TQuestion != tQuestion)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullableType(nullableItemType, tQuestion);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NullableItemTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NullableItemTypeGreen __Missing = new NullableItemTypeGreen();
	    private GenericTypeGreen genericType;
	    private SimpleTypeGreen simpleType;
	
	    public NullableItemTypeGreen(TestLexerModeSyntaxKind kind, GenericTypeGreen genericType, SimpleTypeGreen simpleType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
	    public NullableItemTypeGreen(TestLexerModeSyntaxKind kind, GenericTypeGreen genericType, SimpleTypeGreen simpleType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
		private NullableItemTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullableItemType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public GenericTypeGreen GenericType { get { return this.genericType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.NullableItemTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.genericType;
	            case 1: return this.simpleType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitNullableItemTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitNullableItemTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableItemTypeGreen(this.Kind, this.genericType, this.simpleType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableItemTypeGreen(this.Kind, this.genericType, this.simpleType, this.GetDiagnostics(), annotations);
	    }
	
	    public NullableItemTypeGreen Update(GenericTypeGreen genericType)
	    {
	        if (this.genericType != genericType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullableItemType(genericType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableItemTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public NullableItemTypeGreen Update(SimpleTypeGreen simpleType)
	    {
	        if (this.simpleType != simpleType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullableItemType(simpleType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableItemTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GenericTypeGreen : GreenSyntaxNode
	{
	    internal static readonly GenericTypeGreen __Missing = new GenericTypeGreen();
	    private QualifiedNameGreen qualifiedName;
	    private TypeArgumentListGreen typeArgumentList;
	
	    public GenericTypeGreen(TestLexerModeSyntaxKind kind, QualifiedNameGreen qualifiedName, TypeArgumentListGreen typeArgumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
	    public GenericTypeGreen(TestLexerModeSyntaxKind kind, QualifiedNameGreen qualifiedName, TypeArgumentListGreen typeArgumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
		private GenericTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GenericType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.GenericTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifiedName;
	            case 1: return this.typeArgumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitGenericTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitGenericTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericTypeGreen(this.Kind, this.qualifiedName, this.typeArgumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeGreen(this.Kind, this.qualifiedName, this.typeArgumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public GenericTypeGreen Update(QualifiedNameGreen qualifiedName, TypeArgumentListGreen typeArgumentList)
	    {
	        if (this.QualifiedName != qualifiedName ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.GenericType(qualifiedName, typeArgumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleTypeGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleTypeGreen __Missing = new SimpleTypeGreen();
	    private QualifiedNameGreen qualifiedName;
	    private PredefinedTypeGreen predefinedType;
	
	    public SimpleTypeGreen(TestLexerModeSyntaxKind kind, QualifiedNameGreen qualifiedName, PredefinedTypeGreen predefinedType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (predefinedType != null)
			{
				this.AdjustFlagsAndWidth(predefinedType);
				this.predefinedType = predefinedType;
			}
	    }
	
	    public SimpleTypeGreen(TestLexerModeSyntaxKind kind, QualifiedNameGreen qualifiedName, PredefinedTypeGreen predefinedType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (predefinedType != null)
			{
				this.AdjustFlagsAndWidth(predefinedType);
				this.predefinedType = predefinedType;
			}
	    }
	
		private SimpleTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SimpleType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public PredefinedTypeGreen PredefinedType { get { return this.predefinedType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SimpleTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifiedName;
	            case 1: return this.predefinedType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleTypeGreen(this.Kind, this.qualifiedName, this.predefinedType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleTypeGreen(this.Kind, this.qualifiedName, this.predefinedType, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleTypeGreen Update(QualifiedNameGreen qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SimpleType(qualifiedName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public SimpleTypeGreen Update(PredefinedTypeGreen predefinedType)
	    {
	        if (this.predefinedType != predefinedType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SimpleType(predefinedType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VoidTypeGreen : GreenSyntaxNode
	{
	    internal static readonly VoidTypeGreen __Missing = new VoidTypeGreen();
	    private InternalSyntaxToken kVoid;
	
	    public VoidTypeGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
		private VoidTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VoidType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.VoidTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VoidTypeGreen(this.Kind, this.kVoid, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VoidTypeGreen(this.Kind, this.kVoid, this.GetDiagnostics(), annotations);
	    }
	
	    public VoidTypeGreen Update(InternalSyntaxToken kVoid)
	    {
	        if (this.KVoid != kVoid)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnTypeGreen __Missing = new ReturnTypeGreen();
	    private TypeReferenceGreen typeReference;
	    private VoidTypeGreen voidType;
	
	    public ReturnTypeGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (voidType != null)
			{
				this.AdjustFlagsAndWidth(voidType);
				this.voidType = voidType;
			}
	    }
	
	    public ReturnTypeGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (voidType != null)
			{
				this.AdjustFlagsAndWidth(voidType);
				this.voidType = voidType;
			}
	    }
	
		private ReturnTypeGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ReturnType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ReturnTypeSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.voidType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnTypeGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.typeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public ReturnTypeGreen Update(VoidTypeGreen voidType)
	    {
	        if (this.voidType != voidType)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExpressionListGreen : GreenSyntaxNode
	{
	    internal static readonly ExpressionListGreen __Missing = new ExpressionListGreen();
	    private GreenNode expression;
	
	    public ExpressionListGreen(TestLexerModeSyntaxKind kind, GreenNode expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ExpressionListGreen(TestLexerModeSyntaxKind kind, GreenNode expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private ExpressionListGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExpressionList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> Expression { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen>(this.expression); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ExpressionListSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitExpressionListGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitExpressionListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExpressionListGreen(this.Kind, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExpressionListGreen(this.Kind, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public ExpressionListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> expression)
	    {
	        if (this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExpressionList(expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VariableReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly VariableReferenceGreen __Missing = new VariableReferenceGreen();
	    private ExpressionGreen expression;
	
	    public VariableReferenceGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public VariableReferenceGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private VariableReferenceGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.VariableReferenceSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitVariableReferenceGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitVariableReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableReferenceGreen(this.Kind, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableReferenceGreen(this.Kind, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableReferenceGreen Update(ExpressionGreen expression)
	    {
	        if (this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableReference(expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RankSpecifiersGreen : GreenSyntaxNode
	{
	    internal static readonly RankSpecifiersGreen __Missing = new RankSpecifiersGreen();
	    private GreenNode rankSpecifier;
	
	    public RankSpecifiersGreen(TestLexerModeSyntaxKind kind, GreenNode rankSpecifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (rankSpecifier != null)
			{
				this.AdjustFlagsAndWidth(rankSpecifier);
				this.rankSpecifier = rankSpecifier;
			}
	    }
	
	    public RankSpecifiersGreen(TestLexerModeSyntaxKind kind, GreenNode rankSpecifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (rankSpecifier != null)
			{
				this.AdjustFlagsAndWidth(rankSpecifier);
				this.rankSpecifier = rankSpecifier;
			}
	    }
	
		private RankSpecifiersGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RankSpecifiers, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RankSpecifierGreen> RankSpecifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RankSpecifierGreen>(this.rankSpecifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RankSpecifiersSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.rankSpecifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRankSpecifiersGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRankSpecifiersGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RankSpecifiersGreen(this.Kind, this.rankSpecifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RankSpecifiersGreen(this.Kind, this.rankSpecifier, this.GetDiagnostics(), annotations);
	    }
	
	    public RankSpecifiersGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RankSpecifierGreen> rankSpecifier)
	    {
	        if (this.RankSpecifier != rankSpecifier)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RankSpecifiers(rankSpecifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RankSpecifiersGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RankSpecifierGreen : GreenSyntaxNode
	{
	    internal static readonly RankSpecifierGreen __Missing = new RankSpecifierGreen();
	    private InternalSyntaxToken tOpenBracket;
	    private GreenNode tComma;
	    private InternalSyntaxToken tCloseBracket;
	
	    public RankSpecifierGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenBracket, GreenNode tComma, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (tComma != null)
			{
				this.AdjustFlagsAndWidth(tComma);
				this.tComma = tComma;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public RankSpecifierGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenBracket, GreenNode tComma, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (tComma != null)
			{
				this.AdjustFlagsAndWidth(tComma);
				this.tComma = tComma;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private RankSpecifierGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RankSpecifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> TComma { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken>(this.tComma); } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RankSpecifierSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.tComma;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRankSpecifierGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRankSpecifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RankSpecifierGreen(this.Kind, this.tOpenBracket, this.tComma, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RankSpecifierGreen(this.Kind, this.tOpenBracket, this.tComma, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public RankSpecifierGreen Update(InternalSyntaxToken tOpenBracket, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> tComma, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.TComma != tComma ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RankSpecifier(tOpenBracket, tComma, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RankSpecifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UnboundTypeNameGreen : GreenSyntaxNode
	{
	    internal static readonly UnboundTypeNameGreen __Missing = new UnboundTypeNameGreen();
	    private GreenNode genericDimensionItem;
	
	    public UnboundTypeNameGreen(TestLexerModeSyntaxKind kind, GreenNode genericDimensionItem)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (genericDimensionItem != null)
			{
				this.AdjustFlagsAndWidth(genericDimensionItem);
				this.genericDimensionItem = genericDimensionItem;
			}
	    }
	
	    public UnboundTypeNameGreen(TestLexerModeSyntaxKind kind, GreenNode genericDimensionItem, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (genericDimensionItem != null)
			{
				this.AdjustFlagsAndWidth(genericDimensionItem);
				this.genericDimensionItem = genericDimensionItem;
			}
	    }
	
		private UnboundTypeNameGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UnboundTypeName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericDimensionItemGreen> GenericDimensionItem { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericDimensionItemGreen>(this.genericDimensionItem); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.UnboundTypeNameSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.genericDimensionItem;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitUnboundTypeNameGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitUnboundTypeNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UnboundTypeNameGreen(this.Kind, this.genericDimensionItem, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UnboundTypeNameGreen(this.Kind, this.genericDimensionItem, this.GetDiagnostics(), annotations);
	    }
	
	    public UnboundTypeNameGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericDimensionItemGreen> genericDimensionItem)
	    {
	        if (this.GenericDimensionItem != genericDimensionItem)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.UnboundTypeName(genericDimensionItem);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnboundTypeNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GenericDimensionItemGreen : GreenSyntaxNode
	{
	    internal static readonly GenericDimensionItemGreen __Missing = new GenericDimensionItemGreen();
	    private IdentifierGreen identifier;
	    private GenericDimensionSpecifierGreen genericDimensionSpecifier;
	
	    public GenericDimensionItemGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, GenericDimensionSpecifierGreen genericDimensionSpecifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (genericDimensionSpecifier != null)
			{
				this.AdjustFlagsAndWidth(genericDimensionSpecifier);
				this.genericDimensionSpecifier = genericDimensionSpecifier;
			}
	    }
	
	    public GenericDimensionItemGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, GenericDimensionSpecifierGreen genericDimensionSpecifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (genericDimensionSpecifier != null)
			{
				this.AdjustFlagsAndWidth(genericDimensionSpecifier);
				this.genericDimensionSpecifier = genericDimensionSpecifier;
			}
	    }
	
		private GenericDimensionItemGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GenericDimensionItem, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public GenericDimensionSpecifierGreen GenericDimensionSpecifier { get { return this.genericDimensionSpecifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.GenericDimensionItemSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.genericDimensionSpecifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitGenericDimensionItemGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitGenericDimensionItemGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericDimensionItemGreen(this.Kind, this.identifier, this.genericDimensionSpecifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericDimensionItemGreen(this.Kind, this.identifier, this.genericDimensionSpecifier, this.GetDiagnostics(), annotations);
	    }
	
	    public GenericDimensionItemGreen Update(IdentifierGreen identifier, GenericDimensionSpecifierGreen genericDimensionSpecifier)
	    {
	        if (this.Identifier != identifier ||
				this.GenericDimensionSpecifier != genericDimensionSpecifier)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.GenericDimensionItem(identifier, genericDimensionSpecifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericDimensionItemGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GenericDimensionSpecifierGreen : GreenSyntaxNode
	{
	    internal static readonly GenericDimensionSpecifierGreen __Missing = new GenericDimensionSpecifierGreen();
	    private InternalSyntaxToken tLessThan;
	    private GreenNode tComma;
	    private InternalSyntaxToken tGreaterThan;
	
	    public GenericDimensionSpecifierGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tLessThan, GreenNode tComma, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (tComma != null)
			{
				this.AdjustFlagsAndWidth(tComma);
				this.tComma = tComma;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
	    public GenericDimensionSpecifierGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tLessThan, GreenNode tComma, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (tComma != null)
			{
				this.AdjustFlagsAndWidth(tComma);
				this.tComma = tComma;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
		private GenericDimensionSpecifierGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GenericDimensionSpecifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TLessThan { get { return this.tLessThan; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> TComma { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken>(this.tComma); } }
	    public InternalSyntaxToken TGreaterThan { get { return this.tGreaterThan; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.GenericDimensionSpecifierSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tLessThan;
	            case 1: return this.tComma;
	            case 2: return this.tGreaterThan;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitGenericDimensionSpecifierGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitGenericDimensionSpecifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericDimensionSpecifierGreen(this.Kind, this.tLessThan, this.tComma, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericDimensionSpecifierGreen(this.Kind, this.tLessThan, this.tComma, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public GenericDimensionSpecifierGreen Update(InternalSyntaxToken tLessThan, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> tComma, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.TLessThan != tLessThan ||
				this.TComma != tComma ||
				this.TGreaterThan != tGreaterThan)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.GenericDimensionSpecifier(tLessThan, tComma, tGreaterThan);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericDimensionSpecifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class AnonymousFunctionSignatureGreen : GreenSyntaxNode
	{
	    internal static readonly AnonymousFunctionSignatureGreen __Missing = ExplicitAnonymousFunctionSignatureGreen.__Missing;
	
	    public AnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ExplicitAnonymousFunctionSignatureGreen : AnonymousFunctionSignatureGreen
	{
	    internal static new readonly ExplicitAnonymousFunctionSignatureGreen __Missing = new ExplicitAnonymousFunctionSignatureGreen();
	    private InternalSyntaxToken tOpenParenthesis;
	    private GreenNode explicitParameter;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public ExplicitAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, GreenNode explicitParameter, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (explicitParameter != null)
			{
				this.AdjustFlagsAndWidth(explicitParameter);
				this.explicitParameter = explicitParameter;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public ExplicitAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, GreenNode explicitParameter, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (explicitParameter != null)
			{
				this.AdjustFlagsAndWidth(explicitParameter);
				this.explicitParameter = explicitParameter;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private ExplicitAnonymousFunctionSignatureGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExplicitAnonymousFunctionSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen> ExplicitParameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen>(this.explicitParameter); } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ExplicitAnonymousFunctionSignatureSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParenthesis;
	            case 1: return this.explicitParameter;
	            case 2: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitExplicitAnonymousFunctionSignatureGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitExplicitAnonymousFunctionSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExplicitAnonymousFunctionSignatureGreen(this.Kind, this.tOpenParenthesis, this.explicitParameter, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExplicitAnonymousFunctionSignatureGreen(this.Kind, this.tOpenParenthesis, this.explicitParameter, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public ExplicitAnonymousFunctionSignatureGreen Update(InternalSyntaxToken tOpenParenthesis, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen> explicitParameter, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.ExplicitParameter != explicitParameter ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExplicitAnonymousFunctionSignature(tOpenParenthesis, explicitParameter, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExplicitAnonymousFunctionSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ImplicitAnonymousFunctionSignatureGreen : AnonymousFunctionSignatureGreen
	{
	    internal static new readonly ImplicitAnonymousFunctionSignatureGreen __Missing = new ImplicitAnonymousFunctionSignatureGreen();
	    private InternalSyntaxToken tOpenParenthesis;
	    private GreenNode implicitParameter;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public ImplicitAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, GreenNode implicitParameter, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public ImplicitAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, GreenNode implicitParameter, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private ImplicitAnonymousFunctionSignatureGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ImplicitAnonymousFunctionSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen> ImplicitParameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen>(this.implicitParameter); } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ImplicitAnonymousFunctionSignatureSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParenthesis;
	            case 1: return this.implicitParameter;
	            case 2: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitImplicitAnonymousFunctionSignatureGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitImplicitAnonymousFunctionSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ImplicitAnonymousFunctionSignatureGreen(this.Kind, this.tOpenParenthesis, this.implicitParameter, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ImplicitAnonymousFunctionSignatureGreen(this.Kind, this.tOpenParenthesis, this.implicitParameter, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public ImplicitAnonymousFunctionSignatureGreen Update(InternalSyntaxToken tOpenParenthesis, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen> implicitParameter, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.ImplicitParameter != implicitParameter ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ImplicitAnonymousFunctionSignature(tOpenParenthesis, implicitParameter, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitAnonymousFunctionSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SingleParamAnonymousFunctionSignatureGreen : AnonymousFunctionSignatureGreen
	{
	    internal static new readonly SingleParamAnonymousFunctionSignatureGreen __Missing = new SingleParamAnonymousFunctionSignatureGreen();
	    private ImplicitParameterGreen implicitParameter;
	
	    public SingleParamAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, ImplicitParameterGreen implicitParameter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
	    }
	
	    public SingleParamAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind kind, ImplicitParameterGreen implicitParameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
	    }
	
		private SingleParamAnonymousFunctionSignatureGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleParamAnonymousFunctionSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ImplicitParameterGreen ImplicitParameter { get { return this.implicitParameter; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.SingleParamAnonymousFunctionSignatureSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.implicitParameter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitSingleParamAnonymousFunctionSignatureGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitSingleParamAnonymousFunctionSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SingleParamAnonymousFunctionSignatureGreen(this.Kind, this.implicitParameter, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SingleParamAnonymousFunctionSignatureGreen(this.Kind, this.implicitParameter, this.GetDiagnostics(), annotations);
	    }
	
	    public SingleParamAnonymousFunctionSignatureGreen Update(ImplicitParameterGreen implicitParameter)
	    {
	        if (this.ImplicitParameter != implicitParameter)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleParamAnonymousFunctionSignature(implicitParameter);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleParamAnonymousFunctionSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExplicitParameterGreen : GreenSyntaxNode
	{
	    internal static readonly ExplicitParameterGreen __Missing = new ExplicitParameterGreen();
	    private TypeReferenceGreen typeReference;
	    private IdentifierGreen identifier;
	
	    public ExplicitParameterGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public ExplicitParameterGreen(TestLexerModeSyntaxKind kind, TypeReferenceGreen typeReference, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private ExplicitParameterGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExplicitParameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ExplicitParameterSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitExplicitParameterGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitExplicitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExplicitParameterGreen(this.Kind, this.typeReference, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExplicitParameterGreen(this.Kind, this.typeReference, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ExplicitParameterGreen Update(TypeReferenceGreen typeReference, IdentifierGreen identifier)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExplicitParameter(typeReference, identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExplicitParameterGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ImplicitParameterGreen : GreenSyntaxNode
	{
	    internal static readonly ImplicitParameterGreen __Missing = new ImplicitParameterGreen();
	    private IdentifierGreen identifier;
	
	    public ImplicitParameterGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public ImplicitParameterGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private ImplicitParameterGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ImplicitParameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ImplicitParameterSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitImplicitParameterGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitImplicitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ImplicitParameterGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ImplicitParameterGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ImplicitParameterGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ImplicitParameter(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitParameterGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ExpressionGreen __Missing = ThisExpressionGreen.__Missing;
	
	    public ExpressionGreen(TestLexerModeSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ThisExpressionGreen : ExpressionGreen
	{
	    internal static new readonly ThisExpressionGreen __Missing = new ThisExpressionGreen();
	    private InternalSyntaxToken kThis;
	
	    public ThisExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kThis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kThis != null)
			{
				this.AdjustFlagsAndWidth(kThis);
				this.kThis = kThis;
			}
	    }
	
	    public ThisExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kThis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kThis != null)
			{
				this.AdjustFlagsAndWidth(kThis);
				this.kThis = kThis;
			}
	    }
	
		private ThisExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ThisExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KThis { get { return this.kThis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ThisExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kThis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitThisExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitThisExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ThisExpressionGreen(this.Kind, this.kThis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ThisExpressionGreen(this.Kind, this.kThis, this.GetDiagnostics(), annotations);
	    }
	
	    public ThisExpressionGreen Update(InternalSyntaxToken kThis)
	    {
	        if (this.KThis != kThis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ThisExpression(kThis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThisExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LiteralExpressionGreen : ExpressionGreen
	{
	    internal static new readonly LiteralExpressionGreen __Missing = new LiteralExpressionGreen();
	    private LiteralGreen literal;
	
	    public LiteralExpressionGreen(TestLexerModeSyntaxKind kind, LiteralGreen literal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
	    public LiteralExpressionGreen(TestLexerModeSyntaxKind kind, LiteralGreen literal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
		private LiteralExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LiteralExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LiteralGreen Literal { get { return this.literal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LiteralExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.literal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLiteralExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralExpressionGreen(this.Kind, this.literal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralExpressionGreen(this.Kind, this.literal, this.GetDiagnostics(), annotations);
	    }
	
	    public LiteralExpressionGreen Update(LiteralGreen literal)
	    {
	        if (this.Literal != literal)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LiteralExpression(literal);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeofVoidExpressionGreen : ExpressionGreen
	{
	    internal static new readonly TypeofVoidExpressionGreen __Missing = new TypeofVoidExpressionGreen();
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParenthesis;
	    private InternalSyntaxToken kVoid;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public TypeofVoidExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, InternalSyntaxToken kVoid, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public TypeofVoidExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, InternalSyntaxToken kVoid, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private TypeofVoidExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeofVoidExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypeofVoidExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeof;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.kVoid;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypeofVoidExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypeofVoidExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeofVoidExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.kVoid, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeofVoidExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.kVoid, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeofVoidExpressionGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, InternalSyntaxToken kVoid, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.KVoid != kVoid ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeofVoidExpression(kTypeof, tOpenParenthesis, kVoid, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofVoidExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeofUnboundTypeExpressionGreen : ExpressionGreen
	{
	    internal static new readonly TypeofUnboundTypeExpressionGreen __Missing = new TypeofUnboundTypeExpressionGreen();
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParenthesis;
	    private UnboundTypeNameGreen unboundTypeName;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public TypeofUnboundTypeExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, UnboundTypeNameGreen unboundTypeName, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (unboundTypeName != null)
			{
				this.AdjustFlagsAndWidth(unboundTypeName);
				this.unboundTypeName = unboundTypeName;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public TypeofUnboundTypeExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, UnboundTypeNameGreen unboundTypeName, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (unboundTypeName != null)
			{
				this.AdjustFlagsAndWidth(unboundTypeName);
				this.unboundTypeName = unboundTypeName;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private TypeofUnboundTypeExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeofUnboundTypeExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public UnboundTypeNameGreen UnboundTypeName { get { return this.unboundTypeName; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypeofUnboundTypeExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeof;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.unboundTypeName;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypeofUnboundTypeExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypeofUnboundTypeExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeofUnboundTypeExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.unboundTypeName, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeofUnboundTypeExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.unboundTypeName, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeofUnboundTypeExpressionGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, UnboundTypeNameGreen unboundTypeName, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.UnboundTypeName != unboundTypeName ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeofUnboundTypeExpression(kTypeof, tOpenParenthesis, unboundTypeName, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofUnboundTypeExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeofTypeExpressionGreen : ExpressionGreen
	{
	    internal static new readonly TypeofTypeExpressionGreen __Missing = new TypeofTypeExpressionGreen();
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParenthesis;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public TypeofTypeExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public TypeofTypeExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private TypeofTypeExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeofTypeExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypeofTypeExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeof;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.typeReference;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypeofTypeExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypeofTypeExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeofTypeExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeofTypeExpressionGreen(this.Kind, this.kTypeof, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeofTypeExpressionGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeofTypeExpression(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofTypeExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefaultValueExpressionGreen : ExpressionGreen
	{
	    internal static new readonly DefaultValueExpressionGreen __Missing = new DefaultValueExpressionGreen();
	    private InternalSyntaxToken kDefault;
	    private InternalSyntaxToken tOpenParenthesis;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public DefaultValueExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kDefault, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kDefault != null)
			{
				this.AdjustFlagsAndWidth(kDefault);
				this.kDefault = kDefault;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public DefaultValueExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kDefault, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kDefault != null)
			{
				this.AdjustFlagsAndWidth(kDefault);
				this.kDefault = kDefault;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private DefaultValueExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DefaultValueExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDefault { get { return this.kDefault; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.DefaultValueExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDefault;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.typeReference;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitDefaultValueExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitDefaultValueExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefaultValueExpressionGreen(this.Kind, this.kDefault, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefaultValueExpressionGreen(this.Kind, this.kDefault, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public DefaultValueExpressionGreen Update(InternalSyntaxToken kDefault, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KDefault != kDefault ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DefaultValueExpression(kDefault, tOpenParenthesis, typeReference, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultValueExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NewObjectOrCollectionWithConstructorExpressionGreen : ExpressionGreen
	{
	    internal static new readonly NewObjectOrCollectionWithConstructorExpressionGreen __Missing = new NewObjectOrCollectionWithConstructorExpressionGreen();
	    private InternalSyntaxToken kNew;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public NewObjectOrCollectionWithConstructorExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kNew != null)
			{
				this.AdjustFlagsAndWidth(kNew);
				this.kNew = kNew;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public NewObjectOrCollectionWithConstructorExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kNew != null)
			{
				this.AdjustFlagsAndWidth(kNew);
				this.kNew = kNew;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private NewObjectOrCollectionWithConstructorExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NewObjectOrCollectionWithConstructorExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNew { get { return this.kNew; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.NewObjectOrCollectionWithConstructorExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNew;
	            case 1: return this.typeReference;
	            case 2: return this.tOpenParenthesis;
	            case 3: return this.expressionList;
	            case 4: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitNewObjectOrCollectionWithConstructorExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitNewObjectOrCollectionWithConstructorExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NewObjectOrCollectionWithConstructorExpressionGreen(this.Kind, this.kNew, this.typeReference, this.tOpenParenthesis, this.expressionList, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NewObjectOrCollectionWithConstructorExpressionGreen(this.Kind, this.kNew, this.typeReference, this.tOpenParenthesis, this.expressionList, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public NewObjectOrCollectionWithConstructorExpressionGreen Update(InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KNew != kNew ||
				this.TypeReference != typeReference ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ExpressionList != expressionList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NewObjectOrCollectionWithConstructorExpression(kNew, typeReference, tOpenParenthesis, expressionList, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NewObjectOrCollectionWithConstructorExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierExpressionGreen : ExpressionGreen
	{
	    internal static new readonly IdentifierExpressionGreen __Missing = new IdentifierExpressionGreen();
	    private IdentifierGreen identifier;
	    private TypeArgumentListGreen typeArgumentList;
	
	    public IdentifierExpressionGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
	    public IdentifierExpressionGreen(TestLexerModeSyntaxKind kind, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
		private IdentifierExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IdentifierExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IdentifierExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.typeArgumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIdentifierExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierExpressionGreen(this.Kind, this.identifier, this.typeArgumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierExpressionGreen(this.Kind, this.identifier, this.typeArgumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierExpressionGreen Update(IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	        if (this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IdentifierExpression(identifier, typeArgumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HasLoopExpressionGreen : ExpressionGreen
	{
	    internal static new readonly HasLoopExpressionGreen __Missing = new HasLoopExpressionGreen();
	    private InternalSyntaxToken kHasLoop;
	    private InternalSyntaxToken tOpenParenthesis;
	    private LoopChainGreen loopChain;
	    private LoopWhereExpressionGreen loopWhereExpression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public HasLoopExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kHasLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kHasLoop != null)
			{
				this.AdjustFlagsAndWidth(kHasLoop);
				this.kHasLoop = kHasLoop;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (loopChain != null)
			{
				this.AdjustFlagsAndWidth(loopChain);
				this.loopChain = loopChain;
			}
			if (loopWhereExpression != null)
			{
				this.AdjustFlagsAndWidth(loopWhereExpression);
				this.loopWhereExpression = loopWhereExpression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public HasLoopExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kHasLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kHasLoop != null)
			{
				this.AdjustFlagsAndWidth(kHasLoop);
				this.kHasLoop = kHasLoop;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (loopChain != null)
			{
				this.AdjustFlagsAndWidth(loopChain);
				this.loopChain = loopChain;
			}
			if (loopWhereExpression != null)
			{
				this.AdjustFlagsAndWidth(loopWhereExpression);
				this.loopWhereExpression = loopWhereExpression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private HasLoopExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.HasLoopExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KHasLoop { get { return this.kHasLoop; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public LoopChainGreen LoopChain { get { return this.loopChain; } }
	    public LoopWhereExpressionGreen LoopWhereExpression { get { return this.loopWhereExpression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.HasLoopExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kHasLoop;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.loopChain;
	            case 3: return this.loopWhereExpression;
	            case 4: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitHasLoopExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitHasLoopExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HasLoopExpressionGreen(this.Kind, this.kHasLoop, this.tOpenParenthesis, this.loopChain, this.loopWhereExpression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HasLoopExpressionGreen(this.Kind, this.kHasLoop, this.tOpenParenthesis, this.loopChain, this.loopWhereExpression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public HasLoopExpressionGreen Update(InternalSyntaxToken kHasLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.KHasLoop != kHasLoop ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.LoopChain != loopChain ||
				this.LoopWhereExpression != loopWhereExpression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.HasLoopExpression(kHasLoop, tOpenParenthesis, loopChain, loopWhereExpression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HasLoopExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParenthesizedExpressionGreen : ExpressionGreen
	{
	    internal static new readonly ParenthesizedExpressionGreen __Missing = new ParenthesizedExpressionGreen();
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public ParenthesizedExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public ParenthesizedExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private ParenthesizedExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ParenthesizedExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ParenthesizedExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParenthesis;
	            case 1: return this.expression;
	            case 2: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitParenthesizedExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitParenthesizedExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParenthesizedExpressionGreen(this.Kind, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParenthesizedExpressionGreen(this.Kind, this.tOpenParenthesis, this.expression, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public ParenthesizedExpressionGreen Update(InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ParenthesizedExpression(tOpenParenthesis, expression, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenthesizedExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementAccessExpressionGreen : ExpressionGreen
	{
	    internal static new readonly ElementAccessExpressionGreen __Missing = new ElementAccessExpressionGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tOpenBracket;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tCloseBracket;
	
	    public ElementAccessExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tOpenBracket, ExpressionListGreen expressionList, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public ElementAccessExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tOpenBracket, ExpressionListGreen expressionList, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private ElementAccessExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ElementAccessExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ElementAccessExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.tOpenBracket;
	            case 2: return this.expressionList;
	            case 3: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitElementAccessExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitElementAccessExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementAccessExpressionGreen(this.Kind, this.expression, this.tOpenBracket, this.expressionList, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementAccessExpressionGreen(this.Kind, this.expression, this.tOpenBracket, this.expressionList, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementAccessExpressionGreen Update(ExpressionGreen expression, InternalSyntaxToken tOpenBracket, ExpressionListGreen expressionList, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.Expression != expression ||
				this.TOpenBracket != tOpenBracket ||
				this.ExpressionList != expressionList ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElementAccessExpression(expression, tOpenBracket, expressionList, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementAccessExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FunctionCallExpressionGreen : ExpressionGreen
	{
	    internal static new readonly FunctionCallExpressionGreen __Missing = new FunctionCallExpressionGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tOpenParenthesis;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tCloseParenthesis;
	
	    public FunctionCallExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
	    public FunctionCallExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
	    }
	
		private FunctionCallExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.FunctionCallExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.FunctionCallExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.tOpenParenthesis;
	            case 2: return this.expressionList;
	            case 3: return this.tCloseParenthesis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionCallExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitFunctionCallExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionCallExpressionGreen(this.Kind, this.expression, this.tOpenParenthesis, this.expressionList, this.tCloseParenthesis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionCallExpressionGreen(this.Kind, this.expression, this.tOpenParenthesis, this.expressionList, this.tCloseParenthesis, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionCallExpressionGreen Update(ExpressionGreen expression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	    {
	        if (this.Expression != expression ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ExpressionList != expressionList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.FunctionCallExpression(expression, tOpenParenthesis, expressionList, tCloseParenthesis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionCallExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PredefinedTypeMemberAccessExpressionGreen : ExpressionGreen
	{
	    internal static new readonly PredefinedTypeMemberAccessExpressionGreen __Missing = new PredefinedTypeMemberAccessExpressionGreen();
	    private PredefinedTypeGreen predefinedType;
	    private InternalSyntaxToken tDot;
	    private IdentifierGreen identifier;
	    private TypeArgumentListGreen typeArgumentList;
	
	    public PredefinedTypeMemberAccessExpressionGreen(TestLexerModeSyntaxKind kind, PredefinedTypeGreen predefinedType, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (predefinedType != null)
			{
				this.AdjustFlagsAndWidth(predefinedType);
				this.predefinedType = predefinedType;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
	    public PredefinedTypeMemberAccessExpressionGreen(TestLexerModeSyntaxKind kind, PredefinedTypeGreen predefinedType, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (predefinedType != null)
			{
				this.AdjustFlagsAndWidth(predefinedType);
				this.predefinedType = predefinedType;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
		private PredefinedTypeMemberAccessExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.PredefinedTypeMemberAccessExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public PredefinedTypeGreen PredefinedType { get { return this.predefinedType; } }
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.PredefinedTypeMemberAccessExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.predefinedType;
	            case 1: return this.tDot;
	            case 2: return this.identifier;
	            case 3: return this.typeArgumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitPredefinedTypeMemberAccessExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitPredefinedTypeMemberAccessExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PredefinedTypeMemberAccessExpressionGreen(this.Kind, this.predefinedType, this.tDot, this.identifier, this.typeArgumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PredefinedTypeMemberAccessExpressionGreen(this.Kind, this.predefinedType, this.tDot, this.identifier, this.typeArgumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public PredefinedTypeMemberAccessExpressionGreen Update(PredefinedTypeGreen predefinedType, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	        if (this.PredefinedType != predefinedType ||
				this.TDot != tDot ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.PredefinedTypeMemberAccessExpression(predefinedType, tDot, identifier, typeArgumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PredefinedTypeMemberAccessExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MemberAccessExpressionGreen : ExpressionGreen
	{
	    internal static new readonly MemberAccessExpressionGreen __Missing = new MemberAccessExpressionGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tDot;
	    private IdentifierGreen identifier;
	    private TypeArgumentListGreen typeArgumentList;
	
	    public MemberAccessExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
	    public MemberAccessExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (typeArgumentList != null)
			{
				this.AdjustFlagsAndWidth(typeArgumentList);
				this.typeArgumentList = typeArgumentList;
			}
	    }
	
		private MemberAccessExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MemberAccessExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public TypeArgumentListGreen TypeArgumentList { get { return this.typeArgumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.MemberAccessExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.tDot;
	            case 2: return this.identifier;
	            case 3: return this.typeArgumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitMemberAccessExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitMemberAccessExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MemberAccessExpressionGreen(this.Kind, this.expression, this.tDot, this.identifier, this.typeArgumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MemberAccessExpressionGreen(this.Kind, this.expression, this.tDot, this.identifier, this.typeArgumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public MemberAccessExpressionGreen Update(ExpressionGreen expression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	        if (this.Expression != expression ||
				this.TDot != tDot ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.MemberAccessExpression(expression, tDot, identifier, typeArgumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberAccessExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypecastExpressionGreen : ExpressionGreen
	{
	    internal static new readonly TypecastExpressionGreen __Missing = new TypecastExpressionGreen();
	    private InternalSyntaxToken tOpenParenthesis;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParenthesis;
	    private ExpressionGreen expression;
	
	    public TypecastExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public TypecastExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (tOpenParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tOpenParenthesis);
				this.tOpenParenthesis = tOpenParenthesis;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParenthesis != null)
			{
				this.AdjustFlagsAndWidth(tCloseParenthesis);
				this.tCloseParenthesis = tCloseParenthesis;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private TypecastExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypecastExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParenthesis { get { return this.tOpenParenthesis; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParenthesis { get { return this.tCloseParenthesis; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypecastExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParenthesis;
	            case 1: return this.typeReference;
	            case 2: return this.tCloseParenthesis;
	            case 3: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypecastExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypecastExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypecastExpressionGreen(this.Kind, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypecastExpressionGreen(this.Kind, this.tOpenParenthesis, this.typeReference, this.tCloseParenthesis, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public TypecastExpressionGreen Update(InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, ExpressionGreen expression)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypecastExpression(tOpenParenthesis, typeReference, tCloseParenthesis, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypecastExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UnaryExpressionGreen : ExpressionGreen
	{
	    internal static new readonly UnaryExpressionGreen __Missing = new UnaryExpressionGreen();
	    private InternalSyntaxToken op;
	    private ExpressionGreen expression;
	
	    public UnaryExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken op, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public UnaryExpressionGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken op, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private UnaryExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UnaryExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.UnaryExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.op;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitUnaryExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitUnaryExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UnaryExpressionGreen(this.Kind, this.op, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UnaryExpressionGreen(this.Kind, this.op, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public UnaryExpressionGreen Update(InternalSyntaxToken op, ExpressionGreen expression)
	    {
	        if (this.Op != op ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.UnaryExpression(op, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnaryExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PostExpressionGreen : ExpressionGreen
	{
	    internal static new readonly PostExpressionGreen __Missing = new PostExpressionGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken op;
	
	    public PostExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken op)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
	    }
	
	    public PostExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken op, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
	    }
	
		private PostExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.PostExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.PostExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.op;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitPostExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitPostExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PostExpressionGreen(this.Kind, this.expression, this.op, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PostExpressionGreen(this.Kind, this.expression, this.op, this.GetDiagnostics(), annotations);
	    }
	
	    public PostExpressionGreen Update(ExpressionGreen expression, InternalSyntaxToken op)
	    {
	        if (this.Expression != expression ||
				this.Op != op)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.PostExpression(expression, op);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PostExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MultiplicationExpressionGreen : ExpressionGreen
	{
	    internal static new readonly MultiplicationExpressionGreen __Missing = new MultiplicationExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken op;
	    private ExpressionGreen right;
	
	    public MultiplicationExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public MultiplicationExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private MultiplicationExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MultiplicationExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.MultiplicationExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.op;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitMultiplicationExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitMultiplicationExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MultiplicationExpressionGreen(this.Kind, this.left, this.op, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MultiplicationExpressionGreen(this.Kind, this.left, this.op, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public MultiplicationExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.MultiplicationExpression(left, op, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiplicationExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AdditionExpressionGreen : ExpressionGreen
	{
	    internal static new readonly AdditionExpressionGreen __Missing = new AdditionExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken op;
	    private ExpressionGreen right;
	
	    public AdditionExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AdditionExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private AdditionExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.AdditionExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.AdditionExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.op;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitAdditionExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitAdditionExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AdditionExpressionGreen(this.Kind, this.left, this.op, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AdditionExpressionGreen(this.Kind, this.left, this.op, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public AdditionExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.AdditionExpression(left, op, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AdditionExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RelationalExpressionGreen : ExpressionGreen
	{
	    internal static new readonly RelationalExpressionGreen __Missing = new RelationalExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken op;
	    private ExpressionGreen right;
	
	    public RelationalExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public RelationalExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private RelationalExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RelationalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.RelationalExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.op;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitRelationalExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitRelationalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RelationalExpressionGreen(this.Kind, this.left, this.op, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RelationalExpressionGreen(this.Kind, this.left, this.op, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public RelationalExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.RelationalExpression(left, op, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RelationalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypecheckExpressionGreen : ExpressionGreen
	{
	    internal static new readonly TypecheckExpressionGreen __Missing = new TypecheckExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken op;
	    private TypeReferenceGreen typeReference;
	
	    public TypecheckExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypecheckExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private TypecheckExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypecheckExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TypecheckExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.op;
	            case 2: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTypecheckExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTypecheckExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypecheckExpressionGreen(this.Kind, this.left, this.op, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypecheckExpressionGreen(this.Kind, this.left, this.op, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public TypecheckExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken op, TypeReferenceGreen typeReference)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypecheckExpression(left, op, typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypecheckExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EqualityExpressionGreen : ExpressionGreen
	{
	    internal static new readonly EqualityExpressionGreen __Missing = new EqualityExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken op;
	    private ExpressionGreen right;
	
	    public EqualityExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public EqualityExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private EqualityExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.EqualityExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.EqualityExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.op;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitEqualityExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitEqualityExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EqualityExpressionGreen(this.Kind, this.left, this.op, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EqualityExpressionGreen(this.Kind, this.left, this.op, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public EqualityExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.EqualityExpression(left, op, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EqualityExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BitwiseAndExpressionGreen : ExpressionGreen
	{
	    internal static new readonly BitwiseAndExpressionGreen __Missing = new BitwiseAndExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tAmp;
	    private ExpressionGreen right;
	
	    public BitwiseAndExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAmp, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAmp != null)
			{
				this.AdjustFlagsAndWidth(tAmp);
				this.tAmp = tAmp;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public BitwiseAndExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAmp, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAmp != null)
			{
				this.AdjustFlagsAndWidth(tAmp);
				this.tAmp = tAmp;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private BitwiseAndExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BitwiseAndExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TAmp { get { return this.tAmp; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.BitwiseAndExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tAmp;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitBitwiseAndExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitBitwiseAndExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BitwiseAndExpressionGreen(this.Kind, this.left, this.tAmp, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BitwiseAndExpressionGreen(this.Kind, this.left, this.tAmp, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public BitwiseAndExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken tAmp, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TAmp != tAmp ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.BitwiseAndExpression(left, tAmp, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BitwiseAndExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BitwiseXorExpressionGreen : ExpressionGreen
	{
	    internal static new readonly BitwiseXorExpressionGreen __Missing = new BitwiseXorExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tHat;
	    private ExpressionGreen right;
	
	    public BitwiseXorExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tHat != null)
			{
				this.AdjustFlagsAndWidth(tHat);
				this.tHat = tHat;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public BitwiseXorExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tHat != null)
			{
				this.AdjustFlagsAndWidth(tHat);
				this.tHat = tHat;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private BitwiseXorExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BitwiseXorExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken THat { get { return this.tHat; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.BitwiseXorExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tHat;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitBitwiseXorExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitBitwiseXorExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BitwiseXorExpressionGreen(this.Kind, this.left, this.tHat, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BitwiseXorExpressionGreen(this.Kind, this.left, this.tHat, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public BitwiseXorExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.THat != tHat ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.BitwiseXorExpression(left, tHat, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BitwiseXorExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BitwiseOrExpressionGreen : ExpressionGreen
	{
	    internal static new readonly BitwiseOrExpressionGreen __Missing = new BitwiseOrExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tPipe;
	    private ExpressionGreen right;
	
	    public BitwiseOrExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tPipe, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tPipe != null)
			{
				this.AdjustFlagsAndWidth(tPipe);
				this.tPipe = tPipe;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public BitwiseOrExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tPipe, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tPipe != null)
			{
				this.AdjustFlagsAndWidth(tPipe);
				this.tPipe = tPipe;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private BitwiseOrExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BitwiseOrExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TPipe { get { return this.tPipe; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.BitwiseOrExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tPipe;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitBitwiseOrExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitBitwiseOrExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BitwiseOrExpressionGreen(this.Kind, this.left, this.tPipe, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BitwiseOrExpressionGreen(this.Kind, this.left, this.tPipe, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public BitwiseOrExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken tPipe, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TPipe != tPipe ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.BitwiseOrExpression(left, tPipe, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BitwiseOrExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LogicalAndExpressionGreen : ExpressionGreen
	{
	    internal static new readonly LogicalAndExpressionGreen __Missing = new LogicalAndExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tAnd;
	    private ExpressionGreen right;
	
	    public LogicalAndExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAnd, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAnd != null)
			{
				this.AdjustFlagsAndWidth(tAnd);
				this.tAnd = tAnd;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public LogicalAndExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAnd, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAnd != null)
			{
				this.AdjustFlagsAndWidth(tAnd);
				this.tAnd = tAnd;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private LogicalAndExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LogicalAndExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TAnd { get { return this.tAnd; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LogicalAndExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tAnd;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLogicalAndExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLogicalAndExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LogicalAndExpressionGreen(this.Kind, this.left, this.tAnd, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LogicalAndExpressionGreen(this.Kind, this.left, this.tAnd, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public LogicalAndExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken tAnd, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TAnd != tAnd ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LogicalAndExpression(left, tAnd, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LogicalAndExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LogicalXorExpressionGreen : ExpressionGreen
	{
	    internal static new readonly LogicalXorExpressionGreen __Missing = new LogicalXorExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tXor;
	    private ExpressionGreen right;
	
	    public LogicalXorExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tXor, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tXor != null)
			{
				this.AdjustFlagsAndWidth(tXor);
				this.tXor = tXor;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public LogicalXorExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tXor, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tXor != null)
			{
				this.AdjustFlagsAndWidth(tXor);
				this.tXor = tXor;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private LogicalXorExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LogicalXorExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TXor { get { return this.tXor; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LogicalXorExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tXor;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLogicalXorExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLogicalXorExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LogicalXorExpressionGreen(this.Kind, this.left, this.tXor, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LogicalXorExpressionGreen(this.Kind, this.left, this.tXor, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public LogicalXorExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken tXor, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TXor != tXor ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LogicalXorExpression(left, tXor, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LogicalXorExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LogicalOrExpressionGreen : ExpressionGreen
	{
	    internal static new readonly LogicalOrExpressionGreen __Missing = new LogicalOrExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tOr;
	    private ExpressionGreen right;
	
	    public LogicalOrExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tOr, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tOr != null)
			{
				this.AdjustFlagsAndWidth(tOr);
				this.tOr = tOr;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public LogicalOrExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tOr, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tOr != null)
			{
				this.AdjustFlagsAndWidth(tOr);
				this.tOr = tOr;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private LogicalOrExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LogicalOrExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TOr { get { return this.tOr; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LogicalOrExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tOr;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLogicalOrExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLogicalOrExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LogicalOrExpressionGreen(this.Kind, this.left, this.tOr, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LogicalOrExpressionGreen(this.Kind, this.left, this.tOr, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public LogicalOrExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken tOr, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TOr != tOr ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LogicalOrExpression(left, tOr, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LogicalOrExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ConditionalExpressionGreen : ExpressionGreen
	{
	    internal static new readonly ConditionalExpressionGreen __Missing = new ConditionalExpressionGreen();
	    private ExpressionGreen condition;
	    private InternalSyntaxToken tQuestion;
	    private ExpressionGreen thenBranch;
	    private InternalSyntaxToken tColon;
	    private ExpressionGreen elseBranch;
	
	    public ConditionalExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen thenBranch, InternalSyntaxToken tColon, ExpressionGreen elseBranch)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
			if (thenBranch != null)
			{
				this.AdjustFlagsAndWidth(thenBranch);
				this.thenBranch = thenBranch;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (elseBranch != null)
			{
				this.AdjustFlagsAndWidth(elseBranch);
				this.elseBranch = elseBranch;
			}
	    }
	
	    public ConditionalExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen thenBranch, InternalSyntaxToken tColon, ExpressionGreen elseBranch, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
			if (thenBranch != null)
			{
				this.AdjustFlagsAndWidth(thenBranch);
				this.thenBranch = thenBranch;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (elseBranch != null)
			{
				this.AdjustFlagsAndWidth(elseBranch);
				this.elseBranch = elseBranch;
			}
	    }
	
		private ConditionalExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ConditionalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Condition { get { return this.condition; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	    public ExpressionGreen ThenBranch { get { return this.thenBranch; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ExpressionGreen ElseBranch { get { return this.elseBranch; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ConditionalExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.condition;
	            case 1: return this.tQuestion;
	            case 2: return this.thenBranch;
	            case 3: return this.tColon;
	            case 4: return this.elseBranch;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitConditionalExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitConditionalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConditionalExpressionGreen(this.Kind, this.condition, this.tQuestion, this.thenBranch, this.tColon, this.elseBranch, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConditionalExpressionGreen(this.Kind, this.condition, this.tQuestion, this.thenBranch, this.tColon, this.elseBranch, this.GetDiagnostics(), annotations);
	    }
	
	    public ConditionalExpressionGreen Update(ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen thenBranch, InternalSyntaxToken tColon, ExpressionGreen elseBranch)
	    {
	        if (this.Condition != condition ||
				this.TQuestion != tQuestion ||
				this.ThenBranch != thenBranch ||
				this.TColon != tColon ||
				this.ElseBranch != elseBranch)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConditionalExpression(condition, tQuestion, thenBranch, tColon, elseBranch);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConditionalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssignmentExpressionGreen : ExpressionGreen
	{
	    internal static new readonly AssignmentExpressionGreen __Missing = new AssignmentExpressionGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken op;
	    private ExpressionGreen right;
	
	    public AssignmentExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AssignmentExpressionGreen(TestLexerModeSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (op != null)
			{
				this.AdjustFlagsAndWidth(op);
				this.op = op;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private AssignmentExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.AssignmentExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Op { get { return this.op; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.AssignmentExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.op;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitAssignmentExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitAssignmentExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssignmentExpressionGreen(this.Kind, this.left, this.op, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssignmentExpressionGreen(this.Kind, this.left, this.op, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public AssignmentExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.AssignmentExpression(left, op, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignmentExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LambdaExpressionGreen : ExpressionGreen
	{
	    internal static new readonly LambdaExpressionGreen __Missing = new LambdaExpressionGreen();
	    private AnonymousFunctionSignatureGreen anonymousFunctionSignature;
	    private InternalSyntaxToken tArrow;
	    private ExpressionGreen expression;
	
	    public LambdaExpressionGreen(TestLexerModeSyntaxKind kind, AnonymousFunctionSignatureGreen anonymousFunctionSignature, InternalSyntaxToken tArrow, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (anonymousFunctionSignature != null)
			{
				this.AdjustFlagsAndWidth(anonymousFunctionSignature);
				this.anonymousFunctionSignature = anonymousFunctionSignature;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public LambdaExpressionGreen(TestLexerModeSyntaxKind kind, AnonymousFunctionSignatureGreen anonymousFunctionSignature, InternalSyntaxToken tArrow, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (anonymousFunctionSignature != null)
			{
				this.AdjustFlagsAndWidth(anonymousFunctionSignature);
				this.anonymousFunctionSignature = anonymousFunctionSignature;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private LambdaExpressionGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LambdaExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnonymousFunctionSignatureGreen AnonymousFunctionSignature { get { return this.anonymousFunctionSignature; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LambdaExpressionSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.anonymousFunctionSignature;
	            case 1: return this.tArrow;
	            case 2: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLambdaExpressionGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLambdaExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LambdaExpressionGreen(this.Kind, this.anonymousFunctionSignature, this.tArrow, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LambdaExpressionGreen(this.Kind, this.anonymousFunctionSignature, this.tArrow, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public LambdaExpressionGreen Update(AnonymousFunctionSignatureGreen anonymousFunctionSignature, InternalSyntaxToken tArrow, ExpressionGreen expression)
	    {
	        if (this.AnonymousFunctionSignature != anonymousFunctionSignature ||
				this.TArrow != tArrow ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.LambdaExpression(anonymousFunctionSignature, tArrow, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifiedNameGreen : GreenSyntaxNode
	{
	    internal static readonly QualifiedNameGreen __Missing = new QualifiedNameGreen();
	    private GreenNode identifier;
	
	    public QualifiedNameGreen(TestLexerModeSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifiedNameGreen(TestLexerModeSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private QualifiedNameGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.QualifiedNameSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.QualifiedName(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierListGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierListGreen __Missing = new IdentifierListGreen();
	    private GreenNode identifier;
	
	    public IdentifierListGreen(TestLexerModeSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierListGreen(TestLexerModeSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private IdentifierListGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IdentifierList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IdentifierListSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierListGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIdentifierListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierListGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierListGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IdentifierList(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierGreen __Missing = new IdentifierGreen();
	    private InternalSyntaxToken identifierNormal;
	
	    public IdentifierGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken identifierNormal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifierNormal != null)
			{
				this.AdjustFlagsAndWidth(identifierNormal);
				this.identifierNormal = identifierNormal;
			}
	    }
	
	    public IdentifierGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken identifierNormal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifierNormal != null)
			{
				this.AdjustFlagsAndWidth(identifierNormal);
				this.identifierNormal = identifierNormal;
			}
	    }
	
		private IdentifierGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IdentifierNormal { get { return this.identifierNormal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IdentifierSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifierNormal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.identifierNormal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.identifierNormal, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(InternalSyntaxToken identifierNormal)
	    {
	        if (this.IdentifierNormal != identifierNormal)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Identifier(identifierNormal);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LiteralGreen : GreenSyntaxNode
	{
	    internal static readonly LiteralGreen __Missing = new LiteralGreen();
	    private NullLiteralGreen nullLiteral;
	    private BooleanLiteralGreen booleanLiteral;
	    private NumberLiteralGreen numberLiteral;
	    private DateOrTimeLiteralGreen dateOrTimeLiteral;
	    private CharLiteralGreen charLiteral;
	    private StringLiteralGreen stringLiteral;
	    private GuidLiteralGreen guidLiteral;
	
	    public LiteralGreen(TestLexerModeSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, NumberLiteralGreen numberLiteral, DateOrTimeLiteralGreen dateOrTimeLiteral, CharLiteralGreen charLiteral, StringLiteralGreen stringLiteral, GuidLiteralGreen guidLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (nullLiteral != null)
			{
				this.AdjustFlagsAndWidth(nullLiteral);
				this.nullLiteral = nullLiteral;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (numberLiteral != null)
			{
				this.AdjustFlagsAndWidth(numberLiteral);
				this.numberLiteral = numberLiteral;
			}
			if (dateOrTimeLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateOrTimeLiteral);
				this.dateOrTimeLiteral = dateOrTimeLiteral;
			}
			if (charLiteral != null)
			{
				this.AdjustFlagsAndWidth(charLiteral);
				this.charLiteral = charLiteral;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
			if (guidLiteral != null)
			{
				this.AdjustFlagsAndWidth(guidLiteral);
				this.guidLiteral = guidLiteral;
			}
	    }
	
	    public LiteralGreen(TestLexerModeSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, NumberLiteralGreen numberLiteral, DateOrTimeLiteralGreen dateOrTimeLiteral, CharLiteralGreen charLiteral, StringLiteralGreen stringLiteral, GuidLiteralGreen guidLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (nullLiteral != null)
			{
				this.AdjustFlagsAndWidth(nullLiteral);
				this.nullLiteral = nullLiteral;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (numberLiteral != null)
			{
				this.AdjustFlagsAndWidth(numberLiteral);
				this.numberLiteral = numberLiteral;
			}
			if (dateOrTimeLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateOrTimeLiteral);
				this.dateOrTimeLiteral = dateOrTimeLiteral;
			}
			if (charLiteral != null)
			{
				this.AdjustFlagsAndWidth(charLiteral);
				this.charLiteral = charLiteral;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
			if (guidLiteral != null)
			{
				this.AdjustFlagsAndWidth(guidLiteral);
				this.guidLiteral = guidLiteral;
			}
	    }
	
		private LiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Literal, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NullLiteralGreen NullLiteral { get { return this.nullLiteral; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public NumberLiteralGreen NumberLiteral { get { return this.numberLiteral; } }
	    public DateOrTimeLiteralGreen DateOrTimeLiteral { get { return this.dateOrTimeLiteral; } }
	    public CharLiteralGreen CharLiteral { get { return this.charLiteral; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	    public GuidLiteralGreen GuidLiteral { get { return this.guidLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.LiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nullLiteral;
	            case 1: return this.booleanLiteral;
	            case 2: return this.numberLiteral;
	            case 3: return this.dateOrTimeLiteral;
	            case 4: return this.charLiteral;
	            case 5: return this.stringLiteral;
	            case 6: return this.guidLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.numberLiteral, this.dateOrTimeLiteral, this.charLiteral, this.stringLiteral, this.guidLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.numberLiteral, this.dateOrTimeLiteral, this.charLiteral, this.stringLiteral, this.guidLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public LiteralGreen Update(NullLiteralGreen nullLiteral)
	    {
	        if (this.nullLiteral != nullLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public LiteralGreen Update(BooleanLiteralGreen booleanLiteral)
	    {
	        if (this.booleanLiteral != booleanLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public LiteralGreen Update(NumberLiteralGreen numberLiteral)
	    {
	        if (this.numberLiteral != numberLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(numberLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public LiteralGreen Update(DateOrTimeLiteralGreen dateOrTimeLiteral)
	    {
	        if (this.dateOrTimeLiteral != dateOrTimeLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(dateOrTimeLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public LiteralGreen Update(CharLiteralGreen charLiteral)
	    {
	        if (this.charLiteral != charLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(charLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public LiteralGreen Update(StringLiteralGreen stringLiteral)
	    {
	        if (this.stringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public LiteralGreen Update(GuidLiteralGreen guidLiteral)
	    {
	        if (this.guidLiteral != guidLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal(guidLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NullLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly NullLiteralGreen __Missing = new NullLiteralGreen();
	    private InternalSyntaxToken kNull;
	
	    public NullLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
		private NullLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.NullLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullLiteralGreen(this.Kind, this.kNull, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullLiteralGreen(this.Kind, this.kNull, this.GetDiagnostics(), annotations);
	    }
	
	    public NullLiteralGreen Update(InternalSyntaxToken kNull)
	    {
	        if (this.KNull != kNull)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BooleanLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly BooleanLiteralGreen __Missing = new BooleanLiteralGreen();
	    private InternalSyntaxToken booleanLiteral;
	
	    public BooleanLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
		private BooleanLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.BooleanLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public BooleanLiteralGreen Update(InternalSyntaxToken booleanLiteral)
	    {
	        if (this.BooleanLiteral != booleanLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NumberLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly NumberLiteralGreen __Missing = new NumberLiteralGreen();
	    private IntegerLiteralGreen integerLiteral;
	    private DecimalLiteralGreen decimalLiteral;
	    private ScientificLiteralGreen scientificLiteral;
	
	    public NumberLiteralGreen(TestLexerModeSyntaxKind kind, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (integerLiteral != null)
			{
				this.AdjustFlagsAndWidth(integerLiteral);
				this.integerLiteral = integerLiteral;
			}
			if (decimalLiteral != null)
			{
				this.AdjustFlagsAndWidth(decimalLiteral);
				this.decimalLiteral = decimalLiteral;
			}
			if (scientificLiteral != null)
			{
				this.AdjustFlagsAndWidth(scientificLiteral);
				this.scientificLiteral = scientificLiteral;
			}
	    }
	
	    public NumberLiteralGreen(TestLexerModeSyntaxKind kind, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (integerLiteral != null)
			{
				this.AdjustFlagsAndWidth(integerLiteral);
				this.integerLiteral = integerLiteral;
			}
			if (decimalLiteral != null)
			{
				this.AdjustFlagsAndWidth(decimalLiteral);
				this.decimalLiteral = decimalLiteral;
			}
			if (scientificLiteral != null)
			{
				this.AdjustFlagsAndWidth(scientificLiteral);
				this.scientificLiteral = scientificLiteral;
			}
	    }
	
		private NumberLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NumberLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IntegerLiteralGreen IntegerLiteral { get { return this.integerLiteral; } }
	    public DecimalLiteralGreen DecimalLiteral { get { return this.decimalLiteral; } }
	    public ScientificLiteralGreen ScientificLiteral { get { return this.scientificLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.NumberLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.integerLiteral;
	            case 1: return this.decimalLiteral;
	            case 2: return this.scientificLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitNumberLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitNumberLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NumberLiteralGreen(this.Kind, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NumberLiteralGreen(this.Kind, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public NumberLiteralGreen Update(IntegerLiteralGreen integerLiteral)
	    {
	        if (this.integerLiteral != integerLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NumberLiteral(integerLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NumberLiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public NumberLiteralGreen Update(DecimalLiteralGreen decimalLiteral)
	    {
	        if (this.decimalLiteral != decimalLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NumberLiteral(decimalLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NumberLiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public NumberLiteralGreen Update(ScientificLiteralGreen scientificLiteral)
	    {
	        if (this.scientificLiteral != scientificLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.NumberLiteral(scientificLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NumberLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IntegerLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly IntegerLiteralGreen __Missing = new IntegerLiteralGreen();
	    private InternalSyntaxToken lInteger;
	
	    public IntegerLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
		private IntegerLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.IntegerLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IntegerLiteralGreen(this.Kind, this.lInteger, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IntegerLiteralGreen(this.Kind, this.lInteger, this.GetDiagnostics(), annotations);
	    }
	
	    public IntegerLiteralGreen Update(InternalSyntaxToken lInteger)
	    {
	        if (this.LInteger != lInteger)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DecimalLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly DecimalLiteralGreen __Missing = new DecimalLiteralGreen();
	    private InternalSyntaxToken lDecimal;
	
	    public DecimalLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
		private DecimalLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.DecimalLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DecimalLiteralGreen(this.Kind, this.lDecimal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DecimalLiteralGreen(this.Kind, this.lDecimal, this.GetDiagnostics(), annotations);
	    }
	
	    public DecimalLiteralGreen Update(InternalSyntaxToken lDecimal)
	    {
	        if (this.LDecimal != lDecimal)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ScientificLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly ScientificLiteralGreen __Missing = new ScientificLiteralGreen();
	    private InternalSyntaxToken lScientific;
	
	    public ScientificLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
		private ScientificLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.ScientificLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ScientificLiteralGreen(this.Kind, this.lScientific, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ScientificLiteralGreen(this.Kind, this.lScientific, this.GetDiagnostics(), annotations);
	    }
	
	    public ScientificLiteralGreen Update(InternalSyntaxToken lScientific)
	    {
	        if (this.LScientific != lScientific)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DateOrTimeLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly DateOrTimeLiteralGreen __Missing = new DateOrTimeLiteralGreen();
	    private DateTimeLiteralGreen dateTimeLiteral;
	    private DateTimeOffsetLiteralGreen dateTimeOffsetLiteral;
	    private DateLiteralGreen dateLiteral;
	    private TimeLiteralGreen timeLiteral;
	
	    public DateOrTimeLiteralGreen(TestLexerModeSyntaxKind kind, DateTimeLiteralGreen dateTimeLiteral, DateTimeOffsetLiteralGreen dateTimeOffsetLiteral, DateLiteralGreen dateLiteral, TimeLiteralGreen timeLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (dateTimeLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateTimeLiteral);
				this.dateTimeLiteral = dateTimeLiteral;
			}
			if (dateTimeOffsetLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateTimeOffsetLiteral);
				this.dateTimeOffsetLiteral = dateTimeOffsetLiteral;
			}
			if (dateLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateLiteral);
				this.dateLiteral = dateLiteral;
			}
			if (timeLiteral != null)
			{
				this.AdjustFlagsAndWidth(timeLiteral);
				this.timeLiteral = timeLiteral;
			}
	    }
	
	    public DateOrTimeLiteralGreen(TestLexerModeSyntaxKind kind, DateTimeLiteralGreen dateTimeLiteral, DateTimeOffsetLiteralGreen dateTimeOffsetLiteral, DateLiteralGreen dateLiteral, TimeLiteralGreen timeLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (dateTimeLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateTimeLiteral);
				this.dateTimeLiteral = dateTimeLiteral;
			}
			if (dateTimeOffsetLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateTimeOffsetLiteral);
				this.dateTimeOffsetLiteral = dateTimeOffsetLiteral;
			}
			if (dateLiteral != null)
			{
				this.AdjustFlagsAndWidth(dateLiteral);
				this.dateLiteral = dateLiteral;
			}
			if (timeLiteral != null)
			{
				this.AdjustFlagsAndWidth(timeLiteral);
				this.timeLiteral = timeLiteral;
			}
	    }
	
		private DateOrTimeLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateOrTimeLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public DateTimeLiteralGreen DateTimeLiteral { get { return this.dateTimeLiteral; } }
	    public DateTimeOffsetLiteralGreen DateTimeOffsetLiteral { get { return this.dateTimeOffsetLiteral; } }
	    public DateLiteralGreen DateLiteral { get { return this.dateLiteral; } }
	    public TimeLiteralGreen TimeLiteral { get { return this.timeLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.DateOrTimeLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.dateTimeLiteral;
	            case 1: return this.dateTimeOffsetLiteral;
	            case 2: return this.dateLiteral;
	            case 3: return this.timeLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitDateOrTimeLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitDateOrTimeLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DateOrTimeLiteralGreen(this.Kind, this.dateTimeLiteral, this.dateTimeOffsetLiteral, this.dateLiteral, this.timeLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DateOrTimeLiteralGreen(this.Kind, this.dateTimeLiteral, this.dateTimeOffsetLiteral, this.dateLiteral, this.timeLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public DateOrTimeLiteralGreen Update(DateTimeLiteralGreen dateTimeLiteral)
	    {
	        if (this.dateTimeLiteral != dateTimeLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral(dateTimeLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public DateOrTimeLiteralGreen Update(DateTimeOffsetLiteralGreen dateTimeOffsetLiteral)
	    {
	        if (this.dateTimeOffsetLiteral != dateTimeOffsetLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral(dateTimeOffsetLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public DateOrTimeLiteralGreen Update(DateLiteralGreen dateLiteral)
	    {
	        if (this.dateLiteral != dateLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral(dateLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralGreen)newNode;
	        }
	        return this;
	    }
	
	    public DateOrTimeLiteralGreen Update(TimeLiteralGreen timeLiteral)
	    {
	        if (this.timeLiteral != timeLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral(timeLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DateTimeOffsetLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly DateTimeOffsetLiteralGreen __Missing = new DateTimeOffsetLiteralGreen();
	    private InternalSyntaxToken lDateTimeOffset;
	
	    public DateTimeOffsetLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDateTimeOffset)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDateTimeOffset != null)
			{
				this.AdjustFlagsAndWidth(lDateTimeOffset);
				this.lDateTimeOffset = lDateTimeOffset;
			}
	    }
	
	    public DateTimeOffsetLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDateTimeOffset, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lDateTimeOffset != null)
			{
				this.AdjustFlagsAndWidth(lDateTimeOffset);
				this.lDateTimeOffset = lDateTimeOffset;
			}
	    }
	
		private DateTimeOffsetLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateTimeOffsetLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDateTimeOffset { get { return this.lDateTimeOffset; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.DateTimeOffsetLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDateTimeOffset;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitDateTimeOffsetLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitDateTimeOffsetLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DateTimeOffsetLiteralGreen(this.Kind, this.lDateTimeOffset, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DateTimeOffsetLiteralGreen(this.Kind, this.lDateTimeOffset, this.GetDiagnostics(), annotations);
	    }
	
	    public DateTimeOffsetLiteralGreen Update(InternalSyntaxToken lDateTimeOffset)
	    {
	        if (this.LDateTimeOffset != lDateTimeOffset)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeOffsetLiteral(lDateTimeOffset);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateTimeOffsetLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DateTimeLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly DateTimeLiteralGreen __Missing = new DateTimeLiteralGreen();
	    private InternalSyntaxToken lDateTime;
	
	    public DateTimeLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDateTime)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDateTime != null)
			{
				this.AdjustFlagsAndWidth(lDateTime);
				this.lDateTime = lDateTime;
			}
	    }
	
	    public DateTimeLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDateTime, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lDateTime != null)
			{
				this.AdjustFlagsAndWidth(lDateTime);
				this.lDateTime = lDateTime;
			}
	    }
	
		private DateTimeLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateTimeLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDateTime { get { return this.lDateTime; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.DateTimeLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDateTime;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitDateTimeLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitDateTimeLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DateTimeLiteralGreen(this.Kind, this.lDateTime, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DateTimeLiteralGreen(this.Kind, this.lDateTime, this.GetDiagnostics(), annotations);
	    }
	
	    public DateTimeLiteralGreen Update(InternalSyntaxToken lDateTime)
	    {
	        if (this.LDateTime != lDateTime)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeLiteral(lDateTime);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateTimeLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DateLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly DateLiteralGreen __Missing = new DateLiteralGreen();
	    private InternalSyntaxToken lDate;
	
	    public DateLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDate)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDate != null)
			{
				this.AdjustFlagsAndWidth(lDate);
				this.lDate = lDate;
			}
	    }
	
	    public DateLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lDate, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lDate != null)
			{
				this.AdjustFlagsAndWidth(lDate);
				this.lDate = lDate;
			}
	    }
	
		private DateLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDate { get { return this.lDate; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.DateLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDate;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitDateLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitDateLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DateLiteralGreen(this.Kind, this.lDate, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DateLiteralGreen(this.Kind, this.lDate, this.GetDiagnostics(), annotations);
	    }
	
	    public DateLiteralGreen Update(InternalSyntaxToken lDate)
	    {
	        if (this.LDate != lDate)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateLiteral(lDate);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TimeLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly TimeLiteralGreen __Missing = new TimeLiteralGreen();
	    private InternalSyntaxToken lTime;
	
	    public TimeLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lTime)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lTime != null)
			{
				this.AdjustFlagsAndWidth(lTime);
				this.lTime = lTime;
			}
	    }
	
	    public TimeLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lTime, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lTime != null)
			{
				this.AdjustFlagsAndWidth(lTime);
				this.lTime = lTime;
			}
	    }
	
		private TimeLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TimeLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LTime { get { return this.lTime; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.TimeLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lTime;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitTimeLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitTimeLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TimeLiteralGreen(this.Kind, this.lTime, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TimeLiteralGreen(this.Kind, this.lTime, this.GetDiagnostics(), annotations);
	    }
	
	    public TimeLiteralGreen Update(InternalSyntaxToken lTime)
	    {
	        if (this.LTime != lTime)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.TimeLiteral(lTime);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TimeLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CharLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly CharLiteralGreen __Missing = new CharLiteralGreen();
	    private InternalSyntaxToken lChar;
	
	    public CharLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lChar)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lChar != null)
			{
				this.AdjustFlagsAndWidth(lChar);
				this.lChar = lChar;
			}
	    }
	
	    public CharLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lChar, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lChar != null)
			{
				this.AdjustFlagsAndWidth(lChar);
				this.lChar = lChar;
			}
	    }
	
		private CharLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.CharLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LChar { get { return this.lChar; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.CharLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lChar;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitCharLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitCharLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CharLiteralGreen(this.Kind, this.lChar, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CharLiteralGreen(this.Kind, this.lChar, this.GetDiagnostics(), annotations);
	    }
	
	    public CharLiteralGreen Update(InternalSyntaxToken lChar)
	    {
	        if (this.LChar != lChar)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.CharLiteral(lChar);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CharLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StringLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly StringLiteralGreen __Missing = new StringLiteralGreen();
	    private InternalSyntaxToken stringLiteral;
	
	    public StringLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public StringLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
		private StringLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.StringLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringLiteralGreen(this.Kind, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringLiteralGreen(this.Kind, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public StringLiteralGreen Update(InternalSyntaxToken stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.StringLiteral(stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GuidLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly GuidLiteralGreen __Missing = new GuidLiteralGreen();
	    private InternalSyntaxToken lGuid;
	
	    public GuidLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lGuid)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lGuid != null)
			{
				this.AdjustFlagsAndWidth(lGuid);
				this.lGuid = lGuid;
			}
	    }
	
	    public GuidLiteralGreen(TestLexerModeSyntaxKind kind, InternalSyntaxToken lGuid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lGuid != null)
			{
				this.AdjustFlagsAndWidth(lGuid);
				this.lGuid = lGuid;
			}
	    }
	
		private GuidLiteralGreen()
			: base((TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GuidLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LGuid { get { return this.lGuid; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.GuidLiteralSyntax(this, (TestLexerModeSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lGuid;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLexerModeSyntaxVisitor<TResult> visitor) => visitor.VisitGuidLiteralGreen(this);
	
	    public override void Accept(TestLexerModeSyntaxVisitor visitor) => visitor.VisitGuidLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GuidLiteralGreen(this.Kind, this.lGuid, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GuidLiteralGreen(this.Kind, this.lGuid, this.GetDiagnostics(), annotations);
	    }
	
	    public GuidLiteralGreen Update(InternalSyntaxToken lGuid)
	    {
	        if (this.LGuid != lGuid)
	        {
	            InternalSyntaxNode newNode = TestLexerModeLanguage.Instance.InternalSyntaxFactory.GuidLiteral(lGuid);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GuidLiteralGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class TestLexerModeSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitGeneratorDeclarationGreen(GeneratorDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitUsingNamespaceDeclarationGreen(UsingNamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitUsingGeneratorDeclarationGreen(UsingGeneratorDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitConfigDeclarationGreen(ConfigDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitConfigPropertyDeclarationGreen(ConfigPropertyDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitConfigPropertyGroupDeclarationGreen(ConfigPropertyGroupDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitMethodDeclarationGreen(MethodDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitExternFunctionDeclarationGreen(ExternFunctionDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionDeclarationGreen(FunctionDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionSignatureGreen(FunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitParamListGreen(ParamListGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitBodyGreen(BodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitStatementGreen(StatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSingleStatementGreen(SingleStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSingleStatementSemicolonGreen(SingleStatementSemicolonGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableDeclarationStatementGreen(VariableDeclarationStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableDeclarationExpressionGreen(VariableDeclarationExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableDeclarationItemGreen(VariableDeclarationItemGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidStatementGreen(VoidStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnStatementGreen(ReturnStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitExpressionStatementGreen(ExpressionStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfStatementGreen(IfStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitElseIfStatementBodyGreen(ElseIfStatementBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfStatementElseBodyGreen(IfStatementElseBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfStatementBeginGreen(IfStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual void VisitElseIfStatementGreen(ElseIfStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfStatementElseGreen(IfStatementElseGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfStatementEndGreen(IfStatementEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitForStatementGreen(ForStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitForStatementBeginGreen(ForStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual void VisitForStatementEndGreen(ForStatementEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitForInitStatementGreen(ForInitStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitWhileStatementGreen(WhileStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitWhileStatementBeginGreen(WhileStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual void VisitWhileStatementEndGreen(WhileStatementEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitWhileRunExpressionGreen(WhileRunExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitRepeatStatementGreen(RepeatStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitRepeatStatementBeginGreen(RepeatStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual void VisitRepeatStatementEndGreen(RepeatStatementEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitRepeatRunExpressionGreen(RepeatRunExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopStatementGreen(LoopStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopStatementBeginGreen(LoopStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopStatementEndGreen(LoopStatementEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopChainGreen(LoopChainGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopChainItemGreen(LoopChainItemGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopChainTypeofExpressionGreen(LoopChainTypeofExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopChainIdentifierExpressionGreen(LoopChainIdentifierExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopChainMemberAccessExpressionGreen(LoopChainMemberAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopChainMethodCallExpressionGreen(LoopChainMethodCallExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopWhereExpressionGreen(LoopWhereExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopRunExpressionGreen(LoopRunExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitSeparatorStatementGreen(SeparatorStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchStatementGreen(SwitchStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchStatementBeginGreen(SwitchStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchStatementEndGreen(SwitchStatementEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchBranchStatementGreen(SwitchBranchStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchBranchHeadStatementGreen(SwitchBranchHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchCaseOrTypeIsHeadStatementsGreen(SwitchCaseOrTypeIsHeadStatementsGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchCaseOrTypeIsHeadStatementGreen(SwitchCaseOrTypeIsHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchCaseHeadStatementGreen(SwitchCaseHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchTypeIsHeadStatementGreen(SwitchTypeIsHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchTypeAsHeadStatementGreen(SwitchTypeAsHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchDefaultStatementGreen(SwitchDefaultStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitSwitchDefaultHeadStatementGreen(SwitchDefaultHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateDeclarationGreen(TemplateDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateSignatureGreen(TemplateSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateBodyGreen(TemplateBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateContentLineGreen(TemplateContentLineGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateContentGreen(TemplateContentGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateOutputGreen(TemplateOutputGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateLineEndGreen(TemplateLineEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateStatementStartEndGreen(TemplateStatementStartEndGreen node) => this.DefaultVisit(node);
		public virtual void VisitTemplateStatementGreen(TemplateStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeArgumentListGreen(TypeArgumentListGreen node) => this.DefaultVisit(node);
		public virtual void VisitPredefinedTypeGreen(PredefinedTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceListGreen(TypeReferenceListGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrayTypeGreen(ArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrayItemTypeGreen(ArrayItemTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableItemTypeGreen(NullableItemTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeGreen(GenericTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitExpressionListGreen(ExpressionListGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableReferenceGreen(VariableReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitRankSpecifiersGreen(RankSpecifiersGreen node) => this.DefaultVisit(node);
		public virtual void VisitRankSpecifierGreen(RankSpecifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitUnboundTypeNameGreen(UnboundTypeNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericDimensionItemGreen(GenericDimensionItemGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericDimensionSpecifierGreen(GenericDimensionSpecifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitExplicitAnonymousFunctionSignatureGreen(ExplicitAnonymousFunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitImplicitAnonymousFunctionSignatureGreen(ImplicitAnonymousFunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitSingleParamAnonymousFunctionSignatureGreen(SingleParamAnonymousFunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitExplicitParameterGreen(ExplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitImplicitParameterGreen(ImplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitThisExpressionGreen(ThisExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralExpressionGreen(LiteralExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeofVoidExpressionGreen(TypeofVoidExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeofUnboundTypeExpressionGreen(TypeofUnboundTypeExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeofTypeExpressionGreen(TypeofTypeExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitDefaultValueExpressionGreen(DefaultValueExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitNewObjectOrCollectionWithConstructorExpressionGreen(NewObjectOrCollectionWithConstructorExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierExpressionGreen(IdentifierExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitHasLoopExpressionGreen(HasLoopExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitParenthesizedExpressionGreen(ParenthesizedExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitElementAccessExpressionGreen(ElementAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionCallExpressionGreen(FunctionCallExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitPredefinedTypeMemberAccessExpressionGreen(PredefinedTypeMemberAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitMemberAccessExpressionGreen(MemberAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypecastExpressionGreen(TypecastExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitUnaryExpressionGreen(UnaryExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitPostExpressionGreen(PostExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitMultiplicationExpressionGreen(MultiplicationExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitAdditionExpressionGreen(AdditionExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitRelationalExpressionGreen(RelationalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypecheckExpressionGreen(TypecheckExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitEqualityExpressionGreen(EqualityExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitBitwiseAndExpressionGreen(BitwiseAndExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitBitwiseXorExpressionGreen(BitwiseXorExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitBitwiseOrExpressionGreen(BitwiseOrExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLogicalAndExpressionGreen(LogicalAndExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLogicalXorExpressionGreen(LogicalXorExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLogicalOrExpressionGreen(LogicalOrExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitConditionalExpressionGreen(ConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssignmentExpressionGreen(AssignmentExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLambdaExpressionGreen(LambdaExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierListGreen(IdentifierListGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNumberLiteralGreen(NumberLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDateOrTimeLiteralGreen(DateOrTimeLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDateTimeOffsetLiteralGreen(DateTimeOffsetLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDateTimeLiteralGreen(DateTimeLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDateLiteralGreen(DateLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitTimeLiteralGreen(TimeLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitCharLiteralGreen(CharLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitGuidLiteralGreen(GuidLiteralGreen node) => this.DefaultVisit(node);
	}
	
	internal class TestLexerModeSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGeneratorDeclarationGreen(GeneratorDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUsingNamespaceDeclarationGreen(UsingNamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUsingGeneratorDeclarationGreen(UsingGeneratorDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConfigDeclarationGreen(ConfigDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConfigPropertyDeclarationGreen(ConfigPropertyDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConfigPropertyGroupDeclarationGreen(ConfigPropertyGroupDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMethodDeclarationGreen(MethodDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExternFunctionDeclarationGreen(ExternFunctionDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionDeclarationGreen(FunctionDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionSignatureGreen(FunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParamListGreen(ParamListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBodyGreen(BodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStatementGreen(StatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSingleStatementGreen(SingleStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSingleStatementSemicolonGreen(SingleStatementSemicolonGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableDeclarationStatementGreen(VariableDeclarationStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableDeclarationExpressionGreen(VariableDeclarationExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableDeclarationItemGreen(VariableDeclarationItemGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidStatementGreen(VoidStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnStatementGreen(ReturnStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExpressionStatementGreen(ExpressionStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfStatementGreen(IfStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElseIfStatementBodyGreen(ElseIfStatementBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfStatementElseBodyGreen(IfStatementElseBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfStatementBeginGreen(IfStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElseIfStatementGreen(ElseIfStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfStatementElseGreen(IfStatementElseGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfStatementEndGreen(IfStatementEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForStatementGreen(ForStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForStatementBeginGreen(ForStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForStatementEndGreen(ForStatementEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForInitStatementGreen(ForInitStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWhileStatementGreen(WhileStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWhileStatementBeginGreen(WhileStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWhileStatementEndGreen(WhileStatementEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWhileRunExpressionGreen(WhileRunExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRepeatStatementGreen(RepeatStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRepeatStatementBeginGreen(RepeatStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRepeatStatementEndGreen(RepeatStatementEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRepeatRunExpressionGreen(RepeatRunExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopStatementGreen(LoopStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopStatementBeginGreen(LoopStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopStatementEndGreen(LoopStatementEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopChainGreen(LoopChainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopChainItemGreen(LoopChainItemGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopChainTypeofExpressionGreen(LoopChainTypeofExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopChainIdentifierExpressionGreen(LoopChainIdentifierExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopChainMemberAccessExpressionGreen(LoopChainMemberAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopChainMethodCallExpressionGreen(LoopChainMethodCallExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopWhereExpressionGreen(LoopWhereExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopRunExpressionGreen(LoopRunExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSeparatorStatementGreen(SeparatorStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchStatementGreen(SwitchStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchStatementBeginGreen(SwitchStatementBeginGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchStatementEndGreen(SwitchStatementEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchBranchStatementGreen(SwitchBranchStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchBranchHeadStatementGreen(SwitchBranchHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchCaseOrTypeIsHeadStatementsGreen(SwitchCaseOrTypeIsHeadStatementsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchCaseOrTypeIsHeadStatementGreen(SwitchCaseOrTypeIsHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchCaseHeadStatementGreen(SwitchCaseHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchTypeIsHeadStatementGreen(SwitchTypeIsHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchTypeAsHeadStatementGreen(SwitchTypeAsHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchDefaultStatementGreen(SwitchDefaultStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSwitchDefaultHeadStatementGreen(SwitchDefaultHeadStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateDeclarationGreen(TemplateDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateSignatureGreen(TemplateSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateBodyGreen(TemplateBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateContentLineGreen(TemplateContentLineGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateContentGreen(TemplateContentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateOutputGreen(TemplateOutputGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateLineEndGreen(TemplateLineEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateStatementStartEndGreen(TemplateStatementStartEndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTemplateStatementGreen(TemplateStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeArgumentListGreen(TypeArgumentListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPredefinedTypeGreen(PredefinedTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceListGreen(TypeReferenceListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrayTypeGreen(ArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrayItemTypeGreen(ArrayItemTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableItemTypeGreen(NullableItemTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeGreen(GenericTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExpressionListGreen(ExpressionListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableReferenceGreen(VariableReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRankSpecifiersGreen(RankSpecifiersGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRankSpecifierGreen(RankSpecifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUnboundTypeNameGreen(UnboundTypeNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericDimensionItemGreen(GenericDimensionItemGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericDimensionSpecifierGreen(GenericDimensionSpecifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExplicitAnonymousFunctionSignatureGreen(ExplicitAnonymousFunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitImplicitAnonymousFunctionSignatureGreen(ImplicitAnonymousFunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSingleParamAnonymousFunctionSignatureGreen(SingleParamAnonymousFunctionSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExplicitParameterGreen(ExplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitImplicitParameterGreen(ImplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitThisExpressionGreen(ThisExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralExpressionGreen(LiteralExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeofVoidExpressionGreen(TypeofVoidExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeofUnboundTypeExpressionGreen(TypeofUnboundTypeExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeofTypeExpressionGreen(TypeofTypeExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDefaultValueExpressionGreen(DefaultValueExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNewObjectOrCollectionWithConstructorExpressionGreen(NewObjectOrCollectionWithConstructorExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierExpressionGreen(IdentifierExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHasLoopExpressionGreen(HasLoopExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParenthesizedExpressionGreen(ParenthesizedExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElementAccessExpressionGreen(ElementAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionCallExpressionGreen(FunctionCallExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPredefinedTypeMemberAccessExpressionGreen(PredefinedTypeMemberAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMemberAccessExpressionGreen(MemberAccessExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypecastExpressionGreen(TypecastExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUnaryExpressionGreen(UnaryExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPostExpressionGreen(PostExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMultiplicationExpressionGreen(MultiplicationExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAdditionExpressionGreen(AdditionExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRelationalExpressionGreen(RelationalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypecheckExpressionGreen(TypecheckExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEqualityExpressionGreen(EqualityExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBitwiseAndExpressionGreen(BitwiseAndExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBitwiseXorExpressionGreen(BitwiseXorExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBitwiseOrExpressionGreen(BitwiseOrExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLogicalAndExpressionGreen(LogicalAndExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLogicalXorExpressionGreen(LogicalXorExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLogicalOrExpressionGreen(LogicalOrExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConditionalExpressionGreen(ConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssignmentExpressionGreen(AssignmentExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLambdaExpressionGreen(LambdaExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierListGreen(IdentifierListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNumberLiteralGreen(NumberLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDateOrTimeLiteralGreen(DateOrTimeLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDateTimeOffsetLiteralGreen(DateTimeOffsetLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDateTimeLiteralGreen(DateTimeLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDateLiteralGreen(DateLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTimeLiteralGreen(TimeLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCharLiteralGreen(CharLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGuidLiteralGreen(GuidLiteralGreen node) => this.DefaultVisit(node);
	}
	internal class TestLexerModeInternalSyntaxFactory : InternalSyntaxFactory, MetaDslx.Languages.Antlr4Roslyn.IAntlr4SyntaxFactory
	{
		public TestLexerModeInternalSyntaxFactory(TestLexerModeSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public Antlr4.Runtime.Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new TestLexerModeLexer(input);
	    }
	
	    public Antlr4.Runtime.Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new TestLexerModeParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
		{
			return new TestLexerModeSyntaxLexer(text, (TestLexerModeParseOptions)options ?? TestLexerModeParseOptions.Default);
		}
	
	    public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
		{
			return new TestLexerModeSyntaxParser(text, (TestLexerModeParseOptions)options ?? TestLexerModeParseOptions.Default, (TestLexerModeSyntaxNode)oldTree, changes, cancellationToken);
		}
	
	    public override Language Language => TestLexerModeLanguage.Instance;
	
		private TestLexerModeSyntaxKind ToTestLexerModeSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<TestLexerModeSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToTestLexerModeSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToTestLexerModeSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToTestLexerModeSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
		{
			return new GreenSkippedTokensTriviaSyntax(ToTestLexerModeSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToTestLexerModeSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToTestLexerModeSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			TestLexerModeSyntaxKind typedKind = ToTestLexerModeSyntaxKind(kind);
	        Debug.Assert(TestLexerModeLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestLexerModeLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			TestLexerModeSyntaxKind typedKind = ToTestLexerModeSyntaxKind(kind);
	        Debug.Assert(TestLexerModeLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestLexerModeLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			TestLexerModeSyntaxKind typedKind = ToTestLexerModeSyntaxKind(kind);
	        Debug.Assert(TestLexerModeLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestLexerModeLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToTestLexerModeSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToTestLexerModeSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToTestLexerModeSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken TOpenBracket(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TOpenBracket, text, null);
	    }
	
	    internal InternalSyntaxToken TOpenBracket(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TOpenBracket, text, value, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDateTime, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDate, text, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LDate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTime, text, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LChar(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LChar, text, null);
	    }
	
	    internal InternalSyntaxToken LChar(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LChar, text, value, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LRegularString, text, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LGuid, text, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhitespace(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LWhitespace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhitespace(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LWhitespace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineBreak(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LLineBreak, text, null);
	    }
	
	    internal InternalSyntaxToken LLineBreak(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LLineBreak, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineComment(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LLineComment(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LMultiLineComment(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LMultiLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LMultiLineComment(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LMultiLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken TH_TOpenParenthesis(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TH_TOpenParenthesis, text, null);
	    }
	
	    internal InternalSyntaxToken TH_TOpenParenthesis(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TH_TOpenParenthesis, text, value, null);
	    }
	
	    internal InternalSyntaxToken TH_TCloseParenthesis(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TH_TCloseParenthesis, text, null);
	    }
	
	    internal InternalSyntaxToken TH_TCloseParenthesis(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TH_TCloseParenthesis, text, value, null);
	    }
	
	    internal InternalSyntaxToken KEndTemplate(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.KEndTemplate, text, null);
	    }
	
	    internal InternalSyntaxToken KEndTemplate(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.KEndTemplate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTemplateLineControl(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateLineControl, text, null);
	    }
	
	    internal InternalSyntaxToken LTemplateLineControl(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateLineControl, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTemplateOutput(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateOutput, text, null);
	    }
	
	    internal InternalSyntaxToken LTemplateOutput(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateOutput, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTemplateCrLf(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LTemplateCrLf(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTemplateLineBreak(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateLineBreak, text, null);
	    }
	
	    internal InternalSyntaxToken LTemplateLineBreak(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.LTemplateLineBreak, text, value, null);
	    }
	
	    internal InternalSyntaxToken TTemplateStatementStart(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TTemplateStatementStart, text, null);
	    }
	
	    internal InternalSyntaxToken TTemplateStatementStart(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TTemplateStatementStart, text, value, null);
	    }
	
	    internal InternalSyntaxToken TTemplateStatementEnd(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TTemplateStatementEnd, text, null);
	    }
	
	    internal InternalSyntaxToken TTemplateStatementEnd(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TTemplateStatementEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken TS_TOpenBracket(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TS_TOpenBracket, text, null);
	    }
	
	    internal InternalSyntaxToken TS_TOpenBracket(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TS_TOpenBracket, text, value, null);
	    }
	
	    internal InternalSyntaxToken TS_TCloseBracket(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TS_TCloseBracket, text, null);
	    }
	
	    internal InternalSyntaxToken TS_TCloseBracket(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.TS_TCloseBracket, text, value, null);
	    }
	
	    internal InternalSyntaxToken COMMENT_START(string text)
	    {
	        return Token(null, TestLexerModeSyntaxKind.COMMENT_START, text, null);
	    }
	
	    internal InternalSyntaxToken COMMENT_START(string text, object value)
	    {
	        return Token(null, TestLexerModeSyntaxKind.COMMENT_START, text, value, null);
	    }
	
		public MainGreen Main(NamespaceDeclarationGreen namespaceDeclaration, GeneratorDeclarationGreen generatorDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen> usingDeclaration, ConfigDeclarationGreen configDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MethodDeclarationGreen> methodDeclaration, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
			if (generatorDeclaration == null) throw new ArgumentNullException(nameof(generatorDeclaration));
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != TestLexerModeSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
	        return new MainGreen(TestLexerModeSyntaxKind.Main, namespaceDeclaration, generatorDeclaration, usingDeclaration.Node, configDeclaration, methodDeclaration.Node, eOF);
	    }
	
		public NamespaceDeclarationGreen NamespaceDeclaration(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLexerModeSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NamespaceDeclaration, kNamespace, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (NamespaceDeclarationGreen)cached;
			var result = new NamespaceDeclarationGreen(TestLexerModeSyntaxKind.NamespaceDeclaration, kNamespace, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GeneratorDeclarationGreen GeneratorDeclaration(InternalSyntaxToken kGenerator, IdentifierGreen identifier, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, InternalSyntaxToken kFor, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kGenerator == null) throw new ArgumentNullException(nameof(kGenerator));
			if (kGenerator.Kind != TestLexerModeSyntaxKind.KGenerator) throw new ArgumentException(nameof(kGenerator));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tColon != null && tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (kFor != null && kFor.Kind != TestLexerModeSyntaxKind.KFor) throw new ArgumentException(nameof(kFor));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new GeneratorDeclarationGreen(TestLexerModeSyntaxKind.GeneratorDeclaration, kGenerator, identifier, tColon, qualifiedName, kFor, typeReference, tSemicolon);
	    }
	
		public UsingNamespaceDeclarationGreen UsingNamespaceDeclaration(InternalSyntaxToken kUsing, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
			if (kUsing.Kind != TestLexerModeSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UsingNamespaceDeclaration, kUsing, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (UsingNamespaceDeclarationGreen)cached;
			var result = new UsingNamespaceDeclarationGreen(TestLexerModeSyntaxKind.UsingNamespaceDeclaration, kUsing, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public UsingGeneratorDeclarationGreen UsingGeneratorDeclaration(InternalSyntaxToken kUsing, InternalSyntaxToken kGenerator, QualifiedNameGreen qualifiedName, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
			if (kUsing.Kind != TestLexerModeSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
			if (kGenerator == null) throw new ArgumentNullException(nameof(kGenerator));
			if (kGenerator.Kind != TestLexerModeSyntaxKind.KGenerator) throw new ArgumentException(nameof(kGenerator));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new UsingGeneratorDeclarationGreen(TestLexerModeSyntaxKind.UsingGeneratorDeclaration, kUsing, kGenerator, qualifiedName, identifier, tSemicolon);
	    }
	
		public ConfigDeclarationGreen ConfigDeclaration(InternalSyntaxToken startProperties, IdentifierGreen identifier, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen> configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties)
	    {
	#if DEBUG
			if (startProperties == null) throw new ArgumentNullException(nameof(startProperties));
			if (startProperties.Kind != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(startProperties));
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (endProperties == null) throw new ArgumentNullException(nameof(endProperties));
			if (endProperties.Kind != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(endProperties));
	#endif
	        return new ConfigDeclarationGreen(TestLexerModeSyntaxKind.ConfigDeclaration, startProperties, identifier, configProperty.Node, kEnd, endProperties);
	    }
	
		public ConfigPropertyDeclarationGreen ConfigPropertyDeclaration(TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tAssign != null && tAssign.Kind != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new ConfigPropertyDeclarationGreen(TestLexerModeSyntaxKind.ConfigPropertyDeclaration, typeReference, identifier, tAssign, expression, tSemicolon);
	    }
	
		public ConfigPropertyGroupDeclarationGreen ConfigPropertyGroupDeclaration(InternalSyntaxToken startProperties, IdentifierGreen identifier, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ConfigPropertyGreen> configProperty, InternalSyntaxToken kEnd, InternalSyntaxToken endProperties)
	    {
	#if DEBUG
			if (startProperties == null) throw new ArgumentNullException(nameof(startProperties));
			if (startProperties.Kind != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(startProperties));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (endProperties == null) throw new ArgumentNullException(nameof(endProperties));
			if (endProperties.Kind != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(endProperties));
	#endif
	        return new ConfigPropertyGroupDeclarationGreen(TestLexerModeSyntaxKind.ConfigPropertyGroupDeclaration, startProperties, identifier, configProperty.Node, kEnd, endProperties);
	    }
	
		public MethodDeclarationGreen MethodDeclaration(FunctionDeclarationGreen functionDeclaration)
	    {
	#if DEBUG
		    if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MethodDeclaration, functionDeclaration, out hash);
			if (cached != null) return (MethodDeclarationGreen)cached;
			var result = new MethodDeclarationGreen(TestLexerModeSyntaxKind.MethodDeclaration, functionDeclaration, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MethodDeclarationGreen MethodDeclaration(TemplateDeclarationGreen templateDeclaration)
	    {
	#if DEBUG
		    if (templateDeclaration == null) throw new ArgumentNullException(nameof(templateDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MethodDeclaration, templateDeclaration, out hash);
			if (cached != null) return (MethodDeclarationGreen)cached;
			var result = new MethodDeclarationGreen(TestLexerModeSyntaxKind.MethodDeclaration, null, templateDeclaration, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MethodDeclarationGreen MethodDeclaration(ExternFunctionDeclarationGreen externFunctionDeclaration)
	    {
	#if DEBUG
		    if (externFunctionDeclaration == null) throw new ArgumentNullException(nameof(externFunctionDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MethodDeclaration, externFunctionDeclaration, out hash);
			if (cached != null) return (MethodDeclarationGreen)cached;
			var result = new MethodDeclarationGreen(TestLexerModeSyntaxKind.MethodDeclaration, null, null, externFunctionDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExternFunctionDeclarationGreen ExternFunctionDeclaration(InternalSyntaxToken kExtern, FunctionSignatureGreen functionSignature)
	    {
	#if DEBUG
			if (kExtern == null) throw new ArgumentNullException(nameof(kExtern));
			if (kExtern.Kind != TestLexerModeSyntaxKind.KExtern) throw new ArgumentException(nameof(kExtern));
			if (functionSignature == null) throw new ArgumentNullException(nameof(functionSignature));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExternFunctionDeclaration, kExtern, functionSignature, out hash);
			if (cached != null) return (ExternFunctionDeclarationGreen)cached;
			var result = new ExternFunctionDeclarationGreen(TestLexerModeSyntaxKind.ExternFunctionDeclaration, kExtern, functionSignature);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FunctionDeclarationGreen FunctionDeclaration(FunctionSignatureGreen functionSignature, BodyGreen body, InternalSyntaxToken kEnd, InternalSyntaxToken kFunction)
	    {
	#if DEBUG
			if (functionSignature == null) throw new ArgumentNullException(nameof(functionSignature));
			if (body == null) throw new ArgumentNullException(nameof(body));
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (kFunction == null) throw new ArgumentNullException(nameof(kFunction));
			if (kFunction.Kind != TestLexerModeSyntaxKind.KFunction) throw new ArgumentException(nameof(kFunction));
	#endif
	        return new FunctionDeclarationGreen(TestLexerModeSyntaxKind.FunctionDeclaration, functionSignature, body, kEnd, kFunction);
	    }
	
		public FunctionSignatureGreen FunctionSignature(InternalSyntaxToken kFunction, ReturnTypeGreen returnType, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kFunction == null) throw new ArgumentNullException(nameof(kFunction));
			if (kFunction.Kind != TestLexerModeSyntaxKind.KFunction) throw new ArgumentException(nameof(kFunction));
			if (returnType == null) throw new ArgumentNullException(nameof(returnType));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new FunctionSignatureGreen(TestLexerModeSyntaxKind.FunctionSignature, kFunction, returnType, identifier, typeArgumentList, tOpenParenthesis, paramList, tCloseParenthesis);
	    }
	
		public ParamListGreen ParamList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ParamList, parameter.Node, out hash);
			if (cached != null) return (ParamListGreen)cached;
			var result = new ParamListGreen(TestLexerModeSyntaxKind.ParamList, parameter.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParameterGreen Parameter(TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tAssign != null && tAssign.Kind != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
	#endif
	        return new ParameterGreen(TestLexerModeSyntaxKind.Parameter, typeReference, identifier, tAssign, expression);
	    }
	
		public BodyGreen Body(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Body, statement.Node, out hash);
			if (cached != null) return (BodyGreen)cached;
			var result = new BodyGreen(TestLexerModeSyntaxKind.Body, statement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StatementGreen Statement(SingleStatementSemicolonGreen singleStatementSemicolon)
	    {
	#if DEBUG
		    if (singleStatementSemicolon == null) throw new ArgumentNullException(nameof(singleStatementSemicolon));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, singleStatementSemicolon, null, null, null, null, null, null);
	    }
	
		public StatementGreen Statement(IfStatementGreen ifStatement)
	    {
	#if DEBUG
		    if (ifStatement == null) throw new ArgumentNullException(nameof(ifStatement));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, null, ifStatement, null, null, null, null, null);
	    }
	
		public StatementGreen Statement(ForStatementGreen forStatement)
	    {
	#if DEBUG
		    if (forStatement == null) throw new ArgumentNullException(nameof(forStatement));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, null, null, forStatement, null, null, null, null);
	    }
	
		public StatementGreen Statement(WhileStatementGreen whileStatement)
	    {
	#if DEBUG
		    if (whileStatement == null) throw new ArgumentNullException(nameof(whileStatement));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, null, null, null, whileStatement, null, null, null);
	    }
	
		public StatementGreen Statement(RepeatStatementGreen repeatStatement)
	    {
	#if DEBUG
		    if (repeatStatement == null) throw new ArgumentNullException(nameof(repeatStatement));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, null, null, null, null, repeatStatement, null, null);
	    }
	
		public StatementGreen Statement(LoopStatementGreen loopStatement)
	    {
	#if DEBUG
		    if (loopStatement == null) throw new ArgumentNullException(nameof(loopStatement));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, null, null, null, null, null, loopStatement, null);
	    }
	
		public StatementGreen Statement(SwitchStatementGreen switchStatement)
	    {
	#if DEBUG
		    if (switchStatement == null) throw new ArgumentNullException(nameof(switchStatement));
	#endif
			return new StatementGreen(TestLexerModeSyntaxKind.Statement, null, null, null, null, null, null, switchStatement);
	    }
	
		public SingleStatementGreen SingleStatement(VariableDeclarationStatementGreen variableDeclarationStatement)
	    {
	#if DEBUG
		    if (variableDeclarationStatement == null) throw new ArgumentNullException(nameof(variableDeclarationStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleStatement, variableDeclarationStatement, out hash);
			if (cached != null) return (SingleStatementGreen)cached;
			var result = new SingleStatementGreen(TestLexerModeSyntaxKind.SingleStatement, variableDeclarationStatement, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SingleStatementGreen SingleStatement(ReturnStatementGreen returnStatement)
	    {
	#if DEBUG
		    if (returnStatement == null) throw new ArgumentNullException(nameof(returnStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleStatement, returnStatement, out hash);
			if (cached != null) return (SingleStatementGreen)cached;
			var result = new SingleStatementGreen(TestLexerModeSyntaxKind.SingleStatement, null, returnStatement, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SingleStatementGreen SingleStatement(ExpressionStatementGreen expressionStatement)
	    {
	#if DEBUG
		    if (expressionStatement == null) throw new ArgumentNullException(nameof(expressionStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleStatement, expressionStatement, out hash);
			if (cached != null) return (SingleStatementGreen)cached;
			var result = new SingleStatementGreen(TestLexerModeSyntaxKind.SingleStatement, null, null, expressionStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SingleStatementSemicolonGreen SingleStatementSemicolon(SingleStatementGreen singleStatement, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (singleStatement == null) throw new ArgumentNullException(nameof(singleStatement));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleStatementSemicolon, singleStatement, tSemicolon, out hash);
			if (cached != null) return (SingleStatementSemicolonGreen)cached;
			var result = new SingleStatementSemicolonGreen(TestLexerModeSyntaxKind.SingleStatementSemicolon, singleStatement, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VariableDeclarationStatementGreen VariableDeclarationStatement(VariableDeclarationExpressionGreen variableDeclarationExpression)
	    {
	#if DEBUG
			if (variableDeclarationExpression == null) throw new ArgumentNullException(nameof(variableDeclarationExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableDeclarationStatement, variableDeclarationExpression, out hash);
			if (cached != null) return (VariableDeclarationStatementGreen)cached;
			var result = new VariableDeclarationStatementGreen(TestLexerModeSyntaxKind.VariableDeclarationStatement, variableDeclarationExpression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VariableDeclarationExpressionGreen VariableDeclarationExpression(TypeReferenceGreen typeReference, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableDeclarationItemGreen> variableDeclarationItem)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableDeclarationExpression, typeReference, variableDeclarationItem.Node, out hash);
			if (cached != null) return (VariableDeclarationExpressionGreen)cached;
			var result = new VariableDeclarationExpressionGreen(TestLexerModeSyntaxKind.VariableDeclarationExpression, typeReference, variableDeclarationItem.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VariableDeclarationItemGreen VariableDeclarationItem(IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tAssign != null && tAssign.Kind != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableDeclarationItem, identifier, tAssign, expression, out hash);
			if (cached != null) return (VariableDeclarationItemGreen)cached;
			var result = new VariableDeclarationItemGreen(TestLexerModeSyntaxKind.VariableDeclarationItem, identifier, tAssign, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VoidStatementGreen VoidStatement(InternalSyntaxToken kVoid, ExpressionGreen expression)
	    {
	#if DEBUG
			if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
			if (kVoid.Kind != TestLexerModeSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VoidStatement, kVoid, expression, out hash);
			if (cached != null) return (VoidStatementGreen)cached;
			var result = new VoidStatementGreen(TestLexerModeSyntaxKind.VoidStatement, kVoid, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnStatementGreen ReturnStatement(InternalSyntaxToken kReturn, ExpressionGreen expression)
	    {
	#if DEBUG
			if (kReturn == null) throw new ArgumentNullException(nameof(kReturn));
			if (kReturn.Kind != TestLexerModeSyntaxKind.KReturn) throw new ArgumentException(nameof(kReturn));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ReturnStatement, kReturn, expression, out hash);
			if (cached != null) return (ReturnStatementGreen)cached;
			var result = new ReturnStatementGreen(TestLexerModeSyntaxKind.ReturnStatement, kReturn, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExpressionStatementGreen ExpressionStatement(ExpressionGreen expression)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExpressionStatement, expression, out hash);
			if (cached != null) return (ExpressionStatementGreen)cached;
			var result = new ExpressionStatementGreen(TestLexerModeSyntaxKind.ExpressionStatement, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IfStatementGreen IfStatement(IfStatementBeginGreen ifStatementBegin, BodyGreen body, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfStatementBodyGreen> elseIfStatementBody, IfStatementElseBodyGreen ifStatementElseBody, IfStatementEndGreen ifStatementEnd)
	    {
	#if DEBUG
			if (ifStatementBegin == null) throw new ArgumentNullException(nameof(ifStatementBegin));
			if (body == null) throw new ArgumentNullException(nameof(body));
			if (ifStatementEnd == null) throw new ArgumentNullException(nameof(ifStatementEnd));
	#endif
	        return new IfStatementGreen(TestLexerModeSyntaxKind.IfStatement, ifStatementBegin, body, elseIfStatementBody.Node, ifStatementElseBody, ifStatementEnd);
	    }
	
		public ElseIfStatementBodyGreen ElseIfStatementBody(ElseIfStatementGreen elseIfStatement, BodyGreen body)
	    {
	#if DEBUG
			if (elseIfStatement == null) throw new ArgumentNullException(nameof(elseIfStatement));
			if (body == null) throw new ArgumentNullException(nameof(body));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ElseIfStatementBody, elseIfStatement, body, out hash);
			if (cached != null) return (ElseIfStatementBodyGreen)cached;
			var result = new ElseIfStatementBodyGreen(TestLexerModeSyntaxKind.ElseIfStatementBody, elseIfStatement, body);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IfStatementElseBodyGreen IfStatementElseBody(IfStatementElseGreen ifStatementElse, BodyGreen body)
	    {
	#if DEBUG
			if (ifStatementElse == null) throw new ArgumentNullException(nameof(ifStatementElse));
			if (body == null) throw new ArgumentNullException(nameof(body));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementElseBody, ifStatementElse, body, out hash);
			if (cached != null) return (IfStatementElseBodyGreen)cached;
			var result = new IfStatementElseBodyGreen(TestLexerModeSyntaxKind.IfStatementElseBody, ifStatementElse, body);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IfStatementBeginGreen IfStatementBegin(InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kIf == null) throw new ArgumentNullException(nameof(kIf));
			if (kIf.Kind != TestLexerModeSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new IfStatementBeginGreen(TestLexerModeSyntaxKind.IfStatementBegin, kIf, tOpenParenthesis, expression, tCloseParenthesis);
	    }
	
		public ElseIfStatementGreen ElseIfStatement(InternalSyntaxToken kElse, InternalSyntaxToken kIf, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kElse == null) throw new ArgumentNullException(nameof(kElse));
			if (kElse.Kind != TestLexerModeSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
			if (kIf == null) throw new ArgumentNullException(nameof(kIf));
			if (kIf.Kind != TestLexerModeSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new ElseIfStatementGreen(TestLexerModeSyntaxKind.ElseIfStatement, kElse, kIf, tOpenParenthesis, expression, tCloseParenthesis);
	    }
	
		public IfStatementElseGreen IfStatementElse(InternalSyntaxToken kElse)
	    {
	#if DEBUG
			if (kElse == null) throw new ArgumentNullException(nameof(kElse));
			if (kElse.Kind != TestLexerModeSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementElse, kElse, out hash);
			if (cached != null) return (IfStatementElseGreen)cached;
			var result = new IfStatementElseGreen(TestLexerModeSyntaxKind.IfStatementElse, kElse);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IfStatementEndGreen IfStatementEnd(InternalSyntaxToken kEnd, InternalSyntaxToken kIf)
	    {
	#if DEBUG
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (kIf == null) throw new ArgumentNullException(nameof(kIf));
			if (kIf.Kind != TestLexerModeSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IfStatementEnd, kEnd, kIf, out hash);
			if (cached != null) return (IfStatementEndGreen)cached;
			var result = new IfStatementEndGreen(TestLexerModeSyntaxKind.IfStatementEnd, kEnd, kIf);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForStatementGreen ForStatement(ForStatementBeginGreen forStatementBegin, BodyGreen body, ForStatementEndGreen forStatementEnd)
	    {
	#if DEBUG
			if (forStatementBegin == null) throw new ArgumentNullException(nameof(forStatementBegin));
			if (body == null) throw new ArgumentNullException(nameof(body));
			if (forStatementEnd == null) throw new ArgumentNullException(nameof(forStatementEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForStatement, forStatementBegin, body, forStatementEnd, out hash);
			if (cached != null) return (ForStatementGreen)cached;
			var result = new ForStatementGreen(TestLexerModeSyntaxKind.ForStatement, forStatementBegin, body, forStatementEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForStatementBeginGreen ForStatementBegin(InternalSyntaxToken kFor, InternalSyntaxToken tOpenParenthesis, ForInitStatementGreen forInitStatement, InternalSyntaxToken semi1, ExpressionListGreen endExpression, InternalSyntaxToken semi2, ExpressionListGreen stepExpression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kFor == null) throw new ArgumentNullException(nameof(kFor));
			if (kFor.Kind != TestLexerModeSyntaxKind.KFor) throw new ArgumentException(nameof(kFor));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (semi1 == null) throw new ArgumentNullException(nameof(semi1));
			if (semi1.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(semi1));
			if (semi2 == null) throw new ArgumentNullException(nameof(semi2));
			if (semi2.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(semi2));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new ForStatementBeginGreen(TestLexerModeSyntaxKind.ForStatementBegin, kFor, tOpenParenthesis, forInitStatement, semi1, endExpression, semi2, stepExpression, tCloseParenthesis);
	    }
	
		public ForStatementEndGreen ForStatementEnd(InternalSyntaxToken kEnd, InternalSyntaxToken kFor)
	    {
	#if DEBUG
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (kFor == null) throw new ArgumentNullException(nameof(kFor));
			if (kFor.Kind != TestLexerModeSyntaxKind.KFor) throw new ArgumentException(nameof(kFor));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForStatementEnd, kEnd, kFor, out hash);
			if (cached != null) return (ForStatementEndGreen)cached;
			var result = new ForStatementEndGreen(TestLexerModeSyntaxKind.ForStatementEnd, kEnd, kFor);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForInitStatementGreen ForInitStatement(VariableDeclarationExpressionGreen variableDeclarationExpression)
	    {
	#if DEBUG
		    if (variableDeclarationExpression == null) throw new ArgumentNullException(nameof(variableDeclarationExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForInitStatement, variableDeclarationExpression, out hash);
			if (cached != null) return (ForInitStatementGreen)cached;
			var result = new ForInitStatementGreen(TestLexerModeSyntaxKind.ForInitStatement, variableDeclarationExpression, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForInitStatementGreen ForInitStatement(ExpressionListGreen expressionList)
	    {
	#if DEBUG
		    if (expressionList == null) throw new ArgumentNullException(nameof(expressionList));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ForInitStatement, expressionList, out hash);
			if (cached != null) return (ForInitStatementGreen)cached;
			var result = new ForInitStatementGreen(TestLexerModeSyntaxKind.ForInitStatement, null, expressionList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WhileStatementGreen WhileStatement(WhileStatementBeginGreen whileStatementBegin, BodyGreen body, WhileStatementEndGreen whileStatementEnd)
	    {
	#if DEBUG
			if (whileStatementBegin == null) throw new ArgumentNullException(nameof(whileStatementBegin));
			if (body == null) throw new ArgumentNullException(nameof(body));
			if (whileStatementEnd == null) throw new ArgumentNullException(nameof(whileStatementEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileStatement, whileStatementBegin, body, whileStatementEnd, out hash);
			if (cached != null) return (WhileStatementGreen)cached;
			var result = new WhileStatementGreen(TestLexerModeSyntaxKind.WhileStatement, whileStatementBegin, body, whileStatementEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WhileStatementBeginGreen WhileStatementBegin(InternalSyntaxToken kWhile, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kWhile == null) throw new ArgumentNullException(nameof(kWhile));
			if (kWhile.Kind != TestLexerModeSyntaxKind.KWhile) throw new ArgumentException(nameof(kWhile));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new WhileStatementBeginGreen(TestLexerModeSyntaxKind.WhileStatementBegin, kWhile, tOpenParenthesis, expression, tCloseParenthesis);
	    }
	
		public WhileStatementEndGreen WhileStatementEnd(InternalSyntaxToken kEnd, InternalSyntaxToken kWhile)
	    {
	#if DEBUG
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (kWhile == null) throw new ArgumentNullException(nameof(kWhile));
			if (kWhile.Kind != TestLexerModeSyntaxKind.KWhile) throw new ArgumentException(nameof(kWhile));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileStatementEnd, kEnd, kWhile, out hash);
			if (cached != null) return (WhileStatementEndGreen)cached;
			var result = new WhileStatementEndGreen(TestLexerModeSyntaxKind.WhileStatementEnd, kEnd, kWhile);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WhileRunExpressionGreen WhileRunExpression(SeparatorStatementGreen separatorStatement)
	    {
	#if DEBUG
			if (separatorStatement == null) throw new ArgumentNullException(nameof(separatorStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.WhileRunExpression, separatorStatement, out hash);
			if (cached != null) return (WhileRunExpressionGreen)cached;
			var result = new WhileRunExpressionGreen(TestLexerModeSyntaxKind.WhileRunExpression, separatorStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RepeatStatementGreen RepeatStatement(RepeatStatementBeginGreen repeatStatementBegin, BodyGreen body, RepeatStatementEndGreen repeatStatementEnd)
	    {
	#if DEBUG
			if (repeatStatementBegin == null) throw new ArgumentNullException(nameof(repeatStatementBegin));
			if (body == null) throw new ArgumentNullException(nameof(body));
			if (repeatStatementEnd == null) throw new ArgumentNullException(nameof(repeatStatementEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatStatement, repeatStatementBegin, body, repeatStatementEnd, out hash);
			if (cached != null) return (RepeatStatementGreen)cached;
			var result = new RepeatStatementGreen(TestLexerModeSyntaxKind.RepeatStatement, repeatStatementBegin, body, repeatStatementEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RepeatStatementBeginGreen RepeatStatementBegin(InternalSyntaxToken kRepeat)
	    {
	#if DEBUG
			if (kRepeat == null) throw new ArgumentNullException(nameof(kRepeat));
			if (kRepeat.Kind != TestLexerModeSyntaxKind.KRepeat) throw new ArgumentException(nameof(kRepeat));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatStatementBegin, kRepeat, out hash);
			if (cached != null) return (RepeatStatementBeginGreen)cached;
			var result = new RepeatStatementBeginGreen(TestLexerModeSyntaxKind.RepeatStatementBegin, kRepeat);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RepeatStatementEndGreen RepeatStatementEnd(InternalSyntaxToken kUntil, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kUntil == null) throw new ArgumentNullException(nameof(kUntil));
			if (kUntil.Kind != TestLexerModeSyntaxKind.KUntil) throw new ArgumentException(nameof(kUntil));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new RepeatStatementEndGreen(TestLexerModeSyntaxKind.RepeatStatementEnd, kUntil, tOpenParenthesis, expression, tCloseParenthesis);
	    }
	
		public RepeatRunExpressionGreen RepeatRunExpression(SeparatorStatementGreen separatorStatement)
	    {
	#if DEBUG
			if (separatorStatement == null) throw new ArgumentNullException(nameof(separatorStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RepeatRunExpression, separatorStatement, out hash);
			if (cached != null) return (RepeatRunExpressionGreen)cached;
			var result = new RepeatRunExpressionGreen(TestLexerModeSyntaxKind.RepeatRunExpression, separatorStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopStatementGreen LoopStatement(LoopStatementBeginGreen loopStatementBegin, BodyGreen body, LoopStatementEndGreen loopStatementEnd)
	    {
	#if DEBUG
			if (loopStatementBegin == null) throw new ArgumentNullException(nameof(loopStatementBegin));
			if (body == null) throw new ArgumentNullException(nameof(body));
			if (loopStatementEnd == null) throw new ArgumentNullException(nameof(loopStatementEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopStatement, loopStatementBegin, body, loopStatementEnd, out hash);
			if (cached != null) return (LoopStatementGreen)cached;
			var result = new LoopStatementGreen(TestLexerModeSyntaxKind.LoopStatement, loopStatementBegin, body, loopStatementEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopStatementBeginGreen LoopStatementBegin(InternalSyntaxToken kLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, LoopRunExpressionGreen loopRunExpression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kLoop == null) throw new ArgumentNullException(nameof(kLoop));
			if (kLoop.Kind != TestLexerModeSyntaxKind.KLoop) throw new ArgumentException(nameof(kLoop));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (loopChain == null) throw new ArgumentNullException(nameof(loopChain));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new LoopStatementBeginGreen(TestLexerModeSyntaxKind.LoopStatementBegin, kLoop, tOpenParenthesis, loopChain, loopWhereExpression, loopRunExpression, tCloseParenthesis);
	    }
	
		public LoopStatementEndGreen LoopStatementEnd(InternalSyntaxToken kEnd, InternalSyntaxToken kLoop)
	    {
	#if DEBUG
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (kLoop == null) throw new ArgumentNullException(nameof(kLoop));
			if (kLoop.Kind != TestLexerModeSyntaxKind.KLoop) throw new ArgumentException(nameof(kLoop));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopStatementEnd, kEnd, kLoop, out hash);
			if (cached != null) return (LoopStatementEndGreen)cached;
			var result = new LoopStatementEndGreen(TestLexerModeSyntaxKind.LoopStatementEnd, kEnd, kLoop);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopChainGreen LoopChain(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LoopChainItemGreen> loopChainItem)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChain, loopChainItem.Node, out hash);
			if (cached != null) return (LoopChainGreen)cached;
			var result = new LoopChainGreen(TestLexerModeSyntaxKind.LoopChain, loopChainItem.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopChainItemGreen LoopChainItem(TypeReferenceGreen typeReference, IdentifierGreen identifier, InternalSyntaxToken tColon, LoopChainExpressionGreen loopChainExpression)
	    {
	#if DEBUG
			if (tColon != null && tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (loopChainExpression == null) throw new ArgumentNullException(nameof(loopChainExpression));
	#endif
	        return new LoopChainItemGreen(TestLexerModeSyntaxKind.LoopChainItem, typeReference, identifier, tColon, loopChainExpression);
	    }
	
		public LoopChainTypeofExpressionGreen LoopChainTypeofExpression(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
			if (kTypeof.Kind != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new LoopChainTypeofExpressionGreen(TestLexerModeSyntaxKind.LoopChainTypeofExpression, kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
	    }
	
		public LoopChainIdentifierExpressionGreen LoopChainIdentifierExpression(IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopChainIdentifierExpression, identifier, typeArgumentList, out hash);
			if (cached != null) return (LoopChainIdentifierExpressionGreen)cached;
			var result = new LoopChainIdentifierExpressionGreen(TestLexerModeSyntaxKind.LoopChainIdentifierExpression, identifier, typeArgumentList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopChainMemberAccessExpressionGreen LoopChainMemberAccessExpression(LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	#if DEBUG
			if (loopChainExpression == null) throw new ArgumentNullException(nameof(loopChainExpression));
			if (tDot == null) throw new ArgumentNullException(nameof(tDot));
			if (tDot.Kind != TestLexerModeSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
	        return new LoopChainMemberAccessExpressionGreen(TestLexerModeSyntaxKind.LoopChainMemberAccessExpression, loopChainExpression, tDot, identifier, typeArgumentList);
	    }
	
		public LoopChainMethodCallExpressionGreen LoopChainMethodCallExpression(LoopChainExpressionGreen loopChainExpression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (loopChainExpression == null) throw new ArgumentNullException(nameof(loopChainExpression));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new LoopChainMethodCallExpressionGreen(TestLexerModeSyntaxKind.LoopChainMethodCallExpression, loopChainExpression, tOpenParenthesis, expressionList, tCloseParenthesis);
	    }
	
		public LoopWhereExpressionGreen LoopWhereExpression(InternalSyntaxToken kWhere, ExpressionGreen expression)
	    {
	#if DEBUG
			if (kWhere == null) throw new ArgumentNullException(nameof(kWhere));
			if (kWhere.Kind != TestLexerModeSyntaxKind.KWhere) throw new ArgumentException(nameof(kWhere));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopWhereExpression, kWhere, expression, out hash);
			if (cached != null) return (LoopWhereExpressionGreen)cached;
			var result = new LoopWhereExpressionGreen(TestLexerModeSyntaxKind.LoopWhereExpression, kWhere, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopRunExpressionGreen LoopRunExpression(SeparatorStatementGreen separatorStatement)
	    {
	#if DEBUG
			if (separatorStatement == null) throw new ArgumentNullException(nameof(separatorStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LoopRunExpression, separatorStatement, out hash);
			if (cached != null) return (LoopRunExpressionGreen)cached;
			var result = new LoopRunExpressionGreen(TestLexerModeSyntaxKind.LoopRunExpression, separatorStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SeparatorStatementGreen SeparatorStatement(InternalSyntaxToken tSemicolon, InternalSyntaxToken kSeparator, IdentifierGreen identifier, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (kSeparator == null) throw new ArgumentNullException(nameof(kSeparator));
			if (kSeparator.Kind != TestLexerModeSyntaxKind.KSeparator) throw new ArgumentException(nameof(kSeparator));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
	        return new SeparatorStatementGreen(TestLexerModeSyntaxKind.SeparatorStatement, tSemicolon, kSeparator, identifier, tAssign, stringLiteral);
	    }
	
		public SwitchStatementGreen SwitchStatement(SwitchStatementBeginGreen switchStatementBegin, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchBranchStatementGreen> switchBranchStatement, SwitchDefaultStatementGreen switchDefaultStatement, SwitchStatementEndGreen switchStatementEnd)
	    {
	#if DEBUG
			if (switchStatementBegin == null) throw new ArgumentNullException(nameof(switchStatementBegin));
			if (switchStatementEnd == null) throw new ArgumentNullException(nameof(switchStatementEnd));
	#endif
	        return new SwitchStatementGreen(TestLexerModeSyntaxKind.SwitchStatement, switchStatementBegin, switchBranchStatement.Node, switchDefaultStatement, switchStatementEnd);
	    }
	
		public SwitchStatementBeginGreen SwitchStatementBegin(InternalSyntaxToken kSwitch, InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kSwitch == null) throw new ArgumentNullException(nameof(kSwitch));
			if (kSwitch.Kind != TestLexerModeSyntaxKind.KSwitch) throw new ArgumentException(nameof(kSwitch));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new SwitchStatementBeginGreen(TestLexerModeSyntaxKind.SwitchStatementBegin, kSwitch, tOpenParenthesis, expression, tCloseParenthesis);
	    }
	
		public SwitchStatementEndGreen SwitchStatementEnd(InternalSyntaxToken kEnd, InternalSyntaxToken kSwitch)
	    {
	#if DEBUG
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
			if (kSwitch == null) throw new ArgumentNullException(nameof(kSwitch));
			if (kSwitch.Kind != TestLexerModeSyntaxKind.KSwitch) throw new ArgumentException(nameof(kSwitch));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchStatementEnd, kEnd, kSwitch, out hash);
			if (cached != null) return (SwitchStatementEndGreen)cached;
			var result = new SwitchStatementEndGreen(TestLexerModeSyntaxKind.SwitchStatementEnd, kEnd, kSwitch);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchBranchStatementGreen SwitchBranchStatement(SwitchBranchHeadStatementGreen switchBranchHeadStatement, BodyGreen body)
	    {
	#if DEBUG
			if (switchBranchHeadStatement == null) throw new ArgumentNullException(nameof(switchBranchHeadStatement));
			if (body == null) throw new ArgumentNullException(nameof(body));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchBranchStatement, switchBranchHeadStatement, body, out hash);
			if (cached != null) return (SwitchBranchStatementGreen)cached;
			var result = new SwitchBranchStatementGreen(TestLexerModeSyntaxKind.SwitchBranchStatement, switchBranchHeadStatement, body);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchBranchHeadStatementGreen SwitchBranchHeadStatement(SwitchCaseOrTypeIsHeadStatementsGreen switchCaseOrTypeIsHeadStatements)
	    {
	#if DEBUG
		    if (switchCaseOrTypeIsHeadStatements == null) throw new ArgumentNullException(nameof(switchCaseOrTypeIsHeadStatements));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchBranchHeadStatement, switchCaseOrTypeIsHeadStatements, out hash);
			if (cached != null) return (SwitchBranchHeadStatementGreen)cached;
			var result = new SwitchBranchHeadStatementGreen(TestLexerModeSyntaxKind.SwitchBranchHeadStatement, switchCaseOrTypeIsHeadStatements, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchBranchHeadStatementGreen SwitchBranchHeadStatement(SwitchTypeAsHeadStatementGreen switchTypeAsHeadStatement)
	    {
	#if DEBUG
		    if (switchTypeAsHeadStatement == null) throw new ArgumentNullException(nameof(switchTypeAsHeadStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchBranchHeadStatement, switchTypeAsHeadStatement, out hash);
			if (cached != null) return (SwitchBranchHeadStatementGreen)cached;
			var result = new SwitchBranchHeadStatementGreen(TestLexerModeSyntaxKind.SwitchBranchHeadStatement, null, switchTypeAsHeadStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchCaseOrTypeIsHeadStatementsGreen SwitchCaseOrTypeIsHeadStatements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SwitchCaseOrTypeIsHeadStatementGreen> switchCaseOrTypeIsHeadStatement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatements, switchCaseOrTypeIsHeadStatement.Node, out hash);
			if (cached != null) return (SwitchCaseOrTypeIsHeadStatementsGreen)cached;
			var result = new SwitchCaseOrTypeIsHeadStatementsGreen(TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatements, switchCaseOrTypeIsHeadStatement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchCaseOrTypeIsHeadStatementGreen SwitchCaseOrTypeIsHeadStatement(SwitchCaseHeadStatementGreen switchCaseHeadStatement)
	    {
	#if DEBUG
		    if (switchCaseHeadStatement == null) throw new ArgumentNullException(nameof(switchCaseHeadStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatement, switchCaseHeadStatement, out hash);
			if (cached != null) return (SwitchCaseOrTypeIsHeadStatementGreen)cached;
			var result = new SwitchCaseOrTypeIsHeadStatementGreen(TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatement, switchCaseHeadStatement, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchCaseOrTypeIsHeadStatementGreen SwitchCaseOrTypeIsHeadStatement(SwitchTypeIsHeadStatementGreen switchTypeIsHeadStatement)
	    {
	#if DEBUG
		    if (switchTypeIsHeadStatement == null) throw new ArgumentNullException(nameof(switchTypeIsHeadStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatement, switchTypeIsHeadStatement, out hash);
			if (cached != null) return (SwitchCaseOrTypeIsHeadStatementGreen)cached;
			var result = new SwitchCaseOrTypeIsHeadStatementGreen(TestLexerModeSyntaxKind.SwitchCaseOrTypeIsHeadStatement, null, switchTypeIsHeadStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchCaseHeadStatementGreen SwitchCaseHeadStatement(InternalSyntaxToken kCase, ExpressionListGreen expressionList, InternalSyntaxToken tColon)
	    {
	#if DEBUG
			if (kCase == null) throw new ArgumentNullException(nameof(kCase));
			if (kCase.Kind != TestLexerModeSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
			if (expressionList == null) throw new ArgumentNullException(nameof(expressionList));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchCaseHeadStatement, kCase, expressionList, tColon, out hash);
			if (cached != null) return (SwitchCaseHeadStatementGreen)cached;
			var result = new SwitchCaseHeadStatementGreen(TestLexerModeSyntaxKind.SwitchCaseHeadStatement, kCase, expressionList, tColon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchTypeIsHeadStatementGreen SwitchTypeIsHeadStatement(InternalSyntaxToken kType, InternalSyntaxToken kIs, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tColon)
	    {
	#if DEBUG
			if (kType == null) throw new ArgumentNullException(nameof(kType));
			if (kType.Kind != TestLexerModeSyntaxKind.KType) throw new ArgumentException(nameof(kType));
			if (kIs == null) throw new ArgumentNullException(nameof(kIs));
			if (kIs.Kind != TestLexerModeSyntaxKind.KIs) throw new ArgumentException(nameof(kIs));
			if (typeReferenceList == null) throw new ArgumentNullException(nameof(typeReferenceList));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
	        return new SwitchTypeIsHeadStatementGreen(TestLexerModeSyntaxKind.SwitchTypeIsHeadStatement, kType, kIs, typeReferenceList, tColon);
	    }
	
		public SwitchTypeAsHeadStatementGreen SwitchTypeAsHeadStatement(InternalSyntaxToken kType, InternalSyntaxToken kAs, TypeReferenceGreen typeReference, InternalSyntaxToken tColon)
	    {
	#if DEBUG
			if (kType == null) throw new ArgumentNullException(nameof(kType));
			if (kType.Kind != TestLexerModeSyntaxKind.KType) throw new ArgumentException(nameof(kType));
			if (kAs == null) throw new ArgumentNullException(nameof(kAs));
			if (kAs.Kind != TestLexerModeSyntaxKind.KAs) throw new ArgumentException(nameof(kAs));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
	        return new SwitchTypeAsHeadStatementGreen(TestLexerModeSyntaxKind.SwitchTypeAsHeadStatement, kType, kAs, typeReference, tColon);
	    }
	
		public SwitchDefaultStatementGreen SwitchDefaultStatement(SwitchDefaultHeadStatementGreen switchDefaultHeadStatement, BodyGreen body)
	    {
	#if DEBUG
			if (switchDefaultHeadStatement == null) throw new ArgumentNullException(nameof(switchDefaultHeadStatement));
			if (body == null) throw new ArgumentNullException(nameof(body));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchDefaultStatement, switchDefaultHeadStatement, body, out hash);
			if (cached != null) return (SwitchDefaultStatementGreen)cached;
			var result = new SwitchDefaultStatementGreen(TestLexerModeSyntaxKind.SwitchDefaultStatement, switchDefaultHeadStatement, body);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SwitchDefaultHeadStatementGreen SwitchDefaultHeadStatement(InternalSyntaxToken kDefault, InternalSyntaxToken tColon)
	    {
	#if DEBUG
			if (kDefault == null) throw new ArgumentNullException(nameof(kDefault));
			if (kDefault.Kind != TestLexerModeSyntaxKind.KDefault) throw new ArgumentException(nameof(kDefault));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SwitchDefaultHeadStatement, kDefault, tColon, out hash);
			if (cached != null) return (SwitchDefaultHeadStatementGreen)cached;
			var result = new SwitchDefaultHeadStatementGreen(TestLexerModeSyntaxKind.SwitchDefaultHeadStatement, kDefault, tColon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateDeclarationGreen TemplateDeclaration(TemplateSignatureGreen templateSignature, TemplateBodyGreen templateBody, InternalSyntaxToken kEndTemplate)
	    {
	#if DEBUG
			if (templateSignature == null) throw new ArgumentNullException(nameof(templateSignature));
			if (templateBody == null) throw new ArgumentNullException(nameof(templateBody));
			if (kEndTemplate == null) throw new ArgumentNullException(nameof(kEndTemplate));
			if (kEndTemplate.Kind != TestLexerModeSyntaxKind.KEndTemplate) throw new ArgumentException(nameof(kEndTemplate));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateDeclaration, templateSignature, templateBody, kEndTemplate, out hash);
			if (cached != null) return (TemplateDeclarationGreen)cached;
			var result = new TemplateDeclarationGreen(TestLexerModeSyntaxKind.TemplateDeclaration, templateSignature, templateBody, kEndTemplate);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateSignatureGreen TemplateSignature(InternalSyntaxToken kTemplate, IdentifierGreen identifier, InternalSyntaxToken tOpenParenthesis, ParamListGreen paramList, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kTemplate == null) throw new ArgumentNullException(nameof(kTemplate));
			if (kTemplate.Kind != TestLexerModeSyntaxKind.KTemplate) throw new ArgumentException(nameof(kTemplate));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new TemplateSignatureGreen(TestLexerModeSyntaxKind.TemplateSignature, kTemplate, identifier, tOpenParenthesis, paramList, tCloseParenthesis);
	    }
	
		public TemplateBodyGreen TemplateBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentLineGreen> templateContentLine)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateBody, templateContentLine.Node, out hash);
			if (cached != null) return (TemplateBodyGreen)cached;
			var result = new TemplateBodyGreen(TestLexerModeSyntaxKind.TemplateBody, templateContentLine.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateContentLineGreen TemplateContentLine(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TemplateContentGreen> templateContent, TemplateLineEndGreen templateLineEnd)
	    {
	#if DEBUG
			if (templateLineEnd == null) throw new ArgumentNullException(nameof(templateLineEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateContentLine, templateContent.Node, templateLineEnd, out hash);
			if (cached != null) return (TemplateContentLineGreen)cached;
			var result = new TemplateContentLineGreen(TestLexerModeSyntaxKind.TemplateContentLine, templateContent.Node, templateLineEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateContentGreen TemplateContent(TemplateOutputGreen templateOutput)
	    {
	#if DEBUG
		    if (templateOutput == null) throw new ArgumentNullException(nameof(templateOutput));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateContent, templateOutput, out hash);
			if (cached != null) return (TemplateContentGreen)cached;
			var result = new TemplateContentGreen(TestLexerModeSyntaxKind.TemplateContent, templateOutput, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateContentGreen TemplateContent(TemplateStatementStartEndGreen templateStatementStartEnd)
	    {
	#if DEBUG
		    if (templateStatementStartEnd == null) throw new ArgumentNullException(nameof(templateStatementStartEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateContent, templateStatementStartEnd, out hash);
			if (cached != null) return (TemplateContentGreen)cached;
			var result = new TemplateContentGreen(TestLexerModeSyntaxKind.TemplateContent, null, templateStatementStartEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateOutputGreen TemplateOutput(InternalSyntaxToken lTemplateOutput)
	    {
	#if DEBUG
			if (lTemplateOutput == null) throw new ArgumentNullException(nameof(lTemplateOutput));
			if (lTemplateOutput.Kind != TestLexerModeSyntaxKind.LTemplateOutput) throw new ArgumentException(nameof(lTemplateOutput));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateOutput, lTemplateOutput, out hash);
			if (cached != null) return (TemplateOutputGreen)cached;
			var result = new TemplateOutputGreen(TestLexerModeSyntaxKind.TemplateOutput, lTemplateOutput);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateLineEndGreen TemplateLineEnd(InternalSyntaxToken templateLineEnd)
	    {
	#if DEBUG
			if (templateLineEnd == null) throw new ArgumentNullException(nameof(templateLineEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateLineEnd, templateLineEnd, out hash);
			if (cached != null) return (TemplateLineEndGreen)cached;
			var result = new TemplateLineEndGreen(TestLexerModeSyntaxKind.TemplateLineEnd, templateLineEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateStatementStartEndGreen TemplateStatementStartEnd(InternalSyntaxToken tTemplateStatementStart, TemplateStatementGreen templateStatement, InternalSyntaxToken tTemplateStatementEnd)
	    {
	#if DEBUG
			if (tTemplateStatementStart == null) throw new ArgumentNullException(nameof(tTemplateStatementStart));
			if (tTemplateStatementStart.Kind != TestLexerModeSyntaxKind.TTemplateStatementStart) throw new ArgumentException(nameof(tTemplateStatementStart));
			if (tTemplateStatementEnd == null) throw new ArgumentNullException(nameof(tTemplateStatementEnd));
			if (tTemplateStatementEnd.Kind != TestLexerModeSyntaxKind.TTemplateStatementEnd) throw new ArgumentException(nameof(tTemplateStatementEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TemplateStatementStartEnd, tTemplateStatementStart, templateStatement, tTemplateStatementEnd, out hash);
			if (cached != null) return (TemplateStatementStartEndGreen)cached;
			var result = new TemplateStatementStartEndGreen(TestLexerModeSyntaxKind.TemplateStatementStartEnd, tTemplateStatementStart, templateStatement, tTemplateStatementEnd);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TemplateStatementGreen TemplateStatement(VoidStatementGreen voidStatement)
	    {
	#if DEBUG
		    if (voidStatement == null) throw new ArgumentNullException(nameof(voidStatement));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, voidStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(VariableDeclarationStatementGreen variableDeclarationStatement)
	    {
	#if DEBUG
		    if (variableDeclarationStatement == null) throw new ArgumentNullException(nameof(variableDeclarationStatement));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, variableDeclarationStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(ExpressionStatementGreen expressionStatement)
	    {
	#if DEBUG
		    if (expressionStatement == null) throw new ArgumentNullException(nameof(expressionStatement));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, expressionStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(IfStatementBeginGreen ifStatementBegin)
	    {
	#if DEBUG
		    if (ifStatementBegin == null) throw new ArgumentNullException(nameof(ifStatementBegin));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, ifStatementBegin, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(ElseIfStatementGreen elseIfStatement)
	    {
	#if DEBUG
		    if (elseIfStatement == null) throw new ArgumentNullException(nameof(elseIfStatement));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, elseIfStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(IfStatementElseGreen ifStatementElse)
	    {
	#if DEBUG
		    if (ifStatementElse == null) throw new ArgumentNullException(nameof(ifStatementElse));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, ifStatementElse, null, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(IfStatementEndGreen ifStatementEnd)
	    {
	#if DEBUG
		    if (ifStatementEnd == null) throw new ArgumentNullException(nameof(ifStatementEnd));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, ifStatementEnd, null, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(ForStatementBeginGreen forStatementBegin)
	    {
	#if DEBUG
		    if (forStatementBegin == null) throw new ArgumentNullException(nameof(forStatementBegin));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, forStatementBegin, null, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(ForStatementEndGreen forStatementEnd)
	    {
	#if DEBUG
		    if (forStatementEnd == null) throw new ArgumentNullException(nameof(forStatementEnd));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, forStatementEnd, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(WhileStatementBeginGreen whileStatementBegin)
	    {
	#if DEBUG
		    if (whileStatementBegin == null) throw new ArgumentNullException(nameof(whileStatementBegin));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, whileStatementBegin, null, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(WhileStatementEndGreen whileStatementEnd)
	    {
	#if DEBUG
		    if (whileStatementEnd == null) throw new ArgumentNullException(nameof(whileStatementEnd));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, whileStatementEnd, null, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(RepeatStatementBeginGreen repeatStatementBegin)
	    {
	#if DEBUG
		    if (repeatStatementBegin == null) throw new ArgumentNullException(nameof(repeatStatementBegin));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, repeatStatementBegin, null, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(RepeatStatementEndGreen repeatStatementEnd)
	    {
	#if DEBUG
		    if (repeatStatementEnd == null) throw new ArgumentNullException(nameof(repeatStatementEnd));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, repeatStatementEnd, null, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(LoopStatementBeginGreen loopStatementBegin)
	    {
	#if DEBUG
		    if (loopStatementBegin == null) throw new ArgumentNullException(nameof(loopStatementBegin));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, loopStatementBegin, null, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(LoopStatementEndGreen loopStatementEnd)
	    {
	#if DEBUG
		    if (loopStatementEnd == null) throw new ArgumentNullException(nameof(loopStatementEnd));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, loopStatementEnd, null, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(SwitchStatementBeginGreen switchStatementBegin)
	    {
	#if DEBUG
		    if (switchStatementBegin == null) throw new ArgumentNullException(nameof(switchStatementBegin));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, switchStatementBegin, null, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(SwitchStatementEndGreen switchStatementEnd)
	    {
	#if DEBUG
		    if (switchStatementEnd == null) throw new ArgumentNullException(nameof(switchStatementEnd));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, switchStatementEnd, null, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(SwitchBranchHeadStatementGreen switchBranchHeadStatement)
	    {
	#if DEBUG
		    if (switchBranchHeadStatement == null) throw new ArgumentNullException(nameof(switchBranchHeadStatement));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, switchBranchHeadStatement, null);
	    }
	
		public TemplateStatementGreen TemplateStatement(SwitchDefaultHeadStatementGreen switchDefaultHeadStatement)
	    {
	#if DEBUG
		    if (switchDefaultHeadStatement == null) throw new ArgumentNullException(nameof(switchDefaultHeadStatement));
	#endif
			return new TemplateStatementGreen(TestLexerModeSyntaxKind.TemplateStatement, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, switchDefaultHeadStatement);
	    }
	
		public TypeArgumentListGreen TypeArgumentList(InternalSyntaxToken tLessThan, TypeReferenceListGreen typeReferenceList, InternalSyntaxToken tGreaterThan)
	    {
	#if DEBUG
			if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
			if (tLessThan.Kind != TestLexerModeSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
			if (typeReferenceList == null) throw new ArgumentNullException(nameof(typeReferenceList));
			if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
			if (tGreaterThan.Kind != TestLexerModeSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeArgumentList, tLessThan, typeReferenceList, tGreaterThan, out hash);
			if (cached != null) return (TypeArgumentListGreen)cached;
			var result = new TypeArgumentListGreen(TestLexerModeSyntaxKind.TypeArgumentList, tLessThan, typeReferenceList, tGreaterThan);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PredefinedTypeGreen PredefinedType(InternalSyntaxToken predefinedType)
	    {
	#if DEBUG
			if (predefinedType == null) throw new ArgumentNullException(nameof(predefinedType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.PredefinedType, predefinedType, out hash);
			if (cached != null) return (PredefinedTypeGreen)cached;
			var result = new PredefinedTypeGreen(TestLexerModeSyntaxKind.PredefinedType, predefinedType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceListGreen TypeReferenceList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen> typeReference)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypeReferenceList, typeReference.Node, out hash);
			if (cached != null) return (TypeReferenceListGreen)cached;
			var result = new TypeReferenceListGreen(TestLexerModeSyntaxKind.TypeReferenceList, typeReference.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(ArrayTypeGreen arrayType)
	    {
	#if DEBUG
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
	#endif
			return new TypeReferenceGreen(TestLexerModeSyntaxKind.TypeReference, arrayType, null, null, null);
	    }
	
		public TypeReferenceGreen TypeReference(NullableTypeGreen nullableType)
	    {
	#if DEBUG
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
	#endif
			return new TypeReferenceGreen(TestLexerModeSyntaxKind.TypeReference, null, nullableType, null, null);
	    }
	
		public TypeReferenceGreen TypeReference(GenericTypeGreen genericType)
	    {
	#if DEBUG
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
	#endif
			return new TypeReferenceGreen(TestLexerModeSyntaxKind.TypeReference, null, null, genericType, null);
	    }
	
		public TypeReferenceGreen TypeReference(SimpleTypeGreen simpleType)
	    {
	#if DEBUG
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
	#endif
			return new TypeReferenceGreen(TestLexerModeSyntaxKind.TypeReference, null, null, null, simpleType);
	    }
	
		public ArrayTypeGreen ArrayType(ArrayItemTypeGreen arrayItemType, RankSpecifiersGreen rankSpecifiers)
	    {
	#if DEBUG
			if (arrayItemType == null) throw new ArgumentNullException(nameof(arrayItemType));
			if (rankSpecifiers == null) throw new ArgumentNullException(nameof(rankSpecifiers));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ArrayType, arrayItemType, rankSpecifiers, out hash);
			if (cached != null) return (ArrayTypeGreen)cached;
			var result = new ArrayTypeGreen(TestLexerModeSyntaxKind.ArrayType, arrayItemType, rankSpecifiers);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayItemTypeGreen ArrayItemType(NullableTypeGreen nullableType)
	    {
	#if DEBUG
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ArrayItemType, nullableType, out hash);
			if (cached != null) return (ArrayItemTypeGreen)cached;
			var result = new ArrayItemTypeGreen(TestLexerModeSyntaxKind.ArrayItemType, nullableType, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayItemTypeGreen ArrayItemType(GenericTypeGreen genericType)
	    {
	#if DEBUG
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ArrayItemType, genericType, out hash);
			if (cached != null) return (ArrayItemTypeGreen)cached;
			var result = new ArrayItemTypeGreen(TestLexerModeSyntaxKind.ArrayItemType, null, genericType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayItemTypeGreen ArrayItemType(SimpleTypeGreen simpleType)
	    {
	#if DEBUG
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ArrayItemType, simpleType, out hash);
			if (cached != null) return (ArrayItemTypeGreen)cached;
			var result = new ArrayItemTypeGreen(TestLexerModeSyntaxKind.ArrayItemType, null, null, simpleType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableTypeGreen NullableType(NullableItemTypeGreen nullableItemType, InternalSyntaxToken tQuestion)
	    {
	#if DEBUG
			if (nullableItemType == null) throw new ArgumentNullException(nameof(nullableItemType));
			if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
			if (tQuestion.Kind != TestLexerModeSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullableType, nullableItemType, tQuestion, out hash);
			if (cached != null) return (NullableTypeGreen)cached;
			var result = new NullableTypeGreen(TestLexerModeSyntaxKind.NullableType, nullableItemType, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableItemTypeGreen NullableItemType(GenericTypeGreen genericType)
	    {
	#if DEBUG
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullableItemType, genericType, out hash);
			if (cached != null) return (NullableItemTypeGreen)cached;
			var result = new NullableItemTypeGreen(TestLexerModeSyntaxKind.NullableItemType, genericType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableItemTypeGreen NullableItemType(SimpleTypeGreen simpleType)
	    {
	#if DEBUG
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullableItemType, simpleType, out hash);
			if (cached != null) return (NullableItemTypeGreen)cached;
			var result = new NullableItemTypeGreen(TestLexerModeSyntaxKind.NullableItemType, null, simpleType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericTypeGreen GenericType(QualifiedNameGreen qualifiedName, TypeArgumentListGreen typeArgumentList)
	    {
	#if DEBUG
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (typeArgumentList == null) throw new ArgumentNullException(nameof(typeArgumentList));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GenericType, qualifiedName, typeArgumentList, out hash);
			if (cached != null) return (GenericTypeGreen)cached;
			var result = new GenericTypeGreen(TestLexerModeSyntaxKind.GenericType, qualifiedName, typeArgumentList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(QualifiedNameGreen qualifiedName)
	    {
	#if DEBUG
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SimpleType, qualifiedName, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(TestLexerModeSyntaxKind.SimpleType, qualifiedName, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(PredefinedTypeGreen predefinedType)
	    {
	#if DEBUG
		    if (predefinedType == null) throw new ArgumentNullException(nameof(predefinedType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SimpleType, predefinedType, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(TestLexerModeSyntaxKind.SimpleType, null, predefinedType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VoidTypeGreen VoidType(InternalSyntaxToken kVoid)
	    {
	#if DEBUG
			if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
			if (kVoid.Kind != TestLexerModeSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(TestLexerModeSyntaxKind.VoidType, kVoid);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnTypeGreen ReturnType(TypeReferenceGreen typeReference)
	    {
	#if DEBUG
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(TestLexerModeSyntaxKind.ReturnType, typeReference, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnTypeGreen ReturnType(VoidTypeGreen voidType)
	    {
	#if DEBUG
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(TestLexerModeSyntaxKind.ReturnType, null, voidType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExpressionListGreen ExpressionList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> expression)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExpressionList, expression.Node, out hash);
			if (cached != null) return (ExpressionListGreen)cached;
			var result = new ExpressionListGreen(TestLexerModeSyntaxKind.ExpressionList, expression.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VariableReferenceGreen VariableReference(ExpressionGreen expression)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.VariableReference, expression, out hash);
			if (cached != null) return (VariableReferenceGreen)cached;
			var result = new VariableReferenceGreen(TestLexerModeSyntaxKind.VariableReference, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RankSpecifiersGreen RankSpecifiers(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RankSpecifierGreen> rankSpecifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RankSpecifiers, rankSpecifier.Node, out hash);
			if (cached != null) return (RankSpecifiersGreen)cached;
			var result = new RankSpecifiersGreen(TestLexerModeSyntaxKind.RankSpecifiers, rankSpecifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RankSpecifierGreen RankSpecifier(InternalSyntaxToken tOpenBracket, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> tComma, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != TestLexerModeSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != TestLexerModeSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RankSpecifier, tOpenBracket, tComma.Node, tCloseBracket, out hash);
			if (cached != null) return (RankSpecifierGreen)cached;
			var result = new RankSpecifierGreen(TestLexerModeSyntaxKind.RankSpecifier, tOpenBracket, tComma.Node, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public UnboundTypeNameGreen UnboundTypeName(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericDimensionItemGreen> genericDimensionItem)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UnboundTypeName, genericDimensionItem.Node, out hash);
			if (cached != null) return (UnboundTypeNameGreen)cached;
			var result = new UnboundTypeNameGreen(TestLexerModeSyntaxKind.UnboundTypeName, genericDimensionItem.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericDimensionItemGreen GenericDimensionItem(IdentifierGreen identifier, GenericDimensionSpecifierGreen genericDimensionSpecifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GenericDimensionItem, identifier, genericDimensionSpecifier, out hash);
			if (cached != null) return (GenericDimensionItemGreen)cached;
			var result = new GenericDimensionItemGreen(TestLexerModeSyntaxKind.GenericDimensionItem, identifier, genericDimensionSpecifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericDimensionSpecifierGreen GenericDimensionSpecifier(InternalSyntaxToken tLessThan, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> tComma, InternalSyntaxToken tGreaterThan)
	    {
	#if DEBUG
			if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
			if (tLessThan.Kind != TestLexerModeSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
			if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
			if (tGreaterThan.Kind != TestLexerModeSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GenericDimensionSpecifier, tLessThan, tComma.Node, tGreaterThan, out hash);
			if (cached != null) return (GenericDimensionSpecifierGreen)cached;
			var result = new GenericDimensionSpecifierGreen(TestLexerModeSyntaxKind.GenericDimensionSpecifier, tLessThan, tComma.Node, tGreaterThan);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExplicitAnonymousFunctionSignatureGreen ExplicitAnonymousFunctionSignature(InternalSyntaxToken tOpenParenthesis, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen> explicitParameter, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExplicitAnonymousFunctionSignature, tOpenParenthesis, explicitParameter.Node, tCloseParenthesis, out hash);
			if (cached != null) return (ExplicitAnonymousFunctionSignatureGreen)cached;
			var result = new ExplicitAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind.ExplicitAnonymousFunctionSignature, tOpenParenthesis, explicitParameter.Node, tCloseParenthesis);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ImplicitAnonymousFunctionSignatureGreen ImplicitAnonymousFunctionSignature(InternalSyntaxToken tOpenParenthesis, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen> implicitParameter, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ImplicitAnonymousFunctionSignature, tOpenParenthesis, implicitParameter.Node, tCloseParenthesis, out hash);
			if (cached != null) return (ImplicitAnonymousFunctionSignatureGreen)cached;
			var result = new ImplicitAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind.ImplicitAnonymousFunctionSignature, tOpenParenthesis, implicitParameter.Node, tCloseParenthesis);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SingleParamAnonymousFunctionSignatureGreen SingleParamAnonymousFunctionSignature(ImplicitParameterGreen implicitParameter)
	    {
	#if DEBUG
			if (implicitParameter == null) throw new ArgumentNullException(nameof(implicitParameter));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.SingleParamAnonymousFunctionSignature, implicitParameter, out hash);
			if (cached != null) return (SingleParamAnonymousFunctionSignatureGreen)cached;
			var result = new SingleParamAnonymousFunctionSignatureGreen(TestLexerModeSyntaxKind.SingleParamAnonymousFunctionSignature, implicitParameter);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExplicitParameterGreen ExplicitParameter(TypeReferenceGreen typeReference, IdentifierGreen identifier)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ExplicitParameter, typeReference, identifier, out hash);
			if (cached != null) return (ExplicitParameterGreen)cached;
			var result = new ExplicitParameterGreen(TestLexerModeSyntaxKind.ExplicitParameter, typeReference, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ImplicitParameterGreen ImplicitParameter(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ImplicitParameter, identifier, out hash);
			if (cached != null) return (ImplicitParameterGreen)cached;
			var result = new ImplicitParameterGreen(TestLexerModeSyntaxKind.ImplicitParameter, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ThisExpressionGreen ThisExpression(InternalSyntaxToken kThis)
	    {
	#if DEBUG
			if (kThis == null) throw new ArgumentNullException(nameof(kThis));
			if (kThis.Kind != TestLexerModeSyntaxKind.KThis) throw new ArgumentException(nameof(kThis));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ThisExpression, kThis, out hash);
			if (cached != null) return (ThisExpressionGreen)cached;
			var result = new ThisExpressionGreen(TestLexerModeSyntaxKind.ThisExpression, kThis);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LiteralExpressionGreen LiteralExpression(LiteralGreen literal)
	    {
	#if DEBUG
			if (literal == null) throw new ArgumentNullException(nameof(literal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LiteralExpression, literal, out hash);
			if (cached != null) return (LiteralExpressionGreen)cached;
			var result = new LiteralExpressionGreen(TestLexerModeSyntaxKind.LiteralExpression, literal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeofVoidExpressionGreen TypeofVoidExpression(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, InternalSyntaxToken kVoid, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
			if (kTypeof.Kind != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
			if (kVoid.Kind != TestLexerModeSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new TypeofVoidExpressionGreen(TestLexerModeSyntaxKind.TypeofVoidExpression, kTypeof, tOpenParenthesis, kVoid, tCloseParenthesis);
	    }
	
		public TypeofUnboundTypeExpressionGreen TypeofUnboundTypeExpression(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, UnboundTypeNameGreen unboundTypeName, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
			if (kTypeof.Kind != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (unboundTypeName == null) throw new ArgumentNullException(nameof(unboundTypeName));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new TypeofUnboundTypeExpressionGreen(TestLexerModeSyntaxKind.TypeofUnboundTypeExpression, kTypeof, tOpenParenthesis, unboundTypeName, tCloseParenthesis);
	    }
	
		public TypeofTypeExpressionGreen TypeofTypeExpression(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
			if (kTypeof.Kind != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new TypeofTypeExpressionGreen(TestLexerModeSyntaxKind.TypeofTypeExpression, kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
	    }
	
		public DefaultValueExpressionGreen DefaultValueExpression(InternalSyntaxToken kDefault, InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kDefault == null) throw new ArgumentNullException(nameof(kDefault));
			if (kDefault.Kind != TestLexerModeSyntaxKind.KDefault) throw new ArgumentException(nameof(kDefault));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new DefaultValueExpressionGreen(TestLexerModeSyntaxKind.DefaultValueExpression, kDefault, tOpenParenthesis, typeReference, tCloseParenthesis);
	    }
	
		public NewObjectOrCollectionWithConstructorExpressionGreen NewObjectOrCollectionWithConstructorExpression(InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kNew == null) throw new ArgumentNullException(nameof(kNew));
			if (kNew.Kind != TestLexerModeSyntaxKind.KNew) throw new ArgumentException(nameof(kNew));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new NewObjectOrCollectionWithConstructorExpressionGreen(TestLexerModeSyntaxKind.NewObjectOrCollectionWithConstructorExpression, kNew, typeReference, tOpenParenthesis, expressionList, tCloseParenthesis);
	    }
	
		public IdentifierExpressionGreen IdentifierExpression(IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IdentifierExpression, identifier, typeArgumentList, out hash);
			if (cached != null) return (IdentifierExpressionGreen)cached;
			var result = new IdentifierExpressionGreen(TestLexerModeSyntaxKind.IdentifierExpression, identifier, typeArgumentList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HasLoopExpressionGreen HasLoopExpression(InternalSyntaxToken kHasLoop, InternalSyntaxToken tOpenParenthesis, LoopChainGreen loopChain, LoopWhereExpressionGreen loopWhereExpression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (kHasLoop == null) throw new ArgumentNullException(nameof(kHasLoop));
			if (kHasLoop.Kind != TestLexerModeSyntaxKind.KHasLoop) throw new ArgumentException(nameof(kHasLoop));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (loopChain == null) throw new ArgumentNullException(nameof(loopChain));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new HasLoopExpressionGreen(TestLexerModeSyntaxKind.HasLoopExpression, kHasLoop, tOpenParenthesis, loopChain, loopWhereExpression, tCloseParenthesis);
	    }
	
		public ParenthesizedExpressionGreen ParenthesizedExpression(InternalSyntaxToken tOpenParenthesis, ExpressionGreen expression, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ParenthesizedExpression, tOpenParenthesis, expression, tCloseParenthesis, out hash);
			if (cached != null) return (ParenthesizedExpressionGreen)cached;
			var result = new ParenthesizedExpressionGreen(TestLexerModeSyntaxKind.ParenthesizedExpression, tOpenParenthesis, expression, tCloseParenthesis);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementAccessExpressionGreen ElementAccessExpression(ExpressionGreen expression, InternalSyntaxToken tOpenBracket, ExpressionListGreen expressionList, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != TestLexerModeSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (expressionList == null) throw new ArgumentNullException(nameof(expressionList));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != TestLexerModeSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
	        return new ElementAccessExpressionGreen(TestLexerModeSyntaxKind.ElementAccessExpression, expression, tOpenBracket, expressionList, tCloseBracket);
	    }
	
		public FunctionCallExpressionGreen FunctionCallExpression(ExpressionGreen expression, InternalSyntaxToken tOpenParenthesis, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParenthesis)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
	#endif
	        return new FunctionCallExpressionGreen(TestLexerModeSyntaxKind.FunctionCallExpression, expression, tOpenParenthesis, expressionList, tCloseParenthesis);
	    }
	
		public PredefinedTypeMemberAccessExpressionGreen PredefinedTypeMemberAccessExpression(PredefinedTypeGreen predefinedType, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	#if DEBUG
			if (predefinedType == null) throw new ArgumentNullException(nameof(predefinedType));
			if (tDot == null) throw new ArgumentNullException(nameof(tDot));
			if (tDot.Kind != TestLexerModeSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
	        return new PredefinedTypeMemberAccessExpressionGreen(TestLexerModeSyntaxKind.PredefinedTypeMemberAccessExpression, predefinedType, tDot, identifier, typeArgumentList);
	    }
	
		public MemberAccessExpressionGreen MemberAccessExpression(ExpressionGreen expression, InternalSyntaxToken tDot, IdentifierGreen identifier, TypeArgumentListGreen typeArgumentList)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tDot == null) throw new ArgumentNullException(nameof(tDot));
			if (tDot.Kind != TestLexerModeSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
	        return new MemberAccessExpressionGreen(TestLexerModeSyntaxKind.MemberAccessExpression, expression, tDot, identifier, typeArgumentList);
	    }
	
		public TypecastExpressionGreen TypecastExpression(InternalSyntaxToken tOpenParenthesis, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParenthesis, ExpressionGreen expression)
	    {
	#if DEBUG
			if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
			if (tOpenParenthesis.Kind != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
			if (tCloseParenthesis.Kind != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
	        return new TypecastExpressionGreen(TestLexerModeSyntaxKind.TypecastExpression, tOpenParenthesis, typeReference, tCloseParenthesis, expression);
	    }
	
		public UnaryExpressionGreen UnaryExpression(InternalSyntaxToken op, ExpressionGreen expression)
	    {
	#if DEBUG
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.UnaryExpression, op, expression, out hash);
			if (cached != null) return (UnaryExpressionGreen)cached;
			var result = new UnaryExpressionGreen(TestLexerModeSyntaxKind.UnaryExpression, op, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PostExpressionGreen PostExpression(ExpressionGreen expression, InternalSyntaxToken op)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (op == null) throw new ArgumentNullException(nameof(op));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.PostExpression, expression, op, out hash);
			if (cached != null) return (PostExpressionGreen)cached;
			var result = new PostExpressionGreen(TestLexerModeSyntaxKind.PostExpression, expression, op);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MultiplicationExpressionGreen MultiplicationExpression(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.MultiplicationExpression, left, op, right, out hash);
			if (cached != null) return (MultiplicationExpressionGreen)cached;
			var result = new MultiplicationExpressionGreen(TestLexerModeSyntaxKind.MultiplicationExpression, left, op, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AdditionExpressionGreen AdditionExpression(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.AdditionExpression, left, op, right, out hash);
			if (cached != null) return (AdditionExpressionGreen)cached;
			var result = new AdditionExpressionGreen(TestLexerModeSyntaxKind.AdditionExpression, left, op, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RelationalExpressionGreen RelationalExpression(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.RelationalExpression, left, op, right, out hash);
			if (cached != null) return (RelationalExpressionGreen)cached;
			var result = new RelationalExpressionGreen(TestLexerModeSyntaxKind.RelationalExpression, left, op, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypecheckExpressionGreen TypecheckExpression(ExpressionGreen left, InternalSyntaxToken op, TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TypecheckExpression, left, op, typeReference, out hash);
			if (cached != null) return (TypecheckExpressionGreen)cached;
			var result = new TypecheckExpressionGreen(TestLexerModeSyntaxKind.TypecheckExpression, left, op, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EqualityExpressionGreen EqualityExpression(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.EqualityExpression, left, op, right, out hash);
			if (cached != null) return (EqualityExpressionGreen)cached;
			var result = new EqualityExpressionGreen(TestLexerModeSyntaxKind.EqualityExpression, left, op, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BitwiseAndExpressionGreen BitwiseAndExpression(ExpressionGreen left, InternalSyntaxToken tAmp, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tAmp == null) throw new ArgumentNullException(nameof(tAmp));
			if (tAmp.Kind != TestLexerModeSyntaxKind.TAmp) throw new ArgumentException(nameof(tAmp));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BitwiseAndExpression, left, tAmp, right, out hash);
			if (cached != null) return (BitwiseAndExpressionGreen)cached;
			var result = new BitwiseAndExpressionGreen(TestLexerModeSyntaxKind.BitwiseAndExpression, left, tAmp, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BitwiseXorExpressionGreen BitwiseXorExpression(ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tHat == null) throw new ArgumentNullException(nameof(tHat));
			if (tHat.Kind != TestLexerModeSyntaxKind.THat) throw new ArgumentException(nameof(tHat));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BitwiseXorExpression, left, tHat, right, out hash);
			if (cached != null) return (BitwiseXorExpressionGreen)cached;
			var result = new BitwiseXorExpressionGreen(TestLexerModeSyntaxKind.BitwiseXorExpression, left, tHat, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BitwiseOrExpressionGreen BitwiseOrExpression(ExpressionGreen left, InternalSyntaxToken tPipe, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tPipe == null) throw new ArgumentNullException(nameof(tPipe));
			if (tPipe.Kind != TestLexerModeSyntaxKind.TPipe) throw new ArgumentException(nameof(tPipe));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BitwiseOrExpression, left, tPipe, right, out hash);
			if (cached != null) return (BitwiseOrExpressionGreen)cached;
			var result = new BitwiseOrExpressionGreen(TestLexerModeSyntaxKind.BitwiseOrExpression, left, tPipe, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LogicalAndExpressionGreen LogicalAndExpression(ExpressionGreen left, InternalSyntaxToken tAnd, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tAnd == null) throw new ArgumentNullException(nameof(tAnd));
			if (tAnd.Kind != TestLexerModeSyntaxKind.TAnd) throw new ArgumentException(nameof(tAnd));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LogicalAndExpression, left, tAnd, right, out hash);
			if (cached != null) return (LogicalAndExpressionGreen)cached;
			var result = new LogicalAndExpressionGreen(TestLexerModeSyntaxKind.LogicalAndExpression, left, tAnd, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LogicalXorExpressionGreen LogicalXorExpression(ExpressionGreen left, InternalSyntaxToken tXor, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tXor == null) throw new ArgumentNullException(nameof(tXor));
			if (tXor.Kind != TestLexerModeSyntaxKind.TXor) throw new ArgumentException(nameof(tXor));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LogicalXorExpression, left, tXor, right, out hash);
			if (cached != null) return (LogicalXorExpressionGreen)cached;
			var result = new LogicalXorExpressionGreen(TestLexerModeSyntaxKind.LogicalXorExpression, left, tXor, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LogicalOrExpressionGreen LogicalOrExpression(ExpressionGreen left, InternalSyntaxToken tOr, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tOr == null) throw new ArgumentNullException(nameof(tOr));
			if (tOr.Kind != TestLexerModeSyntaxKind.TOr) throw new ArgumentException(nameof(tOr));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LogicalOrExpression, left, tOr, right, out hash);
			if (cached != null) return (LogicalOrExpressionGreen)cached;
			var result = new LogicalOrExpressionGreen(TestLexerModeSyntaxKind.LogicalOrExpression, left, tOr, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConditionalExpressionGreen ConditionalExpression(ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen thenBranch, InternalSyntaxToken tColon, ExpressionGreen elseBranch)
	    {
	#if DEBUG
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
			if (tQuestion.Kind != TestLexerModeSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
			if (thenBranch == null) throw new ArgumentNullException(nameof(thenBranch));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (elseBranch == null) throw new ArgumentNullException(nameof(elseBranch));
	#endif
	        return new ConditionalExpressionGreen(TestLexerModeSyntaxKind.ConditionalExpression, condition, tQuestion, thenBranch, tColon, elseBranch);
	    }
	
		public AssignmentExpressionGreen AssignmentExpression(ExpressionGreen left, InternalSyntaxToken op, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.AssignmentExpression, left, op, right, out hash);
			if (cached != null) return (AssignmentExpressionGreen)cached;
			var result = new AssignmentExpressionGreen(TestLexerModeSyntaxKind.AssignmentExpression, left, op, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LambdaExpressionGreen LambdaExpression(AnonymousFunctionSignatureGreen anonymousFunctionSignature, InternalSyntaxToken tArrow, ExpressionGreen expression)
	    {
	#if DEBUG
			if (anonymousFunctionSignature == null) throw new ArgumentNullException(nameof(anonymousFunctionSignature));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLexerModeSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.LambdaExpression, anonymousFunctionSignature, tArrow, expression, out hash);
			if (cached != null) return (LambdaExpressionGreen)cached;
			var result = new LambdaExpressionGreen(TestLexerModeSyntaxKind.LambdaExpression, anonymousFunctionSignature, tArrow, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameGreen QualifiedName(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.QualifiedName, identifier.Node, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(TestLexerModeSyntaxKind.QualifiedName, identifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierListGreen IdentifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IdentifierList, identifier.Node, out hash);
			if (cached != null) return (IdentifierListGreen)cached;
			var result = new IdentifierListGreen(TestLexerModeSyntaxKind.IdentifierList, identifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken identifierNormal)
	    {
	#if DEBUG
			if (identifierNormal == null) throw new ArgumentNullException(nameof(identifierNormal));
			if (identifierNormal.Kind != TestLexerModeSyntaxKind.IdentifierNormal) throw new ArgumentException(nameof(identifierNormal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.Identifier, identifierNormal, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(TestLexerModeSyntaxKind.Identifier, identifierNormal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LiteralGreen Literal(NullLiteralGreen nullLiteral)
	    {
	#if DEBUG
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, nullLiteral, null, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, null, booleanLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(NumberLiteralGreen numberLiteral)
	    {
	#if DEBUG
		    if (numberLiteral == null) throw new ArgumentNullException(nameof(numberLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, null, null, numberLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(DateOrTimeLiteralGreen dateOrTimeLiteral)
	    {
	#if DEBUG
		    if (dateOrTimeLiteral == null) throw new ArgumentNullException(nameof(dateOrTimeLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, null, null, null, dateOrTimeLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(CharLiteralGreen charLiteral)
	    {
	#if DEBUG
		    if (charLiteral == null) throw new ArgumentNullException(nameof(charLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, null, null, null, null, charLiteral, null, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, null, null, null, null, null, stringLiteral, null);
	    }
	
		public LiteralGreen Literal(GuidLiteralGreen guidLiteral)
	    {
	#if DEBUG
		    if (guidLiteral == null) throw new ArgumentNullException(nameof(guidLiteral));
	#endif
			return new LiteralGreen(TestLexerModeSyntaxKind.Literal, null, null, null, null, null, null, guidLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != TestLexerModeSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(TestLexerModeSyntaxKind.NullLiteral, kNull);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BooleanLiteralGreen BooleanLiteral(InternalSyntaxToken booleanLiteral)
	    {
	#if DEBUG
			if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(TestLexerModeSyntaxKind.BooleanLiteral, booleanLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NumberLiteralGreen NumberLiteral(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NumberLiteral, integerLiteral, out hash);
			if (cached != null) return (NumberLiteralGreen)cached;
			var result = new NumberLiteralGreen(TestLexerModeSyntaxKind.NumberLiteral, integerLiteral, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NumberLiteralGreen NumberLiteral(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NumberLiteral, decimalLiteral, out hash);
			if (cached != null) return (NumberLiteralGreen)cached;
			var result = new NumberLiteralGreen(TestLexerModeSyntaxKind.NumberLiteral, null, decimalLiteral, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NumberLiteralGreen NumberLiteral(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.NumberLiteral, scientificLiteral, out hash);
			if (cached != null) return (NumberLiteralGreen)cached;
			var result = new NumberLiteralGreen(TestLexerModeSyntaxKind.NumberLiteral, null, null, scientificLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IntegerLiteralGreen IntegerLiteral(InternalSyntaxToken lInteger)
	    {
	#if DEBUG
			if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
			if (lInteger.Kind != TestLexerModeSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(TestLexerModeSyntaxKind.IntegerLiteral, lInteger);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DecimalLiteralGreen DecimalLiteral(InternalSyntaxToken lDecimal)
	    {
	#if DEBUG
			if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
			if (lDecimal.Kind != TestLexerModeSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(TestLexerModeSyntaxKind.DecimalLiteral, lDecimal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ScientificLiteralGreen ScientificLiteral(InternalSyntaxToken lScientific)
	    {
	#if DEBUG
			if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
			if (lScientific.Kind != TestLexerModeSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(TestLexerModeSyntaxKind.ScientificLiteral, lScientific);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DateOrTimeLiteralGreen DateOrTimeLiteral(DateTimeLiteralGreen dateTimeLiteral)
	    {
	#if DEBUG
		    if (dateTimeLiteral == null) throw new ArgumentNullException(nameof(dateTimeLiteral));
	#endif
			return new DateOrTimeLiteralGreen(TestLexerModeSyntaxKind.DateOrTimeLiteral, dateTimeLiteral, null, null, null);
	    }
	
		public DateOrTimeLiteralGreen DateOrTimeLiteral(DateTimeOffsetLiteralGreen dateTimeOffsetLiteral)
	    {
	#if DEBUG
		    if (dateTimeOffsetLiteral == null) throw new ArgumentNullException(nameof(dateTimeOffsetLiteral));
	#endif
			return new DateOrTimeLiteralGreen(TestLexerModeSyntaxKind.DateOrTimeLiteral, null, dateTimeOffsetLiteral, null, null);
	    }
	
		public DateOrTimeLiteralGreen DateOrTimeLiteral(DateLiteralGreen dateLiteral)
	    {
	#if DEBUG
		    if (dateLiteral == null) throw new ArgumentNullException(nameof(dateLiteral));
	#endif
			return new DateOrTimeLiteralGreen(TestLexerModeSyntaxKind.DateOrTimeLiteral, null, null, dateLiteral, null);
	    }
	
		public DateOrTimeLiteralGreen DateOrTimeLiteral(TimeLiteralGreen timeLiteral)
	    {
	#if DEBUG
		    if (timeLiteral == null) throw new ArgumentNullException(nameof(timeLiteral));
	#endif
			return new DateOrTimeLiteralGreen(TestLexerModeSyntaxKind.DateOrTimeLiteral, null, null, null, timeLiteral);
	    }
	
		public DateTimeOffsetLiteralGreen DateTimeOffsetLiteral(InternalSyntaxToken lDateTimeOffset)
	    {
	#if DEBUG
			if (lDateTimeOffset == null) throw new ArgumentNullException(nameof(lDateTimeOffset));
			if (lDateTimeOffset.Kind != TestLexerModeSyntaxKind.LDateTimeOffset) throw new ArgumentException(nameof(lDateTimeOffset));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateTimeOffsetLiteral, lDateTimeOffset, out hash);
			if (cached != null) return (DateTimeOffsetLiteralGreen)cached;
			var result = new DateTimeOffsetLiteralGreen(TestLexerModeSyntaxKind.DateTimeOffsetLiteral, lDateTimeOffset);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DateTimeLiteralGreen DateTimeLiteral(InternalSyntaxToken lDateTime)
	    {
	#if DEBUG
			if (lDateTime == null) throw new ArgumentNullException(nameof(lDateTime));
			if (lDateTime.Kind != TestLexerModeSyntaxKind.LDateTime) throw new ArgumentException(nameof(lDateTime));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateTimeLiteral, lDateTime, out hash);
			if (cached != null) return (DateTimeLiteralGreen)cached;
			var result = new DateTimeLiteralGreen(TestLexerModeSyntaxKind.DateTimeLiteral, lDateTime);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DateLiteralGreen DateLiteral(InternalSyntaxToken lDate)
	    {
	#if DEBUG
			if (lDate == null) throw new ArgumentNullException(nameof(lDate));
			if (lDate.Kind != TestLexerModeSyntaxKind.LDate) throw new ArgumentException(nameof(lDate));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.DateLiteral, lDate, out hash);
			if (cached != null) return (DateLiteralGreen)cached;
			var result = new DateLiteralGreen(TestLexerModeSyntaxKind.DateLiteral, lDate);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TimeLiteralGreen TimeLiteral(InternalSyntaxToken lTime)
	    {
	#if DEBUG
			if (lTime == null) throw new ArgumentNullException(nameof(lTime));
			if (lTime.Kind != TestLexerModeSyntaxKind.LTime) throw new ArgumentException(nameof(lTime));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.TimeLiteral, lTime, out hash);
			if (cached != null) return (TimeLiteralGreen)cached;
			var result = new TimeLiteralGreen(TestLexerModeSyntaxKind.TimeLiteral, lTime);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CharLiteralGreen CharLiteral(InternalSyntaxToken lChar)
	    {
	#if DEBUG
			if (lChar == null) throw new ArgumentNullException(nameof(lChar));
			if (lChar.Kind != TestLexerModeSyntaxKind.LChar) throw new ArgumentException(nameof(lChar));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.CharLiteral, lChar, out hash);
			if (cached != null) return (CharLiteralGreen)cached;
			var result = new CharLiteralGreen(TestLexerModeSyntaxKind.CharLiteral, lChar);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringLiteralGreen StringLiteral(InternalSyntaxToken stringLiteral)
	    {
	#if DEBUG
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.StringLiteral, stringLiteral, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(TestLexerModeSyntaxKind.StringLiteral, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GuidLiteralGreen GuidLiteral(InternalSyntaxToken lGuid)
	    {
	#if DEBUG
			if (lGuid == null) throw new ArgumentNullException(nameof(lGuid));
			if (lGuid.Kind != TestLexerModeSyntaxKind.LGuid) throw new ArgumentException(nameof(lGuid));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLexerModeSyntaxKind)TestLexerModeSyntaxKind.GuidLiteral, lGuid, out hash);
			if (cached != null) return (GuidLiteralGreen)cached;
			var result = new GuidLiteralGreen(TestLexerModeSyntaxKind.GuidLiteral, lGuid);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainGreen),
				typeof(NamespaceDeclarationGreen),
				typeof(GeneratorDeclarationGreen),
				typeof(UsingNamespaceDeclarationGreen),
				typeof(UsingGeneratorDeclarationGreen),
				typeof(ConfigDeclarationGreen),
				typeof(ConfigPropertyDeclarationGreen),
				typeof(ConfigPropertyGroupDeclarationGreen),
				typeof(MethodDeclarationGreen),
				typeof(ExternFunctionDeclarationGreen),
				typeof(FunctionDeclarationGreen),
				typeof(FunctionSignatureGreen),
				typeof(ParamListGreen),
				typeof(ParameterGreen),
				typeof(BodyGreen),
				typeof(StatementGreen),
				typeof(SingleStatementGreen),
				typeof(SingleStatementSemicolonGreen),
				typeof(VariableDeclarationStatementGreen),
				typeof(VariableDeclarationExpressionGreen),
				typeof(VariableDeclarationItemGreen),
				typeof(VoidStatementGreen),
				typeof(ReturnStatementGreen),
				typeof(ExpressionStatementGreen),
				typeof(IfStatementGreen),
				typeof(ElseIfStatementBodyGreen),
				typeof(IfStatementElseBodyGreen),
				typeof(IfStatementBeginGreen),
				typeof(ElseIfStatementGreen),
				typeof(IfStatementElseGreen),
				typeof(IfStatementEndGreen),
				typeof(ForStatementGreen),
				typeof(ForStatementBeginGreen),
				typeof(ForStatementEndGreen),
				typeof(ForInitStatementGreen),
				typeof(WhileStatementGreen),
				typeof(WhileStatementBeginGreen),
				typeof(WhileStatementEndGreen),
				typeof(WhileRunExpressionGreen),
				typeof(RepeatStatementGreen),
				typeof(RepeatStatementBeginGreen),
				typeof(RepeatStatementEndGreen),
				typeof(RepeatRunExpressionGreen),
				typeof(LoopStatementGreen),
				typeof(LoopStatementBeginGreen),
				typeof(LoopStatementEndGreen),
				typeof(LoopChainGreen),
				typeof(LoopChainItemGreen),
				typeof(LoopChainTypeofExpressionGreen),
				typeof(LoopChainIdentifierExpressionGreen),
				typeof(LoopChainMemberAccessExpressionGreen),
				typeof(LoopChainMethodCallExpressionGreen),
				typeof(LoopWhereExpressionGreen),
				typeof(LoopRunExpressionGreen),
				typeof(SeparatorStatementGreen),
				typeof(SwitchStatementGreen),
				typeof(SwitchStatementBeginGreen),
				typeof(SwitchStatementEndGreen),
				typeof(SwitchBranchStatementGreen),
				typeof(SwitchBranchHeadStatementGreen),
				typeof(SwitchCaseOrTypeIsHeadStatementsGreen),
				typeof(SwitchCaseOrTypeIsHeadStatementGreen),
				typeof(SwitchCaseHeadStatementGreen),
				typeof(SwitchTypeIsHeadStatementGreen),
				typeof(SwitchTypeAsHeadStatementGreen),
				typeof(SwitchDefaultStatementGreen),
				typeof(SwitchDefaultHeadStatementGreen),
				typeof(TemplateDeclarationGreen),
				typeof(TemplateSignatureGreen),
				typeof(TemplateBodyGreen),
				typeof(TemplateContentLineGreen),
				typeof(TemplateContentGreen),
				typeof(TemplateOutputGreen),
				typeof(TemplateLineEndGreen),
				typeof(TemplateStatementStartEndGreen),
				typeof(TemplateStatementGreen),
				typeof(TypeArgumentListGreen),
				typeof(PredefinedTypeGreen),
				typeof(TypeReferenceListGreen),
				typeof(TypeReferenceGreen),
				typeof(ArrayTypeGreen),
				typeof(ArrayItemTypeGreen),
				typeof(NullableTypeGreen),
				typeof(NullableItemTypeGreen),
				typeof(GenericTypeGreen),
				typeof(SimpleTypeGreen),
				typeof(VoidTypeGreen),
				typeof(ReturnTypeGreen),
				typeof(ExpressionListGreen),
				typeof(VariableReferenceGreen),
				typeof(RankSpecifiersGreen),
				typeof(RankSpecifierGreen),
				typeof(UnboundTypeNameGreen),
				typeof(GenericDimensionItemGreen),
				typeof(GenericDimensionSpecifierGreen),
				typeof(ExplicitAnonymousFunctionSignatureGreen),
				typeof(ImplicitAnonymousFunctionSignatureGreen),
				typeof(SingleParamAnonymousFunctionSignatureGreen),
				typeof(ExplicitParameterGreen),
				typeof(ImplicitParameterGreen),
				typeof(ThisExpressionGreen),
				typeof(LiteralExpressionGreen),
				typeof(TypeofVoidExpressionGreen),
				typeof(TypeofUnboundTypeExpressionGreen),
				typeof(TypeofTypeExpressionGreen),
				typeof(DefaultValueExpressionGreen),
				typeof(NewObjectOrCollectionWithConstructorExpressionGreen),
				typeof(IdentifierExpressionGreen),
				typeof(HasLoopExpressionGreen),
				typeof(ParenthesizedExpressionGreen),
				typeof(ElementAccessExpressionGreen),
				typeof(FunctionCallExpressionGreen),
				typeof(PredefinedTypeMemberAccessExpressionGreen),
				typeof(MemberAccessExpressionGreen),
				typeof(TypecastExpressionGreen),
				typeof(UnaryExpressionGreen),
				typeof(PostExpressionGreen),
				typeof(MultiplicationExpressionGreen),
				typeof(AdditionExpressionGreen),
				typeof(RelationalExpressionGreen),
				typeof(TypecheckExpressionGreen),
				typeof(EqualityExpressionGreen),
				typeof(BitwiseAndExpressionGreen),
				typeof(BitwiseXorExpressionGreen),
				typeof(BitwiseOrExpressionGreen),
				typeof(LogicalAndExpressionGreen),
				typeof(LogicalXorExpressionGreen),
				typeof(LogicalOrExpressionGreen),
				typeof(ConditionalExpressionGreen),
				typeof(AssignmentExpressionGreen),
				typeof(LambdaExpressionGreen),
				typeof(QualifiedNameGreen),
				typeof(IdentifierListGreen),
				typeof(IdentifierGreen),
				typeof(LiteralGreen),
				typeof(NullLiteralGreen),
				typeof(BooleanLiteralGreen),
				typeof(NumberLiteralGreen),
				typeof(IntegerLiteralGreen),
				typeof(DecimalLiteralGreen),
				typeof(ScientificLiteralGreen),
				typeof(DateOrTimeLiteralGreen),
				typeof(DateTimeOffsetLiteralGreen),
				typeof(DateTimeLiteralGreen),
				typeof(DateLiteralGreen),
				typeof(TimeLiteralGreen),
				typeof(CharLiteralGreen),
				typeof(StringLiteralGreen),
				typeof(GuidLiteralGreen),
			};
		}
	}
}


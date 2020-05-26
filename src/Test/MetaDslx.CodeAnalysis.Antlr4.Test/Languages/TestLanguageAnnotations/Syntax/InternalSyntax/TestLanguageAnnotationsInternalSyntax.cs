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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax
{
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
            if (visitor is TestLanguageAnnotationsSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is TestLanguageAnnotationsSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor);
        public abstract void Accept(TestLanguageAnnotationsSyntaxVisitor visitor);

        public new TestLanguageAnnotationsLanguage Language => TestLanguageAnnotationsLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestLanguageAnnotationsSyntaxKind Kind => (TestLanguageAnnotationsSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

		// Use conditional weak table so we always return same identity for structured trivia
		private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
			= new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

		/// <summary>
		/// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
		/// determine if this trivia has structure.
		/// </summary>
		/// <returns>
		/// A TestLanguageAnnotationsSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
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
							structure = TestLanguageAnnotationsStructuredTriviaSyntax.Create(trivia);
							structsInParent.Add(trivia, structure);
						}
					}

					return structure;
				}
				else
				{
					return TestLanguageAnnotationsStructuredTriviaSyntax.Create(trivia);
				}
			}

			return null;
		}

	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(TestLanguageAnnotationsSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new TestLanguageAnnotationsLanguage Language => TestLanguageAnnotationsLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestLanguageAnnotationsSyntaxKind Kind => EnumObject.FromIntUnsafe<TestLanguageAnnotationsSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(TestLanguageAnnotationsSyntaxKind kind, string text)
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
        internal GreenStructuredTriviaSyntax(TestLanguageAnnotationsSyntaxKind kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        internal GreenSkippedTokensTriviaSyntax(TestLanguageAnnotationsSyntaxKind kind, GreenNode tokens, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position) => new TestLanguageAnnotationsSkippedTokensTriviaSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);

        public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitSkippedTokensTrivia(this);

        public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitSkippedTokensTrivia(this);

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
	    internal GreenSyntaxToken(TestLanguageAnnotationsSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(TestLanguageAnnotationsSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(TestLanguageAnnotationsSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(TestLanguageAnnotationsSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(TestLanguageAnnotationsSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(TestLanguageAnnotationsSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new TestLanguageAnnotationsLanguage Language => TestLanguageAnnotationsLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new TestLanguageAnnotationsSyntaxKind Kind => EnumObject.FromIntUnsafe<TestLanguageAnnotationsSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(TestLanguageAnnotationsSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid TestLanguageAnnotationsSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid TestLanguageAnnotationsSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly TestLanguageAnnotationsSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly TestLanguageAnnotationsSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = TestLanguageAnnotationsSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = TestLanguageAnnotationsSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((TestLanguageAnnotationsSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((TestLanguageAnnotationsSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((TestLanguageAnnotationsSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((TestLanguageAnnotationsSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(TestLanguageAnnotationsSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(TestLanguageAnnotationsSyntaxKind kind, TestLanguageAnnotationsSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(TestLanguageAnnotationsSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual TestLanguageAnnotationsSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(TestLanguageAnnotationsSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(TestLanguageAnnotationsSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly TestLanguageAnnotationsSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(TestLanguageAnnotationsSyntaxKind kind, TestLanguageAnnotationsSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(TestLanguageAnnotationsSyntaxKind kind, TestLanguageAnnotationsSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<TestLanguageAnnotationsSyntaxKind>(reader.ReadInt32());
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
	        public override TestLanguageAnnotationsSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(TestLanguageAnnotationsSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(TestLanguageAnnotationsSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            TestLanguageAnnotationsSyntaxKind kind,
	            TestLanguageAnnotationsSyntaxKind contextualKind,
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
	            TestLanguageAnnotationsSyntaxKind kind,
	            TestLanguageAnnotationsSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(TestLanguageAnnotationsSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(TestLanguageAnnotationsSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(TestLanguageAnnotationsSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            TestLanguageAnnotationsSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(TestLanguageAnnotationsSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    private GreenNode test;
	    private InternalSyntaxToken eOF;
	
	    public MainGreen(TestLanguageAnnotationsSyntaxKind kind, GreenNode test, InternalSyntaxToken eOF)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (test != null)
			{
				this.AdjustFlagsAndWidth(test);
				this.test = test;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
	    public MainGreen(TestLanguageAnnotationsSyntaxKind kind, GreenNode test, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (test != null)
			{
				this.AdjustFlagsAndWidth(test);
				this.test = test;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
		private MainGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TestGreen> Test { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TestGreen>(this.test); } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.MainSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.test;
	            case 1: return this.eOF;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.test, this.eOF, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.test, this.eOF, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TestGreen> test, InternalSyntaxToken eOF)
	    {
	        if (this.Test != test ||
				this.EndOfFileToken != eOF)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Main(test, eOF);
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
	
	internal class TestGreen : GreenSyntaxNode
	{
	    internal static readonly TestGreen __Missing = new TestGreen();
	    private Test01Green test01;
	    private Test02Green test02;
	    private Test03Green test03;
	    private Test04Green test04;
	    private Test05Green test05;
	    private Test06Green test06;
	    private Test07Green test07;
	    private Test08Green test08;
	    private Test09Green test09;
	    private Test10Green test10;
	    private Test11Green test11;
	
	    public TestGreen(TestLanguageAnnotationsSyntaxKind kind, Test01Green test01, Test02Green test02, Test03Green test03, Test04Green test04, Test05Green test05, Test06Green test06, Test07Green test07, Test08Green test08, Test09Green test09, Test10Green test10, Test11Green test11)
	        : base(kind, null, null)
	    {
			this.SlotCount = 11;
			if (test01 != null)
			{
				this.AdjustFlagsAndWidth(test01);
				this.test01 = test01;
			}
			if (test02 != null)
			{
				this.AdjustFlagsAndWidth(test02);
				this.test02 = test02;
			}
			if (test03 != null)
			{
				this.AdjustFlagsAndWidth(test03);
				this.test03 = test03;
			}
			if (test04 != null)
			{
				this.AdjustFlagsAndWidth(test04);
				this.test04 = test04;
			}
			if (test05 != null)
			{
				this.AdjustFlagsAndWidth(test05);
				this.test05 = test05;
			}
			if (test06 != null)
			{
				this.AdjustFlagsAndWidth(test06);
				this.test06 = test06;
			}
			if (test07 != null)
			{
				this.AdjustFlagsAndWidth(test07);
				this.test07 = test07;
			}
			if (test08 != null)
			{
				this.AdjustFlagsAndWidth(test08);
				this.test08 = test08;
			}
			if (test09 != null)
			{
				this.AdjustFlagsAndWidth(test09);
				this.test09 = test09;
			}
			if (test10 != null)
			{
				this.AdjustFlagsAndWidth(test10);
				this.test10 = test10;
			}
			if (test11 != null)
			{
				this.AdjustFlagsAndWidth(test11);
				this.test11 = test11;
			}
	    }
	
	    public TestGreen(TestLanguageAnnotationsSyntaxKind kind, Test01Green test01, Test02Green test02, Test03Green test03, Test04Green test04, Test05Green test05, Test06Green test06, Test07Green test07, Test08Green test08, Test09Green test09, Test10Green test10, Test11Green test11, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 11;
			if (test01 != null)
			{
				this.AdjustFlagsAndWidth(test01);
				this.test01 = test01;
			}
			if (test02 != null)
			{
				this.AdjustFlagsAndWidth(test02);
				this.test02 = test02;
			}
			if (test03 != null)
			{
				this.AdjustFlagsAndWidth(test03);
				this.test03 = test03;
			}
			if (test04 != null)
			{
				this.AdjustFlagsAndWidth(test04);
				this.test04 = test04;
			}
			if (test05 != null)
			{
				this.AdjustFlagsAndWidth(test05);
				this.test05 = test05;
			}
			if (test06 != null)
			{
				this.AdjustFlagsAndWidth(test06);
				this.test06 = test06;
			}
			if (test07 != null)
			{
				this.AdjustFlagsAndWidth(test07);
				this.test07 = test07;
			}
			if (test08 != null)
			{
				this.AdjustFlagsAndWidth(test08);
				this.test08 = test08;
			}
			if (test09 != null)
			{
				this.AdjustFlagsAndWidth(test09);
				this.test09 = test09;
			}
			if (test10 != null)
			{
				this.AdjustFlagsAndWidth(test10);
				this.test10 = test10;
			}
			if (test11 != null)
			{
				this.AdjustFlagsAndWidth(test11);
				this.test11 = test11;
			}
	    }
	
		private TestGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Test01Green Test01 { get { return this.test01; } }
	    public Test02Green Test02 { get { return this.test02; } }
	    public Test03Green Test03 { get { return this.test03; } }
	    public Test04Green Test04 { get { return this.test04; } }
	    public Test05Green Test05 { get { return this.test05; } }
	    public Test06Green Test06 { get { return this.test06; } }
	    public Test07Green Test07 { get { return this.test07; } }
	    public Test08Green Test08 { get { return this.test08; } }
	    public Test09Green Test09 { get { return this.test09; } }
	    public Test10Green Test10 { get { return this.test10; } }
	    public Test11Green Test11 { get { return this.test11; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.TestSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.test01;
	            case 1: return this.test02;
	            case 2: return this.test03;
	            case 3: return this.test04;
	            case 4: return this.test05;
	            case 5: return this.test06;
	            case 6: return this.test07;
	            case 7: return this.test08;
	            case 8: return this.test09;
	            case 9: return this.test10;
	            case 10: return this.test11;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTestGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTestGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TestGreen(this.Kind, this.test01, this.test02, this.test03, this.test04, this.test05, this.test06, this.test07, this.test08, this.test09, this.test10, this.test11, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TestGreen(this.Kind, this.test01, this.test02, this.test03, this.test04, this.test05, this.test06, this.test07, this.test08, this.test09, this.test10, this.test11, this.GetDiagnostics(), annotations);
	    }
	
	    public TestGreen Update(Test01Green test01)
	    {
	        if (this.test01 != test01)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test01);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test02Green test02)
	    {
	        if (this.test02 != test02)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test02);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test03Green test03)
	    {
	        if (this.test03 != test03)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test03);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test04Green test04)
	    {
	        if (this.test04 != test04)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test04);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test05Green test05)
	    {
	        if (this.test05 != test05)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test05);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test06Green test06)
	    {
	        if (this.test06 != test06)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test06);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test07Green test07)
	    {
	        if (this.test07 != test07)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test07);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test08Green test08)
	    {
	        if (this.test08 != test08)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test08);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test09Green test09)
	    {
	        if (this.test09 != test09)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test09);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test10Green test10)
	    {
	        if (this.test10 != test10)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test10);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	
	    public TestGreen Update(Test11Green test11)
	    {
	        if (this.test11 != test11)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test(test11);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test01Green : GreenSyntaxNode
	{
	    internal static readonly Test01Green __Missing = new Test01Green();
	    private InternalSyntaxToken kTest01;
	    private NamespaceDeclaration01Green namespaceDeclaration01;
	
	    public Test01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest01, NamespaceDeclaration01Green namespaceDeclaration01)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest01 != null)
			{
				this.AdjustFlagsAndWidth(kTest01);
				this.kTest01 = kTest01;
			}
			if (namespaceDeclaration01 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration01);
				this.namespaceDeclaration01 = namespaceDeclaration01;
			}
	    }
	
	    public Test01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest01, NamespaceDeclaration01Green namespaceDeclaration01, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest01 != null)
			{
				this.AdjustFlagsAndWidth(kTest01);
				this.kTest01 = kTest01;
			}
			if (namespaceDeclaration01 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration01);
				this.namespaceDeclaration01 = namespaceDeclaration01;
			}
	    }
	
		private Test01Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test01, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest01 { get { return this.kTest01; } }
	    public NamespaceDeclaration01Green NamespaceDeclaration01 { get { return this.namespaceDeclaration01; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test01Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest01;
	            case 1: return this.namespaceDeclaration01;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest01Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest01Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test01Green(this.Kind, this.kTest01, this.namespaceDeclaration01, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test01Green(this.Kind, this.kTest01, this.namespaceDeclaration01, this.GetDiagnostics(), annotations);
	    }
	
	    public Test01Green Update(InternalSyntaxToken kTest01, NamespaceDeclaration01Green namespaceDeclaration01)
	    {
	        if (this.KTest01 != kTest01 ||
				this.NamespaceDeclaration01 != namespaceDeclaration01)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test01(kTest01, namespaceDeclaration01);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test01Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration01Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration01Green __Missing = new NamespaceDeclaration01Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody01Green namespaceBody01;
	
	    public NamespaceDeclaration01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody01Green namespaceBody01)
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
			if (namespaceBody01 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody01);
				this.namespaceBody01 = namespaceBody01;
			}
	    }
	
	    public NamespaceDeclaration01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody01Green namespaceBody01, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody01 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody01);
				this.namespaceBody01 = namespaceBody01;
			}
	    }
	
		private NamespaceDeclaration01Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration01, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody01Green NamespaceBody01 { get { return this.namespaceBody01; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration01Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody01;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration01Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration01Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration01Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody01, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration01Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody01, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration01Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody01Green namespaceBody01)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody01 != namespaceBody01)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration01(kNamespace, qualifiedName, namespaceBody01);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration01Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody01Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody01Green __Missing = new NamespaceBody01Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration01;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration01, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration01 != null)
			{
				this.AdjustFlagsAndWidth(declaration01);
				this.declaration01 = declaration01;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration01, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration01 != null)
			{
				this.AdjustFlagsAndWidth(declaration01);
				this.declaration01 = declaration01;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody01Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody01, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration01Green> Declaration01 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration01Green>(this.declaration01); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody01Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration01;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody01Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody01Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody01Green(this.Kind, this.tOpenBrace, this.declaration01, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody01Green(this.Kind, this.tOpenBrace, this.declaration01, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody01Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration01Green> declaration01, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration01 != declaration01 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody01(tOpenBrace, declaration01, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody01Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration01Green : GreenSyntaxNode
	{
	    internal static readonly Declaration01Green __Missing = new Declaration01Green();
	    private Vertex01Green vertex01;
	    private Arrow01Green arrow01;
	
	    public Declaration01Green(TestLanguageAnnotationsSyntaxKind kind, Vertex01Green vertex01, Arrow01Green arrow01)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex01 != null)
			{
				this.AdjustFlagsAndWidth(vertex01);
				this.vertex01 = vertex01;
			}
			if (arrow01 != null)
			{
				this.AdjustFlagsAndWidth(arrow01);
				this.arrow01 = arrow01;
			}
	    }
	
	    public Declaration01Green(TestLanguageAnnotationsSyntaxKind kind, Vertex01Green vertex01, Arrow01Green arrow01, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex01 != null)
			{
				this.AdjustFlagsAndWidth(vertex01);
				this.vertex01 = vertex01;
			}
			if (arrow01 != null)
			{
				this.AdjustFlagsAndWidth(arrow01);
				this.arrow01 = arrow01;
			}
	    }
	
		private Declaration01Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration01, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex01Green Vertex01 { get { return this.vertex01; } }
	    public Arrow01Green Arrow01 { get { return this.arrow01; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration01Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex01;
	            case 1: return this.arrow01;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration01Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration01Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration01Green(this.Kind, this.vertex01, this.arrow01, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration01Green(this.Kind, this.vertex01, this.arrow01, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration01Green Update(Vertex01Green vertex01)
	    {
	        if (this.vertex01 != vertex01)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration01(vertex01);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration01Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration01Green Update(Arrow01Green arrow01)
	    {
	        if (this.arrow01 != arrow01)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration01(arrow01);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration01Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex01Green : GreenSyntaxNode
	{
	    internal static readonly Vertex01Green __Missing = new Vertex01Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex01Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex01, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex01Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex01Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex01Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex01Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex01Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex01Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex01(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex01Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow01Green : GreenSyntaxNode
	{
	    internal static readonly Arrow01Green __Missing = new Arrow01Green();
	    private InternalSyntaxToken kArrow;
	    private QualifierGreen source;
	    private InternalSyntaxToken tArrow;
	    private QualifierGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow01Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow01Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow01, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public QualifierGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public QualifierGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow01Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow01Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow01Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow01Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow01Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow01Green Update(InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow01(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow01Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test02Green : GreenSyntaxNode
	{
	    internal static readonly Test02Green __Missing = new Test02Green();
	    private InternalSyntaxToken kTest02;
	    private NamespaceDeclaration02Green namespaceDeclaration02;
	
	    public Test02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest02, NamespaceDeclaration02Green namespaceDeclaration02)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest02 != null)
			{
				this.AdjustFlagsAndWidth(kTest02);
				this.kTest02 = kTest02;
			}
			if (namespaceDeclaration02 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration02);
				this.namespaceDeclaration02 = namespaceDeclaration02;
			}
	    }
	
	    public Test02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest02, NamespaceDeclaration02Green namespaceDeclaration02, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest02 != null)
			{
				this.AdjustFlagsAndWidth(kTest02);
				this.kTest02 = kTest02;
			}
			if (namespaceDeclaration02 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration02);
				this.namespaceDeclaration02 = namespaceDeclaration02;
			}
	    }
	
		private Test02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest02 { get { return this.kTest02; } }
	    public NamespaceDeclaration02Green NamespaceDeclaration02 { get { return this.namespaceDeclaration02; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest02;
	            case 1: return this.namespaceDeclaration02;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test02Green(this.Kind, this.kTest02, this.namespaceDeclaration02, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test02Green(this.Kind, this.kTest02, this.namespaceDeclaration02, this.GetDiagnostics(), annotations);
	    }
	
	    public Test02Green Update(InternalSyntaxToken kTest02, NamespaceDeclaration02Green namespaceDeclaration02)
	    {
	        if (this.KTest02 != kTest02 ||
				this.NamespaceDeclaration02 != namespaceDeclaration02)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test02(kTest02, namespaceDeclaration02);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration02Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration02Green __Missing = new NamespaceDeclaration02Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody02Green namespaceBody02;
	
	    public NamespaceDeclaration02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody02Green namespaceBody02)
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
			if (namespaceBody02 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody02);
				this.namespaceBody02 = namespaceBody02;
			}
	    }
	
	    public NamespaceDeclaration02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody02Green namespaceBody02, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody02 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody02);
				this.namespaceBody02 = namespaceBody02;
			}
	    }
	
		private NamespaceDeclaration02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody02Green NamespaceBody02 { get { return this.namespaceBody02; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody02;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration02Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody02, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration02Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody02, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration02Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody02Green namespaceBody02)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody02 != namespaceBody02)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration02(kNamespace, qualifiedName, namespaceBody02);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody02Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody02Green __Missing = new NamespaceBody02Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration02;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration02, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration02 != null)
			{
				this.AdjustFlagsAndWidth(declaration02);
				this.declaration02 = declaration02;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration02, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration02 != null)
			{
				this.AdjustFlagsAndWidth(declaration02);
				this.declaration02 = declaration02;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration02Green> Declaration02 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration02Green>(this.declaration02); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration02;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody02Green(this.Kind, this.tOpenBrace, this.declaration02, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody02Green(this.Kind, this.tOpenBrace, this.declaration02, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody02Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration02Green> declaration02, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration02 != declaration02 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody02(tOpenBrace, declaration02, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration02Green : GreenSyntaxNode
	{
	    internal static readonly Declaration02Green __Missing = new Declaration02Green();
	    private Vertex02Green vertex02;
	    private Arrow02Green arrow02;
	
	    public Declaration02Green(TestLanguageAnnotationsSyntaxKind kind, Vertex02Green vertex02, Arrow02Green arrow02)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex02 != null)
			{
				this.AdjustFlagsAndWidth(vertex02);
				this.vertex02 = vertex02;
			}
			if (arrow02 != null)
			{
				this.AdjustFlagsAndWidth(arrow02);
				this.arrow02 = arrow02;
			}
	    }
	
	    public Declaration02Green(TestLanguageAnnotationsSyntaxKind kind, Vertex02Green vertex02, Arrow02Green arrow02, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex02 != null)
			{
				this.AdjustFlagsAndWidth(vertex02);
				this.vertex02 = vertex02;
			}
			if (arrow02 != null)
			{
				this.AdjustFlagsAndWidth(arrow02);
				this.arrow02 = arrow02;
			}
	    }
	
		private Declaration02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex02Green Vertex02 { get { return this.vertex02; } }
	    public Arrow02Green Arrow02 { get { return this.arrow02; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex02;
	            case 1: return this.arrow02;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration02Green(this.Kind, this.vertex02, this.arrow02, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration02Green(this.Kind, this.vertex02, this.arrow02, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration02Green Update(Vertex02Green vertex02)
	    {
	        if (this.vertex02 != vertex02)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration02(vertex02);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration02Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration02Green Update(Arrow02Green arrow02)
	    {
	        if (this.arrow02 != arrow02)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration02(arrow02);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex02Green : GreenSyntaxNode
	{
	    internal static readonly Vertex02Green __Missing = new Vertex02Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex02Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex02Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex02Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex02(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow02Green : GreenSyntaxNode
	{
	    internal static readonly Arrow02Green __Missing = new Arrow02Green();
	    private InternalSyntaxToken kArrow;
	    private Source02Green source02;
	    private InternalSyntaxToken tArrow;
	    private Target02Green target02;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source02Green source02, InternalSyntaxToken tArrow, Target02Green target02, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source02 != null)
			{
				this.AdjustFlagsAndWidth(source02);
				this.source02 = source02;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target02 != null)
			{
				this.AdjustFlagsAndWidth(target02);
				this.target02 = target02;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow02Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source02Green source02, InternalSyntaxToken tArrow, Target02Green target02, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source02 != null)
			{
				this.AdjustFlagsAndWidth(source02);
				this.source02 = source02;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target02 != null)
			{
				this.AdjustFlagsAndWidth(target02);
				this.target02 = target02;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public Source02Green Source02 { get { return this.source02; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public Target02Green Target02 { get { return this.target02; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source02;
	            case 2: return this.tArrow;
	            case 3: return this.target02;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow02Green(this.Kind, this.kArrow, this.source02, this.tArrow, this.target02, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow02Green(this.Kind, this.kArrow, this.source02, this.tArrow, this.target02, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow02Green Update(InternalSyntaxToken kArrow, Source02Green source02, InternalSyntaxToken tArrow, Target02Green target02, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source02 != source02 ||
				this.TArrow != tArrow ||
				this.Target02 != target02 ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow02(kArrow, source02, tArrow, target02, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Source02Green : GreenSyntaxNode
	{
	    internal static readonly Source02Green __Missing = new Source02Green();
	    private QualifierGreen qualifier;
	
	    public Source02Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public Source02Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private Source02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Source02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitSource02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitSource02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Source02Green(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Source02Green(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public Source02Green Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source02(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Target02Green : GreenSyntaxNode
	{
	    internal static readonly Target02Green __Missing = new Target02Green();
	    private QualifierGreen qualifier;
	
	    public Target02Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public Target02Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private Target02Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target02, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Target02Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTarget02Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTarget02Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Target02Green(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Target02Green(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public Target02Green Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target02(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target02Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test03Green : GreenSyntaxNode
	{
	    internal static readonly Test03Green __Missing = new Test03Green();
	    private InternalSyntaxToken kTest03;
	    private NamespaceDeclaration03Green namespaceDeclaration03;
	
	    public Test03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest03, NamespaceDeclaration03Green namespaceDeclaration03)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest03 != null)
			{
				this.AdjustFlagsAndWidth(kTest03);
				this.kTest03 = kTest03;
			}
			if (namespaceDeclaration03 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration03);
				this.namespaceDeclaration03 = namespaceDeclaration03;
			}
	    }
	
	    public Test03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest03, NamespaceDeclaration03Green namespaceDeclaration03, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest03 != null)
			{
				this.AdjustFlagsAndWidth(kTest03);
				this.kTest03 = kTest03;
			}
			if (namespaceDeclaration03 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration03);
				this.namespaceDeclaration03 = namespaceDeclaration03;
			}
	    }
	
		private Test03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest03 { get { return this.kTest03; } }
	    public NamespaceDeclaration03Green NamespaceDeclaration03 { get { return this.namespaceDeclaration03; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest03;
	            case 1: return this.namespaceDeclaration03;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test03Green(this.Kind, this.kTest03, this.namespaceDeclaration03, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test03Green(this.Kind, this.kTest03, this.namespaceDeclaration03, this.GetDiagnostics(), annotations);
	    }
	
	    public Test03Green Update(InternalSyntaxToken kTest03, NamespaceDeclaration03Green namespaceDeclaration03)
	    {
	        if (this.KTest03 != kTest03 ||
				this.NamespaceDeclaration03 != namespaceDeclaration03)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test03(kTest03, namespaceDeclaration03);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration03Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration03Green __Missing = new NamespaceDeclaration03Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody03Green namespaceBody03;
	
	    public NamespaceDeclaration03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody03Green namespaceBody03)
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
			if (namespaceBody03 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody03);
				this.namespaceBody03 = namespaceBody03;
			}
	    }
	
	    public NamespaceDeclaration03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody03Green namespaceBody03, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody03 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody03);
				this.namespaceBody03 = namespaceBody03;
			}
	    }
	
		private NamespaceDeclaration03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody03Green NamespaceBody03 { get { return this.namespaceBody03; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody03;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration03Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody03, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration03Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody03, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration03Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody03Green namespaceBody03)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody03 != namespaceBody03)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration03(kNamespace, qualifiedName, namespaceBody03);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody03Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody03Green __Missing = new NamespaceBody03Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration03;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration03, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration03 != null)
			{
				this.AdjustFlagsAndWidth(declaration03);
				this.declaration03 = declaration03;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration03, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration03 != null)
			{
				this.AdjustFlagsAndWidth(declaration03);
				this.declaration03 = declaration03;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration03Green> Declaration03 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration03Green>(this.declaration03); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration03;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody03Green(this.Kind, this.tOpenBrace, this.declaration03, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody03Green(this.Kind, this.tOpenBrace, this.declaration03, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody03Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration03Green> declaration03, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration03 != declaration03 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody03(tOpenBrace, declaration03, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration03Green : GreenSyntaxNode
	{
	    internal static readonly Declaration03Green __Missing = new Declaration03Green();
	    private Vertex03Green vertex03;
	    private Arrow03Green arrow03;
	
	    public Declaration03Green(TestLanguageAnnotationsSyntaxKind kind, Vertex03Green vertex03, Arrow03Green arrow03)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex03 != null)
			{
				this.AdjustFlagsAndWidth(vertex03);
				this.vertex03 = vertex03;
			}
			if (arrow03 != null)
			{
				this.AdjustFlagsAndWidth(arrow03);
				this.arrow03 = arrow03;
			}
	    }
	
	    public Declaration03Green(TestLanguageAnnotationsSyntaxKind kind, Vertex03Green vertex03, Arrow03Green arrow03, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex03 != null)
			{
				this.AdjustFlagsAndWidth(vertex03);
				this.vertex03 = vertex03;
			}
			if (arrow03 != null)
			{
				this.AdjustFlagsAndWidth(arrow03);
				this.arrow03 = arrow03;
			}
	    }
	
		private Declaration03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex03Green Vertex03 { get { return this.vertex03; } }
	    public Arrow03Green Arrow03 { get { return this.arrow03; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex03;
	            case 1: return this.arrow03;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration03Green(this.Kind, this.vertex03, this.arrow03, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration03Green(this.Kind, this.vertex03, this.arrow03, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration03Green Update(Vertex03Green vertex03)
	    {
	        if (this.vertex03 != vertex03)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration03(vertex03);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration03Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration03Green Update(Arrow03Green arrow03)
	    {
	        if (this.arrow03 != arrow03)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration03(arrow03);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex03Green : GreenSyntaxNode
	{
	    internal static readonly Vertex03Green __Missing = new Vertex03Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex03Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex03Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex03Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex03(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow03Green : GreenSyntaxNode
	{
	    internal static readonly Arrow03Green __Missing = new Arrow03Green();
	    private InternalSyntaxToken kArrow;
	    private Source03Green source03;
	    private InternalSyntaxToken tArrow;
	    private Target03Green target03;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source03Green source03, InternalSyntaxToken tArrow, Target03Green target03, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source03 != null)
			{
				this.AdjustFlagsAndWidth(source03);
				this.source03 = source03;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target03 != null)
			{
				this.AdjustFlagsAndWidth(target03);
				this.target03 = target03;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow03Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source03Green source03, InternalSyntaxToken tArrow, Target03Green target03, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source03 != null)
			{
				this.AdjustFlagsAndWidth(source03);
				this.source03 = source03;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target03 != null)
			{
				this.AdjustFlagsAndWidth(target03);
				this.target03 = target03;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public Source03Green Source03 { get { return this.source03; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public Target03Green Target03 { get { return this.target03; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source03;
	            case 2: return this.tArrow;
	            case 3: return this.target03;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow03Green(this.Kind, this.kArrow, this.source03, this.tArrow, this.target03, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow03Green(this.Kind, this.kArrow, this.source03, this.tArrow, this.target03, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow03Green Update(InternalSyntaxToken kArrow, Source03Green source03, InternalSyntaxToken tArrow, Target03Green target03, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source03 != source03 ||
				this.TArrow != tArrow ||
				this.Target03 != target03 ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow03(kArrow, source03, tArrow, target03, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Source03Green : GreenSyntaxNode
	{
	    internal static readonly Source03Green __Missing = new Source03Green();
	    private QualifierGreen qualifier;
	
	    public Source03Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public Source03Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private Source03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Source03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitSource03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitSource03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Source03Green(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Source03Green(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public Source03Green Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source03(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Target03Green : GreenSyntaxNode
	{
	    internal static readonly Target03Green __Missing = new Target03Green();
	    private QualifierGreen qualifier;
	
	    public Target03Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public Target03Green(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private Target03Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target03, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Target03Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTarget03Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTarget03Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Target03Green(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Target03Green(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public Target03Green Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target03(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target03Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test04Green : GreenSyntaxNode
	{
	    internal static readonly Test04Green __Missing = new Test04Green();
	    private InternalSyntaxToken kTest04;
	    private NamespaceDeclaration04Green namespaceDeclaration04;
	
	    public Test04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest04, NamespaceDeclaration04Green namespaceDeclaration04)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest04 != null)
			{
				this.AdjustFlagsAndWidth(kTest04);
				this.kTest04 = kTest04;
			}
			if (namespaceDeclaration04 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration04);
				this.namespaceDeclaration04 = namespaceDeclaration04;
			}
	    }
	
	    public Test04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest04, NamespaceDeclaration04Green namespaceDeclaration04, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest04 != null)
			{
				this.AdjustFlagsAndWidth(kTest04);
				this.kTest04 = kTest04;
			}
			if (namespaceDeclaration04 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration04);
				this.namespaceDeclaration04 = namespaceDeclaration04;
			}
	    }
	
		private Test04Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test04, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest04 { get { return this.kTest04; } }
	    public NamespaceDeclaration04Green NamespaceDeclaration04 { get { return this.namespaceDeclaration04; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test04Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest04;
	            case 1: return this.namespaceDeclaration04;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest04Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest04Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test04Green(this.Kind, this.kTest04, this.namespaceDeclaration04, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test04Green(this.Kind, this.kTest04, this.namespaceDeclaration04, this.GetDiagnostics(), annotations);
	    }
	
	    public Test04Green Update(InternalSyntaxToken kTest04, NamespaceDeclaration04Green namespaceDeclaration04)
	    {
	        if (this.KTest04 != kTest04 ||
				this.NamespaceDeclaration04 != namespaceDeclaration04)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test04(kTest04, namespaceDeclaration04);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test04Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration04Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration04Green __Missing = new NamespaceDeclaration04Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody04Green namespaceBody04;
	
	    public NamespaceDeclaration04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody04Green namespaceBody04)
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
			if (namespaceBody04 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody04);
				this.namespaceBody04 = namespaceBody04;
			}
	    }
	
	    public NamespaceDeclaration04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody04Green namespaceBody04, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody04 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody04);
				this.namespaceBody04 = namespaceBody04;
			}
	    }
	
		private NamespaceDeclaration04Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration04, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody04Green NamespaceBody04 { get { return this.namespaceBody04; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration04Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody04;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration04Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration04Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration04Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody04, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration04Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody04, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration04Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody04Green namespaceBody04)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody04 != namespaceBody04)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration04(kNamespace, qualifiedName, namespaceBody04);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration04Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody04Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody04Green __Missing = new NamespaceBody04Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration04;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration04, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration04 != null)
			{
				this.AdjustFlagsAndWidth(declaration04);
				this.declaration04 = declaration04;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration04, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration04 != null)
			{
				this.AdjustFlagsAndWidth(declaration04);
				this.declaration04 = declaration04;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody04Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody04, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration04Green> Declaration04 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration04Green>(this.declaration04); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody04Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration04;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody04Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody04Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody04Green(this.Kind, this.tOpenBrace, this.declaration04, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody04Green(this.Kind, this.tOpenBrace, this.declaration04, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody04Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration04Green> declaration04, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration04 != declaration04 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody04(tOpenBrace, declaration04, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody04Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration04Green : GreenSyntaxNode
	{
	    internal static readonly Declaration04Green __Missing = new Declaration04Green();
	    private Vertex04Green vertex04;
	    private Arrow04Green arrow04;
	
	    public Declaration04Green(TestLanguageAnnotationsSyntaxKind kind, Vertex04Green vertex04, Arrow04Green arrow04)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex04 != null)
			{
				this.AdjustFlagsAndWidth(vertex04);
				this.vertex04 = vertex04;
			}
			if (arrow04 != null)
			{
				this.AdjustFlagsAndWidth(arrow04);
				this.arrow04 = arrow04;
			}
	    }
	
	    public Declaration04Green(TestLanguageAnnotationsSyntaxKind kind, Vertex04Green vertex04, Arrow04Green arrow04, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex04 != null)
			{
				this.AdjustFlagsAndWidth(vertex04);
				this.vertex04 = vertex04;
			}
			if (arrow04 != null)
			{
				this.AdjustFlagsAndWidth(arrow04);
				this.arrow04 = arrow04;
			}
	    }
	
		private Declaration04Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration04, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex04Green Vertex04 { get { return this.vertex04; } }
	    public Arrow04Green Arrow04 { get { return this.arrow04; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration04Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex04;
	            case 1: return this.arrow04;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration04Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration04Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration04Green(this.Kind, this.vertex04, this.arrow04, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration04Green(this.Kind, this.vertex04, this.arrow04, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration04Green Update(Vertex04Green vertex04)
	    {
	        if (this.vertex04 != vertex04)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration04(vertex04);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration04Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration04Green Update(Arrow04Green arrow04)
	    {
	        if (this.arrow04 != arrow04)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration04(arrow04);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration04Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex04Green : GreenSyntaxNode
	{
	    internal static readonly Vertex04Green __Missing = new Vertex04Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex04Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex04, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex04Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex04Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex04Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex04Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex04Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex04Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex04(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex04Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow04Green : GreenSyntaxNode
	{
	    internal static readonly Arrow04Green __Missing = new Arrow04Green();
	    private InternalSyntaxToken kArrow;
	    private QualifierGreen source;
	    private InternalSyntaxToken tArrow;
	    private QualifierGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow04Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow04Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow04, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public QualifierGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public QualifierGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow04Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow04Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow04Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow04Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow04Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow04Green Update(InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow04(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow04Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test05Green : GreenSyntaxNode
	{
	    internal static readonly Test05Green __Missing = new Test05Green();
	    private InternalSyntaxToken kTest05;
	    private NamespaceDeclaration05Green namespaceDeclaration05;
	
	    public Test05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest05, NamespaceDeclaration05Green namespaceDeclaration05)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest05 != null)
			{
				this.AdjustFlagsAndWidth(kTest05);
				this.kTest05 = kTest05;
			}
			if (namespaceDeclaration05 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration05);
				this.namespaceDeclaration05 = namespaceDeclaration05;
			}
	    }
	
	    public Test05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest05, NamespaceDeclaration05Green namespaceDeclaration05, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest05 != null)
			{
				this.AdjustFlagsAndWidth(kTest05);
				this.kTest05 = kTest05;
			}
			if (namespaceDeclaration05 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration05);
				this.namespaceDeclaration05 = namespaceDeclaration05;
			}
	    }
	
		private Test05Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test05, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest05 { get { return this.kTest05; } }
	    public NamespaceDeclaration05Green NamespaceDeclaration05 { get { return this.namespaceDeclaration05; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test05Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest05;
	            case 1: return this.namespaceDeclaration05;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest05Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest05Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test05Green(this.Kind, this.kTest05, this.namespaceDeclaration05, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test05Green(this.Kind, this.kTest05, this.namespaceDeclaration05, this.GetDiagnostics(), annotations);
	    }
	
	    public Test05Green Update(InternalSyntaxToken kTest05, NamespaceDeclaration05Green namespaceDeclaration05)
	    {
	        if (this.KTest05 != kTest05 ||
				this.NamespaceDeclaration05 != namespaceDeclaration05)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test05(kTest05, namespaceDeclaration05);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test05Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration05Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration05Green __Missing = new NamespaceDeclaration05Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody05Green namespaceBody05;
	
	    public NamespaceDeclaration05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody05Green namespaceBody05)
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
			if (namespaceBody05 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody05);
				this.namespaceBody05 = namespaceBody05;
			}
	    }
	
	    public NamespaceDeclaration05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody05Green namespaceBody05, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody05 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody05);
				this.namespaceBody05 = namespaceBody05;
			}
	    }
	
		private NamespaceDeclaration05Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration05, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody05Green NamespaceBody05 { get { return this.namespaceBody05; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration05Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody05;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration05Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration05Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration05Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody05, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration05Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody05, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration05Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody05Green namespaceBody05)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody05 != namespaceBody05)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration05(kNamespace, qualifiedName, namespaceBody05);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration05Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody05Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody05Green __Missing = new NamespaceBody05Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration05;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration05, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration05 != null)
			{
				this.AdjustFlagsAndWidth(declaration05);
				this.declaration05 = declaration05;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration05, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration05 != null)
			{
				this.AdjustFlagsAndWidth(declaration05);
				this.declaration05 = declaration05;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody05Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody05, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration05Green> Declaration05 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration05Green>(this.declaration05); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody05Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration05;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody05Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody05Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody05Green(this.Kind, this.tOpenBrace, this.declaration05, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody05Green(this.Kind, this.tOpenBrace, this.declaration05, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody05Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration05Green> declaration05, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration05 != declaration05 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody05(tOpenBrace, declaration05, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody05Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration05Green : GreenSyntaxNode
	{
	    internal static readonly Declaration05Green __Missing = new Declaration05Green();
	    private Vertex05Green vertex05;
	    private Arrow05Green arrow05;
	
	    public Declaration05Green(TestLanguageAnnotationsSyntaxKind kind, Vertex05Green vertex05, Arrow05Green arrow05)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex05 != null)
			{
				this.AdjustFlagsAndWidth(vertex05);
				this.vertex05 = vertex05;
			}
			if (arrow05 != null)
			{
				this.AdjustFlagsAndWidth(arrow05);
				this.arrow05 = arrow05;
			}
	    }
	
	    public Declaration05Green(TestLanguageAnnotationsSyntaxKind kind, Vertex05Green vertex05, Arrow05Green arrow05, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex05 != null)
			{
				this.AdjustFlagsAndWidth(vertex05);
				this.vertex05 = vertex05;
			}
			if (arrow05 != null)
			{
				this.AdjustFlagsAndWidth(arrow05);
				this.arrow05 = arrow05;
			}
	    }
	
		private Declaration05Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration05, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex05Green Vertex05 { get { return this.vertex05; } }
	    public Arrow05Green Arrow05 { get { return this.arrow05; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration05Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex05;
	            case 1: return this.arrow05;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration05Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration05Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration05Green(this.Kind, this.vertex05, this.arrow05, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration05Green(this.Kind, this.vertex05, this.arrow05, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration05Green Update(Vertex05Green vertex05)
	    {
	        if (this.vertex05 != vertex05)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration05(vertex05);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration05Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration05Green Update(Arrow05Green arrow05)
	    {
	        if (this.arrow05 != arrow05)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration05(arrow05);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration05Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex05Green : GreenSyntaxNode
	{
	    internal static readonly Vertex05Green __Missing = new Vertex05Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex05Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex05, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex05Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex05Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex05Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex05Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex05Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex05Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex05(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex05Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow05Green : GreenSyntaxNode
	{
	    internal static readonly Arrow05Green __Missing = new Arrow05Green();
	    private InternalSyntaxToken kArrow;
	    private QualifierGreen source;
	    private InternalSyntaxToken tArrow;
	    private QualifierGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow05Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow05Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow05, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public QualifierGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public QualifierGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow05Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow05Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow05Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow05Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow05Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow05Green Update(InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow05(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow05Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test06Green : GreenSyntaxNode
	{
	    internal static readonly Test06Green __Missing = new Test06Green();
	    private InternalSyntaxToken kTest06;
	    private NamespaceDeclaration06Green namespaceDeclaration06;
	
	    public Test06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest06, NamespaceDeclaration06Green namespaceDeclaration06)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest06 != null)
			{
				this.AdjustFlagsAndWidth(kTest06);
				this.kTest06 = kTest06;
			}
			if (namespaceDeclaration06 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration06);
				this.namespaceDeclaration06 = namespaceDeclaration06;
			}
	    }
	
	    public Test06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest06, NamespaceDeclaration06Green namespaceDeclaration06, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest06 != null)
			{
				this.AdjustFlagsAndWidth(kTest06);
				this.kTest06 = kTest06;
			}
			if (namespaceDeclaration06 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration06);
				this.namespaceDeclaration06 = namespaceDeclaration06;
			}
	    }
	
		private Test06Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test06, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest06 { get { return this.kTest06; } }
	    public NamespaceDeclaration06Green NamespaceDeclaration06 { get { return this.namespaceDeclaration06; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test06Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest06;
	            case 1: return this.namespaceDeclaration06;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest06Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest06Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test06Green(this.Kind, this.kTest06, this.namespaceDeclaration06, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test06Green(this.Kind, this.kTest06, this.namespaceDeclaration06, this.GetDiagnostics(), annotations);
	    }
	
	    public Test06Green Update(InternalSyntaxToken kTest06, NamespaceDeclaration06Green namespaceDeclaration06)
	    {
	        if (this.KTest06 != kTest06 ||
				this.NamespaceDeclaration06 != namespaceDeclaration06)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test06(kTest06, namespaceDeclaration06);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test06Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration06Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration06Green __Missing = new NamespaceDeclaration06Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody06Green namespaceBody06;
	
	    public NamespaceDeclaration06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody06Green namespaceBody06)
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
			if (namespaceBody06 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody06);
				this.namespaceBody06 = namespaceBody06;
			}
	    }
	
	    public NamespaceDeclaration06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody06Green namespaceBody06, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody06 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody06);
				this.namespaceBody06 = namespaceBody06;
			}
	    }
	
		private NamespaceDeclaration06Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration06, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody06Green NamespaceBody06 { get { return this.namespaceBody06; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration06Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody06;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration06Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration06Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration06Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody06, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration06Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody06, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration06Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody06Green namespaceBody06)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody06 != namespaceBody06)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration06(kNamespace, qualifiedName, namespaceBody06);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration06Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody06Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody06Green __Missing = new NamespaceBody06Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration06;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration06, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration06 != null)
			{
				this.AdjustFlagsAndWidth(declaration06);
				this.declaration06 = declaration06;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration06, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration06 != null)
			{
				this.AdjustFlagsAndWidth(declaration06);
				this.declaration06 = declaration06;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody06Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody06, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration06Green> Declaration06 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration06Green>(this.declaration06); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody06Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration06;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody06Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody06Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody06Green(this.Kind, this.tOpenBrace, this.declaration06, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody06Green(this.Kind, this.tOpenBrace, this.declaration06, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody06Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration06Green> declaration06, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration06 != declaration06 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody06(tOpenBrace, declaration06, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody06Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration06Green : GreenSyntaxNode
	{
	    internal static readonly Declaration06Green __Missing = new Declaration06Green();
	    private Vertex06Green vertex06;
	    private Arrow06Green arrow06;
	
	    public Declaration06Green(TestLanguageAnnotationsSyntaxKind kind, Vertex06Green vertex06, Arrow06Green arrow06)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex06 != null)
			{
				this.AdjustFlagsAndWidth(vertex06);
				this.vertex06 = vertex06;
			}
			if (arrow06 != null)
			{
				this.AdjustFlagsAndWidth(arrow06);
				this.arrow06 = arrow06;
			}
	    }
	
	    public Declaration06Green(TestLanguageAnnotationsSyntaxKind kind, Vertex06Green vertex06, Arrow06Green arrow06, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex06 != null)
			{
				this.AdjustFlagsAndWidth(vertex06);
				this.vertex06 = vertex06;
			}
			if (arrow06 != null)
			{
				this.AdjustFlagsAndWidth(arrow06);
				this.arrow06 = arrow06;
			}
	    }
	
		private Declaration06Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration06, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex06Green Vertex06 { get { return this.vertex06; } }
	    public Arrow06Green Arrow06 { get { return this.arrow06; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration06Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex06;
	            case 1: return this.arrow06;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration06Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration06Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration06Green(this.Kind, this.vertex06, this.arrow06, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration06Green(this.Kind, this.vertex06, this.arrow06, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration06Green Update(Vertex06Green vertex06)
	    {
	        if (this.vertex06 != vertex06)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration06(vertex06);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration06Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration06Green Update(Arrow06Green arrow06)
	    {
	        if (this.arrow06 != arrow06)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration06(arrow06);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration06Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex06Green : GreenSyntaxNode
	{
	    internal static readonly Vertex06Green __Missing = new Vertex06Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex06Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex06, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex06Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex06Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex06Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex06Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex06Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex06Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex06(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex06Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow06Green : GreenSyntaxNode
	{
	    internal static readonly Arrow06Green __Missing = new Arrow06Green();
	    private InternalSyntaxToken kArrow;
	    private NameGreen source;
	    private InternalSyntaxToken tArrow;
	    private NameGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow06Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow06Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow06, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public NameGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public NameGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow06Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow06Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow06Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow06Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow06Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow06Green Update(InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow06(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow06Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test07Green : GreenSyntaxNode
	{
	    internal static readonly Test07Green __Missing = new Test07Green();
	    private InternalSyntaxToken kTest07;
	    private NamespaceDeclaration07Green namespaceDeclaration07;
	
	    public Test07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest07, NamespaceDeclaration07Green namespaceDeclaration07)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest07 != null)
			{
				this.AdjustFlagsAndWidth(kTest07);
				this.kTest07 = kTest07;
			}
			if (namespaceDeclaration07 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration07);
				this.namespaceDeclaration07 = namespaceDeclaration07;
			}
	    }
	
	    public Test07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest07, NamespaceDeclaration07Green namespaceDeclaration07, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest07 != null)
			{
				this.AdjustFlagsAndWidth(kTest07);
				this.kTest07 = kTest07;
			}
			if (namespaceDeclaration07 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration07);
				this.namespaceDeclaration07 = namespaceDeclaration07;
			}
	    }
	
		private Test07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest07 { get { return this.kTest07; } }
	    public NamespaceDeclaration07Green NamespaceDeclaration07 { get { return this.namespaceDeclaration07; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest07;
	            case 1: return this.namespaceDeclaration07;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test07Green(this.Kind, this.kTest07, this.namespaceDeclaration07, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test07Green(this.Kind, this.kTest07, this.namespaceDeclaration07, this.GetDiagnostics(), annotations);
	    }
	
	    public Test07Green Update(InternalSyntaxToken kTest07, NamespaceDeclaration07Green namespaceDeclaration07)
	    {
	        if (this.KTest07 != kTest07 ||
				this.NamespaceDeclaration07 != namespaceDeclaration07)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test07(kTest07, namespaceDeclaration07);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration07Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration07Green __Missing = new NamespaceDeclaration07Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody07Green namespaceBody07;
	
	    public NamespaceDeclaration07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody07Green namespaceBody07)
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
			if (namespaceBody07 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody07);
				this.namespaceBody07 = namespaceBody07;
			}
	    }
	
	    public NamespaceDeclaration07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody07Green namespaceBody07, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody07 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody07);
				this.namespaceBody07 = namespaceBody07;
			}
	    }
	
		private NamespaceDeclaration07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody07Green NamespaceBody07 { get { return this.namespaceBody07; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody07;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration07Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody07, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration07Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody07, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration07Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody07Green namespaceBody07)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody07 != namespaceBody07)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration07(kNamespace, qualifiedName, namespaceBody07);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody07Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody07Green __Missing = new NamespaceBody07Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration07;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration07, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration07 != null)
			{
				this.AdjustFlagsAndWidth(declaration07);
				this.declaration07 = declaration07;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration07, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration07 != null)
			{
				this.AdjustFlagsAndWidth(declaration07);
				this.declaration07 = declaration07;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration07Green> Declaration07 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration07Green>(this.declaration07); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration07;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody07Green(this.Kind, this.tOpenBrace, this.declaration07, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody07Green(this.Kind, this.tOpenBrace, this.declaration07, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody07Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration07Green> declaration07, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration07 != declaration07 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody07(tOpenBrace, declaration07, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration07Green : GreenSyntaxNode
	{
	    internal static readonly Declaration07Green __Missing = new Declaration07Green();
	    private Vertex07Green vertex07;
	    private Arrow07Green arrow07;
	
	    public Declaration07Green(TestLanguageAnnotationsSyntaxKind kind, Vertex07Green vertex07, Arrow07Green arrow07)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex07 != null)
			{
				this.AdjustFlagsAndWidth(vertex07);
				this.vertex07 = vertex07;
			}
			if (arrow07 != null)
			{
				this.AdjustFlagsAndWidth(arrow07);
				this.arrow07 = arrow07;
			}
	    }
	
	    public Declaration07Green(TestLanguageAnnotationsSyntaxKind kind, Vertex07Green vertex07, Arrow07Green arrow07, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex07 != null)
			{
				this.AdjustFlagsAndWidth(vertex07);
				this.vertex07 = vertex07;
			}
			if (arrow07 != null)
			{
				this.AdjustFlagsAndWidth(arrow07);
				this.arrow07 = arrow07;
			}
	    }
	
		private Declaration07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex07Green Vertex07 { get { return this.vertex07; } }
	    public Arrow07Green Arrow07 { get { return this.arrow07; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex07;
	            case 1: return this.arrow07;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration07Green(this.Kind, this.vertex07, this.arrow07, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration07Green(this.Kind, this.vertex07, this.arrow07, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration07Green Update(Vertex07Green vertex07)
	    {
	        if (this.vertex07 != vertex07)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration07(vertex07);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration07Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration07Green Update(Arrow07Green arrow07)
	    {
	        if (this.arrow07 != arrow07)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration07(arrow07);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex07Green : GreenSyntaxNode
	{
	    internal static readonly Vertex07Green __Missing = new Vertex07Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex07Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex07Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex07Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex07(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow07Green : GreenSyntaxNode
	{
	    internal static readonly Arrow07Green __Missing = new Arrow07Green();
	    private InternalSyntaxToken kArrow;
	    private Source07Green source07;
	    private InternalSyntaxToken tArrow;
	    private Target07Green target07;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source07Green source07, InternalSyntaxToken tArrow, Target07Green target07, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source07 != null)
			{
				this.AdjustFlagsAndWidth(source07);
				this.source07 = source07;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target07 != null)
			{
				this.AdjustFlagsAndWidth(target07);
				this.target07 = target07;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow07Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source07Green source07, InternalSyntaxToken tArrow, Target07Green target07, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source07 != null)
			{
				this.AdjustFlagsAndWidth(source07);
				this.source07 = source07;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target07 != null)
			{
				this.AdjustFlagsAndWidth(target07);
				this.target07 = target07;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public Source07Green Source07 { get { return this.source07; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public Target07Green Target07 { get { return this.target07; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source07;
	            case 2: return this.tArrow;
	            case 3: return this.target07;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow07Green(this.Kind, this.kArrow, this.source07, this.tArrow, this.target07, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow07Green(this.Kind, this.kArrow, this.source07, this.tArrow, this.target07, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow07Green Update(InternalSyntaxToken kArrow, Source07Green source07, InternalSyntaxToken tArrow, Target07Green target07, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source07 != source07 ||
				this.TArrow != tArrow ||
				this.Target07 != target07 ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow07(kArrow, source07, tArrow, target07, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Source07Green : GreenSyntaxNode
	{
	    internal static readonly Source07Green __Missing = new Source07Green();
	    private NameGreen name;
	
	    public Source07Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public Source07Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private Source07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Source07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitSource07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitSource07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Source07Green(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Source07Green(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public Source07Green Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source07(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Target07Green : GreenSyntaxNode
	{
	    internal static readonly Target07Green __Missing = new Target07Green();
	    private NameGreen name;
	
	    public Target07Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public Target07Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private Target07Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target07, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Target07Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTarget07Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTarget07Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Target07Green(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Target07Green(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public Target07Green Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target07(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target07Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test08Green : GreenSyntaxNode
	{
	    internal static readonly Test08Green __Missing = new Test08Green();
	    private InternalSyntaxToken kTest08;
	    private NamespaceDeclaration08Green namespaceDeclaration08;
	
	    public Test08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest08, NamespaceDeclaration08Green namespaceDeclaration08)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest08 != null)
			{
				this.AdjustFlagsAndWidth(kTest08);
				this.kTest08 = kTest08;
			}
			if (namespaceDeclaration08 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration08);
				this.namespaceDeclaration08 = namespaceDeclaration08;
			}
	    }
	
	    public Test08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest08, NamespaceDeclaration08Green namespaceDeclaration08, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest08 != null)
			{
				this.AdjustFlagsAndWidth(kTest08);
				this.kTest08 = kTest08;
			}
			if (namespaceDeclaration08 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration08);
				this.namespaceDeclaration08 = namespaceDeclaration08;
			}
	    }
	
		private Test08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest08 { get { return this.kTest08; } }
	    public NamespaceDeclaration08Green NamespaceDeclaration08 { get { return this.namespaceDeclaration08; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest08;
	            case 1: return this.namespaceDeclaration08;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test08Green(this.Kind, this.kTest08, this.namespaceDeclaration08, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test08Green(this.Kind, this.kTest08, this.namespaceDeclaration08, this.GetDiagnostics(), annotations);
	    }
	
	    public Test08Green Update(InternalSyntaxToken kTest08, NamespaceDeclaration08Green namespaceDeclaration08)
	    {
	        if (this.KTest08 != kTest08 ||
				this.NamespaceDeclaration08 != namespaceDeclaration08)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test08(kTest08, namespaceDeclaration08);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration08Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration08Green __Missing = new NamespaceDeclaration08Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody08Green namespaceBody08;
	
	    public NamespaceDeclaration08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody08Green namespaceBody08)
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
			if (namespaceBody08 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody08);
				this.namespaceBody08 = namespaceBody08;
			}
	    }
	
	    public NamespaceDeclaration08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody08Green namespaceBody08, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody08 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody08);
				this.namespaceBody08 = namespaceBody08;
			}
	    }
	
		private NamespaceDeclaration08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody08Green NamespaceBody08 { get { return this.namespaceBody08; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody08;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration08Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody08, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration08Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody08, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration08Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody08Green namespaceBody08)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody08 != namespaceBody08)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration08(kNamespace, qualifiedName, namespaceBody08);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody08Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody08Green __Missing = new NamespaceBody08Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration08;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration08, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration08 != null)
			{
				this.AdjustFlagsAndWidth(declaration08);
				this.declaration08 = declaration08;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration08, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration08 != null)
			{
				this.AdjustFlagsAndWidth(declaration08);
				this.declaration08 = declaration08;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration08Green> Declaration08 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration08Green>(this.declaration08); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration08;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody08Green(this.Kind, this.tOpenBrace, this.declaration08, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody08Green(this.Kind, this.tOpenBrace, this.declaration08, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody08Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration08Green> declaration08, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration08 != declaration08 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody08(tOpenBrace, declaration08, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration08Green : GreenSyntaxNode
	{
	    internal static readonly Declaration08Green __Missing = new Declaration08Green();
	    private Vertex08Green vertex08;
	    private Arrow08Green arrow08;
	
	    public Declaration08Green(TestLanguageAnnotationsSyntaxKind kind, Vertex08Green vertex08, Arrow08Green arrow08)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex08 != null)
			{
				this.AdjustFlagsAndWidth(vertex08);
				this.vertex08 = vertex08;
			}
			if (arrow08 != null)
			{
				this.AdjustFlagsAndWidth(arrow08);
				this.arrow08 = arrow08;
			}
	    }
	
	    public Declaration08Green(TestLanguageAnnotationsSyntaxKind kind, Vertex08Green vertex08, Arrow08Green arrow08, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex08 != null)
			{
				this.AdjustFlagsAndWidth(vertex08);
				this.vertex08 = vertex08;
			}
			if (arrow08 != null)
			{
				this.AdjustFlagsAndWidth(arrow08);
				this.arrow08 = arrow08;
			}
	    }
	
		private Declaration08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex08Green Vertex08 { get { return this.vertex08; } }
	    public Arrow08Green Arrow08 { get { return this.arrow08; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex08;
	            case 1: return this.arrow08;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration08Green(this.Kind, this.vertex08, this.arrow08, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration08Green(this.Kind, this.vertex08, this.arrow08, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration08Green Update(Vertex08Green vertex08)
	    {
	        if (this.vertex08 != vertex08)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration08(vertex08);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration08Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration08Green Update(Arrow08Green arrow08)
	    {
	        if (this.arrow08 != arrow08)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration08(arrow08);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex08Green : GreenSyntaxNode
	{
	    internal static readonly Vertex08Green __Missing = new Vertex08Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex08Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex08Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex08Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex08(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow08Green : GreenSyntaxNode
	{
	    internal static readonly Arrow08Green __Missing = new Arrow08Green();
	    private InternalSyntaxToken kArrow;
	    private Source08Green source08;
	    private InternalSyntaxToken tArrow;
	    private Target08Green target08;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source08Green source08, InternalSyntaxToken tArrow, Target08Green target08, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source08 != null)
			{
				this.AdjustFlagsAndWidth(source08);
				this.source08 = source08;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target08 != null)
			{
				this.AdjustFlagsAndWidth(target08);
				this.target08 = target08;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow08Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, Source08Green source08, InternalSyntaxToken tArrow, Target08Green target08, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source08 != null)
			{
				this.AdjustFlagsAndWidth(source08);
				this.source08 = source08;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target08 != null)
			{
				this.AdjustFlagsAndWidth(target08);
				this.target08 = target08;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public Source08Green Source08 { get { return this.source08; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public Target08Green Target08 { get { return this.target08; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source08;
	            case 2: return this.tArrow;
	            case 3: return this.target08;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow08Green(this.Kind, this.kArrow, this.source08, this.tArrow, this.target08, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow08Green(this.Kind, this.kArrow, this.source08, this.tArrow, this.target08, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow08Green Update(InternalSyntaxToken kArrow, Source08Green source08, InternalSyntaxToken tArrow, Target08Green target08, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source08 != source08 ||
				this.TArrow != tArrow ||
				this.Target08 != target08 ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow08(kArrow, source08, tArrow, target08, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Source08Green : GreenSyntaxNode
	{
	    internal static readonly Source08Green __Missing = new Source08Green();
	    private NameGreen name;
	
	    public Source08Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public Source08Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private Source08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Source08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitSource08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitSource08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Source08Green(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Source08Green(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public Source08Green Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source08(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Target08Green : GreenSyntaxNode
	{
	    internal static readonly Target08Green __Missing = new Target08Green();
	    private NameGreen name;
	
	    public Target08Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public Target08Green(TestLanguageAnnotationsSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private Target08Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target08, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Target08Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTarget08Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTarget08Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Target08Green(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Target08Green(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public Target08Green Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target08(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target08Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test09Green : GreenSyntaxNode
	{
	    internal static readonly Test09Green __Missing = new Test09Green();
	    private InternalSyntaxToken kTest09;
	    private NamespaceDeclaration09Green namespaceDeclaration09;
	
	    public Test09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest09, NamespaceDeclaration09Green namespaceDeclaration09)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest09 != null)
			{
				this.AdjustFlagsAndWidth(kTest09);
				this.kTest09 = kTest09;
			}
			if (namespaceDeclaration09 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration09);
				this.namespaceDeclaration09 = namespaceDeclaration09;
			}
	    }
	
	    public Test09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest09, NamespaceDeclaration09Green namespaceDeclaration09, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest09 != null)
			{
				this.AdjustFlagsAndWidth(kTest09);
				this.kTest09 = kTest09;
			}
			if (namespaceDeclaration09 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration09);
				this.namespaceDeclaration09 = namespaceDeclaration09;
			}
	    }
	
		private Test09Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test09, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest09 { get { return this.kTest09; } }
	    public NamespaceDeclaration09Green NamespaceDeclaration09 { get { return this.namespaceDeclaration09; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test09Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest09;
	            case 1: return this.namespaceDeclaration09;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest09Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest09Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test09Green(this.Kind, this.kTest09, this.namespaceDeclaration09, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test09Green(this.Kind, this.kTest09, this.namespaceDeclaration09, this.GetDiagnostics(), annotations);
	    }
	
	    public Test09Green Update(InternalSyntaxToken kTest09, NamespaceDeclaration09Green namespaceDeclaration09)
	    {
	        if (this.KTest09 != kTest09 ||
				this.NamespaceDeclaration09 != namespaceDeclaration09)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test09(kTest09, namespaceDeclaration09);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test09Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration09Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration09Green __Missing = new NamespaceDeclaration09Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody09Green namespaceBody09;
	
	    public NamespaceDeclaration09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody09Green namespaceBody09)
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
			if (namespaceBody09 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody09);
				this.namespaceBody09 = namespaceBody09;
			}
	    }
	
	    public NamespaceDeclaration09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody09Green namespaceBody09, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody09 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody09);
				this.namespaceBody09 = namespaceBody09;
			}
	    }
	
		private NamespaceDeclaration09Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration09, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody09Green NamespaceBody09 { get { return this.namespaceBody09; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration09Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody09;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration09Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration09Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration09Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody09, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration09Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody09, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration09Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody09Green namespaceBody09)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody09 != namespaceBody09)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration09(kNamespace, qualifiedName, namespaceBody09);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration09Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody09Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody09Green __Missing = new NamespaceBody09Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration09;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration09, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration09 != null)
			{
				this.AdjustFlagsAndWidth(declaration09);
				this.declaration09 = declaration09;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration09, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration09 != null)
			{
				this.AdjustFlagsAndWidth(declaration09);
				this.declaration09 = declaration09;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody09Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody09, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration09Green> Declaration09 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration09Green>(this.declaration09); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody09Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration09;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody09Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody09Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody09Green(this.Kind, this.tOpenBrace, this.declaration09, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody09Green(this.Kind, this.tOpenBrace, this.declaration09, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody09Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration09Green> declaration09, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration09 != declaration09 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody09(tOpenBrace, declaration09, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody09Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration09Green : GreenSyntaxNode
	{
	    internal static readonly Declaration09Green __Missing = new Declaration09Green();
	    private Vertex09Green vertex09;
	    private Arrow09Green arrow09;
	
	    public Declaration09Green(TestLanguageAnnotationsSyntaxKind kind, Vertex09Green vertex09, Arrow09Green arrow09)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex09 != null)
			{
				this.AdjustFlagsAndWidth(vertex09);
				this.vertex09 = vertex09;
			}
			if (arrow09 != null)
			{
				this.AdjustFlagsAndWidth(arrow09);
				this.arrow09 = arrow09;
			}
	    }
	
	    public Declaration09Green(TestLanguageAnnotationsSyntaxKind kind, Vertex09Green vertex09, Arrow09Green arrow09, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex09 != null)
			{
				this.AdjustFlagsAndWidth(vertex09);
				this.vertex09 = vertex09;
			}
			if (arrow09 != null)
			{
				this.AdjustFlagsAndWidth(arrow09);
				this.arrow09 = arrow09;
			}
	    }
	
		private Declaration09Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration09, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex09Green Vertex09 { get { return this.vertex09; } }
	    public Arrow09Green Arrow09 { get { return this.arrow09; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration09Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex09;
	            case 1: return this.arrow09;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration09Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration09Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration09Green(this.Kind, this.vertex09, this.arrow09, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration09Green(this.Kind, this.vertex09, this.arrow09, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration09Green Update(Vertex09Green vertex09)
	    {
	        if (this.vertex09 != vertex09)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration09(vertex09);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration09Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration09Green Update(Arrow09Green arrow09)
	    {
	        if (this.arrow09 != arrow09)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration09(arrow09);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration09Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex09Green : GreenSyntaxNode
	{
	    internal static readonly Vertex09Green __Missing = new Vertex09Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex09Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex09, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex09Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex09Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex09Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex09Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex09Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex09Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex09(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex09Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow09Green : GreenSyntaxNode
	{
	    internal static readonly Arrow09Green __Missing = new Arrow09Green();
	    private InternalSyntaxToken kArrow;
	    private NameGreen source;
	    private InternalSyntaxToken tArrow;
	    private NameGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow09Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow09Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow09, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public NameGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public NameGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow09Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow09Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow09Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow09Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow09Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow09Green Update(InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow09(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow09Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test10Green : GreenSyntaxNode
	{
	    internal static readonly Test10Green __Missing = new Test10Green();
	    private InternalSyntaxToken kTest10;
	    private NamespaceDeclaration10Green namespaceDeclaration10;
	
	    public Test10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest10, NamespaceDeclaration10Green namespaceDeclaration10)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest10 != null)
			{
				this.AdjustFlagsAndWidth(kTest10);
				this.kTest10 = kTest10;
			}
			if (namespaceDeclaration10 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration10);
				this.namespaceDeclaration10 = namespaceDeclaration10;
			}
	    }
	
	    public Test10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest10, NamespaceDeclaration10Green namespaceDeclaration10, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest10 != null)
			{
				this.AdjustFlagsAndWidth(kTest10);
				this.kTest10 = kTest10;
			}
			if (namespaceDeclaration10 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration10);
				this.namespaceDeclaration10 = namespaceDeclaration10;
			}
	    }
	
		private Test10Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test10, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest10 { get { return this.kTest10; } }
	    public NamespaceDeclaration10Green NamespaceDeclaration10 { get { return this.namespaceDeclaration10; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test10Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest10;
	            case 1: return this.namespaceDeclaration10;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest10Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest10Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test10Green(this.Kind, this.kTest10, this.namespaceDeclaration10, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test10Green(this.Kind, this.kTest10, this.namespaceDeclaration10, this.GetDiagnostics(), annotations);
	    }
	
	    public Test10Green Update(InternalSyntaxToken kTest10, NamespaceDeclaration10Green namespaceDeclaration10)
	    {
	        if (this.KTest10 != kTest10 ||
				this.NamespaceDeclaration10 != namespaceDeclaration10)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test10(kTest10, namespaceDeclaration10);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test10Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration10Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration10Green __Missing = new NamespaceDeclaration10Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody10Green namespaceBody10;
	
	    public NamespaceDeclaration10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody10Green namespaceBody10)
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
			if (namespaceBody10 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody10);
				this.namespaceBody10 = namespaceBody10;
			}
	    }
	
	    public NamespaceDeclaration10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody10Green namespaceBody10, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody10 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody10);
				this.namespaceBody10 = namespaceBody10;
			}
	    }
	
		private NamespaceDeclaration10Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration10, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody10Green NamespaceBody10 { get { return this.namespaceBody10; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration10Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody10;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration10Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration10Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration10Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody10, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration10Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody10, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration10Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody10Green namespaceBody10)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody10 != namespaceBody10)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration10(kNamespace, qualifiedName, namespaceBody10);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration10Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody10Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody10Green __Missing = new NamespaceBody10Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration10;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration10, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration10 != null)
			{
				this.AdjustFlagsAndWidth(declaration10);
				this.declaration10 = declaration10;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration10, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration10 != null)
			{
				this.AdjustFlagsAndWidth(declaration10);
				this.declaration10 = declaration10;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody10Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody10, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration10Green> Declaration10 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration10Green>(this.declaration10); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody10Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration10;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody10Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody10Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody10Green(this.Kind, this.tOpenBrace, this.declaration10, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody10Green(this.Kind, this.tOpenBrace, this.declaration10, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody10Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration10Green> declaration10, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration10 != declaration10 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody10(tOpenBrace, declaration10, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody10Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration10Green : GreenSyntaxNode
	{
	    internal static readonly Declaration10Green __Missing = new Declaration10Green();
	    private Vertex10Green vertex10;
	    private Arrow10Green arrow10;
	
	    public Declaration10Green(TestLanguageAnnotationsSyntaxKind kind, Vertex10Green vertex10, Arrow10Green arrow10)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex10 != null)
			{
				this.AdjustFlagsAndWidth(vertex10);
				this.vertex10 = vertex10;
			}
			if (arrow10 != null)
			{
				this.AdjustFlagsAndWidth(arrow10);
				this.arrow10 = arrow10;
			}
	    }
	
	    public Declaration10Green(TestLanguageAnnotationsSyntaxKind kind, Vertex10Green vertex10, Arrow10Green arrow10, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex10 != null)
			{
				this.AdjustFlagsAndWidth(vertex10);
				this.vertex10 = vertex10;
			}
			if (arrow10 != null)
			{
				this.AdjustFlagsAndWidth(arrow10);
				this.arrow10 = arrow10;
			}
	    }
	
		private Declaration10Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration10, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex10Green Vertex10 { get { return this.vertex10; } }
	    public Arrow10Green Arrow10 { get { return this.arrow10; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration10Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex10;
	            case 1: return this.arrow10;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration10Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration10Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration10Green(this.Kind, this.vertex10, this.arrow10, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration10Green(this.Kind, this.vertex10, this.arrow10, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration10Green Update(Vertex10Green vertex10)
	    {
	        if (this.vertex10 != vertex10)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration10(vertex10);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration10Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration10Green Update(Arrow10Green arrow10)
	    {
	        if (this.arrow10 != arrow10)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration10(arrow10);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration10Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex10Green : GreenSyntaxNode
	{
	    internal static readonly Vertex10Green __Missing = new Vertex10Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex10Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex10, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex10Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex10Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex10Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex10Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex10Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex10Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex10(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex10Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow10Green : GreenSyntaxNode
	{
	    internal static readonly Arrow10Green __Missing = new Arrow10Green();
	    private InternalSyntaxToken kArrow;
	    private NameGreen source;
	    private InternalSyntaxToken tArrow;
	    private NameGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow10Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow10Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow10, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public NameGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public NameGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow10Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow10Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow10Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow10Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow10Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow10Green Update(InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow10(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow10Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Test11Green : GreenSyntaxNode
	{
	    internal static readonly Test11Green __Missing = new Test11Green();
	    private InternalSyntaxToken kTest11;
	    private GreenNode namespaceDeclaration11;
	
	    public Test11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest11, GreenNode namespaceDeclaration11)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTest11 != null)
			{
				this.AdjustFlagsAndWidth(kTest11);
				this.kTest11 = kTest11;
			}
			if (namespaceDeclaration11 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration11);
				this.namespaceDeclaration11 = namespaceDeclaration11;
			}
	    }
	
	    public Test11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kTest11, GreenNode namespaceDeclaration11, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTest11 != null)
			{
				this.AdjustFlagsAndWidth(kTest11);
				this.kTest11 = kTest11;
			}
			if (namespaceDeclaration11 != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration11);
				this.namespaceDeclaration11 = namespaceDeclaration11;
			}
	    }
	
		private Test11Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test11, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTest11 { get { return this.kTest11; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclaration11Green> NamespaceDeclaration11 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclaration11Green>(this.namespaceDeclaration11); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Test11Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTest11;
	            case 1: return this.namespaceDeclaration11;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitTest11Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitTest11Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Test11Green(this.Kind, this.kTest11, this.namespaceDeclaration11, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Test11Green(this.Kind, this.kTest11, this.namespaceDeclaration11, this.GetDiagnostics(), annotations);
	    }
	
	    public Test11Green Update(InternalSyntaxToken kTest11, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclaration11Green> namespaceDeclaration11)
	    {
	        if (this.KTest11 != kTest11 ||
				this.NamespaceDeclaration11 != namespaceDeclaration11)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test11(kTest11, namespaceDeclaration11);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test11Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclaration11Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclaration11Green __Missing = new NamespaceDeclaration11Green();
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBody11Green namespaceBody11;
	
	    public NamespaceDeclaration11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody11Green namespaceBody11)
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
			if (namespaceBody11 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody11);
				this.namespaceBody11 = namespaceBody11;
			}
	    }
	
	    public NamespaceDeclaration11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody11Green namespaceBody11, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (namespaceBody11 != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody11);
				this.namespaceBody11 = namespaceBody11;
			}
	    }
	
		private NamespaceDeclaration11Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration11, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBody11Green NamespaceBody11 { get { return this.namespaceBody11; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceDeclaration11Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody11;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclaration11Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceDeclaration11Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclaration11Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody11, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclaration11Green(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody11, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclaration11Green Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody11Green namespaceBody11)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody11 != namespaceBody11)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration11(kNamespace, qualifiedName, namespaceBody11);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration11Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBody11Green : GreenSyntaxNode
	{
	    internal static readonly NamespaceBody11Green __Missing = new NamespaceBody11Green();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration11;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBody11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration11, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration11 != null)
			{
				this.AdjustFlagsAndWidth(declaration11);
				this.declaration11 = declaration11;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBody11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration11, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration11 != null)
			{
				this.AdjustFlagsAndWidth(declaration11);
				this.declaration11 = declaration11;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBody11Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody11, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration11Green> Declaration11 { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration11Green>(this.declaration11); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NamespaceBody11Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration11;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBody11Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNamespaceBody11Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBody11Green(this.Kind, this.tOpenBrace, this.declaration11, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBody11Green(this.Kind, this.tOpenBrace, this.declaration11, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBody11Green Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration11Green> declaration11, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration11 != declaration11 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody11(tOpenBrace, declaration11, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody11Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Declaration11Green : GreenSyntaxNode
	{
	    internal static readonly Declaration11Green __Missing = new Declaration11Green();
	    private Vertex11Green vertex11;
	    private Arrow11Green arrow11;
	
	    public Declaration11Green(TestLanguageAnnotationsSyntaxKind kind, Vertex11Green vertex11, Arrow11Green arrow11)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (vertex11 != null)
			{
				this.AdjustFlagsAndWidth(vertex11);
				this.vertex11 = vertex11;
			}
			if (arrow11 != null)
			{
				this.AdjustFlagsAndWidth(arrow11);
				this.arrow11 = arrow11;
			}
	    }
	
	    public Declaration11Green(TestLanguageAnnotationsSyntaxKind kind, Vertex11Green vertex11, Arrow11Green arrow11, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (vertex11 != null)
			{
				this.AdjustFlagsAndWidth(vertex11);
				this.vertex11 = vertex11;
			}
			if (arrow11 != null)
			{
				this.AdjustFlagsAndWidth(arrow11);
				this.arrow11 = arrow11;
			}
	    }
	
		private Declaration11Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration11, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Vertex11Green Vertex11 { get { return this.vertex11; } }
	    public Arrow11Green Arrow11 { get { return this.arrow11; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Declaration11Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.vertex11;
	            case 1: return this.arrow11;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDeclaration11Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDeclaration11Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Declaration11Green(this.Kind, this.vertex11, this.arrow11, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Declaration11Green(this.Kind, this.vertex11, this.arrow11, this.GetDiagnostics(), annotations);
	    }
	
	    public Declaration11Green Update(Vertex11Green vertex11)
	    {
	        if (this.vertex11 != vertex11)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration11(vertex11);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration11Green)newNode;
	        }
	        return this;
	    }
	
	    public Declaration11Green Update(Arrow11Green arrow11)
	    {
	        if (this.arrow11 != arrow11)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration11(arrow11);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration11Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Vertex11Green : GreenSyntaxNode
	{
	    internal static readonly Vertex11Green __Missing = new Vertex11Green();
	    private InternalSyntaxToken kVertex;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public Vertex11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Vertex11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kVertex != null)
			{
				this.AdjustFlagsAndWidth(kVertex);
				this.kVertex = kVertex;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Vertex11Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex11, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVertex { get { return this.kVertex; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Vertex11Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVertex;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitVertex11Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitVertex11Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Vertex11Green(this.Kind, this.kVertex, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Vertex11Green(this.Kind, this.kVertex, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Vertex11Green Update(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex11(kVertex, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex11Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Arrow11Green : GreenSyntaxNode
	{
	    internal static readonly Arrow11Green __Missing = new Arrow11Green();
	    private InternalSyntaxToken kArrow;
	    private QualifiedNameGreen source;
	    private InternalSyntaxToken tArrow;
	    private QualifiedNameGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public Arrow11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifiedNameGreen source, InternalSyntaxToken tArrow, QualifiedNameGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public Arrow11Green(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kArrow, QualifiedNameGreen source, InternalSyntaxToken tArrow, QualifiedNameGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kArrow != null)
			{
				this.AdjustFlagsAndWidth(kArrow);
				this.kArrow = kArrow;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private Arrow11Green()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Arrow11, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KArrow { get { return this.kArrow; } }
	    public QualifiedNameGreen Source { get { return this.source; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public QualifiedNameGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.Arrow11Syntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kArrow;
	            case 1: return this.source;
	            case 2: return this.tArrow;
	            case 3: return this.target;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitArrow11Green(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitArrow11Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Arrow11Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Arrow11Green(this.Kind, this.kArrow, this.source, this.tArrow, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public Arrow11Green Update(InternalSyntaxToken kArrow, QualifiedNameGreen source, InternalSyntaxToken tArrow, QualifiedNameGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow11(kArrow, source, tArrow, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow11Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameGreen : GreenSyntaxNode
	{
	    internal static readonly NameGreen __Missing = new NameGreen();
	    private IdentifierGreen identifier;
	
	    public NameGreen(TestLanguageAnnotationsSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(TestLanguageAnnotationsSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private NameGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NameSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NameGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Name(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifiedNameGreen : GreenSyntaxNode
	{
	    internal static readonly QualifiedNameGreen __Missing = new QualifiedNameGreen();
	    private QualifierGreen qualifier;
	
	    public QualifiedNameGreen(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(TestLanguageAnnotationsSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private QualifiedNameGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.QualifiedNameSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	internal class QualifierGreen : GreenSyntaxNode
	{
	    internal static readonly QualifierGreen __Missing = new QualifierGreen();
	    private GreenNode identifier;
	
	    public QualifierGreen(TestLanguageAnnotationsSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(TestLanguageAnnotationsSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private QualifierGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.QualifierSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifierGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierGreen __Missing = new IdentifierGreen();
	    private InternalSyntaxToken identifier;
	
	    public IdentifierGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private IdentifierGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.IdentifierSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(InternalSyntaxToken identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Identifier(identifier);
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
	    private IntegerLiteralGreen integerLiteral;
	    private DecimalLiteralGreen decimalLiteral;
	    private ScientificLiteralGreen scientificLiteral;
	    private StringLiteralGreen stringLiteral;
	
	    public LiteralGreen(TestLanguageAnnotationsSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
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
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public LiteralGreen(TestLanguageAnnotationsSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
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
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
		private LiteralGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Literal, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NullLiteralGreen NullLiteral { get { return this.nullLiteral; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public IntegerLiteralGreen IntegerLiteral { get { return this.integerLiteral; } }
	    public DecimalLiteralGreen DecimalLiteral { get { return this.decimalLiteral; } }
	    public ScientificLiteralGreen ScientificLiteral { get { return this.scientificLiteral; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.LiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nullLiteral;
	            case 1: return this.booleanLiteral;
	            case 2: return this.integerLiteral;
	            case 3: return this.decimalLiteral;
	            case 4: return this.scientificLiteral;
	            case 5: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public LiteralGreen Update(NullLiteralGreen nullLiteral)
	    {
	        if (this.nullLiteral != nullLiteral)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	
	    public LiteralGreen Update(IntegerLiteralGreen integerLiteral)
	    {
	        if (this.integerLiteral != integerLiteral)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	
	    public LiteralGreen Update(DecimalLiteralGreen decimalLiteral)
	    {
	        if (this.decimalLiteral != decimalLiteral)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	
	    public LiteralGreen Update(ScientificLiteralGreen scientificLiteral)
	    {
	        if (this.scientificLiteral != scientificLiteral)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	    public NullLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.NullLiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	    public BooleanLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.BooleanLiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	internal class IntegerLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly IntegerLiteralGreen __Missing = new IntegerLiteralGreen();
	    private InternalSyntaxToken lInteger;
	
	    public IntegerLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.IntegerLiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	    public DecimalLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.DecimalLiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	    public ScientificLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.ScientificLiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	
	internal class StringLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly StringLiteralGreen __Missing = new StringLiteralGreen();
	    private InternalSyntaxToken lRegularString;
	
	    public StringLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lRegularString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
	    public StringLiteralGreen(TestLanguageAnnotationsSyntaxKind kind, InternalSyntaxToken lRegularString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
		private StringLiteralGreen()
			: base((TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LRegularString { get { return this.lRegularString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.StringLiteralSyntax(this, (TestLanguageAnnotationsSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lRegularString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestLanguageAnnotationsSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(TestLanguageAnnotationsSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringLiteralGreen(this.Kind, this.lRegularString, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringLiteralGreen(this.Kind, this.lRegularString, this.GetDiagnostics(), annotations);
	    }
	
	    public StringLiteralGreen Update(InternalSyntaxToken lRegularString)
	    {
	        if (this.LRegularString != lRegularString)
	        {
	            InternalSyntaxNode newNode = TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.StringLiteral(lRegularString);
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

	internal class TestLanguageAnnotationsSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitTestGreen(TestGreen node) => this.DefaultVisit(node);
		public virtual void VisitTest01Green(Test01Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration01Green(NamespaceDeclaration01Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody01Green(NamespaceBody01Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration01Green(Declaration01Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex01Green(Vertex01Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow01Green(Arrow01Green node) => this.DefaultVisit(node);
		public virtual void VisitTest02Green(Test02Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration02Green(NamespaceDeclaration02Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody02Green(NamespaceBody02Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration02Green(Declaration02Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex02Green(Vertex02Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow02Green(Arrow02Green node) => this.DefaultVisit(node);
		public virtual void VisitSource02Green(Source02Green node) => this.DefaultVisit(node);
		public virtual void VisitTarget02Green(Target02Green node) => this.DefaultVisit(node);
		public virtual void VisitTest03Green(Test03Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration03Green(NamespaceDeclaration03Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody03Green(NamespaceBody03Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration03Green(Declaration03Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex03Green(Vertex03Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow03Green(Arrow03Green node) => this.DefaultVisit(node);
		public virtual void VisitSource03Green(Source03Green node) => this.DefaultVisit(node);
		public virtual void VisitTarget03Green(Target03Green node) => this.DefaultVisit(node);
		public virtual void VisitTest04Green(Test04Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration04Green(NamespaceDeclaration04Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody04Green(NamespaceBody04Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration04Green(Declaration04Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex04Green(Vertex04Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow04Green(Arrow04Green node) => this.DefaultVisit(node);
		public virtual void VisitTest05Green(Test05Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration05Green(NamespaceDeclaration05Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody05Green(NamespaceBody05Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration05Green(Declaration05Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex05Green(Vertex05Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow05Green(Arrow05Green node) => this.DefaultVisit(node);
		public virtual void VisitTest06Green(Test06Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration06Green(NamespaceDeclaration06Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody06Green(NamespaceBody06Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration06Green(Declaration06Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex06Green(Vertex06Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow06Green(Arrow06Green node) => this.DefaultVisit(node);
		public virtual void VisitTest07Green(Test07Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration07Green(NamespaceDeclaration07Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody07Green(NamespaceBody07Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration07Green(Declaration07Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex07Green(Vertex07Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow07Green(Arrow07Green node) => this.DefaultVisit(node);
		public virtual void VisitSource07Green(Source07Green node) => this.DefaultVisit(node);
		public virtual void VisitTarget07Green(Target07Green node) => this.DefaultVisit(node);
		public virtual void VisitTest08Green(Test08Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration08Green(NamespaceDeclaration08Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody08Green(NamespaceBody08Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration08Green(Declaration08Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex08Green(Vertex08Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow08Green(Arrow08Green node) => this.DefaultVisit(node);
		public virtual void VisitSource08Green(Source08Green node) => this.DefaultVisit(node);
		public virtual void VisitTarget08Green(Target08Green node) => this.DefaultVisit(node);
		public virtual void VisitTest09Green(Test09Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration09Green(NamespaceDeclaration09Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody09Green(NamespaceBody09Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration09Green(Declaration09Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex09Green(Vertex09Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow09Green(Arrow09Green node) => this.DefaultVisit(node);
		public virtual void VisitTest10Green(Test10Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration10Green(NamespaceDeclaration10Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody10Green(NamespaceBody10Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration10Green(Declaration10Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex10Green(Vertex10Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow10Green(Arrow10Green node) => this.DefaultVisit(node);
		public virtual void VisitTest11Green(Test11Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclaration11Green(NamespaceDeclaration11Green node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBody11Green(NamespaceBody11Green node) => this.DefaultVisit(node);
		public virtual void VisitDeclaration11Green(Declaration11Green node) => this.DefaultVisit(node);
		public virtual void VisitVertex11Green(Vertex11Green node) => this.DefaultVisit(node);
		public virtual void VisitArrow11Green(Arrow11Green node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
	}
	
	internal class TestLanguageAnnotationsSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTestGreen(TestGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTest01Green(Test01Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration01Green(NamespaceDeclaration01Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody01Green(NamespaceBody01Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration01Green(Declaration01Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex01Green(Vertex01Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow01Green(Arrow01Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest02Green(Test02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration02Green(NamespaceDeclaration02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody02Green(NamespaceBody02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration02Green(Declaration02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex02Green(Vertex02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow02Green(Arrow02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSource02Green(Source02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTarget02Green(Target02Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest03Green(Test03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration03Green(NamespaceDeclaration03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody03Green(NamespaceBody03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration03Green(Declaration03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex03Green(Vertex03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow03Green(Arrow03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSource03Green(Source03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTarget03Green(Target03Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest04Green(Test04Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration04Green(NamespaceDeclaration04Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody04Green(NamespaceBody04Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration04Green(Declaration04Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex04Green(Vertex04Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow04Green(Arrow04Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest05Green(Test05Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration05Green(NamespaceDeclaration05Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody05Green(NamespaceBody05Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration05Green(Declaration05Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex05Green(Vertex05Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow05Green(Arrow05Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest06Green(Test06Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration06Green(NamespaceDeclaration06Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody06Green(NamespaceBody06Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration06Green(Declaration06Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex06Green(Vertex06Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow06Green(Arrow06Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest07Green(Test07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration07Green(NamespaceDeclaration07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody07Green(NamespaceBody07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration07Green(Declaration07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex07Green(Vertex07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow07Green(Arrow07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSource07Green(Source07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTarget07Green(Target07Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest08Green(Test08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration08Green(NamespaceDeclaration08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody08Green(NamespaceBody08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration08Green(Declaration08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex08Green(Vertex08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow08Green(Arrow08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSource08Green(Source08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTarget08Green(Target08Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest09Green(Test09Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration09Green(NamespaceDeclaration09Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody09Green(NamespaceBody09Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration09Green(Declaration09Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex09Green(Vertex09Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow09Green(Arrow09Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest10Green(Test10Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration10Green(NamespaceDeclaration10Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody10Green(NamespaceBody10Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration10Green(Declaration10Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex10Green(Vertex10Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow10Green(Arrow10Green node) => this.DefaultVisit(node);
		public virtual TResult VisitTest11Green(Test11Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclaration11Green(NamespaceDeclaration11Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBody11Green(NamespaceBody11Green node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclaration11Green(Declaration11Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVertex11Green(Vertex11Green node) => this.DefaultVisit(node);
		public virtual TResult VisitArrow11Green(Arrow11Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
	}
	internal class TestLanguageAnnotationsInternalSyntaxFactory : InternalSyntaxFactory, MetaDslx.Languages.Antlr4Roslyn.IAntlr4SyntaxFactory
	{
		public TestLanguageAnnotationsInternalSyntaxFactory(TestLanguageAnnotationsSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public Antlr4.Runtime.Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new TestLanguageAnnotationsLexer(input);
	    }
	
	    public Antlr4.Runtime.Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new TestLanguageAnnotationsParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
		{
			return new TestLanguageAnnotationsSyntaxLexer(text, (TestLanguageAnnotationsParseOptions)options ?? TestLanguageAnnotationsParseOptions.Default);
		}
	
	    public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
		{
			return new TestLanguageAnnotationsSyntaxParser(text, (TestLanguageAnnotationsParseOptions)options ?? TestLanguageAnnotationsParseOptions.Default, (TestLanguageAnnotationsSyntaxNode)oldTree, changes, cancellationToken);
		}
	
	    public override Language Language => TestLanguageAnnotationsLanguage.Instance;
	
		private TestLanguageAnnotationsSyntaxKind ToTestLanguageAnnotationsSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<TestLanguageAnnotationsSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToTestLanguageAnnotationsSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToTestLanguageAnnotationsSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToTestLanguageAnnotationsSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
		{
			return new GreenSkippedTokensTriviaSyntax(ToTestLanguageAnnotationsSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToTestLanguageAnnotationsSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToTestLanguageAnnotationsSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			TestLanguageAnnotationsSyntaxKind typedKind = ToTestLanguageAnnotationsSyntaxKind(kind);
	        Debug.Assert(TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			TestLanguageAnnotationsSyntaxKind typedKind = ToTestLanguageAnnotationsSyntaxKind(kind);
	        Debug.Assert(TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			TestLanguageAnnotationsSyntaxKind typedKind = ToTestLanguageAnnotationsSyntaxKind(kind);
	        Debug.Assert(TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestLanguageAnnotationsLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToTestLanguageAnnotationsSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToTestLanguageAnnotationsSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToTestLanguageAnnotationsSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken TAsterisk(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDateTime, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDate, text, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LDate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LTime, text, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LRegularString, text, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LGuid, text, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LComment, text, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text, object value)
	    {
	        return Token(null, TestLanguageAnnotationsSyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<TestGreen> test, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != TestLanguageAnnotationsSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Main, test.Node, eOF, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(TestLanguageAnnotationsSyntaxKind.Main, test.Node, eOF);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TestGreen Test(Test01Green test01)
	    {
	#if DEBUG
		    if (test01 == null) throw new ArgumentNullException(nameof(test01));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, test01, null, null, null, null, null, null, null, null, null, null);
	    }
	
		public TestGreen Test(Test02Green test02)
	    {
	#if DEBUG
		    if (test02 == null) throw new ArgumentNullException(nameof(test02));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, test02, null, null, null, null, null, null, null, null, null);
	    }
	
		public TestGreen Test(Test03Green test03)
	    {
	#if DEBUG
		    if (test03 == null) throw new ArgumentNullException(nameof(test03));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, test03, null, null, null, null, null, null, null, null);
	    }
	
		public TestGreen Test(Test04Green test04)
	    {
	#if DEBUG
		    if (test04 == null) throw new ArgumentNullException(nameof(test04));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, test04, null, null, null, null, null, null, null);
	    }
	
		public TestGreen Test(Test05Green test05)
	    {
	#if DEBUG
		    if (test05 == null) throw new ArgumentNullException(nameof(test05));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, test05, null, null, null, null, null, null);
	    }
	
		public TestGreen Test(Test06Green test06)
	    {
	#if DEBUG
		    if (test06 == null) throw new ArgumentNullException(nameof(test06));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, null, test06, null, null, null, null, null);
	    }
	
		public TestGreen Test(Test07Green test07)
	    {
	#if DEBUG
		    if (test07 == null) throw new ArgumentNullException(nameof(test07));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, null, null, test07, null, null, null, null);
	    }
	
		public TestGreen Test(Test08Green test08)
	    {
	#if DEBUG
		    if (test08 == null) throw new ArgumentNullException(nameof(test08));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, null, null, null, test08, null, null, null);
	    }
	
		public TestGreen Test(Test09Green test09)
	    {
	#if DEBUG
		    if (test09 == null) throw new ArgumentNullException(nameof(test09));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, null, null, null, null, test09, null, null);
	    }
	
		public TestGreen Test(Test10Green test10)
	    {
	#if DEBUG
		    if (test10 == null) throw new ArgumentNullException(nameof(test10));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, null, null, null, null, null, test10, null);
	    }
	
		public TestGreen Test(Test11Green test11)
	    {
	#if DEBUG
		    if (test11 == null) throw new ArgumentNullException(nameof(test11));
	#endif
			return new TestGreen(TestLanguageAnnotationsSyntaxKind.Test, null, null, null, null, null, null, null, null, null, null, test11);
	    }
	
		public Test01Green Test01(InternalSyntaxToken kTest01, NamespaceDeclaration01Green namespaceDeclaration01)
	    {
	#if DEBUG
			if (kTest01 == null) throw new ArgumentNullException(nameof(kTest01));
			if (kTest01.Kind != TestLanguageAnnotationsSyntaxKind.KTest01) throw new ArgumentException(nameof(kTest01));
			if (namespaceDeclaration01 == null) throw new ArgumentNullException(nameof(namespaceDeclaration01));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test01, kTest01, namespaceDeclaration01, out hash);
			if (cached != null) return (Test01Green)cached;
			var result = new Test01Green(TestLanguageAnnotationsSyntaxKind.Test01, kTest01, namespaceDeclaration01);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration01Green NamespaceDeclaration01(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody01Green namespaceBody01)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody01 == null) throw new ArgumentNullException(nameof(namespaceBody01));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration01, kNamespace, qualifiedName, namespaceBody01, out hash);
			if (cached != null) return (NamespaceDeclaration01Green)cached;
			var result = new NamespaceDeclaration01Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration01, kNamespace, qualifiedName, namespaceBody01);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody01Green NamespaceBody01(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration01Green> declaration01, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody01, tOpenBrace, declaration01.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody01Green)cached;
			var result = new NamespaceBody01Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody01, tOpenBrace, declaration01.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration01Green Declaration01(Vertex01Green vertex01)
	    {
	#if DEBUG
		    if (vertex01 == null) throw new ArgumentNullException(nameof(vertex01));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration01, vertex01, out hash);
			if (cached != null) return (Declaration01Green)cached;
			var result = new Declaration01Green(TestLanguageAnnotationsSyntaxKind.Declaration01, vertex01, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration01Green Declaration01(Arrow01Green arrow01)
	    {
	#if DEBUG
		    if (arrow01 == null) throw new ArgumentNullException(nameof(arrow01));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration01, arrow01, out hash);
			if (cached != null) return (Declaration01Green)cached;
			var result = new Declaration01Green(TestLanguageAnnotationsSyntaxKind.Declaration01, null, arrow01);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex01Green Vertex01(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex01, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex01Green)cached;
			var result = new Vertex01Green(TestLanguageAnnotationsSyntaxKind.Vertex01, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow01Green Arrow01(InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow01Green(TestLanguageAnnotationsSyntaxKind.Arrow01, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public Test02Green Test02(InternalSyntaxToken kTest02, NamespaceDeclaration02Green namespaceDeclaration02)
	    {
	#if DEBUG
			if (kTest02 == null) throw new ArgumentNullException(nameof(kTest02));
			if (kTest02.Kind != TestLanguageAnnotationsSyntaxKind.KTest02) throw new ArgumentException(nameof(kTest02));
			if (namespaceDeclaration02 == null) throw new ArgumentNullException(nameof(namespaceDeclaration02));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test02, kTest02, namespaceDeclaration02, out hash);
			if (cached != null) return (Test02Green)cached;
			var result = new Test02Green(TestLanguageAnnotationsSyntaxKind.Test02, kTest02, namespaceDeclaration02);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration02Green NamespaceDeclaration02(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody02Green namespaceBody02)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody02 == null) throw new ArgumentNullException(nameof(namespaceBody02));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration02, kNamespace, qualifiedName, namespaceBody02, out hash);
			if (cached != null) return (NamespaceDeclaration02Green)cached;
			var result = new NamespaceDeclaration02Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration02, kNamespace, qualifiedName, namespaceBody02);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody02Green NamespaceBody02(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration02Green> declaration02, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody02, tOpenBrace, declaration02.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody02Green)cached;
			var result = new NamespaceBody02Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody02, tOpenBrace, declaration02.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration02Green Declaration02(Vertex02Green vertex02)
	    {
	#if DEBUG
		    if (vertex02 == null) throw new ArgumentNullException(nameof(vertex02));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration02, vertex02, out hash);
			if (cached != null) return (Declaration02Green)cached;
			var result = new Declaration02Green(TestLanguageAnnotationsSyntaxKind.Declaration02, vertex02, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration02Green Declaration02(Arrow02Green arrow02)
	    {
	#if DEBUG
		    if (arrow02 == null) throw new ArgumentNullException(nameof(arrow02));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration02, arrow02, out hash);
			if (cached != null) return (Declaration02Green)cached;
			var result = new Declaration02Green(TestLanguageAnnotationsSyntaxKind.Declaration02, null, arrow02);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex02Green Vertex02(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex02, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex02Green)cached;
			var result = new Vertex02Green(TestLanguageAnnotationsSyntaxKind.Vertex02, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow02Green Arrow02(InternalSyntaxToken kArrow, Source02Green source02, InternalSyntaxToken tArrow, Target02Green target02, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source02 == null) throw new ArgumentNullException(nameof(source02));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target02 == null) throw new ArgumentNullException(nameof(target02));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow02Green(TestLanguageAnnotationsSyntaxKind.Arrow02, kArrow, source02, tArrow, target02, tSemicolon);
	    }
	
		public Source02Green Source02(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source02, qualifier, out hash);
			if (cached != null) return (Source02Green)cached;
			var result = new Source02Green(TestLanguageAnnotationsSyntaxKind.Source02, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Target02Green Target02(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target02, qualifier, out hash);
			if (cached != null) return (Target02Green)cached;
			var result = new Target02Green(TestLanguageAnnotationsSyntaxKind.Target02, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Test03Green Test03(InternalSyntaxToken kTest03, NamespaceDeclaration03Green namespaceDeclaration03)
	    {
	#if DEBUG
			if (kTest03 == null) throw new ArgumentNullException(nameof(kTest03));
			if (kTest03.Kind != TestLanguageAnnotationsSyntaxKind.KTest03) throw new ArgumentException(nameof(kTest03));
			if (namespaceDeclaration03 == null) throw new ArgumentNullException(nameof(namespaceDeclaration03));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test03, kTest03, namespaceDeclaration03, out hash);
			if (cached != null) return (Test03Green)cached;
			var result = new Test03Green(TestLanguageAnnotationsSyntaxKind.Test03, kTest03, namespaceDeclaration03);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration03Green NamespaceDeclaration03(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody03Green namespaceBody03)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody03 == null) throw new ArgumentNullException(nameof(namespaceBody03));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration03, kNamespace, qualifiedName, namespaceBody03, out hash);
			if (cached != null) return (NamespaceDeclaration03Green)cached;
			var result = new NamespaceDeclaration03Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration03, kNamespace, qualifiedName, namespaceBody03);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody03Green NamespaceBody03(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration03Green> declaration03, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody03, tOpenBrace, declaration03.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody03Green)cached;
			var result = new NamespaceBody03Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody03, tOpenBrace, declaration03.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration03Green Declaration03(Vertex03Green vertex03)
	    {
	#if DEBUG
		    if (vertex03 == null) throw new ArgumentNullException(nameof(vertex03));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration03, vertex03, out hash);
			if (cached != null) return (Declaration03Green)cached;
			var result = new Declaration03Green(TestLanguageAnnotationsSyntaxKind.Declaration03, vertex03, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration03Green Declaration03(Arrow03Green arrow03)
	    {
	#if DEBUG
		    if (arrow03 == null) throw new ArgumentNullException(nameof(arrow03));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration03, arrow03, out hash);
			if (cached != null) return (Declaration03Green)cached;
			var result = new Declaration03Green(TestLanguageAnnotationsSyntaxKind.Declaration03, null, arrow03);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex03Green Vertex03(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex03, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex03Green)cached;
			var result = new Vertex03Green(TestLanguageAnnotationsSyntaxKind.Vertex03, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow03Green Arrow03(InternalSyntaxToken kArrow, Source03Green source03, InternalSyntaxToken tArrow, Target03Green target03, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source03 == null) throw new ArgumentNullException(nameof(source03));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target03 == null) throw new ArgumentNullException(nameof(target03));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow03Green(TestLanguageAnnotationsSyntaxKind.Arrow03, kArrow, source03, tArrow, target03, tSemicolon);
	    }
	
		public Source03Green Source03(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source03, qualifier, out hash);
			if (cached != null) return (Source03Green)cached;
			var result = new Source03Green(TestLanguageAnnotationsSyntaxKind.Source03, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Target03Green Target03(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target03, qualifier, out hash);
			if (cached != null) return (Target03Green)cached;
			var result = new Target03Green(TestLanguageAnnotationsSyntaxKind.Target03, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Test04Green Test04(InternalSyntaxToken kTest04, NamespaceDeclaration04Green namespaceDeclaration04)
	    {
	#if DEBUG
			if (kTest04 == null) throw new ArgumentNullException(nameof(kTest04));
			if (kTest04.Kind != TestLanguageAnnotationsSyntaxKind.KTest04) throw new ArgumentException(nameof(kTest04));
			if (namespaceDeclaration04 == null) throw new ArgumentNullException(nameof(namespaceDeclaration04));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test04, kTest04, namespaceDeclaration04, out hash);
			if (cached != null) return (Test04Green)cached;
			var result = new Test04Green(TestLanguageAnnotationsSyntaxKind.Test04, kTest04, namespaceDeclaration04);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration04Green NamespaceDeclaration04(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody04Green namespaceBody04)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody04 == null) throw new ArgumentNullException(nameof(namespaceBody04));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration04, kNamespace, qualifiedName, namespaceBody04, out hash);
			if (cached != null) return (NamespaceDeclaration04Green)cached;
			var result = new NamespaceDeclaration04Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration04, kNamespace, qualifiedName, namespaceBody04);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody04Green NamespaceBody04(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration04Green> declaration04, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody04, tOpenBrace, declaration04.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody04Green)cached;
			var result = new NamespaceBody04Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody04, tOpenBrace, declaration04.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration04Green Declaration04(Vertex04Green vertex04)
	    {
	#if DEBUG
		    if (vertex04 == null) throw new ArgumentNullException(nameof(vertex04));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration04, vertex04, out hash);
			if (cached != null) return (Declaration04Green)cached;
			var result = new Declaration04Green(TestLanguageAnnotationsSyntaxKind.Declaration04, vertex04, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration04Green Declaration04(Arrow04Green arrow04)
	    {
	#if DEBUG
		    if (arrow04 == null) throw new ArgumentNullException(nameof(arrow04));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration04, arrow04, out hash);
			if (cached != null) return (Declaration04Green)cached;
			var result = new Declaration04Green(TestLanguageAnnotationsSyntaxKind.Declaration04, null, arrow04);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex04Green Vertex04(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex04, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex04Green)cached;
			var result = new Vertex04Green(TestLanguageAnnotationsSyntaxKind.Vertex04, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow04Green Arrow04(InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow04Green(TestLanguageAnnotationsSyntaxKind.Arrow04, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public Test05Green Test05(InternalSyntaxToken kTest05, NamespaceDeclaration05Green namespaceDeclaration05)
	    {
	#if DEBUG
			if (kTest05 == null) throw new ArgumentNullException(nameof(kTest05));
			if (kTest05.Kind != TestLanguageAnnotationsSyntaxKind.KTest05) throw new ArgumentException(nameof(kTest05));
			if (namespaceDeclaration05 == null) throw new ArgumentNullException(nameof(namespaceDeclaration05));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test05, kTest05, namespaceDeclaration05, out hash);
			if (cached != null) return (Test05Green)cached;
			var result = new Test05Green(TestLanguageAnnotationsSyntaxKind.Test05, kTest05, namespaceDeclaration05);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration05Green NamespaceDeclaration05(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody05Green namespaceBody05)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody05 == null) throw new ArgumentNullException(nameof(namespaceBody05));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration05, kNamespace, qualifiedName, namespaceBody05, out hash);
			if (cached != null) return (NamespaceDeclaration05Green)cached;
			var result = new NamespaceDeclaration05Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration05, kNamespace, qualifiedName, namespaceBody05);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody05Green NamespaceBody05(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration05Green> declaration05, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody05, tOpenBrace, declaration05.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody05Green)cached;
			var result = new NamespaceBody05Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody05, tOpenBrace, declaration05.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration05Green Declaration05(Vertex05Green vertex05)
	    {
	#if DEBUG
		    if (vertex05 == null) throw new ArgumentNullException(nameof(vertex05));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration05, vertex05, out hash);
			if (cached != null) return (Declaration05Green)cached;
			var result = new Declaration05Green(TestLanguageAnnotationsSyntaxKind.Declaration05, vertex05, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration05Green Declaration05(Arrow05Green arrow05)
	    {
	#if DEBUG
		    if (arrow05 == null) throw new ArgumentNullException(nameof(arrow05));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration05, arrow05, out hash);
			if (cached != null) return (Declaration05Green)cached;
			var result = new Declaration05Green(TestLanguageAnnotationsSyntaxKind.Declaration05, null, arrow05);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex05Green Vertex05(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex05, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex05Green)cached;
			var result = new Vertex05Green(TestLanguageAnnotationsSyntaxKind.Vertex05, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow05Green Arrow05(InternalSyntaxToken kArrow, QualifierGreen source, InternalSyntaxToken tArrow, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow05Green(TestLanguageAnnotationsSyntaxKind.Arrow05, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public Test06Green Test06(InternalSyntaxToken kTest06, NamespaceDeclaration06Green namespaceDeclaration06)
	    {
	#if DEBUG
			if (kTest06 == null) throw new ArgumentNullException(nameof(kTest06));
			if (kTest06.Kind != TestLanguageAnnotationsSyntaxKind.KTest06) throw new ArgumentException(nameof(kTest06));
			if (namespaceDeclaration06 == null) throw new ArgumentNullException(nameof(namespaceDeclaration06));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test06, kTest06, namespaceDeclaration06, out hash);
			if (cached != null) return (Test06Green)cached;
			var result = new Test06Green(TestLanguageAnnotationsSyntaxKind.Test06, kTest06, namespaceDeclaration06);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration06Green NamespaceDeclaration06(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody06Green namespaceBody06)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody06 == null) throw new ArgumentNullException(nameof(namespaceBody06));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration06, kNamespace, qualifiedName, namespaceBody06, out hash);
			if (cached != null) return (NamespaceDeclaration06Green)cached;
			var result = new NamespaceDeclaration06Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration06, kNamespace, qualifiedName, namespaceBody06);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody06Green NamespaceBody06(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration06Green> declaration06, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody06, tOpenBrace, declaration06.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody06Green)cached;
			var result = new NamespaceBody06Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody06, tOpenBrace, declaration06.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration06Green Declaration06(Vertex06Green vertex06)
	    {
	#if DEBUG
		    if (vertex06 == null) throw new ArgumentNullException(nameof(vertex06));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration06, vertex06, out hash);
			if (cached != null) return (Declaration06Green)cached;
			var result = new Declaration06Green(TestLanguageAnnotationsSyntaxKind.Declaration06, vertex06, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration06Green Declaration06(Arrow06Green arrow06)
	    {
	#if DEBUG
		    if (arrow06 == null) throw new ArgumentNullException(nameof(arrow06));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration06, arrow06, out hash);
			if (cached != null) return (Declaration06Green)cached;
			var result = new Declaration06Green(TestLanguageAnnotationsSyntaxKind.Declaration06, null, arrow06);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex06Green Vertex06(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex06, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex06Green)cached;
			var result = new Vertex06Green(TestLanguageAnnotationsSyntaxKind.Vertex06, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow06Green Arrow06(InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow06Green(TestLanguageAnnotationsSyntaxKind.Arrow06, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public Test07Green Test07(InternalSyntaxToken kTest07, NamespaceDeclaration07Green namespaceDeclaration07)
	    {
	#if DEBUG
			if (kTest07 == null) throw new ArgumentNullException(nameof(kTest07));
			if (kTest07.Kind != TestLanguageAnnotationsSyntaxKind.KTest07) throw new ArgumentException(nameof(kTest07));
			if (namespaceDeclaration07 == null) throw new ArgumentNullException(nameof(namespaceDeclaration07));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test07, kTest07, namespaceDeclaration07, out hash);
			if (cached != null) return (Test07Green)cached;
			var result = new Test07Green(TestLanguageAnnotationsSyntaxKind.Test07, kTest07, namespaceDeclaration07);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration07Green NamespaceDeclaration07(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody07Green namespaceBody07)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody07 == null) throw new ArgumentNullException(nameof(namespaceBody07));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration07, kNamespace, qualifiedName, namespaceBody07, out hash);
			if (cached != null) return (NamespaceDeclaration07Green)cached;
			var result = new NamespaceDeclaration07Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration07, kNamespace, qualifiedName, namespaceBody07);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody07Green NamespaceBody07(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration07Green> declaration07, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody07, tOpenBrace, declaration07.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody07Green)cached;
			var result = new NamespaceBody07Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody07, tOpenBrace, declaration07.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration07Green Declaration07(Vertex07Green vertex07)
	    {
	#if DEBUG
		    if (vertex07 == null) throw new ArgumentNullException(nameof(vertex07));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration07, vertex07, out hash);
			if (cached != null) return (Declaration07Green)cached;
			var result = new Declaration07Green(TestLanguageAnnotationsSyntaxKind.Declaration07, vertex07, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration07Green Declaration07(Arrow07Green arrow07)
	    {
	#if DEBUG
		    if (arrow07 == null) throw new ArgumentNullException(nameof(arrow07));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration07, arrow07, out hash);
			if (cached != null) return (Declaration07Green)cached;
			var result = new Declaration07Green(TestLanguageAnnotationsSyntaxKind.Declaration07, null, arrow07);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex07Green Vertex07(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex07, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex07Green)cached;
			var result = new Vertex07Green(TestLanguageAnnotationsSyntaxKind.Vertex07, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow07Green Arrow07(InternalSyntaxToken kArrow, Source07Green source07, InternalSyntaxToken tArrow, Target07Green target07, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source07 == null) throw new ArgumentNullException(nameof(source07));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target07 == null) throw new ArgumentNullException(nameof(target07));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow07Green(TestLanguageAnnotationsSyntaxKind.Arrow07, kArrow, source07, tArrow, target07, tSemicolon);
	    }
	
		public Source07Green Source07(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source07, name, out hash);
			if (cached != null) return (Source07Green)cached;
			var result = new Source07Green(TestLanguageAnnotationsSyntaxKind.Source07, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Target07Green Target07(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target07, name, out hash);
			if (cached != null) return (Target07Green)cached;
			var result = new Target07Green(TestLanguageAnnotationsSyntaxKind.Target07, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Test08Green Test08(InternalSyntaxToken kTest08, NamespaceDeclaration08Green namespaceDeclaration08)
	    {
	#if DEBUG
			if (kTest08 == null) throw new ArgumentNullException(nameof(kTest08));
			if (kTest08.Kind != TestLanguageAnnotationsSyntaxKind.KTest08) throw new ArgumentException(nameof(kTest08));
			if (namespaceDeclaration08 == null) throw new ArgumentNullException(nameof(namespaceDeclaration08));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test08, kTest08, namespaceDeclaration08, out hash);
			if (cached != null) return (Test08Green)cached;
			var result = new Test08Green(TestLanguageAnnotationsSyntaxKind.Test08, kTest08, namespaceDeclaration08);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration08Green NamespaceDeclaration08(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody08Green namespaceBody08)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody08 == null) throw new ArgumentNullException(nameof(namespaceBody08));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration08, kNamespace, qualifiedName, namespaceBody08, out hash);
			if (cached != null) return (NamespaceDeclaration08Green)cached;
			var result = new NamespaceDeclaration08Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration08, kNamespace, qualifiedName, namespaceBody08);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody08Green NamespaceBody08(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration08Green> declaration08, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody08, tOpenBrace, declaration08.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody08Green)cached;
			var result = new NamespaceBody08Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody08, tOpenBrace, declaration08.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration08Green Declaration08(Vertex08Green vertex08)
	    {
	#if DEBUG
		    if (vertex08 == null) throw new ArgumentNullException(nameof(vertex08));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration08, vertex08, out hash);
			if (cached != null) return (Declaration08Green)cached;
			var result = new Declaration08Green(TestLanguageAnnotationsSyntaxKind.Declaration08, vertex08, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration08Green Declaration08(Arrow08Green arrow08)
	    {
	#if DEBUG
		    if (arrow08 == null) throw new ArgumentNullException(nameof(arrow08));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration08, arrow08, out hash);
			if (cached != null) return (Declaration08Green)cached;
			var result = new Declaration08Green(TestLanguageAnnotationsSyntaxKind.Declaration08, null, arrow08);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex08Green Vertex08(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex08, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex08Green)cached;
			var result = new Vertex08Green(TestLanguageAnnotationsSyntaxKind.Vertex08, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow08Green Arrow08(InternalSyntaxToken kArrow, Source08Green source08, InternalSyntaxToken tArrow, Target08Green target08, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source08 == null) throw new ArgumentNullException(nameof(source08));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target08 == null) throw new ArgumentNullException(nameof(target08));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow08Green(TestLanguageAnnotationsSyntaxKind.Arrow08, kArrow, source08, tArrow, target08, tSemicolon);
	    }
	
		public Source08Green Source08(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Source08, name, out hash);
			if (cached != null) return (Source08Green)cached;
			var result = new Source08Green(TestLanguageAnnotationsSyntaxKind.Source08, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Target08Green Target08(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Target08, name, out hash);
			if (cached != null) return (Target08Green)cached;
			var result = new Target08Green(TestLanguageAnnotationsSyntaxKind.Target08, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Test09Green Test09(InternalSyntaxToken kTest09, NamespaceDeclaration09Green namespaceDeclaration09)
	    {
	#if DEBUG
			if (kTest09 == null) throw new ArgumentNullException(nameof(kTest09));
			if (kTest09.Kind != TestLanguageAnnotationsSyntaxKind.KTest09) throw new ArgumentException(nameof(kTest09));
			if (namespaceDeclaration09 == null) throw new ArgumentNullException(nameof(namespaceDeclaration09));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test09, kTest09, namespaceDeclaration09, out hash);
			if (cached != null) return (Test09Green)cached;
			var result = new Test09Green(TestLanguageAnnotationsSyntaxKind.Test09, kTest09, namespaceDeclaration09);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration09Green NamespaceDeclaration09(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody09Green namespaceBody09)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody09 == null) throw new ArgumentNullException(nameof(namespaceBody09));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration09, kNamespace, qualifiedName, namespaceBody09, out hash);
			if (cached != null) return (NamespaceDeclaration09Green)cached;
			var result = new NamespaceDeclaration09Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration09, kNamespace, qualifiedName, namespaceBody09);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody09Green NamespaceBody09(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration09Green> declaration09, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody09, tOpenBrace, declaration09.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody09Green)cached;
			var result = new NamespaceBody09Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody09, tOpenBrace, declaration09.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration09Green Declaration09(Vertex09Green vertex09)
	    {
	#if DEBUG
		    if (vertex09 == null) throw new ArgumentNullException(nameof(vertex09));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration09, vertex09, out hash);
			if (cached != null) return (Declaration09Green)cached;
			var result = new Declaration09Green(TestLanguageAnnotationsSyntaxKind.Declaration09, vertex09, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration09Green Declaration09(Arrow09Green arrow09)
	    {
	#if DEBUG
		    if (arrow09 == null) throw new ArgumentNullException(nameof(arrow09));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration09, arrow09, out hash);
			if (cached != null) return (Declaration09Green)cached;
			var result = new Declaration09Green(TestLanguageAnnotationsSyntaxKind.Declaration09, null, arrow09);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex09Green Vertex09(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex09, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex09Green)cached;
			var result = new Vertex09Green(TestLanguageAnnotationsSyntaxKind.Vertex09, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow09Green Arrow09(InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow09Green(TestLanguageAnnotationsSyntaxKind.Arrow09, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public Test10Green Test10(InternalSyntaxToken kTest10, NamespaceDeclaration10Green namespaceDeclaration10)
	    {
	#if DEBUG
			if (kTest10 == null) throw new ArgumentNullException(nameof(kTest10));
			if (kTest10.Kind != TestLanguageAnnotationsSyntaxKind.KTest10) throw new ArgumentException(nameof(kTest10));
			if (namespaceDeclaration10 == null) throw new ArgumentNullException(nameof(namespaceDeclaration10));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test10, kTest10, namespaceDeclaration10, out hash);
			if (cached != null) return (Test10Green)cached;
			var result = new Test10Green(TestLanguageAnnotationsSyntaxKind.Test10, kTest10, namespaceDeclaration10);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration10Green NamespaceDeclaration10(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody10Green namespaceBody10)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody10 == null) throw new ArgumentNullException(nameof(namespaceBody10));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration10, kNamespace, qualifiedName, namespaceBody10, out hash);
			if (cached != null) return (NamespaceDeclaration10Green)cached;
			var result = new NamespaceDeclaration10Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration10, kNamespace, qualifiedName, namespaceBody10);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody10Green NamespaceBody10(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration10Green> declaration10, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody10, tOpenBrace, declaration10.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody10Green)cached;
			var result = new NamespaceBody10Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody10, tOpenBrace, declaration10.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration10Green Declaration10(Vertex10Green vertex10)
	    {
	#if DEBUG
		    if (vertex10 == null) throw new ArgumentNullException(nameof(vertex10));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration10, vertex10, out hash);
			if (cached != null) return (Declaration10Green)cached;
			var result = new Declaration10Green(TestLanguageAnnotationsSyntaxKind.Declaration10, vertex10, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration10Green Declaration10(Arrow10Green arrow10)
	    {
	#if DEBUG
		    if (arrow10 == null) throw new ArgumentNullException(nameof(arrow10));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration10, arrow10, out hash);
			if (cached != null) return (Declaration10Green)cached;
			var result = new Declaration10Green(TestLanguageAnnotationsSyntaxKind.Declaration10, null, arrow10);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex10Green Vertex10(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex10, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex10Green)cached;
			var result = new Vertex10Green(TestLanguageAnnotationsSyntaxKind.Vertex10, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow10Green Arrow10(InternalSyntaxToken kArrow, NameGreen source, InternalSyntaxToken tArrow, NameGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow10Green(TestLanguageAnnotationsSyntaxKind.Arrow10, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public Test11Green Test11(InternalSyntaxToken kTest11, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclaration11Green> namespaceDeclaration11)
	    {
	#if DEBUG
			if (kTest11 == null) throw new ArgumentNullException(nameof(kTest11));
			if (kTest11.Kind != TestLanguageAnnotationsSyntaxKind.KTest11) throw new ArgumentException(nameof(kTest11));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Test11, kTest11, namespaceDeclaration11.Node, out hash);
			if (cached != null) return (Test11Green)cached;
			var result = new Test11Green(TestLanguageAnnotationsSyntaxKind.Test11, kTest11, namespaceDeclaration11.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclaration11Green NamespaceDeclaration11(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBody11Green namespaceBody11)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody11 == null) throw new ArgumentNullException(nameof(namespaceBody11));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration11, kNamespace, qualifiedName, namespaceBody11, out hash);
			if (cached != null) return (NamespaceDeclaration11Green)cached;
			var result = new NamespaceDeclaration11Green(TestLanguageAnnotationsSyntaxKind.NamespaceDeclaration11, kNamespace, qualifiedName, namespaceBody11);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBody11Green NamespaceBody11(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<Declaration11Green> declaration11, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NamespaceBody11, tOpenBrace, declaration11.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBody11Green)cached;
			var result = new NamespaceBody11Green(TestLanguageAnnotationsSyntaxKind.NamespaceBody11, tOpenBrace, declaration11.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration11Green Declaration11(Vertex11Green vertex11)
	    {
	#if DEBUG
		    if (vertex11 == null) throw new ArgumentNullException(nameof(vertex11));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration11, vertex11, out hash);
			if (cached != null) return (Declaration11Green)cached;
			var result = new Declaration11Green(TestLanguageAnnotationsSyntaxKind.Declaration11, vertex11, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Declaration11Green Declaration11(Arrow11Green arrow11)
	    {
	#if DEBUG
		    if (arrow11 == null) throw new ArgumentNullException(nameof(arrow11));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Declaration11, arrow11, out hash);
			if (cached != null) return (Declaration11Green)cached;
			var result = new Declaration11Green(TestLanguageAnnotationsSyntaxKind.Declaration11, null, arrow11);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Vertex11Green Vertex11(InternalSyntaxToken kVertex, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
			if (kVertex.Kind != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Vertex11, kVertex, name, tSemicolon, out hash);
			if (cached != null) return (Vertex11Green)cached;
			var result = new Vertex11Green(TestLanguageAnnotationsSyntaxKind.Vertex11, kVertex, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Arrow11Green Arrow11(InternalSyntaxToken kArrow, QualifiedNameGreen source, InternalSyntaxToken tArrow, QualifiedNameGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
			if (kArrow.Kind != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new Arrow11Green(TestLanguageAnnotationsSyntaxKind.Arrow11, kArrow, source, tArrow, target, tSemicolon);
	    }
	
		public NameGreen Name(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(TestLanguageAnnotationsSyntaxKind.Name, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameGreen QualifiedName(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(TestLanguageAnnotationsSyntaxKind.QualifiedName, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifierGreen Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(TestLanguageAnnotationsSyntaxKind.Qualifier, identifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Identifier, identifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(TestLanguageAnnotationsSyntaxKind.Identifier, identifier);
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
			return new LiteralGreen(TestLanguageAnnotationsSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(TestLanguageAnnotationsSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			return new LiteralGreen(TestLanguageAnnotationsSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			return new LiteralGreen(TestLanguageAnnotationsSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			return new LiteralGreen(TestLanguageAnnotationsSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(TestLanguageAnnotationsSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != TestLanguageAnnotationsSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(TestLanguageAnnotationsSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(TestLanguageAnnotationsSyntaxKind.BooleanLiteral, booleanLiteral);
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
			if (lInteger.Kind != TestLanguageAnnotationsSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(TestLanguageAnnotationsSyntaxKind.IntegerLiteral, lInteger);
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
			if (lDecimal.Kind != TestLanguageAnnotationsSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(TestLanguageAnnotationsSyntaxKind.DecimalLiteral, lDecimal);
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
			if (lScientific.Kind != TestLanguageAnnotationsSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(TestLanguageAnnotationsSyntaxKind.ScientificLiteral, lScientific);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringLiteralGreen StringLiteral(InternalSyntaxToken lRegularString)
	    {
	#if DEBUG
			if (lRegularString == null) throw new ArgumentNullException(nameof(lRegularString));
			if (lRegularString.Kind != TestLanguageAnnotationsSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.StringLiteral, lRegularString, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(TestLanguageAnnotationsSyntaxKind.StringLiteral, lRegularString);
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
				typeof(TestGreen),
				typeof(Test01Green),
				typeof(NamespaceDeclaration01Green),
				typeof(NamespaceBody01Green),
				typeof(Declaration01Green),
				typeof(Vertex01Green),
				typeof(Arrow01Green),
				typeof(Test02Green),
				typeof(NamespaceDeclaration02Green),
				typeof(NamespaceBody02Green),
				typeof(Declaration02Green),
				typeof(Vertex02Green),
				typeof(Arrow02Green),
				typeof(Source02Green),
				typeof(Target02Green),
				typeof(Test03Green),
				typeof(NamespaceDeclaration03Green),
				typeof(NamespaceBody03Green),
				typeof(Declaration03Green),
				typeof(Vertex03Green),
				typeof(Arrow03Green),
				typeof(Source03Green),
				typeof(Target03Green),
				typeof(Test04Green),
				typeof(NamespaceDeclaration04Green),
				typeof(NamespaceBody04Green),
				typeof(Declaration04Green),
				typeof(Vertex04Green),
				typeof(Arrow04Green),
				typeof(Test05Green),
				typeof(NamespaceDeclaration05Green),
				typeof(NamespaceBody05Green),
				typeof(Declaration05Green),
				typeof(Vertex05Green),
				typeof(Arrow05Green),
				typeof(Test06Green),
				typeof(NamespaceDeclaration06Green),
				typeof(NamespaceBody06Green),
				typeof(Declaration06Green),
				typeof(Vertex06Green),
				typeof(Arrow06Green),
				typeof(Test07Green),
				typeof(NamespaceDeclaration07Green),
				typeof(NamespaceBody07Green),
				typeof(Declaration07Green),
				typeof(Vertex07Green),
				typeof(Arrow07Green),
				typeof(Source07Green),
				typeof(Target07Green),
				typeof(Test08Green),
				typeof(NamespaceDeclaration08Green),
				typeof(NamespaceBody08Green),
				typeof(Declaration08Green),
				typeof(Vertex08Green),
				typeof(Arrow08Green),
				typeof(Source08Green),
				typeof(Target08Green),
				typeof(Test09Green),
				typeof(NamespaceDeclaration09Green),
				typeof(NamespaceBody09Green),
				typeof(Declaration09Green),
				typeof(Vertex09Green),
				typeof(Arrow09Green),
				typeof(Test10Green),
				typeof(NamespaceDeclaration10Green),
				typeof(NamespaceBody10Green),
				typeof(Declaration10Green),
				typeof(Vertex10Green),
				typeof(Arrow10Green),
				typeof(Test11Green),
				typeof(NamespaceDeclaration11Green),
				typeof(NamespaceBody11Green),
				typeof(Declaration11Green),
				typeof(Vertex11Green),
				typeof(Arrow11Green),
				typeof(NameGreen),
				typeof(QualifiedNameGreen),
				typeof(QualifierGreen),
				typeof(IdentifierGreen),
				typeof(LiteralGreen),
				typeof(NullLiteralGreen),
				typeof(BooleanLiteralGreen),
				typeof(IntegerLiteralGreen),
				typeof(DecimalLiteralGreen),
				typeof(ScientificLiteralGreen),
				typeof(StringLiteralGreen),
			};
		}
	}
}


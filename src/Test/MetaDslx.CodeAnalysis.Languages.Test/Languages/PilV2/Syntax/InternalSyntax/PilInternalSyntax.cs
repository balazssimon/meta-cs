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

namespace PilV2.Syntax.InternalSyntax
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
            if (visitor is PilSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is PilSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor);
        public abstract void Accept(PilSyntaxVisitor visitor);

        public new PilLanguage Language => PilLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new PilSyntaxKind Kind => (PilSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

		// Use conditional weak table so we always return same identity for structured trivia
		private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
			= new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

		/// <summary>
		/// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
		/// determine if this trivia has structure.
		/// </summary>
		/// <returns>
		/// A PilSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
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
							structure = PilStructuredTriviaSyntax.Create(trivia);
							structsInParent.Add(trivia, structure);
						}
					}

					return structure;
				}
				else
				{
					return PilStructuredTriviaSyntax.Create(trivia);
				}
			}

			return null;
		}

	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(PilSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new PilLanguage Language => PilLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new PilSyntaxKind Kind => EnumObject.FromIntUnsafe<PilSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(PilSyntaxKind kind, string text)
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
        internal GreenStructuredTriviaSyntax(PilSyntaxKind kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        internal GreenSkippedTokensTriviaSyntax(PilSyntaxKind kind, GreenNode tokens, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position) => new PilSkippedTokensTriviaSyntax(this, (PilSyntaxNode)parent, position);

        public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitSkippedTokensTrivia(this);

        public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitSkippedTokensTrivia(this);

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
	    internal GreenSyntaxToken(PilSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(PilSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(PilSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(PilSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(PilSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(PilSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new PilLanguage Language => PilLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new PilSyntaxKind Kind => EnumObject.FromIntUnsafe<PilSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(PilSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!PilLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid PilSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(PilSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!PilLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid PilSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == PilLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == PilLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == PilLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == PilLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(PilSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly PilSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly PilSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = PilSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = PilSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = PilLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((PilSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((PilSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((PilSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((PilSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(PilSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(PilSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(PilSyntaxKind kind, PilSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(PilSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(PilSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual PilSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(PilSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(PilSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(PilSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(PilSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly PilSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(PilSyntaxKind kind, PilSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(PilSyntaxKind kind, PilSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<PilSyntaxKind>(reader.ReadInt32());
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
	        public override PilSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(PilSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(PilSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            PilSyntaxKind kind,
	            PilSyntaxKind contextualKind,
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
	            PilSyntaxKind kind,
	            PilSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(PilSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(PilSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(PilSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            PilSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(PilSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(PilSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    private GreenNode declaration;
	    private InternalSyntaxToken eOF;
	
	    public MainGreen(PilSyntaxKind kind, GreenNode declaration, InternalSyntaxToken eOF)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
	    public MainGreen(PilSyntaxKind kind, GreenNode declaration, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
		private MainGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> Declaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen>(this.declaration); } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.MainSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.declaration;
	            case 1: return this.eOF;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.declaration, this.eOF, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.declaration, this.eOF, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken eOF)
	    {
	        if (this.Declaration != declaration ||
				this.EndOfFileToken != eOF)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Main(declaration, eOF);
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
	
	internal class DeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly DeclarationGreen __Missing = new DeclarationGreen();
	    private TypeDefDeclarationGreen typeDefDeclaration;
	    private ExternalParameterDeclarationGreen externalParameterDeclaration;
	    private EnumDeclarationGreen enumDeclaration;
	    private ObjectDeclarationGreen objectDeclaration;
	    private FunctionDeclarationGreen functionDeclaration;
	    private QueryDeclarationGreen queryDeclaration;
	
	    public DeclarationGreen(PilSyntaxKind kind, TypeDefDeclarationGreen typeDefDeclaration, ExternalParameterDeclarationGreen externalParameterDeclaration, EnumDeclarationGreen enumDeclaration, ObjectDeclarationGreen objectDeclaration, FunctionDeclarationGreen functionDeclaration, QueryDeclarationGreen queryDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (typeDefDeclaration != null)
			{
				this.AdjustFlagsAndWidth(typeDefDeclaration);
				this.typeDefDeclaration = typeDefDeclaration;
			}
			if (externalParameterDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externalParameterDeclaration);
				this.externalParameterDeclaration = externalParameterDeclaration;
			}
			if (enumDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumDeclaration);
				this.enumDeclaration = enumDeclaration;
			}
			if (objectDeclaration != null)
			{
				this.AdjustFlagsAndWidth(objectDeclaration);
				this.objectDeclaration = objectDeclaration;
			}
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
			if (queryDeclaration != null)
			{
				this.AdjustFlagsAndWidth(queryDeclaration);
				this.queryDeclaration = queryDeclaration;
			}
	    }
	
	    public DeclarationGreen(PilSyntaxKind kind, TypeDefDeclarationGreen typeDefDeclaration, ExternalParameterDeclarationGreen externalParameterDeclaration, EnumDeclarationGreen enumDeclaration, ObjectDeclarationGreen objectDeclaration, FunctionDeclarationGreen functionDeclaration, QueryDeclarationGreen queryDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (typeDefDeclaration != null)
			{
				this.AdjustFlagsAndWidth(typeDefDeclaration);
				this.typeDefDeclaration = typeDefDeclaration;
			}
			if (externalParameterDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externalParameterDeclaration);
				this.externalParameterDeclaration = externalParameterDeclaration;
			}
			if (enumDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumDeclaration);
				this.enumDeclaration = enumDeclaration;
			}
			if (objectDeclaration != null)
			{
				this.AdjustFlagsAndWidth(objectDeclaration);
				this.objectDeclaration = objectDeclaration;
			}
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
			if (queryDeclaration != null)
			{
				this.AdjustFlagsAndWidth(queryDeclaration);
				this.queryDeclaration = queryDeclaration;
			}
	    }
	
		private DeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Declaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeDefDeclarationGreen TypeDefDeclaration { get { return this.typeDefDeclaration; } }
	    public ExternalParameterDeclarationGreen ExternalParameterDeclaration { get { return this.externalParameterDeclaration; } }
	    public EnumDeclarationGreen EnumDeclaration { get { return this.enumDeclaration; } }
	    public ObjectDeclarationGreen ObjectDeclaration { get { return this.objectDeclaration; } }
	    public FunctionDeclarationGreen FunctionDeclaration { get { return this.functionDeclaration; } }
	    public QueryDeclarationGreen QueryDeclaration { get { return this.queryDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.DeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeDefDeclaration;
	            case 1: return this.externalParameterDeclaration;
	            case 2: return this.enumDeclaration;
	            case 3: return this.objectDeclaration;
	            case 4: return this.functionDeclaration;
	            case 5: return this.queryDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.typeDefDeclaration, this.externalParameterDeclaration, this.enumDeclaration, this.objectDeclaration, this.functionDeclaration, this.queryDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.typeDefDeclaration, this.externalParameterDeclaration, this.enumDeclaration, this.objectDeclaration, this.functionDeclaration, this.queryDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(TypeDefDeclarationGreen typeDefDeclaration)
	    {
	        if (this.typeDefDeclaration != typeDefDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Declaration(typeDefDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationGreen Update(ExternalParameterDeclarationGreen externalParameterDeclaration)
	    {
	        if (this.externalParameterDeclaration != externalParameterDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Declaration(externalParameterDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationGreen Update(EnumDeclarationGreen enumDeclaration)
	    {
	        if (this.enumDeclaration != enumDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Declaration(enumDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationGreen Update(ObjectDeclarationGreen objectDeclaration)
	    {
	        if (this.objectDeclaration != objectDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Declaration(objectDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationGreen Update(FunctionDeclarationGreen functionDeclaration)
	    {
	        if (this.functionDeclaration != functionDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Declaration(functionDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationGreen Update(QueryDeclarationGreen queryDeclaration)
	    {
	        if (this.queryDeclaration != queryDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Declaration(queryDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeDefDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly TypeDefDeclarationGreen __Missing = new TypeDefDeclarationGreen();
	    private InternalSyntaxToken kTypeDef;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tSemicolon;
	
	    public TypeDefDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kTypeDef, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kTypeDef != null)
			{
				this.AdjustFlagsAndWidth(kTypeDef);
				this.kTypeDef = kTypeDef;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
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
	
	    public TypeDefDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kTypeDef, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kTypeDef != null)
			{
				this.AdjustFlagsAndWidth(kTypeDef);
				this.kTypeDef = kTypeDef;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
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
	
		private TypeDefDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TypeDefDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeDef { get { return this.kTypeDef; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TypeDefDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeDef;
	            case 1: return this.name;
	            case 2: return this.tColon;
	            case 3: return this.typeReference;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTypeDefDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTypeDefDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeDefDeclarationGreen(this.Kind, this.kTypeDef, this.name, this.tColon, this.typeReference, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeDefDeclarationGreen(this.Kind, this.kTypeDef, this.name, this.tColon, this.typeReference, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeDefDeclarationGreen Update(InternalSyntaxToken kTypeDef, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KTypeDef != kTypeDef ||
				this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TypeDefDeclaration(kTypeDef, name, tColon, typeReference, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeDefDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExternalParameterDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ExternalParameterDeclarationGreen __Missing = new ExternalParameterDeclarationGreen();
	    private InternalSyntaxToken kParam;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tSemicolon;
	
	    public ExternalParameterDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kParam, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (kParam != null)
			{
				this.AdjustFlagsAndWidth(kParam);
				this.kParam = kParam;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
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
	
	    public ExternalParameterDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kParam, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (kParam != null)
			{
				this.AdjustFlagsAndWidth(kParam);
				this.kParam = kParam;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
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
	
		private ExternalParameterDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ExternalParameterDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KParam { get { return this.kParam; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ExternalParameterDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kParam;
	            case 1: return this.name;
	            case 2: return this.tColon;
	            case 3: return this.typeReference;
	            case 4: return this.tAssign;
	            case 5: return this.expression;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitExternalParameterDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitExternalParameterDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExternalParameterDeclarationGreen(this.Kind, this.kParam, this.name, this.tColon, this.typeReference, this.tAssign, this.expression, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExternalParameterDeclarationGreen(this.Kind, this.kParam, this.name, this.tColon, this.typeReference, this.tAssign, this.expression, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ExternalParameterDeclarationGreen Update(InternalSyntaxToken kParam, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KParam != kParam ||
				this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference ||
				this.TAssign != tAssign ||
				this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ExternalParameterDeclaration(kParam, name, tColon, typeReference, tAssign, expression, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExternalParameterDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly EnumDeclarationGreen __Missing = new EnumDeclarationGreen();
	    private InternalSyntaxToken kEnum;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenBracket;
	    private EnumLiteralsGreen enumLiterals;
	    private InternalSyntaxToken tCloseBracket;
	    private InternalSyntaxToken tSemicolon;
	
	    public EnumDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tOpenBracket, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kEnum != null)
			{
				this.AdjustFlagsAndWidth(kEnum);
				this.kEnum = kEnum;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (enumLiterals != null)
			{
				this.AdjustFlagsAndWidth(enumLiterals);
				this.enumLiterals = enumLiterals;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public EnumDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tOpenBracket, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kEnum != null)
			{
				this.AdjustFlagsAndWidth(kEnum);
				this.kEnum = kEnum;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (enumLiterals != null)
			{
				this.AdjustFlagsAndWidth(enumLiterals);
				this.enumLiterals = enumLiterals;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private EnumDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.EnumDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnum { get { return this.kEnum; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public EnumLiteralsGreen EnumLiterals { get { return this.enumLiterals; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.EnumDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnum;
	            case 1: return this.name;
	            case 2: return this.tOpenBracket;
	            case 3: return this.enumLiterals;
	            case 4: return this.tCloseBracket;
	            case 5: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.kEnum, this.name, this.tOpenBracket, this.enumLiterals, this.tCloseBracket, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.kEnum, this.name, this.tOpenBracket, this.enumLiterals, this.tCloseBracket, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumDeclarationGreen Update(InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tOpenBracket, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KEnum != kEnum ||
				this.Name != name ||
				this.TOpenBracket != tOpenBracket ||
				this.EnumLiterals != enumLiterals ||
				this.TCloseBracket != tCloseBracket ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(kEnum, name, tOpenBracket, enumLiterals, tCloseBracket, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumLiteralsGreen : GreenSyntaxNode
	{
	    internal static readonly EnumLiteralsGreen __Missing = new EnumLiteralsGreen();
	    private GreenNode enumLiteral;
	
	    public EnumLiteralsGreen(PilSyntaxKind kind, GreenNode enumLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (enumLiteral != null)
			{
				this.AdjustFlagsAndWidth(enumLiteral);
				this.enumLiteral = enumLiteral;
			}
	    }
	
	    public EnumLiteralsGreen(PilSyntaxKind kind, GreenNode enumLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (enumLiteral != null)
			{
				this.AdjustFlagsAndWidth(enumLiteral);
				this.enumLiteral = enumLiteral;
			}
	    }
	
		private EnumLiteralsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.EnumLiterals, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen> EnumLiteral { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen>(this.enumLiteral); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.EnumLiteralsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitEnumLiteralsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitEnumLiteralsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumLiteralsGreen(this.Kind, this.enumLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumLiteralsGreen(this.Kind, this.enumLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumLiteralsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen> enumLiteral)
	    {
	        if (this.EnumLiteral != enumLiteral)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.EnumLiterals(enumLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumLiteralsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly EnumLiteralGreen __Missing = new EnumLiteralGreen();
	    private NameGreen name;
	
	    public EnumLiteralGreen(PilSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public EnumLiteralGreen(PilSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private EnumLiteralGreen()
			: base((PilSyntaxKind)PilSyntaxKind.EnumLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.EnumLiteralSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitEnumLiteralGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitEnumLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumLiteralGreen(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumLiteralGreen(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumLiteralGreen Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.EnumLiteral(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumLiteralGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectDeclarationGreen __Missing = new ObjectDeclarationGreen();
	    private InternalSyntaxToken kObject;
	    private ObjectHeaderGreen objectHeader;
	    private InternalSyntaxToken tSemicolon;
	    private ObjectExternalParametersGreen objectExternalParameters;
	    private ObjectFieldsGreen objectFields;
	    private ObjectFunctionsGreen objectFunctions;
	    private InternalSyntaxToken kEndObject;
	
	    public ObjectDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kObject, ObjectHeaderGreen objectHeader, InternalSyntaxToken tSemicolon, ObjectExternalParametersGreen objectExternalParameters, ObjectFieldsGreen objectFields, ObjectFunctionsGreen objectFunctions, InternalSyntaxToken kEndObject)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (kObject != null)
			{
				this.AdjustFlagsAndWidth(kObject);
				this.kObject = kObject;
			}
			if (objectHeader != null)
			{
				this.AdjustFlagsAndWidth(objectHeader);
				this.objectHeader = objectHeader;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (objectExternalParameters != null)
			{
				this.AdjustFlagsAndWidth(objectExternalParameters);
				this.objectExternalParameters = objectExternalParameters;
			}
			if (objectFields != null)
			{
				this.AdjustFlagsAndWidth(objectFields);
				this.objectFields = objectFields;
			}
			if (objectFunctions != null)
			{
				this.AdjustFlagsAndWidth(objectFunctions);
				this.objectFunctions = objectFunctions;
			}
			if (kEndObject != null)
			{
				this.AdjustFlagsAndWidth(kEndObject);
				this.kEndObject = kEndObject;
			}
	    }
	
	    public ObjectDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kObject, ObjectHeaderGreen objectHeader, InternalSyntaxToken tSemicolon, ObjectExternalParametersGreen objectExternalParameters, ObjectFieldsGreen objectFields, ObjectFunctionsGreen objectFunctions, InternalSyntaxToken kEndObject, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (kObject != null)
			{
				this.AdjustFlagsAndWidth(kObject);
				this.kObject = kObject;
			}
			if (objectHeader != null)
			{
				this.AdjustFlagsAndWidth(objectHeader);
				this.objectHeader = objectHeader;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (objectExternalParameters != null)
			{
				this.AdjustFlagsAndWidth(objectExternalParameters);
				this.objectExternalParameters = objectExternalParameters;
			}
			if (objectFields != null)
			{
				this.AdjustFlagsAndWidth(objectFields);
				this.objectFields = objectFields;
			}
			if (objectFunctions != null)
			{
				this.AdjustFlagsAndWidth(objectFunctions);
				this.objectFunctions = objectFunctions;
			}
			if (kEndObject != null)
			{
				this.AdjustFlagsAndWidth(kEndObject);
				this.kEndObject = kEndObject;
			}
	    }
	
		private ObjectDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ObjectDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KObject { get { return this.kObject; } }
	    public ObjectHeaderGreen ObjectHeader { get { return this.objectHeader; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public ObjectExternalParametersGreen ObjectExternalParameters { get { return this.objectExternalParameters; } }
	    public ObjectFieldsGreen ObjectFields { get { return this.objectFields; } }
	    public ObjectFunctionsGreen ObjectFunctions { get { return this.objectFunctions; } }
	    public InternalSyntaxToken KEndObject { get { return this.kEndObject; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ObjectDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kObject;
	            case 1: return this.objectHeader;
	            case 2: return this.tSemicolon;
	            case 3: return this.objectExternalParameters;
	            case 4: return this.objectFields;
	            case 5: return this.objectFunctions;
	            case 6: return this.kEndObject;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitObjectDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitObjectDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectDeclarationGreen(this.Kind, this.kObject, this.objectHeader, this.tSemicolon, this.objectExternalParameters, this.objectFields, this.objectFunctions, this.kEndObject, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectDeclarationGreen(this.Kind, this.kObject, this.objectHeader, this.tSemicolon, this.objectExternalParameters, this.objectFields, this.objectFunctions, this.kEndObject, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectDeclarationGreen Update(InternalSyntaxToken kObject, ObjectHeaderGreen objectHeader, InternalSyntaxToken tSemicolon, ObjectExternalParametersGreen objectExternalParameters, ObjectFieldsGreen objectFields, ObjectFunctionsGreen objectFunctions, InternalSyntaxToken kEndObject)
	    {
	        if (this.KObject != kObject ||
				this.ObjectHeader != objectHeader ||
				this.TSemicolon != tSemicolon ||
				this.ObjectExternalParameters != objectExternalParameters ||
				this.ObjectFields != objectFields ||
				this.ObjectFunctions != objectFunctions ||
				this.KEndObject != kEndObject)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ObjectDeclaration(kObject, objectHeader, tSemicolon, objectExternalParameters, objectFields, objectFunctions, kEndObject);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectHeaderGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectHeaderGreen __Missing = new ObjectHeaderGreen();
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private PortsGreen ports;
	    private InternalSyntaxToken tCloseParen;
	
	    public ObjectHeaderGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tOpenParen, PortsGreen ports, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (ports != null)
			{
				this.AdjustFlagsAndWidth(ports);
				this.ports = ports;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ObjectHeaderGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tOpenParen, PortsGreen ports, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (ports != null)
			{
				this.AdjustFlagsAndWidth(ports);
				this.ports = ports;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ObjectHeaderGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ObjectHeader, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public PortsGreen Ports { get { return this.ports; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ObjectHeaderSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.tOpenParen;
	            case 2: return this.ports;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitObjectHeaderGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitObjectHeaderGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectHeaderGreen(this.Kind, this.name, this.tOpenParen, this.ports, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectHeaderGreen(this.Kind, this.name, this.tOpenParen, this.ports, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectHeaderGreen Update(NameGreen name, InternalSyntaxToken tOpenParen, PortsGreen ports, InternalSyntaxToken tCloseParen)
	    {
	        if (this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.Ports != ports ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ObjectHeader(name, tOpenParen, ports, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectHeaderGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PortsGreen : GreenSyntaxNode
	{
	    internal static readonly PortsGreen __Missing = new PortsGreen();
	    private GreenNode port;
	
	    public PortsGreen(PilSyntaxKind kind, GreenNode port)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (port != null)
			{
				this.AdjustFlagsAndWidth(port);
				this.port = port;
			}
	    }
	
	    public PortsGreen(PilSyntaxKind kind, GreenNode port, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (port != null)
			{
				this.AdjustFlagsAndWidth(port);
				this.port = port;
			}
	    }
	
		private PortsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Ports, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PortGreen> Port { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PortGreen>(this.port); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.PortsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.port;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitPortsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitPortsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PortsGreen(this.Kind, this.port, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PortsGreen(this.Kind, this.port, this.GetDiagnostics(), annotations);
	    }
	
	    public PortsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PortGreen> port)
	    {
	        if (this.Port != port)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Ports(port);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PortsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PortGreen : GreenSyntaxNode
	{
	    internal static readonly PortGreen __Missing = new PortGreen();
	    private NameGreen name;
	
	    public PortGreen(PilSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public PortGreen(PilSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private PortGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Port, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.PortSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitPortGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitPortGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PortGreen(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PortGreen(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public PortGreen Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Port(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PortGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectExternalParametersGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectExternalParametersGreen __Missing = new ObjectExternalParametersGreen();
	    private GreenNode externalParameterDeclaration;
	
	    public ObjectExternalParametersGreen(PilSyntaxKind kind, GreenNode externalParameterDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (externalParameterDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externalParameterDeclaration);
				this.externalParameterDeclaration = externalParameterDeclaration;
			}
	    }
	
	    public ObjectExternalParametersGreen(PilSyntaxKind kind, GreenNode externalParameterDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (externalParameterDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externalParameterDeclaration);
				this.externalParameterDeclaration = externalParameterDeclaration;
			}
	    }
	
		private ObjectExternalParametersGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ObjectExternalParameters, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ExternalParameterDeclarationGreen> ExternalParameterDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ExternalParameterDeclarationGreen>(this.externalParameterDeclaration); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ObjectExternalParametersSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.externalParameterDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitObjectExternalParametersGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitObjectExternalParametersGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectExternalParametersGreen(this.Kind, this.externalParameterDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectExternalParametersGreen(this.Kind, this.externalParameterDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectExternalParametersGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ExternalParameterDeclarationGreen> externalParameterDeclaration)
	    {
	        if (this.ExternalParameterDeclaration != externalParameterDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ObjectExternalParameters(externalParameterDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectExternalParametersGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectFieldsGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectFieldsGreen __Missing = new ObjectFieldsGreen();
	    private GreenNode variableDeclaration;
	
	    public ObjectFieldsGreen(PilSyntaxKind kind, GreenNode variableDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
	    public ObjectFieldsGreen(PilSyntaxKind kind, GreenNode variableDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
		private ObjectFieldsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ObjectFields, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<VariableDeclarationGreen> VariableDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<VariableDeclarationGreen>(this.variableDeclaration); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ObjectFieldsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitObjectFieldsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitObjectFieldsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectFieldsGreen(this.Kind, this.variableDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectFieldsGreen(this.Kind, this.variableDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectFieldsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<VariableDeclarationGreen> variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ObjectFields(variableDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectFieldsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectFunctionsGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectFunctionsGreen __Missing = new ObjectFunctionsGreen();
	    private GreenNode functionDeclaration;
	
	    public ObjectFunctionsGreen(PilSyntaxKind kind, GreenNode functionDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
	    }
	
	    public ObjectFunctionsGreen(PilSyntaxKind kind, GreenNode functionDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
	    }
	
		private ObjectFunctionsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ObjectFunctions, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen> FunctionDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen>(this.functionDeclaration); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ObjectFunctionsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.functionDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitObjectFunctionsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitObjectFunctionsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectFunctionsGreen(this.Kind, this.functionDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectFunctionsGreen(this.Kind, this.functionDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectFunctionsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen> functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ObjectFunctions(functionDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectFunctionsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FunctionDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly FunctionDeclarationGreen __Missing = new FunctionDeclarationGreen();
	    private InternalSyntaxToken kFunction;
	    private FunctionHeaderGreen functionHeader;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	    private InternalSyntaxToken kEndFunction;
	
	    public FunctionDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kFunction, FunctionHeaderGreen functionHeader, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, InternalSyntaxToken kEndFunction)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kFunction != null)
			{
				this.AdjustFlagsAndWidth(kFunction);
				this.kFunction = kFunction;
			}
			if (functionHeader != null)
			{
				this.AdjustFlagsAndWidth(functionHeader);
				this.functionHeader = functionHeader;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
			if (kEndFunction != null)
			{
				this.AdjustFlagsAndWidth(kEndFunction);
				this.kEndFunction = kEndFunction;
			}
	    }
	
	    public FunctionDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kFunction, FunctionHeaderGreen functionHeader, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, InternalSyntaxToken kEndFunction, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kFunction != null)
			{
				this.AdjustFlagsAndWidth(kFunction);
				this.kFunction = kFunction;
			}
			if (functionHeader != null)
			{
				this.AdjustFlagsAndWidth(functionHeader);
				this.functionHeader = functionHeader;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
			if (kEndFunction != null)
			{
				this.AdjustFlagsAndWidth(kEndFunction);
				this.kEndFunction = kEndFunction;
			}
	    }
	
		private FunctionDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.FunctionDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KFunction { get { return this.kFunction; } }
	    public FunctionHeaderGreen FunctionHeader { get { return this.functionHeader; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	    public InternalSyntaxToken KEndFunction { get { return this.kEndFunction; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.FunctionDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kFunction;
	            case 1: return this.functionHeader;
	            case 2: return this.comment;
	            case 3: return this.tSemicolon;
	            case 4: return this.statements;
	            case 5: return this.kEndFunction;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitFunctionDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionDeclarationGreen(this.Kind, this.kFunction, this.functionHeader, this.comment, this.tSemicolon, this.statements, this.kEndFunction, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionDeclarationGreen(this.Kind, this.kFunction, this.functionHeader, this.comment, this.tSemicolon, this.statements, this.kEndFunction, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionDeclarationGreen Update(InternalSyntaxToken kFunction, FunctionHeaderGreen functionHeader, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, InternalSyntaxToken kEndFunction)
	    {
	        if (this.KFunction != kFunction ||
				this.FunctionHeader != functionHeader ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements ||
				this.KEndFunction != kEndFunction)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.FunctionDeclaration(kFunction, functionHeader, comment, tSemicolon, statements, kEndFunction);
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
	
	internal class FunctionHeaderGreen : GreenSyntaxNode
	{
	    internal static readonly FunctionHeaderGreen __Missing = new FunctionHeaderGreen();
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private FunctionParamsGreen functionParams;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tColon;
	    private TypeReferenceGreen typeReference;
	
	    public FunctionHeaderGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tOpenParen, FunctionParamsGreen functionParams, InternalSyntaxToken tCloseParen, InternalSyntaxToken tColon, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (functionParams != null)
			{
				this.AdjustFlagsAndWidth(functionParams);
				this.functionParams = functionParams;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public FunctionHeaderGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tOpenParen, FunctionParamsGreen functionParams, InternalSyntaxToken tCloseParen, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (functionParams != null)
			{
				this.AdjustFlagsAndWidth(functionParams);
				this.functionParams = functionParams;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private FunctionHeaderGreen()
			: base((PilSyntaxKind)PilSyntaxKind.FunctionHeader, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public FunctionParamsGreen FunctionParams { get { return this.functionParams; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.FunctionHeaderSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.tOpenParen;
	            case 2: return this.functionParams;
	            case 3: return this.tCloseParen;
	            case 4: return this.tColon;
	            case 5: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionHeaderGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitFunctionHeaderGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionHeaderGreen(this.Kind, this.name, this.tOpenParen, this.functionParams, this.tCloseParen, this.tColon, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionHeaderGreen(this.Kind, this.name, this.tOpenParen, this.functionParams, this.tCloseParen, this.tColon, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionHeaderGreen Update(NameGreen name, InternalSyntaxToken tOpenParen, FunctionParamsGreen functionParams, InternalSyntaxToken tCloseParen, InternalSyntaxToken tColon, TypeReferenceGreen typeReference)
	    {
	        if (this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.FunctionParams != functionParams ||
				this.TCloseParen != tCloseParen ||
				this.TColon != tColon ||
				this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.FunctionHeader(name, tOpenParen, functionParams, tCloseParen, tColon, typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionHeaderGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FunctionParamsGreen : GreenSyntaxNode
	{
	    internal static readonly FunctionParamsGreen __Missing = new FunctionParamsGreen();
	    private GreenNode param;
	
	    public FunctionParamsGreen(PilSyntaxKind kind, GreenNode param)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
	    }
	
	    public FunctionParamsGreen(PilSyntaxKind kind, GreenNode param, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
	    }
	
		private FunctionParamsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.FunctionParams, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> Param { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen>(this.param); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.FunctionParamsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.param;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionParamsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitFunctionParamsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionParamsGreen(this.Kind, this.param, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionParamsGreen(this.Kind, this.param, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionParamsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param)
	    {
	        if (this.Param != param)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.FunctionParams(param);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionParamsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParamGreen : GreenSyntaxNode
	{
	    internal static readonly ParamGreen __Missing = new ParamGreen();
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private TypeReferenceGreen typeReference;
	
	    public ParamGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public ParamGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private ParamGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Param, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ParamSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.tColon;
	            case 2: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitParamGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitParamGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParamGreen(this.Kind, this.name, this.tColon, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParamGreen(this.Kind, this.name, this.tColon, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public ParamGreen Update(NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference)
	    {
	        if (this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Param(name, tColon, typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParamGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly QueryDeclarationGreen __Missing = new QueryDeclarationGreen();
	    private InternalSyntaxToken kQuery;
	    private QueryHeaderGreen queryHeader;
	    private CommentGreen comment;
	    private InternalSyntaxToken startQuerySemicolon;
	    private GreenNode queryExternalParameters;
	    private GreenNode queryField;
	    private GreenNode functionDeclaration;
	    private GreenNode queryObject;
	    private InternalSyntaxToken kEndQuery;
	    private IdentifierGreen endName;
	    private InternalSyntaxToken endQuerySemicolon;
	
	    public QueryDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kQuery, QueryHeaderGreen queryHeader, CommentGreen comment, InternalSyntaxToken startQuerySemicolon, GreenNode queryExternalParameters, GreenNode queryField, GreenNode functionDeclaration, GreenNode queryObject, InternalSyntaxToken kEndQuery, IdentifierGreen endName, InternalSyntaxToken endQuerySemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 11;
			if (kQuery != null)
			{
				this.AdjustFlagsAndWidth(kQuery);
				this.kQuery = kQuery;
			}
			if (queryHeader != null)
			{
				this.AdjustFlagsAndWidth(queryHeader);
				this.queryHeader = queryHeader;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (startQuerySemicolon != null)
			{
				this.AdjustFlagsAndWidth(startQuerySemicolon);
				this.startQuerySemicolon = startQuerySemicolon;
			}
			if (queryExternalParameters != null)
			{
				this.AdjustFlagsAndWidth(queryExternalParameters);
				this.queryExternalParameters = queryExternalParameters;
			}
			if (queryField != null)
			{
				this.AdjustFlagsAndWidth(queryField);
				this.queryField = queryField;
			}
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
			if (queryObject != null)
			{
				this.AdjustFlagsAndWidth(queryObject);
				this.queryObject = queryObject;
			}
			if (kEndQuery != null)
			{
				this.AdjustFlagsAndWidth(kEndQuery);
				this.kEndQuery = kEndQuery;
			}
			if (endName != null)
			{
				this.AdjustFlagsAndWidth(endName);
				this.endName = endName;
			}
			if (endQuerySemicolon != null)
			{
				this.AdjustFlagsAndWidth(endQuerySemicolon);
				this.endQuerySemicolon = endQuerySemicolon;
			}
	    }
	
	    public QueryDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kQuery, QueryHeaderGreen queryHeader, CommentGreen comment, InternalSyntaxToken startQuerySemicolon, GreenNode queryExternalParameters, GreenNode queryField, GreenNode functionDeclaration, GreenNode queryObject, InternalSyntaxToken kEndQuery, IdentifierGreen endName, InternalSyntaxToken endQuerySemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 11;
			if (kQuery != null)
			{
				this.AdjustFlagsAndWidth(kQuery);
				this.kQuery = kQuery;
			}
			if (queryHeader != null)
			{
				this.AdjustFlagsAndWidth(queryHeader);
				this.queryHeader = queryHeader;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (startQuerySemicolon != null)
			{
				this.AdjustFlagsAndWidth(startQuerySemicolon);
				this.startQuerySemicolon = startQuerySemicolon;
			}
			if (queryExternalParameters != null)
			{
				this.AdjustFlagsAndWidth(queryExternalParameters);
				this.queryExternalParameters = queryExternalParameters;
			}
			if (queryField != null)
			{
				this.AdjustFlagsAndWidth(queryField);
				this.queryField = queryField;
			}
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
			if (queryObject != null)
			{
				this.AdjustFlagsAndWidth(queryObject);
				this.queryObject = queryObject;
			}
			if (kEndQuery != null)
			{
				this.AdjustFlagsAndWidth(kEndQuery);
				this.kEndQuery = kEndQuery;
			}
			if (endName != null)
			{
				this.AdjustFlagsAndWidth(endName);
				this.endName = endName;
			}
			if (endQuerySemicolon != null)
			{
				this.AdjustFlagsAndWidth(endQuerySemicolon);
				this.endQuerySemicolon = endQuerySemicolon;
			}
	    }
	
		private QueryDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KQuery { get { return this.kQuery; } }
	    public QueryHeaderGreen QueryHeader { get { return this.queryHeader; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken StartQuerySemicolon { get { return this.startQuerySemicolon; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryExternalParametersGreen> QueryExternalParameters { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryExternalParametersGreen>(this.queryExternalParameters); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryFieldGreen> QueryField { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryFieldGreen>(this.queryField); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen> FunctionDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen>(this.functionDeclaration); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectGreen> QueryObject { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectGreen>(this.queryObject); } }
	    public InternalSyntaxToken KEndQuery { get { return this.kEndQuery; } }
	    public IdentifierGreen EndName { get { return this.endName; } }
	    public InternalSyntaxToken EndQuerySemicolon { get { return this.endQuerySemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kQuery;
	            case 1: return this.queryHeader;
	            case 2: return this.comment;
	            case 3: return this.startQuerySemicolon;
	            case 4: return this.queryExternalParameters;
	            case 5: return this.queryField;
	            case 6: return this.functionDeclaration;
	            case 7: return this.queryObject;
	            case 8: return this.kEndQuery;
	            case 9: return this.endName;
	            case 10: return this.endQuerySemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryDeclarationGreen(this.Kind, this.kQuery, this.queryHeader, this.comment, this.startQuerySemicolon, this.queryExternalParameters, this.queryField, this.functionDeclaration, this.queryObject, this.kEndQuery, this.endName, this.endQuerySemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryDeclarationGreen(this.Kind, this.kQuery, this.queryHeader, this.comment, this.startQuerySemicolon, this.queryExternalParameters, this.queryField, this.functionDeclaration, this.queryObject, this.kEndQuery, this.endName, this.endQuerySemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryDeclarationGreen Update(InternalSyntaxToken kQuery, QueryHeaderGreen queryHeader, CommentGreen comment, InternalSyntaxToken startQuerySemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryExternalParametersGreen> queryExternalParameters, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryFieldGreen> queryField, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen> functionDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectGreen> queryObject, InternalSyntaxToken kEndQuery, IdentifierGreen endName, InternalSyntaxToken endQuerySemicolon)
	    {
	        if (this.KQuery != kQuery ||
				this.QueryHeader != queryHeader ||
				this.Comment != comment ||
				this.StartQuerySemicolon != startQuerySemicolon ||
				this.QueryExternalParameters != queryExternalParameters ||
				this.QueryField != queryField ||
				this.FunctionDeclaration != functionDeclaration ||
				this.QueryObject != queryObject ||
				this.KEndQuery != kEndQuery ||
				this.EndName != endName ||
				this.EndQuerySemicolon != endQuerySemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryDeclaration(kQuery, queryHeader, comment, startQuerySemicolon, queryExternalParameters, queryField, functionDeclaration, queryObject, kEndQuery, endName, endQuerySemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryHeaderGreen : GreenSyntaxNode
	{
	    internal static readonly QueryHeaderGreen __Missing = new QueryHeaderGreen();
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private QueryRequestParamsGreen queryRequestParams;
	    private InternalSyntaxToken tCloseParen;
	
	    public QueryHeaderGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tOpenParen, QueryRequestParamsGreen queryRequestParams, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (queryRequestParams != null)
			{
				this.AdjustFlagsAndWidth(queryRequestParams);
				this.queryRequestParams = queryRequestParams;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public QueryHeaderGreen(PilSyntaxKind kind, NameGreen name, InternalSyntaxToken tOpenParen, QueryRequestParamsGreen queryRequestParams, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (queryRequestParams != null)
			{
				this.AdjustFlagsAndWidth(queryRequestParams);
				this.queryRequestParams = queryRequestParams;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private QueryHeaderGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryHeader, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public QueryRequestParamsGreen QueryRequestParams { get { return this.queryRequestParams; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryHeaderSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.tOpenParen;
	            case 2: return this.queryRequestParams;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryHeaderGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryHeaderGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryHeaderGreen(this.Kind, this.name, this.tOpenParen, this.queryRequestParams, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryHeaderGreen(this.Kind, this.name, this.tOpenParen, this.queryRequestParams, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryHeaderGreen Update(NameGreen name, InternalSyntaxToken tOpenParen, QueryRequestParamsGreen queryRequestParams, InternalSyntaxToken tCloseParen)
	    {
	        if (this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.QueryRequestParams != queryRequestParams ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryHeader(name, tOpenParen, queryRequestParams, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryHeaderGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryRequestParamsGreen : GreenSyntaxNode
	{
	    internal static readonly QueryRequestParamsGreen __Missing = new QueryRequestParamsGreen();
	    private InternalSyntaxToken kRequest;
	    private GreenNode param;
	    private InternalSyntaxToken tSemicolon;
	
	    public QueryRequestParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kRequest, GreenNode param, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kRequest != null)
			{
				this.AdjustFlagsAndWidth(kRequest);
				this.kRequest = kRequest;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public QueryRequestParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kRequest, GreenNode param, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kRequest != null)
			{
				this.AdjustFlagsAndWidth(kRequest);
				this.kRequest = kRequest;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private QueryRequestParamsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryRequestParams, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRequest { get { return this.kRequest; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> Param { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen>(this.param); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryRequestParamsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRequest;
	            case 1: return this.param;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryRequestParamsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryRequestParamsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryRequestParamsGreen(this.Kind, this.kRequest, this.param, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryRequestParamsGreen(this.Kind, this.kRequest, this.param, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryRequestParamsGreen Update(InternalSyntaxToken kRequest, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KRequest != kRequest ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryRequestParams(kRequest, param, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryRequestParamsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryAcceptParamsGreen : GreenSyntaxNode
	{
	    internal static readonly QueryAcceptParamsGreen __Missing = new QueryAcceptParamsGreen();
	    private InternalSyntaxToken kAccept;
	    private GreenNode param;
	    private InternalSyntaxToken tSemicolon;
	
	    public QueryAcceptParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kAccept, GreenNode param, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kAccept != null)
			{
				this.AdjustFlagsAndWidth(kAccept);
				this.kAccept = kAccept;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public QueryAcceptParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kAccept, GreenNode param, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kAccept != null)
			{
				this.AdjustFlagsAndWidth(kAccept);
				this.kAccept = kAccept;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private QueryAcceptParamsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryAcceptParams, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAccept { get { return this.kAccept; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> Param { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen>(this.param); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryAcceptParamsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAccept;
	            case 1: return this.param;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryAcceptParamsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryAcceptParamsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryAcceptParamsGreen(this.Kind, this.kAccept, this.param, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryAcceptParamsGreen(this.Kind, this.kAccept, this.param, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryAcceptParamsGreen Update(InternalSyntaxToken kAccept, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KAccept != kAccept ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryAcceptParams(kAccept, param, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryAcceptParamsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryRefuseParamsGreen : GreenSyntaxNode
	{
	    internal static readonly QueryRefuseParamsGreen __Missing = new QueryRefuseParamsGreen();
	    private InternalSyntaxToken kRefuse;
	    private GreenNode param;
	    private InternalSyntaxToken tSemicolon;
	
	    public QueryRefuseParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kRefuse, GreenNode param, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kRefuse != null)
			{
				this.AdjustFlagsAndWidth(kRefuse);
				this.kRefuse = kRefuse;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public QueryRefuseParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kRefuse, GreenNode param, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kRefuse != null)
			{
				this.AdjustFlagsAndWidth(kRefuse);
				this.kRefuse = kRefuse;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private QueryRefuseParamsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryRefuseParams, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRefuse { get { return this.kRefuse; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> Param { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen>(this.param); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryRefuseParamsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRefuse;
	            case 1: return this.param;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryRefuseParamsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryRefuseParamsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryRefuseParamsGreen(this.Kind, this.kRefuse, this.param, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryRefuseParamsGreen(this.Kind, this.kRefuse, this.param, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryRefuseParamsGreen Update(InternalSyntaxToken kRefuse, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KRefuse != kRefuse ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryRefuseParams(kRefuse, param, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryRefuseParamsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryCancelParamsGreen : GreenSyntaxNode
	{
	    internal static readonly QueryCancelParamsGreen __Missing = new QueryCancelParamsGreen();
	    private InternalSyntaxToken kCancel;
	    private GreenNode param;
	    private InternalSyntaxToken tSemicolon;
	
	    public QueryCancelParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kCancel, GreenNode param, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kCancel != null)
			{
				this.AdjustFlagsAndWidth(kCancel);
				this.kCancel = kCancel;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public QueryCancelParamsGreen(PilSyntaxKind kind, InternalSyntaxToken kCancel, GreenNode param, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kCancel != null)
			{
				this.AdjustFlagsAndWidth(kCancel);
				this.kCancel = kCancel;
			}
			if (param != null)
			{
				this.AdjustFlagsAndWidth(param);
				this.param = param;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private QueryCancelParamsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryCancelParams, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCancel { get { return this.kCancel; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> Param { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen>(this.param); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryCancelParamsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCancel;
	            case 1: return this.param;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryCancelParamsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryCancelParamsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryCancelParamsGreen(this.Kind, this.kCancel, this.param, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryCancelParamsGreen(this.Kind, this.kCancel, this.param, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryCancelParamsGreen Update(InternalSyntaxToken kCancel, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KCancel != kCancel ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryCancelParams(kCancel, param, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryCancelParamsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryExternalParametersGreen : GreenSyntaxNode
	{
	    internal static readonly QueryExternalParametersGreen __Missing = new QueryExternalParametersGreen();
	    private ExternalParameterDeclarationGreen externalParameterDeclaration;
	
	    public QueryExternalParametersGreen(PilSyntaxKind kind, ExternalParameterDeclarationGreen externalParameterDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (externalParameterDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externalParameterDeclaration);
				this.externalParameterDeclaration = externalParameterDeclaration;
			}
	    }
	
	    public QueryExternalParametersGreen(PilSyntaxKind kind, ExternalParameterDeclarationGreen externalParameterDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (externalParameterDeclaration != null)
			{
				this.AdjustFlagsAndWidth(externalParameterDeclaration);
				this.externalParameterDeclaration = externalParameterDeclaration;
			}
	    }
	
		private QueryExternalParametersGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryExternalParameters, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExternalParameterDeclarationGreen ExternalParameterDeclaration { get { return this.externalParameterDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryExternalParametersSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.externalParameterDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryExternalParametersGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryExternalParametersGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryExternalParametersGreen(this.Kind, this.externalParameterDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryExternalParametersGreen(this.Kind, this.externalParameterDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryExternalParametersGreen Update(ExternalParameterDeclarationGreen externalParameterDeclaration)
	    {
	        if (this.ExternalParameterDeclaration != externalParameterDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryExternalParameters(externalParameterDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryExternalParametersGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryFieldGreen : GreenSyntaxNode
	{
	    internal static readonly QueryFieldGreen __Missing = new QueryFieldGreen();
	    private VariableDeclarationGreen variableDeclaration;
	
	    public QueryFieldGreen(PilSyntaxKind kind, VariableDeclarationGreen variableDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
	    public QueryFieldGreen(PilSyntaxKind kind, VariableDeclarationGreen variableDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
		private QueryFieldGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryField, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationGreen VariableDeclaration { get { return this.variableDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryFieldSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryFieldGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryFieldGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryFieldGreen(this.Kind, this.variableDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryFieldGreen(this.Kind, this.variableDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryFieldGreen Update(VariableDeclarationGreen variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryField(variableDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryFieldGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryFunctionGreen : GreenSyntaxNode
	{
	    internal static readonly QueryFunctionGreen __Missing = new QueryFunctionGreen();
	    private FunctionDeclarationGreen functionDeclaration;
	
	    public QueryFunctionGreen(PilSyntaxKind kind, FunctionDeclarationGreen functionDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
	    }
	
	    public QueryFunctionGreen(PilSyntaxKind kind, FunctionDeclarationGreen functionDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
	    }
	
		private QueryFunctionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryFunction, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FunctionDeclarationGreen FunctionDeclaration { get { return this.functionDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryFunctionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.functionDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryFunctionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryFunctionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryFunctionGreen(this.Kind, this.functionDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryFunctionGreen(this.Kind, this.functionDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryFunctionGreen Update(FunctionDeclarationGreen functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryFunction(functionDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryFunctionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryObjectGreen : GreenSyntaxNode
	{
	    internal static readonly QueryObjectGreen __Missing = new QueryObjectGreen();
	    private InternalSyntaxToken kObject;
	    private NameGreen name;
	    private CommentGreen comment;
	    private InternalSyntaxToken startObjectSemicolon;
	    private GreenNode queryObjectField;
	    private GreenNode queryObjectFunction;
	    private GreenNode queryObjectEvent;
	    private InternalSyntaxToken kEndObject;
	    private IdentifierGreen endName;
	    private InternalSyntaxToken endObjectSemicolon;
	
	    public QueryObjectGreen(PilSyntaxKind kind, InternalSyntaxToken kObject, NameGreen name, CommentGreen comment, InternalSyntaxToken startObjectSemicolon, GreenNode queryObjectField, GreenNode queryObjectFunction, GreenNode queryObjectEvent, InternalSyntaxToken kEndObject, IdentifierGreen endName, InternalSyntaxToken endObjectSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 10;
			if (kObject != null)
			{
				this.AdjustFlagsAndWidth(kObject);
				this.kObject = kObject;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (startObjectSemicolon != null)
			{
				this.AdjustFlagsAndWidth(startObjectSemicolon);
				this.startObjectSemicolon = startObjectSemicolon;
			}
			if (queryObjectField != null)
			{
				this.AdjustFlagsAndWidth(queryObjectField);
				this.queryObjectField = queryObjectField;
			}
			if (queryObjectFunction != null)
			{
				this.AdjustFlagsAndWidth(queryObjectFunction);
				this.queryObjectFunction = queryObjectFunction;
			}
			if (queryObjectEvent != null)
			{
				this.AdjustFlagsAndWidth(queryObjectEvent);
				this.queryObjectEvent = queryObjectEvent;
			}
			if (kEndObject != null)
			{
				this.AdjustFlagsAndWidth(kEndObject);
				this.kEndObject = kEndObject;
			}
			if (endName != null)
			{
				this.AdjustFlagsAndWidth(endName);
				this.endName = endName;
			}
			if (endObjectSemicolon != null)
			{
				this.AdjustFlagsAndWidth(endObjectSemicolon);
				this.endObjectSemicolon = endObjectSemicolon;
			}
	    }
	
	    public QueryObjectGreen(PilSyntaxKind kind, InternalSyntaxToken kObject, NameGreen name, CommentGreen comment, InternalSyntaxToken startObjectSemicolon, GreenNode queryObjectField, GreenNode queryObjectFunction, GreenNode queryObjectEvent, InternalSyntaxToken kEndObject, IdentifierGreen endName, InternalSyntaxToken endObjectSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 10;
			if (kObject != null)
			{
				this.AdjustFlagsAndWidth(kObject);
				this.kObject = kObject;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (startObjectSemicolon != null)
			{
				this.AdjustFlagsAndWidth(startObjectSemicolon);
				this.startObjectSemicolon = startObjectSemicolon;
			}
			if (queryObjectField != null)
			{
				this.AdjustFlagsAndWidth(queryObjectField);
				this.queryObjectField = queryObjectField;
			}
			if (queryObjectFunction != null)
			{
				this.AdjustFlagsAndWidth(queryObjectFunction);
				this.queryObjectFunction = queryObjectFunction;
			}
			if (queryObjectEvent != null)
			{
				this.AdjustFlagsAndWidth(queryObjectEvent);
				this.queryObjectEvent = queryObjectEvent;
			}
			if (kEndObject != null)
			{
				this.AdjustFlagsAndWidth(kEndObject);
				this.kEndObject = kEndObject;
			}
			if (endName != null)
			{
				this.AdjustFlagsAndWidth(endName);
				this.endName = endName;
			}
			if (endObjectSemicolon != null)
			{
				this.AdjustFlagsAndWidth(endObjectSemicolon);
				this.endObjectSemicolon = endObjectSemicolon;
			}
	    }
	
		private QueryObjectGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryObject, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KObject { get { return this.kObject; } }
	    public NameGreen Name { get { return this.name; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken StartObjectSemicolon { get { return this.startObjectSemicolon; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFieldGreen> QueryObjectField { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFieldGreen>(this.queryObjectField); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFunctionGreen> QueryObjectFunction { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFunctionGreen>(this.queryObjectFunction); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectEventGreen> QueryObjectEvent { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectEventGreen>(this.queryObjectEvent); } }
	    public InternalSyntaxToken KEndObject { get { return this.kEndObject; } }
	    public IdentifierGreen EndName { get { return this.endName; } }
	    public InternalSyntaxToken EndObjectSemicolon { get { return this.endObjectSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryObjectSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kObject;
	            case 1: return this.name;
	            case 2: return this.comment;
	            case 3: return this.startObjectSemicolon;
	            case 4: return this.queryObjectField;
	            case 5: return this.queryObjectFunction;
	            case 6: return this.queryObjectEvent;
	            case 7: return this.kEndObject;
	            case 8: return this.endName;
	            case 9: return this.endObjectSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryObjectGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryObjectGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryObjectGreen(this.Kind, this.kObject, this.name, this.comment, this.startObjectSemicolon, this.queryObjectField, this.queryObjectFunction, this.queryObjectEvent, this.kEndObject, this.endName, this.endObjectSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryObjectGreen(this.Kind, this.kObject, this.name, this.comment, this.startObjectSemicolon, this.queryObjectField, this.queryObjectFunction, this.queryObjectEvent, this.kEndObject, this.endName, this.endObjectSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryObjectGreen Update(InternalSyntaxToken kObject, NameGreen name, CommentGreen comment, InternalSyntaxToken startObjectSemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFieldGreen> queryObjectField, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFunctionGreen> queryObjectFunction, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectEventGreen> queryObjectEvent, InternalSyntaxToken kEndObject, IdentifierGreen endName, InternalSyntaxToken endObjectSemicolon)
	    {
	        if (this.KObject != kObject ||
				this.Name != name ||
				this.Comment != comment ||
				this.StartObjectSemicolon != startObjectSemicolon ||
				this.QueryObjectField != queryObjectField ||
				this.QueryObjectFunction != queryObjectFunction ||
				this.QueryObjectEvent != queryObjectEvent ||
				this.KEndObject != kEndObject ||
				this.EndName != endName ||
				this.EndObjectSemicolon != endObjectSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryObject(kObject, name, comment, startObjectSemicolon, queryObjectField, queryObjectFunction, queryObjectEvent, kEndObject, endName, endObjectSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryObjectFieldGreen : GreenSyntaxNode
	{
	    internal static readonly QueryObjectFieldGreen __Missing = new QueryObjectFieldGreen();
	    private VariableDeclarationGreen variableDeclaration;
	
	    public QueryObjectFieldGreen(PilSyntaxKind kind, VariableDeclarationGreen variableDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
	    public QueryObjectFieldGreen(PilSyntaxKind kind, VariableDeclarationGreen variableDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
		private QueryObjectFieldGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryObjectField, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationGreen VariableDeclaration { get { return this.variableDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryObjectFieldSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryObjectFieldGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryObjectFieldGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryObjectFieldGreen(this.Kind, this.variableDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryObjectFieldGreen(this.Kind, this.variableDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryObjectFieldGreen Update(VariableDeclarationGreen variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryObjectField(variableDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectFieldGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryObjectFunctionGreen : GreenSyntaxNode
	{
	    internal static readonly QueryObjectFunctionGreen __Missing = new QueryObjectFunctionGreen();
	    private FunctionDeclarationGreen functionDeclaration;
	
	    public QueryObjectFunctionGreen(PilSyntaxKind kind, FunctionDeclarationGreen functionDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
	    }
	
	    public QueryObjectFunctionGreen(PilSyntaxKind kind, FunctionDeclarationGreen functionDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (functionDeclaration != null)
			{
				this.AdjustFlagsAndWidth(functionDeclaration);
				this.functionDeclaration = functionDeclaration;
			}
	    }
	
		private QueryObjectFunctionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryObjectFunction, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FunctionDeclarationGreen FunctionDeclaration { get { return this.functionDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryObjectFunctionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.functionDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryObjectFunctionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryObjectFunctionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryObjectFunctionGreen(this.Kind, this.functionDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryObjectFunctionGreen(this.Kind, this.functionDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryObjectFunctionGreen Update(FunctionDeclarationGreen functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryObjectFunction(functionDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectFunctionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QueryObjectEventGreen : GreenSyntaxNode
	{
	    internal static readonly QueryObjectEventGreen __Missing = new QueryObjectEventGreen();
	    private InputGreen input;
	    private TriggerGreen trigger;
	
	    public QueryObjectEventGreen(PilSyntaxKind kind, InputGreen input, TriggerGreen trigger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (input != null)
			{
				this.AdjustFlagsAndWidth(input);
				this.input = input;
			}
			if (trigger != null)
			{
				this.AdjustFlagsAndWidth(trigger);
				this.trigger = trigger;
			}
	    }
	
	    public QueryObjectEventGreen(PilSyntaxKind kind, InputGreen input, TriggerGreen trigger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (input != null)
			{
				this.AdjustFlagsAndWidth(input);
				this.input = input;
			}
			if (trigger != null)
			{
				this.AdjustFlagsAndWidth(trigger);
				this.trigger = trigger;
			}
	    }
	
		private QueryObjectEventGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QueryObjectEvent, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InputGreen Input { get { return this.input; } }
	    public TriggerGreen Trigger { get { return this.trigger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QueryObjectEventSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.input;
	            case 1: return this.trigger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQueryObjectEventGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQueryObjectEventGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QueryObjectEventGreen(this.Kind, this.input, this.trigger, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QueryObjectEventGreen(this.Kind, this.input, this.trigger, this.GetDiagnostics(), annotations);
	    }
	
	    public QueryObjectEventGreen Update(InputGreen input)
	    {
	        if (this.input != input)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryObjectEvent(input);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectEventGreen)newNode;
	        }
	        return this;
	    }
	
	    public QueryObjectEventGreen Update(TriggerGreen trigger)
	    {
	        if (this.trigger != trigger)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QueryObjectEvent(trigger);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectEventGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InputGreen : GreenSyntaxNode
	{
	    internal static readonly InputGreen __Missing = new InputGreen();
	    private InternalSyntaxToken kInput;
	    private InputPortListGreen inputPortList;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public InputGreen(PilSyntaxKind kind, InternalSyntaxToken kInput, InputPortListGreen inputPortList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kInput != null)
			{
				this.AdjustFlagsAndWidth(kInput);
				this.kInput = kInput;
			}
			if (inputPortList != null)
			{
				this.AdjustFlagsAndWidth(inputPortList);
				this.inputPortList = inputPortList;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public InputGreen(PilSyntaxKind kind, InternalSyntaxToken kInput, InputPortListGreen inputPortList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kInput != null)
			{
				this.AdjustFlagsAndWidth(kInput);
				this.kInput = kInput;
			}
			if (inputPortList != null)
			{
				this.AdjustFlagsAndWidth(inputPortList);
				this.inputPortList = inputPortList;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private InputGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Input, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KInput { get { return this.kInput; } }
	    public InputPortListGreen InputPortList { get { return this.inputPortList; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.InputSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kInput;
	            case 1: return this.inputPortList;
	            case 2: return this.comment;
	            case 3: return this.tSemicolon;
	            case 4: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitInputGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitInputGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InputGreen(this.Kind, this.kInput, this.inputPortList, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InputGreen(this.Kind, this.kInput, this.inputPortList, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public InputGreen Update(InternalSyntaxToken kInput, InputPortListGreen inputPortList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.KInput != kInput ||
				this.InputPortList != inputPortList ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Input(kInput, inputPortList, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InputGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InputPortListGreen : GreenSyntaxNode
	{
	    internal static readonly InputPortListGreen __Missing = new InputPortListGreen();
	    private GreenNode inputPort;
	
	    public InputPortListGreen(PilSyntaxKind kind, GreenNode inputPort)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (inputPort != null)
			{
				this.AdjustFlagsAndWidth(inputPort);
				this.inputPort = inputPort;
			}
	    }
	
	    public InputPortListGreen(PilSyntaxKind kind, GreenNode inputPort, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (inputPort != null)
			{
				this.AdjustFlagsAndWidth(inputPort);
				this.inputPort = inputPort;
			}
	    }
	
		private InputPortListGreen()
			: base((PilSyntaxKind)PilSyntaxKind.InputPortList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<InputPortGreen> InputPort { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<InputPortGreen>(this.inputPort); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.InputPortListSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.inputPort;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitInputPortListGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitInputPortListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InputPortListGreen(this.Kind, this.inputPort, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InputPortListGreen(this.Kind, this.inputPort, this.GetDiagnostics(), annotations);
	    }
	
	    public InputPortListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<InputPortGreen> inputPort)
	    {
	        if (this.InputPort != inputPort)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.InputPortList(inputPort);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InputPortListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InputPortGreen : GreenSyntaxNode
	{
	    internal static readonly InputPortGreen __Missing = new InputPortGreen();
	    private IdentifierGreen portName;
	    private InternalSyntaxToken tDot;
	    private IdentifierGreen queryName;
	
	    public InputPortGreen(PilSyntaxKind kind, IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (portName != null)
			{
				this.AdjustFlagsAndWidth(portName);
				this.portName = portName;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (queryName != null)
			{
				this.AdjustFlagsAndWidth(queryName);
				this.queryName = queryName;
			}
	    }
	
	    public InputPortGreen(PilSyntaxKind kind, IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (portName != null)
			{
				this.AdjustFlagsAndWidth(portName);
				this.portName = portName;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (queryName != null)
			{
				this.AdjustFlagsAndWidth(queryName);
				this.queryName = queryName;
			}
	    }
	
		private InputPortGreen()
			: base((PilSyntaxKind)PilSyntaxKind.InputPort, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen PortName { get { return this.portName; } }
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	    public IdentifierGreen QueryName { get { return this.queryName; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.InputPortSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.portName;
	            case 1: return this.tDot;
	            case 2: return this.queryName;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitInputPortGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitInputPortGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InputPortGreen(this.Kind, this.portName, this.tDot, this.queryName, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InputPortGreen(this.Kind, this.portName, this.tDot, this.queryName, this.GetDiagnostics(), annotations);
	    }
	
	    public InputPortGreen Update(IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName)
	    {
	        if (this.PortName != portName ||
				this.TDot != tDot ||
				this.QueryName != queryName)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.InputPort(portName, tDot, queryName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InputPortGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TriggerGreen : GreenSyntaxNode
	{
	    internal static readonly TriggerGreen __Missing = new TriggerGreen();
	    private InternalSyntaxToken kTrigger;
	    private TriggerVarListGreen triggerVarList;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public TriggerGreen(PilSyntaxKind kind, InternalSyntaxToken kTrigger, TriggerVarListGreen triggerVarList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kTrigger != null)
			{
				this.AdjustFlagsAndWidth(kTrigger);
				this.kTrigger = kTrigger;
			}
			if (triggerVarList != null)
			{
				this.AdjustFlagsAndWidth(triggerVarList);
				this.triggerVarList = triggerVarList;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public TriggerGreen(PilSyntaxKind kind, InternalSyntaxToken kTrigger, TriggerVarListGreen triggerVarList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kTrigger != null)
			{
				this.AdjustFlagsAndWidth(kTrigger);
				this.kTrigger = kTrigger;
			}
			if (triggerVarList != null)
			{
				this.AdjustFlagsAndWidth(triggerVarList);
				this.triggerVarList = triggerVarList;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private TriggerGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Trigger, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTrigger { get { return this.kTrigger; } }
	    public TriggerVarListGreen TriggerVarList { get { return this.triggerVarList; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TriggerSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTrigger;
	            case 1: return this.triggerVarList;
	            case 2: return this.comment;
	            case 3: return this.tSemicolon;
	            case 4: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTriggerGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTriggerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TriggerGreen(this.Kind, this.kTrigger, this.triggerVarList, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TriggerGreen(this.Kind, this.kTrigger, this.triggerVarList, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public TriggerGreen Update(InternalSyntaxToken kTrigger, TriggerVarListGreen triggerVarList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.KTrigger != kTrigger ||
				this.TriggerVarList != triggerVarList ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Trigger(kTrigger, triggerVarList, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TriggerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TriggerVarListGreen : GreenSyntaxNode
	{
	    internal static readonly TriggerVarListGreen __Missing = new TriggerVarListGreen();
	    private GreenNode triggerVar;
	
	    public TriggerVarListGreen(PilSyntaxKind kind, GreenNode triggerVar)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (triggerVar != null)
			{
				this.AdjustFlagsAndWidth(triggerVar);
				this.triggerVar = triggerVar;
			}
	    }
	
	    public TriggerVarListGreen(PilSyntaxKind kind, GreenNode triggerVar, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (triggerVar != null)
			{
				this.AdjustFlagsAndWidth(triggerVar);
				this.triggerVar = triggerVar;
			}
	    }
	
		private TriggerVarListGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TriggerVarList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TriggerVarGreen> TriggerVar { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TriggerVarGreen>(this.triggerVar); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TriggerVarListSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.triggerVar;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTriggerVarListGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTriggerVarListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TriggerVarListGreen(this.Kind, this.triggerVar, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TriggerVarListGreen(this.Kind, this.triggerVar, this.GetDiagnostics(), annotations);
	    }
	
	    public TriggerVarListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TriggerVarGreen> triggerVar)
	    {
	        if (this.TriggerVar != triggerVar)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TriggerVarList(triggerVar);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TriggerVarListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TriggerVarGreen : GreenSyntaxNode
	{
	    internal static readonly TriggerVarGreen __Missing = new TriggerVarGreen();
	    private IdentifierGreen identifier;
	
	    public TriggerVarGreen(PilSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public TriggerVarGreen(PilSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private TriggerVarGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TriggerVar, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TriggerVarSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTriggerVarGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTriggerVarGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TriggerVarGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TriggerVarGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public TriggerVarGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TriggerVar(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TriggerVarGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StatementsGreen : GreenSyntaxNode
	{
	    internal static readonly StatementsGreen __Missing = new StatementsGreen();
	    private GreenNode statement;
	
	    public StatementsGreen(PilSyntaxKind kind, GreenNode statement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
	    }
	
	    public StatementsGreen(PilSyntaxKind kind, GreenNode statement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
	    }
	
		private StatementsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Statements, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> Statement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen>(this.statement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.StatementsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.statement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitStatementsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitStatementsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StatementsGreen(this.Kind, this.statement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StatementsGreen(this.Kind, this.statement, this.GetDiagnostics(), annotations);
	    }
	
	    public StatementsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement)
	    {
	        if (this.Statement != statement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statements(statement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StatementGreen : GreenSyntaxNode
	{
	    internal static readonly StatementGreen __Missing = new StatementGreen();
	    private VariableDeclarationStatementGreen variableDeclarationStatement;
	    private RequestStatementGreen requestStatement;
	    private ForkStatementGreen forkStatement;
	    private ForkRequestStatementGreen forkRequestStatement;
	    private IfStatementGreen ifStatement;
	    private ResponseStatementGreen responseStatement;
	    private CancelStatementGreen cancelStatement;
	    private AssignmentStatementGreen assignmentStatement;
	
	    public StatementGreen(PilSyntaxKind kind, VariableDeclarationStatementGreen variableDeclarationStatement, RequestStatementGreen requestStatement, ForkStatementGreen forkStatement, ForkRequestStatementGreen forkRequestStatement, IfStatementGreen ifStatement, ResponseStatementGreen responseStatement, CancelStatementGreen cancelStatement, AssignmentStatementGreen assignmentStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (variableDeclarationStatement != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationStatement);
				this.variableDeclarationStatement = variableDeclarationStatement;
			}
			if (requestStatement != null)
			{
				this.AdjustFlagsAndWidth(requestStatement);
				this.requestStatement = requestStatement;
			}
			if (forkStatement != null)
			{
				this.AdjustFlagsAndWidth(forkStatement);
				this.forkStatement = forkStatement;
			}
			if (forkRequestStatement != null)
			{
				this.AdjustFlagsAndWidth(forkRequestStatement);
				this.forkRequestStatement = forkRequestStatement;
			}
			if (ifStatement != null)
			{
				this.AdjustFlagsAndWidth(ifStatement);
				this.ifStatement = ifStatement;
			}
			if (responseStatement != null)
			{
				this.AdjustFlagsAndWidth(responseStatement);
				this.responseStatement = responseStatement;
			}
			if (cancelStatement != null)
			{
				this.AdjustFlagsAndWidth(cancelStatement);
				this.cancelStatement = cancelStatement;
			}
			if (assignmentStatement != null)
			{
				this.AdjustFlagsAndWidth(assignmentStatement);
				this.assignmentStatement = assignmentStatement;
			}
	    }
	
	    public StatementGreen(PilSyntaxKind kind, VariableDeclarationStatementGreen variableDeclarationStatement, RequestStatementGreen requestStatement, ForkStatementGreen forkStatement, ForkRequestStatementGreen forkRequestStatement, IfStatementGreen ifStatement, ResponseStatementGreen responseStatement, CancelStatementGreen cancelStatement, AssignmentStatementGreen assignmentStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (variableDeclarationStatement != null)
			{
				this.AdjustFlagsAndWidth(variableDeclarationStatement);
				this.variableDeclarationStatement = variableDeclarationStatement;
			}
			if (requestStatement != null)
			{
				this.AdjustFlagsAndWidth(requestStatement);
				this.requestStatement = requestStatement;
			}
			if (forkStatement != null)
			{
				this.AdjustFlagsAndWidth(forkStatement);
				this.forkStatement = forkStatement;
			}
			if (forkRequestStatement != null)
			{
				this.AdjustFlagsAndWidth(forkRequestStatement);
				this.forkRequestStatement = forkRequestStatement;
			}
			if (ifStatement != null)
			{
				this.AdjustFlagsAndWidth(ifStatement);
				this.ifStatement = ifStatement;
			}
			if (responseStatement != null)
			{
				this.AdjustFlagsAndWidth(responseStatement);
				this.responseStatement = responseStatement;
			}
			if (cancelStatement != null)
			{
				this.AdjustFlagsAndWidth(cancelStatement);
				this.cancelStatement = cancelStatement;
			}
			if (assignmentStatement != null)
			{
				this.AdjustFlagsAndWidth(assignmentStatement);
				this.assignmentStatement = assignmentStatement;
			}
	    }
	
		private StatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Statement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationStatementGreen VariableDeclarationStatement { get { return this.variableDeclarationStatement; } }
	    public RequestStatementGreen RequestStatement { get { return this.requestStatement; } }
	    public ForkStatementGreen ForkStatement { get { return this.forkStatement; } }
	    public ForkRequestStatementGreen ForkRequestStatement { get { return this.forkRequestStatement; } }
	    public IfStatementGreen IfStatement { get { return this.ifStatement; } }
	    public ResponseStatementGreen ResponseStatement { get { return this.responseStatement; } }
	    public CancelStatementGreen CancelStatement { get { return this.cancelStatement; } }
	    public AssignmentStatementGreen AssignmentStatement { get { return this.assignmentStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.StatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclarationStatement;
	            case 1: return this.requestStatement;
	            case 2: return this.forkStatement;
	            case 3: return this.forkRequestStatement;
	            case 4: return this.ifStatement;
	            case 5: return this.responseStatement;
	            case 6: return this.cancelStatement;
	            case 7: return this.assignmentStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StatementGreen(this.Kind, this.variableDeclarationStatement, this.requestStatement, this.forkStatement, this.forkRequestStatement, this.ifStatement, this.responseStatement, this.cancelStatement, this.assignmentStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StatementGreen(this.Kind, this.variableDeclarationStatement, this.requestStatement, this.forkStatement, this.forkRequestStatement, this.ifStatement, this.responseStatement, this.cancelStatement, this.assignmentStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public StatementGreen Update(VariableDeclarationStatementGreen variableDeclarationStatement)
	    {
	        if (this.variableDeclarationStatement != variableDeclarationStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(variableDeclarationStatement);
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
	
	    public StatementGreen Update(RequestStatementGreen requestStatement)
	    {
	        if (this.requestStatement != requestStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(requestStatement);
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
	
	    public StatementGreen Update(ForkStatementGreen forkStatement)
	    {
	        if (this.forkStatement != forkStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(forkStatement);
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
	
	    public StatementGreen Update(ForkRequestStatementGreen forkRequestStatement)
	    {
	        if (this.forkRequestStatement != forkRequestStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(forkRequestStatement);
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
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(ifStatement);
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
	
	    public StatementGreen Update(ResponseStatementGreen responseStatement)
	    {
	        if (this.responseStatement != responseStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(responseStatement);
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
	
	    public StatementGreen Update(CancelStatementGreen cancelStatement)
	    {
	        if (this.cancelStatement != cancelStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(cancelStatement);
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
	
	    public StatementGreen Update(AssignmentStatementGreen assignmentStatement)
	    {
	        if (this.assignmentStatement != assignmentStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Statement(assignmentStatement);
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
	
	internal class ForkStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ForkStatementGreen __Missing = new ForkStatementGreen();
	    private InternalSyntaxToken kFork;
	    private ExpressionGreen expression;
	    private GreenNode caseBranch;
	    private ElseBranchGreen elseBranch;
	    private InternalSyntaxToken kEndFork;
	
	    public ForkStatementGreen(PilSyntaxKind kind, InternalSyntaxToken kFork, ExpressionGreen expression, GreenNode caseBranch, ElseBranchGreen elseBranch, InternalSyntaxToken kEndFork)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kFork != null)
			{
				this.AdjustFlagsAndWidth(kFork);
				this.kFork = kFork;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (caseBranch != null)
			{
				this.AdjustFlagsAndWidth(caseBranch);
				this.caseBranch = caseBranch;
			}
			if (elseBranch != null)
			{
				this.AdjustFlagsAndWidth(elseBranch);
				this.elseBranch = elseBranch;
			}
			if (kEndFork != null)
			{
				this.AdjustFlagsAndWidth(kEndFork);
				this.kEndFork = kEndFork;
			}
	    }
	
	    public ForkStatementGreen(PilSyntaxKind kind, InternalSyntaxToken kFork, ExpressionGreen expression, GreenNode caseBranch, ElseBranchGreen elseBranch, InternalSyntaxToken kEndFork, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kFork != null)
			{
				this.AdjustFlagsAndWidth(kFork);
				this.kFork = kFork;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (caseBranch != null)
			{
				this.AdjustFlagsAndWidth(caseBranch);
				this.caseBranch = caseBranch;
			}
			if (elseBranch != null)
			{
				this.AdjustFlagsAndWidth(elseBranch);
				this.elseBranch = elseBranch;
			}
			if (kEndFork != null)
			{
				this.AdjustFlagsAndWidth(kEndFork);
				this.kEndFork = kEndFork;
			}
	    }
	
		private ForkStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ForkStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KFork { get { return this.kFork; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CaseBranchGreen> CaseBranch { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CaseBranchGreen>(this.caseBranch); } }
	    public ElseBranchGreen ElseBranch { get { return this.elseBranch; } }
	    public InternalSyntaxToken KEndFork { get { return this.kEndFork; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ForkStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kFork;
	            case 1: return this.expression;
	            case 2: return this.caseBranch;
	            case 3: return this.elseBranch;
	            case 4: return this.kEndFork;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitForkStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitForkStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForkStatementGreen(this.Kind, this.kFork, this.expression, this.caseBranch, this.elseBranch, this.kEndFork, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForkStatementGreen(this.Kind, this.kFork, this.expression, this.caseBranch, this.elseBranch, this.kEndFork, this.GetDiagnostics(), annotations);
	    }
	
	    public ForkStatementGreen Update(InternalSyntaxToken kFork, ExpressionGreen expression, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CaseBranchGreen> caseBranch, ElseBranchGreen elseBranch, InternalSyntaxToken kEndFork)
	    {
	        if (this.KFork != kFork ||
				this.Expression != expression ||
				this.CaseBranch != caseBranch ||
				this.ElseBranch != elseBranch ||
				this.KEndFork != kEndFork)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ForkStatement(kFork, expression, caseBranch, elseBranch, kEndFork);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CaseBranchGreen : GreenSyntaxNode
	{
	    internal static readonly CaseBranchGreen __Missing = new CaseBranchGreen();
	    private InternalSyntaxToken kCase;
	    private ExpressionGreen condition;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public CaseBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public CaseBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private CaseBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.CaseBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCase { get { return this.kCase; } }
	    public ExpressionGreen Condition { get { return this.condition; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.CaseBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCase;
	            case 1: return this.condition;
	            case 2: return this.comment;
	            case 3: return this.tSemicolon;
	            case 4: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitCaseBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitCaseBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CaseBranchGreen(this.Kind, this.kCase, this.condition, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CaseBranchGreen(this.Kind, this.kCase, this.condition, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public CaseBranchGreen Update(InternalSyntaxToken kCase, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.KCase != kCase ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.CaseBranch(kCase, condition, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CaseBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElseBranchGreen : GreenSyntaxNode
	{
	    internal static readonly ElseBranchGreen __Missing = new ElseBranchGreen();
	    private InternalSyntaxToken kElse;
	    private CommentGreen comment;
	    private StatementsGreen statements;
	
	    public ElseBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kElse, CommentGreen comment, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public ElseBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kElse, CommentGreen comment, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private ElseBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ElseBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KElse { get { return this.kElse; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ElseBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kElse;
	            case 1: return this.comment;
	            case 2: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitElseBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitElseBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElseBranchGreen(this.Kind, this.kElse, this.comment, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElseBranchGreen(this.Kind, this.kElse, this.comment, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public ElseBranchGreen Update(InternalSyntaxToken kElse, CommentGreen comment, StatementsGreen statements)
	    {
	        if (this.KElse != kElse ||
				this.Comment != comment ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ElseBranch(kElse, comment, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IfStatementGreen : GreenSyntaxNode
	{
	    internal static readonly IfStatementGreen __Missing = new IfStatementGreen();
	    private InternalSyntaxToken kIf;
	    private IfBranchGreen ifBranch;
	    private GreenNode elseIfBranch;
	    private GreenNode elseBranch;
	    private InternalSyntaxToken kEndIf;
	
	    public IfStatementGreen(PilSyntaxKind kind, InternalSyntaxToken kIf, IfBranchGreen ifBranch, GreenNode elseIfBranch, GreenNode elseBranch, InternalSyntaxToken kEndIf)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
			if (ifBranch != null)
			{
				this.AdjustFlagsAndWidth(ifBranch);
				this.ifBranch = ifBranch;
			}
			if (elseIfBranch != null)
			{
				this.AdjustFlagsAndWidth(elseIfBranch);
				this.elseIfBranch = elseIfBranch;
			}
			if (elseBranch != null)
			{
				this.AdjustFlagsAndWidth(elseBranch);
				this.elseBranch = elseBranch;
			}
			if (kEndIf != null)
			{
				this.AdjustFlagsAndWidth(kEndIf);
				this.kEndIf = kEndIf;
			}
	    }
	
	    public IfStatementGreen(PilSyntaxKind kind, InternalSyntaxToken kIf, IfBranchGreen ifBranch, GreenNode elseIfBranch, GreenNode elseBranch, InternalSyntaxToken kEndIf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kIf != null)
			{
				this.AdjustFlagsAndWidth(kIf);
				this.kIf = kIf;
			}
			if (ifBranch != null)
			{
				this.AdjustFlagsAndWidth(ifBranch);
				this.ifBranch = ifBranch;
			}
			if (elseIfBranch != null)
			{
				this.AdjustFlagsAndWidth(elseIfBranch);
				this.elseIfBranch = elseIfBranch;
			}
			if (elseBranch != null)
			{
				this.AdjustFlagsAndWidth(elseBranch);
				this.elseBranch = elseBranch;
			}
			if (kEndIf != null)
			{
				this.AdjustFlagsAndWidth(kEndIf);
				this.kEndIf = kEndIf;
			}
	    }
	
		private IfStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.IfStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KIf { get { return this.kIf; } }
	    public IfBranchGreen IfBranch { get { return this.ifBranch; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfBranchGreen> ElseIfBranch { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfBranchGreen>(this.elseIfBranch); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseBranchGreen> ElseBranch { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseBranchGreen>(this.elseBranch); } }
	    public InternalSyntaxToken KEndIf { get { return this.kEndIf; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.IfStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kIf;
	            case 1: return this.ifBranch;
	            case 2: return this.elseIfBranch;
	            case 3: return this.elseBranch;
	            case 4: return this.kEndIf;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitIfStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitIfStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfStatementGreen(this.Kind, this.kIf, this.ifBranch, this.elseIfBranch, this.elseBranch, this.kEndIf, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfStatementGreen(this.Kind, this.kIf, this.ifBranch, this.elseIfBranch, this.elseBranch, this.kEndIf, this.GetDiagnostics(), annotations);
	    }
	
	    public IfStatementGreen Update(InternalSyntaxToken kIf, IfBranchGreen ifBranch, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfBranchGreen> elseIfBranch, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseBranchGreen> elseBranch, InternalSyntaxToken kEndIf)
	    {
	        if (this.KIf != kIf ||
				this.IfBranch != ifBranch ||
				this.ElseIfBranch != elseIfBranch ||
				this.ElseBranch != elseBranch ||
				this.KEndIf != kEndIf)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.IfStatement(kIf, ifBranch, elseIfBranch, elseBranch, kEndIf);
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
	
	internal class IfBranchGreen : GreenSyntaxNode
	{
	    internal static readonly IfBranchGreen __Missing = new IfBranchGreen();
	    private ConditionalExpressionGreen conditionalExpression;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public IfBranchGreen(PilSyntaxKind kind, ConditionalExpressionGreen conditionalExpression, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (conditionalExpression != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpression);
				this.conditionalExpression = conditionalExpression;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public IfBranchGreen(PilSyntaxKind kind, ConditionalExpressionGreen conditionalExpression, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (conditionalExpression != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpression);
				this.conditionalExpression = conditionalExpression;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private IfBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.IfBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ConditionalExpressionGreen ConditionalExpression { get { return this.conditionalExpression; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.IfBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.conditionalExpression;
	            case 1: return this.comment;
	            case 2: return this.tSemicolon;
	            case 3: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitIfBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitIfBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IfBranchGreen(this.Kind, this.conditionalExpression, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IfBranchGreen(this.Kind, this.conditionalExpression, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public IfBranchGreen Update(ConditionalExpressionGreen conditionalExpression, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.ConditionalExpression != conditionalExpression ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.IfBranch(conditionalExpression, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElseIfBranchGreen : GreenSyntaxNode
	{
	    internal static readonly ElseIfBranchGreen __Missing = new ElseIfBranchGreen();
	    private InternalSyntaxToken kElse;
	    private InternalSyntaxToken kIf;
	    private IfBranchGreen ifBranch;
	
	    public ElseIfBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kElse, InternalSyntaxToken kIf, IfBranchGreen ifBranch)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
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
			if (ifBranch != null)
			{
				this.AdjustFlagsAndWidth(ifBranch);
				this.ifBranch = ifBranch;
			}
	    }
	
	    public ElseIfBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kElse, InternalSyntaxToken kIf, IfBranchGreen ifBranch, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
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
			if (ifBranch != null)
			{
				this.AdjustFlagsAndWidth(ifBranch);
				this.ifBranch = ifBranch;
			}
	    }
	
		private ElseIfBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ElseIfBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KElse { get { return this.kElse; } }
	    public InternalSyntaxToken KIf { get { return this.kIf; } }
	    public IfBranchGreen IfBranch { get { return this.ifBranch; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ElseIfBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kElse;
	            case 1: return this.kIf;
	            case 2: return this.ifBranch;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitElseIfBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitElseIfBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElseIfBranchGreen(this.Kind, this.kElse, this.kIf, this.ifBranch, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElseIfBranchGreen(this.Kind, this.kElse, this.kIf, this.ifBranch, this.GetDiagnostics(), annotations);
	    }
	
	    public ElseIfBranchGreen Update(InternalSyntaxToken kElse, InternalSyntaxToken kIf, IfBranchGreen ifBranch)
	    {
	        if (this.KElse != kElse ||
				this.KIf != kIf ||
				this.IfBranch != ifBranch)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ElseIfBranch(kElse, kIf, ifBranch);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseIfBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RequestStatementGreen : GreenSyntaxNode
	{
	    internal static readonly RequestStatementGreen __Missing = new RequestStatementGreen();
	    private LeftSideGreen leftSide;
	    private InternalSyntaxToken tAssign;
	    private CallRequestGreen callRequest;
	    private AssertionGreen assertion;
	    private InternalSyntaxToken tSemicolon;
	
	    public RequestStatementGreen(PilSyntaxKind kind, LeftSideGreen leftSide, InternalSyntaxToken tAssign, CallRequestGreen callRequest, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (leftSide != null)
			{
				this.AdjustFlagsAndWidth(leftSide);
				this.leftSide = leftSide;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (callRequest != null)
			{
				this.AdjustFlagsAndWidth(callRequest);
				this.callRequest = callRequest;
			}
			if (assertion != null)
			{
				this.AdjustFlagsAndWidth(assertion);
				this.assertion = assertion;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public RequestStatementGreen(PilSyntaxKind kind, LeftSideGreen leftSide, InternalSyntaxToken tAssign, CallRequestGreen callRequest, AssertionGreen assertion, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (leftSide != null)
			{
				this.AdjustFlagsAndWidth(leftSide);
				this.leftSide = leftSide;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (callRequest != null)
			{
				this.AdjustFlagsAndWidth(callRequest);
				this.callRequest = callRequest;
			}
			if (assertion != null)
			{
				this.AdjustFlagsAndWidth(assertion);
				this.assertion = assertion;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private RequestStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.RequestStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LeftSideGreen LeftSide { get { return this.leftSide; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public CallRequestGreen CallRequest { get { return this.callRequest; } }
	    public AssertionGreen Assertion { get { return this.assertion; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.RequestStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leftSide;
	            case 1: return this.tAssign;
	            case 2: return this.callRequest;
	            case 3: return this.assertion;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitRequestStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitRequestStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RequestStatementGreen(this.Kind, this.leftSide, this.tAssign, this.callRequest, this.assertion, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RequestStatementGreen(this.Kind, this.leftSide, this.tAssign, this.callRequest, this.assertion, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public RequestStatementGreen Update(LeftSideGreen leftSide, InternalSyntaxToken tAssign, CallRequestGreen callRequest, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	    {
	        if (this.LeftSide != leftSide ||
				this.TAssign != tAssign ||
				this.CallRequest != callRequest ||
				this.Assertion != assertion ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.RequestStatement(leftSide, tAssign, callRequest, assertion, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RequestStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CallRequestGreen : GreenSyntaxNode
	{
	    internal static readonly CallRequestGreen __Missing = new CallRequestGreen();
	    private InternalSyntaxToken kRequest;
	    private IdentifierGreen portName;
	    private InternalSyntaxToken tDot;
	    private IdentifierGreen queryName;
	    private RequestArgumentsGreen requestArguments;
	
	    public CallRequestGreen(PilSyntaxKind kind, InternalSyntaxToken kRequest, IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName, RequestArgumentsGreen requestArguments)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kRequest != null)
			{
				this.AdjustFlagsAndWidth(kRequest);
				this.kRequest = kRequest;
			}
			if (portName != null)
			{
				this.AdjustFlagsAndWidth(portName);
				this.portName = portName;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (queryName != null)
			{
				this.AdjustFlagsAndWidth(queryName);
				this.queryName = queryName;
			}
			if (requestArguments != null)
			{
				this.AdjustFlagsAndWidth(requestArguments);
				this.requestArguments = requestArguments;
			}
	    }
	
	    public CallRequestGreen(PilSyntaxKind kind, InternalSyntaxToken kRequest, IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName, RequestArgumentsGreen requestArguments, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kRequest != null)
			{
				this.AdjustFlagsAndWidth(kRequest);
				this.kRequest = kRequest;
			}
			if (portName != null)
			{
				this.AdjustFlagsAndWidth(portName);
				this.portName = portName;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
			if (queryName != null)
			{
				this.AdjustFlagsAndWidth(queryName);
				this.queryName = queryName;
			}
			if (requestArguments != null)
			{
				this.AdjustFlagsAndWidth(requestArguments);
				this.requestArguments = requestArguments;
			}
	    }
	
		private CallRequestGreen()
			: base((PilSyntaxKind)PilSyntaxKind.CallRequest, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRequest { get { return this.kRequest; } }
	    public IdentifierGreen PortName { get { return this.portName; } }
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	    public IdentifierGreen QueryName { get { return this.queryName; } }
	    public RequestArgumentsGreen RequestArguments { get { return this.requestArguments; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.CallRequestSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRequest;
	            case 1: return this.portName;
	            case 2: return this.tDot;
	            case 3: return this.queryName;
	            case 4: return this.requestArguments;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitCallRequestGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitCallRequestGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CallRequestGreen(this.Kind, this.kRequest, this.portName, this.tDot, this.queryName, this.requestArguments, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CallRequestGreen(this.Kind, this.kRequest, this.portName, this.tDot, this.queryName, this.requestArguments, this.GetDiagnostics(), annotations);
	    }
	
	    public CallRequestGreen Update(InternalSyntaxToken kRequest, IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName, RequestArgumentsGreen requestArguments)
	    {
	        if (this.KRequest != kRequest ||
				this.PortName != portName ||
				this.TDot != tDot ||
				this.QueryName != queryName ||
				this.RequestArguments != requestArguments)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.CallRequest(kRequest, portName, tDot, queryName, requestArguments);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CallRequestGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RequestArgumentsGreen : GreenSyntaxNode
	{
	    internal static readonly RequestArgumentsGreen __Missing = new RequestArgumentsGreen();
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tCloseParen;
	
	    public RequestArgumentsGreen(PilSyntaxKind kind, InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public RequestArgumentsGreen(PilSyntaxKind kind, InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private RequestArgumentsGreen()
			: base((PilSyntaxKind)PilSyntaxKind.RequestArguments, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.RequestArgumentsSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.expressionList;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitRequestArgumentsGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitRequestArgumentsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RequestArgumentsGreen(this.Kind, this.tOpenParen, this.expressionList, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RequestArgumentsGreen(this.Kind, this.tOpenParen, this.expressionList, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public RequestArgumentsGreen Update(InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ExpressionList != expressionList ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.RequestArguments(tOpenParen, expressionList, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RequestArgumentsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ResponseStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ResponseStatementGreen __Missing = new ResponseStatementGreen();
	    private ResponseStatementKindGreen responseStatementKind;
	    private AssertionGreen assertion;
	    private InternalSyntaxToken tSemicolon;
	
	    public ResponseStatementGreen(PilSyntaxKind kind, ResponseStatementKindGreen responseStatementKind, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (responseStatementKind != null)
			{
				this.AdjustFlagsAndWidth(responseStatementKind);
				this.responseStatementKind = responseStatementKind;
			}
			if (assertion != null)
			{
				this.AdjustFlagsAndWidth(assertion);
				this.assertion = assertion;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ResponseStatementGreen(PilSyntaxKind kind, ResponseStatementKindGreen responseStatementKind, AssertionGreen assertion, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (responseStatementKind != null)
			{
				this.AdjustFlagsAndWidth(responseStatementKind);
				this.responseStatementKind = responseStatementKind;
			}
			if (assertion != null)
			{
				this.AdjustFlagsAndWidth(assertion);
				this.assertion = assertion;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ResponseStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ResponseStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ResponseStatementKindGreen ResponseStatementKind { get { return this.responseStatementKind; } }
	    public AssertionGreen Assertion { get { return this.assertion; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ResponseStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.responseStatementKind;
	            case 1: return this.assertion;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitResponseStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitResponseStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ResponseStatementGreen(this.Kind, this.responseStatementKind, this.assertion, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ResponseStatementGreen(this.Kind, this.responseStatementKind, this.assertion, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ResponseStatementGreen Update(ResponseStatementKindGreen responseStatementKind, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	    {
	        if (this.ResponseStatementKind != responseStatementKind ||
				this.Assertion != assertion ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ResponseStatement(responseStatementKind, assertion, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ResponseStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CancelStatementGreen : GreenSyntaxNode
	{
	    internal static readonly CancelStatementGreen __Missing = new CancelStatementGreen();
	    private CancelStatementKindGreen cancelStatementKind;
	    private IdentifierGreen portName;
	    private AssertionGreen assertion;
	    private InternalSyntaxToken tSemicolon;
	
	    public CancelStatementGreen(PilSyntaxKind kind, CancelStatementKindGreen cancelStatementKind, IdentifierGreen portName, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (cancelStatementKind != null)
			{
				this.AdjustFlagsAndWidth(cancelStatementKind);
				this.cancelStatementKind = cancelStatementKind;
			}
			if (portName != null)
			{
				this.AdjustFlagsAndWidth(portName);
				this.portName = portName;
			}
			if (assertion != null)
			{
				this.AdjustFlagsAndWidth(assertion);
				this.assertion = assertion;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public CancelStatementGreen(PilSyntaxKind kind, CancelStatementKindGreen cancelStatementKind, IdentifierGreen portName, AssertionGreen assertion, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (cancelStatementKind != null)
			{
				this.AdjustFlagsAndWidth(cancelStatementKind);
				this.cancelStatementKind = cancelStatementKind;
			}
			if (portName != null)
			{
				this.AdjustFlagsAndWidth(portName);
				this.portName = portName;
			}
			if (assertion != null)
			{
				this.AdjustFlagsAndWidth(assertion);
				this.assertion = assertion;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private CancelStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.CancelStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public CancelStatementKindGreen CancelStatementKind { get { return this.cancelStatementKind; } }
	    public IdentifierGreen PortName { get { return this.portName; } }
	    public AssertionGreen Assertion { get { return this.assertion; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.CancelStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.cancelStatementKind;
	            case 1: return this.portName;
	            case 2: return this.assertion;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitCancelStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitCancelStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CancelStatementGreen(this.Kind, this.cancelStatementKind, this.portName, this.assertion, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CancelStatementGreen(this.Kind, this.cancelStatementKind, this.portName, this.assertion, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public CancelStatementGreen Update(CancelStatementKindGreen cancelStatementKind, IdentifierGreen portName, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	    {
	        if (this.CancelStatementKind != cancelStatementKind ||
				this.PortName != portName ||
				this.Assertion != assertion ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.CancelStatement(cancelStatementKind, portName, assertion, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CancelStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssertionGreen : GreenSyntaxNode
	{
	    internal static readonly AssertionGreen __Missing = new AssertionGreen();
	    private InternalSyntaxToken tColon;
	    private ExpressionGreen expression;
	    private CommentGreen comment;
	
	    public AssertionGreen(PilSyntaxKind kind, InternalSyntaxToken tColon, ExpressionGreen expression, CommentGreen comment)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
	    }
	
	    public AssertionGreen(PilSyntaxKind kind, InternalSyntaxToken tColon, ExpressionGreen expression, CommentGreen comment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
	    }
	
		private AssertionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Assertion, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public CommentGreen Comment { get { return this.comment; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.AssertionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tColon;
	            case 1: return this.expression;
	            case 2: return this.comment;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitAssertionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitAssertionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssertionGreen(this.Kind, this.tColon, this.expression, this.comment, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssertionGreen(this.Kind, this.tColon, this.expression, this.comment, this.GetDiagnostics(), annotations);
	    }
	
	    public AssertionGreen Update(InternalSyntaxToken tColon, ExpressionGreen expression, CommentGreen comment)
	    {
	        if (this.TColon != tColon ||
				this.Expression != expression ||
				this.Comment != comment)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Assertion(tColon, expression, comment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssertionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ResponseStatementKindGreen : GreenSyntaxNode
	{
	    internal static readonly ResponseStatementKindGreen __Missing = new ResponseStatementKindGreen();
	    private InternalSyntaxToken responseStatementKind;
	
	    public ResponseStatementKindGreen(PilSyntaxKind kind, InternalSyntaxToken responseStatementKind)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (responseStatementKind != null)
			{
				this.AdjustFlagsAndWidth(responseStatementKind);
				this.responseStatementKind = responseStatementKind;
			}
	    }
	
	    public ResponseStatementKindGreen(PilSyntaxKind kind, InternalSyntaxToken responseStatementKind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (responseStatementKind != null)
			{
				this.AdjustFlagsAndWidth(responseStatementKind);
				this.responseStatementKind = responseStatementKind;
			}
	    }
	
		private ResponseStatementKindGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ResponseStatementKind, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ResponseStatementKind { get { return this.responseStatementKind; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ResponseStatementKindSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.responseStatementKind;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitResponseStatementKindGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitResponseStatementKindGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ResponseStatementKindGreen(this.Kind, this.responseStatementKind, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ResponseStatementKindGreen(this.Kind, this.responseStatementKind, this.GetDiagnostics(), annotations);
	    }
	
	    public ResponseStatementKindGreen Update(InternalSyntaxToken responseStatementKind)
	    {
	        if (this.ResponseStatementKind != responseStatementKind)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ResponseStatementKind(responseStatementKind);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ResponseStatementKindGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CancelStatementKindGreen : GreenSyntaxNode
	{
	    internal static readonly CancelStatementKindGreen __Missing = new CancelStatementKindGreen();
	    private InternalSyntaxToken kCancel;
	
	    public CancelStatementKindGreen(PilSyntaxKind kind, InternalSyntaxToken kCancel)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kCancel != null)
			{
				this.AdjustFlagsAndWidth(kCancel);
				this.kCancel = kCancel;
			}
	    }
	
	    public CancelStatementKindGreen(PilSyntaxKind kind, InternalSyntaxToken kCancel, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kCancel != null)
			{
				this.AdjustFlagsAndWidth(kCancel);
				this.kCancel = kCancel;
			}
	    }
	
		private CancelStatementKindGreen()
			: base((PilSyntaxKind)PilSyntaxKind.CancelStatementKind, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCancel { get { return this.kCancel; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.CancelStatementKindSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCancel;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitCancelStatementKindGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitCancelStatementKindGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CancelStatementKindGreen(this.Kind, this.kCancel, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CancelStatementKindGreen(this.Kind, this.kCancel, this.GetDiagnostics(), annotations);
	    }
	
	    public CancelStatementKindGreen Update(InternalSyntaxToken kCancel)
	    {
	        if (this.KCancel != kCancel)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.CancelStatementKind(kCancel);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CancelStatementKindGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForkRequestStatementGreen : GreenSyntaxNode
	{
	    internal static readonly ForkRequestStatementGreen __Missing = new ForkRequestStatementGreen();
	    private InternalSyntaxToken kFork;
	    private ForkRequestVariableGreen forkRequestVariable;
	    private AcceptBranchGreen acceptBranch;
	    private RefuseBranchGreen refuseBranch;
	    private CancelBranchGreen cancelBranch;
	    private InternalSyntaxToken kEndFork;
	
	    public ForkRequestStatementGreen(PilSyntaxKind kind, InternalSyntaxToken kFork, ForkRequestVariableGreen forkRequestVariable, AcceptBranchGreen acceptBranch, RefuseBranchGreen refuseBranch, CancelBranchGreen cancelBranch, InternalSyntaxToken kEndFork)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kFork != null)
			{
				this.AdjustFlagsAndWidth(kFork);
				this.kFork = kFork;
			}
			if (forkRequestVariable != null)
			{
				this.AdjustFlagsAndWidth(forkRequestVariable);
				this.forkRequestVariable = forkRequestVariable;
			}
			if (acceptBranch != null)
			{
				this.AdjustFlagsAndWidth(acceptBranch);
				this.acceptBranch = acceptBranch;
			}
			if (refuseBranch != null)
			{
				this.AdjustFlagsAndWidth(refuseBranch);
				this.refuseBranch = refuseBranch;
			}
			if (cancelBranch != null)
			{
				this.AdjustFlagsAndWidth(cancelBranch);
				this.cancelBranch = cancelBranch;
			}
			if (kEndFork != null)
			{
				this.AdjustFlagsAndWidth(kEndFork);
				this.kEndFork = kEndFork;
			}
	    }
	
	    public ForkRequestStatementGreen(PilSyntaxKind kind, InternalSyntaxToken kFork, ForkRequestVariableGreen forkRequestVariable, AcceptBranchGreen acceptBranch, RefuseBranchGreen refuseBranch, CancelBranchGreen cancelBranch, InternalSyntaxToken kEndFork, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kFork != null)
			{
				this.AdjustFlagsAndWidth(kFork);
				this.kFork = kFork;
			}
			if (forkRequestVariable != null)
			{
				this.AdjustFlagsAndWidth(forkRequestVariable);
				this.forkRequestVariable = forkRequestVariable;
			}
			if (acceptBranch != null)
			{
				this.AdjustFlagsAndWidth(acceptBranch);
				this.acceptBranch = acceptBranch;
			}
			if (refuseBranch != null)
			{
				this.AdjustFlagsAndWidth(refuseBranch);
				this.refuseBranch = refuseBranch;
			}
			if (cancelBranch != null)
			{
				this.AdjustFlagsAndWidth(cancelBranch);
				this.cancelBranch = cancelBranch;
			}
			if (kEndFork != null)
			{
				this.AdjustFlagsAndWidth(kEndFork);
				this.kEndFork = kEndFork;
			}
	    }
	
		private ForkRequestStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ForkRequestStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KFork { get { return this.kFork; } }
	    public ForkRequestVariableGreen ForkRequestVariable { get { return this.forkRequestVariable; } }
	    public AcceptBranchGreen AcceptBranch { get { return this.acceptBranch; } }
	    public RefuseBranchGreen RefuseBranch { get { return this.refuseBranch; } }
	    public CancelBranchGreen CancelBranch { get { return this.cancelBranch; } }
	    public InternalSyntaxToken KEndFork { get { return this.kEndFork; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ForkRequestStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kFork;
	            case 1: return this.forkRequestVariable;
	            case 2: return this.acceptBranch;
	            case 3: return this.refuseBranch;
	            case 4: return this.cancelBranch;
	            case 5: return this.kEndFork;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitForkRequestStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitForkRequestStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForkRequestStatementGreen(this.Kind, this.kFork, this.forkRequestVariable, this.acceptBranch, this.refuseBranch, this.cancelBranch, this.kEndFork, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForkRequestStatementGreen(this.Kind, this.kFork, this.forkRequestVariable, this.acceptBranch, this.refuseBranch, this.cancelBranch, this.kEndFork, this.GetDiagnostics(), annotations);
	    }
	
	    public ForkRequestStatementGreen Update(InternalSyntaxToken kFork, ForkRequestVariableGreen forkRequestVariable, AcceptBranchGreen acceptBranch, RefuseBranchGreen refuseBranch, CancelBranchGreen cancelBranch, InternalSyntaxToken kEndFork)
	    {
	        if (this.KFork != kFork ||
				this.ForkRequestVariable != forkRequestVariable ||
				this.AcceptBranch != acceptBranch ||
				this.RefuseBranch != refuseBranch ||
				this.CancelBranch != cancelBranch ||
				this.KEndFork != kEndFork)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ForkRequestStatement(kFork, forkRequestVariable, acceptBranch, refuseBranch, cancelBranch, kEndFork);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForkRequestVariableGreen : GreenSyntaxNode
	{
	    internal static readonly ForkRequestVariableGreen __Missing = new ForkRequestVariableGreen();
	    private ForkRequestIdentifierGreen forkRequestIdentifier;
	    private RequestStatementGreen requestStatement;
	
	    public ForkRequestVariableGreen(PilSyntaxKind kind, ForkRequestIdentifierGreen forkRequestIdentifier, RequestStatementGreen requestStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (forkRequestIdentifier != null)
			{
				this.AdjustFlagsAndWidth(forkRequestIdentifier);
				this.forkRequestIdentifier = forkRequestIdentifier;
			}
			if (requestStatement != null)
			{
				this.AdjustFlagsAndWidth(requestStatement);
				this.requestStatement = requestStatement;
			}
	    }
	
	    public ForkRequestVariableGreen(PilSyntaxKind kind, ForkRequestIdentifierGreen forkRequestIdentifier, RequestStatementGreen requestStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (forkRequestIdentifier != null)
			{
				this.AdjustFlagsAndWidth(forkRequestIdentifier);
				this.forkRequestIdentifier = forkRequestIdentifier;
			}
			if (requestStatement != null)
			{
				this.AdjustFlagsAndWidth(requestStatement);
				this.requestStatement = requestStatement;
			}
	    }
	
		private ForkRequestVariableGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ForkRequestVariable, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ForkRequestIdentifierGreen ForkRequestIdentifier { get { return this.forkRequestIdentifier; } }
	    public RequestStatementGreen RequestStatement { get { return this.requestStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ForkRequestVariableSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.forkRequestIdentifier;
	            case 1: return this.requestStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitForkRequestVariableGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitForkRequestVariableGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForkRequestVariableGreen(this.Kind, this.forkRequestIdentifier, this.requestStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForkRequestVariableGreen(this.Kind, this.forkRequestIdentifier, this.requestStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public ForkRequestVariableGreen Update(ForkRequestIdentifierGreen forkRequestIdentifier)
	    {
	        if (this.forkRequestIdentifier != forkRequestIdentifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ForkRequestVariable(forkRequestIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestVariableGreen)newNode;
	        }
	        return this;
	    }
	
	    public ForkRequestVariableGreen Update(RequestStatementGreen requestStatement)
	    {
	        if (this.requestStatement != requestStatement)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ForkRequestVariable(requestStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestVariableGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ForkRequestIdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly ForkRequestIdentifierGreen __Missing = new ForkRequestIdentifierGreen();
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public ForkRequestIdentifierGreen(PilSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
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
	
	    public ForkRequestIdentifierGreen(PilSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
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
	
		private ForkRequestIdentifierGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ForkRequestIdentifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ForkRequestIdentifierSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitForkRequestIdentifierGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitForkRequestIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ForkRequestIdentifierGreen(this.Kind, this.identifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ForkRequestIdentifierGreen(this.Kind, this.identifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ForkRequestIdentifierGreen Update(IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ForkRequestIdentifier(identifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestIdentifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AcceptBranchGreen : GreenSyntaxNode
	{
	    internal static readonly AcceptBranchGreen __Missing = new AcceptBranchGreen();
	    private InternalSyntaxToken kCase;
	    private InternalSyntaxToken kAccept;
	    private ExpressionGreen condition;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public AcceptBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, InternalSyntaxToken kAccept, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (kAccept != null)
			{
				this.AdjustFlagsAndWidth(kAccept);
				this.kAccept = kAccept;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public AcceptBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, InternalSyntaxToken kAccept, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (kAccept != null)
			{
				this.AdjustFlagsAndWidth(kAccept);
				this.kAccept = kAccept;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private AcceptBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.AcceptBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCase { get { return this.kCase; } }
	    public InternalSyntaxToken KAccept { get { return this.kAccept; } }
	    public ExpressionGreen Condition { get { return this.condition; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.AcceptBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCase;
	            case 1: return this.kAccept;
	            case 2: return this.condition;
	            case 3: return this.comment;
	            case 4: return this.tSemicolon;
	            case 5: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitAcceptBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitAcceptBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AcceptBranchGreen(this.Kind, this.kCase, this.kAccept, this.condition, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AcceptBranchGreen(this.Kind, this.kCase, this.kAccept, this.condition, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public AcceptBranchGreen Update(InternalSyntaxToken kCase, InternalSyntaxToken kAccept, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.KCase != kCase ||
				this.KAccept != kAccept ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.AcceptBranch(kCase, kAccept, condition, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AcceptBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RefuseBranchGreen : GreenSyntaxNode
	{
	    internal static readonly RefuseBranchGreen __Missing = new RefuseBranchGreen();
	    private InternalSyntaxToken kCase;
	    private InternalSyntaxToken kRefuse;
	    private ExpressionGreen condition;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public RefuseBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, InternalSyntaxToken kRefuse, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (kRefuse != null)
			{
				this.AdjustFlagsAndWidth(kRefuse);
				this.kRefuse = kRefuse;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public RefuseBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, InternalSyntaxToken kRefuse, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (kRefuse != null)
			{
				this.AdjustFlagsAndWidth(kRefuse);
				this.kRefuse = kRefuse;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private RefuseBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.RefuseBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCase { get { return this.kCase; } }
	    public InternalSyntaxToken KRefuse { get { return this.kRefuse; } }
	    public ExpressionGreen Condition { get { return this.condition; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.RefuseBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCase;
	            case 1: return this.kRefuse;
	            case 2: return this.condition;
	            case 3: return this.comment;
	            case 4: return this.tSemicolon;
	            case 5: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitRefuseBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitRefuseBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RefuseBranchGreen(this.Kind, this.kCase, this.kRefuse, this.condition, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RefuseBranchGreen(this.Kind, this.kCase, this.kRefuse, this.condition, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public RefuseBranchGreen Update(InternalSyntaxToken kCase, InternalSyntaxToken kRefuse, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.KCase != kCase ||
				this.KRefuse != kRefuse ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.RefuseBranch(kCase, kRefuse, condition, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefuseBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CancelBranchGreen : GreenSyntaxNode
	{
	    internal static readonly CancelBranchGreen __Missing = new CancelBranchGreen();
	    private InternalSyntaxToken kCase;
	    private InternalSyntaxToken kCancel;
	    private ExpressionGreen condition;
	    private CommentGreen comment;
	    private InternalSyntaxToken tSemicolon;
	    private StatementsGreen statements;
	
	    public CancelBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, InternalSyntaxToken kCancel, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (kCancel != null)
			{
				this.AdjustFlagsAndWidth(kCancel);
				this.kCancel = kCancel;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
	    public CancelBranchGreen(PilSyntaxKind kind, InternalSyntaxToken kCase, InternalSyntaxToken kCancel, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kCase != null)
			{
				this.AdjustFlagsAndWidth(kCase);
				this.kCase = kCase;
			}
			if (kCancel != null)
			{
				this.AdjustFlagsAndWidth(kCancel);
				this.kCancel = kCancel;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (comment != null)
			{
				this.AdjustFlagsAndWidth(comment);
				this.comment = comment;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (statements != null)
			{
				this.AdjustFlagsAndWidth(statements);
				this.statements = statements;
			}
	    }
	
		private CancelBranchGreen()
			: base((PilSyntaxKind)PilSyntaxKind.CancelBranch, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KCase { get { return this.kCase; } }
	    public InternalSyntaxToken KCancel { get { return this.kCancel; } }
	    public ExpressionGreen Condition { get { return this.condition; } }
	    public CommentGreen Comment { get { return this.comment; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public StatementsGreen Statements { get { return this.statements; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.CancelBranchSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kCase;
	            case 1: return this.kCancel;
	            case 2: return this.condition;
	            case 3: return this.comment;
	            case 4: return this.tSemicolon;
	            case 5: return this.statements;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitCancelBranchGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitCancelBranchGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CancelBranchGreen(this.Kind, this.kCase, this.kCancel, this.condition, this.comment, this.tSemicolon, this.statements, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CancelBranchGreen(this.Kind, this.kCase, this.kCancel, this.condition, this.comment, this.tSemicolon, this.statements, this.GetDiagnostics(), annotations);
	    }
	
	    public CancelBranchGreen Update(InternalSyntaxToken kCase, InternalSyntaxToken kCancel, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	        if (this.KCase != kCase ||
				this.KCancel != kCancel ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.CancelBranch(kCase, kCancel, condition, comment, tSemicolon, statements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CancelBranchGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VariableDeclarationStatementGreen : GreenSyntaxNode
	{
	    internal static readonly VariableDeclarationStatementGreen __Missing = new VariableDeclarationStatementGreen();
	    private VariableDeclarationGreen variableDeclaration;
	
	    public VariableDeclarationStatementGreen(PilSyntaxKind kind, VariableDeclarationGreen variableDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
	    public VariableDeclarationStatementGreen(PilSyntaxKind kind, VariableDeclarationGreen variableDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (variableDeclaration != null)
			{
				this.AdjustFlagsAndWidth(variableDeclaration);
				this.variableDeclaration = variableDeclaration;
			}
	    }
	
		private VariableDeclarationStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.VariableDeclarationStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableDeclarationGreen VariableDeclaration { get { return this.variableDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.VariableDeclarationStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitVariableDeclarationStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitVariableDeclarationStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableDeclarationStatementGreen(this.Kind, this.variableDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableDeclarationStatementGreen(this.Kind, this.variableDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableDeclarationStatementGreen Update(VariableDeclarationGreen variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.VariableDeclarationStatement(variableDeclaration);
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
	
	internal class VariableDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly VariableDeclarationGreen __Missing = new VariableDeclarationGreen();
	    private InternalSyntaxToken kVar;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tSemicolon;
	
	    public VariableDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kVar, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (kVar != null)
			{
				this.AdjustFlagsAndWidth(kVar);
				this.kVar = kVar;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
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
	
	    public VariableDeclarationGreen(PilSyntaxKind kind, InternalSyntaxToken kVar, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (kVar != null)
			{
				this.AdjustFlagsAndWidth(kVar);
				this.kVar = kVar;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
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
	
		private VariableDeclarationGreen()
			: base((PilSyntaxKind)PilSyntaxKind.VariableDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVar { get { return this.kVar; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.VariableDeclarationSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVar;
	            case 1: return this.name;
	            case 2: return this.tColon;
	            case 3: return this.typeReference;
	            case 4: return this.tAssign;
	            case 5: return this.expression;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitVariableDeclarationGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitVariableDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableDeclarationGreen(this.Kind, this.kVar, this.name, this.tColon, this.typeReference, this.tAssign, this.expression, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableDeclarationGreen(this.Kind, this.kVar, this.name, this.tColon, this.typeReference, this.tAssign, this.expression, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableDeclarationGreen Update(InternalSyntaxToken kVar, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KVar != kVar ||
				this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference ||
				this.TAssign != tAssign ||
				this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.VariableDeclaration(kVar, name, tColon, typeReference, tAssign, expression, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssignmentStatementGreen : GreenSyntaxNode
	{
	    internal static readonly AssignmentStatementGreen __Missing = new AssignmentStatementGreen();
	    private LeftSideGreen leftSide;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen value;
	    private InternalSyntaxToken tSemicolon;
	
	    public AssignmentStatementGreen(PilSyntaxKind kind, LeftSideGreen leftSide, InternalSyntaxToken tAssign, ExpressionGreen value, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (leftSide != null)
			{
				this.AdjustFlagsAndWidth(leftSide);
				this.leftSide = leftSide;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public AssignmentStatementGreen(PilSyntaxKind kind, LeftSideGreen leftSide, InternalSyntaxToken tAssign, ExpressionGreen value, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (leftSide != null)
			{
				this.AdjustFlagsAndWidth(leftSide);
				this.leftSide = leftSide;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private AssignmentStatementGreen()
			: base((PilSyntaxKind)PilSyntaxKind.AssignmentStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LeftSideGreen LeftSide { get { return this.leftSide; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Value { get { return this.value; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.AssignmentStatementSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leftSide;
	            case 1: return this.tAssign;
	            case 2: return this.value;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitAssignmentStatementGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitAssignmentStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssignmentStatementGreen(this.Kind, this.leftSide, this.tAssign, this.value, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssignmentStatementGreen(this.Kind, this.leftSide, this.tAssign, this.value, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public AssignmentStatementGreen Update(LeftSideGreen leftSide, InternalSyntaxToken tAssign, ExpressionGreen value, InternalSyntaxToken tSemicolon)
	    {
	        if (this.LeftSide != leftSide ||
				this.TAssign != tAssign ||
				this.Value != value ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.AssignmentStatement(leftSide, tAssign, value, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignmentStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LeftSideGreen : GreenSyntaxNode
	{
	    internal static readonly LeftSideGreen __Missing = new LeftSideGreen();
	    private IdentifierGreen identifier;
	    private ResultIdentifierGreen resultIdentifier;
	
	    public LeftSideGreen(PilSyntaxKind kind, IdentifierGreen identifier, ResultIdentifierGreen resultIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (resultIdentifier != null)
			{
				this.AdjustFlagsAndWidth(resultIdentifier);
				this.resultIdentifier = resultIdentifier;
			}
	    }
	
	    public LeftSideGreen(PilSyntaxKind kind, IdentifierGreen identifier, ResultIdentifierGreen resultIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (resultIdentifier != null)
			{
				this.AdjustFlagsAndWidth(resultIdentifier);
				this.resultIdentifier = resultIdentifier;
			}
	    }
	
		private LeftSideGreen()
			: base((PilSyntaxKind)PilSyntaxKind.LeftSide, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public ResultIdentifierGreen ResultIdentifier { get { return this.resultIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.LeftSideSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.resultIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitLeftSideGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitLeftSideGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LeftSideGreen(this.Kind, this.identifier, this.resultIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LeftSideGreen(this.Kind, this.identifier, this.resultIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public LeftSideGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.LeftSide(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LeftSideGreen)newNode;
	        }
	        return this;
	    }
	
	    public LeftSideGreen Update(ResultIdentifierGreen resultIdentifier)
	    {
	        if (this.resultIdentifier != resultIdentifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.LeftSide(resultIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LeftSideGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExpressionListGreen : GreenSyntaxNode
	{
	    internal static readonly ExpressionListGreen __Missing = new ExpressionListGreen();
	    private GreenNode expression;
	
	    public ExpressionListGreen(PilSyntaxKind kind, GreenNode expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ExpressionListGreen(PilSyntaxKind kind, GreenNode expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((PilSyntaxKind)PilSyntaxKind.ExpressionList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> Expression { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen>(this.expression); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ExpressionListSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitExpressionListGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitExpressionListGreen(this);
	
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
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ExpressionList(expression);
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
	
	internal class ExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ExpressionGreen __Missing = new ExpressionGreen();
	    private ArithmeticExpressionGreen arithmeticExpression;
	    private ConditionalExpressionGreen conditionalExpression;
	
	    public ExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen arithmeticExpression, ConditionalExpressionGreen conditionalExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (arithmeticExpression != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpression);
				this.arithmeticExpression = arithmeticExpression;
			}
			if (conditionalExpression != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpression);
				this.conditionalExpression = conditionalExpression;
			}
	    }
	
	    public ExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen arithmeticExpression, ConditionalExpressionGreen conditionalExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (arithmeticExpression != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpression);
				this.arithmeticExpression = arithmeticExpression;
			}
			if (conditionalExpression != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpression);
				this.conditionalExpression = conditionalExpression;
			}
	    }
	
		private ExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Expression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArithmeticExpressionGreen ArithmeticExpression { get { return this.arithmeticExpression; } }
	    public ConditionalExpressionGreen ConditionalExpression { get { return this.conditionalExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arithmeticExpression;
	            case 1: return this.conditionalExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExpressionGreen(this.Kind, this.arithmeticExpression, this.conditionalExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExpressionGreen(this.Kind, this.arithmeticExpression, this.conditionalExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public ExpressionGreen Update(ArithmeticExpressionGreen arithmeticExpression)
	    {
	        if (this.arithmeticExpression != arithmeticExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Expression(arithmeticExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionGreen)newNode;
	        }
	        return this;
	    }
	
	    public ExpressionGreen Update(ConditionalExpressionGreen conditionalExpression)
	    {
	        if (this.conditionalExpression != conditionalExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Expression(conditionalExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ArithmeticExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ArithmeticExpressionGreen __Missing = MulDivExpressionGreen.__Missing;
	
	    public ArithmeticExpressionGreen(PilSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class MulDivExpressionGreen : ArithmeticExpressionGreen
	{
	    internal static new readonly MulDivExpressionGreen __Missing = new MulDivExpressionGreen();
	    private ArithmeticExpressionGreen left;
	    private OpMulDivGreen opMulDiv;
	    private ArithmeticExpressionGreen right;
	
	    public MulDivExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen left, OpMulDivGreen opMulDiv, ArithmeticExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (opMulDiv != null)
			{
				this.AdjustFlagsAndWidth(opMulDiv);
				this.opMulDiv = opMulDiv;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public MulDivExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen left, OpMulDivGreen opMulDiv, ArithmeticExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (opMulDiv != null)
			{
				this.AdjustFlagsAndWidth(opMulDiv);
				this.opMulDiv = opMulDiv;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private MulDivExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.MulDivExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArithmeticExpressionGreen Left { get { return this.left; } }
	    public OpMulDivGreen OpMulDiv { get { return this.opMulDiv; } }
	    public ArithmeticExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.MulDivExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.opMulDiv;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitMulDivExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitMulDivExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MulDivExpressionGreen(this.Kind, this.left, this.opMulDiv, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MulDivExpressionGreen(this.Kind, this.left, this.opMulDiv, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public MulDivExpressionGreen Update(ArithmeticExpressionGreen left, OpMulDivGreen opMulDiv, ArithmeticExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.OpMulDiv != opMulDiv ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.MulDivExpression(left, opMulDiv, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MulDivExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PlusMinusExpressionGreen : ArithmeticExpressionGreen
	{
	    internal static new readonly PlusMinusExpressionGreen __Missing = new PlusMinusExpressionGreen();
	    private ArithmeticExpressionGreen left;
	    private OpAddSubGreen opAddSub;
	    private ArithmeticExpressionGreen right;
	
	    public PlusMinusExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen left, OpAddSubGreen opAddSub, ArithmeticExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (opAddSub != null)
			{
				this.AdjustFlagsAndWidth(opAddSub);
				this.opAddSub = opAddSub;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public PlusMinusExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen left, OpAddSubGreen opAddSub, ArithmeticExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (opAddSub != null)
			{
				this.AdjustFlagsAndWidth(opAddSub);
				this.opAddSub = opAddSub;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private PlusMinusExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.PlusMinusExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArithmeticExpressionGreen Left { get { return this.left; } }
	    public OpAddSubGreen OpAddSub { get { return this.opAddSub; } }
	    public ArithmeticExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.PlusMinusExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.opAddSub;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitPlusMinusExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitPlusMinusExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PlusMinusExpressionGreen(this.Kind, this.left, this.opAddSub, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PlusMinusExpressionGreen(this.Kind, this.left, this.opAddSub, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public PlusMinusExpressionGreen Update(ArithmeticExpressionGreen left, OpAddSubGreen opAddSub, ArithmeticExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.OpAddSub != opAddSub ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.PlusMinusExpression(left, opAddSub, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PlusMinusExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NegateExpressionGreen : ArithmeticExpressionGreen
	{
	    internal static new readonly NegateExpressionGreen __Missing = new NegateExpressionGreen();
	    private OpMinusGreen opMinus;
	    private ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator;
	
	    public NegateExpressionGreen(PilSyntaxKind kind, OpMinusGreen opMinus, ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (opMinus != null)
			{
				this.AdjustFlagsAndWidth(opMinus);
				this.opMinus = opMinus;
			}
			if (arithmeticExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpressionTerminator);
				this.arithmeticExpressionTerminator = arithmeticExpressionTerminator;
			}
	    }
	
	    public NegateExpressionGreen(PilSyntaxKind kind, OpMinusGreen opMinus, ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (opMinus != null)
			{
				this.AdjustFlagsAndWidth(opMinus);
				this.opMinus = opMinus;
			}
			if (arithmeticExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpressionTerminator);
				this.arithmeticExpressionTerminator = arithmeticExpressionTerminator;
			}
	    }
	
		private NegateExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.NegateExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OpMinusGreen OpMinus { get { return this.opMinus; } }
	    public ArithmeticExpressionTerminatorGreen ArithmeticExpressionTerminator { get { return this.arithmeticExpressionTerminator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.NegateExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.opMinus;
	            case 1: return this.arithmeticExpressionTerminator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitNegateExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitNegateExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NegateExpressionGreen(this.Kind, this.opMinus, this.arithmeticExpressionTerminator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NegateExpressionGreen(this.Kind, this.opMinus, this.arithmeticExpressionTerminator, this.GetDiagnostics(), annotations);
	    }
	
	    public NegateExpressionGreen Update(OpMinusGreen opMinus, ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator)
	    {
	        if (this.OpMinus != opMinus ||
				this.ArithmeticExpressionTerminator != arithmeticExpressionTerminator)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.NegateExpression(opMinus, arithmeticExpressionTerminator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NegateExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleArithmeticExpressionGreen : ArithmeticExpressionGreen
	{
	    internal static new readonly SimpleArithmeticExpressionGreen __Missing = new SimpleArithmeticExpressionGreen();
	    private ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator;
	
	    public SimpleArithmeticExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (arithmeticExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpressionTerminator);
				this.arithmeticExpressionTerminator = arithmeticExpressionTerminator;
			}
	    }
	
	    public SimpleArithmeticExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (arithmeticExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpressionTerminator);
				this.arithmeticExpressionTerminator = arithmeticExpressionTerminator;
			}
	    }
	
		private SimpleArithmeticExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.SimpleArithmeticExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArithmeticExpressionTerminatorGreen ArithmeticExpressionTerminator { get { return this.arithmeticExpressionTerminator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.SimpleArithmeticExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arithmeticExpressionTerminator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleArithmeticExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitSimpleArithmeticExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleArithmeticExpressionGreen(this.Kind, this.arithmeticExpressionTerminator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleArithmeticExpressionGreen(this.Kind, this.arithmeticExpressionTerminator, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleArithmeticExpressionGreen Update(ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator)
	    {
	        if (this.ArithmeticExpressionTerminator != arithmeticExpressionTerminator)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.SimpleArithmeticExpression(arithmeticExpressionTerminator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleArithmeticExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OpMulDivGreen : GreenSyntaxNode
	{
	    internal static readonly OpMulDivGreen __Missing = new OpMulDivGreen();
	    private InternalSyntaxToken opMulDiv;
	
	    public OpMulDivGreen(PilSyntaxKind kind, InternalSyntaxToken opMulDiv)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (opMulDiv != null)
			{
				this.AdjustFlagsAndWidth(opMulDiv);
				this.opMulDiv = opMulDiv;
			}
	    }
	
	    public OpMulDivGreen(PilSyntaxKind kind, InternalSyntaxToken opMulDiv, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (opMulDiv != null)
			{
				this.AdjustFlagsAndWidth(opMulDiv);
				this.opMulDiv = opMulDiv;
			}
	    }
	
		private OpMulDivGreen()
			: base((PilSyntaxKind)PilSyntaxKind.OpMulDiv, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken OpMulDiv { get { return this.opMulDiv; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.OpMulDivSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.opMulDiv;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitOpMulDivGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitOpMulDivGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OpMulDivGreen(this.Kind, this.opMulDiv, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OpMulDivGreen(this.Kind, this.opMulDiv, this.GetDiagnostics(), annotations);
	    }
	
	    public OpMulDivGreen Update(InternalSyntaxToken opMulDiv)
	    {
	        if (this.OpMulDiv != opMulDiv)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.OpMulDiv(opMulDiv);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpMulDivGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OpAddSubGreen : GreenSyntaxNode
	{
	    internal static readonly OpAddSubGreen __Missing = new OpAddSubGreen();
	    private InternalSyntaxToken opAddSub;
	
	    public OpAddSubGreen(PilSyntaxKind kind, InternalSyntaxToken opAddSub)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (opAddSub != null)
			{
				this.AdjustFlagsAndWidth(opAddSub);
				this.opAddSub = opAddSub;
			}
	    }
	
	    public OpAddSubGreen(PilSyntaxKind kind, InternalSyntaxToken opAddSub, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (opAddSub != null)
			{
				this.AdjustFlagsAndWidth(opAddSub);
				this.opAddSub = opAddSub;
			}
	    }
	
		private OpAddSubGreen()
			: base((PilSyntaxKind)PilSyntaxKind.OpAddSub, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken OpAddSub { get { return this.opAddSub; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.OpAddSubSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.opAddSub;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitOpAddSubGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitOpAddSubGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OpAddSubGreen(this.Kind, this.opAddSub, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OpAddSubGreen(this.Kind, this.opAddSub, this.GetDiagnostics(), annotations);
	    }
	
	    public OpAddSubGreen Update(InternalSyntaxToken opAddSub)
	    {
	        if (this.OpAddSub != opAddSub)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.OpAddSub(opAddSub);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpAddSubGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ArithmeticExpressionTerminatorGreen : GreenSyntaxNode
	{
	    internal static readonly ArithmeticExpressionTerminatorGreen __Missing = ParenArithmeticExpressionGreen.__Missing;
	
	    public ArithmeticExpressionTerminatorGreen(PilSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ParenArithmeticExpressionGreen : ArithmeticExpressionTerminatorGreen
	{
	    internal static new readonly ParenArithmeticExpressionGreen __Missing = new ParenArithmeticExpressionGreen();
	    private InternalSyntaxToken tOpenParen;
	    private ArithmeticExpressionGreen arithmeticExpression;
	    private InternalSyntaxToken tCloseParen;
	
	    public ParenArithmeticExpressionGreen(PilSyntaxKind kind, InternalSyntaxToken tOpenParen, ArithmeticExpressionGreen arithmeticExpression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (arithmeticExpression != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpression);
				this.arithmeticExpression = arithmeticExpression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ParenArithmeticExpressionGreen(PilSyntaxKind kind, InternalSyntaxToken tOpenParen, ArithmeticExpressionGreen arithmeticExpression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (arithmeticExpression != null)
			{
				this.AdjustFlagsAndWidth(arithmeticExpression);
				this.arithmeticExpression = arithmeticExpression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ParenArithmeticExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ParenArithmeticExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ArithmeticExpressionGreen ArithmeticExpression { get { return this.arithmeticExpression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ParenArithmeticExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.arithmeticExpression;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitParenArithmeticExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitParenArithmeticExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParenArithmeticExpressionGreen(this.Kind, this.tOpenParen, this.arithmeticExpression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParenArithmeticExpressionGreen(this.Kind, this.tOpenParen, this.arithmeticExpression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public ParenArithmeticExpressionGreen Update(InternalSyntaxToken tOpenParen, ArithmeticExpressionGreen arithmeticExpression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ArithmeticExpression != arithmeticExpression ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ParenArithmeticExpression(tOpenParen, arithmeticExpression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenArithmeticExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TerminalArithmeticExpressionGreen : ArithmeticExpressionTerminatorGreen
	{
	    internal static new readonly TerminalArithmeticExpressionGreen __Missing = new TerminalArithmeticExpressionGreen();
	    private TerminalExpressionGreen terminalExpression;
	
	    public TerminalArithmeticExpressionGreen(PilSyntaxKind kind, TerminalExpressionGreen terminalExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (terminalExpression != null)
			{
				this.AdjustFlagsAndWidth(terminalExpression);
				this.terminalExpression = terminalExpression;
			}
	    }
	
	    public TerminalArithmeticExpressionGreen(PilSyntaxKind kind, TerminalExpressionGreen terminalExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (terminalExpression != null)
			{
				this.AdjustFlagsAndWidth(terminalExpression);
				this.terminalExpression = terminalExpression;
			}
	    }
	
		private TerminalArithmeticExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TerminalArithmeticExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TerminalExpressionGreen TerminalExpression { get { return this.terminalExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TerminalArithmeticExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.terminalExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTerminalArithmeticExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTerminalArithmeticExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TerminalArithmeticExpressionGreen(this.Kind, this.terminalExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TerminalArithmeticExpressionGreen(this.Kind, this.terminalExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public TerminalArithmeticExpressionGreen Update(TerminalExpressionGreen terminalExpression)
	    {
	        if (this.TerminalExpression != terminalExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TerminalArithmeticExpression(terminalExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalArithmeticExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OpMinusGreen : GreenSyntaxNode
	{
	    internal static readonly OpMinusGreen __Missing = new OpMinusGreen();
	    private InternalSyntaxToken tMinus;
	
	    public OpMinusGreen(PilSyntaxKind kind, InternalSyntaxToken tMinus)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tMinus != null)
			{
				this.AdjustFlagsAndWidth(tMinus);
				this.tMinus = tMinus;
			}
	    }
	
	    public OpMinusGreen(PilSyntaxKind kind, InternalSyntaxToken tMinus, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tMinus != null)
			{
				this.AdjustFlagsAndWidth(tMinus);
				this.tMinus = tMinus;
			}
	    }
	
		private OpMinusGreen()
			: base((PilSyntaxKind)PilSyntaxKind.OpMinus, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TMinus { get { return this.tMinus; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.OpMinusSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tMinus;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitOpMinusGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitOpMinusGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OpMinusGreen(this.Kind, this.tMinus, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OpMinusGreen(this.Kind, this.tMinus, this.GetDiagnostics(), annotations);
	    }
	
	    public OpMinusGreen Update(InternalSyntaxToken tMinus)
	    {
	        if (this.TMinus != tMinus)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.OpMinus(tMinus);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpMinusGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ConditionalExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ConditionalExpressionGreen __Missing = AndExpressionGreen.__Missing;
	
	    public ConditionalExpressionGreen(PilSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class AndExpressionGreen : ConditionalExpressionGreen
	{
	    internal static new readonly AndExpressionGreen __Missing = new AndExpressionGreen();
	    private ConditionalExpressionGreen left;
	    private AndAlsoOpGreen andAlsoOp;
	    private ConditionalExpressionGreen right;
	
	    public AndExpressionGreen(PilSyntaxKind kind, ConditionalExpressionGreen left, AndAlsoOpGreen andAlsoOp, ConditionalExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (andAlsoOp != null)
			{
				this.AdjustFlagsAndWidth(andAlsoOp);
				this.andAlsoOp = andAlsoOp;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AndExpressionGreen(PilSyntaxKind kind, ConditionalExpressionGreen left, AndAlsoOpGreen andAlsoOp, ConditionalExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (andAlsoOp != null)
			{
				this.AdjustFlagsAndWidth(andAlsoOp);
				this.andAlsoOp = andAlsoOp;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private AndExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.AndExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ConditionalExpressionGreen Left { get { return this.left; } }
	    public AndAlsoOpGreen AndAlsoOp { get { return this.andAlsoOp; } }
	    public ConditionalExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.AndExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.andAlsoOp;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitAndExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitAndExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AndExpressionGreen(this.Kind, this.left, this.andAlsoOp, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AndExpressionGreen(this.Kind, this.left, this.andAlsoOp, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public AndExpressionGreen Update(ConditionalExpressionGreen left, AndAlsoOpGreen andAlsoOp, ConditionalExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.AndAlsoOp != andAlsoOp ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.AndExpression(left, andAlsoOp, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OrExpressionGreen : ConditionalExpressionGreen
	{
	    internal static new readonly OrExpressionGreen __Missing = new OrExpressionGreen();
	    private ConditionalExpressionGreen left;
	    private OrElseOpGreen orElseOp;
	    private ConditionalExpressionGreen right;
	
	    public OrExpressionGreen(PilSyntaxKind kind, ConditionalExpressionGreen left, OrElseOpGreen orElseOp, ConditionalExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (orElseOp != null)
			{
				this.AdjustFlagsAndWidth(orElseOp);
				this.orElseOp = orElseOp;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public OrExpressionGreen(PilSyntaxKind kind, ConditionalExpressionGreen left, OrElseOpGreen orElseOp, ConditionalExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (orElseOp != null)
			{
				this.AdjustFlagsAndWidth(orElseOp);
				this.orElseOp = orElseOp;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private OrExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.OrExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ConditionalExpressionGreen Left { get { return this.left; } }
	    public OrElseOpGreen OrElseOp { get { return this.orElseOp; } }
	    public ConditionalExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.OrExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.orElseOp;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitOrExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitOrExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OrExpressionGreen(this.Kind, this.left, this.orElseOp, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OrExpressionGreen(this.Kind, this.left, this.orElseOp, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public OrExpressionGreen Update(ConditionalExpressionGreen left, OrElseOpGreen orElseOp, ConditionalExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.OrElseOp != orElseOp ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.OrExpression(left, orElseOp, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NotExpressionGreen : ConditionalExpressionGreen
	{
	    internal static new readonly NotExpressionGreen __Missing = new NotExpressionGreen();
	    private OpExclGreen opExcl;
	    private ConditionalExpressionTerminatorGreen conditionalExpressionTerminator;
	
	    public NotExpressionGreen(PilSyntaxKind kind, OpExclGreen opExcl, ConditionalExpressionTerminatorGreen conditionalExpressionTerminator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (opExcl != null)
			{
				this.AdjustFlagsAndWidth(opExcl);
				this.opExcl = opExcl;
			}
			if (conditionalExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpressionTerminator);
				this.conditionalExpressionTerminator = conditionalExpressionTerminator;
			}
	    }
	
	    public NotExpressionGreen(PilSyntaxKind kind, OpExclGreen opExcl, ConditionalExpressionTerminatorGreen conditionalExpressionTerminator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (opExcl != null)
			{
				this.AdjustFlagsAndWidth(opExcl);
				this.opExcl = opExcl;
			}
			if (conditionalExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpressionTerminator);
				this.conditionalExpressionTerminator = conditionalExpressionTerminator;
			}
	    }
	
		private NotExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.NotExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OpExclGreen OpExcl { get { return this.opExcl; } }
	    public ConditionalExpressionTerminatorGreen ConditionalExpressionTerminator { get { return this.conditionalExpressionTerminator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.NotExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.opExcl;
	            case 1: return this.conditionalExpressionTerminator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitNotExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitNotExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NotExpressionGreen(this.Kind, this.opExcl, this.conditionalExpressionTerminator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NotExpressionGreen(this.Kind, this.opExcl, this.conditionalExpressionTerminator, this.GetDiagnostics(), annotations);
	    }
	
	    public NotExpressionGreen Update(OpExclGreen opExcl, ConditionalExpressionTerminatorGreen conditionalExpressionTerminator)
	    {
	        if (this.OpExcl != opExcl ||
				this.ConditionalExpressionTerminator != conditionalExpressionTerminator)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.NotExpression(opExcl, conditionalExpressionTerminator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NotExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleConditionalExpressionGreen : ConditionalExpressionGreen
	{
	    internal static new readonly SimpleConditionalExpressionGreen __Missing = new SimpleConditionalExpressionGreen();
	    private ConditionalExpressionTerminatorGreen conditionalExpressionTerminator;
	
	    public SimpleConditionalExpressionGreen(PilSyntaxKind kind, ConditionalExpressionTerminatorGreen conditionalExpressionTerminator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (conditionalExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpressionTerminator);
				this.conditionalExpressionTerminator = conditionalExpressionTerminator;
			}
	    }
	
	    public SimpleConditionalExpressionGreen(PilSyntaxKind kind, ConditionalExpressionTerminatorGreen conditionalExpressionTerminator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (conditionalExpressionTerminator != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpressionTerminator);
				this.conditionalExpressionTerminator = conditionalExpressionTerminator;
			}
	    }
	
		private SimpleConditionalExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.SimpleConditionalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ConditionalExpressionTerminatorGreen ConditionalExpressionTerminator { get { return this.conditionalExpressionTerminator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.SimpleConditionalExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.conditionalExpressionTerminator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleConditionalExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitSimpleConditionalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleConditionalExpressionGreen(this.Kind, this.conditionalExpressionTerminator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleConditionalExpressionGreen(this.Kind, this.conditionalExpressionTerminator, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleConditionalExpressionGreen Update(ConditionalExpressionTerminatorGreen conditionalExpressionTerminator)
	    {
	        if (this.ConditionalExpressionTerminator != conditionalExpressionTerminator)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.SimpleConditionalExpression(conditionalExpressionTerminator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleConditionalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AndAlsoOpGreen : GreenSyntaxNode
	{
	    internal static readonly AndAlsoOpGreen __Missing = new AndAlsoOpGreen();
	    private InternalSyntaxToken tAndAlso;
	
	    public AndAlsoOpGreen(PilSyntaxKind kind, InternalSyntaxToken tAndAlso)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tAndAlso != null)
			{
				this.AdjustFlagsAndWidth(tAndAlso);
				this.tAndAlso = tAndAlso;
			}
	    }
	
	    public AndAlsoOpGreen(PilSyntaxKind kind, InternalSyntaxToken tAndAlso, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tAndAlso != null)
			{
				this.AdjustFlagsAndWidth(tAndAlso);
				this.tAndAlso = tAndAlso;
			}
	    }
	
		private AndAlsoOpGreen()
			: base((PilSyntaxKind)PilSyntaxKind.AndAlsoOp, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TAndAlso { get { return this.tAndAlso; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.AndAlsoOpSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tAndAlso;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitAndAlsoOpGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitAndAlsoOpGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AndAlsoOpGreen(this.Kind, this.tAndAlso, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AndAlsoOpGreen(this.Kind, this.tAndAlso, this.GetDiagnostics(), annotations);
	    }
	
	    public AndAlsoOpGreen Update(InternalSyntaxToken tAndAlso)
	    {
	        if (this.TAndAlso != tAndAlso)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.AndAlsoOp(tAndAlso);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndAlsoOpGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OrElseOpGreen : GreenSyntaxNode
	{
	    internal static readonly OrElseOpGreen __Missing = new OrElseOpGreen();
	    private InternalSyntaxToken tOrElse;
	
	    public OrElseOpGreen(PilSyntaxKind kind, InternalSyntaxToken tOrElse)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tOrElse != null)
			{
				this.AdjustFlagsAndWidth(tOrElse);
				this.tOrElse = tOrElse;
			}
	    }
	
	    public OrElseOpGreen(PilSyntaxKind kind, InternalSyntaxToken tOrElse, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tOrElse != null)
			{
				this.AdjustFlagsAndWidth(tOrElse);
				this.tOrElse = tOrElse;
			}
	    }
	
		private OrElseOpGreen()
			: base((PilSyntaxKind)PilSyntaxKind.OrElseOp, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOrElse { get { return this.tOrElse; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.OrElseOpSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOrElse;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitOrElseOpGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitOrElseOpGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OrElseOpGreen(this.Kind, this.tOrElse, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OrElseOpGreen(this.Kind, this.tOrElse, this.GetDiagnostics(), annotations);
	    }
	
	    public OrElseOpGreen Update(InternalSyntaxToken tOrElse)
	    {
	        if (this.TOrElse != tOrElse)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.OrElseOp(tOrElse);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrElseOpGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OpExclGreen : GreenSyntaxNode
	{
	    internal static readonly OpExclGreen __Missing = new OpExclGreen();
	    private InternalSyntaxToken tExclamation;
	
	    public OpExclGreen(PilSyntaxKind kind, InternalSyntaxToken tExclamation)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
	    public OpExclGreen(PilSyntaxKind kind, InternalSyntaxToken tExclamation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
		private OpExclGreen()
			: base((PilSyntaxKind)PilSyntaxKind.OpExcl, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.OpExclSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tExclamation;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitOpExclGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitOpExclGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OpExclGreen(this.Kind, this.tExclamation, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OpExclGreen(this.Kind, this.tExclamation, this.GetDiagnostics(), annotations);
	    }
	
	    public OpExclGreen Update(InternalSyntaxToken tExclamation)
	    {
	        if (this.TExclamation != tExclamation)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.OpExcl(tExclamation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpExclGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ConditionalExpressionTerminatorGreen : GreenSyntaxNode
	{
	    internal static readonly ConditionalExpressionTerminatorGreen __Missing = ParenConditionalExpressionGreen.__Missing;
	
	    public ConditionalExpressionTerminatorGreen(PilSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ParenConditionalExpressionGreen : ConditionalExpressionTerminatorGreen
	{
	    internal static new readonly ParenConditionalExpressionGreen __Missing = new ParenConditionalExpressionGreen();
	    private InternalSyntaxToken tOpenParen;
	    private ConditionalExpressionGreen conditionalExpression;
	    private InternalSyntaxToken tCloseParen;
	
	    public ParenConditionalExpressionGreen(PilSyntaxKind kind, InternalSyntaxToken tOpenParen, ConditionalExpressionGreen conditionalExpression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (conditionalExpression != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpression);
				this.conditionalExpression = conditionalExpression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ParenConditionalExpressionGreen(PilSyntaxKind kind, InternalSyntaxToken tOpenParen, ConditionalExpressionGreen conditionalExpression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (conditionalExpression != null)
			{
				this.AdjustFlagsAndWidth(conditionalExpression);
				this.conditionalExpression = conditionalExpression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ParenConditionalExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ParenConditionalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ConditionalExpressionGreen ConditionalExpression { get { return this.conditionalExpression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ParenConditionalExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.conditionalExpression;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitParenConditionalExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitParenConditionalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParenConditionalExpressionGreen(this.Kind, this.tOpenParen, this.conditionalExpression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParenConditionalExpressionGreen(this.Kind, this.tOpenParen, this.conditionalExpression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public ParenConditionalExpressionGreen Update(InternalSyntaxToken tOpenParen, ConditionalExpressionGreen conditionalExpression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ConditionalExpression != conditionalExpression ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ParenConditionalExpression(tOpenParen, conditionalExpression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenConditionalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementOfConditionalExpressionGreen : ConditionalExpressionTerminatorGreen
	{
	    internal static new readonly ElementOfConditionalExpressionGreen __Missing = new ElementOfConditionalExpressionGreen();
	    private ElementOfExpressionGreen elementOfExpression;
	
	    public ElementOfConditionalExpressionGreen(PilSyntaxKind kind, ElementOfExpressionGreen elementOfExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (elementOfExpression != null)
			{
				this.AdjustFlagsAndWidth(elementOfExpression);
				this.elementOfExpression = elementOfExpression;
			}
	    }
	
	    public ElementOfConditionalExpressionGreen(PilSyntaxKind kind, ElementOfExpressionGreen elementOfExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (elementOfExpression != null)
			{
				this.AdjustFlagsAndWidth(elementOfExpression);
				this.elementOfExpression = elementOfExpression;
			}
	    }
	
		private ElementOfConditionalExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ElementOfConditionalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ElementOfExpressionGreen ElementOfExpression { get { return this.elementOfExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ElementOfConditionalExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.elementOfExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitElementOfConditionalExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitElementOfConditionalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementOfConditionalExpressionGreen(this.Kind, this.elementOfExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementOfConditionalExpressionGreen(this.Kind, this.elementOfExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementOfConditionalExpressionGreen Update(ElementOfExpressionGreen elementOfExpression)
	    {
	        if (this.ElementOfExpression != elementOfExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ElementOfConditionalExpression(elementOfExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfConditionalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComparisonConditionalExpressionGreen : ConditionalExpressionTerminatorGreen
	{
	    internal static new readonly ComparisonConditionalExpressionGreen __Missing = new ComparisonConditionalExpressionGreen();
	    private ComparisonExpressionGreen comparisonExpression;
	
	    public ComparisonConditionalExpressionGreen(PilSyntaxKind kind, ComparisonExpressionGreen comparisonExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (comparisonExpression != null)
			{
				this.AdjustFlagsAndWidth(comparisonExpression);
				this.comparisonExpression = comparisonExpression;
			}
	    }
	
	    public ComparisonConditionalExpressionGreen(PilSyntaxKind kind, ComparisonExpressionGreen comparisonExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (comparisonExpression != null)
			{
				this.AdjustFlagsAndWidth(comparisonExpression);
				this.comparisonExpression = comparisonExpression;
			}
	    }
	
		private ComparisonConditionalExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ComparisonConditionalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ComparisonExpressionGreen ComparisonExpression { get { return this.comparisonExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ComparisonConditionalExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.comparisonExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitComparisonConditionalExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitComparisonConditionalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComparisonConditionalExpressionGreen(this.Kind, this.comparisonExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComparisonConditionalExpressionGreen(this.Kind, this.comparisonExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public ComparisonConditionalExpressionGreen Update(ComparisonExpressionGreen comparisonExpression)
	    {
	        if (this.ComparisonExpression != comparisonExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ComparisonConditionalExpression(comparisonExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComparisonConditionalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TerminalComparisonExpressionGreen : ConditionalExpressionTerminatorGreen
	{
	    internal static new readonly TerminalComparisonExpressionGreen __Missing = new TerminalComparisonExpressionGreen();
	    private TerminalExpressionGreen terminalExpression;
	
	    public TerminalComparisonExpressionGreen(PilSyntaxKind kind, TerminalExpressionGreen terminalExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (terminalExpression != null)
			{
				this.AdjustFlagsAndWidth(terminalExpression);
				this.terminalExpression = terminalExpression;
			}
	    }
	
	    public TerminalComparisonExpressionGreen(PilSyntaxKind kind, TerminalExpressionGreen terminalExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (terminalExpression != null)
			{
				this.AdjustFlagsAndWidth(terminalExpression);
				this.terminalExpression = terminalExpression;
			}
	    }
	
		private TerminalComparisonExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TerminalComparisonExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TerminalExpressionGreen TerminalExpression { get { return this.terminalExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TerminalComparisonExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.terminalExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTerminalComparisonExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTerminalComparisonExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TerminalComparisonExpressionGreen(this.Kind, this.terminalExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TerminalComparisonExpressionGreen(this.Kind, this.terminalExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public TerminalComparisonExpressionGreen Update(TerminalExpressionGreen terminalExpression)
	    {
	        if (this.TerminalExpression != terminalExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TerminalComparisonExpression(terminalExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalComparisonExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComparisonExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ComparisonExpressionGreen __Missing = new ComparisonExpressionGreen();
	    private ArithmeticExpressionGreen left;
	    private ComparisonOperatorGreen op;
	    private ArithmeticExpressionGreen right;
	
	    public ComparisonExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen left, ComparisonOperatorGreen op, ArithmeticExpressionGreen right)
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
	
	    public ComparisonExpressionGreen(PilSyntaxKind kind, ArithmeticExpressionGreen left, ComparisonOperatorGreen op, ArithmeticExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
		private ComparisonExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ComparisonExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArithmeticExpressionGreen Left { get { return this.left; } }
	    public ComparisonOperatorGreen Op { get { return this.op; } }
	    public ArithmeticExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ComparisonExpressionSyntax(this, (PilSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitComparisonExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitComparisonExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComparisonExpressionGreen(this.Kind, this.left, this.op, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComparisonExpressionGreen(this.Kind, this.left, this.op, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public ComparisonExpressionGreen Update(ArithmeticExpressionGreen left, ComparisonOperatorGreen op, ArithmeticExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ComparisonExpression(left, op, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComparisonExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComparisonOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly ComparisonOperatorGreen __Missing = new ComparisonOperatorGreen();
	    private InternalSyntaxToken comparisonOperator;
	
	    public ComparisonOperatorGreen(PilSyntaxKind kind, InternalSyntaxToken comparisonOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (comparisonOperator != null)
			{
				this.AdjustFlagsAndWidth(comparisonOperator);
				this.comparisonOperator = comparisonOperator;
			}
	    }
	
	    public ComparisonOperatorGreen(PilSyntaxKind kind, InternalSyntaxToken comparisonOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (comparisonOperator != null)
			{
				this.AdjustFlagsAndWidth(comparisonOperator);
				this.comparisonOperator = comparisonOperator;
			}
	    }
	
		private ComparisonOperatorGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ComparisonOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ComparisonOperator { get { return this.comparisonOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ComparisonOperatorSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.comparisonOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitComparisonOperatorGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitComparisonOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComparisonOperatorGreen(this.Kind, this.comparisonOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComparisonOperatorGreen(this.Kind, this.comparisonOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public ComparisonOperatorGreen Update(InternalSyntaxToken comparisonOperator)
	    {
	        if (this.ComparisonOperator != comparisonOperator)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ComparisonOperator(comparisonOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComparisonOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementOfExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ElementOfExpressionGreen __Missing = new ElementOfExpressionGreen();
	    private TerminalExpressionGreen terminalExpression;
	    private InternalSyntaxToken kIn;
	    private InternalSyntaxToken tOpenBracket;
	    private ElementOfValueListGreen elementOfValueList;
	    private InternalSyntaxToken tCloseBracket;
	
	    public ElementOfExpressionGreen(PilSyntaxKind kind, TerminalExpressionGreen terminalExpression, InternalSyntaxToken kIn, InternalSyntaxToken tOpenBracket, ElementOfValueListGreen elementOfValueList, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (terminalExpression != null)
			{
				this.AdjustFlagsAndWidth(terminalExpression);
				this.terminalExpression = terminalExpression;
			}
			if (kIn != null)
			{
				this.AdjustFlagsAndWidth(kIn);
				this.kIn = kIn;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (elementOfValueList != null)
			{
				this.AdjustFlagsAndWidth(elementOfValueList);
				this.elementOfValueList = elementOfValueList;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public ElementOfExpressionGreen(PilSyntaxKind kind, TerminalExpressionGreen terminalExpression, InternalSyntaxToken kIn, InternalSyntaxToken tOpenBracket, ElementOfValueListGreen elementOfValueList, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (terminalExpression != null)
			{
				this.AdjustFlagsAndWidth(terminalExpression);
				this.terminalExpression = terminalExpression;
			}
			if (kIn != null)
			{
				this.AdjustFlagsAndWidth(kIn);
				this.kIn = kIn;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (elementOfValueList != null)
			{
				this.AdjustFlagsAndWidth(elementOfValueList);
				this.elementOfValueList = elementOfValueList;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private ElementOfExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ElementOfExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TerminalExpressionGreen TerminalExpression { get { return this.terminalExpression; } }
	    public InternalSyntaxToken KIn { get { return this.kIn; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public ElementOfValueListGreen ElementOfValueList { get { return this.elementOfValueList; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ElementOfExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.terminalExpression;
	            case 1: return this.kIn;
	            case 2: return this.tOpenBracket;
	            case 3: return this.elementOfValueList;
	            case 4: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitElementOfExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitElementOfExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementOfExpressionGreen(this.Kind, this.terminalExpression, this.kIn, this.tOpenBracket, this.elementOfValueList, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementOfExpressionGreen(this.Kind, this.terminalExpression, this.kIn, this.tOpenBracket, this.elementOfValueList, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementOfExpressionGreen Update(TerminalExpressionGreen terminalExpression, InternalSyntaxToken kIn, InternalSyntaxToken tOpenBracket, ElementOfValueListGreen elementOfValueList, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TerminalExpression != terminalExpression ||
				this.KIn != kIn ||
				this.TOpenBracket != tOpenBracket ||
				this.ElementOfValueList != elementOfValueList ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ElementOfExpression(terminalExpression, kIn, tOpenBracket, elementOfValueList, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementOfValueListGreen : GreenSyntaxNode
	{
	    internal static readonly ElementOfValueListGreen __Missing = new ElementOfValueListGreen();
	    private GreenNode elementOfValue;
	
	    public ElementOfValueListGreen(PilSyntaxKind kind, GreenNode elementOfValue)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (elementOfValue != null)
			{
				this.AdjustFlagsAndWidth(elementOfValue);
				this.elementOfValue = elementOfValue;
			}
	    }
	
	    public ElementOfValueListGreen(PilSyntaxKind kind, GreenNode elementOfValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (elementOfValue != null)
			{
				this.AdjustFlagsAndWidth(elementOfValue);
				this.elementOfValue = elementOfValue;
			}
	    }
	
		private ElementOfValueListGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ElementOfValueList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ElementOfValueGreen> ElementOfValue { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ElementOfValueGreen>(this.elementOfValue); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ElementOfValueListSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.elementOfValue;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitElementOfValueListGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitElementOfValueListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementOfValueListGreen(this.Kind, this.elementOfValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementOfValueListGreen(this.Kind, this.elementOfValue, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementOfValueListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ElementOfValueGreen> elementOfValue)
	    {
	        if (this.ElementOfValue != elementOfValue)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ElementOfValueList(elementOfValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfValueListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementOfValueGreen : GreenSyntaxNode
	{
	    internal static readonly ElementOfValueGreen __Missing = new ElementOfValueGreen();
	    private IdentifierGreen identifier;
	
	    public ElementOfValueGreen(PilSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public ElementOfValueGreen(PilSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private ElementOfValueGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ElementOfValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ElementOfValueSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitElementOfValueGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitElementOfValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementOfValueGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementOfValueGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementOfValueGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ElementOfValue(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TerminalExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly TerminalExpressionGreen __Missing = new TerminalExpressionGreen();
	    private VariableReferenceGreen variableReference;
	    private FunctionCallExpressionGreen functionCallExpression;
	    private LiteralGreen literal;
	
	    public TerminalExpressionGreen(PilSyntaxKind kind, VariableReferenceGreen variableReference, FunctionCallExpressionGreen functionCallExpression, LiteralGreen literal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (variableReference != null)
			{
				this.AdjustFlagsAndWidth(variableReference);
				this.variableReference = variableReference;
			}
			if (functionCallExpression != null)
			{
				this.AdjustFlagsAndWidth(functionCallExpression);
				this.functionCallExpression = functionCallExpression;
			}
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
	    public TerminalExpressionGreen(PilSyntaxKind kind, VariableReferenceGreen variableReference, FunctionCallExpressionGreen functionCallExpression, LiteralGreen literal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (variableReference != null)
			{
				this.AdjustFlagsAndWidth(variableReference);
				this.variableReference = variableReference;
			}
			if (functionCallExpression != null)
			{
				this.AdjustFlagsAndWidth(functionCallExpression);
				this.functionCallExpression = functionCallExpression;
			}
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
		private TerminalExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TerminalExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VariableReferenceGreen VariableReference { get { return this.variableReference; } }
	    public FunctionCallExpressionGreen FunctionCallExpression { get { return this.functionCallExpression; } }
	    public LiteralGreen Literal { get { return this.literal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TerminalExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableReference;
	            case 1: return this.functionCallExpression;
	            case 2: return this.literal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTerminalExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTerminalExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TerminalExpressionGreen(this.Kind, this.variableReference, this.functionCallExpression, this.literal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TerminalExpressionGreen(this.Kind, this.variableReference, this.functionCallExpression, this.literal, this.GetDiagnostics(), annotations);
	    }
	
	    public TerminalExpressionGreen Update(VariableReferenceGreen variableReference)
	    {
	        if (this.variableReference != variableReference)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TerminalExpression(variableReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalExpressionGreen)newNode;
	        }
	        return this;
	    }
	
	    public TerminalExpressionGreen Update(FunctionCallExpressionGreen functionCallExpression)
	    {
	        if (this.functionCallExpression != functionCallExpression)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TerminalExpression(functionCallExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalExpressionGreen)newNode;
	        }
	        return this;
	    }
	
	    public TerminalExpressionGreen Update(LiteralGreen literal)
	    {
	        if (this.literal != literal)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TerminalExpression(literal);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FunctionCallExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly FunctionCallExpressionGreen __Missing = new FunctionCallExpressionGreen();
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionListGreen expressionList;
	    private InternalSyntaxToken tCloseParen;
	
	    public FunctionCallExpressionGreen(PilSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public FunctionCallExpressionGreen(PilSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expressionList != null)
			{
				this.AdjustFlagsAndWidth(expressionList);
				this.expressionList = expressionList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private FunctionCallExpressionGreen()
			: base((PilSyntaxKind)PilSyntaxKind.FunctionCallExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionListGreen ExpressionList { get { return this.expressionList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.FunctionCallExpressionSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.tOpenParen;
	            case 2: return this.expressionList;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitFunctionCallExpressionGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitFunctionCallExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FunctionCallExpressionGreen(this.Kind, this.identifier, this.tOpenParen, this.expressionList, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FunctionCallExpressionGreen(this.Kind, this.identifier, this.tOpenParen, this.expressionList, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public FunctionCallExpressionGreen Update(IdentifierGreen identifier, InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen)
	    {
	        if (this.Identifier != identifier ||
				this.TOpenParen != tOpenParen ||
				this.ExpressionList != expressionList ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.FunctionCallExpression(identifier, tOpenParen, expressionList, tCloseParen);
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
	
	internal class VariableReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly VariableReferenceGreen __Missing = new VariableReferenceGreen();
	    private GreenNode variableReferenceIdentifier;
	
	    public VariableReferenceGreen(PilSyntaxKind kind, GreenNode variableReferenceIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (variableReferenceIdentifier != null)
			{
				this.AdjustFlagsAndWidth(variableReferenceIdentifier);
				this.variableReferenceIdentifier = variableReferenceIdentifier;
			}
	    }
	
	    public VariableReferenceGreen(PilSyntaxKind kind, GreenNode variableReferenceIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (variableReferenceIdentifier != null)
			{
				this.AdjustFlagsAndWidth(variableReferenceIdentifier);
				this.variableReferenceIdentifier = variableReferenceIdentifier;
			}
	    }
	
		private VariableReferenceGreen()
			: base((PilSyntaxKind)PilSyntaxKind.VariableReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableReferenceIdentifierGreen> VariableReferenceIdentifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableReferenceIdentifierGreen>(this.variableReferenceIdentifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.VariableReferenceSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.variableReferenceIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitVariableReferenceGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitVariableReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableReferenceGreen(this.Kind, this.variableReferenceIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableReferenceGreen(this.Kind, this.variableReferenceIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableReferenceGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableReferenceIdentifierGreen> variableReferenceIdentifier)
	    {
	        if (this.VariableReferenceIdentifier != variableReferenceIdentifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.VariableReference(variableReferenceIdentifier);
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
	
	internal class VariableReferenceIdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly VariableReferenceIdentifierGreen __Missing = new VariableReferenceIdentifierGreen();
	    private IdentifierGreen identifier;
	
	    public VariableReferenceIdentifierGreen(PilSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public VariableReferenceIdentifierGreen(PilSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private VariableReferenceIdentifierGreen()
			: base((PilSyntaxKind)PilSyntaxKind.VariableReferenceIdentifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.VariableReferenceIdentifierSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitVariableReferenceIdentifierGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitVariableReferenceIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VariableReferenceIdentifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VariableReferenceIdentifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public VariableReferenceIdentifierGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.VariableReferenceIdentifier(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableReferenceIdentifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CommentGreen : GreenSyntaxNode
	{
	    internal static readonly CommentGreen __Missing = new CommentGreen();
	    private InternalSyntaxToken lString;
	
	    public CommentGreen(PilSyntaxKind kind, InternalSyntaxToken lString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lString != null)
			{
				this.AdjustFlagsAndWidth(lString);
				this.lString = lString;
			}
	    }
	
	    public CommentGreen(PilSyntaxKind kind, InternalSyntaxToken lString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lString != null)
			{
				this.AdjustFlagsAndWidth(lString);
				this.lString = lString;
			}
	    }
	
		private CommentGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Comment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LString { get { return this.lString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.CommentSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitCommentGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitCommentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CommentGreen(this.Kind, this.lString, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CommentGreen(this.Kind, this.lString, this.GetDiagnostics(), annotations);
	    }
	
	    public CommentGreen Update(InternalSyntaxToken lString)
	    {
	        if (this.LString != lString)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Comment(lString);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LiteralGreen : GreenSyntaxNode
	{
	    internal static readonly LiteralGreen __Missing = new LiteralGreen();
	    private InternalSyntaxToken literal;
	
	    public LiteralGreen(PilSyntaxKind kind, InternalSyntaxToken literal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
	    public LiteralGreen(PilSyntaxKind kind, InternalSyntaxToken literal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
		private LiteralGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Literal, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Literal { get { return this.literal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.LiteralSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.literal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralGreen(this.Kind, this.literal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralGreen(this.Kind, this.literal, this.GetDiagnostics(), annotations);
	    }
	
	    public LiteralGreen Update(InternalSyntaxToken literal)
	    {
	        if (this.Literal != literal)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Literal(literal);
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
	
	internal class TypeReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly TypeReferenceGreen __Missing = new TypeReferenceGreen();
	    private BuiltInTypeGreen builtInType;
	    private IdentifierGreen identifier;
	
	    public TypeReferenceGreen(PilSyntaxKind kind, BuiltInTypeGreen builtInType, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (builtInType != null)
			{
				this.AdjustFlagsAndWidth(builtInType);
				this.builtInType = builtInType;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public TypeReferenceGreen(PilSyntaxKind kind, BuiltInTypeGreen builtInType, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (builtInType != null)
			{
				this.AdjustFlagsAndWidth(builtInType);
				this.builtInType = builtInType;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private TypeReferenceGreen()
			: base((PilSyntaxKind)PilSyntaxKind.TypeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public BuiltInTypeGreen BuiltInType { get { return this.builtInType; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.TypeReferenceSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.builtInType;
	            case 1: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.builtInType, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.builtInType, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(BuiltInTypeGreen builtInType)
	    {
	        if (this.builtInType != builtInType)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TypeReference(builtInType);
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
	
	    public TypeReferenceGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.TypeReference(identifier);
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
	
	internal class BuiltInTypeGreen : GreenSyntaxNode
	{
	    internal static readonly BuiltInTypeGreen __Missing = new BuiltInTypeGreen();
	    private InternalSyntaxToken builtInType;
	
	    public BuiltInTypeGreen(PilSyntaxKind kind, InternalSyntaxToken builtInType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (builtInType != null)
			{
				this.AdjustFlagsAndWidth(builtInType);
				this.builtInType = builtInType;
			}
	    }
	
	    public BuiltInTypeGreen(PilSyntaxKind kind, InternalSyntaxToken builtInType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (builtInType != null)
			{
				this.AdjustFlagsAndWidth(builtInType);
				this.builtInType = builtInType;
			}
	    }
	
		private BuiltInTypeGreen()
			: base((PilSyntaxKind)PilSyntaxKind.BuiltInType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BuiltInType { get { return this.builtInType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.BuiltInTypeSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.builtInType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitBuiltInTypeGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitBuiltInTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BuiltInTypeGreen(this.Kind, this.builtInType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BuiltInTypeGreen(this.Kind, this.builtInType, this.GetDiagnostics(), annotations);
	    }
	
	    public BuiltInTypeGreen Update(InternalSyntaxToken builtInType)
	    {
	        if (this.BuiltInType != builtInType)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.BuiltInType(builtInType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BuiltInTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifierListGreen : GreenSyntaxNode
	{
	    internal static readonly QualifierListGreen __Missing = new QualifierListGreen();
	    private GreenNode qualifier;
	
	    public QualifierListGreen(PilSyntaxKind kind, GreenNode qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifierListGreen(PilSyntaxKind kind, GreenNode qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private QualifierListGreen()
			: base((PilSyntaxKind)PilSyntaxKind.QualifierList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> Qualifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen>(this.qualifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QualifierListSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierListGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQualifierListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifierListGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierListGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifierListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.QualifierList(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifierGreen : GreenSyntaxNode
	{
	    internal static readonly QualifierGreen __Missing = new QualifierGreen();
	    private GreenNode identifier;
	
	    public QualifierGreen(PilSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(PilSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((PilSyntaxKind)PilSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.QualifierSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
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
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	internal class NameGreen : GreenSyntaxNode
	{
	    internal static readonly NameGreen __Missing = new NameGreen();
	    private IdentifierGreen identifier;
	
	    public NameGreen(PilSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(PilSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((PilSyntaxKind)PilSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.NameSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
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
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	internal class IdentifierListGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierListGreen __Missing = new IdentifierListGreen();
	    private GreenNode identifier;
	
	    public IdentifierListGreen(PilSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierListGreen(PilSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((PilSyntaxKind)PilSyntaxKind.IdentifierList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.IdentifierListSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierListGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitIdentifierListGreen(this);
	
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
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.IdentifierList(identifier);
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
	    private InternalSyntaxToken lIdentifier;
	
	    public IdentifierGreen(PilSyntaxKind kind, InternalSyntaxToken lIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lIdentifier);
				this.lIdentifier = lIdentifier;
			}
	    }
	
	    public IdentifierGreen(PilSyntaxKind kind, InternalSyntaxToken lIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lIdentifier);
				this.lIdentifier = lIdentifier;
			}
	    }
	
		private IdentifierGreen()
			: base((PilSyntaxKind)PilSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LIdentifier { get { return this.lIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.IdentifierSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.lIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.lIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(InternalSyntaxToken lIdentifier)
	    {
	        if (this.LIdentifier != lIdentifier)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.Identifier(lIdentifier);
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
	
	internal class ResultIdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly ResultIdentifierGreen __Missing = new ResultIdentifierGreen();
	    private InternalSyntaxToken kResult;
	
	    public ResultIdentifierGreen(PilSyntaxKind kind, InternalSyntaxToken kResult)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kResult != null)
			{
				this.AdjustFlagsAndWidth(kResult);
				this.kResult = kResult;
			}
	    }
	
	    public ResultIdentifierGreen(PilSyntaxKind kind, InternalSyntaxToken kResult, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kResult != null)
			{
				this.AdjustFlagsAndWidth(kResult);
				this.kResult = kResult;
			}
	    }
	
		private ResultIdentifierGreen()
			: base((PilSyntaxKind)PilSyntaxKind.ResultIdentifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KResult { get { return this.kResult; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::PilV2.Syntax.ResultIdentifierSyntax(this, (PilSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kResult;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(PilSyntaxVisitor<TResult> visitor) => visitor.VisitResultIdentifierGreen(this);
	
	    public override void Accept(PilSyntaxVisitor visitor) => visitor.VisitResultIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ResultIdentifierGreen(this.Kind, this.kResult, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ResultIdentifierGreen(this.Kind, this.kResult, this.GetDiagnostics(), annotations);
	    }
	
	    public ResultIdentifierGreen Update(InternalSyntaxToken kResult)
	    {
	        if (this.KResult != kResult)
	        {
	            InternalSyntaxNode newNode = PilLanguage.Instance.InternalSyntaxFactory.ResultIdentifier(kResult);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ResultIdentifierGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class PilSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeDefDeclarationGreen(TypeDefDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitExternalParameterDeclarationGreen(ExternalParameterDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumLiteralsGreen(EnumLiteralsGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumLiteralGreen(EnumLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectDeclarationGreen(ObjectDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectHeaderGreen(ObjectHeaderGreen node) => this.DefaultVisit(node);
		public virtual void VisitPortsGreen(PortsGreen node) => this.DefaultVisit(node);
		public virtual void VisitPortGreen(PortGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectExternalParametersGreen(ObjectExternalParametersGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectFieldsGreen(ObjectFieldsGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectFunctionsGreen(ObjectFunctionsGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionDeclarationGreen(FunctionDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionHeaderGreen(FunctionHeaderGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionParamsGreen(FunctionParamsGreen node) => this.DefaultVisit(node);
		public virtual void VisitParamGreen(ParamGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryDeclarationGreen(QueryDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryHeaderGreen(QueryHeaderGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryRequestParamsGreen(QueryRequestParamsGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryAcceptParamsGreen(QueryAcceptParamsGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryRefuseParamsGreen(QueryRefuseParamsGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryCancelParamsGreen(QueryCancelParamsGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryExternalParametersGreen(QueryExternalParametersGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryFieldGreen(QueryFieldGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryFunctionGreen(QueryFunctionGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryObjectGreen(QueryObjectGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryObjectFieldGreen(QueryObjectFieldGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryObjectFunctionGreen(QueryObjectFunctionGreen node) => this.DefaultVisit(node);
		public virtual void VisitQueryObjectEventGreen(QueryObjectEventGreen node) => this.DefaultVisit(node);
		public virtual void VisitInputGreen(InputGreen node) => this.DefaultVisit(node);
		public virtual void VisitInputPortListGreen(InputPortListGreen node) => this.DefaultVisit(node);
		public virtual void VisitInputPortGreen(InputPortGreen node) => this.DefaultVisit(node);
		public virtual void VisitTriggerGreen(TriggerGreen node) => this.DefaultVisit(node);
		public virtual void VisitTriggerVarListGreen(TriggerVarListGreen node) => this.DefaultVisit(node);
		public virtual void VisitTriggerVarGreen(TriggerVarGreen node) => this.DefaultVisit(node);
		public virtual void VisitStatementsGreen(StatementsGreen node) => this.DefaultVisit(node);
		public virtual void VisitStatementGreen(StatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitForkStatementGreen(ForkStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitCaseBranchGreen(CaseBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitElseBranchGreen(ElseBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfStatementGreen(IfStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitIfBranchGreen(IfBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitElseIfBranchGreen(ElseIfBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitRequestStatementGreen(RequestStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitCallRequestGreen(CallRequestGreen node) => this.DefaultVisit(node);
		public virtual void VisitRequestArgumentsGreen(RequestArgumentsGreen node) => this.DefaultVisit(node);
		public virtual void VisitResponseStatementGreen(ResponseStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitCancelStatementGreen(CancelStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssertionGreen(AssertionGreen node) => this.DefaultVisit(node);
		public virtual void VisitResponseStatementKindGreen(ResponseStatementKindGreen node) => this.DefaultVisit(node);
		public virtual void VisitCancelStatementKindGreen(CancelStatementKindGreen node) => this.DefaultVisit(node);
		public virtual void VisitForkRequestStatementGreen(ForkRequestStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitForkRequestVariableGreen(ForkRequestVariableGreen node) => this.DefaultVisit(node);
		public virtual void VisitForkRequestIdentifierGreen(ForkRequestIdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitAcceptBranchGreen(AcceptBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitRefuseBranchGreen(RefuseBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitCancelBranchGreen(CancelBranchGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableDeclarationStatementGreen(VariableDeclarationStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableDeclarationGreen(VariableDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssignmentStatementGreen(AssignmentStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLeftSideGreen(LeftSideGreen node) => this.DefaultVisit(node);
		public virtual void VisitExpressionListGreen(ExpressionListGreen node) => this.DefaultVisit(node);
		public virtual void VisitExpressionGreen(ExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitMulDivExpressionGreen(MulDivExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitPlusMinusExpressionGreen(PlusMinusExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitNegateExpressionGreen(NegateExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleArithmeticExpressionGreen(SimpleArithmeticExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitOpMulDivGreen(OpMulDivGreen node) => this.DefaultVisit(node);
		public virtual void VisitOpAddSubGreen(OpAddSubGreen node) => this.DefaultVisit(node);
		public virtual void VisitParenArithmeticExpressionGreen(ParenArithmeticExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTerminalArithmeticExpressionGreen(TerminalArithmeticExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitOpMinusGreen(OpMinusGreen node) => this.DefaultVisit(node);
		public virtual void VisitAndExpressionGreen(AndExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitOrExpressionGreen(OrExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitNotExpressionGreen(NotExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleConditionalExpressionGreen(SimpleConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitAndAlsoOpGreen(AndAlsoOpGreen node) => this.DefaultVisit(node);
		public virtual void VisitOrElseOpGreen(OrElseOpGreen node) => this.DefaultVisit(node);
		public virtual void VisitOpExclGreen(OpExclGreen node) => this.DefaultVisit(node);
		public virtual void VisitParenConditionalExpressionGreen(ParenConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitElementOfConditionalExpressionGreen(ElementOfConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitComparisonConditionalExpressionGreen(ComparisonConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitTerminalComparisonExpressionGreen(TerminalComparisonExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitComparisonExpressionGreen(ComparisonExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitComparisonOperatorGreen(ComparisonOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitElementOfExpressionGreen(ElementOfExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitElementOfValueListGreen(ElementOfValueListGreen node) => this.DefaultVisit(node);
		public virtual void VisitElementOfValueGreen(ElementOfValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitTerminalExpressionGreen(TerminalExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitFunctionCallExpressionGreen(FunctionCallExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableReferenceGreen(VariableReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitVariableReferenceIdentifierGreen(VariableReferenceIdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitCommentGreen(CommentGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitBuiltInTypeGreen(BuiltInTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierListGreen(QualifierListGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierListGreen(IdentifierListGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitResultIdentifierGreen(ResultIdentifierGreen node) => this.DefaultVisit(node);
	}
	
	internal class PilSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeDefDeclarationGreen(TypeDefDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExternalParameterDeclarationGreen(ExternalParameterDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumLiteralsGreen(EnumLiteralsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumLiteralGreen(EnumLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectDeclarationGreen(ObjectDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectHeaderGreen(ObjectHeaderGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPortsGreen(PortsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPortGreen(PortGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectExternalParametersGreen(ObjectExternalParametersGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectFieldsGreen(ObjectFieldsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectFunctionsGreen(ObjectFunctionsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionDeclarationGreen(FunctionDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionHeaderGreen(FunctionHeaderGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionParamsGreen(FunctionParamsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParamGreen(ParamGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryDeclarationGreen(QueryDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryHeaderGreen(QueryHeaderGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryRequestParamsGreen(QueryRequestParamsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryAcceptParamsGreen(QueryAcceptParamsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryRefuseParamsGreen(QueryRefuseParamsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryCancelParamsGreen(QueryCancelParamsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryExternalParametersGreen(QueryExternalParametersGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryFieldGreen(QueryFieldGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryFunctionGreen(QueryFunctionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryObjectGreen(QueryObjectGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryObjectFieldGreen(QueryObjectFieldGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryObjectFunctionGreen(QueryObjectFunctionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQueryObjectEventGreen(QueryObjectEventGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInputGreen(InputGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInputPortListGreen(InputPortListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInputPortGreen(InputPortGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTriggerGreen(TriggerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTriggerVarListGreen(TriggerVarListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTriggerVarGreen(TriggerVarGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStatementsGreen(StatementsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStatementGreen(StatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForkStatementGreen(ForkStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCaseBranchGreen(CaseBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElseBranchGreen(ElseBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfStatementGreen(IfStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIfBranchGreen(IfBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElseIfBranchGreen(ElseIfBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRequestStatementGreen(RequestStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCallRequestGreen(CallRequestGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRequestArgumentsGreen(RequestArgumentsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitResponseStatementGreen(ResponseStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCancelStatementGreen(CancelStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssertionGreen(AssertionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitResponseStatementKindGreen(ResponseStatementKindGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCancelStatementKindGreen(CancelStatementKindGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForkRequestStatementGreen(ForkRequestStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForkRequestVariableGreen(ForkRequestVariableGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitForkRequestIdentifierGreen(ForkRequestIdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAcceptBranchGreen(AcceptBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRefuseBranchGreen(RefuseBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCancelBranchGreen(CancelBranchGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableDeclarationStatementGreen(VariableDeclarationStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableDeclarationGreen(VariableDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssignmentStatementGreen(AssignmentStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLeftSideGreen(LeftSideGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExpressionListGreen(ExpressionListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExpressionGreen(ExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMulDivExpressionGreen(MulDivExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPlusMinusExpressionGreen(PlusMinusExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNegateExpressionGreen(NegateExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleArithmeticExpressionGreen(SimpleArithmeticExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOpMulDivGreen(OpMulDivGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOpAddSubGreen(OpAddSubGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParenArithmeticExpressionGreen(ParenArithmeticExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTerminalArithmeticExpressionGreen(TerminalArithmeticExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOpMinusGreen(OpMinusGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAndExpressionGreen(AndExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOrExpressionGreen(OrExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNotExpressionGreen(NotExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleConditionalExpressionGreen(SimpleConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAndAlsoOpGreen(AndAlsoOpGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOrElseOpGreen(OrElseOpGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOpExclGreen(OpExclGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParenConditionalExpressionGreen(ParenConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElementOfConditionalExpressionGreen(ElementOfConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComparisonConditionalExpressionGreen(ComparisonConditionalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTerminalComparisonExpressionGreen(TerminalComparisonExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComparisonExpressionGreen(ComparisonExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComparisonOperatorGreen(ComparisonOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElementOfExpressionGreen(ElementOfExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElementOfValueListGreen(ElementOfValueListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElementOfValueGreen(ElementOfValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTerminalExpressionGreen(TerminalExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFunctionCallExpressionGreen(FunctionCallExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableReferenceGreen(VariableReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVariableReferenceIdentifierGreen(VariableReferenceIdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCommentGreen(CommentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBuiltInTypeGreen(BuiltInTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierListGreen(QualifierListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierListGreen(IdentifierListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitResultIdentifierGreen(ResultIdentifierGreen node) => this.DefaultVisit(node);
	}
	internal class PilInternalSyntaxFactory : InternalSyntaxFactory, MetaDslx.Languages.Antlr4Roslyn.IAntlr4SyntaxFactory
	{
		public PilInternalSyntaxFactory(PilSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public Antlr4.Runtime.Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new PilLexer(input);
	    }
	
	    public Antlr4.Runtime.Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new PilParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
		{
			return new PilSyntaxLexer(text, (PilParseOptions)options ?? PilParseOptions.Default);
		}
	
	    public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
		{
			return new PilSyntaxParser(text, (PilParseOptions)options ?? PilParseOptions.Default, (PilSyntaxNode)oldTree, changes, cancellationToken);
		}
	
	    public override Language Language => PilLanguage.Instance;
	
		private PilSyntaxKind ToPilSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<PilSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToPilSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToPilSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToPilSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
		{
			return new GreenSkippedTokensTriviaSyntax(ToPilSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToPilSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToPilSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			PilSyntaxKind typedKind = ToPilSyntaxKind(kind);
	        Debug.Assert(PilLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = PilLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			PilSyntaxKind typedKind = ToPilSyntaxKind(kind);
	        Debug.Assert(PilLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = PilLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			PilSyntaxKind typedKind = ToPilSyntaxKind(kind);
	        Debug.Assert(PilLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = PilLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToPilSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToPilSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToPilSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken LIdentifier(string text)
	    {
	        return Token(null, PilSyntaxKind.LIdentifier, text, null);
	    }
	
	    internal InternalSyntaxToken LIdentifier(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LIdentifier, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, PilSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, PilSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, PilSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LString(string text)
	    {
	        return Token(null, PilSyntaxKind.LString, text, null);
	    }
	
	    internal InternalSyntaxToken LString(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, PilSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, PilSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, PilSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, PilSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, PilSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LMultiLineComment(string text)
	    {
	        return Token(null, PilSyntaxKind.LMultiLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LMultiLineComment(string text, object value)
	    {
	        return Token(null, PilSyntaxKind.LMultiLineComment, text, value, null);
	    }
	
		public MainGreen Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != PilSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Main, declaration.Node, eOF, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(PilSyntaxKind.Main, declaration.Node, eOF);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(TypeDefDeclarationGreen typeDefDeclaration)
	    {
	#if DEBUG
		    if (typeDefDeclaration == null) throw new ArgumentNullException(nameof(typeDefDeclaration));
	#endif
			return new DeclarationGreen(PilSyntaxKind.Declaration, typeDefDeclaration, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ExternalParameterDeclarationGreen externalParameterDeclaration)
	    {
	#if DEBUG
		    if (externalParameterDeclaration == null) throw new ArgumentNullException(nameof(externalParameterDeclaration));
	#endif
			return new DeclarationGreen(PilSyntaxKind.Declaration, null, externalParameterDeclaration, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(EnumDeclarationGreen enumDeclaration)
	    {
	#if DEBUG
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
	#endif
			return new DeclarationGreen(PilSyntaxKind.Declaration, null, null, enumDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ObjectDeclarationGreen objectDeclaration)
	    {
	#if DEBUG
		    if (objectDeclaration == null) throw new ArgumentNullException(nameof(objectDeclaration));
	#endif
			return new DeclarationGreen(PilSyntaxKind.Declaration, null, null, null, objectDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(FunctionDeclarationGreen functionDeclaration)
	    {
	#if DEBUG
		    if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
	#endif
			return new DeclarationGreen(PilSyntaxKind.Declaration, null, null, null, null, functionDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(QueryDeclarationGreen queryDeclaration)
	    {
	#if DEBUG
		    if (queryDeclaration == null) throw new ArgumentNullException(nameof(queryDeclaration));
	#endif
			return new DeclarationGreen(PilSyntaxKind.Declaration, null, null, null, null, null, queryDeclaration);
	    }
	
		public TypeDefDeclarationGreen TypeDefDeclaration(InternalSyntaxToken kTypeDef, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kTypeDef == null) throw new ArgumentNullException(nameof(kTypeDef));
			if (kTypeDef.Kind != PilSyntaxKind.KTypeDef) throw new ArgumentException(nameof(kTypeDef));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new TypeDefDeclarationGreen(PilSyntaxKind.TypeDefDeclaration, kTypeDef, name, tColon, typeReference, tSemicolon);
	    }
	
		public ExternalParameterDeclarationGreen ExternalParameterDeclaration(InternalSyntaxToken kParam, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kParam == null) throw new ArgumentNullException(nameof(kParam));
			if (kParam.Kind != PilSyntaxKind.KParam) throw new ArgumentException(nameof(kParam));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tAssign != null && tAssign.Kind != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new ExternalParameterDeclarationGreen(PilSyntaxKind.ExternalParameterDeclaration, kParam, name, tColon, typeReference, tAssign, expression, tSemicolon);
	    }
	
		public EnumDeclarationGreen EnumDeclaration(InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tOpenBracket, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
			if (kEnum.Kind != PilSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != PilSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (enumLiterals == null) throw new ArgumentNullException(nameof(enumLiterals));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != PilSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new EnumDeclarationGreen(PilSyntaxKind.EnumDeclaration, kEnum, name, tOpenBracket, enumLiterals, tCloseBracket, tSemicolon);
	    }
	
		public EnumLiteralsGreen EnumLiterals(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen> enumLiteral)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.EnumLiterals, enumLiteral.Node, out hash);
			if (cached != null) return (EnumLiteralsGreen)cached;
			var result = new EnumLiteralsGreen(PilSyntaxKind.EnumLiterals, enumLiteral.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumLiteralGreen EnumLiteral(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.EnumLiteral, name, out hash);
			if (cached != null) return (EnumLiteralGreen)cached;
			var result = new EnumLiteralGreen(PilSyntaxKind.EnumLiteral, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ObjectDeclarationGreen ObjectDeclaration(InternalSyntaxToken kObject, ObjectHeaderGreen objectHeader, InternalSyntaxToken tSemicolon, ObjectExternalParametersGreen objectExternalParameters, ObjectFieldsGreen objectFields, ObjectFunctionsGreen objectFunctions, InternalSyntaxToken kEndObject)
	    {
	#if DEBUG
			if (kObject == null) throw new ArgumentNullException(nameof(kObject));
			if (kObject.Kind != PilSyntaxKind.KObject) throw new ArgumentException(nameof(kObject));
			if (objectHeader == null) throw new ArgumentNullException(nameof(objectHeader));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (objectExternalParameters == null) throw new ArgumentNullException(nameof(objectExternalParameters));
			if (objectFields == null) throw new ArgumentNullException(nameof(objectFields));
			if (objectFunctions == null) throw new ArgumentNullException(nameof(objectFunctions));
			if (kEndObject == null) throw new ArgumentNullException(nameof(kEndObject));
			if (kEndObject.Kind != PilSyntaxKind.KEndObject) throw new ArgumentException(nameof(kEndObject));
	#endif
	        return new ObjectDeclarationGreen(PilSyntaxKind.ObjectDeclaration, kObject, objectHeader, tSemicolon, objectExternalParameters, objectFields, objectFunctions, kEndObject);
	    }
	
		public ObjectHeaderGreen ObjectHeader(NameGreen name, InternalSyntaxToken tOpenParen, PortsGreen ports, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new ObjectHeaderGreen(PilSyntaxKind.ObjectHeader, name, tOpenParen, ports, tCloseParen);
	    }
	
		public PortsGreen Ports(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PortGreen> port)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Ports, port.Node, out hash);
			if (cached != null) return (PortsGreen)cached;
			var result = new PortsGreen(PilSyntaxKind.Ports, port.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PortGreen Port(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Port, name, out hash);
			if (cached != null) return (PortGreen)cached;
			var result = new PortGreen(PilSyntaxKind.Port, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ObjectExternalParametersGreen ObjectExternalParameters(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ExternalParameterDeclarationGreen> externalParameterDeclaration)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ObjectExternalParameters, externalParameterDeclaration.Node, out hash);
			if (cached != null) return (ObjectExternalParametersGreen)cached;
			var result = new ObjectExternalParametersGreen(PilSyntaxKind.ObjectExternalParameters, externalParameterDeclaration.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ObjectFieldsGreen ObjectFields(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<VariableDeclarationGreen> variableDeclaration)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ObjectFields, variableDeclaration.Node, out hash);
			if (cached != null) return (ObjectFieldsGreen)cached;
			var result = new ObjectFieldsGreen(PilSyntaxKind.ObjectFields, variableDeclaration.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ObjectFunctionsGreen ObjectFunctions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen> functionDeclaration)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ObjectFunctions, functionDeclaration.Node, out hash);
			if (cached != null) return (ObjectFunctionsGreen)cached;
			var result = new ObjectFunctionsGreen(PilSyntaxKind.ObjectFunctions, functionDeclaration.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FunctionDeclarationGreen FunctionDeclaration(InternalSyntaxToken kFunction, FunctionHeaderGreen functionHeader, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements, InternalSyntaxToken kEndFunction)
	    {
	#if DEBUG
			if (kFunction == null) throw new ArgumentNullException(nameof(kFunction));
			if (kFunction.Kind != PilSyntaxKind.KFunction) throw new ArgumentException(nameof(kFunction));
			if (functionHeader == null) throw new ArgumentNullException(nameof(functionHeader));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (kEndFunction == null) throw new ArgumentNullException(nameof(kEndFunction));
			if (kEndFunction.Kind != PilSyntaxKind.KEndFunction) throw new ArgumentException(nameof(kEndFunction));
	#endif
	        return new FunctionDeclarationGreen(PilSyntaxKind.FunctionDeclaration, kFunction, functionHeader, comment, tSemicolon, statements, kEndFunction);
	    }
	
		public FunctionHeaderGreen FunctionHeader(NameGreen name, InternalSyntaxToken tOpenParen, FunctionParamsGreen functionParams, InternalSyntaxToken tCloseParen, InternalSyntaxToken tColon, TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
	        return new FunctionHeaderGreen(PilSyntaxKind.FunctionHeader, name, tOpenParen, functionParams, tCloseParen, tColon, typeReference);
	    }
	
		public FunctionParamsGreen FunctionParams(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.FunctionParams, param.Node, out hash);
			if (cached != null) return (FunctionParamsGreen)cached;
			var result = new FunctionParamsGreen(PilSyntaxKind.FunctionParams, param.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParamGreen Param(NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Param, name, tColon, typeReference, out hash);
			if (cached != null) return (ParamGreen)cached;
			var result = new ParamGreen(PilSyntaxKind.Param, name, tColon, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryDeclarationGreen QueryDeclaration(InternalSyntaxToken kQuery, QueryHeaderGreen queryHeader, CommentGreen comment, InternalSyntaxToken startQuerySemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryExternalParametersGreen> queryExternalParameters, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryFieldGreen> queryField, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<FunctionDeclarationGreen> functionDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectGreen> queryObject, InternalSyntaxToken kEndQuery, IdentifierGreen endName, InternalSyntaxToken endQuerySemicolon)
	    {
	#if DEBUG
			if (kQuery == null) throw new ArgumentNullException(nameof(kQuery));
			if (kQuery.Kind != PilSyntaxKind.KQuery) throw new ArgumentException(nameof(kQuery));
			if (queryHeader == null) throw new ArgumentNullException(nameof(queryHeader));
			if (startQuerySemicolon == null) throw new ArgumentNullException(nameof(startQuerySemicolon));
			if (startQuerySemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(startQuerySemicolon));
			if (kEndQuery == null) throw new ArgumentNullException(nameof(kEndQuery));
			if (kEndQuery.Kind != PilSyntaxKind.KEndQuery) throw new ArgumentException(nameof(kEndQuery));
			if (endQuerySemicolon == null) throw new ArgumentNullException(nameof(endQuerySemicolon));
			if (endQuerySemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(endQuerySemicolon));
	#endif
	        return new QueryDeclarationGreen(PilSyntaxKind.QueryDeclaration, kQuery, queryHeader, comment, startQuerySemicolon, queryExternalParameters.Node, queryField.Node, functionDeclaration.Node, queryObject.Node, kEndQuery, endName, endQuerySemicolon);
	    }
	
		public QueryHeaderGreen QueryHeader(NameGreen name, InternalSyntaxToken tOpenParen, QueryRequestParamsGreen queryRequestParams, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new QueryHeaderGreen(PilSyntaxKind.QueryHeader, name, tOpenParen, queryRequestParams, tCloseParen);
	    }
	
		public QueryRequestParamsGreen QueryRequestParams(InternalSyntaxToken kRequest, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kRequest != null && kRequest.Kind != PilSyntaxKind.KRequest) throw new ArgumentException(nameof(kRequest));
			if (tSemicolon != null && tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryRequestParams, kRequest, param.Node, tSemicolon, out hash);
			if (cached != null) return (QueryRequestParamsGreen)cached;
			var result = new QueryRequestParamsGreen(PilSyntaxKind.QueryRequestParams, kRequest, param.Node, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryAcceptParamsGreen QueryAcceptParams(InternalSyntaxToken kAccept, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kAccept == null) throw new ArgumentNullException(nameof(kAccept));
			if (kAccept.Kind != PilSyntaxKind.KAccept) throw new ArgumentException(nameof(kAccept));
			if (tSemicolon != null && tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryAcceptParams, kAccept, param.Node, tSemicolon, out hash);
			if (cached != null) return (QueryAcceptParamsGreen)cached;
			var result = new QueryAcceptParamsGreen(PilSyntaxKind.QueryAcceptParams, kAccept, param.Node, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryRefuseParamsGreen QueryRefuseParams(InternalSyntaxToken kRefuse, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kRefuse == null) throw new ArgumentNullException(nameof(kRefuse));
			if (kRefuse.Kind != PilSyntaxKind.KRefuse) throw new ArgumentException(nameof(kRefuse));
			if (tSemicolon != null && tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryRefuseParams, kRefuse, param.Node, tSemicolon, out hash);
			if (cached != null) return (QueryRefuseParamsGreen)cached;
			var result = new QueryRefuseParamsGreen(PilSyntaxKind.QueryRefuseParams, kRefuse, param.Node, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryCancelParamsGreen QueryCancelParams(InternalSyntaxToken kCancel, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParamGreen> param, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kCancel == null) throw new ArgumentNullException(nameof(kCancel));
			if (kCancel.Kind != PilSyntaxKind.KCancel) throw new ArgumentException(nameof(kCancel));
			if (tSemicolon != null && tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryCancelParams, kCancel, param.Node, tSemicolon, out hash);
			if (cached != null) return (QueryCancelParamsGreen)cached;
			var result = new QueryCancelParamsGreen(PilSyntaxKind.QueryCancelParams, kCancel, param.Node, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryExternalParametersGreen QueryExternalParameters(ExternalParameterDeclarationGreen externalParameterDeclaration)
	    {
	#if DEBUG
			if (externalParameterDeclaration == null) throw new ArgumentNullException(nameof(externalParameterDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryExternalParameters, externalParameterDeclaration, out hash);
			if (cached != null) return (QueryExternalParametersGreen)cached;
			var result = new QueryExternalParametersGreen(PilSyntaxKind.QueryExternalParameters, externalParameterDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryFieldGreen QueryField(VariableDeclarationGreen variableDeclaration)
	    {
	#if DEBUG
			if (variableDeclaration == null) throw new ArgumentNullException(nameof(variableDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryField, variableDeclaration, out hash);
			if (cached != null) return (QueryFieldGreen)cached;
			var result = new QueryFieldGreen(PilSyntaxKind.QueryField, variableDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryFunctionGreen QueryFunction(FunctionDeclarationGreen functionDeclaration)
	    {
	#if DEBUG
			if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryFunction, functionDeclaration, out hash);
			if (cached != null) return (QueryFunctionGreen)cached;
			var result = new QueryFunctionGreen(PilSyntaxKind.QueryFunction, functionDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryObjectGreen QueryObject(InternalSyntaxToken kObject, NameGreen name, CommentGreen comment, InternalSyntaxToken startObjectSemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFieldGreen> queryObjectField, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectFunctionGreen> queryObjectFunction, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<QueryObjectEventGreen> queryObjectEvent, InternalSyntaxToken kEndObject, IdentifierGreen endName, InternalSyntaxToken endObjectSemicolon)
	    {
	#if DEBUG
			if (kObject == null) throw new ArgumentNullException(nameof(kObject));
			if (kObject.Kind != PilSyntaxKind.KObject) throw new ArgumentException(nameof(kObject));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (startObjectSemicolon == null) throw new ArgumentNullException(nameof(startObjectSemicolon));
			if (startObjectSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(startObjectSemicolon));
			if (kEndObject == null) throw new ArgumentNullException(nameof(kEndObject));
			if (kEndObject.Kind != PilSyntaxKind.KEndObject) throw new ArgumentException(nameof(kEndObject));
			if (endObjectSemicolon == null) throw new ArgumentNullException(nameof(endObjectSemicolon));
			if (endObjectSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(endObjectSemicolon));
	#endif
	        return new QueryObjectGreen(PilSyntaxKind.QueryObject, kObject, name, comment, startObjectSemicolon, queryObjectField.Node, queryObjectFunction.Node, queryObjectEvent.Node, kEndObject, endName, endObjectSemicolon);
	    }
	
		public QueryObjectFieldGreen QueryObjectField(VariableDeclarationGreen variableDeclaration)
	    {
	#if DEBUG
			if (variableDeclaration == null) throw new ArgumentNullException(nameof(variableDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryObjectField, variableDeclaration, out hash);
			if (cached != null) return (QueryObjectFieldGreen)cached;
			var result = new QueryObjectFieldGreen(PilSyntaxKind.QueryObjectField, variableDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryObjectFunctionGreen QueryObjectFunction(FunctionDeclarationGreen functionDeclaration)
	    {
	#if DEBUG
			if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryObjectFunction, functionDeclaration, out hash);
			if (cached != null) return (QueryObjectFunctionGreen)cached;
			var result = new QueryObjectFunctionGreen(PilSyntaxKind.QueryObjectFunction, functionDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryObjectEventGreen QueryObjectEvent(InputGreen input)
	    {
	#if DEBUG
		    if (input == null) throw new ArgumentNullException(nameof(input));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryObjectEvent, input, out hash);
			if (cached != null) return (QueryObjectEventGreen)cached;
			var result = new QueryObjectEventGreen(PilSyntaxKind.QueryObjectEvent, input, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QueryObjectEventGreen QueryObjectEvent(TriggerGreen trigger)
	    {
	#if DEBUG
		    if (trigger == null) throw new ArgumentNullException(nameof(trigger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QueryObjectEvent, trigger, out hash);
			if (cached != null) return (QueryObjectEventGreen)cached;
			var result = new QueryObjectEventGreen(PilSyntaxKind.QueryObjectEvent, null, trigger);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InputGreen Input(InternalSyntaxToken kInput, InputPortListGreen inputPortList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (kInput == null) throw new ArgumentNullException(nameof(kInput));
			if (kInput.Kind != PilSyntaxKind.KInput) throw new ArgumentException(nameof(kInput));
			if (inputPortList == null) throw new ArgumentNullException(nameof(inputPortList));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new InputGreen(PilSyntaxKind.Input, kInput, inputPortList, comment, tSemicolon, statements);
	    }
	
		public InputPortListGreen InputPortList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<InputPortGreen> inputPort)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.InputPortList, inputPort.Node, out hash);
			if (cached != null) return (InputPortListGreen)cached;
			var result = new InputPortListGreen(PilSyntaxKind.InputPortList, inputPort.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InputPortGreen InputPort(IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName)
	    {
	#if DEBUG
			if (portName == null) throw new ArgumentNullException(nameof(portName));
			if (tDot != null && tDot.Kind != PilSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.InputPort, portName, tDot, queryName, out hash);
			if (cached != null) return (InputPortGreen)cached;
			var result = new InputPortGreen(PilSyntaxKind.InputPort, portName, tDot, queryName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TriggerGreen Trigger(InternalSyntaxToken kTrigger, TriggerVarListGreen triggerVarList, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (kTrigger == null) throw new ArgumentNullException(nameof(kTrigger));
			if (kTrigger.Kind != PilSyntaxKind.KTrigger) throw new ArgumentException(nameof(kTrigger));
			if (triggerVarList == null) throw new ArgumentNullException(nameof(triggerVarList));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new TriggerGreen(PilSyntaxKind.Trigger, kTrigger, triggerVarList, comment, tSemicolon, statements);
	    }
	
		public TriggerVarListGreen TriggerVarList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TriggerVarGreen> triggerVar)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TriggerVarList, triggerVar.Node, out hash);
			if (cached != null) return (TriggerVarListGreen)cached;
			var result = new TriggerVarListGreen(PilSyntaxKind.TriggerVarList, triggerVar.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TriggerVarGreen TriggerVar(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TriggerVar, identifier, out hash);
			if (cached != null) return (TriggerVarGreen)cached;
			var result = new TriggerVarGreen(PilSyntaxKind.TriggerVar, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StatementsGreen Statements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Statements, statement.Node, out hash);
			if (cached != null) return (StatementsGreen)cached;
			var result = new StatementsGreen(PilSyntaxKind.Statements, statement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StatementGreen Statement(VariableDeclarationStatementGreen variableDeclarationStatement)
	    {
	#if DEBUG
		    if (variableDeclarationStatement == null) throw new ArgumentNullException(nameof(variableDeclarationStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, variableDeclarationStatement, null, null, null, null, null, null, null);
	    }
	
		public StatementGreen Statement(RequestStatementGreen requestStatement)
	    {
	#if DEBUG
		    if (requestStatement == null) throw new ArgumentNullException(nameof(requestStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, requestStatement, null, null, null, null, null, null);
	    }
	
		public StatementGreen Statement(ForkStatementGreen forkStatement)
	    {
	#if DEBUG
		    if (forkStatement == null) throw new ArgumentNullException(nameof(forkStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, null, forkStatement, null, null, null, null, null);
	    }
	
		public StatementGreen Statement(ForkRequestStatementGreen forkRequestStatement)
	    {
	#if DEBUG
		    if (forkRequestStatement == null) throw new ArgumentNullException(nameof(forkRequestStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, null, null, forkRequestStatement, null, null, null, null);
	    }
	
		public StatementGreen Statement(IfStatementGreen ifStatement)
	    {
	#if DEBUG
		    if (ifStatement == null) throw new ArgumentNullException(nameof(ifStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, null, null, null, ifStatement, null, null, null);
	    }
	
		public StatementGreen Statement(ResponseStatementGreen responseStatement)
	    {
	#if DEBUG
		    if (responseStatement == null) throw new ArgumentNullException(nameof(responseStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, null, null, null, null, responseStatement, null, null);
	    }
	
		public StatementGreen Statement(CancelStatementGreen cancelStatement)
	    {
	#if DEBUG
		    if (cancelStatement == null) throw new ArgumentNullException(nameof(cancelStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, null, null, null, null, null, cancelStatement, null);
	    }
	
		public StatementGreen Statement(AssignmentStatementGreen assignmentStatement)
	    {
	#if DEBUG
		    if (assignmentStatement == null) throw new ArgumentNullException(nameof(assignmentStatement));
	#endif
			return new StatementGreen(PilSyntaxKind.Statement, null, null, null, null, null, null, null, assignmentStatement);
	    }
	
		public ForkStatementGreen ForkStatement(InternalSyntaxToken kFork, ExpressionGreen expression, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CaseBranchGreen> caseBranch, ElseBranchGreen elseBranch, InternalSyntaxToken kEndFork)
	    {
	#if DEBUG
			if (kFork == null) throw new ArgumentNullException(nameof(kFork));
			if (kFork.Kind != PilSyntaxKind.KFork) throw new ArgumentException(nameof(kFork));
			if (kEndFork == null) throw new ArgumentNullException(nameof(kEndFork));
			if (kEndFork.Kind != PilSyntaxKind.KEndFork) throw new ArgumentException(nameof(kEndFork));
	#endif
	        return new ForkStatementGreen(PilSyntaxKind.ForkStatement, kFork, expression, caseBranch.Node, elseBranch, kEndFork);
	    }
	
		public CaseBranchGreen CaseBranch(InternalSyntaxToken kCase, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (kCase == null) throw new ArgumentNullException(nameof(kCase));
			if (kCase.Kind != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new CaseBranchGreen(PilSyntaxKind.CaseBranch, kCase, condition, comment, tSemicolon, statements);
	    }
	
		public ElseBranchGreen ElseBranch(InternalSyntaxToken kElse, CommentGreen comment, StatementsGreen statements)
	    {
	#if DEBUG
			if (kElse == null) throw new ArgumentNullException(nameof(kElse));
			if (kElse.Kind != PilSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ElseBranch, kElse, comment, statements, out hash);
			if (cached != null) return (ElseBranchGreen)cached;
			var result = new ElseBranchGreen(PilSyntaxKind.ElseBranch, kElse, comment, statements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IfStatementGreen IfStatement(InternalSyntaxToken kIf, IfBranchGreen ifBranch, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseIfBranchGreen> elseIfBranch, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseBranchGreen> elseBranch, InternalSyntaxToken kEndIf)
	    {
	#if DEBUG
			if (kIf == null) throw new ArgumentNullException(nameof(kIf));
			if (kIf.Kind != PilSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
			if (ifBranch == null) throw new ArgumentNullException(nameof(ifBranch));
			if (kEndIf == null) throw new ArgumentNullException(nameof(kEndIf));
			if (kEndIf.Kind != PilSyntaxKind.KEndIf) throw new ArgumentException(nameof(kEndIf));
	#endif
	        return new IfStatementGreen(PilSyntaxKind.IfStatement, kIf, ifBranch, elseIfBranch.Node, elseBranch.Node, kEndIf);
	    }
	
		public IfBranchGreen IfBranch(ConditionalExpressionGreen conditionalExpression, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (conditionalExpression == null) throw new ArgumentNullException(nameof(conditionalExpression));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new IfBranchGreen(PilSyntaxKind.IfBranch, conditionalExpression, comment, tSemicolon, statements);
	    }
	
		public ElseIfBranchGreen ElseIfBranch(InternalSyntaxToken kElse, InternalSyntaxToken kIf, IfBranchGreen ifBranch)
	    {
	#if DEBUG
			if (kElse == null) throw new ArgumentNullException(nameof(kElse));
			if (kElse.Kind != PilSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
			if (kIf == null) throw new ArgumentNullException(nameof(kIf));
			if (kIf.Kind != PilSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
			if (ifBranch == null) throw new ArgumentNullException(nameof(ifBranch));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ElseIfBranch, kElse, kIf, ifBranch, out hash);
			if (cached != null) return (ElseIfBranchGreen)cached;
			var result = new ElseIfBranchGreen(PilSyntaxKind.ElseIfBranch, kElse, kIf, ifBranch);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RequestStatementGreen RequestStatement(LeftSideGreen leftSide, InternalSyntaxToken tAssign, CallRequestGreen callRequest, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tAssign != null && tAssign.Kind != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (callRequest == null) throw new ArgumentNullException(nameof(callRequest));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new RequestStatementGreen(PilSyntaxKind.RequestStatement, leftSide, tAssign, callRequest, assertion, tSemicolon);
	    }
	
		public CallRequestGreen CallRequest(InternalSyntaxToken kRequest, IdentifierGreen portName, InternalSyntaxToken tDot, IdentifierGreen queryName, RequestArgumentsGreen requestArguments)
	    {
	#if DEBUG
			if (kRequest == null) throw new ArgumentNullException(nameof(kRequest));
			if (kRequest.Kind != PilSyntaxKind.KRequest) throw new ArgumentException(nameof(kRequest));
			if (portName == null) throw new ArgumentNullException(nameof(portName));
			if (tDot != null && tDot.Kind != PilSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
	#endif
	        return new CallRequestGreen(PilSyntaxKind.CallRequest, kRequest, portName, tDot, queryName, requestArguments);
	    }
	
		public RequestArgumentsGreen RequestArguments(InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.RequestArguments, tOpenParen, expressionList, tCloseParen, out hash);
			if (cached != null) return (RequestArgumentsGreen)cached;
			var result = new RequestArgumentsGreen(PilSyntaxKind.RequestArguments, tOpenParen, expressionList, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ResponseStatementGreen ResponseStatement(ResponseStatementKindGreen responseStatementKind, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (responseStatementKind == null) throw new ArgumentNullException(nameof(responseStatementKind));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ResponseStatement, responseStatementKind, assertion, tSemicolon, out hash);
			if (cached != null) return (ResponseStatementGreen)cached;
			var result = new ResponseStatementGreen(PilSyntaxKind.ResponseStatement, responseStatementKind, assertion, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CancelStatementGreen CancelStatement(CancelStatementKindGreen cancelStatementKind, IdentifierGreen portName, AssertionGreen assertion, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (cancelStatementKind == null) throw new ArgumentNullException(nameof(cancelStatementKind));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new CancelStatementGreen(PilSyntaxKind.CancelStatement, cancelStatementKind, portName, assertion, tSemicolon);
	    }
	
		public AssertionGreen Assertion(InternalSyntaxToken tColon, ExpressionGreen expression, CommentGreen comment)
	    {
	#if DEBUG
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Assertion, tColon, expression, comment, out hash);
			if (cached != null) return (AssertionGreen)cached;
			var result = new AssertionGreen(PilSyntaxKind.Assertion, tColon, expression, comment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ResponseStatementKindGreen ResponseStatementKind(InternalSyntaxToken responseStatementKind)
	    {
	#if DEBUG
			if (responseStatementKind == null) throw new ArgumentNullException(nameof(responseStatementKind));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ResponseStatementKind, responseStatementKind, out hash);
			if (cached != null) return (ResponseStatementKindGreen)cached;
			var result = new ResponseStatementKindGreen(PilSyntaxKind.ResponseStatementKind, responseStatementKind);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CancelStatementKindGreen CancelStatementKind(InternalSyntaxToken kCancel)
	    {
	#if DEBUG
			if (kCancel == null) throw new ArgumentNullException(nameof(kCancel));
			if (kCancel.Kind != PilSyntaxKind.KCancel) throw new ArgumentException(nameof(kCancel));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.CancelStatementKind, kCancel, out hash);
			if (cached != null) return (CancelStatementKindGreen)cached;
			var result = new CancelStatementKindGreen(PilSyntaxKind.CancelStatementKind, kCancel);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForkRequestStatementGreen ForkRequestStatement(InternalSyntaxToken kFork, ForkRequestVariableGreen forkRequestVariable, AcceptBranchGreen acceptBranch, RefuseBranchGreen refuseBranch, CancelBranchGreen cancelBranch, InternalSyntaxToken kEndFork)
	    {
	#if DEBUG
			if (kFork == null) throw new ArgumentNullException(nameof(kFork));
			if (kFork.Kind != PilSyntaxKind.KFork) throw new ArgumentException(nameof(kFork));
			if (forkRequestVariable == null) throw new ArgumentNullException(nameof(forkRequestVariable));
			if (kEndFork == null) throw new ArgumentNullException(nameof(kEndFork));
			if (kEndFork.Kind != PilSyntaxKind.KEndFork) throw new ArgumentException(nameof(kEndFork));
	#endif
	        return new ForkRequestStatementGreen(PilSyntaxKind.ForkRequestStatement, kFork, forkRequestVariable, acceptBranch, refuseBranch, cancelBranch, kEndFork);
	    }
	
		public ForkRequestVariableGreen ForkRequestVariable(ForkRequestIdentifierGreen forkRequestIdentifier)
	    {
	#if DEBUG
		    if (forkRequestIdentifier == null) throw new ArgumentNullException(nameof(forkRequestIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ForkRequestVariable, forkRequestIdentifier, out hash);
			if (cached != null) return (ForkRequestVariableGreen)cached;
			var result = new ForkRequestVariableGreen(PilSyntaxKind.ForkRequestVariable, forkRequestIdentifier, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForkRequestVariableGreen ForkRequestVariable(RequestStatementGreen requestStatement)
	    {
	#if DEBUG
		    if (requestStatement == null) throw new ArgumentNullException(nameof(requestStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ForkRequestVariable, requestStatement, out hash);
			if (cached != null) return (ForkRequestVariableGreen)cached;
			var result = new ForkRequestVariableGreen(PilSyntaxKind.ForkRequestVariable, null, requestStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ForkRequestIdentifierGreen ForkRequestIdentifier(IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ForkRequestIdentifier, identifier, tSemicolon, out hash);
			if (cached != null) return (ForkRequestIdentifierGreen)cached;
			var result = new ForkRequestIdentifierGreen(PilSyntaxKind.ForkRequestIdentifier, identifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AcceptBranchGreen AcceptBranch(InternalSyntaxToken kCase, InternalSyntaxToken kAccept, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (kCase == null) throw new ArgumentNullException(nameof(kCase));
			if (kCase.Kind != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
			if (kAccept == null) throw new ArgumentNullException(nameof(kAccept));
			if (kAccept.Kind != PilSyntaxKind.KAccept) throw new ArgumentException(nameof(kAccept));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new AcceptBranchGreen(PilSyntaxKind.AcceptBranch, kCase, kAccept, condition, comment, tSemicolon, statements);
	    }
	
		public RefuseBranchGreen RefuseBranch(InternalSyntaxToken kCase, InternalSyntaxToken kRefuse, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (kCase == null) throw new ArgumentNullException(nameof(kCase));
			if (kCase.Kind != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
			if (kRefuse == null) throw new ArgumentNullException(nameof(kRefuse));
			if (kRefuse.Kind != PilSyntaxKind.KRefuse) throw new ArgumentException(nameof(kRefuse));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new RefuseBranchGreen(PilSyntaxKind.RefuseBranch, kCase, kRefuse, condition, comment, tSemicolon, statements);
	    }
	
		public CancelBranchGreen CancelBranch(InternalSyntaxToken kCase, InternalSyntaxToken kCancel, ExpressionGreen condition, CommentGreen comment, InternalSyntaxToken tSemicolon, StatementsGreen statements)
	    {
	#if DEBUG
			if (kCase == null) throw new ArgumentNullException(nameof(kCase));
			if (kCase.Kind != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
			if (kCancel == null) throw new ArgumentNullException(nameof(kCancel));
			if (kCancel.Kind != PilSyntaxKind.KCancel) throw new ArgumentException(nameof(kCancel));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new CancelBranchGreen(PilSyntaxKind.CancelBranch, kCase, kCancel, condition, comment, tSemicolon, statements);
	    }
	
		public VariableDeclarationStatementGreen VariableDeclarationStatement(VariableDeclarationGreen variableDeclaration)
	    {
	#if DEBUG
			if (variableDeclaration == null) throw new ArgumentNullException(nameof(variableDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.VariableDeclarationStatement, variableDeclaration, out hash);
			if (cached != null) return (VariableDeclarationStatementGreen)cached;
			var result = new VariableDeclarationStatementGreen(PilSyntaxKind.VariableDeclarationStatement, variableDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VariableDeclarationGreen VariableDeclaration(InternalSyntaxToken kVar, NameGreen name, InternalSyntaxToken tColon, TypeReferenceGreen typeReference, InternalSyntaxToken tAssign, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kVar == null) throw new ArgumentNullException(nameof(kVar));
			if (kVar.Kind != PilSyntaxKind.KVar) throw new ArgumentException(nameof(kVar));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tAssign != null && tAssign.Kind != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new VariableDeclarationGreen(PilSyntaxKind.VariableDeclaration, kVar, name, tColon, typeReference, tAssign, expression, tSemicolon);
	    }
	
		public AssignmentStatementGreen AssignmentStatement(LeftSideGreen leftSide, InternalSyntaxToken tAssign, ExpressionGreen value, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (leftSide == null) throw new ArgumentNullException(nameof(leftSide));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new AssignmentStatementGreen(PilSyntaxKind.AssignmentStatement, leftSide, tAssign, value, tSemicolon);
	    }
	
		public LeftSideGreen LeftSide(IdentifierGreen identifier)
	    {
	#if DEBUG
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.LeftSide, identifier, out hash);
			if (cached != null) return (LeftSideGreen)cached;
			var result = new LeftSideGreen(PilSyntaxKind.LeftSide, identifier, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LeftSideGreen LeftSide(ResultIdentifierGreen resultIdentifier)
	    {
	#if DEBUG
		    if (resultIdentifier == null) throw new ArgumentNullException(nameof(resultIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.LeftSide, resultIdentifier, out hash);
			if (cached != null) return (LeftSideGreen)cached;
			var result = new LeftSideGreen(PilSyntaxKind.LeftSide, null, resultIdentifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ExpressionList, expression.Node, out hash);
			if (cached != null) return (ExpressionListGreen)cached;
			var result = new ExpressionListGreen(PilSyntaxKind.ExpressionList, expression.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExpressionGreen Expression(ArithmeticExpressionGreen arithmeticExpression)
	    {
	#if DEBUG
		    if (arithmeticExpression == null) throw new ArgumentNullException(nameof(arithmeticExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Expression, arithmeticExpression, out hash);
			if (cached != null) return (ExpressionGreen)cached;
			var result = new ExpressionGreen(PilSyntaxKind.Expression, arithmeticExpression, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExpressionGreen Expression(ConditionalExpressionGreen conditionalExpression)
	    {
	#if DEBUG
		    if (conditionalExpression == null) throw new ArgumentNullException(nameof(conditionalExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Expression, conditionalExpression, out hash);
			if (cached != null) return (ExpressionGreen)cached;
			var result = new ExpressionGreen(PilSyntaxKind.Expression, null, conditionalExpression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MulDivExpressionGreen MulDivExpression(ArithmeticExpressionGreen left, OpMulDivGreen opMulDiv, ArithmeticExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (opMulDiv == null) throw new ArgumentNullException(nameof(opMulDiv));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.MulDivExpression, left, opMulDiv, right, out hash);
			if (cached != null) return (MulDivExpressionGreen)cached;
			var result = new MulDivExpressionGreen(PilSyntaxKind.MulDivExpression, left, opMulDiv, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PlusMinusExpressionGreen PlusMinusExpression(ArithmeticExpressionGreen left, OpAddSubGreen opAddSub, ArithmeticExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (opAddSub == null) throw new ArgumentNullException(nameof(opAddSub));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.PlusMinusExpression, left, opAddSub, right, out hash);
			if (cached != null) return (PlusMinusExpressionGreen)cached;
			var result = new PlusMinusExpressionGreen(PilSyntaxKind.PlusMinusExpression, left, opAddSub, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NegateExpressionGreen NegateExpression(OpMinusGreen opMinus, ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator)
	    {
	#if DEBUG
			if (opMinus == null) throw new ArgumentNullException(nameof(opMinus));
			if (arithmeticExpressionTerminator == null) throw new ArgumentNullException(nameof(arithmeticExpressionTerminator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.NegateExpression, opMinus, arithmeticExpressionTerminator, out hash);
			if (cached != null) return (NegateExpressionGreen)cached;
			var result = new NegateExpressionGreen(PilSyntaxKind.NegateExpression, opMinus, arithmeticExpressionTerminator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleArithmeticExpressionGreen SimpleArithmeticExpression(ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator)
	    {
	#if DEBUG
			if (arithmeticExpressionTerminator == null) throw new ArgumentNullException(nameof(arithmeticExpressionTerminator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.SimpleArithmeticExpression, arithmeticExpressionTerminator, out hash);
			if (cached != null) return (SimpleArithmeticExpressionGreen)cached;
			var result = new SimpleArithmeticExpressionGreen(PilSyntaxKind.SimpleArithmeticExpression, arithmeticExpressionTerminator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OpMulDivGreen OpMulDiv(InternalSyntaxToken opMulDiv)
	    {
	#if DEBUG
			if (opMulDiv == null) throw new ArgumentNullException(nameof(opMulDiv));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.OpMulDiv, opMulDiv, out hash);
			if (cached != null) return (OpMulDivGreen)cached;
			var result = new OpMulDivGreen(PilSyntaxKind.OpMulDiv, opMulDiv);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OpAddSubGreen OpAddSub(InternalSyntaxToken opAddSub)
	    {
	#if DEBUG
			if (opAddSub == null) throw new ArgumentNullException(nameof(opAddSub));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.OpAddSub, opAddSub, out hash);
			if (cached != null) return (OpAddSubGreen)cached;
			var result = new OpAddSubGreen(PilSyntaxKind.OpAddSub, opAddSub);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParenArithmeticExpressionGreen ParenArithmeticExpression(InternalSyntaxToken tOpenParen, ArithmeticExpressionGreen arithmeticExpression, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (arithmeticExpression == null) throw new ArgumentNullException(nameof(arithmeticExpression));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ParenArithmeticExpression, tOpenParen, arithmeticExpression, tCloseParen, out hash);
			if (cached != null) return (ParenArithmeticExpressionGreen)cached;
			var result = new ParenArithmeticExpressionGreen(PilSyntaxKind.ParenArithmeticExpression, tOpenParen, arithmeticExpression, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TerminalArithmeticExpressionGreen TerminalArithmeticExpression(TerminalExpressionGreen terminalExpression)
	    {
	#if DEBUG
			if (terminalExpression == null) throw new ArgumentNullException(nameof(terminalExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TerminalArithmeticExpression, terminalExpression, out hash);
			if (cached != null) return (TerminalArithmeticExpressionGreen)cached;
			var result = new TerminalArithmeticExpressionGreen(PilSyntaxKind.TerminalArithmeticExpression, terminalExpression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OpMinusGreen OpMinus(InternalSyntaxToken tMinus)
	    {
	#if DEBUG
			if (tMinus == null) throw new ArgumentNullException(nameof(tMinus));
			if (tMinus.Kind != PilSyntaxKind.TMinus) throw new ArgumentException(nameof(tMinus));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.OpMinus, tMinus, out hash);
			if (cached != null) return (OpMinusGreen)cached;
			var result = new OpMinusGreen(PilSyntaxKind.OpMinus, tMinus);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AndExpressionGreen AndExpression(ConditionalExpressionGreen left, AndAlsoOpGreen andAlsoOp, ConditionalExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (andAlsoOp == null) throw new ArgumentNullException(nameof(andAlsoOp));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.AndExpression, left, andAlsoOp, right, out hash);
			if (cached != null) return (AndExpressionGreen)cached;
			var result = new AndExpressionGreen(PilSyntaxKind.AndExpression, left, andAlsoOp, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OrExpressionGreen OrExpression(ConditionalExpressionGreen left, OrElseOpGreen orElseOp, ConditionalExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (orElseOp == null) throw new ArgumentNullException(nameof(orElseOp));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.OrExpression, left, orElseOp, right, out hash);
			if (cached != null) return (OrExpressionGreen)cached;
			var result = new OrExpressionGreen(PilSyntaxKind.OrExpression, left, orElseOp, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NotExpressionGreen NotExpression(OpExclGreen opExcl, ConditionalExpressionTerminatorGreen conditionalExpressionTerminator)
	    {
	#if DEBUG
			if (opExcl == null) throw new ArgumentNullException(nameof(opExcl));
			if (conditionalExpressionTerminator == null) throw new ArgumentNullException(nameof(conditionalExpressionTerminator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.NotExpression, opExcl, conditionalExpressionTerminator, out hash);
			if (cached != null) return (NotExpressionGreen)cached;
			var result = new NotExpressionGreen(PilSyntaxKind.NotExpression, opExcl, conditionalExpressionTerminator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleConditionalExpressionGreen SimpleConditionalExpression(ConditionalExpressionTerminatorGreen conditionalExpressionTerminator)
	    {
	#if DEBUG
			if (conditionalExpressionTerminator == null) throw new ArgumentNullException(nameof(conditionalExpressionTerminator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.SimpleConditionalExpression, conditionalExpressionTerminator, out hash);
			if (cached != null) return (SimpleConditionalExpressionGreen)cached;
			var result = new SimpleConditionalExpressionGreen(PilSyntaxKind.SimpleConditionalExpression, conditionalExpressionTerminator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AndAlsoOpGreen AndAlsoOp(InternalSyntaxToken tAndAlso)
	    {
	#if DEBUG
			if (tAndAlso == null) throw new ArgumentNullException(nameof(tAndAlso));
			if (tAndAlso.Kind != PilSyntaxKind.TAndAlso) throw new ArgumentException(nameof(tAndAlso));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.AndAlsoOp, tAndAlso, out hash);
			if (cached != null) return (AndAlsoOpGreen)cached;
			var result = new AndAlsoOpGreen(PilSyntaxKind.AndAlsoOp, tAndAlso);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OrElseOpGreen OrElseOp(InternalSyntaxToken tOrElse)
	    {
	#if DEBUG
			if (tOrElse == null) throw new ArgumentNullException(nameof(tOrElse));
			if (tOrElse.Kind != PilSyntaxKind.TOrElse) throw new ArgumentException(nameof(tOrElse));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.OrElseOp, tOrElse, out hash);
			if (cached != null) return (OrElseOpGreen)cached;
			var result = new OrElseOpGreen(PilSyntaxKind.OrElseOp, tOrElse);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OpExclGreen OpExcl(InternalSyntaxToken tExclamation)
	    {
	#if DEBUG
			if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
			if (tExclamation.Kind != PilSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.OpExcl, tExclamation, out hash);
			if (cached != null) return (OpExclGreen)cached;
			var result = new OpExclGreen(PilSyntaxKind.OpExcl, tExclamation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParenConditionalExpressionGreen ParenConditionalExpression(InternalSyntaxToken tOpenParen, ConditionalExpressionGreen conditionalExpression, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (conditionalExpression == null) throw new ArgumentNullException(nameof(conditionalExpression));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ParenConditionalExpression, tOpenParen, conditionalExpression, tCloseParen, out hash);
			if (cached != null) return (ParenConditionalExpressionGreen)cached;
			var result = new ParenConditionalExpressionGreen(PilSyntaxKind.ParenConditionalExpression, tOpenParen, conditionalExpression, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementOfConditionalExpressionGreen ElementOfConditionalExpression(ElementOfExpressionGreen elementOfExpression)
	    {
	#if DEBUG
			if (elementOfExpression == null) throw new ArgumentNullException(nameof(elementOfExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ElementOfConditionalExpression, elementOfExpression, out hash);
			if (cached != null) return (ElementOfConditionalExpressionGreen)cached;
			var result = new ElementOfConditionalExpressionGreen(PilSyntaxKind.ElementOfConditionalExpression, elementOfExpression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComparisonConditionalExpressionGreen ComparisonConditionalExpression(ComparisonExpressionGreen comparisonExpression)
	    {
	#if DEBUG
			if (comparisonExpression == null) throw new ArgumentNullException(nameof(comparisonExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ComparisonConditionalExpression, comparisonExpression, out hash);
			if (cached != null) return (ComparisonConditionalExpressionGreen)cached;
			var result = new ComparisonConditionalExpressionGreen(PilSyntaxKind.ComparisonConditionalExpression, comparisonExpression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TerminalComparisonExpressionGreen TerminalComparisonExpression(TerminalExpressionGreen terminalExpression)
	    {
	#if DEBUG
			if (terminalExpression == null) throw new ArgumentNullException(nameof(terminalExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TerminalComparisonExpression, terminalExpression, out hash);
			if (cached != null) return (TerminalComparisonExpressionGreen)cached;
			var result = new TerminalComparisonExpressionGreen(PilSyntaxKind.TerminalComparisonExpression, terminalExpression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComparisonExpressionGreen ComparisonExpression(ArithmeticExpressionGreen left, ComparisonOperatorGreen op, ArithmeticExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (op == null) throw new ArgumentNullException(nameof(op));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ComparisonExpression, left, op, right, out hash);
			if (cached != null) return (ComparisonExpressionGreen)cached;
			var result = new ComparisonExpressionGreen(PilSyntaxKind.ComparisonExpression, left, op, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComparisonOperatorGreen ComparisonOperator(InternalSyntaxToken comparisonOperator)
	    {
	#if DEBUG
			if (comparisonOperator == null) throw new ArgumentNullException(nameof(comparisonOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ComparisonOperator, comparisonOperator, out hash);
			if (cached != null) return (ComparisonOperatorGreen)cached;
			var result = new ComparisonOperatorGreen(PilSyntaxKind.ComparisonOperator, comparisonOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementOfExpressionGreen ElementOfExpression(TerminalExpressionGreen terminalExpression, InternalSyntaxToken kIn, InternalSyntaxToken tOpenBracket, ElementOfValueListGreen elementOfValueList, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (terminalExpression == null) throw new ArgumentNullException(nameof(terminalExpression));
			if (kIn == null) throw new ArgumentNullException(nameof(kIn));
			if (kIn.Kind != PilSyntaxKind.KIn) throw new ArgumentException(nameof(kIn));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != PilSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != PilSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
	        return new ElementOfExpressionGreen(PilSyntaxKind.ElementOfExpression, terminalExpression, kIn, tOpenBracket, elementOfValueList, tCloseBracket);
	    }
	
		public ElementOfValueListGreen ElementOfValueList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ElementOfValueGreen> elementOfValue)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ElementOfValueList, elementOfValue.Node, out hash);
			if (cached != null) return (ElementOfValueListGreen)cached;
			var result = new ElementOfValueListGreen(PilSyntaxKind.ElementOfValueList, elementOfValue.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementOfValueGreen ElementOfValue(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ElementOfValue, identifier, out hash);
			if (cached != null) return (ElementOfValueGreen)cached;
			var result = new ElementOfValueGreen(PilSyntaxKind.ElementOfValue, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TerminalExpressionGreen TerminalExpression(VariableReferenceGreen variableReference)
	    {
	#if DEBUG
		    if (variableReference == null) throw new ArgumentNullException(nameof(variableReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TerminalExpression, variableReference, out hash);
			if (cached != null) return (TerminalExpressionGreen)cached;
			var result = new TerminalExpressionGreen(PilSyntaxKind.TerminalExpression, variableReference, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TerminalExpressionGreen TerminalExpression(FunctionCallExpressionGreen functionCallExpression)
	    {
	#if DEBUG
		    if (functionCallExpression == null) throw new ArgumentNullException(nameof(functionCallExpression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TerminalExpression, functionCallExpression, out hash);
			if (cached != null) return (TerminalExpressionGreen)cached;
			var result = new TerminalExpressionGreen(PilSyntaxKind.TerminalExpression, null, functionCallExpression, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TerminalExpressionGreen TerminalExpression(LiteralGreen literal)
	    {
	#if DEBUG
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TerminalExpression, literal, out hash);
			if (cached != null) return (TerminalExpressionGreen)cached;
			var result = new TerminalExpressionGreen(PilSyntaxKind.TerminalExpression, null, null, literal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FunctionCallExpressionGreen FunctionCallExpression(IdentifierGreen identifier, InternalSyntaxToken tOpenParen, ExpressionListGreen expressionList, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new FunctionCallExpressionGreen(PilSyntaxKind.FunctionCallExpression, identifier, tOpenParen, expressionList, tCloseParen);
	    }
	
		public VariableReferenceGreen VariableReference(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<VariableReferenceIdentifierGreen> variableReferenceIdentifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.VariableReference, variableReferenceIdentifier.Node, out hash);
			if (cached != null) return (VariableReferenceGreen)cached;
			var result = new VariableReferenceGreen(PilSyntaxKind.VariableReference, variableReferenceIdentifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VariableReferenceIdentifierGreen VariableReferenceIdentifier(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.VariableReferenceIdentifier, identifier, out hash);
			if (cached != null) return (VariableReferenceIdentifierGreen)cached;
			var result = new VariableReferenceIdentifierGreen(PilSyntaxKind.VariableReferenceIdentifier, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CommentGreen Comment(InternalSyntaxToken lString)
	    {
	#if DEBUG
			if (lString == null) throw new ArgumentNullException(nameof(lString));
			if (lString.Kind != PilSyntaxKind.LString) throw new ArgumentException(nameof(lString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Comment, lString, out hash);
			if (cached != null) return (CommentGreen)cached;
			var result = new CommentGreen(PilSyntaxKind.Comment, lString);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LiteralGreen Literal(InternalSyntaxToken literal)
	    {
	#if DEBUG
			if (literal == null) throw new ArgumentNullException(nameof(literal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Literal, literal, out hash);
			if (cached != null) return (LiteralGreen)cached;
			var result = new LiteralGreen(PilSyntaxKind.Literal, literal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(BuiltInTypeGreen builtInType)
	    {
	#if DEBUG
		    if (builtInType == null) throw new ArgumentNullException(nameof(builtInType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TypeReference, builtInType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(PilSyntaxKind.TypeReference, builtInType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(IdentifierGreen identifier)
	    {
	#if DEBUG
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.TypeReference, identifier, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(PilSyntaxKind.TypeReference, null, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BuiltInTypeGreen BuiltInType(InternalSyntaxToken builtInType)
	    {
	#if DEBUG
			if (builtInType == null) throw new ArgumentNullException(nameof(builtInType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.BuiltInType, builtInType, out hash);
			if (cached != null) return (BuiltInTypeGreen)cached;
			var result = new BuiltInTypeGreen(PilSyntaxKind.BuiltInType, builtInType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifierListGreen QualifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> qualifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.QualifierList, qualifier.Node, out hash);
			if (cached != null) return (QualifierListGreen)cached;
			var result = new QualifierListGreen(PilSyntaxKind.QualifierList, qualifier.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(PilSyntaxKind.Qualifier, identifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameGreen Name(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(PilSyntaxKind.Name, identifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.IdentifierList, identifier.Node, out hash);
			if (cached != null) return (IdentifierListGreen)cached;
			var result = new IdentifierListGreen(PilSyntaxKind.IdentifierList, identifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken lIdentifier)
	    {
	#if DEBUG
			if (lIdentifier == null) throw new ArgumentNullException(nameof(lIdentifier));
			if (lIdentifier.Kind != PilSyntaxKind.LIdentifier) throw new ArgumentException(nameof(lIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.Identifier, lIdentifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(PilSyntaxKind.Identifier, lIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ResultIdentifierGreen ResultIdentifier(InternalSyntaxToken kResult)
	    {
	#if DEBUG
			if (kResult == null) throw new ArgumentNullException(nameof(kResult));
			if (kResult.Kind != PilSyntaxKind.KResult) throw new ArgumentException(nameof(kResult));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(PilSyntaxKind)PilSyntaxKind.ResultIdentifier, kResult, out hash);
			if (cached != null) return (ResultIdentifierGreen)cached;
			var result = new ResultIdentifierGreen(PilSyntaxKind.ResultIdentifier, kResult);
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
				typeof(DeclarationGreen),
				typeof(TypeDefDeclarationGreen),
				typeof(ExternalParameterDeclarationGreen),
				typeof(EnumDeclarationGreen),
				typeof(EnumLiteralsGreen),
				typeof(EnumLiteralGreen),
				typeof(ObjectDeclarationGreen),
				typeof(ObjectHeaderGreen),
				typeof(PortsGreen),
				typeof(PortGreen),
				typeof(ObjectExternalParametersGreen),
				typeof(ObjectFieldsGreen),
				typeof(ObjectFunctionsGreen),
				typeof(FunctionDeclarationGreen),
				typeof(FunctionHeaderGreen),
				typeof(FunctionParamsGreen),
				typeof(ParamGreen),
				typeof(QueryDeclarationGreen),
				typeof(QueryHeaderGreen),
				typeof(QueryRequestParamsGreen),
				typeof(QueryAcceptParamsGreen),
				typeof(QueryRefuseParamsGreen),
				typeof(QueryCancelParamsGreen),
				typeof(QueryExternalParametersGreen),
				typeof(QueryFieldGreen),
				typeof(QueryFunctionGreen),
				typeof(QueryObjectGreen),
				typeof(QueryObjectFieldGreen),
				typeof(QueryObjectFunctionGreen),
				typeof(QueryObjectEventGreen),
				typeof(InputGreen),
				typeof(InputPortListGreen),
				typeof(InputPortGreen),
				typeof(TriggerGreen),
				typeof(TriggerVarListGreen),
				typeof(TriggerVarGreen),
				typeof(StatementsGreen),
				typeof(StatementGreen),
				typeof(ForkStatementGreen),
				typeof(CaseBranchGreen),
				typeof(ElseBranchGreen),
				typeof(IfStatementGreen),
				typeof(IfBranchGreen),
				typeof(ElseIfBranchGreen),
				typeof(RequestStatementGreen),
				typeof(CallRequestGreen),
				typeof(RequestArgumentsGreen),
				typeof(ResponseStatementGreen),
				typeof(CancelStatementGreen),
				typeof(AssertionGreen),
				typeof(ResponseStatementKindGreen),
				typeof(CancelStatementKindGreen),
				typeof(ForkRequestStatementGreen),
				typeof(ForkRequestVariableGreen),
				typeof(ForkRequestIdentifierGreen),
				typeof(AcceptBranchGreen),
				typeof(RefuseBranchGreen),
				typeof(CancelBranchGreen),
				typeof(VariableDeclarationStatementGreen),
				typeof(VariableDeclarationGreen),
				typeof(AssignmentStatementGreen),
				typeof(LeftSideGreen),
				typeof(ExpressionListGreen),
				typeof(ExpressionGreen),
				typeof(MulDivExpressionGreen),
				typeof(PlusMinusExpressionGreen),
				typeof(NegateExpressionGreen),
				typeof(SimpleArithmeticExpressionGreen),
				typeof(OpMulDivGreen),
				typeof(OpAddSubGreen),
				typeof(ParenArithmeticExpressionGreen),
				typeof(TerminalArithmeticExpressionGreen),
				typeof(OpMinusGreen),
				typeof(AndExpressionGreen),
				typeof(OrExpressionGreen),
				typeof(NotExpressionGreen),
				typeof(SimpleConditionalExpressionGreen),
				typeof(AndAlsoOpGreen),
				typeof(OrElseOpGreen),
				typeof(OpExclGreen),
				typeof(ParenConditionalExpressionGreen),
				typeof(ElementOfConditionalExpressionGreen),
				typeof(ComparisonConditionalExpressionGreen),
				typeof(TerminalComparisonExpressionGreen),
				typeof(ComparisonExpressionGreen),
				typeof(ComparisonOperatorGreen),
				typeof(ElementOfExpressionGreen),
				typeof(ElementOfValueListGreen),
				typeof(ElementOfValueGreen),
				typeof(TerminalExpressionGreen),
				typeof(FunctionCallExpressionGreen),
				typeof(VariableReferenceGreen),
				typeof(VariableReferenceIdentifierGreen),
				typeof(CommentGreen),
				typeof(LiteralGreen),
				typeof(TypeReferenceGreen),
				typeof(BuiltInTypeGreen),
				typeof(QualifierListGreen),
				typeof(QualifierGreen),
				typeof(NameGreen),
				typeof(IdentifierListGreen),
				typeof(IdentifierGreen),
				typeof(ResultIdentifierGreen),
			};
		}
	}
}


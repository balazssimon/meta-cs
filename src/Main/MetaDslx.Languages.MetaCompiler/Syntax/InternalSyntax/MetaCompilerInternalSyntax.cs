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

namespace MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax
{
    using System.Runtime.CompilerServices;
    using MetaDslx.CodeAnalysis;
    using MetaDslx.CodeAnalysis.Syntax;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using MetaDslx.CodeAnalysis;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using MetaDslx.CodeAnalysis.Text;
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
            if (visitor is MetaCompilerSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is MetaCompilerSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor);
        public abstract void Accept(MetaCompilerSyntaxVisitor visitor);

        public new MetaCompilerLanguage Language => MetaCompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new MetaCompilerSyntaxKind Kind => (MetaCompilerSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

		// Use conditional weak table so we always return same identity for structured trivia
		private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
			= new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

		/// <summary>
		/// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
		/// determine if this trivia has structure.
		/// </summary>
		/// <returns>
		/// A MetaCompilerSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
		/// If this trivia node does not have structure, returns null.
		/// </returns>
		/// <remarks>
		/// Some types of trivia have structure that can be accessed as additional syntax nodes.
		/// These forms of trivia include: 
		///   directives, where the structure describes the structure of the directive.
		///   documentation comments, where the structure describes the XML structure of the comment.
		///   skipped tokens, where the structure describes the tokens that were skipped by the parser.
		/// </remarks>
		public override SyntaxNode GetStructure(MetaDslx.CodeAnalysis.SyntaxTrivia trivia)
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
							structure = MetaCompilerStructuredTriviaSyntax.Create(trivia);
							structsInParent.Add(trivia, structure);
						}
					}

					return structure;
				}
				else
				{
					return MetaCompilerStructuredTriviaSyntax.Create(trivia);
				}
			}

			return null;
		}

	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(MetaCompilerSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new MetaCompilerLanguage Language => MetaCompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new MetaCompilerSyntaxKind Kind => EnumObject.FromIntUnsafe<MetaCompilerSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(MetaCompilerSyntaxKind kind, string text)
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
        internal GreenStructuredTriviaSyntax(MetaCompilerSyntaxKind kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        internal GreenSkippedTokensTriviaSyntax(MetaCompilerSyntaxKind kind, GreenNode tokens, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, diagnostics, annotations)
        {
            this.SlotCount = 1;
            if (tokens != null)
            {
                this.AdjustFlagsAndWidth(tokens);
                this.tokens = tokens;
            }
        }

        public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> Tokens => new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken>(this.tokens);

        protected override GreenNode GetSlot(int index)
        {
            switch (index)
            {
                case 0: return this.tokens;
                default: return null;
            }
        }

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position) => new MetaCompilerSkippedTokensTriviaSyntax(this, (MetaCompilerSyntaxNode)parent, position);

        public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSkippedTokensTrivia(this);

        public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSkippedTokensTrivia(this);

        public GreenSkippedTokensTriviaSyntax Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> tokens)
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
	    internal GreenSyntaxToken(MetaCompilerSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(MetaCompilerSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(MetaCompilerSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(MetaCompilerSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(MetaCompilerSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(MetaCompilerSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new MetaCompilerLanguage Language => MetaCompilerLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new MetaCompilerSyntaxKind Kind => EnumObject.FromIntUnsafe<MetaCompilerSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(MetaCompilerSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!MetaCompilerLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid MetaCompilerSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(MetaCompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!MetaCompilerLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid MetaCompilerSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == MetaCompilerLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == MetaCompilerLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == MetaCompilerLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == MetaCompilerLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(MetaCompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly MetaCompilerSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly MetaCompilerSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = MetaCompilerSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = MetaCompilerSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = MetaCompilerLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((MetaCompilerSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((MetaCompilerSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((MetaCompilerSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((MetaCompilerSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(MetaCompilerSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(MetaCompilerSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(MetaCompilerSyntaxKind kind, MetaCompilerSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(MetaCompilerSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(MetaCompilerSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual MetaCompilerSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(MetaCompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(MetaCompilerSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(MetaCompilerSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(MetaCompilerSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly MetaCompilerSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(MetaCompilerSyntaxKind kind, MetaCompilerSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(MetaCompilerSyntaxKind kind, MetaCompilerSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<MetaCompilerSyntaxKind>(reader.ReadInt32());
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
	        public override MetaCompilerSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(MetaCompilerSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(MetaCompilerSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            MetaCompilerSyntaxKind kind,
	            MetaCompilerSyntaxKind contextualKind,
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
	            MetaCompilerSyntaxKind kind,
	            MetaCompilerSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(MetaCompilerSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(MetaCompilerSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(MetaCompilerSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            MetaCompilerSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(MetaCompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(MetaCompilerSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    private InternalSyntaxToken eOF;
	
	    public MainGreen(MetaCompilerSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (namespaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration);
				this.namespaceDeclaration = namespaceDeclaration;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
	    public MainGreen(MetaCompilerSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (namespaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration);
				this.namespaceDeclaration = namespaceDeclaration;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
		private MainGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NamespaceDeclarationGreen NamespaceDeclaration { get { return this.namespaceDeclaration; } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.MainSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.namespaceDeclaration;
	            case 1: return this.eOF;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eOF, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eOF, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.EndOfFileToken != eOF)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, eOF);
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
	
	internal class NameGreen : GreenSyntaxNode
	{
	    internal static readonly NameGreen __Missing = new NameGreen();
	    private IdentifierGreen identifier;
	
	    public NameGreen(MetaCompilerSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(MetaCompilerSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.NameSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	    public QualifiedNameGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.QualifiedNameSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	    public QualifierGreen(MetaCompilerSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(MetaCompilerSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.QualifierSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifierGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	internal class AttributeGreen : GreenSyntaxNode
	{
	    internal static readonly AttributeGreen __Missing = new AttributeGreen();
	    private InternalSyntaxToken tOpenBracket;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tCloseBracket;
	
	    public AttributeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBracket, QualifierGreen qualifier, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public AttributeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBracket, QualifierGreen qualifier, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private AttributeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Attribute, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.AttributeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.qualifier;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitAttributeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitAttributeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AttributeGreen(this.Kind, this.tOpenBracket, this.qualifier, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AttributeGreen(this.Kind, this.tOpenBracket, this.qualifier, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public AttributeGreen Update(InternalSyntaxToken tOpenBracket, QualifierGreen qualifier, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.Qualifier != qualifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Attribute(tOpenBracket, qualifier, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AttributeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclarationGreen __Missing = new NamespaceDeclarationGreen();
	    private GreenNode attribute;
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBodyGreen namespaceBody;
	
	    public NamespaceDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
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
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
	    public NamespaceDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
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
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
		private NamespaceDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NamespaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.NamespaceDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.kNamespace;
	            case 2: return this.qualifiedName;
	            case 3: return this.namespaceBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.attribute, this.kNamespace, this.qualifiedName, this.namespaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.attribute, this.kNamespace, this.qualifiedName, this.namespaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	    {
	        if (this.Attribute != attribute ||
				this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody != namespaceBody)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
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
	
	internal class NamespaceBodyGreen : GreenSyntaxNode
	{
	    internal static readonly NamespaceBodyGreen __Missing = new NamespaceBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode declaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private NamespaceBodyGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NamespaceBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> Declaration { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen>(this.declaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.NamespaceBodySyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.declaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.declaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBodyGreen Update(InternalSyntaxToken tOpenBrace, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration != declaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly DeclarationGreen __Missing = new DeclarationGreen();
	    private TypedefDeclarationGreen typedefDeclaration;
	    private CompilerDeclarationGreen compilerDeclaration;
	    private PhaseDeclarationGreen phaseDeclaration;
	    private EnumDeclarationGreen enumDeclaration;
	    private ClassDeclarationGreen classDeclaration;
	    private SymbolDeclarationGreen symbolDeclaration;
	
	    public DeclarationGreen(MetaCompilerSyntaxKind kind, TypedefDeclarationGreen typedefDeclaration, CompilerDeclarationGreen compilerDeclaration, PhaseDeclarationGreen phaseDeclaration, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, SymbolDeclarationGreen symbolDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (typedefDeclaration != null)
			{
				this.AdjustFlagsAndWidth(typedefDeclaration);
				this.typedefDeclaration = typedefDeclaration;
			}
			if (compilerDeclaration != null)
			{
				this.AdjustFlagsAndWidth(compilerDeclaration);
				this.compilerDeclaration = compilerDeclaration;
			}
			if (phaseDeclaration != null)
			{
				this.AdjustFlagsAndWidth(phaseDeclaration);
				this.phaseDeclaration = phaseDeclaration;
			}
			if (enumDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumDeclaration);
				this.enumDeclaration = enumDeclaration;
			}
			if (classDeclaration != null)
			{
				this.AdjustFlagsAndWidth(classDeclaration);
				this.classDeclaration = classDeclaration;
			}
			if (symbolDeclaration != null)
			{
				this.AdjustFlagsAndWidth(symbolDeclaration);
				this.symbolDeclaration = symbolDeclaration;
			}
	    }
	
	    public DeclarationGreen(MetaCompilerSyntaxKind kind, TypedefDeclarationGreen typedefDeclaration, CompilerDeclarationGreen compilerDeclaration, PhaseDeclarationGreen phaseDeclaration, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, SymbolDeclarationGreen symbolDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (typedefDeclaration != null)
			{
				this.AdjustFlagsAndWidth(typedefDeclaration);
				this.typedefDeclaration = typedefDeclaration;
			}
			if (compilerDeclaration != null)
			{
				this.AdjustFlagsAndWidth(compilerDeclaration);
				this.compilerDeclaration = compilerDeclaration;
			}
			if (phaseDeclaration != null)
			{
				this.AdjustFlagsAndWidth(phaseDeclaration);
				this.phaseDeclaration = phaseDeclaration;
			}
			if (enumDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumDeclaration);
				this.enumDeclaration = enumDeclaration;
			}
			if (classDeclaration != null)
			{
				this.AdjustFlagsAndWidth(classDeclaration);
				this.classDeclaration = classDeclaration;
			}
			if (symbolDeclaration != null)
			{
				this.AdjustFlagsAndWidth(symbolDeclaration);
				this.symbolDeclaration = symbolDeclaration;
			}
	    }
	
		private DeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Declaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypedefDeclarationGreen TypedefDeclaration { get { return this.typedefDeclaration; } }
	    public CompilerDeclarationGreen CompilerDeclaration { get { return this.compilerDeclaration; } }
	    public PhaseDeclarationGreen PhaseDeclaration { get { return this.phaseDeclaration; } }
	    public EnumDeclarationGreen EnumDeclaration { get { return this.enumDeclaration; } }
	    public ClassDeclarationGreen ClassDeclaration { get { return this.classDeclaration; } }
	    public SymbolDeclarationGreen SymbolDeclaration { get { return this.symbolDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.DeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typedefDeclaration;
	            case 1: return this.compilerDeclaration;
	            case 2: return this.phaseDeclaration;
	            case 3: return this.enumDeclaration;
	            case 4: return this.classDeclaration;
	            case 5: return this.symbolDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.typedefDeclaration, this.compilerDeclaration, this.phaseDeclaration, this.enumDeclaration, this.classDeclaration, this.symbolDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.typedefDeclaration, this.compilerDeclaration, this.phaseDeclaration, this.enumDeclaration, this.classDeclaration, this.symbolDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(TypedefDeclarationGreen typedefDeclaration)
	    {
	        if (this.typedefDeclaration != typedefDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration(typedefDeclaration);
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
	
	    public DeclarationGreen Update(CompilerDeclarationGreen compilerDeclaration)
	    {
	        if (this.compilerDeclaration != compilerDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration(compilerDeclaration);
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
	
	    public DeclarationGreen Update(PhaseDeclarationGreen phaseDeclaration)
	    {
	        if (this.phaseDeclaration != phaseDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration(phaseDeclaration);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration(enumDeclaration);
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
	
	    public DeclarationGreen Update(ClassDeclarationGreen classDeclaration)
	    {
	        if (this.classDeclaration != classDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration(classDeclaration);
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
	
	    public DeclarationGreen Update(SymbolDeclarationGreen symbolDeclaration)
	    {
	        if (this.symbolDeclaration != symbolDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration(symbolDeclaration);
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
	
	internal class CompilerDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly CompilerDeclarationGreen __Missing = new CompilerDeclarationGreen();
	    private GreenNode attribute;
	    private InternalSyntaxToken kCompiler;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public CompilerDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kCompiler, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kCompiler != null)
			{
				this.AdjustFlagsAndWidth(kCompiler);
				this.kCompiler = kCompiler;
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
	
	    public CompilerDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kCompiler, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kCompiler != null)
			{
				this.AdjustFlagsAndWidth(kCompiler);
				this.kCompiler = kCompiler;
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
	
		private CompilerDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.CompilerDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KCompiler { get { return this.kCompiler; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.CompilerDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.kCompiler;
	            case 2: return this.name;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitCompilerDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitCompilerDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompilerDeclarationGreen(this.Kind, this.attribute, this.kCompiler, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompilerDeclarationGreen(this.Kind, this.attribute, this.kCompiler, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public CompilerDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kCompiler, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KCompiler != kCompiler ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.CompilerDeclaration(attribute, kCompiler, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompilerDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PhaseDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly PhaseDeclarationGreen __Missing = new PhaseDeclarationGreen();
	    private GreenNode attribute;
	    private LockedGreen locked;
	    private InternalSyntaxToken kPhase;
	    private NameGreen name;
	    private PhaseJoinGreen phaseJoin;
	    private AfterPhasesGreen afterPhases;
	    private BeforePhasesGreen beforePhases;
	    private InternalSyntaxToken tSemicolon;
	
	    public PhaseDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, LockedGreen locked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (locked != null)
			{
				this.AdjustFlagsAndWidth(locked);
				this.locked = locked;
			}
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (phaseJoin != null)
			{
				this.AdjustFlagsAndWidth(phaseJoin);
				this.phaseJoin = phaseJoin;
			}
			if (afterPhases != null)
			{
				this.AdjustFlagsAndWidth(afterPhases);
				this.afterPhases = afterPhases;
			}
			if (beforePhases != null)
			{
				this.AdjustFlagsAndWidth(beforePhases);
				this.beforePhases = beforePhases;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public PhaseDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, LockedGreen locked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (locked != null)
			{
				this.AdjustFlagsAndWidth(locked);
				this.locked = locked;
			}
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (phaseJoin != null)
			{
				this.AdjustFlagsAndWidth(phaseJoin);
				this.phaseJoin = phaseJoin;
			}
			if (afterPhases != null)
			{
				this.AdjustFlagsAndWidth(afterPhases);
				this.afterPhases = afterPhases;
			}
			if (beforePhases != null)
			{
				this.AdjustFlagsAndWidth(beforePhases);
				this.beforePhases = beforePhases;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private PhaseDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PhaseDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public LockedGreen Locked { get { return this.locked; } }
	    public InternalSyntaxToken KPhase { get { return this.kPhase; } }
	    public NameGreen Name { get { return this.name; } }
	    public PhaseJoinGreen PhaseJoin { get { return this.phaseJoin; } }
	    public AfterPhasesGreen AfterPhases { get { return this.afterPhases; } }
	    public BeforePhasesGreen BeforePhases { get { return this.beforePhases; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.PhaseDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.locked;
	            case 2: return this.kPhase;
	            case 3: return this.name;
	            case 4: return this.phaseJoin;
	            case 5: return this.afterPhases;
	            case 6: return this.beforePhases;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPhaseDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPhaseDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PhaseDeclarationGreen(this.Kind, this.attribute, this.locked, this.kPhase, this.name, this.phaseJoin, this.afterPhases, this.beforePhases, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PhaseDeclarationGreen(this.Kind, this.attribute, this.locked, this.kPhase, this.name, this.phaseJoin, this.afterPhases, this.beforePhases, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public PhaseDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, LockedGreen locked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.Locked != locked ||
				this.KPhase != kPhase ||
				this.Name != name ||
				this.PhaseJoin != phaseJoin ||
				this.AfterPhases != afterPhases ||
				this.BeforePhases != beforePhases ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseDeclaration(attribute, locked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LockedGreen : GreenSyntaxNode
	{
	    internal static readonly LockedGreen __Missing = new LockedGreen();
	    private InternalSyntaxToken kLocked;
	
	    public LockedGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kLocked)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kLocked != null)
			{
				this.AdjustFlagsAndWidth(kLocked);
				this.kLocked = kLocked;
			}
	    }
	
	    public LockedGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kLocked, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kLocked != null)
			{
				this.AdjustFlagsAndWidth(kLocked);
				this.kLocked = kLocked;
			}
	    }
	
		private LockedGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Locked, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KLocked { get { return this.kLocked; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.LockedSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kLocked;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLockedGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitLockedGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LockedGreen(this.Kind, this.kLocked, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LockedGreen(this.Kind, this.kLocked, this.GetDiagnostics(), annotations);
	    }
	
	    public LockedGreen Update(InternalSyntaxToken kLocked)
	    {
	        if (this.KLocked != kLocked)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Locked(kLocked);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LockedGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PhaseJoinGreen : GreenSyntaxNode
	{
	    internal static readonly PhaseJoinGreen __Missing = new PhaseJoinGreen();
	    private InternalSyntaxToken kJoins;
	    private PhaseRefGreen phaseRef;
	
	    public PhaseJoinGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kJoins, PhaseRefGreen phaseRef)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kJoins != null)
			{
				this.AdjustFlagsAndWidth(kJoins);
				this.kJoins = kJoins;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
	    public PhaseJoinGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kJoins, PhaseRefGreen phaseRef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kJoins != null)
			{
				this.AdjustFlagsAndWidth(kJoins);
				this.kJoins = kJoins;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
		private PhaseJoinGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PhaseJoin, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KJoins { get { return this.kJoins; } }
	    public PhaseRefGreen PhaseRef { get { return this.phaseRef; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.PhaseJoinSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kJoins;
	            case 1: return this.phaseRef;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPhaseJoinGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPhaseJoinGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PhaseJoinGreen(this.Kind, this.kJoins, this.phaseRef, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PhaseJoinGreen(this.Kind, this.kJoins, this.phaseRef, this.GetDiagnostics(), annotations);
	    }
	
	    public PhaseJoinGreen Update(InternalSyntaxToken kJoins, PhaseRefGreen phaseRef)
	    {
	        if (this.KJoins != kJoins ||
				this.PhaseRef != phaseRef)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseJoin(kJoins, phaseRef);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseJoinGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AfterPhasesGreen : GreenSyntaxNode
	{
	    internal static readonly AfterPhasesGreen __Missing = new AfterPhasesGreen();
	    private InternalSyntaxToken kAfter;
	    private GreenNode phaseRef;
	
	    public AfterPhasesGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kAfter, GreenNode phaseRef)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kAfter != null)
			{
				this.AdjustFlagsAndWidth(kAfter);
				this.kAfter = kAfter;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
	    public AfterPhasesGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kAfter, GreenNode phaseRef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kAfter != null)
			{
				this.AdjustFlagsAndWidth(kAfter);
				this.kAfter = kAfter;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
		private AfterPhasesGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.AfterPhases, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAfter { get { return this.kAfter; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> PhaseRef { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen>(this.phaseRef); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.AfterPhasesSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAfter;
	            case 1: return this.phaseRef;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitAfterPhasesGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitAfterPhasesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AfterPhasesGreen(this.Kind, this.kAfter, this.phaseRef, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AfterPhasesGreen(this.Kind, this.kAfter, this.phaseRef, this.GetDiagnostics(), annotations);
	    }
	
	    public AfterPhasesGreen Update(InternalSyntaxToken kAfter, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
	    {
	        if (this.KAfter != kAfter ||
				this.PhaseRef != phaseRef)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.AfterPhases(kAfter, phaseRef);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AfterPhasesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BeforePhasesGreen : GreenSyntaxNode
	{
	    internal static readonly BeforePhasesGreen __Missing = new BeforePhasesGreen();
	    private InternalSyntaxToken kBefore;
	    private GreenNode phaseRef;
	
	    public BeforePhasesGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kBefore, GreenNode phaseRef)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kBefore != null)
			{
				this.AdjustFlagsAndWidth(kBefore);
				this.kBefore = kBefore;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
	    public BeforePhasesGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kBefore, GreenNode phaseRef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kBefore != null)
			{
				this.AdjustFlagsAndWidth(kBefore);
				this.kBefore = kBefore;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
		private BeforePhasesGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.BeforePhases, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBefore { get { return this.kBefore; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> PhaseRef { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen>(this.phaseRef); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.BeforePhasesSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBefore;
	            case 1: return this.phaseRef;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitBeforePhasesGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitBeforePhasesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BeforePhasesGreen(this.Kind, this.kBefore, this.phaseRef, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BeforePhasesGreen(this.Kind, this.kBefore, this.phaseRef, this.GetDiagnostics(), annotations);
	    }
	
	    public BeforePhasesGreen Update(InternalSyntaxToken kBefore, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
	    {
	        if (this.KBefore != kBefore ||
				this.PhaseRef != phaseRef)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.BeforePhases(kBefore, phaseRef);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BeforePhasesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PhaseRefGreen : GreenSyntaxNode
	{
	    internal static readonly PhaseRefGreen __Missing = new PhaseRefGreen();
	    private QualifierGreen qualifier;
	
	    public PhaseRefGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public PhaseRefGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private PhaseRefGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PhaseRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.PhaseRefSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPhaseRefGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPhaseRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PhaseRefGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PhaseRefGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public PhaseRefGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseRef(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly EnumDeclarationGreen __Missing = new EnumDeclarationGreen();
	    private GreenNode attribute;
	    private InternalSyntaxToken kEnum;
	    private NameGreen name;
	    private EnumBodyGreen enumBody;
	
	    public EnumDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
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
			if (enumBody != null)
			{
				this.AdjustFlagsAndWidth(enumBody);
				this.enumBody = enumBody;
			}
	    }
	
	    public EnumDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
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
			if (enumBody != null)
			{
				this.AdjustFlagsAndWidth(enumBody);
				this.enumBody = enumBody;
			}
	    }
	
		private EnumDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KEnum { get { return this.kEnum; } }
	    public NameGreen Name { get { return this.name; } }
	    public EnumBodyGreen EnumBody { get { return this.enumBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.EnumDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.kEnum;
	            case 2: return this.name;
	            case 3: return this.enumBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.attribute, this.kEnum, this.name, this.enumBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.attribute, this.kEnum, this.name, this.enumBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	    {
	        if (this.Attribute != attribute ||
				this.KEnum != kEnum ||
				this.Name != name ||
				this.EnumBody != enumBody)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(attribute, kEnum, name, enumBody);
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
	
	internal class EnumBodyGreen : GreenSyntaxNode
	{
	    internal static readonly EnumBodyGreen __Missing = new EnumBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private EnumValuesGreen enumValues;
	    private InternalSyntaxToken tSemicolon;
	    private GreenNode enumMemberDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EnumBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, GreenNode enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (enumValues != null)
			{
				this.AdjustFlagsAndWidth(enumValues);
				this.enumValues = enumValues;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (enumMemberDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumMemberDeclaration);
				this.enumMemberDeclaration = enumMemberDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public EnumBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, GreenNode enumMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (enumValues != null)
			{
				this.AdjustFlagsAndWidth(enumValues);
				this.enumValues = enumValues;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
			if (enumMemberDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumMemberDeclaration);
				this.enumMemberDeclaration = enumMemberDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private EnumBodyGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public EnumValuesGreen EnumValues { get { return this.enumValues; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> EnumMemberDeclaration { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen>(this.enumMemberDeclaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.EnumBodySyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.enumValues;
	            case 2: return this.tSemicolon;
	            case 3: return this.enumMemberDeclaration;
	            case 4: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitEnumBodyGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitEnumBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumValues, this.tSemicolon, this.enumMemberDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumValues, this.tSemicolon, this.enumMemberDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumBodyGreen Update(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EnumValues != enumValues ||
				this.TSemicolon != tSemicolon ||
				this.EnumMemberDeclaration != enumMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumValuesGreen : GreenSyntaxNode
	{
	    internal static readonly EnumValuesGreen __Missing = new EnumValuesGreen();
	    private GreenNode enumValue;
	
	    public EnumValuesGreen(MetaCompilerSyntaxKind kind, GreenNode enumValue)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (enumValue != null)
			{
				this.AdjustFlagsAndWidth(enumValue);
				this.enumValue = enumValue;
			}
	    }
	
	    public EnumValuesGreen(MetaCompilerSyntaxKind kind, GreenNode enumValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (enumValue != null)
			{
				this.AdjustFlagsAndWidth(enumValue);
				this.enumValue = enumValue;
			}
	    }
	
		private EnumValuesGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumValues, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> EnumValue { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen>(this.enumValue); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.EnumValuesSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumValue;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitEnumValuesGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitEnumValuesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumValuesGreen(this.Kind, this.enumValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumValuesGreen(this.Kind, this.enumValue, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumValuesGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> enumValue)
	    {
	        if (this.EnumValue != enumValue)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumValues(enumValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValuesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumValueGreen : GreenSyntaxNode
	{
	    internal static readonly EnumValueGreen __Missing = new EnumValueGreen();
	    private GreenNode attribute;
	    private NameGreen name;
	
	    public EnumValueGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public EnumValueGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private EnumValueGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.EnumValueSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitEnumValueGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitEnumValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumValueGreen(this.Kind, this.attribute, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumValueGreen(this.Kind, this.attribute, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumValueGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, NameGreen name)
	    {
	        if (this.Attribute != attribute ||
				this.Name != name)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumValue(attribute, name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumMemberDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly EnumMemberDeclarationGreen __Missing = new EnumMemberDeclarationGreen();
	    private OperationDeclarationGreen operationDeclaration;
	
	    public EnumMemberDeclarationGreen(MetaCompilerSyntaxKind kind, OperationDeclarationGreen operationDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
	    public EnumMemberDeclarationGreen(MetaCompilerSyntaxKind kind, OperationDeclarationGreen operationDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
		private EnumMemberDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumMemberDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OperationDeclarationGreen OperationDeclaration { get { return this.operationDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.EnumMemberDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.operationDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitEnumMemberDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitEnumMemberDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumMemberDeclarationGreen(this.Kind, this.operationDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumMemberDeclarationGreen(this.Kind, this.operationDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumMemberDeclarationGreen Update(OperationDeclarationGreen operationDeclaration)
	    {
	        if (this.OperationDeclaration != operationDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumMemberDeclaration(operationDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumMemberDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VisibilityGreen : GreenSyntaxNode
	{
	    internal static readonly VisibilityGreen __Missing = new VisibilityGreen();
	    private InternalSyntaxToken visibility;
	
	    public VisibilityGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken visibility)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
	    }
	
	    public VisibilityGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken visibility, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
	    }
	
		private VisibilityGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Visibility, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Visibility { get { return this.visibility; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.VisibilitySyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.visibility;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitVisibilityGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitVisibilityGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VisibilityGreen(this.Kind, this.visibility, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VisibilityGreen(this.Kind, this.visibility, this.GetDiagnostics(), annotations);
	    }
	
	    public VisibilityGreen Update(InternalSyntaxToken visibility)
	    {
	        if (this.Visibility != visibility)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Visibility(visibility);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VisibilityGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ClassDeclarationGreen __Missing = new ClassDeclarationGreen();
	    private GreenNode attribute;
	    private VisibilityGreen visibility;
	    private GreenNode classModifier;
	    private Class_Green class_;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ClassAncestorsGreen classAncestors;
	    private ClassBodyGreen classBody;
	
	    public ClassDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, GreenNode classModifier, Class_Green class_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (classModifier != null)
			{
				this.AdjustFlagsAndWidth(classModifier);
				this.classModifier = classModifier;
			}
			if (class_ != null)
			{
				this.AdjustFlagsAndWidth(class_);
				this.class_ = class_;
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
			if (classAncestors != null)
			{
				this.AdjustFlagsAndWidth(classAncestors);
				this.classAncestors = classAncestors;
			}
			if (classBody != null)
			{
				this.AdjustFlagsAndWidth(classBody);
				this.classBody = classBody;
			}
	    }
	
	    public ClassDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, GreenNode classModifier, Class_Green class_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (classModifier != null)
			{
				this.AdjustFlagsAndWidth(classModifier);
				this.classModifier = classModifier;
			}
			if (class_ != null)
			{
				this.AdjustFlagsAndWidth(class_);
				this.class_ = class_;
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
			if (classAncestors != null)
			{
				this.AdjustFlagsAndWidth(classAncestors);
				this.classAncestors = classAncestors;
			}
			if (classBody != null)
			{
				this.AdjustFlagsAndWidth(classBody);
				this.classBody = classBody;
			}
	    }
	
		private ClassDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public VisibilityGreen Visibility { get { return this.visibility; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen> ClassModifier { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen>(this.classModifier); } }
	    public Class_Green Class_ { get { return this.class_; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ClassAncestorsGreen ClassAncestors { get { return this.classAncestors; } }
	    public ClassBodyGreen ClassBody { get { return this.classBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.visibility;
	            case 2: return this.classModifier;
	            case 3: return this.class_;
	            case 4: return this.name;
	            case 5: return this.tColon;
	            case 6: return this.classAncestors;
	            case 7: return this.classBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.attribute, this.visibility, this.classModifier, this.class_, this.name, this.tColon, this.classAncestors, this.classBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.attribute, this.visibility, this.classModifier, this.class_, this.name, this.tColon, this.classAncestors, this.classBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen> classModifier, Class_Green class_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.ClassModifier != classModifier ||
				this.Class_ != class_ ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(attribute, visibility, classModifier, class_, name, tColon, classAncestors, classBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassModifierGreen : GreenSyntaxNode
	{
	    internal static readonly ClassModifierGreen __Missing = new ClassModifierGreen();
	    private Abstract_Green abstract_;
	    private Sealed_Green sealed_;
	    private Partial_Green partial_;
	    private Static_Green static_;
	
	    public ClassModifierGreen(MetaCompilerSyntaxKind kind, Abstract_Green abstract_, Sealed_Green sealed_, Partial_Green partial_, Static_Green static_)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (abstract_ != null)
			{
				this.AdjustFlagsAndWidth(abstract_);
				this.abstract_ = abstract_;
			}
			if (sealed_ != null)
			{
				this.AdjustFlagsAndWidth(sealed_);
				this.sealed_ = sealed_;
			}
			if (partial_ != null)
			{
				this.AdjustFlagsAndWidth(partial_);
				this.partial_ = partial_;
			}
			if (static_ != null)
			{
				this.AdjustFlagsAndWidth(static_);
				this.static_ = static_;
			}
	    }
	
	    public ClassModifierGreen(MetaCompilerSyntaxKind kind, Abstract_Green abstract_, Sealed_Green sealed_, Partial_Green partial_, Static_Green static_, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (abstract_ != null)
			{
				this.AdjustFlagsAndWidth(abstract_);
				this.abstract_ = abstract_;
			}
			if (sealed_ != null)
			{
				this.AdjustFlagsAndWidth(sealed_);
				this.sealed_ = sealed_;
			}
			if (partial_ != null)
			{
				this.AdjustFlagsAndWidth(partial_);
				this.partial_ = partial_;
			}
			if (static_ != null)
			{
				this.AdjustFlagsAndWidth(static_);
				this.static_ = static_;
			}
	    }
	
		private ClassModifierGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassModifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Abstract_Green Abstract_ { get { return this.abstract_; } }
	    public Sealed_Green Sealed_ { get { return this.sealed_; } }
	    public Partial_Green Partial_ { get { return this.partial_; } }
	    public Static_Green Static_ { get { return this.static_; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassModifierSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.abstract_;
	            case 1: return this.sealed_;
	            case 2: return this.partial_;
	            case 3: return this.static_;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassModifierGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassModifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassModifierGreen(this.Kind, this.abstract_, this.sealed_, this.partial_, this.static_, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassModifierGreen(this.Kind, this.abstract_, this.sealed_, this.partial_, this.static_, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassModifierGreen Update(Abstract_Green abstract_)
	    {
	        if (this.abstract_ != abstract_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier(abstract_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierGreen Update(Sealed_Green sealed_)
	    {
	        if (this.sealed_ != sealed_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier(sealed_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierGreen Update(Partial_Green partial_)
	    {
	        if (this.partial_ != partial_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier(partial_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierGreen Update(Static_Green static_)
	    {
	        if (this.static_ != static_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier(static_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassAncestorsGreen : GreenSyntaxNode
	{
	    internal static readonly ClassAncestorsGreen __Missing = new ClassAncestorsGreen();
	    private GreenNode classAncestor;
	
	    public ClassAncestorsGreen(MetaCompilerSyntaxKind kind, GreenNode classAncestor)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (classAncestor != null)
			{
				this.AdjustFlagsAndWidth(classAncestor);
				this.classAncestor = classAncestor;
			}
	    }
	
	    public ClassAncestorsGreen(MetaCompilerSyntaxKind kind, GreenNode classAncestor, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (classAncestor != null)
			{
				this.AdjustFlagsAndWidth(classAncestor);
				this.classAncestor = classAncestor;
			}
	    }
	
		private ClassAncestorsGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassAncestors, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> ClassAncestor { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen>(this.classAncestor); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassAncestorsSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.classAncestor;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassAncestorsGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassAncestorsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassAncestorsGreen(this.Kind, this.classAncestor, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassAncestorsGreen(this.Kind, this.classAncestor, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassAncestorsGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> classAncestor)
	    {
	        if (this.ClassAncestor != classAncestor)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassAncestors(classAncestor);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassAncestorGreen : GreenSyntaxNode
	{
	    internal static readonly ClassAncestorGreen __Missing = new ClassAncestorGreen();
	    private QualifierGreen qualifier;
	
	    public ClassAncestorGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ClassAncestorGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private ClassAncestorGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassAncestor, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassAncestorSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassAncestorGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassAncestorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassAncestorGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassAncestorGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassAncestorGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassAncestor(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassBodyGreen : GreenSyntaxNode
	{
	    internal static readonly ClassBodyGreen __Missing = new ClassBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private ClassPhasesGreen classPhases;
	    private GreenNode classMemberDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ClassBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, ClassPhasesGreen classPhases, GreenNode classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (classPhases != null)
			{
				this.AdjustFlagsAndWidth(classPhases);
				this.classPhases = classPhases;
			}
			if (classMemberDeclaration != null)
			{
				this.AdjustFlagsAndWidth(classMemberDeclaration);
				this.classMemberDeclaration = classMemberDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public ClassBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, ClassPhasesGreen classPhases, GreenNode classMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (classPhases != null)
			{
				this.AdjustFlagsAndWidth(classPhases);
				this.classPhases = classPhases;
			}
			if (classMemberDeclaration != null)
			{
				this.AdjustFlagsAndWidth(classMemberDeclaration);
				this.classMemberDeclaration = classMemberDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private ClassBodyGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public ClassPhasesGreen ClassPhases { get { return this.classPhases; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> ClassMemberDeclaration { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen>(this.classMemberDeclaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassBodySyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.classPhases;
	            case 2: return this.classMemberDeclaration;
	            case 3: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassBodyGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassBodyGreen(this.Kind, this.tOpenBrace, this.classPhases, this.classMemberDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassBodyGreen(this.Kind, this.tOpenBrace, this.classPhases, this.classMemberDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassBodyGreen Update(InternalSyntaxToken tOpenBrace, ClassPhasesGreen classPhases, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ClassPhases != classPhases ||
				this.ClassMemberDeclaration != classMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassBody(tOpenBrace, classPhases, classMemberDeclaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassPhasesGreen : GreenSyntaxNode
	{
	    internal static readonly ClassPhasesGreen __Missing = new ClassPhasesGreen();
	    private InternalSyntaxToken kPhase;
	    private GreenNode phaseRef;
	    private InternalSyntaxToken tSemicolon;
	
	    public ClassPhasesGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPhase, GreenNode phaseRef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ClassPhasesGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPhase, GreenNode phaseRef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ClassPhasesGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassPhases, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KPhase { get { return this.kPhase; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> PhaseRef { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen>(this.phaseRef); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassPhasesSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPhase;
	            case 1: return this.phaseRef;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassPhasesGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassPhasesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassPhasesGreen(this.Kind, this.kPhase, this.phaseRef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassPhasesGreen(this.Kind, this.kPhase, this.phaseRef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassPhasesGreen Update(InternalSyntaxToken kPhase, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KPhase != kPhase ||
				this.PhaseRef != phaseRef ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassPhases(kPhase, phaseRef, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassPhasesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ClassMemberDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ClassMemberDeclarationGreen __Missing = new ClassMemberDeclarationGreen();
	    private FieldDeclarationGreen fieldDeclaration;
	    private OperationDeclarationGreen operationDeclaration;
	
	    public ClassMemberDeclarationGreen(MetaCompilerSyntaxKind kind, FieldDeclarationGreen fieldDeclaration, OperationDeclarationGreen operationDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (fieldDeclaration != null)
			{
				this.AdjustFlagsAndWidth(fieldDeclaration);
				this.fieldDeclaration = fieldDeclaration;
			}
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
	    public ClassMemberDeclarationGreen(MetaCompilerSyntaxKind kind, FieldDeclarationGreen fieldDeclaration, OperationDeclarationGreen operationDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (fieldDeclaration != null)
			{
				this.AdjustFlagsAndWidth(fieldDeclaration);
				this.fieldDeclaration = fieldDeclaration;
			}
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
		private ClassMemberDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassMemberDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FieldDeclarationGreen FieldDeclaration { get { return this.fieldDeclaration; } }
	    public OperationDeclarationGreen OperationDeclaration { get { return this.operationDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassMemberDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldDeclaration;
	            case 1: return this.operationDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassMemberDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassMemberDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassMemberDeclarationGreen(this.Kind, this.fieldDeclaration, this.operationDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassMemberDeclarationGreen(this.Kind, this.fieldDeclaration, this.operationDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassMemberDeclarationGreen Update(FieldDeclarationGreen fieldDeclaration)
	    {
	        if (this.fieldDeclaration != fieldDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration(fieldDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassMemberDeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public ClassMemberDeclarationGreen Update(OperationDeclarationGreen operationDeclaration)
	    {
	        if (this.operationDeclaration != operationDeclaration)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration(operationDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassMemberDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Class_Green : GreenSyntaxNode
	{
	    internal static readonly Class_Green __Missing = new Class_Green();
	    private InternalSyntaxToken kClass;
	
	    public Class_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kClass)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kClass != null)
			{
				this.AdjustFlagsAndWidth(kClass);
				this.kClass = kClass;
			}
	    }
	
	    public Class_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kClass, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kClass != null)
			{
				this.AdjustFlagsAndWidth(kClass);
				this.kClass = kClass;
			}
	    }
	
		private Class_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Class_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KClass { get { return this.kClass; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Class_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kClass;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClass_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClass_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Class_Green(this.Kind, this.kClass, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Class_Green(this.Kind, this.kClass, this.GetDiagnostics(), annotations);
	    }
	
	    public Class_Green Update(InternalSyntaxToken kClass)
	    {
	        if (this.KClass != kClass)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Class_(kClass);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Class_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SymbolDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly SymbolDeclarationGreen __Missing = new SymbolDeclarationGreen();
	    private GreenNode attribute;
	    private VisibilityGreen visibility;
	    private Visit_Green visit_;
	    private GreenNode classModifier;
	    private Symbol_Green symbol_;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ClassAncestorsGreen classAncestors;
	    private ClassBodyGreen classBody;
	
	    public SymbolDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, Visit_Green visit_, GreenNode classModifier, Symbol_Green symbol_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 9;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (visit_ != null)
			{
				this.AdjustFlagsAndWidth(visit_);
				this.visit_ = visit_;
			}
			if (classModifier != null)
			{
				this.AdjustFlagsAndWidth(classModifier);
				this.classModifier = classModifier;
			}
			if (symbol_ != null)
			{
				this.AdjustFlagsAndWidth(symbol_);
				this.symbol_ = symbol_;
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
			if (classAncestors != null)
			{
				this.AdjustFlagsAndWidth(classAncestors);
				this.classAncestors = classAncestors;
			}
			if (classBody != null)
			{
				this.AdjustFlagsAndWidth(classBody);
				this.classBody = classBody;
			}
	    }
	
	    public SymbolDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, Visit_Green visit_, GreenNode classModifier, Symbol_Green symbol_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 9;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (visit_ != null)
			{
				this.AdjustFlagsAndWidth(visit_);
				this.visit_ = visit_;
			}
			if (classModifier != null)
			{
				this.AdjustFlagsAndWidth(classModifier);
				this.classModifier = classModifier;
			}
			if (symbol_ != null)
			{
				this.AdjustFlagsAndWidth(symbol_);
				this.symbol_ = symbol_;
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
			if (classAncestors != null)
			{
				this.AdjustFlagsAndWidth(classAncestors);
				this.classAncestors = classAncestors;
			}
			if (classBody != null)
			{
				this.AdjustFlagsAndWidth(classBody);
				this.classBody = classBody;
			}
	    }
	
		private SymbolDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SymbolDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public VisibilityGreen Visibility { get { return this.visibility; } }
	    public Visit_Green Visit_ { get { return this.visit_; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen> ClassModifier { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen>(this.classModifier); } }
	    public Symbol_Green Symbol_ { get { return this.symbol_; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ClassAncestorsGreen ClassAncestors { get { return this.classAncestors; } }
	    public ClassBodyGreen ClassBody { get { return this.classBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.SymbolDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.visibility;
	            case 2: return this.visit_;
	            case 3: return this.classModifier;
	            case 4: return this.symbol_;
	            case 5: return this.name;
	            case 6: return this.tColon;
	            case 7: return this.classAncestors;
	            case 8: return this.classBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSymbolDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSymbolDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SymbolDeclarationGreen(this.Kind, this.attribute, this.visibility, this.visit_, this.classModifier, this.symbol_, this.name, this.tColon, this.classAncestors, this.classBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SymbolDeclarationGreen(this.Kind, this.attribute, this.visibility, this.visit_, this.classModifier, this.symbol_, this.name, this.tColon, this.classAncestors, this.classBody, this.GetDiagnostics(), annotations);
	    }
	
	    public SymbolDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, Visit_Green visit_, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen> classModifier, Symbol_Green symbol_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.Visit_ != visit_ ||
				this.ClassModifier != classModifier ||
				this.Symbol_ != symbol_ ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SymbolDeclaration(attribute, visibility, visit_, classModifier, symbol_, name, tColon, classAncestors, classBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SymbolDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Symbol_Green : GreenSyntaxNode
	{
	    internal static readonly Symbol_Green __Missing = new Symbol_Green();
	    private InternalSyntaxToken kSymbol;
	
	    public Symbol_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kSymbol)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kSymbol != null)
			{
				this.AdjustFlagsAndWidth(kSymbol);
				this.kSymbol = kSymbol;
			}
	    }
	
	    public Symbol_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kSymbol, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kSymbol != null)
			{
				this.AdjustFlagsAndWidth(kSymbol);
				this.kSymbol = kSymbol;
			}
	    }
	
		private Symbol_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Symbol_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KSymbol { get { return this.kSymbol; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Symbol_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSymbol;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSymbol_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSymbol_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Symbol_Green(this.Kind, this.kSymbol, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Symbol_Green(this.Kind, this.kSymbol, this.GetDiagnostics(), annotations);
	    }
	
	    public Symbol_Green Update(InternalSyntaxToken kSymbol)
	    {
	        if (this.KSymbol != kSymbol)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Symbol_(kSymbol);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Symbol_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FieldDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly FieldDeclarationGreen __Missing = new FieldDeclarationGreen();
	    private GreenNode attribute;
	    private VisibilityGreen visibility;
	    private GreenNode memberModifier;
	    private FieldContainmentGreen fieldContainment;
	    private FieldKindGreen fieldKind;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private DefaultValueGreen defaultValue;
	    private PhaseGreen phase;
	    private InternalSyntaxToken tSemicolon;
	
	    public FieldDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, GreenNode memberModifier, FieldContainmentGreen fieldContainment, FieldKindGreen fieldKind, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 10;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (memberModifier != null)
			{
				this.AdjustFlagsAndWidth(memberModifier);
				this.memberModifier = memberModifier;
			}
			if (fieldContainment != null)
			{
				this.AdjustFlagsAndWidth(fieldContainment);
				this.fieldContainment = fieldContainment;
			}
			if (fieldKind != null)
			{
				this.AdjustFlagsAndWidth(fieldKind);
				this.fieldKind = fieldKind;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (defaultValue != null)
			{
				this.AdjustFlagsAndWidth(defaultValue);
				this.defaultValue = defaultValue;
			}
			if (phase != null)
			{
				this.AdjustFlagsAndWidth(phase);
				this.phase = phase;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public FieldDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, GreenNode memberModifier, FieldContainmentGreen fieldContainment, FieldKindGreen fieldKind, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 10;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (memberModifier != null)
			{
				this.AdjustFlagsAndWidth(memberModifier);
				this.memberModifier = memberModifier;
			}
			if (fieldContainment != null)
			{
				this.AdjustFlagsAndWidth(fieldContainment);
				this.fieldContainment = fieldContainment;
			}
			if (fieldKind != null)
			{
				this.AdjustFlagsAndWidth(fieldKind);
				this.fieldKind = fieldKind;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (defaultValue != null)
			{
				this.AdjustFlagsAndWidth(defaultValue);
				this.defaultValue = defaultValue;
			}
			if (phase != null)
			{
				this.AdjustFlagsAndWidth(phase);
				this.phase = phase;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private FieldDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public VisibilityGreen Visibility { get { return this.visibility; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen> MemberModifier { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen>(this.memberModifier); } }
	    public FieldContainmentGreen FieldContainment { get { return this.fieldContainment; } }
	    public FieldKindGreen FieldKind { get { return this.fieldKind; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public DefaultValueGreen DefaultValue { get { return this.defaultValue; } }
	    public PhaseGreen Phase { get { return this.phase; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.FieldDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.visibility;
	            case 2: return this.memberModifier;
	            case 3: return this.fieldContainment;
	            case 4: return this.fieldKind;
	            case 5: return this.typeReference;
	            case 6: return this.name;
	            case 7: return this.defaultValue;
	            case 8: return this.phase;
	            case 9: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitFieldDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitFieldDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.attribute, this.visibility, this.memberModifier, this.fieldContainment, this.fieldKind, this.typeReference, this.name, this.defaultValue, this.phase, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.attribute, this.visibility, this.memberModifier, this.fieldContainment, this.fieldKind, this.typeReference, this.name, this.defaultValue, this.phase, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen> memberModifier, FieldContainmentGreen fieldContainment, FieldKindGreen fieldKind, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.MemberModifier != memberModifier ||
				this.FieldContainment != fieldContainment ||
				this.FieldKind != fieldKind ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue ||
				this.Phase != phase ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(attribute, visibility, memberModifier, fieldContainment, fieldKind, typeReference, name, defaultValue, phase, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FieldContainmentGreen : GreenSyntaxNode
	{
	    internal static readonly FieldContainmentGreen __Missing = new FieldContainmentGreen();
	    private InternalSyntaxToken kContainment;
	
	    public FieldContainmentGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kContainment)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kContainment != null)
			{
				this.AdjustFlagsAndWidth(kContainment);
				this.kContainment = kContainment;
			}
	    }
	
	    public FieldContainmentGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kContainment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kContainment != null)
			{
				this.AdjustFlagsAndWidth(kContainment);
				this.kContainment = kContainment;
			}
	    }
	
		private FieldContainmentGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldContainment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KContainment { get { return this.kContainment; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.FieldContainmentSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kContainment;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitFieldContainmentGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitFieldContainmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldContainmentGreen(this.Kind, this.kContainment, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldContainmentGreen(this.Kind, this.kContainment, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldContainmentGreen Update(InternalSyntaxToken kContainment)
	    {
	        if (this.KContainment != kContainment)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldContainment(kContainment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldContainmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FieldKindGreen : GreenSyntaxNode
	{
	    internal static readonly FieldKindGreen __Missing = new FieldKindGreen();
	    private InternalSyntaxToken fieldKind;
	
	    public FieldKindGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken fieldKind)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (fieldKind != null)
			{
				this.AdjustFlagsAndWidth(fieldKind);
				this.fieldKind = fieldKind;
			}
	    }
	
	    public FieldKindGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken fieldKind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (fieldKind != null)
			{
				this.AdjustFlagsAndWidth(fieldKind);
				this.fieldKind = fieldKind;
			}
	    }
	
		private FieldKindGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldKind, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken FieldKind { get { return this.fieldKind; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.FieldKindSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldKind;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitFieldKindGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitFieldKindGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldKindGreen(this.Kind, this.fieldKind, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldKindGreen(this.Kind, this.fieldKind, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldKindGreen Update(InternalSyntaxToken fieldKind)
	    {
	        if (this.FieldKind != fieldKind)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldKind(fieldKind);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldKindGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MemberModifierGreen : GreenSyntaxNode
	{
	    internal static readonly MemberModifierGreen __Missing = new MemberModifierGreen();
	    private Partial_Green partial_;
	    private Static_Green static_;
	    private Virtual_Green virtual_;
	    private Abstract_Green abstract_;
	    private Sealed_Green sealed_;
	    private New_Green new_;
	    private Override_Green override_;
	
	    public MemberModifierGreen(MetaCompilerSyntaxKind kind, Partial_Green partial_, Static_Green static_, Virtual_Green virtual_, Abstract_Green abstract_, Sealed_Green sealed_, New_Green new_, Override_Green override_)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (partial_ != null)
			{
				this.AdjustFlagsAndWidth(partial_);
				this.partial_ = partial_;
			}
			if (static_ != null)
			{
				this.AdjustFlagsAndWidth(static_);
				this.static_ = static_;
			}
			if (virtual_ != null)
			{
				this.AdjustFlagsAndWidth(virtual_);
				this.virtual_ = virtual_;
			}
			if (abstract_ != null)
			{
				this.AdjustFlagsAndWidth(abstract_);
				this.abstract_ = abstract_;
			}
			if (sealed_ != null)
			{
				this.AdjustFlagsAndWidth(sealed_);
				this.sealed_ = sealed_;
			}
			if (new_ != null)
			{
				this.AdjustFlagsAndWidth(new_);
				this.new_ = new_;
			}
			if (override_ != null)
			{
				this.AdjustFlagsAndWidth(override_);
				this.override_ = override_;
			}
	    }
	
	    public MemberModifierGreen(MetaCompilerSyntaxKind kind, Partial_Green partial_, Static_Green static_, Virtual_Green virtual_, Abstract_Green abstract_, Sealed_Green sealed_, New_Green new_, Override_Green override_, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (partial_ != null)
			{
				this.AdjustFlagsAndWidth(partial_);
				this.partial_ = partial_;
			}
			if (static_ != null)
			{
				this.AdjustFlagsAndWidth(static_);
				this.static_ = static_;
			}
			if (virtual_ != null)
			{
				this.AdjustFlagsAndWidth(virtual_);
				this.virtual_ = virtual_;
			}
			if (abstract_ != null)
			{
				this.AdjustFlagsAndWidth(abstract_);
				this.abstract_ = abstract_;
			}
			if (sealed_ != null)
			{
				this.AdjustFlagsAndWidth(sealed_);
				this.sealed_ = sealed_;
			}
			if (new_ != null)
			{
				this.AdjustFlagsAndWidth(new_);
				this.new_ = new_;
			}
			if (override_ != null)
			{
				this.AdjustFlagsAndWidth(override_);
				this.override_ = override_;
			}
	    }
	
		private MemberModifierGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.MemberModifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Partial_Green Partial_ { get { return this.partial_; } }
	    public Static_Green Static_ { get { return this.static_; } }
	    public Virtual_Green Virtual_ { get { return this.virtual_; } }
	    public Abstract_Green Abstract_ { get { return this.abstract_; } }
	    public Sealed_Green Sealed_ { get { return this.sealed_; } }
	    public New_Green New_ { get { return this.new_; } }
	    public Override_Green Override_ { get { return this.override_; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.MemberModifierSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.partial_;
	            case 1: return this.static_;
	            case 2: return this.virtual_;
	            case 3: return this.abstract_;
	            case 4: return this.sealed_;
	            case 5: return this.new_;
	            case 6: return this.override_;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitMemberModifierGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitMemberModifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MemberModifierGreen(this.Kind, this.partial_, this.static_, this.virtual_, this.abstract_, this.sealed_, this.new_, this.override_, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MemberModifierGreen(this.Kind, this.partial_, this.static_, this.virtual_, this.abstract_, this.sealed_, this.new_, this.override_, this.GetDiagnostics(), annotations);
	    }
	
	    public MemberModifierGreen Update(Partial_Green partial_)
	    {
	        if (this.partial_ != partial_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(partial_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierGreen Update(Static_Green static_)
	    {
	        if (this.static_ != static_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(static_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierGreen Update(Virtual_Green virtual_)
	    {
	        if (this.virtual_ != virtual_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(virtual_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierGreen Update(Abstract_Green abstract_)
	    {
	        if (this.abstract_ != abstract_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(abstract_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierGreen Update(Sealed_Green sealed_)
	    {
	        if (this.sealed_ != sealed_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(sealed_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierGreen Update(New_Green new_)
	    {
	        if (this.new_ != new_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(new_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierGreen Update(Override_Green override_)
	    {
	        if (this.override_ != override_)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier(override_);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefaultValueGreen : GreenSyntaxNode
	{
	    internal static readonly DefaultValueGreen __Missing = new DefaultValueGreen();
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public DefaultValueGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
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
	
	    public DefaultValueGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
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
	
		private DefaultValueGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.DefaultValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.DefaultValueSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tAssign;
	            case 1: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitDefaultValueGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitDefaultValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefaultValueGreen(this.Kind, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefaultValueGreen(this.Kind, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public DefaultValueGreen Update(InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.DefaultValue(tAssign, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PhaseGreen : GreenSyntaxNode
	{
	    internal static readonly PhaseGreen __Missing = new PhaseGreen();
	    private InternalSyntaxToken kPhase;
	    private PhaseRefGreen phaseRef;
	
	    public PhaseGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPhase, PhaseRefGreen phaseRef)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
	    public PhaseGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPhase, PhaseRefGreen phaseRef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (phaseRef != null)
			{
				this.AdjustFlagsAndWidth(phaseRef);
				this.phaseRef = phaseRef;
			}
	    }
	
		private PhaseGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Phase, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KPhase { get { return this.kPhase; } }
	    public PhaseRefGreen PhaseRef { get { return this.phaseRef; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.PhaseSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPhase;
	            case 1: return this.phaseRef;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPhaseGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPhaseGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PhaseGreen(this.Kind, this.kPhase, this.phaseRef, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PhaseGreen(this.Kind, this.kPhase, this.phaseRef, this.GetDiagnostics(), annotations);
	    }
	
	    public PhaseGreen Update(InternalSyntaxToken kPhase, PhaseRefGreen phaseRef)
	    {
	        if (this.KPhase != kPhase ||
				this.PhaseRef != phaseRef)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Phase(kPhase, phaseRef);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameUseListGreen : GreenSyntaxNode
	{
	    internal static readonly NameUseListGreen __Missing = new NameUseListGreen();
	    private GreenNode qualifier;
	
	    public NameUseListGreen(MetaCompilerSyntaxKind kind, GreenNode qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public NameUseListGreen(MetaCompilerSyntaxKind kind, GreenNode qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private NameUseListGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NameUseList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> Qualifier { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen>(this.qualifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.NameUseListSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNameUseListGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNameUseListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameUseListGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameUseListGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NameUseListGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.NameUseList(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameUseListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypedefDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly TypedefDeclarationGreen __Missing = new TypedefDeclarationGreen();
	    private InternalSyntaxToken kTypeDef;
	    private NameGreen name;
	    private TypedefValueGreen typedefValue;
	    private InternalSyntaxToken tSemicolon;
	
	    public TypedefDeclarationGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kTypeDef, NameGreen name, TypedefValueGreen typedefValue, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
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
			if (typedefValue != null)
			{
				this.AdjustFlagsAndWidth(typedefValue);
				this.typedefValue = typedefValue;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public TypedefDeclarationGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kTypeDef, NameGreen name, TypedefValueGreen typedefValue, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
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
			if (typedefValue != null)
			{
				this.AdjustFlagsAndWidth(typedefValue);
				this.typedefValue = typedefValue;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private TypedefDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypedefDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeDef { get { return this.kTypeDef; } }
	    public NameGreen Name { get { return this.name; } }
	    public TypedefValueGreen TypedefValue { get { return this.typedefValue; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypedefDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeDef;
	            case 1: return this.name;
	            case 2: return this.typedefValue;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypedefDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypedefDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypedefDeclarationGreen(this.Kind, this.kTypeDef, this.name, this.typedefValue, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypedefDeclarationGreen(this.Kind, this.kTypeDef, this.name, this.typedefValue, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public TypedefDeclarationGreen Update(InternalSyntaxToken kTypeDef, NameGreen name, TypedefValueGreen typedefValue, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KTypeDef != kTypeDef ||
				this.Name != name ||
				this.TypedefValue != typedefValue ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypedefDeclaration(kTypeDef, name, typedefValue, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypedefDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypedefValueGreen : GreenSyntaxNode
	{
	    internal static readonly TypedefValueGreen __Missing = new TypedefValueGreen();
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public TypedefValueGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
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
	
	    public TypedefValueGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
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
	
		private TypedefValueGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypedefValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypedefValueSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tAssign;
	            case 1: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypedefValueGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypedefValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypedefValueGreen(this.Kind, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypedefValueGreen(this.Kind, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public TypedefValueGreen Update(InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypedefValue(tAssign, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypedefValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnTypeGreen __Missing = new ReturnTypeGreen();
	    private TypeReferenceGreen typeReference;
	    private VoidTypeGreen voidType;
	
	    public ReturnTypeGreen(MetaCompilerSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType)
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
	
	    public ReturnTypeGreen(MetaCompilerSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ReturnType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ReturnTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitReturnTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
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
	
	internal class TypeOfReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly TypeOfReferenceGreen __Missing = new TypeOfReferenceGreen();
	    private TypeReferenceGreen typeReference;
	
	    public TypeOfReferenceGreen(MetaCompilerSyntaxKind kind, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypeOfReferenceGreen(MetaCompilerSyntaxKind kind, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private TypeOfReferenceGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeOfReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypeOfReferenceSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypeOfReferenceGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypeOfReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeOfReferenceGreen(this.Kind, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeOfReferenceGreen(this.Kind, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeOfReferenceGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeOfReference(typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeOfReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly TypeReferenceGreen __Missing = new TypeReferenceGreen();
	    private SimpleOrDictionaryTypeGreen simpleOrDictionaryType;
	
	    public TypeReferenceGreen(MetaCompilerSyntaxKind kind, SimpleOrDictionaryTypeGreen simpleOrDictionaryType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (simpleOrDictionaryType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrDictionaryType);
				this.simpleOrDictionaryType = simpleOrDictionaryType;
			}
	    }
	
	    public TypeReferenceGreen(MetaCompilerSyntaxKind kind, SimpleOrDictionaryTypeGreen simpleOrDictionaryType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (simpleOrDictionaryType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrDictionaryType);
				this.simpleOrDictionaryType = simpleOrDictionaryType;
			}
	    }
	
		private TypeReferenceGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleOrDictionaryTypeGreen SimpleOrDictionaryType { get { return this.simpleOrDictionaryType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypeReferenceSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleOrDictionaryType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.simpleOrDictionaryType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.simpleOrDictionaryType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(SimpleOrDictionaryTypeGreen simpleOrDictionaryType)
	    {
	        if (this.SimpleOrDictionaryType != simpleOrDictionaryType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleOrDictionaryType);
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
	
	internal class SimpleOrDictionaryTypeGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleOrDictionaryTypeGreen __Missing = new SimpleOrDictionaryTypeGreen();
	    private SimpleOrArrayTypeGreen simpleOrArrayType;
	    private DictionaryTypeGreen dictionaryType;
	
	    public SimpleOrDictionaryTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrArrayTypeGreen simpleOrArrayType, DictionaryTypeGreen dictionaryType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (simpleOrArrayType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrArrayType);
				this.simpleOrArrayType = simpleOrArrayType;
			}
			if (dictionaryType != null)
			{
				this.AdjustFlagsAndWidth(dictionaryType);
				this.dictionaryType = dictionaryType;
			}
	    }
	
	    public SimpleOrDictionaryTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrArrayTypeGreen simpleOrArrayType, DictionaryTypeGreen dictionaryType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (simpleOrArrayType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrArrayType);
				this.simpleOrArrayType = simpleOrArrayType;
			}
			if (dictionaryType != null)
			{
				this.AdjustFlagsAndWidth(dictionaryType);
				this.dictionaryType = dictionaryType;
			}
	    }
	
		private SimpleOrDictionaryTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrDictionaryType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleOrArrayTypeGreen SimpleOrArrayType { get { return this.simpleOrArrayType; } }
	    public DictionaryTypeGreen DictionaryType { get { return this.dictionaryType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.SimpleOrDictionaryTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleOrArrayType;
	            case 1: return this.dictionaryType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleOrDictionaryTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSimpleOrDictionaryTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleOrDictionaryTypeGreen(this.Kind, this.simpleOrArrayType, this.dictionaryType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleOrDictionaryTypeGreen(this.Kind, this.simpleOrArrayType, this.dictionaryType, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleOrDictionaryTypeGreen Update(SimpleOrArrayTypeGreen simpleOrArrayType)
	    {
	        if (this.simpleOrArrayType != simpleOrArrayType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrDictionaryType(simpleOrArrayType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrDictionaryTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public SimpleOrDictionaryTypeGreen Update(DictionaryTypeGreen dictionaryType)
	    {
	        if (this.dictionaryType != dictionaryType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrDictionaryType(dictionaryType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrDictionaryTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleOrArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleOrArrayTypeGreen __Missing = new SimpleOrArrayTypeGreen();
	    private SimpleOrGenericTypeGreen simpleOrGenericType;
	    private ArrayTypeGreen arrayType;
	
	    public SimpleOrArrayTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrGenericTypeGreen simpleOrGenericType, ArrayTypeGreen arrayType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (simpleOrGenericType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrGenericType);
				this.simpleOrGenericType = simpleOrGenericType;
			}
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
	    }
	
	    public SimpleOrArrayTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrGenericTypeGreen simpleOrGenericType, ArrayTypeGreen arrayType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (simpleOrGenericType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrGenericType);
				this.simpleOrGenericType = simpleOrGenericType;
			}
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
	    }
	
		private SimpleOrArrayTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleOrGenericTypeGreen SimpleOrGenericType { get { return this.simpleOrGenericType; } }
	    public ArrayTypeGreen ArrayType { get { return this.arrayType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.SimpleOrArrayTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleOrGenericType;
	            case 1: return this.arrayType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleOrArrayTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSimpleOrArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleOrArrayTypeGreen(this.Kind, this.simpleOrGenericType, this.arrayType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleOrArrayTypeGreen(this.Kind, this.simpleOrGenericType, this.arrayType, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleOrArrayTypeGreen Update(SimpleOrGenericTypeGreen simpleOrGenericType)
	    {
	        if (this.simpleOrGenericType != simpleOrGenericType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrArrayType(simpleOrGenericType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrArrayTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public SimpleOrArrayTypeGreen Update(ArrayTypeGreen arrayType)
	    {
	        if (this.arrayType != arrayType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrArrayType(arrayType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrArrayTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleOrGenericTypeGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleOrGenericTypeGreen __Missing = new SimpleOrGenericTypeGreen();
	    private SimpleTypeGreen simpleType;
	    private GenericTypeGreen genericType;
	
	    public SimpleOrGenericTypeGreen(MetaCompilerSyntaxKind kind, SimpleTypeGreen simpleType, GenericTypeGreen genericType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
	    }
	
	    public SimpleOrGenericTypeGreen(MetaCompilerSyntaxKind kind, SimpleTypeGreen simpleType, GenericTypeGreen genericType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
			if (genericType != null)
			{
				this.AdjustFlagsAndWidth(genericType);
				this.genericType = genericType;
			}
	    }
	
		private SimpleOrGenericTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrGenericType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public GenericTypeGreen GenericType { get { return this.genericType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.SimpleOrGenericTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleType;
	            case 1: return this.genericType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleOrGenericTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSimpleOrGenericTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleOrGenericTypeGreen(this.Kind, this.simpleType, this.genericType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleOrGenericTypeGreen(this.Kind, this.simpleType, this.genericType, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleOrGenericTypeGreen Update(SimpleTypeGreen simpleType)
	    {
	        if (this.simpleType != simpleType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrGenericType(simpleType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrGenericTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public SimpleOrGenericTypeGreen Update(GenericTypeGreen genericType)
	    {
	        if (this.genericType != genericType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrGenericType(genericType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrGenericTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleTypeGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleTypeGreen __Missing = new SimpleTypeGreen();
	    private PrimitiveTypeGreen primitiveType;
	    private ObjectTypeGreen objectType;
	    private NullableTypeGreen nullableType;
	    private ClassTypeGreen classType;
	
	    public SimpleTypeGreen(MetaCompilerSyntaxKind kind, PrimitiveTypeGreen primitiveType, ObjectTypeGreen objectType, NullableTypeGreen nullableType, ClassTypeGreen classType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (classType != null)
			{
				this.AdjustFlagsAndWidth(classType);
				this.classType = classType;
			}
	    }
	
	    public SimpleTypeGreen(MetaCompilerSyntaxKind kind, PrimitiveTypeGreen primitiveType, ObjectTypeGreen objectType, NullableTypeGreen nullableType, ClassTypeGreen classType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (classType != null)
			{
				this.AdjustFlagsAndWidth(classType);
				this.classType = classType;
			}
	    }
	
		private SimpleTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public ClassTypeGreen ClassType { get { return this.classType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.SimpleTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            case 1: return this.objectType;
	            case 2: return this.nullableType;
	            case 3: return this.classType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleTypeGreen(this.Kind, this.primitiveType, this.objectType, this.nullableType, this.classType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleTypeGreen(this.Kind, this.primitiveType, this.objectType, this.nullableType, this.classType, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleTypeGreen Update(PrimitiveTypeGreen primitiveType)
	    {
	        if (this.primitiveType != primitiveType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType(primitiveType);
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
	
	    public SimpleTypeGreen Update(ObjectTypeGreen objectType)
	    {
	        if (this.objectType != objectType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType(objectType);
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
	
	    public SimpleTypeGreen Update(NullableTypeGreen nullableType)
	    {
	        if (this.nullableType != nullableType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType(nullableType);
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
	
	    public SimpleTypeGreen Update(ClassTypeGreen classType)
	    {
	        if (this.classType != classType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType(classType);
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
	
	internal class ClassTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ClassTypeGreen __Missing = new ClassTypeGreen();
	    private QualifierGreen qualifier;
	
	    public ClassTypeGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ClassTypeGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private ClassTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassTypeGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassTypeGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassTypeGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassType(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectTypeGreen __Missing = new ObjectTypeGreen();
	    private InternalSyntaxToken objectType;
	
	    public ObjectTypeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken objectType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
	    public ObjectTypeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken objectType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
		private ObjectTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ObjectType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ObjectType { get { return this.objectType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ObjectTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.objectType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitObjectTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitObjectTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectTypeGreen(this.Kind, this.objectType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectTypeGreen(this.Kind, this.objectType, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectTypeGreen Update(InternalSyntaxToken objectType)
	    {
	        if (this.ObjectType != objectType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ObjectType(objectType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PrimitiveTypeGreen : GreenSyntaxNode
	{
	    internal static readonly PrimitiveTypeGreen __Missing = new PrimitiveTypeGreen();
	    private InternalSyntaxToken primitiveType;
	
	    public PrimitiveTypeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken primitiveType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
	    public PrimitiveTypeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken primitiveType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
		private PrimitiveTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PrimitiveType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken PrimitiveType { get { return this.primitiveType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.PrimitiveTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPrimitiveTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPrimitiveTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PrimitiveTypeGreen(this.Kind, this.primitiveType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PrimitiveTypeGreen(this.Kind, this.primitiveType, this.GetDiagnostics(), annotations);
	    }
	
	    public PrimitiveTypeGreen Update(InternalSyntaxToken primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.PrimitiveType(primitiveType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VoidTypeGreen : GreenSyntaxNode
	{
	    internal static readonly VoidTypeGreen __Missing = new VoidTypeGreen();
	    private InternalSyntaxToken kVoid;
	
	    public VoidTypeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.VoidType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.VoidTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitVoidTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
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
	
	internal class NullableTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NullableTypeGreen __Missing = new NullableTypeGreen();
	    private PrimitiveTypeGreen primitiveType;
	    private InternalSyntaxToken tQuestion;
	
	    public NullableTypeGreen(MetaCompilerSyntaxKind kind, PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
	    public NullableTypeGreen(MetaCompilerSyntaxKind kind, PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
		private NullableTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NullableType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.NullableTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            case 1: return this.tQuestion;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableTypeGreen(this.Kind, this.primitiveType, this.tQuestion, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableTypeGreen(this.Kind, this.primitiveType, this.tQuestion, this.GetDiagnostics(), annotations);
	    }
	
	    public NullableTypeGreen Update(PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion)
	    {
	        if (this.PrimitiveType != primitiveType ||
				this.TQuestion != tQuestion)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.NullableType(primitiveType, tQuestion);
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
	
	internal class GenericTypeGreen : GreenSyntaxNode
	{
	    internal static readonly GenericTypeGreen __Missing = new GenericTypeGreen();
	    private ClassTypeGreen classType;
	    private InternalSyntaxToken tLessThan;
	    private TypeArgumentsGreen typeArguments;
	    private InternalSyntaxToken tGreaterThan;
	
	    public GenericTypeGreen(MetaCompilerSyntaxKind kind, ClassTypeGreen classType, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (classType != null)
			{
				this.AdjustFlagsAndWidth(classType);
				this.classType = classType;
			}
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (typeArguments != null)
			{
				this.AdjustFlagsAndWidth(typeArguments);
				this.typeArguments = typeArguments;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
	    public GenericTypeGreen(MetaCompilerSyntaxKind kind, ClassTypeGreen classType, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (classType != null)
			{
				this.AdjustFlagsAndWidth(classType);
				this.classType = classType;
			}
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (typeArguments != null)
			{
				this.AdjustFlagsAndWidth(typeArguments);
				this.typeArguments = typeArguments;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
		private GenericTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.GenericType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ClassTypeGreen ClassType { get { return this.classType; } }
	    public InternalSyntaxToken TLessThan { get { return this.tLessThan; } }
	    public TypeArgumentsGreen TypeArguments { get { return this.typeArguments; } }
	    public InternalSyntaxToken TGreaterThan { get { return this.tGreaterThan; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.GenericTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.classType;
	            case 1: return this.tLessThan;
	            case 2: return this.typeArguments;
	            case 3: return this.tGreaterThan;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitGenericTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitGenericTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericTypeGreen(this.Kind, this.classType, this.tLessThan, this.typeArguments, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeGreen(this.Kind, this.classType, this.tLessThan, this.typeArguments, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public GenericTypeGreen Update(ClassTypeGreen classType, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.ClassType != classType ||
				this.TLessThan != tLessThan ||
				this.TypeArguments != typeArguments ||
				this.TGreaterThan != tGreaterThan)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.GenericType(classType, tLessThan, typeArguments, tGreaterThan);
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
	
	internal class TypeArgumentsGreen : GreenSyntaxNode
	{
	    internal static readonly TypeArgumentsGreen __Missing = new TypeArgumentsGreen();
	    private GreenNode typeReference;
	
	    public TypeArgumentsGreen(MetaCompilerSyntaxKind kind, GreenNode typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypeArgumentsGreen(MetaCompilerSyntaxKind kind, GreenNode typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private TypeArgumentsGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeArguments, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen> TypeReference { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen>(this.typeReference); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypeArgumentsSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypeArgumentsGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypeArgumentsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeArgumentsGreen(this.Kind, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeArgumentsGreen(this.Kind, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeArgumentsGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen> typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeArguments(typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeArgumentsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ArrayTypeGreen __Missing = new ArrayTypeGreen();
	    private SimpleOrGenericTypeGreen simpleOrGenericType;
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken tCloseBracket;
	
	    public ArrayTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrGenericTypeGreen simpleOrGenericType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (simpleOrGenericType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrGenericType);
				this.simpleOrGenericType = simpleOrGenericType;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public ArrayTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrGenericTypeGreen simpleOrGenericType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (simpleOrGenericType != null)
			{
				this.AdjustFlagsAndWidth(simpleOrGenericType);
				this.simpleOrGenericType = simpleOrGenericType;
			}
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private ArrayTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleOrGenericTypeGreen SimpleOrGenericType { get { return this.simpleOrGenericType; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ArrayTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleOrGenericType;
	            case 1: return this.tOpenBracket;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitArrayTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrayTypeGreen(this.Kind, this.simpleOrGenericType, this.tOpenBracket, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrayTypeGreen(this.Kind, this.simpleOrGenericType, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrayTypeGreen Update(SimpleOrGenericTypeGreen simpleOrGenericType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.SimpleOrGenericType != simpleOrGenericType ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ArrayType(simpleOrGenericType, tOpenBracket, tCloseBracket);
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
	
	internal class DictionaryTypeGreen : GreenSyntaxNode
	{
	    internal static readonly DictionaryTypeGreen __Missing = new DictionaryTypeGreen();
	    private SimpleOrArrayTypeGreen key;
	    private InternalSyntaxToken tRightArrow;
	    private SimpleOrArrayTypeGreen value;
	
	    public DictionaryTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrArrayTypeGreen key, InternalSyntaxToken tRightArrow, SimpleOrArrayTypeGreen value)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (key != null)
			{
				this.AdjustFlagsAndWidth(key);
				this.key = key;
			}
			if (tRightArrow != null)
			{
				this.AdjustFlagsAndWidth(tRightArrow);
				this.tRightArrow = tRightArrow;
			}
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
	    public DictionaryTypeGreen(MetaCompilerSyntaxKind kind, SimpleOrArrayTypeGreen key, InternalSyntaxToken tRightArrow, SimpleOrArrayTypeGreen value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (key != null)
			{
				this.AdjustFlagsAndWidth(key);
				this.key = key;
			}
			if (tRightArrow != null)
			{
				this.AdjustFlagsAndWidth(tRightArrow);
				this.tRightArrow = tRightArrow;
			}
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
		private DictionaryTypeGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.DictionaryType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleOrArrayTypeGreen Key { get { return this.key; } }
	    public InternalSyntaxToken TRightArrow { get { return this.tRightArrow; } }
	    public SimpleOrArrayTypeGreen Value { get { return this.value; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.DictionaryTypeSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.key;
	            case 1: return this.tRightArrow;
	            case 2: return this.value;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitDictionaryTypeGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitDictionaryTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DictionaryTypeGreen(this.Kind, this.key, this.tRightArrow, this.value, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DictionaryTypeGreen(this.Kind, this.key, this.tRightArrow, this.value, this.GetDiagnostics(), annotations);
	    }
	
	    public DictionaryTypeGreen Update(SimpleOrArrayTypeGreen key, InternalSyntaxToken tRightArrow, SimpleOrArrayTypeGreen value)
	    {
	        if (this.Key != key ||
				this.TRightArrow != tRightArrow ||
				this.Value != value)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.DictionaryType(key, tRightArrow, value);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DictionaryTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly OperationDeclarationGreen __Missing = new OperationDeclarationGreen();
	    private GreenNode attribute;
	    private VisibilityGreen visibility;
	    private GreenNode memberModifier;
	    private ReturnTypeGreen returnType;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private ParameterListGreen parameterList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tSemicolon;
	
	    public OperationDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, GreenNode memberModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 9;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (memberModifier != null)
			{
				this.AdjustFlagsAndWidth(memberModifier);
				this.memberModifier = memberModifier;
			}
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
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
			if (parameterList != null)
			{
				this.AdjustFlagsAndWidth(parameterList);
				this.parameterList = parameterList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public OperationDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, VisibilityGreen visibility, GreenNode memberModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 9;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (visibility != null)
			{
				this.AdjustFlagsAndWidth(visibility);
				this.visibility = visibility;
			}
			if (memberModifier != null)
			{
				this.AdjustFlagsAndWidth(memberModifier);
				this.memberModifier = memberModifier;
			}
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
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
			if (parameterList != null)
			{
				this.AdjustFlagsAndWidth(parameterList);
				this.parameterList = parameterList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private OperationDeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.OperationDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public VisibilityGreen Visibility { get { return this.visibility; } }
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen> MemberModifier { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen>(this.memberModifier); } }
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ParameterListGreen ParameterList { get { return this.parameterList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.OperationDeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.visibility;
	            case 2: return this.memberModifier;
	            case 3: return this.returnType;
	            case 4: return this.name;
	            case 5: return this.tOpenParen;
	            case 6: return this.parameterList;
	            case 7: return this.tCloseParen;
	            case 8: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.attribute, this.visibility, this.memberModifier, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.attribute, this.visibility, this.memberModifier, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationDeclarationGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen> memberModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.MemberModifier != memberModifier ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(attribute, visibility, memberModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParameterListGreen : GreenSyntaxNode
	{
	    internal static readonly ParameterListGreen __Missing = new ParameterListGreen();
	    private GreenNode parameter;
	
	    public ParameterListGreen(MetaCompilerSyntaxKind kind, GreenNode parameter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
	    public ParameterListGreen(MetaCompilerSyntaxKind kind, GreenNode parameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
		private ParameterListGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ParameterList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> Parameter { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen>(this.parameter); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ParameterListSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parameter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParameterListGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitParameterListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterListGreen(this.Kind, this.parameter, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterListGreen(this.Kind, this.parameter, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterListGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
	    {
	        if (this.Parameter != parameter)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ParameterList(parameter);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParameterGreen : GreenSyntaxNode
	{
	    internal static readonly ParameterGreen __Missing = new ParameterGreen();
	    private GreenNode attribute;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private DefaultValueGreen defaultValue;
	
	    public ParameterGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (defaultValue != null)
			{
				this.AdjustFlagsAndWidth(defaultValue);
				this.defaultValue = defaultValue;
			}
	    }
	
	    public ParameterGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (defaultValue != null)
			{
				this.AdjustFlagsAndWidth(defaultValue);
				this.defaultValue = defaultValue;
			}
	    }
	
		private ParameterGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Parameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public DefaultValueGreen DefaultValue { get { return this.defaultValue; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ParameterSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.typeReference;
	            case 2: return this.name;
	            case 3: return this.defaultValue;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParameterGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterGreen(this.Kind, this.attribute, this.typeReference, this.name, this.defaultValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterGreen(this.Kind, this.attribute, this.typeReference, this.name, this.defaultValue, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterGreen Update(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue)
	    {
	        if (this.Attribute != attribute ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Parameter(attribute, typeReference, name, defaultValue);
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
	
	internal class Static_Green : GreenSyntaxNode
	{
	    internal static readonly Static_Green __Missing = new Static_Green();
	    private InternalSyntaxToken kStatic;
	
	    public Static_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kStatic)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kStatic != null)
			{
				this.AdjustFlagsAndWidth(kStatic);
				this.kStatic = kStatic;
			}
	    }
	
	    public Static_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kStatic, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kStatic != null)
			{
				this.AdjustFlagsAndWidth(kStatic);
				this.kStatic = kStatic;
			}
	    }
	
		private Static_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Static_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KStatic { get { return this.kStatic; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Static_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kStatic;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitStatic_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitStatic_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Static_Green(this.Kind, this.kStatic, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Static_Green(this.Kind, this.kStatic, this.GetDiagnostics(), annotations);
	    }
	
	    public Static_Green Update(InternalSyntaxToken kStatic)
	    {
	        if (this.KStatic != kStatic)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Static_(kStatic);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Static_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Base_Green : GreenSyntaxNode
	{
	    internal static readonly Base_Green __Missing = new Base_Green();
	    private InternalSyntaxToken kBase;
	
	    public Base_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kBase)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kBase != null)
			{
				this.AdjustFlagsAndWidth(kBase);
				this.kBase = kBase;
			}
	    }
	
	    public Base_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kBase, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kBase != null)
			{
				this.AdjustFlagsAndWidth(kBase);
				this.kBase = kBase;
			}
	    }
	
		private Base_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Base_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBase { get { return this.kBase; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Base_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBase;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitBase_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitBase_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Base_Green(this.Kind, this.kBase, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Base_Green(this.Kind, this.kBase, this.GetDiagnostics(), annotations);
	    }
	
	    public Base_Green Update(InternalSyntaxToken kBase)
	    {
	        if (this.KBase != kBase)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Base_(kBase);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Base_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Meta_Green : GreenSyntaxNode
	{
	    internal static readonly Meta_Green __Missing = new Meta_Green();
	    private InternalSyntaxToken kMeta;
	
	    public Meta_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kMeta)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kMeta != null)
			{
				this.AdjustFlagsAndWidth(kMeta);
				this.kMeta = kMeta;
			}
	    }
	
	    public Meta_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kMeta, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kMeta != null)
			{
				this.AdjustFlagsAndWidth(kMeta);
				this.kMeta = kMeta;
			}
	    }
	
		private Meta_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Meta_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KMeta { get { return this.kMeta; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Meta_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kMeta;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitMeta_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitMeta_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Meta_Green(this.Kind, this.kMeta, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Meta_Green(this.Kind, this.kMeta, this.GetDiagnostics(), annotations);
	    }
	
	    public Meta_Green Update(InternalSyntaxToken kMeta)
	    {
	        if (this.KMeta != kMeta)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Meta_(kMeta);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Meta_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Source_Green : GreenSyntaxNode
	{
	    internal static readonly Source_Green __Missing = new Source_Green();
	    private InternalSyntaxToken kSource;
	
	    public Source_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kSource)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kSource != null)
			{
				this.AdjustFlagsAndWidth(kSource);
				this.kSource = kSource;
			}
	    }
	
	    public Source_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kSource, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kSource != null)
			{
				this.AdjustFlagsAndWidth(kSource);
				this.kSource = kSource;
			}
	    }
	
		private Source_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Source_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KSource { get { return this.kSource; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Source_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSource;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSource_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSource_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Source_Green(this.Kind, this.kSource, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Source_Green(this.Kind, this.kSource, this.GetDiagnostics(), annotations);
	    }
	
	    public Source_Green Update(InternalSyntaxToken kSource)
	    {
	        if (this.KSource != kSource)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Source_(kSource);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Visit_Green : GreenSyntaxNode
	{
	    internal static readonly Visit_Green __Missing = new Visit_Green();
	    private InternalSyntaxToken kVisit;
	
	    public Visit_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kVisit)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVisit != null)
			{
				this.AdjustFlagsAndWidth(kVisit);
				this.kVisit = kVisit;
			}
	    }
	
	    public Visit_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kVisit, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kVisit != null)
			{
				this.AdjustFlagsAndWidth(kVisit);
				this.kVisit = kVisit;
			}
	    }
	
		private Visit_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Visit_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVisit { get { return this.kVisit; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Visit_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVisit;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitVisit_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitVisit_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Visit_Green(this.Kind, this.kVisit, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Visit_Green(this.Kind, this.kVisit, this.GetDiagnostics(), annotations);
	    }
	
	    public Visit_Green Update(InternalSyntaxToken kVisit)
	    {
	        if (this.KVisit != kVisit)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Visit_(kVisit);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Visit_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Partial_Green : GreenSyntaxNode
	{
	    internal static readonly Partial_Green __Missing = new Partial_Green();
	    private InternalSyntaxToken kPartial;
	
	    public Partial_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPartial)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kPartial != null)
			{
				this.AdjustFlagsAndWidth(kPartial);
				this.kPartial = kPartial;
			}
	    }
	
	    public Partial_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPartial, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kPartial != null)
			{
				this.AdjustFlagsAndWidth(kPartial);
				this.kPartial = kPartial;
			}
	    }
	
		private Partial_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Partial_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KPartial { get { return this.kPartial; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Partial_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPartial;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPartial_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPartial_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Partial_Green(this.Kind, this.kPartial, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Partial_Green(this.Kind, this.kPartial, this.GetDiagnostics(), annotations);
	    }
	
	    public Partial_Green Update(InternalSyntaxToken kPartial)
	    {
	        if (this.KPartial != kPartial)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Partial_(kPartial);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Partial_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Abstract_Green : GreenSyntaxNode
	{
	    internal static readonly Abstract_Green __Missing = new Abstract_Green();
	    private InternalSyntaxToken kAbstract;
	
	    public Abstract_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kAbstract)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kAbstract != null)
			{
				this.AdjustFlagsAndWidth(kAbstract);
				this.kAbstract = kAbstract;
			}
	    }
	
	    public Abstract_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kAbstract, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kAbstract != null)
			{
				this.AdjustFlagsAndWidth(kAbstract);
				this.kAbstract = kAbstract;
			}
	    }
	
		private Abstract_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Abstract_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAbstract { get { return this.kAbstract; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Abstract_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAbstract;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitAbstract_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitAbstract_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Abstract_Green(this.Kind, this.kAbstract, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Abstract_Green(this.Kind, this.kAbstract, this.GetDiagnostics(), annotations);
	    }
	
	    public Abstract_Green Update(InternalSyntaxToken kAbstract)
	    {
	        if (this.KAbstract != kAbstract)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Abstract_(kAbstract);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Abstract_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Virtual_Green : GreenSyntaxNode
	{
	    internal static readonly Virtual_Green __Missing = new Virtual_Green();
	    private InternalSyntaxToken kVirtual;
	
	    public Virtual_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kVirtual)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVirtual != null)
			{
				this.AdjustFlagsAndWidth(kVirtual);
				this.kVirtual = kVirtual;
			}
	    }
	
	    public Virtual_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kVirtual, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kVirtual != null)
			{
				this.AdjustFlagsAndWidth(kVirtual);
				this.kVirtual = kVirtual;
			}
	    }
	
		private Virtual_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Virtual_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVirtual { get { return this.kVirtual; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Virtual_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVirtual;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitVirtual_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitVirtual_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Virtual_Green(this.Kind, this.kVirtual, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Virtual_Green(this.Kind, this.kVirtual, this.GetDiagnostics(), annotations);
	    }
	
	    public Virtual_Green Update(InternalSyntaxToken kVirtual)
	    {
	        if (this.KVirtual != kVirtual)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Virtual_(kVirtual);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Virtual_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Sealed_Green : GreenSyntaxNode
	{
	    internal static readonly Sealed_Green __Missing = new Sealed_Green();
	    private InternalSyntaxToken kSealed;
	
	    public Sealed_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kSealed)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kSealed != null)
			{
				this.AdjustFlagsAndWidth(kSealed);
				this.kSealed = kSealed;
			}
	    }
	
	    public Sealed_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kSealed, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kSealed != null)
			{
				this.AdjustFlagsAndWidth(kSealed);
				this.kSealed = kSealed;
			}
	    }
	
		private Sealed_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Sealed_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KSealed { get { return this.kSealed; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Sealed_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSealed;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSealed_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitSealed_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Sealed_Green(this.Kind, this.kSealed, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Sealed_Green(this.Kind, this.kSealed, this.GetDiagnostics(), annotations);
	    }
	
	    public Sealed_Green Update(InternalSyntaxToken kSealed)
	    {
	        if (this.KSealed != kSealed)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Sealed_(kSealed);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Sealed_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class Override_Green : GreenSyntaxNode
	{
	    internal static readonly Override_Green __Missing = new Override_Green();
	    private InternalSyntaxToken kOverride;
	
	    public Override_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kOverride)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kOverride != null)
			{
				this.AdjustFlagsAndWidth(kOverride);
				this.kOverride = kOverride;
			}
	    }
	
	    public Override_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kOverride, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kOverride != null)
			{
				this.AdjustFlagsAndWidth(kOverride);
				this.kOverride = kOverride;
			}
	    }
	
		private Override_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Override_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KOverride { get { return this.kOverride; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.Override_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kOverride;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitOverride_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitOverride_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new Override_Green(this.Kind, this.kOverride, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new Override_Green(this.Kind, this.kOverride, this.GetDiagnostics(), annotations);
	    }
	
	    public Override_Green Update(InternalSyntaxToken kOverride)
	    {
	        if (this.KOverride != kOverride)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Override_(kOverride);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Override_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class New_Green : GreenSyntaxNode
	{
	    internal static readonly New_Green __Missing = new New_Green();
	    private InternalSyntaxToken kNew;
	
	    public New_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kNew)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNew != null)
			{
				this.AdjustFlagsAndWidth(kNew);
				this.kNew = kNew;
			}
	    }
	
	    public New_Green(MetaCompilerSyntaxKind kind, InternalSyntaxToken kNew, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kNew != null)
			{
				this.AdjustFlagsAndWidth(kNew);
				this.kNew = kNew;
			}
	    }
	
		private New_Green()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.New_, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNew { get { return this.kNew; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.New_Syntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNew;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNew_Green(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNew_Green(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new New_Green(this.Kind, this.kNew, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new New_Green(this.Kind, this.kNew, this.GetDiagnostics(), annotations);
	    }
	
	    public New_Green Update(InternalSyntaxToken kNew)
	    {
	        if (this.KNew != kNew)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.New_(kNew);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (New_Green)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierGreen __Missing = new IdentifierGreen();
	    private InternalSyntaxToken identifier;
	
	    public IdentifierGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.IdentifierSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Identifier(identifier);
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
	
	    public LiteralGreen(MetaCompilerSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
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
	
	    public LiteralGreen(MetaCompilerSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Literal, null, null)
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
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.LiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	    public NullLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.NullLiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	    public BooleanLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.BooleanLiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	    public IntegerLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.IntegerLiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	    public DecimalLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.DecimalLiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	    public ScientificLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ScientificLiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	
	    public StringLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lRegularString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
	    public StringLiteralGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken lRegularString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LRegularString { get { return this.lRegularString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.StringLiteralSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lRegularString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.StringLiteral(lRegularString);
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

	internal class MetaCompilerSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitAttributeGreen(AttributeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompilerDeclarationGreen(CompilerDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitPhaseDeclarationGreen(PhaseDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitLockedGreen(LockedGreen node) => this.DefaultVisit(node);
		public virtual void VisitPhaseJoinGreen(PhaseJoinGreen node) => this.DefaultVisit(node);
		public virtual void VisitAfterPhasesGreen(AfterPhasesGreen node) => this.DefaultVisit(node);
		public virtual void VisitBeforePhasesGreen(BeforePhasesGreen node) => this.DefaultVisit(node);
		public virtual void VisitPhaseRefGreen(PhaseRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumValuesGreen(EnumValuesGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumValueGreen(EnumValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumMemberDeclarationGreen(EnumMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitVisibilityGreen(VisibilityGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassDeclarationGreen(ClassDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassModifierGreen(ClassModifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassAncestorsGreen(ClassAncestorsGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassAncestorGreen(ClassAncestorGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassBodyGreen(ClassBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassPhasesGreen(ClassPhasesGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassMemberDeclarationGreen(ClassMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClass_Green(Class_Green node) => this.DefaultVisit(node);
		public virtual void VisitSymbolDeclarationGreen(SymbolDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitSymbol_Green(Symbol_Green node) => this.DefaultVisit(node);
		public virtual void VisitFieldDeclarationGreen(FieldDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldContainmentGreen(FieldContainmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldKindGreen(FieldKindGreen node) => this.DefaultVisit(node);
		public virtual void VisitMemberModifierGreen(MemberModifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitDefaultValueGreen(DefaultValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitPhaseGreen(PhaseGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameUseListGreen(NameUseListGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypedefDeclarationGreen(TypedefDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypedefValueGreen(TypedefValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeOfReferenceGreen(TypeOfReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleOrDictionaryTypeGreen(SimpleOrDictionaryTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleOrArrayTypeGreen(SimpleOrArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleOrGenericTypeGreen(SimpleOrGenericTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassTypeGreen(ClassTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeGreen(GenericTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeArgumentsGreen(TypeArgumentsGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrayTypeGreen(ArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitDictionaryTypeGreen(DictionaryTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitStatic_Green(Static_Green node) => this.DefaultVisit(node);
		public virtual void VisitBase_Green(Base_Green node) => this.DefaultVisit(node);
		public virtual void VisitMeta_Green(Meta_Green node) => this.DefaultVisit(node);
		public virtual void VisitSource_Green(Source_Green node) => this.DefaultVisit(node);
		public virtual void VisitVisit_Green(Visit_Green node) => this.DefaultVisit(node);
		public virtual void VisitPartial_Green(Partial_Green node) => this.DefaultVisit(node);
		public virtual void VisitAbstract_Green(Abstract_Green node) => this.DefaultVisit(node);
		public virtual void VisitVirtual_Green(Virtual_Green node) => this.DefaultVisit(node);
		public virtual void VisitSealed_Green(Sealed_Green node) => this.DefaultVisit(node);
		public virtual void VisitOverride_Green(Override_Green node) => this.DefaultVisit(node);
		public virtual void VisitNew_Green(New_Green node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
	}
	
	internal class MetaCompilerSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAttributeGreen(AttributeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompilerDeclarationGreen(CompilerDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPhaseDeclarationGreen(PhaseDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLockedGreen(LockedGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPhaseJoinGreen(PhaseJoinGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAfterPhasesGreen(AfterPhasesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBeforePhasesGreen(BeforePhasesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPhaseRefGreen(PhaseRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumValuesGreen(EnumValuesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumValueGreen(EnumValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumMemberDeclarationGreen(EnumMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVisibilityGreen(VisibilityGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassDeclarationGreen(ClassDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassModifierGreen(ClassModifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassAncestorsGreen(ClassAncestorsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassAncestorGreen(ClassAncestorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassBodyGreen(ClassBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassPhasesGreen(ClassPhasesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassMemberDeclarationGreen(ClassMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClass_Green(Class_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSymbolDeclarationGreen(SymbolDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSymbol_Green(Symbol_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldDeclarationGreen(FieldDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldContainmentGreen(FieldContainmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldKindGreen(FieldKindGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMemberModifierGreen(MemberModifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDefaultValueGreen(DefaultValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPhaseGreen(PhaseGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameUseListGreen(NameUseListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypedefDeclarationGreen(TypedefDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypedefValueGreen(TypedefValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeOfReferenceGreen(TypeOfReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleOrDictionaryTypeGreen(SimpleOrDictionaryTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleOrArrayTypeGreen(SimpleOrArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleOrGenericTypeGreen(SimpleOrGenericTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassTypeGreen(ClassTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeGreen(GenericTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeArgumentsGreen(TypeArgumentsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrayTypeGreen(ArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDictionaryTypeGreen(DictionaryTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStatic_Green(Static_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitBase_Green(Base_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitMeta_Green(Meta_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSource_Green(Source_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVisit_Green(Visit_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitPartial_Green(Partial_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitAbstract_Green(Abstract_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitVirtual_Green(Virtual_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitSealed_Green(Sealed_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitOverride_Green(Override_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitNew_Green(New_Green node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
	}
	internal class MetaCompilerInternalSyntaxFactory : InternalSyntaxFactory, MetaDslx.Languages.Antlr4Roslyn.IAntlr4SyntaxFactory
	{
		public MetaCompilerInternalSyntaxFactory(MetaCompilerSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public Antlr4.Runtime.Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new MetaCompilerLexer(input);
	    }
	
	    public Antlr4.Runtime.Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new MetaCompilerParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
		{
			return new MetaCompilerSyntaxLexer(text, (MetaCompilerParseOptions)options ?? MetaCompilerParseOptions.Default);
		}
	
	    public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
		{
			return new MetaCompilerSyntaxParser(text, (MetaCompilerParseOptions)options ?? MetaCompilerParseOptions.Default, (MetaCompilerSyntaxNode)oldTree, changes, cancellationToken);
		}
	
		private MetaCompilerSyntaxKind ToMetaCompilerSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<MetaCompilerSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToMetaCompilerSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToMetaCompilerSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToMetaCompilerSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
		{
			return new GreenSkippedTokensTriviaSyntax(ToMetaCompilerSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToMetaCompilerSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToMetaCompilerSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			MetaCompilerSyntaxKind typedKind = ToMetaCompilerSyntaxKind(kind);
	        Debug.Assert(MetaCompilerLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = MetaCompilerLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			MetaCompilerSyntaxKind typedKind = ToMetaCompilerSyntaxKind(kind);
	        Debug.Assert(MetaCompilerLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = MetaCompilerLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			MetaCompilerSyntaxKind typedKind = ToMetaCompilerSyntaxKind(kind);
	        Debug.Assert(MetaCompilerLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = MetaCompilerLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToMetaCompilerSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToMetaCompilerSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToMetaCompilerSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken TAsterisk(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDateTime, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDate, text, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LDate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LTime, text, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LRegularString, text, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LGuid, text, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LComment, text, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text, object value)
	    {
	        return Token(null, MetaCompilerSyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != MetaCompilerSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Main, namespaceDeclaration, eOF, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(MetaCompilerSyntaxKind.Main, namespaceDeclaration, eOF);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(MetaCompilerSyntaxKind.Name, identifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(MetaCompilerSyntaxKind.QualifiedName, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifierGreen Qualifier(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(MetaCompilerSyntaxKind.Qualifier, identifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AttributeGreen Attribute(InternalSyntaxToken tOpenBracket, QualifierGreen qualifier, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != MetaCompilerSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != MetaCompilerSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Attribute, tOpenBracket, qualifier, tCloseBracket, out hash);
			if (cached != null) return (AttributeGreen)cached;
			var result = new AttributeGreen(MetaCompilerSyntaxKind.Attribute, tOpenBracket, qualifier, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclarationGreen NamespaceDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != MetaCompilerSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
	#endif
	        return new NamespaceDeclarationGreen(MetaCompilerSyntaxKind.NamespaceDeclaration, attribute.Node, kNamespace, qualifiedName, namespaceBody);
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NamespaceBody, tOpenBrace, declaration.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBodyGreen)cached;
			var result = new NamespaceBodyGreen(MetaCompilerSyntaxKind.NamespaceBody, tOpenBrace, declaration.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(TypedefDeclarationGreen typedefDeclaration)
	    {
	#if DEBUG
		    if (typedefDeclaration == null) throw new ArgumentNullException(nameof(typedefDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, typedefDeclaration, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(CompilerDeclarationGreen compilerDeclaration)
	    {
	#if DEBUG
		    if (compilerDeclaration == null) throw new ArgumentNullException(nameof(compilerDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, compilerDeclaration, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(PhaseDeclarationGreen phaseDeclaration)
	    {
	#if DEBUG
		    if (phaseDeclaration == null) throw new ArgumentNullException(nameof(phaseDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, phaseDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(EnumDeclarationGreen enumDeclaration)
	    {
	#if DEBUG
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, null, enumDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(ClassDeclarationGreen classDeclaration)
	    {
	#if DEBUG
		    if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, null, null, classDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(SymbolDeclarationGreen symbolDeclaration)
	    {
	#if DEBUG
		    if (symbolDeclaration == null) throw new ArgumentNullException(nameof(symbolDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, null, null, null, symbolDeclaration);
	    }
	
		public CompilerDeclarationGreen CompilerDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kCompiler, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kCompiler == null) throw new ArgumentNullException(nameof(kCompiler));
			if (kCompiler.Kind != MetaCompilerSyntaxKind.KCompiler) throw new ArgumentException(nameof(kCompiler));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new CompilerDeclarationGreen(MetaCompilerSyntaxKind.CompilerDeclaration, attribute.Node, kCompiler, name, tSemicolon);
	    }
	
		public PhaseDeclarationGreen PhaseDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, LockedGreen locked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
			if (kPhase.Kind != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new PhaseDeclarationGreen(MetaCompilerSyntaxKind.PhaseDeclaration, attribute.Node, locked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
	    }
	
		public LockedGreen Locked(InternalSyntaxToken kLocked)
	    {
	#if DEBUG
			if (kLocked == null) throw new ArgumentNullException(nameof(kLocked));
			if (kLocked.Kind != MetaCompilerSyntaxKind.KLocked) throw new ArgumentException(nameof(kLocked));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Locked, kLocked, out hash);
			if (cached != null) return (LockedGreen)cached;
			var result = new LockedGreen(MetaCompilerSyntaxKind.Locked, kLocked);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PhaseJoinGreen PhaseJoin(InternalSyntaxToken kJoins, PhaseRefGreen phaseRef)
	    {
	#if DEBUG
			if (kJoins == null) throw new ArgumentNullException(nameof(kJoins));
			if (kJoins.Kind != MetaCompilerSyntaxKind.KJoins) throw new ArgumentException(nameof(kJoins));
			if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PhaseJoin, kJoins, phaseRef, out hash);
			if (cached != null) return (PhaseJoinGreen)cached;
			var result = new PhaseJoinGreen(MetaCompilerSyntaxKind.PhaseJoin, kJoins, phaseRef);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AfterPhasesGreen AfterPhases(InternalSyntaxToken kAfter, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
	    {
	#if DEBUG
			if (kAfter == null) throw new ArgumentNullException(nameof(kAfter));
			if (kAfter.Kind != MetaCompilerSyntaxKind.KAfter) throw new ArgumentException(nameof(kAfter));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.AfterPhases, kAfter, phaseRef.Node, out hash);
			if (cached != null) return (AfterPhasesGreen)cached;
			var result = new AfterPhasesGreen(MetaCompilerSyntaxKind.AfterPhases, kAfter, phaseRef.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BeforePhasesGreen BeforePhases(InternalSyntaxToken kBefore, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
	    {
	#if DEBUG
			if (kBefore == null) throw new ArgumentNullException(nameof(kBefore));
			if (kBefore.Kind != MetaCompilerSyntaxKind.KBefore) throw new ArgumentException(nameof(kBefore));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.BeforePhases, kBefore, phaseRef.Node, out hash);
			if (cached != null) return (BeforePhasesGreen)cached;
			var result = new BeforePhasesGreen(MetaCompilerSyntaxKind.BeforePhases, kBefore, phaseRef.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PhaseRefGreen PhaseRef(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PhaseRef, qualifier, out hash);
			if (cached != null) return (PhaseRefGreen)cached;
			var result = new PhaseRefGreen(MetaCompilerSyntaxKind.PhaseRef, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumDeclarationGreen EnumDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	    {
	#if DEBUG
			if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
			if (kEnum.Kind != MetaCompilerSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
	#endif
	        return new EnumDeclarationGreen(MetaCompilerSyntaxKind.EnumDeclaration, attribute.Node, kEnum, name, enumBody);
	    }
	
		public EnumBodyGreen EnumBody(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (enumValues == null) throw new ArgumentNullException(nameof(enumValues));
			if (tSemicolon != null && tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
	        return new EnumBodyGreen(MetaCompilerSyntaxKind.EnumBody, tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration.Node, tCloseBrace);
	    }
	
		public EnumValuesGreen EnumValues(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> enumValue)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumValues, enumValue.Node, out hash);
			if (cached != null) return (EnumValuesGreen)cached;
			var result = new EnumValuesGreen(MetaCompilerSyntaxKind.EnumValues, enumValue.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumValueGreen EnumValue(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumValue, attribute.Node, name, out hash);
			if (cached != null) return (EnumValueGreen)cached;
			var result = new EnumValueGreen(MetaCompilerSyntaxKind.EnumValue, attribute.Node, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumMemberDeclarationGreen EnumMemberDeclaration(OperationDeclarationGreen operationDeclaration)
	    {
	#if DEBUG
			if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.EnumMemberDeclaration, operationDeclaration, out hash);
			if (cached != null) return (EnumMemberDeclarationGreen)cached;
			var result = new EnumMemberDeclarationGreen(MetaCompilerSyntaxKind.EnumMemberDeclaration, operationDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VisibilityGreen Visibility(InternalSyntaxToken visibility)
	    {
	#if DEBUG
			if (visibility == null) throw new ArgumentNullException(nameof(visibility));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Visibility, visibility, out hash);
			if (cached != null) return (VisibilityGreen)cached;
			var result = new VisibilityGreen(MetaCompilerSyntaxKind.Visibility, visibility);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassDeclarationGreen ClassDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen> classModifier, Class_Green class_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	#if DEBUG
			if (class_ == null) throw new ArgumentNullException(nameof(class_));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != MetaCompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (classBody == null) throw new ArgumentNullException(nameof(classBody));
	#endif
	        return new ClassDeclarationGreen(MetaCompilerSyntaxKind.ClassDeclaration, attribute.Node, visibility, classModifier.Node, class_, name, tColon, classAncestors, classBody);
	    }
	
		public ClassModifierGreen ClassModifier(Abstract_Green abstract_)
	    {
	#if DEBUG
		    if (abstract_ == null) throw new ArgumentNullException(nameof(abstract_));
	#endif
			return new ClassModifierGreen(MetaCompilerSyntaxKind.ClassModifier, abstract_, null, null, null);
	    }
	
		public ClassModifierGreen ClassModifier(Sealed_Green sealed_)
	    {
	#if DEBUG
		    if (sealed_ == null) throw new ArgumentNullException(nameof(sealed_));
	#endif
			return new ClassModifierGreen(MetaCompilerSyntaxKind.ClassModifier, null, sealed_, null, null);
	    }
	
		public ClassModifierGreen ClassModifier(Partial_Green partial_)
	    {
	#if DEBUG
		    if (partial_ == null) throw new ArgumentNullException(nameof(partial_));
	#endif
			return new ClassModifierGreen(MetaCompilerSyntaxKind.ClassModifier, null, null, partial_, null);
	    }
	
		public ClassModifierGreen ClassModifier(Static_Green static_)
	    {
	#if DEBUG
		    if (static_ == null) throw new ArgumentNullException(nameof(static_));
	#endif
			return new ClassModifierGreen(MetaCompilerSyntaxKind.ClassModifier, null, null, null, static_);
	    }
	
		public ClassAncestorsGreen ClassAncestors(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> classAncestor)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassAncestors, classAncestor.Node, out hash);
			if (cached != null) return (ClassAncestorsGreen)cached;
			var result = new ClassAncestorsGreen(MetaCompilerSyntaxKind.ClassAncestors, classAncestor.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassAncestorGreen ClassAncestor(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassAncestor, qualifier, out hash);
			if (cached != null) return (ClassAncestorGreen)cached;
			var result = new ClassAncestorGreen(MetaCompilerSyntaxKind.ClassAncestor, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassBodyGreen ClassBody(InternalSyntaxToken tOpenBrace, ClassPhasesGreen classPhases, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
	        return new ClassBodyGreen(MetaCompilerSyntaxKind.ClassBody, tOpenBrace, classPhases, classMemberDeclaration.Node, tCloseBrace);
	    }
	
		public ClassPhasesGreen ClassPhases(InternalSyntaxToken kPhase, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
			if (kPhase.Kind != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassPhases, kPhase, phaseRef.Node, tSemicolon, out hash);
			if (cached != null) return (ClassPhasesGreen)cached;
			var result = new ClassPhasesGreen(MetaCompilerSyntaxKind.ClassPhases, kPhase, phaseRef.Node, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassMemberDeclarationGreen ClassMemberDeclaration(FieldDeclarationGreen fieldDeclaration)
	    {
	#if DEBUG
		    if (fieldDeclaration == null) throw new ArgumentNullException(nameof(fieldDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassMemberDeclaration, fieldDeclaration, out hash);
			if (cached != null) return (ClassMemberDeclarationGreen)cached;
			var result = new ClassMemberDeclarationGreen(MetaCompilerSyntaxKind.ClassMemberDeclaration, fieldDeclaration, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassMemberDeclarationGreen ClassMemberDeclaration(OperationDeclarationGreen operationDeclaration)
	    {
	#if DEBUG
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassMemberDeclaration, operationDeclaration, out hash);
			if (cached != null) return (ClassMemberDeclarationGreen)cached;
			var result = new ClassMemberDeclarationGreen(MetaCompilerSyntaxKind.ClassMemberDeclaration, null, operationDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Class_Green Class_(InternalSyntaxToken kClass)
	    {
	#if DEBUG
			if (kClass == null) throw new ArgumentNullException(nameof(kClass));
			if (kClass.Kind != MetaCompilerSyntaxKind.KClass) throw new ArgumentException(nameof(kClass));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Class_, kClass, out hash);
			if (cached != null) return (Class_Green)cached;
			var result = new Class_Green(MetaCompilerSyntaxKind.Class_, kClass);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SymbolDeclarationGreen SymbolDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, Visit_Green visit_, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassModifierGreen> classModifier, Symbol_Green symbol_, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	#if DEBUG
			if (symbol_ == null) throw new ArgumentNullException(nameof(symbol_));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != MetaCompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (classBody == null) throw new ArgumentNullException(nameof(classBody));
	#endif
	        return new SymbolDeclarationGreen(MetaCompilerSyntaxKind.SymbolDeclaration, attribute.Node, visibility, visit_, classModifier.Node, symbol_, name, tColon, classAncestors, classBody);
	    }
	
		public Symbol_Green Symbol_(InternalSyntaxToken kSymbol)
	    {
	#if DEBUG
			if (kSymbol == null) throw new ArgumentNullException(nameof(kSymbol));
			if (kSymbol.Kind != MetaCompilerSyntaxKind.KSymbol) throw new ArgumentException(nameof(kSymbol));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Symbol_, kSymbol, out hash);
			if (cached != null) return (Symbol_Green)cached;
			var result = new Symbol_Green(MetaCompilerSyntaxKind.Symbol_, kSymbol);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldDeclarationGreen FieldDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen> memberModifier, FieldContainmentGreen fieldContainment, FieldKindGreen fieldKind, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new FieldDeclarationGreen(MetaCompilerSyntaxKind.FieldDeclaration, attribute.Node, visibility, memberModifier.Node, fieldContainment, fieldKind, typeReference, name, defaultValue, phase, tSemicolon);
	    }
	
		public FieldContainmentGreen FieldContainment(InternalSyntaxToken kContainment)
	    {
	#if DEBUG
			if (kContainment == null) throw new ArgumentNullException(nameof(kContainment));
			if (kContainment.Kind != MetaCompilerSyntaxKind.KContainment) throw new ArgumentException(nameof(kContainment));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldContainment, kContainment, out hash);
			if (cached != null) return (FieldContainmentGreen)cached;
			var result = new FieldContainmentGreen(MetaCompilerSyntaxKind.FieldContainment, kContainment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldKindGreen FieldKind(InternalSyntaxToken fieldKind)
	    {
	#if DEBUG
			if (fieldKind == null) throw new ArgumentNullException(nameof(fieldKind));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldKind, fieldKind, out hash);
			if (cached != null) return (FieldKindGreen)cached;
			var result = new FieldKindGreen(MetaCompilerSyntaxKind.FieldKind, fieldKind);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MemberModifierGreen MemberModifier(Partial_Green partial_)
	    {
	#if DEBUG
		    if (partial_ == null) throw new ArgumentNullException(nameof(partial_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, partial_, null, null, null, null, null, null);
	    }
	
		public MemberModifierGreen MemberModifier(Static_Green static_)
	    {
	#if DEBUG
		    if (static_ == null) throw new ArgumentNullException(nameof(static_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, null, static_, null, null, null, null, null);
	    }
	
		public MemberModifierGreen MemberModifier(Virtual_Green virtual_)
	    {
	#if DEBUG
		    if (virtual_ == null) throw new ArgumentNullException(nameof(virtual_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, null, null, virtual_, null, null, null, null);
	    }
	
		public MemberModifierGreen MemberModifier(Abstract_Green abstract_)
	    {
	#if DEBUG
		    if (abstract_ == null) throw new ArgumentNullException(nameof(abstract_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, null, null, null, abstract_, null, null, null);
	    }
	
		public MemberModifierGreen MemberModifier(Sealed_Green sealed_)
	    {
	#if DEBUG
		    if (sealed_ == null) throw new ArgumentNullException(nameof(sealed_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, null, null, null, null, sealed_, null, null);
	    }
	
		public MemberModifierGreen MemberModifier(New_Green new_)
	    {
	#if DEBUG
		    if (new_ == null) throw new ArgumentNullException(nameof(new_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, null, null, null, null, null, new_, null);
	    }
	
		public MemberModifierGreen MemberModifier(Override_Green override_)
	    {
	#if DEBUG
		    if (override_ == null) throw new ArgumentNullException(nameof(override_));
	#endif
			return new MemberModifierGreen(MetaCompilerSyntaxKind.MemberModifier, null, null, null, null, null, null, override_);
	    }
	
		public DefaultValueGreen DefaultValue(InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != MetaCompilerSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.DefaultValue, tAssign, stringLiteral, out hash);
			if (cached != null) return (DefaultValueGreen)cached;
			var result = new DefaultValueGreen(MetaCompilerSyntaxKind.DefaultValue, tAssign, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PhaseGreen Phase(InternalSyntaxToken kPhase, PhaseRefGreen phaseRef)
	    {
	#if DEBUG
			if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
			if (kPhase.Kind != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
			if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Phase, kPhase, phaseRef, out hash);
			if (cached != null) return (PhaseGreen)cached;
			var result = new PhaseGreen(MetaCompilerSyntaxKind.Phase, kPhase, phaseRef);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameUseListGreen NameUseList(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> qualifier)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NameUseList, qualifier.Node, out hash);
			if (cached != null) return (NameUseListGreen)cached;
			var result = new NameUseListGreen(MetaCompilerSyntaxKind.NameUseList, qualifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypedefDeclarationGreen TypedefDeclaration(InternalSyntaxToken kTypeDef, NameGreen name, TypedefValueGreen typedefValue, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kTypeDef == null) throw new ArgumentNullException(nameof(kTypeDef));
			if (kTypeDef.Kind != MetaCompilerSyntaxKind.KTypeDef) throw new ArgumentException(nameof(kTypeDef));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (typedefValue == null) throw new ArgumentNullException(nameof(typedefValue));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new TypedefDeclarationGreen(MetaCompilerSyntaxKind.TypedefDeclaration, kTypeDef, name, typedefValue, tSemicolon);
	    }
	
		public TypedefValueGreen TypedefValue(InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != MetaCompilerSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypedefValue, tAssign, stringLiteral, out hash);
			if (cached != null) return (TypedefValueGreen)cached;
			var result = new TypedefValueGreen(MetaCompilerSyntaxKind.TypedefValue, tAssign, stringLiteral);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(MetaCompilerSyntaxKind.ReturnType, typeReference, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(MetaCompilerSyntaxKind.ReturnType, null, voidType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeOfReferenceGreen TypeOfReference(TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeOfReference, typeReference, out hash);
			if (cached != null) return (TypeOfReferenceGreen)cached;
			var result = new TypeOfReferenceGreen(MetaCompilerSyntaxKind.TypeOfReference, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(SimpleOrDictionaryTypeGreen simpleOrDictionaryType)
	    {
	#if DEBUG
			if (simpleOrDictionaryType == null) throw new ArgumentNullException(nameof(simpleOrDictionaryType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeReference, simpleOrDictionaryType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(MetaCompilerSyntaxKind.TypeReference, simpleOrDictionaryType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleOrDictionaryTypeGreen SimpleOrDictionaryType(SimpleOrArrayTypeGreen simpleOrArrayType)
	    {
	#if DEBUG
		    if (simpleOrArrayType == null) throw new ArgumentNullException(nameof(simpleOrArrayType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrDictionaryType, simpleOrArrayType, out hash);
			if (cached != null) return (SimpleOrDictionaryTypeGreen)cached;
			var result = new SimpleOrDictionaryTypeGreen(MetaCompilerSyntaxKind.SimpleOrDictionaryType, simpleOrArrayType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleOrDictionaryTypeGreen SimpleOrDictionaryType(DictionaryTypeGreen dictionaryType)
	    {
	#if DEBUG
		    if (dictionaryType == null) throw new ArgumentNullException(nameof(dictionaryType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrDictionaryType, dictionaryType, out hash);
			if (cached != null) return (SimpleOrDictionaryTypeGreen)cached;
			var result = new SimpleOrDictionaryTypeGreen(MetaCompilerSyntaxKind.SimpleOrDictionaryType, null, dictionaryType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleOrArrayTypeGreen SimpleOrArrayType(SimpleOrGenericTypeGreen simpleOrGenericType)
	    {
	#if DEBUG
		    if (simpleOrGenericType == null) throw new ArgumentNullException(nameof(simpleOrGenericType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrArrayType, simpleOrGenericType, out hash);
			if (cached != null) return (SimpleOrArrayTypeGreen)cached;
			var result = new SimpleOrArrayTypeGreen(MetaCompilerSyntaxKind.SimpleOrArrayType, simpleOrGenericType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleOrArrayTypeGreen SimpleOrArrayType(ArrayTypeGreen arrayType)
	    {
	#if DEBUG
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrArrayType, arrayType, out hash);
			if (cached != null) return (SimpleOrArrayTypeGreen)cached;
			var result = new SimpleOrArrayTypeGreen(MetaCompilerSyntaxKind.SimpleOrArrayType, null, arrayType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleOrGenericTypeGreen SimpleOrGenericType(SimpleTypeGreen simpleType)
	    {
	#if DEBUG
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrGenericType, simpleType, out hash);
			if (cached != null) return (SimpleOrGenericTypeGreen)cached;
			var result = new SimpleOrGenericTypeGreen(MetaCompilerSyntaxKind.SimpleOrGenericType, simpleType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleOrGenericTypeGreen SimpleOrGenericType(GenericTypeGreen genericType)
	    {
	#if DEBUG
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.SimpleOrGenericType, genericType, out hash);
			if (cached != null) return (SimpleOrGenericTypeGreen)cached;
			var result = new SimpleOrGenericTypeGreen(MetaCompilerSyntaxKind.SimpleOrGenericType, null, genericType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(PrimitiveTypeGreen primitiveType)
	    {
	#if DEBUG
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
	#endif
			return new SimpleTypeGreen(MetaCompilerSyntaxKind.SimpleType, primitiveType, null, null, null);
	    }
	
		public SimpleTypeGreen SimpleType(ObjectTypeGreen objectType)
	    {
	#if DEBUG
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
	#endif
			return new SimpleTypeGreen(MetaCompilerSyntaxKind.SimpleType, null, objectType, null, null);
	    }
	
		public SimpleTypeGreen SimpleType(NullableTypeGreen nullableType)
	    {
	#if DEBUG
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
	#endif
			return new SimpleTypeGreen(MetaCompilerSyntaxKind.SimpleType, null, null, nullableType, null);
	    }
	
		public SimpleTypeGreen SimpleType(ClassTypeGreen classType)
	    {
	#if DEBUG
		    if (classType == null) throw new ArgumentNullException(nameof(classType));
	#endif
			return new SimpleTypeGreen(MetaCompilerSyntaxKind.SimpleType, null, null, null, classType);
	    }
	
		public ClassTypeGreen ClassType(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassType, qualifier, out hash);
			if (cached != null) return (ClassTypeGreen)cached;
			var result = new ClassTypeGreen(MetaCompilerSyntaxKind.ClassType, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ObjectTypeGreen ObjectType(InternalSyntaxToken objectType)
	    {
	#if DEBUG
			if (objectType == null) throw new ArgumentNullException(nameof(objectType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ObjectType, objectType, out hash);
			if (cached != null) return (ObjectTypeGreen)cached;
			var result = new ObjectTypeGreen(MetaCompilerSyntaxKind.ObjectType, objectType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PrimitiveTypeGreen PrimitiveType(InternalSyntaxToken primitiveType)
	    {
	#if DEBUG
			if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.PrimitiveType, primitiveType, out hash);
			if (cached != null) return (PrimitiveTypeGreen)cached;
			var result = new PrimitiveTypeGreen(MetaCompilerSyntaxKind.PrimitiveType, primitiveType);
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
			if (kVoid.Kind != MetaCompilerSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(MetaCompilerSyntaxKind.VoidType, kVoid);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableTypeGreen NullableType(PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion)
	    {
	#if DEBUG
			if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
			if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
			if (tQuestion.Kind != MetaCompilerSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NullableType, primitiveType, tQuestion, out hash);
			if (cached != null) return (NullableTypeGreen)cached;
			var result = new NullableTypeGreen(MetaCompilerSyntaxKind.NullableType, primitiveType, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericTypeGreen GenericType(ClassTypeGreen classType, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan)
	    {
	#if DEBUG
			if (classType == null) throw new ArgumentNullException(nameof(classType));
			if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
			if (tLessThan.Kind != MetaCompilerSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
			if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
			if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
			if (tGreaterThan.Kind != MetaCompilerSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
	#endif
	        return new GenericTypeGreen(MetaCompilerSyntaxKind.GenericType, classType, tLessThan, typeArguments, tGreaterThan);
	    }
	
		public TypeArgumentsGreen TypeArguments(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeReferenceGreen> typeReference)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeArguments, typeReference.Node, out hash);
			if (cached != null) return (TypeArgumentsGreen)cached;
			var result = new TypeArgumentsGreen(MetaCompilerSyntaxKind.TypeArguments, typeReference.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayTypeGreen ArrayType(SimpleOrGenericTypeGreen simpleOrGenericType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (simpleOrGenericType == null) throw new ArgumentNullException(nameof(simpleOrGenericType));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != MetaCompilerSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != MetaCompilerSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ArrayType, simpleOrGenericType, tOpenBracket, tCloseBracket, out hash);
			if (cached != null) return (ArrayTypeGreen)cached;
			var result = new ArrayTypeGreen(MetaCompilerSyntaxKind.ArrayType, simpleOrGenericType, tOpenBracket, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DictionaryTypeGreen DictionaryType(SimpleOrArrayTypeGreen key, InternalSyntaxToken tRightArrow, SimpleOrArrayTypeGreen value)
	    {
	#if DEBUG
			if (key == null) throw new ArgumentNullException(nameof(key));
			if (tRightArrow == null) throw new ArgumentNullException(nameof(tRightArrow));
			if (tRightArrow.Kind != MetaCompilerSyntaxKind.TRightArrow) throw new ArgumentException(nameof(tRightArrow));
			if (value == null) throw new ArgumentNullException(nameof(value));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.DictionaryType, key, tRightArrow, value, out hash);
			if (cached != null) return (DictionaryTypeGreen)cached;
			var result = new DictionaryTypeGreen(MetaCompilerSyntaxKind.DictionaryType, key, tRightArrow, value);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationDeclarationGreen OperationDeclaration(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, VisibilityGreen visibility, MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<MemberModifierGreen> memberModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (returnType == null) throw new ArgumentNullException(nameof(returnType));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != MetaCompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != MetaCompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new OperationDeclarationGreen(MetaCompilerSyntaxKind.OperationDeclaration, attribute.Node, visibility, memberModifier.Node, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	    }
	
		public ParameterListGreen ParameterList(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ParameterList, parameter.Node, out hash);
			if (cached != null) return (ParameterListGreen)cached;
			var result = new ParameterListGreen(MetaCompilerSyntaxKind.ParameterList, parameter.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParameterGreen Parameter(MetaDslx.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
	        return new ParameterGreen(MetaCompilerSyntaxKind.Parameter, attribute.Node, typeReference, name, defaultValue);
	    }
	
		public Static_Green Static_(InternalSyntaxToken kStatic)
	    {
	#if DEBUG
			if (kStatic == null) throw new ArgumentNullException(nameof(kStatic));
			if (kStatic.Kind != MetaCompilerSyntaxKind.KStatic) throw new ArgumentException(nameof(kStatic));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Static_, kStatic, out hash);
			if (cached != null) return (Static_Green)cached;
			var result = new Static_Green(MetaCompilerSyntaxKind.Static_, kStatic);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Base_Green Base_(InternalSyntaxToken kBase)
	    {
	#if DEBUG
			if (kBase == null) throw new ArgumentNullException(nameof(kBase));
			if (kBase.Kind != MetaCompilerSyntaxKind.KBase) throw new ArgumentException(nameof(kBase));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Base_, kBase, out hash);
			if (cached != null) return (Base_Green)cached;
			var result = new Base_Green(MetaCompilerSyntaxKind.Base_, kBase);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Meta_Green Meta_(InternalSyntaxToken kMeta)
	    {
	#if DEBUG
			if (kMeta == null) throw new ArgumentNullException(nameof(kMeta));
			if (kMeta.Kind != MetaCompilerSyntaxKind.KMeta) throw new ArgumentException(nameof(kMeta));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Meta_, kMeta, out hash);
			if (cached != null) return (Meta_Green)cached;
			var result = new Meta_Green(MetaCompilerSyntaxKind.Meta_, kMeta);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Source_Green Source_(InternalSyntaxToken kSource)
	    {
	#if DEBUG
			if (kSource == null) throw new ArgumentNullException(nameof(kSource));
			if (kSource.Kind != MetaCompilerSyntaxKind.KSource) throw new ArgumentException(nameof(kSource));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Source_, kSource, out hash);
			if (cached != null) return (Source_Green)cached;
			var result = new Source_Green(MetaCompilerSyntaxKind.Source_, kSource);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Visit_Green Visit_(InternalSyntaxToken kVisit)
	    {
	#if DEBUG
			if (kVisit == null) throw new ArgumentNullException(nameof(kVisit));
			if (kVisit.Kind != MetaCompilerSyntaxKind.KVisit) throw new ArgumentException(nameof(kVisit));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Visit_, kVisit, out hash);
			if (cached != null) return (Visit_Green)cached;
			var result = new Visit_Green(MetaCompilerSyntaxKind.Visit_, kVisit);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Partial_Green Partial_(InternalSyntaxToken kPartial)
	    {
	#if DEBUG
			if (kPartial == null) throw new ArgumentNullException(nameof(kPartial));
			if (kPartial.Kind != MetaCompilerSyntaxKind.KPartial) throw new ArgumentException(nameof(kPartial));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Partial_, kPartial, out hash);
			if (cached != null) return (Partial_Green)cached;
			var result = new Partial_Green(MetaCompilerSyntaxKind.Partial_, kPartial);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Abstract_Green Abstract_(InternalSyntaxToken kAbstract)
	    {
	#if DEBUG
			if (kAbstract == null) throw new ArgumentNullException(nameof(kAbstract));
			if (kAbstract.Kind != MetaCompilerSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Abstract_, kAbstract, out hash);
			if (cached != null) return (Abstract_Green)cached;
			var result = new Abstract_Green(MetaCompilerSyntaxKind.Abstract_, kAbstract);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Virtual_Green Virtual_(InternalSyntaxToken kVirtual)
	    {
	#if DEBUG
			if (kVirtual == null) throw new ArgumentNullException(nameof(kVirtual));
			if (kVirtual.Kind != MetaCompilerSyntaxKind.KVirtual) throw new ArgumentException(nameof(kVirtual));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Virtual_, kVirtual, out hash);
			if (cached != null) return (Virtual_Green)cached;
			var result = new Virtual_Green(MetaCompilerSyntaxKind.Virtual_, kVirtual);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Sealed_Green Sealed_(InternalSyntaxToken kSealed)
	    {
	#if DEBUG
			if (kSealed == null) throw new ArgumentNullException(nameof(kSealed));
			if (kSealed.Kind != MetaCompilerSyntaxKind.KSealed) throw new ArgumentException(nameof(kSealed));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Sealed_, kSealed, out hash);
			if (cached != null) return (Sealed_Green)cached;
			var result = new Sealed_Green(MetaCompilerSyntaxKind.Sealed_, kSealed);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public Override_Green Override_(InternalSyntaxToken kOverride)
	    {
	#if DEBUG
			if (kOverride == null) throw new ArgumentNullException(nameof(kOverride));
			if (kOverride.Kind != MetaCompilerSyntaxKind.KOverride) throw new ArgumentException(nameof(kOverride));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Override_, kOverride, out hash);
			if (cached != null) return (Override_Green)cached;
			var result = new Override_Green(MetaCompilerSyntaxKind.Override_, kOverride);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public New_Green New_(InternalSyntaxToken kNew)
	    {
	#if DEBUG
			if (kNew == null) throw new ArgumentNullException(nameof(kNew));
			if (kNew.Kind != MetaCompilerSyntaxKind.KNew) throw new ArgumentException(nameof(kNew));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.New_, kNew, out hash);
			if (cached != null) return (New_Green)cached;
			var result = new New_Green(MetaCompilerSyntaxKind.New_, kNew);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Identifier, identifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(MetaCompilerSyntaxKind.Identifier, identifier);
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
			return new LiteralGreen(MetaCompilerSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(MetaCompilerSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			return new LiteralGreen(MetaCompilerSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			return new LiteralGreen(MetaCompilerSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			return new LiteralGreen(MetaCompilerSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(MetaCompilerSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != MetaCompilerSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(MetaCompilerSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(MetaCompilerSyntaxKind.BooleanLiteral, booleanLiteral);
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
			if (lInteger.Kind != MetaCompilerSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(MetaCompilerSyntaxKind.IntegerLiteral, lInteger);
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
			if (lDecimal.Kind != MetaCompilerSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(MetaCompilerSyntaxKind.DecimalLiteral, lDecimal);
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
			if (lScientific.Kind != MetaCompilerSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(MetaCompilerSyntaxKind.ScientificLiteral, lScientific);
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
			if (lRegularString.Kind != MetaCompilerSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.StringLiteral, lRegularString, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(MetaCompilerSyntaxKind.StringLiteral, lRegularString);
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
				typeof(NameGreen),
				typeof(QualifiedNameGreen),
				typeof(QualifierGreen),
				typeof(AttributeGreen),
				typeof(NamespaceDeclarationGreen),
				typeof(NamespaceBodyGreen),
				typeof(DeclarationGreen),
				typeof(CompilerDeclarationGreen),
				typeof(PhaseDeclarationGreen),
				typeof(LockedGreen),
				typeof(PhaseJoinGreen),
				typeof(AfterPhasesGreen),
				typeof(BeforePhasesGreen),
				typeof(PhaseRefGreen),
				typeof(EnumDeclarationGreen),
				typeof(EnumBodyGreen),
				typeof(EnumValuesGreen),
				typeof(EnumValueGreen),
				typeof(EnumMemberDeclarationGreen),
				typeof(VisibilityGreen),
				typeof(ClassDeclarationGreen),
				typeof(ClassModifierGreen),
				typeof(ClassAncestorsGreen),
				typeof(ClassAncestorGreen),
				typeof(ClassBodyGreen),
				typeof(ClassPhasesGreen),
				typeof(ClassMemberDeclarationGreen),
				typeof(Class_Green),
				typeof(SymbolDeclarationGreen),
				typeof(Symbol_Green),
				typeof(FieldDeclarationGreen),
				typeof(FieldContainmentGreen),
				typeof(FieldKindGreen),
				typeof(MemberModifierGreen),
				typeof(DefaultValueGreen),
				typeof(PhaseGreen),
				typeof(NameUseListGreen),
				typeof(TypedefDeclarationGreen),
				typeof(TypedefValueGreen),
				typeof(ReturnTypeGreen),
				typeof(TypeOfReferenceGreen),
				typeof(TypeReferenceGreen),
				typeof(SimpleOrDictionaryTypeGreen),
				typeof(SimpleOrArrayTypeGreen),
				typeof(SimpleOrGenericTypeGreen),
				typeof(SimpleTypeGreen),
				typeof(ClassTypeGreen),
				typeof(ObjectTypeGreen),
				typeof(PrimitiveTypeGreen),
				typeof(VoidTypeGreen),
				typeof(NullableTypeGreen),
				typeof(GenericTypeGreen),
				typeof(TypeArgumentsGreen),
				typeof(ArrayTypeGreen),
				typeof(DictionaryTypeGreen),
				typeof(OperationDeclarationGreen),
				typeof(ParameterListGreen),
				typeof(ParameterGreen),
				typeof(Static_Green),
				typeof(Base_Green),
				typeof(Meta_Green),
				typeof(Source_Green),
				typeof(Visit_Green),
				typeof(Partial_Green),
				typeof(Abstract_Green),
				typeof(Virtual_Green),
				typeof(Sealed_Green),
				typeof(Override_Green),
				typeof(New_Green),
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


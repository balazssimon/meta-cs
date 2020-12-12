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

        public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken> Tokens => new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxToken>(this.tokens);

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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
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
	
	    public QualifierGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
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
	
	    public NamespaceDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
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
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> Declaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen>(this.declaration); } }
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
	
	    public NamespaceBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
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
	    private CompilerDeclarationGreen compilerDeclaration;
	    private PhaseDeclarationGreen phaseDeclaration;
	    private EnumDeclarationGreen enumDeclaration;
	    private ClassDeclarationGreen classDeclaration;
	    private TypedefDeclarationGreen typedefDeclaration;
	
	    public DeclarationGreen(MetaCompilerSyntaxKind kind, CompilerDeclarationGreen compilerDeclaration, PhaseDeclarationGreen phaseDeclaration, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, TypedefDeclarationGreen typedefDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
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
			if (typedefDeclaration != null)
			{
				this.AdjustFlagsAndWidth(typedefDeclaration);
				this.typedefDeclaration = typedefDeclaration;
			}
	    }
	
	    public DeclarationGreen(MetaCompilerSyntaxKind kind, CompilerDeclarationGreen compilerDeclaration, PhaseDeclarationGreen phaseDeclaration, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, TypedefDeclarationGreen typedefDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
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
			if (typedefDeclaration != null)
			{
				this.AdjustFlagsAndWidth(typedefDeclaration);
				this.typedefDeclaration = typedefDeclaration;
			}
	    }
	
		private DeclarationGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Declaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public CompilerDeclarationGreen CompilerDeclaration { get { return this.compilerDeclaration; } }
	    public PhaseDeclarationGreen PhaseDeclaration { get { return this.phaseDeclaration; } }
	    public EnumDeclarationGreen EnumDeclaration { get { return this.enumDeclaration; } }
	    public ClassDeclarationGreen ClassDeclaration { get { return this.classDeclaration; } }
	    public TypedefDeclarationGreen TypedefDeclaration { get { return this.typedefDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.DeclarationSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.compilerDeclaration;
	            case 1: return this.phaseDeclaration;
	            case 2: return this.enumDeclaration;
	            case 3: return this.classDeclaration;
	            case 4: return this.typedefDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.compilerDeclaration, this.phaseDeclaration, this.enumDeclaration, this.classDeclaration, this.typedefDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.compilerDeclaration, this.phaseDeclaration, this.enumDeclaration, this.classDeclaration, this.typedefDeclaration, this.GetDiagnostics(), annotations);
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
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
	
	    public CompilerDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kCompiler, NameGreen name, InternalSyntaxToken tSemicolon)
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
	    private InternalSyntaxToken kLocked;
	    private InternalSyntaxToken kPhase;
	    private NameGreen name;
	    private PhaseJoinGreen phaseJoin;
	    private AfterPhasesGreen afterPhases;
	    private BeforePhasesGreen beforePhases;
	    private InternalSyntaxToken tSemicolon;
	
	    public PhaseDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kLocked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kLocked != null)
			{
				this.AdjustFlagsAndWidth(kLocked);
				this.kLocked = kLocked;
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
	
	    public PhaseDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kLocked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kLocked != null)
			{
				this.AdjustFlagsAndWidth(kLocked);
				this.kLocked = kLocked;
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KLocked { get { return this.kLocked; } }
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
	            case 1: return this.kLocked;
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
	        return new PhaseDeclarationGreen(this.Kind, this.attribute, this.kLocked, this.kPhase, this.name, this.phaseJoin, this.afterPhases, this.beforePhases, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PhaseDeclarationGreen(this.Kind, this.attribute, this.kLocked, this.kPhase, this.name, this.phaseJoin, this.afterPhases, this.beforePhases, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public PhaseDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kLocked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KLocked != kLocked ||
				this.KPhase != kPhase ||
				this.Name != name ||
				this.PhaseJoin != phaseJoin ||
				this.AfterPhases != afterPhases ||
				this.BeforePhases != beforePhases ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseDeclaration(attribute, kLocked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
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
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> PhaseRef { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen>(this.phaseRef); } }
	
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
	
	    public AfterPhasesGreen Update(InternalSyntaxToken kAfter, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
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
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> PhaseRef { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen>(this.phaseRef); } }
	
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
	
	    public BeforePhasesGreen Update(InternalSyntaxToken kBefore, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
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
	
	    public EnumDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
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
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> EnumMemberDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen>(this.enumMemberDeclaration); } }
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
	
	    public EnumBodyGreen Update(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> EnumValue { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen>(this.enumValue); } }
	
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
	
	    public EnumValuesGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> enumValue)
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
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
	
	    public EnumValueGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, NameGreen name)
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
	
	internal class ClassDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ClassDeclarationGreen __Missing = new ClassDeclarationGreen();
	    private GreenNode attribute;
	    private InternalSyntaxToken kAbstract;
	    private ClassKindGreen classKind;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ClassAncestorsGreen classAncestors;
	    private ClassBodyGreen classBody;
	
	    public ClassDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kAbstract, ClassKindGreen classKind, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kAbstract != null)
			{
				this.AdjustFlagsAndWidth(kAbstract);
				this.kAbstract = kAbstract;
			}
			if (classKind != null)
			{
				this.AdjustFlagsAndWidth(classKind);
				this.classKind = classKind;
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
	
	    public ClassDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kAbstract, ClassKindGreen classKind, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kAbstract != null)
			{
				this.AdjustFlagsAndWidth(kAbstract);
				this.kAbstract = kAbstract;
			}
			if (classKind != null)
			{
				this.AdjustFlagsAndWidth(classKind);
				this.classKind = classKind;
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KAbstract { get { return this.kAbstract; } }
	    public ClassKindGreen ClassKind { get { return this.classKind; } }
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
	            case 1: return this.kAbstract;
	            case 2: return this.classKind;
	            case 3: return this.name;
	            case 4: return this.tColon;
	            case 5: return this.classAncestors;
	            case 6: return this.classBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.attribute, this.kAbstract, this.classKind, this.name, this.tColon, this.classAncestors, this.classBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.attribute, this.kAbstract, this.classKind, this.name, this.tColon, this.classAncestors, this.classBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kAbstract, ClassKindGreen classKind, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	        if (this.Attribute != attribute ||
				this.KAbstract != kAbstract ||
				this.ClassKind != classKind ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(attribute, kAbstract, classKind, name, tColon, classAncestors, classBody);
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> ClassAncestor { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen>(this.classAncestor); } }
	
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
	
	    public ClassAncestorsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> classAncestor)
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
	    private GreenNode classMemberDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ClassBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
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
	
	    public ClassBodyGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode classMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
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
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> ClassMemberDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen>(this.classMemberDeclaration); } }
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
	            case 1: return this.classMemberDeclaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassBodyGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassBodyGreen(this.Kind, this.tOpenBrace, this.classMemberDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassBodyGreen(this.Kind, this.tOpenBrace, this.classMemberDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ClassMemberDeclaration != classMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
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
	
	internal class ClassKindGreen : GreenSyntaxNode
	{
	    internal static readonly ClassKindGreen __Missing = new ClassKindGreen();
	    private InternalSyntaxToken classKind;
	
	    public ClassKindGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken classKind)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (classKind != null)
			{
				this.AdjustFlagsAndWidth(classKind);
				this.classKind = classKind;
			}
	    }
	
	    public ClassKindGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken classKind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (classKind != null)
			{
				this.AdjustFlagsAndWidth(classKind);
				this.classKind = classKind;
			}
	    }
	
		private ClassKindGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassKind, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ClassKind { get { return this.classKind; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.ClassKindSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.classKind;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitClassKindGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitClassKindGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassKindGreen(this.Kind, this.classKind, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassKindGreen(this.Kind, this.classKind, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassKindGreen Update(InternalSyntaxToken classKind)
	    {
	        if (this.ClassKind != classKind)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassKind(classKind);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassKindGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FieldDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly FieldDeclarationGreen __Missing = new FieldDeclarationGreen();
	    private GreenNode attribute;
	    private FieldContainmentGreen fieldContainment;
	    private FieldModifierGreen fieldModifier;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private DefaultValueGreen defaultValue;
	    private PhaseGreen phase;
	    private InternalSyntaxToken tSemicolon;
	
	    public FieldDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (fieldContainment != null)
			{
				this.AdjustFlagsAndWidth(fieldContainment);
				this.fieldContainment = fieldContainment;
			}
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
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
	
	    public FieldDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (fieldContainment != null)
			{
				this.AdjustFlagsAndWidth(fieldContainment);
				this.fieldContainment = fieldContainment;
			}
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public FieldContainmentGreen FieldContainment { get { return this.fieldContainment; } }
	    public FieldModifierGreen FieldModifier { get { return this.fieldModifier; } }
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
	            case 1: return this.fieldContainment;
	            case 2: return this.fieldModifier;
	            case 3: return this.typeReference;
	            case 4: return this.name;
	            case 5: return this.defaultValue;
	            case 6: return this.phase;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitFieldDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitFieldDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.attribute, this.fieldContainment, this.fieldModifier, this.typeReference, this.name, this.defaultValue, this.phase, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.attribute, this.fieldContainment, this.fieldModifier, this.typeReference, this.name, this.defaultValue, this.phase, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.FieldContainment != fieldContainment ||
				this.FieldModifier != fieldModifier ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue ||
				this.Phase != phase ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(attribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, phase, tSemicolon);
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
	
	internal class FieldModifierGreen : GreenSyntaxNode
	{
	    internal static readonly FieldModifierGreen __Missing = new FieldModifierGreen();
	    private InternalSyntaxToken fieldModifier;
	
	    public FieldModifierGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken fieldModifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
			}
	    }
	
	    public FieldModifierGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken fieldModifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
			}
	    }
	
		private FieldModifierGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldModifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken FieldModifier { get { return this.fieldModifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.FieldModifierSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldModifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitFieldModifierGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitFieldModifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldModifierGreen(this.Kind, this.fieldModifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldModifierGreen(this.Kind, this.fieldModifier, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldModifierGreen Update(InternalSyntaxToken fieldModifier)
	    {
	        if (this.FieldModifier != fieldModifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldModifier(fieldModifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldModifierGreen)newNode;
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
	    private QualifierGreen qualifier;
	
	    public PhaseGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPhase, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public PhaseGreen(MetaCompilerSyntaxKind kind, InternalSyntaxToken kPhase, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kPhase != null)
			{
				this.AdjustFlagsAndWidth(kPhase);
				this.kPhase = kPhase;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private PhaseGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Phase, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KPhase { get { return this.kPhase; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.PhaseSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPhase;
	            case 1: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitPhaseGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitPhaseGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PhaseGreen(this.Kind, this.kPhase, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PhaseGreen(this.Kind, this.kPhase, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public PhaseGreen Update(InternalSyntaxToken kPhase, QualifierGreen qualifier)
	    {
	        if (this.KPhase != kPhase ||
				this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Phase(kPhase, qualifier);
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> Qualifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen>(this.qualifier); } }
	
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
	
	    public NameUseListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> qualifier)
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
	    private GenericTypeGreen genericType;
	    private SimpleTypeGreen simpleType;
	
	    public TypeReferenceGreen(MetaCompilerSyntaxKind kind, GenericTypeGreen genericType, SimpleTypeGreen simpleType)
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
	
	    public TypeReferenceGreen(MetaCompilerSyntaxKind kind, GenericTypeGreen genericType, SimpleTypeGreen simpleType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
		private TypeReferenceGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public GenericTypeGreen GenericType { get { return this.genericType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypeReferenceSyntax(this, (MetaCompilerSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.genericType, this.simpleType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.genericType, this.simpleType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(GenericTypeGreen genericType)
	    {
	        if (this.genericType != genericType)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeReference(genericType);
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
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleType);
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
	    private GenericTypeNameGreen genericTypeName;
	    private InternalSyntaxToken tLessThan;
	    private TypeArgumentsGreen typeArguments;
	    private InternalSyntaxToken tGreaterThan;
	
	    public GenericTypeGreen(MetaCompilerSyntaxKind kind, GenericTypeNameGreen genericTypeName, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (genericTypeName != null)
			{
				this.AdjustFlagsAndWidth(genericTypeName);
				this.genericTypeName = genericTypeName;
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
	
	    public GenericTypeGreen(MetaCompilerSyntaxKind kind, GenericTypeNameGreen genericTypeName, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (genericTypeName != null)
			{
				this.AdjustFlagsAndWidth(genericTypeName);
				this.genericTypeName = genericTypeName;
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
	
	    public GenericTypeNameGreen GenericTypeName { get { return this.genericTypeName; } }
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
	            case 0: return this.genericTypeName;
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
	        return new GenericTypeGreen(this.Kind, this.genericTypeName, this.tLessThan, this.typeArguments, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeGreen(this.Kind, this.genericTypeName, this.tLessThan, this.typeArguments, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public GenericTypeGreen Update(GenericTypeNameGreen genericTypeName, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.GenericTypeName != genericTypeName ||
				this.TLessThan != tLessThan ||
				this.TypeArguments != typeArguments ||
				this.TGreaterThan != tGreaterThan)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.GenericType(genericTypeName, tLessThan, typeArguments, tGreaterThan);
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
	
	internal class GenericTypeNameGreen : GreenSyntaxNode
	{
	    internal static readonly GenericTypeNameGreen __Missing = new GenericTypeNameGreen();
	    private QualifierGreen qualifier;
	
	    public GenericTypeNameGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public GenericTypeNameGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private GenericTypeNameGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.GenericTypeName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.GenericTypeNameSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitGenericTypeNameGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitGenericTypeNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericTypeNameGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeNameGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public GenericTypeNameGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.GenericTypeName(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeArgumentsGreen : GreenSyntaxNode
	{
	    internal static readonly TypeArgumentsGreen __Missing = new TypeArgumentsGreen();
	    private GreenNode typeArgument;
	
	    public TypeArgumentsGreen(MetaCompilerSyntaxKind kind, GreenNode typeArgument)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (typeArgument != null)
			{
				this.AdjustFlagsAndWidth(typeArgument);
				this.typeArgument = typeArgument;
			}
	    }
	
	    public TypeArgumentsGreen(MetaCompilerSyntaxKind kind, GreenNode typeArgument, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (typeArgument != null)
			{
				this.AdjustFlagsAndWidth(typeArgument);
				this.typeArgument = typeArgument;
			}
	    }
	
		private TypeArgumentsGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeArguments, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeArgumentGreen> TypeArgument { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeArgumentGreen>(this.typeArgument); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypeArgumentsSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeArgument;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypeArgumentsGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypeArgumentsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeArgumentsGreen(this.Kind, this.typeArgument, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeArgumentsGreen(this.Kind, this.typeArgument, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeArgumentsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeArgumentGreen> typeArgument)
	    {
	        if (this.TypeArgument != typeArgument)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeArguments(typeArgument);
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
	
	internal class TypeArgumentGreen : GreenSyntaxNode
	{
	    internal static readonly TypeArgumentGreen __Missing = new TypeArgumentGreen();
	    private QualifierGreen qualifier;
	
	    public TypeArgumentGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public TypeArgumentGreen(MetaCompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private TypeArgumentGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeArgument, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.MetaCompiler.Syntax.TypeArgumentSyntax(this, (MetaCompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitTypeArgumentGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitTypeArgumentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeArgumentGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeArgumentGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeArgumentGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeArgument(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeArgumentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly OperationDeclarationGreen __Missing = new OperationDeclarationGreen();
	    private GreenNode attribute;
	    private ReturnTypeGreen returnType;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private ParameterListGreen parameterList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tSemicolon;
	
	    public OperationDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
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
	
	    public OperationDeclarationGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
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
	            case 1: return this.returnType;
	            case 2: return this.name;
	            case 3: return this.tOpenParen;
	            case 4: return this.parameterList;
	            case 5: return this.tCloseParen;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.attribute, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.attribute, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(attribute, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
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
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> Parameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen>(this.parameter); } }
	
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
	
	    public ParameterListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
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
	
	    public ParameterGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, TypeReferenceGreen typeReference, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
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
	    }
	
	    public ParameterGreen(MetaCompilerSyntaxKind kind, GreenNode attribute, TypeReferenceGreen typeReference, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
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
	    }
	
		private ParameterGreen()
			: base((MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Parameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	
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
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(MetaCompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParameterGreen(this);
	
	    public override void Accept(MetaCompilerSyntaxVisitor visitor) => visitor.VisitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterGreen(this.Kind, this.attribute, this.typeReference, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterGreen(this.Kind, this.attribute, this.typeReference, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, TypeReferenceGreen typeReference, NameGreen name)
	    {
	        if (this.Attribute != attribute ||
				this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            InternalSyntaxNode newNode = MetaCompilerLanguage.Instance.InternalSyntaxFactory.Parameter(attribute, typeReference, name);
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
		public virtual void VisitPhaseJoinGreen(PhaseJoinGreen node) => this.DefaultVisit(node);
		public virtual void VisitAfterPhasesGreen(AfterPhasesGreen node) => this.DefaultVisit(node);
		public virtual void VisitBeforePhasesGreen(BeforePhasesGreen node) => this.DefaultVisit(node);
		public virtual void VisitPhaseRefGreen(PhaseRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumValuesGreen(EnumValuesGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumValueGreen(EnumValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumMemberDeclarationGreen(EnumMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassDeclarationGreen(ClassDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassAncestorsGreen(ClassAncestorsGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassAncestorGreen(ClassAncestorGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassBodyGreen(ClassBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassMemberDeclarationGreen(ClassMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassKindGreen(ClassKindGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldDeclarationGreen(FieldDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldContainmentGreen(FieldContainmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldModifierGreen(FieldModifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitDefaultValueGreen(DefaultValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitPhaseGreen(PhaseGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameUseListGreen(NameUseListGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypedefDeclarationGreen(TypedefDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypedefValueGreen(TypedefValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeOfReferenceGreen(TypeOfReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassTypeGreen(ClassTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeGreen(GenericTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeNameGreen(GenericTypeNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeArgumentsGreen(TypeArgumentsGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeArgumentGreen(TypeArgumentGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
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
		public virtual TResult VisitPhaseJoinGreen(PhaseJoinGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAfterPhasesGreen(AfterPhasesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBeforePhasesGreen(BeforePhasesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPhaseRefGreen(PhaseRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumValuesGreen(EnumValuesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumValueGreen(EnumValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumMemberDeclarationGreen(EnumMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassDeclarationGreen(ClassDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassAncestorsGreen(ClassAncestorsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassAncestorGreen(ClassAncestorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassBodyGreen(ClassBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassMemberDeclarationGreen(ClassMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassKindGreen(ClassKindGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldDeclarationGreen(FieldDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldContainmentGreen(FieldContainmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldModifierGreen(FieldModifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDefaultValueGreen(DefaultValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPhaseGreen(PhaseGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameUseListGreen(NameUseListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypedefDeclarationGreen(TypedefDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypedefValueGreen(TypedefValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeOfReferenceGreen(TypeOfReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassTypeGreen(ClassTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeGreen(GenericTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeNameGreen(GenericTypeNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeArgumentsGreen(TypeArgumentsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeArgumentGreen(TypeArgumentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
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
	
		public QualifierGreen Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
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
	
		public NamespaceDeclarationGreen NamespaceDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != MetaCompilerSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
	#endif
	        return new NamespaceDeclarationGreen(MetaCompilerSyntaxKind.NamespaceDeclaration, attribute.Node, kNamespace, qualifiedName, namespaceBody);
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
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
	
		public DeclarationGreen Declaration(CompilerDeclarationGreen compilerDeclaration)
	    {
	#if DEBUG
		    if (compilerDeclaration == null) throw new ArgumentNullException(nameof(compilerDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, compilerDeclaration, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(PhaseDeclarationGreen phaseDeclaration)
	    {
	#if DEBUG
		    if (phaseDeclaration == null) throw new ArgumentNullException(nameof(phaseDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, phaseDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(EnumDeclarationGreen enumDeclaration)
	    {
	#if DEBUG
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, enumDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(ClassDeclarationGreen classDeclaration)
	    {
	#if DEBUG
		    if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, null, classDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(TypedefDeclarationGreen typedefDeclaration)
	    {
	#if DEBUG
		    if (typedefDeclaration == null) throw new ArgumentNullException(nameof(typedefDeclaration));
	#endif
			return new DeclarationGreen(MetaCompilerSyntaxKind.Declaration, null, null, null, null, typedefDeclaration);
	    }
	
		public CompilerDeclarationGreen CompilerDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kCompiler, NameGreen name, InternalSyntaxToken tSemicolon)
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
	
		public PhaseDeclarationGreen PhaseDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kLocked, InternalSyntaxToken kPhase, NameGreen name, PhaseJoinGreen phaseJoin, AfterPhasesGreen afterPhases, BeforePhasesGreen beforePhases, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kLocked != null && kLocked.Kind != MetaCompilerSyntaxKind.KLocked) throw new ArgumentException(nameof(kLocked));
			if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
			if (kPhase.Kind != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new PhaseDeclarationGreen(MetaCompilerSyntaxKind.PhaseDeclaration, attribute.Node, kLocked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
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
	
		public AfterPhasesGreen AfterPhases(InternalSyntaxToken kAfter, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
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
	
		public BeforePhasesGreen BeforePhases(InternalSyntaxToken kBefore, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<PhaseRefGreen> phaseRef)
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
	
		public EnumDeclarationGreen EnumDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	    {
	#if DEBUG
			if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
			if (kEnum.Kind != MetaCompilerSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
	#endif
	        return new EnumDeclarationGreen(MetaCompilerSyntaxKind.EnumDeclaration, attribute.Node, kEnum, name, enumBody);
	    }
	
		public EnumBodyGreen EnumBody(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
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
	
		public EnumValuesGreen EnumValues(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> enumValue)
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
	
		public EnumValueGreen EnumValue(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, NameGreen name)
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
	
		public ClassDeclarationGreen ClassDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kAbstract, ClassKindGreen classKind, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	#if DEBUG
			if (kAbstract != null && kAbstract.Kind != MetaCompilerSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
			if (classKind == null) throw new ArgumentNullException(nameof(classKind));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != MetaCompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (classBody == null) throw new ArgumentNullException(nameof(classBody));
	#endif
	        return new ClassDeclarationGreen(MetaCompilerSyntaxKind.ClassDeclaration, attribute.Node, kAbstract, classKind, name, tColon, classAncestors, classBody);
	    }
	
		public ClassAncestorsGreen ClassAncestors(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> classAncestor)
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
	
		public ClassBodyGreen ClassBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassBody, tOpenBrace, classMemberDeclaration.Node, tCloseBrace, out hash);
			if (cached != null) return (ClassBodyGreen)cached;
			var result = new ClassBodyGreen(MetaCompilerSyntaxKind.ClassBody, tOpenBrace, classMemberDeclaration.Node, tCloseBrace);
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
	
		public ClassKindGreen ClassKind(InternalSyntaxToken classKind)
	    {
	#if DEBUG
			if (classKind == null) throw new ArgumentNullException(nameof(classKind));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.ClassKind, classKind, out hash);
			if (cached != null) return (ClassKindGreen)cached;
			var result = new ClassKindGreen(MetaCompilerSyntaxKind.ClassKind, classKind);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldDeclarationGreen FieldDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, PhaseGreen phase, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new FieldDeclarationGreen(MetaCompilerSyntaxKind.FieldDeclaration, attribute.Node, fieldContainment, fieldModifier, typeReference, name, defaultValue, phase, tSemicolon);
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
	
		public FieldModifierGreen FieldModifier(InternalSyntaxToken fieldModifier)
	    {
	#if DEBUG
			if (fieldModifier == null) throw new ArgumentNullException(nameof(fieldModifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.FieldModifier, fieldModifier, out hash);
			if (cached != null) return (FieldModifierGreen)cached;
			var result = new FieldModifierGreen(MetaCompilerSyntaxKind.FieldModifier, fieldModifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
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
	
		public PhaseGreen Phase(InternalSyntaxToken kPhase, QualifierGreen qualifier)
	    {
	#if DEBUG
			if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
			if (kPhase.Kind != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Phase, kPhase, qualifier, out hash);
			if (cached != null) return (PhaseGreen)cached;
			var result = new PhaseGreen(MetaCompilerSyntaxKind.Phase, kPhase, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameUseListGreen NameUseList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> qualifier)
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
	
		public TypeReferenceGreen TypeReference(GenericTypeGreen genericType)
	    {
	#if DEBUG
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeReference, genericType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(MetaCompilerSyntaxKind.TypeReference, genericType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(SimpleTypeGreen simpleType)
	    {
	#if DEBUG
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeReference, simpleType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(MetaCompilerSyntaxKind.TypeReference, null, simpleType);
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
	
		public GenericTypeGreen GenericType(GenericTypeNameGreen genericTypeName, InternalSyntaxToken tLessThan, TypeArgumentsGreen typeArguments, InternalSyntaxToken tGreaterThan)
	    {
	#if DEBUG
			if (genericTypeName == null) throw new ArgumentNullException(nameof(genericTypeName));
			if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
			if (tLessThan.Kind != MetaCompilerSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
			if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
			if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
			if (tGreaterThan.Kind != MetaCompilerSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
	#endif
	        return new GenericTypeGreen(MetaCompilerSyntaxKind.GenericType, genericTypeName, tLessThan, typeArguments, tGreaterThan);
	    }
	
		public GenericTypeNameGreen GenericTypeName(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.GenericTypeName, qualifier, out hash);
			if (cached != null) return (GenericTypeNameGreen)cached;
			var result = new GenericTypeNameGreen(MetaCompilerSyntaxKind.GenericTypeName, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeArgumentsGreen TypeArguments(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<TypeArgumentGreen> typeArgument)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeArguments, typeArgument.Node, out hash);
			if (cached != null) return (TypeArgumentsGreen)cached;
			var result = new TypeArgumentsGreen(MetaCompilerSyntaxKind.TypeArguments, typeArgument.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeArgumentGreen TypeArgument(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.TypeArgument, qualifier, out hash);
			if (cached != null) return (TypeArgumentGreen)cached;
			var result = new TypeArgumentGreen(MetaCompilerSyntaxKind.TypeArgument, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationDeclarationGreen OperationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
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
	        return new OperationDeclarationGreen(MetaCompilerSyntaxKind.OperationDeclaration, attribute.Node, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	    }
	
		public ParameterListGreen ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
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
	
		public ParameterGreen Parameter(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, TypeReferenceGreen typeReference, NameGreen name)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Parameter, attribute.Node, typeReference, name, out hash);
			if (cached != null) return (ParameterGreen)cached;
			var result = new ParameterGreen(MetaCompilerSyntaxKind.Parameter, attribute.Node, typeReference, name);
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
				typeof(PhaseJoinGreen),
				typeof(AfterPhasesGreen),
				typeof(BeforePhasesGreen),
				typeof(PhaseRefGreen),
				typeof(EnumDeclarationGreen),
				typeof(EnumBodyGreen),
				typeof(EnumValuesGreen),
				typeof(EnumValueGreen),
				typeof(EnumMemberDeclarationGreen),
				typeof(ClassDeclarationGreen),
				typeof(ClassAncestorsGreen),
				typeof(ClassAncestorGreen),
				typeof(ClassBodyGreen),
				typeof(ClassMemberDeclarationGreen),
				typeof(ClassKindGreen),
				typeof(FieldDeclarationGreen),
				typeof(FieldContainmentGreen),
				typeof(FieldModifierGreen),
				typeof(DefaultValueGreen),
				typeof(PhaseGreen),
				typeof(NameUseListGreen),
				typeof(TypedefDeclarationGreen),
				typeof(TypedefValueGreen),
				typeof(ReturnTypeGreen),
				typeof(TypeOfReferenceGreen),
				typeof(TypeReferenceGreen),
				typeof(SimpleTypeGreen),
				typeof(ClassTypeGreen),
				typeof(ObjectTypeGreen),
				typeof(PrimitiveTypeGreen),
				typeof(VoidTypeGreen),
				typeof(NullableTypeGreen),
				typeof(GenericTypeGreen),
				typeof(GenericTypeNameGreen),
				typeof(TypeArgumentsGreen),
				typeof(TypeArgumentGreen),
				typeof(OperationDeclarationGreen),
				typeof(ParameterListGreen),
				typeof(ParameterGreen),
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


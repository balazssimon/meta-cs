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

namespace MetaDslx.Languages.Compiler.Syntax.InternalSyntax
{
    using System.Runtime.CompilerServices;
    using MetaDslx.CodeAnalysis;
    using MetaDslx.CodeAnalysis.Syntax;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Syntax;
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
            if (visitor is CompilerSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is CompilerSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor);
        public abstract void Accept(CompilerSyntaxVisitor visitor);

        public new CompilerLanguage Language => CompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new CompilerSyntaxKind Kind => (CompilerSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

		// Use conditional weak table so we always return same identity for structured trivia
		private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
			= new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

		/// <summary>
		/// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
		/// determine if this trivia has structure.
		/// </summary>
		/// <returns>
		/// A CompilerSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
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
							structure = CompilerStructuredTriviaSyntax.Create(trivia);
							structsInParent.Add(trivia, structure);
						}
					}

					return structure;
				}
				else
				{
					return CompilerStructuredTriviaSyntax.Create(trivia);
				}
			}

			return null;
		}

	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(CompilerSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new CompilerLanguage Language => CompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new CompilerSyntaxKind Kind => EnumObject.FromIntUnsafe<CompilerSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(CompilerSyntaxKind kind, string text)
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

        public override GreenNode Clone()
        {
			return new GreenSyntaxTrivia(this.Kind, this.Text, GetDiagnostics(), GetAnnotations());
		}

        public static implicit operator SyntaxTrivia(GreenSyntaxTrivia trivia)
        {
            return new SyntaxTrivia(default, trivia, position: 0, index: 0);
        }
    }

    internal abstract class GreenStructuredTriviaSyntax : GreenSyntaxNode
    {
        internal GreenStructuredTriviaSyntax(CompilerSyntaxKind kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        internal GreenSkippedTokensTriviaSyntax(CompilerSyntaxKind kind, GreenNode tokens, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position) => new CompilerSkippedTokensTriviaSyntax(this, (CompilerSyntaxNode)parent, position);

        public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitSkippedTokensTrivia(this);

        public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitSkippedTokensTrivia(this);

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

        public override GreenNode Clone()
        {
			return new GreenSkippedTokensTriviaSyntax(this.Kind, this.tokens, GetDiagnostics(), GetAnnotations());
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
	    internal GreenSyntaxToken(CompilerSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(CompilerSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(CompilerSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(CompilerSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(CompilerSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(CompilerSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new CompilerLanguage Language => CompilerLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new CompilerSyntaxKind Kind => EnumObject.FromIntUnsafe<CompilerSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(CompilerSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!CompilerLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid CompilerSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(CompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!CompilerLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid CompilerSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == CompilerLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == CompilerLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == CompilerLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == CompilerLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(CompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly CompilerSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly CompilerSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = CompilerSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = CompilerSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = CompilerLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((CompilerSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((CompilerSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((CompilerSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((CompilerSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(CompilerSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(CompilerSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(CompilerSyntaxKind kind, CompilerSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(CompilerSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(CompilerSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual CompilerSyntaxKind ContextualKind => this.Kind;
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
		public override GreenNode Clone()
		{
	        System.Diagnostics.Debug.Assert(this.GetType() == typeof(GreenSyntaxToken));
			return new GreenSyntaxToken(this.Kind, this.FullWidth, GetDiagnostics(), GetAnnotations());
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
	        internal MissingTokenWithTrivia(CompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(CompilerSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
		    public override GreenNode Clone()
		    {
			    return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
		    }
	    }
	
	    internal class SyntaxIdentifier : GreenSyntaxToken
	    {
	        static SyntaxIdentifier()
	        {
	            ObjectBinder.RegisterTypeReader(typeof(SyntaxIdentifier), r => new SyntaxIdentifier(r));
	        }
	        protected readonly string TextField;
	        internal SyntaxIdentifier(CompilerSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(CompilerSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxIdentifier(this.Kind, this.Text, this.GetDiagnostics(), this.GetAnnotations());
		    }
	    }
	
	    internal class SyntaxIdentifierExtended : SyntaxIdentifier
	    {
	        protected readonly CompilerSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(CompilerSyntaxKind kind, CompilerSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(CompilerSyntaxKind kind, CompilerSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<CompilerSyntaxKind>(reader.ReadInt32());
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
	        public override CompilerSyntaxKind ContextualKind
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxIdentifierExtended(this.Kind, this.contextualKind, this.TextField, this.valueText, this.GetDiagnostics(), this.GetAnnotations());
		    }
	    }
	
		internal class SyntaxIdentifierWithTrailingTrivia : SyntaxIdentifier
	    {
	        private readonly GreenNode _trailing;
	        internal SyntaxIdentifierWithTrailingTrivia(CompilerSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(CompilerSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxIdentifierWithTrailingTrivia(this.Kind, this.TextField, _trailing, this.GetDiagnostics(), this.GetAnnotations());
		    }
	    }
	
	    internal class SyntaxIdentifierWithTrivia : SyntaxIdentifierExtended
	    {
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	        internal SyntaxIdentifierWithTrivia(
	            CompilerSyntaxKind kind,
	            CompilerSyntaxKind contextualKind,
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
	            CompilerSyntaxKind kind,
	            CompilerSyntaxKind contextualKind,
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxIdentifierWithTrivia(this.Kind, this.contextualKind, this.TextField, this.valueText, _leading, _trailing, this.GetDiagnostics(), this.GetAnnotations());
		    }
	    }
	
	    internal class SyntaxTokenWithValue<T> : GreenSyntaxToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	        internal SyntaxTokenWithValue(CompilerSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(CompilerSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, this.GetDiagnostics(), this.GetAnnotations());
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
	        internal SyntaxTokenWithValueAndTrivia(CompilerSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            CompilerSyntaxKind kind,
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, this.GetDiagnostics(), this.GetAnnotations());
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
	        internal SyntaxTokenWithTrivia(CompilerSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(CompilerSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
		    public override GreenNode Clone()
		    {
			    return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
		    }
	    }
	}
	
	internal class MainGreen : GreenSyntaxNode
	{
	    internal static readonly MainGreen __Missing = new MainGreen();
	    private NamespaceDeclarationGreen namespaceDeclaration;
	    private InternalSyntaxToken eOF;
	
	    public MainGreen(CompilerSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
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
	
	    public MainGreen(CompilerSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NamespaceDeclarationGreen NamespaceDeclaration { get { return this.namespaceDeclaration; } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.MainSyntax(this, (CompilerSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eOF, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eOF, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new MainGreen(this.Kind, this.namespaceDeclaration, this.eOF, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public MainGreen Update(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.EndOfFileToken != eOF)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, eOF);
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
	
	internal class AnnotationGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationGreen __Missing = new AnnotationGreen();
	    private InternalSyntaxToken tOpenBracket;
	    private NameGreen name;
	    private InternalSyntaxToken tCloseBracket;
	
	    public AnnotationGreen(CompilerSyntaxKind kind, InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public AnnotationGreen(CompilerSyntaxKind kind, InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private AnnotationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Annotation, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.AnnotationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.name;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitAnnotationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.name, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.name, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AnnotationGreen(this.Kind, this.tOpenBracket, this.name, this.tCloseBracket, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AnnotationGreen Update(InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.Name != name ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Annotation(tOpenBracket, name, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationGreen)newNode;
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
	    private NamespaceBodyGreen namespaceBody;
	
	    public NamespaceDeclarationGreen(CompilerSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, NamespaceBodyGreen namespaceBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
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
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
	    public NamespaceDeclarationGreen(CompilerSyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
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
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
		private NamespaceDeclarationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.NamespaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.NamespaceDeclarationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            case 3: return this.namespaceBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.kNamespace, this.qualifiedName, this.tSemicolon, this.namespaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.kNamespace, this.qualifiedName, this.tSemicolon, this.namespaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NamespaceDeclarationGreen(this.Kind, this.kNamespace, this.qualifiedName, this.tSemicolon, this.namespaceBody, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NamespaceDeclarationGreen Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, NamespaceBodyGreen namespaceBody)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.TSemicolon != tSemicolon ||
				this.NamespaceBody != namespaceBody)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(kNamespace, qualifiedName, tSemicolon, namespaceBody);
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
	    private GreenNode usingDeclaration;
	    private GrammarDeclarationGreen grammarDeclaration;
	
	    public NamespaceBodyGreen(CompilerSyntaxKind kind, GreenNode usingDeclaration, GrammarDeclarationGreen grammarDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (usingDeclaration != null)
			{
				this.AdjustFlagsAndWidth(usingDeclaration);
				this.usingDeclaration = usingDeclaration;
			}
			if (grammarDeclaration != null)
			{
				this.AdjustFlagsAndWidth(grammarDeclaration);
				this.grammarDeclaration = grammarDeclaration;
			}
	    }
	
	    public NamespaceBodyGreen(CompilerSyntaxKind kind, GreenNode usingDeclaration, GrammarDeclarationGreen grammarDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (usingDeclaration != null)
			{
				this.AdjustFlagsAndWidth(usingDeclaration);
				this.usingDeclaration = usingDeclaration;
			}
			if (grammarDeclaration != null)
			{
				this.AdjustFlagsAndWidth(grammarDeclaration);
				this.grammarDeclaration = grammarDeclaration;
			}
	    }
	
		private NamespaceBodyGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.NamespaceBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen> UsingDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen>(this.usingDeclaration); } }
	    public GrammarDeclarationGreen GrammarDeclaration { get { return this.grammarDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.NamespaceBodySyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.usingDeclaration;
	            case 1: return this.grammarDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.usingDeclaration, this.grammarDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.usingDeclaration, this.grammarDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NamespaceBodyGreen(this.Kind, this.usingDeclaration, this.grammarDeclaration, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NamespaceBodyGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen> usingDeclaration, GrammarDeclarationGreen grammarDeclaration)
	    {
	        if (this.UsingDeclaration != usingDeclaration ||
				this.GrammarDeclaration != grammarDeclaration)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.NamespaceBody(usingDeclaration, grammarDeclaration);
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
	
	internal class GrammarDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly GrammarDeclarationGreen __Missing = new GrammarDeclarationGreen();
	    private GreenNode annotation;
	    private InternalSyntaxToken kGrammar;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	    private RuleDeclarationsGreen ruleDeclarations;
	
	    public GrammarDeclarationGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken kGrammar, NameGreen name, InternalSyntaxToken tSemicolon, RuleDeclarationsGreen ruleDeclarations)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (kGrammar != null)
			{
				this.AdjustFlagsAndWidth(kGrammar);
				this.kGrammar = kGrammar;
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
			if (ruleDeclarations != null)
			{
				this.AdjustFlagsAndWidth(ruleDeclarations);
				this.ruleDeclarations = ruleDeclarations;
			}
	    }
	
	    public GrammarDeclarationGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken kGrammar, NameGreen name, InternalSyntaxToken tSemicolon, RuleDeclarationsGreen ruleDeclarations, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (kGrammar != null)
			{
				this.AdjustFlagsAndWidth(kGrammar);
				this.kGrammar = kGrammar;
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
			if (ruleDeclarations != null)
			{
				this.AdjustFlagsAndWidth(ruleDeclarations);
				this.ruleDeclarations = ruleDeclarations;
			}
	    }
	
		private GrammarDeclarationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.GrammarDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public InternalSyntaxToken KGrammar { get { return this.kGrammar; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public RuleDeclarationsGreen RuleDeclarations { get { return this.ruleDeclarations; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.GrammarDeclarationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kGrammar;
	            case 2: return this.name;
	            case 3: return this.tSemicolon;
	            case 4: return this.ruleDeclarations;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitGrammarDeclarationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitGrammarDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GrammarDeclarationGreen(this.Kind, this.annotation, this.kGrammar, this.name, this.tSemicolon, this.ruleDeclarations, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GrammarDeclarationGreen(this.Kind, this.annotation, this.kGrammar, this.name, this.tSemicolon, this.ruleDeclarations, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new GrammarDeclarationGreen(this.Kind, this.annotation, this.kGrammar, this.name, this.tSemicolon, this.ruleDeclarations, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public GrammarDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken kGrammar, NameGreen name, InternalSyntaxToken tSemicolon, RuleDeclarationsGreen ruleDeclarations)
	    {
	        if (this.Annotation != annotation ||
				this.KGrammar != kGrammar ||
				this.Name != name ||
				this.TSemicolon != tSemicolon ||
				this.RuleDeclarations != ruleDeclarations)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.GrammarDeclaration(annotation, kGrammar, name, tSemicolon, ruleDeclarations);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GrammarDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UsingDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly UsingDeclarationGreen __Missing = new UsingDeclarationGreen();
	    private InternalSyntaxToken kUsing;
	    private NameGreen name;
	    private InternalSyntaxToken tAssign;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public UsingDeclarationGreen(CompilerSyntaxKind kind, InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kUsing != null)
			{
				this.AdjustFlagsAndWidth(kUsing);
				this.kUsing = kUsing;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public UsingDeclarationGreen(CompilerSyntaxKind kind, InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kUsing != null)
			{
				this.AdjustFlagsAndWidth(kUsing);
				this.kUsing = kUsing;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private UsingDeclarationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.UsingDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KUsing { get { return this.kUsing; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.UsingDeclarationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kUsing;
	            case 1: return this.name;
	            case 2: return this.tAssign;
	            case 3: return this.qualifier;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitUsingDeclarationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitUsingDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UsingDeclarationGreen(this.Kind, this.kUsing, this.name, this.tAssign, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UsingDeclarationGreen(this.Kind, this.kUsing, this.name, this.tAssign, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new UsingDeclarationGreen(this.Kind, this.kUsing, this.name, this.tAssign, this.qualifier, this.tSemicolon, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public UsingDeclarationGreen Update(InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.Name != name ||
				this.TAssign != tAssign ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.UsingDeclaration(kUsing, name, tAssign, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RuleDeclarationsGreen : GreenSyntaxNode
	{
	    internal static readonly RuleDeclarationsGreen __Missing = new RuleDeclarationsGreen();
	    private GreenNode ruleDeclaration;
	
	    public RuleDeclarationsGreen(CompilerSyntaxKind kind, GreenNode ruleDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (ruleDeclaration != null)
			{
				this.AdjustFlagsAndWidth(ruleDeclaration);
				this.ruleDeclaration = ruleDeclaration;
			}
	    }
	
	    public RuleDeclarationsGreen(CompilerSyntaxKind kind, GreenNode ruleDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (ruleDeclaration != null)
			{
				this.AdjustFlagsAndWidth(ruleDeclaration);
				this.ruleDeclaration = ruleDeclaration;
			}
	    }
	
		private RuleDeclarationsGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.RuleDeclarations, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuleDeclarationGreen> RuleDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuleDeclarationGreen>(this.ruleDeclaration); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.RuleDeclarationsSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.ruleDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitRuleDeclarationsGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitRuleDeclarationsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RuleDeclarationsGreen(this.Kind, this.ruleDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RuleDeclarationsGreen(this.Kind, this.ruleDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new RuleDeclarationsGreen(this.Kind, this.ruleDeclaration, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public RuleDeclarationsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuleDeclarationGreen> ruleDeclaration)
	    {
	        if (this.RuleDeclaration != ruleDeclaration)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.RuleDeclarations(ruleDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuleDeclarationsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RuleDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly RuleDeclarationGreen __Missing = new RuleDeclarationGreen();
	    private ParserRuleDeclarationGreen parserRuleDeclaration;
	    private LexerRuleDeclarationGreen lexerRuleDeclaration;
	
	    public RuleDeclarationGreen(CompilerSyntaxKind kind, ParserRuleDeclarationGreen parserRuleDeclaration, LexerRuleDeclarationGreen lexerRuleDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (parserRuleDeclaration != null)
			{
				this.AdjustFlagsAndWidth(parserRuleDeclaration);
				this.parserRuleDeclaration = parserRuleDeclaration;
			}
			if (lexerRuleDeclaration != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleDeclaration);
				this.lexerRuleDeclaration = lexerRuleDeclaration;
			}
	    }
	
	    public RuleDeclarationGreen(CompilerSyntaxKind kind, ParserRuleDeclarationGreen parserRuleDeclaration, LexerRuleDeclarationGreen lexerRuleDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (parserRuleDeclaration != null)
			{
				this.AdjustFlagsAndWidth(parserRuleDeclaration);
				this.parserRuleDeclaration = parserRuleDeclaration;
			}
			if (lexerRuleDeclaration != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleDeclaration);
				this.lexerRuleDeclaration = lexerRuleDeclaration;
			}
	    }
	
		private RuleDeclarationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.RuleDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ParserRuleDeclarationGreen ParserRuleDeclaration { get { return this.parserRuleDeclaration; } }
	    public LexerRuleDeclarationGreen LexerRuleDeclaration { get { return this.lexerRuleDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.RuleDeclarationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parserRuleDeclaration;
	            case 1: return this.lexerRuleDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitRuleDeclarationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitRuleDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RuleDeclarationGreen(this.Kind, this.parserRuleDeclaration, this.lexerRuleDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RuleDeclarationGreen(this.Kind, this.parserRuleDeclaration, this.lexerRuleDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new RuleDeclarationGreen(this.Kind, this.parserRuleDeclaration, this.lexerRuleDeclaration, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public RuleDeclarationGreen Update(ParserRuleDeclarationGreen parserRuleDeclaration)
	    {
	        if (this.parserRuleDeclaration != parserRuleDeclaration)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.RuleDeclaration(parserRuleDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuleDeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public RuleDeclarationGreen Update(LexerRuleDeclarationGreen lexerRuleDeclaration)
	    {
	        if (this.lexerRuleDeclaration != lexerRuleDeclaration)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.RuleDeclaration(lexerRuleDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuleDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleDeclarationGreen __Missing = new ParserRuleDeclarationGreen();
	    private ParserRuleAltGreen parserRuleAlt;
	    private ParserRuleSimpleGreen parserRuleSimple;
	
	    public ParserRuleDeclarationGreen(CompilerSyntaxKind kind, ParserRuleAltGreen parserRuleAlt, ParserRuleSimpleGreen parserRuleSimple)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (parserRuleAlt != null)
			{
				this.AdjustFlagsAndWidth(parserRuleAlt);
				this.parserRuleAlt = parserRuleAlt;
			}
			if (parserRuleSimple != null)
			{
				this.AdjustFlagsAndWidth(parserRuleSimple);
				this.parserRuleSimple = parserRuleSimple;
			}
	    }
	
	    public ParserRuleDeclarationGreen(CompilerSyntaxKind kind, ParserRuleAltGreen parserRuleAlt, ParserRuleSimpleGreen parserRuleSimple, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (parserRuleAlt != null)
			{
				this.AdjustFlagsAndWidth(parserRuleAlt);
				this.parserRuleAlt = parserRuleAlt;
			}
			if (parserRuleSimple != null)
			{
				this.AdjustFlagsAndWidth(parserRuleSimple);
				this.parserRuleSimple = parserRuleSimple;
			}
	    }
	
		private ParserRuleDeclarationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ParserRuleAltGreen ParserRuleAlt { get { return this.parserRuleAlt; } }
	    public ParserRuleSimpleGreen ParserRuleSimple { get { return this.parserRuleSimple; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleDeclarationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parserRuleAlt;
	            case 1: return this.parserRuleSimple;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleDeclarationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleDeclarationGreen(this.Kind, this.parserRuleAlt, this.parserRuleSimple, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleDeclarationGreen(this.Kind, this.parserRuleAlt, this.parserRuleSimple, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleDeclarationGreen(this.Kind, this.parserRuleAlt, this.parserRuleSimple, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleDeclarationGreen Update(ParserRuleAltGreen parserRuleAlt)
	    {
	        if (this.parserRuleAlt != parserRuleAlt)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleDeclaration(parserRuleAlt);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleDeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleDeclarationGreen Update(ParserRuleSimpleGreen parserRuleSimple)
	    {
	        if (this.parserRuleSimple != parserRuleSimple)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleDeclaration(parserRuleSimple);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleAltGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleAltGreen __Missing = new ParserRuleAltGreen();
	    private GreenNode annotation;
	    private ParserRuleNameGreen parserRuleName;
	    private InternalSyntaxToken kDefines;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tColon;
	    private GreenNode parserRuleAltRef;
	    private InternalSyntaxToken tSemicolon;
	
	    public ParserRuleAltGreen(CompilerSyntaxKind kind, GreenNode annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, GreenNode parserRuleAltRef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (parserRuleName != null)
			{
				this.AdjustFlagsAndWidth(parserRuleName);
				this.parserRuleName = parserRuleName;
			}
			if (kDefines != null)
			{
				this.AdjustFlagsAndWidth(kDefines);
				this.kDefines = kDefines;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (parserRuleAltRef != null)
			{
				this.AdjustFlagsAndWidth(parserRuleAltRef);
				this.parserRuleAltRef = parserRuleAltRef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ParserRuleAltGreen(CompilerSyntaxKind kind, GreenNode annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, GreenNode parserRuleAltRef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (parserRuleName != null)
			{
				this.AdjustFlagsAndWidth(parserRuleName);
				this.parserRuleName = parserRuleName;
			}
			if (kDefines != null)
			{
				this.AdjustFlagsAndWidth(kDefines);
				this.kDefines = kDefines;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (parserRuleAltRef != null)
			{
				this.AdjustFlagsAndWidth(parserRuleAltRef);
				this.parserRuleAltRef = parserRuleAltRef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ParserRuleAltGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleAlt, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public ParserRuleNameGreen ParserRuleName { get { return this.parserRuleName; } }
	    public InternalSyntaxToken KDefines { get { return this.kDefines; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParserRuleAltRefGreen> ParserRuleAltRef { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParserRuleAltRefGreen>(this.parserRuleAltRef); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleAltSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.parserRuleName;
	            case 2: return this.kDefines;
	            case 3: return this.qualifier;
	            case 4: return this.tColon;
	            case 5: return this.parserRuleAltRef;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleAltGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleAltGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleAltGreen(this.Kind, this.annotation, this.parserRuleName, this.kDefines, this.qualifier, this.tColon, this.parserRuleAltRef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleAltGreen(this.Kind, this.annotation, this.parserRuleName, this.kDefines, this.qualifier, this.tColon, this.parserRuleAltRef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleAltGreen(this.Kind, this.annotation, this.parserRuleName, this.kDefines, this.qualifier, this.tColon, this.parserRuleAltRef, this.tSemicolon, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleAltGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParserRuleAltRefGreen> parserRuleAltRef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Annotation != annotation ||
				this.ParserRuleName != parserRuleName ||
				this.KDefines != kDefines ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.ParserRuleAltRef != parserRuleAltRef ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAlt(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleAltRef, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAltGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleAltRefGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleAltRefGreen __Missing = new ParserRuleAltRefGreen();
	    private ParserRuleIdentifierGreen parserRuleIdentifier;
	
	    public ParserRuleAltRefGreen(CompilerSyntaxKind kind, ParserRuleIdentifierGreen parserRuleIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parserRuleIdentifier != null)
			{
				this.AdjustFlagsAndWidth(parserRuleIdentifier);
				this.parserRuleIdentifier = parserRuleIdentifier;
			}
	    }
	
	    public ParserRuleAltRefGreen(CompilerSyntaxKind kind, ParserRuleIdentifierGreen parserRuleIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (parserRuleIdentifier != null)
			{
				this.AdjustFlagsAndWidth(parserRuleIdentifier);
				this.parserRuleIdentifier = parserRuleIdentifier;
			}
	    }
	
		private ParserRuleAltRefGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleAltRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ParserRuleIdentifierGreen ParserRuleIdentifier { get { return this.parserRuleIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleAltRefSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parserRuleIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleAltRefGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleAltRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleAltRefGreen(this.Kind, this.parserRuleIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleAltRefGreen(this.Kind, this.parserRuleIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleAltRefGreen(this.Kind, this.parserRuleIdentifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleAltRefGreen Update(ParserRuleIdentifierGreen parserRuleIdentifier)
	    {
	        if (this.ParserRuleIdentifier != parserRuleIdentifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAltRef(parserRuleIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAltRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleSimpleGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleSimpleGreen __Missing = new ParserRuleSimpleGreen();
	    private GreenNode annotation;
	    private ParserRuleNameGreen parserRuleName;
	    private InternalSyntaxToken kDefines;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tColon;
	    private GreenNode parserRuleNamedElement;
	    private EofElementGreen eofElement;
	    private InternalSyntaxToken tSemicolon;
	
	    public ParserRuleSimpleGreen(CompilerSyntaxKind kind, GreenNode annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, GreenNode parserRuleNamedElement, EofElementGreen eofElement, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (parserRuleName != null)
			{
				this.AdjustFlagsAndWidth(parserRuleName);
				this.parserRuleName = parserRuleName;
			}
			if (kDefines != null)
			{
				this.AdjustFlagsAndWidth(kDefines);
				this.kDefines = kDefines;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (parserRuleNamedElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleNamedElement);
				this.parserRuleNamedElement = parserRuleNamedElement;
			}
			if (eofElement != null)
			{
				this.AdjustFlagsAndWidth(eofElement);
				this.eofElement = eofElement;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ParserRuleSimpleGreen(CompilerSyntaxKind kind, GreenNode annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, GreenNode parserRuleNamedElement, EofElementGreen eofElement, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (parserRuleName != null)
			{
				this.AdjustFlagsAndWidth(parserRuleName);
				this.parserRuleName = parserRuleName;
			}
			if (kDefines != null)
			{
				this.AdjustFlagsAndWidth(kDefines);
				this.kDefines = kDefines;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (parserRuleNamedElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleNamedElement);
				this.parserRuleNamedElement = parserRuleNamedElement;
			}
			if (eofElement != null)
			{
				this.AdjustFlagsAndWidth(eofElement);
				this.eofElement = eofElement;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ParserRuleSimpleGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleSimple, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public ParserRuleNameGreen ParserRuleName { get { return this.parserRuleName; } }
	    public InternalSyntaxToken KDefines { get { return this.kDefines; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen> ParserRuleNamedElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen>(this.parserRuleNamedElement); } }
	    public EofElementGreen EofElement { get { return this.eofElement; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleSimpleSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.parserRuleName;
	            case 2: return this.kDefines;
	            case 3: return this.qualifier;
	            case 4: return this.tColon;
	            case 5: return this.parserRuleNamedElement;
	            case 6: return this.eofElement;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleSimpleGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleSimpleGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleSimpleGreen(this.Kind, this.annotation, this.parserRuleName, this.kDefines, this.qualifier, this.tColon, this.parserRuleNamedElement, this.eofElement, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleSimpleGreen(this.Kind, this.annotation, this.parserRuleName, this.kDefines, this.qualifier, this.tColon, this.parserRuleNamedElement, this.eofElement, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleSimpleGreen(this.Kind, this.annotation, this.parserRuleName, this.kDefines, this.qualifier, this.tColon, this.parserRuleNamedElement, this.eofElement, this.tSemicolon, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleSimpleGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen> parserRuleNamedElement, EofElementGreen eofElement, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Annotation != annotation ||
				this.ParserRuleName != parserRuleName ||
				this.KDefines != kDefines ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.ParserRuleNamedElement != parserRuleNamedElement ||
				this.EofElement != eofElement ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleSimple(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleNamedElement, eofElement, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleSimpleGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EofElementGreen : GreenSyntaxNode
	{
	    internal static readonly EofElementGreen __Missing = new EofElementGreen();
	    private InternalSyntaxToken kEof;
	
	    public EofElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken kEof)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kEof != null)
			{
				this.AdjustFlagsAndWidth(kEof);
				this.kEof = kEof;
			}
	    }
	
	    public EofElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken kEof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kEof != null)
			{
				this.AdjustFlagsAndWidth(kEof);
				this.kEof = kEof;
			}
	    }
	
		private EofElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.EofElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEof { get { return this.kEof; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.EofElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEof;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitEofElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitEofElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EofElementGreen(this.Kind, this.kEof, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EofElementGreen(this.Kind, this.kEof, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new EofElementGreen(this.Kind, this.kEof, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public EofElementGreen Update(InternalSyntaxToken kEof)
	    {
	        if (this.KEof != kEof)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.EofElement(kEof);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EofElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleNamedElementGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleNamedElementGreen __Missing = new ParserRuleNamedElementGreen();
	    private GreenNode annotation;
	    private ElementNameGreen elementName;
	    private AssignGreen assign;
	    private ParserNegatedElementGreen parserNegatedElement;
	    private MultiplicityGreen multiplicity;
	
	    public ParserRuleNamedElementGreen(CompilerSyntaxKind kind, GreenNode annotation, ElementNameGreen elementName, AssignGreen assign, ParserNegatedElementGreen parserNegatedElement, MultiplicityGreen multiplicity)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (elementName != null)
			{
				this.AdjustFlagsAndWidth(elementName);
				this.elementName = elementName;
			}
			if (assign != null)
			{
				this.AdjustFlagsAndWidth(assign);
				this.assign = assign;
			}
			if (parserNegatedElement != null)
			{
				this.AdjustFlagsAndWidth(parserNegatedElement);
				this.parserNegatedElement = parserNegatedElement;
			}
			if (multiplicity != null)
			{
				this.AdjustFlagsAndWidth(multiplicity);
				this.multiplicity = multiplicity;
			}
	    }
	
	    public ParserRuleNamedElementGreen(CompilerSyntaxKind kind, GreenNode annotation, ElementNameGreen elementName, AssignGreen assign, ParserNegatedElementGreen parserNegatedElement, MultiplicityGreen multiplicity, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (elementName != null)
			{
				this.AdjustFlagsAndWidth(elementName);
				this.elementName = elementName;
			}
			if (assign != null)
			{
				this.AdjustFlagsAndWidth(assign);
				this.assign = assign;
			}
			if (parserNegatedElement != null)
			{
				this.AdjustFlagsAndWidth(parserNegatedElement);
				this.parserNegatedElement = parserNegatedElement;
			}
			if (multiplicity != null)
			{
				this.AdjustFlagsAndWidth(multiplicity);
				this.multiplicity = multiplicity;
			}
	    }
	
		private ParserRuleNamedElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleNamedElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public ElementNameGreen ElementName { get { return this.elementName; } }
	    public AssignGreen Assign { get { return this.assign; } }
	    public ParserNegatedElementGreen ParserNegatedElement { get { return this.parserNegatedElement; } }
	    public MultiplicityGreen Multiplicity { get { return this.multiplicity; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleNamedElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.elementName;
	            case 2: return this.assign;
	            case 3: return this.parserNegatedElement;
	            case 4: return this.multiplicity;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleNamedElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleNamedElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleNamedElementGreen(this.Kind, this.annotation, this.elementName, this.assign, this.parserNegatedElement, this.multiplicity, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleNamedElementGreen(this.Kind, this.annotation, this.elementName, this.assign, this.parserNegatedElement, this.multiplicity, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleNamedElementGreen(this.Kind, this.annotation, this.elementName, this.assign, this.parserNegatedElement, this.multiplicity, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleNamedElementGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, ElementNameGreen elementName, AssignGreen assign, ParserNegatedElementGreen parserNegatedElement, MultiplicityGreen multiplicity)
	    {
	        if (this.Annotation != annotation ||
				this.ElementName != elementName ||
				this.Assign != assign ||
				this.ParserNegatedElement != parserNegatedElement ||
				this.Multiplicity != multiplicity)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleNamedElement(annotation, elementName, assign, parserNegatedElement, multiplicity);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleNamedElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssignGreen : GreenSyntaxNode
	{
	    internal static readonly AssignGreen __Missing = new AssignGreen();
	    private InternalSyntaxToken assign;
	
	    public AssignGreen(CompilerSyntaxKind kind, InternalSyntaxToken assign)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (assign != null)
			{
				this.AdjustFlagsAndWidth(assign);
				this.assign = assign;
			}
	    }
	
	    public AssignGreen(CompilerSyntaxKind kind, InternalSyntaxToken assign, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (assign != null)
			{
				this.AdjustFlagsAndWidth(assign);
				this.assign = assign;
			}
	    }
	
		private AssignGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Assign, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Assign { get { return this.assign; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.AssignSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.assign;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitAssignGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitAssignGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssignGreen(this.Kind, this.assign, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssignGreen(this.Kind, this.assign, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AssignGreen(this.Kind, this.assign, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AssignGreen Update(InternalSyntaxToken assign)
	    {
	        if (this.Assign != assign)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Assign(assign);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MultiplicityGreen : GreenSyntaxNode
	{
	    internal static readonly MultiplicityGreen __Missing = new MultiplicityGreen();
	    private InternalSyntaxToken multiplicity;
	
	    public MultiplicityGreen(CompilerSyntaxKind kind, InternalSyntaxToken multiplicity)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (multiplicity != null)
			{
				this.AdjustFlagsAndWidth(multiplicity);
				this.multiplicity = multiplicity;
			}
	    }
	
	    public MultiplicityGreen(CompilerSyntaxKind kind, InternalSyntaxToken multiplicity, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (multiplicity != null)
			{
				this.AdjustFlagsAndWidth(multiplicity);
				this.multiplicity = multiplicity;
			}
	    }
	
		private MultiplicityGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Multiplicity, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Multiplicity { get { return this.multiplicity; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.MultiplicitySyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.multiplicity;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitMultiplicityGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitMultiplicityGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MultiplicityGreen(this.Kind, this.multiplicity, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MultiplicityGreen(this.Kind, this.multiplicity, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new MultiplicityGreen(this.Kind, this.multiplicity, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public MultiplicityGreen Update(InternalSyntaxToken multiplicity)
	    {
	        if (this.Multiplicity != multiplicity)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Multiplicity(multiplicity);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiplicityGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserNegatedElementGreen : GreenSyntaxNode
	{
	    internal static readonly ParserNegatedElementGreen __Missing = new ParserNegatedElementGreen();
	    private InternalSyntaxToken tNegate;
	    private ParserRuleElementGreen parserRuleElement;
	
	    public ParserNegatedElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tNegate, ParserRuleElementGreen parserRuleElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (tNegate != null)
			{
				this.AdjustFlagsAndWidth(tNegate);
				this.tNegate = tNegate;
			}
			if (parserRuleElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleElement);
				this.parserRuleElement = parserRuleElement;
			}
	    }
	
	    public ParserNegatedElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tNegate, ParserRuleElementGreen parserRuleElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (tNegate != null)
			{
				this.AdjustFlagsAndWidth(tNegate);
				this.tNegate = tNegate;
			}
			if (parserRuleElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleElement);
				this.parserRuleElement = parserRuleElement;
			}
	    }
	
		private ParserNegatedElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserNegatedElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TNegate { get { return this.tNegate; } }
	    public ParserRuleElementGreen ParserRuleElement { get { return this.parserRuleElement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserNegatedElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tNegate;
	            case 1: return this.parserRuleElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserNegatedElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserNegatedElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserNegatedElementGreen(this.Kind, this.tNegate, this.parserRuleElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserNegatedElementGreen(this.Kind, this.tNegate, this.parserRuleElement, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserNegatedElementGreen(this.Kind, this.tNegate, this.parserRuleElement, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserNegatedElementGreen Update(InternalSyntaxToken tNegate, ParserRuleElementGreen parserRuleElement)
	    {
	        if (this.TNegate != tNegate ||
				this.ParserRuleElement != parserRuleElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserNegatedElement(tNegate, parserRuleElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserNegatedElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleElementGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleElementGreen __Missing = new ParserRuleElementGreen();
	    private ParserRuleFixedElementGreen parserRuleFixedElement;
	    private ParserRuleReferenceGreen parserRuleReference;
	    private ParserRuleWildcardElementGreen parserRuleWildcardElement;
	    private ParserRuleBlockElementGreen parserRuleBlockElement;
	
	    public ParserRuleElementGreen(CompilerSyntaxKind kind, ParserRuleFixedElementGreen parserRuleFixedElement, ParserRuleReferenceGreen parserRuleReference, ParserRuleWildcardElementGreen parserRuleWildcardElement, ParserRuleBlockElementGreen parserRuleBlockElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (parserRuleFixedElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleFixedElement);
				this.parserRuleFixedElement = parserRuleFixedElement;
			}
			if (parserRuleReference != null)
			{
				this.AdjustFlagsAndWidth(parserRuleReference);
				this.parserRuleReference = parserRuleReference;
			}
			if (parserRuleWildcardElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleWildcardElement);
				this.parserRuleWildcardElement = parserRuleWildcardElement;
			}
			if (parserRuleBlockElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleBlockElement);
				this.parserRuleBlockElement = parserRuleBlockElement;
			}
	    }
	
	    public ParserRuleElementGreen(CompilerSyntaxKind kind, ParserRuleFixedElementGreen parserRuleFixedElement, ParserRuleReferenceGreen parserRuleReference, ParserRuleWildcardElementGreen parserRuleWildcardElement, ParserRuleBlockElementGreen parserRuleBlockElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (parserRuleFixedElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleFixedElement);
				this.parserRuleFixedElement = parserRuleFixedElement;
			}
			if (parserRuleReference != null)
			{
				this.AdjustFlagsAndWidth(parserRuleReference);
				this.parserRuleReference = parserRuleReference;
			}
			if (parserRuleWildcardElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleWildcardElement);
				this.parserRuleWildcardElement = parserRuleWildcardElement;
			}
			if (parserRuleBlockElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleBlockElement);
				this.parserRuleBlockElement = parserRuleBlockElement;
			}
	    }
	
		private ParserRuleElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ParserRuleFixedElementGreen ParserRuleFixedElement { get { return this.parserRuleFixedElement; } }
	    public ParserRuleReferenceGreen ParserRuleReference { get { return this.parserRuleReference; } }
	    public ParserRuleWildcardElementGreen ParserRuleWildcardElement { get { return this.parserRuleWildcardElement; } }
	    public ParserRuleBlockElementGreen ParserRuleBlockElement { get { return this.parserRuleBlockElement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parserRuleFixedElement;
	            case 1: return this.parserRuleReference;
	            case 2: return this.parserRuleWildcardElement;
	            case 3: return this.parserRuleBlockElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleElementGreen(this.Kind, this.parserRuleFixedElement, this.parserRuleReference, this.parserRuleWildcardElement, this.parserRuleBlockElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleElementGreen(this.Kind, this.parserRuleFixedElement, this.parserRuleReference, this.parserRuleWildcardElement, this.parserRuleBlockElement, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleElementGreen(this.Kind, this.parserRuleFixedElement, this.parserRuleReference, this.parserRuleWildcardElement, this.parserRuleBlockElement, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleElementGreen Update(ParserRuleFixedElementGreen parserRuleFixedElement)
	    {
	        if (this.parserRuleFixedElement != parserRuleFixedElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement(parserRuleFixedElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleElementGreen Update(ParserRuleReferenceGreen parserRuleReference)
	    {
	        if (this.parserRuleReference != parserRuleReference)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement(parserRuleReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleElementGreen Update(ParserRuleWildcardElementGreen parserRuleWildcardElement)
	    {
	        if (this.parserRuleWildcardElement != parserRuleWildcardElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement(parserRuleWildcardElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleElementGreen Update(ParserRuleBlockElementGreen parserRuleBlockElement)
	    {
	        if (this.parserRuleBlockElement != parserRuleBlockElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement(parserRuleBlockElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleFixedElementGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleFixedElementGreen __Missing = new ParserRuleFixedElementGreen();
	    private GreenNode annotation;
	    private StringLiteralGreen stringLiteral;
	
	    public ParserRuleFixedElementGreen(CompilerSyntaxKind kind, GreenNode annotation, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public ParserRuleFixedElementGreen(CompilerSyntaxKind kind, GreenNode annotation, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
		private ParserRuleFixedElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleFixedElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleFixedElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleFixedElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleFixedElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleFixedElementGreen(this.Kind, this.annotation, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleFixedElementGreen(this.Kind, this.annotation, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleFixedElementGreen(this.Kind, this.annotation, this.stringLiteral, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleFixedElementGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, StringLiteralGreen stringLiteral)
	    {
	        if (this.Annotation != annotation ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleFixedElement(annotation, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleFixedElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleWildcardElementGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleWildcardElementGreen __Missing = new ParserRuleWildcardElementGreen();
	    private GreenNode annotation;
	    private InternalSyntaxToken tDot;
	
	    public ParserRuleWildcardElementGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken tDot)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
	    }
	
	    public ParserRuleWildcardElementGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken tDot, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
	    }
	
		private ParserRuleWildcardElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleWildcardElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleWildcardElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.tDot;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleWildcardElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleWildcardElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleWildcardElementGreen(this.Kind, this.annotation, this.tDot, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleWildcardElementGreen(this.Kind, this.annotation, this.tDot, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleWildcardElementGreen(this.Kind, this.annotation, this.tDot, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleWildcardElementGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken tDot)
	    {
	        if (this.Annotation != annotation ||
				this.TDot != tDot)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleWildcardElement(annotation, tDot);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleWildcardElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleReferenceGreen __Missing = new ParserRuleReferenceGreen();
	    private GreenNode annotation;
	    private IdentifierGreen identifier;
	
	    public ParserRuleReferenceGreen(CompilerSyntaxKind kind, GreenNode annotation, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public ParserRuleReferenceGreen(CompilerSyntaxKind kind, GreenNode annotation, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private ParserRuleReferenceGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleReferenceSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleReferenceGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleReferenceGreen(this.Kind, this.annotation, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleReferenceGreen(this.Kind, this.annotation, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleReferenceGreen(this.Kind, this.annotation, this.identifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleReferenceGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, IdentifierGreen identifier)
	    {
	        if (this.Annotation != annotation ||
				this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleReference(annotation, identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleBlockElementGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleBlockElementGreen __Missing = new ParserRuleBlockElementGreen();
	    private GreenNode annotation;
	    private InternalSyntaxToken tOpenParen;
	    private GreenNode parserRuleNamedElement;
	    private InternalSyntaxToken tCloseParen;
	
	    public ParserRuleBlockElementGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken tOpenParen, GreenNode parserRuleNamedElement, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (parserRuleNamedElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleNamedElement);
				this.parserRuleNamedElement = parserRuleNamedElement;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ParserRuleBlockElementGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken tOpenParen, GreenNode parserRuleNamedElement, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (parserRuleNamedElement != null)
			{
				this.AdjustFlagsAndWidth(parserRuleNamedElement);
				this.parserRuleNamedElement = parserRuleNamedElement;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ParserRuleBlockElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleBlockElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen> ParserRuleNamedElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen>(this.parserRuleNamedElement); } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleBlockElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.tOpenParen;
	            case 2: return this.parserRuleNamedElement;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleBlockElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleBlockElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleBlockElementGreen(this.Kind, this.annotation, this.tOpenParen, this.parserRuleNamedElement, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleBlockElementGreen(this.Kind, this.annotation, this.tOpenParen, this.parserRuleNamedElement, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleBlockElementGreen(this.Kind, this.annotation, this.tOpenParen, this.parserRuleNamedElement, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleBlockElementGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen> parserRuleNamedElement, InternalSyntaxToken tCloseParen)
	    {
	        if (this.Annotation != annotation ||
				this.TOpenParen != tOpenParen ||
				this.ParserRuleNamedElement != parserRuleNamedElement ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleBlockElement(annotation, tOpenParen, parserRuleNamedElement, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleBlockElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleDeclarationGreen __Missing = new LexerRuleDeclarationGreen();
	    private GreenNode annotation;
	    private InternalSyntaxToken modifier;
	    private LexerRuleNameGreen lexerRuleName;
	    private InternalSyntaxToken kReturns;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tColon;
	    private GreenNode lexerRuleAlternative;
	    private InternalSyntaxToken tSemicolon;
	
	    public LexerRuleDeclarationGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken modifier, LexerRuleNameGreen lexerRuleName, InternalSyntaxToken kReturns, QualifierGreen qualifier, InternalSyntaxToken tColon, GreenNode lexerRuleAlternative, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (modifier != null)
			{
				this.AdjustFlagsAndWidth(modifier);
				this.modifier = modifier;
			}
			if (lexerRuleName != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleName);
				this.lexerRuleName = lexerRuleName;
			}
			if (kReturns != null)
			{
				this.AdjustFlagsAndWidth(kReturns);
				this.kReturns = kReturns;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (lexerRuleAlternative != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleAlternative);
				this.lexerRuleAlternative = lexerRuleAlternative;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public LexerRuleDeclarationGreen(CompilerSyntaxKind kind, GreenNode annotation, InternalSyntaxToken modifier, LexerRuleNameGreen lexerRuleName, InternalSyntaxToken kReturns, QualifierGreen qualifier, InternalSyntaxToken tColon, GreenNode lexerRuleAlternative, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (modifier != null)
			{
				this.AdjustFlagsAndWidth(modifier);
				this.modifier = modifier;
			}
			if (lexerRuleName != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleName);
				this.lexerRuleName = lexerRuleName;
			}
			if (kReturns != null)
			{
				this.AdjustFlagsAndWidth(kReturns);
				this.kReturns = kReturns;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (lexerRuleAlternative != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleAlternative);
				this.lexerRuleAlternative = lexerRuleAlternative;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private LexerRuleDeclarationGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	    public InternalSyntaxToken Modifier { get { return this.modifier; } }
	    public LexerRuleNameGreen LexerRuleName { get { return this.lexerRuleName; } }
	    public InternalSyntaxToken KReturns { get { return this.kReturns; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen> LexerRuleAlternative { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen>(this.lexerRuleAlternative); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleDeclarationSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.modifier;
	            case 2: return this.lexerRuleName;
	            case 3: return this.kReturns;
	            case 4: return this.qualifier;
	            case 5: return this.tColon;
	            case 6: return this.lexerRuleAlternative;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleDeclarationGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleDeclarationGreen(this.Kind, this.annotation, this.modifier, this.lexerRuleName, this.kReturns, this.qualifier, this.tColon, this.lexerRuleAlternative, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleDeclarationGreen(this.Kind, this.annotation, this.modifier, this.lexerRuleName, this.kReturns, this.qualifier, this.tColon, this.lexerRuleAlternative, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleDeclarationGreen(this.Kind, this.annotation, this.modifier, this.lexerRuleName, this.kReturns, this.qualifier, this.tColon, this.lexerRuleAlternative, this.tSemicolon, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken modifier, LexerRuleNameGreen lexerRuleName, InternalSyntaxToken kReturns, QualifierGreen qualifier, InternalSyntaxToken tColon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen> lexerRuleAlternative, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Annotation != annotation ||
				this.Modifier != modifier ||
				this.LexerRuleName != lexerRuleName ||
				this.KReturns != kReturns ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.LexerRuleAlternative != lexerRuleAlternative ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleDeclaration(annotation, modifier, lexerRuleName, kReturns, qualifier, tColon, lexerRuleAlternative, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleAlternativeGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleAlternativeGreen __Missing = new LexerRuleAlternativeGreen();
	    private GreenNode lexerRuleAlternativeElement;
	
	    public LexerRuleAlternativeGreen(CompilerSyntaxKind kind, GreenNode lexerRuleAlternativeElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lexerRuleAlternativeElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleAlternativeElement);
				this.lexerRuleAlternativeElement = lexerRuleAlternativeElement;
			}
	    }
	
	    public LexerRuleAlternativeGreen(CompilerSyntaxKind kind, GreenNode lexerRuleAlternativeElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lexerRuleAlternativeElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleAlternativeElement);
				this.lexerRuleAlternativeElement = lexerRuleAlternativeElement;
			}
	    }
	
		private LexerRuleAlternativeGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleAlternative, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LexerRuleAlternativeElementGreen> LexerRuleAlternativeElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LexerRuleAlternativeElementGreen>(this.lexerRuleAlternativeElement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleAlternativeSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lexerRuleAlternativeElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleAlternativeGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleAlternativeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleAlternativeGreen(this.Kind, this.lexerRuleAlternativeElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleAlternativeGreen(this.Kind, this.lexerRuleAlternativeElement, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleAlternativeGreen(this.Kind, this.lexerRuleAlternativeElement, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleAlternativeGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LexerRuleAlternativeElementGreen> lexerRuleAlternativeElement)
	    {
	        if (this.LexerRuleAlternativeElement != lexerRuleAlternativeElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternative(lexerRuleAlternativeElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleAlternativeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleAlternativeElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleAlternativeElementGreen __Missing = new LexerRuleAlternativeElementGreen();
	    private InternalSyntaxToken tNegate;
	    private LexerRuleElementGreen lexerRuleElement;
	    private MultiplicityGreen multiplicity;
	
	    public LexerRuleAlternativeElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tNegate, LexerRuleElementGreen lexerRuleElement, MultiplicityGreen multiplicity)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tNegate != null)
			{
				this.AdjustFlagsAndWidth(tNegate);
				this.tNegate = tNegate;
			}
			if (lexerRuleElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleElement);
				this.lexerRuleElement = lexerRuleElement;
			}
			if (multiplicity != null)
			{
				this.AdjustFlagsAndWidth(multiplicity);
				this.multiplicity = multiplicity;
			}
	    }
	
	    public LexerRuleAlternativeElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tNegate, LexerRuleElementGreen lexerRuleElement, MultiplicityGreen multiplicity, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tNegate != null)
			{
				this.AdjustFlagsAndWidth(tNegate);
				this.tNegate = tNegate;
			}
			if (lexerRuleElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleElement);
				this.lexerRuleElement = lexerRuleElement;
			}
			if (multiplicity != null)
			{
				this.AdjustFlagsAndWidth(multiplicity);
				this.multiplicity = multiplicity;
			}
	    }
	
		private LexerRuleAlternativeElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleAlternativeElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TNegate { get { return this.tNegate; } }
	    public LexerRuleElementGreen LexerRuleElement { get { return this.lexerRuleElement; } }
	    public MultiplicityGreen Multiplicity { get { return this.multiplicity; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleAlternativeElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tNegate;
	            case 1: return this.lexerRuleElement;
	            case 2: return this.multiplicity;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleAlternativeElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleAlternativeElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleAlternativeElementGreen(this.Kind, this.tNegate, this.lexerRuleElement, this.multiplicity, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleAlternativeElementGreen(this.Kind, this.tNegate, this.lexerRuleElement, this.multiplicity, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleAlternativeElementGreen(this.Kind, this.tNegate, this.lexerRuleElement, this.multiplicity, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleAlternativeElementGreen Update(InternalSyntaxToken tNegate, LexerRuleElementGreen lexerRuleElement, MultiplicityGreen multiplicity)
	    {
	        if (this.TNegate != tNegate ||
				this.LexerRuleElement != lexerRuleElement ||
				this.Multiplicity != multiplicity)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternativeElement(tNegate, lexerRuleElement, multiplicity);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleAlternativeElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleElementGreen __Missing = new LexerRuleElementGreen();
	    private LexerRuleReferenceElementGreen lexerRuleReferenceElement;
	    private LexerRuleFixedStringElementGreen lexerRuleFixedStringElement;
	    private LexerRuleFixedCharElementGreen lexerRuleFixedCharElement;
	    private LexerRuleWildcardElementGreen lexerRuleWildcardElement;
	    private LexerRuleBlockElementGreen lexerRuleBlockElement;
	    private LexerRuleRangeElementGreen lexerRuleRangeElement;
	
	    public LexerRuleElementGreen(CompilerSyntaxKind kind, LexerRuleReferenceElementGreen lexerRuleReferenceElement, LexerRuleFixedStringElementGreen lexerRuleFixedStringElement, LexerRuleFixedCharElementGreen lexerRuleFixedCharElement, LexerRuleWildcardElementGreen lexerRuleWildcardElement, LexerRuleBlockElementGreen lexerRuleBlockElement, LexerRuleRangeElementGreen lexerRuleRangeElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (lexerRuleReferenceElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleReferenceElement);
				this.lexerRuleReferenceElement = lexerRuleReferenceElement;
			}
			if (lexerRuleFixedStringElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleFixedStringElement);
				this.lexerRuleFixedStringElement = lexerRuleFixedStringElement;
			}
			if (lexerRuleFixedCharElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleFixedCharElement);
				this.lexerRuleFixedCharElement = lexerRuleFixedCharElement;
			}
			if (lexerRuleWildcardElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleWildcardElement);
				this.lexerRuleWildcardElement = lexerRuleWildcardElement;
			}
			if (lexerRuleBlockElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleBlockElement);
				this.lexerRuleBlockElement = lexerRuleBlockElement;
			}
			if (lexerRuleRangeElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleRangeElement);
				this.lexerRuleRangeElement = lexerRuleRangeElement;
			}
	    }
	
	    public LexerRuleElementGreen(CompilerSyntaxKind kind, LexerRuleReferenceElementGreen lexerRuleReferenceElement, LexerRuleFixedStringElementGreen lexerRuleFixedStringElement, LexerRuleFixedCharElementGreen lexerRuleFixedCharElement, LexerRuleWildcardElementGreen lexerRuleWildcardElement, LexerRuleBlockElementGreen lexerRuleBlockElement, LexerRuleRangeElementGreen lexerRuleRangeElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (lexerRuleReferenceElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleReferenceElement);
				this.lexerRuleReferenceElement = lexerRuleReferenceElement;
			}
			if (lexerRuleFixedStringElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleFixedStringElement);
				this.lexerRuleFixedStringElement = lexerRuleFixedStringElement;
			}
			if (lexerRuleFixedCharElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleFixedCharElement);
				this.lexerRuleFixedCharElement = lexerRuleFixedCharElement;
			}
			if (lexerRuleWildcardElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleWildcardElement);
				this.lexerRuleWildcardElement = lexerRuleWildcardElement;
			}
			if (lexerRuleBlockElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleBlockElement);
				this.lexerRuleBlockElement = lexerRuleBlockElement;
			}
			if (lexerRuleRangeElement != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleRangeElement);
				this.lexerRuleRangeElement = lexerRuleRangeElement;
			}
	    }
	
		private LexerRuleElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LexerRuleReferenceElementGreen LexerRuleReferenceElement { get { return this.lexerRuleReferenceElement; } }
	    public LexerRuleFixedStringElementGreen LexerRuleFixedStringElement { get { return this.lexerRuleFixedStringElement; } }
	    public LexerRuleFixedCharElementGreen LexerRuleFixedCharElement { get { return this.lexerRuleFixedCharElement; } }
	    public LexerRuleWildcardElementGreen LexerRuleWildcardElement { get { return this.lexerRuleWildcardElement; } }
	    public LexerRuleBlockElementGreen LexerRuleBlockElement { get { return this.lexerRuleBlockElement; } }
	    public LexerRuleRangeElementGreen LexerRuleRangeElement { get { return this.lexerRuleRangeElement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lexerRuleReferenceElement;
	            case 1: return this.lexerRuleFixedStringElement;
	            case 2: return this.lexerRuleFixedCharElement;
	            case 3: return this.lexerRuleWildcardElement;
	            case 4: return this.lexerRuleBlockElement;
	            case 5: return this.lexerRuleRangeElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleElementGreen(this.Kind, this.lexerRuleReferenceElement, this.lexerRuleFixedStringElement, this.lexerRuleFixedCharElement, this.lexerRuleWildcardElement, this.lexerRuleBlockElement, this.lexerRuleRangeElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleElementGreen(this.Kind, this.lexerRuleReferenceElement, this.lexerRuleFixedStringElement, this.lexerRuleFixedCharElement, this.lexerRuleWildcardElement, this.lexerRuleBlockElement, this.lexerRuleRangeElement, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleElementGreen(this.Kind, this.lexerRuleReferenceElement, this.lexerRuleFixedStringElement, this.lexerRuleFixedCharElement, this.lexerRuleWildcardElement, this.lexerRuleBlockElement, this.lexerRuleRangeElement, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleElementGreen Update(LexerRuleReferenceElementGreen lexerRuleReferenceElement)
	    {
	        if (this.lexerRuleReferenceElement != lexerRuleReferenceElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement(lexerRuleReferenceElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementGreen Update(LexerRuleFixedStringElementGreen lexerRuleFixedStringElement)
	    {
	        if (this.lexerRuleFixedStringElement != lexerRuleFixedStringElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement(lexerRuleFixedStringElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementGreen Update(LexerRuleFixedCharElementGreen lexerRuleFixedCharElement)
	    {
	        if (this.lexerRuleFixedCharElement != lexerRuleFixedCharElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement(lexerRuleFixedCharElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementGreen Update(LexerRuleWildcardElementGreen lexerRuleWildcardElement)
	    {
	        if (this.lexerRuleWildcardElement != lexerRuleWildcardElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement(lexerRuleWildcardElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementGreen Update(LexerRuleBlockElementGreen lexerRuleBlockElement)
	    {
	        if (this.lexerRuleBlockElement != lexerRuleBlockElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement(lexerRuleBlockElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementGreen Update(LexerRuleRangeElementGreen lexerRuleRangeElement)
	    {
	        if (this.lexerRuleRangeElement != lexerRuleRangeElement)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement(lexerRuleRangeElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleReferenceElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleReferenceElementGreen __Missing = new LexerRuleReferenceElementGreen();
	    private LexerRuleIdentifierGreen lexerRuleIdentifier;
	
	    public LexerRuleReferenceElementGreen(CompilerSyntaxKind kind, LexerRuleIdentifierGreen lexerRuleIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lexerRuleIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleIdentifier);
				this.lexerRuleIdentifier = lexerRuleIdentifier;
			}
	    }
	
	    public LexerRuleReferenceElementGreen(CompilerSyntaxKind kind, LexerRuleIdentifierGreen lexerRuleIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lexerRuleIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleIdentifier);
				this.lexerRuleIdentifier = lexerRuleIdentifier;
			}
	    }
	
		private LexerRuleReferenceElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleReferenceElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LexerRuleIdentifierGreen LexerRuleIdentifier { get { return this.lexerRuleIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleReferenceElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lexerRuleIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleReferenceElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleReferenceElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleReferenceElementGreen(this.Kind, this.lexerRuleIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleReferenceElementGreen(this.Kind, this.lexerRuleIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleReferenceElementGreen(this.Kind, this.lexerRuleIdentifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleReferenceElementGreen Update(LexerRuleIdentifierGreen lexerRuleIdentifier)
	    {
	        if (this.LexerRuleIdentifier != lexerRuleIdentifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleReferenceElement(lexerRuleIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleReferenceElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleWildcardElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleWildcardElementGreen __Missing = new LexerRuleWildcardElementGreen();
	    private InternalSyntaxToken tDot;
	
	    public LexerRuleWildcardElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tDot)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
	    }
	
	    public LexerRuleWildcardElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tDot, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tDot != null)
			{
				this.AdjustFlagsAndWidth(tDot);
				this.tDot = tDot;
			}
	    }
	
		private LexerRuleWildcardElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleWildcardElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TDot { get { return this.tDot; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleWildcardElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tDot;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleWildcardElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleWildcardElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleWildcardElementGreen(this.Kind, this.tDot, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleWildcardElementGreen(this.Kind, this.tDot, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleWildcardElementGreen(this.Kind, this.tDot, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleWildcardElementGreen Update(InternalSyntaxToken tDot)
	    {
	        if (this.TDot != tDot)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleWildcardElement(tDot);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleWildcardElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleFixedStringElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleFixedStringElementGreen __Missing = new LexerRuleFixedStringElementGreen();
	    private InternalSyntaxToken lString;
	
	    public LexerRuleFixedStringElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken lString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lString != null)
			{
				this.AdjustFlagsAndWidth(lString);
				this.lString = lString;
			}
	    }
	
	    public LexerRuleFixedStringElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken lString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lString != null)
			{
				this.AdjustFlagsAndWidth(lString);
				this.lString = lString;
			}
	    }
	
		private LexerRuleFixedStringElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleFixedStringElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LString { get { return this.lString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleFixedStringElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleFixedStringElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleFixedStringElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleFixedStringElementGreen(this.Kind, this.lString, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleFixedStringElementGreen(this.Kind, this.lString, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleFixedStringElementGreen(this.Kind, this.lString, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleFixedStringElementGreen Update(InternalSyntaxToken lString)
	    {
	        if (this.LString != lString)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleFixedStringElement(lString);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleFixedStringElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleFixedCharElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleFixedCharElementGreen __Missing = new LexerRuleFixedCharElementGreen();
	    private InternalSyntaxToken lCharacter;
	
	    public LexerRuleFixedCharElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken lCharacter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lCharacter != null)
			{
				this.AdjustFlagsAndWidth(lCharacter);
				this.lCharacter = lCharacter;
			}
	    }
	
	    public LexerRuleFixedCharElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken lCharacter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lCharacter != null)
			{
				this.AdjustFlagsAndWidth(lCharacter);
				this.lCharacter = lCharacter;
			}
	    }
	
		private LexerRuleFixedCharElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleFixedCharElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LCharacter { get { return this.lCharacter; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleFixedCharElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lCharacter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleFixedCharElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleFixedCharElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleFixedCharElementGreen(this.Kind, this.lCharacter, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleFixedCharElementGreen(this.Kind, this.lCharacter, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleFixedCharElementGreen(this.Kind, this.lCharacter, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleFixedCharElementGreen Update(InternalSyntaxToken lCharacter)
	    {
	        if (this.LCharacter != lCharacter)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleFixedCharElement(lCharacter);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleFixedCharElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleBlockElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleBlockElementGreen __Missing = new LexerRuleBlockElementGreen();
	    private InternalSyntaxToken tOpenParen;
	    private GreenNode lexerRuleAlternative;
	    private InternalSyntaxToken tCloseParen;
	
	    public LexerRuleBlockElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tOpenParen, GreenNode lexerRuleAlternative, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (lexerRuleAlternative != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleAlternative);
				this.lexerRuleAlternative = lexerRuleAlternative;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public LexerRuleBlockElementGreen(CompilerSyntaxKind kind, InternalSyntaxToken tOpenParen, GreenNode lexerRuleAlternative, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (lexerRuleAlternative != null)
			{
				this.AdjustFlagsAndWidth(lexerRuleAlternative);
				this.lexerRuleAlternative = lexerRuleAlternative;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private LexerRuleBlockElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleBlockElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen> LexerRuleAlternative { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen>(this.lexerRuleAlternative); } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleBlockElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.lexerRuleAlternative;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleBlockElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleBlockElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleBlockElementGreen(this.Kind, this.tOpenParen, this.lexerRuleAlternative, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleBlockElementGreen(this.Kind, this.tOpenParen, this.lexerRuleAlternative, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleBlockElementGreen(this.Kind, this.tOpenParen, this.lexerRuleAlternative, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleBlockElementGreen Update(InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen> lexerRuleAlternative, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.LexerRuleAlternative != lexerRuleAlternative ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleBlockElement(tOpenParen, lexerRuleAlternative, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleBlockElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleRangeElementGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleRangeElementGreen __Missing = new LexerRuleRangeElementGreen();
	    private LexerRuleFixedCharElementGreen start;
	    private InternalSyntaxToken tDotDot;
	    private LexerRuleFixedCharElementGreen end;
	
	    public LexerRuleRangeElementGreen(CompilerSyntaxKind kind, LexerRuleFixedCharElementGreen start, InternalSyntaxToken tDotDot, LexerRuleFixedCharElementGreen end)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (start != null)
			{
				this.AdjustFlagsAndWidth(start);
				this.start = start;
			}
			if (tDotDot != null)
			{
				this.AdjustFlagsAndWidth(tDotDot);
				this.tDotDot = tDotDot;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
	    public LexerRuleRangeElementGreen(CompilerSyntaxKind kind, LexerRuleFixedCharElementGreen start, InternalSyntaxToken tDotDot, LexerRuleFixedCharElementGreen end, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (start != null)
			{
				this.AdjustFlagsAndWidth(start);
				this.start = start;
			}
			if (tDotDot != null)
			{
				this.AdjustFlagsAndWidth(tDotDot);
				this.tDotDot = tDotDot;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
		private LexerRuleRangeElementGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleRangeElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LexerRuleFixedCharElementGreen Start { get { return this.start; } }
	    public InternalSyntaxToken TDotDot { get { return this.tDotDot; } }
	    public LexerRuleFixedCharElementGreen End { get { return this.end; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleRangeElementSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.start;
	            case 1: return this.tDotDot;
	            case 2: return this.end;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleRangeElementGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleRangeElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleRangeElementGreen(this.Kind, this.start, this.tDotDot, this.end, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleRangeElementGreen(this.Kind, this.start, this.tDotDot, this.end, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleRangeElementGreen(this.Kind, this.start, this.tDotDot, this.end, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleRangeElementGreen Update(LexerRuleFixedCharElementGreen start, InternalSyntaxToken tDotDot, LexerRuleFixedCharElementGreen end)
	    {
	        if (this.Start != start ||
				this.TDotDot != tDotDot ||
				this.End != end)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleRangeElement(start, tDotDot, end);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleRangeElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameGreen : GreenSyntaxNode
	{
	    internal static readonly NameGreen __Missing = new NameGreen();
	    private IdentifierGreen identifier;
	
	    public NameGreen(CompilerSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(CompilerSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.NameSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NameGreen(this.Kind, this.identifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NameGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	    public QualifiedNameGreen(CompilerSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(CompilerSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.QualifiedNameSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new QualifiedNameGreen(this.Kind, this.qualifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public QualifiedNameGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	    public QualifierGreen(CompilerSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(CompilerSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.QualifierSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new QualifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public QualifierGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	    public IdentifierGreen(CompilerSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierGreen(CompilerSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.IdentifierSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new IdentifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public IdentifierGreen Update(InternalSyntaxToken identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Identifier(identifier);
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
	
	internal class LexerRuleIdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleIdentifierGreen __Missing = new LexerRuleIdentifierGreen();
	    private InternalSyntaxToken lexerIdentifier;
	
	    public LexerRuleIdentifierGreen(CompilerSyntaxKind kind, InternalSyntaxToken lexerIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lexerIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lexerIdentifier);
				this.lexerIdentifier = lexerIdentifier;
			}
	    }
	
	    public LexerRuleIdentifierGreen(CompilerSyntaxKind kind, InternalSyntaxToken lexerIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lexerIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lexerIdentifier);
				this.lexerIdentifier = lexerIdentifier;
			}
	    }
	
		private LexerRuleIdentifierGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleIdentifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LexerIdentifier { get { return this.lexerIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleIdentifierSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lexerIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleIdentifierGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleIdentifierGreen(this.Kind, this.lexerIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleIdentifierGreen(this.Kind, this.lexerIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleIdentifierGreen(this.Kind, this.lexerIdentifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleIdentifierGreen Update(InternalSyntaxToken lexerIdentifier)
	    {
	        if (this.LexerIdentifier != lexerIdentifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleIdentifier(lexerIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleIdentifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleIdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleIdentifierGreen __Missing = new ParserRuleIdentifierGreen();
	    private InternalSyntaxToken parserIdentifier;
	
	    public ParserRuleIdentifierGreen(CompilerSyntaxKind kind, InternalSyntaxToken parserIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parserIdentifier != null)
			{
				this.AdjustFlagsAndWidth(parserIdentifier);
				this.parserIdentifier = parserIdentifier;
			}
	    }
	
	    public ParserRuleIdentifierGreen(CompilerSyntaxKind kind, InternalSyntaxToken parserIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (parserIdentifier != null)
			{
				this.AdjustFlagsAndWidth(parserIdentifier);
				this.parserIdentifier = parserIdentifier;
			}
	    }
	
		private ParserRuleIdentifierGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleIdentifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ParserIdentifier { get { return this.parserIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleIdentifierSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parserIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleIdentifierGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleIdentifierGreen(this.Kind, this.parserIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleIdentifierGreen(this.Kind, this.parserIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleIdentifierGreen(this.Kind, this.parserIdentifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleIdentifierGreen Update(InternalSyntaxToken parserIdentifier)
	    {
	        if (this.ParserIdentifier != parserIdentifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleIdentifier(parserIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleIdentifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LexerRuleNameGreen : GreenSyntaxNode
	{
	    internal static readonly LexerRuleNameGreen __Missing = new LexerRuleNameGreen();
	    private InternalSyntaxToken lexerIdentifier;
	
	    public LexerRuleNameGreen(CompilerSyntaxKind kind, InternalSyntaxToken lexerIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lexerIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lexerIdentifier);
				this.lexerIdentifier = lexerIdentifier;
			}
	    }
	
	    public LexerRuleNameGreen(CompilerSyntaxKind kind, InternalSyntaxToken lexerIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lexerIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lexerIdentifier);
				this.lexerIdentifier = lexerIdentifier;
			}
	    }
	
		private LexerRuleNameGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LexerIdentifier { get { return this.lexerIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.LexerRuleNameSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lexerIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLexerRuleNameGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLexerRuleNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LexerRuleNameGreen(this.Kind, this.lexerIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LexerRuleNameGreen(this.Kind, this.lexerIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LexerRuleNameGreen(this.Kind, this.lexerIdentifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LexerRuleNameGreen Update(InternalSyntaxToken lexerIdentifier)
	    {
	        if (this.LexerIdentifier != lexerIdentifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleName(lexerIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParserRuleNameGreen : GreenSyntaxNode
	{
	    internal static readonly ParserRuleNameGreen __Missing = new ParserRuleNameGreen();
	    private InternalSyntaxToken parserIdentifier;
	
	    public ParserRuleNameGreen(CompilerSyntaxKind kind, InternalSyntaxToken parserIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parserIdentifier != null)
			{
				this.AdjustFlagsAndWidth(parserIdentifier);
				this.parserIdentifier = parserIdentifier;
			}
	    }
	
	    public ParserRuleNameGreen(CompilerSyntaxKind kind, InternalSyntaxToken parserIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (parserIdentifier != null)
			{
				this.AdjustFlagsAndWidth(parserIdentifier);
				this.parserIdentifier = parserIdentifier;
			}
	    }
	
		private ParserRuleNameGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ParserIdentifier { get { return this.parserIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ParserRuleNameSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parserIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitParserRuleNameGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitParserRuleNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParserRuleNameGreen(this.Kind, this.parserIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParserRuleNameGreen(this.Kind, this.parserIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParserRuleNameGreen(this.Kind, this.parserIdentifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParserRuleNameGreen Update(InternalSyntaxToken parserIdentifier)
	    {
	        if (this.ParserIdentifier != parserIdentifier)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleName(parserIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementNameGreen : GreenSyntaxNode
	{
	    internal static readonly ElementNameGreen __Missing = new ElementNameGreen();
	    private InternalSyntaxToken elementName;
	
	    public ElementNameGreen(CompilerSyntaxKind kind, InternalSyntaxToken elementName)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (elementName != null)
			{
				this.AdjustFlagsAndWidth(elementName);
				this.elementName = elementName;
			}
	    }
	
	    public ElementNameGreen(CompilerSyntaxKind kind, InternalSyntaxToken elementName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (elementName != null)
			{
				this.AdjustFlagsAndWidth(elementName);
				this.elementName = elementName;
			}
	    }
	
		private ElementNameGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ElementName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ElementName { get { return this.elementName; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ElementNameSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.elementName;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitElementNameGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitElementNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementNameGreen(this.Kind, this.elementName, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementNameGreen(this.Kind, this.elementName, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ElementNameGreen(this.Kind, this.elementName, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ElementNameGreen Update(InternalSyntaxToken elementName)
	    {
	        if (this.ElementName != elementName)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ElementName(elementName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementNameGreen)newNode;
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
	
	    public LiteralGreen(CompilerSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
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
	
	    public LiteralGreen(CompilerSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.Literal, null, null)
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
	        return new global::MetaDslx.Languages.Compiler.Syntax.LiteralSyntax(this, (CompilerSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LiteralGreen Update(NullLiteralGreen nullLiteral)
	    {
	        if (this.nullLiteral != nullLiteral)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	    public NullLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.NullLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullLiteralGreen(this.Kind, this.kNull, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullLiteralGreen(this.Kind, this.kNull, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NullLiteralGreen(this.Kind, this.kNull, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NullLiteralGreen Update(InternalSyntaxToken kNull)
	    {
	        if (this.KNull != kNull)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	    public BooleanLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.BooleanLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public BooleanLiteralGreen Update(InternalSyntaxToken booleanLiteral)
	    {
	        if (this.BooleanLiteral != booleanLiteral)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	    public IntegerLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.IntegerLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IntegerLiteralGreen(this.Kind, this.lInteger, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IntegerLiteralGreen(this.Kind, this.lInteger, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new IntegerLiteralGreen(this.Kind, this.lInteger, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public IntegerLiteralGreen Update(InternalSyntaxToken lInteger)
	    {
	        if (this.LInteger != lInteger)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	    public DecimalLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.DecimalLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DecimalLiteralGreen(this.Kind, this.lDecimal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DecimalLiteralGreen(this.Kind, this.lDecimal, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new DecimalLiteralGreen(this.Kind, this.lDecimal, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public DecimalLiteralGreen Update(InternalSyntaxToken lDecimal)
	    {
	        if (this.LDecimal != lDecimal)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	    public ScientificLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CompilerSyntaxKind)CompilerSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.ScientificLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ScientificLiteralGreen(this.Kind, this.lScientific, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ScientificLiteralGreen(this.Kind, this.lScientific, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ScientificLiteralGreen(this.Kind, this.lScientific, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ScientificLiteralGreen Update(InternalSyntaxToken lScientific)
	    {
	        if (this.LScientific != lScientific)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	    private InternalSyntaxToken lString;
	
	    public StringLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lString != null)
			{
				this.AdjustFlagsAndWidth(lString);
				this.lString = lString;
			}
	    }
	
	    public StringLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lString != null)
			{
				this.AdjustFlagsAndWidth(lString);
				this.lString = lString;
			}
	    }
	
		private StringLiteralGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LString { get { return this.lString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.StringLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringLiteralGreen(this.Kind, this.lString, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringLiteralGreen(this.Kind, this.lString, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new StringLiteralGreen(this.Kind, this.lString, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public StringLiteralGreen Update(InternalSyntaxToken lString)
	    {
	        if (this.LString != lString)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.StringLiteral(lString);
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
	
	internal class CharLiteralGreen : GreenSyntaxNode
	{
	    internal static readonly CharLiteralGreen __Missing = new CharLiteralGreen();
	    private InternalSyntaxToken lCharacter;
	
	    public CharLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lCharacter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lCharacter != null)
			{
				this.AdjustFlagsAndWidth(lCharacter);
				this.lCharacter = lCharacter;
			}
	    }
	
	    public CharLiteralGreen(CompilerSyntaxKind kind, InternalSyntaxToken lCharacter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lCharacter != null)
			{
				this.AdjustFlagsAndWidth(lCharacter);
				this.lCharacter = lCharacter;
			}
	    }
	
		private CharLiteralGreen()
			: base((CompilerSyntaxKind)CompilerSyntaxKind.CharLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LCharacter { get { return this.lCharacter; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Compiler.Syntax.CharLiteralSyntax(this, (CompilerSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lCharacter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CompilerSyntaxVisitor<TResult> visitor) => visitor.VisitCharLiteralGreen(this);
	
	    public override void Accept(CompilerSyntaxVisitor visitor) => visitor.VisitCharLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CharLiteralGreen(this.Kind, this.lCharacter, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CharLiteralGreen(this.Kind, this.lCharacter, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CharLiteralGreen(this.Kind, this.lCharacter, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CharLiteralGreen Update(InternalSyntaxToken lCharacter)
	    {
	        if (this.LCharacter != lCharacter)
	        {
	            InternalSyntaxNode newNode = CompilerLanguage.Instance.InternalSyntaxFactory.CharLiteral(lCharacter);
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

	internal class CompilerSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationGreen(AnnotationGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitGrammarDeclarationGreen(GrammarDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitUsingDeclarationGreen(UsingDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitRuleDeclarationsGreen(RuleDeclarationsGreen node) => this.DefaultVisit(node);
		public virtual void VisitRuleDeclarationGreen(RuleDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleDeclarationGreen(ParserRuleDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleAltGreen(ParserRuleAltGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleAltRefGreen(ParserRuleAltRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleSimpleGreen(ParserRuleSimpleGreen node) => this.DefaultVisit(node);
		public virtual void VisitEofElementGreen(EofElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleNamedElementGreen(ParserRuleNamedElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssignGreen(AssignGreen node) => this.DefaultVisit(node);
		public virtual void VisitMultiplicityGreen(MultiplicityGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserNegatedElementGreen(ParserNegatedElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleElementGreen(ParserRuleElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleFixedElementGreen(ParserRuleFixedElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleWildcardElementGreen(ParserRuleWildcardElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleReferenceGreen(ParserRuleReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleBlockElementGreen(ParserRuleBlockElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleDeclarationGreen(LexerRuleDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleAlternativeGreen(LexerRuleAlternativeGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleAlternativeElementGreen(LexerRuleAlternativeElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleElementGreen(LexerRuleElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleReferenceElementGreen(LexerRuleReferenceElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleWildcardElementGreen(LexerRuleWildcardElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleFixedStringElementGreen(LexerRuleFixedStringElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleFixedCharElementGreen(LexerRuleFixedCharElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleBlockElementGreen(LexerRuleBlockElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleRangeElementGreen(LexerRuleRangeElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleIdentifierGreen(LexerRuleIdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleIdentifierGreen(ParserRuleIdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitLexerRuleNameGreen(LexerRuleNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitParserRuleNameGreen(ParserRuleNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitElementNameGreen(ElementNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitCharLiteralGreen(CharLiteralGreen node) => this.DefaultVisit(node);
	}
	
	internal class CompilerSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationGreen(AnnotationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGrammarDeclarationGreen(GrammarDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUsingDeclarationGreen(UsingDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRuleDeclarationsGreen(RuleDeclarationsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRuleDeclarationGreen(RuleDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleDeclarationGreen(ParserRuleDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleAltGreen(ParserRuleAltGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleAltRefGreen(ParserRuleAltRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleSimpleGreen(ParserRuleSimpleGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEofElementGreen(EofElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleNamedElementGreen(ParserRuleNamedElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssignGreen(AssignGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMultiplicityGreen(MultiplicityGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserNegatedElementGreen(ParserNegatedElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleElementGreen(ParserRuleElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleFixedElementGreen(ParserRuleFixedElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleWildcardElementGreen(ParserRuleWildcardElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleReferenceGreen(ParserRuleReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleBlockElementGreen(ParserRuleBlockElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleDeclarationGreen(LexerRuleDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleAlternativeGreen(LexerRuleAlternativeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleAlternativeElementGreen(LexerRuleAlternativeElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleElementGreen(LexerRuleElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleReferenceElementGreen(LexerRuleReferenceElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleWildcardElementGreen(LexerRuleWildcardElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleFixedStringElementGreen(LexerRuleFixedStringElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleFixedCharElementGreen(LexerRuleFixedCharElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleBlockElementGreen(LexerRuleBlockElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleRangeElementGreen(LexerRuleRangeElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleIdentifierGreen(LexerRuleIdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleIdentifierGreen(ParserRuleIdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLexerRuleNameGreen(LexerRuleNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParserRuleNameGreen(ParserRuleNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElementNameGreen(ElementNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCharLiteralGreen(CharLiteralGreen node) => this.DefaultVisit(node);
	}
	internal class CompilerInternalSyntaxFactory : InternalSyntaxFactory, global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.IAntlr4SyntaxFactory
	{
		public CompilerInternalSyntaxFactory(CompilerSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.Antlr4Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new CompilerLexer(input);
	    }
	
	    public global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.Antlr4Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new CompilerParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions? options)
		{
			return new CompilerSyntaxLexer(text, (CompilerParseOptions)(options ?? CompilerParseOptions.Default));
		}
	
		public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions? options, LanguageSyntaxNode? oldTree, ParseData? oldParseData, IEnumerable<TextChangeRange>? changes, CancellationToken cancellationToken = default)
		{
			return new CompilerSyntaxParser(text, (CompilerParseOptions)(options ?? CompilerParseOptions.Default), (CompilerSyntaxNode?)oldTree, oldParseData, changes, cancellationToken);
		}
	
		private CompilerSyntaxKind ToCompilerSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<CompilerSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToCompilerSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToCompilerSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToCompilerSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
		{
			return new GreenSkippedTokensTriviaSyntax(ToCompilerSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToCompilerSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToCompilerSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			CompilerSyntaxKind typedKind = ToCompilerSyntaxKind(kind);
	        Debug.Assert(CompilerLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = CompilerLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			CompilerSyntaxKind typedKind = ToCompilerSyntaxKind(kind);
	        Debug.Assert(CompilerLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = CompilerLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			CompilerSyntaxKind typedKind = ToCompilerSyntaxKind(kind);
	        Debug.Assert(CompilerLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = CompilerLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToCompilerSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToCompilerSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToCompilerSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken LexerIdentifier(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LexerIdentifier, text, null);
	    }
	
	    internal InternalSyntaxToken LexerIdentifier(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LexerIdentifier, text, value, null);
	    }
	
	    internal InternalSyntaxToken ParserIdentifier(string text)
	    {
	        return Token(null, CompilerSyntaxKind.ParserIdentifier, text, null);
	    }
	
	    internal InternalSyntaxToken ParserIdentifier(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.ParserIdentifier, text, value, null);
	    }
	
	    internal InternalSyntaxToken IgnoredIdentifier(string text)
	    {
	        return Token(null, CompilerSyntaxKind.IgnoredIdentifier, text, null);
	    }
	
	    internal InternalSyntaxToken IgnoredIdentifier(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.IgnoredIdentifier, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LString(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LString, text, null);
	    }
	
	    internal InternalSyntaxToken LString(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCharacter(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LCharacter, text, null);
	    }
	
	    internal InternalSyntaxToken LCharacter(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LCharacter, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LMultilineComment(string text)
	    {
	        return Token(null, CompilerSyntaxKind.LMultilineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LMultilineComment(string text, object value)
	    {
	        return Token(null, CompilerSyntaxKind.LMultilineComment, text, value, null);
	    }
	
		public MainGreen Main(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != CompilerSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Main, namespaceDeclaration, eOF, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(CompilerSyntaxKind.Main, namespaceDeclaration, eOF);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationGreen Annotation(InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != CompilerSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != CompilerSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Annotation, tOpenBracket, name, tCloseBracket, out hash);
			if (cached != null) return (AnnotationGreen)cached;
			var result = new AnnotationGreen(CompilerSyntaxKind.Annotation, tOpenBracket, name, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclarationGreen NamespaceDeclaration(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, NamespaceBodyGreen namespaceBody)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != CompilerSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
	#endif
	        return new NamespaceDeclarationGreen(CompilerSyntaxKind.NamespaceDeclaration, kNamespace, qualifiedName, tSemicolon, namespaceBody);
	    }
	
		public NamespaceBodyGreen NamespaceBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingDeclarationGreen> usingDeclaration, GrammarDeclarationGreen grammarDeclaration)
	    {
	#if DEBUG
			if (grammarDeclaration == null) throw new ArgumentNullException(nameof(grammarDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.NamespaceBody, usingDeclaration.Node, grammarDeclaration, out hash);
			if (cached != null) return (NamespaceBodyGreen)cached;
			var result = new NamespaceBodyGreen(CompilerSyntaxKind.NamespaceBody, usingDeclaration.Node, grammarDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GrammarDeclarationGreen GrammarDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken kGrammar, NameGreen name, InternalSyntaxToken tSemicolon, RuleDeclarationsGreen ruleDeclarations)
	    {
	#if DEBUG
			if (kGrammar == null) throw new ArgumentNullException(nameof(kGrammar));
			if (kGrammar.Kind != CompilerSyntaxKind.KGrammar) throw new ArgumentException(nameof(kGrammar));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (ruleDeclarations == null) throw new ArgumentNullException(nameof(ruleDeclarations));
	#endif
	        return new GrammarDeclarationGreen(CompilerSyntaxKind.GrammarDeclaration, annotation.Node, kGrammar, name, tSemicolon, ruleDeclarations);
	    }
	
		public UsingDeclarationGreen UsingDeclaration(InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
			if (kUsing.Kind != CompilerSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
			if (tAssign != null && tAssign.Kind != CompilerSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new UsingDeclarationGreen(CompilerSyntaxKind.UsingDeclaration, kUsing, name, tAssign, qualifier, tSemicolon);
	    }
	
		public RuleDeclarationsGreen RuleDeclarations(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuleDeclarationGreen> ruleDeclaration)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.RuleDeclarations, ruleDeclaration.Node, out hash);
			if (cached != null) return (RuleDeclarationsGreen)cached;
			var result = new RuleDeclarationsGreen(CompilerSyntaxKind.RuleDeclarations, ruleDeclaration.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RuleDeclarationGreen RuleDeclaration(ParserRuleDeclarationGreen parserRuleDeclaration)
	    {
	#if DEBUG
		    if (parserRuleDeclaration == null) throw new ArgumentNullException(nameof(parserRuleDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.RuleDeclaration, parserRuleDeclaration, out hash);
			if (cached != null) return (RuleDeclarationGreen)cached;
			var result = new RuleDeclarationGreen(CompilerSyntaxKind.RuleDeclaration, parserRuleDeclaration, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RuleDeclarationGreen RuleDeclaration(LexerRuleDeclarationGreen lexerRuleDeclaration)
	    {
	#if DEBUG
		    if (lexerRuleDeclaration == null) throw new ArgumentNullException(nameof(lexerRuleDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.RuleDeclaration, lexerRuleDeclaration, out hash);
			if (cached != null) return (RuleDeclarationGreen)cached;
			var result = new RuleDeclarationGreen(CompilerSyntaxKind.RuleDeclaration, null, lexerRuleDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleDeclarationGreen ParserRuleDeclaration(ParserRuleAltGreen parserRuleAlt)
	    {
	#if DEBUG
		    if (parserRuleAlt == null) throw new ArgumentNullException(nameof(parserRuleAlt));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleDeclaration, parserRuleAlt, out hash);
			if (cached != null) return (ParserRuleDeclarationGreen)cached;
			var result = new ParserRuleDeclarationGreen(CompilerSyntaxKind.ParserRuleDeclaration, parserRuleAlt, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleDeclarationGreen ParserRuleDeclaration(ParserRuleSimpleGreen parserRuleSimple)
	    {
	#if DEBUG
		    if (parserRuleSimple == null) throw new ArgumentNullException(nameof(parserRuleSimple));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleDeclaration, parserRuleSimple, out hash);
			if (cached != null) return (ParserRuleDeclarationGreen)cached;
			var result = new ParserRuleDeclarationGreen(CompilerSyntaxKind.ParserRuleDeclaration, null, parserRuleSimple);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleAltGreen ParserRuleAlt(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParserRuleAltRefGreen> parserRuleAltRef, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (parserRuleName == null) throw new ArgumentNullException(nameof(parserRuleName));
			if (kDefines != null && kDefines.Kind != CompilerSyntaxKind.KDefines) throw new ArgumentException(nameof(kDefines));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new ParserRuleAltGreen(CompilerSyntaxKind.ParserRuleAlt, annotation.Node, parserRuleName, kDefines, qualifier, tColon, parserRuleAltRef.Node, tSemicolon);
	    }
	
		public ParserRuleAltRefGreen ParserRuleAltRef(ParserRuleIdentifierGreen parserRuleIdentifier)
	    {
	#if DEBUG
			if (parserRuleIdentifier == null) throw new ArgumentNullException(nameof(parserRuleIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleAltRef, parserRuleIdentifier, out hash);
			if (cached != null) return (ParserRuleAltRefGreen)cached;
			var result = new ParserRuleAltRefGreen(CompilerSyntaxKind.ParserRuleAltRef, parserRuleIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleSimpleGreen ParserRuleSimple(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, ParserRuleNameGreen parserRuleName, InternalSyntaxToken kDefines, QualifierGreen qualifier, InternalSyntaxToken tColon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen> parserRuleNamedElement, EofElementGreen eofElement, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (parserRuleName == null) throw new ArgumentNullException(nameof(parserRuleName));
			if (kDefines != null && kDefines.Kind != CompilerSyntaxKind.KDefines) throw new ArgumentException(nameof(kDefines));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new ParserRuleSimpleGreen(CompilerSyntaxKind.ParserRuleSimple, annotation.Node, parserRuleName, kDefines, qualifier, tColon, parserRuleNamedElement.Node, eofElement, tSemicolon);
	    }
	
		public EofElementGreen EofElement(InternalSyntaxToken kEof)
	    {
	#if DEBUG
			if (kEof == null) throw new ArgumentNullException(nameof(kEof));
			if (kEof.Kind != CompilerSyntaxKind.KEof) throw new ArgumentException(nameof(kEof));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.EofElement, kEof, out hash);
			if (cached != null) return (EofElementGreen)cached;
			var result = new EofElementGreen(CompilerSyntaxKind.EofElement, kEof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleNamedElementGreen ParserRuleNamedElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, ElementNameGreen elementName, AssignGreen assign, ParserNegatedElementGreen parserNegatedElement, MultiplicityGreen multiplicity)
	    {
	#if DEBUG
			if (parserNegatedElement == null) throw new ArgumentNullException(nameof(parserNegatedElement));
	#endif
	        return new ParserRuleNamedElementGreen(CompilerSyntaxKind.ParserRuleNamedElement, annotation.Node, elementName, assign, parserNegatedElement, multiplicity);
	    }
	
		public AssignGreen Assign(InternalSyntaxToken assign)
	    {
	#if DEBUG
			if (assign == null) throw new ArgumentNullException(nameof(assign));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Assign, assign, out hash);
			if (cached != null) return (AssignGreen)cached;
			var result = new AssignGreen(CompilerSyntaxKind.Assign, assign);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MultiplicityGreen Multiplicity(InternalSyntaxToken multiplicity)
	    {
	#if DEBUG
			if (multiplicity == null) throw new ArgumentNullException(nameof(multiplicity));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Multiplicity, multiplicity, out hash);
			if (cached != null) return (MultiplicityGreen)cached;
			var result = new MultiplicityGreen(CompilerSyntaxKind.Multiplicity, multiplicity);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserNegatedElementGreen ParserNegatedElement(InternalSyntaxToken tNegate, ParserRuleElementGreen parserRuleElement)
	    {
	#if DEBUG
			if (tNegate != null && tNegate.Kind != CompilerSyntaxKind.TNegate) throw new ArgumentException(nameof(tNegate));
			if (parserRuleElement == null) throw new ArgumentNullException(nameof(parserRuleElement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserNegatedElement, tNegate, parserRuleElement, out hash);
			if (cached != null) return (ParserNegatedElementGreen)cached;
			var result = new ParserNegatedElementGreen(CompilerSyntaxKind.ParserNegatedElement, tNegate, parserRuleElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleElementGreen ParserRuleElement(ParserRuleFixedElementGreen parserRuleFixedElement)
	    {
	#if DEBUG
		    if (parserRuleFixedElement == null) throw new ArgumentNullException(nameof(parserRuleFixedElement));
	#endif
			return new ParserRuleElementGreen(CompilerSyntaxKind.ParserRuleElement, parserRuleFixedElement, null, null, null);
	    }
	
		public ParserRuleElementGreen ParserRuleElement(ParserRuleReferenceGreen parserRuleReference)
	    {
	#if DEBUG
		    if (parserRuleReference == null) throw new ArgumentNullException(nameof(parserRuleReference));
	#endif
			return new ParserRuleElementGreen(CompilerSyntaxKind.ParserRuleElement, null, parserRuleReference, null, null);
	    }
	
		public ParserRuleElementGreen ParserRuleElement(ParserRuleWildcardElementGreen parserRuleWildcardElement)
	    {
	#if DEBUG
		    if (parserRuleWildcardElement == null) throw new ArgumentNullException(nameof(parserRuleWildcardElement));
	#endif
			return new ParserRuleElementGreen(CompilerSyntaxKind.ParserRuleElement, null, null, parserRuleWildcardElement, null);
	    }
	
		public ParserRuleElementGreen ParserRuleElement(ParserRuleBlockElementGreen parserRuleBlockElement)
	    {
	#if DEBUG
		    if (parserRuleBlockElement == null) throw new ArgumentNullException(nameof(parserRuleBlockElement));
	#endif
			return new ParserRuleElementGreen(CompilerSyntaxKind.ParserRuleElement, null, null, null, parserRuleBlockElement);
	    }
	
		public ParserRuleFixedElementGreen ParserRuleFixedElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleFixedElement, annotation.Node, stringLiteral, out hash);
			if (cached != null) return (ParserRuleFixedElementGreen)cached;
			var result = new ParserRuleFixedElementGreen(CompilerSyntaxKind.ParserRuleFixedElement, annotation.Node, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleWildcardElementGreen ParserRuleWildcardElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken tDot)
	    {
	#if DEBUG
			if (tDot == null) throw new ArgumentNullException(nameof(tDot));
			if (tDot.Kind != CompilerSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleWildcardElement, annotation.Node, tDot, out hash);
			if (cached != null) return (ParserRuleWildcardElementGreen)cached;
			var result = new ParserRuleWildcardElementGreen(CompilerSyntaxKind.ParserRuleWildcardElement, annotation.Node, tDot);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleReferenceGreen ParserRuleReference(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleReference, annotation.Node, identifier, out hash);
			if (cached != null) return (ParserRuleReferenceGreen)cached;
			var result = new ParserRuleReferenceGreen(CompilerSyntaxKind.ParserRuleReference, annotation.Node, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleBlockElementGreen ParserRuleBlockElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ParserRuleNamedElementGreen> parserRuleNamedElement, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new ParserRuleBlockElementGreen(CompilerSyntaxKind.ParserRuleBlockElement, annotation.Node, tOpenParen, parserRuleNamedElement.Node, tCloseParen);
	    }
	
		public LexerRuleDeclarationGreen LexerRuleDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation, InternalSyntaxToken modifier, LexerRuleNameGreen lexerRuleName, InternalSyntaxToken kReturns, QualifierGreen qualifier, InternalSyntaxToken tColon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen> lexerRuleAlternative, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (lexerRuleName == null) throw new ArgumentNullException(nameof(lexerRuleName));
			if (kReturns != null && kReturns.Kind != CompilerSyntaxKind.KReturns) throw new ArgumentException(nameof(kReturns));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new LexerRuleDeclarationGreen(CompilerSyntaxKind.LexerRuleDeclaration, annotation.Node, modifier, lexerRuleName, kReturns, qualifier, tColon, lexerRuleAlternative.Node, tSemicolon);
	    }
	
		public LexerRuleAlternativeGreen LexerRuleAlternative(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LexerRuleAlternativeElementGreen> lexerRuleAlternativeElement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleAlternative, lexerRuleAlternativeElement.Node, out hash);
			if (cached != null) return (LexerRuleAlternativeGreen)cached;
			var result = new LexerRuleAlternativeGreen(CompilerSyntaxKind.LexerRuleAlternative, lexerRuleAlternativeElement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleAlternativeElementGreen LexerRuleAlternativeElement(InternalSyntaxToken tNegate, LexerRuleElementGreen lexerRuleElement, MultiplicityGreen multiplicity)
	    {
	#if DEBUG
			if (tNegate != null && tNegate.Kind != CompilerSyntaxKind.TNegate) throw new ArgumentException(nameof(tNegate));
			if (lexerRuleElement == null) throw new ArgumentNullException(nameof(lexerRuleElement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleAlternativeElement, tNegate, lexerRuleElement, multiplicity, out hash);
			if (cached != null) return (LexerRuleAlternativeElementGreen)cached;
			var result = new LexerRuleAlternativeElementGreen(CompilerSyntaxKind.LexerRuleAlternativeElement, tNegate, lexerRuleElement, multiplicity);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleElementGreen LexerRuleElement(LexerRuleReferenceElementGreen lexerRuleReferenceElement)
	    {
	#if DEBUG
		    if (lexerRuleReferenceElement == null) throw new ArgumentNullException(nameof(lexerRuleReferenceElement));
	#endif
			return new LexerRuleElementGreen(CompilerSyntaxKind.LexerRuleElement, lexerRuleReferenceElement, null, null, null, null, null);
	    }
	
		public LexerRuleElementGreen LexerRuleElement(LexerRuleFixedStringElementGreen lexerRuleFixedStringElement)
	    {
	#if DEBUG
		    if (lexerRuleFixedStringElement == null) throw new ArgumentNullException(nameof(lexerRuleFixedStringElement));
	#endif
			return new LexerRuleElementGreen(CompilerSyntaxKind.LexerRuleElement, null, lexerRuleFixedStringElement, null, null, null, null);
	    }
	
		public LexerRuleElementGreen LexerRuleElement(LexerRuleFixedCharElementGreen lexerRuleFixedCharElement)
	    {
	#if DEBUG
		    if (lexerRuleFixedCharElement == null) throw new ArgumentNullException(nameof(lexerRuleFixedCharElement));
	#endif
			return new LexerRuleElementGreen(CompilerSyntaxKind.LexerRuleElement, null, null, lexerRuleFixedCharElement, null, null, null);
	    }
	
		public LexerRuleElementGreen LexerRuleElement(LexerRuleWildcardElementGreen lexerRuleWildcardElement)
	    {
	#if DEBUG
		    if (lexerRuleWildcardElement == null) throw new ArgumentNullException(nameof(lexerRuleWildcardElement));
	#endif
			return new LexerRuleElementGreen(CompilerSyntaxKind.LexerRuleElement, null, null, null, lexerRuleWildcardElement, null, null);
	    }
	
		public LexerRuleElementGreen LexerRuleElement(LexerRuleBlockElementGreen lexerRuleBlockElement)
	    {
	#if DEBUG
		    if (lexerRuleBlockElement == null) throw new ArgumentNullException(nameof(lexerRuleBlockElement));
	#endif
			return new LexerRuleElementGreen(CompilerSyntaxKind.LexerRuleElement, null, null, null, null, lexerRuleBlockElement, null);
	    }
	
		public LexerRuleElementGreen LexerRuleElement(LexerRuleRangeElementGreen lexerRuleRangeElement)
	    {
	#if DEBUG
		    if (lexerRuleRangeElement == null) throw new ArgumentNullException(nameof(lexerRuleRangeElement));
	#endif
			return new LexerRuleElementGreen(CompilerSyntaxKind.LexerRuleElement, null, null, null, null, null, lexerRuleRangeElement);
	    }
	
		public LexerRuleReferenceElementGreen LexerRuleReferenceElement(LexerRuleIdentifierGreen lexerRuleIdentifier)
	    {
	#if DEBUG
			if (lexerRuleIdentifier == null) throw new ArgumentNullException(nameof(lexerRuleIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleReferenceElement, lexerRuleIdentifier, out hash);
			if (cached != null) return (LexerRuleReferenceElementGreen)cached;
			var result = new LexerRuleReferenceElementGreen(CompilerSyntaxKind.LexerRuleReferenceElement, lexerRuleIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleWildcardElementGreen LexerRuleWildcardElement(InternalSyntaxToken tDot)
	    {
	#if DEBUG
			if (tDot == null) throw new ArgumentNullException(nameof(tDot));
			if (tDot.Kind != CompilerSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleWildcardElement, tDot, out hash);
			if (cached != null) return (LexerRuleWildcardElementGreen)cached;
			var result = new LexerRuleWildcardElementGreen(CompilerSyntaxKind.LexerRuleWildcardElement, tDot);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleFixedStringElementGreen LexerRuleFixedStringElement(InternalSyntaxToken lString)
	    {
	#if DEBUG
			if (lString == null) throw new ArgumentNullException(nameof(lString));
			if (lString.Kind != CompilerSyntaxKind.LString) throw new ArgumentException(nameof(lString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleFixedStringElement, lString, out hash);
			if (cached != null) return (LexerRuleFixedStringElementGreen)cached;
			var result = new LexerRuleFixedStringElementGreen(CompilerSyntaxKind.LexerRuleFixedStringElement, lString);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleFixedCharElementGreen LexerRuleFixedCharElement(InternalSyntaxToken lCharacter)
	    {
	#if DEBUG
			if (lCharacter == null) throw new ArgumentNullException(nameof(lCharacter));
			if (lCharacter.Kind != CompilerSyntaxKind.LCharacter) throw new ArgumentException(nameof(lCharacter));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleFixedCharElement, lCharacter, out hash);
			if (cached != null) return (LexerRuleFixedCharElementGreen)cached;
			var result = new LexerRuleFixedCharElementGreen(CompilerSyntaxKind.LexerRuleFixedCharElement, lCharacter);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleBlockElementGreen LexerRuleBlockElement(InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<LexerRuleAlternativeGreen> lexerRuleAlternative, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleBlockElement, tOpenParen, lexerRuleAlternative.Node, tCloseParen, out hash);
			if (cached != null) return (LexerRuleBlockElementGreen)cached;
			var result = new LexerRuleBlockElementGreen(CompilerSyntaxKind.LexerRuleBlockElement, tOpenParen, lexerRuleAlternative.Node, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleRangeElementGreen LexerRuleRangeElement(LexerRuleFixedCharElementGreen start, InternalSyntaxToken tDotDot, LexerRuleFixedCharElementGreen end)
	    {
	#if DEBUG
			if (start == null) throw new ArgumentNullException(nameof(start));
			if (tDotDot == null) throw new ArgumentNullException(nameof(tDotDot));
			if (tDotDot.Kind != CompilerSyntaxKind.TDotDot) throw new ArgumentException(nameof(tDotDot));
			if (end == null) throw new ArgumentNullException(nameof(end));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleRangeElement, start, tDotDot, end, out hash);
			if (cached != null) return (LexerRuleRangeElementGreen)cached;
			var result = new LexerRuleRangeElementGreen(CompilerSyntaxKind.LexerRuleRangeElement, start, tDotDot, end);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(CompilerSyntaxKind.Name, identifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(CompilerSyntaxKind.QualifiedName, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(CompilerSyntaxKind.Qualifier, identifier.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.Identifier, identifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(CompilerSyntaxKind.Identifier, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleIdentifierGreen LexerRuleIdentifier(InternalSyntaxToken lexerIdentifier)
	    {
	#if DEBUG
			if (lexerIdentifier == null) throw new ArgumentNullException(nameof(lexerIdentifier));
			if (lexerIdentifier.Kind != CompilerSyntaxKind.LexerIdentifier) throw new ArgumentException(nameof(lexerIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleIdentifier, lexerIdentifier, out hash);
			if (cached != null) return (LexerRuleIdentifierGreen)cached;
			var result = new LexerRuleIdentifierGreen(CompilerSyntaxKind.LexerRuleIdentifier, lexerIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleIdentifierGreen ParserRuleIdentifier(InternalSyntaxToken parserIdentifier)
	    {
	#if DEBUG
			if (parserIdentifier == null) throw new ArgumentNullException(nameof(parserIdentifier));
			if (parserIdentifier.Kind != CompilerSyntaxKind.ParserIdentifier) throw new ArgumentException(nameof(parserIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleIdentifier, parserIdentifier, out hash);
			if (cached != null) return (ParserRuleIdentifierGreen)cached;
			var result = new ParserRuleIdentifierGreen(CompilerSyntaxKind.ParserRuleIdentifier, parserIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LexerRuleNameGreen LexerRuleName(InternalSyntaxToken lexerIdentifier)
	    {
	#if DEBUG
			if (lexerIdentifier == null) throw new ArgumentNullException(nameof(lexerIdentifier));
			if (lexerIdentifier.Kind != CompilerSyntaxKind.LexerIdentifier) throw new ArgumentException(nameof(lexerIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.LexerRuleName, lexerIdentifier, out hash);
			if (cached != null) return (LexerRuleNameGreen)cached;
			var result = new LexerRuleNameGreen(CompilerSyntaxKind.LexerRuleName, lexerIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParserRuleNameGreen ParserRuleName(InternalSyntaxToken parserIdentifier)
	    {
	#if DEBUG
			if (parserIdentifier == null) throw new ArgumentNullException(nameof(parserIdentifier));
			if (parserIdentifier.Kind != CompilerSyntaxKind.ParserIdentifier) throw new ArgumentException(nameof(parserIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ParserRuleName, parserIdentifier, out hash);
			if (cached != null) return (ParserRuleNameGreen)cached;
			var result = new ParserRuleNameGreen(CompilerSyntaxKind.ParserRuleName, parserIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementNameGreen ElementName(InternalSyntaxToken elementName)
	    {
	#if DEBUG
			if (elementName == null) throw new ArgumentNullException(nameof(elementName));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ElementName, elementName, out hash);
			if (cached != null) return (ElementNameGreen)cached;
			var result = new ElementNameGreen(CompilerSyntaxKind.ElementName, elementName);
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
			return new LiteralGreen(CompilerSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(CompilerSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			return new LiteralGreen(CompilerSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			return new LiteralGreen(CompilerSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			return new LiteralGreen(CompilerSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(CompilerSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != CompilerSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(CompilerSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(CompilerSyntaxKind.BooleanLiteral, booleanLiteral);
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
			if (lInteger.Kind != CompilerSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(CompilerSyntaxKind.IntegerLiteral, lInteger);
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
			if (lDecimal.Kind != CompilerSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(CompilerSyntaxKind.DecimalLiteral, lDecimal);
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
			if (lScientific.Kind != CompilerSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(CompilerSyntaxKind.ScientificLiteral, lScientific);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringLiteralGreen StringLiteral(InternalSyntaxToken lString)
	    {
	#if DEBUG
			if (lString == null) throw new ArgumentNullException(nameof(lString));
			if (lString.Kind != CompilerSyntaxKind.LString) throw new ArgumentException(nameof(lString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.StringLiteral, lString, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(CompilerSyntaxKind.StringLiteral, lString);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CharLiteralGreen CharLiteral(InternalSyntaxToken lCharacter)
	    {
	#if DEBUG
			if (lCharacter == null) throw new ArgumentNullException(nameof(lCharacter));
			if (lCharacter.Kind != CompilerSyntaxKind.LCharacter) throw new ArgumentException(nameof(lCharacter));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CompilerSyntaxKind)CompilerSyntaxKind.CharLiteral, lCharacter, out hash);
			if (cached != null) return (CharLiteralGreen)cached;
			var result = new CharLiteralGreen(CompilerSyntaxKind.CharLiteral, lCharacter);
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
				typeof(AnnotationGreen),
				typeof(NamespaceDeclarationGreen),
				typeof(NamespaceBodyGreen),
				typeof(GrammarDeclarationGreen),
				typeof(UsingDeclarationGreen),
				typeof(RuleDeclarationsGreen),
				typeof(RuleDeclarationGreen),
				typeof(ParserRuleDeclarationGreen),
				typeof(ParserRuleAltGreen),
				typeof(ParserRuleAltRefGreen),
				typeof(ParserRuleSimpleGreen),
				typeof(EofElementGreen),
				typeof(ParserRuleNamedElementGreen),
				typeof(AssignGreen),
				typeof(MultiplicityGreen),
				typeof(ParserNegatedElementGreen),
				typeof(ParserRuleElementGreen),
				typeof(ParserRuleFixedElementGreen),
				typeof(ParserRuleWildcardElementGreen),
				typeof(ParserRuleReferenceGreen),
				typeof(ParserRuleBlockElementGreen),
				typeof(LexerRuleDeclarationGreen),
				typeof(LexerRuleAlternativeGreen),
				typeof(LexerRuleAlternativeElementGreen),
				typeof(LexerRuleElementGreen),
				typeof(LexerRuleReferenceElementGreen),
				typeof(LexerRuleWildcardElementGreen),
				typeof(LexerRuleFixedStringElementGreen),
				typeof(LexerRuleFixedCharElementGreen),
				typeof(LexerRuleBlockElementGreen),
				typeof(LexerRuleRangeElementGreen),
				typeof(NameGreen),
				typeof(QualifiedNameGreen),
				typeof(QualifierGreen),
				typeof(IdentifierGreen),
				typeof(LexerRuleIdentifierGreen),
				typeof(ParserRuleIdentifierGreen),
				typeof(LexerRuleNameGreen),
				typeof(ParserRuleNameGreen),
				typeof(ElementNameGreen),
				typeof(LiteralGreen),
				typeof(NullLiteralGreen),
				typeof(BooleanLiteralGreen),
				typeof(IntegerLiteralGreen),
				typeof(DecimalLiteralGreen),
				typeof(ScientificLiteralGreen),
				typeof(StringLiteralGreen),
				typeof(CharLiteralGreen),
			};
		}
	}
}


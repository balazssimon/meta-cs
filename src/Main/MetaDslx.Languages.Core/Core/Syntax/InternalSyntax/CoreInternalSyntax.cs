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

namespace MetaDslx.Languages.Core.Syntax.InternalSyntax
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
            if (visitor is CoreSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is CoreSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor);
        public abstract void Accept(CoreSyntaxVisitor visitor);

        public new CoreLanguage Language => CoreLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new CoreSyntaxKind Kind => (CoreSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

		// Use conditional weak table so we always return same identity for structured trivia
		private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
			= new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

		/// <summary>
		/// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
		/// determine if this trivia has structure.
		/// </summary>
		/// <returns>
		/// A CoreSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
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
							structure = CoreStructuredTriviaSyntax.Create(trivia);
							structsInParent.Add(trivia, structure);
						}
					}

					return structure;
				}
				else
				{
					return CoreStructuredTriviaSyntax.Create(trivia);
				}
			}

			return null;
		}

	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(CoreSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new CoreLanguage Language => CoreLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new CoreSyntaxKind Kind => EnumObject.FromIntUnsafe<CoreSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(CoreSyntaxKind kind, string text)
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
        internal GreenStructuredTriviaSyntax(CoreSyntaxKind kind, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        internal GreenSkippedTokensTriviaSyntax(CoreSyntaxKind kind, GreenNode tokens, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        protected override SyntaxNode CreateRed(SyntaxNode parent, int position) => new CoreSkippedTokensTriviaSyntax(this, (CoreSyntaxNode)parent, position);

        public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitSkippedTokensTrivia(this);

        public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitSkippedTokensTrivia(this);

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
	    internal GreenSyntaxToken(CoreSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(CoreSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(CoreSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(CoreSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(CoreSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(CoreSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new CoreLanguage Language => CoreLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new CoreSyntaxKind Kind => EnumObject.FromIntUnsafe<CoreSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(CoreSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!CoreLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid CoreSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(CoreSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!CoreLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid CoreSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == CoreLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == CoreLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == CoreLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == CoreLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(CoreSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly CoreSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly CoreSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = CoreSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = CoreSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = CoreLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((CoreSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((CoreSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((CoreSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((CoreSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(CoreSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(CoreSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(CoreSyntaxKind kind, CoreSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(CoreSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(CoreSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual CoreSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(CoreSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(CoreSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(CoreSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(CoreSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly CoreSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(CoreSyntaxKind kind, CoreSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(CoreSyntaxKind kind, CoreSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<CoreSyntaxKind>(reader.ReadInt32());
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
	        public override CoreSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(CoreSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(CoreSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            CoreSyntaxKind kind,
	            CoreSyntaxKind contextualKind,
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
	            CoreSyntaxKind kind,
	            CoreSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(CoreSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(CoreSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(CoreSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            CoreSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(CoreSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(CoreSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    private GreenNode usingNamespace;
	    private GreenNode statement;
	    private InternalSyntaxToken eOF;
	
	    public MainGreen(CoreSyntaxKind kind, GreenNode usingNamespace, GreenNode statement, InternalSyntaxToken eOF)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (usingNamespace != null)
			{
				this.AdjustFlagsAndWidth(usingNamespace);
				this.usingNamespace = usingNamespace;
			}
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
	    public MainGreen(CoreSyntaxKind kind, GreenNode usingNamespace, GreenNode statement, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (usingNamespace != null)
			{
				this.AdjustFlagsAndWidth(usingNamespace);
				this.usingNamespace = usingNamespace;
			}
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
			if (eOF != null)
			{
				this.AdjustFlagsAndWidth(eOF);
				this.eOF = eOF;
			}
	    }
	
		private MainGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingNamespaceGreen> UsingNamespace { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingNamespaceGreen>(this.usingNamespace); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> Statement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen>(this.statement); } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.MainSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.usingNamespace;
	            case 1: return this.statement;
	            case 2: return this.eOF;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.usingNamespace, this.statement, this.eOF, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.usingNamespace, this.statement, this.eOF, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new MainGreen(this.Kind, this.usingNamespace, this.statement, this.eOF, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public MainGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingNamespaceGreen> usingNamespace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement, InternalSyntaxToken eOF)
	    {
	        if (this.UsingNamespace != usingNamespace ||
				this.Statement != statement ||
				this.EndOfFileToken != eOF)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Main(usingNamespace, statement, eOF);
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
	
	internal class UsingNamespaceGreen : GreenSyntaxNode
	{
	    internal static readonly UsingNamespaceGreen __Missing = new UsingNamespaceGreen();
	    private InternalSyntaxToken kUsing;
	    private NameGreen name;
	    private InternalSyntaxToken tAssign;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public UsingNamespaceGreen(CoreSyntaxKind kind, InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
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
	
	    public UsingNamespaceGreen(CoreSyntaxKind kind, InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
		private UsingNamespaceGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.UsingNamespace, null, null)
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
	        return new global::MetaDslx.Languages.Core.Syntax.UsingNamespaceSyntax(this, (CoreSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitUsingNamespaceGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitUsingNamespaceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UsingNamespaceGreen(this.Kind, this.kUsing, this.name, this.tAssign, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UsingNamespaceGreen(this.Kind, this.kUsing, this.name, this.tAssign, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new UsingNamespaceGreen(this.Kind, this.kUsing, this.name, this.tAssign, this.qualifier, this.tSemicolon, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public UsingNamespaceGreen Update(InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.Name != name ||
				this.TAssign != tAssign ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.UsingNamespace(kUsing, name, tAssign, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StatementGreen : GreenSyntaxNode
	{
	    internal static readonly StatementGreen __Missing = new StatementGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tSemicolon;
	
	    public StatementGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
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
	
	    public StatementGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
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
	
		private StatementGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.Statement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.StatementSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitStatementGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StatementGreen(this.Kind, this.expression, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StatementGreen(this.Kind, this.expression, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new StatementGreen(this.Kind, this.expression, this.tSemicolon, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public StatementGreen Update(ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Statement(expression, tSemicolon);
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
	
	internal class BlockStatementGreen : GreenSyntaxNode
	{
	    internal static readonly BlockStatementGreen __Missing = new BlockStatementGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode statement;
	    private InternalSyntaxToken tCloseBrace;
	
	    public BlockStatementGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode statement, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public BlockStatementGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode statement, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private BlockStatementGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.BlockStatement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> Statement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen>(this.statement); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.BlockStatementSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.statement;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitBlockStatementGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitBlockStatementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BlockStatementGreen(this.Kind, this.tOpenBrace, this.statement, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BlockStatementGreen(this.Kind, this.tOpenBrace, this.statement, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new BlockStatementGreen(this.Kind, this.tOpenBrace, this.statement, this.tCloseBrace, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public BlockStatementGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Statement != statement ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.BlockStatement(tOpenBrace, statement, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BlockStatementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ExpressionGreen __Missing = ParenthesizedExprGreen.__Missing;
	
	    public ExpressionGreen(CoreSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ParenthesizedExprGreen : ExpressionGreen
	{
	    internal static new readonly ParenthesizedExprGreen __Missing = new ParenthesizedExprGreen();
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParen;
	
	    public ParenthesizedExprGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ParenthesizedExprGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ParenthesizedExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ParenthesizedExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ParenthesizedExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.expression;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitParenthesizedExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitParenthesizedExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParenthesizedExprGreen(this.Kind, this.tOpenParen, this.expression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParenthesizedExprGreen(this.Kind, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ParenthesizedExprGreen(this.Kind, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ParenthesizedExprGreen Update(InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ParenthesizedExpr(tOpenParen, expression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenthesizedExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TupleExprGreen : ExpressionGreen
	{
	    internal static new readonly TupleExprGreen __Missing = new TupleExprGreen();
	    private InternalSyntaxToken tOpenParen;
	    private TupleArgumentsGreen tupleArguments;
	    private InternalSyntaxToken tCloseParen;
	
	    public TupleExprGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, TupleArgumentsGreen tupleArguments, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (tupleArguments != null)
			{
				this.AdjustFlagsAndWidth(tupleArguments);
				this.tupleArguments = tupleArguments;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public TupleExprGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, TupleArgumentsGreen tupleArguments, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (tupleArguments != null)
			{
				this.AdjustFlagsAndWidth(tupleArguments);
				this.tupleArguments = tupleArguments;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private TupleExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.TupleExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public TupleArgumentsGreen TupleArguments { get { return this.tupleArguments; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.TupleExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.tupleArguments;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitTupleExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitTupleExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TupleExprGreen(this.Kind, this.tOpenParen, this.tupleArguments, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TupleExprGreen(this.Kind, this.tOpenParen, this.tupleArguments, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new TupleExprGreen(this.Kind, this.tOpenParen, this.tupleArguments, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public TupleExprGreen Update(InternalSyntaxToken tOpenParen, TupleArgumentsGreen tupleArguments, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.TupleArguments != tupleArguments ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.TupleExpr(tOpenParen, tupleArguments, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TupleExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DiscardExprGreen : ExpressionGreen
	{
	    internal static new readonly DiscardExprGreen __Missing = new DiscardExprGreen();
	    private InternalSyntaxToken kDiscard;
	
	    public DiscardExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kDiscard)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kDiscard != null)
			{
				this.AdjustFlagsAndWidth(kDiscard);
				this.kDiscard = kDiscard;
			}
	    }
	
	    public DiscardExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kDiscard, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kDiscard != null)
			{
				this.AdjustFlagsAndWidth(kDiscard);
				this.kDiscard = kDiscard;
			}
	    }
	
		private DiscardExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.DiscardExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDiscard { get { return this.kDiscard; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.DiscardExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDiscard;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitDiscardExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitDiscardExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DiscardExprGreen(this.Kind, this.kDiscard, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DiscardExprGreen(this.Kind, this.kDiscard, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new DiscardExprGreen(this.Kind, this.kDiscard, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public DiscardExprGreen Update(InternalSyntaxToken kDiscard)
	    {
	        if (this.KDiscard != kDiscard)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.DiscardExpr(kDiscard);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DiscardExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefaultExprGreen : ExpressionGreen
	{
	    internal static new readonly DefaultExprGreen __Missing = new DefaultExprGreen();
	    private InternalSyntaxToken kDefault;
	
	    public DefaultExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kDefault)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kDefault != null)
			{
				this.AdjustFlagsAndWidth(kDefault);
				this.kDefault = kDefault;
			}
	    }
	
	    public DefaultExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kDefault, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kDefault != null)
			{
				this.AdjustFlagsAndWidth(kDefault);
				this.kDefault = kDefault;
			}
	    }
	
		private DefaultExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.DefaultExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDefault { get { return this.kDefault; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.DefaultExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDefault;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitDefaultExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitDefaultExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefaultExprGreen(this.Kind, this.kDefault, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefaultExprGreen(this.Kind, this.kDefault, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new DefaultExprGreen(this.Kind, this.kDefault, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public DefaultExprGreen Update(InternalSyntaxToken kDefault)
	    {
	        if (this.KDefault != kDefault)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.DefaultExpr(kDefault);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ThisExprGreen : ExpressionGreen
	{
	    internal static new readonly ThisExprGreen __Missing = new ThisExprGreen();
	    private InternalSyntaxToken kThis;
	
	    public ThisExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kThis)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kThis != null)
			{
				this.AdjustFlagsAndWidth(kThis);
				this.kThis = kThis;
			}
	    }
	
	    public ThisExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kThis, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kThis != null)
			{
				this.AdjustFlagsAndWidth(kThis);
				this.kThis = kThis;
			}
	    }
	
		private ThisExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ThisExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KThis { get { return this.kThis; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ThisExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kThis;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitThisExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitThisExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ThisExprGreen(this.Kind, this.kThis, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ThisExprGreen(this.Kind, this.kThis, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ThisExprGreen(this.Kind, this.kThis, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ThisExprGreen Update(InternalSyntaxToken kThis)
	    {
	        if (this.KThis != kThis)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ThisExpr(kThis);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThisExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BaseExprGreen : ExpressionGreen
	{
	    internal static new readonly BaseExprGreen __Missing = new BaseExprGreen();
	    private InternalSyntaxToken kBase;
	
	    public BaseExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kBase)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kBase != null)
			{
				this.AdjustFlagsAndWidth(kBase);
				this.kBase = kBase;
			}
	    }
	
	    public BaseExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kBase, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kBase != null)
			{
				this.AdjustFlagsAndWidth(kBase);
				this.kBase = kBase;
			}
	    }
	
		private BaseExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.BaseExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBase { get { return this.kBase; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.BaseExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBase;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitBaseExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitBaseExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BaseExprGreen(this.Kind, this.kBase, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BaseExprGreen(this.Kind, this.kBase, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new BaseExprGreen(this.Kind, this.kBase, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public BaseExprGreen Update(InternalSyntaxToken kBase)
	    {
	        if (this.KBase != kBase)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.BaseExpr(kBase);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BaseExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LiteralExprGreen : ExpressionGreen
	{
	    internal static new readonly LiteralExprGreen __Missing = new LiteralExprGreen();
	    private LiteralGreen literal;
	
	    public LiteralExprGreen(CoreSyntaxKind kind, LiteralGreen literal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
	    public LiteralExprGreen(CoreSyntaxKind kind, LiteralGreen literal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
	    }
	
		private LiteralExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.LiteralExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LiteralGreen Literal { get { return this.literal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.LiteralExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.literal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitLiteralExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralExprGreen(this.Kind, this.literal, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralExprGreen(this.Kind, this.literal, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LiteralExprGreen(this.Kind, this.literal, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LiteralExprGreen Update(LiteralGreen literal)
	    {
	        if (this.Literal != literal)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LiteralExpr(literal);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierExprGreen : ExpressionGreen
	{
	    internal static new readonly IdentifierExprGreen __Missing = new IdentifierExprGreen();
	    private IdentifierGreen identifier;
	    private GenericTypeArgumentsGreen genericTypeArguments;
	
	    public IdentifierExprGreen(CoreSyntaxKind kind, IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (genericTypeArguments != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArguments);
				this.genericTypeArguments = genericTypeArguments;
			}
	    }
	
	    public IdentifierExprGreen(CoreSyntaxKind kind, IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (genericTypeArguments != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArguments);
				this.genericTypeArguments = genericTypeArguments;
			}
	    }
	
		private IdentifierExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.IdentifierExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public GenericTypeArgumentsGreen GenericTypeArguments { get { return this.genericTypeArguments; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.IdentifierExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.genericTypeArguments;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitIdentifierExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierExprGreen(this.Kind, this.identifier, this.genericTypeArguments, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierExprGreen(this.Kind, this.identifier, this.genericTypeArguments, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new IdentifierExprGreen(this.Kind, this.identifier, this.genericTypeArguments, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public IdentifierExprGreen Update(IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments)
	    {
	        if (this.Identifier != identifier ||
				this.GenericTypeArguments != genericTypeArguments)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.IdentifierExpr(identifier, genericTypeArguments);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifierExprGreen : ExpressionGreen
	{
	    internal static new readonly QualifierExprGreen __Missing = new QualifierExprGreen();
	    private ExpressionGreen expression;
	    private DotOperatorGreen dotOperator;
	    private IdentifierGreen identifier;
	    private GenericTypeArgumentsGreen genericTypeArguments;
	
	    public QualifierExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, DotOperatorGreen dotOperator, IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (dotOperator != null)
			{
				this.AdjustFlagsAndWidth(dotOperator);
				this.dotOperator = dotOperator;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (genericTypeArguments != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArguments);
				this.genericTypeArguments = genericTypeArguments;
			}
	    }
	
	    public QualifierExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, DotOperatorGreen dotOperator, IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (dotOperator != null)
			{
				this.AdjustFlagsAndWidth(dotOperator);
				this.dotOperator = dotOperator;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (genericTypeArguments != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArguments);
				this.genericTypeArguments = genericTypeArguments;
			}
	    }
	
		private QualifierExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.QualifierExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public DotOperatorGreen DotOperator { get { return this.dotOperator; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public GenericTypeArgumentsGreen GenericTypeArguments { get { return this.genericTypeArguments; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.QualifierExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.dotOperator;
	            case 2: return this.identifier;
	            case 3: return this.genericTypeArguments;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitQualifierExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifierExprGreen(this.Kind, this.expression, this.dotOperator, this.identifier, this.genericTypeArguments, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierExprGreen(this.Kind, this.expression, this.dotOperator, this.identifier, this.genericTypeArguments, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new QualifierExprGreen(this.Kind, this.expression, this.dotOperator, this.identifier, this.genericTypeArguments, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public QualifierExprGreen Update(ExpressionGreen expression, DotOperatorGreen dotOperator, IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments)
	    {
	        if (this.Expression != expression ||
				this.DotOperator != dotOperator ||
				this.Identifier != identifier ||
				this.GenericTypeArguments != genericTypeArguments)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.QualifierExpr(expression, dotOperator, identifier, genericTypeArguments);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IndexerExprGreen : ExpressionGreen
	{
	    internal static new readonly IndexerExprGreen __Missing = new IndexerExprGreen();
	    private ExpressionGreen expression;
	    private IndexerOperatorGreen indexerOperator;
	    private ArgumentListGreen argumentList;
	    private InternalSyntaxToken tCloseBracket;
	
	    public IndexerExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, IndexerOperatorGreen indexerOperator, ArgumentListGreen argumentList, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (indexerOperator != null)
			{
				this.AdjustFlagsAndWidth(indexerOperator);
				this.indexerOperator = indexerOperator;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public IndexerExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, IndexerOperatorGreen indexerOperator, ArgumentListGreen argumentList, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (indexerOperator != null)
			{
				this.AdjustFlagsAndWidth(indexerOperator);
				this.indexerOperator = indexerOperator;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private IndexerExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.IndexerExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public IndexerOperatorGreen IndexerOperator { get { return this.indexerOperator; } }
	    public ArgumentListGreen ArgumentList { get { return this.argumentList; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.IndexerExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.indexerOperator;
	            case 2: return this.argumentList;
	            case 3: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitIndexerExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitIndexerExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IndexerExprGreen(this.Kind, this.expression, this.indexerOperator, this.argumentList, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IndexerExprGreen(this.Kind, this.expression, this.indexerOperator, this.argumentList, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new IndexerExprGreen(this.Kind, this.expression, this.indexerOperator, this.argumentList, this.tCloseBracket, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public IndexerExprGreen Update(ExpressionGreen expression, IndexerOperatorGreen indexerOperator, ArgumentListGreen argumentList, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.Expression != expression ||
				this.IndexerOperator != indexerOperator ||
				this.ArgumentList != argumentList ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.IndexerExpr(expression, indexerOperator, argumentList, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IndexerExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InvocationExprGreen : ExpressionGreen
	{
	    internal static new readonly InvocationExprGreen __Missing = new InvocationExprGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tOpenParen;
	    private ArgumentListGreen argumentList;
	    private InternalSyntaxToken tCloseParen;
	
	    public InvocationExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public InvocationExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private InvocationExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.InvocationExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ArgumentListGreen ArgumentList { get { return this.argumentList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.InvocationExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.tOpenParen;
	            case 2: return this.argumentList;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitInvocationExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitInvocationExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InvocationExprGreen(this.Kind, this.expression, this.tOpenParen, this.argumentList, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InvocationExprGreen(this.Kind, this.expression, this.tOpenParen, this.argumentList, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new InvocationExprGreen(this.Kind, this.expression, this.tOpenParen, this.argumentList, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public InvocationExprGreen Update(ExpressionGreen expression, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen)
	    {
	        if (this.Expression != expression ||
				this.TOpenParen != tOpenParen ||
				this.ArgumentList != argumentList ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.InvocationExpr(expression, tOpenParen, argumentList, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InvocationExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeofExprGreen : ExpressionGreen
	{
	    internal static new readonly TypeofExprGreen __Missing = new TypeofExprGreen();
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParen;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParen;
	
	    public TypeofExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public TypeofExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kTypeof != null)
			{
				this.AdjustFlagsAndWidth(kTypeof);
				this.kTypeof = kTypeof;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private TypeofExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.TypeofExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.TypeofExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeof;
	            case 1: return this.tOpenParen;
	            case 2: return this.typeReference;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitTypeofExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitTypeofExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeofExprGreen(this.Kind, this.kTypeof, this.tOpenParen, this.typeReference, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeofExprGreen(this.Kind, this.kTypeof, this.tOpenParen, this.typeReference, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new TypeofExprGreen(this.Kind, this.kTypeof, this.tOpenParen, this.typeReference, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public TypeofExprGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParen != tOpenParen ||
				this.TypeReference != typeReference ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.TypeofExpr(kTypeof, tOpenParen, typeReference, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameofExprGreen : ExpressionGreen
	{
	    internal static new readonly NameofExprGreen __Missing = new NameofExprGreen();
	    private InternalSyntaxToken kNameof;
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParen;
	
	    public NameofExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kNameof, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kNameof != null)
			{
				this.AdjustFlagsAndWidth(kNameof);
				this.kNameof = kNameof;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public NameofExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kNameof, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kNameof != null)
			{
				this.AdjustFlagsAndWidth(kNameof);
				this.kNameof = kNameof;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private NameofExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.NameofExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNameof { get { return this.kNameof; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NameofExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNameof;
	            case 1: return this.tOpenParen;
	            case 2: return this.expression;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNameofExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNameofExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameofExprGreen(this.Kind, this.kNameof, this.tOpenParen, this.expression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameofExprGreen(this.Kind, this.kNameof, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NameofExprGreen(this.Kind, this.kNameof, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NameofExprGreen Update(InternalSyntaxToken kNameof, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.KNameof != kNameof ||
				this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NameofExpr(kNameof, tOpenParen, expression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameofExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SizeofExprGreen : ExpressionGreen
	{
	    internal static new readonly SizeofExprGreen __Missing = new SizeofExprGreen();
	    private InternalSyntaxToken kSizeof;
	    private InternalSyntaxToken tOpenParen;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParen;
	
	    public SizeofExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kSizeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kSizeof != null)
			{
				this.AdjustFlagsAndWidth(kSizeof);
				this.kSizeof = kSizeof;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public SizeofExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kSizeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kSizeof != null)
			{
				this.AdjustFlagsAndWidth(kSizeof);
				this.kSizeof = kSizeof;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private SizeofExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.SizeofExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KSizeof { get { return this.kSizeof; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.SizeofExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSizeof;
	            case 1: return this.tOpenParen;
	            case 2: return this.typeReference;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitSizeofExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitSizeofExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SizeofExprGreen(this.Kind, this.kSizeof, this.tOpenParen, this.typeReference, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SizeofExprGreen(this.Kind, this.kSizeof, this.tOpenParen, this.typeReference, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new SizeofExprGreen(this.Kind, this.kSizeof, this.tOpenParen, this.typeReference, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public SizeofExprGreen Update(InternalSyntaxToken kSizeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen)
	    {
	        if (this.KSizeof != kSizeof ||
				this.TOpenParen != tOpenParen ||
				this.TypeReference != typeReference ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.SizeofExpr(kSizeof, tOpenParen, typeReference, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SizeofExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CheckedExprGreen : ExpressionGreen
	{
	    internal static new readonly CheckedExprGreen __Missing = new CheckedExprGreen();
	    private InternalSyntaxToken kChecked;
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParen;
	
	    public CheckedExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kChecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kChecked != null)
			{
				this.AdjustFlagsAndWidth(kChecked);
				this.kChecked = kChecked;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public CheckedExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kChecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kChecked != null)
			{
				this.AdjustFlagsAndWidth(kChecked);
				this.kChecked = kChecked;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private CheckedExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.CheckedExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KChecked { get { return this.kChecked; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.CheckedExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kChecked;
	            case 1: return this.tOpenParen;
	            case 2: return this.expression;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitCheckedExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitCheckedExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CheckedExprGreen(this.Kind, this.kChecked, this.tOpenParen, this.expression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CheckedExprGreen(this.Kind, this.kChecked, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CheckedExprGreen(this.Kind, this.kChecked, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CheckedExprGreen Update(InternalSyntaxToken kChecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.KChecked != kChecked ||
				this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.CheckedExpr(kChecked, tOpenParen, expression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CheckedExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UncheckedExprGreen : ExpressionGreen
	{
	    internal static new readonly UncheckedExprGreen __Missing = new UncheckedExprGreen();
	    private InternalSyntaxToken kUnchecked;
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParen;
	
	    public UncheckedExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kUnchecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kUnchecked != null)
			{
				this.AdjustFlagsAndWidth(kUnchecked);
				this.kUnchecked = kUnchecked;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public UncheckedExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kUnchecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kUnchecked != null)
			{
				this.AdjustFlagsAndWidth(kUnchecked);
				this.kUnchecked = kUnchecked;
			}
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private UncheckedExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.UncheckedExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KUnchecked { get { return this.kUnchecked; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.UncheckedExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kUnchecked;
	            case 1: return this.tOpenParen;
	            case 2: return this.expression;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitUncheckedExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitUncheckedExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UncheckedExprGreen(this.Kind, this.kUnchecked, this.tOpenParen, this.expression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UncheckedExprGreen(this.Kind, this.kUnchecked, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new UncheckedExprGreen(this.Kind, this.kUnchecked, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public UncheckedExprGreen Update(InternalSyntaxToken kUnchecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.KUnchecked != kUnchecked ||
				this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.UncheckedExpr(kUnchecked, tOpenParen, expression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UncheckedExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NewExprGreen : ExpressionGreen
	{
	    internal static new readonly NewExprGreen __Missing = new NewExprGreen();
	    private InternalSyntaxToken kNew;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tOpenParen;
	    private ArgumentListGreen argumentList;
	    private InternalSyntaxToken tCloseParen;
	    private InitializerExpressionGreen initializerExpression;
	
	    public NewExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen, InitializerExpressionGreen initializerExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
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
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (initializerExpression != null)
			{
				this.AdjustFlagsAndWidth(initializerExpression);
				this.initializerExpression = initializerExpression;
			}
	    }
	
	    public NewExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen, InitializerExpressionGreen initializerExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
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
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (initializerExpression != null)
			{
				this.AdjustFlagsAndWidth(initializerExpression);
				this.initializerExpression = initializerExpression;
			}
	    }
	
		private NewExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.NewExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNew { get { return this.kNew; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ArgumentListGreen ArgumentList { get { return this.argumentList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InitializerExpressionGreen InitializerExpression { get { return this.initializerExpression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NewExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNew;
	            case 1: return this.typeReference;
	            case 2: return this.tOpenParen;
	            case 3: return this.argumentList;
	            case 4: return this.tCloseParen;
	            case 5: return this.initializerExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNewExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNewExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NewExprGreen(this.Kind, this.kNew, this.typeReference, this.tOpenParen, this.argumentList, this.tCloseParen, this.initializerExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NewExprGreen(this.Kind, this.kNew, this.typeReference, this.tOpenParen, this.argumentList, this.tCloseParen, this.initializerExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NewExprGreen(this.Kind, this.kNew, this.typeReference, this.tOpenParen, this.argumentList, this.tCloseParen, this.initializerExpression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NewExprGreen Update(InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen, InitializerExpressionGreen initializerExpression)
	    {
	        if (this.KNew != kNew ||
				this.TypeReference != typeReference ||
				this.TOpenParen != tOpenParen ||
				this.ArgumentList != argumentList ||
				this.TCloseParen != tCloseParen ||
				this.InitializerExpression != initializerExpression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NewExpr(kNew, typeReference, tOpenParen, argumentList, tCloseParen, initializerExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NewExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PostfixUnaryExprGreen : ExpressionGreen
	{
	    internal static new readonly PostfixUnaryExprGreen __Missing = new PostfixUnaryExprGreen();
	    private ExpressionGreen expression;
	    private PostfixOperatorGreen postfixOperator;
	
	    public PostfixUnaryExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, PostfixOperatorGreen postfixOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (postfixOperator != null)
			{
				this.AdjustFlagsAndWidth(postfixOperator);
				this.postfixOperator = postfixOperator;
			}
	    }
	
	    public PostfixUnaryExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, PostfixOperatorGreen postfixOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (postfixOperator != null)
			{
				this.AdjustFlagsAndWidth(postfixOperator);
				this.postfixOperator = postfixOperator;
			}
	    }
	
		private PostfixUnaryExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.PostfixUnaryExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public PostfixOperatorGreen PostfixOperator { get { return this.postfixOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.PostfixUnaryExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.postfixOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitPostfixUnaryExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitPostfixUnaryExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PostfixUnaryExprGreen(this.Kind, this.expression, this.postfixOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PostfixUnaryExprGreen(this.Kind, this.expression, this.postfixOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new PostfixUnaryExprGreen(this.Kind, this.expression, this.postfixOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public PostfixUnaryExprGreen Update(ExpressionGreen expression, PostfixOperatorGreen postfixOperator)
	    {
	        if (this.Expression != expression ||
				this.PostfixOperator != postfixOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.PostfixUnaryExpr(expression, postfixOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PostfixUnaryExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NullForgivingExprGreen : ExpressionGreen
	{
	    internal static new readonly NullForgivingExprGreen __Missing = new NullForgivingExprGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tExclamation;
	
	    public NullForgivingExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tExclamation)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
	    public NullForgivingExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken tExclamation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
		private NullForgivingExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.NullForgivingExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NullForgivingExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.tExclamation;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNullForgivingExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNullForgivingExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullForgivingExprGreen(this.Kind, this.expression, this.tExclamation, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullForgivingExprGreen(this.Kind, this.expression, this.tExclamation, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NullForgivingExprGreen(this.Kind, this.expression, this.tExclamation, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NullForgivingExprGreen Update(ExpressionGreen expression, InternalSyntaxToken tExclamation)
	    {
	        if (this.Expression != expression ||
				this.TExclamation != tExclamation)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NullForgivingExpr(expression, tExclamation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullForgivingExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UnaryExprGreen : ExpressionGreen
	{
	    internal static new readonly UnaryExprGreen __Missing = new UnaryExprGreen();
	    private UnaryOperatorGreen unaryOperator;
	    private ExpressionGreen expression;
	
	    public UnaryExprGreen(CoreSyntaxKind kind, UnaryOperatorGreen unaryOperator, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (unaryOperator != null)
			{
				this.AdjustFlagsAndWidth(unaryOperator);
				this.unaryOperator = unaryOperator;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public UnaryExprGreen(CoreSyntaxKind kind, UnaryOperatorGreen unaryOperator, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (unaryOperator != null)
			{
				this.AdjustFlagsAndWidth(unaryOperator);
				this.unaryOperator = unaryOperator;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private UnaryExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.UnaryExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public UnaryOperatorGreen UnaryOperator { get { return this.unaryOperator; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.UnaryExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.unaryOperator;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitUnaryExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitUnaryExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UnaryExprGreen(this.Kind, this.unaryOperator, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UnaryExprGreen(this.Kind, this.unaryOperator, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new UnaryExprGreen(this.Kind, this.unaryOperator, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public UnaryExprGreen Update(UnaryOperatorGreen unaryOperator, ExpressionGreen expression)
	    {
	        if (this.UnaryOperator != unaryOperator ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.UnaryExpr(unaryOperator, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnaryExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeCastExprGreen : ExpressionGreen
	{
	    internal static new readonly TypeCastExprGreen __Missing = new TypeCastExprGreen();
	    private InternalSyntaxToken tOpenParen;
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tCloseParen;
	    private ExpressionGreen expression;
	
	    public TypeCastExprGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public TypeCastExprGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private TypeCastExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.TypeCastExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.TypeCastExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.typeReference;
	            case 2: return this.tCloseParen;
	            case 3: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitTypeCastExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitTypeCastExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeCastExprGreen(this.Kind, this.tOpenParen, this.typeReference, this.tCloseParen, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeCastExprGreen(this.Kind, this.tOpenParen, this.typeReference, this.tCloseParen, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new TypeCastExprGreen(this.Kind, this.tOpenParen, this.typeReference, this.tCloseParen, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public TypeCastExprGreen Update(InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen, ExpressionGreen expression)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.TypeReference != typeReference ||
				this.TCloseParen != tCloseParen ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.TypeCastExpr(tOpenParen, typeReference, tCloseParen, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeCastExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AwaitExprGreen : ExpressionGreen
	{
	    internal static new readonly AwaitExprGreen __Missing = new AwaitExprGreen();
	    private InternalSyntaxToken kAwait;
	    private ExpressionGreen expression;
	
	    public AwaitExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kAwait, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kAwait != null)
			{
				this.AdjustFlagsAndWidth(kAwait);
				this.kAwait = kAwait;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public AwaitExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kAwait, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kAwait != null)
			{
				this.AdjustFlagsAndWidth(kAwait);
				this.kAwait = kAwait;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private AwaitExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.AwaitExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAwait { get { return this.kAwait; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.AwaitExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAwait;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitAwaitExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitAwaitExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AwaitExprGreen(this.Kind, this.kAwait, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AwaitExprGreen(this.Kind, this.kAwait, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AwaitExprGreen(this.Kind, this.kAwait, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AwaitExprGreen Update(InternalSyntaxToken kAwait, ExpressionGreen expression)
	    {
	        if (this.KAwait != kAwait ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.AwaitExpr(kAwait, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AwaitExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MultExprGreen : ExpressionGreen
	{
	    internal static new readonly MultExprGreen __Missing = new MultExprGreen();
	    private ExpressionGreen left;
	    private MultiplicativeOperatorGreen multiplicativeOperator;
	    private ExpressionGreen right;
	
	    public MultExprGreen(CoreSyntaxKind kind, ExpressionGreen left, MultiplicativeOperatorGreen multiplicativeOperator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (multiplicativeOperator != null)
			{
				this.AdjustFlagsAndWidth(multiplicativeOperator);
				this.multiplicativeOperator = multiplicativeOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public MultExprGreen(CoreSyntaxKind kind, ExpressionGreen left, MultiplicativeOperatorGreen multiplicativeOperator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (multiplicativeOperator != null)
			{
				this.AdjustFlagsAndWidth(multiplicativeOperator);
				this.multiplicativeOperator = multiplicativeOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private MultExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.MultExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public MultiplicativeOperatorGreen MultiplicativeOperator { get { return this.multiplicativeOperator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.MultExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.multiplicativeOperator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitMultExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitMultExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MultExprGreen(this.Kind, this.left, this.multiplicativeOperator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MultExprGreen(this.Kind, this.left, this.multiplicativeOperator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new MultExprGreen(this.Kind, this.left, this.multiplicativeOperator, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public MultExprGreen Update(ExpressionGreen left, MultiplicativeOperatorGreen multiplicativeOperator, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.MultiplicativeOperator != multiplicativeOperator ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.MultExpr(left, multiplicativeOperator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AddExprGreen : ExpressionGreen
	{
	    internal static new readonly AddExprGreen __Missing = new AddExprGreen();
	    private ExpressionGreen left;
	    private AdditiveOperatorGreen additiveOperator;
	    private ExpressionGreen right;
	
	    public AddExprGreen(CoreSyntaxKind kind, ExpressionGreen left, AdditiveOperatorGreen additiveOperator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (additiveOperator != null)
			{
				this.AdjustFlagsAndWidth(additiveOperator);
				this.additiveOperator = additiveOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AddExprGreen(CoreSyntaxKind kind, ExpressionGreen left, AdditiveOperatorGreen additiveOperator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (additiveOperator != null)
			{
				this.AdjustFlagsAndWidth(additiveOperator);
				this.additiveOperator = additiveOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private AddExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.AddExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public AdditiveOperatorGreen AdditiveOperator { get { return this.additiveOperator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.AddExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.additiveOperator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitAddExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitAddExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AddExprGreen(this.Kind, this.left, this.additiveOperator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AddExprGreen(this.Kind, this.left, this.additiveOperator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AddExprGreen(this.Kind, this.left, this.additiveOperator, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AddExprGreen Update(ExpressionGreen left, AdditiveOperatorGreen additiveOperator, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.AdditiveOperator != additiveOperator ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.AddExpr(left, additiveOperator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AddExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ShiftExprGreen : ExpressionGreen
	{
	    internal static new readonly ShiftExprGreen __Missing = new ShiftExprGreen();
	    private ExpressionGreen left;
	    private ShiftOperatorGreen shiftOperator;
	    private ExpressionGreen right;
	
	    public ShiftExprGreen(CoreSyntaxKind kind, ExpressionGreen left, ShiftOperatorGreen shiftOperator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (shiftOperator != null)
			{
				this.AdjustFlagsAndWidth(shiftOperator);
				this.shiftOperator = shiftOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public ShiftExprGreen(CoreSyntaxKind kind, ExpressionGreen left, ShiftOperatorGreen shiftOperator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (shiftOperator != null)
			{
				this.AdjustFlagsAndWidth(shiftOperator);
				this.shiftOperator = shiftOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private ShiftExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ShiftExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public ShiftOperatorGreen ShiftOperator { get { return this.shiftOperator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ShiftExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.shiftOperator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitShiftExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitShiftExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ShiftExprGreen(this.Kind, this.left, this.shiftOperator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ShiftExprGreen(this.Kind, this.left, this.shiftOperator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ShiftExprGreen(this.Kind, this.left, this.shiftOperator, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ShiftExprGreen Update(ExpressionGreen left, ShiftOperatorGreen shiftOperator, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.ShiftOperator != shiftOperator ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ShiftExpr(left, shiftOperator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ShiftExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RelExprGreen : ExpressionGreen
	{
	    internal static new readonly RelExprGreen __Missing = new RelExprGreen();
	    private ExpressionGreen left;
	    private RelationalOperatorGreen relationalOperator;
	    private ExpressionGreen right;
	
	    public RelExprGreen(CoreSyntaxKind kind, ExpressionGreen left, RelationalOperatorGreen relationalOperator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (relationalOperator != null)
			{
				this.AdjustFlagsAndWidth(relationalOperator);
				this.relationalOperator = relationalOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public RelExprGreen(CoreSyntaxKind kind, ExpressionGreen left, RelationalOperatorGreen relationalOperator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (relationalOperator != null)
			{
				this.AdjustFlagsAndWidth(relationalOperator);
				this.relationalOperator = relationalOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private RelExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.RelExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public RelationalOperatorGreen RelationalOperator { get { return this.relationalOperator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.RelExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.relationalOperator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitRelExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitRelExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RelExprGreen(this.Kind, this.left, this.relationalOperator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RelExprGreen(this.Kind, this.left, this.relationalOperator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new RelExprGreen(this.Kind, this.left, this.relationalOperator, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public RelExprGreen Update(ExpressionGreen left, RelationalOperatorGreen relationalOperator, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.RelationalOperator != relationalOperator ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.RelExpr(left, relationalOperator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RelExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeIsExprGreen : ExpressionGreen
	{
	    internal static new readonly TypeIsExprGreen __Missing = new TypeIsExprGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken kIs;
	    private InternalSyntaxToken kNot;
	    private TypeReferenceGreen typeReference;
	
	    public TypeIsExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken kIs, InternalSyntaxToken kNot, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (kIs != null)
			{
				this.AdjustFlagsAndWidth(kIs);
				this.kIs = kIs;
			}
			if (kNot != null)
			{
				this.AdjustFlagsAndWidth(kNot);
				this.kNot = kNot;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypeIsExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken kIs, InternalSyntaxToken kNot, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (kIs != null)
			{
				this.AdjustFlagsAndWidth(kIs);
				this.kIs = kIs;
			}
			if (kNot != null)
			{
				this.AdjustFlagsAndWidth(kNot);
				this.kNot = kNot;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private TypeIsExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.TypeIsExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken KIs { get { return this.kIs; } }
	    public InternalSyntaxToken KNot { get { return this.kNot; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.TypeIsExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.kIs;
	            case 2: return this.kNot;
	            case 3: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitTypeIsExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitTypeIsExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeIsExprGreen(this.Kind, this.expression, this.kIs, this.kNot, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeIsExprGreen(this.Kind, this.expression, this.kIs, this.kNot, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new TypeIsExprGreen(this.Kind, this.expression, this.kIs, this.kNot, this.typeReference, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public TypeIsExprGreen Update(ExpressionGreen expression, InternalSyntaxToken kIs, InternalSyntaxToken kNot, TypeReferenceGreen typeReference)
	    {
	        if (this.Expression != expression ||
				this.KIs != kIs ||
				this.KNot != kNot ||
				this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.TypeIsExpr(expression, kIs, kNot, typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeIsExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeAsExprGreen : ExpressionGreen
	{
	    internal static new readonly TypeAsExprGreen __Missing = new TypeAsExprGreen();
	    private ExpressionGreen expression;
	    private InternalSyntaxToken kAs;
	    private TypeReferenceGreen typeReference;
	
	    public TypeAsExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken kAs, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
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
	    }
	
	    public TypeAsExprGreen(CoreSyntaxKind kind, ExpressionGreen expression, InternalSyntaxToken kAs, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
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
	    }
	
		private TypeAsExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.TypeAsExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken KAs { get { return this.kAs; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.TypeAsExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.kAs;
	            case 2: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitTypeAsExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitTypeAsExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeAsExprGreen(this.Kind, this.expression, this.kAs, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeAsExprGreen(this.Kind, this.expression, this.kAs, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new TypeAsExprGreen(this.Kind, this.expression, this.kAs, this.typeReference, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public TypeAsExprGreen Update(ExpressionGreen expression, InternalSyntaxToken kAs, TypeReferenceGreen typeReference)
	    {
	        if (this.Expression != expression ||
				this.KAs != kAs ||
				this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.TypeAsExpr(expression, kAs, typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeAsExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EqExprGreen : ExpressionGreen
	{
	    internal static new readonly EqExprGreen __Missing = new EqExprGreen();
	    private ExpressionGreen left;
	    private EqualityOperatorGreen equalityOperator;
	    private ExpressionGreen right;
	
	    public EqExprGreen(CoreSyntaxKind kind, ExpressionGreen left, EqualityOperatorGreen equalityOperator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (equalityOperator != null)
			{
				this.AdjustFlagsAndWidth(equalityOperator);
				this.equalityOperator = equalityOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public EqExprGreen(CoreSyntaxKind kind, ExpressionGreen left, EqualityOperatorGreen equalityOperator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (equalityOperator != null)
			{
				this.AdjustFlagsAndWidth(equalityOperator);
				this.equalityOperator = equalityOperator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private EqExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.EqExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public EqualityOperatorGreen EqualityOperator { get { return this.equalityOperator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.EqExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.equalityOperator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitEqExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitEqExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EqExprGreen(this.Kind, this.left, this.equalityOperator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EqExprGreen(this.Kind, this.left, this.equalityOperator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new EqExprGreen(this.Kind, this.left, this.equalityOperator, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public EqExprGreen Update(ExpressionGreen left, EqualityOperatorGreen equalityOperator, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.EqualityOperator != equalityOperator ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.EqExpr(left, equalityOperator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EqExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AndExprGreen : ExpressionGreen
	{
	    internal static new readonly AndExprGreen __Missing = new AndExprGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tAmpersand;
	    private ExpressionGreen right;
	
	    public AndExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAmpersand, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAmpersand != null)
			{
				this.AdjustFlagsAndWidth(tAmpersand);
				this.tAmpersand = tAmpersand;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AndExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAmpersand, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAmpersand != null)
			{
				this.AdjustFlagsAndWidth(tAmpersand);
				this.tAmpersand = tAmpersand;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private AndExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.AndExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TAmpersand { get { return this.tAmpersand; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.AndExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tAmpersand;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitAndExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitAndExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AndExprGreen(this.Kind, this.left, this.tAmpersand, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AndExprGreen(this.Kind, this.left, this.tAmpersand, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AndExprGreen(this.Kind, this.left, this.tAmpersand, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AndExprGreen Update(ExpressionGreen left, InternalSyntaxToken tAmpersand, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TAmpersand != tAmpersand ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.AndExpr(left, tAmpersand, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class XorExprGreen : ExpressionGreen
	{
	    internal static new readonly XorExprGreen __Missing = new XorExprGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tHat;
	    private ExpressionGreen right;
	
	    public XorExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right)
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
	
	    public XorExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
		private XorExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.XorExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken THat { get { return this.tHat; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.XorExprSyntax(this, (CoreSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitXorExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitXorExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XorExprGreen(this.Kind, this.left, this.tHat, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XorExprGreen(this.Kind, this.left, this.tHat, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new XorExprGreen(this.Kind, this.left, this.tHat, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public XorExprGreen Update(ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.THat != tHat ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.XorExpr(left, tHat, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XorExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OrExprGreen : ExpressionGreen
	{
	    internal static new readonly OrExprGreen __Missing = new OrExprGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tBar;
	    private ExpressionGreen right;
	
	    public OrExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tBar, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public OrExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tBar, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private OrExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.OrExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TBar { get { return this.tBar; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.OrExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tBar;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitOrExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitOrExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OrExprGreen(this.Kind, this.left, this.tBar, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OrExprGreen(this.Kind, this.left, this.tBar, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new OrExprGreen(this.Kind, this.left, this.tBar, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public OrExprGreen Update(ExpressionGreen left, InternalSyntaxToken tBar, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TBar != tBar ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.OrExpr(left, tBar, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AndAlsoExprGreen : ExpressionGreen
	{
	    internal static new readonly AndAlsoExprGreen __Missing = new AndAlsoExprGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tAndAlso;
	    private ExpressionGreen right;
	
	    public AndAlsoExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAndAlso, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAndAlso != null)
			{
				this.AdjustFlagsAndWidth(tAndAlso);
				this.tAndAlso = tAndAlso;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AndAlsoExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tAndAlso, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tAndAlso != null)
			{
				this.AdjustFlagsAndWidth(tAndAlso);
				this.tAndAlso = tAndAlso;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private AndAlsoExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.AndAlsoExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TAndAlso { get { return this.tAndAlso; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.AndAlsoExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tAndAlso;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitAndAlsoExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitAndAlsoExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AndAlsoExprGreen(this.Kind, this.left, this.tAndAlso, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AndAlsoExprGreen(this.Kind, this.left, this.tAndAlso, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AndAlsoExprGreen(this.Kind, this.left, this.tAndAlso, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AndAlsoExprGreen Update(ExpressionGreen left, InternalSyntaxToken tAndAlso, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TAndAlso != tAndAlso ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.AndAlsoExpr(left, tAndAlso, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndAlsoExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OrElseExprGreen : ExpressionGreen
	{
	    internal static new readonly OrElseExprGreen __Missing = new OrElseExprGreen();
	    private ExpressionGreen left;
	    private InternalSyntaxToken tOrElse;
	    private ExpressionGreen right;
	
	    public OrElseExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tOrElse, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tOrElse != null)
			{
				this.AdjustFlagsAndWidth(tOrElse);
				this.tOrElse = tOrElse;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public OrElseExprGreen(CoreSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken tOrElse, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (tOrElse != null)
			{
				this.AdjustFlagsAndWidth(tOrElse);
				this.tOrElse = tOrElse;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		private OrElseExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.OrElseExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken TOrElse { get { return this.tOrElse; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.OrElseExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this.tOrElse;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitOrElseExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitOrElseExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OrElseExprGreen(this.Kind, this.left, this.tOrElse, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OrElseExprGreen(this.Kind, this.left, this.tOrElse, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new OrElseExprGreen(this.Kind, this.left, this.tOrElse, this.right, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public OrElseExprGreen Update(ExpressionGreen left, InternalSyntaxToken tOrElse, ExpressionGreen right)
	    {
	        if (this.Left != left ||
				this.TOrElse != tOrElse ||
				this.Right != right)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.OrElseExpr(left, tOrElse, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrElseExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ThrowExprGreen : ExpressionGreen
	{
	    internal static new readonly ThrowExprGreen __Missing = new ThrowExprGreen();
	    private InternalSyntaxToken kThrow;
	    private ExpressionGreen expression;
	
	    public ThrowExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kThrow, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kThrow != null)
			{
				this.AdjustFlagsAndWidth(kThrow);
				this.kThrow = kThrow;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ThrowExprGreen(CoreSyntaxKind kind, InternalSyntaxToken kThrow, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kThrow != null)
			{
				this.AdjustFlagsAndWidth(kThrow);
				this.kThrow = kThrow;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private ThrowExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ThrowExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KThrow { get { return this.kThrow; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ThrowExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kThrow;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitThrowExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitThrowExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ThrowExprGreen(this.Kind, this.kThrow, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ThrowExprGreen(this.Kind, this.kThrow, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ThrowExprGreen(this.Kind, this.kThrow, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ThrowExprGreen Update(InternalSyntaxToken kThrow, ExpressionGreen expression)
	    {
	        if (this.KThrow != kThrow ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ThrowExpr(kThrow, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThrowExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CoalExprGreen : ExpressionGreen
	{
	    internal static new readonly CoalExprGreen __Missing = new CoalExprGreen();
	    private ExpressionGreen value;
	    private InternalSyntaxToken tQuestionQuestion;
	    private ExpressionGreen whenNull;
	
	    public CoalExprGreen(CoreSyntaxKind kind, ExpressionGreen value, InternalSyntaxToken tQuestionQuestion, ExpressionGreen whenNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
			if (tQuestionQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestionQuestion);
				this.tQuestionQuestion = tQuestionQuestion;
			}
			if (whenNull != null)
			{
				this.AdjustFlagsAndWidth(whenNull);
				this.whenNull = whenNull;
			}
	    }
	
	    public CoalExprGreen(CoreSyntaxKind kind, ExpressionGreen value, InternalSyntaxToken tQuestionQuestion, ExpressionGreen whenNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
			if (tQuestionQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestionQuestion);
				this.tQuestionQuestion = tQuestionQuestion;
			}
			if (whenNull != null)
			{
				this.AdjustFlagsAndWidth(whenNull);
				this.whenNull = whenNull;
			}
	    }
	
		private CoalExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.CoalExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Value { get { return this.value; } }
	    public InternalSyntaxToken TQuestionQuestion { get { return this.tQuestionQuestion; } }
	    public ExpressionGreen WhenNull { get { return this.whenNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.CoalExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.value;
	            case 1: return this.tQuestionQuestion;
	            case 2: return this.whenNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitCoalExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitCoalExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CoalExprGreen(this.Kind, this.value, this.tQuestionQuestion, this.whenNull, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CoalExprGreen(this.Kind, this.value, this.tQuestionQuestion, this.whenNull, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CoalExprGreen(this.Kind, this.value, this.tQuestionQuestion, this.whenNull, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CoalExprGreen Update(ExpressionGreen value, InternalSyntaxToken tQuestionQuestion, ExpressionGreen whenNull)
	    {
	        if (this.Value != value ||
				this.TQuestionQuestion != tQuestionQuestion ||
				this.WhenNull != whenNull)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.CoalExpr(value, tQuestionQuestion, whenNull);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CoalExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CondExprGreen : ExpressionGreen
	{
	    internal static new readonly CondExprGreen __Missing = new CondExprGreen();
	    private ExpressionGreen condition;
	    private InternalSyntaxToken tQuestion;
	    private ExpressionGreen whenTrue;
	    private InternalSyntaxToken tColon;
	    private ExpressionGreen whenFalse;
	
	    public CondExprGreen(CoreSyntaxKind kind, ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen whenTrue, InternalSyntaxToken tColon, ExpressionGreen whenFalse)
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
			if (whenTrue != null)
			{
				this.AdjustFlagsAndWidth(whenTrue);
				this.whenTrue = whenTrue;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (whenFalse != null)
			{
				this.AdjustFlagsAndWidth(whenFalse);
				this.whenFalse = whenFalse;
			}
	    }
	
	    public CondExprGreen(CoreSyntaxKind kind, ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen whenTrue, InternalSyntaxToken tColon, ExpressionGreen whenFalse, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (whenTrue != null)
			{
				this.AdjustFlagsAndWidth(whenTrue);
				this.whenTrue = whenTrue;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (whenFalse != null)
			{
				this.AdjustFlagsAndWidth(whenFalse);
				this.whenFalse = whenFalse;
			}
	    }
	
		private CondExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.CondExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Condition { get { return this.condition; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	    public ExpressionGreen WhenTrue { get { return this.whenTrue; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ExpressionGreen WhenFalse { get { return this.whenFalse; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.CondExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.condition;
	            case 1: return this.tQuestion;
	            case 2: return this.whenTrue;
	            case 3: return this.tColon;
	            case 4: return this.whenFalse;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitCondExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitCondExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CondExprGreen(this.Kind, this.condition, this.tQuestion, this.whenTrue, this.tColon, this.whenFalse, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CondExprGreen(this.Kind, this.condition, this.tQuestion, this.whenTrue, this.tColon, this.whenFalse, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CondExprGreen(this.Kind, this.condition, this.tQuestion, this.whenTrue, this.tColon, this.whenFalse, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CondExprGreen Update(ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen whenTrue, InternalSyntaxToken tColon, ExpressionGreen whenFalse)
	    {
	        if (this.Condition != condition ||
				this.TQuestion != tQuestion ||
				this.WhenTrue != whenTrue ||
				this.TColon != tColon ||
				this.WhenFalse != whenFalse)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.CondExpr(condition, tQuestion, whenTrue, tColon, whenFalse);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CondExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssignExprGreen : ExpressionGreen
	{
	    internal static new readonly AssignExprGreen __Missing = new AssignExprGreen();
	    private ExpressionGreen target;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen value;
	
	    public AssignExprGreen(CoreSyntaxKind kind, ExpressionGreen target, InternalSyntaxToken tAssign, ExpressionGreen value)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
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
	    }
	
	    public AssignExprGreen(CoreSyntaxKind kind, ExpressionGreen target, InternalSyntaxToken tAssign, ExpressionGreen value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
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
	    }
	
		private AssignExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.AssignExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Value { get { return this.value; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.AssignExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.target;
	            case 1: return this.tAssign;
	            case 2: return this.value;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitAssignExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitAssignExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssignExprGreen(this.Kind, this.target, this.tAssign, this.value, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssignExprGreen(this.Kind, this.target, this.tAssign, this.value, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AssignExprGreen(this.Kind, this.target, this.tAssign, this.value, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AssignExprGreen Update(ExpressionGreen target, InternalSyntaxToken tAssign, ExpressionGreen value)
	    {
	        if (this.Target != target ||
				this.TAssign != tAssign ||
				this.Value != value)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.AssignExpr(target, tAssign, value);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompAssignExprGreen : ExpressionGreen
	{
	    internal static new readonly CompAssignExprGreen __Missing = new CompAssignExprGreen();
	    private ExpressionGreen target;
	    private CompoundAssignmentOperatorGreen compoundAssignmentOperator;
	    private ExpressionGreen value;
	
	    public CompAssignExprGreen(CoreSyntaxKind kind, ExpressionGreen target, CompoundAssignmentOperatorGreen compoundAssignmentOperator, ExpressionGreen value)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (compoundAssignmentOperator != null)
			{
				this.AdjustFlagsAndWidth(compoundAssignmentOperator);
				this.compoundAssignmentOperator = compoundAssignmentOperator;
			}
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
	    public CompAssignExprGreen(CoreSyntaxKind kind, ExpressionGreen target, CompoundAssignmentOperatorGreen compoundAssignmentOperator, ExpressionGreen value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (compoundAssignmentOperator != null)
			{
				this.AdjustFlagsAndWidth(compoundAssignmentOperator);
				this.compoundAssignmentOperator = compoundAssignmentOperator;
			}
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
		private CompAssignExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.CompAssignExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Target { get { return this.target; } }
	    public CompoundAssignmentOperatorGreen CompoundAssignmentOperator { get { return this.compoundAssignmentOperator; } }
	    public ExpressionGreen Value { get { return this.value; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.CompAssignExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.target;
	            case 1: return this.compoundAssignmentOperator;
	            case 2: return this.value;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitCompAssignExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitCompAssignExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompAssignExprGreen(this.Kind, this.target, this.compoundAssignmentOperator, this.value, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompAssignExprGreen(this.Kind, this.target, this.compoundAssignmentOperator, this.value, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CompAssignExprGreen(this.Kind, this.target, this.compoundAssignmentOperator, this.value, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CompAssignExprGreen Update(ExpressionGreen target, CompoundAssignmentOperatorGreen compoundAssignmentOperator, ExpressionGreen value)
	    {
	        if (this.Target != target ||
				this.CompoundAssignmentOperator != compoundAssignmentOperator ||
				this.Value != value)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.CompAssignExpr(target, compoundAssignmentOperator, value);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompAssignExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LambdaExprGreen : ExpressionGreen
	{
	    internal static new readonly LambdaExprGreen __Missing = new LambdaExprGreen();
	    private LambdaSignatureGreen lambdaSignature;
	    private InternalSyntaxToken tArrow;
	    private LambdaBodyGreen lambdaBody;
	
	    public LambdaExprGreen(CoreSyntaxKind kind, LambdaSignatureGreen lambdaSignature, InternalSyntaxToken tArrow, LambdaBodyGreen lambdaBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (lambdaSignature != null)
			{
				this.AdjustFlagsAndWidth(lambdaSignature);
				this.lambdaSignature = lambdaSignature;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (lambdaBody != null)
			{
				this.AdjustFlagsAndWidth(lambdaBody);
				this.lambdaBody = lambdaBody;
			}
	    }
	
	    public LambdaExprGreen(CoreSyntaxKind kind, LambdaSignatureGreen lambdaSignature, InternalSyntaxToken tArrow, LambdaBodyGreen lambdaBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (lambdaSignature != null)
			{
				this.AdjustFlagsAndWidth(lambdaSignature);
				this.lambdaSignature = lambdaSignature;
			}
			if (tArrow != null)
			{
				this.AdjustFlagsAndWidth(tArrow);
				this.tArrow = tArrow;
			}
			if (lambdaBody != null)
			{
				this.AdjustFlagsAndWidth(lambdaBody);
				this.lambdaBody = lambdaBody;
			}
	    }
	
		private LambdaExprGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.LambdaExpr, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LambdaSignatureGreen LambdaSignature { get { return this.lambdaSignature; } }
	    public InternalSyntaxToken TArrow { get { return this.tArrow; } }
	    public LambdaBodyGreen LambdaBody { get { return this.lambdaBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.LambdaExprSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lambdaSignature;
	            case 1: return this.tArrow;
	            case 2: return this.lambdaBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitLambdaExprGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitLambdaExprGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LambdaExprGreen(this.Kind, this.lambdaSignature, this.tArrow, this.lambdaBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LambdaExprGreen(this.Kind, this.lambdaSignature, this.tArrow, this.lambdaBody, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LambdaExprGreen(this.Kind, this.lambdaSignature, this.tArrow, this.lambdaBody, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LambdaExprGreen Update(LambdaSignatureGreen lambdaSignature, InternalSyntaxToken tArrow, LambdaBodyGreen lambdaBody)
	    {
	        if (this.LambdaSignature != lambdaSignature ||
				this.TArrow != tArrow ||
				this.LambdaBody != lambdaBody)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LambdaExpr(lambdaSignature, tArrow, lambdaBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaExprGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TupleArgumentsGreen : GreenSyntaxNode
	{
	    internal static readonly TupleArgumentsGreen __Missing = new TupleArgumentsGreen();
	    private ArgumentExpressionGreen argumentExpression;
	    private InternalSyntaxToken tComma;
	    private ArgumentListGreen argumentList;
	
	    public TupleArgumentsGreen(CoreSyntaxKind kind, ArgumentExpressionGreen argumentExpression, InternalSyntaxToken tComma, ArgumentListGreen argumentList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (argumentExpression != null)
			{
				this.AdjustFlagsAndWidth(argumentExpression);
				this.argumentExpression = argumentExpression;
			}
			if (tComma != null)
			{
				this.AdjustFlagsAndWidth(tComma);
				this.tComma = tComma;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
	    }
	
	    public TupleArgumentsGreen(CoreSyntaxKind kind, ArgumentExpressionGreen argumentExpression, InternalSyntaxToken tComma, ArgumentListGreen argumentList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (argumentExpression != null)
			{
				this.AdjustFlagsAndWidth(argumentExpression);
				this.argumentExpression = argumentExpression;
			}
			if (tComma != null)
			{
				this.AdjustFlagsAndWidth(tComma);
				this.tComma = tComma;
			}
			if (argumentList != null)
			{
				this.AdjustFlagsAndWidth(argumentList);
				this.argumentList = argumentList;
			}
	    }
	
		private TupleArgumentsGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.TupleArguments, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArgumentExpressionGreen ArgumentExpression { get { return this.argumentExpression; } }
	    public InternalSyntaxToken TComma { get { return this.tComma; } }
	    public ArgumentListGreen ArgumentList { get { return this.argumentList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.TupleArgumentsSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.argumentExpression;
	            case 1: return this.tComma;
	            case 2: return this.argumentList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitTupleArgumentsGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitTupleArgumentsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TupleArgumentsGreen(this.Kind, this.argumentExpression, this.tComma, this.argumentList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TupleArgumentsGreen(this.Kind, this.argumentExpression, this.tComma, this.argumentList, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new TupleArgumentsGreen(this.Kind, this.argumentExpression, this.tComma, this.argumentList, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public TupleArgumentsGreen Update(ArgumentExpressionGreen argumentExpression, InternalSyntaxToken tComma, ArgumentListGreen argumentList)
	    {
	        if (this.ArgumentExpression != argumentExpression ||
				this.TComma != tComma ||
				this.ArgumentList != argumentList)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.TupleArguments(argumentExpression, tComma, argumentList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TupleArgumentsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArgumentListGreen : GreenSyntaxNode
	{
	    internal static readonly ArgumentListGreen __Missing = new ArgumentListGreen();
	    private GreenNode argumentExpression;
	
	    public ArgumentListGreen(CoreSyntaxKind kind, GreenNode argumentExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (argumentExpression != null)
			{
				this.AdjustFlagsAndWidth(argumentExpression);
				this.argumentExpression = argumentExpression;
			}
	    }
	
	    public ArgumentListGreen(CoreSyntaxKind kind, GreenNode argumentExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (argumentExpression != null)
			{
				this.AdjustFlagsAndWidth(argumentExpression);
				this.argumentExpression = argumentExpression;
			}
	    }
	
		private ArgumentListGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ArgumentList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ArgumentExpressionGreen> ArgumentExpression { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ArgumentExpressionGreen>(this.argumentExpression); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ArgumentListSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.argumentExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitArgumentListGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitArgumentListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArgumentListGreen(this.Kind, this.argumentExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArgumentListGreen(this.Kind, this.argumentExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ArgumentListGreen(this.Kind, this.argumentExpression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ArgumentListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ArgumentExpressionGreen> argumentExpression)
	    {
	        if (this.ArgumentExpression != argumentExpression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ArgumentList(argumentExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgumentListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArgumentExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly ArgumentExpressionGreen __Missing = new ArgumentExpressionGreen();
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ExpressionGreen expression;
	
	    public ArgumentExpressionGreen(CoreSyntaxKind kind, NameGreen name, InternalSyntaxToken tColon, ExpressionGreen expression)
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
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public ArgumentExpressionGreen(CoreSyntaxKind kind, NameGreen name, InternalSyntaxToken tColon, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private ArgumentExpressionGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ArgumentExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ArgumentExpressionSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.tColon;
	            case 2: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitArgumentExpressionGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitArgumentExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArgumentExpressionGreen(this.Kind, this.name, this.tColon, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArgumentExpressionGreen(this.Kind, this.name, this.tColon, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ArgumentExpressionGreen(this.Kind, this.name, this.tColon, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ArgumentExpressionGreen Update(NameGreen name, InternalSyntaxToken tColon, ExpressionGreen expression)
	    {
	        if (this.Name != name ||
				this.TColon != tColon ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ArgumentExpression(name, tColon, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgumentExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InitializerExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly InitializerExpressionGreen __Missing = new InitializerExpressionGreen();
	    private FieldInitializerExpressionsGreen fieldInitializerExpressions;
	    private CollectionInitializerExpressionsGreen collectionInitializerExpressions;
	    private DictionaryInitializerExpressionsGreen dictionaryInitializerExpressions;
	
	    public InitializerExpressionGreen(CoreSyntaxKind kind, FieldInitializerExpressionsGreen fieldInitializerExpressions, CollectionInitializerExpressionsGreen collectionInitializerExpressions, DictionaryInitializerExpressionsGreen dictionaryInitializerExpressions)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (fieldInitializerExpressions != null)
			{
				this.AdjustFlagsAndWidth(fieldInitializerExpressions);
				this.fieldInitializerExpressions = fieldInitializerExpressions;
			}
			if (collectionInitializerExpressions != null)
			{
				this.AdjustFlagsAndWidth(collectionInitializerExpressions);
				this.collectionInitializerExpressions = collectionInitializerExpressions;
			}
			if (dictionaryInitializerExpressions != null)
			{
				this.AdjustFlagsAndWidth(dictionaryInitializerExpressions);
				this.dictionaryInitializerExpressions = dictionaryInitializerExpressions;
			}
	    }
	
	    public InitializerExpressionGreen(CoreSyntaxKind kind, FieldInitializerExpressionsGreen fieldInitializerExpressions, CollectionInitializerExpressionsGreen collectionInitializerExpressions, DictionaryInitializerExpressionsGreen dictionaryInitializerExpressions, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (fieldInitializerExpressions != null)
			{
				this.AdjustFlagsAndWidth(fieldInitializerExpressions);
				this.fieldInitializerExpressions = fieldInitializerExpressions;
			}
			if (collectionInitializerExpressions != null)
			{
				this.AdjustFlagsAndWidth(collectionInitializerExpressions);
				this.collectionInitializerExpressions = collectionInitializerExpressions;
			}
			if (dictionaryInitializerExpressions != null)
			{
				this.AdjustFlagsAndWidth(dictionaryInitializerExpressions);
				this.dictionaryInitializerExpressions = dictionaryInitializerExpressions;
			}
	    }
	
		private InitializerExpressionGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.InitializerExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FieldInitializerExpressionsGreen FieldInitializerExpressions { get { return this.fieldInitializerExpressions; } }
	    public CollectionInitializerExpressionsGreen CollectionInitializerExpressions { get { return this.collectionInitializerExpressions; } }
	    public DictionaryInitializerExpressionsGreen DictionaryInitializerExpressions { get { return this.dictionaryInitializerExpressions; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.InitializerExpressionSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldInitializerExpressions;
	            case 1: return this.collectionInitializerExpressions;
	            case 2: return this.dictionaryInitializerExpressions;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitInitializerExpressionGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitInitializerExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InitializerExpressionGreen(this.Kind, this.fieldInitializerExpressions, this.collectionInitializerExpressions, this.dictionaryInitializerExpressions, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InitializerExpressionGreen(this.Kind, this.fieldInitializerExpressions, this.collectionInitializerExpressions, this.dictionaryInitializerExpressions, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new InitializerExpressionGreen(this.Kind, this.fieldInitializerExpressions, this.collectionInitializerExpressions, this.dictionaryInitializerExpressions, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public InitializerExpressionGreen Update(FieldInitializerExpressionsGreen fieldInitializerExpressions)
	    {
	        if (this.fieldInitializerExpressions != fieldInitializerExpressions)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.InitializerExpression(fieldInitializerExpressions);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InitializerExpressionGreen)newNode;
	        }
	        return this;
	    }
	
	    public InitializerExpressionGreen Update(CollectionInitializerExpressionsGreen collectionInitializerExpressions)
	    {
	        if (this.collectionInitializerExpressions != collectionInitializerExpressions)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.InitializerExpression(collectionInitializerExpressions);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InitializerExpressionGreen)newNode;
	        }
	        return this;
	    }
	
	    public InitializerExpressionGreen Update(DictionaryInitializerExpressionsGreen dictionaryInitializerExpressions)
	    {
	        if (this.dictionaryInitializerExpressions != dictionaryInitializerExpressions)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.InitializerExpression(dictionaryInitializerExpressions);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InitializerExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FieldInitializerExpressionsGreen : GreenSyntaxNode
	{
	    internal static readonly FieldInitializerExpressionsGreen __Missing = new FieldInitializerExpressionsGreen();
	    private GreenNode fieldInitializerExpression;
	
	    public FieldInitializerExpressionsGreen(CoreSyntaxKind kind, GreenNode fieldInitializerExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (fieldInitializerExpression != null)
			{
				this.AdjustFlagsAndWidth(fieldInitializerExpression);
				this.fieldInitializerExpression = fieldInitializerExpression;
			}
	    }
	
	    public FieldInitializerExpressionsGreen(CoreSyntaxKind kind, GreenNode fieldInitializerExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (fieldInitializerExpression != null)
			{
				this.AdjustFlagsAndWidth(fieldInitializerExpression);
				this.fieldInitializerExpression = fieldInitializerExpression;
			}
	    }
	
		private FieldInitializerExpressionsGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.FieldInitializerExpressions, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<FieldInitializerExpressionGreen> FieldInitializerExpression { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<FieldInitializerExpressionGreen>(this.fieldInitializerExpression); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.FieldInitializerExpressionsSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldInitializerExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitFieldInitializerExpressionsGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitFieldInitializerExpressionsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldInitializerExpressionsGreen(this.Kind, this.fieldInitializerExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldInitializerExpressionsGreen(this.Kind, this.fieldInitializerExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new FieldInitializerExpressionsGreen(this.Kind, this.fieldInitializerExpression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public FieldInitializerExpressionsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<FieldInitializerExpressionGreen> fieldInitializerExpression)
	    {
	        if (this.FieldInitializerExpression != fieldInitializerExpression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.FieldInitializerExpressions(fieldInitializerExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldInitializerExpressionsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FieldInitializerExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly FieldInitializerExpressionGreen __Missing = new FieldInitializerExpressionGreen();
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	
	    public FieldInitializerExpressionGreen(CoreSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
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
	
	    public FieldInitializerExpressionGreen(CoreSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
		private FieldInitializerExpressionGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.FieldInitializerExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.FieldInitializerExpressionSyntax(this, (CoreSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitFieldInitializerExpressionGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitFieldInitializerExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldInitializerExpressionGreen(this.Kind, this.identifier, this.tAssign, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldInitializerExpressionGreen(this.Kind, this.identifier, this.tAssign, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new FieldInitializerExpressionGreen(this.Kind, this.identifier, this.tAssign, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public FieldInitializerExpressionGreen Update(IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	        if (this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.FieldInitializerExpression(identifier, tAssign, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldInitializerExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CollectionInitializerExpressionsGreen : GreenSyntaxNode
	{
	    internal static readonly CollectionInitializerExpressionsGreen __Missing = new CollectionInitializerExpressionsGreen();
	    private GreenNode expression;
	
	    public CollectionInitializerExpressionsGreen(CoreSyntaxKind kind, GreenNode expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public CollectionInitializerExpressionsGreen(CoreSyntaxKind kind, GreenNode expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		private CollectionInitializerExpressionsGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.CollectionInitializerExpressions, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> Expression { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen>(this.expression); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.CollectionInitializerExpressionsSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitCollectionInitializerExpressionsGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitCollectionInitializerExpressionsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CollectionInitializerExpressionsGreen(this.Kind, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CollectionInitializerExpressionsGreen(this.Kind, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CollectionInitializerExpressionsGreen(this.Kind, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CollectionInitializerExpressionsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> expression)
	    {
	        if (this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.CollectionInitializerExpressions(expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionInitializerExpressionsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DictionaryInitializerExpressionsGreen : GreenSyntaxNode
	{
	    internal static readonly DictionaryInitializerExpressionsGreen __Missing = new DictionaryInitializerExpressionsGreen();
	    private GreenNode dictionaryInitializerExpression;
	
	    public DictionaryInitializerExpressionsGreen(CoreSyntaxKind kind, GreenNode dictionaryInitializerExpression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (dictionaryInitializerExpression != null)
			{
				this.AdjustFlagsAndWidth(dictionaryInitializerExpression);
				this.dictionaryInitializerExpression = dictionaryInitializerExpression;
			}
	    }
	
	    public DictionaryInitializerExpressionsGreen(CoreSyntaxKind kind, GreenNode dictionaryInitializerExpression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (dictionaryInitializerExpression != null)
			{
				this.AdjustFlagsAndWidth(dictionaryInitializerExpression);
				this.dictionaryInitializerExpression = dictionaryInitializerExpression;
			}
	    }
	
		private DictionaryInitializerExpressionsGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.DictionaryInitializerExpressions, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<DictionaryInitializerExpressionGreen> DictionaryInitializerExpression { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<DictionaryInitializerExpressionGreen>(this.dictionaryInitializerExpression); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.DictionaryInitializerExpressionsSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.dictionaryInitializerExpression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitDictionaryInitializerExpressionsGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitDictionaryInitializerExpressionsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DictionaryInitializerExpressionsGreen(this.Kind, this.dictionaryInitializerExpression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DictionaryInitializerExpressionsGreen(this.Kind, this.dictionaryInitializerExpression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new DictionaryInitializerExpressionsGreen(this.Kind, this.dictionaryInitializerExpression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public DictionaryInitializerExpressionsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<DictionaryInitializerExpressionGreen> dictionaryInitializerExpression)
	    {
	        if (this.DictionaryInitializerExpression != dictionaryInitializerExpression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.DictionaryInitializerExpressions(dictionaryInitializerExpression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DictionaryInitializerExpressionsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DictionaryInitializerExpressionGreen : GreenSyntaxNode
	{
	    internal static readonly DictionaryInitializerExpressionGreen __Missing = new DictionaryInitializerExpressionGreen();
	    private InternalSyntaxToken tOpenBracket;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tCloseBracket;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	
	    public DictionaryInitializerExpressionGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenBracket, IdentifierGreen identifier, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tAssign, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
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
	
	    public DictionaryInitializerExpressionGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenBracket, IdentifierGreen identifier, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tAssign, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
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
	
		private DictionaryInitializerExpressionGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.DictionaryInitializerExpression, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.DictionaryInitializerExpressionSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.identifier;
	            case 2: return this.tCloseBracket;
	            case 3: return this.tAssign;
	            case 4: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitDictionaryInitializerExpressionGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitDictionaryInitializerExpressionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DictionaryInitializerExpressionGreen(this.Kind, this.tOpenBracket, this.identifier, this.tCloseBracket, this.tAssign, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DictionaryInitializerExpressionGreen(this.Kind, this.tOpenBracket, this.identifier, this.tCloseBracket, this.tAssign, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new DictionaryInitializerExpressionGreen(this.Kind, this.tOpenBracket, this.identifier, this.tCloseBracket, this.tAssign, this.expression, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public DictionaryInitializerExpressionGreen Update(InternalSyntaxToken tOpenBracket, IdentifierGreen identifier, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.Identifier != identifier ||
				this.TCloseBracket != tCloseBracket ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.DictionaryInitializerExpression(tOpenBracket, identifier, tCloseBracket, tAssign, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DictionaryInitializerExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LambdaSignatureGreen : GreenSyntaxNode
	{
	    internal static readonly LambdaSignatureGreen __Missing = new LambdaSignatureGreen();
	    private ImplicitLambdaSignatureGreen implicitLambdaSignature;
	    private ExplicitLambdaSignatureGreen explicitLambdaSignature;
	
	    public LambdaSignatureGreen(CoreSyntaxKind kind, ImplicitLambdaSignatureGreen implicitLambdaSignature, ExplicitLambdaSignatureGreen explicitLambdaSignature)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (implicitLambdaSignature != null)
			{
				this.AdjustFlagsAndWidth(implicitLambdaSignature);
				this.implicitLambdaSignature = implicitLambdaSignature;
			}
			if (explicitLambdaSignature != null)
			{
				this.AdjustFlagsAndWidth(explicitLambdaSignature);
				this.explicitLambdaSignature = explicitLambdaSignature;
			}
	    }
	
	    public LambdaSignatureGreen(CoreSyntaxKind kind, ImplicitLambdaSignatureGreen implicitLambdaSignature, ExplicitLambdaSignatureGreen explicitLambdaSignature, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (implicitLambdaSignature != null)
			{
				this.AdjustFlagsAndWidth(implicitLambdaSignature);
				this.implicitLambdaSignature = implicitLambdaSignature;
			}
			if (explicitLambdaSignature != null)
			{
				this.AdjustFlagsAndWidth(explicitLambdaSignature);
				this.explicitLambdaSignature = explicitLambdaSignature;
			}
	    }
	
		private LambdaSignatureGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.LambdaSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ImplicitLambdaSignatureGreen ImplicitLambdaSignature { get { return this.implicitLambdaSignature; } }
	    public ExplicitLambdaSignatureGreen ExplicitLambdaSignature { get { return this.explicitLambdaSignature; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.LambdaSignatureSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.implicitLambdaSignature;
	            case 1: return this.explicitLambdaSignature;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitLambdaSignatureGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitLambdaSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LambdaSignatureGreen(this.Kind, this.implicitLambdaSignature, this.explicitLambdaSignature, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LambdaSignatureGreen(this.Kind, this.implicitLambdaSignature, this.explicitLambdaSignature, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LambdaSignatureGreen(this.Kind, this.implicitLambdaSignature, this.explicitLambdaSignature, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LambdaSignatureGreen Update(ImplicitLambdaSignatureGreen implicitLambdaSignature)
	    {
	        if (this.implicitLambdaSignature != implicitLambdaSignature)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LambdaSignature(implicitLambdaSignature);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaSignatureGreen)newNode;
	        }
	        return this;
	    }
	
	    public LambdaSignatureGreen Update(ExplicitLambdaSignatureGreen explicitLambdaSignature)
	    {
	        if (this.explicitLambdaSignature != explicitLambdaSignature)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LambdaSignature(explicitLambdaSignature);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ImplicitLambdaSignatureGreen : GreenSyntaxNode
	{
	    internal static readonly ImplicitLambdaSignatureGreen __Missing = new ImplicitLambdaSignatureGreen();
	    private ImplicitParameterGreen implicitParameter;
	    private ImplicitParameterListGreen implicitParameterList;
	
	    public ImplicitLambdaSignatureGreen(CoreSyntaxKind kind, ImplicitParameterGreen implicitParameter, ImplicitParameterListGreen implicitParameterList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
			if (implicitParameterList != null)
			{
				this.AdjustFlagsAndWidth(implicitParameterList);
				this.implicitParameterList = implicitParameterList;
			}
	    }
	
	    public ImplicitLambdaSignatureGreen(CoreSyntaxKind kind, ImplicitParameterGreen implicitParameter, ImplicitParameterListGreen implicitParameterList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
			if (implicitParameterList != null)
			{
				this.AdjustFlagsAndWidth(implicitParameterList);
				this.implicitParameterList = implicitParameterList;
			}
	    }
	
		private ImplicitLambdaSignatureGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ImplicitLambdaSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ImplicitParameterGreen ImplicitParameter { get { return this.implicitParameter; } }
	    public ImplicitParameterListGreen ImplicitParameterList { get { return this.implicitParameterList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ImplicitLambdaSignatureSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.implicitParameter;
	            case 1: return this.implicitParameterList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitImplicitLambdaSignatureGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitImplicitLambdaSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ImplicitLambdaSignatureGreen(this.Kind, this.implicitParameter, this.implicitParameterList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ImplicitLambdaSignatureGreen(this.Kind, this.implicitParameter, this.implicitParameterList, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ImplicitLambdaSignatureGreen(this.Kind, this.implicitParameter, this.implicitParameterList, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ImplicitLambdaSignatureGreen Update(ImplicitParameterGreen implicitParameter)
	    {
	        if (this.implicitParameter != implicitParameter)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ImplicitLambdaSignature(implicitParameter);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitLambdaSignatureGreen)newNode;
	        }
	        return this;
	    }
	
	    public ImplicitLambdaSignatureGreen Update(ImplicitParameterListGreen implicitParameterList)
	    {
	        if (this.implicitParameterList != implicitParameterList)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ImplicitLambdaSignature(implicitParameterList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitLambdaSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ImplicitParameterListGreen : GreenSyntaxNode
	{
	    internal static readonly ImplicitParameterListGreen __Missing = new ImplicitParameterListGreen();
	    private InternalSyntaxToken tOpenParen;
	    private GreenNode implicitParameter;
	    private InternalSyntaxToken tCloseParen;
	
	    public ImplicitParameterListGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, GreenNode implicitParameter, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ImplicitParameterListGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, GreenNode implicitParameter, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (implicitParameter != null)
			{
				this.AdjustFlagsAndWidth(implicitParameter);
				this.implicitParameter = implicitParameter;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ImplicitParameterListGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ImplicitParameterList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen> ImplicitParameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen>(this.implicitParameter); } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ImplicitParameterListSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.implicitParameter;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitImplicitParameterListGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitImplicitParameterListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ImplicitParameterListGreen(this.Kind, this.tOpenParen, this.implicitParameter, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ImplicitParameterListGreen(this.Kind, this.tOpenParen, this.implicitParameter, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ImplicitParameterListGreen(this.Kind, this.tOpenParen, this.implicitParameter, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ImplicitParameterListGreen Update(InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen> implicitParameter, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ImplicitParameter != implicitParameter ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ImplicitParameterList(tOpenParen, implicitParameter, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitParameterListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ImplicitParameterGreen : GreenSyntaxNode
	{
	    internal static readonly ImplicitParameterGreen __Missing = new ImplicitParameterGreen();
	    private NameGreen name;
	
	    public ImplicitParameterGreen(CoreSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public ImplicitParameterGreen(CoreSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private ImplicitParameterGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ImplicitParameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ImplicitParameterSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitImplicitParameterGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitImplicitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ImplicitParameterGreen(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ImplicitParameterGreen(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ImplicitParameterGreen(this.Kind, this.name, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ImplicitParameterGreen Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ImplicitParameter(name);
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
	
	internal class ExplicitLambdaSignatureGreen : GreenSyntaxNode
	{
	    internal static readonly ExplicitLambdaSignatureGreen __Missing = new ExplicitLambdaSignatureGreen();
	    private ExplicitParameterListGreen explicitParameterList;
	
	    public ExplicitLambdaSignatureGreen(CoreSyntaxKind kind, ExplicitParameterListGreen explicitParameterList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (explicitParameterList != null)
			{
				this.AdjustFlagsAndWidth(explicitParameterList);
				this.explicitParameterList = explicitParameterList;
			}
	    }
	
	    public ExplicitLambdaSignatureGreen(CoreSyntaxKind kind, ExplicitParameterListGreen explicitParameterList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (explicitParameterList != null)
			{
				this.AdjustFlagsAndWidth(explicitParameterList);
				this.explicitParameterList = explicitParameterList;
			}
	    }
	
		private ExplicitLambdaSignatureGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ExplicitLambdaSignature, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExplicitParameterListGreen ExplicitParameterList { get { return this.explicitParameterList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ExplicitLambdaSignatureSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.explicitParameterList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitExplicitLambdaSignatureGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitExplicitLambdaSignatureGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExplicitLambdaSignatureGreen(this.Kind, this.explicitParameterList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExplicitLambdaSignatureGreen(this.Kind, this.explicitParameterList, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ExplicitLambdaSignatureGreen(this.Kind, this.explicitParameterList, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ExplicitLambdaSignatureGreen Update(ExplicitParameterListGreen explicitParameterList)
	    {
	        if (this.ExplicitParameterList != explicitParameterList)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ExplicitLambdaSignature(explicitParameterList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExplicitLambdaSignatureGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExplicitParameterListGreen : GreenSyntaxNode
	{
	    internal static readonly ExplicitParameterListGreen __Missing = new ExplicitParameterListGreen();
	    private InternalSyntaxToken tOpenParen;
	    private GreenNode explicitParameter;
	    private InternalSyntaxToken tCloseParen;
	
	    public ExplicitParameterListGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, GreenNode explicitParameter, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (explicitParameter != null)
			{
				this.AdjustFlagsAndWidth(explicitParameter);
				this.explicitParameter = explicitParameter;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public ExplicitParameterListGreen(CoreSyntaxKind kind, InternalSyntaxToken tOpenParen, GreenNode explicitParameter, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (explicitParameter != null)
			{
				this.AdjustFlagsAndWidth(explicitParameter);
				this.explicitParameter = explicitParameter;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private ExplicitParameterListGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ExplicitParameterList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen> ExplicitParameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen>(this.explicitParameter); } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ExplicitParameterListSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.explicitParameter;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitExplicitParameterListGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitExplicitParameterListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExplicitParameterListGreen(this.Kind, this.tOpenParen, this.explicitParameter, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExplicitParameterListGreen(this.Kind, this.tOpenParen, this.explicitParameter, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ExplicitParameterListGreen(this.Kind, this.tOpenParen, this.explicitParameter, this.tCloseParen, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ExplicitParameterListGreen Update(InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen> explicitParameter, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ExplicitParameter != explicitParameter ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ExplicitParameterList(tOpenParen, explicitParameter, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExplicitParameterListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ExplicitParameterGreen : GreenSyntaxNode
	{
	    internal static readonly ExplicitParameterGreen __Missing = new ExplicitParameterGreen();
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	
	    public ExplicitParameterGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
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
	
	    public ExplicitParameterGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
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
	
		private ExplicitParameterGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ExplicitParameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ExplicitParameterSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitExplicitParameterGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitExplicitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ExplicitParameterGreen(this.Kind, this.typeReference, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ExplicitParameterGreen(this.Kind, this.typeReference, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ExplicitParameterGreen(this.Kind, this.typeReference, this.name, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ExplicitParameterGreen Update(TypeReferenceGreen typeReference, NameGreen name)
	    {
	        if (this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ExplicitParameter(typeReference, name);
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
	
	internal class LambdaBodyGreen : GreenSyntaxNode
	{
	    internal static readonly LambdaBodyGreen __Missing = new LambdaBodyGreen();
	    private ExpressionGreen expression;
	    private BlockStatementGreen blockStatement;
	
	    public LambdaBodyGreen(CoreSyntaxKind kind, ExpressionGreen expression, BlockStatementGreen blockStatement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (blockStatement != null)
			{
				this.AdjustFlagsAndWidth(blockStatement);
				this.blockStatement = blockStatement;
			}
	    }
	
	    public LambdaBodyGreen(CoreSyntaxKind kind, ExpressionGreen expression, BlockStatementGreen blockStatement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
			if (blockStatement != null)
			{
				this.AdjustFlagsAndWidth(blockStatement);
				this.blockStatement = blockStatement;
			}
	    }
	
		private LambdaBodyGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.LambdaBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public BlockStatementGreen BlockStatement { get { return this.blockStatement; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.LambdaBodySyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.expression;
	            case 1: return this.blockStatement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitLambdaBodyGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitLambdaBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LambdaBodyGreen(this.Kind, this.expression, this.blockStatement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LambdaBodyGreen(this.Kind, this.expression, this.blockStatement, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LambdaBodyGreen(this.Kind, this.expression, this.blockStatement, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LambdaBodyGreen Update(ExpressionGreen expression)
	    {
	        if (this.expression != expression)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LambdaBody(expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaBodyGreen)newNode;
	        }
	        return this;
	    }
	
	    public LambdaBodyGreen Update(BlockStatementGreen blockStatement)
	    {
	        if (this.blockStatement != blockStatement)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LambdaBody(blockStatement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DotOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly DotOperatorGreen __Missing = new DotOperatorGreen();
	    private InternalSyntaxToken dotOperator;
	
	    public DotOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken dotOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (dotOperator != null)
			{
				this.AdjustFlagsAndWidth(dotOperator);
				this.dotOperator = dotOperator;
			}
	    }
	
	    public DotOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken dotOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (dotOperator != null)
			{
				this.AdjustFlagsAndWidth(dotOperator);
				this.dotOperator = dotOperator;
			}
	    }
	
		private DotOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.DotOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken DotOperator { get { return this.dotOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.DotOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.dotOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitDotOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitDotOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DotOperatorGreen(this.Kind, this.dotOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DotOperatorGreen(this.Kind, this.dotOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new DotOperatorGreen(this.Kind, this.dotOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public DotOperatorGreen Update(InternalSyntaxToken dotOperator)
	    {
	        if (this.DotOperator != dotOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.DotOperator(dotOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DotOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IndexerOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly IndexerOperatorGreen __Missing = new IndexerOperatorGreen();
	    private InternalSyntaxToken indexerOperator;
	
	    public IndexerOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken indexerOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (indexerOperator != null)
			{
				this.AdjustFlagsAndWidth(indexerOperator);
				this.indexerOperator = indexerOperator;
			}
	    }
	
	    public IndexerOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken indexerOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (indexerOperator != null)
			{
				this.AdjustFlagsAndWidth(indexerOperator);
				this.indexerOperator = indexerOperator;
			}
	    }
	
		private IndexerOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.IndexerOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IndexerOperator { get { return this.indexerOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.IndexerOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.indexerOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitIndexerOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitIndexerOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IndexerOperatorGreen(this.Kind, this.indexerOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IndexerOperatorGreen(this.Kind, this.indexerOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new IndexerOperatorGreen(this.Kind, this.indexerOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public IndexerOperatorGreen Update(InternalSyntaxToken indexerOperator)
	    {
	        if (this.IndexerOperator != indexerOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.IndexerOperator(indexerOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IndexerOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PostfixOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly PostfixOperatorGreen __Missing = new PostfixOperatorGreen();
	    private InternalSyntaxToken postfixOperator;
	
	    public PostfixOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken postfixOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (postfixOperator != null)
			{
				this.AdjustFlagsAndWidth(postfixOperator);
				this.postfixOperator = postfixOperator;
			}
	    }
	
	    public PostfixOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken postfixOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (postfixOperator != null)
			{
				this.AdjustFlagsAndWidth(postfixOperator);
				this.postfixOperator = postfixOperator;
			}
	    }
	
		private PostfixOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.PostfixOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken PostfixOperator { get { return this.postfixOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.PostfixOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.postfixOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitPostfixOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitPostfixOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PostfixOperatorGreen(this.Kind, this.postfixOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PostfixOperatorGreen(this.Kind, this.postfixOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new PostfixOperatorGreen(this.Kind, this.postfixOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public PostfixOperatorGreen Update(InternalSyntaxToken postfixOperator)
	    {
	        if (this.PostfixOperator != postfixOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.PostfixOperator(postfixOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PostfixOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class UnaryOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly UnaryOperatorGreen __Missing = new UnaryOperatorGreen();
	    private InternalSyntaxToken unaryOperator;
	
	    public UnaryOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken unaryOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (unaryOperator != null)
			{
				this.AdjustFlagsAndWidth(unaryOperator);
				this.unaryOperator = unaryOperator;
			}
	    }
	
	    public UnaryOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken unaryOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (unaryOperator != null)
			{
				this.AdjustFlagsAndWidth(unaryOperator);
				this.unaryOperator = unaryOperator;
			}
	    }
	
		private UnaryOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.UnaryOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken UnaryOperator { get { return this.unaryOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.UnaryOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.unaryOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitUnaryOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitUnaryOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new UnaryOperatorGreen(this.Kind, this.unaryOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new UnaryOperatorGreen(this.Kind, this.unaryOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new UnaryOperatorGreen(this.Kind, this.unaryOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public UnaryOperatorGreen Update(InternalSyntaxToken unaryOperator)
	    {
	        if (this.UnaryOperator != unaryOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.UnaryOperator(unaryOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnaryOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MultiplicativeOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly MultiplicativeOperatorGreen __Missing = new MultiplicativeOperatorGreen();
	    private InternalSyntaxToken multiplicativeOperator;
	
	    public MultiplicativeOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken multiplicativeOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (multiplicativeOperator != null)
			{
				this.AdjustFlagsAndWidth(multiplicativeOperator);
				this.multiplicativeOperator = multiplicativeOperator;
			}
	    }
	
	    public MultiplicativeOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken multiplicativeOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (multiplicativeOperator != null)
			{
				this.AdjustFlagsAndWidth(multiplicativeOperator);
				this.multiplicativeOperator = multiplicativeOperator;
			}
	    }
	
		private MultiplicativeOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.MultiplicativeOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken MultiplicativeOperator { get { return this.multiplicativeOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.MultiplicativeOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.multiplicativeOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitMultiplicativeOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitMultiplicativeOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MultiplicativeOperatorGreen(this.Kind, this.multiplicativeOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MultiplicativeOperatorGreen(this.Kind, this.multiplicativeOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new MultiplicativeOperatorGreen(this.Kind, this.multiplicativeOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public MultiplicativeOperatorGreen Update(InternalSyntaxToken multiplicativeOperator)
	    {
	        if (this.MultiplicativeOperator != multiplicativeOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.MultiplicativeOperator(multiplicativeOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiplicativeOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AdditiveOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly AdditiveOperatorGreen __Missing = new AdditiveOperatorGreen();
	    private InternalSyntaxToken additiveOperator;
	
	    public AdditiveOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken additiveOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (additiveOperator != null)
			{
				this.AdjustFlagsAndWidth(additiveOperator);
				this.additiveOperator = additiveOperator;
			}
	    }
	
	    public AdditiveOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken additiveOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (additiveOperator != null)
			{
				this.AdjustFlagsAndWidth(additiveOperator);
				this.additiveOperator = additiveOperator;
			}
	    }
	
		private AdditiveOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.AdditiveOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken AdditiveOperator { get { return this.additiveOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.AdditiveOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.additiveOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitAdditiveOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitAdditiveOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AdditiveOperatorGreen(this.Kind, this.additiveOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AdditiveOperatorGreen(this.Kind, this.additiveOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new AdditiveOperatorGreen(this.Kind, this.additiveOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public AdditiveOperatorGreen Update(InternalSyntaxToken additiveOperator)
	    {
	        if (this.AdditiveOperator != additiveOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.AdditiveOperator(additiveOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AdditiveOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ShiftOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly ShiftOperatorGreen __Missing = new ShiftOperatorGreen();
	    private LeftShiftOperatorGreen leftShiftOperator;
	    private RightShiftOperatorGreen rightShiftOperator;
	
	    public ShiftOperatorGreen(CoreSyntaxKind kind, LeftShiftOperatorGreen leftShiftOperator, RightShiftOperatorGreen rightShiftOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (leftShiftOperator != null)
			{
				this.AdjustFlagsAndWidth(leftShiftOperator);
				this.leftShiftOperator = leftShiftOperator;
			}
			if (rightShiftOperator != null)
			{
				this.AdjustFlagsAndWidth(rightShiftOperator);
				this.rightShiftOperator = rightShiftOperator;
			}
	    }
	
	    public ShiftOperatorGreen(CoreSyntaxKind kind, LeftShiftOperatorGreen leftShiftOperator, RightShiftOperatorGreen rightShiftOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (leftShiftOperator != null)
			{
				this.AdjustFlagsAndWidth(leftShiftOperator);
				this.leftShiftOperator = leftShiftOperator;
			}
			if (rightShiftOperator != null)
			{
				this.AdjustFlagsAndWidth(rightShiftOperator);
				this.rightShiftOperator = rightShiftOperator;
			}
	    }
	
		private ShiftOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ShiftOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LeftShiftOperatorGreen LeftShiftOperator { get { return this.leftShiftOperator; } }
	    public RightShiftOperatorGreen RightShiftOperator { get { return this.rightShiftOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ShiftOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leftShiftOperator;
	            case 1: return this.rightShiftOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitShiftOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitShiftOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ShiftOperatorGreen(this.Kind, this.leftShiftOperator, this.rightShiftOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ShiftOperatorGreen(this.Kind, this.leftShiftOperator, this.rightShiftOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ShiftOperatorGreen(this.Kind, this.leftShiftOperator, this.rightShiftOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ShiftOperatorGreen Update(LeftShiftOperatorGreen leftShiftOperator)
	    {
	        if (this.leftShiftOperator != leftShiftOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ShiftOperator(leftShiftOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ShiftOperatorGreen)newNode;
	        }
	        return this;
	    }
	
	    public ShiftOperatorGreen Update(RightShiftOperatorGreen rightShiftOperator)
	    {
	        if (this.rightShiftOperator != rightShiftOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ShiftOperator(rightShiftOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ShiftOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LeftShiftOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly LeftShiftOperatorGreen __Missing = new LeftShiftOperatorGreen();
	    private InternalSyntaxToken first;
	    private InternalSyntaxToken second;
	
	    public LeftShiftOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken first, InternalSyntaxToken second)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (first != null)
			{
				this.AdjustFlagsAndWidth(first);
				this.first = first;
			}
			if (second != null)
			{
				this.AdjustFlagsAndWidth(second);
				this.second = second;
			}
	    }
	
	    public LeftShiftOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken first, InternalSyntaxToken second, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (first != null)
			{
				this.AdjustFlagsAndWidth(first);
				this.first = first;
			}
			if (second != null)
			{
				this.AdjustFlagsAndWidth(second);
				this.second = second;
			}
	    }
	
		private LeftShiftOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.LeftShiftOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken First { get { return this.first; } }
	    public InternalSyntaxToken Second { get { return this.second; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.LeftShiftOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.first;
	            case 1: return this.second;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitLeftShiftOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitLeftShiftOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LeftShiftOperatorGreen(this.Kind, this.first, this.second, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LeftShiftOperatorGreen(this.Kind, this.first, this.second, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new LeftShiftOperatorGreen(this.Kind, this.first, this.second, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public LeftShiftOperatorGreen Update(InternalSyntaxToken first, InternalSyntaxToken second)
	    {
	        if (this.First != first ||
				this.Second != second)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.LeftShiftOperator(first, second);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LeftShiftOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RightShiftOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly RightShiftOperatorGreen __Missing = new RightShiftOperatorGreen();
	    private InternalSyntaxToken first;
	    private InternalSyntaxToken second;
	
	    public RightShiftOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken first, InternalSyntaxToken second)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (first != null)
			{
				this.AdjustFlagsAndWidth(first);
				this.first = first;
			}
			if (second != null)
			{
				this.AdjustFlagsAndWidth(second);
				this.second = second;
			}
	    }
	
	    public RightShiftOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken first, InternalSyntaxToken second, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (first != null)
			{
				this.AdjustFlagsAndWidth(first);
				this.first = first;
			}
			if (second != null)
			{
				this.AdjustFlagsAndWidth(second);
				this.second = second;
			}
	    }
	
		private RightShiftOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.RightShiftOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken First { get { return this.first; } }
	    public InternalSyntaxToken Second { get { return this.second; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.RightShiftOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.first;
	            case 1: return this.second;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitRightShiftOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitRightShiftOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RightShiftOperatorGreen(this.Kind, this.first, this.second, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RightShiftOperatorGreen(this.Kind, this.first, this.second, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new RightShiftOperatorGreen(this.Kind, this.first, this.second, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public RightShiftOperatorGreen Update(InternalSyntaxToken first, InternalSyntaxToken second)
	    {
	        if (this.First != first ||
				this.Second != second)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.RightShiftOperator(first, second);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RightShiftOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RelationalOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly RelationalOperatorGreen __Missing = new RelationalOperatorGreen();
	    private InternalSyntaxToken relationalOperator;
	
	    public RelationalOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken relationalOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (relationalOperator != null)
			{
				this.AdjustFlagsAndWidth(relationalOperator);
				this.relationalOperator = relationalOperator;
			}
	    }
	
	    public RelationalOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken relationalOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (relationalOperator != null)
			{
				this.AdjustFlagsAndWidth(relationalOperator);
				this.relationalOperator = relationalOperator;
			}
	    }
	
		private RelationalOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.RelationalOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken RelationalOperator { get { return this.relationalOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.RelationalOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.relationalOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitRelationalOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitRelationalOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RelationalOperatorGreen(this.Kind, this.relationalOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RelationalOperatorGreen(this.Kind, this.relationalOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new RelationalOperatorGreen(this.Kind, this.relationalOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public RelationalOperatorGreen Update(InternalSyntaxToken relationalOperator)
	    {
	        if (this.RelationalOperator != relationalOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.RelationalOperator(relationalOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RelationalOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EqualityOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly EqualityOperatorGreen __Missing = new EqualityOperatorGreen();
	    private InternalSyntaxToken equalityOperator;
	
	    public EqualityOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken equalityOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (equalityOperator != null)
			{
				this.AdjustFlagsAndWidth(equalityOperator);
				this.equalityOperator = equalityOperator;
			}
	    }
	
	    public EqualityOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken equalityOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (equalityOperator != null)
			{
				this.AdjustFlagsAndWidth(equalityOperator);
				this.equalityOperator = equalityOperator;
			}
	    }
	
		private EqualityOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.EqualityOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken EqualityOperator { get { return this.equalityOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.EqualityOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.equalityOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitEqualityOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitEqualityOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EqualityOperatorGreen(this.Kind, this.equalityOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EqualityOperatorGreen(this.Kind, this.equalityOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new EqualityOperatorGreen(this.Kind, this.equalityOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public EqualityOperatorGreen Update(InternalSyntaxToken equalityOperator)
	    {
	        if (this.EqualityOperator != equalityOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.EqualityOperator(equalityOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EqualityOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompoundAssignmentOperatorGreen : GreenSyntaxNode
	{
	    internal static readonly CompoundAssignmentOperatorGreen __Missing = new CompoundAssignmentOperatorGreen();
	    private InternalSyntaxToken compoundAssignmentOperator;
	
	    public CompoundAssignmentOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken compoundAssignmentOperator)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (compoundAssignmentOperator != null)
			{
				this.AdjustFlagsAndWidth(compoundAssignmentOperator);
				this.compoundAssignmentOperator = compoundAssignmentOperator;
			}
	    }
	
	    public CompoundAssignmentOperatorGreen(CoreSyntaxKind kind, InternalSyntaxToken compoundAssignmentOperator, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (compoundAssignmentOperator != null)
			{
				this.AdjustFlagsAndWidth(compoundAssignmentOperator);
				this.compoundAssignmentOperator = compoundAssignmentOperator;
			}
	    }
	
		private CompoundAssignmentOperatorGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.CompoundAssignmentOperator, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken CompoundAssignmentOperator { get { return this.compoundAssignmentOperator; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.CompoundAssignmentOperatorSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.compoundAssignmentOperator;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitCompoundAssignmentOperatorGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitCompoundAssignmentOperatorGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompoundAssignmentOperatorGreen(this.Kind, this.compoundAssignmentOperator, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompoundAssignmentOperatorGreen(this.Kind, this.compoundAssignmentOperator, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new CompoundAssignmentOperatorGreen(this.Kind, this.compoundAssignmentOperator, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public CompoundAssignmentOperatorGreen Update(InternalSyntaxToken compoundAssignmentOperator)
	    {
	        if (this.CompoundAssignmentOperator != compoundAssignmentOperator)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.CompoundAssignmentOperator(compoundAssignmentOperator);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompoundAssignmentOperatorGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnTypeGreen __Missing = new ReturnTypeGreen();
	    private TypeReferenceGreen typeReference;
	    private VoidTypeGreen voidType;
	
	    public ReturnTypeGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType)
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
	
	    public ReturnTypeGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.ReturnType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ReturnTypeSyntax(this, (CoreSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ReturnTypeGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.typeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
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
	
	internal abstract class TypeReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly TypeReferenceGreen __Missing = PrimitiveTypeRefGreen.__Missing;
	
	    public TypeReferenceGreen(CoreSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class PrimitiveTypeRefGreen : TypeReferenceGreen
	{
	    internal static new readonly PrimitiveTypeRefGreen __Missing = new PrimitiveTypeRefGreen();
	    private PrimitiveTypeGreen primitiveType;
	
	    public PrimitiveTypeRefGreen(CoreSyntaxKind kind, PrimitiveTypeGreen primitiveType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
	    public PrimitiveTypeRefGreen(CoreSyntaxKind kind, PrimitiveTypeGreen primitiveType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
		private PrimitiveTypeRefGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.PrimitiveTypeRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.PrimitiveTypeRefSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitPrimitiveTypeRefGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitPrimitiveTypeRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PrimitiveTypeRefGreen(this.Kind, this.primitiveType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PrimitiveTypeRefGreen(this.Kind, this.primitiveType, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new PrimitiveTypeRefGreen(this.Kind, this.primitiveType, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public PrimitiveTypeRefGreen Update(PrimitiveTypeGreen primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.PrimitiveTypeRef(primitiveType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GenericTypeRefGreen : TypeReferenceGreen
	{
	    internal static new readonly GenericTypeRefGreen __Missing = new GenericTypeRefGreen();
	    private NamedTypeGreen namedType;
	    private GenericTypeArgumentsGreen genericTypeArguments;
	
	    public GenericTypeRefGreen(CoreSyntaxKind kind, NamedTypeGreen namedType, GenericTypeArgumentsGreen genericTypeArguments)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (namedType != null)
			{
				this.AdjustFlagsAndWidth(namedType);
				this.namedType = namedType;
			}
			if (genericTypeArguments != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArguments);
				this.genericTypeArguments = genericTypeArguments;
			}
	    }
	
	    public GenericTypeRefGreen(CoreSyntaxKind kind, NamedTypeGreen namedType, GenericTypeArgumentsGreen genericTypeArguments, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (namedType != null)
			{
				this.AdjustFlagsAndWidth(namedType);
				this.namedType = namedType;
			}
			if (genericTypeArguments != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArguments);
				this.genericTypeArguments = genericTypeArguments;
			}
	    }
	
		private GenericTypeRefGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.GenericTypeRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NamedTypeGreen NamedType { get { return this.namedType; } }
	    public GenericTypeArgumentsGreen GenericTypeArguments { get { return this.genericTypeArguments; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.GenericTypeRefSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.namedType;
	            case 1: return this.genericTypeArguments;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitGenericTypeRefGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitGenericTypeRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericTypeRefGreen(this.Kind, this.namedType, this.genericTypeArguments, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeRefGreen(this.Kind, this.namedType, this.genericTypeArguments, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new GenericTypeRefGreen(this.Kind, this.namedType, this.genericTypeArguments, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public GenericTypeRefGreen Update(NamedTypeGreen namedType, GenericTypeArgumentsGreen genericTypeArguments)
	    {
	        if (this.NamedType != namedType ||
				this.GenericTypeArguments != genericTypeArguments)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.GenericTypeRef(namedType, genericTypeArguments);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamedTypeRefGreen : TypeReferenceGreen
	{
	    internal static new readonly NamedTypeRefGreen __Missing = new NamedTypeRefGreen();
	    private QualifierGreen qualifier;
	
	    public NamedTypeRefGreen(CoreSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public NamedTypeRefGreen(CoreSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private NamedTypeRefGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.NamedTypeRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NamedTypeRefSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNamedTypeRefGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNamedTypeRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamedTypeRefGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamedTypeRefGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NamedTypeRefGreen(this.Kind, this.qualifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NamedTypeRefGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NamedTypeRef(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamedTypeRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrayTypeRefGreen : TypeReferenceGreen
	{
	    internal static new readonly ArrayTypeRefGreen __Missing = new ArrayTypeRefGreen();
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken tCloseBracket;
	
	    public ArrayTypeRefGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
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
	
	    public ArrayTypeRefGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
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
	
		private ArrayTypeRefGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.ArrayTypeRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ArrayTypeRefSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.tOpenBracket;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitArrayTypeRefGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitArrayTypeRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrayTypeRefGreen(this.Kind, this.typeReference, this.tOpenBracket, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrayTypeRefGreen(this.Kind, this.typeReference, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new ArrayTypeRefGreen(this.Kind, this.typeReference, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public ArrayTypeRefGreen Update(TypeReferenceGreen typeReference, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TypeReference != typeReference ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ArrayTypeRef(typeReference, tOpenBracket, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NullableTypeRefGreen : TypeReferenceGreen
	{
	    internal static new readonly NullableTypeRefGreen __Missing = new NullableTypeRefGreen();
	    private TypeReferenceGreen typeReference;
	    private InternalSyntaxToken tQuestion;
	
	    public NullableTypeRefGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, InternalSyntaxToken tQuestion)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
	    public NullableTypeRefGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, InternalSyntaxToken tQuestion, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
		private NullableTypeRefGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.NullableTypeRef, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NullableTypeRefSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.tQuestion;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNullableTypeRefGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNullableTypeRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableTypeRefGreen(this.Kind, this.typeReference, this.tQuestion, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableTypeRefGreen(this.Kind, this.typeReference, this.tQuestion, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NullableTypeRefGreen(this.Kind, this.typeReference, this.tQuestion, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NullableTypeRefGreen Update(TypeReferenceGreen typeReference, InternalSyntaxToken tQuestion)
	    {
	        if (this.TypeReference != typeReference ||
				this.TQuestion != tQuestion)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NullableTypeRef(typeReference, tQuestion);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeRefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamedTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NamedTypeGreen __Missing = new NamedTypeGreen();
	    private QualifierGreen qualifier;
	
	    public NamedTypeGreen(CoreSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public NamedTypeGreen(CoreSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private NamedTypeGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.NamedType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NamedTypeSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNamedTypeGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNamedTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamedTypeGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamedTypeGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new NamedTypeGreen(this.Kind, this.qualifier, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public NamedTypeGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NamedType(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamedTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GenericTypeArgumentsGreen : GreenSyntaxNode
	{
	    internal static readonly GenericTypeArgumentsGreen __Missing = new GenericTypeArgumentsGreen();
	    private InternalSyntaxToken tLessThan;
	    private GreenNode genericTypeArgument;
	    private InternalSyntaxToken tGreaterThan;
	
	    public GenericTypeArgumentsGreen(CoreSyntaxKind kind, InternalSyntaxToken tLessThan, GreenNode genericTypeArgument, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (genericTypeArgument != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArgument);
				this.genericTypeArgument = genericTypeArgument;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
	    public GenericTypeArgumentsGreen(CoreSyntaxKind kind, InternalSyntaxToken tLessThan, GreenNode genericTypeArgument, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (genericTypeArgument != null)
			{
				this.AdjustFlagsAndWidth(genericTypeArgument);
				this.genericTypeArgument = genericTypeArgument;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
		private GenericTypeArgumentsGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.GenericTypeArguments, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TLessThan { get { return this.tLessThan; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericTypeArgumentGreen> GenericTypeArgument { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericTypeArgumentGreen>(this.genericTypeArgument); } }
	    public InternalSyntaxToken TGreaterThan { get { return this.tGreaterThan; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.GenericTypeArgumentsSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tLessThan;
	            case 1: return this.genericTypeArgument;
	            case 2: return this.tGreaterThan;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitGenericTypeArgumentsGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitGenericTypeArgumentsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericTypeArgumentsGreen(this.Kind, this.tLessThan, this.genericTypeArgument, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeArgumentsGreen(this.Kind, this.tLessThan, this.genericTypeArgument, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new GenericTypeArgumentsGreen(this.Kind, this.tLessThan, this.genericTypeArgument, this.tGreaterThan, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public GenericTypeArgumentsGreen Update(InternalSyntaxToken tLessThan, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericTypeArgumentGreen> genericTypeArgument, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.TLessThan != tLessThan ||
				this.GenericTypeArgument != genericTypeArgument ||
				this.TGreaterThan != tGreaterThan)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.GenericTypeArguments(tLessThan, genericTypeArgument, tGreaterThan);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeArgumentsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class GenericTypeArgumentGreen : GreenSyntaxNode
	{
	    internal static readonly GenericTypeArgumentGreen __Missing = new GenericTypeArgumentGreen();
	    private TypeReferenceGreen typeReference;
	
	    public GenericTypeArgumentGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public GenericTypeArgumentGreen(CoreSyntaxKind kind, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private GenericTypeArgumentGreen()
			: base((CoreSyntaxKind)CoreSyntaxKind.GenericTypeArgument, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.GenericTypeArgumentSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitGenericTypeArgumentGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitGenericTypeArgumentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new GenericTypeArgumentGreen(this.Kind, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new GenericTypeArgumentGreen(this.Kind, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new GenericTypeArgumentGreen(this.Kind, this.typeReference, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public GenericTypeArgumentGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.GenericTypeArgument(typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeArgumentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PrimitiveTypeGreen : GreenSyntaxNode
	{
	    internal static readonly PrimitiveTypeGreen __Missing = new PrimitiveTypeGreen();
	    private InternalSyntaxToken primitiveType;
	
	    public PrimitiveTypeGreen(CoreSyntaxKind kind, InternalSyntaxToken primitiveType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
	    public PrimitiveTypeGreen(CoreSyntaxKind kind, InternalSyntaxToken primitiveType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.PrimitiveType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken PrimitiveType { get { return this.primitiveType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.PrimitiveTypeSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitPrimitiveTypeGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitPrimitiveTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PrimitiveTypeGreen(this.Kind, this.primitiveType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PrimitiveTypeGreen(this.Kind, this.primitiveType, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new PrimitiveTypeGreen(this.Kind, this.primitiveType, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public PrimitiveTypeGreen Update(InternalSyntaxToken primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.PrimitiveType(primitiveType);
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
	
	    public VoidTypeGreen(CoreSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(CoreSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.VoidType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.VoidTypeSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VoidTypeGreen(this.Kind, this.kVoid, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VoidTypeGreen(this.Kind, this.kVoid, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new VoidTypeGreen(this.Kind, this.kVoid, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public VoidTypeGreen Update(InternalSyntaxToken kVoid)
	    {
	        if (this.KVoid != kVoid)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
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
	
	internal class NameGreen : GreenSyntaxNode
	{
	    internal static readonly NameGreen __Missing = new NameGreen();
	    private IdentifierGreen identifier;
	
	    public NameGreen(CoreSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(CoreSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NameSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	    public QualifiedNameGreen(CoreSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(CoreSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.QualifiedNameSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	    public QualifierGreen(CoreSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(CoreSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.QualifierSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	    public IdentifierGreen(CoreSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierGreen(CoreSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.IdentifierSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Identifier(identifier);
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
	
	    public LiteralGreen(CoreSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
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
	
	    public LiteralGreen(CoreSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.Literal, null, null)
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
	        return new global::MetaDslx.Languages.Core.Syntax.LiteralSyntax(this, (CoreSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	    public NullLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.NullLiteralSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	    public BooleanLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.BooleanLiteralSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	    public IntegerLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.IntegerLiteralSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	    public DecimalLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.DecimalLiteralSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	    public ScientificLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.ScientificLiteralSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	
	    public StringLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lRegularString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
	    public StringLiteralGreen(CoreSyntaxKind kind, InternalSyntaxToken lRegularString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((CoreSyntaxKind)CoreSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LRegularString { get { return this.lRegularString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Core.Syntax.StringLiteralSyntax(this, (CoreSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lRegularString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(CoreSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(CoreSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringLiteralGreen(this.Kind, this.lRegularString, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringLiteralGreen(this.Kind, this.lRegularString, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode Clone()
	    {
			return new StringLiteralGreen(this.Kind, this.lRegularString, this.GetDiagnostics(), this.GetAnnotations());
		}
	
	
	    public StringLiteralGreen Update(InternalSyntaxToken lRegularString)
	    {
	        if (this.LRegularString != lRegularString)
	        {
	            InternalSyntaxNode newNode = CoreLanguage.Instance.InternalSyntaxFactory.StringLiteral(lRegularString);
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

	internal class CoreSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitUsingNamespaceGreen(UsingNamespaceGreen node) => this.DefaultVisit(node);
		public virtual void VisitStatementGreen(StatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitBlockStatementGreen(BlockStatementGreen node) => this.DefaultVisit(node);
		public virtual void VisitParenthesizedExprGreen(ParenthesizedExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitTupleExprGreen(TupleExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitDiscardExprGreen(DiscardExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitDefaultExprGreen(DefaultExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitThisExprGreen(ThisExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitBaseExprGreen(BaseExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralExprGreen(LiteralExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierExprGreen(IdentifierExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierExprGreen(QualifierExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitIndexerExprGreen(IndexerExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitInvocationExprGreen(InvocationExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeofExprGreen(TypeofExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameofExprGreen(NameofExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitSizeofExprGreen(SizeofExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitCheckedExprGreen(CheckedExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitUncheckedExprGreen(UncheckedExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitNewExprGreen(NewExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitPostfixUnaryExprGreen(PostfixUnaryExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullForgivingExprGreen(NullForgivingExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitUnaryExprGreen(UnaryExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeCastExprGreen(TypeCastExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitAwaitExprGreen(AwaitExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitMultExprGreen(MultExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitAddExprGreen(AddExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitShiftExprGreen(ShiftExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitRelExprGreen(RelExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeIsExprGreen(TypeIsExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeAsExprGreen(TypeAsExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitEqExprGreen(EqExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitAndExprGreen(AndExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitXorExprGreen(XorExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitOrExprGreen(OrExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitAndAlsoExprGreen(AndAlsoExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitOrElseExprGreen(OrElseExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitThrowExprGreen(ThrowExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitCoalExprGreen(CoalExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitCondExprGreen(CondExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssignExprGreen(AssignExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompAssignExprGreen(CompAssignExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitLambdaExprGreen(LambdaExprGreen node) => this.DefaultVisit(node);
		public virtual void VisitTupleArgumentsGreen(TupleArgumentsGreen node) => this.DefaultVisit(node);
		public virtual void VisitArgumentListGreen(ArgumentListGreen node) => this.DefaultVisit(node);
		public virtual void VisitArgumentExpressionGreen(ArgumentExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitInitializerExpressionGreen(InitializerExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldInitializerExpressionsGreen(FieldInitializerExpressionsGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldInitializerExpressionGreen(FieldInitializerExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitCollectionInitializerExpressionsGreen(CollectionInitializerExpressionsGreen node) => this.DefaultVisit(node);
		public virtual void VisitDictionaryInitializerExpressionsGreen(DictionaryInitializerExpressionsGreen node) => this.DefaultVisit(node);
		public virtual void VisitDictionaryInitializerExpressionGreen(DictionaryInitializerExpressionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLambdaSignatureGreen(LambdaSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitImplicitLambdaSignatureGreen(ImplicitLambdaSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitImplicitParameterListGreen(ImplicitParameterListGreen node) => this.DefaultVisit(node);
		public virtual void VisitImplicitParameterGreen(ImplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitExplicitLambdaSignatureGreen(ExplicitLambdaSignatureGreen node) => this.DefaultVisit(node);
		public virtual void VisitExplicitParameterListGreen(ExplicitParameterListGreen node) => this.DefaultVisit(node);
		public virtual void VisitExplicitParameterGreen(ExplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitLambdaBodyGreen(LambdaBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitDotOperatorGreen(DotOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitIndexerOperatorGreen(IndexerOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitPostfixOperatorGreen(PostfixOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitUnaryOperatorGreen(UnaryOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitMultiplicativeOperatorGreen(MultiplicativeOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitAdditiveOperatorGreen(AdditiveOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitShiftOperatorGreen(ShiftOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitLeftShiftOperatorGreen(LeftShiftOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitRightShiftOperatorGreen(RightShiftOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitRelationalOperatorGreen(RelationalOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitEqualityOperatorGreen(EqualityOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompoundAssignmentOperatorGreen(CompoundAssignmentOperatorGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitPrimitiveTypeRefGreen(PrimitiveTypeRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeRefGreen(GenericTypeRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamedTypeRefGreen(NamedTypeRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrayTypeRefGreen(ArrayTypeRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableTypeRefGreen(NullableTypeRefGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamedTypeGreen(NamedTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeArgumentsGreen(GenericTypeArgumentsGreen node) => this.DefaultVisit(node);
		public virtual void VisitGenericTypeArgumentGreen(GenericTypeArgumentGreen node) => this.DefaultVisit(node);
		public virtual void VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
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
	
	internal class CoreSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitSkippedTokensTrivia(GreenSkippedTokensTriviaSyntax node) => this.DefaultVisit(node);
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUsingNamespaceGreen(UsingNamespaceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStatementGreen(StatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBlockStatementGreen(BlockStatementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParenthesizedExprGreen(ParenthesizedExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTupleExprGreen(TupleExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDiscardExprGreen(DiscardExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDefaultExprGreen(DefaultExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitThisExprGreen(ThisExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBaseExprGreen(BaseExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralExprGreen(LiteralExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierExprGreen(IdentifierExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierExprGreen(QualifierExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIndexerExprGreen(IndexerExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInvocationExprGreen(InvocationExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeofExprGreen(TypeofExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameofExprGreen(NameofExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSizeofExprGreen(SizeofExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCheckedExprGreen(CheckedExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUncheckedExprGreen(UncheckedExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNewExprGreen(NewExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPostfixUnaryExprGreen(PostfixUnaryExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullForgivingExprGreen(NullForgivingExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUnaryExprGreen(UnaryExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeCastExprGreen(TypeCastExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAwaitExprGreen(AwaitExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMultExprGreen(MultExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAddExprGreen(AddExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitShiftExprGreen(ShiftExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRelExprGreen(RelExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeIsExprGreen(TypeIsExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeAsExprGreen(TypeAsExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEqExprGreen(EqExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAndExprGreen(AndExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitXorExprGreen(XorExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOrExprGreen(OrExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAndAlsoExprGreen(AndAlsoExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOrElseExprGreen(OrElseExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitThrowExprGreen(ThrowExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCoalExprGreen(CoalExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCondExprGreen(CondExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssignExprGreen(AssignExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompAssignExprGreen(CompAssignExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLambdaExprGreen(LambdaExprGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTupleArgumentsGreen(TupleArgumentsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArgumentListGreen(ArgumentListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArgumentExpressionGreen(ArgumentExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInitializerExpressionGreen(InitializerExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldInitializerExpressionsGreen(FieldInitializerExpressionsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldInitializerExpressionGreen(FieldInitializerExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCollectionInitializerExpressionsGreen(CollectionInitializerExpressionsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDictionaryInitializerExpressionsGreen(DictionaryInitializerExpressionsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDictionaryInitializerExpressionGreen(DictionaryInitializerExpressionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLambdaSignatureGreen(LambdaSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitImplicitLambdaSignatureGreen(ImplicitLambdaSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitImplicitParameterListGreen(ImplicitParameterListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitImplicitParameterGreen(ImplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExplicitLambdaSignatureGreen(ExplicitLambdaSignatureGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExplicitParameterListGreen(ExplicitParameterListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitExplicitParameterGreen(ExplicitParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLambdaBodyGreen(LambdaBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDotOperatorGreen(DotOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIndexerOperatorGreen(IndexerOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPostfixOperatorGreen(PostfixOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitUnaryOperatorGreen(UnaryOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMultiplicativeOperatorGreen(MultiplicativeOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAdditiveOperatorGreen(AdditiveOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitShiftOperatorGreen(ShiftOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLeftShiftOperatorGreen(LeftShiftOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRightShiftOperatorGreen(RightShiftOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRelationalOperatorGreen(RelationalOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEqualityOperatorGreen(EqualityOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompoundAssignmentOperatorGreen(CompoundAssignmentOperatorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPrimitiveTypeRefGreen(PrimitiveTypeRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeRefGreen(GenericTypeRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamedTypeRefGreen(NamedTypeRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrayTypeRefGreen(ArrayTypeRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableTypeRefGreen(NullableTypeRefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamedTypeGreen(NamedTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeArgumentsGreen(GenericTypeArgumentsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitGenericTypeArgumentGreen(GenericTypeArgumentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
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
	internal class CoreInternalSyntaxFactory : InternalSyntaxFactory, global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.IAntlr4SyntaxFactory
	{
		public CoreInternalSyntaxFactory(CoreSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.Antlr4Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new CoreLexer(input);
	    }
	
	    public global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.Antlr4Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new CoreParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions? options)
		{
			return new CoreSyntaxLexer(text, (CoreParseOptions)(options ?? CoreParseOptions.Default));
		}
	
		public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions? options, LanguageSyntaxNode? oldTree, ParseData? oldParseData, IEnumerable<TextChangeRange>? changes, CancellationToken cancellationToken = default)
		{
			return new CoreSyntaxParser(text, (CoreParseOptions)(options ?? CoreParseOptions.Default), (CoreSyntaxNode?)oldTree, oldParseData, changes, cancellationToken);
		}
	
		private CoreSyntaxKind ToCoreSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<CoreSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToCoreSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToCoreSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToCoreSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
		{
			return new GreenSkippedTokensTriviaSyntax(ToCoreSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToCoreSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToCoreSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			CoreSyntaxKind typedKind = ToCoreSyntaxKind(kind);
	        Debug.Assert(CoreLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = CoreLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			CoreSyntaxKind typedKind = ToCoreSyntaxKind(kind);
	        Debug.Assert(CoreLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = CoreLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			CoreSyntaxKind typedKind = ToCoreSyntaxKind(kind);
	        Debug.Assert(CoreLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = CoreLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToCoreSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToCoreSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToCoreSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken TAsterisk(string text)
	    {
	        return Token(null, CoreSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text)
	    {
	        return Token(null, CoreSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text)
	    {
	        return Token(null, CoreSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, CoreSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, CoreSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, CoreSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text)
	    {
	        return Token(null, CoreSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text)
	    {
	        return Token(null, CoreSyntaxKind.LDateTime, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text)
	    {
	        return Token(null, CoreSyntaxKind.LDate, text, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LDate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text)
	    {
	        return Token(null, CoreSyntaxKind.LTime, text, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text)
	    {
	        return Token(null, CoreSyntaxKind.LRegularString, text, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text)
	    {
	        return Token(null, CoreSyntaxKind.LGuid, text, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, CoreSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, CoreSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, CoreSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, CoreSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, CoreSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text)
	    {
	        return Token(null, CoreSyntaxKind.LComment, text, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text, object value)
	    {
	        return Token(null, CoreSyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<UsingNamespaceGreen> usingNamespace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != CoreSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.Main, usingNamespace.Node, statement.Node, eOF, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(CoreSyntaxKind.Main, usingNamespace.Node, statement.Node, eOF);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public UsingNamespaceGreen UsingNamespace(InternalSyntaxToken kUsing, NameGreen name, InternalSyntaxToken tAssign, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
			if (kUsing.Kind != CoreSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
			if (tAssign != null && tAssign.Kind != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CoreSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new UsingNamespaceGreen(CoreSyntaxKind.UsingNamespace, kUsing, name, tAssign, qualifier, tSemicolon);
	    }
	
		public StatementGreen Statement(ExpressionGreen expression, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != CoreSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.Statement, expression, tSemicolon, out hash);
			if (cached != null) return (StatementGreen)cached;
			var result = new StatementGreen(CoreSyntaxKind.Statement, expression, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BlockStatementGreen BlockStatement(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<StatementGreen> statement, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != CoreSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != CoreSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.BlockStatement, tOpenBrace, statement.Node, tCloseBrace, out hash);
			if (cached != null) return (BlockStatementGreen)cached;
			var result = new BlockStatementGreen(CoreSyntaxKind.BlockStatement, tOpenBrace, statement.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParenthesizedExprGreen ParenthesizedExpr(InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ParenthesizedExpr, tOpenParen, expression, tCloseParen, out hash);
			if (cached != null) return (ParenthesizedExprGreen)cached;
			var result = new ParenthesizedExprGreen(CoreSyntaxKind.ParenthesizedExpr, tOpenParen, expression, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TupleExprGreen TupleExpr(InternalSyntaxToken tOpenParen, TupleArgumentsGreen tupleArguments, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tupleArguments == null) throw new ArgumentNullException(nameof(tupleArguments));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.TupleExpr, tOpenParen, tupleArguments, tCloseParen, out hash);
			if (cached != null) return (TupleExprGreen)cached;
			var result = new TupleExprGreen(CoreSyntaxKind.TupleExpr, tOpenParen, tupleArguments, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DiscardExprGreen DiscardExpr(InternalSyntaxToken kDiscard)
	    {
	#if DEBUG
			if (kDiscard == null) throw new ArgumentNullException(nameof(kDiscard));
			if (kDiscard.Kind != CoreSyntaxKind.KDiscard) throw new ArgumentException(nameof(kDiscard));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.DiscardExpr, kDiscard, out hash);
			if (cached != null) return (DiscardExprGreen)cached;
			var result = new DiscardExprGreen(CoreSyntaxKind.DiscardExpr, kDiscard);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefaultExprGreen DefaultExpr(InternalSyntaxToken kDefault)
	    {
	#if DEBUG
			if (kDefault == null) throw new ArgumentNullException(nameof(kDefault));
			if (kDefault.Kind != CoreSyntaxKind.KDefault) throw new ArgumentException(nameof(kDefault));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.DefaultExpr, kDefault, out hash);
			if (cached != null) return (DefaultExprGreen)cached;
			var result = new DefaultExprGreen(CoreSyntaxKind.DefaultExpr, kDefault);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ThisExprGreen ThisExpr(InternalSyntaxToken kThis)
	    {
	#if DEBUG
			if (kThis == null) throw new ArgumentNullException(nameof(kThis));
			if (kThis.Kind != CoreSyntaxKind.KThis) throw new ArgumentException(nameof(kThis));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ThisExpr, kThis, out hash);
			if (cached != null) return (ThisExprGreen)cached;
			var result = new ThisExprGreen(CoreSyntaxKind.ThisExpr, kThis);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BaseExprGreen BaseExpr(InternalSyntaxToken kBase)
	    {
	#if DEBUG
			if (kBase == null) throw new ArgumentNullException(nameof(kBase));
			if (kBase.Kind != CoreSyntaxKind.KBase) throw new ArgumentException(nameof(kBase));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.BaseExpr, kBase, out hash);
			if (cached != null) return (BaseExprGreen)cached;
			var result = new BaseExprGreen(CoreSyntaxKind.BaseExpr, kBase);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LiteralExprGreen LiteralExpr(LiteralGreen literal)
	    {
	#if DEBUG
			if (literal == null) throw new ArgumentNullException(nameof(literal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LiteralExpr, literal, out hash);
			if (cached != null) return (LiteralExprGreen)cached;
			var result = new LiteralExprGreen(CoreSyntaxKind.LiteralExpr, literal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierExprGreen IdentifierExpr(IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.IdentifierExpr, identifier, genericTypeArguments, out hash);
			if (cached != null) return (IdentifierExprGreen)cached;
			var result = new IdentifierExprGreen(CoreSyntaxKind.IdentifierExpr, identifier, genericTypeArguments);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifierExprGreen QualifierExpr(ExpressionGreen expression, DotOperatorGreen dotOperator, IdentifierGreen identifier, GenericTypeArgumentsGreen genericTypeArguments)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (dotOperator == null) throw new ArgumentNullException(nameof(dotOperator));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
	        return new QualifierExprGreen(CoreSyntaxKind.QualifierExpr, expression, dotOperator, identifier, genericTypeArguments);
	    }
	
		public IndexerExprGreen IndexerExpr(ExpressionGreen expression, IndexerOperatorGreen indexerOperator, ArgumentListGreen argumentList, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (indexerOperator == null) throw new ArgumentNullException(nameof(indexerOperator));
			if (argumentList == null) throw new ArgumentNullException(nameof(argumentList));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != CoreSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
	        return new IndexerExprGreen(CoreSyntaxKind.IndexerExpr, expression, indexerOperator, argumentList, tCloseBracket);
	    }
	
		public InvocationExprGreen InvocationExpr(ExpressionGreen expression, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new InvocationExprGreen(CoreSyntaxKind.InvocationExpr, expression, tOpenParen, argumentList, tCloseParen);
	    }
	
		public TypeofExprGreen TypeofExpr(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
			if (kTypeof.Kind != CoreSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new TypeofExprGreen(CoreSyntaxKind.TypeofExpr, kTypeof, tOpenParen, typeReference, tCloseParen);
	    }
	
		public NameofExprGreen NameofExpr(InternalSyntaxToken kNameof, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (kNameof == null) throw new ArgumentNullException(nameof(kNameof));
			if (kNameof.Kind != CoreSyntaxKind.KNameof) throw new ArgumentException(nameof(kNameof));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new NameofExprGreen(CoreSyntaxKind.NameofExpr, kNameof, tOpenParen, expression, tCloseParen);
	    }
	
		public SizeofExprGreen SizeofExpr(InternalSyntaxToken kSizeof, InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (kSizeof == null) throw new ArgumentNullException(nameof(kSizeof));
			if (kSizeof.Kind != CoreSyntaxKind.KSizeof) throw new ArgumentException(nameof(kSizeof));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new SizeofExprGreen(CoreSyntaxKind.SizeofExpr, kSizeof, tOpenParen, typeReference, tCloseParen);
	    }
	
		public CheckedExprGreen CheckedExpr(InternalSyntaxToken kChecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (kChecked == null) throw new ArgumentNullException(nameof(kChecked));
			if (kChecked.Kind != CoreSyntaxKind.KChecked) throw new ArgumentException(nameof(kChecked));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new CheckedExprGreen(CoreSyntaxKind.CheckedExpr, kChecked, tOpenParen, expression, tCloseParen);
	    }
	
		public UncheckedExprGreen UncheckedExpr(InternalSyntaxToken kUnchecked, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (kUnchecked == null) throw new ArgumentNullException(nameof(kUnchecked));
			if (kUnchecked.Kind != CoreSyntaxKind.KUnchecked) throw new ArgumentException(nameof(kUnchecked));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new UncheckedExprGreen(CoreSyntaxKind.UncheckedExpr, kUnchecked, tOpenParen, expression, tCloseParen);
	    }
	
		public NewExprGreen NewExpr(InternalSyntaxToken kNew, TypeReferenceGreen typeReference, InternalSyntaxToken tOpenParen, ArgumentListGreen argumentList, InternalSyntaxToken tCloseParen, InitializerExpressionGreen initializerExpression)
	    {
	#if DEBUG
			if (kNew == null) throw new ArgumentNullException(nameof(kNew));
			if (kNew.Kind != CoreSyntaxKind.KNew) throw new ArgumentException(nameof(kNew));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new NewExprGreen(CoreSyntaxKind.NewExpr, kNew, typeReference, tOpenParen, argumentList, tCloseParen, initializerExpression);
	    }
	
		public PostfixUnaryExprGreen PostfixUnaryExpr(ExpressionGreen expression, PostfixOperatorGreen postfixOperator)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (postfixOperator == null) throw new ArgumentNullException(nameof(postfixOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.PostfixUnaryExpr, expression, postfixOperator, out hash);
			if (cached != null) return (PostfixUnaryExprGreen)cached;
			var result = new PostfixUnaryExprGreen(CoreSyntaxKind.PostfixUnaryExpr, expression, postfixOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullForgivingExprGreen NullForgivingExpr(ExpressionGreen expression, InternalSyntaxToken tExclamation)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
			if (tExclamation.Kind != CoreSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.NullForgivingExpr, expression, tExclamation, out hash);
			if (cached != null) return (NullForgivingExprGreen)cached;
			var result = new NullForgivingExprGreen(CoreSyntaxKind.NullForgivingExpr, expression, tExclamation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public UnaryExprGreen UnaryExpr(UnaryOperatorGreen unaryOperator, ExpressionGreen expression)
	    {
	#if DEBUG
			if (unaryOperator == null) throw new ArgumentNullException(nameof(unaryOperator));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.UnaryExpr, unaryOperator, expression, out hash);
			if (cached != null) return (UnaryExprGreen)cached;
			var result = new UnaryExprGreen(CoreSyntaxKind.UnaryExpr, unaryOperator, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeCastExprGreen TypeCastExpr(InternalSyntaxToken tOpenParen, TypeReferenceGreen typeReference, InternalSyntaxToken tCloseParen, ExpressionGreen expression)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
	        return new TypeCastExprGreen(CoreSyntaxKind.TypeCastExpr, tOpenParen, typeReference, tCloseParen, expression);
	    }
	
		public AwaitExprGreen AwaitExpr(InternalSyntaxToken kAwait, ExpressionGreen expression)
	    {
	#if DEBUG
			if (kAwait == null) throw new ArgumentNullException(nameof(kAwait));
			if (kAwait.Kind != CoreSyntaxKind.KAwait) throw new ArgumentException(nameof(kAwait));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.AwaitExpr, kAwait, expression, out hash);
			if (cached != null) return (AwaitExprGreen)cached;
			var result = new AwaitExprGreen(CoreSyntaxKind.AwaitExpr, kAwait, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MultExprGreen MultExpr(ExpressionGreen left, MultiplicativeOperatorGreen multiplicativeOperator, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (multiplicativeOperator == null) throw new ArgumentNullException(nameof(multiplicativeOperator));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.MultExpr, left, multiplicativeOperator, right, out hash);
			if (cached != null) return (MultExprGreen)cached;
			var result = new MultExprGreen(CoreSyntaxKind.MultExpr, left, multiplicativeOperator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AddExprGreen AddExpr(ExpressionGreen left, AdditiveOperatorGreen additiveOperator, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (additiveOperator == null) throw new ArgumentNullException(nameof(additiveOperator));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.AddExpr, left, additiveOperator, right, out hash);
			if (cached != null) return (AddExprGreen)cached;
			var result = new AddExprGreen(CoreSyntaxKind.AddExpr, left, additiveOperator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ShiftExprGreen ShiftExpr(ExpressionGreen left, ShiftOperatorGreen shiftOperator, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (shiftOperator == null) throw new ArgumentNullException(nameof(shiftOperator));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ShiftExpr, left, shiftOperator, right, out hash);
			if (cached != null) return (ShiftExprGreen)cached;
			var result = new ShiftExprGreen(CoreSyntaxKind.ShiftExpr, left, shiftOperator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RelExprGreen RelExpr(ExpressionGreen left, RelationalOperatorGreen relationalOperator, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (relationalOperator == null) throw new ArgumentNullException(nameof(relationalOperator));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.RelExpr, left, relationalOperator, right, out hash);
			if (cached != null) return (RelExprGreen)cached;
			var result = new RelExprGreen(CoreSyntaxKind.RelExpr, left, relationalOperator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeIsExprGreen TypeIsExpr(ExpressionGreen expression, InternalSyntaxToken kIs, InternalSyntaxToken kNot, TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (kIs == null) throw new ArgumentNullException(nameof(kIs));
			if (kIs.Kind != CoreSyntaxKind.KIs) throw new ArgumentException(nameof(kIs));
			if (kNot != null && kNot.Kind != CoreSyntaxKind.KNot) throw new ArgumentException(nameof(kNot));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
	        return new TypeIsExprGreen(CoreSyntaxKind.TypeIsExpr, expression, kIs, kNot, typeReference);
	    }
	
		public TypeAsExprGreen TypeAsExpr(ExpressionGreen expression, InternalSyntaxToken kAs, TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (expression == null) throw new ArgumentNullException(nameof(expression));
			if (kAs == null) throw new ArgumentNullException(nameof(kAs));
			if (kAs.Kind != CoreSyntaxKind.KAs) throw new ArgumentException(nameof(kAs));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.TypeAsExpr, expression, kAs, typeReference, out hash);
			if (cached != null) return (TypeAsExprGreen)cached;
			var result = new TypeAsExprGreen(CoreSyntaxKind.TypeAsExpr, expression, kAs, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EqExprGreen EqExpr(ExpressionGreen left, EqualityOperatorGreen equalityOperator, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (equalityOperator == null) throw new ArgumentNullException(nameof(equalityOperator));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.EqExpr, left, equalityOperator, right, out hash);
			if (cached != null) return (EqExprGreen)cached;
			var result = new EqExprGreen(CoreSyntaxKind.EqExpr, left, equalityOperator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AndExprGreen AndExpr(ExpressionGreen left, InternalSyntaxToken tAmpersand, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tAmpersand == null) throw new ArgumentNullException(nameof(tAmpersand));
			if (tAmpersand.Kind != CoreSyntaxKind.TAmpersand) throw new ArgumentException(nameof(tAmpersand));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.AndExpr, left, tAmpersand, right, out hash);
			if (cached != null) return (AndExprGreen)cached;
			var result = new AndExprGreen(CoreSyntaxKind.AndExpr, left, tAmpersand, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XorExprGreen XorExpr(ExpressionGreen left, InternalSyntaxToken tHat, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tHat == null) throw new ArgumentNullException(nameof(tHat));
			if (tHat.Kind != CoreSyntaxKind.THat) throw new ArgumentException(nameof(tHat));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.XorExpr, left, tHat, right, out hash);
			if (cached != null) return (XorExprGreen)cached;
			var result = new XorExprGreen(CoreSyntaxKind.XorExpr, left, tHat, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OrExprGreen OrExpr(ExpressionGreen left, InternalSyntaxToken tBar, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tBar == null) throw new ArgumentNullException(nameof(tBar));
			if (tBar.Kind != CoreSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.OrExpr, left, tBar, right, out hash);
			if (cached != null) return (OrExprGreen)cached;
			var result = new OrExprGreen(CoreSyntaxKind.OrExpr, left, tBar, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AndAlsoExprGreen AndAlsoExpr(ExpressionGreen left, InternalSyntaxToken tAndAlso, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tAndAlso == null) throw new ArgumentNullException(nameof(tAndAlso));
			if (tAndAlso.Kind != CoreSyntaxKind.TAndAlso) throw new ArgumentException(nameof(tAndAlso));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.AndAlsoExpr, left, tAndAlso, right, out hash);
			if (cached != null) return (AndAlsoExprGreen)cached;
			var result = new AndAlsoExprGreen(CoreSyntaxKind.AndAlsoExpr, left, tAndAlso, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OrElseExprGreen OrElseExpr(ExpressionGreen left, InternalSyntaxToken tOrElse, ExpressionGreen right)
	    {
	#if DEBUG
			if (left == null) throw new ArgumentNullException(nameof(left));
			if (tOrElse == null) throw new ArgumentNullException(nameof(tOrElse));
			if (tOrElse.Kind != CoreSyntaxKind.TOrElse) throw new ArgumentException(nameof(tOrElse));
			if (right == null) throw new ArgumentNullException(nameof(right));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.OrElseExpr, left, tOrElse, right, out hash);
			if (cached != null) return (OrElseExprGreen)cached;
			var result = new OrElseExprGreen(CoreSyntaxKind.OrElseExpr, left, tOrElse, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ThrowExprGreen ThrowExpr(InternalSyntaxToken kThrow, ExpressionGreen expression)
	    {
	#if DEBUG
			if (kThrow == null) throw new ArgumentNullException(nameof(kThrow));
			if (kThrow.Kind != CoreSyntaxKind.KThrow) throw new ArgumentException(nameof(kThrow));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ThrowExpr, kThrow, expression, out hash);
			if (cached != null) return (ThrowExprGreen)cached;
			var result = new ThrowExprGreen(CoreSyntaxKind.ThrowExpr, kThrow, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CoalExprGreen CoalExpr(ExpressionGreen value, InternalSyntaxToken tQuestionQuestion, ExpressionGreen whenNull)
	    {
	#if DEBUG
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (tQuestionQuestion == null) throw new ArgumentNullException(nameof(tQuestionQuestion));
			if (tQuestionQuestion.Kind != CoreSyntaxKind.TQuestionQuestion) throw new ArgumentException(nameof(tQuestionQuestion));
			if (whenNull == null) throw new ArgumentNullException(nameof(whenNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.CoalExpr, value, tQuestionQuestion, whenNull, out hash);
			if (cached != null) return (CoalExprGreen)cached;
			var result = new CoalExprGreen(CoreSyntaxKind.CoalExpr, value, tQuestionQuestion, whenNull);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CondExprGreen CondExpr(ExpressionGreen condition, InternalSyntaxToken tQuestion, ExpressionGreen whenTrue, InternalSyntaxToken tColon, ExpressionGreen whenFalse)
	    {
	#if DEBUG
			if (condition == null) throw new ArgumentNullException(nameof(condition));
			if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
			if (tQuestion.Kind != CoreSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
			if (whenTrue == null) throw new ArgumentNullException(nameof(whenTrue));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != CoreSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (whenFalse == null) throw new ArgumentNullException(nameof(whenFalse));
	#endif
	        return new CondExprGreen(CoreSyntaxKind.CondExpr, condition, tQuestion, whenTrue, tColon, whenFalse);
	    }
	
		public AssignExprGreen AssignExpr(ExpressionGreen target, InternalSyntaxToken tAssign, ExpressionGreen value)
	    {
	#if DEBUG
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (value == null) throw new ArgumentNullException(nameof(value));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.AssignExpr, target, tAssign, value, out hash);
			if (cached != null) return (AssignExprGreen)cached;
			var result = new AssignExprGreen(CoreSyntaxKind.AssignExpr, target, tAssign, value);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompAssignExprGreen CompAssignExpr(ExpressionGreen target, CompoundAssignmentOperatorGreen compoundAssignmentOperator, ExpressionGreen value)
	    {
	#if DEBUG
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (compoundAssignmentOperator == null) throw new ArgumentNullException(nameof(compoundAssignmentOperator));
			if (value == null) throw new ArgumentNullException(nameof(value));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.CompAssignExpr, target, compoundAssignmentOperator, value, out hash);
			if (cached != null) return (CompAssignExprGreen)cached;
			var result = new CompAssignExprGreen(CoreSyntaxKind.CompAssignExpr, target, compoundAssignmentOperator, value);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LambdaExprGreen LambdaExpr(LambdaSignatureGreen lambdaSignature, InternalSyntaxToken tArrow, LambdaBodyGreen lambdaBody)
	    {
	#if DEBUG
			if (lambdaSignature == null) throw new ArgumentNullException(nameof(lambdaSignature));
			if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
			if (tArrow.Kind != CoreSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
			if (lambdaBody == null) throw new ArgumentNullException(nameof(lambdaBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LambdaExpr, lambdaSignature, tArrow, lambdaBody, out hash);
			if (cached != null) return (LambdaExprGreen)cached;
			var result = new LambdaExprGreen(CoreSyntaxKind.LambdaExpr, lambdaSignature, tArrow, lambdaBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TupleArgumentsGreen TupleArguments(ArgumentExpressionGreen argumentExpression, InternalSyntaxToken tComma, ArgumentListGreen argumentList)
	    {
	#if DEBUG
			if (argumentExpression == null) throw new ArgumentNullException(nameof(argumentExpression));
			if (tComma == null) throw new ArgumentNullException(nameof(tComma));
			if (tComma.Kind != CoreSyntaxKind.TComma) throw new ArgumentException(nameof(tComma));
			if (argumentList == null) throw new ArgumentNullException(nameof(argumentList));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.TupleArguments, argumentExpression, tComma, argumentList, out hash);
			if (cached != null) return (TupleArgumentsGreen)cached;
			var result = new TupleArgumentsGreen(CoreSyntaxKind.TupleArguments, argumentExpression, tComma, argumentList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArgumentListGreen ArgumentList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ArgumentExpressionGreen> argumentExpression)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ArgumentList, argumentExpression.Node, out hash);
			if (cached != null) return (ArgumentListGreen)cached;
			var result = new ArgumentListGreen(CoreSyntaxKind.ArgumentList, argumentExpression.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArgumentExpressionGreen ArgumentExpression(NameGreen name, InternalSyntaxToken tColon, ExpressionGreen expression)
	    {
	#if DEBUG
			if (tColon != null && tColon.Kind != CoreSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ArgumentExpression, name, tColon, expression, out hash);
			if (cached != null) return (ArgumentExpressionGreen)cached;
			var result = new ArgumentExpressionGreen(CoreSyntaxKind.ArgumentExpression, name, tColon, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InitializerExpressionGreen InitializerExpression(FieldInitializerExpressionsGreen fieldInitializerExpressions)
	    {
	#if DEBUG
		    if (fieldInitializerExpressions == null) throw new ArgumentNullException(nameof(fieldInitializerExpressions));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.InitializerExpression, fieldInitializerExpressions, out hash);
			if (cached != null) return (InitializerExpressionGreen)cached;
			var result = new InitializerExpressionGreen(CoreSyntaxKind.InitializerExpression, fieldInitializerExpressions, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InitializerExpressionGreen InitializerExpression(CollectionInitializerExpressionsGreen collectionInitializerExpressions)
	    {
	#if DEBUG
		    if (collectionInitializerExpressions == null) throw new ArgumentNullException(nameof(collectionInitializerExpressions));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.InitializerExpression, collectionInitializerExpressions, out hash);
			if (cached != null) return (InitializerExpressionGreen)cached;
			var result = new InitializerExpressionGreen(CoreSyntaxKind.InitializerExpression, null, collectionInitializerExpressions, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InitializerExpressionGreen InitializerExpression(DictionaryInitializerExpressionsGreen dictionaryInitializerExpressions)
	    {
	#if DEBUG
		    if (dictionaryInitializerExpressions == null) throw new ArgumentNullException(nameof(dictionaryInitializerExpressions));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.InitializerExpression, dictionaryInitializerExpressions, out hash);
			if (cached != null) return (InitializerExpressionGreen)cached;
			var result = new InitializerExpressionGreen(CoreSyntaxKind.InitializerExpression, null, null, dictionaryInitializerExpressions);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldInitializerExpressionsGreen FieldInitializerExpressions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<FieldInitializerExpressionGreen> fieldInitializerExpression)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.FieldInitializerExpressions, fieldInitializerExpression.Node, out hash);
			if (cached != null) return (FieldInitializerExpressionsGreen)cached;
			var result = new FieldInitializerExpressionsGreen(CoreSyntaxKind.FieldInitializerExpressions, fieldInitializerExpression.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldInitializerExpressionGreen FieldInitializerExpression(IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.FieldInitializerExpression, identifier, tAssign, expression, out hash);
			if (cached != null) return (FieldInitializerExpressionGreen)cached;
			var result = new FieldInitializerExpressionGreen(CoreSyntaxKind.FieldInitializerExpression, identifier, tAssign, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CollectionInitializerExpressionsGreen CollectionInitializerExpressions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExpressionGreen> expression)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.CollectionInitializerExpressions, expression.Node, out hash);
			if (cached != null) return (CollectionInitializerExpressionsGreen)cached;
			var result = new CollectionInitializerExpressionsGreen(CoreSyntaxKind.CollectionInitializerExpressions, expression.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DictionaryInitializerExpressionsGreen DictionaryInitializerExpressions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<DictionaryInitializerExpressionGreen> dictionaryInitializerExpression)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.DictionaryInitializerExpressions, dictionaryInitializerExpression.Node, out hash);
			if (cached != null) return (DictionaryInitializerExpressionsGreen)cached;
			var result = new DictionaryInitializerExpressionsGreen(CoreSyntaxKind.DictionaryInitializerExpressions, dictionaryInitializerExpression.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DictionaryInitializerExpressionGreen DictionaryInitializerExpression(InternalSyntaxToken tOpenBracket, IdentifierGreen identifier, InternalSyntaxToken tCloseBracket, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	#if DEBUG
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != CoreSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != CoreSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
	        return new DictionaryInitializerExpressionGreen(CoreSyntaxKind.DictionaryInitializerExpression, tOpenBracket, identifier, tCloseBracket, tAssign, expression);
	    }
	
		public LambdaSignatureGreen LambdaSignature(ImplicitLambdaSignatureGreen implicitLambdaSignature)
	    {
	#if DEBUG
		    if (implicitLambdaSignature == null) throw new ArgumentNullException(nameof(implicitLambdaSignature));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LambdaSignature, implicitLambdaSignature, out hash);
			if (cached != null) return (LambdaSignatureGreen)cached;
			var result = new LambdaSignatureGreen(CoreSyntaxKind.LambdaSignature, implicitLambdaSignature, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LambdaSignatureGreen LambdaSignature(ExplicitLambdaSignatureGreen explicitLambdaSignature)
	    {
	#if DEBUG
		    if (explicitLambdaSignature == null) throw new ArgumentNullException(nameof(explicitLambdaSignature));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LambdaSignature, explicitLambdaSignature, out hash);
			if (cached != null) return (LambdaSignatureGreen)cached;
			var result = new LambdaSignatureGreen(CoreSyntaxKind.LambdaSignature, null, explicitLambdaSignature);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ImplicitLambdaSignatureGreen ImplicitLambdaSignature(ImplicitParameterGreen implicitParameter)
	    {
	#if DEBUG
		    if (implicitParameter == null) throw new ArgumentNullException(nameof(implicitParameter));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ImplicitLambdaSignature, implicitParameter, out hash);
			if (cached != null) return (ImplicitLambdaSignatureGreen)cached;
			var result = new ImplicitLambdaSignatureGreen(CoreSyntaxKind.ImplicitLambdaSignature, implicitParameter, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ImplicitLambdaSignatureGreen ImplicitLambdaSignature(ImplicitParameterListGreen implicitParameterList)
	    {
	#if DEBUG
		    if (implicitParameterList == null) throw new ArgumentNullException(nameof(implicitParameterList));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ImplicitLambdaSignature, implicitParameterList, out hash);
			if (cached != null) return (ImplicitLambdaSignatureGreen)cached;
			var result = new ImplicitLambdaSignatureGreen(CoreSyntaxKind.ImplicitLambdaSignature, null, implicitParameterList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ImplicitParameterListGreen ImplicitParameterList(InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ImplicitParameterGreen> implicitParameter, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ImplicitParameterList, tOpenParen, implicitParameter.Node, tCloseParen, out hash);
			if (cached != null) return (ImplicitParameterListGreen)cached;
			var result = new ImplicitParameterListGreen(CoreSyntaxKind.ImplicitParameterList, tOpenParen, implicitParameter.Node, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ImplicitParameterGreen ImplicitParameter(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ImplicitParameter, name, out hash);
			if (cached != null) return (ImplicitParameterGreen)cached;
			var result = new ImplicitParameterGreen(CoreSyntaxKind.ImplicitParameter, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExplicitLambdaSignatureGreen ExplicitLambdaSignature(ExplicitParameterListGreen explicitParameterList)
	    {
	#if DEBUG
			if (explicitParameterList == null) throw new ArgumentNullException(nameof(explicitParameterList));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ExplicitLambdaSignature, explicitParameterList, out hash);
			if (cached != null) return (ExplicitLambdaSignatureGreen)cached;
			var result = new ExplicitLambdaSignatureGreen(CoreSyntaxKind.ExplicitLambdaSignature, explicitParameterList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExplicitParameterListGreen ExplicitParameterList(InternalSyntaxToken tOpenParen, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ExplicitParameterGreen> explicitParameter, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ExplicitParameterList, tOpenParen, explicitParameter.Node, tCloseParen, out hash);
			if (cached != null) return (ExplicitParameterListGreen)cached;
			var result = new ExplicitParameterListGreen(CoreSyntaxKind.ExplicitParameterList, tOpenParen, explicitParameter.Node, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ExplicitParameterGreen ExplicitParameter(TypeReferenceGreen typeReference, NameGreen name)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ExplicitParameter, typeReference, name, out hash);
			if (cached != null) return (ExplicitParameterGreen)cached;
			var result = new ExplicitParameterGreen(CoreSyntaxKind.ExplicitParameter, typeReference, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LambdaBodyGreen LambdaBody(ExpressionGreen expression)
	    {
	#if DEBUG
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LambdaBody, expression, out hash);
			if (cached != null) return (LambdaBodyGreen)cached;
			var result = new LambdaBodyGreen(CoreSyntaxKind.LambdaBody, expression, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LambdaBodyGreen LambdaBody(BlockStatementGreen blockStatement)
	    {
	#if DEBUG
		    if (blockStatement == null) throw new ArgumentNullException(nameof(blockStatement));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LambdaBody, blockStatement, out hash);
			if (cached != null) return (LambdaBodyGreen)cached;
			var result = new LambdaBodyGreen(CoreSyntaxKind.LambdaBody, null, blockStatement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DotOperatorGreen DotOperator(InternalSyntaxToken dotOperator)
	    {
	#if DEBUG
			if (dotOperator == null) throw new ArgumentNullException(nameof(dotOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.DotOperator, dotOperator, out hash);
			if (cached != null) return (DotOperatorGreen)cached;
			var result = new DotOperatorGreen(CoreSyntaxKind.DotOperator, dotOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IndexerOperatorGreen IndexerOperator(InternalSyntaxToken indexerOperator)
	    {
	#if DEBUG
			if (indexerOperator == null) throw new ArgumentNullException(nameof(indexerOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.IndexerOperator, indexerOperator, out hash);
			if (cached != null) return (IndexerOperatorGreen)cached;
			var result = new IndexerOperatorGreen(CoreSyntaxKind.IndexerOperator, indexerOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PostfixOperatorGreen PostfixOperator(InternalSyntaxToken postfixOperator)
	    {
	#if DEBUG
			if (postfixOperator == null) throw new ArgumentNullException(nameof(postfixOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.PostfixOperator, postfixOperator, out hash);
			if (cached != null) return (PostfixOperatorGreen)cached;
			var result = new PostfixOperatorGreen(CoreSyntaxKind.PostfixOperator, postfixOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public UnaryOperatorGreen UnaryOperator(InternalSyntaxToken unaryOperator)
	    {
	#if DEBUG
			if (unaryOperator == null) throw new ArgumentNullException(nameof(unaryOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.UnaryOperator, unaryOperator, out hash);
			if (cached != null) return (UnaryOperatorGreen)cached;
			var result = new UnaryOperatorGreen(CoreSyntaxKind.UnaryOperator, unaryOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MultiplicativeOperatorGreen MultiplicativeOperator(InternalSyntaxToken multiplicativeOperator)
	    {
	#if DEBUG
			if (multiplicativeOperator == null) throw new ArgumentNullException(nameof(multiplicativeOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.MultiplicativeOperator, multiplicativeOperator, out hash);
			if (cached != null) return (MultiplicativeOperatorGreen)cached;
			var result = new MultiplicativeOperatorGreen(CoreSyntaxKind.MultiplicativeOperator, multiplicativeOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AdditiveOperatorGreen AdditiveOperator(InternalSyntaxToken additiveOperator)
	    {
	#if DEBUG
			if (additiveOperator == null) throw new ArgumentNullException(nameof(additiveOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.AdditiveOperator, additiveOperator, out hash);
			if (cached != null) return (AdditiveOperatorGreen)cached;
			var result = new AdditiveOperatorGreen(CoreSyntaxKind.AdditiveOperator, additiveOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ShiftOperatorGreen ShiftOperator(LeftShiftOperatorGreen leftShiftOperator)
	    {
	#if DEBUG
		    if (leftShiftOperator == null) throw new ArgumentNullException(nameof(leftShiftOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ShiftOperator, leftShiftOperator, out hash);
			if (cached != null) return (ShiftOperatorGreen)cached;
			var result = new ShiftOperatorGreen(CoreSyntaxKind.ShiftOperator, leftShiftOperator, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ShiftOperatorGreen ShiftOperator(RightShiftOperatorGreen rightShiftOperator)
	    {
	#if DEBUG
		    if (rightShiftOperator == null) throw new ArgumentNullException(nameof(rightShiftOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ShiftOperator, rightShiftOperator, out hash);
			if (cached != null) return (ShiftOperatorGreen)cached;
			var result = new ShiftOperatorGreen(CoreSyntaxKind.ShiftOperator, null, rightShiftOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LeftShiftOperatorGreen LeftShiftOperator(InternalSyntaxToken first, InternalSyntaxToken second)
	    {
	#if DEBUG
			if (first == null) throw new ArgumentNullException(nameof(first));
			if (first.Kind != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(first));
			if (second == null) throw new ArgumentNullException(nameof(second));
			if (second.Kind != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(second));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.LeftShiftOperator, first, second, out hash);
			if (cached != null) return (LeftShiftOperatorGreen)cached;
			var result = new LeftShiftOperatorGreen(CoreSyntaxKind.LeftShiftOperator, first, second);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RightShiftOperatorGreen RightShiftOperator(InternalSyntaxToken first, InternalSyntaxToken second)
	    {
	#if DEBUG
			if (first == null) throw new ArgumentNullException(nameof(first));
			if (first.Kind != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(first));
			if (second == null) throw new ArgumentNullException(nameof(second));
			if (second.Kind != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(second));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.RightShiftOperator, first, second, out hash);
			if (cached != null) return (RightShiftOperatorGreen)cached;
			var result = new RightShiftOperatorGreen(CoreSyntaxKind.RightShiftOperator, first, second);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RelationalOperatorGreen RelationalOperator(InternalSyntaxToken relationalOperator)
	    {
	#if DEBUG
			if (relationalOperator == null) throw new ArgumentNullException(nameof(relationalOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.RelationalOperator, relationalOperator, out hash);
			if (cached != null) return (RelationalOperatorGreen)cached;
			var result = new RelationalOperatorGreen(CoreSyntaxKind.RelationalOperator, relationalOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EqualityOperatorGreen EqualityOperator(InternalSyntaxToken equalityOperator)
	    {
	#if DEBUG
			if (equalityOperator == null) throw new ArgumentNullException(nameof(equalityOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.EqualityOperator, equalityOperator, out hash);
			if (cached != null) return (EqualityOperatorGreen)cached;
			var result = new EqualityOperatorGreen(CoreSyntaxKind.EqualityOperator, equalityOperator);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompoundAssignmentOperatorGreen CompoundAssignmentOperator(InternalSyntaxToken compoundAssignmentOperator)
	    {
	#if DEBUG
			if (compoundAssignmentOperator == null) throw new ArgumentNullException(nameof(compoundAssignmentOperator));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.CompoundAssignmentOperator, compoundAssignmentOperator, out hash);
			if (cached != null) return (CompoundAssignmentOperatorGreen)cached;
			var result = new CompoundAssignmentOperatorGreen(CoreSyntaxKind.CompoundAssignmentOperator, compoundAssignmentOperator);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(CoreSyntaxKind.ReturnType, typeReference, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(CoreSyntaxKind.ReturnType, null, voidType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PrimitiveTypeRefGreen PrimitiveTypeRef(PrimitiveTypeGreen primitiveType)
	    {
	#if DEBUG
			if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.PrimitiveTypeRef, primitiveType, out hash);
			if (cached != null) return (PrimitiveTypeRefGreen)cached;
			var result = new PrimitiveTypeRefGreen(CoreSyntaxKind.PrimitiveTypeRef, primitiveType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericTypeRefGreen GenericTypeRef(NamedTypeGreen namedType, GenericTypeArgumentsGreen genericTypeArguments)
	    {
	#if DEBUG
			if (namedType == null) throw new ArgumentNullException(nameof(namedType));
			if (genericTypeArguments == null) throw new ArgumentNullException(nameof(genericTypeArguments));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.GenericTypeRef, namedType, genericTypeArguments, out hash);
			if (cached != null) return (GenericTypeRefGreen)cached;
			var result = new GenericTypeRefGreen(CoreSyntaxKind.GenericTypeRef, namedType, genericTypeArguments);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamedTypeRefGreen NamedTypeRef(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.NamedTypeRef, qualifier, out hash);
			if (cached != null) return (NamedTypeRefGreen)cached;
			var result = new NamedTypeRefGreen(CoreSyntaxKind.NamedTypeRef, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayTypeRefGreen ArrayTypeRef(TypeReferenceGreen typeReference, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != CoreSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != CoreSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ArrayTypeRef, typeReference, tOpenBracket, tCloseBracket, out hash);
			if (cached != null) return (ArrayTypeRefGreen)cached;
			var result = new ArrayTypeRefGreen(CoreSyntaxKind.ArrayTypeRef, typeReference, tOpenBracket, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableTypeRefGreen NullableTypeRef(TypeReferenceGreen typeReference, InternalSyntaxToken tQuestion)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
			if (tQuestion.Kind != CoreSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.NullableTypeRef, typeReference, tQuestion, out hash);
			if (cached != null) return (NullableTypeRefGreen)cached;
			var result = new NullableTypeRefGreen(CoreSyntaxKind.NullableTypeRef, typeReference, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamedTypeGreen NamedType(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.NamedType, qualifier, out hash);
			if (cached != null) return (NamedTypeGreen)cached;
			var result = new NamedTypeGreen(CoreSyntaxKind.NamedType, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericTypeArgumentsGreen GenericTypeArguments(InternalSyntaxToken tLessThan, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<GenericTypeArgumentGreen> genericTypeArgument, InternalSyntaxToken tGreaterThan)
	    {
	#if DEBUG
			if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
			if (tLessThan.Kind != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
			if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
			if (tGreaterThan.Kind != CoreSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.GenericTypeArguments, tLessThan, genericTypeArgument.Node, tGreaterThan, out hash);
			if (cached != null) return (GenericTypeArgumentsGreen)cached;
			var result = new GenericTypeArgumentsGreen(CoreSyntaxKind.GenericTypeArguments, tLessThan, genericTypeArgument.Node, tGreaterThan);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public GenericTypeArgumentGreen GenericTypeArgument(TypeReferenceGreen typeReference)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.GenericTypeArgument, typeReference, out hash);
			if (cached != null) return (GenericTypeArgumentGreen)cached;
			var result = new GenericTypeArgumentGreen(CoreSyntaxKind.GenericTypeArgument, typeReference);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.PrimitiveType, primitiveType, out hash);
			if (cached != null) return (PrimitiveTypeGreen)cached;
			var result = new PrimitiveTypeGreen(CoreSyntaxKind.PrimitiveType, primitiveType);
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
			if (kVoid.Kind != CoreSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(CoreSyntaxKind.VoidType, kVoid);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(CoreSyntaxKind.Name, identifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(CoreSyntaxKind.QualifiedName, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(CoreSyntaxKind.Qualifier, identifier.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.Identifier, identifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(CoreSyntaxKind.Identifier, identifier);
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
			return new LiteralGreen(CoreSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(CoreSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			return new LiteralGreen(CoreSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			return new LiteralGreen(CoreSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			return new LiteralGreen(CoreSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(CoreSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != CoreSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(CoreSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(CoreSyntaxKind.BooleanLiteral, booleanLiteral);
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
			if (lInteger.Kind != CoreSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(CoreSyntaxKind.IntegerLiteral, lInteger);
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
			if (lDecimal.Kind != CoreSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(CoreSyntaxKind.DecimalLiteral, lDecimal);
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
			if (lScientific.Kind != CoreSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(CoreSyntaxKind.ScientificLiteral, lScientific);
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
			if (lRegularString.Kind != CoreSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(CoreSyntaxKind)CoreSyntaxKind.StringLiteral, lRegularString, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(CoreSyntaxKind.StringLiteral, lRegularString);
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
				typeof(UsingNamespaceGreen),
				typeof(StatementGreen),
				typeof(BlockStatementGreen),
				typeof(ParenthesizedExprGreen),
				typeof(TupleExprGreen),
				typeof(DiscardExprGreen),
				typeof(DefaultExprGreen),
				typeof(ThisExprGreen),
				typeof(BaseExprGreen),
				typeof(LiteralExprGreen),
				typeof(IdentifierExprGreen),
				typeof(QualifierExprGreen),
				typeof(IndexerExprGreen),
				typeof(InvocationExprGreen),
				typeof(TypeofExprGreen),
				typeof(NameofExprGreen),
				typeof(SizeofExprGreen),
				typeof(CheckedExprGreen),
				typeof(UncheckedExprGreen),
				typeof(NewExprGreen),
				typeof(PostfixUnaryExprGreen),
				typeof(NullForgivingExprGreen),
				typeof(UnaryExprGreen),
				typeof(TypeCastExprGreen),
				typeof(AwaitExprGreen),
				typeof(MultExprGreen),
				typeof(AddExprGreen),
				typeof(ShiftExprGreen),
				typeof(RelExprGreen),
				typeof(TypeIsExprGreen),
				typeof(TypeAsExprGreen),
				typeof(EqExprGreen),
				typeof(AndExprGreen),
				typeof(XorExprGreen),
				typeof(OrExprGreen),
				typeof(AndAlsoExprGreen),
				typeof(OrElseExprGreen),
				typeof(ThrowExprGreen),
				typeof(CoalExprGreen),
				typeof(CondExprGreen),
				typeof(AssignExprGreen),
				typeof(CompAssignExprGreen),
				typeof(LambdaExprGreen),
				typeof(TupleArgumentsGreen),
				typeof(ArgumentListGreen),
				typeof(ArgumentExpressionGreen),
				typeof(InitializerExpressionGreen),
				typeof(FieldInitializerExpressionsGreen),
				typeof(FieldInitializerExpressionGreen),
				typeof(CollectionInitializerExpressionsGreen),
				typeof(DictionaryInitializerExpressionsGreen),
				typeof(DictionaryInitializerExpressionGreen),
				typeof(LambdaSignatureGreen),
				typeof(ImplicitLambdaSignatureGreen),
				typeof(ImplicitParameterListGreen),
				typeof(ImplicitParameterGreen),
				typeof(ExplicitLambdaSignatureGreen),
				typeof(ExplicitParameterListGreen),
				typeof(ExplicitParameterGreen),
				typeof(LambdaBodyGreen),
				typeof(DotOperatorGreen),
				typeof(IndexerOperatorGreen),
				typeof(PostfixOperatorGreen),
				typeof(UnaryOperatorGreen),
				typeof(MultiplicativeOperatorGreen),
				typeof(AdditiveOperatorGreen),
				typeof(ShiftOperatorGreen),
				typeof(LeftShiftOperatorGreen),
				typeof(RightShiftOperatorGreen),
				typeof(RelationalOperatorGreen),
				typeof(EqualityOperatorGreen),
				typeof(CompoundAssignmentOperatorGreen),
				typeof(ReturnTypeGreen),
				typeof(PrimitiveTypeRefGreen),
				typeof(GenericTypeRefGreen),
				typeof(NamedTypeRefGreen),
				typeof(ArrayTypeRefGreen),
				typeof(NullableTypeRefGreen),
				typeof(NamedTypeGreen),
				typeof(GenericTypeArgumentsGreen),
				typeof(GenericTypeArgumentGreen),
				typeof(PrimitiveTypeGreen),
				typeof(VoidTypeGreen),
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


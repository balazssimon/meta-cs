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
using System.Threading.Tasks;

namespace WebSequenceDiagramsModel.Syntax.InternalSyntax
{
    using MetaDslx.CodeAnalysis;
    using MetaDslx.CodeAnalysis.Syntax;
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
    using Roslyn.Utilities;

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
            if (visitor is SequenceSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is SequenceSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor);
        public abstract void Accept(SequenceSyntaxVisitor visitor);

        public new SequenceLanguage Language => SequenceLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new SequenceSyntaxKind Kind => (SequenceSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;
	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(SequenceSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new SequenceLanguage Language => SequenceLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new SequenceSyntaxKind Kind => EnumObject.FromIntUnsafe<SequenceSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(SequenceSyntaxKind kind, string text)
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

	internal partial class GreenSyntaxToken : InternalSyntaxToken
	{
	    //====================
	    // Optimization: Normally, we wouldn't accept this much duplicate code, but these constructors
	    // are called A LOT and we want to keep them as short and simple as possible and increase the
	    // likelihood that they will be inlined.
	    internal GreenSyntaxToken(SequenceSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(SequenceSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(SequenceSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(SequenceSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(SequenceSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(SequenceSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new SequenceLanguage Language => SequenceLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new SequenceSyntaxKind Kind => EnumObject.FromIntUnsafe<SequenceSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(SequenceSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!SequenceLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid SequenceSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(SequenceSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!SequenceLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid SequenceSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == SequenceLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == SequenceLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == SequenceLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == SequenceLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(SequenceSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly SequenceSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly SequenceSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = SequenceSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = SequenceSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = SequenceLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((SequenceSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((SequenceSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((SequenceSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((SequenceSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(SequenceSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(SequenceSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(SequenceSyntaxKind kind, SequenceSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(SequenceSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(SequenceSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public virtual SequenceSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(SequenceSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(SequenceSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(SequenceSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(SequenceSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly SequenceSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(SequenceSyntaxKind kind, SequenceSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(SequenceSyntaxKind kind, SequenceSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<SequenceSyntaxKind>(reader.ReadInt32());
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
	        public override SequenceSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(SequenceSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(SequenceSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            SequenceSyntaxKind kind,
	            SequenceSyntaxKind contextualKind,
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
	            SequenceSyntaxKind kind,
	            SequenceSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(SequenceSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(SequenceSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(SequenceSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            SequenceSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(SequenceSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(SequenceSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    private InteractionGreen interaction;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(SequenceSyntaxKind kind, InteractionGreen interaction, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (interaction != null)
			{
				this.AdjustFlagsAndWidth(interaction);
				this.interaction = interaction;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
	    public MainGreen(SequenceSyntaxKind kind, InteractionGreen interaction, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (interaction != null)
			{
				this.AdjustFlagsAndWidth(interaction);
				this.interaction = interaction;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
		private MainGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InteractionGreen Interaction { get { return this.interaction; } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eof; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.MainSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.interaction;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.interaction, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.interaction, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(InteractionGreen interaction, InternalSyntaxToken eof)
	    {
	        if (this.Interaction != interaction ||
				this.EndOfFileToken != eof)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Main(interaction, eof);
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
	
	internal class InteractionGreen : GreenSyntaxNode
	{
	    internal static readonly InteractionGreen __Missing = new InteractionGreen();
	    private GreenNode line;
	
	    public InteractionGreen(SequenceSyntaxKind kind, GreenNode line)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (line != null)
			{
				this.AdjustFlagsAndWidth(line);
				this.line = line;
			}
	    }
	
	    public InteractionGreen(SequenceSyntaxKind kind, GreenNode line, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (line != null)
			{
				this.AdjustFlagsAndWidth(line);
				this.line = line;
			}
	    }
	
		private InteractionGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Interaction, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen> Line { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen>(this.line); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.InteractionSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.line;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitInteractionGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitInteractionGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InteractionGreen(this.Kind, this.line, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InteractionGreen(this.Kind, this.line, this.GetDiagnostics(), annotations);
	    }
	
	    public InteractionGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen> line)
	    {
	        if (this.Line != line)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Interaction(line);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InteractionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LineGreen : GreenSyntaxNode
	{
	    internal static readonly LineGreen __Missing = new LineGreen();
	    private DeclarationGreen declaration;
	    private InternalSyntaxToken lCrLf;
	
	    public LineGreen(SequenceSyntaxKind kind, DeclarationGreen declaration, InternalSyntaxToken lCrLf)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
	    }
	
	    public LineGreen(SequenceSyntaxKind kind, DeclarationGreen declaration, InternalSyntaxToken lCrLf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
	    }
	
		private LineGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Line, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public DeclarationGreen Declaration { get { return this.declaration; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.LineSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.declaration;
	            case 1: return this.lCrLf;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitLineGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitLineGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LineGreen(this.Kind, this.declaration, this.lCrLf, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LineGreen(this.Kind, this.declaration, this.lCrLf, this.GetDiagnostics(), annotations);
	    }
	
	    public LineGreen Update(DeclarationGreen declaration, InternalSyntaxToken lCrLf)
	    {
	        if (this.Declaration != declaration ||
				this.LCrLf != lCrLf)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Line(declaration, lCrLf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LineGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly DeclarationGreen __Missing = new DeclarationGreen();
	    private TitleGreen title;
	    private DestroyGreen destroy;
	    private ArrowGreen arrow;
	    private AltGreen alt;
	    private OptGreen opt;
	    private LoopGreen loop;
	    private RefGreen _ref;
	    private NoteGreen note;
	
	    public DeclarationGreen(SequenceSyntaxKind kind, TitleGreen title, DestroyGreen destroy, ArrowGreen arrow, AltGreen alt, OptGreen opt, LoopGreen loop, RefGreen _ref, NoteGreen note)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (title != null)
			{
				this.AdjustFlagsAndWidth(title);
				this.title = title;
			}
			if (destroy != null)
			{
				this.AdjustFlagsAndWidth(destroy);
				this.destroy = destroy;
			}
			if (arrow != null)
			{
				this.AdjustFlagsAndWidth(arrow);
				this.arrow = arrow;
			}
			if (alt != null)
			{
				this.AdjustFlagsAndWidth(alt);
				this.alt = alt;
			}
			if (opt != null)
			{
				this.AdjustFlagsAndWidth(opt);
				this.opt = opt;
			}
			if (loop != null)
			{
				this.AdjustFlagsAndWidth(loop);
				this.loop = loop;
			}
			if (_ref != null)
			{
				this.AdjustFlagsAndWidth(_ref);
				this._ref = _ref;
			}
			if (note != null)
			{
				this.AdjustFlagsAndWidth(note);
				this.note = note;
			}
	    }
	
	    public DeclarationGreen(SequenceSyntaxKind kind, TitleGreen title, DestroyGreen destroy, ArrowGreen arrow, AltGreen alt, OptGreen opt, LoopGreen loop, RefGreen _ref, NoteGreen note, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (title != null)
			{
				this.AdjustFlagsAndWidth(title);
				this.title = title;
			}
			if (destroy != null)
			{
				this.AdjustFlagsAndWidth(destroy);
				this.destroy = destroy;
			}
			if (arrow != null)
			{
				this.AdjustFlagsAndWidth(arrow);
				this.arrow = arrow;
			}
			if (alt != null)
			{
				this.AdjustFlagsAndWidth(alt);
				this.alt = alt;
			}
			if (opt != null)
			{
				this.AdjustFlagsAndWidth(opt);
				this.opt = opt;
			}
			if (loop != null)
			{
				this.AdjustFlagsAndWidth(loop);
				this.loop = loop;
			}
			if (_ref != null)
			{
				this.AdjustFlagsAndWidth(_ref);
				this._ref = _ref;
			}
			if (note != null)
			{
				this.AdjustFlagsAndWidth(note);
				this.note = note;
			}
	    }
	
		private DeclarationGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Declaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TitleGreen Title { get { return this.title; } }
	    public DestroyGreen Destroy { get { return this.destroy; } }
	    public ArrowGreen Arrow { get { return this.arrow; } }
	    public AltGreen Alt { get { return this.alt; } }
	    public OptGreen Opt { get { return this.opt; } }
	    public LoopGreen Loop { get { return this.loop; } }
	    public RefGreen Ref { get { return this._ref; } }
	    public NoteGreen Note { get { return this.note; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.DeclarationSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.title;
	            case 1: return this.destroy;
	            case 2: return this.arrow;
	            case 3: return this.alt;
	            case 4: return this.opt;
	            case 5: return this.loop;
	            case 6: return this._ref;
	            case 7: return this.note;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.title, this.destroy, this.arrow, this.alt, this.opt, this.loop, this._ref, this.note, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.title, this.destroy, this.arrow, this.alt, this.opt, this.loop, this._ref, this.note, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(TitleGreen title)
	    {
	        if (this.title != title)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(title);
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
	
	    public DeclarationGreen Update(DestroyGreen destroy)
	    {
	        if (this.destroy != destroy)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(destroy);
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
	
	    public DeclarationGreen Update(ArrowGreen arrow)
	    {
	        if (this.arrow != arrow)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(arrow);
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
	
	    public DeclarationGreen Update(AltGreen alt)
	    {
	        if (this.alt != alt)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(alt);
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
	
	    public DeclarationGreen Update(OptGreen opt)
	    {
	        if (this.opt != opt)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(opt);
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
	
	    public DeclarationGreen Update(LoopGreen loop)
	    {
	        if (this.loop != loop)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(loop);
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
	
	    public DeclarationGreen Update(RefGreen _ref)
	    {
	        if (this._ref != _ref)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(_ref);
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
	
	    public DeclarationGreen Update(NoteGreen note)
	    {
	        if (this.note != note)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Declaration(note);
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
	
	internal class TitleGreen : GreenSyntaxNode
	{
	    internal static readonly TitleGreen __Missing = new TitleGreen();
	    private InternalSyntaxToken kTitle;
	    private TextGreen text;
	
	    public TitleGreen(SequenceSyntaxKind kind, InternalSyntaxToken kTitle, TextGreen text)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kTitle != null)
			{
				this.AdjustFlagsAndWidth(kTitle);
				this.kTitle = kTitle;
			}
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
	    public TitleGreen(SequenceSyntaxKind kind, InternalSyntaxToken kTitle, TextGreen text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kTitle != null)
			{
				this.AdjustFlagsAndWidth(kTitle);
				this.kTitle = kTitle;
			}
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
		private TitleGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Title, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTitle { get { return this.kTitle; } }
	    public TextGreen Text { get { return this.text; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.TitleSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTitle;
	            case 1: return this.text;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitTitleGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitTitleGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TitleGreen(this.Kind, this.kTitle, this.text, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TitleGreen(this.Kind, this.kTitle, this.text, this.GetDiagnostics(), annotations);
	    }
	
	    public TitleGreen Update(InternalSyntaxToken kTitle, TextGreen text)
	    {
	        if (this.KTitle != kTitle ||
				this.Text != text)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Title(kTitle, text);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TitleGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrowGreen : GreenSyntaxNode
	{
	    internal static readonly ArrowGreen __Missing = new ArrowGreen();
	    private LifeLineNameGreen source;
	    private ArrowTypeGreen type;
	    private LifeLineNameGreen target;
	    private InternalSyntaxToken tColon;
	    private TextGreen text;
	
	    public ArrowGreen(SequenceSyntaxKind kind, LifeLineNameGreen source, ArrowTypeGreen type, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen text)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (type != null)
			{
				this.AdjustFlagsAndWidth(type);
				this.type = type;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
	    public ArrowGreen(SequenceSyntaxKind kind, LifeLineNameGreen source, ArrowTypeGreen type, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (type != null)
			{
				this.AdjustFlagsAndWidth(type);
				this.type = type;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
		private ArrowGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Arrow, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LifeLineNameGreen Source { get { return this.source; } }
	    public ArrowTypeGreen Type { get { return this.type; } }
	    public LifeLineNameGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TextGreen Text { get { return this.text; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.ArrowSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.source;
	            case 1: return this.type;
	            case 2: return this.target;
	            case 3: return this.tColon;
	            case 4: return this.text;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitArrowGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitArrowGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrowGreen(this.Kind, this.source, this.type, this.target, this.tColon, this.text, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrowGreen(this.Kind, this.source, this.type, this.target, this.tColon, this.text, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrowGreen Update(LifeLineNameGreen source, ArrowTypeGreen type, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen text)
	    {
	        if (this.Source != source ||
				this.Type != type ||
				this.Target != target ||
				this.TColon != tColon ||
				this.Text != text)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Arrow(source, type, target, tColon, text);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrowGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DestroyGreen : GreenSyntaxNode
	{
	    internal static readonly DestroyGreen __Missing = new DestroyGreen();
	    private InternalSyntaxToken kDestroy;
	    private LifeLineNameGreen lifeLineName;
	
	    public DestroyGreen(SequenceSyntaxKind kind, InternalSyntaxToken kDestroy, LifeLineNameGreen lifeLineName)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kDestroy != null)
			{
				this.AdjustFlagsAndWidth(kDestroy);
				this.kDestroy = kDestroy;
			}
			if (lifeLineName != null)
			{
				this.AdjustFlagsAndWidth(lifeLineName);
				this.lifeLineName = lifeLineName;
			}
	    }
	
	    public DestroyGreen(SequenceSyntaxKind kind, InternalSyntaxToken kDestroy, LifeLineNameGreen lifeLineName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kDestroy != null)
			{
				this.AdjustFlagsAndWidth(kDestroy);
				this.kDestroy = kDestroy;
			}
			if (lifeLineName != null)
			{
				this.AdjustFlagsAndWidth(lifeLineName);
				this.lifeLineName = lifeLineName;
			}
	    }
	
		private DestroyGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Destroy, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDestroy { get { return this.kDestroy; } }
	    public LifeLineNameGreen LifeLineName { get { return this.lifeLineName; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.DestroySyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDestroy;
	            case 1: return this.lifeLineName;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitDestroyGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitDestroyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DestroyGreen(this.Kind, this.kDestroy, this.lifeLineName, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DestroyGreen(this.Kind, this.kDestroy, this.lifeLineName, this.GetDiagnostics(), annotations);
	    }
	
	    public DestroyGreen Update(InternalSyntaxToken kDestroy, LifeLineNameGreen lifeLineName)
	    {
	        if (this.KDestroy != kDestroy ||
				this.LifeLineName != lifeLineName)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Destroy(kDestroy, lifeLineName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DestroyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AltGreen : GreenSyntaxNode
	{
	    internal static readonly AltGreen __Missing = new AltGreen();
	    private AltFragmentGreen altFragment;
	    private GreenNode elseFragment;
	    private EndGreen end;
	
	    public AltGreen(SequenceSyntaxKind kind, AltFragmentGreen altFragment, GreenNode elseFragment, EndGreen end)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (altFragment != null)
			{
				this.AdjustFlagsAndWidth(altFragment);
				this.altFragment = altFragment;
			}
			if (elseFragment != null)
			{
				this.AdjustFlagsAndWidth(elseFragment);
				this.elseFragment = elseFragment;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
	    public AltGreen(SequenceSyntaxKind kind, AltFragmentGreen altFragment, GreenNode elseFragment, EndGreen end, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (altFragment != null)
			{
				this.AdjustFlagsAndWidth(altFragment);
				this.altFragment = altFragment;
			}
			if (elseFragment != null)
			{
				this.AdjustFlagsAndWidth(elseFragment);
				this.elseFragment = elseFragment;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
		private AltGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Alt, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AltFragmentGreen AltFragment { get { return this.altFragment; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseFragmentGreen> ElseFragment { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseFragmentGreen>(this.elseFragment); } }
	    public EndGreen End { get { return this.end; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.AltSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.altFragment;
	            case 1: return this.elseFragment;
	            case 2: return this.end;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitAltGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitAltGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AltGreen(this.Kind, this.altFragment, this.elseFragment, this.end, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AltGreen(this.Kind, this.altFragment, this.elseFragment, this.end, this.GetDiagnostics(), annotations);
	    }
	
	    public AltGreen Update(AltFragmentGreen altFragment, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseFragmentGreen> elseFragment, EndGreen end)
	    {
	        if (this.AltFragment != altFragment ||
				this.ElseFragment != elseFragment ||
				this.End != end)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Alt(altFragment, elseFragment, end);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AltGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AltFragmentGreen : GreenSyntaxNode
	{
	    internal static readonly AltFragmentGreen __Missing = new AltFragmentGreen();
	    private InternalSyntaxToken kAlt;
	    private TextGreen condition;
	    private InternalSyntaxToken lCrLf;
	    private FragmentBodyGreen fragmentBody;
	
	    public AltFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kAlt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kAlt != null)
			{
				this.AdjustFlagsAndWidth(kAlt);
				this.kAlt = kAlt;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
	    public AltFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kAlt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kAlt != null)
			{
				this.AdjustFlagsAndWidth(kAlt);
				this.kAlt = kAlt;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
		private AltFragmentGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.AltFragment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAlt { get { return this.kAlt; } }
	    public TextGreen Condition { get { return this.condition; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	    public FragmentBodyGreen FragmentBody { get { return this.fragmentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.AltFragmentSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAlt;
	            case 1: return this.condition;
	            case 2: return this.lCrLf;
	            case 3: return this.fragmentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitAltFragmentGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitAltFragmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AltFragmentGreen(this.Kind, this.kAlt, this.condition, this.lCrLf, this.fragmentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AltFragmentGreen(this.Kind, this.kAlt, this.condition, this.lCrLf, this.fragmentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public AltFragmentGreen Update(InternalSyntaxToken kAlt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	        if (this.KAlt != kAlt ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.AltFragment(kAlt, condition, lCrLf, fragmentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AltFragmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElseFragmentGreen : GreenSyntaxNode
	{
	    internal static readonly ElseFragmentGreen __Missing = new ElseFragmentGreen();
	    private InternalSyntaxToken kElse;
	    private TextGreen condition;
	    private InternalSyntaxToken lCrLf;
	    private FragmentBodyGreen fragmentBody;
	
	    public ElseFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kElse, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
	    public ElseFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kElse, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kElse != null)
			{
				this.AdjustFlagsAndWidth(kElse);
				this.kElse = kElse;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
		private ElseFragmentGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.ElseFragment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KElse { get { return this.kElse; } }
	    public TextGreen Condition { get { return this.condition; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	    public FragmentBodyGreen FragmentBody { get { return this.fragmentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.ElseFragmentSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kElse;
	            case 1: return this.condition;
	            case 2: return this.lCrLf;
	            case 3: return this.fragmentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitElseFragmentGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitElseFragmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElseFragmentGreen(this.Kind, this.kElse, this.condition, this.lCrLf, this.fragmentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElseFragmentGreen(this.Kind, this.kElse, this.condition, this.lCrLf, this.fragmentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ElseFragmentGreen Update(InternalSyntaxToken kElse, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	        if (this.KElse != kElse ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.ElseFragment(kElse, condition, lCrLf, fragmentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseFragmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopGreen : GreenSyntaxNode
	{
	    internal static readonly LoopGreen __Missing = new LoopGreen();
	    private LoopFragmentGreen loopFragment;
	    private EndGreen end;
	
	    public LoopGreen(SequenceSyntaxKind kind, LoopFragmentGreen loopFragment, EndGreen end)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (loopFragment != null)
			{
				this.AdjustFlagsAndWidth(loopFragment);
				this.loopFragment = loopFragment;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
	    public LoopGreen(SequenceSyntaxKind kind, LoopFragmentGreen loopFragment, EndGreen end, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (loopFragment != null)
			{
				this.AdjustFlagsAndWidth(loopFragment);
				this.loopFragment = loopFragment;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
		private LoopGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Loop, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LoopFragmentGreen LoopFragment { get { return this.loopFragment; } }
	    public EndGreen End { get { return this.end; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.LoopSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.loopFragment;
	            case 1: return this.end;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitLoopGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitLoopGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopGreen(this.Kind, this.loopFragment, this.end, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopGreen(this.Kind, this.loopFragment, this.end, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopGreen Update(LoopFragmentGreen loopFragment, EndGreen end)
	    {
	        if (this.LoopFragment != loopFragment ||
				this.End != end)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Loop(loopFragment, end);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LoopFragmentGreen : GreenSyntaxNode
	{
	    internal static readonly LoopFragmentGreen __Missing = new LoopFragmentGreen();
	    private InternalSyntaxToken kLoop;
	    private TextGreen condition;
	    private InternalSyntaxToken lCrLf;
	    private FragmentBodyGreen fragmentBody;
	
	    public LoopFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kLoop, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kLoop != null)
			{
				this.AdjustFlagsAndWidth(kLoop);
				this.kLoop = kLoop;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
	    public LoopFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kLoop, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kLoop != null)
			{
				this.AdjustFlagsAndWidth(kLoop);
				this.kLoop = kLoop;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
		private LoopFragmentGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.LoopFragment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KLoop { get { return this.kLoop; } }
	    public TextGreen Condition { get { return this.condition; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	    public FragmentBodyGreen FragmentBody { get { return this.fragmentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.LoopFragmentSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kLoop;
	            case 1: return this.condition;
	            case 2: return this.lCrLf;
	            case 3: return this.fragmentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitLoopFragmentGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitLoopFragmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LoopFragmentGreen(this.Kind, this.kLoop, this.condition, this.lCrLf, this.fragmentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LoopFragmentGreen(this.Kind, this.kLoop, this.condition, this.lCrLf, this.fragmentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public LoopFragmentGreen Update(InternalSyntaxToken kLoop, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	        if (this.KLoop != kLoop ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.LoopFragment(kLoop, condition, lCrLf, fragmentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopFragmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OptGreen : GreenSyntaxNode
	{
	    internal static readonly OptGreen __Missing = new OptGreen();
	    private OptFragmentGreen optFragment;
	    private EndGreen end;
	
	    public OptGreen(SequenceSyntaxKind kind, OptFragmentGreen optFragment, EndGreen end)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (optFragment != null)
			{
				this.AdjustFlagsAndWidth(optFragment);
				this.optFragment = optFragment;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
	    public OptGreen(SequenceSyntaxKind kind, OptFragmentGreen optFragment, EndGreen end, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (optFragment != null)
			{
				this.AdjustFlagsAndWidth(optFragment);
				this.optFragment = optFragment;
			}
			if (end != null)
			{
				this.AdjustFlagsAndWidth(end);
				this.end = end;
			}
	    }
	
		private OptGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Opt, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OptFragmentGreen OptFragment { get { return this.optFragment; } }
	    public EndGreen End { get { return this.end; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.OptSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.optFragment;
	            case 1: return this.end;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitOptGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitOptGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OptGreen(this.Kind, this.optFragment, this.end, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OptGreen(this.Kind, this.optFragment, this.end, this.GetDiagnostics(), annotations);
	    }
	
	    public OptGreen Update(OptFragmentGreen optFragment, EndGreen end)
	    {
	        if (this.OptFragment != optFragment ||
				this.End != end)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Opt(optFragment, end);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OptGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OptFragmentGreen : GreenSyntaxNode
	{
	    internal static readonly OptFragmentGreen __Missing = new OptFragmentGreen();
	    private InternalSyntaxToken kOpt;
	    private TextGreen condition;
	    private InternalSyntaxToken lCrLf;
	    private FragmentBodyGreen fragmentBody;
	
	    public OptFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kOpt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kOpt != null)
			{
				this.AdjustFlagsAndWidth(kOpt);
				this.kOpt = kOpt;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
	    public OptFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kOpt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kOpt != null)
			{
				this.AdjustFlagsAndWidth(kOpt);
				this.kOpt = kOpt;
			}
			if (condition != null)
			{
				this.AdjustFlagsAndWidth(condition);
				this.condition = condition;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (fragmentBody != null)
			{
				this.AdjustFlagsAndWidth(fragmentBody);
				this.fragmentBody = fragmentBody;
			}
	    }
	
		private OptFragmentGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.OptFragment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KOpt { get { return this.kOpt; } }
	    public TextGreen Condition { get { return this.condition; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	    public FragmentBodyGreen FragmentBody { get { return this.fragmentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.OptFragmentSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kOpt;
	            case 1: return this.condition;
	            case 2: return this.lCrLf;
	            case 3: return this.fragmentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitOptFragmentGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitOptFragmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OptFragmentGreen(this.Kind, this.kOpt, this.condition, this.lCrLf, this.fragmentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OptFragmentGreen(this.Kind, this.kOpt, this.condition, this.lCrLf, this.fragmentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public OptFragmentGreen Update(InternalSyntaxToken kOpt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	        if (this.KOpt != kOpt ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.OptFragment(kOpt, condition, lCrLf, fragmentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OptFragmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RefGreen : GreenSyntaxNode
	{
	    internal static readonly RefGreen __Missing = new RefGreen();
	    private SimpleRefFragmentGreen simpleRefFragment;
	    private MessageRefFragmentGreen messageRefFragment;
	
	    public RefGreen(SequenceSyntaxKind kind, SimpleRefFragmentGreen simpleRefFragment, MessageRefFragmentGreen messageRefFragment)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (simpleRefFragment != null)
			{
				this.AdjustFlagsAndWidth(simpleRefFragment);
				this.simpleRefFragment = simpleRefFragment;
			}
			if (messageRefFragment != null)
			{
				this.AdjustFlagsAndWidth(messageRefFragment);
				this.messageRefFragment = messageRefFragment;
			}
	    }
	
	    public RefGreen(SequenceSyntaxKind kind, SimpleRefFragmentGreen simpleRefFragment, MessageRefFragmentGreen messageRefFragment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (simpleRefFragment != null)
			{
				this.AdjustFlagsAndWidth(simpleRefFragment);
				this.simpleRefFragment = simpleRefFragment;
			}
			if (messageRefFragment != null)
			{
				this.AdjustFlagsAndWidth(messageRefFragment);
				this.messageRefFragment = messageRefFragment;
			}
	    }
	
		private RefGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Ref, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleRefFragmentGreen SimpleRefFragment { get { return this.simpleRefFragment; } }
	    public MessageRefFragmentGreen MessageRefFragment { get { return this.messageRefFragment; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.RefSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleRefFragment;
	            case 1: return this.messageRefFragment;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitRefGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitRefGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RefGreen(this.Kind, this.simpleRefFragment, this.messageRefFragment, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RefGreen(this.Kind, this.simpleRefFragment, this.messageRefFragment, this.GetDiagnostics(), annotations);
	    }
	
	    public RefGreen Update(SimpleRefFragmentGreen simpleRefFragment)
	    {
	        if (this.simpleRefFragment != simpleRefFragment)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Ref(simpleRefFragment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefGreen)newNode;
	        }
	        return this;
	    }
	
	    public RefGreen Update(MessageRefFragmentGreen messageRefFragment)
	    {
	        if (this.messageRefFragment != messageRefFragment)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Ref(messageRefFragment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleRefFragmentGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleRefFragmentGreen __Missing = new SimpleRefFragmentGreen();
	    private InternalSyntaxToken kRef;
	    private TextGreen over;
	    private InternalSyntaxToken tColon;
	    private TextGreen refText;
	    private InternalSyntaxToken lCrLf;
	    private SimpleBodyGreen simpleBody;
	    private InternalSyntaxToken kEndRef;
	
	    public SimpleRefFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen refText, InternalSyntaxToken lCrLf, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndRef)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (kRef != null)
			{
				this.AdjustFlagsAndWidth(kRef);
				this.kRef = kRef;
			}
			if (over != null)
			{
				this.AdjustFlagsAndWidth(over);
				this.over = over;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (refText != null)
			{
				this.AdjustFlagsAndWidth(refText);
				this.refText = refText;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (simpleBody != null)
			{
				this.AdjustFlagsAndWidth(simpleBody);
				this.simpleBody = simpleBody;
			}
			if (kEndRef != null)
			{
				this.AdjustFlagsAndWidth(kEndRef);
				this.kEndRef = kEndRef;
			}
	    }
	
	    public SimpleRefFragmentGreen(SequenceSyntaxKind kind, InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen refText, InternalSyntaxToken lCrLf, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndRef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (kRef != null)
			{
				this.AdjustFlagsAndWidth(kRef);
				this.kRef = kRef;
			}
			if (over != null)
			{
				this.AdjustFlagsAndWidth(over);
				this.over = over;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (refText != null)
			{
				this.AdjustFlagsAndWidth(refText);
				this.refText = refText;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
			if (simpleBody != null)
			{
				this.AdjustFlagsAndWidth(simpleBody);
				this.simpleBody = simpleBody;
			}
			if (kEndRef != null)
			{
				this.AdjustFlagsAndWidth(kEndRef);
				this.kEndRef = kEndRef;
			}
	    }
	
		private SimpleRefFragmentGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.SimpleRefFragment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRef { get { return this.kRef; } }
	    public TextGreen Over { get { return this.over; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TextGreen RefText { get { return this.refText; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	    public SimpleBodyGreen SimpleBody { get { return this.simpleBody; } }
	    public InternalSyntaxToken KEndRef { get { return this.kEndRef; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.SimpleRefFragmentSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRef;
	            case 1: return this.over;
	            case 2: return this.tColon;
	            case 3: return this.refText;
	            case 4: return this.lCrLf;
	            case 5: return this.simpleBody;
	            case 6: return this.kEndRef;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleRefFragmentGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitSimpleRefFragmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleRefFragmentGreen(this.Kind, this.kRef, this.over, this.tColon, this.refText, this.lCrLf, this.simpleBody, this.kEndRef, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleRefFragmentGreen(this.Kind, this.kRef, this.over, this.tColon, this.refText, this.lCrLf, this.simpleBody, this.kEndRef, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleRefFragmentGreen Update(InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen refText, InternalSyntaxToken lCrLf, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndRef)
	    {
	        if (this.KRef != kRef ||
				this.Over != over ||
				this.TColon != tColon ||
				this.RefText != refText ||
				this.LCrLf != lCrLf ||
				this.SimpleBody != simpleBody ||
				this.KEndRef != kEndRef)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.SimpleRefFragment(kRef, over, tColon, refText, lCrLf, simpleBody, kEndRef);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleRefFragmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MessageRefFragmentGreen : GreenSyntaxNode
	{
	    internal static readonly MessageRefFragmentGreen __Missing = new MessageRefFragmentGreen();
	    private RefInputGreen refInput;
	    private SimpleBodyGreen simpleBody;
	    private RefOutputGreen refOutput;
	
	    public MessageRefFragmentGreen(SequenceSyntaxKind kind, RefInputGreen refInput, SimpleBodyGreen simpleBody, RefOutputGreen refOutput)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (refInput != null)
			{
				this.AdjustFlagsAndWidth(refInput);
				this.refInput = refInput;
			}
			if (simpleBody != null)
			{
				this.AdjustFlagsAndWidth(simpleBody);
				this.simpleBody = simpleBody;
			}
			if (refOutput != null)
			{
				this.AdjustFlagsAndWidth(refOutput);
				this.refOutput = refOutput;
			}
	    }
	
	    public MessageRefFragmentGreen(SequenceSyntaxKind kind, RefInputGreen refInput, SimpleBodyGreen simpleBody, RefOutputGreen refOutput, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (refInput != null)
			{
				this.AdjustFlagsAndWidth(refInput);
				this.refInput = refInput;
			}
			if (simpleBody != null)
			{
				this.AdjustFlagsAndWidth(simpleBody);
				this.simpleBody = simpleBody;
			}
			if (refOutput != null)
			{
				this.AdjustFlagsAndWidth(refOutput);
				this.refOutput = refOutput;
			}
	    }
	
		private MessageRefFragmentGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.MessageRefFragment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public RefInputGreen RefInput { get { return this.refInput; } }
	    public SimpleBodyGreen SimpleBody { get { return this.simpleBody; } }
	    public RefOutputGreen RefOutput { get { return this.refOutput; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.MessageRefFragmentSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.refInput;
	            case 1: return this.simpleBody;
	            case 2: return this.refOutput;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitMessageRefFragmentGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitMessageRefFragmentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MessageRefFragmentGreen(this.Kind, this.refInput, this.simpleBody, this.refOutput, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MessageRefFragmentGreen(this.Kind, this.refInput, this.simpleBody, this.refOutput, this.GetDiagnostics(), annotations);
	    }
	
	    public MessageRefFragmentGreen Update(RefInputGreen refInput, SimpleBodyGreen simpleBody, RefOutputGreen refOutput)
	    {
	        if (this.RefInput != refInput ||
				this.SimpleBody != simpleBody ||
				this.RefOutput != refOutput)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.MessageRefFragment(refInput, simpleBody, refOutput);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MessageRefFragmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RefInputGreen : GreenSyntaxNode
	{
	    internal static readonly RefInputGreen __Missing = new RefInputGreen();
	    private LifeLineNameGreen source;
	    private ArrowTypeGreen sourceType;
	    private InternalSyntaxToken kRef;
	    private TextGreen over;
	    private InternalSyntaxToken tColon;
	    private TextGreen message;
	    private InternalSyntaxToken lCrLf;
	
	    public RefInputGreen(SequenceSyntaxKind kind, LifeLineNameGreen source, ArrowTypeGreen sourceType, InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen message, InternalSyntaxToken lCrLf)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (sourceType != null)
			{
				this.AdjustFlagsAndWidth(sourceType);
				this.sourceType = sourceType;
			}
			if (kRef != null)
			{
				this.AdjustFlagsAndWidth(kRef);
				this.kRef = kRef;
			}
			if (over != null)
			{
				this.AdjustFlagsAndWidth(over);
				this.over = over;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (message != null)
			{
				this.AdjustFlagsAndWidth(message);
				this.message = message;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
	    }
	
	    public RefInputGreen(SequenceSyntaxKind kind, LifeLineNameGreen source, ArrowTypeGreen sourceType, InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen message, InternalSyntaxToken lCrLf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (sourceType != null)
			{
				this.AdjustFlagsAndWidth(sourceType);
				this.sourceType = sourceType;
			}
			if (kRef != null)
			{
				this.AdjustFlagsAndWidth(kRef);
				this.kRef = kRef;
			}
			if (over != null)
			{
				this.AdjustFlagsAndWidth(over);
				this.over = over;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (message != null)
			{
				this.AdjustFlagsAndWidth(message);
				this.message = message;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
	    }
	
		private RefInputGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.RefInput, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LifeLineNameGreen Source { get { return this.source; } }
	    public ArrowTypeGreen SourceType { get { return this.sourceType; } }
	    public InternalSyntaxToken KRef { get { return this.kRef; } }
	    public TextGreen Over { get { return this.over; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TextGreen Message { get { return this.message; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.RefInputSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.source;
	            case 1: return this.sourceType;
	            case 2: return this.kRef;
	            case 3: return this.over;
	            case 4: return this.tColon;
	            case 5: return this.message;
	            case 6: return this.lCrLf;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitRefInputGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitRefInputGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RefInputGreen(this.Kind, this.source, this.sourceType, this.kRef, this.over, this.tColon, this.message, this.lCrLf, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RefInputGreen(this.Kind, this.source, this.sourceType, this.kRef, this.over, this.tColon, this.message, this.lCrLf, this.GetDiagnostics(), annotations);
	    }
	
	    public RefInputGreen Update(LifeLineNameGreen source, ArrowTypeGreen sourceType, InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen message, InternalSyntaxToken lCrLf)
	    {
	        if (this.Source != source ||
				this.SourceType != sourceType ||
				this.KRef != kRef ||
				this.Over != over ||
				this.TColon != tColon ||
				this.Message != message ||
				this.LCrLf != lCrLf)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.RefInput(source, sourceType, kRef, over, tColon, message, lCrLf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefInputGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RefOutputGreen : GreenSyntaxNode
	{
	    internal static readonly RefOutputGreen __Missing = new RefOutputGreen();
	    private InternalSyntaxToken kEndRef;
	    private TextGreen ignored;
	    private ArrowTypeGreen targetType;
	    private LifeLineNameGreen target;
	    private InternalSyntaxToken tColon;
	    private TextGreen message;
	
	    public RefOutputGreen(SequenceSyntaxKind kind, InternalSyntaxToken kEndRef, TextGreen ignored, ArrowTypeGreen targetType, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen message)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kEndRef != null)
			{
				this.AdjustFlagsAndWidth(kEndRef);
				this.kEndRef = kEndRef;
			}
			if (ignored != null)
			{
				this.AdjustFlagsAndWidth(ignored);
				this.ignored = ignored;
			}
			if (targetType != null)
			{
				this.AdjustFlagsAndWidth(targetType);
				this.targetType = targetType;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (message != null)
			{
				this.AdjustFlagsAndWidth(message);
				this.message = message;
			}
	    }
	
	    public RefOutputGreen(SequenceSyntaxKind kind, InternalSyntaxToken kEndRef, TextGreen ignored, ArrowTypeGreen targetType, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen message, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kEndRef != null)
			{
				this.AdjustFlagsAndWidth(kEndRef);
				this.kEndRef = kEndRef;
			}
			if (ignored != null)
			{
				this.AdjustFlagsAndWidth(ignored);
				this.ignored = ignored;
			}
			if (targetType != null)
			{
				this.AdjustFlagsAndWidth(targetType);
				this.targetType = targetType;
			}
			if (target != null)
			{
				this.AdjustFlagsAndWidth(target);
				this.target = target;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (message != null)
			{
				this.AdjustFlagsAndWidth(message);
				this.message = message;
			}
	    }
	
		private RefOutputGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.RefOutput, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEndRef { get { return this.kEndRef; } }
	    public TextGreen Ignored { get { return this.ignored; } }
	    public ArrowTypeGreen TargetType { get { return this.targetType; } }
	    public LifeLineNameGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TextGreen Message { get { return this.message; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.RefOutputSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEndRef;
	            case 1: return this.ignored;
	            case 2: return this.targetType;
	            case 3: return this.target;
	            case 4: return this.tColon;
	            case 5: return this.message;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitRefOutputGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitRefOutputGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RefOutputGreen(this.Kind, this.kEndRef, this.ignored, this.targetType, this.target, this.tColon, this.message, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RefOutputGreen(this.Kind, this.kEndRef, this.ignored, this.targetType, this.target, this.tColon, this.message, this.GetDiagnostics(), annotations);
	    }
	
	    public RefOutputGreen Update(InternalSyntaxToken kEndRef, TextGreen ignored, ArrowTypeGreen targetType, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen message)
	    {
	        if (this.KEndRef != kEndRef ||
				this.Ignored != ignored ||
				this.TargetType != targetType ||
				this.Target != target ||
				this.TColon != tColon ||
				this.Message != message)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.RefOutput(kEndRef, ignored, targetType, target, tColon, message);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefOutputGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class FragmentBodyGreen : GreenSyntaxNode
	{
	    internal static readonly FragmentBodyGreen __Missing = new FragmentBodyGreen();
	    private GreenNode line;
	
	    public FragmentBodyGreen(SequenceSyntaxKind kind, GreenNode line)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (line != null)
			{
				this.AdjustFlagsAndWidth(line);
				this.line = line;
			}
	    }
	
	    public FragmentBodyGreen(SequenceSyntaxKind kind, GreenNode line, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (line != null)
			{
				this.AdjustFlagsAndWidth(line);
				this.line = line;
			}
	    }
	
		private FragmentBodyGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.FragmentBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen> Line { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen>(this.line); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.FragmentBodySyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.line;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitFragmentBodyGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitFragmentBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FragmentBodyGreen(this.Kind, this.line, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FragmentBodyGreen(this.Kind, this.line, this.GetDiagnostics(), annotations);
	    }
	
	    public FragmentBodyGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen> line)
	    {
	        if (this.Line != line)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.FragmentBody(line);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FragmentBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndGreen : GreenSyntaxNode
	{
	    internal static readonly EndGreen __Missing = new EndGreen();
	    private InternalSyntaxToken kEnd;
	    private TextGreen text;
	
	    public EndGreen(SequenceSyntaxKind kind, InternalSyntaxToken kEnd, TextGreen text)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
	    public EndGreen(SequenceSyntaxKind kind, InternalSyntaxToken kEnd, TextGreen text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kEnd != null)
			{
				this.AdjustFlagsAndWidth(kEnd);
				this.kEnd = kEnd;
			}
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
		private EndGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.End, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnd { get { return this.kEnd; } }
	    public TextGreen Text { get { return this.text; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.EndSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnd;
	            case 1: return this.text;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitEndGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitEndGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndGreen(this.Kind, this.kEnd, this.text, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndGreen(this.Kind, this.kEnd, this.text, this.GetDiagnostics(), annotations);
	    }
	
	    public EndGreen Update(InternalSyntaxToken kEnd, TextGreen text)
	    {
	        if (this.KEnd != kEnd ||
				this.Text != text)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.End(kEnd, text);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NoteGreen : GreenSyntaxNode
	{
	    internal static readonly NoteGreen __Missing = new NoteGreen();
	    private SingleLineNoteGreen singleLineNote;
	    private MultiLineNoteGreen multiLineNote;
	
	    public NoteGreen(SequenceSyntaxKind kind, SingleLineNoteGreen singleLineNote, MultiLineNoteGreen multiLineNote)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (singleLineNote != null)
			{
				this.AdjustFlagsAndWidth(singleLineNote);
				this.singleLineNote = singleLineNote;
			}
			if (multiLineNote != null)
			{
				this.AdjustFlagsAndWidth(multiLineNote);
				this.multiLineNote = multiLineNote;
			}
	    }
	
	    public NoteGreen(SequenceSyntaxKind kind, SingleLineNoteGreen singleLineNote, MultiLineNoteGreen multiLineNote, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (singleLineNote != null)
			{
				this.AdjustFlagsAndWidth(singleLineNote);
				this.singleLineNote = singleLineNote;
			}
			if (multiLineNote != null)
			{
				this.AdjustFlagsAndWidth(multiLineNote);
				this.multiLineNote = multiLineNote;
			}
	    }
	
		private NoteGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Note, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SingleLineNoteGreen SingleLineNote { get { return this.singleLineNote; } }
	    public MultiLineNoteGreen MultiLineNote { get { return this.multiLineNote; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.NoteSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.singleLineNote;
	            case 1: return this.multiLineNote;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitNoteGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitNoteGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NoteGreen(this.Kind, this.singleLineNote, this.multiLineNote, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NoteGreen(this.Kind, this.singleLineNote, this.multiLineNote, this.GetDiagnostics(), annotations);
	    }
	
	    public NoteGreen Update(SingleLineNoteGreen singleLineNote)
	    {
	        if (this.singleLineNote != singleLineNote)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Note(singleLineNote);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NoteGreen)newNode;
	        }
	        return this;
	    }
	
	    public NoteGreen Update(MultiLineNoteGreen multiLineNote)
	    {
	        if (this.multiLineNote != multiLineNote)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Note(multiLineNote);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NoteGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SingleLineNoteGreen : GreenSyntaxNode
	{
	    internal static readonly SingleLineNoteGreen __Missing = new SingleLineNoteGreen();
	    private InternalSyntaxToken kNote;
	    private TextGreen position;
	    private InternalSyntaxToken tColon;
	    private TextGreen noteText;
	
	    public SingleLineNoteGreen(SequenceSyntaxKind kind, InternalSyntaxToken kNote, TextGreen position, InternalSyntaxToken tColon, TextGreen noteText)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kNote != null)
			{
				this.AdjustFlagsAndWidth(kNote);
				this.kNote = kNote;
			}
			if (position != null)
			{
				this.AdjustFlagsAndWidth(position);
				this.position = position;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (noteText != null)
			{
				this.AdjustFlagsAndWidth(noteText);
				this.noteText = noteText;
			}
	    }
	
	    public SingleLineNoteGreen(SequenceSyntaxKind kind, InternalSyntaxToken kNote, TextGreen position, InternalSyntaxToken tColon, TextGreen noteText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kNote != null)
			{
				this.AdjustFlagsAndWidth(kNote);
				this.kNote = kNote;
			}
			if (position != null)
			{
				this.AdjustFlagsAndWidth(position);
				this.position = position;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (noteText != null)
			{
				this.AdjustFlagsAndWidth(noteText);
				this.noteText = noteText;
			}
	    }
	
		private SingleLineNoteGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.SingleLineNote, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNote { get { return this.kNote; } }
	    public TextGreen Position { get { return this.position; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public TextGreen NoteText { get { return this.noteText; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.SingleLineNoteSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNote;
	            case 1: return this.position;
	            case 2: return this.tColon;
	            case 3: return this.noteText;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitSingleLineNoteGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitSingleLineNoteGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SingleLineNoteGreen(this.Kind, this.kNote, this.position, this.tColon, this.noteText, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SingleLineNoteGreen(this.Kind, this.kNote, this.position, this.tColon, this.noteText, this.GetDiagnostics(), annotations);
	    }
	
	    public SingleLineNoteGreen Update(InternalSyntaxToken kNote, TextGreen position, InternalSyntaxToken tColon, TextGreen noteText)
	    {
	        if (this.KNote != kNote ||
				this.Position != position ||
				this.TColon != tColon ||
				this.NoteText != noteText)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.SingleLineNote(kNote, position, tColon, noteText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleLineNoteGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MultiLineNoteGreen : GreenSyntaxNode
	{
	    internal static readonly MultiLineNoteGreen __Missing = new MultiLineNoteGreen();
	    private InternalSyntaxToken kNote;
	    private SimpleBodyGreen simpleBody;
	    private InternalSyntaxToken kEndNote;
	
	    public MultiLineNoteGreen(SequenceSyntaxKind kind, InternalSyntaxToken kNote, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndNote)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kNote != null)
			{
				this.AdjustFlagsAndWidth(kNote);
				this.kNote = kNote;
			}
			if (simpleBody != null)
			{
				this.AdjustFlagsAndWidth(simpleBody);
				this.simpleBody = simpleBody;
			}
			if (kEndNote != null)
			{
				this.AdjustFlagsAndWidth(kEndNote);
				this.kEndNote = kEndNote;
			}
	    }
	
	    public MultiLineNoteGreen(SequenceSyntaxKind kind, InternalSyntaxToken kNote, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndNote, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kNote != null)
			{
				this.AdjustFlagsAndWidth(kNote);
				this.kNote = kNote;
			}
			if (simpleBody != null)
			{
				this.AdjustFlagsAndWidth(simpleBody);
				this.simpleBody = simpleBody;
			}
			if (kEndNote != null)
			{
				this.AdjustFlagsAndWidth(kEndNote);
				this.kEndNote = kEndNote;
			}
	    }
	
		private MultiLineNoteGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.MultiLineNote, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNote { get { return this.kNote; } }
	    public SimpleBodyGreen SimpleBody { get { return this.simpleBody; } }
	    public InternalSyntaxToken KEndNote { get { return this.kEndNote; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.MultiLineNoteSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNote;
	            case 1: return this.simpleBody;
	            case 2: return this.kEndNote;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitMultiLineNoteGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitMultiLineNoteGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MultiLineNoteGreen(this.Kind, this.kNote, this.simpleBody, this.kEndNote, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MultiLineNoteGreen(this.Kind, this.kNote, this.simpleBody, this.kEndNote, this.GetDiagnostics(), annotations);
	    }
	
	    public MultiLineNoteGreen Update(InternalSyntaxToken kNote, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndNote)
	    {
	        if (this.KNote != kNote ||
				this.SimpleBody != simpleBody ||
				this.KEndNote != kEndNote)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.MultiLineNote(kNote, simpleBody, kEndNote);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiLineNoteGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleBodyGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleBodyGreen __Missing = new SimpleBodyGreen();
	    private GreenNode simpleLine;
	
	    public SimpleBodyGreen(SequenceSyntaxKind kind, GreenNode simpleLine)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (simpleLine != null)
			{
				this.AdjustFlagsAndWidth(simpleLine);
				this.simpleLine = simpleLine;
			}
	    }
	
	    public SimpleBodyGreen(SequenceSyntaxKind kind, GreenNode simpleLine, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (simpleLine != null)
			{
				this.AdjustFlagsAndWidth(simpleLine);
				this.simpleLine = simpleLine;
			}
	    }
	
		private SimpleBodyGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.SimpleBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SimpleLineGreen> SimpleLine { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SimpleLineGreen>(this.simpleLine); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.SimpleBodySyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleLine;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleBodyGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitSimpleBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleBodyGreen(this.Kind, this.simpleLine, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleBodyGreen(this.Kind, this.simpleLine, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleBodyGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SimpleLineGreen> simpleLine)
	    {
	        if (this.SimpleLine != simpleLine)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.SimpleBody(simpleLine);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SimpleLineGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleLineGreen __Missing = new SimpleLineGreen();
	    private TextGreen text;
	    private InternalSyntaxToken lCrLf;
	
	    public SimpleLineGreen(SequenceSyntaxKind kind, TextGreen text, InternalSyntaxToken lCrLf)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
	    }
	
	    public SimpleLineGreen(SequenceSyntaxKind kind, TextGreen text, InternalSyntaxToken lCrLf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
			if (lCrLf != null)
			{
				this.AdjustFlagsAndWidth(lCrLf);
				this.lCrLf = lCrLf;
			}
	    }
	
		private SimpleLineGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.SimpleLine, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TextGreen Text { get { return this.text; } }
	    public InternalSyntaxToken LCrLf { get { return this.lCrLf; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.SimpleLineSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.text;
	            case 1: return this.lCrLf;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleLineGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitSimpleLineGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleLineGreen(this.Kind, this.text, this.lCrLf, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleLineGreen(this.Kind, this.text, this.lCrLf, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleLineGreen Update(TextGreen text, InternalSyntaxToken lCrLf)
	    {
	        if (this.Text != text ||
				this.LCrLf != lCrLf)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.SimpleLine(text, lCrLf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleLineGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrowTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ArrowTypeGreen __Missing = new ArrowTypeGreen();
	    private InternalSyntaxToken arrowType;
	
	    public ArrowTypeGreen(SequenceSyntaxKind kind, InternalSyntaxToken arrowType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (arrowType != null)
			{
				this.AdjustFlagsAndWidth(arrowType);
				this.arrowType = arrowType;
			}
	    }
	
	    public ArrowTypeGreen(SequenceSyntaxKind kind, InternalSyntaxToken arrowType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (arrowType != null)
			{
				this.AdjustFlagsAndWidth(arrowType);
				this.arrowType = arrowType;
			}
	    }
	
		private ArrowTypeGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.ArrowType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ArrowType { get { return this.arrowType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.ArrowTypeSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arrowType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitArrowTypeGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitArrowTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrowTypeGreen(this.Kind, this.arrowType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrowTypeGreen(this.Kind, this.arrowType, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrowTypeGreen Update(InternalSyntaxToken arrowType)
	    {
	        if (this.ArrowType != arrowType)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.ArrowType(arrowType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrowTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LifeLineNameGreen : GreenSyntaxNode
	{
	    internal static readonly LifeLineNameGreen __Missing = new LifeLineNameGreen();
	    private NameGreen name;
	
	    public LifeLineNameGreen(SequenceSyntaxKind kind, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public LifeLineNameGreen(SequenceSyntaxKind kind, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private LifeLineNameGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.LifeLineName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.LifeLineNameSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitLifeLineNameGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitLifeLineNameGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LifeLineNameGreen(this.Kind, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LifeLineNameGreen(this.Kind, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public LifeLineNameGreen Update(NameGreen name)
	    {
	        if (this.Name != name)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.LifeLineName(name);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LifeLineNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameGreen : GreenSyntaxNode
	{
	    internal static readonly NameGreen __Missing = new NameGreen();
	    private IdentifierGreen identifier;
	
	    public NameGreen(SequenceSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(SequenceSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.NameSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
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
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	internal class IdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierGreen __Missing = new IdentifierGreen();
	    private TextGreen text;
	
	    public IdentifierGreen(SequenceSyntaxKind kind, TextGreen text)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
	    public IdentifierGreen(SequenceSyntaxKind kind, TextGreen text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (text != null)
			{
				this.AdjustFlagsAndWidth(text);
				this.text = text;
			}
	    }
	
		private IdentifierGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TextGreen Text { get { return this.text; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.IdentifierSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.text;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.text, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.text, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(TextGreen text)
	    {
	        if (this.Text != text)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Identifier(text);
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
	
	internal class TextGreen : GreenSyntaxNode
	{
	    internal static readonly TextGreen __Missing = new TextGreen();
	    private GreenNode identifierPart;
	
	    public TextGreen(SequenceSyntaxKind kind, GreenNode identifierPart)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifierPart != null)
			{
				this.AdjustFlagsAndWidth(identifierPart);
				this.identifierPart = identifierPart;
			}
	    }
	
	    public TextGreen(SequenceSyntaxKind kind, GreenNode identifierPart, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifierPart != null)
			{
				this.AdjustFlagsAndWidth(identifierPart);
				this.identifierPart = identifierPart;
			}
	    }
	
		private TextGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.Text, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<IdentifierPartGreen> IdentifierPart { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<IdentifierPartGreen>(this.identifierPart); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.TextSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifierPart;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitTextGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitTextGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TextGreen(this.Kind, this.identifierPart, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TextGreen(this.Kind, this.identifierPart, this.GetDiagnostics(), annotations);
	    }
	
	    public TextGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<IdentifierPartGreen> identifierPart)
	    {
	        if (this.IdentifierPart != identifierPart)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.Text(identifierPart);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierPartGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierPartGreen __Missing = new IdentifierPartGreen();
	    private InternalSyntaxToken lIdentifier;
	
	    public IdentifierPartGreen(SequenceSyntaxKind kind, InternalSyntaxToken lIdentifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lIdentifier);
				this.lIdentifier = lIdentifier;
			}
	    }
	
	    public IdentifierPartGreen(SequenceSyntaxKind kind, InternalSyntaxToken lIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (lIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lIdentifier);
				this.lIdentifier = lIdentifier;
			}
	    }
	
		private IdentifierPartGreen()
			: base((SequenceSyntaxKind)SequenceSyntaxKind.IdentifierPart, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LIdentifier { get { return this.lIdentifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::WebSequenceDiagramsModel.Syntax.IdentifierPartSyntax(this, (SequenceSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lIdentifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SequenceSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierPartGreen(this);
	
	    public override void Accept(SequenceSyntaxVisitor visitor) => visitor.VisitIdentifierPartGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierPartGreen(this.Kind, this.lIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierPartGreen(this.Kind, this.lIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierPartGreen Update(InternalSyntaxToken lIdentifier)
	    {
	        if (this.LIdentifier != lIdentifier)
	        {
	            InternalSyntaxNode newNode = SequenceLanguage.Instance.InternalSyntaxFactory.IdentifierPart(lIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierPartGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class SequenceSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitInteractionGreen(InteractionGreen node) => this.DefaultVisit(node);
		public virtual void VisitLineGreen(LineGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitTitleGreen(TitleGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrowGreen(ArrowGreen node) => this.DefaultVisit(node);
		public virtual void VisitDestroyGreen(DestroyGreen node) => this.DefaultVisit(node);
		public virtual void VisitAltGreen(AltGreen node) => this.DefaultVisit(node);
		public virtual void VisitAltFragmentGreen(AltFragmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitElseFragmentGreen(ElseFragmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopGreen(LoopGreen node) => this.DefaultVisit(node);
		public virtual void VisitLoopFragmentGreen(LoopFragmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitOptGreen(OptGreen node) => this.DefaultVisit(node);
		public virtual void VisitOptFragmentGreen(OptFragmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitRefGreen(RefGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleRefFragmentGreen(SimpleRefFragmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitMessageRefFragmentGreen(MessageRefFragmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitRefInputGreen(RefInputGreen node) => this.DefaultVisit(node);
		public virtual void VisitRefOutputGreen(RefOutputGreen node) => this.DefaultVisit(node);
		public virtual void VisitFragmentBodyGreen(FragmentBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndGreen(EndGreen node) => this.DefaultVisit(node);
		public virtual void VisitNoteGreen(NoteGreen node) => this.DefaultVisit(node);
		public virtual void VisitSingleLineNoteGreen(SingleLineNoteGreen node) => this.DefaultVisit(node);
		public virtual void VisitMultiLineNoteGreen(MultiLineNoteGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleBodyGreen(SimpleBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleLineGreen(SimpleLineGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrowTypeGreen(ArrowTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitLifeLineNameGreen(LifeLineNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitTextGreen(TextGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierPartGreen(IdentifierPartGreen node) => this.DefaultVisit(node);
	}
	
	internal class SequenceSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInteractionGreen(InteractionGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLineGreen(LineGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTitleGreen(TitleGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrowGreen(ArrowGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDestroyGreen(DestroyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAltGreen(AltGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAltFragmentGreen(AltFragmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitElseFragmentGreen(ElseFragmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopGreen(LoopGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLoopFragmentGreen(LoopFragmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOptGreen(OptGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOptFragmentGreen(OptFragmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRefGreen(RefGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleRefFragmentGreen(SimpleRefFragmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMessageRefFragmentGreen(MessageRefFragmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRefInputGreen(RefInputGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRefOutputGreen(RefOutputGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFragmentBodyGreen(FragmentBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndGreen(EndGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNoteGreen(NoteGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSingleLineNoteGreen(SingleLineNoteGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMultiLineNoteGreen(MultiLineNoteGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleBodyGreen(SimpleBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleLineGreen(SimpleLineGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrowTypeGreen(ArrowTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLifeLineNameGreen(LifeLineNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTextGreen(TextGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierPartGreen(IdentifierPartGreen node) => this.DefaultVisit(node);
	}
	internal class SequenceInternalSyntaxFactory : InternalSyntaxFactory
	{
		public SequenceInternalSyntaxFactory(SequenceSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public override Language Language => SequenceLanguage.Instance;
	
		private SequenceSyntaxKind ToMetaSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<SequenceSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToMetaSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToMetaSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToMetaSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToMetaSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToMetaSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			SequenceSyntaxKind typedKind = ToMetaSyntaxKind(kind);
	        Debug.Assert(SequenceLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = SequenceLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			SequenceSyntaxKind typedKind = ToMetaSyntaxKind(kind);
	        Debug.Assert(SequenceLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = SequenceLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			SequenceSyntaxKind typedKind = ToMetaSyntaxKind(kind);
	        Debug.Assert(SequenceLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = SequenceLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToMetaSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToMetaSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToMetaSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCommentStart(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LCommentStart, text, null);
	    }
	
	    internal InternalSyntaxToken LCommentStart(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LCommentStart, text, value, null);
	    }
	
	    internal InternalSyntaxToken TCreate(string text)
	    {
	        return Token(null, SequenceSyntaxKind.TCreate, text, null);
	    }
	
	    internal InternalSyntaxToken TCreate(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.TCreate, text, value, null);
	    }
	
	    internal InternalSyntaxToken TReturn(string text)
	    {
	        return Token(null, SequenceSyntaxKind.TReturn, text, null);
	    }
	
	    internal InternalSyntaxToken TReturn(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.TReturn, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LIdentifier(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LIdentifier, text, null);
	    }
	
	    internal InternalSyntaxToken LIdentifier(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LIdentifier, text, value, null);
	    }
	
	    internal InternalSyntaxToken NoteWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.NoteWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken NoteWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.NoteWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken NoteLinesWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.NoteLinesWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken NoteLinesWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.NoteLinesWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken RefWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.RefWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken RefWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.RefWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken RefLinesWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.RefLinesWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken RefLinesWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.RefLinesWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken RefEndWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.RefEndWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken RefEndWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.RefEndWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LineEndWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.LineEndWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LineEndWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.LineEndWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken ArrowEndWhiteSpace(string text)
	    {
	        return Token(null, SequenceSyntaxKind.ArrowEndWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken ArrowEndWhiteSpace(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.ArrowEndWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken TMinus(string text)
	    {
	        return Token(null, SequenceSyntaxKind.TMinus, text, null);
	    }
	
	    internal InternalSyntaxToken TMinus(string text, object value)
	    {
	        return Token(null, SequenceSyntaxKind.TMinus, text, value, null);
	    }
	
		public MainGreen Main(InteractionGreen interaction, InternalSyntaxToken eof)
	    {
	#if DEBUG
			if (interaction == null) throw new ArgumentNullException(nameof(interaction));
			if (eof == null) throw new ArgumentNullException(nameof(eof));
			if (eof.Kind != SequenceSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Main, interaction, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(SequenceSyntaxKind.Main, interaction, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InteractionGreen Interaction(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen> line)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Interaction, line.Node, out hash);
			if (cached != null) return (InteractionGreen)cached;
			var result = new InteractionGreen(SequenceSyntaxKind.Interaction, line.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LineGreen Line(DeclarationGreen declaration, InternalSyntaxToken lCrLf)
	    {
	#if DEBUG
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Line, declaration, lCrLf, out hash);
			if (cached != null) return (LineGreen)cached;
			var result = new LineGreen(SequenceSyntaxKind.Line, declaration, lCrLf);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(TitleGreen title)
	    {
	#if DEBUG
		    if (title == null) throw new ArgumentNullException(nameof(title));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, title, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(DestroyGreen destroy)
	    {
	#if DEBUG
		    if (destroy == null) throw new ArgumentNullException(nameof(destroy));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, destroy, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ArrowGreen arrow)
	    {
	#if DEBUG
		    if (arrow == null) throw new ArgumentNullException(nameof(arrow));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, null, arrow, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(AltGreen alt)
	    {
	#if DEBUG
		    if (alt == null) throw new ArgumentNullException(nameof(alt));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, null, null, alt, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(OptGreen opt)
	    {
	#if DEBUG
		    if (opt == null) throw new ArgumentNullException(nameof(opt));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, null, null, null, opt, null, null, null);
	    }
	
		public DeclarationGreen Declaration(LoopGreen loop)
	    {
	#if DEBUG
		    if (loop == null) throw new ArgumentNullException(nameof(loop));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, null, null, null, null, loop, null, null);
	    }
	
		public DeclarationGreen Declaration(RefGreen _ref)
	    {
	#if DEBUG
		    if (_ref == null) throw new ArgumentNullException(nameof(_ref));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, null, null, null, null, null, _ref, null);
	    }
	
		public DeclarationGreen Declaration(NoteGreen note)
	    {
	#if DEBUG
		    if (note == null) throw new ArgumentNullException(nameof(note));
	#endif
			return new DeclarationGreen(SequenceSyntaxKind.Declaration, null, null, null, null, null, null, null, note);
	    }
	
		public TitleGreen Title(InternalSyntaxToken kTitle, TextGreen text)
	    {
	#if DEBUG
			if (kTitle == null) throw new ArgumentNullException(nameof(kTitle));
			if (kTitle.Kind != SequenceSyntaxKind.KTitle) throw new ArgumentException(nameof(kTitle));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Title, kTitle, text, out hash);
			if (cached != null) return (TitleGreen)cached;
			var result = new TitleGreen(SequenceSyntaxKind.Title, kTitle, text);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrowGreen Arrow(LifeLineNameGreen source, ArrowTypeGreen type, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen text)
	    {
	#if DEBUG
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
	        return new ArrowGreen(SequenceSyntaxKind.Arrow, source, type, target, tColon, text);
	    }
	
		public DestroyGreen Destroy(InternalSyntaxToken kDestroy, LifeLineNameGreen lifeLineName)
	    {
	#if DEBUG
			if (kDestroy == null) throw new ArgumentNullException(nameof(kDestroy));
			if (kDestroy.Kind != SequenceSyntaxKind.KDestroy) throw new ArgumentException(nameof(kDestroy));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Destroy, kDestroy, lifeLineName, out hash);
			if (cached != null) return (DestroyGreen)cached;
			var result = new DestroyGreen(SequenceSyntaxKind.Destroy, kDestroy, lifeLineName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AltGreen Alt(AltFragmentGreen altFragment, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ElseFragmentGreen> elseFragment, EndGreen end)
	    {
	#if DEBUG
			if (altFragment == null) throw new ArgumentNullException(nameof(altFragment));
			if (end == null) throw new ArgumentNullException(nameof(end));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Alt, altFragment, elseFragment.Node, end, out hash);
			if (cached != null) return (AltGreen)cached;
			var result = new AltGreen(SequenceSyntaxKind.Alt, altFragment, elseFragment.Node, end);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AltFragmentGreen AltFragment(InternalSyntaxToken kAlt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	#if DEBUG
			if (kAlt == null) throw new ArgumentNullException(nameof(kAlt));
			if (kAlt.Kind != SequenceSyntaxKind.KAlt) throw new ArgumentException(nameof(kAlt));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
			if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
	#endif
	        return new AltFragmentGreen(SequenceSyntaxKind.AltFragment, kAlt, condition, lCrLf, fragmentBody);
	    }
	
		public ElseFragmentGreen ElseFragment(InternalSyntaxToken kElse, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	#if DEBUG
			if (kElse == null) throw new ArgumentNullException(nameof(kElse));
			if (kElse.Kind != SequenceSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
			if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
	#endif
	        return new ElseFragmentGreen(SequenceSyntaxKind.ElseFragment, kElse, condition, lCrLf, fragmentBody);
	    }
	
		public LoopGreen Loop(LoopFragmentGreen loopFragment, EndGreen end)
	    {
	#if DEBUG
			if (loopFragment == null) throw new ArgumentNullException(nameof(loopFragment));
			if (end == null) throw new ArgumentNullException(nameof(end));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Loop, loopFragment, end, out hash);
			if (cached != null) return (LoopGreen)cached;
			var result = new LoopGreen(SequenceSyntaxKind.Loop, loopFragment, end);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LoopFragmentGreen LoopFragment(InternalSyntaxToken kLoop, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	#if DEBUG
			if (kLoop == null) throw new ArgumentNullException(nameof(kLoop));
			if (kLoop.Kind != SequenceSyntaxKind.KLoop) throw new ArgumentException(nameof(kLoop));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
			if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
	#endif
	        return new LoopFragmentGreen(SequenceSyntaxKind.LoopFragment, kLoop, condition, lCrLf, fragmentBody);
	    }
	
		public OptGreen Opt(OptFragmentGreen optFragment, EndGreen end)
	    {
	#if DEBUG
			if (optFragment == null) throw new ArgumentNullException(nameof(optFragment));
			if (end == null) throw new ArgumentNullException(nameof(end));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Opt, optFragment, end, out hash);
			if (cached != null) return (OptGreen)cached;
			var result = new OptGreen(SequenceSyntaxKind.Opt, optFragment, end);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OptFragmentGreen OptFragment(InternalSyntaxToken kOpt, TextGreen condition, InternalSyntaxToken lCrLf, FragmentBodyGreen fragmentBody)
	    {
	#if DEBUG
			if (kOpt == null) throw new ArgumentNullException(nameof(kOpt));
			if (kOpt.Kind != SequenceSyntaxKind.KOpt) throw new ArgumentException(nameof(kOpt));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
			if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
	#endif
	        return new OptFragmentGreen(SequenceSyntaxKind.OptFragment, kOpt, condition, lCrLf, fragmentBody);
	    }
	
		public RefGreen Ref(SimpleRefFragmentGreen simpleRefFragment)
	    {
	#if DEBUG
		    if (simpleRefFragment == null) throw new ArgumentNullException(nameof(simpleRefFragment));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Ref, simpleRefFragment, out hash);
			if (cached != null) return (RefGreen)cached;
			var result = new RefGreen(SequenceSyntaxKind.Ref, simpleRefFragment, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RefGreen Ref(MessageRefFragmentGreen messageRefFragment)
	    {
	#if DEBUG
		    if (messageRefFragment == null) throw new ArgumentNullException(nameof(messageRefFragment));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Ref, messageRefFragment, out hash);
			if (cached != null) return (RefGreen)cached;
			var result = new RefGreen(SequenceSyntaxKind.Ref, null, messageRefFragment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleRefFragmentGreen SimpleRefFragment(InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen refText, InternalSyntaxToken lCrLf, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndRef)
	    {
	#if DEBUG
			if (kRef == null) throw new ArgumentNullException(nameof(kRef));
			if (kRef.Kind != SequenceSyntaxKind.KRef) throw new ArgumentException(nameof(kRef));
			if (tColon != null && tColon.Kind != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
			if (simpleBody == null) throw new ArgumentNullException(nameof(simpleBody));
			if (kEndRef == null) throw new ArgumentNullException(nameof(kEndRef));
			if (kEndRef.Kind != SequenceSyntaxKind.KEndRef) throw new ArgumentException(nameof(kEndRef));
	#endif
	        return new SimpleRefFragmentGreen(SequenceSyntaxKind.SimpleRefFragment, kRef, over, tColon, refText, lCrLf, simpleBody, kEndRef);
	    }
	
		public MessageRefFragmentGreen MessageRefFragment(RefInputGreen refInput, SimpleBodyGreen simpleBody, RefOutputGreen refOutput)
	    {
	#if DEBUG
			if (refInput == null) throw new ArgumentNullException(nameof(refInput));
			if (simpleBody == null) throw new ArgumentNullException(nameof(simpleBody));
			if (refOutput == null) throw new ArgumentNullException(nameof(refOutput));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.MessageRefFragment, refInput, simpleBody, refOutput, out hash);
			if (cached != null) return (MessageRefFragmentGreen)cached;
			var result = new MessageRefFragmentGreen(SequenceSyntaxKind.MessageRefFragment, refInput, simpleBody, refOutput);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RefInputGreen RefInput(LifeLineNameGreen source, ArrowTypeGreen sourceType, InternalSyntaxToken kRef, TextGreen over, InternalSyntaxToken tColon, TextGreen message, InternalSyntaxToken lCrLf)
	    {
	#if DEBUG
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
			if (kRef == null) throw new ArgumentNullException(nameof(kRef));
			if (kRef.Kind != SequenceSyntaxKind.KRef) throw new ArgumentException(nameof(kRef));
			if (tColon != null && tColon.Kind != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
	#endif
	        return new RefInputGreen(SequenceSyntaxKind.RefInput, source, sourceType, kRef, over, tColon, message, lCrLf);
	    }
	
		public RefOutputGreen RefOutput(InternalSyntaxToken kEndRef, TextGreen ignored, ArrowTypeGreen targetType, LifeLineNameGreen target, InternalSyntaxToken tColon, TextGreen message)
	    {
	#if DEBUG
			if (kEndRef == null) throw new ArgumentNullException(nameof(kEndRef));
			if (kEndRef.Kind != SequenceSyntaxKind.KEndRef) throw new ArgumentException(nameof(kEndRef));
			if (targetType == null) throw new ArgumentNullException(nameof(targetType));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
	#endif
	        return new RefOutputGreen(SequenceSyntaxKind.RefOutput, kEndRef, ignored, targetType, target, tColon, message);
	    }
	
		public FragmentBodyGreen FragmentBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<LineGreen> line)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.FragmentBody, line.Node, out hash);
			if (cached != null) return (FragmentBodyGreen)cached;
			var result = new FragmentBodyGreen(SequenceSyntaxKind.FragmentBody, line.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndGreen End(InternalSyntaxToken kEnd, TextGreen text)
	    {
	#if DEBUG
			if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
			if (kEnd.Kind != SequenceSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.End, kEnd, text, out hash);
			if (cached != null) return (EndGreen)cached;
			var result = new EndGreen(SequenceSyntaxKind.End, kEnd, text);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NoteGreen Note(SingleLineNoteGreen singleLineNote)
	    {
	#if DEBUG
		    if (singleLineNote == null) throw new ArgumentNullException(nameof(singleLineNote));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Note, singleLineNote, out hash);
			if (cached != null) return (NoteGreen)cached;
			var result = new NoteGreen(SequenceSyntaxKind.Note, singleLineNote, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NoteGreen Note(MultiLineNoteGreen multiLineNote)
	    {
	#if DEBUG
		    if (multiLineNote == null) throw new ArgumentNullException(nameof(multiLineNote));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Note, multiLineNote, out hash);
			if (cached != null) return (NoteGreen)cached;
			var result = new NoteGreen(SequenceSyntaxKind.Note, null, multiLineNote);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SingleLineNoteGreen SingleLineNote(InternalSyntaxToken kNote, TextGreen position, InternalSyntaxToken tColon, TextGreen noteText)
	    {
	#if DEBUG
			if (kNote == null) throw new ArgumentNullException(nameof(kNote));
			if (kNote.Kind != SequenceSyntaxKind.KNote) throw new ArgumentException(nameof(kNote));
			if (position == null) throw new ArgumentNullException(nameof(position));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (noteText == null) throw new ArgumentNullException(nameof(noteText));
	#endif
	        return new SingleLineNoteGreen(SequenceSyntaxKind.SingleLineNote, kNote, position, tColon, noteText);
	    }
	
		public MultiLineNoteGreen MultiLineNote(InternalSyntaxToken kNote, SimpleBodyGreen simpleBody, InternalSyntaxToken kEndNote)
	    {
	#if DEBUG
			if (kNote == null) throw new ArgumentNullException(nameof(kNote));
			if (kNote.Kind != SequenceSyntaxKind.KNote) throw new ArgumentException(nameof(kNote));
			if (simpleBody == null) throw new ArgumentNullException(nameof(simpleBody));
			if (kEndNote == null) throw new ArgumentNullException(nameof(kEndNote));
			if (kEndNote.Kind != SequenceSyntaxKind.KEndNote) throw new ArgumentException(nameof(kEndNote));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.MultiLineNote, kNote, simpleBody, kEndNote, out hash);
			if (cached != null) return (MultiLineNoteGreen)cached;
			var result = new MultiLineNoteGreen(SequenceSyntaxKind.MultiLineNote, kNote, simpleBody, kEndNote);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleBodyGreen SimpleBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SimpleLineGreen> simpleLine)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.SimpleBody, simpleLine.Node, out hash);
			if (cached != null) return (SimpleBodyGreen)cached;
			var result = new SimpleBodyGreen(SequenceSyntaxKind.SimpleBody, simpleLine.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleLineGreen SimpleLine(TextGreen text, InternalSyntaxToken lCrLf)
	    {
	#if DEBUG
			if (text == null) throw new ArgumentNullException(nameof(text));
			if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
			if (lCrLf.Kind != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.SimpleLine, text, lCrLf, out hash);
			if (cached != null) return (SimpleLineGreen)cached;
			var result = new SimpleLineGreen(SequenceSyntaxKind.SimpleLine, text, lCrLf);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrowTypeGreen ArrowType(InternalSyntaxToken arrowType)
	    {
	#if DEBUG
			if (arrowType == null) throw new ArgumentNullException(nameof(arrowType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.ArrowType, arrowType, out hash);
			if (cached != null) return (ArrowTypeGreen)cached;
			var result = new ArrowTypeGreen(SequenceSyntaxKind.ArrowType, arrowType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LifeLineNameGreen LifeLineName(NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.LifeLineName, name, out hash);
			if (cached != null) return (LifeLineNameGreen)cached;
			var result = new LifeLineNameGreen(SequenceSyntaxKind.LifeLineName, name);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(SequenceSyntaxKind.Name, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(TextGreen text)
	    {
	#if DEBUG
			if (text == null) throw new ArgumentNullException(nameof(text));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Identifier, text, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(SequenceSyntaxKind.Identifier, text);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TextGreen Text(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<IdentifierPartGreen> identifierPart)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.Text, identifierPart.Node, out hash);
			if (cached != null) return (TextGreen)cached;
			var result = new TextGreen(SequenceSyntaxKind.Text, identifierPart.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierPartGreen IdentifierPart(InternalSyntaxToken lIdentifier)
	    {
	#if DEBUG
			if (lIdentifier == null) throw new ArgumentNullException(nameof(lIdentifier));
			if (lIdentifier.Kind != SequenceSyntaxKind.LIdentifier) throw new ArgumentException(nameof(lIdentifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SequenceSyntaxKind)SequenceSyntaxKind.IdentifierPart, lIdentifier, out hash);
			if (cached != null) return (IdentifierPartGreen)cached;
			var result = new IdentifierPartGreen(SequenceSyntaxKind.IdentifierPart, lIdentifier);
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
				typeof(InteractionGreen),
				typeof(LineGreen),
				typeof(DeclarationGreen),
				typeof(TitleGreen),
				typeof(ArrowGreen),
				typeof(DestroyGreen),
				typeof(AltGreen),
				typeof(AltFragmentGreen),
				typeof(ElseFragmentGreen),
				typeof(LoopGreen),
				typeof(LoopFragmentGreen),
				typeof(OptGreen),
				typeof(OptFragmentGreen),
				typeof(RefGreen),
				typeof(SimpleRefFragmentGreen),
				typeof(MessageRefFragmentGreen),
				typeof(RefInputGreen),
				typeof(RefOutputGreen),
				typeof(FragmentBodyGreen),
				typeof(EndGreen),
				typeof(NoteGreen),
				typeof(SingleLineNoteGreen),
				typeof(MultiLineNoteGreen),
				typeof(SimpleBodyGreen),
				typeof(SimpleLineGreen),
				typeof(ArrowTypeGreen),
				typeof(LifeLineNameGreen),
				typeof(NameGreen),
				typeof(IdentifierGreen),
				typeof(TextGreen),
				typeof(IdentifierPartGreen),
			};
		}
	}
}


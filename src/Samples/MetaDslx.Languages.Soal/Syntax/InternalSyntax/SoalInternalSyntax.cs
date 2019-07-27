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

namespace MetaDslx.Languages.Soal.Syntax.InternalSyntax
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
            if (visitor is SoalSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is SoalSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor);
        public abstract void Accept(SoalSyntaxVisitor visitor);

        public new SoalLanguage Language => SoalLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new SoalSyntaxKind Kind => (SoalSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;
	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(SoalSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new SoalLanguage Language => SoalLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new SoalSyntaxKind Kind => EnumObject.FromIntUnsafe<SoalSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(SoalSyntaxKind kind, string text)
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
	    internal GreenSyntaxToken(SoalSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(SoalSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(SoalSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(SoalSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new SoalLanguage Language => SoalLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new SoalSyntaxKind Kind => EnumObject.FromIntUnsafe<SoalSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(SoalSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!SoalLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid SoalSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!SoalLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid SoalSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == SoalLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == SoalLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == SoalLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == SoalLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly SoalSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly SoalSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = SoalSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = SoalSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = SoalLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((SoalSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((SoalSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((SoalSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((SoalSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(SoalSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(SoalSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(SoalSyntaxKind kind, SoalSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(SoalSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(SoalSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public virtual SoalSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(SoalSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(SoalSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly SoalSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(SoalSyntaxKind kind, SoalSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(SoalSyntaxKind kind, SoalSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<SoalSyntaxKind>(reader.ReadInt32());
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
	        public override SoalSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(SoalSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(SoalSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            SoalSyntaxKind kind,
	            SoalSyntaxKind contextualKind,
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
	            SoalSyntaxKind kind,
	            SoalSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(SoalSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(SoalSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(SoalSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            SoalSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    private GreenNode namespaceDeclaration;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(SoalSyntaxKind kind, GreenNode namespaceDeclaration, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (namespaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration);
				this.namespaceDeclaration = namespaceDeclaration;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
	    public MainGreen(SoalSyntaxKind kind, GreenNode namespaceDeclaration, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (namespaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(namespaceDeclaration);
				this.namespaceDeclaration = namespaceDeclaration;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
		private MainGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclarationGreen> NamespaceDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclarationGreen>(this.namespaceDeclaration); } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eof; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.MainSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.namespaceDeclaration;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclarationGreen> namespaceDeclaration, InternalSyntaxToken eof)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.EndOfFileToken != eof)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, eof);
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
	
	    public NameGreen(SoalSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(SoalSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NameSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	    public QualifiedNameGreen(SoalSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(SoalSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.QualifiedNameSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	    public QualifierGreen(SoalSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(SoalSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.QualifierSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	internal class IdentifierListGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierListGreen __Missing = new IdentifierListGreen();
	    private GreenNode identifier;
	
	    public IdentifierListGreen(SoalSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierListGreen(SoalSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.IdentifierList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IdentifierListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitIdentifierListGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.IdentifierList(identifier);
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
	
	internal class QualifierListGreen : GreenSyntaxNode
	{
	    internal static readonly QualifierListGreen __Missing = new QualifierListGreen();
	    private GreenNode qualifier;
	
	    public QualifierListGreen(SoalSyntaxKind kind, GreenNode qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifierListGreen(SoalSyntaxKind kind, GreenNode qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.QualifierList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> Qualifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen>(this.qualifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.QualifierListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitQualifierListGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.QualifierList(qualifier);
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
	
	internal class AnnotationListGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationListGreen __Missing = new AnnotationListGreen();
	    private GreenNode annotation;
	
	    public AnnotationListGreen(SoalSyntaxKind kind, GreenNode annotation)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
	    }
	
	    public AnnotationListGreen(SoalSyntaxKind kind, GreenNode annotation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
	    }
	
		private AnnotationListGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AnnotationList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> Annotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen>(this.annotation); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationListGreen(this.Kind, this.annotation, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationListGreen(this.Kind, this.annotation, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation)
	    {
	        if (this.Annotation != annotation)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationList(annotation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnAnnotationListGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnAnnotationListGreen __Missing = new ReturnAnnotationListGreen();
	    private GreenNode returnAnnotation;
	
	    public ReturnAnnotationListGreen(SoalSyntaxKind kind, GreenNode returnAnnotation)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (returnAnnotation != null)
			{
				this.AdjustFlagsAndWidth(returnAnnotation);
				this.returnAnnotation = returnAnnotation;
			}
	    }
	
	    public ReturnAnnotationListGreen(SoalSyntaxKind kind, GreenNode returnAnnotation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (returnAnnotation != null)
			{
				this.AdjustFlagsAndWidth(returnAnnotation);
				this.returnAnnotation = returnAnnotation;
			}
	    }
	
		private ReturnAnnotationListGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ReturnAnnotationList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ReturnAnnotationGreen> ReturnAnnotation { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ReturnAnnotationGreen>(this.returnAnnotation); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReturnAnnotationListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.returnAnnotation;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitReturnAnnotationListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitReturnAnnotationListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnAnnotationListGreen(this.Kind, this.returnAnnotation, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnAnnotationListGreen(this.Kind, this.returnAnnotation, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnAnnotationListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ReturnAnnotationGreen> returnAnnotation)
	    {
	        if (this.ReturnAnnotation != returnAnnotation)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnAnnotationList(returnAnnotation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnAnnotationListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationGreen __Missing = new AnnotationGreen();
	    private InternalSyntaxToken tOpenBracket;
	    private AnnotationHeadGreen annotationHead;
	    private InternalSyntaxToken tCloseBracket;
	
	    public AnnotationGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (annotationHead != null)
			{
				this.AdjustFlagsAndWidth(annotationHead);
				this.annotationHead = annotationHead;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public AnnotationGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (annotationHead != null)
			{
				this.AdjustFlagsAndWidth(annotationHead);
				this.annotationHead = annotationHead;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private AnnotationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.Annotation, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public AnnotationHeadGreen AnnotationHead { get { return this.annotationHead; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.annotationHead;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.annotationHead, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.annotationHead, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationGreen Update(InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.AnnotationHead != annotationHead ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Annotation(tOpenBracket, annotationHead, tCloseBracket);
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
	
	internal class ReturnAnnotationGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnAnnotationGreen __Missing = new ReturnAnnotationGreen();
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken kReturn;
	    private InternalSyntaxToken tColon;
	    private AnnotationHeadGreen annotationHead;
	    private InternalSyntaxToken tCloseBracket;
	
	    public ReturnAnnotationGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (kReturn != null)
			{
				this.AdjustFlagsAndWidth(kReturn);
				this.kReturn = kReturn;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (annotationHead != null)
			{
				this.AdjustFlagsAndWidth(annotationHead);
				this.annotationHead = annotationHead;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
	    public ReturnAnnotationGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (tOpenBracket != null)
			{
				this.AdjustFlagsAndWidth(tOpenBracket);
				this.tOpenBracket = tOpenBracket;
			}
			if (kReturn != null)
			{
				this.AdjustFlagsAndWidth(kReturn);
				this.kReturn = kReturn;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (annotationHead != null)
			{
				this.AdjustFlagsAndWidth(annotationHead);
				this.annotationHead = annotationHead;
			}
			if (tCloseBracket != null)
			{
				this.AdjustFlagsAndWidth(tCloseBracket);
				this.tCloseBracket = tCloseBracket;
			}
	    }
	
		private ReturnAnnotationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ReturnAnnotation, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken KReturn { get { return this.kReturn; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public AnnotationHeadGreen AnnotationHead { get { return this.annotationHead; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReturnAnnotationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.kReturn;
	            case 2: return this.tColon;
	            case 3: return this.annotationHead;
	            case 4: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitReturnAnnotationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitReturnAnnotationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnAnnotationGreen(this.Kind, this.tOpenBracket, this.kReturn, this.tColon, this.annotationHead, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnAnnotationGreen(this.Kind, this.tOpenBracket, this.kReturn, this.tColon, this.annotationHead, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnAnnotationGreen Update(InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KReturn != kReturn ||
				this.TColon != tColon ||
				this.AnnotationHead != annotationHead ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnAnnotation(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnAnnotationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationHeadGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationHeadGreen __Missing = new AnnotationHeadGreen();
	    private NameGreen name;
	    private AnnotationBodyGreen annotationBody;
	
	    public AnnotationHeadGreen(SoalSyntaxKind kind, NameGreen name, AnnotationBodyGreen annotationBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (annotationBody != null)
			{
				this.AdjustFlagsAndWidth(annotationBody);
				this.annotationBody = annotationBody;
			}
	    }
	
	    public AnnotationHeadGreen(SoalSyntaxKind kind, NameGreen name, AnnotationBodyGreen annotationBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (annotationBody != null)
			{
				this.AdjustFlagsAndWidth(annotationBody);
				this.annotationBody = annotationBody;
			}
	    }
	
		private AnnotationHeadGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AnnotationHead, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public AnnotationBodyGreen AnnotationBody { get { return this.annotationBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationHeadSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.annotationBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationHeadGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationHeadGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationHeadGreen(this.Kind, this.name, this.annotationBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationHeadGreen(this.Kind, this.name, this.annotationBody, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationHeadGreen Update(NameGreen name, AnnotationBodyGreen annotationBody)
	    {
	        if (this.Name != name ||
				this.AnnotationBody != annotationBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationHead(name, annotationBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationHeadGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationBodyGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationBodyGreen __Missing = new AnnotationBodyGreen();
	    private InternalSyntaxToken tOpenParen;
	    private AnnotationPropertyListGreen annotationPropertyList;
	    private InternalSyntaxToken tCloseParen;
	
	    public AnnotationBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (annotationPropertyList != null)
			{
				this.AdjustFlagsAndWidth(annotationPropertyList);
				this.annotationPropertyList = annotationPropertyList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public AnnotationBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenParen != null)
			{
				this.AdjustFlagsAndWidth(tOpenParen);
				this.tOpenParen = tOpenParen;
			}
			if (annotationPropertyList != null)
			{
				this.AdjustFlagsAndWidth(annotationPropertyList);
				this.annotationPropertyList = annotationPropertyList;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private AnnotationBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AnnotationBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public AnnotationPropertyListGreen AnnotationPropertyList { get { return this.annotationPropertyList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.annotationPropertyList;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationBodyGreen(this.Kind, this.tOpenParen, this.annotationPropertyList, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationBodyGreen(this.Kind, this.tOpenParen, this.annotationPropertyList, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationBodyGreen Update(InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.AnnotationPropertyList != annotationPropertyList ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationBody(tOpenParen, annotationPropertyList, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationPropertyListGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationPropertyListGreen __Missing = new AnnotationPropertyListGreen();
	    private GreenNode annotationProperty;
	
	    public AnnotationPropertyListGreen(SoalSyntaxKind kind, GreenNode annotationProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (annotationProperty != null)
			{
				this.AdjustFlagsAndWidth(annotationProperty);
				this.annotationProperty = annotationProperty;
			}
	    }
	
	    public AnnotationPropertyListGreen(SoalSyntaxKind kind, GreenNode annotationProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (annotationProperty != null)
			{
				this.AdjustFlagsAndWidth(annotationProperty);
				this.annotationProperty = annotationProperty;
			}
	    }
	
		private AnnotationPropertyListGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AnnotationPropertyList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<AnnotationPropertyGreen> AnnotationProperty { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<AnnotationPropertyGreen>(this.annotationProperty); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationPropertyListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationPropertyListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationPropertyListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationPropertyListGreen(this.Kind, this.annotationProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationPropertyListGreen(this.Kind, this.annotationProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationPropertyListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<AnnotationPropertyGreen> annotationProperty)
	    {
	        if (this.AnnotationProperty != annotationProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyList(annotationProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationPropertyGreen __Missing = new AnnotationPropertyGreen();
	    private NameGreen name;
	    private InternalSyntaxToken tAssign;
	    private AnnotationPropertyValueGreen annotationPropertyValue;
	
	    public AnnotationPropertyGreen(SoalSyntaxKind kind, NameGreen name, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
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
			if (annotationPropertyValue != null)
			{
				this.AdjustFlagsAndWidth(annotationPropertyValue);
				this.annotationPropertyValue = annotationPropertyValue;
			}
	    }
	
	    public AnnotationPropertyGreen(SoalSyntaxKind kind, NameGreen name, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
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
			if (annotationPropertyValue != null)
			{
				this.AdjustFlagsAndWidth(annotationPropertyValue);
				this.annotationPropertyValue = annotationPropertyValue;
			}
	    }
	
		private AnnotationPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AnnotationProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public AnnotationPropertyValueGreen AnnotationPropertyValue { get { return this.annotationPropertyValue; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.name;
	            case 1: return this.tAssign;
	            case 2: return this.annotationPropertyValue;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationPropertyGreen(this.Kind, this.name, this.tAssign, this.annotationPropertyValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationPropertyGreen(this.Kind, this.name, this.tAssign, this.annotationPropertyValue, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationPropertyGreen Update(NameGreen name, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue)
	    {
	        if (this.Name != name ||
				this.TAssign != tAssign ||
				this.AnnotationPropertyValue != annotationPropertyValue)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationProperty(name, tAssign, annotationPropertyValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationPropertyValueGreen : GreenSyntaxNode
	{
	    internal static readonly AnnotationPropertyValueGreen __Missing = new AnnotationPropertyValueGreen();
	    private ConstantValueGreen constantValue;
	    private TypeofValueGreen typeofValue;
	
	    public AnnotationPropertyValueGreen(SoalSyntaxKind kind, ConstantValueGreen constantValue, TypeofValueGreen typeofValue)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (constantValue != null)
			{
				this.AdjustFlagsAndWidth(constantValue);
				this.constantValue = constantValue;
			}
			if (typeofValue != null)
			{
				this.AdjustFlagsAndWidth(typeofValue);
				this.typeofValue = typeofValue;
			}
	    }
	
	    public AnnotationPropertyValueGreen(SoalSyntaxKind kind, ConstantValueGreen constantValue, TypeofValueGreen typeofValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (constantValue != null)
			{
				this.AdjustFlagsAndWidth(constantValue);
				this.constantValue = constantValue;
			}
			if (typeofValue != null)
			{
				this.AdjustFlagsAndWidth(typeofValue);
				this.typeofValue = typeofValue;
			}
	    }
	
		private AnnotationPropertyValueGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AnnotationPropertyValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ConstantValueGreen ConstantValue { get { return this.constantValue; } }
	    public TypeofValueGreen TypeofValue { get { return this.typeofValue; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationPropertyValueSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.constantValue;
	            case 1: return this.typeofValue;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAnnotationPropertyValueGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAnnotationPropertyValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationPropertyValueGreen(this.Kind, this.constantValue, this.typeofValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationPropertyValueGreen(this.Kind, this.constantValue, this.typeofValue, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationPropertyValueGreen Update(ConstantValueGreen constantValue)
	    {
	        if (this.constantValue != constantValue)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyValue(constantValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyValueGreen)newNode;
	        }
	        return this;
	    }
	
	    public AnnotationPropertyValueGreen Update(TypeofValueGreen typeofValue)
	    {
	        if (this.typeofValue != typeofValue)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyValue(typeofValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly NamespaceDeclarationGreen __Missing = new NamespaceDeclarationGreen();
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tAssign;
	    private NamespacePrefixGreen namespacePrefix;
	    private InternalSyntaxToken tColon;
	    private NamespaceUriGreen namespaceUri;
	    private NamespaceBodyGreen namespaceBody;
	
	    public NamespaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tAssign, NamespacePrefixGreen namespacePrefix, InternalSyntaxToken tColon, NamespaceUriGreen namespaceUri, NamespaceBodyGreen namespaceBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (namespacePrefix != null)
			{
				this.AdjustFlagsAndWidth(namespacePrefix);
				this.namespacePrefix = namespacePrefix;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (namespaceUri != null)
			{
				this.AdjustFlagsAndWidth(namespaceUri);
				this.namespaceUri = namespaceUri;
			}
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
	    public NamespaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tAssign, NamespacePrefixGreen namespacePrefix, InternalSyntaxToken tColon, NamespaceUriGreen namespaceUri, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (namespacePrefix != null)
			{
				this.AdjustFlagsAndWidth(namespacePrefix);
				this.namespacePrefix = namespacePrefix;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (namespaceUri != null)
			{
				this.AdjustFlagsAndWidth(namespaceUri);
				this.namespaceUri = namespaceUri;
			}
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
		private NamespaceDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NamespaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public NamespacePrefixGreen NamespacePrefix { get { return this.namespacePrefix; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public NamespaceUriGreen NamespaceUri { get { return this.namespaceUri; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NamespaceDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kNamespace;
	            case 2: return this.qualifiedName;
	            case 3: return this.tAssign;
	            case 4: return this.namespacePrefix;
	            case 5: return this.tColon;
	            case 6: return this.namespaceUri;
	            case 7: return this.namespaceBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.annotationList, this.kNamespace, this.qualifiedName, this.tAssign, this.namespacePrefix, this.tColon, this.namespaceUri, this.namespaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.annotationList, this.kNamespace, this.qualifiedName, this.tAssign, this.namespacePrefix, this.tColon, this.namespaceUri, this.namespaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tAssign, NamespacePrefixGreen namespacePrefix, InternalSyntaxToken tColon, NamespaceUriGreen namespaceUri, NamespaceBodyGreen namespaceBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.TAssign != tAssign ||
				this.NamespacePrefix != namespacePrefix ||
				this.TColon != tColon ||
				this.NamespaceUri != namespaceUri ||
				this.NamespaceBody != namespaceBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(annotationList, kNamespace, qualifiedName, tAssign, namespacePrefix, tColon, namespaceUri, namespaceBody);
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
	
	internal class NamespacePrefixGreen : GreenSyntaxNode
	{
	    internal static readonly NamespacePrefixGreen __Missing = new NamespacePrefixGreen();
	    private IdentifierGreen identifier;
	
	    public NamespacePrefixGreen(SoalSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NamespacePrefixGreen(SoalSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private NamespacePrefixGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NamespacePrefix, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NamespacePrefixSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNamespacePrefixGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNamespacePrefixGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespacePrefixGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespacePrefixGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespacePrefixGreen Update(IdentifierGreen identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NamespacePrefix(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespacePrefixGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceUriGreen : GreenSyntaxNode
	{
	    internal static readonly NamespaceUriGreen __Missing = new NamespaceUriGreen();
	    private StringLiteralGreen stringLiteral;
	
	    public NamespaceUriGreen(SoalSyntaxKind kind, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public NamespaceUriGreen(SoalSyntaxKind kind, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
		private NamespaceUriGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NamespaceUri, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NamespaceUriSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceUriGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNamespaceUriGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceUriGreen(this.Kind, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceUriGreen(this.Kind, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceUriGreen Update(StringLiteralGreen stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NamespaceUri(stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceUriGreen)newNode;
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
	
	    public NamespaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration, InternalSyntaxToken tCloseBrace)
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
	
	    public NamespaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode declaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.NamespaceBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> Declaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen>(this.declaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NamespaceBodySyntax(this, (SoalSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNamespaceBodyGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
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
	    private EnumDeclarationGreen enumDeclaration;
	    private StructDeclarationGreen structDeclaration;
	    private DatabaseDeclarationGreen databaseDeclaration;
	    private InterfaceDeclarationGreen interfaceDeclaration;
	    private ComponentDeclarationGreen componentDeclaration;
	    private CompositeDeclarationGreen compositeDeclaration;
	    private AssemblyDeclarationGreen assemblyDeclaration;
	    private BindingDeclarationGreen bindingDeclaration;
	    private EndpointDeclarationGreen endpointDeclaration;
	    private DeploymentDeclarationGreen deploymentDeclaration;
	
	    public DeclarationGreen(SoalSyntaxKind kind, EnumDeclarationGreen enumDeclaration, StructDeclarationGreen structDeclaration, DatabaseDeclarationGreen databaseDeclaration, InterfaceDeclarationGreen interfaceDeclaration, ComponentDeclarationGreen componentDeclaration, CompositeDeclarationGreen compositeDeclaration, AssemblyDeclarationGreen assemblyDeclaration, BindingDeclarationGreen bindingDeclaration, EndpointDeclarationGreen endpointDeclaration, DeploymentDeclarationGreen deploymentDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 10;
			if (enumDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumDeclaration);
				this.enumDeclaration = enumDeclaration;
			}
			if (structDeclaration != null)
			{
				this.AdjustFlagsAndWidth(structDeclaration);
				this.structDeclaration = structDeclaration;
			}
			if (databaseDeclaration != null)
			{
				this.AdjustFlagsAndWidth(databaseDeclaration);
				this.databaseDeclaration = databaseDeclaration;
			}
			if (interfaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(interfaceDeclaration);
				this.interfaceDeclaration = interfaceDeclaration;
			}
			if (componentDeclaration != null)
			{
				this.AdjustFlagsAndWidth(componentDeclaration);
				this.componentDeclaration = componentDeclaration;
			}
			if (compositeDeclaration != null)
			{
				this.AdjustFlagsAndWidth(compositeDeclaration);
				this.compositeDeclaration = compositeDeclaration;
			}
			if (assemblyDeclaration != null)
			{
				this.AdjustFlagsAndWidth(assemblyDeclaration);
				this.assemblyDeclaration = assemblyDeclaration;
			}
			if (bindingDeclaration != null)
			{
				this.AdjustFlagsAndWidth(bindingDeclaration);
				this.bindingDeclaration = bindingDeclaration;
			}
			if (endpointDeclaration != null)
			{
				this.AdjustFlagsAndWidth(endpointDeclaration);
				this.endpointDeclaration = endpointDeclaration;
			}
			if (deploymentDeclaration != null)
			{
				this.AdjustFlagsAndWidth(deploymentDeclaration);
				this.deploymentDeclaration = deploymentDeclaration;
			}
	    }
	
	    public DeclarationGreen(SoalSyntaxKind kind, EnumDeclarationGreen enumDeclaration, StructDeclarationGreen structDeclaration, DatabaseDeclarationGreen databaseDeclaration, InterfaceDeclarationGreen interfaceDeclaration, ComponentDeclarationGreen componentDeclaration, CompositeDeclarationGreen compositeDeclaration, AssemblyDeclarationGreen assemblyDeclaration, BindingDeclarationGreen bindingDeclaration, EndpointDeclarationGreen endpointDeclaration, DeploymentDeclarationGreen deploymentDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 10;
			if (enumDeclaration != null)
			{
				this.AdjustFlagsAndWidth(enumDeclaration);
				this.enumDeclaration = enumDeclaration;
			}
			if (structDeclaration != null)
			{
				this.AdjustFlagsAndWidth(structDeclaration);
				this.structDeclaration = structDeclaration;
			}
			if (databaseDeclaration != null)
			{
				this.AdjustFlagsAndWidth(databaseDeclaration);
				this.databaseDeclaration = databaseDeclaration;
			}
			if (interfaceDeclaration != null)
			{
				this.AdjustFlagsAndWidth(interfaceDeclaration);
				this.interfaceDeclaration = interfaceDeclaration;
			}
			if (componentDeclaration != null)
			{
				this.AdjustFlagsAndWidth(componentDeclaration);
				this.componentDeclaration = componentDeclaration;
			}
			if (compositeDeclaration != null)
			{
				this.AdjustFlagsAndWidth(compositeDeclaration);
				this.compositeDeclaration = compositeDeclaration;
			}
			if (assemblyDeclaration != null)
			{
				this.AdjustFlagsAndWidth(assemblyDeclaration);
				this.assemblyDeclaration = assemblyDeclaration;
			}
			if (bindingDeclaration != null)
			{
				this.AdjustFlagsAndWidth(bindingDeclaration);
				this.bindingDeclaration = bindingDeclaration;
			}
			if (endpointDeclaration != null)
			{
				this.AdjustFlagsAndWidth(endpointDeclaration);
				this.endpointDeclaration = endpointDeclaration;
			}
			if (deploymentDeclaration != null)
			{
				this.AdjustFlagsAndWidth(deploymentDeclaration);
				this.deploymentDeclaration = deploymentDeclaration;
			}
	    }
	
		private DeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.Declaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public EnumDeclarationGreen EnumDeclaration { get { return this.enumDeclaration; } }
	    public StructDeclarationGreen StructDeclaration { get { return this.structDeclaration; } }
	    public DatabaseDeclarationGreen DatabaseDeclaration { get { return this.databaseDeclaration; } }
	    public InterfaceDeclarationGreen InterfaceDeclaration { get { return this.interfaceDeclaration; } }
	    public ComponentDeclarationGreen ComponentDeclaration { get { return this.componentDeclaration; } }
	    public CompositeDeclarationGreen CompositeDeclaration { get { return this.compositeDeclaration; } }
	    public AssemblyDeclarationGreen AssemblyDeclaration { get { return this.assemblyDeclaration; } }
	    public BindingDeclarationGreen BindingDeclaration { get { return this.bindingDeclaration; } }
	    public EndpointDeclarationGreen EndpointDeclaration { get { return this.endpointDeclaration; } }
	    public DeploymentDeclarationGreen DeploymentDeclaration { get { return this.deploymentDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumDeclaration;
	            case 1: return this.structDeclaration;
	            case 2: return this.databaseDeclaration;
	            case 3: return this.interfaceDeclaration;
	            case 4: return this.componentDeclaration;
	            case 5: return this.compositeDeclaration;
	            case 6: return this.assemblyDeclaration;
	            case 7: return this.bindingDeclaration;
	            case 8: return this.endpointDeclaration;
	            case 9: return this.deploymentDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.structDeclaration, this.databaseDeclaration, this.interfaceDeclaration, this.componentDeclaration, this.compositeDeclaration, this.assemblyDeclaration, this.bindingDeclaration, this.endpointDeclaration, this.deploymentDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.structDeclaration, this.databaseDeclaration, this.interfaceDeclaration, this.componentDeclaration, this.compositeDeclaration, this.assemblyDeclaration, this.bindingDeclaration, this.endpointDeclaration, this.deploymentDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(EnumDeclarationGreen enumDeclaration)
	    {
	        if (this.enumDeclaration != enumDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(enumDeclaration);
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
	
	    public DeclarationGreen Update(StructDeclarationGreen structDeclaration)
	    {
	        if (this.structDeclaration != structDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(structDeclaration);
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
	
	    public DeclarationGreen Update(DatabaseDeclarationGreen databaseDeclaration)
	    {
	        if (this.databaseDeclaration != databaseDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(databaseDeclaration);
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
	
	    public DeclarationGreen Update(InterfaceDeclarationGreen interfaceDeclaration)
	    {
	        if (this.interfaceDeclaration != interfaceDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(interfaceDeclaration);
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
	
	    public DeclarationGreen Update(ComponentDeclarationGreen componentDeclaration)
	    {
	        if (this.componentDeclaration != componentDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(componentDeclaration);
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
	
	    public DeclarationGreen Update(CompositeDeclarationGreen compositeDeclaration)
	    {
	        if (this.compositeDeclaration != compositeDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(compositeDeclaration);
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
	
	    public DeclarationGreen Update(AssemblyDeclarationGreen assemblyDeclaration)
	    {
	        if (this.assemblyDeclaration != assemblyDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(assemblyDeclaration);
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
	
	    public DeclarationGreen Update(BindingDeclarationGreen bindingDeclaration)
	    {
	        if (this.bindingDeclaration != bindingDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(bindingDeclaration);
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
	
	    public DeclarationGreen Update(EndpointDeclarationGreen endpointDeclaration)
	    {
	        if (this.endpointDeclaration != endpointDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(endpointDeclaration);
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
	
	    public DeclarationGreen Update(DeploymentDeclarationGreen deploymentDeclaration)
	    {
	        if (this.deploymentDeclaration != deploymentDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(deploymentDeclaration);
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
	
	internal class EnumDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly EnumDeclarationGreen __Missing = new EnumDeclarationGreen();
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kEnum;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private EnumBaseGreen enumBase;
	    private EnumBodyGreen enumBody;
	
	    public EnumDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tColon, EnumBaseGreen enumBase, EnumBodyGreen enumBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (enumBase != null)
			{
				this.AdjustFlagsAndWidth(enumBase);
				this.enumBase = enumBase;
			}
			if (enumBody != null)
			{
				this.AdjustFlagsAndWidth(enumBody);
				this.enumBody = enumBody;
			}
	    }
	
	    public EnumDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tColon, EnumBaseGreen enumBase, EnumBodyGreen enumBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (enumBase != null)
			{
				this.AdjustFlagsAndWidth(enumBase);
				this.enumBase = enumBase;
			}
			if (enumBody != null)
			{
				this.AdjustFlagsAndWidth(enumBody);
				this.enumBody = enumBody;
			}
	    }
	
		private EnumDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EnumDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KEnum { get { return this.kEnum; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public EnumBaseGreen EnumBase { get { return this.enumBase; } }
	    public EnumBodyGreen EnumBody { get { return this.enumBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kEnum;
	            case 2: return this.name;
	            case 3: return this.tColon;
	            case 4: return this.enumBase;
	            case 5: return this.enumBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.annotationList, this.kEnum, this.name, this.tColon, this.enumBase, this.enumBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.annotationList, this.kEnum, this.name, this.tColon, this.enumBase, this.enumBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tColon, EnumBaseGreen enumBase, EnumBodyGreen enumBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KEnum != kEnum ||
				this.Name != name ||
				this.TColon != tColon ||
				this.EnumBase != enumBase ||
				this.EnumBody != enumBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(annotationList, kEnum, name, tColon, enumBase, enumBody);
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
	
	internal class EnumBaseGreen : GreenSyntaxNode
	{
	    internal static readonly EnumBaseGreen __Missing = new EnumBaseGreen();
	    private QualifierGreen qualifier;
	
	    public EnumBaseGreen(SoalSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public EnumBaseGreen(SoalSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private EnumBaseGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EnumBase, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumBaseSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnumBaseGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnumBaseGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumBaseGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumBaseGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumBaseGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumBase(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBaseGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnumBodyGreen : GreenSyntaxNode
	{
	    internal static readonly EnumBodyGreen __Missing = new EnumBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private EnumLiteralsGreen enumLiterals;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EnumBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (enumLiterals != null)
			{
				this.AdjustFlagsAndWidth(enumLiterals);
				this.enumLiterals = enumLiterals;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public EnumBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (enumLiterals != null)
			{
				this.AdjustFlagsAndWidth(enumLiterals);
				this.enumLiterals = enumLiterals;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private EnumBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EnumBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public EnumLiteralsGreen EnumLiterals { get { return this.enumLiterals; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.enumLiterals;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnumBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnumBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumLiterals, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumLiterals, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumBodyGreen Update(InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EnumLiterals != enumLiterals ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumBody(tOpenBrace, enumLiterals, tCloseBrace);
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
	
	internal class EnumLiteralsGreen : GreenSyntaxNode
	{
	    internal static readonly EnumLiteralsGreen __Missing = new EnumLiteralsGreen();
	    private GreenNode enumLiteral;
	
	    public EnumLiteralsGreen(SoalSyntaxKind kind, GreenNode enumLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (enumLiteral != null)
			{
				this.AdjustFlagsAndWidth(enumLiteral);
				this.enumLiteral = enumLiteral;
			}
	    }
	
	    public EnumLiteralsGreen(SoalSyntaxKind kind, GreenNode enumLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.EnumLiterals, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen> EnumLiteral { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen>(this.enumLiteral); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumLiteralsSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnumLiteralsGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnumLiteralsGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumLiterals(enumLiteral);
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
	    private AnnotationListGreen annotationList;
	    private NameGreen name;
	
	    public EnumLiteralGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public EnumLiteralGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		private EnumLiteralGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EnumLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnumLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnumLiteralGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumLiteralGreen(this.Kind, this.annotationList, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumLiteralGreen(this.Kind, this.annotationList, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumLiteralGreen Update(AnnotationListGreen annotationList, NameGreen name)
	    {
	        if (this.AnnotationList != annotationList ||
				this.Name != name)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumLiteral(annotationList, name);
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
	
	internal class StructDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly StructDeclarationGreen __Missing = new StructDeclarationGreen();
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kStruct;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private QualifierGreen qualifier;
	    private StructBodyGreen structBody;
	
	    public StructDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, StructBodyGreen structBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (kStruct != null)
			{
				this.AdjustFlagsAndWidth(kStruct);
				this.kStruct = kStruct;
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
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (structBody != null)
			{
				this.AdjustFlagsAndWidth(structBody);
				this.structBody = structBody;
			}
	    }
	
	    public StructDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, StructBodyGreen structBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (kStruct != null)
			{
				this.AdjustFlagsAndWidth(kStruct);
				this.kStruct = kStruct;
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
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (structBody != null)
			{
				this.AdjustFlagsAndWidth(structBody);
				this.structBody = structBody;
			}
	    }
	
		private StructDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.StructDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KStruct { get { return this.kStruct; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public StructBodyGreen StructBody { get { return this.structBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.StructDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kStruct;
	            case 2: return this.name;
	            case 3: return this.tColon;
	            case 4: return this.qualifier;
	            case 5: return this.structBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitStructDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitStructDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StructDeclarationGreen(this.Kind, this.annotationList, this.kStruct, this.name, this.tColon, this.qualifier, this.structBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StructDeclarationGreen(this.Kind, this.annotationList, this.kStruct, this.name, this.tColon, this.qualifier, this.structBody, this.GetDiagnostics(), annotations);
	    }
	
	    public StructDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, StructBodyGreen structBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KStruct != kStruct ||
				this.Name != name ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.StructBody != structBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.StructDeclaration(annotationList, kStruct, name, tColon, qualifier, structBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StructDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StructBodyGreen : GreenSyntaxNode
	{
	    internal static readonly StructBodyGreen __Missing = new StructBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode propertyDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public StructBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode propertyDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (propertyDeclaration != null)
			{
				this.AdjustFlagsAndWidth(propertyDeclaration);
				this.propertyDeclaration = propertyDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public StructBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode propertyDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (propertyDeclaration != null)
			{
				this.AdjustFlagsAndWidth(propertyDeclaration);
				this.propertyDeclaration = propertyDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private StructBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.StructBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<PropertyDeclarationGreen> PropertyDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<PropertyDeclarationGreen>(this.propertyDeclaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.StructBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.propertyDeclaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitStructBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitStructBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StructBodyGreen(this.Kind, this.tOpenBrace, this.propertyDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StructBodyGreen(this.Kind, this.tOpenBrace, this.propertyDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public StructBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<PropertyDeclarationGreen> propertyDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.PropertyDeclaration != propertyDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.StructBody(tOpenBrace, propertyDeclaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StructBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PropertyDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly PropertyDeclarationGreen __Missing = new PropertyDeclarationGreen();
	    private AnnotationListGreen annotationList;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public PropertyDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public PropertyDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private PropertyDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.PropertyDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.PropertyDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.typeReference;
	            case 2: return this.name;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitPropertyDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitPropertyDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PropertyDeclarationGreen(this.Kind, this.annotationList, this.typeReference, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PropertyDeclarationGreen(this.Kind, this.annotationList, this.typeReference, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public PropertyDeclarationGreen Update(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.AnnotationList != annotationList ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.PropertyDeclaration(annotationList, typeReference, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PropertyDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DatabaseDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly DatabaseDeclarationGreen __Missing = new DatabaseDeclarationGreen();
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kDatabase;
	    private NameGreen name;
	    private DatabaseBodyGreen databaseBody;
	
	    public DatabaseDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameGreen name, DatabaseBodyGreen databaseBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (kDatabase != null)
			{
				this.AdjustFlagsAndWidth(kDatabase);
				this.kDatabase = kDatabase;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (databaseBody != null)
			{
				this.AdjustFlagsAndWidth(databaseBody);
				this.databaseBody = databaseBody;
			}
	    }
	
	    public DatabaseDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameGreen name, DatabaseBodyGreen databaseBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (kDatabase != null)
			{
				this.AdjustFlagsAndWidth(kDatabase);
				this.kDatabase = kDatabase;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (databaseBody != null)
			{
				this.AdjustFlagsAndWidth(databaseBody);
				this.databaseBody = databaseBody;
			}
	    }
	
		private DatabaseDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DatabaseDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KDatabase { get { return this.kDatabase; } }
	    public NameGreen Name { get { return this.name; } }
	    public DatabaseBodyGreen DatabaseBody { get { return this.databaseBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DatabaseDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kDatabase;
	            case 2: return this.name;
	            case 3: return this.databaseBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDatabaseDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDatabaseDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DatabaseDeclarationGreen(this.Kind, this.annotationList, this.kDatabase, this.name, this.databaseBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DatabaseDeclarationGreen(this.Kind, this.annotationList, this.kDatabase, this.name, this.databaseBody, this.GetDiagnostics(), annotations);
	    }
	
	    public DatabaseDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameGreen name, DatabaseBodyGreen databaseBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KDatabase != kDatabase ||
				this.Name != name ||
				this.DatabaseBody != databaseBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DatabaseDeclaration(annotationList, kDatabase, name, databaseBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DatabaseDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DatabaseBodyGreen : GreenSyntaxNode
	{
	    internal static readonly DatabaseBodyGreen __Missing = new DatabaseBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode entityReference;
	    private GreenNode operationDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public DatabaseBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode entityReference, GreenNode operationDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (entityReference != null)
			{
				this.AdjustFlagsAndWidth(entityReference);
				this.entityReference = entityReference;
			}
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public DatabaseBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode entityReference, GreenNode operationDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (entityReference != null)
			{
				this.AdjustFlagsAndWidth(entityReference);
				this.entityReference = entityReference;
			}
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private DatabaseBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DatabaseBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EntityReferenceGreen> EntityReference { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EntityReferenceGreen>(this.entityReference); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen> OperationDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen>(this.operationDeclaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DatabaseBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.entityReference;
	            case 2: return this.operationDeclaration;
	            case 3: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDatabaseBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDatabaseBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DatabaseBodyGreen(this.Kind, this.tOpenBrace, this.entityReference, this.operationDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DatabaseBodyGreen(this.Kind, this.tOpenBrace, this.entityReference, this.operationDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public DatabaseBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EntityReferenceGreen> entityReference, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen> operationDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EntityReference != entityReference ||
				this.OperationDeclaration != operationDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DatabaseBody(tOpenBrace, entityReference, operationDeclaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DatabaseBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EntityReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly EntityReferenceGreen __Missing = new EntityReferenceGreen();
	    private InternalSyntaxToken kEntity;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public EntityReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kEntity, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kEntity != null)
			{
				this.AdjustFlagsAndWidth(kEntity);
				this.kEntity = kEntity;
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
	
	    public EntityReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kEntity, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kEntity != null)
			{
				this.AdjustFlagsAndWidth(kEntity);
				this.kEntity = kEntity;
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
	
		private EntityReferenceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EntityReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEntity { get { return this.kEntity; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EntityReferenceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEntity;
	            case 1: return this.qualifier;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEntityReferenceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEntityReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EntityReferenceGreen(this.Kind, this.kEntity, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EntityReferenceGreen(this.Kind, this.kEntity, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EntityReferenceGreen Update(InternalSyntaxToken kEntity, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KEntity != kEntity ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EntityReference(kEntity, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EntityReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InterfaceDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly InterfaceDeclarationGreen __Missing = new InterfaceDeclarationGreen();
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kInterface;
	    private NameGreen name;
	    private InterfaceBodyGreen interfaceBody;
	
	    public InterfaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameGreen name, InterfaceBodyGreen interfaceBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (kInterface != null)
			{
				this.AdjustFlagsAndWidth(kInterface);
				this.kInterface = kInterface;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (interfaceBody != null)
			{
				this.AdjustFlagsAndWidth(interfaceBody);
				this.interfaceBody = interfaceBody;
			}
	    }
	
	    public InterfaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameGreen name, InterfaceBodyGreen interfaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (kInterface != null)
			{
				this.AdjustFlagsAndWidth(kInterface);
				this.kInterface = kInterface;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (interfaceBody != null)
			{
				this.AdjustFlagsAndWidth(interfaceBody);
				this.interfaceBody = interfaceBody;
			}
	    }
	
		private InterfaceDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.InterfaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KInterface { get { return this.kInterface; } }
	    public NameGreen Name { get { return this.name; } }
	    public InterfaceBodyGreen InterfaceBody { get { return this.interfaceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.InterfaceDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kInterface;
	            case 2: return this.name;
	            case 3: return this.interfaceBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitInterfaceDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitInterfaceDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InterfaceDeclarationGreen(this.Kind, this.annotationList, this.kInterface, this.name, this.interfaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InterfaceDeclarationGreen(this.Kind, this.annotationList, this.kInterface, this.name, this.interfaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public InterfaceDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameGreen name, InterfaceBodyGreen interfaceBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KInterface != kInterface ||
				this.Name != name ||
				this.InterfaceBody != interfaceBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.InterfaceDeclaration(annotationList, kInterface, name, interfaceBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InterfaceDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InterfaceBodyGreen : GreenSyntaxNode
	{
	    internal static readonly InterfaceBodyGreen __Missing = new InterfaceBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode operationDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public InterfaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode operationDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public InterfaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode operationDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private InterfaceBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.InterfaceBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen> OperationDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen>(this.operationDeclaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.InterfaceBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.operationDeclaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitInterfaceBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitInterfaceBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InterfaceBodyGreen(this.Kind, this.tOpenBrace, this.operationDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InterfaceBodyGreen(this.Kind, this.tOpenBrace, this.operationDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public InterfaceBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen> operationDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.OperationDeclaration != operationDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.InterfaceBody(tOpenBrace, operationDeclaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InterfaceBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly OperationDeclarationGreen __Missing = new OperationDeclarationGreen();
	    private OperationHeadGreen operationHead;
	    private InternalSyntaxToken tSemicolon;
	
	    public OperationDeclarationGreen(SoalSyntaxKind kind, OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (operationHead != null)
			{
				this.AdjustFlagsAndWidth(operationHead);
				this.operationHead = operationHead;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public OperationDeclarationGreen(SoalSyntaxKind kind, OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (operationHead != null)
			{
				this.AdjustFlagsAndWidth(operationHead);
				this.operationHead = operationHead;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private OperationDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.OperationDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OperationHeadGreen OperationHead { get { return this.operationHead; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.operationHead;
	            case 1: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.operationHead, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.operationHead, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationDeclarationGreen Update(OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon)
	    {
	        if (this.OperationHead != operationHead ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(operationHead, tSemicolon);
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
	
	internal class OperationHeadGreen : GreenSyntaxNode
	{
	    internal static readonly OperationHeadGreen __Missing = new OperationHeadGreen();
	    private AnnotationListGreen annotationList;
	    private OperationResultGreen operationResult;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private ParameterListGreen parameterList;
	    private InternalSyntaxToken tCloseParen;
	    private ThrowsListGreen throwsList;
	
	    public OperationHeadGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, OperationResultGreen operationResult, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, ThrowsListGreen throwsList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (operationResult != null)
			{
				this.AdjustFlagsAndWidth(operationResult);
				this.operationResult = operationResult;
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
			if (throwsList != null)
			{
				this.AdjustFlagsAndWidth(throwsList);
				this.throwsList = throwsList;
			}
	    }
	
	    public OperationHeadGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, OperationResultGreen operationResult, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, ThrowsListGreen throwsList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (operationResult != null)
			{
				this.AdjustFlagsAndWidth(operationResult);
				this.operationResult = operationResult;
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
			if (throwsList != null)
			{
				this.AdjustFlagsAndWidth(throwsList);
				this.throwsList = throwsList;
			}
	    }
	
		private OperationHeadGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.OperationHead, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public OperationResultGreen OperationResult { get { return this.operationResult; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ParameterListGreen ParameterList { get { return this.parameterList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public ThrowsListGreen ThrowsList { get { return this.throwsList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationHeadSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.operationResult;
	            case 2: return this.name;
	            case 3: return this.tOpenParen;
	            case 4: return this.parameterList;
	            case 5: return this.tCloseParen;
	            case 6: return this.throwsList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitOperationHeadGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitOperationHeadGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationHeadGreen(this.Kind, this.annotationList, this.operationResult, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.throwsList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationHeadGreen(this.Kind, this.annotationList, this.operationResult, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.throwsList, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationHeadGreen Update(AnnotationListGreen annotationList, OperationResultGreen operationResult, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, ThrowsListGreen throwsList)
	    {
	        if (this.AnnotationList != annotationList ||
				this.OperationResult != operationResult ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.ThrowsList != throwsList)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationHead(annotationList, operationResult, name, tOpenParen, parameterList, tCloseParen, throwsList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationHeadGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParameterListGreen : GreenSyntaxNode
	{
	    internal static readonly ParameterListGreen __Missing = new ParameterListGreen();
	    private GreenNode parameter;
	
	    public ParameterListGreen(SoalSyntaxKind kind, GreenNode parameter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
	    public ParameterListGreen(SoalSyntaxKind kind, GreenNode parameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.ParameterList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> Parameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen>(this.parameter); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ParameterListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parameter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitParameterListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitParameterListGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ParameterList(parameter);
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
	    private AnnotationListGreen annotationList;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	
	    public ParameterGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
	
	    public ParameterGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
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
			: base((SoalSyntaxKind)SoalSyntaxKind.Parameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ParameterSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.typeReference;
	            case 2: return this.name;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitParameterGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitParameterGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterGreen(this.Kind, this.annotationList, this.typeReference, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterGreen(this.Kind, this.annotationList, this.typeReference, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterGreen Update(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name)
	    {
	        if (this.AnnotationList != annotationList ||
				this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Parameter(annotationList, typeReference, name);
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
	
	internal class OperationResultGreen : GreenSyntaxNode
	{
	    internal static readonly OperationResultGreen __Missing = new OperationResultGreen();
	    private ReturnAnnotationListGreen returnAnnotationList;
	    private OperationReturnTypeGreen operationReturnType;
	
	    public OperationResultGreen(SoalSyntaxKind kind, ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (returnAnnotationList != null)
			{
				this.AdjustFlagsAndWidth(returnAnnotationList);
				this.returnAnnotationList = returnAnnotationList;
			}
			if (operationReturnType != null)
			{
				this.AdjustFlagsAndWidth(operationReturnType);
				this.operationReturnType = operationReturnType;
			}
	    }
	
	    public OperationResultGreen(SoalSyntaxKind kind, ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (returnAnnotationList != null)
			{
				this.AdjustFlagsAndWidth(returnAnnotationList);
				this.returnAnnotationList = returnAnnotationList;
			}
			if (operationReturnType != null)
			{
				this.AdjustFlagsAndWidth(operationReturnType);
				this.operationReturnType = operationReturnType;
			}
	    }
	
		private OperationResultGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.OperationResult, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ReturnAnnotationListGreen ReturnAnnotationList { get { return this.returnAnnotationList; } }
	    public OperationReturnTypeGreen OperationReturnType { get { return this.operationReturnType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationResultSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.returnAnnotationList;
	            case 1: return this.operationReturnType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitOperationResultGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitOperationResultGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationResultGreen(this.Kind, this.returnAnnotationList, this.operationReturnType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationResultGreen(this.Kind, this.returnAnnotationList, this.operationReturnType, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationResultGreen Update(ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType)
	    {
	        if (this.ReturnAnnotationList != returnAnnotationList ||
				this.OperationReturnType != operationReturnType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationResult(returnAnnotationList, operationReturnType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationResultGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ThrowsListGreen : GreenSyntaxNode
	{
	    internal static readonly ThrowsListGreen __Missing = new ThrowsListGreen();
	    private InternalSyntaxToken kThrows;
	    private QualifierListGreen qualifierList;
	
	    public ThrowsListGreen(SoalSyntaxKind kind, InternalSyntaxToken kThrows, QualifierListGreen qualifierList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kThrows != null)
			{
				this.AdjustFlagsAndWidth(kThrows);
				this.kThrows = kThrows;
			}
			if (qualifierList != null)
			{
				this.AdjustFlagsAndWidth(qualifierList);
				this.qualifierList = qualifierList;
			}
	    }
	
	    public ThrowsListGreen(SoalSyntaxKind kind, InternalSyntaxToken kThrows, QualifierListGreen qualifierList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kThrows != null)
			{
				this.AdjustFlagsAndWidth(kThrows);
				this.kThrows = kThrows;
			}
			if (qualifierList != null)
			{
				this.AdjustFlagsAndWidth(qualifierList);
				this.qualifierList = qualifierList;
			}
	    }
	
		private ThrowsListGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ThrowsList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KThrows { get { return this.kThrows; } }
	    public QualifierListGreen QualifierList { get { return this.qualifierList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ThrowsListSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kThrows;
	            case 1: return this.qualifierList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitThrowsListGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitThrowsListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ThrowsListGreen(this.Kind, this.kThrows, this.qualifierList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ThrowsListGreen(this.Kind, this.kThrows, this.qualifierList, this.GetDiagnostics(), annotations);
	    }
	
	    public ThrowsListGreen Update(InternalSyntaxToken kThrows, QualifierListGreen qualifierList)
	    {
	        if (this.KThrows != kThrows ||
				this.QualifierList != qualifierList)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ThrowsList(kThrows, qualifierList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThrowsListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentDeclarationGreen __Missing = new ComponentDeclarationGreen();
	    private InternalSyntaxToken kAbstract;
	    private InternalSyntaxToken kComponent;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ComponentBaseGreen componentBase;
	    private ComponentBodyGreen componentBody;
	
	    public ComponentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, ComponentBodyGreen componentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (kAbstract != null)
			{
				this.AdjustFlagsAndWidth(kAbstract);
				this.kAbstract = kAbstract;
			}
			if (kComponent != null)
			{
				this.AdjustFlagsAndWidth(kComponent);
				this.kComponent = kComponent;
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
			if (componentBase != null)
			{
				this.AdjustFlagsAndWidth(componentBase);
				this.componentBase = componentBase;
			}
			if (componentBody != null)
			{
				this.AdjustFlagsAndWidth(componentBody);
				this.componentBody = componentBody;
			}
	    }
	
	    public ComponentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, ComponentBodyGreen componentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (kAbstract != null)
			{
				this.AdjustFlagsAndWidth(kAbstract);
				this.kAbstract = kAbstract;
			}
			if (kComponent != null)
			{
				this.AdjustFlagsAndWidth(kComponent);
				this.kComponent = kComponent;
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
			if (componentBase != null)
			{
				this.AdjustFlagsAndWidth(componentBase);
				this.componentBase = componentBase;
			}
			if (componentBody != null)
			{
				this.AdjustFlagsAndWidth(componentBody);
				this.componentBody = componentBody;
			}
	    }
	
		private ComponentDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAbstract { get { return this.kAbstract; } }
	    public InternalSyntaxToken KComponent { get { return this.kComponent; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ComponentBaseGreen ComponentBase { get { return this.componentBase; } }
	    public ComponentBodyGreen ComponentBody { get { return this.componentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAbstract;
	            case 1: return this.kComponent;
	            case 2: return this.name;
	            case 3: return this.tColon;
	            case 4: return this.componentBase;
	            case 5: return this.componentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentDeclarationGreen(this.Kind, this.kAbstract, this.kComponent, this.name, this.tColon, this.componentBase, this.componentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentDeclarationGreen(this.Kind, this.kAbstract, this.kComponent, this.name, this.tColon, this.componentBase, this.componentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentDeclarationGreen Update(InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, ComponentBodyGreen componentBody)
	    {
	        if (this.KAbstract != kAbstract ||
				this.KComponent != kComponent ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ComponentBase != componentBase ||
				this.ComponentBody != componentBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentDeclaration(kAbstract, kComponent, name, tColon, componentBase, componentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentBaseGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentBaseGreen __Missing = new ComponentBaseGreen();
	    private QualifierGreen qualifier;
	
	    public ComponentBaseGreen(SoalSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ComponentBaseGreen(SoalSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private ComponentBaseGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentBase, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentBaseSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentBaseGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentBaseGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentBaseGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentBaseGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentBaseGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentBase(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentBaseGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentBodyGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentBodyGreen __Missing = new ComponentBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private ComponentElementsGreen componentElements;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ComponentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (componentElements != null)
			{
				this.AdjustFlagsAndWidth(componentElements);
				this.componentElements = componentElements;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public ComponentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (componentElements != null)
			{
				this.AdjustFlagsAndWidth(componentElements);
				this.componentElements = componentElements;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private ComponentBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public ComponentElementsGreen ComponentElements { get { return this.componentElements; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.componentElements;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentBodyGreen(this.Kind, this.tOpenBrace, this.componentElements, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentBodyGreen(this.Kind, this.tOpenBrace, this.componentElements, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentBodyGreen Update(InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ComponentElements != componentElements ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentBody(tOpenBrace, componentElements, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentElementsGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentElementsGreen __Missing = new ComponentElementsGreen();
	    private GreenNode componentElement;
	
	    public ComponentElementsGreen(SoalSyntaxKind kind, GreenNode componentElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (componentElement != null)
			{
				this.AdjustFlagsAndWidth(componentElement);
				this.componentElement = componentElement;
			}
	    }
	
	    public ComponentElementsGreen(SoalSyntaxKind kind, GreenNode componentElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (componentElement != null)
			{
				this.AdjustFlagsAndWidth(componentElement);
				this.componentElement = componentElement;
			}
	    }
	
		private ComponentElementsGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentElements, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentElementGreen> ComponentElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentElementGreen>(this.componentElement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentElementsSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.componentElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentElementsGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentElementsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentElementsGreen(this.Kind, this.componentElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentElementsGreen(this.Kind, this.componentElement, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentElementsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentElementGreen> componentElement)
	    {
	        if (this.ComponentElement != componentElement)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElements(componentElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentElementGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentElementGreen __Missing = new ComponentElementGreen();
	    private ComponentServiceGreen componentService;
	    private ComponentReferenceGreen componentReference;
	    private ComponentPropertyGreen componentProperty;
	    private ComponentImplementationGreen componentImplementation;
	    private ComponentLanguageGreen componentLanguage;
	
	    public ComponentElementGreen(SoalSyntaxKind kind, ComponentServiceGreen componentService, ComponentReferenceGreen componentReference, ComponentPropertyGreen componentProperty, ComponentImplementationGreen componentImplementation, ComponentLanguageGreen componentLanguage)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (componentService != null)
			{
				this.AdjustFlagsAndWidth(componentService);
				this.componentService = componentService;
			}
			if (componentReference != null)
			{
				this.AdjustFlagsAndWidth(componentReference);
				this.componentReference = componentReference;
			}
			if (componentProperty != null)
			{
				this.AdjustFlagsAndWidth(componentProperty);
				this.componentProperty = componentProperty;
			}
			if (componentImplementation != null)
			{
				this.AdjustFlagsAndWidth(componentImplementation);
				this.componentImplementation = componentImplementation;
			}
			if (componentLanguage != null)
			{
				this.AdjustFlagsAndWidth(componentLanguage);
				this.componentLanguage = componentLanguage;
			}
	    }
	
	    public ComponentElementGreen(SoalSyntaxKind kind, ComponentServiceGreen componentService, ComponentReferenceGreen componentReference, ComponentPropertyGreen componentProperty, ComponentImplementationGreen componentImplementation, ComponentLanguageGreen componentLanguage, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (componentService != null)
			{
				this.AdjustFlagsAndWidth(componentService);
				this.componentService = componentService;
			}
			if (componentReference != null)
			{
				this.AdjustFlagsAndWidth(componentReference);
				this.componentReference = componentReference;
			}
			if (componentProperty != null)
			{
				this.AdjustFlagsAndWidth(componentProperty);
				this.componentProperty = componentProperty;
			}
			if (componentImplementation != null)
			{
				this.AdjustFlagsAndWidth(componentImplementation);
				this.componentImplementation = componentImplementation;
			}
			if (componentLanguage != null)
			{
				this.AdjustFlagsAndWidth(componentLanguage);
				this.componentLanguage = componentLanguage;
			}
	    }
	
		private ComponentElementGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ComponentServiceGreen ComponentService { get { return this.componentService; } }
	    public ComponentReferenceGreen ComponentReference { get { return this.componentReference; } }
	    public ComponentPropertyGreen ComponentProperty { get { return this.componentProperty; } }
	    public ComponentImplementationGreen ComponentImplementation { get { return this.componentImplementation; } }
	    public ComponentLanguageGreen ComponentLanguage { get { return this.componentLanguage; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentElementSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.componentService;
	            case 1: return this.componentReference;
	            case 2: return this.componentProperty;
	            case 3: return this.componentImplementation;
	            case 4: return this.componentLanguage;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentElementGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentElementGreen Update(ComponentServiceGreen componentService)
	    {
	        if (this.componentService != componentService)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentService);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementGreen Update(ComponentReferenceGreen componentReference)
	    {
	        if (this.componentReference != componentReference)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementGreen Update(ComponentPropertyGreen componentProperty)
	    {
	        if (this.componentProperty != componentProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementGreen Update(ComponentImplementationGreen componentImplementation)
	    {
	        if (this.componentImplementation != componentImplementation)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentImplementation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementGreen Update(ComponentLanguageGreen componentLanguage)
	    {
	        if (this.componentLanguage != componentLanguage)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentLanguage);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentServiceGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentServiceGreen __Missing = new ComponentServiceGreen();
	    private InternalSyntaxToken kService;
	    private QualifierGreen qualifier;
	    private NameGreen name;
	    private ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody;
	
	    public ComponentServiceGreen(SoalSyntaxKind kind, InternalSyntaxToken kService, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kService != null)
			{
				this.AdjustFlagsAndWidth(kService);
				this.kService = kService;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
	    public ComponentServiceGreen(SoalSyntaxKind kind, InternalSyntaxToken kService, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kService != null)
			{
				this.AdjustFlagsAndWidth(kService);
				this.kService = kService;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
		private ComponentServiceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentService, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KService { get { return this.kService; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public NameGreen Name { get { return this.name; } }
	    public ComponentServiceOrReferenceBodyGreen ComponentServiceOrReferenceBody { get { return this.componentServiceOrReferenceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kService;
	            case 1: return this.qualifier;
	            case 2: return this.name;
	            case 3: return this.componentServiceOrReferenceBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentServiceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentServiceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceGreen(this.Kind, this.kService, this.qualifier, this.name, this.componentServiceOrReferenceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceGreen(this.Kind, this.kService, this.qualifier, this.name, this.componentServiceOrReferenceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceGreen Update(InternalSyntaxToken kService, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	    {
	        if (this.KService != kService ||
				this.Qualifier != qualifier ||
				this.Name != name ||
				this.ComponentServiceOrReferenceBody != componentServiceOrReferenceBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentService(kService, qualifier, name, componentServiceOrReferenceBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentReferenceGreen __Missing = new ComponentReferenceGreen();
	    private InternalSyntaxToken kReference;
	    private QualifierGreen qualifier;
	    private NameGreen name;
	    private ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody;
	
	    public ComponentReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kReference, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (kReference != null)
			{
				this.AdjustFlagsAndWidth(kReference);
				this.kReference = kReference;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
	    public ComponentReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kReference, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (kReference != null)
			{
				this.AdjustFlagsAndWidth(kReference);
				this.kReference = kReference;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
		private ComponentReferenceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KReference { get { return this.kReference; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public NameGreen Name { get { return this.name; } }
	    public ComponentServiceOrReferenceBodyGreen ComponentServiceOrReferenceBody { get { return this.componentServiceOrReferenceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentReferenceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kReference;
	            case 1: return this.qualifier;
	            case 2: return this.name;
	            case 3: return this.componentServiceOrReferenceBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentReferenceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentReferenceGreen(this.Kind, this.kReference, this.qualifier, this.name, this.componentServiceOrReferenceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentReferenceGreen(this.Kind, this.kReference, this.qualifier, this.name, this.componentServiceOrReferenceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentReferenceGreen Update(InternalSyntaxToken kReference, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	    {
	        if (this.KReference != kReference ||
				this.Qualifier != qualifier ||
				this.Name != name ||
				this.ComponentServiceOrReferenceBody != componentServiceOrReferenceBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentReference(kReference, qualifier, name, componentServiceOrReferenceBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ComponentServiceOrReferenceBodyGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentServiceOrReferenceBodyGreen __Missing = ComponentServiceOrReferenceEmptyBodyGreen.__Missing;
	
	    public ComponentServiceOrReferenceBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class ComponentServiceOrReferenceEmptyBodyGreen : ComponentServiceOrReferenceBodyGreen
	{
	    internal static new readonly ComponentServiceOrReferenceEmptyBodyGreen __Missing = new ComponentServiceOrReferenceEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentServiceOrReferenceEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ComponentServiceOrReferenceEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ComponentServiceOrReferenceEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentServiceOrReferenceEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceOrReferenceEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentServiceOrReferenceEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentServiceOrReferenceEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceOrReferenceEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceOrReferenceEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceOrReferenceEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceOrReferenceEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentServiceOrReferenceNonEmptyBodyGreen : ComponentServiceOrReferenceBodyGreen
	{
	    internal static new readonly ComponentServiceOrReferenceNonEmptyBodyGreen __Missing = new ComponentServiceOrReferenceNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode componentServiceOrReferenceElement;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ComponentServiceOrReferenceNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (componentServiceOrReferenceElement != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceElement);
				this.componentServiceOrReferenceElement = componentServiceOrReferenceElement;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public ComponentServiceOrReferenceNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (componentServiceOrReferenceElement != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceElement);
				this.componentServiceOrReferenceElement = componentServiceOrReferenceElement;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private ComponentServiceOrReferenceNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentServiceOrReferenceNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentServiceOrReferenceElementGreen> ComponentServiceOrReferenceElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentServiceOrReferenceElementGreen>(this.componentServiceOrReferenceElement); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceOrReferenceNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.componentServiceOrReferenceElement;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentServiceOrReferenceNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentServiceOrReferenceNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceOrReferenceNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.componentServiceOrReferenceElement, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceOrReferenceNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.componentServiceOrReferenceElement, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceOrReferenceNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentServiceOrReferenceElementGreen> componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ComponentServiceOrReferenceElement != componentServiceOrReferenceElement ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceNonEmptyBody(tOpenBrace, componentServiceOrReferenceElement, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceOrReferenceNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentServiceOrReferenceElementGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentServiceOrReferenceElementGreen __Missing = new ComponentServiceOrReferenceElementGreen();
	    private InternalSyntaxToken kBinding;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentServiceOrReferenceElementGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
	    public ComponentServiceOrReferenceElementGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
		private ComponentServiceOrReferenceElementGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentServiceOrReferenceElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBinding { get { return this.kBinding; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceOrReferenceElementSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBinding;
	            case 1: return this.qualifier;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentServiceOrReferenceElementGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentServiceOrReferenceElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceOrReferenceElementGreen(this.Kind, this.kBinding, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceOrReferenceElementGreen(this.Kind, this.kBinding, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceOrReferenceElementGreen Update(InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KBinding != kBinding ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceElement(kBinding, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceOrReferenceElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentPropertyGreen __Missing = new ComponentPropertyGreen();
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentPropertyGreen(SoalSyntaxKind kind, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
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
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ComponentPropertyGreen(SoalSyntaxKind kind, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
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
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ComponentPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentPropertyGreen(this.Kind, this.typeReference, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentPropertyGreen(this.Kind, this.typeReference, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentPropertyGreen Update(TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.TypeReference != typeReference ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentProperty(typeReference, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentImplementationGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentImplementationGreen __Missing = new ComponentImplementationGreen();
	    private InternalSyntaxToken kImplementation;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentImplementationGreen(SoalSyntaxKind kind, InternalSyntaxToken kImplementation, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kImplementation != null)
			{
				this.AdjustFlagsAndWidth(kImplementation);
				this.kImplementation = kImplementation;
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
	
	    public ComponentImplementationGreen(SoalSyntaxKind kind, InternalSyntaxToken kImplementation, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kImplementation != null)
			{
				this.AdjustFlagsAndWidth(kImplementation);
				this.kImplementation = kImplementation;
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
	
		private ComponentImplementationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentImplementation, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KImplementation { get { return this.kImplementation; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentImplementationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kImplementation;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentImplementationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentImplementationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentImplementationGreen(this.Kind, this.kImplementation, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentImplementationGreen(this.Kind, this.kImplementation, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentImplementationGreen Update(InternalSyntaxToken kImplementation, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KImplementation != kImplementation ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentImplementation(kImplementation, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentImplementationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ComponentLanguageGreen : GreenSyntaxNode
	{
	    internal static readonly ComponentLanguageGreen __Missing = new ComponentLanguageGreen();
	    private InternalSyntaxToken kLanguage;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentLanguageGreen(SoalSyntaxKind kind, InternalSyntaxToken kLanguage, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kLanguage != null)
			{
				this.AdjustFlagsAndWidth(kLanguage);
				this.kLanguage = kLanguage;
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
	
	    public ComponentLanguageGreen(SoalSyntaxKind kind, InternalSyntaxToken kLanguage, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kLanguage != null)
			{
				this.AdjustFlagsAndWidth(kLanguage);
				this.kLanguage = kLanguage;
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
	
		private ComponentLanguageGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ComponentLanguage, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KLanguage { get { return this.kLanguage; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentLanguageSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kLanguage;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitComponentLanguageGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitComponentLanguageGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentLanguageGreen(this.Kind, this.kLanguage, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentLanguageGreen(this.Kind, this.kLanguage, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentLanguageGreen Update(InternalSyntaxToken kLanguage, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KLanguage != kLanguage ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentLanguage(kLanguage, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentLanguageGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompositeDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly CompositeDeclarationGreen __Missing = new CompositeDeclarationGreen();
	    private InternalSyntaxToken kComposite;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ComponentBaseGreen componentBase;
	    private CompositeBodyGreen compositeBody;
	
	    public CompositeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kComposite, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kComposite != null)
			{
				this.AdjustFlagsAndWidth(kComposite);
				this.kComposite = kComposite;
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
			if (componentBase != null)
			{
				this.AdjustFlagsAndWidth(componentBase);
				this.componentBase = componentBase;
			}
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
	    public CompositeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kComposite, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kComposite != null)
			{
				this.AdjustFlagsAndWidth(kComposite);
				this.kComposite = kComposite;
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
			if (componentBase != null)
			{
				this.AdjustFlagsAndWidth(componentBase);
				this.componentBase = componentBase;
			}
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
		private CompositeDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.CompositeDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KComposite { get { return this.kComposite; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ComponentBaseGreen ComponentBase { get { return this.componentBase; } }
	    public CompositeBodyGreen CompositeBody { get { return this.compositeBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kComposite;
	            case 1: return this.name;
	            case 2: return this.tColon;
	            case 3: return this.componentBase;
	            case 4: return this.compositeBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitCompositeDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitCompositeDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeDeclarationGreen(this.Kind, this.kComposite, this.name, this.tColon, this.componentBase, this.compositeBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeDeclarationGreen(this.Kind, this.kComposite, this.name, this.tColon, this.componentBase, this.compositeBody, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeDeclarationGreen Update(InternalSyntaxToken kComposite, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody)
	    {
	        if (this.KComposite != kComposite ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ComponentBase != componentBase ||
				this.CompositeBody != compositeBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeDeclaration(kComposite, name, tColon, componentBase, compositeBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompositeBodyGreen : GreenSyntaxNode
	{
	    internal static readonly CompositeBodyGreen __Missing = new CompositeBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private CompositeElementsGreen compositeElements;
	    private InternalSyntaxToken tCloseBrace;
	
	    public CompositeBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (compositeElements != null)
			{
				this.AdjustFlagsAndWidth(compositeElements);
				this.compositeElements = compositeElements;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public CompositeBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (compositeElements != null)
			{
				this.AdjustFlagsAndWidth(compositeElements);
				this.compositeElements = compositeElements;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private CompositeBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.CompositeBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public CompositeElementsGreen CompositeElements { get { return this.compositeElements; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.compositeElements;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitCompositeBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitCompositeBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeBodyGreen(this.Kind, this.tOpenBrace, this.compositeElements, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeBodyGreen(this.Kind, this.tOpenBrace, this.compositeElements, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeBodyGreen Update(InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.CompositeElements != compositeElements ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeBody(tOpenBrace, compositeElements, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssemblyDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly AssemblyDeclarationGreen __Missing = new AssemblyDeclarationGreen();
	    private InternalSyntaxToken kAssembly;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ComponentBaseGreen componentBase;
	    private CompositeBodyGreen compositeBody;
	
	    public AssemblyDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
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
			if (componentBase != null)
			{
				this.AdjustFlagsAndWidth(componentBase);
				this.componentBase = componentBase;
			}
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
	    public AssemblyDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
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
			if (componentBase != null)
			{
				this.AdjustFlagsAndWidth(componentBase);
				this.componentBase = componentBase;
			}
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
		private AssemblyDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AssemblyDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAssembly { get { return this.kAssembly; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ComponentBaseGreen ComponentBase { get { return this.componentBase; } }
	    public CompositeBodyGreen CompositeBody { get { return this.compositeBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AssemblyDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAssembly;
	            case 1: return this.name;
	            case 2: return this.tColon;
	            case 3: return this.componentBase;
	            case 4: return this.compositeBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAssemblyDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAssemblyDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssemblyDeclarationGreen(this.Kind, this.kAssembly, this.name, this.tColon, this.componentBase, this.compositeBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssemblyDeclarationGreen(this.Kind, this.kAssembly, this.name, this.tColon, this.componentBase, this.compositeBody, this.GetDiagnostics(), annotations);
	    }
	
	    public AssemblyDeclarationGreen Update(InternalSyntaxToken kAssembly, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody)
	    {
	        if (this.KAssembly != kAssembly ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ComponentBase != componentBase ||
				this.CompositeBody != compositeBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AssemblyDeclaration(kAssembly, name, tColon, componentBase, compositeBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssemblyDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompositeElementsGreen : GreenSyntaxNode
	{
	    internal static readonly CompositeElementsGreen __Missing = new CompositeElementsGreen();
	    private GreenNode compositeElement;
	
	    public CompositeElementsGreen(SoalSyntaxKind kind, GreenNode compositeElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (compositeElement != null)
			{
				this.AdjustFlagsAndWidth(compositeElement);
				this.compositeElement = compositeElement;
			}
	    }
	
	    public CompositeElementsGreen(SoalSyntaxKind kind, GreenNode compositeElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (compositeElement != null)
			{
				this.AdjustFlagsAndWidth(compositeElement);
				this.compositeElement = compositeElement;
			}
	    }
	
		private CompositeElementsGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.CompositeElements, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CompositeElementGreen> CompositeElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CompositeElementGreen>(this.compositeElement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeElementsSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.compositeElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitCompositeElementsGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitCompositeElementsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeElementsGreen(this.Kind, this.compositeElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeElementsGreen(this.Kind, this.compositeElement, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeElementsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CompositeElementGreen> compositeElement)
	    {
	        if (this.CompositeElement != compositeElement)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElements(compositeElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompositeElementGreen : GreenSyntaxNode
	{
	    internal static readonly CompositeElementGreen __Missing = new CompositeElementGreen();
	    private ComponentServiceGreen componentService;
	    private ComponentReferenceGreen componentReference;
	    private ComponentPropertyGreen componentProperty;
	    private ComponentImplementationGreen componentImplementation;
	    private ComponentLanguageGreen componentLanguage;
	    private CompositeComponentGreen compositeComponent;
	    private CompositeWireGreen compositeWire;
	
	    public CompositeElementGreen(SoalSyntaxKind kind, ComponentServiceGreen componentService, ComponentReferenceGreen componentReference, ComponentPropertyGreen componentProperty, ComponentImplementationGreen componentImplementation, ComponentLanguageGreen componentLanguage, CompositeComponentGreen compositeComponent, CompositeWireGreen compositeWire)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (componentService != null)
			{
				this.AdjustFlagsAndWidth(componentService);
				this.componentService = componentService;
			}
			if (componentReference != null)
			{
				this.AdjustFlagsAndWidth(componentReference);
				this.componentReference = componentReference;
			}
			if (componentProperty != null)
			{
				this.AdjustFlagsAndWidth(componentProperty);
				this.componentProperty = componentProperty;
			}
			if (componentImplementation != null)
			{
				this.AdjustFlagsAndWidth(componentImplementation);
				this.componentImplementation = componentImplementation;
			}
			if (componentLanguage != null)
			{
				this.AdjustFlagsAndWidth(componentLanguage);
				this.componentLanguage = componentLanguage;
			}
			if (compositeComponent != null)
			{
				this.AdjustFlagsAndWidth(compositeComponent);
				this.compositeComponent = compositeComponent;
			}
			if (compositeWire != null)
			{
				this.AdjustFlagsAndWidth(compositeWire);
				this.compositeWire = compositeWire;
			}
	    }
	
	    public CompositeElementGreen(SoalSyntaxKind kind, ComponentServiceGreen componentService, ComponentReferenceGreen componentReference, ComponentPropertyGreen componentProperty, ComponentImplementationGreen componentImplementation, ComponentLanguageGreen componentLanguage, CompositeComponentGreen compositeComponent, CompositeWireGreen compositeWire, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (componentService != null)
			{
				this.AdjustFlagsAndWidth(componentService);
				this.componentService = componentService;
			}
			if (componentReference != null)
			{
				this.AdjustFlagsAndWidth(componentReference);
				this.componentReference = componentReference;
			}
			if (componentProperty != null)
			{
				this.AdjustFlagsAndWidth(componentProperty);
				this.componentProperty = componentProperty;
			}
			if (componentImplementation != null)
			{
				this.AdjustFlagsAndWidth(componentImplementation);
				this.componentImplementation = componentImplementation;
			}
			if (componentLanguage != null)
			{
				this.AdjustFlagsAndWidth(componentLanguage);
				this.componentLanguage = componentLanguage;
			}
			if (compositeComponent != null)
			{
				this.AdjustFlagsAndWidth(compositeComponent);
				this.compositeComponent = compositeComponent;
			}
			if (compositeWire != null)
			{
				this.AdjustFlagsAndWidth(compositeWire);
				this.compositeWire = compositeWire;
			}
	    }
	
		private CompositeElementGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.CompositeElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ComponentServiceGreen ComponentService { get { return this.componentService; } }
	    public ComponentReferenceGreen ComponentReference { get { return this.componentReference; } }
	    public ComponentPropertyGreen ComponentProperty { get { return this.componentProperty; } }
	    public ComponentImplementationGreen ComponentImplementation { get { return this.componentImplementation; } }
	    public ComponentLanguageGreen ComponentLanguage { get { return this.componentLanguage; } }
	    public CompositeComponentGreen CompositeComponent { get { return this.compositeComponent; } }
	    public CompositeWireGreen CompositeWire { get { return this.compositeWire; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeElementSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.componentService;
	            case 1: return this.componentReference;
	            case 2: return this.componentProperty;
	            case 3: return this.componentImplementation;
	            case 4: return this.componentLanguage;
	            case 5: return this.compositeComponent;
	            case 6: return this.compositeWire;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitCompositeElementGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitCompositeElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, this.compositeComponent, this.compositeWire, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, this.compositeComponent, this.compositeWire, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeElementGreen Update(ComponentServiceGreen componentService)
	    {
	        if (this.componentService != componentService)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentService);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementGreen Update(ComponentReferenceGreen componentReference)
	    {
	        if (this.componentReference != componentReference)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementGreen Update(ComponentPropertyGreen componentProperty)
	    {
	        if (this.componentProperty != componentProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementGreen Update(ComponentImplementationGreen componentImplementation)
	    {
	        if (this.componentImplementation != componentImplementation)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentImplementation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementGreen Update(ComponentLanguageGreen componentLanguage)
	    {
	        if (this.componentLanguage != componentLanguage)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentLanguage);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementGreen Update(CompositeComponentGreen compositeComponent)
	    {
	        if (this.compositeComponent != compositeComponent)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(compositeComponent);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementGreen Update(CompositeWireGreen compositeWire)
	    {
	        if (this.compositeWire != compositeWire)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(compositeWire);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompositeComponentGreen : GreenSyntaxNode
	{
	    internal static readonly CompositeComponentGreen __Missing = new CompositeComponentGreen();
	    private InternalSyntaxToken kComponent;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public CompositeComponentGreen(SoalSyntaxKind kind, InternalSyntaxToken kComponent, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kComponent != null)
			{
				this.AdjustFlagsAndWidth(kComponent);
				this.kComponent = kComponent;
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
	
	    public CompositeComponentGreen(SoalSyntaxKind kind, InternalSyntaxToken kComponent, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kComponent != null)
			{
				this.AdjustFlagsAndWidth(kComponent);
				this.kComponent = kComponent;
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
	
		private CompositeComponentGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.CompositeComponent, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KComponent { get { return this.kComponent; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeComponentSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kComponent;
	            case 1: return this.qualifier;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitCompositeComponentGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitCompositeComponentGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeComponentGreen(this.Kind, this.kComponent, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeComponentGreen(this.Kind, this.kComponent, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeComponentGreen Update(InternalSyntaxToken kComponent, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KComponent != kComponent ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeComponent(kComponent, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeComponentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CompositeWireGreen : GreenSyntaxNode
	{
	    internal static readonly CompositeWireGreen __Missing = new CompositeWireGreen();
	    private InternalSyntaxToken kWire;
	    private WireSourceGreen wireSource;
	    private InternalSyntaxToken kTo;
	    private WireTargetGreen wireTarget;
	    private InternalSyntaxToken tSemicolon;
	
	    public CompositeWireGreen(SoalSyntaxKind kind, InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kWire != null)
			{
				this.AdjustFlagsAndWidth(kWire);
				this.kWire = kWire;
			}
			if (wireSource != null)
			{
				this.AdjustFlagsAndWidth(wireSource);
				this.wireSource = wireSource;
			}
			if (kTo != null)
			{
				this.AdjustFlagsAndWidth(kTo);
				this.kTo = kTo;
			}
			if (wireTarget != null)
			{
				this.AdjustFlagsAndWidth(wireTarget);
				this.wireTarget = wireTarget;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public CompositeWireGreen(SoalSyntaxKind kind, InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kWire != null)
			{
				this.AdjustFlagsAndWidth(kWire);
				this.kWire = kWire;
			}
			if (wireSource != null)
			{
				this.AdjustFlagsAndWidth(wireSource);
				this.wireSource = wireSource;
			}
			if (kTo != null)
			{
				this.AdjustFlagsAndWidth(kTo);
				this.kTo = kTo;
			}
			if (wireTarget != null)
			{
				this.AdjustFlagsAndWidth(wireTarget);
				this.wireTarget = wireTarget;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private CompositeWireGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.CompositeWire, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KWire { get { return this.kWire; } }
	    public WireSourceGreen WireSource { get { return this.wireSource; } }
	    public InternalSyntaxToken KTo { get { return this.kTo; } }
	    public WireTargetGreen WireTarget { get { return this.wireTarget; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeWireSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kWire;
	            case 1: return this.wireSource;
	            case 2: return this.kTo;
	            case 3: return this.wireTarget;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitCompositeWireGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitCompositeWireGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeWireGreen(this.Kind, this.kWire, this.wireSource, this.kTo, this.wireTarget, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeWireGreen(this.Kind, this.kWire, this.wireSource, this.kTo, this.wireTarget, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeWireGreen Update(InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KWire != kWire ||
				this.WireSource != wireSource ||
				this.KTo != kTo ||
				this.WireTarget != wireTarget ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeWire(kWire, wireSource, kTo, wireTarget, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeWireGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WireSourceGreen : GreenSyntaxNode
	{
	    internal static readonly WireSourceGreen __Missing = new WireSourceGreen();
	    private QualifierGreen qualifier;
	
	    public WireSourceGreen(SoalSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public WireSourceGreen(SoalSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private WireSourceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.WireSource, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WireSourceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitWireSourceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitWireSourceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WireSourceGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WireSourceGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public WireSourceGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WireSource(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WireSourceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WireTargetGreen : GreenSyntaxNode
	{
	    internal static readonly WireTargetGreen __Missing = new WireTargetGreen();
	    private QualifierGreen qualifier;
	
	    public WireTargetGreen(SoalSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public WireTargetGreen(SoalSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private WireTargetGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.WireTarget, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WireTargetSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitWireTargetGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitWireTargetGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WireTargetGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WireTargetGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public WireTargetGreen Update(QualifierGreen qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WireTarget(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WireTargetGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeploymentDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly DeploymentDeclarationGreen __Missing = new DeploymentDeclarationGreen();
	    private InternalSyntaxToken kDeployment;
	    private NameGreen name;
	    private DeploymentBodyGreen deploymentBody;
	
	    public DeploymentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kDeployment, NameGreen name, DeploymentBodyGreen deploymentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kDeployment != null)
			{
				this.AdjustFlagsAndWidth(kDeployment);
				this.kDeployment = kDeployment;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (deploymentBody != null)
			{
				this.AdjustFlagsAndWidth(deploymentBody);
				this.deploymentBody = deploymentBody;
			}
	    }
	
	    public DeploymentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kDeployment, NameGreen name, DeploymentBodyGreen deploymentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kDeployment != null)
			{
				this.AdjustFlagsAndWidth(kDeployment);
				this.kDeployment = kDeployment;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (deploymentBody != null)
			{
				this.AdjustFlagsAndWidth(deploymentBody);
				this.deploymentBody = deploymentBody;
			}
	    }
	
		private DeploymentDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DeploymentDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDeployment { get { return this.kDeployment; } }
	    public NameGreen Name { get { return this.name; } }
	    public DeploymentBodyGreen DeploymentBody { get { return this.deploymentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDeployment;
	            case 1: return this.name;
	            case 2: return this.deploymentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDeploymentDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDeploymentDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentDeclarationGreen(this.Kind, this.kDeployment, this.name, this.deploymentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentDeclarationGreen(this.Kind, this.kDeployment, this.name, this.deploymentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentDeclarationGreen Update(InternalSyntaxToken kDeployment, NameGreen name, DeploymentBodyGreen deploymentBody)
	    {
	        if (this.KDeployment != kDeployment ||
				this.Name != name ||
				this.DeploymentBody != deploymentBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentDeclaration(kDeployment, name, deploymentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeploymentBodyGreen : GreenSyntaxNode
	{
	    internal static readonly DeploymentBodyGreen __Missing = new DeploymentBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private DeploymentElementsGreen deploymentElements;
	    private InternalSyntaxToken tCloseBrace;
	
	    public DeploymentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (deploymentElements != null)
			{
				this.AdjustFlagsAndWidth(deploymentElements);
				this.deploymentElements = deploymentElements;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public DeploymentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (deploymentElements != null)
			{
				this.AdjustFlagsAndWidth(deploymentElements);
				this.deploymentElements = deploymentElements;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private DeploymentBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DeploymentBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public DeploymentElementsGreen DeploymentElements { get { return this.deploymentElements; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.deploymentElements;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDeploymentBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDeploymentBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentBodyGreen(this.Kind, this.tOpenBrace, this.deploymentElements, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentBodyGreen(this.Kind, this.tOpenBrace, this.deploymentElements, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentBodyGreen Update(InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.DeploymentElements != deploymentElements ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentBody(tOpenBrace, deploymentElements, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeploymentElementsGreen : GreenSyntaxNode
	{
	    internal static readonly DeploymentElementsGreen __Missing = new DeploymentElementsGreen();
	    private GreenNode deploymentElement;
	
	    public DeploymentElementsGreen(SoalSyntaxKind kind, GreenNode deploymentElement)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (deploymentElement != null)
			{
				this.AdjustFlagsAndWidth(deploymentElement);
				this.deploymentElement = deploymentElement;
			}
	    }
	
	    public DeploymentElementsGreen(SoalSyntaxKind kind, GreenNode deploymentElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (deploymentElement != null)
			{
				this.AdjustFlagsAndWidth(deploymentElement);
				this.deploymentElement = deploymentElement;
			}
	    }
	
		private DeploymentElementsGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DeploymentElements, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeploymentElementGreen> DeploymentElement { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeploymentElementGreen>(this.deploymentElement); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentElementsSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.deploymentElement;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDeploymentElementsGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDeploymentElementsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentElementsGreen(this.Kind, this.deploymentElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentElementsGreen(this.Kind, this.deploymentElement, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentElementsGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeploymentElementGreen> deploymentElement)
	    {
	        if (this.DeploymentElement != deploymentElement)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElements(deploymentElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeploymentElementGreen : GreenSyntaxNode
	{
	    internal static readonly DeploymentElementGreen __Missing = new DeploymentElementGreen();
	    private EnvironmentDeclarationGreen environmentDeclaration;
	    private CompositeWireGreen compositeWire;
	
	    public DeploymentElementGreen(SoalSyntaxKind kind, EnvironmentDeclarationGreen environmentDeclaration, CompositeWireGreen compositeWire)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (environmentDeclaration != null)
			{
				this.AdjustFlagsAndWidth(environmentDeclaration);
				this.environmentDeclaration = environmentDeclaration;
			}
			if (compositeWire != null)
			{
				this.AdjustFlagsAndWidth(compositeWire);
				this.compositeWire = compositeWire;
			}
	    }
	
	    public DeploymentElementGreen(SoalSyntaxKind kind, EnvironmentDeclarationGreen environmentDeclaration, CompositeWireGreen compositeWire, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (environmentDeclaration != null)
			{
				this.AdjustFlagsAndWidth(environmentDeclaration);
				this.environmentDeclaration = environmentDeclaration;
			}
			if (compositeWire != null)
			{
				this.AdjustFlagsAndWidth(compositeWire);
				this.compositeWire = compositeWire;
			}
	    }
	
		private DeploymentElementGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DeploymentElement, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public EnvironmentDeclarationGreen EnvironmentDeclaration { get { return this.environmentDeclaration; } }
	    public CompositeWireGreen CompositeWire { get { return this.compositeWire; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentElementSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.environmentDeclaration;
	            case 1: return this.compositeWire;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDeploymentElementGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDeploymentElementGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentElementGreen(this.Kind, this.environmentDeclaration, this.compositeWire, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentElementGreen(this.Kind, this.environmentDeclaration, this.compositeWire, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentElementGreen Update(EnvironmentDeclarationGreen environmentDeclaration)
	    {
	        if (this.environmentDeclaration != environmentDeclaration)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElement(environmentDeclaration);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeploymentElementGreen Update(CompositeWireGreen compositeWire)
	    {
	        if (this.compositeWire != compositeWire)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElement(compositeWire);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnvironmentDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly EnvironmentDeclarationGreen __Missing = new EnvironmentDeclarationGreen();
	    private InternalSyntaxToken kEnvironment;
	    private NameGreen name;
	    private EnvironmentBodyGreen environmentBody;
	
	    public EnvironmentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEnvironment, NameGreen name, EnvironmentBodyGreen environmentBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kEnvironment != null)
			{
				this.AdjustFlagsAndWidth(kEnvironment);
				this.kEnvironment = kEnvironment;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (environmentBody != null)
			{
				this.AdjustFlagsAndWidth(environmentBody);
				this.environmentBody = environmentBody;
			}
	    }
	
	    public EnvironmentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEnvironment, NameGreen name, EnvironmentBodyGreen environmentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kEnvironment != null)
			{
				this.AdjustFlagsAndWidth(kEnvironment);
				this.kEnvironment = kEnvironment;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (environmentBody != null)
			{
				this.AdjustFlagsAndWidth(environmentBody);
				this.environmentBody = environmentBody;
			}
	    }
	
		private EnvironmentDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EnvironmentDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEnvironment { get { return this.kEnvironment; } }
	    public NameGreen Name { get { return this.name; } }
	    public EnvironmentBodyGreen EnvironmentBody { get { return this.environmentBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnvironmentDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnvironment;
	            case 1: return this.name;
	            case 2: return this.environmentBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnvironmentDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnvironmentDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnvironmentDeclarationGreen(this.Kind, this.kEnvironment, this.name, this.environmentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnvironmentDeclarationGreen(this.Kind, this.kEnvironment, this.name, this.environmentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EnvironmentDeclarationGreen Update(InternalSyntaxToken kEnvironment, NameGreen name, EnvironmentBodyGreen environmentBody)
	    {
	        if (this.KEnvironment != kEnvironment ||
				this.Name != name ||
				this.EnvironmentBody != environmentBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnvironmentDeclaration(kEnvironment, name, environmentBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnvironmentDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EnvironmentBodyGreen : GreenSyntaxNode
	{
	    internal static readonly EnvironmentBodyGreen __Missing = new EnvironmentBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private RuntimeDeclarationGreen runtimeDeclaration;
	    private GreenNode runtimeReference;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EnvironmentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, GreenNode runtimeReference, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (runtimeDeclaration != null)
			{
				this.AdjustFlagsAndWidth(runtimeDeclaration);
				this.runtimeDeclaration = runtimeDeclaration;
			}
			if (runtimeReference != null)
			{
				this.AdjustFlagsAndWidth(runtimeReference);
				this.runtimeReference = runtimeReference;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public EnvironmentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, GreenNode runtimeReference, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (runtimeDeclaration != null)
			{
				this.AdjustFlagsAndWidth(runtimeDeclaration);
				this.runtimeDeclaration = runtimeDeclaration;
			}
			if (runtimeReference != null)
			{
				this.AdjustFlagsAndWidth(runtimeReference);
				this.runtimeReference = runtimeReference;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private EnvironmentBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EnvironmentBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public RuntimeDeclarationGreen RuntimeDeclaration { get { return this.runtimeDeclaration; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuntimeReferenceGreen> RuntimeReference { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuntimeReferenceGreen>(this.runtimeReference); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnvironmentBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.runtimeDeclaration;
	            case 2: return this.runtimeReference;
	            case 3: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEnvironmentBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEnvironmentBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnvironmentBodyGreen(this.Kind, this.tOpenBrace, this.runtimeDeclaration, this.runtimeReference, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnvironmentBodyGreen(this.Kind, this.tOpenBrace, this.runtimeDeclaration, this.runtimeReference, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EnvironmentBodyGreen Update(InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuntimeReferenceGreen> runtimeReference, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.RuntimeDeclaration != runtimeDeclaration ||
				this.RuntimeReference != runtimeReference ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnvironmentBody(tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnvironmentBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RuntimeDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly RuntimeDeclarationGreen __Missing = new RuntimeDeclarationGreen();
	    private InternalSyntaxToken kRuntime;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public RuntimeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kRuntime, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kRuntime != null)
			{
				this.AdjustFlagsAndWidth(kRuntime);
				this.kRuntime = kRuntime;
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
	
	    public RuntimeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kRuntime, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kRuntime != null)
			{
				this.AdjustFlagsAndWidth(kRuntime);
				this.kRuntime = kRuntime;
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
	
		private RuntimeDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.RuntimeDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRuntime { get { return this.kRuntime; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RuntimeDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRuntime;
	            case 1: return this.name;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitRuntimeDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitRuntimeDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RuntimeDeclarationGreen(this.Kind, this.kRuntime, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RuntimeDeclarationGreen(this.Kind, this.kRuntime, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public RuntimeDeclarationGreen Update(InternalSyntaxToken kRuntime, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KRuntime != kRuntime ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RuntimeDeclaration(kRuntime, name, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuntimeDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RuntimeReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly RuntimeReferenceGreen __Missing = new RuntimeReferenceGreen();
	    private AssemblyReferenceGreen assemblyReference;
	    private DatabaseReferenceGreen databaseReference;
	
	    public RuntimeReferenceGreen(SoalSyntaxKind kind, AssemblyReferenceGreen assemblyReference, DatabaseReferenceGreen databaseReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (assemblyReference != null)
			{
				this.AdjustFlagsAndWidth(assemblyReference);
				this.assemblyReference = assemblyReference;
			}
			if (databaseReference != null)
			{
				this.AdjustFlagsAndWidth(databaseReference);
				this.databaseReference = databaseReference;
			}
	    }
	
	    public RuntimeReferenceGreen(SoalSyntaxKind kind, AssemblyReferenceGreen assemblyReference, DatabaseReferenceGreen databaseReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (assemblyReference != null)
			{
				this.AdjustFlagsAndWidth(assemblyReference);
				this.assemblyReference = assemblyReference;
			}
			if (databaseReference != null)
			{
				this.AdjustFlagsAndWidth(databaseReference);
				this.databaseReference = databaseReference;
			}
	    }
	
		private RuntimeReferenceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.RuntimeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public AssemblyReferenceGreen AssemblyReference { get { return this.assemblyReference; } }
	    public DatabaseReferenceGreen DatabaseReference { get { return this.databaseReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RuntimeReferenceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.assemblyReference;
	            case 1: return this.databaseReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitRuntimeReferenceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitRuntimeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RuntimeReferenceGreen(this.Kind, this.assemblyReference, this.databaseReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RuntimeReferenceGreen(this.Kind, this.assemblyReference, this.databaseReference, this.GetDiagnostics(), annotations);
	    }
	
	    public RuntimeReferenceGreen Update(AssemblyReferenceGreen assemblyReference)
	    {
	        if (this.assemblyReference != assemblyReference)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RuntimeReference(assemblyReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuntimeReferenceGreen)newNode;
	        }
	        return this;
	    }
	
	    public RuntimeReferenceGreen Update(DatabaseReferenceGreen databaseReference)
	    {
	        if (this.databaseReference != databaseReference)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RuntimeReference(databaseReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuntimeReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AssemblyReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly AssemblyReferenceGreen __Missing = new AssemblyReferenceGreen();
	    private InternalSyntaxToken kAssembly;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public AssemblyReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
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
	
	    public AssemblyReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
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
	
		private AssemblyReferenceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.AssemblyReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAssembly { get { return this.kAssembly; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AssemblyReferenceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAssembly;
	            case 1: return this.qualifier;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitAssemblyReferenceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitAssemblyReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssemblyReferenceGreen(this.Kind, this.kAssembly, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssemblyReferenceGreen(this.Kind, this.kAssembly, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public AssemblyReferenceGreen Update(InternalSyntaxToken kAssembly, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KAssembly != kAssembly ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AssemblyReference(kAssembly, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssemblyReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DatabaseReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly DatabaseReferenceGreen __Missing = new DatabaseReferenceGreen();
	    private InternalSyntaxToken kDatabase;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public DatabaseReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kDatabase, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kDatabase != null)
			{
				this.AdjustFlagsAndWidth(kDatabase);
				this.kDatabase = kDatabase;
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
	
	    public DatabaseReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kDatabase, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kDatabase != null)
			{
				this.AdjustFlagsAndWidth(kDatabase);
				this.kDatabase = kDatabase;
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
	
		private DatabaseReferenceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.DatabaseReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KDatabase { get { return this.kDatabase; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DatabaseReferenceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDatabase;
	            case 1: return this.qualifier;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDatabaseReferenceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDatabaseReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DatabaseReferenceGreen(this.Kind, this.kDatabase, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DatabaseReferenceGreen(this.Kind, this.kDatabase, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public DatabaseReferenceGreen Update(InternalSyntaxToken kDatabase, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KDatabase != kDatabase ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DatabaseReference(kDatabase, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DatabaseReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BindingDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly BindingDeclarationGreen __Missing = new BindingDeclarationGreen();
	    private InternalSyntaxToken kBinding;
	    private NameGreen name;
	    private BindingBodyGreen bindingBody;
	
	    public BindingDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, NameGreen name, BindingBodyGreen bindingBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (bindingBody != null)
			{
				this.AdjustFlagsAndWidth(bindingBody);
				this.bindingBody = bindingBody;
			}
	    }
	
	    public BindingDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, NameGreen name, BindingBodyGreen bindingBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (bindingBody != null)
			{
				this.AdjustFlagsAndWidth(bindingBody);
				this.bindingBody = bindingBody;
			}
	    }
	
		private BindingDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.BindingDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBinding { get { return this.kBinding; } }
	    public NameGreen Name { get { return this.name; } }
	    public BindingBodyGreen BindingBody { get { return this.bindingBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BindingDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBinding;
	            case 1: return this.name;
	            case 2: return this.bindingBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitBindingDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitBindingDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BindingDeclarationGreen(this.Kind, this.kBinding, this.name, this.bindingBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BindingDeclarationGreen(this.Kind, this.kBinding, this.name, this.bindingBody, this.GetDiagnostics(), annotations);
	    }
	
	    public BindingDeclarationGreen Update(InternalSyntaxToken kBinding, NameGreen name, BindingBodyGreen bindingBody)
	    {
	        if (this.KBinding != kBinding ||
				this.Name != name ||
				this.BindingBody != bindingBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BindingDeclaration(kBinding, name, bindingBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BindingDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BindingBodyGreen : GreenSyntaxNode
	{
	    internal static readonly BindingBodyGreen __Missing = new BindingBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private BindingLayersGreen bindingLayers;
	    private InternalSyntaxToken tCloseBrace;
	
	    public BindingBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (bindingLayers != null)
			{
				this.AdjustFlagsAndWidth(bindingLayers);
				this.bindingLayers = bindingLayers;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public BindingBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (bindingLayers != null)
			{
				this.AdjustFlagsAndWidth(bindingLayers);
				this.bindingLayers = bindingLayers;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private BindingBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.BindingBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public BindingLayersGreen BindingLayers { get { return this.bindingLayers; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BindingBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.bindingLayers;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitBindingBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitBindingBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BindingBodyGreen(this.Kind, this.tOpenBrace, this.bindingLayers, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BindingBodyGreen(this.Kind, this.tOpenBrace, this.bindingLayers, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public BindingBodyGreen Update(InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.BindingLayers != bindingLayers ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BindingBody(tOpenBrace, bindingLayers, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BindingBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BindingLayersGreen : GreenSyntaxNode
	{
	    internal static readonly BindingLayersGreen __Missing = new BindingLayersGreen();
	    private TransportLayerGreen transportLayer;
	    private GreenNode encodingLayer;
	    private GreenNode protocolLayer;
	
	    public BindingLayersGreen(SoalSyntaxKind kind, TransportLayerGreen transportLayer, GreenNode encodingLayer, GreenNode protocolLayer)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (transportLayer != null)
			{
				this.AdjustFlagsAndWidth(transportLayer);
				this.transportLayer = transportLayer;
			}
			if (encodingLayer != null)
			{
				this.AdjustFlagsAndWidth(encodingLayer);
				this.encodingLayer = encodingLayer;
			}
			if (protocolLayer != null)
			{
				this.AdjustFlagsAndWidth(protocolLayer);
				this.protocolLayer = protocolLayer;
			}
	    }
	
	    public BindingLayersGreen(SoalSyntaxKind kind, TransportLayerGreen transportLayer, GreenNode encodingLayer, GreenNode protocolLayer, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (transportLayer != null)
			{
				this.AdjustFlagsAndWidth(transportLayer);
				this.transportLayer = transportLayer;
			}
			if (encodingLayer != null)
			{
				this.AdjustFlagsAndWidth(encodingLayer);
				this.encodingLayer = encodingLayer;
			}
			if (protocolLayer != null)
			{
				this.AdjustFlagsAndWidth(protocolLayer);
				this.protocolLayer = protocolLayer;
			}
	    }
	
		private BindingLayersGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.BindingLayers, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TransportLayerGreen TransportLayer { get { return this.transportLayer; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EncodingLayerGreen> EncodingLayer { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EncodingLayerGreen>(this.encodingLayer); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ProtocolLayerGreen> ProtocolLayer { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ProtocolLayerGreen>(this.protocolLayer); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BindingLayersSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.transportLayer;
	            case 1: return this.encodingLayer;
	            case 2: return this.protocolLayer;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitBindingLayersGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitBindingLayersGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BindingLayersGreen(this.Kind, this.transportLayer, this.encodingLayer, this.protocolLayer, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BindingLayersGreen(this.Kind, this.transportLayer, this.encodingLayer, this.protocolLayer, this.GetDiagnostics(), annotations);
	    }
	
	    public BindingLayersGreen Update(TransportLayerGreen transportLayer, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EncodingLayerGreen> encodingLayer, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ProtocolLayerGreen> protocolLayer)
	    {
	        if (this.TransportLayer != transportLayer ||
				this.EncodingLayer != encodingLayer ||
				this.ProtocolLayer != protocolLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BindingLayers(transportLayer, encodingLayer, protocolLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BindingLayersGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TransportLayerGreen : GreenSyntaxNode
	{
	    internal static readonly TransportLayerGreen __Missing = new TransportLayerGreen();
	    private HttpTransportLayerGreen httpTransportLayer;
	    private RestTransportLayerGreen restTransportLayer;
	    private WebSocketTransportLayerGreen webSocketTransportLayer;
	
	    public TransportLayerGreen(SoalSyntaxKind kind, HttpTransportLayerGreen httpTransportLayer, RestTransportLayerGreen restTransportLayer, WebSocketTransportLayerGreen webSocketTransportLayer)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (httpTransportLayer != null)
			{
				this.AdjustFlagsAndWidth(httpTransportLayer);
				this.httpTransportLayer = httpTransportLayer;
			}
			if (restTransportLayer != null)
			{
				this.AdjustFlagsAndWidth(restTransportLayer);
				this.restTransportLayer = restTransportLayer;
			}
			if (webSocketTransportLayer != null)
			{
				this.AdjustFlagsAndWidth(webSocketTransportLayer);
				this.webSocketTransportLayer = webSocketTransportLayer;
			}
	    }
	
	    public TransportLayerGreen(SoalSyntaxKind kind, HttpTransportLayerGreen httpTransportLayer, RestTransportLayerGreen restTransportLayer, WebSocketTransportLayerGreen webSocketTransportLayer, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (httpTransportLayer != null)
			{
				this.AdjustFlagsAndWidth(httpTransportLayer);
				this.httpTransportLayer = httpTransportLayer;
			}
			if (restTransportLayer != null)
			{
				this.AdjustFlagsAndWidth(restTransportLayer);
				this.restTransportLayer = restTransportLayer;
			}
			if (webSocketTransportLayer != null)
			{
				this.AdjustFlagsAndWidth(webSocketTransportLayer);
				this.webSocketTransportLayer = webSocketTransportLayer;
			}
	    }
	
		private TransportLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.TransportLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public HttpTransportLayerGreen HttpTransportLayer { get { return this.httpTransportLayer; } }
	    public RestTransportLayerGreen RestTransportLayer { get { return this.restTransportLayer; } }
	    public WebSocketTransportLayerGreen WebSocketTransportLayer { get { return this.webSocketTransportLayer; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.TransportLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.httpTransportLayer;
	            case 1: return this.restTransportLayer;
	            case 2: return this.webSocketTransportLayer;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitTransportLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitTransportLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TransportLayerGreen(this.Kind, this.httpTransportLayer, this.restTransportLayer, this.webSocketTransportLayer, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TransportLayerGreen(this.Kind, this.httpTransportLayer, this.restTransportLayer, this.webSocketTransportLayer, this.GetDiagnostics(), annotations);
	    }
	
	    public TransportLayerGreen Update(HttpTransportLayerGreen httpTransportLayer)
	    {
	        if (this.httpTransportLayer != httpTransportLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer(httpTransportLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TransportLayerGreen)newNode;
	        }
	        return this;
	    }
	
	    public TransportLayerGreen Update(RestTransportLayerGreen restTransportLayer)
	    {
	        if (this.restTransportLayer != restTransportLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer(restTransportLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TransportLayerGreen)newNode;
	        }
	        return this;
	    }
	
	    public TransportLayerGreen Update(WebSocketTransportLayerGreen webSocketTransportLayer)
	    {
	        if (this.webSocketTransportLayer != webSocketTransportLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer(webSocketTransportLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TransportLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HttpTransportLayerGreen : GreenSyntaxNode
	{
	    internal static readonly HttpTransportLayerGreen __Missing = new HttpTransportLayerGreen();
	    private InternalSyntaxToken kTransport;
	    private InternalSyntaxToken ihttp;
	    private HttpTransportLayerBodyGreen httpTransportLayerBody;
	
	    public HttpTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kTransport != null)
			{
				this.AdjustFlagsAndWidth(kTransport);
				this.kTransport = kTransport;
			}
			if (ihttp != null)
			{
				this.AdjustFlagsAndWidth(ihttp);
				this.ihttp = ihttp;
			}
			if (httpTransportLayerBody != null)
			{
				this.AdjustFlagsAndWidth(httpTransportLayerBody);
				this.httpTransportLayerBody = httpTransportLayerBody;
			}
	    }
	
	    public HttpTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kTransport != null)
			{
				this.AdjustFlagsAndWidth(kTransport);
				this.kTransport = kTransport;
			}
			if (ihttp != null)
			{
				this.AdjustFlagsAndWidth(ihttp);
				this.ihttp = ihttp;
			}
			if (httpTransportLayerBody != null)
			{
				this.AdjustFlagsAndWidth(httpTransportLayerBody);
				this.httpTransportLayerBody = httpTransportLayerBody;
			}
	    }
	
		private HttpTransportLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTransport { get { return this.kTransport; } }
	    public InternalSyntaxToken IHTTP { get { return this.ihttp; } }
	    public HttpTransportLayerBodyGreen HttpTransportLayerBody { get { return this.httpTransportLayerBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTransport;
	            case 1: return this.ihttp;
	            case 2: return this.httpTransportLayerBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitHttpTransportLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitHttpTransportLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerGreen(this.Kind, this.kTransport, this.ihttp, this.httpTransportLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerGreen(this.Kind, this.kTransport, this.ihttp, this.httpTransportLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerGreen Update(InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody)
	    {
	        if (this.KTransport != kTransport ||
				this.IHTTP != ihttp ||
				this.HttpTransportLayerBody != httpTransportLayerBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayer(kTransport, ihttp, httpTransportLayerBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class HttpTransportLayerBodyGreen : GreenSyntaxNode
	{
	    internal static readonly HttpTransportLayerBodyGreen __Missing = HttpTransportLayerEmptyBodyGreen.__Missing;
	
	    public HttpTransportLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class HttpTransportLayerEmptyBodyGreen : HttpTransportLayerBodyGreen
	{
	    internal static new readonly HttpTransportLayerEmptyBodyGreen __Missing = new HttpTransportLayerEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public HttpTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public HttpTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private HttpTransportLayerEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitHttpTransportLayerEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitHttpTransportLayerEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HttpTransportLayerNonEmptyBodyGreen : HttpTransportLayerBodyGreen
	{
	    internal static new readonly HttpTransportLayerNonEmptyBodyGreen __Missing = new HttpTransportLayerNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode httpTransportLayerProperties;
	    private InternalSyntaxToken tCloseBrace;
	
	    public HttpTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode httpTransportLayerProperties, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (httpTransportLayerProperties != null)
			{
				this.AdjustFlagsAndWidth(httpTransportLayerProperties);
				this.httpTransportLayerProperties = httpTransportLayerProperties;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public HttpTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode httpTransportLayerProperties, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (httpTransportLayerProperties != null)
			{
				this.AdjustFlagsAndWidth(httpTransportLayerProperties);
				this.httpTransportLayerProperties = httpTransportLayerProperties;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private HttpTransportLayerNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<HttpTransportLayerPropertiesGreen> HttpTransportLayerProperties { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<HttpTransportLayerPropertiesGreen>(this.httpTransportLayerProperties); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.httpTransportLayerProperties;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitHttpTransportLayerNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitHttpTransportLayerNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.httpTransportLayerProperties, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.httpTransportLayerProperties, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<HttpTransportLayerPropertiesGreen> httpTransportLayerProperties, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.HttpTransportLayerProperties != httpTransportLayerProperties ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerNonEmptyBody(tOpenBrace, httpTransportLayerProperties, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RestTransportLayerGreen : GreenSyntaxNode
	{
	    internal static readonly RestTransportLayerGreen __Missing = new RestTransportLayerGreen();
	    private InternalSyntaxToken kTransport;
	    private InternalSyntaxToken irest;
	    private RestTransportLayerBodyGreen restTransportLayerBody;
	
	    public RestTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kTransport != null)
			{
				this.AdjustFlagsAndWidth(kTransport);
				this.kTransport = kTransport;
			}
			if (irest != null)
			{
				this.AdjustFlagsAndWidth(irest);
				this.irest = irest;
			}
			if (restTransportLayerBody != null)
			{
				this.AdjustFlagsAndWidth(restTransportLayerBody);
				this.restTransportLayerBody = restTransportLayerBody;
			}
	    }
	
	    public RestTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kTransport != null)
			{
				this.AdjustFlagsAndWidth(kTransport);
				this.kTransport = kTransport;
			}
			if (irest != null)
			{
				this.AdjustFlagsAndWidth(irest);
				this.irest = irest;
			}
			if (restTransportLayerBody != null)
			{
				this.AdjustFlagsAndWidth(restTransportLayerBody);
				this.restTransportLayerBody = restTransportLayerBody;
			}
	    }
	
		private RestTransportLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.RestTransportLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTransport { get { return this.kTransport; } }
	    public InternalSyntaxToken IREST { get { return this.irest; } }
	    public RestTransportLayerBodyGreen RestTransportLayerBody { get { return this.restTransportLayerBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RestTransportLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTransport;
	            case 1: return this.irest;
	            case 2: return this.restTransportLayerBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitRestTransportLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitRestTransportLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RestTransportLayerGreen(this.Kind, this.kTransport, this.irest, this.restTransportLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RestTransportLayerGreen(this.Kind, this.kTransport, this.irest, this.restTransportLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public RestTransportLayerGreen Update(InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody)
	    {
	        if (this.KTransport != kTransport ||
				this.IREST != irest ||
				this.RestTransportLayerBody != restTransportLayerBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayer(kTransport, irest, restTransportLayerBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RestTransportLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class RestTransportLayerBodyGreen : GreenSyntaxNode
	{
	    internal static readonly RestTransportLayerBodyGreen __Missing = RestTransportLayerEmptyBodyGreen.__Missing;
	
	    public RestTransportLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class RestTransportLayerEmptyBodyGreen : RestTransportLayerBodyGreen
	{
	    internal static new readonly RestTransportLayerEmptyBodyGreen __Missing = new RestTransportLayerEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public RestTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public RestTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private RestTransportLayerEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.RestTransportLayerEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RestTransportLayerEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitRestTransportLayerEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitRestTransportLayerEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RestTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RestTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public RestTransportLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayerEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RestTransportLayerEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RestTransportLayerNonEmptyBodyGreen : RestTransportLayerBodyGreen
	{
	    internal static new readonly RestTransportLayerNonEmptyBodyGreen __Missing = new RestTransportLayerNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public RestTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public RestTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private RestTransportLayerNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.RestTransportLayerNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RestTransportLayerNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitRestTransportLayerNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitRestTransportLayerNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RestTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RestTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public RestTransportLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RestTransportLayerNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WebSocketTransportLayerGreen : GreenSyntaxNode
	{
	    internal static readonly WebSocketTransportLayerGreen __Missing = new WebSocketTransportLayerGreen();
	    private InternalSyntaxToken kTransport;
	    private InternalSyntaxToken iWebSocket;
	    private WebSocketTransportLayerBodyGreen webSocketTransportLayerBody;
	
	    public WebSocketTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kTransport != null)
			{
				this.AdjustFlagsAndWidth(kTransport);
				this.kTransport = kTransport;
			}
			if (iWebSocket != null)
			{
				this.AdjustFlagsAndWidth(iWebSocket);
				this.iWebSocket = iWebSocket;
			}
			if (webSocketTransportLayerBody != null)
			{
				this.AdjustFlagsAndWidth(webSocketTransportLayerBody);
				this.webSocketTransportLayerBody = webSocketTransportLayerBody;
			}
	    }
	
	    public WebSocketTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kTransport != null)
			{
				this.AdjustFlagsAndWidth(kTransport);
				this.kTransport = kTransport;
			}
			if (iWebSocket != null)
			{
				this.AdjustFlagsAndWidth(iWebSocket);
				this.iWebSocket = iWebSocket;
			}
			if (webSocketTransportLayerBody != null)
			{
				this.AdjustFlagsAndWidth(webSocketTransportLayerBody);
				this.webSocketTransportLayerBody = webSocketTransportLayerBody;
			}
	    }
	
		private WebSocketTransportLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.WebSocketTransportLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTransport { get { return this.kTransport; } }
	    public InternalSyntaxToken IWebSocket { get { return this.iWebSocket; } }
	    public WebSocketTransportLayerBodyGreen WebSocketTransportLayerBody { get { return this.webSocketTransportLayerBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WebSocketTransportLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTransport;
	            case 1: return this.iWebSocket;
	            case 2: return this.webSocketTransportLayerBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitWebSocketTransportLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitWebSocketTransportLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WebSocketTransportLayerGreen(this.Kind, this.kTransport, this.iWebSocket, this.webSocketTransportLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WebSocketTransportLayerGreen(this.Kind, this.kTransport, this.iWebSocket, this.webSocketTransportLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public WebSocketTransportLayerGreen Update(InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody)
	    {
	        if (this.KTransport != kTransport ||
				this.IWebSocket != iWebSocket ||
				this.WebSocketTransportLayerBody != webSocketTransportLayerBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayer(kTransport, iWebSocket, webSocketTransportLayerBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WebSocketTransportLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class WebSocketTransportLayerBodyGreen : GreenSyntaxNode
	{
	    internal static readonly WebSocketTransportLayerBodyGreen __Missing = WebSocketTransportLayerEmptyBodyGreen.__Missing;
	
	    public WebSocketTransportLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class WebSocketTransportLayerEmptyBodyGreen : WebSocketTransportLayerBodyGreen
	{
	    internal static new readonly WebSocketTransportLayerEmptyBodyGreen __Missing = new WebSocketTransportLayerEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public WebSocketTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public WebSocketTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private WebSocketTransportLayerEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.WebSocketTransportLayerEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WebSocketTransportLayerEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitWebSocketTransportLayerEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitWebSocketTransportLayerEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WebSocketTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WebSocketTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public WebSocketTransportLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayerEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WebSocketTransportLayerEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WebSocketTransportLayerNonEmptyBodyGreen : WebSocketTransportLayerBodyGreen
	{
	    internal static new readonly WebSocketTransportLayerNonEmptyBodyGreen __Missing = new WebSocketTransportLayerNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public WebSocketTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public WebSocketTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private WebSocketTransportLayerNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.WebSocketTransportLayerNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WebSocketTransportLayerNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitWebSocketTransportLayerNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitWebSocketTransportLayerNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WebSocketTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WebSocketTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public WebSocketTransportLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WebSocketTransportLayerNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HttpTransportLayerPropertiesGreen : GreenSyntaxNode
	{
	    internal static readonly HttpTransportLayerPropertiesGreen __Missing = new HttpTransportLayerPropertiesGreen();
	    private HttpSslPropertyGreen httpSslProperty;
	    private HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty;
	
	    public HttpTransportLayerPropertiesGreen(SoalSyntaxKind kind, HttpSslPropertyGreen httpSslProperty, HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (httpSslProperty != null)
			{
				this.AdjustFlagsAndWidth(httpSslProperty);
				this.httpSslProperty = httpSslProperty;
			}
			if (httpClientAuthenticationProperty != null)
			{
				this.AdjustFlagsAndWidth(httpClientAuthenticationProperty);
				this.httpClientAuthenticationProperty = httpClientAuthenticationProperty;
			}
	    }
	
	    public HttpTransportLayerPropertiesGreen(SoalSyntaxKind kind, HttpSslPropertyGreen httpSslProperty, HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (httpSslProperty != null)
			{
				this.AdjustFlagsAndWidth(httpSslProperty);
				this.httpSslProperty = httpSslProperty;
			}
			if (httpClientAuthenticationProperty != null)
			{
				this.AdjustFlagsAndWidth(httpClientAuthenticationProperty);
				this.httpClientAuthenticationProperty = httpClientAuthenticationProperty;
			}
	    }
	
		private HttpTransportLayerPropertiesGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerProperties, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public HttpSslPropertyGreen HttpSslProperty { get { return this.httpSslProperty; } }
	    public HttpClientAuthenticationPropertyGreen HttpClientAuthenticationProperty { get { return this.httpClientAuthenticationProperty; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerPropertiesSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.httpSslProperty;
	            case 1: return this.httpClientAuthenticationProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitHttpTransportLayerPropertiesGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitHttpTransportLayerPropertiesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerPropertiesGreen(this.Kind, this.httpSslProperty, this.httpClientAuthenticationProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerPropertiesGreen(this.Kind, this.httpSslProperty, this.httpClientAuthenticationProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerPropertiesGreen Update(HttpSslPropertyGreen httpSslProperty)
	    {
	        if (this.httpSslProperty != httpSslProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerProperties(httpSslProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerPropertiesGreen)newNode;
	        }
	        return this;
	    }
	
	    public HttpTransportLayerPropertiesGreen Update(HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty)
	    {
	        if (this.httpClientAuthenticationProperty != httpClientAuthenticationProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerProperties(httpClientAuthenticationProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerPropertiesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HttpSslPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly HttpSslPropertyGreen __Missing = new HttpSslPropertyGreen();
	    private InternalSyntaxToken issl;
	    private InternalSyntaxToken tAssign;
	    private BooleanLiteralGreen booleanLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public HttpSslPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (issl != null)
			{
				this.AdjustFlagsAndWidth(issl);
				this.issl = issl;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public HttpSslPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (issl != null)
			{
				this.AdjustFlagsAndWidth(issl);
				this.issl = issl;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private HttpSslPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.HttpSslProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ISSL { get { return this.issl; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpSslPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.issl;
	            case 1: return this.tAssign;
	            case 2: return this.booleanLiteral;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitHttpSslPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitHttpSslPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpSslPropertyGreen(this.Kind, this.issl, this.tAssign, this.booleanLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpSslPropertyGreen(this.Kind, this.issl, this.tAssign, this.booleanLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpSslPropertyGreen Update(InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.ISSL != issl ||
				this.TAssign != tAssign ||
				this.BooleanLiteral != booleanLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpSslProperty(issl, tAssign, booleanLiteral, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpSslPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HttpClientAuthenticationPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly HttpClientAuthenticationPropertyGreen __Missing = new HttpClientAuthenticationPropertyGreen();
	    private InternalSyntaxToken iClientAuthentication;
	    private InternalSyntaxToken tAssign;
	    private BooleanLiteralGreen booleanLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public HttpClientAuthenticationPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (iClientAuthentication != null)
			{
				this.AdjustFlagsAndWidth(iClientAuthentication);
				this.iClientAuthentication = iClientAuthentication;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public HttpClientAuthenticationPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (iClientAuthentication != null)
			{
				this.AdjustFlagsAndWidth(iClientAuthentication);
				this.iClientAuthentication = iClientAuthentication;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private HttpClientAuthenticationPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.HttpClientAuthenticationProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IClientAuthentication { get { return this.iClientAuthentication; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpClientAuthenticationPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iClientAuthentication;
	            case 1: return this.tAssign;
	            case 2: return this.booleanLiteral;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitHttpClientAuthenticationPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitHttpClientAuthenticationPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpClientAuthenticationPropertyGreen(this.Kind, this.iClientAuthentication, this.tAssign, this.booleanLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpClientAuthenticationPropertyGreen(this.Kind, this.iClientAuthentication, this.tAssign, this.booleanLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpClientAuthenticationPropertyGreen Update(InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.IClientAuthentication != iClientAuthentication ||
				this.TAssign != tAssign ||
				this.BooleanLiteral != booleanLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpClientAuthenticationProperty(iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpClientAuthenticationPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EncodingLayerGreen : GreenSyntaxNode
	{
	    internal static readonly EncodingLayerGreen __Missing = new EncodingLayerGreen();
	    private SoapEncodingLayerGreen soapEncodingLayer;
	    private XmlEncodingLayerGreen xmlEncodingLayer;
	    private JsonEncodingLayerGreen jsonEncodingLayer;
	
	    public EncodingLayerGreen(SoalSyntaxKind kind, SoapEncodingLayerGreen soapEncodingLayer, XmlEncodingLayerGreen xmlEncodingLayer, JsonEncodingLayerGreen jsonEncodingLayer)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (soapEncodingLayer != null)
			{
				this.AdjustFlagsAndWidth(soapEncodingLayer);
				this.soapEncodingLayer = soapEncodingLayer;
			}
			if (xmlEncodingLayer != null)
			{
				this.AdjustFlagsAndWidth(xmlEncodingLayer);
				this.xmlEncodingLayer = xmlEncodingLayer;
			}
			if (jsonEncodingLayer != null)
			{
				this.AdjustFlagsAndWidth(jsonEncodingLayer);
				this.jsonEncodingLayer = jsonEncodingLayer;
			}
	    }
	
	    public EncodingLayerGreen(SoalSyntaxKind kind, SoapEncodingLayerGreen soapEncodingLayer, XmlEncodingLayerGreen xmlEncodingLayer, JsonEncodingLayerGreen jsonEncodingLayer, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (soapEncodingLayer != null)
			{
				this.AdjustFlagsAndWidth(soapEncodingLayer);
				this.soapEncodingLayer = soapEncodingLayer;
			}
			if (xmlEncodingLayer != null)
			{
				this.AdjustFlagsAndWidth(xmlEncodingLayer);
				this.xmlEncodingLayer = xmlEncodingLayer;
			}
			if (jsonEncodingLayer != null)
			{
				this.AdjustFlagsAndWidth(jsonEncodingLayer);
				this.jsonEncodingLayer = jsonEncodingLayer;
			}
	    }
	
		private EncodingLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EncodingLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SoapEncodingLayerGreen SoapEncodingLayer { get { return this.soapEncodingLayer; } }
	    public XmlEncodingLayerGreen XmlEncodingLayer { get { return this.xmlEncodingLayer; } }
	    public JsonEncodingLayerGreen JsonEncodingLayer { get { return this.jsonEncodingLayer; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EncodingLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.soapEncodingLayer;
	            case 1: return this.xmlEncodingLayer;
	            case 2: return this.jsonEncodingLayer;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEncodingLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEncodingLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EncodingLayerGreen(this.Kind, this.soapEncodingLayer, this.xmlEncodingLayer, this.jsonEncodingLayer, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EncodingLayerGreen(this.Kind, this.soapEncodingLayer, this.xmlEncodingLayer, this.jsonEncodingLayer, this.GetDiagnostics(), annotations);
	    }
	
	    public EncodingLayerGreen Update(SoapEncodingLayerGreen soapEncodingLayer)
	    {
	        if (this.soapEncodingLayer != soapEncodingLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer(soapEncodingLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EncodingLayerGreen)newNode;
	        }
	        return this;
	    }
	
	    public EncodingLayerGreen Update(XmlEncodingLayerGreen xmlEncodingLayer)
	    {
	        if (this.xmlEncodingLayer != xmlEncodingLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer(xmlEncodingLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EncodingLayerGreen)newNode;
	        }
	        return this;
	    }
	
	    public EncodingLayerGreen Update(JsonEncodingLayerGreen jsonEncodingLayer)
	    {
	        if (this.jsonEncodingLayer != jsonEncodingLayer)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer(jsonEncodingLayer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EncodingLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SoapEncodingLayerGreen : GreenSyntaxNode
	{
	    internal static readonly SoapEncodingLayerGreen __Missing = new SoapEncodingLayerGreen();
	    private InternalSyntaxToken kEncoding;
	    private InternalSyntaxToken isoap;
	    private SoapEncodingLayerBodyGreen soapEncodingLayerBody;
	
	    public SoapEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kEncoding != null)
			{
				this.AdjustFlagsAndWidth(kEncoding);
				this.kEncoding = kEncoding;
			}
			if (isoap != null)
			{
				this.AdjustFlagsAndWidth(isoap);
				this.isoap = isoap;
			}
			if (soapEncodingLayerBody != null)
			{
				this.AdjustFlagsAndWidth(soapEncodingLayerBody);
				this.soapEncodingLayerBody = soapEncodingLayerBody;
			}
	    }
	
	    public SoapEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kEncoding != null)
			{
				this.AdjustFlagsAndWidth(kEncoding);
				this.kEncoding = kEncoding;
			}
			if (isoap != null)
			{
				this.AdjustFlagsAndWidth(isoap);
				this.isoap = isoap;
			}
			if (soapEncodingLayerBody != null)
			{
				this.AdjustFlagsAndWidth(soapEncodingLayerBody);
				this.soapEncodingLayerBody = soapEncodingLayerBody;
			}
	    }
	
		private SoapEncodingLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapEncodingLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEncoding { get { return this.kEncoding; } }
	    public InternalSyntaxToken ISOAP { get { return this.isoap; } }
	    public SoapEncodingLayerBodyGreen SoapEncodingLayerBody { get { return this.soapEncodingLayerBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEncoding;
	            case 1: return this.isoap;
	            case 2: return this.soapEncodingLayerBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapEncodingLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapEncodingLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingLayerGreen(this.Kind, this.kEncoding, this.isoap, this.soapEncodingLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingLayerGreen(this.Kind, this.kEncoding, this.isoap, this.soapEncodingLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingLayerGreen Update(InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody)
	    {
	        if (this.KEncoding != kEncoding ||
				this.ISOAP != isoap ||
				this.SoapEncodingLayerBody != soapEncodingLayerBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayer(kEncoding, isoap, soapEncodingLayerBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class SoapEncodingLayerBodyGreen : GreenSyntaxNode
	{
	    internal static readonly SoapEncodingLayerBodyGreen __Missing = SoapEncodingLayerEmptyBodyGreen.__Missing;
	
	    public SoapEncodingLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class SoapEncodingLayerEmptyBodyGreen : SoapEncodingLayerBodyGreen
	{
	    internal static new readonly SoapEncodingLayerEmptyBodyGreen __Missing = new SoapEncodingLayerEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public SoapEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private SoapEncodingLayerEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapEncodingLayerEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingLayerEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapEncodingLayerEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapEncodingLayerEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayerEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingLayerEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SoapEncodingLayerNonEmptyBodyGreen : SoapEncodingLayerBodyGreen
	{
	    internal static new readonly SoapEncodingLayerNonEmptyBodyGreen __Missing = new SoapEncodingLayerNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode soapEncodingProperties;
	    private InternalSyntaxToken tCloseBrace;
	
	    public SoapEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode soapEncodingProperties, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (soapEncodingProperties != null)
			{
				this.AdjustFlagsAndWidth(soapEncodingProperties);
				this.soapEncodingProperties = soapEncodingProperties;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public SoapEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode soapEncodingProperties, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (soapEncodingProperties != null)
			{
				this.AdjustFlagsAndWidth(soapEncodingProperties);
				this.soapEncodingProperties = soapEncodingProperties;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private SoapEncodingLayerNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapEncodingLayerNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SoapEncodingPropertiesGreen> SoapEncodingProperties { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SoapEncodingPropertiesGreen>(this.soapEncodingProperties); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingLayerNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.soapEncodingProperties;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapEncodingLayerNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapEncodingLayerNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.soapEncodingProperties, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.soapEncodingProperties, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SoapEncodingPropertiesGreen> soapEncodingProperties, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.SoapEncodingProperties != soapEncodingProperties ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayerNonEmptyBody(tOpenBrace, soapEncodingProperties, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingLayerNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class XmlEncodingLayerGreen : GreenSyntaxNode
	{
	    internal static readonly XmlEncodingLayerGreen __Missing = new XmlEncodingLayerGreen();
	    private InternalSyntaxToken kEncoding;
	    private InternalSyntaxToken ixml;
	    private XmlEncodingLayerBodyGreen xmlEncodingLayerBody;
	
	    public XmlEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kEncoding != null)
			{
				this.AdjustFlagsAndWidth(kEncoding);
				this.kEncoding = kEncoding;
			}
			if (ixml != null)
			{
				this.AdjustFlagsAndWidth(ixml);
				this.ixml = ixml;
			}
			if (xmlEncodingLayerBody != null)
			{
				this.AdjustFlagsAndWidth(xmlEncodingLayerBody);
				this.xmlEncodingLayerBody = xmlEncodingLayerBody;
			}
	    }
	
	    public XmlEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kEncoding != null)
			{
				this.AdjustFlagsAndWidth(kEncoding);
				this.kEncoding = kEncoding;
			}
			if (ixml != null)
			{
				this.AdjustFlagsAndWidth(ixml);
				this.ixml = ixml;
			}
			if (xmlEncodingLayerBody != null)
			{
				this.AdjustFlagsAndWidth(xmlEncodingLayerBody);
				this.xmlEncodingLayerBody = xmlEncodingLayerBody;
			}
	    }
	
		private XmlEncodingLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.XmlEncodingLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEncoding { get { return this.kEncoding; } }
	    public InternalSyntaxToken IXML { get { return this.ixml; } }
	    public XmlEncodingLayerBodyGreen XmlEncodingLayerBody { get { return this.xmlEncodingLayerBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.XmlEncodingLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEncoding;
	            case 1: return this.ixml;
	            case 2: return this.xmlEncodingLayerBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitXmlEncodingLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitXmlEncodingLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XmlEncodingLayerGreen(this.Kind, this.kEncoding, this.ixml, this.xmlEncodingLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XmlEncodingLayerGreen(this.Kind, this.kEncoding, this.ixml, this.xmlEncodingLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public XmlEncodingLayerGreen Update(InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody)
	    {
	        if (this.KEncoding != kEncoding ||
				this.IXML != ixml ||
				this.XmlEncodingLayerBody != xmlEncodingLayerBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayer(kEncoding, ixml, xmlEncodingLayerBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XmlEncodingLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class XmlEncodingLayerBodyGreen : GreenSyntaxNode
	{
	    internal static readonly XmlEncodingLayerBodyGreen __Missing = XmlEncodingLayerEmptyBodyGreen.__Missing;
	
	    public XmlEncodingLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class XmlEncodingLayerEmptyBodyGreen : XmlEncodingLayerBodyGreen
	{
	    internal static new readonly XmlEncodingLayerEmptyBodyGreen __Missing = new XmlEncodingLayerEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public XmlEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public XmlEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private XmlEncodingLayerEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.XmlEncodingLayerEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.XmlEncodingLayerEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitXmlEncodingLayerEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitXmlEncodingLayerEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XmlEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XmlEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public XmlEncodingLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayerEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XmlEncodingLayerEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class XmlEncodingLayerNonEmptyBodyGreen : XmlEncodingLayerBodyGreen
	{
	    internal static new readonly XmlEncodingLayerNonEmptyBodyGreen __Missing = new XmlEncodingLayerNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public XmlEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public XmlEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private XmlEncodingLayerNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.XmlEncodingLayerNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.XmlEncodingLayerNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitXmlEncodingLayerNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitXmlEncodingLayerNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XmlEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XmlEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public XmlEncodingLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XmlEncodingLayerNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class JsonEncodingLayerGreen : GreenSyntaxNode
	{
	    internal static readonly JsonEncodingLayerGreen __Missing = new JsonEncodingLayerGreen();
	    private InternalSyntaxToken kEncoding;
	    private InternalSyntaxToken ijson;
	    private JsonEncodingLayerBodyGreen jsonEncodingLayerBody;
	
	    public JsonEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kEncoding != null)
			{
				this.AdjustFlagsAndWidth(kEncoding);
				this.kEncoding = kEncoding;
			}
			if (ijson != null)
			{
				this.AdjustFlagsAndWidth(ijson);
				this.ijson = ijson;
			}
			if (jsonEncodingLayerBody != null)
			{
				this.AdjustFlagsAndWidth(jsonEncodingLayerBody);
				this.jsonEncodingLayerBody = jsonEncodingLayerBody;
			}
	    }
	
	    public JsonEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kEncoding != null)
			{
				this.AdjustFlagsAndWidth(kEncoding);
				this.kEncoding = kEncoding;
			}
			if (ijson != null)
			{
				this.AdjustFlagsAndWidth(ijson);
				this.ijson = ijson;
			}
			if (jsonEncodingLayerBody != null)
			{
				this.AdjustFlagsAndWidth(jsonEncodingLayerBody);
				this.jsonEncodingLayerBody = jsonEncodingLayerBody;
			}
	    }
	
		private JsonEncodingLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.JsonEncodingLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEncoding { get { return this.kEncoding; } }
	    public InternalSyntaxToken IJSON { get { return this.ijson; } }
	    public JsonEncodingLayerBodyGreen JsonEncodingLayerBody { get { return this.jsonEncodingLayerBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.JsonEncodingLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEncoding;
	            case 1: return this.ijson;
	            case 2: return this.jsonEncodingLayerBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitJsonEncodingLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitJsonEncodingLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new JsonEncodingLayerGreen(this.Kind, this.kEncoding, this.ijson, this.jsonEncodingLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new JsonEncodingLayerGreen(this.Kind, this.kEncoding, this.ijson, this.jsonEncodingLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public JsonEncodingLayerGreen Update(InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody)
	    {
	        if (this.KEncoding != kEncoding ||
				this.IJSON != ijson ||
				this.JsonEncodingLayerBody != jsonEncodingLayerBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayer(kEncoding, ijson, jsonEncodingLayerBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (JsonEncodingLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class JsonEncodingLayerBodyGreen : GreenSyntaxNode
	{
	    internal static readonly JsonEncodingLayerBodyGreen __Missing = JsonEncodingLayerEmptyBodyGreen.__Missing;
	
	    public JsonEncodingLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 0;
	    }
	}
	
	internal class JsonEncodingLayerEmptyBodyGreen : JsonEncodingLayerBodyGreen
	{
	    internal static new readonly JsonEncodingLayerEmptyBodyGreen __Missing = new JsonEncodingLayerEmptyBodyGreen();
	    private InternalSyntaxToken tSemicolon;
	
	    public JsonEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public JsonEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private JsonEncodingLayerEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.JsonEncodingLayerEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.JsonEncodingLayerEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitJsonEncodingLayerEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitJsonEncodingLayerEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new JsonEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new JsonEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public JsonEncodingLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayerEmptyBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (JsonEncodingLayerEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class JsonEncodingLayerNonEmptyBodyGreen : JsonEncodingLayerBodyGreen
	{
	    internal static new readonly JsonEncodingLayerNonEmptyBodyGreen __Missing = new JsonEncodingLayerNonEmptyBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public JsonEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public JsonEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private JsonEncodingLayerNonEmptyBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.JsonEncodingLayerNonEmptyBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.JsonEncodingLayerNonEmptyBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitJsonEncodingLayerNonEmptyBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitJsonEncodingLayerNonEmptyBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new JsonEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new JsonEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public JsonEncodingLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (JsonEncodingLayerNonEmptyBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SoapEncodingPropertiesGreen : GreenSyntaxNode
	{
	    internal static readonly SoapEncodingPropertiesGreen __Missing = new SoapEncodingPropertiesGreen();
	    private SoapVersionPropertyGreen soapVersionProperty;
	    private SoapMtomPropertyGreen soapMtomProperty;
	    private SoapStylePropertyGreen soapStyleProperty;
	
	    public SoapEncodingPropertiesGreen(SoalSyntaxKind kind, SoapVersionPropertyGreen soapVersionProperty, SoapMtomPropertyGreen soapMtomProperty, SoapStylePropertyGreen soapStyleProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (soapVersionProperty != null)
			{
				this.AdjustFlagsAndWidth(soapVersionProperty);
				this.soapVersionProperty = soapVersionProperty;
			}
			if (soapMtomProperty != null)
			{
				this.AdjustFlagsAndWidth(soapMtomProperty);
				this.soapMtomProperty = soapMtomProperty;
			}
			if (soapStyleProperty != null)
			{
				this.AdjustFlagsAndWidth(soapStyleProperty);
				this.soapStyleProperty = soapStyleProperty;
			}
	    }
	
	    public SoapEncodingPropertiesGreen(SoalSyntaxKind kind, SoapVersionPropertyGreen soapVersionProperty, SoapMtomPropertyGreen soapMtomProperty, SoapStylePropertyGreen soapStyleProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (soapVersionProperty != null)
			{
				this.AdjustFlagsAndWidth(soapVersionProperty);
				this.soapVersionProperty = soapVersionProperty;
			}
			if (soapMtomProperty != null)
			{
				this.AdjustFlagsAndWidth(soapMtomProperty);
				this.soapMtomProperty = soapMtomProperty;
			}
			if (soapStyleProperty != null)
			{
				this.AdjustFlagsAndWidth(soapStyleProperty);
				this.soapStyleProperty = soapStyleProperty;
			}
	    }
	
		private SoapEncodingPropertiesGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapEncodingProperties, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SoapVersionPropertyGreen SoapVersionProperty { get { return this.soapVersionProperty; } }
	    public SoapMtomPropertyGreen SoapMtomProperty { get { return this.soapMtomProperty; } }
	    public SoapStylePropertyGreen SoapStyleProperty { get { return this.soapStyleProperty; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingPropertiesSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.soapVersionProperty;
	            case 1: return this.soapMtomProperty;
	            case 2: return this.soapStyleProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapEncodingPropertiesGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapEncodingPropertiesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingPropertiesGreen(this.Kind, this.soapVersionProperty, this.soapMtomProperty, this.soapStyleProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingPropertiesGreen(this.Kind, this.soapVersionProperty, this.soapMtomProperty, this.soapStyleProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingPropertiesGreen Update(SoapVersionPropertyGreen soapVersionProperty)
	    {
	        if (this.soapVersionProperty != soapVersionProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties(soapVersionProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingPropertiesGreen)newNode;
	        }
	        return this;
	    }
	
	    public SoapEncodingPropertiesGreen Update(SoapMtomPropertyGreen soapMtomProperty)
	    {
	        if (this.soapMtomProperty != soapMtomProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties(soapMtomProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingPropertiesGreen)newNode;
	        }
	        return this;
	    }
	
	    public SoapEncodingPropertiesGreen Update(SoapStylePropertyGreen soapStyleProperty)
	    {
	        if (this.soapStyleProperty != soapStyleProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties(soapStyleProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingPropertiesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SoapVersionPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly SoapVersionPropertyGreen __Missing = new SoapVersionPropertyGreen();
	    private InternalSyntaxToken iVersion;
	    private InternalSyntaxToken tAssign;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapVersionPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (iVersion != null)
			{
				this.AdjustFlagsAndWidth(iVersion);
				this.iVersion = iVersion;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
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
	
	    public SoapVersionPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (iVersion != null)
			{
				this.AdjustFlagsAndWidth(iVersion);
				this.iVersion = iVersion;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
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
	
		private SoapVersionPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapVersionProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IVersion { get { return this.iVersion; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapVersionPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iVersion;
	            case 1: return this.tAssign;
	            case 2: return this.identifier;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapVersionPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapVersionPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapVersionPropertyGreen(this.Kind, this.iVersion, this.tAssign, this.identifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapVersionPropertyGreen(this.Kind, this.iVersion, this.tAssign, this.identifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapVersionPropertyGreen Update(InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.IVersion != iVersion ||
				this.TAssign != tAssign ||
				this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapVersionProperty(iVersion, tAssign, identifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapVersionPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SoapMtomPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly SoapMtomPropertyGreen __Missing = new SoapMtomPropertyGreen();
	    private InternalSyntaxToken imtom;
	    private InternalSyntaxToken tAssign;
	    private BooleanLiteralGreen booleanLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapMtomPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (imtom != null)
			{
				this.AdjustFlagsAndWidth(imtom);
				this.imtom = imtom;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public SoapMtomPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (imtom != null)
			{
				this.AdjustFlagsAndWidth(imtom);
				this.imtom = imtom;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private SoapMtomPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapMtomProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IMTOM { get { return this.imtom; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapMtomPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.imtom;
	            case 1: return this.tAssign;
	            case 2: return this.booleanLiteral;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapMtomPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapMtomPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapMtomPropertyGreen(this.Kind, this.imtom, this.tAssign, this.booleanLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapMtomPropertyGreen(this.Kind, this.imtom, this.tAssign, this.booleanLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapMtomPropertyGreen Update(InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.IMTOM != imtom ||
				this.TAssign != tAssign ||
				this.BooleanLiteral != booleanLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapMtomProperty(imtom, tAssign, booleanLiteral, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapMtomPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SoapStylePropertyGreen : GreenSyntaxNode
	{
	    internal static readonly SoapStylePropertyGreen __Missing = new SoapStylePropertyGreen();
	    private InternalSyntaxToken iStyle;
	    private InternalSyntaxToken tAssign;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapStylePropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (iStyle != null)
			{
				this.AdjustFlagsAndWidth(iStyle);
				this.iStyle = iStyle;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
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
	
	    public SoapStylePropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (iStyle != null)
			{
				this.AdjustFlagsAndWidth(iStyle);
				this.iStyle = iStyle;
			}
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
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
	
		private SoapStylePropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SoapStyleProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IStyle { get { return this.iStyle; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapStylePropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iStyle;
	            case 1: return this.tAssign;
	            case 2: return this.identifier;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSoapStylePropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSoapStylePropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapStylePropertyGreen(this.Kind, this.iStyle, this.tAssign, this.identifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapStylePropertyGreen(this.Kind, this.iStyle, this.tAssign, this.identifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapStylePropertyGreen Update(InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.IStyle != iStyle ||
				this.TAssign != tAssign ||
				this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapStyleProperty(iStyle, tAssign, identifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapStylePropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ProtocolLayerGreen : GreenSyntaxNode
	{
	    internal static readonly ProtocolLayerGreen __Missing = new ProtocolLayerGreen();
	    private InternalSyntaxToken kProtocol;
	    private ProtocolLayerKindGreen protocolLayerKind;
	    private InternalSyntaxToken tSemicolon;
	
	    public ProtocolLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kProtocol != null)
			{
				this.AdjustFlagsAndWidth(kProtocol);
				this.kProtocol = kProtocol;
			}
			if (protocolLayerKind != null)
			{
				this.AdjustFlagsAndWidth(protocolLayerKind);
				this.protocolLayerKind = protocolLayerKind;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ProtocolLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kProtocol != null)
			{
				this.AdjustFlagsAndWidth(kProtocol);
				this.kProtocol = kProtocol;
			}
			if (protocolLayerKind != null)
			{
				this.AdjustFlagsAndWidth(protocolLayerKind);
				this.protocolLayerKind = protocolLayerKind;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ProtocolLayerGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ProtocolLayer, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KProtocol { get { return this.kProtocol; } }
	    public ProtocolLayerKindGreen ProtocolLayerKind { get { return this.protocolLayerKind; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ProtocolLayerSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kProtocol;
	            case 1: return this.protocolLayerKind;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitProtocolLayerGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitProtocolLayerGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ProtocolLayerGreen(this.Kind, this.kProtocol, this.protocolLayerKind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ProtocolLayerGreen(this.Kind, this.kProtocol, this.protocolLayerKind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ProtocolLayerGreen Update(InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KProtocol != kProtocol ||
				this.ProtocolLayerKind != protocolLayerKind ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ProtocolLayer(kProtocol, protocolLayerKind, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ProtocolLayerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ProtocolLayerKindGreen : GreenSyntaxNode
	{
	    internal static readonly ProtocolLayerKindGreen __Missing = new ProtocolLayerKindGreen();
	    private WsAddressingGreen wsAddressing;
	
	    public ProtocolLayerKindGreen(SoalSyntaxKind kind, WsAddressingGreen wsAddressing)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (wsAddressing != null)
			{
				this.AdjustFlagsAndWidth(wsAddressing);
				this.wsAddressing = wsAddressing;
			}
	    }
	
	    public ProtocolLayerKindGreen(SoalSyntaxKind kind, WsAddressingGreen wsAddressing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (wsAddressing != null)
			{
				this.AdjustFlagsAndWidth(wsAddressing);
				this.wsAddressing = wsAddressing;
			}
	    }
	
		private ProtocolLayerKindGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ProtocolLayerKind, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public WsAddressingGreen WsAddressing { get { return this.wsAddressing; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ProtocolLayerKindSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.wsAddressing;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitProtocolLayerKindGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitProtocolLayerKindGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ProtocolLayerKindGreen(this.Kind, this.wsAddressing, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ProtocolLayerKindGreen(this.Kind, this.wsAddressing, this.GetDiagnostics(), annotations);
	    }
	
	    public ProtocolLayerKindGreen Update(WsAddressingGreen wsAddressing)
	    {
	        if (this.WsAddressing != wsAddressing)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ProtocolLayerKind(wsAddressing);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ProtocolLayerKindGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WsAddressingGreen : GreenSyntaxNode
	{
	    internal static readonly WsAddressingGreen __Missing = new WsAddressingGreen();
	    private InternalSyntaxToken iWsAddressing;
	
	    public WsAddressingGreen(SoalSyntaxKind kind, InternalSyntaxToken iWsAddressing)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (iWsAddressing != null)
			{
				this.AdjustFlagsAndWidth(iWsAddressing);
				this.iWsAddressing = iWsAddressing;
			}
	    }
	
	    public WsAddressingGreen(SoalSyntaxKind kind, InternalSyntaxToken iWsAddressing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (iWsAddressing != null)
			{
				this.AdjustFlagsAndWidth(iWsAddressing);
				this.iWsAddressing = iWsAddressing;
			}
	    }
	
		private WsAddressingGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.WsAddressing, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IWsAddressing { get { return this.iWsAddressing; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WsAddressingSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iWsAddressing;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitWsAddressingGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitWsAddressingGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WsAddressingGreen(this.Kind, this.iWsAddressing, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WsAddressingGreen(this.Kind, this.iWsAddressing, this.GetDiagnostics(), annotations);
	    }
	
	    public WsAddressingGreen Update(InternalSyntaxToken iWsAddressing)
	    {
	        if (this.IWsAddressing != iWsAddressing)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WsAddressing(iWsAddressing);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WsAddressingGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndpointDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly EndpointDeclarationGreen __Missing = new EndpointDeclarationGreen();
	    private InternalSyntaxToken kEndpoint;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private QualifierGreen qualifier;
	    private EndpointBodyGreen endpointBody;
	
	    public EndpointDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEndpoint, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, EndpointBodyGreen endpointBody)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kEndpoint != null)
			{
				this.AdjustFlagsAndWidth(kEndpoint);
				this.kEndpoint = kEndpoint;
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
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (endpointBody != null)
			{
				this.AdjustFlagsAndWidth(endpointBody);
				this.endpointBody = endpointBody;
			}
	    }
	
	    public EndpointDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEndpoint, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, EndpointBodyGreen endpointBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kEndpoint != null)
			{
				this.AdjustFlagsAndWidth(kEndpoint);
				this.kEndpoint = kEndpoint;
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
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
			if (endpointBody != null)
			{
				this.AdjustFlagsAndWidth(endpointBody);
				this.endpointBody = endpointBody;
			}
	    }
	
		private EndpointDeclarationGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EndpointDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KEndpoint { get { return this.kEndpoint; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public EndpointBodyGreen EndpointBody { get { return this.endpointBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointDeclarationSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEndpoint;
	            case 1: return this.name;
	            case 2: return this.tColon;
	            case 3: return this.qualifier;
	            case 4: return this.endpointBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEndpointDeclarationGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEndpointDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointDeclarationGreen(this.Kind, this.kEndpoint, this.name, this.tColon, this.qualifier, this.endpointBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointDeclarationGreen(this.Kind, this.kEndpoint, this.name, this.tColon, this.qualifier, this.endpointBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointDeclarationGreen Update(InternalSyntaxToken kEndpoint, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, EndpointBodyGreen endpointBody)
	    {
	        if (this.KEndpoint != kEndpoint ||
				this.Name != name ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.EndpointBody != endpointBody)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointDeclaration(kEndpoint, name, tColon, qualifier, endpointBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndpointBodyGreen : GreenSyntaxNode
	{
	    internal static readonly EndpointBodyGreen __Missing = new EndpointBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private EndpointPropertiesGreen endpointProperties;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EndpointBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (endpointProperties != null)
			{
				this.AdjustFlagsAndWidth(endpointProperties);
				this.endpointProperties = endpointProperties;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public EndpointBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (endpointProperties != null)
			{
				this.AdjustFlagsAndWidth(endpointProperties);
				this.endpointProperties = endpointProperties;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		private EndpointBodyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EndpointBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public EndpointPropertiesGreen EndpointProperties { get { return this.endpointProperties; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointBodySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.endpointProperties;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEndpointBodyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEndpointBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointBodyGreen(this.Kind, this.tOpenBrace, this.endpointProperties, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointBodyGreen(this.Kind, this.tOpenBrace, this.endpointProperties, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointBodyGreen Update(InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EndpointProperties != endpointProperties ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointBody(tOpenBrace, endpointProperties, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndpointPropertiesGreen : GreenSyntaxNode
	{
	    internal static readonly EndpointPropertiesGreen __Missing = new EndpointPropertiesGreen();
	    private GreenNode endpointProperty;
	
	    public EndpointPropertiesGreen(SoalSyntaxKind kind, GreenNode endpointProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (endpointProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointProperty);
				this.endpointProperty = endpointProperty;
			}
	    }
	
	    public EndpointPropertiesGreen(SoalSyntaxKind kind, GreenNode endpointProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (endpointProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointProperty);
				this.endpointProperty = endpointProperty;
			}
	    }
	
		private EndpointPropertiesGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EndpointProperties, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EndpointPropertyGreen> EndpointProperty { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EndpointPropertyGreen>(this.endpointProperty); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointPropertiesSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.endpointProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEndpointPropertiesGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEndpointPropertiesGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointPropertiesGreen(this.Kind, this.endpointProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointPropertiesGreen(this.Kind, this.endpointProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointPropertiesGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EndpointPropertyGreen> endpointProperty)
	    {
	        if (this.EndpointProperty != endpointProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperties(endpointProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointPropertiesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndpointPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly EndpointPropertyGreen __Missing = new EndpointPropertyGreen();
	    private EndpointBindingPropertyGreen endpointBindingProperty;
	    private EndpointAddressPropertyGreen endpointAddressProperty;
	
	    public EndpointPropertyGreen(SoalSyntaxKind kind, EndpointBindingPropertyGreen endpointBindingProperty, EndpointAddressPropertyGreen endpointAddressProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (endpointBindingProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointBindingProperty);
				this.endpointBindingProperty = endpointBindingProperty;
			}
			if (endpointAddressProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointAddressProperty);
				this.endpointAddressProperty = endpointAddressProperty;
			}
	    }
	
	    public EndpointPropertyGreen(SoalSyntaxKind kind, EndpointBindingPropertyGreen endpointBindingProperty, EndpointAddressPropertyGreen endpointAddressProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (endpointBindingProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointBindingProperty);
				this.endpointBindingProperty = endpointBindingProperty;
			}
			if (endpointAddressProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointAddressProperty);
				this.endpointAddressProperty = endpointAddressProperty;
			}
	    }
	
		private EndpointPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EndpointProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public EndpointBindingPropertyGreen EndpointBindingProperty { get { return this.endpointBindingProperty; } }
	    public EndpointAddressPropertyGreen EndpointAddressProperty { get { return this.endpointAddressProperty; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.endpointBindingProperty;
	            case 1: return this.endpointAddressProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEndpointPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEndpointPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointPropertyGreen(this.Kind, this.endpointBindingProperty, this.endpointAddressProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointPropertyGreen(this.Kind, this.endpointBindingProperty, this.endpointAddressProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointPropertyGreen Update(EndpointBindingPropertyGreen endpointBindingProperty)
	    {
	        if (this.endpointBindingProperty != endpointBindingProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperty(endpointBindingProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointPropertyGreen)newNode;
	        }
	        return this;
	    }
	
	    public EndpointPropertyGreen Update(EndpointAddressPropertyGreen endpointAddressProperty)
	    {
	        if (this.endpointAddressProperty != endpointAddressProperty)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperty(endpointAddressProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndpointBindingPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly EndpointBindingPropertyGreen __Missing = new EndpointBindingPropertyGreen();
	    private InternalSyntaxToken kBinding;
	    private QualifierGreen qualifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public EndpointBindingPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
	    public EndpointBindingPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
		private EndpointBindingPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EndpointBindingProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBinding { get { return this.kBinding; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointBindingPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBinding;
	            case 1: return this.qualifier;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEndpointBindingPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEndpointBindingPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointBindingPropertyGreen(this.Kind, this.kBinding, this.qualifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointBindingPropertyGreen(this.Kind, this.kBinding, this.qualifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointBindingPropertyGreen Update(InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KBinding != kBinding ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointBindingProperty(kBinding, qualifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointBindingPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EndpointAddressPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly EndpointAddressPropertyGreen __Missing = new EndpointAddressPropertyGreen();
	    private InternalSyntaxToken kAddress;
	    private StringLiteralGreen stringLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public EndpointAddressPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (kAddress != null)
			{
				this.AdjustFlagsAndWidth(kAddress);
				this.kAddress = kAddress;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public EndpointAddressPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (kAddress != null)
			{
				this.AdjustFlagsAndWidth(kAddress);
				this.kAddress = kAddress;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private EndpointAddressPropertyGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.EndpointAddressProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KAddress { get { return this.kAddress; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointAddressPropertySyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAddress;
	            case 1: return this.stringLiteral;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitEndpointAddressPropertyGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitEndpointAddressPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointAddressPropertyGreen(this.Kind, this.kAddress, this.stringLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointAddressPropertyGreen(this.Kind, this.kAddress, this.stringLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointAddressPropertyGreen Update(InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KAddress != kAddress ||
				this.StringLiteral != stringLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointAddressProperty(kAddress, stringLiteral, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointAddressPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnTypeGreen __Missing = new ReturnTypeGreen();
	    private VoidTypeGreen voidType;
	    private TypeReferenceGreen typeReference;
	
	    public ReturnTypeGreen(SoalSyntaxKind kind, VoidTypeGreen voidType, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (voidType != null)
			{
				this.AdjustFlagsAndWidth(voidType);
				this.voidType = voidType;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public ReturnTypeGreen(SoalSyntaxKind kind, VoidTypeGreen voidType, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (voidType != null)
			{
				this.AdjustFlagsAndWidth(voidType);
				this.voidType = voidType;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private ReturnTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ReturnType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReturnTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.voidType;
	            case 1: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnTypeGreen(this.Kind, this.voidType, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnTypeGreen(this.Kind, this.voidType, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnTypeGreen Update(VoidTypeGreen voidType)
	    {
	        if (this.voidType != voidType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
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
	
	    public ReturnTypeGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.typeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
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
	
	internal class TypeReferenceGreen : GreenSyntaxNode
	{
	    internal static readonly TypeReferenceGreen __Missing = new TypeReferenceGreen();
	    private NonNullableArrayTypeGreen nonNullableArrayType;
	    private ArrayTypeGreen arrayType;
	    private SimpleTypeGreen simpleType;
	    private NulledTypeGreen nulledType;
	
	    public TypeReferenceGreen(SoalSyntaxKind kind, NonNullableArrayTypeGreen nonNullableArrayType, ArrayTypeGreen arrayType, SimpleTypeGreen simpleType, NulledTypeGreen nulledType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (nonNullableArrayType != null)
			{
				this.AdjustFlagsAndWidth(nonNullableArrayType);
				this.nonNullableArrayType = nonNullableArrayType;
			}
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
			if (nulledType != null)
			{
				this.AdjustFlagsAndWidth(nulledType);
				this.nulledType = nulledType;
			}
	    }
	
	    public TypeReferenceGreen(SoalSyntaxKind kind, NonNullableArrayTypeGreen nonNullableArrayType, ArrayTypeGreen arrayType, SimpleTypeGreen simpleType, NulledTypeGreen nulledType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (nonNullableArrayType != null)
			{
				this.AdjustFlagsAndWidth(nonNullableArrayType);
				this.nonNullableArrayType = nonNullableArrayType;
			}
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
			if (nulledType != null)
			{
				this.AdjustFlagsAndWidth(nulledType);
				this.nulledType = nulledType;
			}
	    }
	
		private TypeReferenceGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.TypeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NonNullableArrayTypeGreen NonNullableArrayType { get { return this.nonNullableArrayType; } }
	    public ArrayTypeGreen ArrayType { get { return this.arrayType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public NulledTypeGreen NulledType { get { return this.nulledType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.TypeReferenceSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nonNullableArrayType;
	            case 1: return this.arrayType;
	            case 2: return this.simpleType;
	            case 3: return this.nulledType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.nonNullableArrayType, this.arrayType, this.simpleType, this.nulledType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.nonNullableArrayType, this.arrayType, this.simpleType, this.nulledType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(NonNullableArrayTypeGreen nonNullableArrayType)
	    {
	        if (this.nonNullableArrayType != nonNullableArrayType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(nonNullableArrayType);
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
	
	    public TypeReferenceGreen Update(ArrayTypeGreen arrayType)
	    {
	        if (this.arrayType != arrayType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(arrayType);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleType);
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
	
	    public TypeReferenceGreen Update(NulledTypeGreen nulledType)
	    {
	        if (this.nulledType != nulledType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(nulledType);
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
	    private ValueTypeGreen valueType;
	    private ObjectTypeGreen objectType;
	    private QualifierGreen qualifier;
	
	    public SimpleTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, ObjectTypeGreen objectType, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public SimpleTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, ObjectTypeGreen objectType, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private SimpleTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SimpleType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ValueTypeGreen ValueType { get { return this.valueType; } }
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SimpleTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.valueType;
	            case 1: return this.objectType;
	            case 2: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleTypeGreen(this.Kind, this.valueType, this.objectType, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleTypeGreen(this.Kind, this.valueType, this.objectType, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleTypeGreen Update(ValueTypeGreen valueType)
	    {
	        if (this.valueType != valueType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleType(valueType);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleType(objectType);
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
	
	    public SimpleTypeGreen Update(QualifierGreen qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleType(qualifier);
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
	
	internal class NulledTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NulledTypeGreen __Missing = new NulledTypeGreen();
	    private NullableTypeGreen nullableType;
	    private NonNullableTypeGreen nonNullableType;
	
	    public NulledTypeGreen(SoalSyntaxKind kind, NullableTypeGreen nullableType, NonNullableTypeGreen nonNullableType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (nonNullableType != null)
			{
				this.AdjustFlagsAndWidth(nonNullableType);
				this.nonNullableType = nonNullableType;
			}
	    }
	
	    public NulledTypeGreen(SoalSyntaxKind kind, NullableTypeGreen nullableType, NonNullableTypeGreen nonNullableType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (nullableType != null)
			{
				this.AdjustFlagsAndWidth(nullableType);
				this.nullableType = nullableType;
			}
			if (nonNullableType != null)
			{
				this.AdjustFlagsAndWidth(nonNullableType);
				this.nonNullableType = nonNullableType;
			}
	    }
	
		private NulledTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NulledType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public NonNullableTypeGreen NonNullableType { get { return this.nonNullableType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NulledTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nullableType;
	            case 1: return this.nonNullableType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNulledTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNulledTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NulledTypeGreen(this.Kind, this.nullableType, this.nonNullableType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NulledTypeGreen(this.Kind, this.nullableType, this.nonNullableType, this.GetDiagnostics(), annotations);
	    }
	
	    public NulledTypeGreen Update(NullableTypeGreen nullableType)
	    {
	        if (this.nullableType != nullableType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NulledType(nullableType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NulledTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public NulledTypeGreen Update(NonNullableTypeGreen nonNullableType)
	    {
	        if (this.nonNullableType != nonNullableType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NulledType(nonNullableType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NulledTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReferenceTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ReferenceTypeGreen __Missing = new ReferenceTypeGreen();
	    private ObjectTypeGreen objectType;
	    private QualifierGreen qualifier;
	
	    public ReferenceTypeGreen(SoalSyntaxKind kind, ObjectTypeGreen objectType, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ReferenceTypeGreen(SoalSyntaxKind kind, ObjectTypeGreen objectType, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		private ReferenceTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ReferenceType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReferenceTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.objectType;
	            case 1: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitReferenceTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitReferenceTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReferenceTypeGreen(this.Kind, this.objectType, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReferenceTypeGreen(this.Kind, this.objectType, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ReferenceTypeGreen Update(ObjectTypeGreen objectType)
	    {
	        if (this.objectType != objectType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReferenceType(objectType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReferenceTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public ReferenceTypeGreen Update(QualifierGreen qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReferenceType(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReferenceTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ObjectTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ObjectTypeGreen __Missing = new ObjectTypeGreen();
	    private InternalSyntaxToken objectType;
	
	    public ObjectTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken objectType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
	    public ObjectTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken objectType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.ObjectType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ObjectType { get { return this.objectType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ObjectTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.objectType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitObjectTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitObjectTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ObjectType(objectType);
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
	
	internal class ValueTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ValueTypeGreen __Missing = new ValueTypeGreen();
	    private InternalSyntaxToken valueType;
	
	    public ValueTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken valueType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
	    }
	
	    public ValueTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken valueType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
	    }
	
		private ValueTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ValueType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ValueType { get { return this.valueType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ValueTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.valueType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitValueTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitValueTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ValueTypeGreen(this.Kind, this.valueType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ValueTypeGreen(this.Kind, this.valueType, this.GetDiagnostics(), annotations);
	    }
	
	    public ValueTypeGreen Update(InternalSyntaxToken valueType)
	    {
	        if (this.ValueType != valueType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ValueType(valueType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class VoidTypeGreen : GreenSyntaxNode
	{
	    internal static readonly VoidTypeGreen __Missing = new VoidTypeGreen();
	    private InternalSyntaxToken kVoid;
	
	    public VoidTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.VoidType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.VoidTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitVoidTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
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
	
	internal class OnewayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly OnewayTypeGreen __Missing = new OnewayTypeGreen();
	    private InternalSyntaxToken kOneway;
	
	    public OnewayTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kOneway)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kOneway != null)
			{
				this.AdjustFlagsAndWidth(kOneway);
				this.kOneway = kOneway;
			}
	    }
	
	    public OnewayTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kOneway, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kOneway != null)
			{
				this.AdjustFlagsAndWidth(kOneway);
				this.kOneway = kOneway;
			}
	    }
	
		private OnewayTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.OnewayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KOneway { get { return this.kOneway; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OnewayTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kOneway;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitOnewayTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitOnewayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OnewayTypeGreen(this.Kind, this.kOneway, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OnewayTypeGreen(this.Kind, this.kOneway, this.GetDiagnostics(), annotations);
	    }
	
	    public OnewayTypeGreen Update(InternalSyntaxToken kOneway)
	    {
	        if (this.KOneway != kOneway)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OnewayType(kOneway);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OnewayTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationReturnTypeGreen : GreenSyntaxNode
	{
	    internal static readonly OperationReturnTypeGreen __Missing = new OperationReturnTypeGreen();
	    private OnewayTypeGreen onewayType;
	    private VoidTypeGreen voidType;
	    private TypeReferenceGreen typeReference;
	
	    public OperationReturnTypeGreen(SoalSyntaxKind kind, OnewayTypeGreen onewayType, VoidTypeGreen voidType, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (onewayType != null)
			{
				this.AdjustFlagsAndWidth(onewayType);
				this.onewayType = onewayType;
			}
			if (voidType != null)
			{
				this.AdjustFlagsAndWidth(voidType);
				this.voidType = voidType;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public OperationReturnTypeGreen(SoalSyntaxKind kind, OnewayTypeGreen onewayType, VoidTypeGreen voidType, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (onewayType != null)
			{
				this.AdjustFlagsAndWidth(onewayType);
				this.onewayType = onewayType;
			}
			if (voidType != null)
			{
				this.AdjustFlagsAndWidth(voidType);
				this.voidType = voidType;
			}
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		private OperationReturnTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.OperationReturnType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OnewayTypeGreen OnewayType { get { return this.onewayType; } }
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationReturnTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.onewayType;
	            case 1: return this.voidType;
	            case 2: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitOperationReturnTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitOperationReturnTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationReturnTypeGreen(this.Kind, this.onewayType, this.voidType, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationReturnTypeGreen(this.Kind, this.onewayType, this.voidType, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationReturnTypeGreen Update(OnewayTypeGreen onewayType)
	    {
	        if (this.onewayType != onewayType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType(onewayType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationReturnTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public OperationReturnTypeGreen Update(VoidTypeGreen voidType)
	    {
	        if (this.voidType != voidType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType(voidType);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationReturnTypeGreen)newNode;
	        }
	        return this;
	    }
	
	    public OperationReturnTypeGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.typeReference != typeReference)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType(typeReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationReturnTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NullableTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NullableTypeGreen __Missing = new NullableTypeGreen();
	    private ValueTypeGreen valueType;
	    private InternalSyntaxToken tQuestion;
	
	    public NullableTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, InternalSyntaxToken tQuestion)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
	    public NullableTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, InternalSyntaxToken tQuestion, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
			if (tQuestion != null)
			{
				this.AdjustFlagsAndWidth(tQuestion);
				this.tQuestion = tQuestion;
			}
	    }
	
		private NullableTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NullableType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ValueTypeGreen ValueType { get { return this.valueType; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NullableTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.valueType;
	            case 1: return this.tQuestion;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableTypeGreen(this.Kind, this.valueType, this.tQuestion, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableTypeGreen(this.Kind, this.valueType, this.tQuestion, this.GetDiagnostics(), annotations);
	    }
	
	    public NullableTypeGreen Update(ValueTypeGreen valueType, InternalSyntaxToken tQuestion)
	    {
	        if (this.ValueType != valueType ||
				this.TQuestion != tQuestion)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NullableType(valueType, tQuestion);
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
	
	internal class NonNullableTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NonNullableTypeGreen __Missing = new NonNullableTypeGreen();
	    private ReferenceTypeGreen referenceType;
	    private InternalSyntaxToken tExclamation;
	
	    public NonNullableTypeGreen(SoalSyntaxKind kind, ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (referenceType != null)
			{
				this.AdjustFlagsAndWidth(referenceType);
				this.referenceType = referenceType;
			}
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
	    public NonNullableTypeGreen(SoalSyntaxKind kind, ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (referenceType != null)
			{
				this.AdjustFlagsAndWidth(referenceType);
				this.referenceType = referenceType;
			}
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
		private NonNullableTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NonNullableType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ReferenceTypeGreen ReferenceType { get { return this.referenceType; } }
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NonNullableTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.referenceType;
	            case 1: return this.tExclamation;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNonNullableTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNonNullableTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NonNullableTypeGreen(this.Kind, this.referenceType, this.tExclamation, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NonNullableTypeGreen(this.Kind, this.referenceType, this.tExclamation, this.GetDiagnostics(), annotations);
	    }
	
	    public NonNullableTypeGreen Update(ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation)
	    {
	        if (this.ReferenceType != referenceType ||
				this.TExclamation != tExclamation)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NonNullableType(referenceType, tExclamation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NonNullableTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NonNullableArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NonNullableArrayTypeGreen __Missing = new NonNullableArrayTypeGreen();
	    private ArrayTypeGreen arrayType;
	    private InternalSyntaxToken tExclamation;
	
	    public NonNullableArrayTypeGreen(SoalSyntaxKind kind, ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
	    public NonNullableArrayTypeGreen(SoalSyntaxKind kind, ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (arrayType != null)
			{
				this.AdjustFlagsAndWidth(arrayType);
				this.arrayType = arrayType;
			}
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
	    }
	
		private NonNullableArrayTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NonNullableArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public ArrayTypeGreen ArrayType { get { return this.arrayType; } }
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NonNullableArrayTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arrayType;
	            case 1: return this.tExclamation;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNonNullableArrayTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNonNullableArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NonNullableArrayTypeGreen(this.Kind, this.arrayType, this.tExclamation, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NonNullableArrayTypeGreen(this.Kind, this.arrayType, this.tExclamation, this.GetDiagnostics(), annotations);
	    }
	
	    public NonNullableArrayTypeGreen Update(ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation)
	    {
	        if (this.ArrayType != arrayType ||
				this.TExclamation != tExclamation)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NonNullableArrayType(arrayType, tExclamation);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NonNullableArrayTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ArrayTypeGreen __Missing = new ArrayTypeGreen();
	    private SimpleArrayTypeGreen simpleArrayType;
	    private NulledArrayTypeGreen nulledArrayType;
	
	    public ArrayTypeGreen(SoalSyntaxKind kind, SimpleArrayTypeGreen simpleArrayType, NulledArrayTypeGreen nulledArrayType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (simpleArrayType != null)
			{
				this.AdjustFlagsAndWidth(simpleArrayType);
				this.simpleArrayType = simpleArrayType;
			}
			if (nulledArrayType != null)
			{
				this.AdjustFlagsAndWidth(nulledArrayType);
				this.nulledArrayType = nulledArrayType;
			}
	    }
	
	    public ArrayTypeGreen(SoalSyntaxKind kind, SimpleArrayTypeGreen simpleArrayType, NulledArrayTypeGreen nulledArrayType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (simpleArrayType != null)
			{
				this.AdjustFlagsAndWidth(simpleArrayType);
				this.simpleArrayType = simpleArrayType;
			}
			if (nulledArrayType != null)
			{
				this.AdjustFlagsAndWidth(nulledArrayType);
				this.nulledArrayType = nulledArrayType;
			}
	    }
	
		private ArrayTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleArrayTypeGreen SimpleArrayType { get { return this.simpleArrayType; } }
	    public NulledArrayTypeGreen NulledArrayType { get { return this.nulledArrayType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ArrayTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleArrayType;
	            case 1: return this.nulledArrayType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitArrayTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrayTypeGreen(this.Kind, this.simpleArrayType, this.nulledArrayType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrayTypeGreen(this.Kind, this.simpleArrayType, this.nulledArrayType, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrayTypeGreen Update(SimpleArrayTypeGreen simpleArrayType)
	    {
	        if (this.simpleArrayType != simpleArrayType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ArrayType(simpleArrayType);
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
	
	    public ArrayTypeGreen Update(NulledArrayTypeGreen nulledArrayType)
	    {
	        if (this.nulledArrayType != nulledArrayType)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ArrayType(nulledArrayType);
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
	
	internal class SimpleArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly SimpleArrayTypeGreen __Missing = new SimpleArrayTypeGreen();
	    private SimpleTypeGreen simpleType;
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken tCloseBracket;
	
	    public SimpleArrayTypeGreen(SoalSyntaxKind kind, SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
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
	
	    public SimpleArrayTypeGreen(SoalSyntaxKind kind, SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
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
	
		private SimpleArrayTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.SimpleArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SimpleArrayTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleType;
	            case 1: return this.tOpenBracket;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleArrayTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitSimpleArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleArrayTypeGreen(this.Kind, this.simpleType, this.tOpenBracket, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleArrayTypeGreen(this.Kind, this.simpleType, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleArrayTypeGreen Update(SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.SimpleType != simpleType ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleArrayType(simpleType, tOpenBracket, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleArrayTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NulledArrayTypeGreen : GreenSyntaxNode
	{
	    internal static readonly NulledArrayTypeGreen __Missing = new NulledArrayTypeGreen();
	    private NulledTypeGreen nulledType;
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken tCloseBracket;
	
	    public NulledArrayTypeGreen(SoalSyntaxKind kind, NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (nulledType != null)
			{
				this.AdjustFlagsAndWidth(nulledType);
				this.nulledType = nulledType;
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
	
	    public NulledArrayTypeGreen(SoalSyntaxKind kind, NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (nulledType != null)
			{
				this.AdjustFlagsAndWidth(nulledType);
				this.nulledType = nulledType;
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
	
		private NulledArrayTypeGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.NulledArrayType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NulledTypeGreen NulledType { get { return this.nulledType; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NulledArrayTypeSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nulledType;
	            case 1: return this.tOpenBracket;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNulledArrayTypeGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNulledArrayTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NulledArrayTypeGreen(this.Kind, this.nulledType, this.tOpenBracket, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NulledArrayTypeGreen(this.Kind, this.nulledType, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public NulledArrayTypeGreen Update(NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.NulledType != nulledType ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NulledArrayType(nulledType, tOpenBracket, tCloseBracket);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NulledArrayTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ConstantValueGreen : GreenSyntaxNode
	{
	    internal static readonly ConstantValueGreen __Missing = new ConstantValueGreen();
	    private LiteralGreen literal;
	    private IdentifierGreen identifier;
	
	    public ConstantValueGreen(SoalSyntaxKind kind, LiteralGreen literal, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public ConstantValueGreen(SoalSyntaxKind kind, LiteralGreen literal, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (literal != null)
			{
				this.AdjustFlagsAndWidth(literal);
				this.literal = literal;
			}
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		private ConstantValueGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ConstantValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public LiteralGreen Literal { get { return this.literal; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ConstantValueSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.literal;
	            case 1: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitConstantValueGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitConstantValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConstantValueGreen(this.Kind, this.literal, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConstantValueGreen(this.Kind, this.literal, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ConstantValueGreen Update(LiteralGreen literal)
	    {
	        if (this.literal != literal)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ConstantValue(literal);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstantValueGreen)newNode;
	        }
	        return this;
	    }
	
	    public ConstantValueGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ConstantValue(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstantValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeofValueGreen : GreenSyntaxNode
	{
	    internal static readonly TypeofValueGreen __Missing = new TypeofValueGreen();
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParen;
	    private ReturnTypeGreen returnType;
	    private InternalSyntaxToken tCloseParen;
	
	    public TypeofValueGreen(SoalSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen)
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
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
	    public TypeofValueGreen(SoalSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
			if (tCloseParen != null)
			{
				this.AdjustFlagsAndWidth(tCloseParen);
				this.tCloseParen = tCloseParen;
			}
	    }
	
		private TypeofValueGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.TypeofValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.TypeofValueSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTypeof;
	            case 1: return this.tOpenParen;
	            case 2: return this.returnType;
	            case 3: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitTypeofValueGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitTypeofValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeofValueGreen(this.Kind, this.kTypeof, this.tOpenParen, this.returnType, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeofValueGreen(this.Kind, this.kTypeof, this.tOpenParen, this.returnType, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeofValueGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParen != tOpenParen ||
				this.ReturnType != returnType ||
				this.TCloseParen != tCloseParen)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeofValue(kTypeof, tOpenParen, returnType, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierGreen __Missing = new IdentifierGreen();
	    private IdentifiersGreen identifiers;
	    private ContextualKeywordsGreen contextualKeywords;
	
	    public IdentifierGreen(SoalSyntaxKind kind, IdentifiersGreen identifiers, ContextualKeywordsGreen contextualKeywords)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (identifiers != null)
			{
				this.AdjustFlagsAndWidth(identifiers);
				this.identifiers = identifiers;
			}
			if (contextualKeywords != null)
			{
				this.AdjustFlagsAndWidth(contextualKeywords);
				this.contextualKeywords = contextualKeywords;
			}
	    }
	
	    public IdentifierGreen(SoalSyntaxKind kind, IdentifiersGreen identifiers, ContextualKeywordsGreen contextualKeywords, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (identifiers != null)
			{
				this.AdjustFlagsAndWidth(identifiers);
				this.identifiers = identifiers;
			}
			if (contextualKeywords != null)
			{
				this.AdjustFlagsAndWidth(contextualKeywords);
				this.contextualKeywords = contextualKeywords;
			}
	    }
	
		private IdentifierGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifiersGreen Identifiers { get { return this.identifiers; } }
	    public ContextualKeywordsGreen ContextualKeywords { get { return this.contextualKeywords; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IdentifierSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifiers;
	            case 1: return this.contextualKeywords;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.identifiers, this.contextualKeywords, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.identifiers, this.contextualKeywords, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(IdentifiersGreen identifiers)
	    {
	        if (this.identifiers != identifiers)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Identifier(identifiers);
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
	
	    public IdentifierGreen Update(ContextualKeywordsGreen contextualKeywords)
	    {
	        if (this.contextualKeywords != contextualKeywords)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Identifier(contextualKeywords);
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
	
	internal class IdentifiersGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifiersGreen __Missing = new IdentifiersGreen();
	    private InternalSyntaxToken identifiers;
	
	    public IdentifiersGreen(SoalSyntaxKind kind, InternalSyntaxToken identifiers)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifiers != null)
			{
				this.AdjustFlagsAndWidth(identifiers);
				this.identifiers = identifiers;
			}
	    }
	
	    public IdentifiersGreen(SoalSyntaxKind kind, InternalSyntaxToken identifiers, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (identifiers != null)
			{
				this.AdjustFlagsAndWidth(identifiers);
				this.identifiers = identifiers;
			}
	    }
	
		private IdentifiersGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.Identifiers, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Identifiers { get { return this.identifiers; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IdentifiersSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifiers;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifiersGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitIdentifiersGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifiersGreen(this.Kind, this.identifiers, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifiersGreen(this.Kind, this.identifiers, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifiersGreen Update(InternalSyntaxToken identifiers)
	    {
	        if (this.Identifiers != identifiers)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Identifiers(identifiers);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifiersGreen)newNode;
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
	
	    public LiteralGreen(SoalSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
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
	
	    public LiteralGreen(SoalSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.Literal, null, null)
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
	        return new global::MetaDslx.Languages.Soal.Syntax.LiteralSyntax(this, (SoalSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	    public NullLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NullLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	    public BooleanLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BooleanLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	    public IntegerLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IntegerLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	    public DecimalLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DecimalLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	    public ScientificLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ScientificLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	    private InternalSyntaxToken stringLiteral;
	
	    public StringLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public StringLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((SoalSyntaxKind)SoalSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.StringLiteralSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.StringLiteral(stringLiteral);
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
	
	internal class ContextualKeywordsGreen : GreenSyntaxNode
	{
	    internal static readonly ContextualKeywordsGreen __Missing = new ContextualKeywordsGreen();
	    private InternalSyntaxToken contextualKeywords;
	
	    public ContextualKeywordsGreen(SoalSyntaxKind kind, InternalSyntaxToken contextualKeywords)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (contextualKeywords != null)
			{
				this.AdjustFlagsAndWidth(contextualKeywords);
				this.contextualKeywords = contextualKeywords;
			}
	    }
	
	    public ContextualKeywordsGreen(SoalSyntaxKind kind, InternalSyntaxToken contextualKeywords, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (contextualKeywords != null)
			{
				this.AdjustFlagsAndWidth(contextualKeywords);
				this.contextualKeywords = contextualKeywords;
			}
	    }
	
		private ContextualKeywordsGreen()
			: base((SoalSyntaxKind)SoalSyntaxKind.ContextualKeywords, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ContextualKeywords { get { return this.contextualKeywords; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ContextualKeywordsSyntax(this, (SoalSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.contextualKeywords;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(SoalSyntaxVisitor<TResult> visitor) => visitor.VisitContextualKeywordsGreen(this);
	
	    public override void Accept(SoalSyntaxVisitor visitor) => visitor.VisitContextualKeywordsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ContextualKeywordsGreen(this.Kind, this.contextualKeywords, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ContextualKeywordsGreen(this.Kind, this.contextualKeywords, this.GetDiagnostics(), annotations);
	    }
	
	    public ContextualKeywordsGreen Update(InternalSyntaxToken contextualKeywords)
	    {
	        if (this.ContextualKeywords != contextualKeywords)
	        {
	            InternalSyntaxNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ContextualKeywords(contextualKeywords);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ContextualKeywordsGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class SoalSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierListGreen(IdentifierListGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierListGreen(QualifierListGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationListGreen(AnnotationListGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnAnnotationListGreen(ReturnAnnotationListGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationGreen(AnnotationGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnAnnotationGreen(ReturnAnnotationGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationHeadGreen(AnnotationHeadGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationBodyGreen(AnnotationBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationPropertyListGreen(AnnotationPropertyListGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationPropertyGreen(AnnotationPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitAnnotationPropertyValueGreen(AnnotationPropertyValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespacePrefixGreen(NamespacePrefixGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceUriGreen(NamespaceUriGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumBaseGreen(EnumBaseGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumLiteralsGreen(EnumLiteralsGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumLiteralGreen(EnumLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStructDeclarationGreen(StructDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitStructBodyGreen(StructBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitPropertyDeclarationGreen(PropertyDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitDatabaseDeclarationGreen(DatabaseDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitDatabaseBodyGreen(DatabaseBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEntityReferenceGreen(EntityReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitInterfaceDeclarationGreen(InterfaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitInterfaceBodyGreen(InterfaceBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationHeadGreen(OperationHeadGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationResultGreen(OperationResultGreen node) => this.DefaultVisit(node);
		public virtual void VisitThrowsListGreen(ThrowsListGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentDeclarationGreen(ComponentDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentBaseGreen(ComponentBaseGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentBodyGreen(ComponentBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentElementsGreen(ComponentElementsGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentElementGreen(ComponentElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentServiceGreen(ComponentServiceGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentReferenceGreen(ComponentReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentServiceOrReferenceEmptyBodyGreen(ComponentServiceOrReferenceEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentServiceOrReferenceNonEmptyBodyGreen(ComponentServiceOrReferenceNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentServiceOrReferenceElementGreen(ComponentServiceOrReferenceElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentPropertyGreen(ComponentPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentImplementationGreen(ComponentImplementationGreen node) => this.DefaultVisit(node);
		public virtual void VisitComponentLanguageGreen(ComponentLanguageGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompositeDeclarationGreen(CompositeDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompositeBodyGreen(CompositeBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssemblyDeclarationGreen(AssemblyDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompositeElementsGreen(CompositeElementsGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompositeElementGreen(CompositeElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompositeComponentGreen(CompositeComponentGreen node) => this.DefaultVisit(node);
		public virtual void VisitCompositeWireGreen(CompositeWireGreen node) => this.DefaultVisit(node);
		public virtual void VisitWireSourceGreen(WireSourceGreen node) => this.DefaultVisit(node);
		public virtual void VisitWireTargetGreen(WireTargetGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeploymentDeclarationGreen(DeploymentDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeploymentBodyGreen(DeploymentBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeploymentElementsGreen(DeploymentElementsGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeploymentElementGreen(DeploymentElementGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnvironmentDeclarationGreen(EnvironmentDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnvironmentBodyGreen(EnvironmentBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitRuntimeDeclarationGreen(RuntimeDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitRuntimeReferenceGreen(RuntimeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssemblyReferenceGreen(AssemblyReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitDatabaseReferenceGreen(DatabaseReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitBindingDeclarationGreen(BindingDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitBindingBodyGreen(BindingBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitBindingLayersGreen(BindingLayersGreen node) => this.DefaultVisit(node);
		public virtual void VisitTransportLayerGreen(TransportLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitHttpTransportLayerGreen(HttpTransportLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitHttpTransportLayerEmptyBodyGreen(HttpTransportLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitHttpTransportLayerNonEmptyBodyGreen(HttpTransportLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitRestTransportLayerGreen(RestTransportLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitRestTransportLayerEmptyBodyGreen(RestTransportLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitRestTransportLayerNonEmptyBodyGreen(RestTransportLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitWebSocketTransportLayerGreen(WebSocketTransportLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitWebSocketTransportLayerEmptyBodyGreen(WebSocketTransportLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitWebSocketTransportLayerNonEmptyBodyGreen(WebSocketTransportLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitHttpTransportLayerPropertiesGreen(HttpTransportLayerPropertiesGreen node) => this.DefaultVisit(node);
		public virtual void VisitHttpSslPropertyGreen(HttpSslPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitHttpClientAuthenticationPropertyGreen(HttpClientAuthenticationPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEncodingLayerGreen(EncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapEncodingLayerGreen(SoapEncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapEncodingLayerEmptyBodyGreen(SoapEncodingLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapEncodingLayerNonEmptyBodyGreen(SoapEncodingLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitXmlEncodingLayerGreen(XmlEncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitXmlEncodingLayerEmptyBodyGreen(XmlEncodingLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitXmlEncodingLayerNonEmptyBodyGreen(XmlEncodingLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitJsonEncodingLayerGreen(JsonEncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitJsonEncodingLayerEmptyBodyGreen(JsonEncodingLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitJsonEncodingLayerNonEmptyBodyGreen(JsonEncodingLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapEncodingPropertiesGreen(SoapEncodingPropertiesGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapVersionPropertyGreen(SoapVersionPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapMtomPropertyGreen(SoapMtomPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitSoapStylePropertyGreen(SoapStylePropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitProtocolLayerGreen(ProtocolLayerGreen node) => this.DefaultVisit(node);
		public virtual void VisitProtocolLayerKindGreen(ProtocolLayerKindGreen node) => this.DefaultVisit(node);
		public virtual void VisitWsAddressingGreen(WsAddressingGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndpointDeclarationGreen(EndpointDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndpointBodyGreen(EndpointBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndpointPropertiesGreen(EndpointPropertiesGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndpointPropertyGreen(EndpointPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndpointBindingPropertyGreen(EndpointBindingPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEndpointAddressPropertyGreen(EndpointAddressPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNulledTypeGreen(NulledTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitReferenceTypeGreen(ReferenceTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitValueTypeGreen(ValueTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitOnewayTypeGreen(OnewayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationReturnTypeGreen(OperationReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNonNullableTypeGreen(NonNullableTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNonNullableArrayTypeGreen(NonNullableArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitArrayTypeGreen(ArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleArrayTypeGreen(SimpleArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNulledArrayTypeGreen(NulledArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitConstantValueGreen(ConstantValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeofValueGreen(TypeofValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifiersGreen(IdentifiersGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitContextualKeywordsGreen(ContextualKeywordsGreen node) => this.DefaultVisit(node);
	}
	
	internal class SoalSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierListGreen(IdentifierListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierListGreen(QualifierListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationListGreen(AnnotationListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnAnnotationListGreen(ReturnAnnotationListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationGreen(AnnotationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnAnnotationGreen(ReturnAnnotationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationHeadGreen(AnnotationHeadGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationBodyGreen(AnnotationBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationPropertyListGreen(AnnotationPropertyListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationPropertyGreen(AnnotationPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAnnotationPropertyValueGreen(AnnotationPropertyValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespacePrefixGreen(NamespacePrefixGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceUriGreen(NamespaceUriGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumBaseGreen(EnumBaseGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumLiteralsGreen(EnumLiteralsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumLiteralGreen(EnumLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStructDeclarationGreen(StructDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStructBodyGreen(StructBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPropertyDeclarationGreen(PropertyDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDatabaseDeclarationGreen(DatabaseDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDatabaseBodyGreen(DatabaseBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEntityReferenceGreen(EntityReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInterfaceDeclarationGreen(InterfaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitInterfaceBodyGreen(InterfaceBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationHeadGreen(OperationHeadGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationResultGreen(OperationResultGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitThrowsListGreen(ThrowsListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentDeclarationGreen(ComponentDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentBaseGreen(ComponentBaseGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentBodyGreen(ComponentBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentElementsGreen(ComponentElementsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentElementGreen(ComponentElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentServiceGreen(ComponentServiceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentReferenceGreen(ComponentReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentServiceOrReferenceEmptyBodyGreen(ComponentServiceOrReferenceEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentServiceOrReferenceNonEmptyBodyGreen(ComponentServiceOrReferenceNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentServiceOrReferenceElementGreen(ComponentServiceOrReferenceElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentPropertyGreen(ComponentPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentImplementationGreen(ComponentImplementationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitComponentLanguageGreen(ComponentLanguageGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompositeDeclarationGreen(CompositeDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompositeBodyGreen(CompositeBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssemblyDeclarationGreen(AssemblyDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompositeElementsGreen(CompositeElementsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompositeElementGreen(CompositeElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompositeComponentGreen(CompositeComponentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCompositeWireGreen(CompositeWireGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWireSourceGreen(WireSourceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWireTargetGreen(WireTargetGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeploymentDeclarationGreen(DeploymentDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeploymentBodyGreen(DeploymentBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeploymentElementsGreen(DeploymentElementsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeploymentElementGreen(DeploymentElementGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnvironmentDeclarationGreen(EnvironmentDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnvironmentBodyGreen(EnvironmentBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRuntimeDeclarationGreen(RuntimeDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRuntimeReferenceGreen(RuntimeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssemblyReferenceGreen(AssemblyReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDatabaseReferenceGreen(DatabaseReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBindingDeclarationGreen(BindingDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBindingBodyGreen(BindingBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBindingLayersGreen(BindingLayersGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTransportLayerGreen(TransportLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHttpTransportLayerGreen(HttpTransportLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHttpTransportLayerEmptyBodyGreen(HttpTransportLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHttpTransportLayerNonEmptyBodyGreen(HttpTransportLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRestTransportLayerGreen(RestTransportLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRestTransportLayerEmptyBodyGreen(RestTransportLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRestTransportLayerNonEmptyBodyGreen(RestTransportLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWebSocketTransportLayerGreen(WebSocketTransportLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWebSocketTransportLayerEmptyBodyGreen(WebSocketTransportLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWebSocketTransportLayerNonEmptyBodyGreen(WebSocketTransportLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHttpTransportLayerPropertiesGreen(HttpTransportLayerPropertiesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHttpSslPropertyGreen(HttpSslPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitHttpClientAuthenticationPropertyGreen(HttpClientAuthenticationPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEncodingLayerGreen(EncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapEncodingLayerGreen(SoapEncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapEncodingLayerEmptyBodyGreen(SoapEncodingLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapEncodingLayerNonEmptyBodyGreen(SoapEncodingLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitXmlEncodingLayerGreen(XmlEncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitXmlEncodingLayerEmptyBodyGreen(XmlEncodingLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitXmlEncodingLayerNonEmptyBodyGreen(XmlEncodingLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitJsonEncodingLayerGreen(JsonEncodingLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitJsonEncodingLayerEmptyBodyGreen(JsonEncodingLayerEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitJsonEncodingLayerNonEmptyBodyGreen(JsonEncodingLayerNonEmptyBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapEncodingPropertiesGreen(SoapEncodingPropertiesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapVersionPropertyGreen(SoapVersionPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapMtomPropertyGreen(SoapMtomPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSoapStylePropertyGreen(SoapStylePropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitProtocolLayerGreen(ProtocolLayerGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitProtocolLayerKindGreen(ProtocolLayerKindGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitWsAddressingGreen(WsAddressingGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndpointDeclarationGreen(EndpointDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndpointBodyGreen(EndpointBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndpointPropertiesGreen(EndpointPropertiesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndpointPropertyGreen(EndpointPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndpointBindingPropertyGreen(EndpointBindingPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEndpointAddressPropertyGreen(EndpointAddressPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNulledTypeGreen(NulledTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReferenceTypeGreen(ReferenceTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitValueTypeGreen(ValueTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOnewayTypeGreen(OnewayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationReturnTypeGreen(OperationReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNonNullableTypeGreen(NonNullableTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNonNullableArrayTypeGreen(NonNullableArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitArrayTypeGreen(ArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleArrayTypeGreen(SimpleArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNulledArrayTypeGreen(NulledArrayTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConstantValueGreen(ConstantValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeofValueGreen(TypeofValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifiersGreen(IdentifiersGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitContextualKeywordsGreen(ContextualKeywordsGreen node) => this.DefaultVisit(node);
	}
	internal class SoalInternalSyntaxFactory : InternalSyntaxFactory
	{
		public SoalInternalSyntaxFactory(SoalSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public override Language Language => SoalLanguage.Instance;
	
		private SoalSyntaxKind ToMetaSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<SoalSyntaxKind>();
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
			SoalSyntaxKind typedKind = ToMetaSyntaxKind(kind);
	        Debug.Assert(SoalLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = SoalLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			SoalSyntaxKind typedKind = ToMetaSyntaxKind(kind);
	        Debug.Assert(SoalLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = SoalLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			SoalSyntaxKind typedKind = ToMetaSyntaxKind(kind);
	        Debug.Assert(SoalLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = SoalLanguage.Instance.SyntaxFacts.GetText(typedKind);
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
	
	
	    internal InternalSyntaxToken TAsterisk(string text)
	    {
	        return Token(null, SoalSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, SoalSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, SoalSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDateTime, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDate, text, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text)
	    {
	        return Token(null, SoalSyntaxKind.LTime, text, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text)
	    {
	        return Token(null, SoalSyntaxKind.LRegularString, text, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text)
	    {
	        return Token(null, SoalSyntaxKind.LGuid, text, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, SoalSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, SoalSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, SoalSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, SoalSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, SoalSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LMultiLineComment(string text)
	    {
	        return Token(null, SoalSyntaxKind.LMultiLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LMultiLineComment(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LMultiLineComment, text, value, null);
	    }
	
		public MainGreen Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<NamespaceDeclarationGreen> namespaceDeclaration, InternalSyntaxToken eof)
	    {
	#if DEBUG
			if (eof == null) throw new ArgumentNullException(nameof(eof));
			if (eof.Kind != SoalSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Main, namespaceDeclaration.Node, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(SoalSyntaxKind.Main, namespaceDeclaration.Node, eof);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(SoalSyntaxKind.Name, identifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(SoalSyntaxKind.QualifiedName, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(SoalSyntaxKind.Qualifier, identifier.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.IdentifierList, identifier.Node, out hash);
			if (cached != null) return (IdentifierListGreen)cached;
			var result = new IdentifierListGreen(SoalSyntaxKind.IdentifierList, identifier.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.QualifierList, qualifier.Node, out hash);
			if (cached != null) return (QualifierListGreen)cached;
			var result = new QualifierListGreen(SoalSyntaxKind.QualifierList, qualifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationListGreen AnnotationList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AnnotationGreen> annotation)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationList, annotation.Node, out hash);
			if (cached != null) return (AnnotationListGreen)cached;
			var result = new AnnotationListGreen(SoalSyntaxKind.AnnotationList, annotation.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnAnnotationListGreen ReturnAnnotationList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ReturnAnnotationGreen> returnAnnotation)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ReturnAnnotationList, returnAnnotation.Node, out hash);
			if (cached != null) return (ReturnAnnotationListGreen)cached;
			var result = new ReturnAnnotationListGreen(SoalSyntaxKind.ReturnAnnotationList, returnAnnotation.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationGreen Annotation(InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (annotationHead == null) throw new ArgumentNullException(nameof(annotationHead));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Annotation, tOpenBracket, annotationHead, tCloseBracket, out hash);
			if (cached != null) return (AnnotationGreen)cached;
			var result = new AnnotationGreen(SoalSyntaxKind.Annotation, tOpenBracket, annotationHead, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnAnnotationGreen ReturnAnnotation(InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (kReturn == null) throw new ArgumentNullException(nameof(kReturn));
			if (kReturn.Kind != SoalSyntaxKind.KReturn) throw new ArgumentException(nameof(kReturn));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (annotationHead == null) throw new ArgumentNullException(nameof(annotationHead));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
	        return new ReturnAnnotationGreen(SoalSyntaxKind.ReturnAnnotation, tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
	    }
	
		public AnnotationHeadGreen AnnotationHead(NameGreen name, AnnotationBodyGreen annotationBody)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationHead, name, annotationBody, out hash);
			if (cached != null) return (AnnotationHeadGreen)cached;
			var result = new AnnotationHeadGreen(SoalSyntaxKind.AnnotationHead, name, annotationBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationBodyGreen AnnotationBody(InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationBody, tOpenParen, annotationPropertyList, tCloseParen, out hash);
			if (cached != null) return (AnnotationBodyGreen)cached;
			var result = new AnnotationBodyGreen(SoalSyntaxKind.AnnotationBody, tOpenParen, annotationPropertyList, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyListGreen AnnotationPropertyList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<AnnotationPropertyGreen> annotationProperty)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationPropertyList, annotationProperty.Node, out hash);
			if (cached != null) return (AnnotationPropertyListGreen)cached;
			var result = new AnnotationPropertyListGreen(SoalSyntaxKind.AnnotationPropertyList, annotationProperty.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyGreen AnnotationProperty(NameGreen name, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (annotationPropertyValue == null) throw new ArgumentNullException(nameof(annotationPropertyValue));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationProperty, name, tAssign, annotationPropertyValue, out hash);
			if (cached != null) return (AnnotationPropertyGreen)cached;
			var result = new AnnotationPropertyGreen(SoalSyntaxKind.AnnotationProperty, name, tAssign, annotationPropertyValue);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyValueGreen AnnotationPropertyValue(ConstantValueGreen constantValue)
	    {
	#if DEBUG
		    if (constantValue == null) throw new ArgumentNullException(nameof(constantValue));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationPropertyValue, constantValue, out hash);
			if (cached != null) return (AnnotationPropertyValueGreen)cached;
			var result = new AnnotationPropertyValueGreen(SoalSyntaxKind.AnnotationPropertyValue, constantValue, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyValueGreen AnnotationPropertyValue(TypeofValueGreen typeofValue)
	    {
	#if DEBUG
		    if (typeofValue == null) throw new ArgumentNullException(nameof(typeofValue));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AnnotationPropertyValue, typeofValue, out hash);
			if (cached != null) return (AnnotationPropertyValueGreen)cached;
			var result = new AnnotationPropertyValueGreen(SoalSyntaxKind.AnnotationPropertyValue, null, typeofValue);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclarationGreen NamespaceDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, InternalSyntaxToken tAssign, NamespacePrefixGreen namespacePrefix, InternalSyntaxToken tColon, NamespaceUriGreen namespaceUri, NamespaceBodyGreen namespaceBody)
	    {
	#if DEBUG
			if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
			if (kNamespace.Kind != SoalSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (tColon != null && tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (namespaceUri == null) throw new ArgumentNullException(nameof(namespaceUri));
			if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
	#endif
	        return new NamespaceDeclarationGreen(SoalSyntaxKind.NamespaceDeclaration, annotationList, kNamespace, qualifiedName, tAssign, namespacePrefix, tColon, namespaceUri, namespaceBody);
	    }
	
		public NamespacePrefixGreen NamespacePrefix(IdentifierGreen identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NamespacePrefix, identifier, out hash);
			if (cached != null) return (NamespacePrefixGreen)cached;
			var result = new NamespacePrefixGreen(SoalSyntaxKind.NamespacePrefix, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceUriGreen NamespaceUri(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NamespaceUri, stringLiteral, out hash);
			if (cached != null) return (NamespaceUriGreen)cached;
			var result = new NamespaceUriGreen(SoalSyntaxKind.NamespaceUri, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NamespaceBody, tOpenBrace, declaration.Node, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBodyGreen)cached;
			var result = new NamespaceBodyGreen(SoalSyntaxKind.NamespaceBody, tOpenBrace, declaration.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(EnumDeclarationGreen enumDeclaration)
	    {
	#if DEBUG
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, enumDeclaration, null, null, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(StructDeclarationGreen structDeclaration)
	    {
	#if DEBUG
		    if (structDeclaration == null) throw new ArgumentNullException(nameof(structDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, structDeclaration, null, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(DatabaseDeclarationGreen databaseDeclaration)
	    {
	#if DEBUG
		    if (databaseDeclaration == null) throw new ArgumentNullException(nameof(databaseDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, databaseDeclaration, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(InterfaceDeclarationGreen interfaceDeclaration)
	    {
	#if DEBUG
		    if (interfaceDeclaration == null) throw new ArgumentNullException(nameof(interfaceDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, interfaceDeclaration, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ComponentDeclarationGreen componentDeclaration)
	    {
	#if DEBUG
		    if (componentDeclaration == null) throw new ArgumentNullException(nameof(componentDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, componentDeclaration, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(CompositeDeclarationGreen compositeDeclaration)
	    {
	#if DEBUG
		    if (compositeDeclaration == null) throw new ArgumentNullException(nameof(compositeDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, compositeDeclaration, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(AssemblyDeclarationGreen assemblyDeclaration)
	    {
	#if DEBUG
		    if (assemblyDeclaration == null) throw new ArgumentNullException(nameof(assemblyDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, assemblyDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(BindingDeclarationGreen bindingDeclaration)
	    {
	#if DEBUG
		    if (bindingDeclaration == null) throw new ArgumentNullException(nameof(bindingDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, null, bindingDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(EndpointDeclarationGreen endpointDeclaration)
	    {
	#if DEBUG
		    if (endpointDeclaration == null) throw new ArgumentNullException(nameof(endpointDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, null, null, endpointDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(DeploymentDeclarationGreen deploymentDeclaration)
	    {
	#if DEBUG
		    if (deploymentDeclaration == null) throw new ArgumentNullException(nameof(deploymentDeclaration));
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, null, null, null, deploymentDeclaration);
	    }
	
		public EnumDeclarationGreen EnumDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameGreen name, InternalSyntaxToken tColon, EnumBaseGreen enumBase, EnumBodyGreen enumBody)
	    {
	#if DEBUG
			if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
			if (kEnum.Kind != SoalSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
	#endif
	        return new EnumDeclarationGreen(SoalSyntaxKind.EnumDeclaration, annotationList, kEnum, name, tColon, enumBase, enumBody);
	    }
	
		public EnumBaseGreen EnumBase(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EnumBase, qualifier, out hash);
			if (cached != null) return (EnumBaseGreen)cached;
			var result = new EnumBaseGreen(SoalSyntaxKind.EnumBase, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumBodyGreen EnumBody(InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EnumBody, tOpenBrace, enumLiterals, tCloseBrace, out hash);
			if (cached != null) return (EnumBodyGreen)cached;
			var result = new EnumBodyGreen(SoalSyntaxKind.EnumBody, tOpenBrace, enumLiterals, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumLiteralsGreen EnumLiterals(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumLiteralGreen> enumLiteral)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EnumLiterals, enumLiteral.Node, out hash);
			if (cached != null) return (EnumLiteralsGreen)cached;
			var result = new EnumLiteralsGreen(SoalSyntaxKind.EnumLiterals, enumLiteral.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumLiteralGreen EnumLiteral(AnnotationListGreen annotationList, NameGreen name)
	    {
	#if DEBUG
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EnumLiteral, annotationList, name, out hash);
			if (cached != null) return (EnumLiteralGreen)cached;
			var result = new EnumLiteralGreen(SoalSyntaxKind.EnumLiteral, annotationList, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StructDeclarationGreen StructDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, StructBodyGreen structBody)
	    {
	#if DEBUG
			if (kStruct == null) throw new ArgumentNullException(nameof(kStruct));
			if (kStruct.Kind != SoalSyntaxKind.KStruct) throw new ArgumentException(nameof(kStruct));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (structBody == null) throw new ArgumentNullException(nameof(structBody));
	#endif
	        return new StructDeclarationGreen(SoalSyntaxKind.StructDeclaration, annotationList, kStruct, name, tColon, qualifier, structBody);
	    }
	
		public StructBodyGreen StructBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<PropertyDeclarationGreen> propertyDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.StructBody, tOpenBrace, propertyDeclaration.Node, tCloseBrace, out hash);
			if (cached != null) return (StructBodyGreen)cached;
			var result = new StructBodyGreen(SoalSyntaxKind.StructBody, tOpenBrace, propertyDeclaration.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PropertyDeclarationGreen PropertyDeclaration(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new PropertyDeclarationGreen(SoalSyntaxKind.PropertyDeclaration, annotationList, typeReference, name, tSemicolon);
	    }
	
		public DatabaseDeclarationGreen DatabaseDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameGreen name, DatabaseBodyGreen databaseBody)
	    {
	#if DEBUG
			if (kDatabase == null) throw new ArgumentNullException(nameof(kDatabase));
			if (kDatabase.Kind != SoalSyntaxKind.KDatabase) throw new ArgumentException(nameof(kDatabase));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (databaseBody == null) throw new ArgumentNullException(nameof(databaseBody));
	#endif
	        return new DatabaseDeclarationGreen(SoalSyntaxKind.DatabaseDeclaration, annotationList, kDatabase, name, databaseBody);
	    }
	
		public DatabaseBodyGreen DatabaseBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EntityReferenceGreen> entityReference, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen> operationDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
	        return new DatabaseBodyGreen(SoalSyntaxKind.DatabaseBody, tOpenBrace, entityReference.Node, operationDeclaration.Node, tCloseBrace);
	    }
	
		public EntityReferenceGreen EntityReference(InternalSyntaxToken kEntity, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kEntity == null) throw new ArgumentNullException(nameof(kEntity));
			if (kEntity.Kind != SoalSyntaxKind.KEntity) throw new ArgumentException(nameof(kEntity));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EntityReference, kEntity, qualifier, tSemicolon, out hash);
			if (cached != null) return (EntityReferenceGreen)cached;
			var result = new EntityReferenceGreen(SoalSyntaxKind.EntityReference, kEntity, qualifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InterfaceDeclarationGreen InterfaceDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameGreen name, InterfaceBodyGreen interfaceBody)
	    {
	#if DEBUG
			if (kInterface == null) throw new ArgumentNullException(nameof(kInterface));
			if (kInterface.Kind != SoalSyntaxKind.KInterface) throw new ArgumentException(nameof(kInterface));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (interfaceBody == null) throw new ArgumentNullException(nameof(interfaceBody));
	#endif
	        return new InterfaceDeclarationGreen(SoalSyntaxKind.InterfaceDeclaration, annotationList, kInterface, name, interfaceBody);
	    }
	
		public InterfaceBodyGreen InterfaceBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationDeclarationGreen> operationDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.InterfaceBody, tOpenBrace, operationDeclaration.Node, tCloseBrace, out hash);
			if (cached != null) return (InterfaceBodyGreen)cached;
			var result = new InterfaceBodyGreen(SoalSyntaxKind.InterfaceBody, tOpenBrace, operationDeclaration.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationDeclarationGreen OperationDeclaration(OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (operationHead == null) throw new ArgumentNullException(nameof(operationHead));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.OperationDeclaration, operationHead, tSemicolon, out hash);
			if (cached != null) return (OperationDeclarationGreen)cached;
			var result = new OperationDeclarationGreen(SoalSyntaxKind.OperationDeclaration, operationHead, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationHeadGreen OperationHead(AnnotationListGreen annotationList, OperationResultGreen operationResult, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, ThrowsListGreen throwsList)
	    {
	#if DEBUG
			if (operationResult == null) throw new ArgumentNullException(nameof(operationResult));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new OperationHeadGreen(SoalSyntaxKind.OperationHead, annotationList, operationResult, name, tOpenParen, parameterList, tCloseParen, throwsList);
	    }
	
		public ParameterListGreen ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ParameterList, parameter.Node, out hash);
			if (cached != null) return (ParameterListGreen)cached;
			var result = new ParameterListGreen(SoalSyntaxKind.ParameterList, parameter.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParameterGreen Parameter(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameGreen name)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Parameter, annotationList, typeReference, name, out hash);
			if (cached != null) return (ParameterGreen)cached;
			var result = new ParameterGreen(SoalSyntaxKind.Parameter, annotationList, typeReference, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationResultGreen OperationResult(ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType)
	    {
	#if DEBUG
			if (operationReturnType == null) throw new ArgumentNullException(nameof(operationReturnType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.OperationResult, returnAnnotationList, operationReturnType, out hash);
			if (cached != null) return (OperationResultGreen)cached;
			var result = new OperationResultGreen(SoalSyntaxKind.OperationResult, returnAnnotationList, operationReturnType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ThrowsListGreen ThrowsList(InternalSyntaxToken kThrows, QualifierListGreen qualifierList)
	    {
	#if DEBUG
			if (kThrows == null) throw new ArgumentNullException(nameof(kThrows));
			if (kThrows.Kind != SoalSyntaxKind.KThrows) throw new ArgumentException(nameof(kThrows));
			if (qualifierList == null) throw new ArgumentNullException(nameof(qualifierList));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ThrowsList, kThrows, qualifierList, out hash);
			if (cached != null) return (ThrowsListGreen)cached;
			var result = new ThrowsListGreen(SoalSyntaxKind.ThrowsList, kThrows, qualifierList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentDeclarationGreen ComponentDeclaration(InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, ComponentBodyGreen componentBody)
	    {
	#if DEBUG
			if (kAbstract != null && kAbstract.Kind != SoalSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
			if (kComponent == null) throw new ArgumentNullException(nameof(kComponent));
			if (kComponent.Kind != SoalSyntaxKind.KComponent) throw new ArgumentException(nameof(kComponent));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (componentBody == null) throw new ArgumentNullException(nameof(componentBody));
	#endif
	        return new ComponentDeclarationGreen(SoalSyntaxKind.ComponentDeclaration, kAbstract, kComponent, name, tColon, componentBase, componentBody);
	    }
	
		public ComponentBaseGreen ComponentBase(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentBase, qualifier, out hash);
			if (cached != null) return (ComponentBaseGreen)cached;
			var result = new ComponentBaseGreen(SoalSyntaxKind.ComponentBase, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentBodyGreen ComponentBody(InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentBody, tOpenBrace, componentElements, tCloseBrace, out hash);
			if (cached != null) return (ComponentBodyGreen)cached;
			var result = new ComponentBodyGreen(SoalSyntaxKind.ComponentBody, tOpenBrace, componentElements, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentElementsGreen ComponentElements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentElementGreen> componentElement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentElements, componentElement.Node, out hash);
			if (cached != null) return (ComponentElementsGreen)cached;
			var result = new ComponentElementsGreen(SoalSyntaxKind.ComponentElements, componentElement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentElementGreen ComponentElement(ComponentServiceGreen componentService)
	    {
	#if DEBUG
		    if (componentService == null) throw new ArgumentNullException(nameof(componentService));
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, componentService, null, null, null, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentReferenceGreen componentReference)
	    {
	#if DEBUG
		    if (componentReference == null) throw new ArgumentNullException(nameof(componentReference));
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, componentReference, null, null, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentPropertyGreen componentProperty)
	    {
	#if DEBUG
		    if (componentProperty == null) throw new ArgumentNullException(nameof(componentProperty));
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, null, componentProperty, null, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentImplementationGreen componentImplementation)
	    {
	#if DEBUG
		    if (componentImplementation == null) throw new ArgumentNullException(nameof(componentImplementation));
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, null, null, componentImplementation, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentLanguageGreen componentLanguage)
	    {
	#if DEBUG
		    if (componentLanguage == null) throw new ArgumentNullException(nameof(componentLanguage));
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, null, null, null, componentLanguage);
	    }
	
		public ComponentServiceGreen ComponentService(InternalSyntaxToken kService, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	    {
	#if DEBUG
			if (kService == null) throw new ArgumentNullException(nameof(kService));
			if (kService.Kind != SoalSyntaxKind.KService) throw new ArgumentException(nameof(kService));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (componentServiceOrReferenceBody == null) throw new ArgumentNullException(nameof(componentServiceOrReferenceBody));
	#endif
	        return new ComponentServiceGreen(SoalSyntaxKind.ComponentService, kService, qualifier, name, componentServiceOrReferenceBody);
	    }
	
		public ComponentReferenceGreen ComponentReference(InternalSyntaxToken kReference, QualifierGreen qualifier, NameGreen name, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	    {
	#if DEBUG
			if (kReference == null) throw new ArgumentNullException(nameof(kReference));
			if (kReference.Kind != SoalSyntaxKind.KReference) throw new ArgumentException(nameof(kReference));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (componentServiceOrReferenceBody == null) throw new ArgumentNullException(nameof(componentServiceOrReferenceBody));
	#endif
	        return new ComponentReferenceGreen(SoalSyntaxKind.ComponentReference, kReference, qualifier, name, componentServiceOrReferenceBody);
	    }
	
		public ComponentServiceOrReferenceEmptyBodyGreen ComponentServiceOrReferenceEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentServiceOrReferenceEmptyBody, tSemicolon, out hash);
			if (cached != null) return (ComponentServiceOrReferenceEmptyBodyGreen)cached;
			var result = new ComponentServiceOrReferenceEmptyBodyGreen(SoalSyntaxKind.ComponentServiceOrReferenceEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentServiceOrReferenceNonEmptyBodyGreen ComponentServiceOrReferenceNonEmptyBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ComponentServiceOrReferenceElementGreen> componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentServiceOrReferenceNonEmptyBody, tOpenBrace, componentServiceOrReferenceElement.Node, tCloseBrace, out hash);
			if (cached != null) return (ComponentServiceOrReferenceNonEmptyBodyGreen)cached;
			var result = new ComponentServiceOrReferenceNonEmptyBodyGreen(SoalSyntaxKind.ComponentServiceOrReferenceNonEmptyBody, tOpenBrace, componentServiceOrReferenceElement.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentServiceOrReferenceElementGreen ComponentServiceOrReferenceElement(InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
			if (kBinding.Kind != SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentServiceOrReferenceElement, kBinding, qualifier, tSemicolon, out hash);
			if (cached != null) return (ComponentServiceOrReferenceElementGreen)cached;
			var result = new ComponentServiceOrReferenceElementGreen(SoalSyntaxKind.ComponentServiceOrReferenceElement, kBinding, qualifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentPropertyGreen ComponentProperty(TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentProperty, typeReference, name, tSemicolon, out hash);
			if (cached != null) return (ComponentPropertyGreen)cached;
			var result = new ComponentPropertyGreen(SoalSyntaxKind.ComponentProperty, typeReference, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentImplementationGreen ComponentImplementation(InternalSyntaxToken kImplementation, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kImplementation == null) throw new ArgumentNullException(nameof(kImplementation));
			if (kImplementation.Kind != SoalSyntaxKind.KImplementation) throw new ArgumentException(nameof(kImplementation));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentImplementation, kImplementation, name, tSemicolon, out hash);
			if (cached != null) return (ComponentImplementationGreen)cached;
			var result = new ComponentImplementationGreen(SoalSyntaxKind.ComponentImplementation, kImplementation, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentLanguageGreen ComponentLanguage(InternalSyntaxToken kLanguage, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kLanguage == null) throw new ArgumentNullException(nameof(kLanguage));
			if (kLanguage.Kind != SoalSyntaxKind.KLanguage) throw new ArgumentException(nameof(kLanguage));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ComponentLanguage, kLanguage, name, tSemicolon, out hash);
			if (cached != null) return (ComponentLanguageGreen)cached;
			var result = new ComponentLanguageGreen(SoalSyntaxKind.ComponentLanguage, kLanguage, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompositeDeclarationGreen CompositeDeclaration(InternalSyntaxToken kComposite, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody)
	    {
	#if DEBUG
			if (kComposite == null) throw new ArgumentNullException(nameof(kComposite));
			if (kComposite.Kind != SoalSyntaxKind.KComposite) throw new ArgumentException(nameof(kComposite));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (compositeBody == null) throw new ArgumentNullException(nameof(compositeBody));
	#endif
	        return new CompositeDeclarationGreen(SoalSyntaxKind.CompositeDeclaration, kComposite, name, tColon, componentBase, compositeBody);
	    }
	
		public CompositeBodyGreen CompositeBody(InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.CompositeBody, tOpenBrace, compositeElements, tCloseBrace, out hash);
			if (cached != null) return (CompositeBodyGreen)cached;
			var result = new CompositeBodyGreen(SoalSyntaxKind.CompositeBody, tOpenBrace, compositeElements, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssemblyDeclarationGreen AssemblyDeclaration(InternalSyntaxToken kAssembly, NameGreen name, InternalSyntaxToken tColon, ComponentBaseGreen componentBase, CompositeBodyGreen compositeBody)
	    {
	#if DEBUG
			if (kAssembly == null) throw new ArgumentNullException(nameof(kAssembly));
			if (kAssembly.Kind != SoalSyntaxKind.KAssembly) throw new ArgumentException(nameof(kAssembly));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (compositeBody == null) throw new ArgumentNullException(nameof(compositeBody));
	#endif
	        return new AssemblyDeclarationGreen(SoalSyntaxKind.AssemblyDeclaration, kAssembly, name, tColon, componentBase, compositeBody);
	    }
	
		public CompositeElementsGreen CompositeElements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<CompositeElementGreen> compositeElement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.CompositeElements, compositeElement.Node, out hash);
			if (cached != null) return (CompositeElementsGreen)cached;
			var result = new CompositeElementsGreen(SoalSyntaxKind.CompositeElements, compositeElement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompositeElementGreen CompositeElement(ComponentServiceGreen componentService)
	    {
	#if DEBUG
		    if (componentService == null) throw new ArgumentNullException(nameof(componentService));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, componentService, null, null, null, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentReferenceGreen componentReference)
	    {
	#if DEBUG
		    if (componentReference == null) throw new ArgumentNullException(nameof(componentReference));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, componentReference, null, null, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentPropertyGreen componentProperty)
	    {
	#if DEBUG
		    if (componentProperty == null) throw new ArgumentNullException(nameof(componentProperty));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, componentProperty, null, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentImplementationGreen componentImplementation)
	    {
	#if DEBUG
		    if (componentImplementation == null) throw new ArgumentNullException(nameof(componentImplementation));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, componentImplementation, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentLanguageGreen componentLanguage)
	    {
	#if DEBUG
		    if (componentLanguage == null) throw new ArgumentNullException(nameof(componentLanguage));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, null, componentLanguage, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(CompositeComponentGreen compositeComponent)
	    {
	#if DEBUG
		    if (compositeComponent == null) throw new ArgumentNullException(nameof(compositeComponent));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, null, null, compositeComponent, null);
	    }
	
		public CompositeElementGreen CompositeElement(CompositeWireGreen compositeWire)
	    {
	#if DEBUG
		    if (compositeWire == null) throw new ArgumentNullException(nameof(compositeWire));
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, null, null, null, compositeWire);
	    }
	
		public CompositeComponentGreen CompositeComponent(InternalSyntaxToken kComponent, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kComponent == null) throw new ArgumentNullException(nameof(kComponent));
			if (kComponent.Kind != SoalSyntaxKind.KComponent) throw new ArgumentException(nameof(kComponent));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.CompositeComponent, kComponent, qualifier, tSemicolon, out hash);
			if (cached != null) return (CompositeComponentGreen)cached;
			var result = new CompositeComponentGreen(SoalSyntaxKind.CompositeComponent, kComponent, qualifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompositeWireGreen CompositeWire(InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kWire == null) throw new ArgumentNullException(nameof(kWire));
			if (kWire.Kind != SoalSyntaxKind.KWire) throw new ArgumentException(nameof(kWire));
			if (wireSource == null) throw new ArgumentNullException(nameof(wireSource));
			if (kTo == null) throw new ArgumentNullException(nameof(kTo));
			if (kTo.Kind != SoalSyntaxKind.KTo) throw new ArgumentException(nameof(kTo));
			if (wireTarget == null) throw new ArgumentNullException(nameof(wireTarget));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new CompositeWireGreen(SoalSyntaxKind.CompositeWire, kWire, wireSource, kTo, wireTarget, tSemicolon);
	    }
	
		public WireSourceGreen WireSource(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.WireSource, qualifier, out hash);
			if (cached != null) return (WireSourceGreen)cached;
			var result = new WireSourceGreen(SoalSyntaxKind.WireSource, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WireTargetGreen WireTarget(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.WireTarget, qualifier, out hash);
			if (cached != null) return (WireTargetGreen)cached;
			var result = new WireTargetGreen(SoalSyntaxKind.WireTarget, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentDeclarationGreen DeploymentDeclaration(InternalSyntaxToken kDeployment, NameGreen name, DeploymentBodyGreen deploymentBody)
	    {
	#if DEBUG
			if (kDeployment == null) throw new ArgumentNullException(nameof(kDeployment));
			if (kDeployment.Kind != SoalSyntaxKind.KDeployment) throw new ArgumentException(nameof(kDeployment));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (deploymentBody == null) throw new ArgumentNullException(nameof(deploymentBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DeploymentDeclaration, kDeployment, name, deploymentBody, out hash);
			if (cached != null) return (DeploymentDeclarationGreen)cached;
			var result = new DeploymentDeclarationGreen(SoalSyntaxKind.DeploymentDeclaration, kDeployment, name, deploymentBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentBodyGreen DeploymentBody(InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DeploymentBody, tOpenBrace, deploymentElements, tCloseBrace, out hash);
			if (cached != null) return (DeploymentBodyGreen)cached;
			var result = new DeploymentBodyGreen(SoalSyntaxKind.DeploymentBody, tOpenBrace, deploymentElements, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentElementsGreen DeploymentElements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeploymentElementGreen> deploymentElement)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DeploymentElements, deploymentElement.Node, out hash);
			if (cached != null) return (DeploymentElementsGreen)cached;
			var result = new DeploymentElementsGreen(SoalSyntaxKind.DeploymentElements, deploymentElement.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentElementGreen DeploymentElement(EnvironmentDeclarationGreen environmentDeclaration)
	    {
	#if DEBUG
		    if (environmentDeclaration == null) throw new ArgumentNullException(nameof(environmentDeclaration));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DeploymentElement, environmentDeclaration, out hash);
			if (cached != null) return (DeploymentElementGreen)cached;
			var result = new DeploymentElementGreen(SoalSyntaxKind.DeploymentElement, environmentDeclaration, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentElementGreen DeploymentElement(CompositeWireGreen compositeWire)
	    {
	#if DEBUG
		    if (compositeWire == null) throw new ArgumentNullException(nameof(compositeWire));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DeploymentElement, compositeWire, out hash);
			if (cached != null) return (DeploymentElementGreen)cached;
			var result = new DeploymentElementGreen(SoalSyntaxKind.DeploymentElement, null, compositeWire);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnvironmentDeclarationGreen EnvironmentDeclaration(InternalSyntaxToken kEnvironment, NameGreen name, EnvironmentBodyGreen environmentBody)
	    {
	#if DEBUG
			if (kEnvironment == null) throw new ArgumentNullException(nameof(kEnvironment));
			if (kEnvironment.Kind != SoalSyntaxKind.KEnvironment) throw new ArgumentException(nameof(kEnvironment));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (environmentBody == null) throw new ArgumentNullException(nameof(environmentBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EnvironmentDeclaration, kEnvironment, name, environmentBody, out hash);
			if (cached != null) return (EnvironmentDeclarationGreen)cached;
			var result = new EnvironmentDeclarationGreen(SoalSyntaxKind.EnvironmentDeclaration, kEnvironment, name, environmentBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnvironmentBodyGreen EnvironmentBody(InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RuntimeReferenceGreen> runtimeReference, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (runtimeDeclaration == null) throw new ArgumentNullException(nameof(runtimeDeclaration));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
	        return new EnvironmentBodyGreen(SoalSyntaxKind.EnvironmentBody, tOpenBrace, runtimeDeclaration, runtimeReference.Node, tCloseBrace);
	    }
	
		public RuntimeDeclarationGreen RuntimeDeclaration(InternalSyntaxToken kRuntime, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kRuntime == null) throw new ArgumentNullException(nameof(kRuntime));
			if (kRuntime.Kind != SoalSyntaxKind.KRuntime) throw new ArgumentException(nameof(kRuntime));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.RuntimeDeclaration, kRuntime, name, tSemicolon, out hash);
			if (cached != null) return (RuntimeDeclarationGreen)cached;
			var result = new RuntimeDeclarationGreen(SoalSyntaxKind.RuntimeDeclaration, kRuntime, name, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RuntimeReferenceGreen RuntimeReference(AssemblyReferenceGreen assemblyReference)
	    {
	#if DEBUG
		    if (assemblyReference == null) throw new ArgumentNullException(nameof(assemblyReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.RuntimeReference, assemblyReference, out hash);
			if (cached != null) return (RuntimeReferenceGreen)cached;
			var result = new RuntimeReferenceGreen(SoalSyntaxKind.RuntimeReference, assemblyReference, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RuntimeReferenceGreen RuntimeReference(DatabaseReferenceGreen databaseReference)
	    {
	#if DEBUG
		    if (databaseReference == null) throw new ArgumentNullException(nameof(databaseReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.RuntimeReference, databaseReference, out hash);
			if (cached != null) return (RuntimeReferenceGreen)cached;
			var result = new RuntimeReferenceGreen(SoalSyntaxKind.RuntimeReference, null, databaseReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssemblyReferenceGreen AssemblyReference(InternalSyntaxToken kAssembly, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kAssembly == null) throw new ArgumentNullException(nameof(kAssembly));
			if (kAssembly.Kind != SoalSyntaxKind.KAssembly) throw new ArgumentException(nameof(kAssembly));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.AssemblyReference, kAssembly, qualifier, tSemicolon, out hash);
			if (cached != null) return (AssemblyReferenceGreen)cached;
			var result = new AssemblyReferenceGreen(SoalSyntaxKind.AssemblyReference, kAssembly, qualifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DatabaseReferenceGreen DatabaseReference(InternalSyntaxToken kDatabase, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kDatabase == null) throw new ArgumentNullException(nameof(kDatabase));
			if (kDatabase.Kind != SoalSyntaxKind.KDatabase) throw new ArgumentException(nameof(kDatabase));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DatabaseReference, kDatabase, qualifier, tSemicolon, out hash);
			if (cached != null) return (DatabaseReferenceGreen)cached;
			var result = new DatabaseReferenceGreen(SoalSyntaxKind.DatabaseReference, kDatabase, qualifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BindingDeclarationGreen BindingDeclaration(InternalSyntaxToken kBinding, NameGreen name, BindingBodyGreen bindingBody)
	    {
	#if DEBUG
			if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
			if (kBinding.Kind != SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (bindingBody == null) throw new ArgumentNullException(nameof(bindingBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.BindingDeclaration, kBinding, name, bindingBody, out hash);
			if (cached != null) return (BindingDeclarationGreen)cached;
			var result = new BindingDeclarationGreen(SoalSyntaxKind.BindingDeclaration, kBinding, name, bindingBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BindingBodyGreen BindingBody(InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.BindingBody, tOpenBrace, bindingLayers, tCloseBrace, out hash);
			if (cached != null) return (BindingBodyGreen)cached;
			var result = new BindingBodyGreen(SoalSyntaxKind.BindingBody, tOpenBrace, bindingLayers, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BindingLayersGreen BindingLayers(TransportLayerGreen transportLayer, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EncodingLayerGreen> encodingLayer, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ProtocolLayerGreen> protocolLayer)
	    {
	#if DEBUG
			if (transportLayer == null) throw new ArgumentNullException(nameof(transportLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.BindingLayers, transportLayer, encodingLayer.Node, protocolLayer.Node, out hash);
			if (cached != null) return (BindingLayersGreen)cached;
			var result = new BindingLayersGreen(SoalSyntaxKind.BindingLayers, transportLayer, encodingLayer.Node, protocolLayer.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TransportLayerGreen TransportLayer(HttpTransportLayerGreen httpTransportLayer)
	    {
	#if DEBUG
		    if (httpTransportLayer == null) throw new ArgumentNullException(nameof(httpTransportLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.TransportLayer, httpTransportLayer, out hash);
			if (cached != null) return (TransportLayerGreen)cached;
			var result = new TransportLayerGreen(SoalSyntaxKind.TransportLayer, httpTransportLayer, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TransportLayerGreen TransportLayer(RestTransportLayerGreen restTransportLayer)
	    {
	#if DEBUG
		    if (restTransportLayer == null) throw new ArgumentNullException(nameof(restTransportLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.TransportLayer, restTransportLayer, out hash);
			if (cached != null) return (TransportLayerGreen)cached;
			var result = new TransportLayerGreen(SoalSyntaxKind.TransportLayer, null, restTransportLayer, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TransportLayerGreen TransportLayer(WebSocketTransportLayerGreen webSocketTransportLayer)
	    {
	#if DEBUG
		    if (webSocketTransportLayer == null) throw new ArgumentNullException(nameof(webSocketTransportLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.TransportLayer, webSocketTransportLayer, out hash);
			if (cached != null) return (TransportLayerGreen)cached;
			var result = new TransportLayerGreen(SoalSyntaxKind.TransportLayer, null, null, webSocketTransportLayer);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerGreen HttpTransportLayer(InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody)
	    {
	#if DEBUG
			if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
			if (kTransport.Kind != SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
			if (ihttp == null) throw new ArgumentNullException(nameof(ihttp));
			if (ihttp.Kind != SoalSyntaxKind.IHTTP) throw new ArgumentException(nameof(ihttp));
			if (httpTransportLayerBody == null) throw new ArgumentNullException(nameof(httpTransportLayerBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayer, kTransport, ihttp, httpTransportLayerBody, out hash);
			if (cached != null) return (HttpTransportLayerGreen)cached;
			var result = new HttpTransportLayerGreen(SoalSyntaxKind.HttpTransportLayer, kTransport, ihttp, httpTransportLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerEmptyBodyGreen HttpTransportLayerEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (HttpTransportLayerEmptyBodyGreen)cached;
			var result = new HttpTransportLayerEmptyBodyGreen(SoalSyntaxKind.HttpTransportLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerNonEmptyBodyGreen HttpTransportLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<HttpTransportLayerPropertiesGreen> httpTransportLayerProperties, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerNonEmptyBody, tOpenBrace, httpTransportLayerProperties.Node, tCloseBrace, out hash);
			if (cached != null) return (HttpTransportLayerNonEmptyBodyGreen)cached;
			var result = new HttpTransportLayerNonEmptyBodyGreen(SoalSyntaxKind.HttpTransportLayerNonEmptyBody, tOpenBrace, httpTransportLayerProperties.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RestTransportLayerGreen RestTransportLayer(InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody)
	    {
	#if DEBUG
			if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
			if (kTransport.Kind != SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
			if (irest == null) throw new ArgumentNullException(nameof(irest));
			if (irest.Kind != SoalSyntaxKind.IREST) throw new ArgumentException(nameof(irest));
			if (restTransportLayerBody == null) throw new ArgumentNullException(nameof(restTransportLayerBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.RestTransportLayer, kTransport, irest, restTransportLayerBody, out hash);
			if (cached != null) return (RestTransportLayerGreen)cached;
			var result = new RestTransportLayerGreen(SoalSyntaxKind.RestTransportLayer, kTransport, irest, restTransportLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RestTransportLayerEmptyBodyGreen RestTransportLayerEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.RestTransportLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (RestTransportLayerEmptyBodyGreen)cached;
			var result = new RestTransportLayerEmptyBodyGreen(SoalSyntaxKind.RestTransportLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RestTransportLayerNonEmptyBodyGreen RestTransportLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.RestTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (RestTransportLayerNonEmptyBodyGreen)cached;
			var result = new RestTransportLayerNonEmptyBodyGreen(SoalSyntaxKind.RestTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WebSocketTransportLayerGreen WebSocketTransportLayer(InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody)
	    {
	#if DEBUG
			if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
			if (kTransport.Kind != SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
			if (iWebSocket == null) throw new ArgumentNullException(nameof(iWebSocket));
			if (iWebSocket.Kind != SoalSyntaxKind.IWebSocket) throw new ArgumentException(nameof(iWebSocket));
			if (webSocketTransportLayerBody == null) throw new ArgumentNullException(nameof(webSocketTransportLayerBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.WebSocketTransportLayer, kTransport, iWebSocket, webSocketTransportLayerBody, out hash);
			if (cached != null) return (WebSocketTransportLayerGreen)cached;
			var result = new WebSocketTransportLayerGreen(SoalSyntaxKind.WebSocketTransportLayer, kTransport, iWebSocket, webSocketTransportLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WebSocketTransportLayerEmptyBodyGreen WebSocketTransportLayerEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.WebSocketTransportLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (WebSocketTransportLayerEmptyBodyGreen)cached;
			var result = new WebSocketTransportLayerEmptyBodyGreen(SoalSyntaxKind.WebSocketTransportLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WebSocketTransportLayerNonEmptyBodyGreen WebSocketTransportLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.WebSocketTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (WebSocketTransportLayerNonEmptyBodyGreen)cached;
			var result = new WebSocketTransportLayerNonEmptyBodyGreen(SoalSyntaxKind.WebSocketTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerPropertiesGreen HttpTransportLayerProperties(HttpSslPropertyGreen httpSslProperty)
	    {
	#if DEBUG
		    if (httpSslProperty == null) throw new ArgumentNullException(nameof(httpSslProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerProperties, httpSslProperty, out hash);
			if (cached != null) return (HttpTransportLayerPropertiesGreen)cached;
			var result = new HttpTransportLayerPropertiesGreen(SoalSyntaxKind.HttpTransportLayerProperties, httpSslProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerPropertiesGreen HttpTransportLayerProperties(HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty)
	    {
	#if DEBUG
		    if (httpClientAuthenticationProperty == null) throw new ArgumentNullException(nameof(httpClientAuthenticationProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.HttpTransportLayerProperties, httpClientAuthenticationProperty, out hash);
			if (cached != null) return (HttpTransportLayerPropertiesGreen)cached;
			var result = new HttpTransportLayerPropertiesGreen(SoalSyntaxKind.HttpTransportLayerProperties, null, httpClientAuthenticationProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpSslPropertyGreen HttpSslProperty(InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (issl == null) throw new ArgumentNullException(nameof(issl));
			if (issl.Kind != SoalSyntaxKind.ISSL) throw new ArgumentException(nameof(issl));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new HttpSslPropertyGreen(SoalSyntaxKind.HttpSslProperty, issl, tAssign, booleanLiteral, tSemicolon);
	    }
	
		public HttpClientAuthenticationPropertyGreen HttpClientAuthenticationProperty(InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (iClientAuthentication == null) throw new ArgumentNullException(nameof(iClientAuthentication));
			if (iClientAuthentication.Kind != SoalSyntaxKind.IClientAuthentication) throw new ArgumentException(nameof(iClientAuthentication));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new HttpClientAuthenticationPropertyGreen(SoalSyntaxKind.HttpClientAuthenticationProperty, iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
	    }
	
		public EncodingLayerGreen EncodingLayer(SoapEncodingLayerGreen soapEncodingLayer)
	    {
	#if DEBUG
		    if (soapEncodingLayer == null) throw new ArgumentNullException(nameof(soapEncodingLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EncodingLayer, soapEncodingLayer, out hash);
			if (cached != null) return (EncodingLayerGreen)cached;
			var result = new EncodingLayerGreen(SoalSyntaxKind.EncodingLayer, soapEncodingLayer, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EncodingLayerGreen EncodingLayer(XmlEncodingLayerGreen xmlEncodingLayer)
	    {
	#if DEBUG
		    if (xmlEncodingLayer == null) throw new ArgumentNullException(nameof(xmlEncodingLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EncodingLayer, xmlEncodingLayer, out hash);
			if (cached != null) return (EncodingLayerGreen)cached;
			var result = new EncodingLayerGreen(SoalSyntaxKind.EncodingLayer, null, xmlEncodingLayer, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EncodingLayerGreen EncodingLayer(JsonEncodingLayerGreen jsonEncodingLayer)
	    {
	#if DEBUG
		    if (jsonEncodingLayer == null) throw new ArgumentNullException(nameof(jsonEncodingLayer));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EncodingLayer, jsonEncodingLayer, out hash);
			if (cached != null) return (EncodingLayerGreen)cached;
			var result = new EncodingLayerGreen(SoalSyntaxKind.EncodingLayer, null, null, jsonEncodingLayer);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingLayerGreen SoapEncodingLayer(InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody)
	    {
	#if DEBUG
			if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
			if (kEncoding.Kind != SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
			if (isoap == null) throw new ArgumentNullException(nameof(isoap));
			if (isoap.Kind != SoalSyntaxKind.ISOAP) throw new ArgumentException(nameof(isoap));
			if (soapEncodingLayerBody == null) throw new ArgumentNullException(nameof(soapEncodingLayerBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SoapEncodingLayer, kEncoding, isoap, soapEncodingLayerBody, out hash);
			if (cached != null) return (SoapEncodingLayerGreen)cached;
			var result = new SoapEncodingLayerGreen(SoalSyntaxKind.SoapEncodingLayer, kEncoding, isoap, soapEncodingLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingLayerEmptyBodyGreen SoapEncodingLayerEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SoapEncodingLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (SoapEncodingLayerEmptyBodyGreen)cached;
			var result = new SoapEncodingLayerEmptyBodyGreen(SoalSyntaxKind.SoapEncodingLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingLayerNonEmptyBodyGreen SoapEncodingLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<SoapEncodingPropertiesGreen> soapEncodingProperties, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SoapEncodingLayerNonEmptyBody, tOpenBrace, soapEncodingProperties.Node, tCloseBrace, out hash);
			if (cached != null) return (SoapEncodingLayerNonEmptyBodyGreen)cached;
			var result = new SoapEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind.SoapEncodingLayerNonEmptyBody, tOpenBrace, soapEncodingProperties.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XmlEncodingLayerGreen XmlEncodingLayer(InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody)
	    {
	#if DEBUG
			if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
			if (kEncoding.Kind != SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
			if (ixml == null) throw new ArgumentNullException(nameof(ixml));
			if (ixml.Kind != SoalSyntaxKind.IXML) throw new ArgumentException(nameof(ixml));
			if (xmlEncodingLayerBody == null) throw new ArgumentNullException(nameof(xmlEncodingLayerBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.XmlEncodingLayer, kEncoding, ixml, xmlEncodingLayerBody, out hash);
			if (cached != null) return (XmlEncodingLayerGreen)cached;
			var result = new XmlEncodingLayerGreen(SoalSyntaxKind.XmlEncodingLayer, kEncoding, ixml, xmlEncodingLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XmlEncodingLayerEmptyBodyGreen XmlEncodingLayerEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.XmlEncodingLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (XmlEncodingLayerEmptyBodyGreen)cached;
			var result = new XmlEncodingLayerEmptyBodyGreen(SoalSyntaxKind.XmlEncodingLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XmlEncodingLayerNonEmptyBodyGreen XmlEncodingLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.XmlEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (XmlEncodingLayerNonEmptyBodyGreen)cached;
			var result = new XmlEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind.XmlEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public JsonEncodingLayerGreen JsonEncodingLayer(InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody)
	    {
	#if DEBUG
			if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
			if (kEncoding.Kind != SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
			if (ijson == null) throw new ArgumentNullException(nameof(ijson));
			if (ijson.Kind != SoalSyntaxKind.IJSON) throw new ArgumentException(nameof(ijson));
			if (jsonEncodingLayerBody == null) throw new ArgumentNullException(nameof(jsonEncodingLayerBody));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.JsonEncodingLayer, kEncoding, ijson, jsonEncodingLayerBody, out hash);
			if (cached != null) return (JsonEncodingLayerGreen)cached;
			var result = new JsonEncodingLayerGreen(SoalSyntaxKind.JsonEncodingLayer, kEncoding, ijson, jsonEncodingLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public JsonEncodingLayerEmptyBodyGreen JsonEncodingLayerEmptyBody(InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.JsonEncodingLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (JsonEncodingLayerEmptyBodyGreen)cached;
			var result = new JsonEncodingLayerEmptyBodyGreen(SoalSyntaxKind.JsonEncodingLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public JsonEncodingLayerNonEmptyBodyGreen JsonEncodingLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.JsonEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (JsonEncodingLayerNonEmptyBodyGreen)cached;
			var result = new JsonEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind.JsonEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingPropertiesGreen SoapEncodingProperties(SoapVersionPropertyGreen soapVersionProperty)
	    {
	#if DEBUG
		    if (soapVersionProperty == null) throw new ArgumentNullException(nameof(soapVersionProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SoapEncodingProperties, soapVersionProperty, out hash);
			if (cached != null) return (SoapEncodingPropertiesGreen)cached;
			var result = new SoapEncodingPropertiesGreen(SoalSyntaxKind.SoapEncodingProperties, soapVersionProperty, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingPropertiesGreen SoapEncodingProperties(SoapMtomPropertyGreen soapMtomProperty)
	    {
	#if DEBUG
		    if (soapMtomProperty == null) throw new ArgumentNullException(nameof(soapMtomProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SoapEncodingProperties, soapMtomProperty, out hash);
			if (cached != null) return (SoapEncodingPropertiesGreen)cached;
			var result = new SoapEncodingPropertiesGreen(SoalSyntaxKind.SoapEncodingProperties, null, soapMtomProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingPropertiesGreen SoapEncodingProperties(SoapStylePropertyGreen soapStyleProperty)
	    {
	#if DEBUG
		    if (soapStyleProperty == null) throw new ArgumentNullException(nameof(soapStyleProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SoapEncodingProperties, soapStyleProperty, out hash);
			if (cached != null) return (SoapEncodingPropertiesGreen)cached;
			var result = new SoapEncodingPropertiesGreen(SoalSyntaxKind.SoapEncodingProperties, null, null, soapStyleProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapVersionPropertyGreen SoapVersionProperty(InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (iVersion == null) throw new ArgumentNullException(nameof(iVersion));
			if (iVersion.Kind != SoalSyntaxKind.IVersion) throw new ArgumentException(nameof(iVersion));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new SoapVersionPropertyGreen(SoalSyntaxKind.SoapVersionProperty, iVersion, tAssign, identifier, tSemicolon);
	    }
	
		public SoapMtomPropertyGreen SoapMtomProperty(InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (imtom == null) throw new ArgumentNullException(nameof(imtom));
			if (imtom.Kind != SoalSyntaxKind.IMTOM) throw new ArgumentException(nameof(imtom));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new SoapMtomPropertyGreen(SoalSyntaxKind.SoapMtomProperty, imtom, tAssign, booleanLiteral, tSemicolon);
	    }
	
		public SoapStylePropertyGreen SoapStyleProperty(InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (iStyle == null) throw new ArgumentNullException(nameof(iStyle));
			if (iStyle.Kind != SoalSyntaxKind.IStyle) throw new ArgumentException(nameof(iStyle));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new SoapStylePropertyGreen(SoalSyntaxKind.SoapStyleProperty, iStyle, tAssign, identifier, tSemicolon);
	    }
	
		public ProtocolLayerGreen ProtocolLayer(InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kProtocol == null) throw new ArgumentNullException(nameof(kProtocol));
			if (kProtocol.Kind != SoalSyntaxKind.KProtocol) throw new ArgumentException(nameof(kProtocol));
			if (protocolLayerKind == null) throw new ArgumentNullException(nameof(protocolLayerKind));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ProtocolLayer, kProtocol, protocolLayerKind, tSemicolon, out hash);
			if (cached != null) return (ProtocolLayerGreen)cached;
			var result = new ProtocolLayerGreen(SoalSyntaxKind.ProtocolLayer, kProtocol, protocolLayerKind, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ProtocolLayerKindGreen ProtocolLayerKind(WsAddressingGreen wsAddressing)
	    {
	#if DEBUG
			if (wsAddressing == null) throw new ArgumentNullException(nameof(wsAddressing));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ProtocolLayerKind, wsAddressing, out hash);
			if (cached != null) return (ProtocolLayerKindGreen)cached;
			var result = new ProtocolLayerKindGreen(SoalSyntaxKind.ProtocolLayerKind, wsAddressing);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WsAddressingGreen WsAddressing(InternalSyntaxToken iWsAddressing)
	    {
	#if DEBUG
			if (iWsAddressing == null) throw new ArgumentNullException(nameof(iWsAddressing));
			if (iWsAddressing.Kind != SoalSyntaxKind.IWsAddressing) throw new ArgumentException(nameof(iWsAddressing));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.WsAddressing, iWsAddressing, out hash);
			if (cached != null) return (WsAddressingGreen)cached;
			var result = new WsAddressingGreen(SoalSyntaxKind.WsAddressing, iWsAddressing);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointDeclarationGreen EndpointDeclaration(InternalSyntaxToken kEndpoint, NameGreen name, InternalSyntaxToken tColon, QualifierGreen qualifier, EndpointBodyGreen endpointBody)
	    {
	#if DEBUG
			if (kEndpoint == null) throw new ArgumentNullException(nameof(kEndpoint));
			if (kEndpoint.Kind != SoalSyntaxKind.KEndpoint) throw new ArgumentException(nameof(kEndpoint));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon == null) throw new ArgumentNullException(nameof(tColon));
			if (tColon.Kind != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (endpointBody == null) throw new ArgumentNullException(nameof(endpointBody));
	#endif
	        return new EndpointDeclarationGreen(SoalSyntaxKind.EndpointDeclaration, kEndpoint, name, tColon, qualifier, endpointBody);
	    }
	
		public EndpointBodyGreen EndpointBody(InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EndpointBody, tOpenBrace, endpointProperties, tCloseBrace, out hash);
			if (cached != null) return (EndpointBodyGreen)cached;
			var result = new EndpointBodyGreen(SoalSyntaxKind.EndpointBody, tOpenBrace, endpointProperties, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointPropertiesGreen EndpointProperties(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EndpointPropertyGreen> endpointProperty)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EndpointProperties, endpointProperty.Node, out hash);
			if (cached != null) return (EndpointPropertiesGreen)cached;
			var result = new EndpointPropertiesGreen(SoalSyntaxKind.EndpointProperties, endpointProperty.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointPropertyGreen EndpointProperty(EndpointBindingPropertyGreen endpointBindingProperty)
	    {
	#if DEBUG
		    if (endpointBindingProperty == null) throw new ArgumentNullException(nameof(endpointBindingProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EndpointProperty, endpointBindingProperty, out hash);
			if (cached != null) return (EndpointPropertyGreen)cached;
			var result = new EndpointPropertyGreen(SoalSyntaxKind.EndpointProperty, endpointBindingProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointPropertyGreen EndpointProperty(EndpointAddressPropertyGreen endpointAddressProperty)
	    {
	#if DEBUG
		    if (endpointAddressProperty == null) throw new ArgumentNullException(nameof(endpointAddressProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EndpointProperty, endpointAddressProperty, out hash);
			if (cached != null) return (EndpointPropertyGreen)cached;
			var result = new EndpointPropertyGreen(SoalSyntaxKind.EndpointProperty, null, endpointAddressProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointBindingPropertyGreen EndpointBindingProperty(InternalSyntaxToken kBinding, QualifierGreen qualifier, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
			if (kBinding.Kind != SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EndpointBindingProperty, kBinding, qualifier, tSemicolon, out hash);
			if (cached != null) return (EndpointBindingPropertyGreen)cached;
			var result = new EndpointBindingPropertyGreen(SoalSyntaxKind.EndpointBindingProperty, kBinding, qualifier, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointAddressPropertyGreen EndpointAddressProperty(InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kAddress == null) throw new ArgumentNullException(nameof(kAddress));
			if (kAddress.Kind != SoalSyntaxKind.KAddress) throw new ArgumentException(nameof(kAddress));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.EndpointAddressProperty, kAddress, stringLiteral, tSemicolon, out hash);
			if (cached != null) return (EndpointAddressPropertyGreen)cached;
			var result = new EndpointAddressPropertyGreen(SoalSyntaxKind.EndpointAddressProperty, kAddress, stringLiteral, tSemicolon);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(SoalSyntaxKind.ReturnType, voidType, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(SoalSyntaxKind.ReturnType, null, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(NonNullableArrayTypeGreen nonNullableArrayType)
	    {
	#if DEBUG
		    if (nonNullableArrayType == null) throw new ArgumentNullException(nameof(nonNullableArrayType));
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, nonNullableArrayType, null, null, null);
	    }
	
		public TypeReferenceGreen TypeReference(ArrayTypeGreen arrayType)
	    {
	#if DEBUG
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, null, arrayType, null, null);
	    }
	
		public TypeReferenceGreen TypeReference(SimpleTypeGreen simpleType)
	    {
	#if DEBUG
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, null, null, simpleType, null);
	    }
	
		public TypeReferenceGreen TypeReference(NulledTypeGreen nulledType)
	    {
	#if DEBUG
		    if (nulledType == null) throw new ArgumentNullException(nameof(nulledType));
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, null, null, null, nulledType);
	    }
	
		public SimpleTypeGreen SimpleType(ValueTypeGreen valueType)
	    {
	#if DEBUG
		    if (valueType == null) throw new ArgumentNullException(nameof(valueType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SimpleType, valueType, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(SoalSyntaxKind.SimpleType, valueType, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(ObjectTypeGreen objectType)
	    {
	#if DEBUG
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SimpleType, objectType, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(SoalSyntaxKind.SimpleType, null, objectType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(QualifierGreen qualifier)
	    {
	#if DEBUG
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SimpleType, qualifier, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(SoalSyntaxKind.SimpleType, null, null, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NulledTypeGreen NulledType(NullableTypeGreen nullableType)
	    {
	#if DEBUG
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NulledType, nullableType, out hash);
			if (cached != null) return (NulledTypeGreen)cached;
			var result = new NulledTypeGreen(SoalSyntaxKind.NulledType, nullableType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NulledTypeGreen NulledType(NonNullableTypeGreen nonNullableType)
	    {
	#if DEBUG
		    if (nonNullableType == null) throw new ArgumentNullException(nameof(nonNullableType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NulledType, nonNullableType, out hash);
			if (cached != null) return (NulledTypeGreen)cached;
			var result = new NulledTypeGreen(SoalSyntaxKind.NulledType, null, nonNullableType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReferenceTypeGreen ReferenceType(ObjectTypeGreen objectType)
	    {
	#if DEBUG
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ReferenceType, objectType, out hash);
			if (cached != null) return (ReferenceTypeGreen)cached;
			var result = new ReferenceTypeGreen(SoalSyntaxKind.ReferenceType, objectType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReferenceTypeGreen ReferenceType(QualifierGreen qualifier)
	    {
	#if DEBUG
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ReferenceType, qualifier, out hash);
			if (cached != null) return (ReferenceTypeGreen)cached;
			var result = new ReferenceTypeGreen(SoalSyntaxKind.ReferenceType, null, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ObjectType, objectType, out hash);
			if (cached != null) return (ObjectTypeGreen)cached;
			var result = new ObjectTypeGreen(SoalSyntaxKind.ObjectType, objectType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ValueTypeGreen ValueType(InternalSyntaxToken valueType)
	    {
	#if DEBUG
			if (valueType == null) throw new ArgumentNullException(nameof(valueType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ValueType, valueType, out hash);
			if (cached != null) return (ValueTypeGreen)cached;
			var result = new ValueTypeGreen(SoalSyntaxKind.ValueType, valueType);
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
			if (kVoid.Kind != SoalSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(SoalSyntaxKind.VoidType, kVoid);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OnewayTypeGreen OnewayType(InternalSyntaxToken kOneway)
	    {
	#if DEBUG
			if (kOneway == null) throw new ArgumentNullException(nameof(kOneway));
			if (kOneway.Kind != SoalSyntaxKind.KOneway) throw new ArgumentException(nameof(kOneway));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.OnewayType, kOneway, out hash);
			if (cached != null) return (OnewayTypeGreen)cached;
			var result = new OnewayTypeGreen(SoalSyntaxKind.OnewayType, kOneway);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationReturnTypeGreen OperationReturnType(OnewayTypeGreen onewayType)
	    {
	#if DEBUG
		    if (onewayType == null) throw new ArgumentNullException(nameof(onewayType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.OperationReturnType, onewayType, out hash);
			if (cached != null) return (OperationReturnTypeGreen)cached;
			var result = new OperationReturnTypeGreen(SoalSyntaxKind.OperationReturnType, onewayType, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationReturnTypeGreen OperationReturnType(VoidTypeGreen voidType)
	    {
	#if DEBUG
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.OperationReturnType, voidType, out hash);
			if (cached != null) return (OperationReturnTypeGreen)cached;
			var result = new OperationReturnTypeGreen(SoalSyntaxKind.OperationReturnType, null, voidType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationReturnTypeGreen OperationReturnType(TypeReferenceGreen typeReference)
	    {
	#if DEBUG
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.OperationReturnType, typeReference, out hash);
			if (cached != null) return (OperationReturnTypeGreen)cached;
			var result = new OperationReturnTypeGreen(SoalSyntaxKind.OperationReturnType, null, null, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableTypeGreen NullableType(ValueTypeGreen valueType, InternalSyntaxToken tQuestion)
	    {
	#if DEBUG
			if (valueType == null) throw new ArgumentNullException(nameof(valueType));
			if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
			if (tQuestion.Kind != SoalSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NullableType, valueType, tQuestion, out hash);
			if (cached != null) return (NullableTypeGreen)cached;
			var result = new NullableTypeGreen(SoalSyntaxKind.NullableType, valueType, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NonNullableTypeGreen NonNullableType(ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation)
	    {
	#if DEBUG
			if (referenceType == null) throw new ArgumentNullException(nameof(referenceType));
			if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
			if (tExclamation.Kind != SoalSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NonNullableType, referenceType, tExclamation, out hash);
			if (cached != null) return (NonNullableTypeGreen)cached;
			var result = new NonNullableTypeGreen(SoalSyntaxKind.NonNullableType, referenceType, tExclamation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NonNullableArrayTypeGreen NonNullableArrayType(ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation)
	    {
	#if DEBUG
			if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
			if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
			if (tExclamation.Kind != SoalSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NonNullableArrayType, arrayType, tExclamation, out hash);
			if (cached != null) return (NonNullableArrayTypeGreen)cached;
			var result = new NonNullableArrayTypeGreen(SoalSyntaxKind.NonNullableArrayType, arrayType, tExclamation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayTypeGreen ArrayType(SimpleArrayTypeGreen simpleArrayType)
	    {
	#if DEBUG
		    if (simpleArrayType == null) throw new ArgumentNullException(nameof(simpleArrayType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ArrayType, simpleArrayType, out hash);
			if (cached != null) return (ArrayTypeGreen)cached;
			var result = new ArrayTypeGreen(SoalSyntaxKind.ArrayType, simpleArrayType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayTypeGreen ArrayType(NulledArrayTypeGreen nulledArrayType)
	    {
	#if DEBUG
		    if (nulledArrayType == null) throw new ArgumentNullException(nameof(nulledArrayType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ArrayType, nulledArrayType, out hash);
			if (cached != null) return (ArrayTypeGreen)cached;
			var result = new ArrayTypeGreen(SoalSyntaxKind.ArrayType, null, nulledArrayType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleArrayTypeGreen SimpleArrayType(SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.SimpleArrayType, simpleType, tOpenBracket, tCloseBracket, out hash);
			if (cached != null) return (SimpleArrayTypeGreen)cached;
			var result = new SimpleArrayTypeGreen(SoalSyntaxKind.SimpleArrayType, simpleType, tOpenBracket, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NulledArrayTypeGreen NulledArrayType(NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	#if DEBUG
			if (nulledType == null) throw new ArgumentNullException(nameof(nulledType));
			if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
			if (tOpenBracket.Kind != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NulledArrayType, nulledType, tOpenBracket, tCloseBracket, out hash);
			if (cached != null) return (NulledArrayTypeGreen)cached;
			var result = new NulledArrayTypeGreen(SoalSyntaxKind.NulledArrayType, nulledType, tOpenBracket, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConstantValueGreen ConstantValue(LiteralGreen literal)
	    {
	#if DEBUG
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ConstantValue, literal, out hash);
			if (cached != null) return (ConstantValueGreen)cached;
			var result = new ConstantValueGreen(SoalSyntaxKind.ConstantValue, literal, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConstantValueGreen ConstantValue(IdentifierGreen identifier)
	    {
	#if DEBUG
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ConstantValue, identifier, out hash);
			if (cached != null) return (ConstantValueGreen)cached;
			var result = new ConstantValueGreen(SoalSyntaxKind.ConstantValue, null, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeofValueGreen TypeofValue(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen)
	    {
	#if DEBUG
			if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
			if (kTypeof.Kind != SoalSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (returnType == null) throw new ArgumentNullException(nameof(returnType));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
	#endif
	        return new TypeofValueGreen(SoalSyntaxKind.TypeofValue, kTypeof, tOpenParen, returnType, tCloseParen);
	    }
	
		public IdentifierGreen Identifier(IdentifiersGreen identifiers)
	    {
	#if DEBUG
		    if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Identifier, identifiers, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(SoalSyntaxKind.Identifier, identifiers, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(ContextualKeywordsGreen contextualKeywords)
	    {
	#if DEBUG
		    if (contextualKeywords == null) throw new ArgumentNullException(nameof(contextualKeywords));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Identifier, contextualKeywords, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(SoalSyntaxKind.Identifier, null, contextualKeywords);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifiersGreen Identifiers(InternalSyntaxToken identifiers)
	    {
	#if DEBUG
			if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.Identifiers, identifiers, out hash);
			if (cached != null) return (IdentifiersGreen)cached;
			var result = new IdentifiersGreen(SoalSyntaxKind.Identifiers, identifiers);
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
			return new LiteralGreen(SoalSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != SoalSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(SoalSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(SoalSyntaxKind.BooleanLiteral, booleanLiteral);
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
			if (lInteger.Kind != SoalSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(SoalSyntaxKind.IntegerLiteral, lInteger);
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
			if (lDecimal.Kind != SoalSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(SoalSyntaxKind.DecimalLiteral, lDecimal);
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
			if (lScientific.Kind != SoalSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(SoalSyntaxKind.ScientificLiteral, lScientific);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.StringLiteral, stringLiteral, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(SoalSyntaxKind.StringLiteral, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ContextualKeywordsGreen ContextualKeywords(InternalSyntaxToken contextualKeywords)
	    {
	#if DEBUG
			if (contextualKeywords == null) throw new ArgumentNullException(nameof(contextualKeywords));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(SoalSyntaxKind)SoalSyntaxKind.ContextualKeywords, contextualKeywords, out hash);
			if (cached != null) return (ContextualKeywordsGreen)cached;
			var result = new ContextualKeywordsGreen(SoalSyntaxKind.ContextualKeywords, contextualKeywords);
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
				typeof(IdentifierListGreen),
				typeof(QualifierListGreen),
				typeof(AnnotationListGreen),
				typeof(ReturnAnnotationListGreen),
				typeof(AnnotationGreen),
				typeof(ReturnAnnotationGreen),
				typeof(AnnotationHeadGreen),
				typeof(AnnotationBodyGreen),
				typeof(AnnotationPropertyListGreen),
				typeof(AnnotationPropertyGreen),
				typeof(AnnotationPropertyValueGreen),
				typeof(NamespaceDeclarationGreen),
				typeof(NamespacePrefixGreen),
				typeof(NamespaceUriGreen),
				typeof(NamespaceBodyGreen),
				typeof(DeclarationGreen),
				typeof(EnumDeclarationGreen),
				typeof(EnumBaseGreen),
				typeof(EnumBodyGreen),
				typeof(EnumLiteralsGreen),
				typeof(EnumLiteralGreen),
				typeof(StructDeclarationGreen),
				typeof(StructBodyGreen),
				typeof(PropertyDeclarationGreen),
				typeof(DatabaseDeclarationGreen),
				typeof(DatabaseBodyGreen),
				typeof(EntityReferenceGreen),
				typeof(InterfaceDeclarationGreen),
				typeof(InterfaceBodyGreen),
				typeof(OperationDeclarationGreen),
				typeof(OperationHeadGreen),
				typeof(ParameterListGreen),
				typeof(ParameterGreen),
				typeof(OperationResultGreen),
				typeof(ThrowsListGreen),
				typeof(ComponentDeclarationGreen),
				typeof(ComponentBaseGreen),
				typeof(ComponentBodyGreen),
				typeof(ComponentElementsGreen),
				typeof(ComponentElementGreen),
				typeof(ComponentServiceGreen),
				typeof(ComponentReferenceGreen),
				typeof(ComponentServiceOrReferenceEmptyBodyGreen),
				typeof(ComponentServiceOrReferenceNonEmptyBodyGreen),
				typeof(ComponentServiceOrReferenceElementGreen),
				typeof(ComponentPropertyGreen),
				typeof(ComponentImplementationGreen),
				typeof(ComponentLanguageGreen),
				typeof(CompositeDeclarationGreen),
				typeof(CompositeBodyGreen),
				typeof(AssemblyDeclarationGreen),
				typeof(CompositeElementsGreen),
				typeof(CompositeElementGreen),
				typeof(CompositeComponentGreen),
				typeof(CompositeWireGreen),
				typeof(WireSourceGreen),
				typeof(WireTargetGreen),
				typeof(DeploymentDeclarationGreen),
				typeof(DeploymentBodyGreen),
				typeof(DeploymentElementsGreen),
				typeof(DeploymentElementGreen),
				typeof(EnvironmentDeclarationGreen),
				typeof(EnvironmentBodyGreen),
				typeof(RuntimeDeclarationGreen),
				typeof(RuntimeReferenceGreen),
				typeof(AssemblyReferenceGreen),
				typeof(DatabaseReferenceGreen),
				typeof(BindingDeclarationGreen),
				typeof(BindingBodyGreen),
				typeof(BindingLayersGreen),
				typeof(TransportLayerGreen),
				typeof(HttpTransportLayerGreen),
				typeof(HttpTransportLayerEmptyBodyGreen),
				typeof(HttpTransportLayerNonEmptyBodyGreen),
				typeof(RestTransportLayerGreen),
				typeof(RestTransportLayerEmptyBodyGreen),
				typeof(RestTransportLayerNonEmptyBodyGreen),
				typeof(WebSocketTransportLayerGreen),
				typeof(WebSocketTransportLayerEmptyBodyGreen),
				typeof(WebSocketTransportLayerNonEmptyBodyGreen),
				typeof(HttpTransportLayerPropertiesGreen),
				typeof(HttpSslPropertyGreen),
				typeof(HttpClientAuthenticationPropertyGreen),
				typeof(EncodingLayerGreen),
				typeof(SoapEncodingLayerGreen),
				typeof(SoapEncodingLayerEmptyBodyGreen),
				typeof(SoapEncodingLayerNonEmptyBodyGreen),
				typeof(XmlEncodingLayerGreen),
				typeof(XmlEncodingLayerEmptyBodyGreen),
				typeof(XmlEncodingLayerNonEmptyBodyGreen),
				typeof(JsonEncodingLayerGreen),
				typeof(JsonEncodingLayerEmptyBodyGreen),
				typeof(JsonEncodingLayerNonEmptyBodyGreen),
				typeof(SoapEncodingPropertiesGreen),
				typeof(SoapVersionPropertyGreen),
				typeof(SoapMtomPropertyGreen),
				typeof(SoapStylePropertyGreen),
				typeof(ProtocolLayerGreen),
				typeof(ProtocolLayerKindGreen),
				typeof(WsAddressingGreen),
				typeof(EndpointDeclarationGreen),
				typeof(EndpointBodyGreen),
				typeof(EndpointPropertiesGreen),
				typeof(EndpointPropertyGreen),
				typeof(EndpointBindingPropertyGreen),
				typeof(EndpointAddressPropertyGreen),
				typeof(ReturnTypeGreen),
				typeof(TypeReferenceGreen),
				typeof(SimpleTypeGreen),
				typeof(NulledTypeGreen),
				typeof(ReferenceTypeGreen),
				typeof(ObjectTypeGreen),
				typeof(ValueTypeGreen),
				typeof(VoidTypeGreen),
				typeof(OnewayTypeGreen),
				typeof(OperationReturnTypeGreen),
				typeof(NullableTypeGreen),
				typeof(NonNullableTypeGreen),
				typeof(NonNullableArrayTypeGreen),
				typeof(ArrayTypeGreen),
				typeof(SimpleArrayTypeGreen),
				typeof(NulledArrayTypeGreen),
				typeof(ConstantValueGreen),
				typeof(TypeofValueGreen),
				typeof(IdentifierGreen),
				typeof(IdentifiersGreen),
				typeof(LiteralGreen),
				typeof(NullLiteralGreen),
				typeof(BooleanLiteralGreen),
				typeof(IntegerLiteralGreen),
				typeof(DecimalLiteralGreen),
				typeof(ScientificLiteralGreen),
				typeof(StringLiteralGreen),
				typeof(ContextualKeywordsGreen),
			};
		}
	}
}


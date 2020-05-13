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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax
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
            if (visitor is TestIncrementalCompilationSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public override void Accept(InternalSyntaxVisitor visitor) 
        {
            if (visitor is TestIncrementalCompilationSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor);
        public abstract void Accept(TestIncrementalCompilationSyntaxVisitor visitor);

        public new TestIncrementalCompilationLanguage Language => TestIncrementalCompilationLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestIncrementalCompilationSyntaxKind Kind => (TestIncrementalCompilationSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;
	}

    internal class GreenSyntaxTrivia : InternalSyntaxTrivia
    {
        internal GreenSyntaxTrivia(TestIncrementalCompilationSyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
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

        public new TestIncrementalCompilationLanguage Language => TestIncrementalCompilationLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestIncrementalCompilationSyntaxKind Kind => EnumObject.FromIntUnsafe<TestIncrementalCompilationSyntaxKind>(this.RawKind);
        protected override SyntaxKind KindCore => this.Kind;

        protected override bool ShouldReuseInSerialization => this.Kind == Language.SyntaxFacts.DefaultWhitespaceKind &&
                                                             FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteString(this.Text);
        }

        internal static GreenSyntaxTrivia Create(TestIncrementalCompilationSyntaxKind kind, string text)
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

    internal class GreenStructuredSyntaxTrivia : GreenSyntaxTrivia
    {
        private readonly GreenNode _structure;
        internal GreenStructuredSyntaxTrivia(TestIncrementalCompilationSyntaxKind kind, GreenNode structure, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
            : base(kind, structure?.ToFullString(), diagnostics, annotations)
        {
            this.Initialize();
            _structure = structure;
        }

        internal GreenStructuredSyntaxTrivia(ObjectReader reader)
            : base(reader)
        {
            this.Initialize();
        }

        static GreenStructuredSyntaxTrivia()
        {
            ObjectBinder.RegisterTypeReader(typeof(GreenStructuredSyntaxTrivia), r => new GreenStructuredSyntaxTrivia(r));
        }

        private void Initialize()
        {
            this.flags |= NodeFlags.ContainsStructuredTrivia;

            if (this.Kind == SyntaxKind.SkippedTokensTrivia)
            {
                this.flags |= NodeFlags.ContainsSkippedText;
            }
        }

        public GreenNode Structure => _structure;

        internal static GreenStructuredSyntaxTrivia Create(TestIncrementalCompilationSyntaxKind kind, GreenNode structure)
        {
            return new GreenStructuredSyntaxTrivia(kind, structure);
        }

        public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new GreenStructuredSyntaxTrivia(this.Kind, this.Structure, diagnostics, GetAnnotations());
        }

        public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new GreenStructuredSyntaxTrivia(this.Kind, this.Structure, GetDiagnostics(), annotations);
        }
    }

	internal partial class GreenSyntaxToken : InternalSyntaxToken
	{
	    //====================
	    // Optimization: Normally, we wouldn't accept this much duplicate code, but these constructors
	    // are called A LOT and we want to keep them as short and simple as possible and increase the
	    // likelihood that they will be inlined.
	    internal GreenSyntaxToken(TestIncrementalCompilationSyntaxKind kind)
	        : base(kind)
	    {
	    }
	    internal GreenSyntaxToken(TestIncrementalCompilationSyntaxKind kind, DiagnosticInfo[] diagnostics)
	        : base(kind, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(TestIncrementalCompilationSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	    internal GreenSyntaxToken(TestIncrementalCompilationSyntaxKind kind, int fullWidth)
	        : base(kind, fullWidth)
	    {
	    }
	    internal GreenSyntaxToken(TestIncrementalCompilationSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics)
	        : base(kind, fullWidth, diagnostics)
	    {
	    }
	    internal GreenSyntaxToken(TestIncrementalCompilationSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	    public new TestIncrementalCompilationLanguage Language => TestIncrementalCompilationLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public new TestIncrementalCompilationSyntaxKind Kind => EnumObject.FromIntUnsafe<TestIncrementalCompilationSyntaxKind>(this.RawKind);
	    protected override SyntaxKind KindCore => this.Kind;
	    protected override bool ShouldReuseInSerialization => base.ShouldReuseInSerialization &&
	                                                            FullWidth < Language.SyntaxFacts.MaxCachedTokenSize;
	    //====================
	    internal static GreenSyntaxToken Create(TestIncrementalCompilationSyntaxKind kind)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!TestIncrementalCompilationLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid TestIncrementalCompilationSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, null, null);
	        }
	        return s_tokensWithNoTrivia[(int)kind].Value;
	    }
	    internal static GreenSyntaxToken Create(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind > LastTokenWithWellKnownText)
	        {
	            if (!TestIncrementalCompilationLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid TestIncrementalCompilationSyntaxKind: {0}. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	            return CreateMissing(kind, leading, trailing);
	        }
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind].Value;
	            }
	            else if (trailing == TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind].Value;
	            }
	            else if (trailing == TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind].Value;
	            }
	        }
	        if (leading == TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind].Value;
	        }
	        return new SyntaxTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static GreenSyntaxToken CreateMissing(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing);
	    }
	    internal static readonly TestIncrementalCompilationSyntaxKind FirstTokenWithWellKnownText;
	    internal static readonly TestIncrementalCompilationSyntaxKind LastTokenWithWellKnownText;
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithNoTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithElasticTrivia;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingSpace;
	    private static readonly ArrayElement<GreenSyntaxToken>[] s_tokensWithSingleTrailingCRLF;
	    static GreenSyntaxToken()
	    {
	        ObjectBinder.RegisterTypeReader(typeof(GreenSyntaxToken), r => new GreenSyntaxToken(r));
	        FirstTokenWithWellKnownText = TestIncrementalCompilationSyntaxKind.__FirstFixedToken;
	        LastTokenWithWellKnownText = TestIncrementalCompilationSyntaxKind.__LastFixedToken;
	        s_tokensWithNoTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithElasticTrivia = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingSpace = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
	        s_tokensWithSingleTrailingCRLF = new ArrayElement<GreenSyntaxToken>[(int)LastTokenWithWellKnownText + 1];
			InternalSyntaxFactory factory = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory;
	        for (EnumObject kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind].Value = new GreenSyntaxToken((TestIncrementalCompilationSyntaxKind)kind);
	            s_tokensWithElasticTrivia[(int)kind].Value = new SyntaxTokenWithTrivia((TestIncrementalCompilationSyntaxKind)kind, factory.ElasticZeroSpace, factory.ElasticZeroSpace);
	            s_tokensWithSingleTrailingSpace[(int)kind].Value = new SyntaxTokenWithTrivia((TestIncrementalCompilationSyntaxKind)kind, null, factory.Space);
	            s_tokensWithSingleTrailingCRLF[(int)kind].Value = new SyntaxTokenWithTrivia((TestIncrementalCompilationSyntaxKind)kind, null, factory.CarriageReturnLineFeed);
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
	    internal static GreenSyntaxToken Identifier(TestIncrementalCompilationSyntaxKind kind, string text)
	    {
	        return new SyntaxIdentifier(kind, text);
	    }
	    internal static GreenSyntaxToken Identifier(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	    internal static GreenSyntaxToken Identifier(TestIncrementalCompilationSyntaxKind kind, TestIncrementalCompilationSyntaxKind contextualKind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (contextualKind == kind && valueText == text)
	        {
	            return Identifier(kind, leading, text, trailing);
	        }
	        return new SyntaxIdentifierWithTrivia(kind, contextualKind, text, valueText, leading, trailing);
	    }
	    internal static GreenSyntaxToken WithValue<T>(TestIncrementalCompilationSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value);
	    }
	    internal static GreenSyntaxToken WithValue<T>(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing);
	    }
	    public new virtual TestIncrementalCompilationSyntaxKind ContextualKind => this.Kind;
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
	        internal MissingTokenWithTrivia(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, GreenNode trailing)
	            : base(kind, leading, trailing)
	        {
	            this.flags &= ~NodeFlags.IsNotMissing;
	        }
	        internal MissingTokenWithTrivia(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxIdentifier(TestIncrementalCompilationSyntaxKind kind, string text)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	        }
	        internal SyntaxIdentifier(TestIncrementalCompilationSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        protected readonly TestIncrementalCompilationSyntaxKind contextualKind;
	        protected readonly string valueText;
	        internal SyntaxIdentifierExtended(TestIncrementalCompilationSyntaxKind kind, TestIncrementalCompilationSyntaxKind contextualKind, string text, string valueText)
	            : base(kind, text)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(TestIncrementalCompilationSyntaxKind kind, TestIncrementalCompilationSyntaxKind contextualKind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.contextualKind = contextualKind;
	            this.valueText = valueText;
	        }
	        internal SyntaxIdentifierExtended(ObjectReader reader)
	            : base(reader)
	        {
	            this.contextualKind = EnumObject.FromIntUnsafe<TestIncrementalCompilationSyntaxKind>(reader.ReadInt32());
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
	        public override TestIncrementalCompilationSyntaxKind ContextualKind
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
	        internal SyntaxIdentifierWithTrailingTrivia(TestIncrementalCompilationSyntaxKind kind, string text, GreenNode trailing)
	            : base(kind, text)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	        internal SyntaxIdentifierWithTrailingTrivia(TestIncrementalCompilationSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            TestIncrementalCompilationSyntaxKind kind,
	            TestIncrementalCompilationSyntaxKind contextualKind,
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
	            TestIncrementalCompilationSyntaxKind kind,
	            TestIncrementalCompilationSyntaxKind contextualKind,
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
	        internal SyntaxTokenWithValue(TestIncrementalCompilationSyntaxKind kind, string text, T value)
	            : base(kind, text.Length)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	        internal SyntaxTokenWithValue(TestIncrementalCompilationSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal SyntaxTokenWithValueAndTrivia(TestIncrementalCompilationSyntaxKind kind, string text, T value, GreenNode leading, GreenNode trailing)
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
	            TestIncrementalCompilationSyntaxKind kind,
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
	        internal SyntaxTokenWithTrivia(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, GreenNode trailing)
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
	        internal SyntaxTokenWithTrivia(TestIncrementalCompilationSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	    public MainGreen(TestIncrementalCompilationSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
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
	
	    public MainGreen(TestIncrementalCompilationSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Main, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public NamespaceDeclarationGreen NamespaceDeclaration { get { return this.namespaceDeclaration; } }
	    public InternalSyntaxToken EndOfFileToken { get { return this.eOF; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.MainSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitMainGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitMainGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, eOF);
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
	
	    public NameGreen(TestIncrementalCompilationSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(TestIncrementalCompilationSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Name, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.NameSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitNameGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitNameGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	    public QualifiedNameGreen(TestIncrementalCompilationSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(TestIncrementalCompilationSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.QualifiedName, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.QualifiedNameSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitQualifiedNameGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitQualifiedNameGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	    public QualifierGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Qualifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen> Identifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<IdentifierGreen>(this.identifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.QualifierSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitQualifierGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitQualifierGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	    public AttributeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBracket, QualifierGreen qualifier, InternalSyntaxToken tCloseBracket)
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
	
	    public AttributeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBracket, QualifierGreen qualifier, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Attribute, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.AttributeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitAttributeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitAttributeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Attribute(tOpenBracket, qualifier, tCloseBracket);
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
	
	    public NamespaceDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
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
	
	    public NamespaceDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NamespaceDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.NamespaceDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitNamespaceDeclarationGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
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
	    private MetamodelDeclarationGreen metamodelDeclaration;
	    private GreenNode declaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBodyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, GreenNode declaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (metamodelDeclaration != null)
			{
				this.AdjustFlagsAndWidth(metamodelDeclaration);
				this.metamodelDeclaration = metamodelDeclaration;
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
	
	    public NamespaceBodyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, GreenNode declaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (metamodelDeclaration != null)
			{
				this.AdjustFlagsAndWidth(metamodelDeclaration);
				this.metamodelDeclaration = metamodelDeclaration;
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NamespaceBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public MetamodelDeclarationGreen MetamodelDeclaration { get { return this.metamodelDeclaration; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> Declaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen>(this.declaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.NamespaceBodySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.metamodelDeclaration;
	            case 2: return this.declaration;
	            case 3: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitNamespaceBodyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.metamodelDeclaration, this.declaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.metamodelDeclaration, this.declaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBodyGreen Update(InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.MetamodelDeclaration != metamodelDeclaration ||
				this.Declaration != declaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
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
	
	internal class MetamodelDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly MetamodelDeclarationGreen __Missing = new MetamodelDeclarationGreen();
	    private GreenNode attribute;
	    private InternalSyntaxToken kMetamodel;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private MetamodelPropertyListGreen metamodelPropertyList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tSemicolon;
	
	    public MetamodelDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 7;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kMetamodel != null)
			{
				this.AdjustFlagsAndWidth(kMetamodel);
				this.kMetamodel = kMetamodel;
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
			if (metamodelPropertyList != null)
			{
				this.AdjustFlagsAndWidth(metamodelPropertyList);
				this.metamodelPropertyList = metamodelPropertyList;
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
	
	    public MetamodelDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 7;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kMetamodel != null)
			{
				this.AdjustFlagsAndWidth(kMetamodel);
				this.kMetamodel = kMetamodel;
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
			if (metamodelPropertyList != null)
			{
				this.AdjustFlagsAndWidth(metamodelPropertyList);
				this.metamodelPropertyList = metamodelPropertyList;
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
	
		private MetamodelDeclarationGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KMetamodel { get { return this.kMetamodel; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public MetamodelPropertyListGreen MetamodelPropertyList { get { return this.metamodelPropertyList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.MetamodelDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.kMetamodel;
	            case 2: return this.name;
	            case 3: return this.tOpenParen;
	            case 4: return this.metamodelPropertyList;
	            case 5: return this.tCloseParen;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitMetamodelDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitMetamodelDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelDeclarationGreen(this.Kind, this.attribute, this.kMetamodel, this.name, this.tOpenParen, this.metamodelPropertyList, this.tCloseParen, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelDeclarationGreen(this.Kind, this.attribute, this.kMetamodel, this.name, this.tOpenParen, this.metamodelPropertyList, this.tCloseParen, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KMetamodel != kMetamodel ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.MetamodelPropertyList != metamodelPropertyList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.MetamodelDeclaration(attribute, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MetamodelPropertyListGreen : GreenSyntaxNode
	{
	    internal static readonly MetamodelPropertyListGreen __Missing = new MetamodelPropertyListGreen();
	    private GreenNode metamodelProperty;
	
	    public MetamodelPropertyListGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode metamodelProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (metamodelProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelProperty);
				this.metamodelProperty = metamodelProperty;
			}
	    }
	
	    public MetamodelPropertyListGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode metamodelProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (metamodelProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelProperty);
				this.metamodelProperty = metamodelProperty;
			}
	    }
	
		private MetamodelPropertyListGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelPropertyList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<MetamodelPropertyGreen> MetamodelProperty { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<MetamodelPropertyGreen>(this.metamodelProperty); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.MetamodelPropertyListSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.metamodelProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitMetamodelPropertyListGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitMetamodelPropertyListGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelPropertyListGreen(this.Kind, this.metamodelProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelPropertyListGreen(this.Kind, this.metamodelProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelPropertyListGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<MetamodelPropertyGreen> metamodelProperty)
	    {
	        if (this.MetamodelProperty != metamodelProperty)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.MetamodelPropertyList(metamodelProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertyListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MetamodelPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly MetamodelPropertyGreen __Missing = new MetamodelPropertyGreen();
	    private MetamodelUriPropertyGreen metamodelUriProperty;
	    private MetamodelPrefixPropertyGreen metamodelPrefixProperty;
	
	    public MetamodelPropertyGreen(TestIncrementalCompilationSyntaxKind kind, MetamodelUriPropertyGreen metamodelUriProperty, MetamodelPrefixPropertyGreen metamodelPrefixProperty)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (metamodelUriProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelUriProperty);
				this.metamodelUriProperty = metamodelUriProperty;
			}
			if (metamodelPrefixProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelPrefixProperty);
				this.metamodelPrefixProperty = metamodelPrefixProperty;
			}
	    }
	
	    public MetamodelPropertyGreen(TestIncrementalCompilationSyntaxKind kind, MetamodelUriPropertyGreen metamodelUriProperty, MetamodelPrefixPropertyGreen metamodelPrefixProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (metamodelUriProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelUriProperty);
				this.metamodelUriProperty = metamodelUriProperty;
			}
			if (metamodelPrefixProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelPrefixProperty);
				this.metamodelPrefixProperty = metamodelPrefixProperty;
			}
	    }
	
		private MetamodelPropertyGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public MetamodelUriPropertyGreen MetamodelUriProperty { get { return this.metamodelUriProperty; } }
	    public MetamodelPrefixPropertyGreen MetamodelPrefixProperty { get { return this.metamodelPrefixProperty; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.MetamodelPropertySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.metamodelUriProperty;
	            case 1: return this.metamodelPrefixProperty;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitMetamodelPropertyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitMetamodelPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelPropertyGreen(this.Kind, this.metamodelUriProperty, this.metamodelPrefixProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelPropertyGreen(this.Kind, this.metamodelUriProperty, this.metamodelPrefixProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelPropertyGreen Update(MetamodelUriPropertyGreen metamodelUriProperty)
	    {
	        if (this.metamodelUriProperty != metamodelUriProperty)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.MetamodelProperty(metamodelUriProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertyGreen)newNode;
	        }
	        return this;
	    }
	
	    public MetamodelPropertyGreen Update(MetamodelPrefixPropertyGreen metamodelPrefixProperty)
	    {
	        if (this.metamodelPrefixProperty != metamodelPrefixProperty)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.MetamodelProperty(metamodelPrefixProperty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MetamodelUriPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly MetamodelUriPropertyGreen __Missing = new MetamodelUriPropertyGreen();
	    private InternalSyntaxToken iUri;
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public MetamodelUriPropertyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (iUri != null)
			{
				this.AdjustFlagsAndWidth(iUri);
				this.iUri = iUri;
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
	
	    public MetamodelUriPropertyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (iUri != null)
			{
				this.AdjustFlagsAndWidth(iUri);
				this.iUri = iUri;
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
	
		private MetamodelUriPropertyGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelUriProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IUri { get { return this.iUri; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.MetamodelUriPropertySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iUri;
	            case 1: return this.tAssign;
	            case 2: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitMetamodelUriPropertyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitMetamodelUriPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelUriPropertyGreen(this.Kind, this.iUri, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelUriPropertyGreen(this.Kind, this.iUri, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelUriPropertyGreen Update(InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.IUri != iUri ||
				this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelUriPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MetamodelPrefixPropertyGreen : GreenSyntaxNode
	{
	    internal static readonly MetamodelPrefixPropertyGreen __Missing = new MetamodelPrefixPropertyGreen();
	    private InternalSyntaxToken iPrefix;
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public MetamodelPrefixPropertyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken iPrefix, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 3;
			if (iPrefix != null)
			{
				this.AdjustFlagsAndWidth(iPrefix);
				this.iPrefix = iPrefix;
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
	
	    public MetamodelPrefixPropertyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken iPrefix, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 3;
			if (iPrefix != null)
			{
				this.AdjustFlagsAndWidth(iPrefix);
				this.iPrefix = iPrefix;
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
	
		private MetamodelPrefixPropertyGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelPrefixProperty, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken IPrefix { get { return this.iPrefix; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.MetamodelPrefixPropertySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iPrefix;
	            case 1: return this.tAssign;
	            case 2: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitMetamodelPrefixPropertyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitMetamodelPrefixPropertyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelPrefixPropertyGreen(this.Kind, this.iPrefix, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelPrefixPropertyGreen(this.Kind, this.iPrefix, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelPrefixPropertyGreen Update(InternalSyntaxToken iPrefix, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.IPrefix != iPrefix ||
				this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.MetamodelPrefixProperty(iPrefix, tAssign, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPrefixPropertyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly DeclarationGreen __Missing = new DeclarationGreen();
	    private EnumDeclarationGreen enumDeclaration;
	    private ClassDeclarationGreen classDeclaration;
	    private AssociationDeclarationGreen associationDeclaration;
	    private ConstDeclarationGreen constDeclaration;
	
	    public DeclarationGreen(TestIncrementalCompilationSyntaxKind kind, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, AssociationDeclarationGreen associationDeclaration, ConstDeclarationGreen constDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
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
			if (associationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(associationDeclaration);
				this.associationDeclaration = associationDeclaration;
			}
			if (constDeclaration != null)
			{
				this.AdjustFlagsAndWidth(constDeclaration);
				this.constDeclaration = constDeclaration;
			}
	    }
	
	    public DeclarationGreen(TestIncrementalCompilationSyntaxKind kind, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, AssociationDeclarationGreen associationDeclaration, ConstDeclarationGreen constDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
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
			if (associationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(associationDeclaration);
				this.associationDeclaration = associationDeclaration;
			}
			if (constDeclaration != null)
			{
				this.AdjustFlagsAndWidth(constDeclaration);
				this.constDeclaration = constDeclaration;
			}
	    }
	
		private DeclarationGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Declaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public EnumDeclarationGreen EnumDeclaration { get { return this.enumDeclaration; } }
	    public ClassDeclarationGreen ClassDeclaration { get { return this.classDeclaration; } }
	    public AssociationDeclarationGreen AssociationDeclaration { get { return this.associationDeclaration; } }
	    public ConstDeclarationGreen ConstDeclaration { get { return this.constDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.DeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumDeclaration;
	            case 1: return this.classDeclaration;
	            case 2: return this.associationDeclaration;
	            case 3: return this.constDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.classDeclaration, this.associationDeclaration, this.constDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.classDeclaration, this.associationDeclaration, this.constDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(EnumDeclarationGreen enumDeclaration)
	    {
	        if (this.enumDeclaration != enumDeclaration)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Declaration(enumDeclaration);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Declaration(classDeclaration);
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
	
	    public DeclarationGreen Update(AssociationDeclarationGreen associationDeclaration)
	    {
	        if (this.associationDeclaration != associationDeclaration)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Declaration(associationDeclaration);
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
	
	    public DeclarationGreen Update(ConstDeclarationGreen constDeclaration)
	    {
	        if (this.constDeclaration != constDeclaration)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Declaration(constDeclaration);
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
	    private GreenNode attribute;
	    private InternalSyntaxToken kEnum;
	    private NameGreen name;
	    private EnumBodyGreen enumBody;
	
	    public EnumDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
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
	
	    public EnumDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KEnum { get { return this.kEnum; } }
	    public NameGreen Name { get { return this.name; } }
	    public EnumBodyGreen EnumBody { get { return this.enumBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.EnumDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitEnumDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitEnumDeclarationGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(attribute, kEnum, name, enumBody);
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
	
	    public EnumBodyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, GreenNode enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
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
	
	    public EnumBodyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, GreenNode enumMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumBody, null, null)
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
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.EnumBodySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitEnumBodyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitEnumBodyGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
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
	
	    public EnumValuesGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode enumValue)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (enumValue != null)
			{
				this.AdjustFlagsAndWidth(enumValue);
				this.enumValue = enumValue;
			}
	    }
	
	    public EnumValuesGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode enumValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumValues, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> EnumValue { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen>(this.enumValue); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.EnumValuesSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumValue;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitEnumValuesGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitEnumValuesGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.EnumValues(enumValue);
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
	
	    public EnumValueGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, NameGreen name)
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
	
	    public EnumValueGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.EnumValueSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitEnumValueGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitEnumValueGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.EnumValue(attribute, name);
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
	
	    public EnumMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, OperationDeclarationGreen operationDeclaration)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
	    public EnumMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, OperationDeclarationGreen operationDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumMemberDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OperationDeclarationGreen OperationDeclaration { get { return this.operationDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.EnumMemberDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.operationDeclaration;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitEnumMemberDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitEnumMemberDeclarationGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.EnumMemberDeclaration(operationDeclaration);
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
	    private InternalSyntaxToken kClass;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ClassAncestorsGreen classAncestors;
	    private ClassBodyGreen classBody;
	
	    public ClassDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
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
			if (kClass != null)
			{
				this.AdjustFlagsAndWidth(kClass);
				this.kClass = kClass;
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
	
	    public ClassDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (kClass != null)
			{
				this.AdjustFlagsAndWidth(kClass);
				this.kClass = kClass;
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KAbstract { get { return this.kAbstract; } }
	    public InternalSyntaxToken KClass { get { return this.kClass; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ClassAncestorsGreen ClassAncestors { get { return this.classAncestors; } }
	    public ClassBodyGreen ClassBody { get { return this.classBody; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ClassDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.kAbstract;
	            case 2: return this.kClass;
	            case 3: return this.name;
	            case 4: return this.tColon;
	            case 5: return this.classAncestors;
	            case 6: return this.classBody;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitClassDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitClassDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.attribute, this.kAbstract, this.kClass, this.name, this.tColon, this.classAncestors, this.classBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.attribute, this.kAbstract, this.kClass, this.name, this.tColon, this.classAncestors, this.classBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	        if (this.Attribute != attribute ||
				this.KAbstract != kAbstract ||
				this.KClass != kClass ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(attribute, kAbstract, kClass, name, tColon, classAncestors, classBody);
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
	
	internal class ClassBodyGreen : GreenSyntaxNode
	{
	    internal static readonly ClassBodyGreen __Missing = new ClassBodyGreen();
	    private InternalSyntaxToken tOpenBrace;
	    private GreenNode classMemberDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ClassBodyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode classMemberDeclaration, InternalSyntaxToken tCloseBrace)
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
	
	    public ClassBodyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tOpenBrace, GreenNode classMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassBody, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> ClassMemberDeclaration { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen>(this.classMemberDeclaration); } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ClassBodySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitClassBodyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitClassBodyGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
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
	
	internal class ClassAncestorsGreen : GreenSyntaxNode
	{
	    internal static readonly ClassAncestorsGreen __Missing = new ClassAncestorsGreen();
	    private GreenNode classAncestor;
	
	    public ClassAncestorsGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode classAncestor)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (classAncestor != null)
			{
				this.AdjustFlagsAndWidth(classAncestor);
				this.classAncestor = classAncestor;
			}
	    }
	
	    public ClassAncestorsGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode classAncestor, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassAncestors, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> ClassAncestor { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen>(this.classAncestor); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ClassAncestorsSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.classAncestor;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitClassAncestorsGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitClassAncestorsGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassAncestors(classAncestor);
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
	
	    public ClassAncestorGreen(TestIncrementalCompilationSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ClassAncestorGreen(TestIncrementalCompilationSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassAncestor, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ClassAncestorSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitClassAncestorGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitClassAncestorGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassAncestor(qualifier);
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
	
	internal class ClassMemberDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ClassMemberDeclarationGreen __Missing = new ClassMemberDeclarationGreen();
	    private FieldDeclarationGreen fieldDeclaration;
	    private OperationDeclarationGreen operationDeclaration;
	
	    public ClassMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, FieldDeclarationGreen fieldDeclaration, OperationDeclarationGreen operationDeclaration)
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
	
	    public ClassMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, FieldDeclarationGreen fieldDeclaration, OperationDeclarationGreen operationDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassMemberDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public FieldDeclarationGreen FieldDeclaration { get { return this.fieldDeclaration; } }
	    public OperationDeclarationGreen OperationDeclaration { get { return this.operationDeclaration; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ClassMemberDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitClassMemberDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitClassMemberDeclarationGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration(fieldDeclaration);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration(operationDeclaration);
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
	
	internal class FieldDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly FieldDeclarationGreen __Missing = new FieldDeclarationGreen();
	    private GreenNode attribute;
	    private FieldContainmentGreen fieldContainment;
	    private FieldModifierGreen fieldModifier;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private DefaultValueGreen defaultValue;
	    private GreenNode redefinitionsOrSubsettings;
	    private InternalSyntaxToken tSemicolon;
	
	    public FieldDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, GreenNode redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon)
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
			if (redefinitionsOrSubsettings != null)
			{
				this.AdjustFlagsAndWidth(redefinitionsOrSubsettings);
				this.redefinitionsOrSubsettings = redefinitionsOrSubsettings;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public FieldDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, GreenNode redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (redefinitionsOrSubsettings != null)
			{
				this.AdjustFlagsAndWidth(redefinitionsOrSubsettings);
				this.redefinitionsOrSubsettings = redefinitionsOrSubsettings;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private FieldDeclarationGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.FieldDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public FieldContainmentGreen FieldContainment { get { return this.fieldContainment; } }
	    public FieldModifierGreen FieldModifier { get { return this.fieldModifier; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public DefaultValueGreen DefaultValue { get { return this.defaultValue; } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RedefinitionsOrSubsettingsGreen> RedefinitionsOrSubsettings { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RedefinitionsOrSubsettingsGreen>(this.redefinitionsOrSubsettings); } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.FieldDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	            case 6: return this.redefinitionsOrSubsettings;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitFieldDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitFieldDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.attribute, this.fieldContainment, this.fieldModifier, this.typeReference, this.name, this.defaultValue, this.redefinitionsOrSubsettings, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.attribute, this.fieldContainment, this.fieldModifier, this.typeReference, this.name, this.defaultValue, this.redefinitionsOrSubsettings, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RedefinitionsOrSubsettingsGreen> redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.FieldContainment != fieldContainment ||
				this.FieldModifier != fieldModifier ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue ||
				this.RedefinitionsOrSubsettings != redefinitionsOrSubsettings ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(attribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, redefinitionsOrSubsettings, tSemicolon);
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
	
	    public FieldContainmentGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kContainment)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kContainment != null)
			{
				this.AdjustFlagsAndWidth(kContainment);
				this.kContainment = kContainment;
			}
	    }
	
	    public FieldContainmentGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kContainment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.FieldContainment, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KContainment { get { return this.kContainment; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.FieldContainmentSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kContainment;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitFieldContainmentGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitFieldContainmentGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.FieldContainment(kContainment);
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
	
	    public FieldModifierGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken fieldModifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
			}
	    }
	
	    public FieldModifierGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken fieldModifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.FieldModifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken FieldModifier { get { return this.fieldModifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.FieldModifierSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldModifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitFieldModifierGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitFieldModifierGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.FieldModifier(fieldModifier);
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
	
	    public DefaultValueGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
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
	
	    public DefaultValueGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.DefaultValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.DefaultValueSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitDefaultValueGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitDefaultValueGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.DefaultValue(tAssign, stringLiteral);
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
	
	internal class RedefinitionsOrSubsettingsGreen : GreenSyntaxNode
	{
	    internal static readonly RedefinitionsOrSubsettingsGreen __Missing = new RedefinitionsOrSubsettingsGreen();
	    private RedefinitionsGreen redefinitions;
	    private SubsettingsGreen subsettings;
	
	    public RedefinitionsOrSubsettingsGreen(TestIncrementalCompilationSyntaxKind kind, RedefinitionsGreen redefinitions, SubsettingsGreen subsettings)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (redefinitions != null)
			{
				this.AdjustFlagsAndWidth(redefinitions);
				this.redefinitions = redefinitions;
			}
			if (subsettings != null)
			{
				this.AdjustFlagsAndWidth(subsettings);
				this.subsettings = subsettings;
			}
	    }
	
	    public RedefinitionsOrSubsettingsGreen(TestIncrementalCompilationSyntaxKind kind, RedefinitionsGreen redefinitions, SubsettingsGreen subsettings, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (redefinitions != null)
			{
				this.AdjustFlagsAndWidth(redefinitions);
				this.redefinitions = redefinitions;
			}
			if (subsettings != null)
			{
				this.AdjustFlagsAndWidth(subsettings);
				this.subsettings = subsettings;
			}
	    }
	
		private RedefinitionsOrSubsettingsGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.RedefinitionsOrSubsettings, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public RedefinitionsGreen Redefinitions { get { return this.redefinitions; } }
	    public SubsettingsGreen Subsettings { get { return this.subsettings; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.RedefinitionsOrSubsettingsSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.redefinitions;
	            case 1: return this.subsettings;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitRedefinitionsOrSubsettingsGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitRedefinitionsOrSubsettingsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RedefinitionsOrSubsettingsGreen(this.Kind, this.redefinitions, this.subsettings, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RedefinitionsOrSubsettingsGreen(this.Kind, this.redefinitions, this.subsettings, this.GetDiagnostics(), annotations);
	    }
	
	    public RedefinitionsOrSubsettingsGreen Update(RedefinitionsGreen redefinitions)
	    {
	        if (this.redefinitions != redefinitions)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings(redefinitions);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsOrSubsettingsGreen)newNode;
	        }
	        return this;
	    }
	
	    public RedefinitionsOrSubsettingsGreen Update(SubsettingsGreen subsettings)
	    {
	        if (this.subsettings != subsettings)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings(subsettings);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsOrSubsettingsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class RedefinitionsGreen : GreenSyntaxNode
	{
	    internal static readonly RedefinitionsGreen __Missing = new RedefinitionsGreen();
	    private InternalSyntaxToken kRedefines;
	    private NameUseListGreen nameUseList;
	
	    public RedefinitionsGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kRedefines, NameUseListGreen nameUseList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kRedefines != null)
			{
				this.AdjustFlagsAndWidth(kRedefines);
				this.kRedefines = kRedefines;
			}
			if (nameUseList != null)
			{
				this.AdjustFlagsAndWidth(nameUseList);
				this.nameUseList = nameUseList;
			}
	    }
	
	    public RedefinitionsGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kRedefines, NameUseListGreen nameUseList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kRedefines != null)
			{
				this.AdjustFlagsAndWidth(kRedefines);
				this.kRedefines = kRedefines;
			}
			if (nameUseList != null)
			{
				this.AdjustFlagsAndWidth(nameUseList);
				this.nameUseList = nameUseList;
			}
	    }
	
		private RedefinitionsGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Redefinitions, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KRedefines { get { return this.kRedefines; } }
	    public NameUseListGreen NameUseList { get { return this.nameUseList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.RedefinitionsSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRedefines;
	            case 1: return this.nameUseList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitRedefinitionsGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitRedefinitionsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RedefinitionsGreen(this.Kind, this.kRedefines, this.nameUseList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RedefinitionsGreen(this.Kind, this.kRedefines, this.nameUseList, this.GetDiagnostics(), annotations);
	    }
	
	    public RedefinitionsGreen Update(InternalSyntaxToken kRedefines, NameUseListGreen nameUseList)
	    {
	        if (this.KRedefines != kRedefines ||
				this.NameUseList != nameUseList)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Redefinitions(kRedefines, nameUseList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SubsettingsGreen : GreenSyntaxNode
	{
	    internal static readonly SubsettingsGreen __Missing = new SubsettingsGreen();
	    private InternalSyntaxToken kSubsets;
	    private NameUseListGreen nameUseList;
	
	    public SubsettingsGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kSubsets, NameUseListGreen nameUseList)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (kSubsets != null)
			{
				this.AdjustFlagsAndWidth(kSubsets);
				this.kSubsets = kSubsets;
			}
			if (nameUseList != null)
			{
				this.AdjustFlagsAndWidth(nameUseList);
				this.nameUseList = nameUseList;
			}
	    }
	
	    public SubsettingsGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kSubsets, NameUseListGreen nameUseList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (kSubsets != null)
			{
				this.AdjustFlagsAndWidth(kSubsets);
				this.kSubsets = kSubsets;
			}
			if (nameUseList != null)
			{
				this.AdjustFlagsAndWidth(nameUseList);
				this.nameUseList = nameUseList;
			}
	    }
	
		private SubsettingsGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Subsettings, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KSubsets { get { return this.kSubsets; } }
	    public NameUseListGreen NameUseList { get { return this.nameUseList; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.SubsettingsSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSubsets;
	            case 1: return this.nameUseList;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitSubsettingsGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitSubsettingsGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SubsettingsGreen(this.Kind, this.kSubsets, this.nameUseList, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SubsettingsGreen(this.Kind, this.kSubsets, this.nameUseList, this.GetDiagnostics(), annotations);
	    }
	
	    public SubsettingsGreen Update(InternalSyntaxToken kSubsets, NameUseListGreen nameUseList)
	    {
	        if (this.KSubsets != kSubsets ||
				this.NameUseList != nameUseList)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Subsettings(kSubsets, nameUseList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SubsettingsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameUseListGreen : GreenSyntaxNode
	{
	    internal static readonly NameUseListGreen __Missing = new NameUseListGreen();
	    private GreenNode qualifier;
	
	    public NameUseListGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public NameUseListGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NameUseList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen> Qualifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<QualifierGreen>(this.qualifier); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.NameUseListSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitNameUseListGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitNameUseListGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.NameUseList(qualifier);
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
	
	internal class ConstDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly ConstDeclarationGreen __Missing = new ConstDeclarationGreen();
	    private InternalSyntaxToken kConst;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private ConstValueGreen constValue;
	    private InternalSyntaxToken tSemicolon;
	
	    public ConstDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, ConstValueGreen constValue, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 5;
			if (kConst != null)
			{
				this.AdjustFlagsAndWidth(kConst);
				this.kConst = kConst;
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
			if (constValue != null)
			{
				this.AdjustFlagsAndWidth(constValue);
				this.constValue = constValue;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ConstDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, ConstValueGreen constValue, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 5;
			if (kConst != null)
			{
				this.AdjustFlagsAndWidth(kConst);
				this.kConst = kConst;
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
			if (constValue != null)
			{
				this.AdjustFlagsAndWidth(constValue);
				this.constValue = constValue;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		private ConstDeclarationGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ConstDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KConst { get { return this.kConst; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public ConstValueGreen ConstValue { get { return this.constValue; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ConstDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kConst;
	            case 1: return this.typeReference;
	            case 2: return this.name;
	            case 3: return this.constValue;
	            case 4: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitConstDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitConstDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConstDeclarationGreen(this.Kind, this.kConst, this.typeReference, this.name, this.constValue, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConstDeclarationGreen(this.Kind, this.kConst, this.typeReference, this.name, this.constValue, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ConstDeclarationGreen Update(InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, ConstValueGreen constValue, InternalSyntaxToken tSemicolon)
	    {
	        if (this.KConst != kConst ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.ConstValue != constValue ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ConstDeclaration(kConst, typeReference, name, constValue, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ConstValueGreen : GreenSyntaxNode
	{
	    internal static readonly ConstValueGreen __Missing = new ConstValueGreen();
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public ConstValueGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
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
	
	    public ConstValueGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
		private ConstValueGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ConstValue, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ConstValueSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitConstValueGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitConstValueGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConstValueGreen(this.Kind, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConstValueGreen(this.Kind, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public ConstValueGreen Update(InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ConstValue(tAssign, stringLiteral);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ReturnTypeGreen : GreenSyntaxNode
	{
	    internal static readonly ReturnTypeGreen __Missing = new ReturnTypeGreen();
	    private TypeReferenceGreen typeReference;
	    private VoidTypeGreen voidType;
	
	    public ReturnTypeGreen(TestIncrementalCompilationSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType)
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
	
	    public ReturnTypeGreen(TestIncrementalCompilationSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ReturnType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ReturnTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitReturnTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitReturnTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
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
	
	    public TypeOfReferenceGreen(TestIncrementalCompilationSyntaxKind kind, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypeOfReferenceGreen(TestIncrementalCompilationSyntaxKind kind, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.TypeOfReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.TypeOfReferenceSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitTypeOfReferenceGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitTypeOfReferenceGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.TypeOfReference(typeReference);
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
	    private CollectionTypeGreen collectionType;
	    private SimpleTypeGreen simpleType;
	
	    public TypeReferenceGreen(TestIncrementalCompilationSyntaxKind kind, CollectionTypeGreen collectionType, SimpleTypeGreen simpleType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (collectionType != null)
			{
				this.AdjustFlagsAndWidth(collectionType);
				this.collectionType = collectionType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
	    public TypeReferenceGreen(TestIncrementalCompilationSyntaxKind kind, CollectionTypeGreen collectionType, SimpleTypeGreen simpleType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (collectionType != null)
			{
				this.AdjustFlagsAndWidth(collectionType);
				this.collectionType = collectionType;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
	    }
	
		private TypeReferenceGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.TypeReference, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public CollectionTypeGreen CollectionType { get { return this.collectionType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.TypeReferenceSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.collectionType;
	            case 1: return this.simpleType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitTypeReferenceGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.collectionType, this.simpleType, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.collectionType, this.simpleType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(CollectionTypeGreen collectionType)
	    {
	        if (this.collectionType != collectionType)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.TypeReference(collectionType);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleType);
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
	
	    public SimpleTypeGreen(TestIncrementalCompilationSyntaxKind kind, PrimitiveTypeGreen primitiveType, ObjectTypeGreen objectType, NullableTypeGreen nullableType, ClassTypeGreen classType)
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
	
	    public SimpleTypeGreen(TestIncrementalCompilationSyntaxKind kind, PrimitiveTypeGreen primitiveType, ObjectTypeGreen objectType, NullableTypeGreen nullableType, ClassTypeGreen classType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.SimpleType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public ClassTypeGreen ClassType { get { return this.classType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.SimpleTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitSimpleTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitSimpleTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.SimpleType(primitiveType);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.SimpleType(objectType);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.SimpleType(nullableType);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.SimpleType(classType);
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
	
	    public ClassTypeGreen(TestIncrementalCompilationSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ClassTypeGreen(TestIncrementalCompilationSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ClassTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitClassTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitClassTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ClassType(qualifier);
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
	
	    public ObjectTypeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken objectType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
	    public ObjectTypeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken objectType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ObjectType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken ObjectType { get { return this.objectType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ObjectTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.objectType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitObjectTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitObjectTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ObjectType(objectType);
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
	
	    public PrimitiveTypeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken primitiveType)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
	    public PrimitiveTypeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken primitiveType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.PrimitiveType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken PrimitiveType { get { return this.primitiveType; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.PrimitiveTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitPrimitiveTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitPrimitiveTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.PrimitiveType(primitiveType);
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
	
	    public VoidTypeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.VoidType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.VoidTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitVoidTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitVoidTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
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
	
	    public NullableTypeGreen(TestIncrementalCompilationSyntaxKind kind, PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion)
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
	
	    public NullableTypeGreen(TestIncrementalCompilationSyntaxKind kind, PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NullableType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.NullableTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitNullableTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitNullableTypeGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.NullableType(primitiveType, tQuestion);
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
	
	internal class CollectionTypeGreen : GreenSyntaxNode
	{
	    internal static readonly CollectionTypeGreen __Missing = new CollectionTypeGreen();
	    private CollectionKindGreen collectionKind;
	    private InternalSyntaxToken tLessThan;
	    private SimpleTypeGreen simpleType;
	    private InternalSyntaxToken tGreaterThan;
	
	    public CollectionTypeGreen(TestIncrementalCompilationSyntaxKind kind, CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
			this.SlotCount = 4;
			if (collectionKind != null)
			{
				this.AdjustFlagsAndWidth(collectionKind);
				this.collectionKind = collectionKind;
			}
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
	    public CollectionTypeGreen(TestIncrementalCompilationSyntaxKind kind, CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 4;
			if (collectionKind != null)
			{
				this.AdjustFlagsAndWidth(collectionKind);
				this.collectionKind = collectionKind;
			}
			if (tLessThan != null)
			{
				this.AdjustFlagsAndWidth(tLessThan);
				this.tLessThan = tLessThan;
			}
			if (simpleType != null)
			{
				this.AdjustFlagsAndWidth(simpleType);
				this.simpleType = simpleType;
			}
			if (tGreaterThan != null)
			{
				this.AdjustFlagsAndWidth(tGreaterThan);
				this.tGreaterThan = tGreaterThan;
			}
	    }
	
		private CollectionTypeGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.CollectionType, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public CollectionKindGreen CollectionKind { get { return this.collectionKind; } }
	    public InternalSyntaxToken TLessThan { get { return this.tLessThan; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public InternalSyntaxToken TGreaterThan { get { return this.tGreaterThan; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.CollectionTypeSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.collectionKind;
	            case 1: return this.tLessThan;
	            case 2: return this.simpleType;
	            case 3: return this.tGreaterThan;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitCollectionTypeGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitCollectionTypeGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CollectionTypeGreen(this.Kind, this.collectionKind, this.tLessThan, this.simpleType, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CollectionTypeGreen(this.Kind, this.collectionKind, this.tLessThan, this.simpleType, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public CollectionTypeGreen Update(CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.CollectionKind != collectionKind ||
				this.TLessThan != tLessThan ||
				this.SimpleType != simpleType ||
				this.TGreaterThan != tGreaterThan)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionTypeGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CollectionKindGreen : GreenSyntaxNode
	{
	    internal static readonly CollectionKindGreen __Missing = new CollectionKindGreen();
	    private InternalSyntaxToken collectionKind;
	
	    public CollectionKindGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken collectionKind)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (collectionKind != null)
			{
				this.AdjustFlagsAndWidth(collectionKind);
				this.collectionKind = collectionKind;
			}
	    }
	
	    public CollectionKindGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken collectionKind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (collectionKind != null)
			{
				this.AdjustFlagsAndWidth(collectionKind);
				this.collectionKind = collectionKind;
			}
	    }
	
		private CollectionKindGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.CollectionKind, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken CollectionKind { get { return this.collectionKind; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.CollectionKindSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.collectionKind;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitCollectionKindGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitCollectionKindGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CollectionKindGreen(this.Kind, this.collectionKind, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CollectionKindGreen(this.Kind, this.collectionKind, this.GetDiagnostics(), annotations);
	    }
	
	    public CollectionKindGreen Update(InternalSyntaxToken collectionKind)
	    {
	        if (this.CollectionKind != collectionKind)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.CollectionKind(collectionKind);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionKindGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly OperationDeclarationGreen __Missing = new OperationDeclarationGreen();
	    private GreenNode attribute;
	    private GreenNode operationModifier;
	    private ReturnTypeGreen returnType;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private ParameterListGreen parameterList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tSemicolon;
	
	    public OperationDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, GreenNode operationModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (operationModifier != null)
			{
				this.AdjustFlagsAndWidth(operationModifier);
				this.operationModifier = operationModifier;
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
	
	    public OperationDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, GreenNode operationModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 8;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (operationModifier != null)
			{
				this.AdjustFlagsAndWidth(operationModifier);
				this.operationModifier = operationModifier;
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationModifierGreen> OperationModifier { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationModifierGreen>(this.operationModifier); } }
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ParameterListGreen ParameterList { get { return this.parameterList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.OperationDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.operationModifier;
	            case 2: return this.returnType;
	            case 3: return this.name;
	            case 4: return this.tOpenParen;
	            case 5: return this.parameterList;
	            case 6: return this.tCloseParen;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitOperationDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.attribute, this.operationModifier, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.attribute, this.operationModifier, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationModifierGreen> operationModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.OperationModifier != operationModifier ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(attribute, operationModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
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
	
	internal class OperationModifierGreen : GreenSyntaxNode
	{
	    internal static readonly OperationModifierGreen __Missing = new OperationModifierGreen();
	    private OperationModifierBuilderGreen operationModifierBuilder;
	    private OperationModifierReadonlyGreen operationModifierReadonly;
	
	    public OperationModifierGreen(TestIncrementalCompilationSyntaxKind kind, OperationModifierBuilderGreen operationModifierBuilder, OperationModifierReadonlyGreen operationModifierReadonly)
	        : base(kind, null, null)
	    {
			this.SlotCount = 2;
			if (operationModifierBuilder != null)
			{
				this.AdjustFlagsAndWidth(operationModifierBuilder);
				this.operationModifierBuilder = operationModifierBuilder;
			}
			if (operationModifierReadonly != null)
			{
				this.AdjustFlagsAndWidth(operationModifierReadonly);
				this.operationModifierReadonly = operationModifierReadonly;
			}
	    }
	
	    public OperationModifierGreen(TestIncrementalCompilationSyntaxKind kind, OperationModifierBuilderGreen operationModifierBuilder, OperationModifierReadonlyGreen operationModifierReadonly, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 2;
			if (operationModifierBuilder != null)
			{
				this.AdjustFlagsAndWidth(operationModifierBuilder);
				this.operationModifierBuilder = operationModifierBuilder;
			}
			if (operationModifierReadonly != null)
			{
				this.AdjustFlagsAndWidth(operationModifierReadonly);
				this.operationModifierReadonly = operationModifierReadonly;
			}
	    }
	
		private OperationModifierGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public OperationModifierBuilderGreen OperationModifierBuilder { get { return this.operationModifierBuilder; } }
	    public OperationModifierReadonlyGreen OperationModifierReadonly { get { return this.operationModifierReadonly; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.OperationModifierSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.operationModifierBuilder;
	            case 1: return this.operationModifierReadonly;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitOperationModifierGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitOperationModifierGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationModifierGreen(this.Kind, this.operationModifierBuilder, this.operationModifierReadonly, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationModifierGreen(this.Kind, this.operationModifierBuilder, this.operationModifierReadonly, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationModifierGreen Update(OperationModifierBuilderGreen operationModifierBuilder)
	    {
	        if (this.operationModifierBuilder != operationModifierBuilder)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.OperationModifier(operationModifierBuilder);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierGreen)newNode;
	        }
	        return this;
	    }
	
	    public OperationModifierGreen Update(OperationModifierReadonlyGreen operationModifierReadonly)
	    {
	        if (this.operationModifierReadonly != operationModifierReadonly)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.OperationModifier(operationModifierReadonly);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationModifierBuilderGreen : GreenSyntaxNode
	{
	    internal static readonly OperationModifierBuilderGreen __Missing = new OperationModifierBuilderGreen();
	    private InternalSyntaxToken kBuilder;
	
	    public OperationModifierBuilderGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kBuilder)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kBuilder != null)
			{
				this.AdjustFlagsAndWidth(kBuilder);
				this.kBuilder = kBuilder;
			}
	    }
	
	    public OperationModifierBuilderGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kBuilder, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kBuilder != null)
			{
				this.AdjustFlagsAndWidth(kBuilder);
				this.kBuilder = kBuilder;
			}
	    }
	
		private OperationModifierBuilderGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifierBuilder, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KBuilder { get { return this.kBuilder; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.OperationModifierBuilderSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBuilder;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitOperationModifierBuilderGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitOperationModifierBuilderGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationModifierBuilderGreen(this.Kind, this.kBuilder, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationModifierBuilderGreen(this.Kind, this.kBuilder, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationModifierBuilderGreen Update(InternalSyntaxToken kBuilder)
	    {
	        if (this.KBuilder != kBuilder)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.OperationModifierBuilder(kBuilder);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierBuilderGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class OperationModifierReadonlyGreen : GreenSyntaxNode
	{
	    internal static readonly OperationModifierReadonlyGreen __Missing = new OperationModifierReadonlyGreen();
	    private InternalSyntaxToken kReadonly;
	
	    public OperationModifierReadonlyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kReadonly)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kReadonly != null)
			{
				this.AdjustFlagsAndWidth(kReadonly);
				this.kReadonly = kReadonly;
			}
	    }
	
	    public OperationModifierReadonlyGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kReadonly, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 1;
			if (kReadonly != null)
			{
				this.AdjustFlagsAndWidth(kReadonly);
				this.kReadonly = kReadonly;
			}
	    }
	
		private OperationModifierReadonlyGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifierReadonly, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KReadonly { get { return this.kReadonly; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.OperationModifierReadonlySyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kReadonly;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitOperationModifierReadonlyGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitOperationModifierReadonlyGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationModifierReadonlyGreen(this.Kind, this.kReadonly, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationModifierReadonlyGreen(this.Kind, this.kReadonly, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationModifierReadonlyGreen Update(InternalSyntaxToken kReadonly)
	    {
	        if (this.KReadonly != kReadonly)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.OperationModifierReadonly(kReadonly);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierReadonlyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParameterListGreen : GreenSyntaxNode
	{
	    internal static readonly ParameterListGreen __Missing = new ParameterListGreen();
	    private GreenNode parameter;
	
	    public ParameterListGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode parameter)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
	    public ParameterListGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode parameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ParameterList, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> Parameter { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen>(this.parameter); } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ParameterListSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parameter;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitParameterListGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitParameterListGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ParameterList(parameter);
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
	
	    public ParameterGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, TypeReferenceGreen typeReference, NameGreen name)
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
	
	    public ParameterGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, TypeReferenceGreen typeReference, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Parameter, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ParameterSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitParameterGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitParameterGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Parameter(attribute, typeReference, name);
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
	
	internal class AssociationDeclarationGreen : GreenSyntaxNode
	{
	    internal static readonly AssociationDeclarationGreen __Missing = new AssociationDeclarationGreen();
	    private GreenNode attribute;
	    private InternalSyntaxToken kAssociation;
	    private QualifierGreen source;
	    private InternalSyntaxToken kWith;
	    private QualifierGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public AssociationDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			this.SlotCount = 6;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kAssociation != null)
			{
				this.AdjustFlagsAndWidth(kAssociation);
				this.kAssociation = kAssociation;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (kWith != null)
			{
				this.AdjustFlagsAndWidth(kWith);
				this.kWith = kWith;
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
	
	    public AssociationDeclarationGreen(TestIncrementalCompilationSyntaxKind kind, GreenNode attribute, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			this.SlotCount = 6;
			if (attribute != null)
			{
				this.AdjustFlagsAndWidth(attribute);
				this.attribute = attribute;
			}
			if (kAssociation != null)
			{
				this.AdjustFlagsAndWidth(kAssociation);
				this.kAssociation = kAssociation;
			}
			if (source != null)
			{
				this.AdjustFlagsAndWidth(source);
				this.source = source;
			}
			if (kWith != null)
			{
				this.AdjustFlagsAndWidth(kWith);
				this.kWith = kWith;
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
	
		private AssociationDeclarationGreen()
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.AssociationDeclaration, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> Attribute { get { return new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen>(this.attribute); } }
	    public InternalSyntaxToken KAssociation { get { return this.kAssociation; } }
	    public QualifierGreen Source { get { return this.source; } }
	    public InternalSyntaxToken KWith { get { return this.kWith; } }
	    public QualifierGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.AssociationDeclarationSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.attribute;
	            case 1: return this.kAssociation;
	            case 2: return this.source;
	            case 3: return this.kWith;
	            case 4: return this.target;
	            case 5: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitAssociationDeclarationGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitAssociationDeclarationGreen(this);
	
	    public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssociationDeclarationGreen(this.Kind, this.attribute, this.kAssociation, this.source, this.kWith, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssociationDeclarationGreen(this.Kind, this.attribute, this.kAssociation, this.source, this.kWith, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public AssociationDeclarationGreen Update(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KAssociation != kAssociation ||
				this.Source != source ||
				this.KWith != kWith ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.AssociationDeclaration(attribute, kAssociation, source, kWith, target, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssociationDeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : GreenSyntaxNode
	{
	    internal static readonly IdentifierGreen __Missing = new IdentifierGreen();
	    private InternalSyntaxToken identifier;
	
	    public IdentifierGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Identifier, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.IdentifierSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitIdentifierGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitIdentifierGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Identifier(identifier);
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
	
	    public LiteralGreen(TestIncrementalCompilationSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
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
	
	    public LiteralGreen(TestIncrementalCompilationSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Literal, null, null)
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
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.LiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
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
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	    public NullLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NullLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.NullLiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitNullLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitNullLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	    public BooleanLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.BooleanLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.BooleanLiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitBooleanLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitBooleanLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	    public IntegerLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.IntegerLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.IntegerLiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitIntegerLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitIntegerLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	    public DecimalLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.DecimalLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.DecimalLiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitDecimalLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitDecimalLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	    public ScientificLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ScientificLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.ScientificLiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitScientificLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitScientificLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	
	    public StringLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lRegularString)
	        : base(kind, null, null)
	    {
			this.SlotCount = 1;
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
	    public StringLiteralGreen(TestIncrementalCompilationSyntaxKind kind, InternalSyntaxToken lRegularString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			: base((TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.StringLiteral, null, null)
		{
			this.flags &= ~NodeFlags.IsNotMissing;
		}
	
	    public InternalSyntaxToken LRegularString { get { return this.lRegularString; } }
	
	    protected override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.StringLiteralSyntax(this, (TestIncrementalCompilationSyntaxNode)parent, position);
	    }
	
	    protected override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lRegularString;
	            default: return null;
	        }
	    }
	
	    public override TResult Accept<TResult>(TestIncrementalCompilationSyntaxVisitor<TResult> visitor) => visitor.VisitStringLiteralGreen(this);
	
	    public override void Accept(TestIncrementalCompilationSyntaxVisitor visitor) => visitor.VisitStringLiteralGreen(this);
	
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
	            InternalSyntaxNode newNode = TestIncrementalCompilationLanguage.Instance.InternalSyntaxFactory.StringLiteral(lRegularString);
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

	internal class TestIncrementalCompilationSyntaxVisitor : InternalSyntaxVisitor
	{
		public virtual void VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual void VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitAttributeGreen(AttributeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitMetamodelDeclarationGreen(MetamodelDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitMetamodelPropertyListGreen(MetamodelPropertyListGreen node) => this.DefaultVisit(node);
		public virtual void VisitMetamodelPropertyGreen(MetamodelPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitMetamodelUriPropertyGreen(MetamodelUriPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitMetamodelPrefixPropertyGreen(MetamodelPrefixPropertyGreen node) => this.DefaultVisit(node);
		public virtual void VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumValuesGreen(EnumValuesGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumValueGreen(EnumValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitEnumMemberDeclarationGreen(EnumMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassDeclarationGreen(ClassDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassBodyGreen(ClassBodyGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassAncestorsGreen(ClassAncestorsGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassAncestorGreen(ClassAncestorGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassMemberDeclarationGreen(ClassMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldDeclarationGreen(FieldDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldContainmentGreen(FieldContainmentGreen node) => this.DefaultVisit(node);
		public virtual void VisitFieldModifierGreen(FieldModifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitDefaultValueGreen(DefaultValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitRedefinitionsOrSubsettingsGreen(RedefinitionsOrSubsettingsGreen node) => this.DefaultVisit(node);
		public virtual void VisitRedefinitionsGreen(RedefinitionsGreen node) => this.DefaultVisit(node);
		public virtual void VisitSubsettingsGreen(SubsettingsGreen node) => this.DefaultVisit(node);
		public virtual void VisitNameUseListGreen(NameUseListGreen node) => this.DefaultVisit(node);
		public virtual void VisitConstDeclarationGreen(ConstDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitConstValueGreen(ConstValueGreen node) => this.DefaultVisit(node);
		public virtual void VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeOfReferenceGreen(TypeOfReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual void VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitClassTypeGreen(ClassTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitCollectionTypeGreen(CollectionTypeGreen node) => this.DefaultVisit(node);
		public virtual void VisitCollectionKindGreen(CollectionKindGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationModifierGreen(OperationModifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationModifierBuilderGreen(OperationModifierBuilderGreen node) => this.DefaultVisit(node);
		public virtual void VisitOperationModifierReadonlyGreen(OperationModifierReadonlyGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual void VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual void VisitAssociationDeclarationGreen(AssociationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual void VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual void VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual void VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
	}
	
	internal class TestIncrementalCompilationSyntaxVisitor<TResult> : InternalSyntaxVisitor<TResult>
	{
		public virtual TResult VisitMainGreen(MainGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameGreen(NameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifiedNameGreen(QualifiedNameGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitQualifierGreen(QualifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAttributeGreen(AttributeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceDeclarationGreen(NamespaceDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNamespaceBodyGreen(NamespaceBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMetamodelDeclarationGreen(MetamodelDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMetamodelPropertyListGreen(MetamodelPropertyListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMetamodelPropertyGreen(MetamodelPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMetamodelUriPropertyGreen(MetamodelUriPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitMetamodelPrefixPropertyGreen(MetamodelPrefixPropertyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDeclarationGreen(DeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumDeclarationGreen(EnumDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumBodyGreen(EnumBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumValuesGreen(EnumValuesGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumValueGreen(EnumValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitEnumMemberDeclarationGreen(EnumMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassDeclarationGreen(ClassDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassBodyGreen(ClassBodyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassAncestorsGreen(ClassAncestorsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassAncestorGreen(ClassAncestorGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassMemberDeclarationGreen(ClassMemberDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldDeclarationGreen(FieldDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldContainmentGreen(FieldContainmentGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitFieldModifierGreen(FieldModifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDefaultValueGreen(DefaultValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRedefinitionsOrSubsettingsGreen(RedefinitionsOrSubsettingsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitRedefinitionsGreen(RedefinitionsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSubsettingsGreen(SubsettingsGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNameUseListGreen(NameUseListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConstDeclarationGreen(ConstDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitConstValueGreen(ConstValueGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitReturnTypeGreen(ReturnTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeOfReferenceGreen(TypeOfReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitTypeReferenceGreen(TypeReferenceGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitSimpleTypeGreen(SimpleTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitClassTypeGreen(ClassTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitObjectTypeGreen(ObjectTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitPrimitiveTypeGreen(PrimitiveTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitVoidTypeGreen(VoidTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullableTypeGreen(NullableTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCollectionTypeGreen(CollectionTypeGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitCollectionKindGreen(CollectionKindGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationDeclarationGreen(OperationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationModifierGreen(OperationModifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationModifierBuilderGreen(OperationModifierBuilderGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitOperationModifierReadonlyGreen(OperationModifierReadonlyGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterListGreen(ParameterListGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitParameterGreen(ParameterGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitAssociationDeclarationGreen(AssociationDeclarationGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIdentifierGreen(IdentifierGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitLiteralGreen(LiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitNullLiteralGreen(NullLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitBooleanLiteralGreen(BooleanLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitIntegerLiteralGreen(IntegerLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitDecimalLiteralGreen(DecimalLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitScientificLiteralGreen(ScientificLiteralGreen node) => this.DefaultVisit(node);
		public virtual TResult VisitStringLiteralGreen(StringLiteralGreen node) => this.DefaultVisit(node);
	}
	internal class TestIncrementalCompilationInternalSyntaxFactory : InternalSyntaxFactory, MetaDslx.Languages.Antlr4Roslyn.IAntlr4SyntaxFactory
	{
		public TestIncrementalCompilationInternalSyntaxFactory(TestIncrementalCompilationSyntaxFacts syntaxFacts) 
		    : base(syntaxFacts)
		{
		}
	
	    public Antlr4.Runtime.Lexer CreateAntlr4Lexer(Antlr4.Runtime.ICharStream input)
	    {
	        return new TestIncrementalCompilationLexer(input);
	    }
	
	    public Antlr4.Runtime.Parser CreateAntlr4Parser(Antlr4.Runtime.ITokenStream input)
	    {
	        return new TestIncrementalCompilationParser(input);
	    }
	
		public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions options)
		{
			return new TestIncrementalCompilationSyntaxLexer(text, (TestIncrementalCompilationParseOptions)options ?? TestIncrementalCompilationParseOptions.Default);
		}
	
	    public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
		{
			return new TestIncrementalCompilationSyntaxParser(text, (TestIncrementalCompilationParseOptions)options ?? TestIncrementalCompilationParseOptions.Default, (TestIncrementalCompilationSyntaxNode)oldTree, changes, cancellationToken);
		}
	
	    public override Language Language => TestIncrementalCompilationLanguage.Instance;
	
		private TestIncrementalCompilationSyntaxKind ToTestIncrementalCompilationSyntaxKind(SyntaxKind kind)
	    {
	        return kind.CastUnsafe<TestIncrementalCompilationSyntaxKind>();
	    }
	
	    public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
	    {
	        var trivia = GreenSyntaxTrivia.Create(ToTestIncrementalCompilationSyntaxKind(kind), text);
	        if (!elastic)
	        {
	            return trivia;
	        }
	        return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
	    }
	
	    public override InternalSyntaxTrivia ConflictMarker(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToTestIncrementalCompilationSyntaxKind(SyntaxKind.ConflictMarkerTrivia), text);
	    }
	
	    public override InternalSyntaxTrivia DisabledText(string text)
	    {
	        return GreenSyntaxTrivia.Create(ToTestIncrementalCompilationSyntaxKind(SyntaxKind.DisabledTextTrivia), text);
	    }
	
		public override InternalSyntaxTrivia SkippedToken(GreenNode token)
		{
			return GreenStructuredSyntaxTrivia.Create(ToTestIncrementalCompilationSyntaxKind(SyntaxKind.SkippedTokensTrivia), token);
		}
	
	    public override InternalSyntaxToken Token(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.Create(ToTestIncrementalCompilationSyntaxKind(kind));
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.Create(ToTestIncrementalCompilationSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
	    {
			TestIncrementalCompilationSyntaxKind typedKind = ToTestIncrementalCompilationSyntaxKind(kind);
	        Debug.Assert(TestIncrementalCompilationLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestIncrementalCompilationLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.Identifier(typedKind, leading, text, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
	    {
			TestIncrementalCompilationSyntaxKind typedKind = ToTestIncrementalCompilationSyntaxKind(kind);
	        Debug.Assert(TestIncrementalCompilationLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestIncrementalCompilationLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && valueText == defaultText
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, valueText, trailing);
	    }
	
	    public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
	    {
			TestIncrementalCompilationSyntaxKind typedKind = ToTestIncrementalCompilationSyntaxKind(kind);
	        Debug.Assert(TestIncrementalCompilationLanguage.Instance.SyntaxFacts.IsToken(typedKind));
	        string defaultText = TestIncrementalCompilationLanguage.Instance.SyntaxFacts.GetText(typedKind);
	        return typedKind >= GreenSyntaxToken.FirstTokenWithWellKnownText && typedKind <= GreenSyntaxToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
	            ? Token(leading, kind, trailing)
	            : GreenSyntaxToken.WithValue(typedKind, leading, text, value, trailing);
	    }
	
	    public override InternalSyntaxToken MissingToken(SyntaxKind kind)
	    {
	        return GreenSyntaxToken.CreateMissing(ToTestIncrementalCompilationSyntaxKind(kind), null, null);
	    }
	
	    public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
	    {
	        return GreenSyntaxToken.CreateMissing(ToTestIncrementalCompilationSyntaxKind(kind), leading, trailing);
	    }
	
	    public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
	    {
	        return GreenSyntaxToken.WithValue(ToTestIncrementalCompilationSyntaxKind(SyntaxKind.BadToken), leading, text, text, trailing);
	    }
	
	    public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
	    {
	        return GreenSyntaxToken.GetWellKnownTokens();
	    }
	
	
	    internal InternalSyntaxToken TAsterisk(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal InternalSyntaxToken TAsterisk(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal InternalSyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LInteger, text, null);
	    }
	
	    internal InternalSyntaxToken LInteger(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDecimal, text, null);
	    }
	
	    internal InternalSyntaxToken LDecimal(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LScientific, text, null);
	    }
	
	    internal InternalSyntaxToken LScientific(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDateTime, text, null);
	    }
	
	    internal InternalSyntaxToken LDateTime(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDate, text, null);
	    }
	
	    internal InternalSyntaxToken LDate(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LDate, text, value, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LTime, text, null);
	    }
	
	    internal InternalSyntaxToken LTime(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LTime, text, value, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LRegularString, text, null);
	    }
	
	    internal InternalSyntaxToken LRegularString(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LGuid, text, null);
	    }
	
	    internal InternalSyntaxToken LGuid(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal InternalSyntaxToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal InternalSyntaxToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LCrLf, text, null);
	    }
	
	    internal InternalSyntaxToken LCrLf(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal InternalSyntaxToken LLineEnd(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal InternalSyntaxToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LComment, text, null);
	    }
	
	    internal InternalSyntaxToken LComment(string text, object value)
	    {
	        return Token(null, TestIncrementalCompilationSyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eOF)
	    {
	#if DEBUG
			if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
			if (eOF == null) throw new ArgumentNullException(nameof(eOF));
			if (eOF.Kind != TestIncrementalCompilationSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Main, namespaceDeclaration, eOF, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(TestIncrementalCompilationSyntaxKind.Main, namespaceDeclaration, eOF);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(TestIncrementalCompilationSyntaxKind.Name, identifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(TestIncrementalCompilationSyntaxKind.QualifiedName, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Qualifier, identifier.Node, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(TestIncrementalCompilationSyntaxKind.Qualifier, identifier.Node);
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
			if (tOpenBracket.Kind != TestIncrementalCompilationSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
			if (tCloseBracket.Kind != TestIncrementalCompilationSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Attribute, tOpenBracket, qualifier, tCloseBracket, out hash);
			if (cached != null) return (AttributeGreen)cached;
			var result = new AttributeGreen(TestIncrementalCompilationSyntaxKind.Attribute, tOpenBracket, qualifier, tCloseBracket);
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
			if (kNamespace.Kind != TestIncrementalCompilationSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
			if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
	#endif
	        return new NamespaceDeclarationGreen(TestIncrementalCompilationSyntaxKind.NamespaceDeclaration, attribute.Node, kNamespace, qualifiedName, namespaceBody);
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<DeclarationGreen> declaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestIncrementalCompilationSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (metamodelDeclaration == null) throw new ArgumentNullException(nameof(metamodelDeclaration));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestIncrementalCompilationSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
	        return new NamespaceBodyGreen(TestIncrementalCompilationSyntaxKind.NamespaceBody, tOpenBrace, metamodelDeclaration, declaration.Node, tCloseBrace);
	    }
	
		public MetamodelDeclarationGreen MetamodelDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kMetamodel == null) throw new ArgumentNullException(nameof(kMetamodel));
			if (kMetamodel.Kind != TestIncrementalCompilationSyntaxKind.KMetamodel) throw new ArgumentException(nameof(kMetamodel));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen != null && tOpenParen.Kind != TestIncrementalCompilationSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen != null && tCloseParen.Kind != TestIncrementalCompilationSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestIncrementalCompilationSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new MetamodelDeclarationGreen(TestIncrementalCompilationSyntaxKind.MetamodelDeclaration, attribute.Node, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
	    }
	
		public MetamodelPropertyListGreen MetamodelPropertyList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<MetamodelPropertyGreen> metamodelProperty)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelPropertyList, metamodelProperty.Node, out hash);
			if (cached != null) return (MetamodelPropertyListGreen)cached;
			var result = new MetamodelPropertyListGreen(TestIncrementalCompilationSyntaxKind.MetamodelPropertyList, metamodelProperty.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MetamodelPropertyGreen MetamodelProperty(MetamodelUriPropertyGreen metamodelUriProperty)
	    {
	#if DEBUG
		    if (metamodelUriProperty == null) throw new ArgumentNullException(nameof(metamodelUriProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelProperty, metamodelUriProperty, out hash);
			if (cached != null) return (MetamodelPropertyGreen)cached;
			var result = new MetamodelPropertyGreen(TestIncrementalCompilationSyntaxKind.MetamodelProperty, metamodelUriProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MetamodelPropertyGreen MetamodelProperty(MetamodelPrefixPropertyGreen metamodelPrefixProperty)
	    {
	#if DEBUG
		    if (metamodelPrefixProperty == null) throw new ArgumentNullException(nameof(metamodelPrefixProperty));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelProperty, metamodelPrefixProperty, out hash);
			if (cached != null) return (MetamodelPropertyGreen)cached;
			var result = new MetamodelPropertyGreen(TestIncrementalCompilationSyntaxKind.MetamodelProperty, null, metamodelPrefixProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MetamodelUriPropertyGreen MetamodelUriProperty(InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (iUri == null) throw new ArgumentNullException(nameof(iUri));
			if (iUri.Kind != TestIncrementalCompilationSyntaxKind.IUri) throw new ArgumentException(nameof(iUri));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != TestIncrementalCompilationSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelUriProperty, iUri, tAssign, stringLiteral, out hash);
			if (cached != null) return (MetamodelUriPropertyGreen)cached;
			var result = new MetamodelUriPropertyGreen(TestIncrementalCompilationSyntaxKind.MetamodelUriProperty, iUri, tAssign, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MetamodelPrefixPropertyGreen MetamodelPrefixProperty(InternalSyntaxToken iPrefix, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (iPrefix == null) throw new ArgumentNullException(nameof(iPrefix));
			if (iPrefix.Kind != TestIncrementalCompilationSyntaxKind.IPrefix) throw new ArgumentException(nameof(iPrefix));
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != TestIncrementalCompilationSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.MetamodelPrefixProperty, iPrefix, tAssign, stringLiteral, out hash);
			if (cached != null) return (MetamodelPrefixPropertyGreen)cached;
			var result = new MetamodelPrefixPropertyGreen(TestIncrementalCompilationSyntaxKind.MetamodelPrefixProperty, iPrefix, tAssign, stringLiteral);
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
			return new DeclarationGreen(TestIncrementalCompilationSyntaxKind.Declaration, enumDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ClassDeclarationGreen classDeclaration)
	    {
	#if DEBUG
		    if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
	#endif
			return new DeclarationGreen(TestIncrementalCompilationSyntaxKind.Declaration, null, classDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(AssociationDeclarationGreen associationDeclaration)
	    {
	#if DEBUG
		    if (associationDeclaration == null) throw new ArgumentNullException(nameof(associationDeclaration));
	#endif
			return new DeclarationGreen(TestIncrementalCompilationSyntaxKind.Declaration, null, null, associationDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(ConstDeclarationGreen constDeclaration)
	    {
	#if DEBUG
		    if (constDeclaration == null) throw new ArgumentNullException(nameof(constDeclaration));
	#endif
			return new DeclarationGreen(TestIncrementalCompilationSyntaxKind.Declaration, null, null, null, constDeclaration);
	    }
	
		public EnumDeclarationGreen EnumDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	    {
	#if DEBUG
			if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
			if (kEnum.Kind != TestIncrementalCompilationSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
	#endif
	        return new EnumDeclarationGreen(TestIncrementalCompilationSyntaxKind.EnumDeclaration, attribute.Node, kEnum, name, enumBody);
	    }
	
		public EnumBodyGreen EnumBody(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<EnumMemberDeclarationGreen> enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestIncrementalCompilationSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (enumValues == null) throw new ArgumentNullException(nameof(enumValues));
			if (tSemicolon != null && tSemicolon.Kind != TestIncrementalCompilationSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestIncrementalCompilationSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
	        return new EnumBodyGreen(TestIncrementalCompilationSyntaxKind.EnumBody, tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration.Node, tCloseBrace);
	    }
	
		public EnumValuesGreen EnumValues(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<EnumValueGreen> enumValue)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumValues, enumValue.Node, out hash);
			if (cached != null) return (EnumValuesGreen)cached;
			var result = new EnumValuesGreen(TestIncrementalCompilationSyntaxKind.EnumValues, enumValue.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumValue, attribute.Node, name, out hash);
			if (cached != null) return (EnumValueGreen)cached;
			var result = new EnumValueGreen(TestIncrementalCompilationSyntaxKind.EnumValue, attribute.Node, name);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.EnumMemberDeclaration, operationDeclaration, out hash);
			if (cached != null) return (EnumMemberDeclarationGreen)cached;
			var result = new EnumMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind.EnumMemberDeclaration, operationDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassDeclarationGreen ClassDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	#if DEBUG
			if (kAbstract != null && kAbstract.Kind != TestIncrementalCompilationSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
			if (kClass == null) throw new ArgumentNullException(nameof(kClass));
			if (kClass.Kind != TestIncrementalCompilationSyntaxKind.KClass) throw new ArgumentException(nameof(kClass));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tColon != null && tColon.Kind != TestIncrementalCompilationSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
			if (classBody == null) throw new ArgumentNullException(nameof(classBody));
	#endif
	        return new ClassDeclarationGreen(TestIncrementalCompilationSyntaxKind.ClassDeclaration, attribute.Node, kAbstract, kClass, name, tColon, classAncestors, classBody);
	    }
	
		public ClassBodyGreen ClassBody(InternalSyntaxToken tOpenBrace, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<ClassMemberDeclarationGreen> classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	#if DEBUG
			if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
			if (tOpenBrace.Kind != TestIncrementalCompilationSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
			if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
			if (tCloseBrace.Kind != TestIncrementalCompilationSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassBody, tOpenBrace, classMemberDeclaration.Node, tCloseBrace, out hash);
			if (cached != null) return (ClassBodyGreen)cached;
			var result = new ClassBodyGreen(TestIncrementalCompilationSyntaxKind.ClassBody, tOpenBrace, classMemberDeclaration.Node, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassAncestorsGreen ClassAncestors(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ClassAncestorGreen> classAncestor)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassAncestors, classAncestor.Node, out hash);
			if (cached != null) return (ClassAncestorsGreen)cached;
			var result = new ClassAncestorsGreen(TestIncrementalCompilationSyntaxKind.ClassAncestors, classAncestor.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassAncestor, qualifier, out hash);
			if (cached != null) return (ClassAncestorGreen)cached;
			var result = new ClassAncestorGreen(TestIncrementalCompilationSyntaxKind.ClassAncestor, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassMemberDeclaration, fieldDeclaration, out hash);
			if (cached != null) return (ClassMemberDeclarationGreen)cached;
			var result = new ClassMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind.ClassMemberDeclaration, fieldDeclaration, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassMemberDeclaration, operationDeclaration, out hash);
			if (cached != null) return (ClassMemberDeclarationGreen)cached;
			var result = new ClassMemberDeclarationGreen(TestIncrementalCompilationSyntaxKind.ClassMemberDeclaration, null, operationDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldDeclarationGreen FieldDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, FieldContainmentGreen fieldContainment, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, DefaultValueGreen defaultValue, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<RedefinitionsOrSubsettingsGreen> redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestIncrementalCompilationSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new FieldDeclarationGreen(TestIncrementalCompilationSyntaxKind.FieldDeclaration, attribute.Node, fieldContainment, fieldModifier, typeReference, name, defaultValue, redefinitionsOrSubsettings.Node, tSemicolon);
	    }
	
		public FieldContainmentGreen FieldContainment(InternalSyntaxToken kContainment)
	    {
	#if DEBUG
			if (kContainment == null) throw new ArgumentNullException(nameof(kContainment));
			if (kContainment.Kind != TestIncrementalCompilationSyntaxKind.KContainment) throw new ArgumentException(nameof(kContainment));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.FieldContainment, kContainment, out hash);
			if (cached != null) return (FieldContainmentGreen)cached;
			var result = new FieldContainmentGreen(TestIncrementalCompilationSyntaxKind.FieldContainment, kContainment);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.FieldModifier, fieldModifier, out hash);
			if (cached != null) return (FieldModifierGreen)cached;
			var result = new FieldModifierGreen(TestIncrementalCompilationSyntaxKind.FieldModifier, fieldModifier);
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
			if (tAssign.Kind != TestIncrementalCompilationSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.DefaultValue, tAssign, stringLiteral, out hash);
			if (cached != null) return (DefaultValueGreen)cached;
			var result = new DefaultValueGreen(TestIncrementalCompilationSyntaxKind.DefaultValue, tAssign, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RedefinitionsOrSubsettingsGreen RedefinitionsOrSubsettings(RedefinitionsGreen redefinitions)
	    {
	#if DEBUG
		    if (redefinitions == null) throw new ArgumentNullException(nameof(redefinitions));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.RedefinitionsOrSubsettings, redefinitions, out hash);
			if (cached != null) return (RedefinitionsOrSubsettingsGreen)cached;
			var result = new RedefinitionsOrSubsettingsGreen(TestIncrementalCompilationSyntaxKind.RedefinitionsOrSubsettings, redefinitions, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RedefinitionsOrSubsettingsGreen RedefinitionsOrSubsettings(SubsettingsGreen subsettings)
	    {
	#if DEBUG
		    if (subsettings == null) throw new ArgumentNullException(nameof(subsettings));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.RedefinitionsOrSubsettings, subsettings, out hash);
			if (cached != null) return (RedefinitionsOrSubsettingsGreen)cached;
			var result = new RedefinitionsOrSubsettingsGreen(TestIncrementalCompilationSyntaxKind.RedefinitionsOrSubsettings, null, subsettings);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RedefinitionsGreen Redefinitions(InternalSyntaxToken kRedefines, NameUseListGreen nameUseList)
	    {
	#if DEBUG
			if (kRedefines == null) throw new ArgumentNullException(nameof(kRedefines));
			if (kRedefines.Kind != TestIncrementalCompilationSyntaxKind.KRedefines) throw new ArgumentException(nameof(kRedefines));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Redefinitions, kRedefines, nameUseList, out hash);
			if (cached != null) return (RedefinitionsGreen)cached;
			var result = new RedefinitionsGreen(TestIncrementalCompilationSyntaxKind.Redefinitions, kRedefines, nameUseList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SubsettingsGreen Subsettings(InternalSyntaxToken kSubsets, NameUseListGreen nameUseList)
	    {
	#if DEBUG
			if (kSubsets == null) throw new ArgumentNullException(nameof(kSubsets));
			if (kSubsets.Kind != TestIncrementalCompilationSyntaxKind.KSubsets) throw new ArgumentException(nameof(kSubsets));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Subsettings, kSubsets, nameUseList, out hash);
			if (cached != null) return (SubsettingsGreen)cached;
			var result = new SubsettingsGreen(TestIncrementalCompilationSyntaxKind.Subsettings, kSubsets, nameUseList);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NameUseList, qualifier.Node, out hash);
			if (cached != null) return (NameUseListGreen)cached;
			var result = new NameUseListGreen(TestIncrementalCompilationSyntaxKind.NameUseList, qualifier.Node);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConstDeclarationGreen ConstDeclaration(InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, ConstValueGreen constValue, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kConst == null) throw new ArgumentNullException(nameof(kConst));
			if (kConst.Kind != TestIncrementalCompilationSyntaxKind.KConst) throw new ArgumentException(nameof(kConst));
			if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestIncrementalCompilationSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new ConstDeclarationGreen(TestIncrementalCompilationSyntaxKind.ConstDeclaration, kConst, typeReference, name, constValue, tSemicolon);
	    }
	
		public ConstValueGreen ConstValue(InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
			if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
			if (tAssign.Kind != TestIncrementalCompilationSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
			if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ConstValue, tAssign, stringLiteral, out hash);
			if (cached != null) return (ConstValueGreen)cached;
			var result = new ConstValueGreen(TestIncrementalCompilationSyntaxKind.ConstValue, tAssign, stringLiteral);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(TestIncrementalCompilationSyntaxKind.ReturnType, typeReference, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(TestIncrementalCompilationSyntaxKind.ReturnType, null, voidType);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.TypeOfReference, typeReference, out hash);
			if (cached != null) return (TypeOfReferenceGreen)cached;
			var result = new TypeOfReferenceGreen(TestIncrementalCompilationSyntaxKind.TypeOfReference, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(CollectionTypeGreen collectionType)
	    {
	#if DEBUG
		    if (collectionType == null) throw new ArgumentNullException(nameof(collectionType));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.TypeReference, collectionType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(TestIncrementalCompilationSyntaxKind.TypeReference, collectionType, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.TypeReference, simpleType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(TestIncrementalCompilationSyntaxKind.TypeReference, null, simpleType);
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
			return new SimpleTypeGreen(TestIncrementalCompilationSyntaxKind.SimpleType, primitiveType, null, null, null);
	    }
	
		public SimpleTypeGreen SimpleType(ObjectTypeGreen objectType)
	    {
	#if DEBUG
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
	#endif
			return new SimpleTypeGreen(TestIncrementalCompilationSyntaxKind.SimpleType, null, objectType, null, null);
	    }
	
		public SimpleTypeGreen SimpleType(NullableTypeGreen nullableType)
	    {
	#if DEBUG
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
	#endif
			return new SimpleTypeGreen(TestIncrementalCompilationSyntaxKind.SimpleType, null, null, nullableType, null);
	    }
	
		public SimpleTypeGreen SimpleType(ClassTypeGreen classType)
	    {
	#if DEBUG
		    if (classType == null) throw new ArgumentNullException(nameof(classType));
	#endif
			return new SimpleTypeGreen(TestIncrementalCompilationSyntaxKind.SimpleType, null, null, null, classType);
	    }
	
		public ClassTypeGreen ClassType(QualifierGreen qualifier)
	    {
	#if DEBUG
			if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ClassType, qualifier, out hash);
			if (cached != null) return (ClassTypeGreen)cached;
			var result = new ClassTypeGreen(TestIncrementalCompilationSyntaxKind.ClassType, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ObjectType, objectType, out hash);
			if (cached != null) return (ObjectTypeGreen)cached;
			var result = new ObjectTypeGreen(TestIncrementalCompilationSyntaxKind.ObjectType, objectType);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.PrimitiveType, primitiveType, out hash);
			if (cached != null) return (PrimitiveTypeGreen)cached;
			var result = new PrimitiveTypeGreen(TestIncrementalCompilationSyntaxKind.PrimitiveType, primitiveType);
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
			if (kVoid.Kind != TestIncrementalCompilationSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(TestIncrementalCompilationSyntaxKind.VoidType, kVoid);
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
			if (tQuestion.Kind != TestIncrementalCompilationSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NullableType, primitiveType, tQuestion, out hash);
			if (cached != null) return (NullableTypeGreen)cached;
			var result = new NullableTypeGreen(TestIncrementalCompilationSyntaxKind.NullableType, primitiveType, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CollectionTypeGreen CollectionType(CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan)
	    {
	#if DEBUG
			if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
			if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
			if (tLessThan.Kind != TestIncrementalCompilationSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
			if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
			if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
			if (tGreaterThan.Kind != TestIncrementalCompilationSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
	#endif
	        return new CollectionTypeGreen(TestIncrementalCompilationSyntaxKind.CollectionType, collectionKind, tLessThan, simpleType, tGreaterThan);
	    }
	
		public CollectionKindGreen CollectionKind(InternalSyntaxToken collectionKind)
	    {
	#if DEBUG
			if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.CollectionKind, collectionKind, out hash);
			if (cached != null) return (CollectionKindGreen)cached;
			var result = new CollectionKindGreen(TestIncrementalCompilationSyntaxKind.CollectionKind, collectionKind);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationDeclarationGreen OperationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<OperationModifierGreen> operationModifier, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (returnType == null) throw new ArgumentNullException(nameof(returnType));
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
			if (tOpenParen.Kind != TestIncrementalCompilationSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
			if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
			if (tCloseParen.Kind != TestIncrementalCompilationSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestIncrementalCompilationSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new OperationDeclarationGreen(TestIncrementalCompilationSyntaxKind.OperationDeclaration, attribute.Node, operationModifier.Node, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	    }
	
		public OperationModifierGreen OperationModifier(OperationModifierBuilderGreen operationModifierBuilder)
	    {
	#if DEBUG
		    if (operationModifierBuilder == null) throw new ArgumentNullException(nameof(operationModifierBuilder));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifier, operationModifierBuilder, out hash);
			if (cached != null) return (OperationModifierGreen)cached;
			var result = new OperationModifierGreen(TestIncrementalCompilationSyntaxKind.OperationModifier, operationModifierBuilder, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationModifierGreen OperationModifier(OperationModifierReadonlyGreen operationModifierReadonly)
	    {
	#if DEBUG
		    if (operationModifierReadonly == null) throw new ArgumentNullException(nameof(operationModifierReadonly));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifier, operationModifierReadonly, out hash);
			if (cached != null) return (OperationModifierGreen)cached;
			var result = new OperationModifierGreen(TestIncrementalCompilationSyntaxKind.OperationModifier, null, operationModifierReadonly);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationModifierBuilderGreen OperationModifierBuilder(InternalSyntaxToken kBuilder)
	    {
	#if DEBUG
			if (kBuilder == null) throw new ArgumentNullException(nameof(kBuilder));
			if (kBuilder.Kind != TestIncrementalCompilationSyntaxKind.KBuilder) throw new ArgumentException(nameof(kBuilder));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifierBuilder, kBuilder, out hash);
			if (cached != null) return (OperationModifierBuilderGreen)cached;
			var result = new OperationModifierBuilderGreen(TestIncrementalCompilationSyntaxKind.OperationModifierBuilder, kBuilder);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationModifierReadonlyGreen OperationModifierReadonly(InternalSyntaxToken kReadonly)
	    {
	#if DEBUG
			if (kReadonly == null) throw new ArgumentNullException(nameof(kReadonly));
			if (kReadonly.Kind != TestIncrementalCompilationSyntaxKind.KReadonly) throw new ArgumentException(nameof(kReadonly));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.OperationModifierReadonly, kReadonly, out hash);
			if (cached != null) return (OperationModifierReadonlyGreen)cached;
			var result = new OperationModifierReadonlyGreen(TestIncrementalCompilationSyntaxKind.OperationModifierReadonly, kReadonly);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParameterListGreen ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList<ParameterGreen> parameter)
	    {
	#if DEBUG
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ParameterList, parameter.Node, out hash);
			if (cached != null) return (ParameterListGreen)cached;
			var result = new ParameterListGreen(TestIncrementalCompilationSyntaxKind.ParameterList, parameter.Node);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Parameter, attribute.Node, typeReference, name, out hash);
			if (cached != null) return (ParameterGreen)cached;
			var result = new ParameterGreen(TestIncrementalCompilationSyntaxKind.Parameter, attribute.Node, typeReference, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssociationDeclarationGreen AssociationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<AttributeGreen> attribute, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	#if DEBUG
			if (kAssociation == null) throw new ArgumentNullException(nameof(kAssociation));
			if (kAssociation.Kind != TestIncrementalCompilationSyntaxKind.KAssociation) throw new ArgumentException(nameof(kAssociation));
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (kWith == null) throw new ArgumentNullException(nameof(kWith));
			if (kWith.Kind != TestIncrementalCompilationSyntaxKind.KWith) throw new ArgumentException(nameof(kWith));
			if (target == null) throw new ArgumentNullException(nameof(target));
			if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
			if (tSemicolon.Kind != TestIncrementalCompilationSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
	#endif
	        return new AssociationDeclarationGreen(TestIncrementalCompilationSyntaxKind.AssociationDeclaration, attribute.Node, kAssociation, source, kWith, target, tSemicolon);
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken identifier)
	    {
	#if DEBUG
			if (identifier == null) throw new ArgumentNullException(nameof(identifier));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Identifier, identifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(TestIncrementalCompilationSyntaxKind.Identifier, identifier);
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
			return new LiteralGreen(TestIncrementalCompilationSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral)
	    {
	#if DEBUG
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
	#endif
			return new LiteralGreen(TestIncrementalCompilationSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral)
	    {
	#if DEBUG
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
	#endif
			return new LiteralGreen(TestIncrementalCompilationSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral)
	    {
	#if DEBUG
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
	#endif
			return new LiteralGreen(TestIncrementalCompilationSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral)
	    {
	#if DEBUG
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
	#endif
			return new LiteralGreen(TestIncrementalCompilationSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral)
	    {
	#if DEBUG
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
	#endif
			return new LiteralGreen(TestIncrementalCompilationSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull)
	    {
	#if DEBUG
			if (kNull == null) throw new ArgumentNullException(nameof(kNull));
			if (kNull.Kind != TestIncrementalCompilationSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(TestIncrementalCompilationSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(TestIncrementalCompilationSyntaxKind.BooleanLiteral, booleanLiteral);
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
			if (lInteger.Kind != TestIncrementalCompilationSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(TestIncrementalCompilationSyntaxKind.IntegerLiteral, lInteger);
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
			if (lDecimal.Kind != TestIncrementalCompilationSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(TestIncrementalCompilationSyntaxKind.DecimalLiteral, lDecimal);
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
			if (lScientific.Kind != TestIncrementalCompilationSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(TestIncrementalCompilationSyntaxKind.ScientificLiteral, lScientific);
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
			if (lRegularString.Kind != TestIncrementalCompilationSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)(TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.StringLiteral, lRegularString, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(TestIncrementalCompilationSyntaxKind.StringLiteral, lRegularString);
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
				typeof(MetamodelDeclarationGreen),
				typeof(MetamodelPropertyListGreen),
				typeof(MetamodelPropertyGreen),
				typeof(MetamodelUriPropertyGreen),
				typeof(MetamodelPrefixPropertyGreen),
				typeof(DeclarationGreen),
				typeof(EnumDeclarationGreen),
				typeof(EnumBodyGreen),
				typeof(EnumValuesGreen),
				typeof(EnumValueGreen),
				typeof(EnumMemberDeclarationGreen),
				typeof(ClassDeclarationGreen),
				typeof(ClassBodyGreen),
				typeof(ClassAncestorsGreen),
				typeof(ClassAncestorGreen),
				typeof(ClassMemberDeclarationGreen),
				typeof(FieldDeclarationGreen),
				typeof(FieldContainmentGreen),
				typeof(FieldModifierGreen),
				typeof(DefaultValueGreen),
				typeof(RedefinitionsOrSubsettingsGreen),
				typeof(RedefinitionsGreen),
				typeof(SubsettingsGreen),
				typeof(NameUseListGreen),
				typeof(ConstDeclarationGreen),
				typeof(ConstValueGreen),
				typeof(ReturnTypeGreen),
				typeof(TypeOfReferenceGreen),
				typeof(TypeReferenceGreen),
				typeof(SimpleTypeGreen),
				typeof(ClassTypeGreen),
				typeof(ObjectTypeGreen),
				typeof(PrimitiveTypeGreen),
				typeof(VoidTypeGreen),
				typeof(NullableTypeGreen),
				typeof(CollectionTypeGreen),
				typeof(CollectionKindGreen),
				typeof(OperationDeclarationGreen),
				typeof(OperationModifierGreen),
				typeof(OperationModifierBuilderGreen),
				typeof(OperationModifierReadonlyGreen),
				typeof(ParameterListGreen),
				typeof(ParameterGreen),
				typeof(AssociationDeclarationGreen),
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


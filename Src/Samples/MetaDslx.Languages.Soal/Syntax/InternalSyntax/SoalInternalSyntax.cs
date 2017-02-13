using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Languages.Soal.Syntax.InternalSyntax
{
    internal abstract class SoalGreenNode : InternalSyntaxNode
    {
        public SoalGreenNode(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, 0, diagnostics, annotations)
        {
        }

        public SoalSyntaxKind Kind
        {
            get { return (SoalSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return SoalLanguage.Instance; }
        }
    }

    internal class SoalGreenTrivia : InternalSyntaxTrivia
    {
        public SoalGreenTrivia(SoalSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        public SoalSyntaxKind Kind
        {
            get { return (SoalSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return SoalLanguage.Instance; }
        }

        public override SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index)
        {
            return new SoalSyntaxTrivia(this, parent, position, index);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new SoalGreenTrivia(this.Kind, this.Text, diagnostics, this.GetAnnotations());
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new SoalGreenTrivia(this.Kind, this.Text, this.GetDiagnostics(), annotations);
        }
    }

	public class SoalGreenToken : InternalSyntaxToken
	{
		public SoalGreenToken(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
		    : base((int)kind, diagnostics, annotations)
		{
		}
	
	    public SoalGreenToken(SoalSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base((int)kind, fullWidth, diagnostics, annotations)
	    {
	    }
	
	    public SoalSyntaxKind Kind
		{
		    get { return (SoalSyntaxKind)base.RawKind; }
		}
	
		public virtual SoalSyntaxKind ContextualKind
		{
		    get { return this.Kind; }
		}
	
	    public override string Text
	    {
	        get
	        {
	            return SoalLanguage.Instance.SyntaxFacts.GetText(this.Kind);
	        }
	    }
	
	    public override Language Language
	    {
	        get { return SoalLanguage.Instance; }
	    }
	
	    public override SyntaxToken CreateRed(SyntaxNode parent, int position, int index)
	    {
	        return new SoalSyntaxToken(this, parent, position, index);
	    }
	
	    public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	    {
	        return new SyntaxTokenWithTrivia(this.Kind, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	    }
	
	    public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	    {
	        return new SyntaxTokenWithTrivia(this.Kind, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoalGreenToken(this.Kind, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoalGreenToken(this.Kind, diagnostics, this.GetAnnotations());
	    }
	
	    internal static SoalGreenToken Create(SoalSyntaxKind kind)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!SoalLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, null, null);
	        }
	
	        return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	    }
	
	    internal static SoalGreenToken Create(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!SoalLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, leading, trailing);
	        }
	
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == SoalLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == SoalLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	        }
	
	        if (leading == SoalLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == SoalLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	        }
	
	        return new SyntaxTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static SoalGreenToken CreateMissing(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static readonly SoalSyntaxKind FirstTokenWithWellKnownText = SoalSyntaxKind.KNamespace;
	    internal static readonly SoalSyntaxKind LastTokenWithWellKnownText = SoalSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
	
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly SoalGreenToken[] s_tokensWithNoTrivia = new SoalGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SoalGreenToken[] s_tokensWithElasticTrivia = new SoalGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SoalGreenToken[] s_tokensWithSingleTrailingSpace = new SoalGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SoalGreenToken[] s_tokensWithSingleTrailingCRLF = new SoalGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	
	    static SoalGreenToken()
	    {
	        for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SoalGreenToken(kind, null, null);
	            s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, SoalLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, SoalLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, null, null);
	            s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, SoalLanguage.Instance.InternalSyntaxFactory.Space, null, null);
	            s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, SoalLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed, null, null);
	        }
	    }
	
	    internal static IEnumerable<SoalGreenToken> GetWellKnownTokens()
	    {
	        foreach (var element in s_tokensWithNoTrivia)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	
	        foreach (var element in s_tokensWithElasticTrivia)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	
	        foreach (var element in s_tokensWithSingleTrailingSpace)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	
	        foreach (var element in s_tokensWithSingleTrailingCRLF)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	    }
	
	    internal static SoalGreenToken WithText(SoalSyntaxKind kind, string text)
	    {
	        return new SyntaxTokenWithText(kind, text, null, null);
	    }
	
	    internal static SoalGreenToken WithText(SoalSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
	    {
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return WithText(kind, text);
	            }
	            else
	            {
	                return new SyntaxTokenWithTextAndTrailingTrivia(kind, text, trailing, null, null);
	            }
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, text, leading, trailing, null, null);
	    }
	
	    internal static SoalGreenToken WithText(SoalSyntaxKind kind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (valueText == text)
	        {
	            return WithText(kind, leading, text, trailing);
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, valueText, leading, trailing, null, null);
	    }
	
	    internal static SoalGreenToken WithValue<T>(SoalSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value, null, null);
	    }
	
	    internal static SoalGreenToken WithValue<T>(SoalSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing, null, null);
	    }
	
	    private class SyntaxTokenWithTrivia : SoalGreenToken
	    {
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	
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
	
	        public override GreenNode GetLeadingTrivia()
	        {
	            return this.LeadingField;
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return this.TrailingField;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class MissingTokenWithTrivia : SyntaxTokenWithTrivia
	    {
	        internal MissingTokenWithTrivia(SoalSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, leading, trailing, diagnostics, annotations)
	        {
	            this.AddFlags(NodeFlags.IsMissing);
	        }
	
	        public override string Text
	        {
	            get { return string.Empty; }
	        }
	
	        public override object Value
	        {
	            get { return null; }
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new MissingTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithText : SoalGreenToken
	    {
	        protected readonly string TextField;
	
	        internal SyntaxTokenWithText(SoalSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text.Length, diagnostics, annotations)
	        {
	            this.TextField = text;
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
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.TextField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.TextField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithText(this.Kind, this.Text, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithText(this.Kind, this.Text, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxIdentifierExtended : SyntaxTokenWithText
	    {
	        protected readonly string valueText;
	
	        internal SyntaxIdentifierExtended(SoalSyntaxKind kind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.valueText = valueText;
	        }
	
	        public override string ValueText
	        {
	            get { return this.valueText; }
	        }
	
	        public override object Value
	        {
	            get { return this.valueText; }
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxIdentifierExtended(this.Kind, this.TextField, this.valueText, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxIdentifierExtended(this.Kind, this.TextField, this.valueText, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithTextAndTrailingTrivia : SyntaxTokenWithText
	    {
	        private readonly GreenNode _trailing;
	
	        internal SyntaxTokenWithTextAndTrailingTrivia(SoalSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.TextField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrailingTrivia(this.Kind, this.TextField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTextAndTrailingTrivia(this.Kind, this.TextField, _trailing, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTextAndTrailingTrivia(this.Kind, this.TextField, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithTextAndTrivia : SyntaxIdentifierExtended
	    {
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	
	        internal SyntaxTokenWithTextAndTrivia(
	            SoalSyntaxKind kind,
	            string text,
	            string valueText,
	            GreenNode leading,
	            GreenNode trailing,
	            DiagnosticInfo[] diagnostics,
	            SyntaxAnnotation[] annotations)
	            : base(kind, text, valueText, diagnostics, annotations)
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
	
	        public override GreenNode GetLeadingTrivia()
	        {
	            return _leading;
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, _leading, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, _leading, _trailing, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, _leading, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithValue<T> : SoalGreenToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	
	        internal SyntaxTokenWithValue(SoalSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text.Length, diagnostics, annotations)
	        {
	            this.TextField = text;
	            this.ValueField = value;
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
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithValueAndTrivia<T> : SyntaxTokenWithValue<T>
	    {
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	
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
	
	        public override GreenNode GetLeadingTrivia()
	        {
	            return _leading;
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	}
	
	internal class MainGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList namespaceDeclaration;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(SoalSyntaxKind kind, InternalSyntaxNodeList namespaceDeclaration, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
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
	
	    public MainGreen(SoalSyntaxKind kind, InternalSyntaxNodeList namespaceDeclaration, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList NamespaceDeclaration { get { return this.namespaceDeclaration; } }
	    public InternalSyntaxToken Eof { get { return this.eof; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.MainSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.namespaceDeclaration;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.namespaceDeclaration, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(InternalSyntaxNodeList namespaceDeclaration, InternalSyntaxToken eof)
	    {
	        if (this.namespaceDeclaration != namespaceDeclaration ||
				this.eof != eof)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, eof);
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
	
	internal class NameDefGreen : SoalGreenNode
	{
	    private IdentifierGreen identifier;
	
	    public NameDefGreen(SoalSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameDefGreen(SoalSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NameDefSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameDefGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameDefGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NameDefGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NameDef(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameDefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifiedNameDefGreen : SoalGreenNode
	{
	    private QualifiedNameGreen qualifiedName;
	
	    public QualifiedNameDefGreen(SoalSyntaxKind kind, QualifiedNameGreen qualifiedName)
	        : base(kind, null, null)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
	    public QualifiedNameDefGreen(SoalSyntaxKind kind, QualifiedNameGreen qualifiedName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.QualifiedNameDefSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifiedName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameDefGreen(this.Kind, this.qualifiedName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameDefGreen(this.Kind, this.qualifiedName, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameDefGreen Update(QualifiedNameGreen qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.QualifiedNameDef(qualifiedName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameDefGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifiedNameGreen : SoalGreenNode
	{
	    private InternalSeparatedSyntaxNodeList identifier;
	
	    public QualifiedNameGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifiedNameGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.QualifiedNameSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameGreen Update(InternalSeparatedSyntaxNodeList identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.QualifiedName(identifier);
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
	
	internal class IdentifierListGreen : SoalGreenNode
	{
	    private InternalSeparatedSyntaxNodeList identifier;
	
	    public IdentifierListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IdentifierListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierListGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierListGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierListGreen Update(InternalSeparatedSyntaxNodeList identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.IdentifierList(identifier);
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
	
	internal class QualifiedNameListGreen : SoalGreenNode
	{
	    private InternalSeparatedSyntaxNodeList qualifiedName;
	
	    public QualifiedNameListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList qualifiedName)
	        : base(kind, null, null)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
	    public QualifiedNameListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList qualifiedName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList QualifiedName { get { return this.qualifiedName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.QualifiedNameListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifiedName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameListGreen(this.Kind, this.qualifiedName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameListGreen(this.Kind, this.qualifiedName, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameListGreen Update(InternalSeparatedSyntaxNodeList qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.QualifiedNameList(qualifiedName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AnnotationListGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	
	    public AnnotationListGreen(SoalSyntaxKind kind, InternalSyntaxNodeList annotation)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
	    }
	
	    public AnnotationListGreen(SoalSyntaxKind kind, InternalSyntaxNodeList annotation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationListGreen(this.Kind, this.annotation, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationListGreen(this.Kind, this.annotation, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationListGreen Update(InternalSyntaxNodeList annotation)
	    {
	        if (this.annotation != annotation)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationList(annotation);
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
	
	internal class ReturnAnnotationListGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList returnAnnotation;
	
	    public ReturnAnnotationListGreen(SoalSyntaxKind kind, InternalSyntaxNodeList returnAnnotation)
	        : base(kind, null, null)
	    {
			if (returnAnnotation != null)
			{
				this.AdjustFlagsAndWidth(returnAnnotation);
				this.returnAnnotation = returnAnnotation;
			}
	    }
	
	    public ReturnAnnotationListGreen(SoalSyntaxKind kind, InternalSyntaxNodeList returnAnnotation, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (returnAnnotation != null)
			{
				this.AdjustFlagsAndWidth(returnAnnotation);
				this.returnAnnotation = returnAnnotation;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList ReturnAnnotation { get { return this.returnAnnotation; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReturnAnnotationListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.returnAnnotation;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnAnnotationListGreen(this.Kind, this.returnAnnotation, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnAnnotationListGreen(this.Kind, this.returnAnnotation, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnAnnotationListGreen Update(InternalSyntaxNodeList returnAnnotation)
	    {
	        if (this.returnAnnotation != returnAnnotation)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnAnnotationList(returnAnnotation);
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
	
	internal class AnnotationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBracket;
	    private AnnotationHeadGreen annotationHead;
	    private InternalSyntaxToken tCloseBracket;
	
	    public AnnotationGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public AnnotationHeadGreen AnnotationHead { get { return this.annotationHead; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.annotationHead;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.annotationHead, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.annotationHead, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationGreen Update(InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.tOpenBracket != tOpenBracket ||
				this.annotationHead != annotationHead ||
				this.tCloseBracket != tCloseBracket)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Annotation(tOpenBracket, annotationHead, tCloseBracket);
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
	
	internal class ReturnAnnotationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken kReturn;
	    private InternalSyntaxToken tColon;
	    private AnnotationHeadGreen annotationHead;
	    private InternalSyntaxToken tCloseBracket;
	
	    public ReturnAnnotationGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken KReturn { get { return this.kReturn; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public AnnotationHeadGreen AnnotationHead { get { return this.annotationHead; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReturnAnnotationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnAnnotationGreen(this.Kind, this.tOpenBracket, this.kReturn, this.tColon, this.annotationHead, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnAnnotationGreen(this.Kind, this.tOpenBracket, this.kReturn, this.tColon, this.annotationHead, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnAnnotationGreen Update(InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.tOpenBracket != tOpenBracket ||
				this.kReturn != kReturn ||
				this.tColon != tColon ||
				this.annotationHead != annotationHead ||
				this.tCloseBracket != tCloseBracket)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnAnnotation(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
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
	
	internal class AnnotationHeadGreen : SoalGreenNode
	{
	    private IdentifierGreen identifier;
	    private AnnotationBodyGreen annotationBody;
	
	    public AnnotationHeadGreen(SoalSyntaxKind kind, IdentifierGreen identifier, AnnotationBodyGreen annotationBody)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (annotationBody != null)
			{
				this.AdjustFlagsAndWidth(annotationBody);
				this.annotationBody = annotationBody;
			}
	    }
	
	    public AnnotationHeadGreen(SoalSyntaxKind kind, IdentifierGreen identifier, AnnotationBodyGreen annotationBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (annotationBody != null)
			{
				this.AdjustFlagsAndWidth(annotationBody);
				this.annotationBody = annotationBody;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public AnnotationBodyGreen AnnotationBody { get { return this.annotationBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationHeadSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.annotationBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationHeadGreen(this.Kind, this.identifier, this.annotationBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationHeadGreen(this.Kind, this.identifier, this.annotationBody, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationHeadGreen Update(IdentifierGreen identifier, AnnotationBodyGreen annotationBody)
	    {
	        if (this.identifier != identifier ||
				this.annotationBody != annotationBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationHead(identifier, annotationBody);
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
	
	internal class AnnotationBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenParen;
	    private AnnotationPropertyListGreen annotationPropertyList;
	    private InternalSyntaxToken tCloseParen;
	
	    public AnnotationBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public AnnotationPropertyListGreen AnnotationPropertyList { get { return this.annotationPropertyList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.annotationPropertyList;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationBodyGreen(this.Kind, this.tOpenParen, this.annotationPropertyList, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationBodyGreen(this.Kind, this.tOpenParen, this.annotationPropertyList, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationBodyGreen Update(InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen)
	    {
	        if (this.tOpenParen != tOpenParen ||
				this.annotationPropertyList != annotationPropertyList ||
				this.tCloseParen != tCloseParen)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationBody(tOpenParen, annotationPropertyList, tCloseParen);
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
	
	internal class AnnotationPropertyListGreen : SoalGreenNode
	{
	    private InternalSeparatedSyntaxNodeList annotationProperty;
	
	    public AnnotationPropertyListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList annotationProperty)
	        : base(kind, null, null)
	    {
			if (annotationProperty != null)
			{
				this.AdjustFlagsAndWidth(annotationProperty);
				this.annotationProperty = annotationProperty;
			}
	    }
	
	    public AnnotationPropertyListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList annotationProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotationProperty != null)
			{
				this.AdjustFlagsAndWidth(annotationProperty);
				this.annotationProperty = annotationProperty;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList AnnotationProperty { get { return this.annotationProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationPropertyListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationPropertyListGreen(this.Kind, this.annotationProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationPropertyListGreen(this.Kind, this.annotationProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationPropertyListGreen Update(InternalSeparatedSyntaxNodeList annotationProperty)
	    {
	        if (this.annotationProperty != annotationProperty)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyList(annotationProperty);
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
	
	internal class AnnotationPropertyGreen : SoalGreenNode
	{
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private AnnotationPropertyValueGreen annotationPropertyValue;
	
	    public AnnotationPropertyGreen(SoalSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue)
	        : base(kind, null, null)
	    {
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
			if (annotationPropertyValue != null)
			{
				this.AdjustFlagsAndWidth(annotationPropertyValue);
				this.annotationPropertyValue = annotationPropertyValue;
			}
	    }
	
	    public AnnotationPropertyGreen(SoalSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (annotationPropertyValue != null)
			{
				this.AdjustFlagsAndWidth(annotationPropertyValue);
				this.annotationPropertyValue = annotationPropertyValue;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public AnnotationPropertyValueGreen AnnotationPropertyValue { get { return this.annotationPropertyValue; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.tAssign;
	            case 2: return this.annotationPropertyValue;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationPropertyGreen(this.Kind, this.identifier, this.tAssign, this.annotationPropertyValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationPropertyGreen(this.Kind, this.identifier, this.tAssign, this.annotationPropertyValue, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationPropertyGreen Update(IdentifierGreen identifier, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue)
	    {
	        if (this.identifier != identifier ||
				this.tAssign != tAssign ||
				this.annotationPropertyValue != annotationPropertyValue)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationProperty(identifier, tAssign, annotationPropertyValue);
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
	
	internal class AnnotationPropertyValueGreen : SoalGreenNode
	{
	    private ConstantValueGreen constantValue;
	    private TypeofValueGreen typeofValue;
	
	    public AnnotationPropertyValueGreen(SoalSyntaxKind kind, ConstantValueGreen constantValue, TypeofValueGreen typeofValue)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public ConstantValueGreen ConstantValue { get { return this.constantValue; } }
	    public TypeofValueGreen TypeofValue { get { return this.typeofValue; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AnnotationPropertyValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.constantValue;
	            case 1: return this.typeofValue;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationPropertyValueGreen(this.Kind, this.constantValue, this.typeofValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationPropertyValueGreen(this.Kind, this.constantValue, this.typeofValue, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationPropertyValueGreen Update(ConstantValueGreen constantValue)
	    {
	        if (this.constantValue != constantValue)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyValue(constantValue);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyValue(typeofValue);
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
	
	internal class NamespaceDeclarationGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameDefGreen qualifiedNameDef;
	    private InternalSyntaxToken tAssign;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tColon;
	    private StringLiteralGreen stringLiteral;
	    private NamespaceBodyGreen namespaceBody;
	
	    public NamespaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameDefGreen qualifiedNameDef, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tColon, StringLiteralGreen stringLiteral, NamespaceBodyGreen namespaceBody)
	        : base(kind, null, null)
	    {
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
			if (qualifiedNameDef != null)
			{
				this.AdjustFlagsAndWidth(qualifiedNameDef);
				this.qualifiedNameDef = qualifiedNameDef;
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
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
	    public NamespaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameDefGreen qualifiedNameDef, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tColon, StringLiteralGreen stringLiteral, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (qualifiedNameDef != null)
			{
				this.AdjustFlagsAndWidth(qualifiedNameDef);
				this.qualifiedNameDef = qualifiedNameDef;
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
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
		public override int SlotCount { get { return 8; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameDefGreen QualifiedNameDef { get { return this.qualifiedNameDef; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NamespaceDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kNamespace;
	            case 2: return this.qualifiedNameDef;
	            case 3: return this.tAssign;
	            case 4: return this.identifier;
	            case 5: return this.tColon;
	            case 6: return this.stringLiteral;
	            case 7: return this.namespaceBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.annotationList, this.kNamespace, this.qualifiedNameDef, this.tAssign, this.identifier, this.tColon, this.stringLiteral, this.namespaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.annotationList, this.kNamespace, this.qualifiedNameDef, this.tAssign, this.identifier, this.tColon, this.stringLiteral, this.namespaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameDefGreen qualifiedNameDef, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tColon, StringLiteralGreen stringLiteral, NamespaceBodyGreen namespaceBody)
	    {
	        if (this.annotationList != annotationList ||
				this.kNamespace != kNamespace ||
				this.qualifiedNameDef != qualifiedNameDef ||
				this.tAssign != tAssign ||
				this.identifier != identifier ||
				this.tColon != tColon ||
				this.stringLiteral != stringLiteral ||
				this.namespaceBody != namespaceBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(annotationList, kNamespace, qualifiedNameDef, tAssign, identifier, tColon, stringLiteral, namespaceBody);
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
	
	internal class NamespaceBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList declaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public NamespaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList Declaration { get { return this.declaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NamespaceBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.declaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.declaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.declaration != declaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
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
	
	internal class DeclarationGreen : SoalGreenNode
	{
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
	
		public override int SlotCount { get { return 10; } }
	
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
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.structDeclaration, this.databaseDeclaration, this.interfaceDeclaration, this.componentDeclaration, this.compositeDeclaration, this.assemblyDeclaration, this.bindingDeclaration, this.endpointDeclaration, this.deploymentDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.structDeclaration, this.databaseDeclaration, this.interfaceDeclaration, this.componentDeclaration, this.compositeDeclaration, this.assemblyDeclaration, this.bindingDeclaration, this.endpointDeclaration, this.deploymentDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(EnumDeclarationGreen enumDeclaration)
	    {
	        if (this.enumDeclaration != enumDeclaration)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(enumDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(structDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(databaseDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(interfaceDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(componentDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(compositeDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(assemblyDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(bindingDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(endpointDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Declaration(deploymentDeclaration);
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
	
	internal class EnumDeclarationGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kEnum;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private EnumBodyGreen enumBody;
	
	    public EnumDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EnumBodyGreen enumBody)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (enumBody != null)
			{
				this.AdjustFlagsAndWidth(enumBody);
				this.enumBody = enumBody;
			}
	    }
	
	    public EnumDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EnumBodyGreen enumBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (enumBody != null)
			{
				this.AdjustFlagsAndWidth(enumBody);
				this.enumBody = enumBody;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KEnum { get { return this.kEnum; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public EnumBodyGreen EnumBody { get { return this.enumBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kEnum;
	            case 2: return this.nameDef;
	            case 3: return this.tColon;
	            case 4: return this.qualifiedName;
	            case 5: return this.enumBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.annotationList, this.kEnum, this.nameDef, this.tColon, this.qualifiedName, this.enumBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.annotationList, this.kEnum, this.nameDef, this.tColon, this.qualifiedName, this.enumBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EnumBodyGreen enumBody)
	    {
	        if (this.annotationList != annotationList ||
				this.kEnum != kEnum ||
				this.nameDef != nameDef ||
				this.tColon != tColon ||
				this.qualifiedName != qualifiedName ||
				this.enumBody != enumBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(annotationList, kEnum, nameDef, tColon, qualifiedName, enumBody);
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
	
	internal class EnumBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private EnumLiteralsGreen enumLiterals;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EnumBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public EnumLiteralsGreen EnumLiterals { get { return this.enumLiterals; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.enumLiterals;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumLiterals, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumLiterals, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumBodyGreen Update(InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.enumLiterals != enumLiterals ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumBody(tOpenBrace, enumLiterals, tCloseBrace);
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
	
	internal class EnumLiteralsGreen : SoalGreenNode
	{
	    private InternalSeparatedSyntaxNodeList enumLiteral;
	
	    public EnumLiteralsGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList enumLiteral)
	        : base(kind, null, null)
	    {
			if (enumLiteral != null)
			{
				this.AdjustFlagsAndWidth(enumLiteral);
				this.enumLiteral = enumLiteral;
			}
	    }
	
	    public EnumLiteralsGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList enumLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (enumLiteral != null)
			{
				this.AdjustFlagsAndWidth(enumLiteral);
				this.enumLiteral = enumLiteral;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList EnumLiteral { get { return this.enumLiteral; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumLiteralsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumLiteral;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumLiteralsGreen(this.Kind, this.enumLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumLiteralsGreen(this.Kind, this.enumLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumLiteralsGreen Update(InternalSeparatedSyntaxNodeList enumLiteral)
	    {
	        if (this.enumLiteral != enumLiteral)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumLiterals(enumLiteral);
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
	
	internal class EnumLiteralGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private NameDefGreen nameDef;
	
	    public EnumLiteralGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, NameDefGreen nameDef)
	        : base(kind, null, null)
	    {
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
	    }
	
	    public EnumLiteralGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, NameDefGreen nameDef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotationList != null)
			{
				this.AdjustFlagsAndWidth(annotationList);
				this.annotationList = annotationList;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnumLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.nameDef;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumLiteralGreen(this.Kind, this.annotationList, this.nameDef, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumLiteralGreen(this.Kind, this.annotationList, this.nameDef, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumLiteralGreen Update(AnnotationListGreen annotationList, NameDefGreen nameDef)
	    {
	        if (this.annotationList != annotationList ||
				this.nameDef != nameDef)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnumLiteral(annotationList, nameDef);
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
	
	internal class StructDeclarationGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kStruct;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private StructBodyGreen structBody;
	
	    public StructDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, StructBodyGreen structBody)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (structBody != null)
			{
				this.AdjustFlagsAndWidth(structBody);
				this.structBody = structBody;
			}
	    }
	
	    public StructDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, StructBodyGreen structBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (structBody != null)
			{
				this.AdjustFlagsAndWidth(structBody);
				this.structBody = structBody;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KStruct { get { return this.kStruct; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public StructBodyGreen StructBody { get { return this.structBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.StructDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kStruct;
	            case 2: return this.nameDef;
	            case 3: return this.tColon;
	            case 4: return this.qualifiedName;
	            case 5: return this.structBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StructDeclarationGreen(this.Kind, this.annotationList, this.kStruct, this.nameDef, this.tColon, this.qualifiedName, this.structBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StructDeclarationGreen(this.Kind, this.annotationList, this.kStruct, this.nameDef, this.tColon, this.qualifiedName, this.structBody, this.GetDiagnostics(), annotations);
	    }
	
	    public StructDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, StructBodyGreen structBody)
	    {
	        if (this.annotationList != annotationList ||
				this.kStruct != kStruct ||
				this.nameDef != nameDef ||
				this.tColon != tColon ||
				this.qualifiedName != qualifiedName ||
				this.structBody != structBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.StructDeclaration(annotationList, kStruct, nameDef, tColon, qualifiedName, structBody);
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
	
	internal class StructBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList propertyDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public StructBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList propertyDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public StructBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList propertyDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList PropertyDeclaration { get { return this.propertyDeclaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.StructBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.propertyDeclaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StructBodyGreen(this.Kind, this.tOpenBrace, this.propertyDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StructBodyGreen(this.Kind, this.tOpenBrace, this.propertyDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public StructBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList propertyDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.propertyDeclaration != propertyDeclaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.StructBody(tOpenBrace, propertyDeclaration, tCloseBrace);
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
	
	internal class PropertyDeclarationGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private TypeReferenceGreen typeReference;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tSemicolon;
	
	    public PropertyDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public PropertyDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.PropertyDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.typeReference;
	            case 2: return this.nameDef;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PropertyDeclarationGreen(this.Kind, this.annotationList, this.typeReference, this.nameDef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PropertyDeclarationGreen(this.Kind, this.annotationList, this.typeReference, this.nameDef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public PropertyDeclarationGreen Update(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.annotationList != annotationList ||
				this.typeReference != typeReference ||
				this.nameDef != nameDef ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.PropertyDeclaration(annotationList, typeReference, nameDef, tSemicolon);
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
	
	internal class DatabaseDeclarationGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kDatabase;
	    private NameDefGreen nameDef;
	    private DatabaseBodyGreen databaseBody;
	
	    public DatabaseDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameDefGreen nameDef, DatabaseBodyGreen databaseBody)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (databaseBody != null)
			{
				this.AdjustFlagsAndWidth(databaseBody);
				this.databaseBody = databaseBody;
			}
	    }
	
	    public DatabaseDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameDefGreen nameDef, DatabaseBodyGreen databaseBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (databaseBody != null)
			{
				this.AdjustFlagsAndWidth(databaseBody);
				this.databaseBody = databaseBody;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KDatabase { get { return this.kDatabase; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public DatabaseBodyGreen DatabaseBody { get { return this.databaseBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DatabaseDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kDatabase;
	            case 2: return this.nameDef;
	            case 3: return this.databaseBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DatabaseDeclarationGreen(this.Kind, this.annotationList, this.kDatabase, this.nameDef, this.databaseBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DatabaseDeclarationGreen(this.Kind, this.annotationList, this.kDatabase, this.nameDef, this.databaseBody, this.GetDiagnostics(), annotations);
	    }
	
	    public DatabaseDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameDefGreen nameDef, DatabaseBodyGreen databaseBody)
	    {
	        if (this.annotationList != annotationList ||
				this.kDatabase != kDatabase ||
				this.nameDef != nameDef ||
				this.databaseBody != databaseBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DatabaseDeclaration(annotationList, kDatabase, nameDef, databaseBody);
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
	
	internal class DatabaseBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList entityReference;
	    private InternalSyntaxNodeList operationDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public DatabaseBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList entityReference, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public DatabaseBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList entityReference, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList EntityReference { get { return this.entityReference; } }
	    public InternalSyntaxNodeList OperationDeclaration { get { return this.operationDeclaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DatabaseBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DatabaseBodyGreen(this.Kind, this.tOpenBrace, this.entityReference, this.operationDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DatabaseBodyGreen(this.Kind, this.tOpenBrace, this.entityReference, this.operationDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public DatabaseBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList entityReference, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.entityReference != entityReference ||
				this.operationDeclaration != operationDeclaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DatabaseBody(tOpenBrace, entityReference, operationDeclaration, tCloseBrace);
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
	
	internal class EntityReferenceGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kEntity;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public EntityReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kEntity, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kEntity != null)
			{
				this.AdjustFlagsAndWidth(kEntity);
				this.kEntity = kEntity;
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
	
	    public EntityReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kEntity, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kEntity != null)
			{
				this.AdjustFlagsAndWidth(kEntity);
				this.kEntity = kEntity;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KEntity { get { return this.kEntity; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EntityReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEntity;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EntityReferenceGreen(this.Kind, this.kEntity, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EntityReferenceGreen(this.Kind, this.kEntity, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EntityReferenceGreen Update(InternalSyntaxToken kEntity, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kEntity != kEntity ||
				this.qualifiedName != qualifiedName ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EntityReference(kEntity, qualifiedName, tSemicolon);
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
	
	internal class InterfaceDeclarationGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private InternalSyntaxToken kInterface;
	    private NameDefGreen nameDef;
	    private InterfaceBodyGreen interfaceBody;
	
	    public InterfaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameDefGreen nameDef, InterfaceBodyGreen interfaceBody)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (interfaceBody != null)
			{
				this.AdjustFlagsAndWidth(interfaceBody);
				this.interfaceBody = interfaceBody;
			}
	    }
	
	    public InterfaceDeclarationGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameDefGreen nameDef, InterfaceBodyGreen interfaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (interfaceBody != null)
			{
				this.AdjustFlagsAndWidth(interfaceBody);
				this.interfaceBody = interfaceBody;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public InternalSyntaxToken KInterface { get { return this.kInterface; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InterfaceBodyGreen InterfaceBody { get { return this.interfaceBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.InterfaceDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.kInterface;
	            case 2: return this.nameDef;
	            case 3: return this.interfaceBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InterfaceDeclarationGreen(this.Kind, this.annotationList, this.kInterface, this.nameDef, this.interfaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InterfaceDeclarationGreen(this.Kind, this.annotationList, this.kInterface, this.nameDef, this.interfaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public InterfaceDeclarationGreen Update(AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameDefGreen nameDef, InterfaceBodyGreen interfaceBody)
	    {
	        if (this.annotationList != annotationList ||
				this.kInterface != kInterface ||
				this.nameDef != nameDef ||
				this.interfaceBody != interfaceBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.InterfaceDeclaration(annotationList, kInterface, nameDef, interfaceBody);
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
	
	internal class InterfaceBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList operationDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public InterfaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public InterfaceBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList OperationDeclaration { get { return this.operationDeclaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.InterfaceBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.operationDeclaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InterfaceBodyGreen(this.Kind, this.tOpenBrace, this.operationDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InterfaceBodyGreen(this.Kind, this.tOpenBrace, this.operationDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public InterfaceBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.operationDeclaration != operationDeclaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.InterfaceBody(tOpenBrace, operationDeclaration, tCloseBrace);
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
	
	internal class OperationDeclarationGreen : SoalGreenNode
	{
	    private OperationHeadGreen operationHead;
	    private InternalSyntaxToken tSemicolon;
	
	    public OperationDeclarationGreen(SoalSyntaxKind kind, OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public OperationHeadGreen OperationHead { get { return this.operationHead; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.operationHead;
	            case 1: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.operationHead, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.operationHead, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationDeclarationGreen Update(OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon)
	    {
	        if (this.operationHead != operationHead ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(operationHead, tSemicolon);
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
	
	internal class OperationHeadGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private OperationResultGreen operationResult;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tOpenParen;
	    private ParameterListGreen parameterList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken kThrows;
	    private QualifiedNameListGreen qualifiedNameList;
	
	    public OperationHeadGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, OperationResultGreen operationResult, NameDefGreen nameDef, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken kThrows, QualifiedNameListGreen qualifiedNameList)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (kThrows != null)
			{
				this.AdjustFlagsAndWidth(kThrows);
				this.kThrows = kThrows;
			}
			if (qualifiedNameList != null)
			{
				this.AdjustFlagsAndWidth(qualifiedNameList);
				this.qualifiedNameList = qualifiedNameList;
			}
	    }
	
	    public OperationHeadGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, OperationResultGreen operationResult, NameDefGreen nameDef, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken kThrows, QualifiedNameListGreen qualifiedNameList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (kThrows != null)
			{
				this.AdjustFlagsAndWidth(kThrows);
				this.kThrows = kThrows;
			}
			if (qualifiedNameList != null)
			{
				this.AdjustFlagsAndWidth(qualifiedNameList);
				this.qualifiedNameList = qualifiedNameList;
			}
	    }
	
		public override int SlotCount { get { return 8; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public OperationResultGreen OperationResult { get { return this.operationResult; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ParameterListGreen ParameterList { get { return this.parameterList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken KThrows { get { return this.kThrows; } }
	    public QualifiedNameListGreen QualifiedNameList { get { return this.qualifiedNameList; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationHeadSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.operationResult;
	            case 2: return this.nameDef;
	            case 3: return this.tOpenParen;
	            case 4: return this.parameterList;
	            case 5: return this.tCloseParen;
	            case 6: return this.kThrows;
	            case 7: return this.qualifiedNameList;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationHeadGreen(this.Kind, this.annotationList, this.operationResult, this.nameDef, this.tOpenParen, this.parameterList, this.tCloseParen, this.kThrows, this.qualifiedNameList, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationHeadGreen(this.Kind, this.annotationList, this.operationResult, this.nameDef, this.tOpenParen, this.parameterList, this.tCloseParen, this.kThrows, this.qualifiedNameList, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationHeadGreen Update(AnnotationListGreen annotationList, OperationResultGreen operationResult, NameDefGreen nameDef, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken kThrows, QualifiedNameListGreen qualifiedNameList)
	    {
	        if (this.annotationList != annotationList ||
				this.operationResult != operationResult ||
				this.nameDef != nameDef ||
				this.tOpenParen != tOpenParen ||
				this.parameterList != parameterList ||
				this.tCloseParen != tCloseParen ||
				this.kThrows != kThrows ||
				this.qualifiedNameList != qualifiedNameList)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationHead(annotationList, operationResult, nameDef, tOpenParen, parameterList, tCloseParen, kThrows, qualifiedNameList);
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
	
	internal class ParameterListGreen : SoalGreenNode
	{
	    private InternalSeparatedSyntaxNodeList parameter;
	
	    public ParameterListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList parameter)
	        : base(kind, null, null)
	    {
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
	    public ParameterListGreen(SoalSyntaxKind kind, InternalSeparatedSyntaxNodeList parameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList Parameter { get { return this.parameter; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ParameterListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.parameter;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterListGreen(this.Kind, this.parameter, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterListGreen(this.Kind, this.parameter, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterListGreen Update(InternalSeparatedSyntaxNodeList parameter)
	    {
	        if (this.parameter != parameter)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ParameterList(parameter);
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
	
	internal class ParameterGreen : SoalGreenNode
	{
	    private AnnotationListGreen annotationList;
	    private TypeReferenceGreen typeReference;
	    private NameDefGreen nameDef;
	
	    public ParameterGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
	    }
	
	    public ParameterGreen(SoalSyntaxKind kind, AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public AnnotationListGreen AnnotationList { get { return this.annotationList; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ParameterSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotationList;
	            case 1: return this.typeReference;
	            case 2: return this.nameDef;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterGreen(this.Kind, this.annotationList, this.typeReference, this.nameDef, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterGreen(this.Kind, this.annotationList, this.typeReference, this.nameDef, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterGreen Update(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef)
	    {
	        if (this.annotationList != annotationList ||
				this.typeReference != typeReference ||
				this.nameDef != nameDef)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Parameter(annotationList, typeReference, nameDef);
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
	
	internal class OperationResultGreen : SoalGreenNode
	{
	    private ReturnAnnotationListGreen returnAnnotationList;
	    private OperationReturnTypeGreen operationReturnType;
	
	    public OperationResultGreen(SoalSyntaxKind kind, ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public ReturnAnnotationListGreen ReturnAnnotationList { get { return this.returnAnnotationList; } }
	    public OperationReturnTypeGreen OperationReturnType { get { return this.operationReturnType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationResultSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.returnAnnotationList;
	            case 1: return this.operationReturnType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationResultGreen(this.Kind, this.returnAnnotationList, this.operationReturnType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationResultGreen(this.Kind, this.returnAnnotationList, this.operationReturnType, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationResultGreen Update(ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType)
	    {
	        if (this.returnAnnotationList != returnAnnotationList ||
				this.operationReturnType != operationReturnType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationResult(returnAnnotationList, operationReturnType);
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
	
	internal class ComponentDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kAbstract;
	    private InternalSyntaxToken kComponent;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private ComponentBodyGreen componentBody;
	
	    public ComponentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, ComponentBodyGreen componentBody)
	        : base(kind, null, null)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (componentBody != null)
			{
				this.AdjustFlagsAndWidth(componentBody);
				this.componentBody = componentBody;
			}
	    }
	
	    public ComponentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, ComponentBodyGreen componentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (componentBody != null)
			{
				this.AdjustFlagsAndWidth(componentBody);
				this.componentBody = componentBody;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public InternalSyntaxToken KAbstract { get { return this.kAbstract; } }
	    public InternalSyntaxToken KComponent { get { return this.kComponent; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public ComponentBodyGreen ComponentBody { get { return this.componentBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAbstract;
	            case 1: return this.kComponent;
	            case 2: return this.nameDef;
	            case 3: return this.tColon;
	            case 4: return this.qualifiedName;
	            case 5: return this.componentBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentDeclarationGreen(this.Kind, this.kAbstract, this.kComponent, this.nameDef, this.tColon, this.qualifiedName, this.componentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentDeclarationGreen(this.Kind, this.kAbstract, this.kComponent, this.nameDef, this.tColon, this.qualifiedName, this.componentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentDeclarationGreen Update(InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, ComponentBodyGreen componentBody)
	    {
	        if (this.kAbstract != kAbstract ||
				this.kComponent != kComponent ||
				this.nameDef != nameDef ||
				this.tColon != tColon ||
				this.qualifiedName != qualifiedName ||
				this.componentBody != componentBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentDeclaration(kAbstract, kComponent, nameDef, tColon, qualifiedName, componentBody);
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
	
	internal class ComponentBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private ComponentElementsGreen componentElements;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ComponentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public ComponentElementsGreen ComponentElements { get { return this.componentElements; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.componentElements;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentBodyGreen(this.Kind, this.tOpenBrace, this.componentElements, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentBodyGreen(this.Kind, this.tOpenBrace, this.componentElements, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentBodyGreen Update(InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.componentElements != componentElements ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentBody(tOpenBrace, componentElements, tCloseBrace);
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
	
	internal class ComponentElementsGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList componentElement;
	
	    public ComponentElementsGreen(SoalSyntaxKind kind, InternalSyntaxNodeList componentElement)
	        : base(kind, null, null)
	    {
			if (componentElement != null)
			{
				this.AdjustFlagsAndWidth(componentElement);
				this.componentElement = componentElement;
			}
	    }
	
	    public ComponentElementsGreen(SoalSyntaxKind kind, InternalSyntaxNodeList componentElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (componentElement != null)
			{
				this.AdjustFlagsAndWidth(componentElement);
				this.componentElement = componentElement;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList ComponentElement { get { return this.componentElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.componentElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentElementsGreen(this.Kind, this.componentElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentElementsGreen(this.Kind, this.componentElement, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentElementsGreen Update(InternalSyntaxNodeList componentElement)
	    {
	        if (this.componentElement != componentElement)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElements(componentElement);
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
	
	internal class ComponentElementGreen : SoalGreenNode
	{
	    private ComponentServiceGreen componentService;
	    private ComponentReferenceGreen componentReference;
	    private ComponentPropertyGreen componentProperty;
	    private ComponentImplementationGreen componentImplementation;
	    private ComponentLanguageGreen componentLanguage;
	
	    public ComponentElementGreen(SoalSyntaxKind kind, ComponentServiceGreen componentService, ComponentReferenceGreen componentReference, ComponentPropertyGreen componentProperty, ComponentImplementationGreen componentImplementation, ComponentLanguageGreen componentLanguage)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 5; } }
	
	    public ComponentServiceGreen ComponentService { get { return this.componentService; } }
	    public ComponentReferenceGreen ComponentReference { get { return this.componentReference; } }
	    public ComponentPropertyGreen ComponentProperty { get { return this.componentProperty; } }
	    public ComponentImplementationGreen ComponentImplementation { get { return this.componentImplementation; } }
	    public ComponentLanguageGreen ComponentLanguage { get { return this.componentLanguage; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentElementGreen Update(ComponentServiceGreen componentService)
	    {
	        if (this.componentService != componentService)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentService);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentReference);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentProperty);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentImplementation);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement(componentLanguage);
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
	
	internal class ComponentServiceGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kService;
	    private QualifiedNameGreen qualifiedName;
	    private NameDefGreen nameDef;
	    private ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody;
	
	    public ComponentServiceGreen(SoalSyntaxKind kind, InternalSyntaxToken kService, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	        : base(kind, null, null)
	    {
			if (kService != null)
			{
				this.AdjustFlagsAndWidth(kService);
				this.kService = kService;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
	    public ComponentServiceGreen(SoalSyntaxKind kind, InternalSyntaxToken kService, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kService != null)
			{
				this.AdjustFlagsAndWidth(kService);
				this.kService = kService;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken KService { get { return this.kService; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public ComponentServiceOrReferenceBodyGreen ComponentServiceOrReferenceBody { get { return this.componentServiceOrReferenceBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kService;
	            case 1: return this.qualifiedName;
	            case 2: return this.nameDef;
	            case 3: return this.componentServiceOrReferenceBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceGreen(this.Kind, this.kService, this.qualifiedName, this.nameDef, this.componentServiceOrReferenceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceGreen(this.Kind, this.kService, this.qualifiedName, this.nameDef, this.componentServiceOrReferenceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceGreen Update(InternalSyntaxToken kService, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	    {
	        if (this.kService != kService ||
				this.qualifiedName != qualifiedName ||
				this.nameDef != nameDef ||
				this.componentServiceOrReferenceBody != componentServiceOrReferenceBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentService(kService, qualifiedName, nameDef, componentServiceOrReferenceBody);
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
	
	internal class ComponentReferenceGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kReference;
	    private QualifiedNameGreen qualifiedName;
	    private NameDefGreen nameDef;
	    private ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody;
	
	    public ComponentReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kReference, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	        : base(kind, null, null)
	    {
			if (kReference != null)
			{
				this.AdjustFlagsAndWidth(kReference);
				this.kReference = kReference;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
	    public ComponentReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kReference, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kReference != null)
			{
				this.AdjustFlagsAndWidth(kReference);
				this.kReference = kReference;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (componentServiceOrReferenceBody != null)
			{
				this.AdjustFlagsAndWidth(componentServiceOrReferenceBody);
				this.componentServiceOrReferenceBody = componentServiceOrReferenceBody;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken KReference { get { return this.kReference; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public ComponentServiceOrReferenceBodyGreen ComponentServiceOrReferenceBody { get { return this.componentServiceOrReferenceBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kReference;
	            case 1: return this.qualifiedName;
	            case 2: return this.nameDef;
	            case 3: return this.componentServiceOrReferenceBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentReferenceGreen(this.Kind, this.kReference, this.qualifiedName, this.nameDef, this.componentServiceOrReferenceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentReferenceGreen(this.Kind, this.kReference, this.qualifiedName, this.nameDef, this.componentServiceOrReferenceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentReferenceGreen Update(InternalSyntaxToken kReference, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody)
	    {
	        if (this.kReference != kReference ||
				this.qualifiedName != qualifiedName ||
				this.nameDef != nameDef ||
				this.componentServiceOrReferenceBody != componentServiceOrReferenceBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentReference(kReference, qualifiedName, nameDef, componentServiceOrReferenceBody);
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
	
	internal abstract class ComponentServiceOrReferenceBodyGreen : SoalGreenNode
	{
	
	    public ComponentServiceOrReferenceBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class ComponentServiceOrReferenceEmptyBodyGreen : ComponentServiceOrReferenceBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentServiceOrReferenceEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ComponentServiceOrReferenceEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceOrReferenceEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceOrReferenceEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceOrReferenceEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceOrReferenceEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList componentServiceOrReferenceElement;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ComponentServiceOrReferenceNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public ComponentServiceOrReferenceNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList ComponentServiceOrReferenceElement { get { return this.componentServiceOrReferenceElement; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceOrReferenceNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.componentServiceOrReferenceElement;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceOrReferenceNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.componentServiceOrReferenceElement, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceOrReferenceNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.componentServiceOrReferenceElement, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceOrReferenceNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.componentServiceOrReferenceElement != componentServiceOrReferenceElement ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceNonEmptyBody(tOpenBrace, componentServiceOrReferenceElement, tCloseBrace);
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
	
	internal class ComponentServiceOrReferenceElementGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kBinding;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentServiceOrReferenceElementGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
	    public ComponentServiceOrReferenceElementGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KBinding { get { return this.kBinding; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentServiceOrReferenceElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBinding;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentServiceOrReferenceElementGreen(this.Kind, this.kBinding, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentServiceOrReferenceElementGreen(this.Kind, this.kBinding, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentServiceOrReferenceElementGreen Update(InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kBinding != kBinding ||
				this.qualifiedName != qualifiedName ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceElement(kBinding, qualifiedName, tSemicolon);
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
	
	internal class ComponentPropertyGreen : SoalGreenNode
	{
	    private TypeReferenceGreen typeReference;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentPropertyGreen(SoalSyntaxKind kind, TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ComponentPropertyGreen(SoalSyntaxKind kind, TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.nameDef;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentPropertyGreen(this.Kind, this.typeReference, this.nameDef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentPropertyGreen(this.Kind, this.typeReference, this.nameDef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentPropertyGreen Update(TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.typeReference != typeReference ||
				this.nameDef != nameDef ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentProperty(typeReference, nameDef, tSemicolon);
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
	
	internal class ComponentImplementationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kImplementation;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentImplementationGreen(SoalSyntaxKind kind, InternalSyntaxToken kImplementation, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kImplementation != null)
			{
				this.AdjustFlagsAndWidth(kImplementation);
				this.kImplementation = kImplementation;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ComponentImplementationGreen(SoalSyntaxKind kind, InternalSyntaxToken kImplementation, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kImplementation != null)
			{
				this.AdjustFlagsAndWidth(kImplementation);
				this.kImplementation = kImplementation;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KImplementation { get { return this.kImplementation; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentImplementationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kImplementation;
	            case 1: return this.nameDef;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentImplementationGreen(this.Kind, this.kImplementation, this.nameDef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentImplementationGreen(this.Kind, this.kImplementation, this.nameDef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentImplementationGreen Update(InternalSyntaxToken kImplementation, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kImplementation != kImplementation ||
				this.nameDef != nameDef ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentImplementation(kImplementation, nameDef, tSemicolon);
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
	
	internal class ComponentLanguageGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kLanguage;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tSemicolon;
	
	    public ComponentLanguageGreen(SoalSyntaxKind kind, InternalSyntaxToken kLanguage, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kLanguage != null)
			{
				this.AdjustFlagsAndWidth(kLanguage);
				this.kLanguage = kLanguage;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ComponentLanguageGreen(SoalSyntaxKind kind, InternalSyntaxToken kLanguage, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kLanguage != null)
			{
				this.AdjustFlagsAndWidth(kLanguage);
				this.kLanguage = kLanguage;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KLanguage { get { return this.kLanguage; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ComponentLanguageSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kLanguage;
	            case 1: return this.nameDef;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ComponentLanguageGreen(this.Kind, this.kLanguage, this.nameDef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ComponentLanguageGreen(this.Kind, this.kLanguage, this.nameDef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ComponentLanguageGreen Update(InternalSyntaxToken kLanguage, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kLanguage != kLanguage ||
				this.nameDef != nameDef ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ComponentLanguage(kLanguage, nameDef, tSemicolon);
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
	
	internal class CompositeDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kComposite;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private CompositeBodyGreen compositeBody;
	
	    public CompositeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kComposite, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody)
	        : base(kind, null, null)
	    {
			if (kComposite != null)
			{
				this.AdjustFlagsAndWidth(kComposite);
				this.kComposite = kComposite;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
	    public CompositeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kComposite, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kComposite != null)
			{
				this.AdjustFlagsAndWidth(kComposite);
				this.kComposite = kComposite;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken KComposite { get { return this.kComposite; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public CompositeBodyGreen CompositeBody { get { return this.compositeBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kComposite;
	            case 1: return this.nameDef;
	            case 2: return this.tColon;
	            case 3: return this.qualifiedName;
	            case 4: return this.compositeBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeDeclarationGreen(this.Kind, this.kComposite, this.nameDef, this.tColon, this.qualifiedName, this.compositeBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeDeclarationGreen(this.Kind, this.kComposite, this.nameDef, this.tColon, this.qualifiedName, this.compositeBody, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeDeclarationGreen Update(InternalSyntaxToken kComposite, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody)
	    {
	        if (this.kComposite != kComposite ||
				this.nameDef != nameDef ||
				this.tColon != tColon ||
				this.qualifiedName != qualifiedName ||
				this.compositeBody != compositeBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeDeclaration(kComposite, nameDef, tColon, qualifiedName, compositeBody);
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
	
	internal class CompositeBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private CompositeElementsGreen compositeElements;
	    private InternalSyntaxToken tCloseBrace;
	
	    public CompositeBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public CompositeElementsGreen CompositeElements { get { return this.compositeElements; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.compositeElements;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeBodyGreen(this.Kind, this.tOpenBrace, this.compositeElements, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeBodyGreen(this.Kind, this.tOpenBrace, this.compositeElements, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeBodyGreen Update(InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.compositeElements != compositeElements ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeBody(tOpenBrace, compositeElements, tCloseBrace);
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
	
	internal class AssemblyDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kAssembly;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private CompositeBodyGreen compositeBody;
	
	    public AssemblyDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody)
	        : base(kind, null, null)
	    {
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
	    public AssemblyDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (compositeBody != null)
			{
				this.AdjustFlagsAndWidth(compositeBody);
				this.compositeBody = compositeBody;
			}
	    }
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken KAssembly { get { return this.kAssembly; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public CompositeBodyGreen CompositeBody { get { return this.compositeBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AssemblyDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAssembly;
	            case 1: return this.nameDef;
	            case 2: return this.tColon;
	            case 3: return this.qualifiedName;
	            case 4: return this.compositeBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssemblyDeclarationGreen(this.Kind, this.kAssembly, this.nameDef, this.tColon, this.qualifiedName, this.compositeBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssemblyDeclarationGreen(this.Kind, this.kAssembly, this.nameDef, this.tColon, this.qualifiedName, this.compositeBody, this.GetDiagnostics(), annotations);
	    }
	
	    public AssemblyDeclarationGreen Update(InternalSyntaxToken kAssembly, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody)
	    {
	        if (this.kAssembly != kAssembly ||
				this.nameDef != nameDef ||
				this.tColon != tColon ||
				this.qualifiedName != qualifiedName ||
				this.compositeBody != compositeBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AssemblyDeclaration(kAssembly, nameDef, tColon, qualifiedName, compositeBody);
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
	
	internal class CompositeElementsGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList compositeElement;
	
	    public CompositeElementsGreen(SoalSyntaxKind kind, InternalSyntaxNodeList compositeElement)
	        : base(kind, null, null)
	    {
			if (compositeElement != null)
			{
				this.AdjustFlagsAndWidth(compositeElement);
				this.compositeElement = compositeElement;
			}
	    }
	
	    public CompositeElementsGreen(SoalSyntaxKind kind, InternalSyntaxNodeList compositeElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (compositeElement != null)
			{
				this.AdjustFlagsAndWidth(compositeElement);
				this.compositeElement = compositeElement;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList CompositeElement { get { return this.compositeElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.compositeElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeElementsGreen(this.Kind, this.compositeElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeElementsGreen(this.Kind, this.compositeElement, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeElementsGreen Update(InternalSyntaxNodeList compositeElement)
	    {
	        if (this.compositeElement != compositeElement)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElements(compositeElement);
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
	
	internal class CompositeElementGreen : SoalGreenNode
	{
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
	
		public override int SlotCount { get { return 7; } }
	
	    public ComponentServiceGreen ComponentService { get { return this.componentService; } }
	    public ComponentReferenceGreen ComponentReference { get { return this.componentReference; } }
	    public ComponentPropertyGreen ComponentProperty { get { return this.componentProperty; } }
	    public ComponentImplementationGreen ComponentImplementation { get { return this.componentImplementation; } }
	    public ComponentLanguageGreen ComponentLanguage { get { return this.componentLanguage; } }
	    public CompositeComponentGreen CompositeComponent { get { return this.compositeComponent; } }
	    public CompositeWireGreen CompositeWire { get { return this.compositeWire; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, this.compositeComponent, this.compositeWire, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeElementGreen(this.Kind, this.componentService, this.componentReference, this.componentProperty, this.componentImplementation, this.componentLanguage, this.compositeComponent, this.compositeWire, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeElementGreen Update(ComponentServiceGreen componentService)
	    {
	        if (this.componentService != componentService)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentService);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentReference);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentProperty);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentImplementation);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(componentLanguage);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(compositeComponent);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement(compositeWire);
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
	
	internal class CompositeComponentGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kComponent;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public CompositeComponentGreen(SoalSyntaxKind kind, InternalSyntaxToken kComponent, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kComponent != null)
			{
				this.AdjustFlagsAndWidth(kComponent);
				this.kComponent = kComponent;
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
	
	    public CompositeComponentGreen(SoalSyntaxKind kind, InternalSyntaxToken kComponent, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kComponent != null)
			{
				this.AdjustFlagsAndWidth(kComponent);
				this.kComponent = kComponent;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KComponent { get { return this.kComponent; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeComponentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kComponent;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeComponentGreen(this.Kind, this.kComponent, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeComponentGreen(this.Kind, this.kComponent, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeComponentGreen Update(InternalSyntaxToken kComponent, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kComponent != kComponent ||
				this.qualifiedName != qualifiedName ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeComponent(kComponent, qualifiedName, tSemicolon);
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
	
	internal class CompositeWireGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kWire;
	    private WireSourceGreen wireSource;
	    private InternalSyntaxToken kTo;
	    private WireTargetGreen wireTarget;
	    private InternalSyntaxToken tSemicolon;
	
	    public CompositeWireGreen(SoalSyntaxKind kind, InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken KWire { get { return this.kWire; } }
	    public WireSourceGreen WireSource { get { return this.wireSource; } }
	    public InternalSyntaxToken KTo { get { return this.kTo; } }
	    public WireTargetGreen WireTarget { get { return this.wireTarget; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.CompositeWireSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CompositeWireGreen(this.Kind, this.kWire, this.wireSource, this.kTo, this.wireTarget, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CompositeWireGreen(this.Kind, this.kWire, this.wireSource, this.kTo, this.wireTarget, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public CompositeWireGreen Update(InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kWire != kWire ||
				this.wireSource != wireSource ||
				this.kTo != kTo ||
				this.wireTarget != wireTarget ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.CompositeWire(kWire, wireSource, kTo, wireTarget, tSemicolon);
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
	
	internal class WireSourceGreen : SoalGreenNode
	{
	    private QualifiedNameGreen qualifiedName;
	
	    public WireSourceGreen(SoalSyntaxKind kind, QualifiedNameGreen qualifiedName)
	        : base(kind, null, null)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
	    public WireSourceGreen(SoalSyntaxKind kind, QualifiedNameGreen qualifiedName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WireSourceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifiedName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WireSourceGreen(this.Kind, this.qualifiedName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WireSourceGreen(this.Kind, this.qualifiedName, this.GetDiagnostics(), annotations);
	    }
	
	    public WireSourceGreen Update(QualifiedNameGreen qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WireSource(qualifiedName);
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
	
	internal class WireTargetGreen : SoalGreenNode
	{
	    private QualifiedNameGreen qualifiedName;
	
	    public WireTargetGreen(SoalSyntaxKind kind, QualifiedNameGreen qualifiedName)
	        : base(kind, null, null)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
	    public WireTargetGreen(SoalSyntaxKind kind, QualifiedNameGreen qualifiedName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WireTargetSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifiedName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WireTargetGreen(this.Kind, this.qualifiedName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WireTargetGreen(this.Kind, this.qualifiedName, this.GetDiagnostics(), annotations);
	    }
	
	    public WireTargetGreen Update(QualifiedNameGreen qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WireTarget(qualifiedName);
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
	
	internal class DeploymentDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kDeployment;
	    private NameDefGreen nameDef;
	    private DeploymentBodyGreen deploymentBody;
	
	    public DeploymentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kDeployment, NameDefGreen nameDef, DeploymentBodyGreen deploymentBody)
	        : base(kind, null, null)
	    {
			if (kDeployment != null)
			{
				this.AdjustFlagsAndWidth(kDeployment);
				this.kDeployment = kDeployment;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (deploymentBody != null)
			{
				this.AdjustFlagsAndWidth(deploymentBody);
				this.deploymentBody = deploymentBody;
			}
	    }
	
	    public DeploymentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kDeployment, NameDefGreen nameDef, DeploymentBodyGreen deploymentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kDeployment != null)
			{
				this.AdjustFlagsAndWidth(kDeployment);
				this.kDeployment = kDeployment;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (deploymentBody != null)
			{
				this.AdjustFlagsAndWidth(deploymentBody);
				this.deploymentBody = deploymentBody;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KDeployment { get { return this.kDeployment; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public DeploymentBodyGreen DeploymentBody { get { return this.deploymentBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDeployment;
	            case 1: return this.nameDef;
	            case 2: return this.deploymentBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentDeclarationGreen(this.Kind, this.kDeployment, this.nameDef, this.deploymentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentDeclarationGreen(this.Kind, this.kDeployment, this.nameDef, this.deploymentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentDeclarationGreen Update(InternalSyntaxToken kDeployment, NameDefGreen nameDef, DeploymentBodyGreen deploymentBody)
	    {
	        if (this.kDeployment != kDeployment ||
				this.nameDef != nameDef ||
				this.deploymentBody != deploymentBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentDeclaration(kDeployment, nameDef, deploymentBody);
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
	
	internal class DeploymentBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private DeploymentElementsGreen deploymentElements;
	    private InternalSyntaxToken tCloseBrace;
	
	    public DeploymentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public DeploymentElementsGreen DeploymentElements { get { return this.deploymentElements; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.deploymentElements;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentBodyGreen(this.Kind, this.tOpenBrace, this.deploymentElements, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentBodyGreen(this.Kind, this.tOpenBrace, this.deploymentElements, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentBodyGreen Update(InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.deploymentElements != deploymentElements ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentBody(tOpenBrace, deploymentElements, tCloseBrace);
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
	
	internal class DeploymentElementsGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList deploymentElement;
	
	    public DeploymentElementsGreen(SoalSyntaxKind kind, InternalSyntaxNodeList deploymentElement)
	        : base(kind, null, null)
	    {
			if (deploymentElement != null)
			{
				this.AdjustFlagsAndWidth(deploymentElement);
				this.deploymentElement = deploymentElement;
			}
	    }
	
	    public DeploymentElementsGreen(SoalSyntaxKind kind, InternalSyntaxNodeList deploymentElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (deploymentElement != null)
			{
				this.AdjustFlagsAndWidth(deploymentElement);
				this.deploymentElement = deploymentElement;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList DeploymentElement { get { return this.deploymentElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.deploymentElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentElementsGreen(this.Kind, this.deploymentElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentElementsGreen(this.Kind, this.deploymentElement, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentElementsGreen Update(InternalSyntaxNodeList deploymentElement)
	    {
	        if (this.deploymentElement != deploymentElement)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElements(deploymentElement);
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
	
	internal class DeploymentElementGreen : SoalGreenNode
	{
	    private EnvironmentDeclarationGreen environmentDeclaration;
	    private CompositeWireGreen compositeWire;
	
	    public DeploymentElementGreen(SoalSyntaxKind kind, EnvironmentDeclarationGreen environmentDeclaration, CompositeWireGreen compositeWire)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public EnvironmentDeclarationGreen EnvironmentDeclaration { get { return this.environmentDeclaration; } }
	    public CompositeWireGreen CompositeWire { get { return this.compositeWire; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DeploymentElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.environmentDeclaration;
	            case 1: return this.compositeWire;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeploymentElementGreen(this.Kind, this.environmentDeclaration, this.compositeWire, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeploymentElementGreen(this.Kind, this.environmentDeclaration, this.compositeWire, this.GetDiagnostics(), annotations);
	    }
	
	    public DeploymentElementGreen Update(EnvironmentDeclarationGreen environmentDeclaration)
	    {
	        if (this.environmentDeclaration != environmentDeclaration)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElement(environmentDeclaration);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElement(compositeWire);
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
	
	internal class EnvironmentDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kEnvironment;
	    private NameDefGreen nameDef;
	    private EnvironmentBodyGreen environmentBody;
	
	    public EnvironmentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEnvironment, NameDefGreen nameDef, EnvironmentBodyGreen environmentBody)
	        : base(kind, null, null)
	    {
			if (kEnvironment != null)
			{
				this.AdjustFlagsAndWidth(kEnvironment);
				this.kEnvironment = kEnvironment;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (environmentBody != null)
			{
				this.AdjustFlagsAndWidth(environmentBody);
				this.environmentBody = environmentBody;
			}
	    }
	
	    public EnvironmentDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEnvironment, NameDefGreen nameDef, EnvironmentBodyGreen environmentBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kEnvironment != null)
			{
				this.AdjustFlagsAndWidth(kEnvironment);
				this.kEnvironment = kEnvironment;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (environmentBody != null)
			{
				this.AdjustFlagsAndWidth(environmentBody);
				this.environmentBody = environmentBody;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KEnvironment { get { return this.kEnvironment; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public EnvironmentBodyGreen EnvironmentBody { get { return this.environmentBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnvironmentDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEnvironment;
	            case 1: return this.nameDef;
	            case 2: return this.environmentBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnvironmentDeclarationGreen(this.Kind, this.kEnvironment, this.nameDef, this.environmentBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnvironmentDeclarationGreen(this.Kind, this.kEnvironment, this.nameDef, this.environmentBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EnvironmentDeclarationGreen Update(InternalSyntaxToken kEnvironment, NameDefGreen nameDef, EnvironmentBodyGreen environmentBody)
	    {
	        if (this.kEnvironment != kEnvironment ||
				this.nameDef != nameDef ||
				this.environmentBody != environmentBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnvironmentDeclaration(kEnvironment, nameDef, environmentBody);
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
	
	internal class EnvironmentBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private RuntimeDeclarationGreen runtimeDeclaration;
	    private InternalSyntaxNodeList runtimeReference;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EnvironmentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, InternalSyntaxNodeList runtimeReference, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public EnvironmentBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, InternalSyntaxNodeList runtimeReference, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public RuntimeDeclarationGreen RuntimeDeclaration { get { return this.runtimeDeclaration; } }
	    public InternalSyntaxNodeList RuntimeReference { get { return this.runtimeReference; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EnvironmentBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnvironmentBodyGreen(this.Kind, this.tOpenBrace, this.runtimeDeclaration, this.runtimeReference, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnvironmentBodyGreen(this.Kind, this.tOpenBrace, this.runtimeDeclaration, this.runtimeReference, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EnvironmentBodyGreen Update(InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, InternalSyntaxNodeList runtimeReference, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.runtimeDeclaration != runtimeDeclaration ||
				this.runtimeReference != runtimeReference ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EnvironmentBody(tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace);
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
	
	internal class RuntimeDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kRuntime;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tSemicolon;
	
	    public RuntimeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kRuntime, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kRuntime != null)
			{
				this.AdjustFlagsAndWidth(kRuntime);
				this.kRuntime = kRuntime;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public RuntimeDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kRuntime, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kRuntime != null)
			{
				this.AdjustFlagsAndWidth(kRuntime);
				this.kRuntime = kRuntime;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KRuntime { get { return this.kRuntime; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RuntimeDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRuntime;
	            case 1: return this.nameDef;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RuntimeDeclarationGreen(this.Kind, this.kRuntime, this.nameDef, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RuntimeDeclarationGreen(this.Kind, this.kRuntime, this.nameDef, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public RuntimeDeclarationGreen Update(InternalSyntaxToken kRuntime, NameDefGreen nameDef, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kRuntime != kRuntime ||
				this.nameDef != nameDef ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RuntimeDeclaration(kRuntime, nameDef, tSemicolon);
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
	
	internal class RuntimeReferenceGreen : SoalGreenNode
	{
	    private AssemblyReferenceGreen assemblyReference;
	    private DatabaseReferenceGreen databaseReference;
	
	    public RuntimeReferenceGreen(SoalSyntaxKind kind, AssemblyReferenceGreen assemblyReference, DatabaseReferenceGreen databaseReference)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public AssemblyReferenceGreen AssemblyReference { get { return this.assemblyReference; } }
	    public DatabaseReferenceGreen DatabaseReference { get { return this.databaseReference; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RuntimeReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.assemblyReference;
	            case 1: return this.databaseReference;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RuntimeReferenceGreen(this.Kind, this.assemblyReference, this.databaseReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RuntimeReferenceGreen(this.Kind, this.assemblyReference, this.databaseReference, this.GetDiagnostics(), annotations);
	    }
	
	    public RuntimeReferenceGreen Update(AssemblyReferenceGreen assemblyReference)
	    {
	        if (this.assemblyReference != assemblyReference)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RuntimeReference(assemblyReference);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RuntimeReference(databaseReference);
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
	
	internal class AssemblyReferenceGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kAssembly;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public AssemblyReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
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
	
	    public AssemblyReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kAssembly, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kAssembly != null)
			{
				this.AdjustFlagsAndWidth(kAssembly);
				this.kAssembly = kAssembly;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KAssembly { get { return this.kAssembly; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.AssemblyReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAssembly;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssemblyReferenceGreen(this.Kind, this.kAssembly, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssemblyReferenceGreen(this.Kind, this.kAssembly, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public AssemblyReferenceGreen Update(InternalSyntaxToken kAssembly, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kAssembly != kAssembly ||
				this.qualifiedName != qualifiedName ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.AssemblyReference(kAssembly, qualifiedName, tSemicolon);
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
	
	internal class DatabaseReferenceGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kDatabase;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public DatabaseReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kDatabase, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kDatabase != null)
			{
				this.AdjustFlagsAndWidth(kDatabase);
				this.kDatabase = kDatabase;
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
	
	    public DatabaseReferenceGreen(SoalSyntaxKind kind, InternalSyntaxToken kDatabase, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kDatabase != null)
			{
				this.AdjustFlagsAndWidth(kDatabase);
				this.kDatabase = kDatabase;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KDatabase { get { return this.kDatabase; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DatabaseReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kDatabase;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DatabaseReferenceGreen(this.Kind, this.kDatabase, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DatabaseReferenceGreen(this.Kind, this.kDatabase, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public DatabaseReferenceGreen Update(InternalSyntaxToken kDatabase, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kDatabase != kDatabase ||
				this.qualifiedName != qualifiedName ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DatabaseReference(kDatabase, qualifiedName, tSemicolon);
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
	
	internal class BindingDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kBinding;
	    private NameDefGreen nameDef;
	    private BindingBodyGreen bindingBody;
	
	    public BindingDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, NameDefGreen nameDef, BindingBodyGreen bindingBody)
	        : base(kind, null, null)
	    {
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (bindingBody != null)
			{
				this.AdjustFlagsAndWidth(bindingBody);
				this.bindingBody = bindingBody;
			}
	    }
	
	    public BindingDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, NameDefGreen nameDef, BindingBodyGreen bindingBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
			}
			if (bindingBody != null)
			{
				this.AdjustFlagsAndWidth(bindingBody);
				this.bindingBody = bindingBody;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KBinding { get { return this.kBinding; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public BindingBodyGreen BindingBody { get { return this.bindingBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BindingDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBinding;
	            case 1: return this.nameDef;
	            case 2: return this.bindingBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BindingDeclarationGreen(this.Kind, this.kBinding, this.nameDef, this.bindingBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BindingDeclarationGreen(this.Kind, this.kBinding, this.nameDef, this.bindingBody, this.GetDiagnostics(), annotations);
	    }
	
	    public BindingDeclarationGreen Update(InternalSyntaxToken kBinding, NameDefGreen nameDef, BindingBodyGreen bindingBody)
	    {
	        if (this.kBinding != kBinding ||
				this.nameDef != nameDef ||
				this.bindingBody != bindingBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BindingDeclaration(kBinding, nameDef, bindingBody);
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
	
	internal class BindingBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private BindingLayersGreen bindingLayers;
	    private InternalSyntaxToken tCloseBrace;
	
	    public BindingBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public BindingLayersGreen BindingLayers { get { return this.bindingLayers; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BindingBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.bindingLayers;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BindingBodyGreen(this.Kind, this.tOpenBrace, this.bindingLayers, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BindingBodyGreen(this.Kind, this.tOpenBrace, this.bindingLayers, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public BindingBodyGreen Update(InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.bindingLayers != bindingLayers ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BindingBody(tOpenBrace, bindingLayers, tCloseBrace);
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
	
	internal class BindingLayersGreen : SoalGreenNode
	{
	    private TransportLayerGreen transportLayer;
	    private InternalSyntaxNodeList encodingLayer;
	    private InternalSyntaxNodeList protocolLayer;
	
	    public BindingLayersGreen(SoalSyntaxKind kind, TransportLayerGreen transportLayer, InternalSyntaxNodeList encodingLayer, InternalSyntaxNodeList protocolLayer)
	        : base(kind, null, null)
	    {
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
	
	    public BindingLayersGreen(SoalSyntaxKind kind, TransportLayerGreen transportLayer, InternalSyntaxNodeList encodingLayer, InternalSyntaxNodeList protocolLayer, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public TransportLayerGreen TransportLayer { get { return this.transportLayer; } }
	    public InternalSyntaxNodeList EncodingLayer { get { return this.encodingLayer; } }
	    public InternalSyntaxNodeList ProtocolLayer { get { return this.protocolLayer; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BindingLayersSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.transportLayer;
	            case 1: return this.encodingLayer;
	            case 2: return this.protocolLayer;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BindingLayersGreen(this.Kind, this.transportLayer, this.encodingLayer, this.protocolLayer, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BindingLayersGreen(this.Kind, this.transportLayer, this.encodingLayer, this.protocolLayer, this.GetDiagnostics(), annotations);
	    }
	
	    public BindingLayersGreen Update(TransportLayerGreen transportLayer, InternalSyntaxNodeList encodingLayer, InternalSyntaxNodeList protocolLayer)
	    {
	        if (this.transportLayer != transportLayer ||
				this.encodingLayer != encodingLayer ||
				this.protocolLayer != protocolLayer)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BindingLayers(transportLayer, encodingLayer, protocolLayer);
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
	
	internal class TransportLayerGreen : SoalGreenNode
	{
	    private HttpTransportLayerGreen httpTransportLayer;
	    private RestTransportLayerGreen restTransportLayer;
	    private WebSocketTransportLayerGreen webSocketTransportLayer;
	
	    public TransportLayerGreen(SoalSyntaxKind kind, HttpTransportLayerGreen httpTransportLayer, RestTransportLayerGreen restTransportLayer, WebSocketTransportLayerGreen webSocketTransportLayer)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public HttpTransportLayerGreen HttpTransportLayer { get { return this.httpTransportLayer; } }
	    public RestTransportLayerGreen RestTransportLayer { get { return this.restTransportLayer; } }
	    public WebSocketTransportLayerGreen WebSocketTransportLayer { get { return this.webSocketTransportLayer; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.TransportLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.httpTransportLayer;
	            case 1: return this.restTransportLayer;
	            case 2: return this.webSocketTransportLayer;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TransportLayerGreen(this.Kind, this.httpTransportLayer, this.restTransportLayer, this.webSocketTransportLayer, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TransportLayerGreen(this.Kind, this.httpTransportLayer, this.restTransportLayer, this.webSocketTransportLayer, this.GetDiagnostics(), annotations);
	    }
	
	    public TransportLayerGreen Update(HttpTransportLayerGreen httpTransportLayer)
	    {
	        if (this.httpTransportLayer != httpTransportLayer)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer(httpTransportLayer);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer(restTransportLayer);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer(webSocketTransportLayer);
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
	
	internal class HttpTransportLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kTransport;
	    private InternalSyntaxToken ihttp;
	    private HttpTransportLayerBodyGreen httpTransportLayerBody;
	
	    public HttpTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KTransport { get { return this.kTransport; } }
	    public InternalSyntaxToken IHTTP { get { return this.ihttp; } }
	    public HttpTransportLayerBodyGreen HttpTransportLayerBody { get { return this.httpTransportLayerBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTransport;
	            case 1: return this.ihttp;
	            case 2: return this.httpTransportLayerBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerGreen(this.Kind, this.kTransport, this.ihttp, this.httpTransportLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerGreen(this.Kind, this.kTransport, this.ihttp, this.httpTransportLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerGreen Update(InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody)
	    {
	        if (this.kTransport != kTransport ||
				this.ihttp != ihttp ||
				this.httpTransportLayerBody != httpTransportLayerBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayer(kTransport, ihttp, httpTransportLayerBody);
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
	
	internal abstract class HttpTransportLayerBodyGreen : SoalGreenNode
	{
	
	    public HttpTransportLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class HttpTransportLayerEmptyBodyGreen : HttpTransportLayerBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public HttpTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public HttpTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList httpTransportLayerProperties;
	    private InternalSyntaxToken tCloseBrace;
	
	    public HttpTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList httpTransportLayerProperties, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public HttpTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList httpTransportLayerProperties, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList HttpTransportLayerProperties { get { return this.httpTransportLayerProperties; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.httpTransportLayerProperties;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.httpTransportLayerProperties, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.httpTransportLayerProperties, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList httpTransportLayerProperties, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.httpTransportLayerProperties != httpTransportLayerProperties ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerNonEmptyBody(tOpenBrace, httpTransportLayerProperties, tCloseBrace);
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
	
	internal class RestTransportLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kTransport;
	    private InternalSyntaxToken irest;
	    private RestTransportLayerBodyGreen restTransportLayerBody;
	
	    public RestTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KTransport { get { return this.kTransport; } }
	    public InternalSyntaxToken IREST { get { return this.irest; } }
	    public RestTransportLayerBodyGreen RestTransportLayerBody { get { return this.restTransportLayerBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RestTransportLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTransport;
	            case 1: return this.irest;
	            case 2: return this.restTransportLayerBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RestTransportLayerGreen(this.Kind, this.kTransport, this.irest, this.restTransportLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RestTransportLayerGreen(this.Kind, this.kTransport, this.irest, this.restTransportLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public RestTransportLayerGreen Update(InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody)
	    {
	        if (this.kTransport != kTransport ||
				this.irest != irest ||
				this.restTransportLayerBody != restTransportLayerBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayer(kTransport, irest, restTransportLayerBody);
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
	
	internal abstract class RestTransportLayerBodyGreen : SoalGreenNode
	{
	
	    public RestTransportLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class RestTransportLayerEmptyBodyGreen : RestTransportLayerBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public RestTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public RestTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RestTransportLayerEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RestTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RestTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public RestTransportLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayerEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public RestTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.RestTransportLayerNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RestTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RestTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public RestTransportLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
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
	
	internal class WebSocketTransportLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kTransport;
	    private InternalSyntaxToken iWebSocket;
	    private WebSocketTransportLayerBodyGreen webSocketTransportLayerBody;
	
	    public WebSocketTransportLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KTransport { get { return this.kTransport; } }
	    public InternalSyntaxToken IWebSocket { get { return this.iWebSocket; } }
	    public WebSocketTransportLayerBodyGreen WebSocketTransportLayerBody { get { return this.webSocketTransportLayerBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WebSocketTransportLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTransport;
	            case 1: return this.iWebSocket;
	            case 2: return this.webSocketTransportLayerBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WebSocketTransportLayerGreen(this.Kind, this.kTransport, this.iWebSocket, this.webSocketTransportLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WebSocketTransportLayerGreen(this.Kind, this.kTransport, this.iWebSocket, this.webSocketTransportLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public WebSocketTransportLayerGreen Update(InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody)
	    {
	        if (this.kTransport != kTransport ||
				this.iWebSocket != iWebSocket ||
				this.webSocketTransportLayerBody != webSocketTransportLayerBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayer(kTransport, iWebSocket, webSocketTransportLayerBody);
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
	
	internal abstract class WebSocketTransportLayerBodyGreen : SoalGreenNode
	{
	
	    public WebSocketTransportLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class WebSocketTransportLayerEmptyBodyGreen : WebSocketTransportLayerBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public WebSocketTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public WebSocketTransportLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WebSocketTransportLayerEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WebSocketTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WebSocketTransportLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public WebSocketTransportLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayerEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public WebSocketTransportLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.WebSocketTransportLayerNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WebSocketTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WebSocketTransportLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public WebSocketTransportLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
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
	
	internal class HttpTransportLayerPropertiesGreen : SoalGreenNode
	{
	    private HttpSslPropertyGreen httpSslProperty;
	    private HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty;
	
	    public HttpTransportLayerPropertiesGreen(SoalSyntaxKind kind, HttpSslPropertyGreen httpSslProperty, HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public HttpSslPropertyGreen HttpSslProperty { get { return this.httpSslProperty; } }
	    public HttpClientAuthenticationPropertyGreen HttpClientAuthenticationProperty { get { return this.httpClientAuthenticationProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpTransportLayerPropertiesSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.httpSslProperty;
	            case 1: return this.httpClientAuthenticationProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpTransportLayerPropertiesGreen(this.Kind, this.httpSslProperty, this.httpClientAuthenticationProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpTransportLayerPropertiesGreen(this.Kind, this.httpSslProperty, this.httpClientAuthenticationProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpTransportLayerPropertiesGreen Update(HttpSslPropertyGreen httpSslProperty)
	    {
	        if (this.httpSslProperty != httpSslProperty)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerProperties(httpSslProperty);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerProperties(httpClientAuthenticationProperty);
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
	
	internal class HttpSslPropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken issl;
	    private InternalSyntaxToken tAssign;
	    private BooleanLiteralGreen booleanLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public HttpSslPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken ISSL { get { return this.issl; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpSslPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpSslPropertyGreen(this.Kind, this.issl, this.tAssign, this.booleanLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpSslPropertyGreen(this.Kind, this.issl, this.tAssign, this.booleanLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpSslPropertyGreen Update(InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.issl != issl ||
				this.tAssign != tAssign ||
				this.booleanLiteral != booleanLiteral ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpSslProperty(issl, tAssign, booleanLiteral, tSemicolon);
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
	
	internal class HttpClientAuthenticationPropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken iClientAuthentication;
	    private InternalSyntaxToken tAssign;
	    private BooleanLiteralGreen booleanLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public HttpClientAuthenticationPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken IClientAuthentication { get { return this.iClientAuthentication; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.HttpClientAuthenticationPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HttpClientAuthenticationPropertyGreen(this.Kind, this.iClientAuthentication, this.tAssign, this.booleanLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HttpClientAuthenticationPropertyGreen(this.Kind, this.iClientAuthentication, this.tAssign, this.booleanLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public HttpClientAuthenticationPropertyGreen Update(InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.iClientAuthentication != iClientAuthentication ||
				this.tAssign != tAssign ||
				this.booleanLiteral != booleanLiteral ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.HttpClientAuthenticationProperty(iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
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
	
	internal class EncodingLayerGreen : SoalGreenNode
	{
	    private SoapEncodingLayerGreen soapEncodingLayer;
	    private XmlEncodingLayerGreen xmlEncodingLayer;
	    private JsonEncodingLayerGreen jsonEncodingLayer;
	
	    public EncodingLayerGreen(SoalSyntaxKind kind, SoapEncodingLayerGreen soapEncodingLayer, XmlEncodingLayerGreen xmlEncodingLayer, JsonEncodingLayerGreen jsonEncodingLayer)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public SoapEncodingLayerGreen SoapEncodingLayer { get { return this.soapEncodingLayer; } }
	    public XmlEncodingLayerGreen XmlEncodingLayer { get { return this.xmlEncodingLayer; } }
	    public JsonEncodingLayerGreen JsonEncodingLayer { get { return this.jsonEncodingLayer; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EncodingLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.soapEncodingLayer;
	            case 1: return this.xmlEncodingLayer;
	            case 2: return this.jsonEncodingLayer;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EncodingLayerGreen(this.Kind, this.soapEncodingLayer, this.xmlEncodingLayer, this.jsonEncodingLayer, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EncodingLayerGreen(this.Kind, this.soapEncodingLayer, this.xmlEncodingLayer, this.jsonEncodingLayer, this.GetDiagnostics(), annotations);
	    }
	
	    public EncodingLayerGreen Update(SoapEncodingLayerGreen soapEncodingLayer)
	    {
	        if (this.soapEncodingLayer != soapEncodingLayer)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer(soapEncodingLayer);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer(xmlEncodingLayer);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer(jsonEncodingLayer);
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
	
	internal class SoapEncodingLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kEncoding;
	    private InternalSyntaxToken isoap;
	    private SoapEncodingLayerBodyGreen soapEncodingLayerBody;
	
	    public SoapEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KEncoding { get { return this.kEncoding; } }
	    public InternalSyntaxToken ISOAP { get { return this.isoap; } }
	    public SoapEncodingLayerBodyGreen SoapEncodingLayerBody { get { return this.soapEncodingLayerBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEncoding;
	            case 1: return this.isoap;
	            case 2: return this.soapEncodingLayerBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingLayerGreen(this.Kind, this.kEncoding, this.isoap, this.soapEncodingLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingLayerGreen(this.Kind, this.kEncoding, this.isoap, this.soapEncodingLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingLayerGreen Update(InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody)
	    {
	        if (this.kEncoding != kEncoding ||
				this.isoap != isoap ||
				this.soapEncodingLayerBody != soapEncodingLayerBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayer(kEncoding, isoap, soapEncodingLayerBody);
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
	
	internal abstract class SoapEncodingLayerBodyGreen : SoalGreenNode
	{
	
	    public SoapEncodingLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class SoapEncodingLayerEmptyBodyGreen : SoapEncodingLayerBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public SoapEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingLayerEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayerEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList soapEncodingProperties;
	    private InternalSyntaxToken tCloseBrace;
	
	    public SoapEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList soapEncodingProperties, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public SoapEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList soapEncodingProperties, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList SoapEncodingProperties { get { return this.soapEncodingProperties; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingLayerNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.soapEncodingProperties;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.soapEncodingProperties, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.soapEncodingProperties, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList soapEncodingProperties, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.soapEncodingProperties != soapEncodingProperties ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayerNonEmptyBody(tOpenBrace, soapEncodingProperties, tCloseBrace);
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
	
	internal class XmlEncodingLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kEncoding;
	    private InternalSyntaxToken ixml;
	    private XmlEncodingLayerBodyGreen xmlEncodingLayerBody;
	
	    public XmlEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KEncoding { get { return this.kEncoding; } }
	    public InternalSyntaxToken IXML { get { return this.ixml; } }
	    public XmlEncodingLayerBodyGreen XmlEncodingLayerBody { get { return this.xmlEncodingLayerBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.XmlEncodingLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEncoding;
	            case 1: return this.ixml;
	            case 2: return this.xmlEncodingLayerBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XmlEncodingLayerGreen(this.Kind, this.kEncoding, this.ixml, this.xmlEncodingLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XmlEncodingLayerGreen(this.Kind, this.kEncoding, this.ixml, this.xmlEncodingLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public XmlEncodingLayerGreen Update(InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody)
	    {
	        if (this.kEncoding != kEncoding ||
				this.ixml != ixml ||
				this.xmlEncodingLayerBody != xmlEncodingLayerBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayer(kEncoding, ixml, xmlEncodingLayerBody);
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
	
	internal abstract class XmlEncodingLayerBodyGreen : SoalGreenNode
	{
	
	    public XmlEncodingLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class XmlEncodingLayerEmptyBodyGreen : XmlEncodingLayerBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public XmlEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public XmlEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.XmlEncodingLayerEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XmlEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XmlEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public XmlEncodingLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayerEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public XmlEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.XmlEncodingLayerNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new XmlEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new XmlEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public XmlEncodingLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
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
	
	internal class JsonEncodingLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kEncoding;
	    private InternalSyntaxToken ijson;
	    private JsonEncodingLayerBodyGreen jsonEncodingLayerBody;
	
	    public JsonEncodingLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KEncoding { get { return this.kEncoding; } }
	    public InternalSyntaxToken IJSON { get { return this.ijson; } }
	    public JsonEncodingLayerBodyGreen JsonEncodingLayerBody { get { return this.jsonEncodingLayerBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.JsonEncodingLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEncoding;
	            case 1: return this.ijson;
	            case 2: return this.jsonEncodingLayerBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new JsonEncodingLayerGreen(this.Kind, this.kEncoding, this.ijson, this.jsonEncodingLayerBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new JsonEncodingLayerGreen(this.Kind, this.kEncoding, this.ijson, this.jsonEncodingLayerBody, this.GetDiagnostics(), annotations);
	    }
	
	    public JsonEncodingLayerGreen Update(InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody)
	    {
	        if (this.kEncoding != kEncoding ||
				this.ijson != ijson ||
				this.jsonEncodingLayerBody != jsonEncodingLayerBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayer(kEncoding, ijson, jsonEncodingLayerBody);
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
	
	internal abstract class JsonEncodingLayerBodyGreen : SoalGreenNode
	{
	
	    public JsonEncodingLayerBodyGreen(SoalSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class JsonEncodingLayerEmptyBodyGreen : JsonEncodingLayerBodyGreen
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public JsonEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public JsonEncodingLayerEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.JsonEncodingLayerEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new JsonEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new JsonEncodingLayerEmptyBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public JsonEncodingLayerEmptyBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayerEmptyBody(tSemicolon);
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
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public JsonEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.JsonEncodingLayerNonEmptyBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new JsonEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new JsonEncodingLayerNonEmptyBodyGreen(this.Kind, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public JsonEncodingLayerNonEmptyBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
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
	
	internal class SoapEncodingPropertiesGreen : SoalGreenNode
	{
	    private SoapVersionPropertyGreen soapVersionProperty;
	    private SoapMtomPropertyGreen soapMtomProperty;
	    private SoapStylePropertyGreen soapStyleProperty;
	
	    public SoapEncodingPropertiesGreen(SoalSyntaxKind kind, SoapVersionPropertyGreen soapVersionProperty, SoapMtomPropertyGreen soapMtomProperty, SoapStylePropertyGreen soapStyleProperty)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public SoapVersionPropertyGreen SoapVersionProperty { get { return this.soapVersionProperty; } }
	    public SoapMtomPropertyGreen SoapMtomProperty { get { return this.soapMtomProperty; } }
	    public SoapStylePropertyGreen SoapStyleProperty { get { return this.soapStyleProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapEncodingPropertiesSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.soapVersionProperty;
	            case 1: return this.soapMtomProperty;
	            case 2: return this.soapStyleProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapEncodingPropertiesGreen(this.Kind, this.soapVersionProperty, this.soapMtomProperty, this.soapStyleProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapEncodingPropertiesGreen(this.Kind, this.soapVersionProperty, this.soapMtomProperty, this.soapStyleProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapEncodingPropertiesGreen Update(SoapVersionPropertyGreen soapVersionProperty)
	    {
	        if (this.soapVersionProperty != soapVersionProperty)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties(soapVersionProperty);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties(soapMtomProperty);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties(soapStyleProperty);
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
	
	internal class SoapVersionPropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken iVersion;
	    private InternalSyntaxToken tAssign;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapVersionPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken IVersion { get { return this.iVersion; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapVersionPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapVersionPropertyGreen(this.Kind, this.iVersion, this.tAssign, this.identifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapVersionPropertyGreen(this.Kind, this.iVersion, this.tAssign, this.identifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapVersionPropertyGreen Update(InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.iVersion != iVersion ||
				this.tAssign != tAssign ||
				this.identifier != identifier ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapVersionProperty(iVersion, tAssign, identifier, tSemicolon);
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
	
	internal class SoapMtomPropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken imtom;
	    private InternalSyntaxToken tAssign;
	    private BooleanLiteralGreen booleanLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapMtomPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken IMTOM { get { return this.imtom; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapMtomPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapMtomPropertyGreen(this.Kind, this.imtom, this.tAssign, this.booleanLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapMtomPropertyGreen(this.Kind, this.imtom, this.tAssign, this.booleanLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapMtomPropertyGreen Update(InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.imtom != imtom ||
				this.tAssign != tAssign ||
				this.booleanLiteral != booleanLiteral ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapMtomProperty(imtom, tAssign, booleanLiteral, tSemicolon);
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
	
	internal class SoapStylePropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken iStyle;
	    private InternalSyntaxToken tAssign;
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public SoapStylePropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken IStyle { get { return this.iStyle; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SoapStylePropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SoapStylePropertyGreen(this.Kind, this.iStyle, this.tAssign, this.identifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SoapStylePropertyGreen(this.Kind, this.iStyle, this.tAssign, this.identifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public SoapStylePropertyGreen Update(InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.iStyle != iStyle ||
				this.tAssign != tAssign ||
				this.identifier != identifier ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SoapStyleProperty(iStyle, tAssign, identifier, tSemicolon);
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
	
	internal class ProtocolLayerGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kProtocol;
	    private ProtocolLayerKindGreen protocolLayerKind;
	    private InternalSyntaxToken tSemicolon;
	
	    public ProtocolLayerGreen(SoalSyntaxKind kind, InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KProtocol { get { return this.kProtocol; } }
	    public ProtocolLayerKindGreen ProtocolLayerKind { get { return this.protocolLayerKind; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ProtocolLayerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kProtocol;
	            case 1: return this.protocolLayerKind;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ProtocolLayerGreen(this.Kind, this.kProtocol, this.protocolLayerKind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ProtocolLayerGreen(this.Kind, this.kProtocol, this.protocolLayerKind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ProtocolLayerGreen Update(InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kProtocol != kProtocol ||
				this.protocolLayerKind != protocolLayerKind ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ProtocolLayer(kProtocol, protocolLayerKind, tSemicolon);
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
	
	internal class ProtocolLayerKindGreen : SoalGreenNode
	{
	    private IdentifierGreen identifier;
	
	    public ProtocolLayerKindGreen(SoalSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public ProtocolLayerKindGreen(SoalSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ProtocolLayerKindSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ProtocolLayerKindGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ProtocolLayerKindGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ProtocolLayerKindGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ProtocolLayerKind(identifier);
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
	
	internal class EndpointDeclarationGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kEndpoint;
	    private NameDefGreen nameDef;
	    private InternalSyntaxToken tColon;
	    private QualifiedNameGreen qualifiedName;
	    private EndpointBodyGreen endpointBody;
	
	    public EndpointDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEndpoint, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EndpointBodyGreen endpointBody)
	        : base(kind, null, null)
	    {
			if (kEndpoint != null)
			{
				this.AdjustFlagsAndWidth(kEndpoint);
				this.kEndpoint = kEndpoint;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (endpointBody != null)
			{
				this.AdjustFlagsAndWidth(endpointBody);
				this.endpointBody = endpointBody;
			}
	    }
	
	    public EndpointDeclarationGreen(SoalSyntaxKind kind, InternalSyntaxToken kEndpoint, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EndpointBodyGreen endpointBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kEndpoint != null)
			{
				this.AdjustFlagsAndWidth(kEndpoint);
				this.kEndpoint = kEndpoint;
			}
			if (nameDef != null)
			{
				this.AdjustFlagsAndWidth(nameDef);
				this.nameDef = nameDef;
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
			if (endpointBody != null)
			{
				this.AdjustFlagsAndWidth(endpointBody);
				this.endpointBody = endpointBody;
			}
	    }
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken KEndpoint { get { return this.kEndpoint; } }
	    public NameDefGreen NameDef { get { return this.nameDef; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public EndpointBodyGreen EndpointBody { get { return this.endpointBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kEndpoint;
	            case 1: return this.nameDef;
	            case 2: return this.tColon;
	            case 3: return this.qualifiedName;
	            case 4: return this.endpointBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointDeclarationGreen(this.Kind, this.kEndpoint, this.nameDef, this.tColon, this.qualifiedName, this.endpointBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointDeclarationGreen(this.Kind, this.kEndpoint, this.nameDef, this.tColon, this.qualifiedName, this.endpointBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointDeclarationGreen Update(InternalSyntaxToken kEndpoint, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EndpointBodyGreen endpointBody)
	    {
	        if (this.kEndpoint != kEndpoint ||
				this.nameDef != nameDef ||
				this.tColon != tColon ||
				this.qualifiedName != qualifiedName ||
				this.endpointBody != endpointBody)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointDeclaration(kEndpoint, nameDef, tColon, qualifiedName, endpointBody);
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
	
	internal class EndpointBodyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private EndpointPropertiesGreen endpointProperties;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EndpointBodyGreen(SoalSyntaxKind kind, InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public EndpointPropertiesGreen EndpointProperties { get { return this.endpointProperties; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.endpointProperties;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointBodyGreen(this.Kind, this.tOpenBrace, this.endpointProperties, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointBodyGreen(this.Kind, this.tOpenBrace, this.endpointProperties, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointBodyGreen Update(InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.endpointProperties != endpointProperties ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointBody(tOpenBrace, endpointProperties, tCloseBrace);
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
	
	internal class EndpointPropertiesGreen : SoalGreenNode
	{
	    private InternalSyntaxNodeList endpointProperty;
	
	    public EndpointPropertiesGreen(SoalSyntaxKind kind, InternalSyntaxNodeList endpointProperty)
	        : base(kind, null, null)
	    {
			if (endpointProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointProperty);
				this.endpointProperty = endpointProperty;
			}
	    }
	
	    public EndpointPropertiesGreen(SoalSyntaxKind kind, InternalSyntaxNodeList endpointProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (endpointProperty != null)
			{
				this.AdjustFlagsAndWidth(endpointProperty);
				this.endpointProperty = endpointProperty;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList EndpointProperty { get { return this.endpointProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointPropertiesSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.endpointProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointPropertiesGreen(this.Kind, this.endpointProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointPropertiesGreen(this.Kind, this.endpointProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointPropertiesGreen Update(InternalSyntaxNodeList endpointProperty)
	    {
	        if (this.endpointProperty != endpointProperty)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperties(endpointProperty);
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
	
	internal class EndpointPropertyGreen : SoalGreenNode
	{
	    private EndpointBindingPropertyGreen endpointBindingProperty;
	    private EndpointAddressPropertyGreen endpointAddressProperty;
	
	    public EndpointPropertyGreen(SoalSyntaxKind kind, EndpointBindingPropertyGreen endpointBindingProperty, EndpointAddressPropertyGreen endpointAddressProperty)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public EndpointBindingPropertyGreen EndpointBindingProperty { get { return this.endpointBindingProperty; } }
	    public EndpointAddressPropertyGreen EndpointAddressProperty { get { return this.endpointAddressProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.endpointBindingProperty;
	            case 1: return this.endpointAddressProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointPropertyGreen(this.Kind, this.endpointBindingProperty, this.endpointAddressProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointPropertyGreen(this.Kind, this.endpointBindingProperty, this.endpointAddressProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointPropertyGreen Update(EndpointBindingPropertyGreen endpointBindingProperty)
	    {
	        if (this.endpointBindingProperty != endpointBindingProperty)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperty(endpointBindingProperty);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperty(endpointAddressProperty);
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
	
	internal class EndpointBindingPropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kBinding;
	    private QualifiedNameGreen qualifiedName;
	    private InternalSyntaxToken tSemicolon;
	
	    public EndpointBindingPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
	    public EndpointBindingPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kBinding != null)
			{
				this.AdjustFlagsAndWidth(kBinding);
				this.kBinding = kBinding;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KBinding { get { return this.kBinding; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointBindingPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kBinding;
	            case 1: return this.qualifiedName;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointBindingPropertyGreen(this.Kind, this.kBinding, this.qualifiedName, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointBindingPropertyGreen(this.Kind, this.kBinding, this.qualifiedName, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointBindingPropertyGreen Update(InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kBinding != kBinding ||
				this.qualifiedName != qualifiedName ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointBindingProperty(kBinding, qualifiedName, tSemicolon);
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
	
	internal class EndpointAddressPropertyGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kAddress;
	    private StringLiteralGreen stringLiteral;
	    private InternalSyntaxToken tSemicolon;
	
	    public EndpointAddressPropertyGreen(SoalSyntaxKind kind, InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KAddress { get { return this.kAddress; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.EndpointAddressPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kAddress;
	            case 1: return this.stringLiteral;
	            case 2: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EndpointAddressPropertyGreen(this.Kind, this.kAddress, this.stringLiteral, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EndpointAddressPropertyGreen(this.Kind, this.kAddress, this.stringLiteral, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EndpointAddressPropertyGreen Update(InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kAddress != kAddress ||
				this.stringLiteral != stringLiteral ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.EndpointAddressProperty(kAddress, stringLiteral, tSemicolon);
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
	
	internal class ReturnTypeGreen : SoalGreenNode
	{
	    private TypeReferenceGreen typeReference;
	    private VoidTypeGreen voidType;
	
	    public ReturnTypeGreen(SoalSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType)
	        : base(kind, null, null)
	    {
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
	
	    public ReturnTypeGreen(SoalSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public VoidTypeGreen VoidType { get { return this.voidType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReturnTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            case 1: return this.voidType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReturnTypeGreen(this.Kind, this.typeReference, this.voidType, this.GetDiagnostics(), annotations);
	    }
	
	    public ReturnTypeGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.typeReference != typeReference)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
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
	
	internal class TypeReferenceGreen : SoalGreenNode
	{
	    private NonNullableArrayTypeGreen nonNullableArrayType;
	    private ArrayTypeGreen arrayType;
	    private SimpleTypeGreen simpleType;
	    private NulledTypeGreen nulledType;
	
	    public TypeReferenceGreen(SoalSyntaxKind kind, NonNullableArrayTypeGreen nonNullableArrayType, ArrayTypeGreen arrayType, SimpleTypeGreen simpleType, NulledTypeGreen nulledType)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public NonNullableArrayTypeGreen NonNullableArrayType { get { return this.nonNullableArrayType; } }
	    public ArrayTypeGreen ArrayType { get { return this.arrayType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public NulledTypeGreen NulledType { get { return this.nulledType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.TypeReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.nonNullableArrayType, this.arrayType, this.simpleType, this.nulledType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.nonNullableArrayType, this.arrayType, this.simpleType, this.nulledType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(NonNullableArrayTypeGreen nonNullableArrayType)
	    {
	        if (this.nonNullableArrayType != nonNullableArrayType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(nonNullableArrayType);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(arrayType);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleType);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeReference(nulledType);
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
	
	internal class SimpleTypeGreen : SoalGreenNode
	{
	    private ValueTypeGreen valueType;
	    private ObjectTypeGreen objectType;
	    private QualifiedNameGreen qualifiedName;
	
	    public SimpleTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, ObjectTypeGreen objectType, QualifiedNameGreen qualifiedName)
	        : base(kind, null, null)
	    {
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
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
	    public SimpleTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, ObjectTypeGreen objectType, QualifiedNameGreen qualifiedName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public ValueTypeGreen ValueType { get { return this.valueType; } }
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SimpleTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.valueType;
	            case 1: return this.objectType;
	            case 2: return this.qualifiedName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleTypeGreen(this.Kind, this.valueType, this.objectType, this.qualifiedName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleTypeGreen(this.Kind, this.valueType, this.objectType, this.qualifiedName, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleTypeGreen Update(ValueTypeGreen valueType)
	    {
	        if (this.valueType != valueType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleType(valueType);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleType(objectType);
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
	
	    public SimpleTypeGreen Update(QualifiedNameGreen qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleType(qualifiedName);
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
	
	internal class NulledTypeGreen : SoalGreenNode
	{
	    private NullableTypeGreen nullableType;
	    private NonNullableTypeGreen nonNullableType;
	
	    public NulledTypeGreen(SoalSyntaxKind kind, NullableTypeGreen nullableType, NonNullableTypeGreen nonNullableType)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public NonNullableTypeGreen NonNullableType { get { return this.nonNullableType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NulledTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nullableType;
	            case 1: return this.nonNullableType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NulledTypeGreen(this.Kind, this.nullableType, this.nonNullableType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NulledTypeGreen(this.Kind, this.nullableType, this.nonNullableType, this.GetDiagnostics(), annotations);
	    }
	
	    public NulledTypeGreen Update(NullableTypeGreen nullableType)
	    {
	        if (this.nullableType != nullableType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NulledType(nullableType);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NulledType(nonNullableType);
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
	
	internal class ReferenceTypeGreen : SoalGreenNode
	{
	    private ObjectTypeGreen objectType;
	    private QualifiedNameGreen qualifiedName;
	
	    public ReferenceTypeGreen(SoalSyntaxKind kind, ObjectTypeGreen objectType, QualifiedNameGreen qualifiedName)
	        : base(kind, null, null)
	    {
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
	    public ReferenceTypeGreen(SoalSyntaxKind kind, ObjectTypeGreen objectType, QualifiedNameGreen qualifiedName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ReferenceTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.objectType;
	            case 1: return this.qualifiedName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ReferenceTypeGreen(this.Kind, this.objectType, this.qualifiedName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ReferenceTypeGreen(this.Kind, this.objectType, this.qualifiedName, this.GetDiagnostics(), annotations);
	    }
	
	    public ReferenceTypeGreen Update(ObjectTypeGreen objectType)
	    {
	        if (this.objectType != objectType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReferenceType(objectType);
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
	
	    public ReferenceTypeGreen Update(QualifiedNameGreen qualifiedName)
	    {
	        if (this.qualifiedName != qualifiedName)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ReferenceType(qualifiedName);
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
	
	internal class ObjectTypeGreen : SoalGreenNode
	{
	    private InternalSyntaxToken objectType;
	
	    public ObjectTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken objectType)
	        : base(kind, null, null)
	    {
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
	    public ObjectTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken objectType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken ObjectType { get { return this.objectType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ObjectTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.objectType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ObjectTypeGreen(this.Kind, this.objectType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ObjectTypeGreen(this.Kind, this.objectType, this.GetDiagnostics(), annotations);
	    }
	
	    public ObjectTypeGreen Update(InternalSyntaxToken objectType)
	    {
	        if (this.objectType != objectType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ObjectType(objectType);
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
	
	internal class ValueTypeGreen : SoalGreenNode
	{
	    private InternalSyntaxToken valueType;
	
	    public ValueTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken valueType)
	        : base(kind, null, null)
	    {
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
	    }
	
	    public ValueTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken valueType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (valueType != null)
			{
				this.AdjustFlagsAndWidth(valueType);
				this.valueType = valueType;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken ValueType { get { return this.valueType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ValueTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.valueType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ValueTypeGreen(this.Kind, this.valueType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ValueTypeGreen(this.Kind, this.valueType, this.GetDiagnostics(), annotations);
	    }
	
	    public ValueTypeGreen Update(InternalSyntaxToken valueType)
	    {
	        if (this.valueType != valueType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ValueType(valueType);
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
	
	internal class VoidTypeGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kVoid;
	
	    public VoidTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken KVoid { get { return this.kVoid; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.VoidTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kVoid;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new VoidTypeGreen(this.Kind, this.kVoid, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new VoidTypeGreen(this.Kind, this.kVoid, this.GetDiagnostics(), annotations);
	    }
	
	    public VoidTypeGreen Update(InternalSyntaxToken kVoid)
	    {
	        if (this.kVoid != kVoid)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
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
	
	internal class OnewayTypeGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kOneway;
	
	    public OnewayTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kOneway)
	        : base(kind, null, null)
	    {
			if (kOneway != null)
			{
				this.AdjustFlagsAndWidth(kOneway);
				this.kOneway = kOneway;
			}
	    }
	
	    public OnewayTypeGreen(SoalSyntaxKind kind, InternalSyntaxToken kOneway, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kOneway != null)
			{
				this.AdjustFlagsAndWidth(kOneway);
				this.kOneway = kOneway;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken KOneway { get { return this.kOneway; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OnewayTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kOneway;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OnewayTypeGreen(this.Kind, this.kOneway, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OnewayTypeGreen(this.Kind, this.kOneway, this.GetDiagnostics(), annotations);
	    }
	
	    public OnewayTypeGreen Update(InternalSyntaxToken kOneway)
	    {
	        if (this.kOneway != kOneway)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OnewayType(kOneway);
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
	
	internal class OperationReturnTypeGreen : SoalGreenNode
	{
	    private ReturnTypeGreen returnType;
	    private OnewayTypeGreen onewayType;
	
	    public OperationReturnTypeGreen(SoalSyntaxKind kind, ReturnTypeGreen returnType, OnewayTypeGreen onewayType)
	        : base(kind, null, null)
	    {
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
			if (onewayType != null)
			{
				this.AdjustFlagsAndWidth(onewayType);
				this.onewayType = onewayType;
			}
	    }
	
	    public OperationReturnTypeGreen(SoalSyntaxKind kind, ReturnTypeGreen returnType, OnewayTypeGreen onewayType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (returnType != null)
			{
				this.AdjustFlagsAndWidth(returnType);
				this.returnType = returnType;
			}
			if (onewayType != null)
			{
				this.AdjustFlagsAndWidth(onewayType);
				this.onewayType = onewayType;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public OnewayTypeGreen OnewayType { get { return this.onewayType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.OperationReturnTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.returnType;
	            case 1: return this.onewayType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationReturnTypeGreen(this.Kind, this.returnType, this.onewayType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationReturnTypeGreen(this.Kind, this.returnType, this.onewayType, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationReturnTypeGreen Update(ReturnTypeGreen returnType)
	    {
	        if (this.returnType != returnType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType(returnType);
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
	
	    public OperationReturnTypeGreen Update(OnewayTypeGreen onewayType)
	    {
	        if (this.onewayType != onewayType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType(onewayType);
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
	
	internal class NullableTypeGreen : SoalGreenNode
	{
	    private ValueTypeGreen valueType;
	    private InternalSyntaxToken tQuestion;
	
	    public NullableTypeGreen(SoalSyntaxKind kind, ValueTypeGreen valueType, InternalSyntaxToken tQuestion)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public ValueTypeGreen ValueType { get { return this.valueType; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NullableTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.valueType;
	            case 1: return this.tQuestion;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableTypeGreen(this.Kind, this.valueType, this.tQuestion, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableTypeGreen(this.Kind, this.valueType, this.tQuestion, this.GetDiagnostics(), annotations);
	    }
	
	    public NullableTypeGreen Update(ValueTypeGreen valueType, InternalSyntaxToken tQuestion)
	    {
	        if (this.valueType != valueType ||
				this.tQuestion != tQuestion)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NullableType(valueType, tQuestion);
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
	
	internal class NonNullableTypeGreen : SoalGreenNode
	{
	    private ReferenceTypeGreen referenceType;
	    private InternalSyntaxToken tExclamation;
	
	    public NonNullableTypeGreen(SoalSyntaxKind kind, ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public ReferenceTypeGreen ReferenceType { get { return this.referenceType; } }
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NonNullableTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.referenceType;
	            case 1: return this.tExclamation;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NonNullableTypeGreen(this.Kind, this.referenceType, this.tExclamation, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NonNullableTypeGreen(this.Kind, this.referenceType, this.tExclamation, this.GetDiagnostics(), annotations);
	    }
	
	    public NonNullableTypeGreen Update(ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation)
	    {
	        if (this.referenceType != referenceType ||
				this.tExclamation != tExclamation)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NonNullableType(referenceType, tExclamation);
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
	
	internal class NonNullableArrayTypeGreen : SoalGreenNode
	{
	    private ArrayTypeGreen arrayType;
	    private InternalSyntaxToken tExclamation;
	
	    public NonNullableArrayTypeGreen(SoalSyntaxKind kind, ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public ArrayTypeGreen ArrayType { get { return this.arrayType; } }
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NonNullableArrayTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arrayType;
	            case 1: return this.tExclamation;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NonNullableArrayTypeGreen(this.Kind, this.arrayType, this.tExclamation, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NonNullableArrayTypeGreen(this.Kind, this.arrayType, this.tExclamation, this.GetDiagnostics(), annotations);
	    }
	
	    public NonNullableArrayTypeGreen Update(ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation)
	    {
	        if (this.arrayType != arrayType ||
				this.tExclamation != tExclamation)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NonNullableArrayType(arrayType, tExclamation);
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
	
	internal class ArrayTypeGreen : SoalGreenNode
	{
	    private SimpleArrayTypeGreen simpleArrayType;
	    private NulledArrayTypeGreen nulledArrayType;
	
	    public ArrayTypeGreen(SoalSyntaxKind kind, SimpleArrayTypeGreen simpleArrayType, NulledArrayTypeGreen nulledArrayType)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public SimpleArrayTypeGreen SimpleArrayType { get { return this.simpleArrayType; } }
	    public NulledArrayTypeGreen NulledArrayType { get { return this.nulledArrayType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ArrayTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleArrayType;
	            case 1: return this.nulledArrayType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArrayTypeGreen(this.Kind, this.simpleArrayType, this.nulledArrayType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArrayTypeGreen(this.Kind, this.simpleArrayType, this.nulledArrayType, this.GetDiagnostics(), annotations);
	    }
	
	    public ArrayTypeGreen Update(SimpleArrayTypeGreen simpleArrayType)
	    {
	        if (this.simpleArrayType != simpleArrayType)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ArrayType(simpleArrayType);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ArrayType(nulledArrayType);
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
	
	internal class SimpleArrayTypeGreen : SoalGreenNode
	{
	    private SimpleTypeGreen simpleType;
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken tCloseBracket;
	
	    public SimpleArrayTypeGreen(SoalSyntaxKind kind, SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.SimpleArrayTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.simpleType;
	            case 1: return this.tOpenBracket;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleArrayTypeGreen(this.Kind, this.simpleType, this.tOpenBracket, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleArrayTypeGreen(this.Kind, this.simpleType, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleArrayTypeGreen Update(SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.simpleType != simpleType ||
				this.tOpenBracket != tOpenBracket ||
				this.tCloseBracket != tCloseBracket)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.SimpleArrayType(simpleType, tOpenBracket, tCloseBracket);
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
	
	internal class NulledArrayTypeGreen : SoalGreenNode
	{
	    private NulledTypeGreen nulledType;
	    private InternalSyntaxToken tOpenBracket;
	    private InternalSyntaxToken tCloseBracket;
	
	    public NulledArrayTypeGreen(SoalSyntaxKind kind, NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public NulledTypeGreen NulledType { get { return this.nulledType; } }
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NulledArrayTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.nulledType;
	            case 1: return this.tOpenBracket;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NulledArrayTypeGreen(this.Kind, this.nulledType, this.tOpenBracket, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NulledArrayTypeGreen(this.Kind, this.nulledType, this.tOpenBracket, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public NulledArrayTypeGreen Update(NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.nulledType != nulledType ||
				this.tOpenBracket != tOpenBracket ||
				this.tCloseBracket != tCloseBracket)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NulledArrayType(nulledType, tOpenBracket, tCloseBracket);
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
	
	internal class ConstantValueGreen : SoalGreenNode
	{
	    private LiteralGreen literal;
	    private IdentifierGreen identifier;
	
	    public ConstantValueGreen(SoalSyntaxKind kind, LiteralGreen literal, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public LiteralGreen Literal { get { return this.literal; } }
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ConstantValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.literal;
	            case 1: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConstantValueGreen(this.Kind, this.literal, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConstantValueGreen(this.Kind, this.literal, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ConstantValueGreen Update(LiteralGreen literal)
	    {
	        if (this.literal != literal)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ConstantValue(literal);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ConstantValue(identifier);
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
	
	internal class TypeofValueGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kTypeof;
	    private InternalSyntaxToken tOpenParen;
	    private ReturnTypeGreen returnType;
	    private InternalSyntaxToken tCloseParen;
	
	    public TypeofValueGreen(SoalSyntaxKind kind, InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken KTypeof { get { return this.kTypeof; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.TypeofValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeofValueGreen(this.Kind, this.kTypeof, this.tOpenParen, this.returnType, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeofValueGreen(this.Kind, this.kTypeof, this.tOpenParen, this.returnType, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeofValueGreen Update(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen)
	    {
	        if (this.kTypeof != kTypeof ||
				this.tOpenParen != tOpenParen ||
				this.returnType != returnType ||
				this.tCloseParen != tCloseParen)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.TypeofValue(kTypeof, tOpenParen, returnType, tCloseParen);
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
	
	internal class IdentifierGreen : SoalGreenNode
	{
	    private IdentifiersGreen identifiers;
	    private ContextualKeywordsGreen contextualKeywords;
	
	    public IdentifierGreen(SoalSyntaxKind kind, IdentifiersGreen identifiers, ContextualKeywordsGreen contextualKeywords)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public IdentifiersGreen Identifiers { get { return this.identifiers; } }
	    public ContextualKeywordsGreen ContextualKeywords { get { return this.contextualKeywords; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IdentifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifiers;
	            case 1: return this.contextualKeywords;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.identifiers, this.contextualKeywords, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.identifiers, this.contextualKeywords, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(IdentifiersGreen identifiers)
	    {
	        if (this.identifiers != identifiers)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Identifier(identifiers);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Identifier(contextualKeywords);
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
	
	internal class IdentifiersGreen : SoalGreenNode
	{
	    private InternalSyntaxToken identifiers;
	
	    public IdentifiersGreen(SoalSyntaxKind kind, InternalSyntaxToken identifiers)
	        : base(kind, null, null)
	    {
			if (identifiers != null)
			{
				this.AdjustFlagsAndWidth(identifiers);
				this.identifiers = identifiers;
			}
	    }
	
	    public IdentifiersGreen(SoalSyntaxKind kind, InternalSyntaxToken identifiers, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifiers != null)
			{
				this.AdjustFlagsAndWidth(identifiers);
				this.identifiers = identifiers;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken Identifiers { get { return this.identifiers; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IdentifiersSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifiers;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifiersGreen(this.Kind, this.identifiers, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifiersGreen(this.Kind, this.identifiers, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifiersGreen Update(InternalSyntaxToken identifiers)
	    {
	        if (this.identifiers != identifiers)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Identifiers(identifiers);
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
	
	internal class LiteralGreen : SoalGreenNode
	{
	    private NullLiteralGreen nullLiteral;
	    private BooleanLiteralGreen booleanLiteral;
	    private IntegerLiteralGreen integerLiteral;
	    private DecimalLiteralGreen decimalLiteral;
	    private ScientificLiteralGreen scientificLiteral;
	    private StringLiteralGreen stringLiteral;
	
	    public LiteralGreen(SoalSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
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
	
		public override int SlotCount { get { return 6; } }
	
	    public NullLiteralGreen NullLiteral { get { return this.nullLiteral; } }
	    public BooleanLiteralGreen BooleanLiteral { get { return this.booleanLiteral; } }
	    public IntegerLiteralGreen IntegerLiteral { get { return this.integerLiteral; } }
	    public DecimalLiteralGreen DecimalLiteral { get { return this.decimalLiteral; } }
	    public ScientificLiteralGreen ScientificLiteral { get { return this.scientificLiteral; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.LiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LiteralGreen(this.Kind, this.nullLiteral, this.booleanLiteral, this.integerLiteral, this.decimalLiteral, this.scientificLiteral, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public LiteralGreen Update(NullLiteralGreen nullLiteral)
	    {
	        if (this.nullLiteral != nullLiteral)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	internal class NullLiteralGreen : SoalGreenNode
	{
	    private InternalSyntaxToken kNull;
	
	    public NullLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken KNull { get { return this.kNull; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.NullLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNull;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullLiteralGreen(this.Kind, this.kNull, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullLiteralGreen(this.Kind, this.kNull, this.GetDiagnostics(), annotations);
	    }
	
	    public NullLiteralGreen Update(InternalSyntaxToken kNull)
	    {
	        if (this.kNull != kNull)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	internal class BooleanLiteralGreen : SoalGreenNode
	{
	    private InternalSyntaxToken booleanLiteral;
	
	    public BooleanLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken BooleanLiteral { get { return this.booleanLiteral; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.BooleanLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.booleanLiteral;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BooleanLiteralGreen(this.Kind, this.booleanLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public BooleanLiteralGreen Update(InternalSyntaxToken booleanLiteral)
	    {
	        if (this.booleanLiteral != booleanLiteral)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	internal class IntegerLiteralGreen : SoalGreenNode
	{
	    private InternalSyntaxToken lInteger;
	
	    public IntegerLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken LInteger { get { return this.lInteger; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.IntegerLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lInteger;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IntegerLiteralGreen(this.Kind, this.lInteger, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IntegerLiteralGreen(this.Kind, this.lInteger, this.GetDiagnostics(), annotations);
	    }
	
	    public IntegerLiteralGreen Update(InternalSyntaxToken lInteger)
	    {
	        if (this.lInteger != lInteger)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	internal class DecimalLiteralGreen : SoalGreenNode
	{
	    private InternalSyntaxToken lDecimal;
	
	    public DecimalLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken LDecimal { get { return this.lDecimal; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.DecimalLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lDecimal;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DecimalLiteralGreen(this.Kind, this.lDecimal, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DecimalLiteralGreen(this.Kind, this.lDecimal, this.GetDiagnostics(), annotations);
	    }
	
	    public DecimalLiteralGreen Update(InternalSyntaxToken lDecimal)
	    {
	        if (this.lDecimal != lDecimal)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	internal class ScientificLiteralGreen : SoalGreenNode
	{
	    private InternalSyntaxToken lScientific;
	
	    public ScientificLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken LScientific { get { return this.lScientific; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ScientificLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lScientific;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ScientificLiteralGreen(this.Kind, this.lScientific, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ScientificLiteralGreen(this.Kind, this.lScientific, this.GetDiagnostics(), annotations);
	    }
	
	    public ScientificLiteralGreen Update(InternalSyntaxToken lScientific)
	    {
	        if (this.lScientific != lScientific)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	
	internal class StringLiteralGreen : SoalGreenNode
	{
	    private InternalSyntaxToken stringLiteral;
	
	    public StringLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken stringLiteral)
	        : base(kind, null, null)
	    {
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
	    public StringLiteralGreen(SoalSyntaxKind kind, InternalSyntaxToken stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (stringLiteral != null)
			{
				this.AdjustFlagsAndWidth(stringLiteral);
				this.stringLiteral = stringLiteral;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken StringLiteral { get { return this.stringLiteral; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.StringLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringLiteralGreen(this.Kind, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringLiteralGreen(this.Kind, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public StringLiteralGreen Update(InternalSyntaxToken stringLiteral)
	    {
	        if (this.stringLiteral != stringLiteral)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.StringLiteral(stringLiteral);
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
	
	internal class ContextualKeywordsGreen : SoalGreenNode
	{
	    private InternalSyntaxToken contextualKeywords;
	
	    public ContextualKeywordsGreen(SoalSyntaxKind kind, InternalSyntaxToken contextualKeywords)
	        : base(kind, null, null)
	    {
			if (contextualKeywords != null)
			{
				this.AdjustFlagsAndWidth(contextualKeywords);
				this.contextualKeywords = contextualKeywords;
			}
	    }
	
	    public ContextualKeywordsGreen(SoalSyntaxKind kind, InternalSyntaxToken contextualKeywords, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (contextualKeywords != null)
			{
				this.AdjustFlagsAndWidth(contextualKeywords);
				this.contextualKeywords = contextualKeywords;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken ContextualKeywords { get { return this.contextualKeywords; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Soal.Syntax.ContextualKeywordsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.contextualKeywords;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ContextualKeywordsGreen(this.Kind, this.contextualKeywords, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ContextualKeywordsGreen(this.Kind, this.contextualKeywords, this.GetDiagnostics(), annotations);
	    }
	
	    public ContextualKeywordsGreen Update(InternalSyntaxToken contextualKeywords)
	    {
	        if (this.contextualKeywords != contextualKeywords)
	        {
	            GreenNode newNode = SoalLanguage.Instance.InternalSyntaxFactory.ContextualKeywords(contextualKeywords);
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

	internal class SoalGreenFactory : InternalSyntaxFactory
	{
	    internal static readonly SoalGreenFactory Instance = new SoalGreenFactory();
	
		public SoalGreenTrivia Trivia(SoalSyntaxKind kind, string text)
		{
		    return new SoalGreenTrivia(kind, text, null, null);
		}
	
		public override InternalSyntaxTrivia Trivia(int kind, string text)
		{
		    return new SoalGreenTrivia((SoalSyntaxKind)kind, text, null, null);
		}
	
		public SoalGreenToken MissingToken(SoalSyntaxKind kind)
		{
		    return SoalGreenToken.CreateMissing(kind, null, null);
		}
	
		public override InternalSyntaxToken MissingToken(int kind)
		{
		    return SoalGreenToken.CreateMissing((SoalSyntaxKind)kind, null, null);
		}
	
		public SoalGreenToken MissingToken(GreenNode leading, SoalSyntaxKind kind, GreenNode trailing)
		{
		    return SoalGreenToken.CreateMissing(kind, leading, trailing);
		}
	
		public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
		{
		    return SoalGreenToken.CreateMissing((SoalSyntaxKind)kind, leading, trailing);
		}
	
		public SoalGreenToken Token(SoalSyntaxKind kind)
		{
		    return SoalGreenToken.Create(kind);
		}
	
		public override InternalSyntaxToken Token(int kind)
		{
		    return SoalGreenToken.Create((SoalSyntaxKind)kind);
		}
	
	    public SoalGreenToken Token(GreenNode leading, SoalSyntaxKind kind, GreenNode trailing)
		{
		    return SoalGreenToken.Create(kind, leading, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
		{
		    return SoalGreenToken.Create((SoalSyntaxKind)kind, leading, trailing);
		}
	
	    public SoalGreenToken Token(GreenNode leading, SoalSyntaxKind kind, string text, GreenNode trailing)
		{
		    Debug.Assert(SoalLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SoalLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SoalGreenToken.FirstTokenWithWellKnownText && kind <= SoalGreenToken.LastTokenWithWellKnownText && text == defaultText
		        ? this.Token(leading, kind, trailing)
		        : SoalGreenToken.WithText(kind, leading, text, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
	    {
	        return this.Token(leading, (SoalSyntaxKind)kind, text, trailing);
	    }
	
	    public SoalGreenToken Token(GreenNode leading, SoalSyntaxKind kind, string text, string valueText, GreenNode trailing)
		{
		    Debug.Assert(SoalLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SoalLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SoalGreenToken.FirstTokenWithWellKnownText && kind <= SoalGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(valueText)
		        ? this.Token(leading, kind, trailing)
		        : SoalGreenToken.WithValue(kind, leading, text, valueText, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
	    {
	        return this.Token(leading, (SoalSyntaxKind)kind, text, valueText, trailing);
	    }
	
	    public SoalGreenToken Token(GreenNode leading, SoalSyntaxKind kind, string text, object value, GreenNode trailing)
		{
		    Debug.Assert(SoalLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SoalLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SoalGreenToken.FirstTokenWithWellKnownText && kind <= SoalGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
		        ? this.Token(leading, kind, trailing)
		        : SoalGreenToken.WithValue(kind, leading, text, value, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
	    {
	        return this.Token(leading, (SoalSyntaxKind)kind, text, value, trailing);
	    }
	
	    public SoalGreenToken BadToken(GreenNode leading, string text, GreenNode trailing)
		{
		    return SoalGreenToken.WithText(SoalSyntaxKind.BadToken, leading, text, trailing);
		}
	
	
	    internal SoalGreenToken TAsterisk(string text)
	    {
	        return Token(null, SoalSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal SoalGreenToken TAsterisk(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal SoalGreenToken IdentifierNormal(string text)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal SoalGreenToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal SoalGreenToken IdentifierVerbatim(string text)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal SoalGreenToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal SoalGreenToken LInteger(string text)
	    {
	        return Token(null, SoalSyntaxKind.LInteger, text, null);
	    }
	
	    internal SoalGreenToken LInteger(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal SoalGreenToken LDecimal(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDecimal, text, null);
	    }
	
	    internal SoalGreenToken LDecimal(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal SoalGreenToken LScientific(string text)
	    {
	        return Token(null, SoalSyntaxKind.LScientific, text, null);
	    }
	
	    internal SoalGreenToken LScientific(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal SoalGreenToken LDateTimeOffset(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal SoalGreenToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal SoalGreenToken LDateTime(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDateTime, text, null);
	    }
	
	    internal SoalGreenToken LDateTime(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal SoalGreenToken LDate(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDate, text, null);
	    }
	
	    internal SoalGreenToken LDate(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDate, text, value, null);
	    }
	
	    internal SoalGreenToken LTime(string text)
	    {
	        return Token(null, SoalSyntaxKind.LTime, text, null);
	    }
	
	    internal SoalGreenToken LTime(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LTime, text, value, null);
	    }
	
	    internal SoalGreenToken LRegularString(string text)
	    {
	        return Token(null, SoalSyntaxKind.LRegularString, text, null);
	    }
	
	    internal SoalGreenToken LRegularString(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal SoalGreenToken LGuid(string text)
	    {
	        return Token(null, SoalSyntaxKind.LGuid, text, null);
	    }
	
	    internal SoalGreenToken LGuid(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal SoalGreenToken LUtf8Bom(string text)
	    {
	        return Token(null, SoalSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal SoalGreenToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal SoalGreenToken LWhiteSpace(string text)
	    {
	        return Token(null, SoalSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal SoalGreenToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal SoalGreenToken LCrLf(string text)
	    {
	        return Token(null, SoalSyntaxKind.LCrLf, text, null);
	    }
	
	    internal SoalGreenToken LCrLf(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal SoalGreenToken LLineEnd(string text)
	    {
	        return Token(null, SoalSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal SoalGreenToken LLineEnd(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal SoalGreenToken LSingleLineComment(string text)
	    {
	        return Token(null, SoalSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal SoalGreenToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal SoalGreenToken COMMENT(string text)
	    {
	        return Token(null, SoalSyntaxKind.COMMENT, text, null);
	    }
	
	    internal SoalGreenToken COMMENT(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.COMMENT, text, value, null);
	    }
	
	    internal SoalGreenToken LDoubleQuoteVerbatimString(string text)
	    {
	        return Token(null, SoalSyntaxKind.LDoubleQuoteVerbatimString, text, null);
	    }
	
	    internal SoalGreenToken LDoubleQuoteVerbatimString(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LDoubleQuoteVerbatimString, text, value, null);
	    }
	
	    internal SoalGreenToken LSingleQuoteVerbatimString(string text)
	    {
	        return Token(null, SoalSyntaxKind.LSingleQuoteVerbatimString, text, null);
	    }
	
	    internal SoalGreenToken LSingleQuoteVerbatimString(string text, object value)
	    {
	        return Token(null, SoalSyntaxKind.LSingleQuoteVerbatimString, text, value, null);
	    }
	
		public MainGreen Main(InternalSyntaxNodeList namespaceDeclaration, InternalSyntaxToken eof, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (eof == null) throw new ArgumentNullException(nameof(eof));
				if (eof.RawKind != (int)SoalSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.Main, namespaceDeclaration, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(SoalSyntaxKind.Main, namespaceDeclaration, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameDefGreen NameDef(IdentifierGreen identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NameDef, identifier, out hash);
			if (cached != null) return (NameDefGreen)cached;
			var result = new NameDefGreen(SoalSyntaxKind.NameDef, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameDefGreen QualifiedNameDef(QualifiedNameGreen qualifiedName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.QualifiedNameDef, qualifiedName, out hash);
			if (cached != null) return (QualifiedNameDefGreen)cached;
			var result = new QualifiedNameDefGreen(SoalSyntaxKind.QualifiedNameDef, qualifiedName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameGreen QualifiedName(InternalSeparatedSyntaxNodeList identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.QualifiedName, identifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(SoalSyntaxKind.QualifiedName, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierListGreen IdentifierList(InternalSeparatedSyntaxNodeList identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.IdentifierList, identifier, out hash);
			if (cached != null) return (IdentifierListGreen)cached;
			var result = new IdentifierListGreen(SoalSyntaxKind.IdentifierList, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameListGreen QualifiedNameList(InternalSeparatedSyntaxNodeList qualifiedName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.QualifiedNameList, qualifiedName, out hash);
			if (cached != null) return (QualifiedNameListGreen)cached;
			var result = new QualifiedNameListGreen(SoalSyntaxKind.QualifiedNameList, qualifiedName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationListGreen AnnotationList(InternalSyntaxNodeList annotation, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationList, annotation, out hash);
			if (cached != null) return (AnnotationListGreen)cached;
			var result = new AnnotationListGreen(SoalSyntaxKind.AnnotationList, annotation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnAnnotationListGreen ReturnAnnotationList(InternalSyntaxNodeList returnAnnotation, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ReturnAnnotationList, returnAnnotation, out hash);
			if (cached != null) return (ReturnAnnotationListGreen)cached;
			var result = new ReturnAnnotationListGreen(SoalSyntaxKind.ReturnAnnotationList, returnAnnotation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationGreen Annotation(InternalSyntaxToken tOpenBracket, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
				if (tOpenBracket.RawKind != (int)SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
				if (annotationHead == null) throw new ArgumentNullException(nameof(annotationHead));
				if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
				if (tCloseBracket.RawKind != (int)SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.Annotation, tOpenBracket, annotationHead, tCloseBracket, out hash);
			if (cached != null) return (AnnotationGreen)cached;
			var result = new AnnotationGreen(SoalSyntaxKind.Annotation, tOpenBracket, annotationHead, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnAnnotationGreen ReturnAnnotation(InternalSyntaxToken tOpenBracket, InternalSyntaxToken kReturn, InternalSyntaxToken tColon, AnnotationHeadGreen annotationHead, InternalSyntaxToken tCloseBracket, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
				if (tOpenBracket.RawKind != (int)SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
				if (kReturn == null) throw new ArgumentNullException(nameof(kReturn));
				if (kReturn.RawKind != (int)SoalSyntaxKind.KReturn) throw new ArgumentException(nameof(kReturn));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (annotationHead == null) throw new ArgumentNullException(nameof(annotationHead));
				if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
				if (tCloseBracket.RawKind != (int)SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			}
	#endif
	        return new ReturnAnnotationGreen(SoalSyntaxKind.ReturnAnnotation, tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
	    }
	
		public AnnotationHeadGreen AnnotationHead(IdentifierGreen identifier, AnnotationBodyGreen annotationBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationHead, identifier, annotationBody, out hash);
			if (cached != null) return (AnnotationHeadGreen)cached;
			var result = new AnnotationHeadGreen(SoalSyntaxKind.AnnotationHead, identifier, annotationBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationBodyGreen AnnotationBody(InternalSyntaxToken tOpenParen, AnnotationPropertyListGreen annotationPropertyList, InternalSyntaxToken tCloseParen, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
				if (tOpenParen.RawKind != (int)SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
				if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
				if (tCloseParen.RawKind != (int)SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationBody, tOpenParen, annotationPropertyList, tCloseParen, out hash);
			if (cached != null) return (AnnotationBodyGreen)cached;
			var result = new AnnotationBodyGreen(SoalSyntaxKind.AnnotationBody, tOpenParen, annotationPropertyList, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyListGreen AnnotationPropertyList(InternalSeparatedSyntaxNodeList annotationProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationPropertyList, annotationProperty, out hash);
			if (cached != null) return (AnnotationPropertyListGreen)cached;
			var result = new AnnotationPropertyListGreen(SoalSyntaxKind.AnnotationPropertyList, annotationProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyGreen AnnotationProperty(IdentifierGreen identifier, InternalSyntaxToken tAssign, AnnotationPropertyValueGreen annotationPropertyValue, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (annotationPropertyValue == null) throw new ArgumentNullException(nameof(annotationPropertyValue));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationProperty, identifier, tAssign, annotationPropertyValue, out hash);
			if (cached != null) return (AnnotationPropertyGreen)cached;
			var result = new AnnotationPropertyGreen(SoalSyntaxKind.AnnotationProperty, identifier, tAssign, annotationPropertyValue);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyValueGreen AnnotationPropertyValue(ConstantValueGreen constantValue, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (constantValue == null) throw new ArgumentNullException(nameof(constantValue));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationPropertyValue, constantValue, out hash);
			if (cached != null) return (AnnotationPropertyValueGreen)cached;
			var result = new AnnotationPropertyValueGreen(SoalSyntaxKind.AnnotationPropertyValue, constantValue, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationPropertyValueGreen AnnotationPropertyValue(TypeofValueGreen typeofValue, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (typeofValue == null) throw new ArgumentNullException(nameof(typeofValue));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AnnotationPropertyValue, typeofValue, out hash);
			if (cached != null) return (AnnotationPropertyValueGreen)cached;
			var result = new AnnotationPropertyValueGreen(SoalSyntaxKind.AnnotationPropertyValue, null, typeofValue);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclarationGreen NamespaceDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kNamespace, QualifiedNameDefGreen qualifiedNameDef, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tColon, StringLiteralGreen stringLiteral, NamespaceBodyGreen namespaceBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
				if (kNamespace.RawKind != (int)SoalSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
				if (qualifiedNameDef == null) throw new ArgumentNullException(nameof(qualifiedNameDef));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
				if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
			}
	#endif
	        return new NamespaceDeclarationGreen(SoalSyntaxKind.NamespaceDeclaration, annotationList, kNamespace, qualifiedNameDef, tAssign, identifier, tColon, stringLiteral, namespaceBody);
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NamespaceBody, tOpenBrace, declaration, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBodyGreen)cached;
			var result = new NamespaceBodyGreen(SoalSyntaxKind.NamespaceBody, tOpenBrace, declaration, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(EnumDeclarationGreen enumDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, enumDeclaration, null, null, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(StructDeclarationGreen structDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (structDeclaration == null) throw new ArgumentNullException(nameof(structDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, structDeclaration, null, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(DatabaseDeclarationGreen databaseDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (databaseDeclaration == null) throw new ArgumentNullException(nameof(databaseDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, databaseDeclaration, null, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(InterfaceDeclarationGreen interfaceDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (interfaceDeclaration == null) throw new ArgumentNullException(nameof(interfaceDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, interfaceDeclaration, null, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ComponentDeclarationGreen componentDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentDeclaration == null) throw new ArgumentNullException(nameof(componentDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, componentDeclaration, null, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(CompositeDeclarationGreen compositeDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (compositeDeclaration == null) throw new ArgumentNullException(nameof(compositeDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, compositeDeclaration, null, null, null, null);
	    }
	
		public DeclarationGreen Declaration(AssemblyDeclarationGreen assemblyDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (assemblyDeclaration == null) throw new ArgumentNullException(nameof(assemblyDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, assemblyDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(BindingDeclarationGreen bindingDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (bindingDeclaration == null) throw new ArgumentNullException(nameof(bindingDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, null, bindingDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(EndpointDeclarationGreen endpointDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (endpointDeclaration == null) throw new ArgumentNullException(nameof(endpointDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, null, null, endpointDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(DeploymentDeclarationGreen deploymentDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (deploymentDeclaration == null) throw new ArgumentNullException(nameof(deploymentDeclaration));
			}
	#endif
			return new DeclarationGreen(SoalSyntaxKind.Declaration, null, null, null, null, null, null, null, null, null, deploymentDeclaration);
	    }
	
		public EnumDeclarationGreen EnumDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kEnum, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EnumBodyGreen enumBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
				if (kEnum.RawKind != (int)SoalSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
			}
	#endif
	        return new EnumDeclarationGreen(SoalSyntaxKind.EnumDeclaration, annotationList, kEnum, nameDef, tColon, qualifiedName, enumBody);
	    }
	
		public EnumBodyGreen EnumBody(InternalSyntaxToken tOpenBrace, EnumLiteralsGreen enumLiterals, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EnumBody, tOpenBrace, enumLiterals, tCloseBrace, out hash);
			if (cached != null) return (EnumBodyGreen)cached;
			var result = new EnumBodyGreen(SoalSyntaxKind.EnumBody, tOpenBrace, enumLiterals, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumLiteralsGreen EnumLiterals(InternalSeparatedSyntaxNodeList enumLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EnumLiterals, enumLiteral, out hash);
			if (cached != null) return (EnumLiteralsGreen)cached;
			var result = new EnumLiteralsGreen(SoalSyntaxKind.EnumLiterals, enumLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumLiteralGreen EnumLiteral(AnnotationListGreen annotationList, NameDefGreen nameDef, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EnumLiteral, annotationList, nameDef, out hash);
			if (cached != null) return (EnumLiteralGreen)cached;
			var result = new EnumLiteralGreen(SoalSyntaxKind.EnumLiteral, annotationList, nameDef);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StructDeclarationGreen StructDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kStruct, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, StructBodyGreen structBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kStruct == null) throw new ArgumentNullException(nameof(kStruct));
				if (kStruct.RawKind != (int)SoalSyntaxKind.KStruct) throw new ArgumentException(nameof(kStruct));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (structBody == null) throw new ArgumentNullException(nameof(structBody));
			}
	#endif
	        return new StructDeclarationGreen(SoalSyntaxKind.StructDeclaration, annotationList, kStruct, nameDef, tColon, qualifiedName, structBody);
	    }
	
		public StructBodyGreen StructBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList propertyDeclaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.StructBody, tOpenBrace, propertyDeclaration, tCloseBrace, out hash);
			if (cached != null) return (StructBodyGreen)cached;
			var result = new StructBodyGreen(SoalSyntaxKind.StructBody, tOpenBrace, propertyDeclaration, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PropertyDeclarationGreen PropertyDeclaration(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new PropertyDeclarationGreen(SoalSyntaxKind.PropertyDeclaration, annotationList, typeReference, nameDef, tSemicolon);
	    }
	
		public DatabaseDeclarationGreen DatabaseDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kDatabase, NameDefGreen nameDef, DatabaseBodyGreen databaseBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kDatabase == null) throw new ArgumentNullException(nameof(kDatabase));
				if (kDatabase.RawKind != (int)SoalSyntaxKind.KDatabase) throw new ArgumentException(nameof(kDatabase));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (databaseBody == null) throw new ArgumentNullException(nameof(databaseBody));
			}
	#endif
	        return new DatabaseDeclarationGreen(SoalSyntaxKind.DatabaseDeclaration, annotationList, kDatabase, nameDef, databaseBody);
	    }
	
		public DatabaseBodyGreen DatabaseBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList entityReference, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
	        return new DatabaseBodyGreen(SoalSyntaxKind.DatabaseBody, tOpenBrace, entityReference, operationDeclaration, tCloseBrace);
	    }
	
		public EntityReferenceGreen EntityReference(InternalSyntaxToken kEntity, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEntity == null) throw new ArgumentNullException(nameof(kEntity));
				if (kEntity.RawKind != (int)SoalSyntaxKind.KEntity) throw new ArgumentException(nameof(kEntity));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EntityReference, kEntity, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (EntityReferenceGreen)cached;
			var result = new EntityReferenceGreen(SoalSyntaxKind.EntityReference, kEntity, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InterfaceDeclarationGreen InterfaceDeclaration(AnnotationListGreen annotationList, InternalSyntaxToken kInterface, NameDefGreen nameDef, InterfaceBodyGreen interfaceBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kInterface == null) throw new ArgumentNullException(nameof(kInterface));
				if (kInterface.RawKind != (int)SoalSyntaxKind.KInterface) throw new ArgumentException(nameof(kInterface));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (interfaceBody == null) throw new ArgumentNullException(nameof(interfaceBody));
			}
	#endif
	        return new InterfaceDeclarationGreen(SoalSyntaxKind.InterfaceDeclaration, annotationList, kInterface, nameDef, interfaceBody);
	    }
	
		public InterfaceBodyGreen InterfaceBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList operationDeclaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.InterfaceBody, tOpenBrace, operationDeclaration, tCloseBrace, out hash);
			if (cached != null) return (InterfaceBodyGreen)cached;
			var result = new InterfaceBodyGreen(SoalSyntaxKind.InterfaceBody, tOpenBrace, operationDeclaration, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationDeclarationGreen OperationDeclaration(OperationHeadGreen operationHead, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (operationHead == null) throw new ArgumentNullException(nameof(operationHead));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.OperationDeclaration, operationHead, tSemicolon, out hash);
			if (cached != null) return (OperationDeclarationGreen)cached;
			var result = new OperationDeclarationGreen(SoalSyntaxKind.OperationDeclaration, operationHead, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationHeadGreen OperationHead(AnnotationListGreen annotationList, OperationResultGreen operationResult, NameDefGreen nameDef, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken kThrows, QualifiedNameListGreen qualifiedNameList, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (operationResult == null) throw new ArgumentNullException(nameof(operationResult));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
				if (tOpenParen.RawKind != (int)SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
				if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
				if (tCloseParen.RawKind != (int)SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
				if (kThrows == null) throw new ArgumentNullException(nameof(kThrows));
				if (kThrows.RawKind != (int)SoalSyntaxKind.KThrows) throw new ArgumentException(nameof(kThrows));
				if (qualifiedNameList == null) throw new ArgumentNullException(nameof(qualifiedNameList));
			}
	#endif
	        return new OperationHeadGreen(SoalSyntaxKind.OperationHead, annotationList, operationResult, nameDef, tOpenParen, parameterList, tCloseParen, kThrows, qualifiedNameList);
	    }
	
		public ParameterListGreen ParameterList(InternalSeparatedSyntaxNodeList parameter, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ParameterList, parameter, out hash);
			if (cached != null) return (ParameterListGreen)cached;
			var result = new ParameterListGreen(SoalSyntaxKind.ParameterList, parameter);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParameterGreen Parameter(AnnotationListGreen annotationList, TypeReferenceGreen typeReference, NameDefGreen nameDef, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.Parameter, annotationList, typeReference, nameDef, out hash);
			if (cached != null) return (ParameterGreen)cached;
			var result = new ParameterGreen(SoalSyntaxKind.Parameter, annotationList, typeReference, nameDef);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationResultGreen OperationResult(ReturnAnnotationListGreen returnAnnotationList, OperationReturnTypeGreen operationReturnType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (operationReturnType == null) throw new ArgumentNullException(nameof(operationReturnType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.OperationResult, returnAnnotationList, operationReturnType, out hash);
			if (cached != null) return (OperationResultGreen)cached;
			var result = new OperationResultGreen(SoalSyntaxKind.OperationResult, returnAnnotationList, operationReturnType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentDeclarationGreen ComponentDeclaration(InternalSyntaxToken kAbstract, InternalSyntaxToken kComponent, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, ComponentBodyGreen componentBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kAbstract != null && kAbstract.RawKind != (int)SoalSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
				if (kComponent == null) throw new ArgumentNullException(nameof(kComponent));
				if (kComponent.RawKind != (int)SoalSyntaxKind.KComponent) throw new ArgumentException(nameof(kComponent));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (componentBody == null) throw new ArgumentNullException(nameof(componentBody));
			}
	#endif
	        return new ComponentDeclarationGreen(SoalSyntaxKind.ComponentDeclaration, kAbstract, kComponent, nameDef, tColon, qualifiedName, componentBody);
	    }
	
		public ComponentBodyGreen ComponentBody(InternalSyntaxToken tOpenBrace, ComponentElementsGreen componentElements, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentBody, tOpenBrace, componentElements, tCloseBrace, out hash);
			if (cached != null) return (ComponentBodyGreen)cached;
			var result = new ComponentBodyGreen(SoalSyntaxKind.ComponentBody, tOpenBrace, componentElements, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentElementsGreen ComponentElements(InternalSyntaxNodeList componentElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentElements, componentElement, out hash);
			if (cached != null) return (ComponentElementsGreen)cached;
			var result = new ComponentElementsGreen(SoalSyntaxKind.ComponentElements, componentElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentElementGreen ComponentElement(ComponentServiceGreen componentService, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentService == null) throw new ArgumentNullException(nameof(componentService));
			}
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, componentService, null, null, null, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentReferenceGreen componentReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentReference == null) throw new ArgumentNullException(nameof(componentReference));
			}
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, componentReference, null, null, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentPropertyGreen componentProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentProperty == null) throw new ArgumentNullException(nameof(componentProperty));
			}
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, null, componentProperty, null, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentImplementationGreen componentImplementation, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentImplementation == null) throw new ArgumentNullException(nameof(componentImplementation));
			}
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, null, null, componentImplementation, null);
	    }
	
		public ComponentElementGreen ComponentElement(ComponentLanguageGreen componentLanguage, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentLanguage == null) throw new ArgumentNullException(nameof(componentLanguage));
			}
	#endif
			return new ComponentElementGreen(SoalSyntaxKind.ComponentElement, null, null, null, null, componentLanguage);
	    }
	
		public ComponentServiceGreen ComponentService(InternalSyntaxToken kService, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kService == null) throw new ArgumentNullException(nameof(kService));
				if (kService.RawKind != (int)SoalSyntaxKind.KService) throw new ArgumentException(nameof(kService));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (componentServiceOrReferenceBody == null) throw new ArgumentNullException(nameof(componentServiceOrReferenceBody));
			}
	#endif
	        return new ComponentServiceGreen(SoalSyntaxKind.ComponentService, kService, qualifiedName, nameDef, componentServiceOrReferenceBody);
	    }
	
		public ComponentReferenceGreen ComponentReference(InternalSyntaxToken kReference, QualifiedNameGreen qualifiedName, NameDefGreen nameDef, ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kReference == null) throw new ArgumentNullException(nameof(kReference));
				if (kReference.RawKind != (int)SoalSyntaxKind.KReference) throw new ArgumentException(nameof(kReference));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (componentServiceOrReferenceBody == null) throw new ArgumentNullException(nameof(componentServiceOrReferenceBody));
			}
	#endif
	        return new ComponentReferenceGreen(SoalSyntaxKind.ComponentReference, kReference, qualifiedName, nameDef, componentServiceOrReferenceBody);
	    }
	
		public ComponentServiceOrReferenceEmptyBodyGreen ComponentServiceOrReferenceEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentServiceOrReferenceEmptyBody, tSemicolon, out hash);
			if (cached != null) return (ComponentServiceOrReferenceEmptyBodyGreen)cached;
			var result = new ComponentServiceOrReferenceEmptyBodyGreen(SoalSyntaxKind.ComponentServiceOrReferenceEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentServiceOrReferenceNonEmptyBodyGreen ComponentServiceOrReferenceNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList componentServiceOrReferenceElement, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentServiceOrReferenceNonEmptyBody, tOpenBrace, componentServiceOrReferenceElement, tCloseBrace, out hash);
			if (cached != null) return (ComponentServiceOrReferenceNonEmptyBodyGreen)cached;
			var result = new ComponentServiceOrReferenceNonEmptyBodyGreen(SoalSyntaxKind.ComponentServiceOrReferenceNonEmptyBody, tOpenBrace, componentServiceOrReferenceElement, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentServiceOrReferenceElementGreen ComponentServiceOrReferenceElement(InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
				if (kBinding.RawKind != (int)SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentServiceOrReferenceElement, kBinding, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (ComponentServiceOrReferenceElementGreen)cached;
			var result = new ComponentServiceOrReferenceElementGreen(SoalSyntaxKind.ComponentServiceOrReferenceElement, kBinding, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentPropertyGreen ComponentProperty(TypeReferenceGreen typeReference, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentProperty, typeReference, nameDef, tSemicolon, out hash);
			if (cached != null) return (ComponentPropertyGreen)cached;
			var result = new ComponentPropertyGreen(SoalSyntaxKind.ComponentProperty, typeReference, nameDef, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentImplementationGreen ComponentImplementation(InternalSyntaxToken kImplementation, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kImplementation == null) throw new ArgumentNullException(nameof(kImplementation));
				if (kImplementation.RawKind != (int)SoalSyntaxKind.KImplementation) throw new ArgumentException(nameof(kImplementation));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentImplementation, kImplementation, nameDef, tSemicolon, out hash);
			if (cached != null) return (ComponentImplementationGreen)cached;
			var result = new ComponentImplementationGreen(SoalSyntaxKind.ComponentImplementation, kImplementation, nameDef, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ComponentLanguageGreen ComponentLanguage(InternalSyntaxToken kLanguage, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kLanguage == null) throw new ArgumentNullException(nameof(kLanguage));
				if (kLanguage.RawKind != (int)SoalSyntaxKind.KLanguage) throw new ArgumentException(nameof(kLanguage));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ComponentLanguage, kLanguage, nameDef, tSemicolon, out hash);
			if (cached != null) return (ComponentLanguageGreen)cached;
			var result = new ComponentLanguageGreen(SoalSyntaxKind.ComponentLanguage, kLanguage, nameDef, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompositeDeclarationGreen CompositeDeclaration(InternalSyntaxToken kComposite, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kComposite == null) throw new ArgumentNullException(nameof(kComposite));
				if (kComposite.RawKind != (int)SoalSyntaxKind.KComposite) throw new ArgumentException(nameof(kComposite));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (compositeBody == null) throw new ArgumentNullException(nameof(compositeBody));
			}
	#endif
	        return new CompositeDeclarationGreen(SoalSyntaxKind.CompositeDeclaration, kComposite, nameDef, tColon, qualifiedName, compositeBody);
	    }
	
		public CompositeBodyGreen CompositeBody(InternalSyntaxToken tOpenBrace, CompositeElementsGreen compositeElements, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.CompositeBody, tOpenBrace, compositeElements, tCloseBrace, out hash);
			if (cached != null) return (CompositeBodyGreen)cached;
			var result = new CompositeBodyGreen(SoalSyntaxKind.CompositeBody, tOpenBrace, compositeElements, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssemblyDeclarationGreen AssemblyDeclaration(InternalSyntaxToken kAssembly, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, CompositeBodyGreen compositeBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kAssembly == null) throw new ArgumentNullException(nameof(kAssembly));
				if (kAssembly.RawKind != (int)SoalSyntaxKind.KAssembly) throw new ArgumentException(nameof(kAssembly));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (compositeBody == null) throw new ArgumentNullException(nameof(compositeBody));
			}
	#endif
	        return new AssemblyDeclarationGreen(SoalSyntaxKind.AssemblyDeclaration, kAssembly, nameDef, tColon, qualifiedName, compositeBody);
	    }
	
		public CompositeElementsGreen CompositeElements(InternalSyntaxNodeList compositeElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.CompositeElements, compositeElement, out hash);
			if (cached != null) return (CompositeElementsGreen)cached;
			var result = new CompositeElementsGreen(SoalSyntaxKind.CompositeElements, compositeElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompositeElementGreen CompositeElement(ComponentServiceGreen componentService, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentService == null) throw new ArgumentNullException(nameof(componentService));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, componentService, null, null, null, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentReferenceGreen componentReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentReference == null) throw new ArgumentNullException(nameof(componentReference));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, componentReference, null, null, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentPropertyGreen componentProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentProperty == null) throw new ArgumentNullException(nameof(componentProperty));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, componentProperty, null, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentImplementationGreen componentImplementation, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentImplementation == null) throw new ArgumentNullException(nameof(componentImplementation));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, componentImplementation, null, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(ComponentLanguageGreen componentLanguage, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (componentLanguage == null) throw new ArgumentNullException(nameof(componentLanguage));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, null, componentLanguage, null, null);
	    }
	
		public CompositeElementGreen CompositeElement(CompositeComponentGreen compositeComponent, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (compositeComponent == null) throw new ArgumentNullException(nameof(compositeComponent));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, null, null, compositeComponent, null);
	    }
	
		public CompositeElementGreen CompositeElement(CompositeWireGreen compositeWire, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (compositeWire == null) throw new ArgumentNullException(nameof(compositeWire));
			}
	#endif
			return new CompositeElementGreen(SoalSyntaxKind.CompositeElement, null, null, null, null, null, null, compositeWire);
	    }
	
		public CompositeComponentGreen CompositeComponent(InternalSyntaxToken kComponent, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kComponent == null) throw new ArgumentNullException(nameof(kComponent));
				if (kComponent.RawKind != (int)SoalSyntaxKind.KComponent) throw new ArgumentException(nameof(kComponent));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.CompositeComponent, kComponent, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (CompositeComponentGreen)cached;
			var result = new CompositeComponentGreen(SoalSyntaxKind.CompositeComponent, kComponent, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CompositeWireGreen CompositeWire(InternalSyntaxToken kWire, WireSourceGreen wireSource, InternalSyntaxToken kTo, WireTargetGreen wireTarget, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kWire == null) throw new ArgumentNullException(nameof(kWire));
				if (kWire.RawKind != (int)SoalSyntaxKind.KWire) throw new ArgumentException(nameof(kWire));
				if (wireSource == null) throw new ArgumentNullException(nameof(wireSource));
				if (kTo == null) throw new ArgumentNullException(nameof(kTo));
				if (kTo.RawKind != (int)SoalSyntaxKind.KTo) throw new ArgumentException(nameof(kTo));
				if (wireTarget == null) throw new ArgumentNullException(nameof(wireTarget));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new CompositeWireGreen(SoalSyntaxKind.CompositeWire, kWire, wireSource, kTo, wireTarget, tSemicolon);
	    }
	
		public WireSourceGreen WireSource(QualifiedNameGreen qualifiedName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.WireSource, qualifiedName, out hash);
			if (cached != null) return (WireSourceGreen)cached;
			var result = new WireSourceGreen(SoalSyntaxKind.WireSource, qualifiedName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WireTargetGreen WireTarget(QualifiedNameGreen qualifiedName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.WireTarget, qualifiedName, out hash);
			if (cached != null) return (WireTargetGreen)cached;
			var result = new WireTargetGreen(SoalSyntaxKind.WireTarget, qualifiedName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentDeclarationGreen DeploymentDeclaration(InternalSyntaxToken kDeployment, NameDefGreen nameDef, DeploymentBodyGreen deploymentBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kDeployment == null) throw new ArgumentNullException(nameof(kDeployment));
				if (kDeployment.RawKind != (int)SoalSyntaxKind.KDeployment) throw new ArgumentException(nameof(kDeployment));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (deploymentBody == null) throw new ArgumentNullException(nameof(deploymentBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DeploymentDeclaration, kDeployment, nameDef, deploymentBody, out hash);
			if (cached != null) return (DeploymentDeclarationGreen)cached;
			var result = new DeploymentDeclarationGreen(SoalSyntaxKind.DeploymentDeclaration, kDeployment, nameDef, deploymentBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentBodyGreen DeploymentBody(InternalSyntaxToken tOpenBrace, DeploymentElementsGreen deploymentElements, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DeploymentBody, tOpenBrace, deploymentElements, tCloseBrace, out hash);
			if (cached != null) return (DeploymentBodyGreen)cached;
			var result = new DeploymentBodyGreen(SoalSyntaxKind.DeploymentBody, tOpenBrace, deploymentElements, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentElementsGreen DeploymentElements(InternalSyntaxNodeList deploymentElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DeploymentElements, deploymentElement, out hash);
			if (cached != null) return (DeploymentElementsGreen)cached;
			var result = new DeploymentElementsGreen(SoalSyntaxKind.DeploymentElements, deploymentElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentElementGreen DeploymentElement(EnvironmentDeclarationGreen environmentDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (environmentDeclaration == null) throw new ArgumentNullException(nameof(environmentDeclaration));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DeploymentElement, environmentDeclaration, out hash);
			if (cached != null) return (DeploymentElementGreen)cached;
			var result = new DeploymentElementGreen(SoalSyntaxKind.DeploymentElement, environmentDeclaration, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeploymentElementGreen DeploymentElement(CompositeWireGreen compositeWire, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (compositeWire == null) throw new ArgumentNullException(nameof(compositeWire));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DeploymentElement, compositeWire, out hash);
			if (cached != null) return (DeploymentElementGreen)cached;
			var result = new DeploymentElementGreen(SoalSyntaxKind.DeploymentElement, null, compositeWire);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnvironmentDeclarationGreen EnvironmentDeclaration(InternalSyntaxToken kEnvironment, NameDefGreen nameDef, EnvironmentBodyGreen environmentBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEnvironment == null) throw new ArgumentNullException(nameof(kEnvironment));
				if (kEnvironment.RawKind != (int)SoalSyntaxKind.KEnvironment) throw new ArgumentException(nameof(kEnvironment));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (environmentBody == null) throw new ArgumentNullException(nameof(environmentBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EnvironmentDeclaration, kEnvironment, nameDef, environmentBody, out hash);
			if (cached != null) return (EnvironmentDeclarationGreen)cached;
			var result = new EnvironmentDeclarationGreen(SoalSyntaxKind.EnvironmentDeclaration, kEnvironment, nameDef, environmentBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnvironmentBodyGreen EnvironmentBody(InternalSyntaxToken tOpenBrace, RuntimeDeclarationGreen runtimeDeclaration, InternalSyntaxNodeList runtimeReference, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (runtimeDeclaration == null) throw new ArgumentNullException(nameof(runtimeDeclaration));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
	        return new EnvironmentBodyGreen(SoalSyntaxKind.EnvironmentBody, tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace);
	    }
	
		public RuntimeDeclarationGreen RuntimeDeclaration(InternalSyntaxToken kRuntime, NameDefGreen nameDef, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kRuntime == null) throw new ArgumentNullException(nameof(kRuntime));
				if (kRuntime.RawKind != (int)SoalSyntaxKind.KRuntime) throw new ArgumentException(nameof(kRuntime));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.RuntimeDeclaration, kRuntime, nameDef, tSemicolon, out hash);
			if (cached != null) return (RuntimeDeclarationGreen)cached;
			var result = new RuntimeDeclarationGreen(SoalSyntaxKind.RuntimeDeclaration, kRuntime, nameDef, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RuntimeReferenceGreen RuntimeReference(AssemblyReferenceGreen assemblyReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (assemblyReference == null) throw new ArgumentNullException(nameof(assemblyReference));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.RuntimeReference, assemblyReference, out hash);
			if (cached != null) return (RuntimeReferenceGreen)cached;
			var result = new RuntimeReferenceGreen(SoalSyntaxKind.RuntimeReference, assemblyReference, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RuntimeReferenceGreen RuntimeReference(DatabaseReferenceGreen databaseReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (databaseReference == null) throw new ArgumentNullException(nameof(databaseReference));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.RuntimeReference, databaseReference, out hash);
			if (cached != null) return (RuntimeReferenceGreen)cached;
			var result = new RuntimeReferenceGreen(SoalSyntaxKind.RuntimeReference, null, databaseReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssemblyReferenceGreen AssemblyReference(InternalSyntaxToken kAssembly, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kAssembly == null) throw new ArgumentNullException(nameof(kAssembly));
				if (kAssembly.RawKind != (int)SoalSyntaxKind.KAssembly) throw new ArgumentException(nameof(kAssembly));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.AssemblyReference, kAssembly, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (AssemblyReferenceGreen)cached;
			var result = new AssemblyReferenceGreen(SoalSyntaxKind.AssemblyReference, kAssembly, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DatabaseReferenceGreen DatabaseReference(InternalSyntaxToken kDatabase, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kDatabase == null) throw new ArgumentNullException(nameof(kDatabase));
				if (kDatabase.RawKind != (int)SoalSyntaxKind.KDatabase) throw new ArgumentException(nameof(kDatabase));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DatabaseReference, kDatabase, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (DatabaseReferenceGreen)cached;
			var result = new DatabaseReferenceGreen(SoalSyntaxKind.DatabaseReference, kDatabase, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BindingDeclarationGreen BindingDeclaration(InternalSyntaxToken kBinding, NameDefGreen nameDef, BindingBodyGreen bindingBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
				if (kBinding.RawKind != (int)SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (bindingBody == null) throw new ArgumentNullException(nameof(bindingBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.BindingDeclaration, kBinding, nameDef, bindingBody, out hash);
			if (cached != null) return (BindingDeclarationGreen)cached;
			var result = new BindingDeclarationGreen(SoalSyntaxKind.BindingDeclaration, kBinding, nameDef, bindingBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BindingBodyGreen BindingBody(InternalSyntaxToken tOpenBrace, BindingLayersGreen bindingLayers, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.BindingBody, tOpenBrace, bindingLayers, tCloseBrace, out hash);
			if (cached != null) return (BindingBodyGreen)cached;
			var result = new BindingBodyGreen(SoalSyntaxKind.BindingBody, tOpenBrace, bindingLayers, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BindingLayersGreen BindingLayers(TransportLayerGreen transportLayer, InternalSyntaxNodeList encodingLayer, InternalSyntaxNodeList protocolLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (transportLayer == null) throw new ArgumentNullException(nameof(transportLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.BindingLayers, transportLayer, encodingLayer, protocolLayer, out hash);
			if (cached != null) return (BindingLayersGreen)cached;
			var result = new BindingLayersGreen(SoalSyntaxKind.BindingLayers, transportLayer, encodingLayer, protocolLayer);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TransportLayerGreen TransportLayer(HttpTransportLayerGreen httpTransportLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (httpTransportLayer == null) throw new ArgumentNullException(nameof(httpTransportLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.TransportLayer, httpTransportLayer, out hash);
			if (cached != null) return (TransportLayerGreen)cached;
			var result = new TransportLayerGreen(SoalSyntaxKind.TransportLayer, httpTransportLayer, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TransportLayerGreen TransportLayer(RestTransportLayerGreen restTransportLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (restTransportLayer == null) throw new ArgumentNullException(nameof(restTransportLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.TransportLayer, restTransportLayer, out hash);
			if (cached != null) return (TransportLayerGreen)cached;
			var result = new TransportLayerGreen(SoalSyntaxKind.TransportLayer, null, restTransportLayer, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TransportLayerGreen TransportLayer(WebSocketTransportLayerGreen webSocketTransportLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (webSocketTransportLayer == null) throw new ArgumentNullException(nameof(webSocketTransportLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.TransportLayer, webSocketTransportLayer, out hash);
			if (cached != null) return (TransportLayerGreen)cached;
			var result = new TransportLayerGreen(SoalSyntaxKind.TransportLayer, null, null, webSocketTransportLayer);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerGreen HttpTransportLayer(InternalSyntaxToken kTransport, InternalSyntaxToken ihttp, HttpTransportLayerBodyGreen httpTransportLayerBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
				if (kTransport.RawKind != (int)SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
				if (ihttp == null) throw new ArgumentNullException(nameof(ihttp));
				if (ihttp.RawKind != (int)SoalSyntaxKind.IHTTP) throw new ArgumentException(nameof(ihttp));
				if (httpTransportLayerBody == null) throw new ArgumentNullException(nameof(httpTransportLayerBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.HttpTransportLayer, kTransport, ihttp, httpTransportLayerBody, out hash);
			if (cached != null) return (HttpTransportLayerGreen)cached;
			var result = new HttpTransportLayerGreen(SoalSyntaxKind.HttpTransportLayer, kTransport, ihttp, httpTransportLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerEmptyBodyGreen HttpTransportLayerEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.HttpTransportLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (HttpTransportLayerEmptyBodyGreen)cached;
			var result = new HttpTransportLayerEmptyBodyGreen(SoalSyntaxKind.HttpTransportLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerNonEmptyBodyGreen HttpTransportLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList httpTransportLayerProperties, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.HttpTransportLayerNonEmptyBody, tOpenBrace, httpTransportLayerProperties, tCloseBrace, out hash);
			if (cached != null) return (HttpTransportLayerNonEmptyBodyGreen)cached;
			var result = new HttpTransportLayerNonEmptyBodyGreen(SoalSyntaxKind.HttpTransportLayerNonEmptyBody, tOpenBrace, httpTransportLayerProperties, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RestTransportLayerGreen RestTransportLayer(InternalSyntaxToken kTransport, InternalSyntaxToken irest, RestTransportLayerBodyGreen restTransportLayerBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
				if (kTransport.RawKind != (int)SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
				if (irest == null) throw new ArgumentNullException(nameof(irest));
				if (irest.RawKind != (int)SoalSyntaxKind.IREST) throw new ArgumentException(nameof(irest));
				if (restTransportLayerBody == null) throw new ArgumentNullException(nameof(restTransportLayerBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.RestTransportLayer, kTransport, irest, restTransportLayerBody, out hash);
			if (cached != null) return (RestTransportLayerGreen)cached;
			var result = new RestTransportLayerGreen(SoalSyntaxKind.RestTransportLayer, kTransport, irest, restTransportLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RestTransportLayerEmptyBodyGreen RestTransportLayerEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.RestTransportLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (RestTransportLayerEmptyBodyGreen)cached;
			var result = new RestTransportLayerEmptyBodyGreen(SoalSyntaxKind.RestTransportLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RestTransportLayerNonEmptyBodyGreen RestTransportLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.RestTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (RestTransportLayerNonEmptyBodyGreen)cached;
			var result = new RestTransportLayerNonEmptyBodyGreen(SoalSyntaxKind.RestTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WebSocketTransportLayerGreen WebSocketTransportLayer(InternalSyntaxToken kTransport, InternalSyntaxToken iWebSocket, WebSocketTransportLayerBodyGreen webSocketTransportLayerBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
				if (kTransport.RawKind != (int)SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
				if (iWebSocket == null) throw new ArgumentNullException(nameof(iWebSocket));
				if (iWebSocket.RawKind != (int)SoalSyntaxKind.IWebSocket) throw new ArgumentException(nameof(iWebSocket));
				if (webSocketTransportLayerBody == null) throw new ArgumentNullException(nameof(webSocketTransportLayerBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.WebSocketTransportLayer, kTransport, iWebSocket, webSocketTransportLayerBody, out hash);
			if (cached != null) return (WebSocketTransportLayerGreen)cached;
			var result = new WebSocketTransportLayerGreen(SoalSyntaxKind.WebSocketTransportLayer, kTransport, iWebSocket, webSocketTransportLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WebSocketTransportLayerEmptyBodyGreen WebSocketTransportLayerEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.WebSocketTransportLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (WebSocketTransportLayerEmptyBodyGreen)cached;
			var result = new WebSocketTransportLayerEmptyBodyGreen(SoalSyntaxKind.WebSocketTransportLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WebSocketTransportLayerNonEmptyBodyGreen WebSocketTransportLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.WebSocketTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (WebSocketTransportLayerNonEmptyBodyGreen)cached;
			var result = new WebSocketTransportLayerNonEmptyBodyGreen(SoalSyntaxKind.WebSocketTransportLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerPropertiesGreen HttpTransportLayerProperties(HttpSslPropertyGreen httpSslProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (httpSslProperty == null) throw new ArgumentNullException(nameof(httpSslProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.HttpTransportLayerProperties, httpSslProperty, out hash);
			if (cached != null) return (HttpTransportLayerPropertiesGreen)cached;
			var result = new HttpTransportLayerPropertiesGreen(SoalSyntaxKind.HttpTransportLayerProperties, httpSslProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpTransportLayerPropertiesGreen HttpTransportLayerProperties(HttpClientAuthenticationPropertyGreen httpClientAuthenticationProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (httpClientAuthenticationProperty == null) throw new ArgumentNullException(nameof(httpClientAuthenticationProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.HttpTransportLayerProperties, httpClientAuthenticationProperty, out hash);
			if (cached != null) return (HttpTransportLayerPropertiesGreen)cached;
			var result = new HttpTransportLayerPropertiesGreen(SoalSyntaxKind.HttpTransportLayerProperties, null, httpClientAuthenticationProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HttpSslPropertyGreen HttpSslProperty(InternalSyntaxToken issl, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (issl == null) throw new ArgumentNullException(nameof(issl));
				if (issl.RawKind != (int)SoalSyntaxKind.ISSL) throw new ArgumentException(nameof(issl));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new HttpSslPropertyGreen(SoalSyntaxKind.HttpSslProperty, issl, tAssign, booleanLiteral, tSemicolon);
	    }
	
		public HttpClientAuthenticationPropertyGreen HttpClientAuthenticationProperty(InternalSyntaxToken iClientAuthentication, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (iClientAuthentication == null) throw new ArgumentNullException(nameof(iClientAuthentication));
				if (iClientAuthentication.RawKind != (int)SoalSyntaxKind.IClientAuthentication) throw new ArgumentException(nameof(iClientAuthentication));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new HttpClientAuthenticationPropertyGreen(SoalSyntaxKind.HttpClientAuthenticationProperty, iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
	    }
	
		public EncodingLayerGreen EncodingLayer(SoapEncodingLayerGreen soapEncodingLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (soapEncodingLayer == null) throw new ArgumentNullException(nameof(soapEncodingLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EncodingLayer, soapEncodingLayer, out hash);
			if (cached != null) return (EncodingLayerGreen)cached;
			var result = new EncodingLayerGreen(SoalSyntaxKind.EncodingLayer, soapEncodingLayer, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EncodingLayerGreen EncodingLayer(XmlEncodingLayerGreen xmlEncodingLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (xmlEncodingLayer == null) throw new ArgumentNullException(nameof(xmlEncodingLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EncodingLayer, xmlEncodingLayer, out hash);
			if (cached != null) return (EncodingLayerGreen)cached;
			var result = new EncodingLayerGreen(SoalSyntaxKind.EncodingLayer, null, xmlEncodingLayer, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EncodingLayerGreen EncodingLayer(JsonEncodingLayerGreen jsonEncodingLayer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (jsonEncodingLayer == null) throw new ArgumentNullException(nameof(jsonEncodingLayer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EncodingLayer, jsonEncodingLayer, out hash);
			if (cached != null) return (EncodingLayerGreen)cached;
			var result = new EncodingLayerGreen(SoalSyntaxKind.EncodingLayer, null, null, jsonEncodingLayer);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingLayerGreen SoapEncodingLayer(InternalSyntaxToken kEncoding, InternalSyntaxToken isoap, SoapEncodingLayerBodyGreen soapEncodingLayerBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
				if (kEncoding.RawKind != (int)SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
				if (isoap == null) throw new ArgumentNullException(nameof(isoap));
				if (isoap.RawKind != (int)SoalSyntaxKind.ISOAP) throw new ArgumentException(nameof(isoap));
				if (soapEncodingLayerBody == null) throw new ArgumentNullException(nameof(soapEncodingLayerBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SoapEncodingLayer, kEncoding, isoap, soapEncodingLayerBody, out hash);
			if (cached != null) return (SoapEncodingLayerGreen)cached;
			var result = new SoapEncodingLayerGreen(SoalSyntaxKind.SoapEncodingLayer, kEncoding, isoap, soapEncodingLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingLayerEmptyBodyGreen SoapEncodingLayerEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SoapEncodingLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (SoapEncodingLayerEmptyBodyGreen)cached;
			var result = new SoapEncodingLayerEmptyBodyGreen(SoalSyntaxKind.SoapEncodingLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingLayerNonEmptyBodyGreen SoapEncodingLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList soapEncodingProperties, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SoapEncodingLayerNonEmptyBody, tOpenBrace, soapEncodingProperties, tCloseBrace, out hash);
			if (cached != null) return (SoapEncodingLayerNonEmptyBodyGreen)cached;
			var result = new SoapEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind.SoapEncodingLayerNonEmptyBody, tOpenBrace, soapEncodingProperties, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XmlEncodingLayerGreen XmlEncodingLayer(InternalSyntaxToken kEncoding, InternalSyntaxToken ixml, XmlEncodingLayerBodyGreen xmlEncodingLayerBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
				if (kEncoding.RawKind != (int)SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
				if (ixml == null) throw new ArgumentNullException(nameof(ixml));
				if (ixml.RawKind != (int)SoalSyntaxKind.IXML) throw new ArgumentException(nameof(ixml));
				if (xmlEncodingLayerBody == null) throw new ArgumentNullException(nameof(xmlEncodingLayerBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.XmlEncodingLayer, kEncoding, ixml, xmlEncodingLayerBody, out hash);
			if (cached != null) return (XmlEncodingLayerGreen)cached;
			var result = new XmlEncodingLayerGreen(SoalSyntaxKind.XmlEncodingLayer, kEncoding, ixml, xmlEncodingLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XmlEncodingLayerEmptyBodyGreen XmlEncodingLayerEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.XmlEncodingLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (XmlEncodingLayerEmptyBodyGreen)cached;
			var result = new XmlEncodingLayerEmptyBodyGreen(SoalSyntaxKind.XmlEncodingLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public XmlEncodingLayerNonEmptyBodyGreen XmlEncodingLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.XmlEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (XmlEncodingLayerNonEmptyBodyGreen)cached;
			var result = new XmlEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind.XmlEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public JsonEncodingLayerGreen JsonEncodingLayer(InternalSyntaxToken kEncoding, InternalSyntaxToken ijson, JsonEncodingLayerBodyGreen jsonEncodingLayerBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
				if (kEncoding.RawKind != (int)SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
				if (ijson == null) throw new ArgumentNullException(nameof(ijson));
				if (ijson.RawKind != (int)SoalSyntaxKind.IJSON) throw new ArgumentException(nameof(ijson));
				if (jsonEncodingLayerBody == null) throw new ArgumentNullException(nameof(jsonEncodingLayerBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.JsonEncodingLayer, kEncoding, ijson, jsonEncodingLayerBody, out hash);
			if (cached != null) return (JsonEncodingLayerGreen)cached;
			var result = new JsonEncodingLayerGreen(SoalSyntaxKind.JsonEncodingLayer, kEncoding, ijson, jsonEncodingLayerBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public JsonEncodingLayerEmptyBodyGreen JsonEncodingLayerEmptyBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.JsonEncodingLayerEmptyBody, tSemicolon, out hash);
			if (cached != null) return (JsonEncodingLayerEmptyBodyGreen)cached;
			var result = new JsonEncodingLayerEmptyBodyGreen(SoalSyntaxKind.JsonEncodingLayerEmptyBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public JsonEncodingLayerNonEmptyBodyGreen JsonEncodingLayerNonEmptyBody(InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.JsonEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace, out hash);
			if (cached != null) return (JsonEncodingLayerNonEmptyBodyGreen)cached;
			var result = new JsonEncodingLayerNonEmptyBodyGreen(SoalSyntaxKind.JsonEncodingLayerNonEmptyBody, tOpenBrace, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingPropertiesGreen SoapEncodingProperties(SoapVersionPropertyGreen soapVersionProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (soapVersionProperty == null) throw new ArgumentNullException(nameof(soapVersionProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SoapEncodingProperties, soapVersionProperty, out hash);
			if (cached != null) return (SoapEncodingPropertiesGreen)cached;
			var result = new SoapEncodingPropertiesGreen(SoalSyntaxKind.SoapEncodingProperties, soapVersionProperty, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingPropertiesGreen SoapEncodingProperties(SoapMtomPropertyGreen soapMtomProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (soapMtomProperty == null) throw new ArgumentNullException(nameof(soapMtomProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SoapEncodingProperties, soapMtomProperty, out hash);
			if (cached != null) return (SoapEncodingPropertiesGreen)cached;
			var result = new SoapEncodingPropertiesGreen(SoalSyntaxKind.SoapEncodingProperties, null, soapMtomProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapEncodingPropertiesGreen SoapEncodingProperties(SoapStylePropertyGreen soapStyleProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (soapStyleProperty == null) throw new ArgumentNullException(nameof(soapStyleProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SoapEncodingProperties, soapStyleProperty, out hash);
			if (cached != null) return (SoapEncodingPropertiesGreen)cached;
			var result = new SoapEncodingPropertiesGreen(SoalSyntaxKind.SoapEncodingProperties, null, null, soapStyleProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SoapVersionPropertyGreen SoapVersionProperty(InternalSyntaxToken iVersion, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (iVersion == null) throw new ArgumentNullException(nameof(iVersion));
				if (iVersion.RawKind != (int)SoalSyntaxKind.IVersion) throw new ArgumentException(nameof(iVersion));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new SoapVersionPropertyGreen(SoalSyntaxKind.SoapVersionProperty, iVersion, tAssign, identifier, tSemicolon);
	    }
	
		public SoapMtomPropertyGreen SoapMtomProperty(InternalSyntaxToken imtom, InternalSyntaxToken tAssign, BooleanLiteralGreen booleanLiteral, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (imtom == null) throw new ArgumentNullException(nameof(imtom));
				if (imtom.RawKind != (int)SoalSyntaxKind.IMTOM) throw new ArgumentException(nameof(imtom));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new SoapMtomPropertyGreen(SoalSyntaxKind.SoapMtomProperty, imtom, tAssign, booleanLiteral, tSemicolon);
	    }
	
		public SoapStylePropertyGreen SoapStyleProperty(InternalSyntaxToken iStyle, InternalSyntaxToken tAssign, IdentifierGreen identifier, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (iStyle == null) throw new ArgumentNullException(nameof(iStyle));
				if (iStyle.RawKind != (int)SoalSyntaxKind.IStyle) throw new ArgumentException(nameof(iStyle));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new SoapStylePropertyGreen(SoalSyntaxKind.SoapStyleProperty, iStyle, tAssign, identifier, tSemicolon);
	    }
	
		public ProtocolLayerGreen ProtocolLayer(InternalSyntaxToken kProtocol, ProtocolLayerKindGreen protocolLayerKind, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kProtocol == null) throw new ArgumentNullException(nameof(kProtocol));
				if (kProtocol.RawKind != (int)SoalSyntaxKind.KProtocol) throw new ArgumentException(nameof(kProtocol));
				if (protocolLayerKind == null) throw new ArgumentNullException(nameof(protocolLayerKind));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ProtocolLayer, kProtocol, protocolLayerKind, tSemicolon, out hash);
			if (cached != null) return (ProtocolLayerGreen)cached;
			var result = new ProtocolLayerGreen(SoalSyntaxKind.ProtocolLayer, kProtocol, protocolLayerKind, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ProtocolLayerKindGreen ProtocolLayerKind(IdentifierGreen identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ProtocolLayerKind, identifier, out hash);
			if (cached != null) return (ProtocolLayerKindGreen)cached;
			var result = new ProtocolLayerKindGreen(SoalSyntaxKind.ProtocolLayerKind, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointDeclarationGreen EndpointDeclaration(InternalSyntaxToken kEndpoint, NameDefGreen nameDef, InternalSyntaxToken tColon, QualifiedNameGreen qualifiedName, EndpointBodyGreen endpointBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEndpoint == null) throw new ArgumentNullException(nameof(kEndpoint));
				if (kEndpoint.RawKind != (int)SoalSyntaxKind.KEndpoint) throw new ArgumentException(nameof(kEndpoint));
				if (nameDef == null) throw new ArgumentNullException(nameof(nameDef));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (endpointBody == null) throw new ArgumentNullException(nameof(endpointBody));
			}
	#endif
	        return new EndpointDeclarationGreen(SoalSyntaxKind.EndpointDeclaration, kEndpoint, nameDef, tColon, qualifiedName, endpointBody);
	    }
	
		public EndpointBodyGreen EndpointBody(InternalSyntaxToken tOpenBrace, EndpointPropertiesGreen endpointProperties, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EndpointBody, tOpenBrace, endpointProperties, tCloseBrace, out hash);
			if (cached != null) return (EndpointBodyGreen)cached;
			var result = new EndpointBodyGreen(SoalSyntaxKind.EndpointBody, tOpenBrace, endpointProperties, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointPropertiesGreen EndpointProperties(InternalSyntaxNodeList endpointProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EndpointProperties, endpointProperty, out hash);
			if (cached != null) return (EndpointPropertiesGreen)cached;
			var result = new EndpointPropertiesGreen(SoalSyntaxKind.EndpointProperties, endpointProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointPropertyGreen EndpointProperty(EndpointBindingPropertyGreen endpointBindingProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (endpointBindingProperty == null) throw new ArgumentNullException(nameof(endpointBindingProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EndpointProperty, endpointBindingProperty, out hash);
			if (cached != null) return (EndpointPropertyGreen)cached;
			var result = new EndpointPropertyGreen(SoalSyntaxKind.EndpointProperty, endpointBindingProperty, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointPropertyGreen EndpointProperty(EndpointAddressPropertyGreen endpointAddressProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (endpointAddressProperty == null) throw new ArgumentNullException(nameof(endpointAddressProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EndpointProperty, endpointAddressProperty, out hash);
			if (cached != null) return (EndpointPropertyGreen)cached;
			var result = new EndpointPropertyGreen(SoalSyntaxKind.EndpointProperty, null, endpointAddressProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointBindingPropertyGreen EndpointBindingProperty(InternalSyntaxToken kBinding, QualifiedNameGreen qualifiedName, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
				if (kBinding.RawKind != (int)SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EndpointBindingProperty, kBinding, qualifiedName, tSemicolon, out hash);
			if (cached != null) return (EndpointBindingPropertyGreen)cached;
			var result = new EndpointBindingPropertyGreen(SoalSyntaxKind.EndpointBindingProperty, kBinding, qualifiedName, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EndpointAddressPropertyGreen EndpointAddressProperty(InternalSyntaxToken kAddress, StringLiteralGreen stringLiteral, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kAddress == null) throw new ArgumentNullException(nameof(kAddress));
				if (kAddress.RawKind != (int)SoalSyntaxKind.KAddress) throw new ArgumentException(nameof(kAddress));
				if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.EndpointAddressProperty, kAddress, stringLiteral, tSemicolon, out hash);
			if (cached != null) return (EndpointAddressPropertyGreen)cached;
			var result = new EndpointAddressPropertyGreen(SoalSyntaxKind.EndpointAddressProperty, kAddress, stringLiteral, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnTypeGreen ReturnType(TypeReferenceGreen typeReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(SoalSyntaxKind.ReturnType, typeReference, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReturnTypeGreen ReturnType(VoidTypeGreen voidType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (voidType == null) throw new ArgumentNullException(nameof(voidType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(SoalSyntaxKind.ReturnType, null, voidType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(NonNullableArrayTypeGreen nonNullableArrayType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nonNullableArrayType == null) throw new ArgumentNullException(nameof(nonNullableArrayType));
			}
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, nonNullableArrayType, null, null, null);
	    }
	
		public TypeReferenceGreen TypeReference(ArrayTypeGreen arrayType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
			}
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, null, arrayType, null, null);
	    }
	
		public TypeReferenceGreen TypeReference(SimpleTypeGreen simpleType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
			}
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, null, null, simpleType, null);
	    }
	
		public TypeReferenceGreen TypeReference(NulledTypeGreen nulledType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nulledType == null) throw new ArgumentNullException(nameof(nulledType));
			}
	#endif
			return new TypeReferenceGreen(SoalSyntaxKind.TypeReference, null, null, null, nulledType);
	    }
	
		public SimpleTypeGreen SimpleType(ValueTypeGreen valueType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (valueType == null) throw new ArgumentNullException(nameof(valueType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SimpleType, valueType, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(SoalSyntaxKind.SimpleType, valueType, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(ObjectTypeGreen objectType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (objectType == null) throw new ArgumentNullException(nameof(objectType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SimpleType, objectType, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(SoalSyntaxKind.SimpleType, null, objectType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(QualifiedNameGreen qualifiedName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SimpleType, qualifiedName, out hash);
			if (cached != null) return (SimpleTypeGreen)cached;
			var result = new SimpleTypeGreen(SoalSyntaxKind.SimpleType, null, null, qualifiedName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NulledTypeGreen NulledType(NullableTypeGreen nullableType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NulledType, nullableType, out hash);
			if (cached != null) return (NulledTypeGreen)cached;
			var result = new NulledTypeGreen(SoalSyntaxKind.NulledType, nullableType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NulledTypeGreen NulledType(NonNullableTypeGreen nonNullableType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nonNullableType == null) throw new ArgumentNullException(nameof(nonNullableType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NulledType, nonNullableType, out hash);
			if (cached != null) return (NulledTypeGreen)cached;
			var result = new NulledTypeGreen(SoalSyntaxKind.NulledType, null, nonNullableType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReferenceTypeGreen ReferenceType(ObjectTypeGreen objectType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (objectType == null) throw new ArgumentNullException(nameof(objectType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ReferenceType, objectType, out hash);
			if (cached != null) return (ReferenceTypeGreen)cached;
			var result = new ReferenceTypeGreen(SoalSyntaxKind.ReferenceType, objectType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ReferenceTypeGreen ReferenceType(QualifiedNameGreen qualifiedName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ReferenceType, qualifiedName, out hash);
			if (cached != null) return (ReferenceTypeGreen)cached;
			var result = new ReferenceTypeGreen(SoalSyntaxKind.ReferenceType, null, qualifiedName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ObjectTypeGreen ObjectType(InternalSyntaxToken objectType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (objectType == null) throw new ArgumentNullException(nameof(objectType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ObjectType, objectType, out hash);
			if (cached != null) return (ObjectTypeGreen)cached;
			var result = new ObjectTypeGreen(SoalSyntaxKind.ObjectType, objectType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ValueTypeGreen ValueType(InternalSyntaxToken valueType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (valueType == null) throw new ArgumentNullException(nameof(valueType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ValueType, valueType, out hash);
			if (cached != null) return (ValueTypeGreen)cached;
			var result = new ValueTypeGreen(SoalSyntaxKind.ValueType, valueType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public VoidTypeGreen VoidType(InternalSyntaxToken kVoid, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
				if (kVoid.RawKind != (int)SoalSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(SoalSyntaxKind.VoidType, kVoid);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OnewayTypeGreen OnewayType(InternalSyntaxToken kOneway, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kOneway == null) throw new ArgumentNullException(nameof(kOneway));
				if (kOneway.RawKind != (int)SoalSyntaxKind.KOneway) throw new ArgumentException(nameof(kOneway));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.OnewayType, kOneway, out hash);
			if (cached != null) return (OnewayTypeGreen)cached;
			var result = new OnewayTypeGreen(SoalSyntaxKind.OnewayType, kOneway);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationReturnTypeGreen OperationReturnType(ReturnTypeGreen returnType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (returnType == null) throw new ArgumentNullException(nameof(returnType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.OperationReturnType, returnType, out hash);
			if (cached != null) return (OperationReturnTypeGreen)cached;
			var result = new OperationReturnTypeGreen(SoalSyntaxKind.OperationReturnType, returnType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationReturnTypeGreen OperationReturnType(OnewayTypeGreen onewayType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (onewayType == null) throw new ArgumentNullException(nameof(onewayType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.OperationReturnType, onewayType, out hash);
			if (cached != null) return (OperationReturnTypeGreen)cached;
			var result = new OperationReturnTypeGreen(SoalSyntaxKind.OperationReturnType, null, onewayType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableTypeGreen NullableType(ValueTypeGreen valueType, InternalSyntaxToken tQuestion, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (valueType == null) throw new ArgumentNullException(nameof(valueType));
				if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
				if (tQuestion.RawKind != (int)SoalSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NullableType, valueType, tQuestion, out hash);
			if (cached != null) return (NullableTypeGreen)cached;
			var result = new NullableTypeGreen(SoalSyntaxKind.NullableType, valueType, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NonNullableTypeGreen NonNullableType(ReferenceTypeGreen referenceType, InternalSyntaxToken tExclamation, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (referenceType == null) throw new ArgumentNullException(nameof(referenceType));
				if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
				if (tExclamation.RawKind != (int)SoalSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NonNullableType, referenceType, tExclamation, out hash);
			if (cached != null) return (NonNullableTypeGreen)cached;
			var result = new NonNullableTypeGreen(SoalSyntaxKind.NonNullableType, referenceType, tExclamation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NonNullableArrayTypeGreen NonNullableArrayType(ArrayTypeGreen arrayType, InternalSyntaxToken tExclamation, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
				if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
				if (tExclamation.RawKind != (int)SoalSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NonNullableArrayType, arrayType, tExclamation, out hash);
			if (cached != null) return (NonNullableArrayTypeGreen)cached;
			var result = new NonNullableArrayTypeGreen(SoalSyntaxKind.NonNullableArrayType, arrayType, tExclamation);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayTypeGreen ArrayType(SimpleArrayTypeGreen simpleArrayType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (simpleArrayType == null) throw new ArgumentNullException(nameof(simpleArrayType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ArrayType, simpleArrayType, out hash);
			if (cached != null) return (ArrayTypeGreen)cached;
			var result = new ArrayTypeGreen(SoalSyntaxKind.ArrayType, simpleArrayType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArrayTypeGreen ArrayType(NulledArrayTypeGreen nulledArrayType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nulledArrayType == null) throw new ArgumentNullException(nameof(nulledArrayType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ArrayType, nulledArrayType, out hash);
			if (cached != null) return (ArrayTypeGreen)cached;
			var result = new ArrayTypeGreen(SoalSyntaxKind.ArrayType, null, nulledArrayType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleArrayTypeGreen SimpleArrayType(SimpleTypeGreen simpleType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
				if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
				if (tOpenBracket.RawKind != (int)SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
				if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
				if (tCloseBracket.RawKind != (int)SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.SimpleArrayType, simpleType, tOpenBracket, tCloseBracket, out hash);
			if (cached != null) return (SimpleArrayTypeGreen)cached;
			var result = new SimpleArrayTypeGreen(SoalSyntaxKind.SimpleArrayType, simpleType, tOpenBracket, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NulledArrayTypeGreen NulledArrayType(NulledTypeGreen nulledType, InternalSyntaxToken tOpenBracket, InternalSyntaxToken tCloseBracket, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (nulledType == null) throw new ArgumentNullException(nameof(nulledType));
				if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
				if (tOpenBracket.RawKind != (int)SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
				if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
				if (tCloseBracket.RawKind != (int)SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NulledArrayType, nulledType, tOpenBracket, tCloseBracket, out hash);
			if (cached != null) return (NulledArrayTypeGreen)cached;
			var result = new NulledArrayTypeGreen(SoalSyntaxKind.NulledArrayType, nulledType, tOpenBracket, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConstantValueGreen ConstantValue(LiteralGreen literal, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (literal == null) throw new ArgumentNullException(nameof(literal));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ConstantValue, literal, out hash);
			if (cached != null) return (ConstantValueGreen)cached;
			var result = new ConstantValueGreen(SoalSyntaxKind.ConstantValue, literal, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConstantValueGreen ConstantValue(IdentifierGreen identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ConstantValue, identifier, out hash);
			if (cached != null) return (ConstantValueGreen)cached;
			var result = new ConstantValueGreen(SoalSyntaxKind.ConstantValue, null, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeofValueGreen TypeofValue(InternalSyntaxToken kTypeof, InternalSyntaxToken tOpenParen, ReturnTypeGreen returnType, InternalSyntaxToken tCloseParen, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
				if (kTypeof.RawKind != (int)SoalSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
				if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
				if (tOpenParen.RawKind != (int)SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
				if (returnType == null) throw new ArgumentNullException(nameof(returnType));
				if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
				if (tCloseParen.RawKind != (int)SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			}
	#endif
	        return new TypeofValueGreen(SoalSyntaxKind.TypeofValue, kTypeof, tOpenParen, returnType, tCloseParen);
	    }
	
		public IdentifierGreen Identifier(IdentifiersGreen identifiers, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.Identifier, identifiers, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(SoalSyntaxKind.Identifier, identifiers, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(ContextualKeywordsGreen contextualKeywords, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (contextualKeywords == null) throw new ArgumentNullException(nameof(contextualKeywords));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.Identifier, contextualKeywords, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(SoalSyntaxKind.Identifier, null, contextualKeywords);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifiersGreen Identifiers(InternalSyntaxToken identifiers, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.Identifiers, identifiers, out hash);
			if (cached != null) return (IdentifiersGreen)cached;
			var result = new IdentifiersGreen(SoalSyntaxKind.Identifiers, identifiers);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LiteralGreen Literal(NullLiteralGreen nullLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
			}
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
			}
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
			}
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
			}
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
			}
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
			}
	#endif
			return new LiteralGreen(SoalSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kNull == null) throw new ArgumentNullException(nameof(kNull));
				if (kNull.RawKind != (int)SoalSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(SoalSyntaxKind.NullLiteral, kNull);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BooleanLiteralGreen BooleanLiteral(InternalSyntaxToken booleanLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(SoalSyntaxKind.BooleanLiteral, booleanLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IntegerLiteralGreen IntegerLiteral(InternalSyntaxToken lInteger, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
				if (lInteger.RawKind != (int)SoalSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(SoalSyntaxKind.IntegerLiteral, lInteger);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DecimalLiteralGreen DecimalLiteral(InternalSyntaxToken lDecimal, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
				if (lDecimal.RawKind != (int)SoalSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(SoalSyntaxKind.DecimalLiteral, lDecimal);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ScientificLiteralGreen ScientificLiteral(InternalSyntaxToken lScientific, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
				if (lScientific.RawKind != (int)SoalSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(SoalSyntaxKind.ScientificLiteral, lScientific);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringLiteralGreen StringLiteral(InternalSyntaxToken stringLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.StringLiteral, stringLiteral, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(SoalSyntaxKind.StringLiteral, stringLiteral);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ContextualKeywordsGreen ContextualKeywords(InternalSyntaxToken contextualKeywords, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (contextualKeywords == null) throw new ArgumentNullException(nameof(contextualKeywords));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SoalSyntaxKind.ContextualKeywords, contextualKeywords, out hash);
			if (cached != null) return (ContextualKeywordsGreen)cached;
			var result = new ContextualKeywordsGreen(SoalSyntaxKind.ContextualKeywords, contextualKeywords);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
	    internal IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainGreen),
				typeof(NameDefGreen),
				typeof(QualifiedNameDefGreen),
				typeof(QualifiedNameGreen),
				typeof(IdentifierListGreen),
				typeof(QualifiedNameListGreen),
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
				typeof(NamespaceBodyGreen),
				typeof(DeclarationGreen),
				typeof(EnumDeclarationGreen),
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
				typeof(ComponentDeclarationGreen),
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


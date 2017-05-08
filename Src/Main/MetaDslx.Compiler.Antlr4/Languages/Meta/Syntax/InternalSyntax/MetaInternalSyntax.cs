// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
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

namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    internal abstract class MetaGreenNode : InternalSyntaxNode
    {
        public MetaGreenNode(MetaSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, 0, diagnostics, annotations)
        {
        }

        public MetaSyntaxKind Kind
        {
            get { return (MetaSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return MetaLanguage.Instance; }
        }
    }

    internal class MetaGreenTrivia : InternalSyntaxTrivia
    {
        public MetaGreenTrivia(MetaSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        public MetaSyntaxKind Kind
        {
            get { return (MetaSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return MetaLanguage.Instance; }
        }

        public override SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index)
        {
            return new MetaSyntaxTrivia(this, parent, position, index);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new MetaGreenTrivia(this.Kind, this.Text, diagnostics, this.GetAnnotations());
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new MetaGreenTrivia(this.Kind, this.Text, this.GetDiagnostics(), annotations);
        }
    }

	public class MetaGreenToken : InternalSyntaxToken
	{
		public MetaGreenToken(MetaSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
		    : base((int)kind, diagnostics, annotations)
		{
		}
	
	    public MetaGreenToken(MetaSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base((int)kind, fullWidth, diagnostics, annotations)
	    {
	    }
	
	    public MetaSyntaxKind Kind
		{
		    get { return (MetaSyntaxKind)base.RawKind; }
		}
	
		public virtual MetaSyntaxKind ContextualKind
		{
		    get { return this.Kind; }
		}
	
	    public override string Text
	    {
	        get
	        {
	            return MetaLanguage.Instance.SyntaxFacts.GetText(this.Kind);
	        }
	    }
	
	    public override Language Language
	    {
	        get { return MetaLanguage.Instance; }
	    }
	
	    public override SyntaxToken CreateRed(SyntaxNode parent, int position, int index)
	    {
	        return new MetaSyntaxToken(this, parent, position, index);
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
	        return new MetaGreenToken(this.Kind, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetaGreenToken(this.Kind, diagnostics, this.GetAnnotations());
	    }
	
	    internal static MetaGreenToken Create(MetaSyntaxKind kind)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!MetaLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, null, null);
	        }
	
	        return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	    }
	
	    internal static MetaGreenToken Create(MetaSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!MetaLanguage.Instance.SyntaxFacts.IsToken(kind))
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
	            else if (trailing == MetaLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == MetaLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	        }
	
	        if (leading == MetaLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == MetaLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	        }
	
	        return new SyntaxTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static MetaGreenToken CreateMissing(MetaSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static readonly MetaSyntaxKind FirstTokenWithWellKnownText = MetaSyntaxKind.KNamespace;
	    internal static readonly MetaSyntaxKind LastTokenWithWellKnownText = MetaSyntaxKind.LCommentStart;
	
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly MetaGreenToken[] s_tokensWithNoTrivia = new MetaGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly MetaGreenToken[] s_tokensWithElasticTrivia = new MetaGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly MetaGreenToken[] s_tokensWithSingleTrailingSpace = new MetaGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly MetaGreenToken[] s_tokensWithSingleTrailingCRLF = new MetaGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	
	    static MetaGreenToken()
	    {
	        for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new MetaGreenToken(kind, null, null);
	            s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, MetaLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, MetaLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, null, null);
	            s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, MetaLanguage.Instance.InternalSyntaxFactory.Space, null, null);
	            s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, MetaLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed, null, null);
	        }
	    }
	
	    internal static IEnumerable<MetaGreenToken> GetWellKnownTokens()
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
	
	    internal static MetaGreenToken WithText(MetaSyntaxKind kind, string text)
	    {
	        return new SyntaxTokenWithText(kind, text, null, null);
	    }
	
	    internal static MetaGreenToken WithText(MetaSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	
	    internal static MetaGreenToken WithText(MetaSyntaxKind kind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (valueText == text)
	        {
	            return WithText(kind, leading, text, trailing);
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, valueText, leading, trailing, null, null);
	    }
	
	    internal static MetaGreenToken WithValue<T>(MetaSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value, null, null);
	    }
	
	    internal static MetaGreenToken WithValue<T>(MetaSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing, null, null);
	    }
	
	    private class SyntaxTokenWithTrivia : MetaGreenToken
	    {
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	
	        internal SyntaxTokenWithTrivia(MetaSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal MissingTokenWithTrivia(MetaSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	    private class SyntaxTokenWithText : MetaGreenToken
	    {
	        protected readonly string TextField;
	
	        internal SyntaxTokenWithText(MetaSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxIdentifierExtended(MetaSyntaxKind kind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxTokenWithTextAndTrailingTrivia(MetaSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            MetaSyntaxKind kind,
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
	
	    private class SyntaxTokenWithValue<T> : MetaGreenToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	
	        internal SyntaxTokenWithValue(MetaSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            MetaSyntaxKind kind,
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
	
	internal class MainGreen : MetaGreenNode
	{
	    private NamespaceDeclarationGreen namespaceDeclaration;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(MetaSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eof)
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
	
	    public MainGreen(MetaSyntaxKind kind, NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	    public NamespaceDeclarationGreen NamespaceDeclaration { get { return this.namespaceDeclaration; } }
	    public InternalSyntaxToken Eof { get { return this.eof; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.MainSyntax(this, parent, position);
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
	
	    public MainGreen Update(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eof)
	    {
	        if (this.namespaceDeclaration != namespaceDeclaration ||
				this.eof != eof)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Main(namespaceDeclaration, eof);
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
	
	internal class NameGreen : MetaGreenNode
	{
	    private IdentifierGreen identifier;
	
	    public NameGreen(MetaSyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(MetaSyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.NameSyntax(this, parent, position);
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
	        return new NameGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NameGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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
	
	internal class QualifiedNameGreen : MetaGreenNode
	{
	    private QualifierGreen qualifier;
	
	    public QualifiedNameGreen(MetaSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(MetaSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.QualifiedNameSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameGreen Update(QualifierGreen qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
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
	
	internal class QualifierGreen : MetaGreenNode
	{
	    private InternalSeparatedSyntaxNodeList identifier;
	
	    public QualifierGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.QualifierSyntax(this, parent, position);
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
	        return new QualifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifierGreen Update(InternalSeparatedSyntaxNodeList identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
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
	
	internal class AnnotationGreen : MetaGreenNode
	{
	    private InternalSyntaxToken tOpenBracket;
	    private NameGreen name;
	    private InternalSyntaxToken tCloseBracket;
	
	    public AnnotationGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket)
	        : base(kind, null, null)
	    {
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
	
	    public AnnotationGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBracket { get { return this.tOpenBracket; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TCloseBracket { get { return this.tCloseBracket; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.AnnotationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBracket;
	            case 1: return this.name;
	            case 2: return this.tCloseBracket;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.name, this.tCloseBracket, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AnnotationGreen(this.Kind, this.tOpenBracket, this.name, this.tCloseBracket, this.GetDiagnostics(), annotations);
	    }
	
	    public AnnotationGreen Update(InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket)
	    {
	        if (this.tOpenBracket != tOpenBracket ||
				this.name != name ||
				this.tCloseBracket != tCloseBracket)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Annotation(tOpenBracket, name, tCloseBracket);
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
	
	internal class NamespaceDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBodyGreen namespaceBody;
	
	    public NamespaceDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public NamespaceDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.NamespaceDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kNamespace;
	            case 2: return this.qualifiedName;
	            case 3: return this.namespaceBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.annotation, this.kNamespace, this.qualifiedName, this.namespaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceDeclarationGreen(this.Kind, this.annotation, this.kNamespace, this.qualifiedName, this.namespaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceDeclarationGreen Update(InternalSyntaxNodeList annotation, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	    {
	        if (this.annotation != annotation ||
				this.kNamespace != kNamespace ||
				this.qualifiedName != qualifiedName ||
				this.namespaceBody != namespaceBody)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(annotation, kNamespace, qualifiedName, namespaceBody);
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
	
	internal class NamespaceBodyGreen : MetaGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private MetamodelDeclarationGreen metamodelDeclaration;
	    private InternalSyntaxNodeList declaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBodyGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public NamespaceBodyGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public MetamodelDeclarationGreen MetamodelDeclaration { get { return this.metamodelDeclaration; } }
	    public InternalSyntaxNodeList Declaration { get { return this.declaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.NamespaceBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.metamodelDeclaration, this.declaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.metamodelDeclaration, this.declaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBodyGreen Update(InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.metamodelDeclaration != metamodelDeclaration ||
				this.declaration != declaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
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
	
	internal class MetamodelDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private InternalSyntaxToken kMetamodel;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private MetamodelPropertyListGreen metamodelPropertyList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tSemicolon;
	
	    public MetamodelDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public MetamodelDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 7; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public InternalSyntaxToken KMetamodel { get { return this.kMetamodel; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public MetamodelPropertyListGreen MetamodelPropertyList { get { return this.metamodelPropertyList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.MetamodelDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kMetamodel;
	            case 2: return this.name;
	            case 3: return this.tOpenParen;
	            case 4: return this.metamodelPropertyList;
	            case 5: return this.tCloseParen;
	            case 6: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelDeclarationGreen(this.Kind, this.annotation, this.kMetamodel, this.name, this.tOpenParen, this.metamodelPropertyList, this.tCloseParen, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelDeclarationGreen(this.Kind, this.annotation, this.kMetamodel, this.name, this.tOpenParen, this.metamodelPropertyList, this.tCloseParen, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelDeclarationGreen Update(InternalSyntaxNodeList annotation, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	        if (this.annotation != annotation ||
				this.kMetamodel != kMetamodel ||
				this.name != name ||
				this.tOpenParen != tOpenParen ||
				this.metamodelPropertyList != metamodelPropertyList ||
				this.tCloseParen != tCloseParen ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.MetamodelDeclaration(annotation, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
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
	
	internal class MetamodelPropertyListGreen : MetaGreenNode
	{
	    private InternalSeparatedSyntaxNodeList metamodelProperty;
	
	    public MetamodelPropertyListGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList metamodelProperty)
	        : base(kind, null, null)
	    {
			if (metamodelProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelProperty);
				this.metamodelProperty = metamodelProperty;
			}
	    }
	
	    public MetamodelPropertyListGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList metamodelProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (metamodelProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelProperty);
				this.metamodelProperty = metamodelProperty;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList MetamodelProperty { get { return this.metamodelProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.MetamodelPropertyListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.metamodelProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelPropertyListGreen(this.Kind, this.metamodelProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelPropertyListGreen(this.Kind, this.metamodelProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelPropertyListGreen Update(InternalSeparatedSyntaxNodeList metamodelProperty)
	    {
	        if (this.metamodelProperty != metamodelProperty)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.MetamodelPropertyList(metamodelProperty);
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
	
	internal class MetamodelPropertyGreen : MetaGreenNode
	{
	    private MetamodelUriPropertyGreen metamodelUriProperty;
	
	    public MetamodelPropertyGreen(MetaSyntaxKind kind, MetamodelUriPropertyGreen metamodelUriProperty)
	        : base(kind, null, null)
	    {
			if (metamodelUriProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelUriProperty);
				this.metamodelUriProperty = metamodelUriProperty;
			}
	    }
	
	    public MetamodelPropertyGreen(MetaSyntaxKind kind, MetamodelUriPropertyGreen metamodelUriProperty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (metamodelUriProperty != null)
			{
				this.AdjustFlagsAndWidth(metamodelUriProperty);
				this.metamodelUriProperty = metamodelUriProperty;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public MetamodelUriPropertyGreen MetamodelUriProperty { get { return this.metamodelUriProperty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.MetamodelPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.metamodelUriProperty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelPropertyGreen(this.Kind, this.metamodelUriProperty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelPropertyGreen(this.Kind, this.metamodelUriProperty, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelPropertyGreen Update(MetamodelUriPropertyGreen metamodelUriProperty)
	    {
	        if (this.metamodelUriProperty != metamodelUriProperty)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.MetamodelProperty(metamodelUriProperty);
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
	
	internal class MetamodelUriPropertyGreen : MetaGreenNode
	{
	    private InternalSyntaxToken iUri;
	    private InternalSyntaxToken tAssign;
	    private StringLiteralGreen stringLiteral;
	
	    public MetamodelUriPropertyGreen(MetaSyntaxKind kind, InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	        : base(kind, null, null)
	    {
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
	
	    public MetamodelUriPropertyGreen(MetaSyntaxKind kind, InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken IUri { get { return this.iUri; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringLiteralGreen StringLiteral { get { return this.stringLiteral; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.MetamodelUriPropertySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.iUri;
	            case 1: return this.tAssign;
	            case 2: return this.stringLiteral;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MetamodelUriPropertyGreen(this.Kind, this.iUri, this.tAssign, this.stringLiteral, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MetamodelUriPropertyGreen(this.Kind, this.iUri, this.tAssign, this.stringLiteral, this.GetDiagnostics(), annotations);
	    }
	
	    public MetamodelUriPropertyGreen Update(InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral)
	    {
	        if (this.iUri != iUri ||
				this.tAssign != tAssign ||
				this.stringLiteral != stringLiteral)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
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
	
	internal class DeclarationGreen : MetaGreenNode
	{
	    private EnumDeclarationGreen enumDeclaration;
	    private ClassDeclarationGreen classDeclaration;
	    private AssociationDeclarationGreen associationDeclaration;
	    private ConstDeclarationGreen constDeclaration;
	
	    public DeclarationGreen(MetaSyntaxKind kind, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, AssociationDeclarationGreen associationDeclaration, ConstDeclarationGreen constDeclaration)
	        : base(kind, null, null)
	    {
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
	
	    public DeclarationGreen(MetaSyntaxKind kind, EnumDeclarationGreen enumDeclaration, ClassDeclarationGreen classDeclaration, AssociationDeclarationGreen associationDeclaration, ConstDeclarationGreen constDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public EnumDeclarationGreen EnumDeclaration { get { return this.enumDeclaration; } }
	    public ClassDeclarationGreen ClassDeclaration { get { return this.classDeclaration; } }
	    public AssociationDeclarationGreen AssociationDeclaration { get { return this.associationDeclaration; } }
	    public ConstDeclarationGreen ConstDeclaration { get { return this.constDeclaration; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.DeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.classDeclaration, this.associationDeclaration, this.constDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.enumDeclaration, this.classDeclaration, this.associationDeclaration, this.constDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(EnumDeclarationGreen enumDeclaration)
	    {
	        if (this.enumDeclaration != enumDeclaration)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Declaration(enumDeclaration);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Declaration(classDeclaration);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Declaration(associationDeclaration);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Declaration(constDeclaration);
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
	
	internal class EnumDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private InternalSyntaxToken kEnum;
	    private NameGreen name;
	    private EnumBodyGreen enumBody;
	
	    public EnumDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public EnumDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public InternalSyntaxToken KEnum { get { return this.kEnum; } }
	    public NameGreen Name { get { return this.name; } }
	    public EnumBodyGreen EnumBody { get { return this.enumBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.EnumDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kEnum;
	            case 2: return this.name;
	            case 3: return this.enumBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.annotation, this.kEnum, this.name, this.enumBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumDeclarationGreen(this.Kind, this.annotation, this.kEnum, this.name, this.enumBody, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumDeclarationGreen Update(InternalSyntaxNodeList annotation, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody)
	    {
	        if (this.annotation != annotation ||
				this.kEnum != kEnum ||
				this.name != name ||
				this.enumBody != enumBody)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(annotation, kEnum, name, enumBody);
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
	
	internal class EnumBodyGreen : MetaGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private EnumValuesGreen enumValues;
	    private InternalSyntaxToken tSemicolon;
	    private InternalSyntaxNodeList enumMemberDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public EnumBodyGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, InternalSyntaxNodeList enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public EnumBodyGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, InternalSyntaxNodeList enumMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public EnumValuesGreen EnumValues { get { return this.enumValues; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	    public InternalSyntaxNodeList EnumMemberDeclaration { get { return this.enumMemberDeclaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.EnumBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumValues, this.tSemicolon, this.enumMemberDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumBodyGreen(this.Kind, this.tOpenBrace, this.enumValues, this.tSemicolon, this.enumMemberDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumBodyGreen Update(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, InternalSyntaxNodeList enumMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.enumValues != enumValues ||
				this.tSemicolon != tSemicolon ||
				this.enumMemberDeclaration != enumMemberDeclaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
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
	
	internal class EnumValuesGreen : MetaGreenNode
	{
	    private InternalSeparatedSyntaxNodeList enumValue;
	
	    public EnumValuesGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList enumValue)
	        : base(kind, null, null)
	    {
			if (enumValue != null)
			{
				this.AdjustFlagsAndWidth(enumValue);
				this.enumValue = enumValue;
			}
	    }
	
	    public EnumValuesGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList enumValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (enumValue != null)
			{
				this.AdjustFlagsAndWidth(enumValue);
				this.enumValue = enumValue;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList EnumValue { get { return this.enumValue; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.EnumValuesSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.enumValue;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumValuesGreen(this.Kind, this.enumValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumValuesGreen(this.Kind, this.enumValue, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumValuesGreen Update(InternalSeparatedSyntaxNodeList enumValue)
	    {
	        if (this.enumValue != enumValue)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.EnumValues(enumValue);
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
	
	internal class EnumValueGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private NameGreen name;
	
	    public EnumValueGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, NameGreen name)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
	    public EnumValueGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public NameGreen Name { get { return this.name; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.EnumValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.name;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumValueGreen(this.Kind, this.annotation, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumValueGreen(this.Kind, this.annotation, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumValueGreen Update(InternalSyntaxNodeList annotation, NameGreen name)
	    {
	        if (this.annotation != annotation ||
				this.name != name)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.EnumValue(annotation, name);
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
	
	internal class EnumMemberDeclarationGreen : MetaGreenNode
	{
	    private OperationDeclarationGreen operationDeclaration;
	
	    public EnumMemberDeclarationGreen(MetaSyntaxKind kind, OperationDeclarationGreen operationDeclaration)
	        : base(kind, null, null)
	    {
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
	    public EnumMemberDeclarationGreen(MetaSyntaxKind kind, OperationDeclarationGreen operationDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (operationDeclaration != null)
			{
				this.AdjustFlagsAndWidth(operationDeclaration);
				this.operationDeclaration = operationDeclaration;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public OperationDeclarationGreen OperationDeclaration { get { return this.operationDeclaration; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.EnumMemberDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.operationDeclaration;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EnumMemberDeclarationGreen(this.Kind, this.operationDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EnumMemberDeclarationGreen(this.Kind, this.operationDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public EnumMemberDeclarationGreen Update(OperationDeclarationGreen operationDeclaration)
	    {
	        if (this.operationDeclaration != operationDeclaration)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.EnumMemberDeclaration(operationDeclaration);
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
	
	internal class ClassDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private InternalSyntaxToken kAbstract;
	    private InternalSyntaxToken kClass;
	    private NameGreen name;
	    private InternalSyntaxToken tColon;
	    private ClassAncestorsGreen classAncestors;
	    private ClassBodyGreen classBody;
	
	    public ClassDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public ClassDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 7; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public InternalSyntaxToken KAbstract { get { return this.kAbstract; } }
	    public InternalSyntaxToken KClass { get { return this.kClass; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public ClassAncestorsGreen ClassAncestors { get { return this.classAncestors; } }
	    public ClassBodyGreen ClassBody { get { return this.classBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ClassDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kAbstract;
	            case 2: return this.kClass;
	            case 3: return this.name;
	            case 4: return this.tColon;
	            case 5: return this.classAncestors;
	            case 6: return this.classBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.annotation, this.kAbstract, this.kClass, this.name, this.tColon, this.classAncestors, this.classBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassDeclarationGreen(this.Kind, this.annotation, this.kAbstract, this.kClass, this.name, this.tColon, this.classAncestors, this.classBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassDeclarationGreen Update(InternalSyntaxNodeList annotation, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody)
	    {
	        if (this.annotation != annotation ||
				this.kAbstract != kAbstract ||
				this.kClass != kClass ||
				this.name != name ||
				this.tColon != tColon ||
				this.classAncestors != classAncestors ||
				this.classBody != classBody)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(annotation, kAbstract, kClass, name, tColon, classAncestors, classBody);
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
	
	internal class ClassBodyGreen : MetaGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList classMemberDeclaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ClassBodyGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
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
	
	    public ClassBodyGreen(MetaSyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList classMemberDeclaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList ClassMemberDeclaration { get { return this.classMemberDeclaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ClassBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.classMemberDeclaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassBodyGreen(this.Kind, this.tOpenBrace, this.classMemberDeclaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassBodyGreen(this.Kind, this.tOpenBrace, this.classMemberDeclaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList classMemberDeclaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.classMemberDeclaration != classMemberDeclaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
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
	
	internal class ClassAncestorsGreen : MetaGreenNode
	{
	    private InternalSeparatedSyntaxNodeList classAncestor;
	
	    public ClassAncestorsGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList classAncestor)
	        : base(kind, null, null)
	    {
			if (classAncestor != null)
			{
				this.AdjustFlagsAndWidth(classAncestor);
				this.classAncestor = classAncestor;
			}
	    }
	
	    public ClassAncestorsGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList classAncestor, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (classAncestor != null)
			{
				this.AdjustFlagsAndWidth(classAncestor);
				this.classAncestor = classAncestor;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList ClassAncestor { get { return this.classAncestor; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ClassAncestorsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.classAncestor;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassAncestorsGreen(this.Kind, this.classAncestor, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassAncestorsGreen(this.Kind, this.classAncestor, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassAncestorsGreen Update(InternalSeparatedSyntaxNodeList classAncestor)
	    {
	        if (this.classAncestor != classAncestor)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassAncestors(classAncestor);
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
	
	internal class ClassAncestorGreen : MetaGreenNode
	{
	    private QualifierGreen qualifier;
	
	    public ClassAncestorGreen(MetaSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ClassAncestorGreen(MetaSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ClassAncestorSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassAncestorGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassAncestorGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassAncestorGreen Update(QualifierGreen qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassAncestor(qualifier);
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
	
	internal class ClassMemberDeclarationGreen : MetaGreenNode
	{
	    private FieldDeclarationGreen fieldDeclaration;
	    private OperationDeclarationGreen operationDeclaration;
	
	    public ClassMemberDeclarationGreen(MetaSyntaxKind kind, FieldDeclarationGreen fieldDeclaration, OperationDeclarationGreen operationDeclaration)
	        : base(kind, null, null)
	    {
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
	
	    public ClassMemberDeclarationGreen(MetaSyntaxKind kind, FieldDeclarationGreen fieldDeclaration, OperationDeclarationGreen operationDeclaration, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public FieldDeclarationGreen FieldDeclaration { get { return this.fieldDeclaration; } }
	    public OperationDeclarationGreen OperationDeclaration { get { return this.operationDeclaration; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ClassMemberDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldDeclaration;
	            case 1: return this.operationDeclaration;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassMemberDeclarationGreen(this.Kind, this.fieldDeclaration, this.operationDeclaration, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassMemberDeclarationGreen(this.Kind, this.fieldDeclaration, this.operationDeclaration, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassMemberDeclarationGreen Update(FieldDeclarationGreen fieldDeclaration)
	    {
	        if (this.fieldDeclaration != fieldDeclaration)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration(fieldDeclaration);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration(operationDeclaration);
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
	
	internal class FieldDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private FieldModifierGreen fieldModifier;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings;
	    private InternalSyntaxToken tSemicolon;
	
	    public FieldDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public FieldDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 6; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public FieldModifierGreen FieldModifier { get { return this.fieldModifier; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public RedefinitionsOrSubsettingsGreen RedefinitionsOrSubsettings { get { return this.redefinitionsOrSubsettings; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.FieldDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.fieldModifier;
	            case 2: return this.typeReference;
	            case 3: return this.name;
	            case 4: return this.redefinitionsOrSubsettings;
	            case 5: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.annotation, this.fieldModifier, this.typeReference, this.name, this.redefinitionsOrSubsettings, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldDeclarationGreen(this.Kind, this.annotation, this.fieldModifier, this.typeReference, this.name, this.redefinitionsOrSubsettings, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldDeclarationGreen Update(InternalSyntaxNodeList annotation, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon)
	    {
	        if (this.annotation != annotation ||
				this.fieldModifier != fieldModifier ||
				this.typeReference != typeReference ||
				this.name != name ||
				this.redefinitionsOrSubsettings != redefinitionsOrSubsettings ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(annotation, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon);
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
	
	internal class FieldModifierGreen : MetaGreenNode
	{
	    private InternalSyntaxToken fieldModifier;
	
	    public FieldModifierGreen(MetaSyntaxKind kind, InternalSyntaxToken fieldModifier)
	        : base(kind, null, null)
	    {
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
			}
	    }
	
	    public FieldModifierGreen(MetaSyntaxKind kind, InternalSyntaxToken fieldModifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (fieldModifier != null)
			{
				this.AdjustFlagsAndWidth(fieldModifier);
				this.fieldModifier = fieldModifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken FieldModifier { get { return this.fieldModifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.FieldModifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.fieldModifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new FieldModifierGreen(this.Kind, this.fieldModifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new FieldModifierGreen(this.Kind, this.fieldModifier, this.GetDiagnostics(), annotations);
	    }
	
	    public FieldModifierGreen Update(InternalSyntaxToken fieldModifier)
	    {
	        if (this.fieldModifier != fieldModifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.FieldModifier(fieldModifier);
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
	
	internal class RedefinitionsOrSubsettingsGreen : MetaGreenNode
	{
	    private RedefinitionsGreen redefinitions;
	    private SubsettingsGreen subsettings;
	
	    public RedefinitionsOrSubsettingsGreen(MetaSyntaxKind kind, RedefinitionsGreen redefinitions, SubsettingsGreen subsettings)
	        : base(kind, null, null)
	    {
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
	
	    public RedefinitionsOrSubsettingsGreen(MetaSyntaxKind kind, RedefinitionsGreen redefinitions, SubsettingsGreen subsettings, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public RedefinitionsGreen Redefinitions { get { return this.redefinitions; } }
	    public SubsettingsGreen Subsettings { get { return this.subsettings; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.RedefinitionsOrSubsettingsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.redefinitions;
	            case 1: return this.subsettings;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RedefinitionsOrSubsettingsGreen(this.Kind, this.redefinitions, this.subsettings, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RedefinitionsOrSubsettingsGreen(this.Kind, this.redefinitions, this.subsettings, this.GetDiagnostics(), annotations);
	    }
	
	    public RedefinitionsOrSubsettingsGreen Update(RedefinitionsGreen redefinitions)
	    {
	        if (this.redefinitions != redefinitions)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings(redefinitions);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings(subsettings);
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
	
	internal class RedefinitionsGreen : MetaGreenNode
	{
	    private InternalSyntaxToken kRedefines;
	    private NameUseListGreen nameUseList;
	
	    public RedefinitionsGreen(MetaSyntaxKind kind, InternalSyntaxToken kRedefines, NameUseListGreen nameUseList)
	        : base(kind, null, null)
	    {
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
	
	    public RedefinitionsGreen(MetaSyntaxKind kind, InternalSyntaxToken kRedefines, NameUseListGreen nameUseList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken KRedefines { get { return this.kRedefines; } }
	    public NameUseListGreen NameUseList { get { return this.nameUseList; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.RedefinitionsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kRedefines;
	            case 1: return this.nameUseList;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new RedefinitionsGreen(this.Kind, this.kRedefines, this.nameUseList, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new RedefinitionsGreen(this.Kind, this.kRedefines, this.nameUseList, this.GetDiagnostics(), annotations);
	    }
	
	    public RedefinitionsGreen Update(InternalSyntaxToken kRedefines, NameUseListGreen nameUseList)
	    {
	        if (this.kRedefines != kRedefines ||
				this.nameUseList != nameUseList)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Redefinitions(kRedefines, nameUseList);
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
	
	internal class SubsettingsGreen : MetaGreenNode
	{
	    private InternalSyntaxToken kSubsets;
	    private NameUseListGreen nameUseList;
	
	    public SubsettingsGreen(MetaSyntaxKind kind, InternalSyntaxToken kSubsets, NameUseListGreen nameUseList)
	        : base(kind, null, null)
	    {
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
	
	    public SubsettingsGreen(MetaSyntaxKind kind, InternalSyntaxToken kSubsets, NameUseListGreen nameUseList, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken KSubsets { get { return this.kSubsets; } }
	    public NameUseListGreen NameUseList { get { return this.nameUseList; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.SubsettingsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kSubsets;
	            case 1: return this.nameUseList;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SubsettingsGreen(this.Kind, this.kSubsets, this.nameUseList, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SubsettingsGreen(this.Kind, this.kSubsets, this.nameUseList, this.GetDiagnostics(), annotations);
	    }
	
	    public SubsettingsGreen Update(InternalSyntaxToken kSubsets, NameUseListGreen nameUseList)
	    {
	        if (this.kSubsets != kSubsets ||
				this.nameUseList != nameUseList)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Subsettings(kSubsets, nameUseList);
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
	
	internal class NameUseListGreen : MetaGreenNode
	{
	    private InternalSeparatedSyntaxNodeList qualifier;
	
	    public NameUseListGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList qualifier)
	        : base(kind, null, null)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public NameUseListGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.NameUseListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameUseListGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameUseListGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NameUseListGreen Update(InternalSeparatedSyntaxNodeList qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.NameUseList(qualifier);
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
	
	internal class ConstDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxToken kConst;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	    private InternalSyntaxToken tSemicolon;
	
	    public ConstDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
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
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public ConstDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken KConst { get { return this.kConst; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ConstDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kConst;
	            case 1: return this.typeReference;
	            case 2: return this.name;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ConstDeclarationGreen(this.Kind, this.kConst, this.typeReference, this.name, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ConstDeclarationGreen(this.Kind, this.kConst, this.typeReference, this.name, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public ConstDeclarationGreen Update(InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kConst != kConst ||
				this.typeReference != typeReference ||
				this.name != name ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ConstDeclaration(kConst, typeReference, name, tSemicolon);
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
	
	internal class ReturnTypeGreen : MetaGreenNode
	{
	    private TypeReferenceGreen typeReference;
	    private VoidTypeGreen voidType;
	
	    public ReturnTypeGreen(MetaSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType)
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
	
	    public ReturnTypeGreen(MetaSyntaxKind kind, TypeReferenceGreen typeReference, VoidTypeGreen voidType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.ReturnTypeSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ReturnType(typeReference);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ReturnType(voidType);
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
	
	internal class TypeOfReferenceGreen : MetaGreenNode
	{
	    private TypeReferenceGreen typeReference;
	
	    public TypeOfReferenceGreen(MetaSyntaxKind kind, TypeReferenceGreen typeReference)
	        : base(kind, null, null)
	    {
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
	    public TypeOfReferenceGreen(MetaSyntaxKind kind, TypeReferenceGreen typeReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (typeReference != null)
			{
				this.AdjustFlagsAndWidth(typeReference);
				this.typeReference = typeReference;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.TypeOfReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.typeReference;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeOfReferenceGreen(this.Kind, this.typeReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeOfReferenceGreen(this.Kind, this.typeReference, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeOfReferenceGreen Update(TypeReferenceGreen typeReference)
	    {
	        if (this.typeReference != typeReference)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.TypeOfReference(typeReference);
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
	
	internal class TypeReferenceGreen : MetaGreenNode
	{
	    private CollectionTypeGreen collectionType;
	    private SimpleTypeGreen simpleType;
	
	    public TypeReferenceGreen(MetaSyntaxKind kind, CollectionTypeGreen collectionType, SimpleTypeGreen simpleType)
	        : base(kind, null, null)
	    {
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
	
	    public TypeReferenceGreen(MetaSyntaxKind kind, CollectionTypeGreen collectionType, SimpleTypeGreen simpleType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public CollectionTypeGreen CollectionType { get { return this.collectionType; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.TypeReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.collectionType;
	            case 1: return this.simpleType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeReferenceGreen(this.Kind, this.collectionType, this.simpleType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeReferenceGreen(this.Kind, this.collectionType, this.simpleType, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeReferenceGreen Update(CollectionTypeGreen collectionType)
	    {
	        if (this.collectionType != collectionType)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.TypeReference(collectionType);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.TypeReference(simpleType);
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
	
	internal class SimpleTypeGreen : MetaGreenNode
	{
	    private PrimitiveTypeGreen primitiveType;
	    private ObjectTypeGreen objectType;
	    private NullableTypeGreen nullableType;
	    private QualifierGreen qualifier;
	
	    public SimpleTypeGreen(MetaSyntaxKind kind, PrimitiveTypeGreen primitiveType, ObjectTypeGreen objectType, NullableTypeGreen nullableType, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
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
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public SimpleTypeGreen(MetaSyntaxKind kind, PrimitiveTypeGreen primitiveType, ObjectTypeGreen objectType, NullableTypeGreen nullableType, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	    public ObjectTypeGreen ObjectType { get { return this.objectType; } }
	    public NullableTypeGreen NullableType { get { return this.nullableType; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.SimpleTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            case 1: return this.objectType;
	            case 2: return this.nullableType;
	            case 3: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SimpleTypeGreen(this.Kind, this.primitiveType, this.objectType, this.nullableType, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SimpleTypeGreen(this.Kind, this.primitiveType, this.objectType, this.nullableType, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public SimpleTypeGreen Update(PrimitiveTypeGreen primitiveType)
	    {
	        if (this.primitiveType != primitiveType)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.SimpleType(primitiveType);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.SimpleType(objectType);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.SimpleType(nullableType);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.SimpleType(qualifier);
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
	
	internal class ClassTypeGreen : MetaGreenNode
	{
	    private QualifierGreen qualifier;
	
	    public ClassTypeGreen(MetaSyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public ClassTypeGreen(MetaSyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ClassTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ClassTypeGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ClassTypeGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public ClassTypeGreen Update(QualifierGreen qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ClassType(qualifier);
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
	
	internal class ObjectTypeGreen : MetaGreenNode
	{
	    private InternalSyntaxToken objectType;
	
	    public ObjectTypeGreen(MetaSyntaxKind kind, InternalSyntaxToken objectType)
	        : base(kind, null, null)
	    {
			if (objectType != null)
			{
				this.AdjustFlagsAndWidth(objectType);
				this.objectType = objectType;
			}
	    }
	
	    public ObjectTypeGreen(MetaSyntaxKind kind, InternalSyntaxToken objectType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.ObjectTypeSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ObjectType(objectType);
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
	
	internal class PrimitiveTypeGreen : MetaGreenNode
	{
	    private InternalSyntaxToken primitiveType;
	
	    public PrimitiveTypeGreen(MetaSyntaxKind kind, InternalSyntaxToken primitiveType)
	        : base(kind, null, null)
	    {
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
	    public PrimitiveTypeGreen(MetaSyntaxKind kind, InternalSyntaxToken primitiveType, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (primitiveType != null)
			{
				this.AdjustFlagsAndWidth(primitiveType);
				this.primitiveType = primitiveType;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken PrimitiveType { get { return this.primitiveType; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.PrimitiveTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PrimitiveTypeGreen(this.Kind, this.primitiveType, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PrimitiveTypeGreen(this.Kind, this.primitiveType, this.GetDiagnostics(), annotations);
	    }
	
	    public PrimitiveTypeGreen Update(InternalSyntaxToken primitiveType)
	    {
	        if (this.primitiveType != primitiveType)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.PrimitiveType(primitiveType);
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
	
	internal class VoidTypeGreen : MetaGreenNode
	{
	    private InternalSyntaxToken kVoid;
	
	    public VoidTypeGreen(MetaSyntaxKind kind, InternalSyntaxToken kVoid)
	        : base(kind, null, null)
	    {
			if (kVoid != null)
			{
				this.AdjustFlagsAndWidth(kVoid);
				this.kVoid = kVoid;
			}
	    }
	
	    public VoidTypeGreen(MetaSyntaxKind kind, InternalSyntaxToken kVoid, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.VoidTypeSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.VoidType(kVoid);
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
	
	internal class NullableTypeGreen : MetaGreenNode
	{
	    private PrimitiveTypeGreen primitiveType;
	    private InternalSyntaxToken tQuestion;
	
	    public NullableTypeGreen(MetaSyntaxKind kind, PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion)
	        : base(kind, null, null)
	    {
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
	
	    public NullableTypeGreen(MetaSyntaxKind kind, PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 2; } }
	
	    public PrimitiveTypeGreen PrimitiveType { get { return this.primitiveType; } }
	    public InternalSyntaxToken TQuestion { get { return this.tQuestion; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.NullableTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.primitiveType;
	            case 1: return this.tQuestion;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NullableTypeGreen(this.Kind, this.primitiveType, this.tQuestion, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NullableTypeGreen(this.Kind, this.primitiveType, this.tQuestion, this.GetDiagnostics(), annotations);
	    }
	
	    public NullableTypeGreen Update(PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion)
	    {
	        if (this.primitiveType != primitiveType ||
				this.tQuestion != tQuestion)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.NullableType(primitiveType, tQuestion);
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
	
	internal class CollectionTypeGreen : MetaGreenNode
	{
	    private CollectionKindGreen collectionKind;
	    private InternalSyntaxToken tLessThan;
	    private SimpleTypeGreen simpleType;
	    private InternalSyntaxToken tGreaterThan;
	
	    public CollectionTypeGreen(MetaSyntaxKind kind, CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan)
	        : base(kind, null, null)
	    {
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
	
	    public CollectionTypeGreen(MetaSyntaxKind kind, CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 4; } }
	
	    public CollectionKindGreen CollectionKind { get { return this.collectionKind; } }
	    public InternalSyntaxToken TLessThan { get { return this.tLessThan; } }
	    public SimpleTypeGreen SimpleType { get { return this.simpleType; } }
	    public InternalSyntaxToken TGreaterThan { get { return this.tGreaterThan; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.CollectionTypeSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CollectionTypeGreen(this.Kind, this.collectionKind, this.tLessThan, this.simpleType, this.tGreaterThan, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CollectionTypeGreen(this.Kind, this.collectionKind, this.tLessThan, this.simpleType, this.tGreaterThan, this.GetDiagnostics(), annotations);
	    }
	
	    public CollectionTypeGreen Update(CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan)
	    {
	        if (this.collectionKind != collectionKind ||
				this.tLessThan != tLessThan ||
				this.simpleType != simpleType ||
				this.tGreaterThan != tGreaterThan)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
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
	
	internal class CollectionKindGreen : MetaGreenNode
	{
	    private InternalSyntaxToken collectionKind;
	
	    public CollectionKindGreen(MetaSyntaxKind kind, InternalSyntaxToken collectionKind)
	        : base(kind, null, null)
	    {
			if (collectionKind != null)
			{
				this.AdjustFlagsAndWidth(collectionKind);
				this.collectionKind = collectionKind;
			}
	    }
	
	    public CollectionKindGreen(MetaSyntaxKind kind, InternalSyntaxToken collectionKind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (collectionKind != null)
			{
				this.AdjustFlagsAndWidth(collectionKind);
				this.collectionKind = collectionKind;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken CollectionKind { get { return this.collectionKind; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.CollectionKindSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.collectionKind;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CollectionKindGreen(this.Kind, this.collectionKind, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CollectionKindGreen(this.Kind, this.collectionKind, this.GetDiagnostics(), annotations);
	    }
	
	    public CollectionKindGreen Update(InternalSyntaxToken collectionKind)
	    {
	        if (this.collectionKind != collectionKind)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.CollectionKind(collectionKind);
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
	
	internal class OperationDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private InternalSyntaxToken kStatic;
	    private ReturnTypeGreen returnType;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenParen;
	    private ParameterListGreen parameterList;
	    private InternalSyntaxToken tCloseParen;
	    private InternalSyntaxToken tSemicolon;
	
	    public OperationDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kStatic, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (kStatic != null)
			{
				this.AdjustFlagsAndWidth(kStatic);
				this.kStatic = kStatic;
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
	
	    public OperationDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kStatic, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
			}
			if (kStatic != null)
			{
				this.AdjustFlagsAndWidth(kStatic);
				this.kStatic = kStatic;
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
	
		public override int SlotCount { get { return 8; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public InternalSyntaxToken KStatic { get { return this.kStatic; } }
	    public ReturnTypeGreen ReturnType { get { return this.returnType; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ParameterListGreen ParameterList { get { return this.parameterList; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.OperationDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kStatic;
	            case 2: return this.returnType;
	            case 3: return this.name;
	            case 4: return this.tOpenParen;
	            case 5: return this.parameterList;
	            case 6: return this.tCloseParen;
	            case 7: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.annotation, this.kStatic, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new OperationDeclarationGreen(this.Kind, this.annotation, this.kStatic, this.returnType, this.name, this.tOpenParen, this.parameterList, this.tCloseParen, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public OperationDeclarationGreen Update(InternalSyntaxNodeList annotation, InternalSyntaxToken kStatic, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon)
	    {
	        if (this.annotation != annotation ||
				this.kStatic != kStatic ||
				this.returnType != returnType ||
				this.name != name ||
				this.tOpenParen != tOpenParen ||
				this.parameterList != parameterList ||
				this.tCloseParen != tCloseParen ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(annotation, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
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
	
	internal class ParameterListGreen : MetaGreenNode
	{
	    private InternalSeparatedSyntaxNodeList parameter;
	
	    public ParameterListGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList parameter)
	        : base(kind, null, null)
	    {
			if (parameter != null)
			{
				this.AdjustFlagsAndWidth(parameter);
				this.parameter = parameter;
			}
	    }
	
	    public ParameterListGreen(MetaSyntaxKind kind, InternalSeparatedSyntaxNodeList parameter, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.ParameterListSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ParameterList(parameter);
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
	
	internal class ParameterGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private TypeReferenceGreen typeReference;
	    private NameGreen name;
	
	    public ParameterGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, TypeReferenceGreen typeReference, NameGreen name)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public ParameterGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, TypeReferenceGreen typeReference, NameGreen name, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public TypeReferenceGreen TypeReference { get { return this.typeReference; } }
	    public NameGreen Name { get { return this.name; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.ParameterSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.typeReference;
	            case 2: return this.name;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParameterGreen(this.Kind, this.annotation, this.typeReference, this.name, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParameterGreen(this.Kind, this.annotation, this.typeReference, this.name, this.GetDiagnostics(), annotations);
	    }
	
	    public ParameterGreen Update(InternalSyntaxNodeList annotation, TypeReferenceGreen typeReference, NameGreen name)
	    {
	        if (this.annotation != annotation ||
				this.typeReference != typeReference ||
				this.name != name)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Parameter(annotation, typeReference, name);
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
	
	internal class AssociationDeclarationGreen : MetaGreenNode
	{
	    private InternalSyntaxNodeList annotation;
	    private InternalSyntaxToken kAssociation;
	    private QualifierGreen source;
	    private InternalSyntaxToken kWith;
	    private QualifierGreen target;
	    private InternalSyntaxToken tSemicolon;
	
	    public AssociationDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
	    public AssociationDeclarationGreen(MetaSyntaxKind kind, InternalSyntaxNodeList annotation, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (annotation != null)
			{
				this.AdjustFlagsAndWidth(annotation);
				this.annotation = annotation;
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
	
		public override int SlotCount { get { return 6; } }
	
	    public InternalSyntaxNodeList Annotation { get { return this.annotation; } }
	    public InternalSyntaxToken KAssociation { get { return this.kAssociation; } }
	    public QualifierGreen Source { get { return this.source; } }
	    public InternalSyntaxToken KWith { get { return this.kWith; } }
	    public QualifierGreen Target { get { return this.target; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.AssociationDeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.annotation;
	            case 1: return this.kAssociation;
	            case 2: return this.source;
	            case 3: return this.kWith;
	            case 4: return this.target;
	            case 5: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssociationDeclarationGreen(this.Kind, this.annotation, this.kAssociation, this.source, this.kWith, this.target, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssociationDeclarationGreen(this.Kind, this.annotation, this.kAssociation, this.source, this.kWith, this.target, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public AssociationDeclarationGreen Update(InternalSyntaxNodeList annotation, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon)
	    {
	        if (this.annotation != annotation ||
				this.kAssociation != kAssociation ||
				this.source != source ||
				this.kWith != kWith ||
				this.target != target ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.AssociationDeclaration(annotation, kAssociation, source, kWith, target, tSemicolon);
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
	
	internal class IdentifierGreen : MetaGreenNode
	{
	    private InternalSyntaxToken identifier;
	
	    public IdentifierGreen(MetaSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public IdentifierGreen(MetaSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.IdentifierSyntax(this, parent, position);
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
	        return new IdentifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(InternalSyntaxToken identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Identifier(identifier);
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
	
	internal class LiteralGreen : MetaGreenNode
	{
	    private NullLiteralGreen nullLiteral;
	    private BooleanLiteralGreen booleanLiteral;
	    private IntegerLiteralGreen integerLiteral;
	    private DecimalLiteralGreen decimalLiteral;
	    private ScientificLiteralGreen scientificLiteral;
	    private StringLiteralGreen stringLiteral;
	
	    public LiteralGreen(MetaSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral)
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
	
	    public LiteralGreen(MetaSyntaxKind kind, NullLiteralGreen nullLiteral, BooleanLiteralGreen booleanLiteral, IntegerLiteralGreen integerLiteral, DecimalLiteralGreen decimalLiteral, ScientificLiteralGreen scientificLiteral, StringLiteralGreen stringLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.LiteralSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Literal(nullLiteral);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Literal(booleanLiteral);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Literal(integerLiteral);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Literal(decimalLiteral);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Literal(scientificLiteral);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.Literal(stringLiteral);
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
	
	internal class NullLiteralGreen : MetaGreenNode
	{
	    private InternalSyntaxToken kNull;
	
	    public NullLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken kNull)
	        : base(kind, null, null)
	    {
			if (kNull != null)
			{
				this.AdjustFlagsAndWidth(kNull);
				this.kNull = kNull;
			}
	    }
	
	    public NullLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken kNull, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.NullLiteralSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.NullLiteral(kNull);
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
	
	internal class BooleanLiteralGreen : MetaGreenNode
	{
	    private InternalSyntaxToken booleanLiteral;
	
	    public BooleanLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken booleanLiteral)
	        : base(kind, null, null)
	    {
			if (booleanLiteral != null)
			{
				this.AdjustFlagsAndWidth(booleanLiteral);
				this.booleanLiteral = booleanLiteral;
			}
	    }
	
	    public BooleanLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken booleanLiteral, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.BooleanLiteralSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.BooleanLiteral(booleanLiteral);
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
	
	internal class IntegerLiteralGreen : MetaGreenNode
	{
	    private InternalSyntaxToken lInteger;
	
	    public IntegerLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lInteger)
	        : base(kind, null, null)
	    {
			if (lInteger != null)
			{
				this.AdjustFlagsAndWidth(lInteger);
				this.lInteger = lInteger;
			}
	    }
	
	    public IntegerLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lInteger, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.IntegerLiteralSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(lInteger);
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
	
	internal class DecimalLiteralGreen : MetaGreenNode
	{
	    private InternalSyntaxToken lDecimal;
	
	    public DecimalLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lDecimal)
	        : base(kind, null, null)
	    {
			if (lDecimal != null)
			{
				this.AdjustFlagsAndWidth(lDecimal);
				this.lDecimal = lDecimal;
			}
	    }
	
	    public DecimalLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lDecimal, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.DecimalLiteralSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(lDecimal);
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
	
	internal class ScientificLiteralGreen : MetaGreenNode
	{
	    private InternalSyntaxToken lScientific;
	
	    public ScientificLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lScientific)
	        : base(kind, null, null)
	    {
			if (lScientific != null)
			{
				this.AdjustFlagsAndWidth(lScientific);
				this.lScientific = lScientific;
			}
	    }
	
	    public ScientificLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lScientific, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        return new global::MetaDslx.Languages.Meta.Syntax.ScientificLiteralSyntax(this, parent, position);
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
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(lScientific);
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
	
	internal class StringLiteralGreen : MetaGreenNode
	{
	    private InternalSyntaxToken lRegularString;
	
	    public StringLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lRegularString)
	        : base(kind, null, null)
	    {
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
	    public StringLiteralGreen(MetaSyntaxKind kind, InternalSyntaxToken lRegularString, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (lRegularString != null)
			{
				this.AdjustFlagsAndWidth(lRegularString);
				this.lRegularString = lRegularString;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken LRegularString { get { return this.lRegularString; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Meta.Syntax.StringLiteralSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lRegularString;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringLiteralGreen(this.Kind, this.lRegularString, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringLiteralGreen(this.Kind, this.lRegularString, this.GetDiagnostics(), annotations);
	    }
	
	    public StringLiteralGreen Update(InternalSyntaxToken lRegularString)
	    {
	        if (this.lRegularString != lRegularString)
	        {
	            GreenNode newNode = MetaLanguage.Instance.InternalSyntaxFactory.StringLiteral(lRegularString);
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

	internal class MetaGreenFactory : InternalSyntaxFactory
	{
	    internal static readonly MetaGreenFactory Instance = new MetaGreenFactory();
	
		public new MetaLanguage Language
		{
			get { return MetaLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
		public MetaGreenTrivia Trivia(MetaSyntaxKind kind, string text)
		{
		    return new MetaGreenTrivia(kind, text, null, null);
		}
	
		public override InternalSyntaxTrivia Trivia(int kind, string text)
		{
		    return new MetaGreenTrivia((MetaSyntaxKind)kind, text, null, null);
		}
	
		public MetaGreenToken MissingToken(MetaSyntaxKind kind)
		{
		    return MetaGreenToken.CreateMissing(kind, null, null);
		}
	
		public override InternalSyntaxToken MissingToken(int kind)
		{
		    return MetaGreenToken.CreateMissing((MetaSyntaxKind)kind, null, null);
		}
	
		public MetaGreenToken MissingToken(GreenNode leading, MetaSyntaxKind kind, GreenNode trailing)
		{
		    return MetaGreenToken.CreateMissing(kind, leading, trailing);
		}
	
		public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
		{
		    return MetaGreenToken.CreateMissing((MetaSyntaxKind)kind, leading, trailing);
		}
	
		public MetaGreenToken Token(MetaSyntaxKind kind)
		{
		    return MetaGreenToken.Create(kind);
		}
	
		public override InternalSyntaxToken Token(int kind)
		{
		    return MetaGreenToken.Create((MetaSyntaxKind)kind);
		}
	
	    public MetaGreenToken Token(GreenNode leading, MetaSyntaxKind kind, GreenNode trailing)
		{
		    return MetaGreenToken.Create(kind, leading, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
		{
		    return MetaGreenToken.Create((MetaSyntaxKind)kind, leading, trailing);
		}
	
	    public MetaGreenToken Token(GreenNode leading, MetaSyntaxKind kind, string text, GreenNode trailing)
		{
		    Debug.Assert(MetaLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = MetaLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= MetaGreenToken.FirstTokenWithWellKnownText && kind <= MetaGreenToken.LastTokenWithWellKnownText && text == defaultText
		        ? this.Token(leading, kind, trailing)
		        : MetaGreenToken.WithText(kind, leading, text, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
	    {
	        return this.Token(leading, (MetaSyntaxKind)kind, text, trailing);
	    }
	
	    public MetaGreenToken Token(GreenNode leading, MetaSyntaxKind kind, string text, string valueText, GreenNode trailing)
		{
		    Debug.Assert(MetaLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = MetaLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= MetaGreenToken.FirstTokenWithWellKnownText && kind <= MetaGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(valueText)
		        ? this.Token(leading, kind, trailing)
		        : MetaGreenToken.WithValue(kind, leading, text, valueText, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
	    {
	        return this.Token(leading, (MetaSyntaxKind)kind, text, valueText, trailing);
	    }
	
	    public MetaGreenToken Token(GreenNode leading, MetaSyntaxKind kind, string text, object value, GreenNode trailing)
		{
		    Debug.Assert(MetaLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = MetaLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= MetaGreenToken.FirstTokenWithWellKnownText && kind <= MetaGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
		        ? this.Token(leading, kind, trailing)
		        : MetaGreenToken.WithValue(kind, leading, text, value, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
	    {
	        return this.Token(leading, (MetaSyntaxKind)kind, text, value, trailing);
	    }
	
	    public MetaGreenToken BadToken(GreenNode leading, string text, GreenNode trailing)
		{
		    return MetaGreenToken.WithText(MetaSyntaxKind.BadToken, leading, text, trailing);
		}
	
	
	    internal MetaGreenToken TAsterisk(string text)
	    {
	        return Token(null, MetaSyntaxKind.TAsterisk, text, null);
	    }
	
	    internal MetaGreenToken TAsterisk(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.TAsterisk, text, value, null);
	    }
	
	    internal MetaGreenToken IdentifierNormal(string text)
	    {
	        return Token(null, MetaSyntaxKind.IdentifierNormal, text, null);
	    }
	
	    internal MetaGreenToken IdentifierNormal(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.IdentifierNormal, text, value, null);
	    }
	
	    internal MetaGreenToken IdentifierVerbatim(string text)
	    {
	        return Token(null, MetaSyntaxKind.IdentifierVerbatim, text, null);
	    }
	
	    internal MetaGreenToken IdentifierVerbatim(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.IdentifierVerbatim, text, value, null);
	    }
	
	    internal MetaGreenToken LInteger(string text)
	    {
	        return Token(null, MetaSyntaxKind.LInteger, text, null);
	    }
	
	    internal MetaGreenToken LInteger(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal MetaGreenToken LDecimal(string text)
	    {
	        return Token(null, MetaSyntaxKind.LDecimal, text, null);
	    }
	
	    internal MetaGreenToken LDecimal(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal MetaGreenToken LScientific(string text)
	    {
	        return Token(null, MetaSyntaxKind.LScientific, text, null);
	    }
	
	    internal MetaGreenToken LScientific(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal MetaGreenToken LDateTimeOffset(string text)
	    {
	        return Token(null, MetaSyntaxKind.LDateTimeOffset, text, null);
	    }
	
	    internal MetaGreenToken LDateTimeOffset(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LDateTimeOffset, text, value, null);
	    }
	
	    internal MetaGreenToken LDateTime(string text)
	    {
	        return Token(null, MetaSyntaxKind.LDateTime, text, null);
	    }
	
	    internal MetaGreenToken LDateTime(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LDateTime, text, value, null);
	    }
	
	    internal MetaGreenToken LDate(string text)
	    {
	        return Token(null, MetaSyntaxKind.LDate, text, null);
	    }
	
	    internal MetaGreenToken LDate(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LDate, text, value, null);
	    }
	
	    internal MetaGreenToken LTime(string text)
	    {
	        return Token(null, MetaSyntaxKind.LTime, text, null);
	    }
	
	    internal MetaGreenToken LTime(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LTime, text, value, null);
	    }
	
	    internal MetaGreenToken LRegularString(string text)
	    {
	        return Token(null, MetaSyntaxKind.LRegularString, text, null);
	    }
	
	    internal MetaGreenToken LRegularString(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal MetaGreenToken LGuid(string text)
	    {
	        return Token(null, MetaSyntaxKind.LGuid, text, null);
	    }
	
	    internal MetaGreenToken LGuid(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LGuid, text, value, null);
	    }
	
	    internal MetaGreenToken LUtf8Bom(string text)
	    {
	        return Token(null, MetaSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal MetaGreenToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal MetaGreenToken LWhiteSpace(string text)
	    {
	        return Token(null, MetaSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal MetaGreenToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal MetaGreenToken LCrLf(string text)
	    {
	        return Token(null, MetaSyntaxKind.LCrLf, text, null);
	    }
	
	    internal MetaGreenToken LCrLf(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal MetaGreenToken LLineEnd(string text)
	    {
	        return Token(null, MetaSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal MetaGreenToken LLineEnd(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal MetaGreenToken LSingleLineComment(string text)
	    {
	        return Token(null, MetaSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal MetaGreenToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal MetaGreenToken LComment(string text)
	    {
	        return Token(null, MetaSyntaxKind.LComment, text, null);
	    }
	
	    internal MetaGreenToken LComment(string text, object value)
	    {
	        return Token(null, MetaSyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(NamespaceDeclarationGreen namespaceDeclaration, InternalSyntaxToken eof, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
				if (eof == null) throw new ArgumentNullException(nameof(eof));
				if (eof.RawKind != (int)MetaSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Main, namespaceDeclaration, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(MetaSyntaxKind.Main, namespaceDeclaration, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameGreen Name(IdentifierGreen identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(MetaSyntaxKind.Name, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameGreen QualifiedName(QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(MetaSyntaxKind.QualifiedName, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifierGreen Qualifier(InternalSeparatedSyntaxNodeList identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Qualifier, identifier, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(MetaSyntaxKind.Qualifier, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AnnotationGreen Annotation(InternalSyntaxToken tOpenBracket, NameGreen name, InternalSyntaxToken tCloseBracket, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
				if (tOpenBracket.RawKind != (int)MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
				if (tCloseBracket.RawKind != (int)MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Annotation, tOpenBracket, name, tCloseBracket, out hash);
			if (cached != null) return (AnnotationGreen)cached;
			var result = new AnnotationGreen(MetaSyntaxKind.Annotation, tOpenBracket, name, tCloseBracket);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceDeclarationGreen NamespaceDeclaration(InternalSyntaxNodeList annotation, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
				if (kNamespace.RawKind != (int)MetaSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
			}
	#endif
	        return new NamespaceDeclarationGreen(MetaSyntaxKind.NamespaceDeclaration, annotation, kNamespace, qualifiedName, namespaceBody);
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, MetamodelDeclarationGreen metamodelDeclaration, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)MetaSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (metamodelDeclaration == null) throw new ArgumentNullException(nameof(metamodelDeclaration));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)MetaSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
	        return new NamespaceBodyGreen(MetaSyntaxKind.NamespaceBody, tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
	    }
	
		public MetamodelDeclarationGreen MetamodelDeclaration(InternalSyntaxNodeList annotation, InternalSyntaxToken kMetamodel, NameGreen name, InternalSyntaxToken tOpenParen, MetamodelPropertyListGreen metamodelPropertyList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kMetamodel == null) throw new ArgumentNullException(nameof(kMetamodel));
				if (kMetamodel.RawKind != (int)MetaSyntaxKind.KMetamodel) throw new ArgumentException(nameof(kMetamodel));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
				if (tOpenParen.RawKind != (int)MetaSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
				if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
				if (tCloseParen.RawKind != (int)MetaSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new MetamodelDeclarationGreen(MetaSyntaxKind.MetamodelDeclaration, annotation, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
	    }
	
		public MetamodelPropertyListGreen MetamodelPropertyList(InternalSeparatedSyntaxNodeList metamodelProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.MetamodelPropertyList, metamodelProperty, out hash);
			if (cached != null) return (MetamodelPropertyListGreen)cached;
			var result = new MetamodelPropertyListGreen(MetaSyntaxKind.MetamodelPropertyList, metamodelProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MetamodelPropertyGreen MetamodelProperty(MetamodelUriPropertyGreen metamodelUriProperty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (metamodelUriProperty == null) throw new ArgumentNullException(nameof(metamodelUriProperty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.MetamodelProperty, metamodelUriProperty, out hash);
			if (cached != null) return (MetamodelPropertyGreen)cached;
			var result = new MetamodelPropertyGreen(MetaSyntaxKind.MetamodelProperty, metamodelUriProperty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MetamodelUriPropertyGreen MetamodelUriProperty(InternalSyntaxToken iUri, InternalSyntaxToken tAssign, StringLiteralGreen stringLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (iUri == null) throw new ArgumentNullException(nameof(iUri));
				if (iUri.RawKind != (int)MetaSyntaxKind.IUri) throw new ArgumentException(nameof(iUri));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.MetamodelUriProperty, iUri, tAssign, stringLiteral, out hash);
			if (cached != null) return (MetamodelUriPropertyGreen)cached;
			var result = new MetamodelUriPropertyGreen(MetaSyntaxKind.MetamodelUriProperty, iUri, tAssign, stringLiteral);
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
			return new DeclarationGreen(MetaSyntaxKind.Declaration, enumDeclaration, null, null, null);
	    }
	
		public DeclarationGreen Declaration(ClassDeclarationGreen classDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
			}
	#endif
			return new DeclarationGreen(MetaSyntaxKind.Declaration, null, classDeclaration, null, null);
	    }
	
		public DeclarationGreen Declaration(AssociationDeclarationGreen associationDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (associationDeclaration == null) throw new ArgumentNullException(nameof(associationDeclaration));
			}
	#endif
			return new DeclarationGreen(MetaSyntaxKind.Declaration, null, null, associationDeclaration, null);
	    }
	
		public DeclarationGreen Declaration(ConstDeclarationGreen constDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (constDeclaration == null) throw new ArgumentNullException(nameof(constDeclaration));
			}
	#endif
			return new DeclarationGreen(MetaSyntaxKind.Declaration, null, null, null, constDeclaration);
	    }
	
		public EnumDeclarationGreen EnumDeclaration(InternalSyntaxNodeList annotation, InternalSyntaxToken kEnum, NameGreen name, EnumBodyGreen enumBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
				if (kEnum.RawKind != (int)MetaSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
			}
	#endif
	        return new EnumDeclarationGreen(MetaSyntaxKind.EnumDeclaration, annotation, kEnum, name, enumBody);
	    }
	
		public EnumBodyGreen EnumBody(InternalSyntaxToken tOpenBrace, EnumValuesGreen enumValues, InternalSyntaxToken tSemicolon, InternalSyntaxNodeList enumMemberDeclaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)MetaSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (enumValues == null) throw new ArgumentNullException(nameof(enumValues));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)MetaSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
	        return new EnumBodyGreen(MetaSyntaxKind.EnumBody, tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
	    }
	
		public EnumValuesGreen EnumValues(InternalSeparatedSyntaxNodeList enumValue, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.EnumValues, enumValue, out hash);
			if (cached != null) return (EnumValuesGreen)cached;
			var result = new EnumValuesGreen(MetaSyntaxKind.EnumValues, enumValue);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumValueGreen EnumValue(InternalSyntaxNodeList annotation, NameGreen name, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (name == null) throw new ArgumentNullException(nameof(name));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.EnumValue, annotation, name, out hash);
			if (cached != null) return (EnumValueGreen)cached;
			var result = new EnumValueGreen(MetaSyntaxKind.EnumValue, annotation, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EnumMemberDeclarationGreen EnumMemberDeclaration(OperationDeclarationGreen operationDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.EnumMemberDeclaration, operationDeclaration, out hash);
			if (cached != null) return (EnumMemberDeclarationGreen)cached;
			var result = new EnumMemberDeclarationGreen(MetaSyntaxKind.EnumMemberDeclaration, operationDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassDeclarationGreen ClassDeclaration(InternalSyntaxNodeList annotation, InternalSyntaxToken kAbstract, InternalSyntaxToken kClass, NameGreen name, InternalSyntaxToken tColon, ClassAncestorsGreen classAncestors, ClassBodyGreen classBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kAbstract != null && kAbstract.RawKind != (int)MetaSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
				if (kClass == null) throw new ArgumentNullException(nameof(kClass));
				if (kClass.RawKind != (int)MetaSyntaxKind.KClass) throw new ArgumentException(nameof(kClass));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (classAncestors == null) throw new ArgumentNullException(nameof(classAncestors));
				if (classBody == null) throw new ArgumentNullException(nameof(classBody));
			}
	#endif
	        return new ClassDeclarationGreen(MetaSyntaxKind.ClassDeclaration, annotation, kAbstract, kClass, name, tColon, classAncestors, classBody);
	    }
	
		public ClassBodyGreen ClassBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList classMemberDeclaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)MetaSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)MetaSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ClassBody, tOpenBrace, classMemberDeclaration, tCloseBrace, out hash);
			if (cached != null) return (ClassBodyGreen)cached;
			var result = new ClassBodyGreen(MetaSyntaxKind.ClassBody, tOpenBrace, classMemberDeclaration, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassAncestorsGreen ClassAncestors(InternalSeparatedSyntaxNodeList classAncestor, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ClassAncestors, classAncestor, out hash);
			if (cached != null) return (ClassAncestorsGreen)cached;
			var result = new ClassAncestorsGreen(MetaSyntaxKind.ClassAncestors, classAncestor);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassAncestorGreen ClassAncestor(QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ClassAncestor, qualifier, out hash);
			if (cached != null) return (ClassAncestorGreen)cached;
			var result = new ClassAncestorGreen(MetaSyntaxKind.ClassAncestor, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassMemberDeclarationGreen ClassMemberDeclaration(FieldDeclarationGreen fieldDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (fieldDeclaration == null) throw new ArgumentNullException(nameof(fieldDeclaration));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ClassMemberDeclaration, fieldDeclaration, out hash);
			if (cached != null) return (ClassMemberDeclarationGreen)cached;
			var result = new ClassMemberDeclarationGreen(MetaSyntaxKind.ClassMemberDeclaration, fieldDeclaration, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ClassMemberDeclarationGreen ClassMemberDeclaration(OperationDeclarationGreen operationDeclaration, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ClassMemberDeclaration, operationDeclaration, out hash);
			if (cached != null) return (ClassMemberDeclarationGreen)cached;
			var result = new ClassMemberDeclarationGreen(MetaSyntaxKind.ClassMemberDeclaration, null, operationDeclaration);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public FieldDeclarationGreen FieldDeclaration(InternalSyntaxNodeList annotation, FieldModifierGreen fieldModifier, TypeReferenceGreen typeReference, NameGreen name, RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new FieldDeclarationGreen(MetaSyntaxKind.FieldDeclaration, annotation, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon);
	    }
	
		public FieldModifierGreen FieldModifier(InternalSyntaxToken fieldModifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (fieldModifier == null) throw new ArgumentNullException(nameof(fieldModifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.FieldModifier, fieldModifier, out hash);
			if (cached != null) return (FieldModifierGreen)cached;
			var result = new FieldModifierGreen(MetaSyntaxKind.FieldModifier, fieldModifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RedefinitionsOrSubsettingsGreen RedefinitionsOrSubsettings(RedefinitionsGreen redefinitions, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (redefinitions == null) throw new ArgumentNullException(nameof(redefinitions));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.RedefinitionsOrSubsettings, redefinitions, out hash);
			if (cached != null) return (RedefinitionsOrSubsettingsGreen)cached;
			var result = new RedefinitionsOrSubsettingsGreen(MetaSyntaxKind.RedefinitionsOrSubsettings, redefinitions, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RedefinitionsOrSubsettingsGreen RedefinitionsOrSubsettings(SubsettingsGreen subsettings, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (subsettings == null) throw new ArgumentNullException(nameof(subsettings));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.RedefinitionsOrSubsettings, subsettings, out hash);
			if (cached != null) return (RedefinitionsOrSubsettingsGreen)cached;
			var result = new RedefinitionsOrSubsettingsGreen(MetaSyntaxKind.RedefinitionsOrSubsettings, null, subsettings);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public RedefinitionsGreen Redefinitions(InternalSyntaxToken kRedefines, NameUseListGreen nameUseList, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kRedefines == null) throw new ArgumentNullException(nameof(kRedefines));
				if (kRedefines.RawKind != (int)MetaSyntaxKind.KRedefines) throw new ArgumentException(nameof(kRedefines));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Redefinitions, kRedefines, nameUseList, out hash);
			if (cached != null) return (RedefinitionsGreen)cached;
			var result = new RedefinitionsGreen(MetaSyntaxKind.Redefinitions, kRedefines, nameUseList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SubsettingsGreen Subsettings(InternalSyntaxToken kSubsets, NameUseListGreen nameUseList, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kSubsets == null) throw new ArgumentNullException(nameof(kSubsets));
				if (kSubsets.RawKind != (int)MetaSyntaxKind.KSubsets) throw new ArgumentException(nameof(kSubsets));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Subsettings, kSubsets, nameUseList, out hash);
			if (cached != null) return (SubsettingsGreen)cached;
			var result = new SubsettingsGreen(MetaSyntaxKind.Subsettings, kSubsets, nameUseList);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameUseListGreen NameUseList(InternalSeparatedSyntaxNodeList qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.NameUseList, qualifier, out hash);
			if (cached != null) return (NameUseListGreen)cached;
			var result = new NameUseListGreen(MetaSyntaxKind.NameUseList, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ConstDeclarationGreen ConstDeclaration(InternalSyntaxToken kConst, TypeReferenceGreen typeReference, NameGreen name, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kConst == null) throw new ArgumentNullException(nameof(kConst));
				if (kConst.RawKind != (int)MetaSyntaxKind.KConst) throw new ArgumentException(nameof(kConst));
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new ConstDeclarationGreen(MetaSyntaxKind.ConstDeclaration, kConst, typeReference, name, tSemicolon);
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
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ReturnType, typeReference, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(MetaSyntaxKind.ReturnType, typeReference, null);
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
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ReturnType, voidType, out hash);
			if (cached != null) return (ReturnTypeGreen)cached;
			var result = new ReturnTypeGreen(MetaSyntaxKind.ReturnType, null, voidType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeOfReferenceGreen TypeOfReference(TypeReferenceGreen typeReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.TypeOfReference, typeReference, out hash);
			if (cached != null) return (TypeOfReferenceGreen)cached;
			var result = new TypeOfReferenceGreen(MetaSyntaxKind.TypeOfReference, typeReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(CollectionTypeGreen collectionType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (collectionType == null) throw new ArgumentNullException(nameof(collectionType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.TypeReference, collectionType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(MetaSyntaxKind.TypeReference, collectionType, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TypeReferenceGreen TypeReference(SimpleTypeGreen simpleType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.TypeReference, simpleType, out hash);
			if (cached != null) return (TypeReferenceGreen)cached;
			var result = new TypeReferenceGreen(MetaSyntaxKind.TypeReference, null, simpleType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SimpleTypeGreen SimpleType(PrimitiveTypeGreen primitiveType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
			}
	#endif
			return new SimpleTypeGreen(MetaSyntaxKind.SimpleType, primitiveType, null, null, null);
	    }
	
		public SimpleTypeGreen SimpleType(ObjectTypeGreen objectType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (objectType == null) throw new ArgumentNullException(nameof(objectType));
			}
	#endif
			return new SimpleTypeGreen(MetaSyntaxKind.SimpleType, null, objectType, null, null);
	    }
	
		public SimpleTypeGreen SimpleType(NullableTypeGreen nullableType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
			}
	#endif
			return new SimpleTypeGreen(MetaSyntaxKind.SimpleType, null, null, nullableType, null);
	    }
	
		public SimpleTypeGreen SimpleType(QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			return new SimpleTypeGreen(MetaSyntaxKind.SimpleType, null, null, null, qualifier);
	    }
	
		public ClassTypeGreen ClassType(QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ClassType, qualifier, out hash);
			if (cached != null) return (ClassTypeGreen)cached;
			var result = new ClassTypeGreen(MetaSyntaxKind.ClassType, qualifier);
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
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ObjectType, objectType, out hash);
			if (cached != null) return (ObjectTypeGreen)cached;
			var result = new ObjectTypeGreen(MetaSyntaxKind.ObjectType, objectType);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PrimitiveTypeGreen PrimitiveType(InternalSyntaxToken primitiveType, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.PrimitiveType, primitiveType, out hash);
			if (cached != null) return (PrimitiveTypeGreen)cached;
			var result = new PrimitiveTypeGreen(MetaSyntaxKind.PrimitiveType, primitiveType);
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
				if (kVoid.RawKind != (int)MetaSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.VoidType, kVoid, out hash);
			if (cached != null) return (VoidTypeGreen)cached;
			var result = new VoidTypeGreen(MetaSyntaxKind.VoidType, kVoid);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NullableTypeGreen NullableType(PrimitiveTypeGreen primitiveType, InternalSyntaxToken tQuestion, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
				if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
				if (tQuestion.RawKind != (int)MetaSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.NullableType, primitiveType, tQuestion, out hash);
			if (cached != null) return (NullableTypeGreen)cached;
			var result = new NullableTypeGreen(MetaSyntaxKind.NullableType, primitiveType, tQuestion);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CollectionTypeGreen CollectionType(CollectionKindGreen collectionKind, InternalSyntaxToken tLessThan, SimpleTypeGreen simpleType, InternalSyntaxToken tGreaterThan, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
				if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
				if (tLessThan.RawKind != (int)MetaSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
				if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
				if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
				if (tGreaterThan.RawKind != (int)MetaSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
			}
	#endif
	        return new CollectionTypeGreen(MetaSyntaxKind.CollectionType, collectionKind, tLessThan, simpleType, tGreaterThan);
	    }
	
		public CollectionKindGreen CollectionKind(InternalSyntaxToken collectionKind, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.CollectionKind, collectionKind, out hash);
			if (cached != null) return (CollectionKindGreen)cached;
			var result = new CollectionKindGreen(MetaSyntaxKind.CollectionKind, collectionKind);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public OperationDeclarationGreen OperationDeclaration(InternalSyntaxNodeList annotation, InternalSyntaxToken kStatic, ReturnTypeGreen returnType, NameGreen name, InternalSyntaxToken tOpenParen, ParameterListGreen parameterList, InternalSyntaxToken tCloseParen, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kStatic != null && kStatic.RawKind != (int)MetaSyntaxKind.KStatic) throw new ArgumentException(nameof(kStatic));
				if (returnType == null) throw new ArgumentNullException(nameof(returnType));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
				if (tOpenParen.RawKind != (int)MetaSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
				if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
				if (tCloseParen.RawKind != (int)MetaSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new OperationDeclarationGreen(MetaSyntaxKind.OperationDeclaration, annotation, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	    }
	
		public ParameterListGreen ParameterList(InternalSeparatedSyntaxNodeList parameter, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ParameterList, parameter, out hash);
			if (cached != null) return (ParameterListGreen)cached;
			var result = new ParameterListGreen(MetaSyntaxKind.ParameterList, parameter);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParameterGreen Parameter(InternalSyntaxNodeList annotation, TypeReferenceGreen typeReference, NameGreen name, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
				if (name == null) throw new ArgumentNullException(nameof(name));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Parameter, annotation, typeReference, name, out hash);
			if (cached != null) return (ParameterGreen)cached;
			var result = new ParameterGreen(MetaSyntaxKind.Parameter, annotation, typeReference, name);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssociationDeclarationGreen AssociationDeclaration(InternalSyntaxNodeList annotation, InternalSyntaxToken kAssociation, QualifierGreen source, InternalSyntaxToken kWith, QualifierGreen target, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kAssociation == null) throw new ArgumentNullException(nameof(kAssociation));
				if (kAssociation.RawKind != (int)MetaSyntaxKind.KAssociation) throw new ArgumentException(nameof(kAssociation));
				if (source == null) throw new ArgumentNullException(nameof(source));
				if (kWith == null) throw new ArgumentNullException(nameof(kWith));
				if (kWith.RawKind != (int)MetaSyntaxKind.KWith) throw new ArgumentException(nameof(kWith));
				if (target == null) throw new ArgumentNullException(nameof(target));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new AssociationDeclarationGreen(MetaSyntaxKind.AssociationDeclaration, annotation, kAssociation, source, kWith, target, tSemicolon);
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.Identifier, identifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(MetaSyntaxKind.Identifier, identifier);
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
			return new LiteralGreen(MetaSyntaxKind.Literal, nullLiteral, null, null, null, null, null);
	    }
	
		public LiteralGreen Literal(BooleanLiteralGreen booleanLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
			}
	#endif
			return new LiteralGreen(MetaSyntaxKind.Literal, null, booleanLiteral, null, null, null, null);
	    }
	
		public LiteralGreen Literal(IntegerLiteralGreen integerLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
			}
	#endif
			return new LiteralGreen(MetaSyntaxKind.Literal, null, null, integerLiteral, null, null, null);
	    }
	
		public LiteralGreen Literal(DecimalLiteralGreen decimalLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
			}
	#endif
			return new LiteralGreen(MetaSyntaxKind.Literal, null, null, null, decimalLiteral, null, null);
	    }
	
		public LiteralGreen Literal(ScientificLiteralGreen scientificLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
			}
	#endif
			return new LiteralGreen(MetaSyntaxKind.Literal, null, null, null, null, scientificLiteral, null);
	    }
	
		public LiteralGreen Literal(StringLiteralGreen stringLiteral, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
			}
	#endif
			return new LiteralGreen(MetaSyntaxKind.Literal, null, null, null, null, null, stringLiteral);
	    }
	
		public NullLiteralGreen NullLiteral(InternalSyntaxToken kNull, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kNull == null) throw new ArgumentNullException(nameof(kNull));
				if (kNull.RawKind != (int)MetaSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.NullLiteral, kNull, out hash);
			if (cached != null) return (NullLiteralGreen)cached;
			var result = new NullLiteralGreen(MetaSyntaxKind.NullLiteral, kNull);
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
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.BooleanLiteral, booleanLiteral, out hash);
			if (cached != null) return (BooleanLiteralGreen)cached;
			var result = new BooleanLiteralGreen(MetaSyntaxKind.BooleanLiteral, booleanLiteral);
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
				if (lInteger.RawKind != (int)MetaSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.IntegerLiteral, lInteger, out hash);
			if (cached != null) return (IntegerLiteralGreen)cached;
			var result = new IntegerLiteralGreen(MetaSyntaxKind.IntegerLiteral, lInteger);
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
				if (lDecimal.RawKind != (int)MetaSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.DecimalLiteral, lDecimal, out hash);
			if (cached != null) return (DecimalLiteralGreen)cached;
			var result = new DecimalLiteralGreen(MetaSyntaxKind.DecimalLiteral, lDecimal);
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
				if (lScientific.RawKind != (int)MetaSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.ScientificLiteral, lScientific, out hash);
			if (cached != null) return (ScientificLiteralGreen)cached;
			var result = new ScientificLiteralGreen(MetaSyntaxKind.ScientificLiteral, lScientific);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringLiteralGreen StringLiteral(InternalSyntaxToken lRegularString, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (lRegularString == null) throw new ArgumentNullException(nameof(lRegularString));
				if (lRegularString.RawKind != (int)MetaSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MetaSyntaxKind.StringLiteral, lRegularString, out hash);
			if (cached != null) return (StringLiteralGreen)cached;
			var result = new StringLiteralGreen(MetaSyntaxKind.StringLiteral, lRegularString);
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
				typeof(NameGreen),
				typeof(QualifiedNameGreen),
				typeof(QualifierGreen),
				typeof(AnnotationGreen),
				typeof(NamespaceDeclarationGreen),
				typeof(NamespaceBodyGreen),
				typeof(MetamodelDeclarationGreen),
				typeof(MetamodelPropertyListGreen),
				typeof(MetamodelPropertyGreen),
				typeof(MetamodelUriPropertyGreen),
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
				typeof(FieldModifierGreen),
				typeof(RedefinitionsOrSubsettingsGreen),
				typeof(RedefinitionsGreen),
				typeof(SubsettingsGreen),
				typeof(NameUseListGreen),
				typeof(ConstDeclarationGreen),
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


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

namespace MetaDslx.Languages.Calculator.Syntax.InternalSyntax
{
    internal abstract class CalculatorGreenNode : InternalSyntaxNode
    {
        public CalculatorGreenNode(CalculatorSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, 0, diagnostics, annotations)
        {
        }

        public CalculatorSyntaxKind Kind
        {
            get { return (CalculatorSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return CalculatorLanguage.Instance; }
        }
    }

    internal class CalculatorGreenTrivia : InternalSyntaxTrivia
    {
        public CalculatorGreenTrivia(CalculatorSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        public CalculatorSyntaxKind Kind
        {
            get { return (CalculatorSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return CalculatorLanguage.Instance; }
        }

        public override SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index)
        {
            return new CalculatorSyntaxTrivia(this, parent, position, index);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new CalculatorGreenTrivia(this.Kind, this.Text, diagnostics, this.GetAnnotations());
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new CalculatorGreenTrivia(this.Kind, this.Text, this.GetDiagnostics(), annotations);
        }
    }

	public class CalculatorGreenToken : InternalSyntaxToken
	{
		public CalculatorGreenToken(CalculatorSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
		    : base((int)kind, diagnostics, annotations)
		{
		}
	
	    public CalculatorGreenToken(CalculatorSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base((int)kind, fullWidth, diagnostics, annotations)
	    {
	    }
	
	    public CalculatorSyntaxKind Kind
		{
		    get { return (CalculatorSyntaxKind)base.RawKind; }
		}
	
		public virtual CalculatorSyntaxKind ContextualKind
		{
		    get { return this.Kind; }
		}
	
	    public override string Text
	    {
	        get
	        {
	            return CalculatorLanguage.Instance.SyntaxFacts.GetText(this.Kind);
	        }
	    }
	
	    public override Language Language
	    {
	        get { return CalculatorLanguage.Instance; }
	    }
	
	    public override SyntaxToken CreateRed(SyntaxNode parent, int position, int index)
	    {
	        return new CalculatorSyntaxToken(this, parent, position, index);
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
	        return new CalculatorGreenToken(this.Kind, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CalculatorGreenToken(this.Kind, diagnostics, this.GetAnnotations());
	    }
	
	    internal static CalculatorGreenToken Create(CalculatorSyntaxKind kind)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!CalculatorLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, null, null);
	        }
	
	        return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	    }
	
	    internal static CalculatorGreenToken Create(CalculatorSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!CalculatorLanguage.Instance.SyntaxFacts.IsToken(kind))
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
	            else if (trailing == CalculatorLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == CalculatorLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	        }
	
	        if (leading == CalculatorLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == CalculatorLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	        }
	
	        return new SyntaxTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static CalculatorGreenToken CreateMissing(CalculatorSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static readonly CalculatorSyntaxKind FirstTokenWithWellKnownText = CalculatorSyntaxKind.TSemicolon;
	    internal static readonly CalculatorSyntaxKind LastTokenWithWellKnownText = CalculatorSyntaxKind.KPrint;
	
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly CalculatorGreenToken[] s_tokensWithNoTrivia = new CalculatorGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly CalculatorGreenToken[] s_tokensWithElasticTrivia = new CalculatorGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly CalculatorGreenToken[] s_tokensWithSingleTrailingSpace = new CalculatorGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly CalculatorGreenToken[] s_tokensWithSingleTrailingCRLF = new CalculatorGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	
	    static CalculatorGreenToken()
	    {
	        for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new CalculatorGreenToken(kind, null, null);
	            s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, CalculatorLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, CalculatorLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, null, null);
	            s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, CalculatorLanguage.Instance.InternalSyntaxFactory.Space, null, null);
	            s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, CalculatorLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed, null, null);
	        }
	    }
	
	    internal static IEnumerable<CalculatorGreenToken> GetWellKnownTokens()
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
	
	    internal static CalculatorGreenToken WithText(CalculatorSyntaxKind kind, string text)
	    {
	        return new SyntaxTokenWithText(kind, text, null, null);
	    }
	
	    internal static CalculatorGreenToken WithText(CalculatorSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	
	    internal static CalculatorGreenToken WithText(CalculatorSyntaxKind kind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (valueText == text)
	        {
	            return WithText(kind, leading, text, trailing);
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, valueText, leading, trailing, null, null);
	    }
	
	    internal static CalculatorGreenToken WithValue<T>(CalculatorSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value, null, null);
	    }
	
	    internal static CalculatorGreenToken WithValue<T>(CalculatorSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing, null, null);
	    }
	
	    private class SyntaxTokenWithTrivia : CalculatorGreenToken
	    {
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	
	        internal SyntaxTokenWithTrivia(CalculatorSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal MissingTokenWithTrivia(CalculatorSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	    private class SyntaxTokenWithText : CalculatorGreenToken
	    {
	        protected readonly string TextField;
	
	        internal SyntaxTokenWithText(CalculatorSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxIdentifierExtended(CalculatorSyntaxKind kind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxTokenWithTextAndTrailingTrivia(CalculatorSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            CalculatorSyntaxKind kind,
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
	
	    private class SyntaxTokenWithValue<T> : CalculatorGreenToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	
	        internal SyntaxTokenWithValue(CalculatorSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            CalculatorSyntaxKind kind,
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
	
	internal class MainGreen : CalculatorGreenNode
	{
	    private InternalNodeList statementLine;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(CalculatorSyntaxKind kind, InternalNodeList statementLine, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
			if (statementLine != null)
			{
				this.AdjustFlagsAndWidth(statementLine);
				this.statementLine = statementLine;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
	    public MainGreen(CalculatorSyntaxKind kind, InternalNodeList statementLine, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (statementLine != null)
			{
				this.AdjustFlagsAndWidth(statementLine);
				this.statementLine = statementLine;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalNodeList StatementLine { get { return this.statementLine; } }
	    public InternalSyntaxToken EOF { get { return this.eof; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.MainSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.statementLine;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.statementLine, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.statementLine, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(InternalNodeList statementLine, InternalSyntaxToken eof)
	    {
	        if (this.statementLine != statementLine ||
				this.eof != eof)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Main(statementLine, eof);
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
	
	internal class StatementLineGreen : CalculatorGreenNode
	{
	    private StatementGreen statement;
	    private InternalSyntaxToken tSemicolon;
	
	    public StatementLineGreen(CalculatorSyntaxKind kind, StatementGreen statement, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public StatementLineGreen(CalculatorSyntaxKind kind, StatementGreen statement, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (statement != null)
			{
				this.AdjustFlagsAndWidth(statement);
				this.statement = statement;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public StatementGreen Statement { get { return this.statement; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.StatementLineSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.statement;
	            case 1: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StatementLineGreen(this.Kind, this.statement, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StatementLineGreen(this.Kind, this.statement, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public StatementLineGreen Update(StatementGreen statement, InternalSyntaxToken tSemicolon)
	    {
	        if (this.statement != statement ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.StatementLine(statement, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementLineGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StatementGreen : CalculatorGreenNode
	{
	    private AssignmentGreen assignment;
	    private ExpressionGreen expression;
	
	    public StatementGreen(CalculatorSyntaxKind kind, AssignmentGreen assignment, ExpressionGreen expression)
	        : base(kind, null, null)
	    {
			if (assignment != null)
			{
				this.AdjustFlagsAndWidth(assignment);
				this.assignment = assignment;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public StatementGreen(CalculatorSyntaxKind kind, AssignmentGreen assignment, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (assignment != null)
			{
				this.AdjustFlagsAndWidth(assignment);
				this.assignment = assignment;
			}
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public AssignmentGreen Assignment { get { return this.assignment; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.StatementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.assignment;
	            case 1: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StatementGreen(this.Kind, this.assignment, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StatementGreen(this.Kind, this.assignment, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public StatementGreen Update(AssignmentGreen assignment)
	    {
	        if (this.assignment != assignment)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Statement(assignment);
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
	
	    public StatementGreen Update(ExpressionGreen expression)
	    {
	        if (this.expression != expression)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Statement(expression);
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
	
	internal class AssignmentGreen : CalculatorGreenNode
	{
	    private IdentifierGreen identifier;
	    private InternalSyntaxToken tAssign;
	    private ExpressionGreen expression;
	
	    public AssignmentGreen(CalculatorSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
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
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
	    public AssignmentGreen(CalculatorSyntaxKind kind, IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (expression != null)
			{
				this.AdjustFlagsAndWidth(expression);
				this.expression = expression;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.AssignmentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this.tAssign;
	            case 2: return this.expression;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AssignmentGreen(this.Kind, this.identifier, this.tAssign, this.expression, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AssignmentGreen(this.Kind, this.identifier, this.tAssign, this.expression, this.GetDiagnostics(), annotations);
	    }
	
	    public AssignmentGreen Update(IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression)
	    {
	        if (this.identifier != identifier ||
				this.tAssign != tAssign ||
				this.expression != expression)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Assignment(identifier, tAssign, expression);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignmentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class ExpressionGreen : CalculatorGreenNode
	{
	
	    public ExpressionGreen(CalculatorSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class ParenExpressionGreen : ExpressionGreen
	{
	    private InternalSyntaxToken tOpenParen;
	    private ExpressionGreen expression;
	    private InternalSyntaxToken tCloseParen;
	
	    public ParenExpressionGreen(CalculatorSyntaxKind kind, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	        : base(kind, null, null)
	    {
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
	
	    public ParenExpressionGreen(CalculatorSyntaxKind kind, InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
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
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenParen { get { return this.tOpenParen; } }
	    public ExpressionGreen Expression { get { return this.expression; } }
	    public InternalSyntaxToken TCloseParen { get { return this.tCloseParen; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.ParenExpressionSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenParen;
	            case 1: return this.expression;
	            case 2: return this.tCloseParen;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParenExpressionGreen(this.Kind, this.tOpenParen, this.expression, this.tCloseParen, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParenExpressionGreen(this.Kind, this.tOpenParen, this.expression, this.tCloseParen, this.GetDiagnostics(), annotations);
	    }
	
	    public ParenExpressionGreen Update(InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen)
	    {
	        if (this.tOpenParen != tOpenParen ||
				this.expression != expression ||
				this.tCloseParen != tCloseParen)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.ParenExpression(tOpenParen, expression, tCloseParen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class MulOrDivExpressionGreen : ExpressionGreen
	{
	    private ExpressionGreen left;
	    private InternalSyntaxToken _operator;
	    private ExpressionGreen right;
	
	    public MulOrDivExpressionGreen(CalculatorSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (_operator != null)
			{
				this.AdjustFlagsAndWidth(_operator);
				this._operator = _operator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public MulOrDivExpressionGreen(CalculatorSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (_operator != null)
			{
				this.AdjustFlagsAndWidth(_operator);
				this._operator = _operator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Operator { get { return this._operator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.MulOrDivExpressionSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this._operator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MulOrDivExpressionGreen(this.Kind, this.left, this._operator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MulOrDivExpressionGreen(this.Kind, this.left, this._operator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public MulOrDivExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right)
	    {
	        if (this.left != left ||
				this._operator != _operator ||
				this.right != right)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.MulOrDivExpression(left, _operator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MulOrDivExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class AddOrSubExpressionGreen : ExpressionGreen
	{
	    private ExpressionGreen left;
	    private InternalSyntaxToken _operator;
	    private ExpressionGreen right;
	
	    public AddOrSubExpressionGreen(CalculatorSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right)
	        : base(kind, null, null)
	    {
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (_operator != null)
			{
				this.AdjustFlagsAndWidth(_operator);
				this._operator = _operator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
	    public AddOrSubExpressionGreen(CalculatorSyntaxKind kind, ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (left != null)
			{
				this.AdjustFlagsAndWidth(left);
				this.left = left;
			}
			if (_operator != null)
			{
				this.AdjustFlagsAndWidth(_operator);
				this._operator = _operator;
			}
			if (right != null)
			{
				this.AdjustFlagsAndWidth(right);
				this.right = right;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public ExpressionGreen Left { get { return this.left; } }
	    public InternalSyntaxToken Operator { get { return this._operator; } }
	    public ExpressionGreen Right { get { return this.right; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.AddOrSubExpressionSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.left;
	            case 1: return this._operator;
	            case 2: return this.right;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new AddOrSubExpressionGreen(this.Kind, this.left, this._operator, this.right, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new AddOrSubExpressionGreen(this.Kind, this.left, this._operator, this.right, this.GetDiagnostics(), annotations);
	    }
	
	    public AddOrSubExpressionGreen Update(ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right)
	    {
	        if (this.left != left ||
				this._operator != _operator ||
				this.right != right)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.AddOrSubExpression(left, _operator, right);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AddOrSubExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PrintExpressionGreen : ExpressionGreen
	{
	    private InternalSyntaxToken kPrint;
	    private ArgsGreen args;
	
	    public PrintExpressionGreen(CalculatorSyntaxKind kind, InternalSyntaxToken kPrint, ArgsGreen args)
	        : base(kind, null, null)
	    {
			if (kPrint != null)
			{
				this.AdjustFlagsAndWidth(kPrint);
				this.kPrint = kPrint;
			}
			if (args != null)
			{
				this.AdjustFlagsAndWidth(args);
				this.args = args;
			}
	    }
	
	    public PrintExpressionGreen(CalculatorSyntaxKind kind, InternalSyntaxToken kPrint, ArgsGreen args, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kPrint != null)
			{
				this.AdjustFlagsAndWidth(kPrint);
				this.kPrint = kPrint;
			}
			if (args != null)
			{
				this.AdjustFlagsAndWidth(args);
				this.args = args;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken KPrint { get { return this.kPrint; } }
	    public ArgsGreen Args { get { return this.args; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.PrintExpressionSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPrint;
	            case 1: return this.args;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PrintExpressionGreen(this.Kind, this.kPrint, this.args, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PrintExpressionGreen(this.Kind, this.kPrint, this.args, this.GetDiagnostics(), annotations);
	    }
	
	    public PrintExpressionGreen Update(InternalSyntaxToken kPrint, ArgsGreen args)
	    {
	        if (this.kPrint != kPrint ||
				this.args != args)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.PrintExpression(kPrint, args);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrintExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ValueExpressionGreen : ExpressionGreen
	{
	    private ValueGreen value;
	
	    public ValueExpressionGreen(CalculatorSyntaxKind kind, ValueGreen value)
	        : base(kind, null, null)
	    {
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
	    public ValueExpressionGreen(CalculatorSyntaxKind kind, ValueGreen value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public ValueGreen Value { get { return this.value; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.ValueExpressionSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.value;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ValueExpressionGreen(this.Kind, this.value, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ValueExpressionGreen(this.Kind, this.value, this.GetDiagnostics(), annotations);
	    }
	
	    public ValueExpressionGreen Update(ValueGreen value)
	    {
	        if (this.value != value)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.ValueExpression(value);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueExpressionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArgsGreen : CalculatorGreenNode
	{
	    private InternalSeparatedNodeList arg;
	
	    public ArgsGreen(CalculatorSyntaxKind kind, InternalSeparatedNodeList arg)
	        : base(kind, null, null)
	    {
			if (arg != null)
			{
				this.AdjustFlagsAndWidth(arg);
				this.arg = arg;
			}
	    }
	
	    public ArgsGreen(CalculatorSyntaxKind kind, InternalSeparatedNodeList arg, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (arg != null)
			{
				this.AdjustFlagsAndWidth(arg);
				this.arg = arg;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedNodeList Arg { get { return this.arg; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.ArgsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.arg;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArgsGreen(this.Kind, this.arg, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArgsGreen(this.Kind, this.arg, this.GetDiagnostics(), annotations);
	    }
	
	    public ArgsGreen Update(InternalSeparatedNodeList arg)
	    {
	        if (this.arg != arg)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Args(arg);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ValueGreen : CalculatorGreenNode
	{
	    private IdentifierGreen identifier;
	    private StringGreen _string;
	    private IntegerGreen integer;
	
	    public ValueGreen(CalculatorSyntaxKind kind, IdentifierGreen identifier, StringGreen _string, IntegerGreen integer)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
			if (integer != null)
			{
				this.AdjustFlagsAndWidth(integer);
				this.integer = integer;
			}
	    }
	
	    public ValueGreen(CalculatorSyntaxKind kind, IdentifierGreen identifier, StringGreen _string, IntegerGreen integer, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
			if (integer != null)
			{
				this.AdjustFlagsAndWidth(integer);
				this.integer = integer;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	    public StringGreen String { get { return this._string; } }
	    public IntegerGreen Integer { get { return this.integer; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.ValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            case 1: return this._string;
	            case 2: return this.integer;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ValueGreen(this.Kind, this.identifier, this._string, this.integer, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ValueGreen(this.Kind, this.identifier, this._string, this.integer, this.GetDiagnostics(), annotations);
	    }
	
	    public ValueGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Value(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueGreen)newNode;
	        }
	        return this;
	    }
	
	    public ValueGreen Update(StringGreen _string)
	    {
	        if (this._string != _string)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Value(_string);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueGreen)newNode;
	        }
	        return this;
	    }
	
	    public ValueGreen Update(IntegerGreen integer)
	    {
	        if (this.integer != integer)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Value(integer);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : CalculatorGreenNode
	{
	    private InternalSyntaxToken id;
	
	    public IdentifierGreen(CalculatorSyntaxKind kind, InternalSyntaxToken id)
	        : base(kind, null, null)
	    {
			if (id != null)
			{
				this.AdjustFlagsAndWidth(id);
				this.id = id;
			}
	    }
	
	    public IdentifierGreen(CalculatorSyntaxKind kind, InternalSyntaxToken id, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (id != null)
			{
				this.AdjustFlagsAndWidth(id);
				this.id = id;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken ID { get { return this.id; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.IdentifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.id;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.id, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.id, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(InternalSyntaxToken id)
	    {
	        if (this.id != id)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Identifier(id);
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
	
	internal class StringGreen : CalculatorGreenNode
	{
	    private InternalSyntaxToken _string;
	
	    public StringGreen(CalculatorSyntaxKind kind, InternalSyntaxToken _string)
	        : base(kind, null, null)
	    {
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
	    }
	
	    public StringGreen(CalculatorSyntaxKind kind, InternalSyntaxToken _string, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken STRING { get { return this._string; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.StringSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this._string;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringGreen(this.Kind, this._string, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringGreen(this.Kind, this._string, this.GetDiagnostics(), annotations);
	    }
	
	    public StringGreen Update(InternalSyntaxToken _string)
	    {
	        if (this._string != _string)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.String(_string);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IntegerGreen : CalculatorGreenNode
	{
	    private InternalSyntaxToken _int;
	
	    public IntegerGreen(CalculatorSyntaxKind kind, InternalSyntaxToken _int)
	        : base(kind, null, null)
	    {
			if (_int != null)
			{
				this.AdjustFlagsAndWidth(_int);
				this._int = _int;
			}
	    }
	
	    public IntegerGreen(CalculatorSyntaxKind kind, InternalSyntaxToken _int, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (_int != null)
			{
				this.AdjustFlagsAndWidth(_int);
				this._int = _int;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken INT { get { return this._int; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.IntegerSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this._int;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IntegerGreen(this.Kind, this._int, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IntegerGreen(this.Kind, this._int, this.GetDiagnostics(), annotations);
	    }
	
	    public IntegerGreen Update(InternalSyntaxToken _int)
	    {
	        if (this._int != _int)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Integer(_int);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ArgGreen : CalculatorGreenNode
	{
	    private ValueGreen value;
	
	    public ArgGreen(CalculatorSyntaxKind kind, ValueGreen value)
	        : base(kind, null, null)
	    {
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
	    public ArgGreen(CalculatorSyntaxKind kind, ValueGreen value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (value != null)
			{
				this.AdjustFlagsAndWidth(value);
				this.value = value;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public ValueGreen Value { get { return this.value; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::MetaDslx.Languages.Calculator.Syntax.ArgSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.value;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ArgGreen(this.Kind, this.value, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ArgGreen(this.Kind, this.value, this.GetDiagnostics(), annotations);
	    }
	
	    public ArgGreen Update(ValueGreen value)
	    {
	        if (this.value != value)
	        {
	            GreenNode newNode = CalculatorLanguage.Instance.InternalSyntaxFactory.Arg(value);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class CalculatorGreenFactory : InternalSyntaxFactory
	{
	    internal static readonly CalculatorGreenFactory Instance = new CalculatorGreenFactory();
	
		public CalculatorGreenTrivia Trivia(CalculatorSyntaxKind kind, string text)
		{
		    return new CalculatorGreenTrivia(kind, text, null, null);
		}
	
		protected override InternalSyntaxTrivia Trivia(int kind, string text)
		{
		    return new CalculatorGreenTrivia((CalculatorSyntaxKind)kind, text, null, null);
		}
	
		public CalculatorGreenToken MissingToken(CalculatorSyntaxKind kind)
		{
		    return CalculatorGreenToken.CreateMissing(kind, null, null);
		}
	
		protected override InternalSyntaxToken MissingToken(int kind)
		{
		    return CalculatorGreenToken.CreateMissing((CalculatorSyntaxKind)kind, null, null);
		}
	
		public CalculatorGreenToken MissingToken(GreenNode leading, CalculatorSyntaxKind kind, GreenNode trailing)
		{
		    return CalculatorGreenToken.CreateMissing(kind, leading, trailing);
		}
	
		protected override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
		{
		    return CalculatorGreenToken.CreateMissing((CalculatorSyntaxKind)kind, leading, trailing);
		}
	
		public CalculatorGreenToken Token(CalculatorSyntaxKind kind)
		{
		    return CalculatorGreenToken.Create(kind);
		}
	
		protected override InternalSyntaxToken Token(int kind)
		{
		    return CalculatorGreenToken.Create((CalculatorSyntaxKind)kind);
		}
	
	    public CalculatorGreenToken Token(GreenNode leading, CalculatorSyntaxKind kind, GreenNode trailing)
		{
		    return CalculatorGreenToken.Create(kind, leading, trailing);
		}
	
	    protected override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
		{
		    return CalculatorGreenToken.Create((CalculatorSyntaxKind)kind, leading, trailing);
		}
	
	    public CalculatorGreenToken Token(GreenNode leading, CalculatorSyntaxKind kind, string text, GreenNode trailing)
		{
		    Debug.Assert(CalculatorLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = CalculatorLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= CalculatorGreenToken.FirstTokenWithWellKnownText && kind <= CalculatorGreenToken.LastTokenWithWellKnownText && text == defaultText
		        ? this.Token(leading, kind, trailing)
		        : CalculatorGreenToken.WithText(kind, leading, text, trailing);
		}
	
	    protected override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
	    {
	        return this.Token(leading, (CalculatorSyntaxKind)kind, text, trailing);
	    }
	
	    public CalculatorGreenToken Token(GreenNode leading, CalculatorSyntaxKind kind, string text, string valueText, GreenNode trailing)
		{
		    Debug.Assert(CalculatorLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = CalculatorLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= CalculatorGreenToken.FirstTokenWithWellKnownText && kind <= CalculatorGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(valueText)
		        ? this.Token(leading, kind, trailing)
		        : CalculatorGreenToken.WithValue(kind, leading, text, valueText, trailing);
		}
	
	    protected override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
	    {
	        return this.Token(leading, (CalculatorSyntaxKind)kind, text, valueText, trailing);
	    }
	
	    public CalculatorGreenToken Token(GreenNode leading, CalculatorSyntaxKind kind, string text, object value, GreenNode trailing)
		{
		    Debug.Assert(CalculatorLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = CalculatorLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= CalculatorGreenToken.FirstTokenWithWellKnownText && kind <= CalculatorGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
		        ? this.Token(leading, kind, trailing)
		        : CalculatorGreenToken.WithValue(kind, leading, text, value, trailing);
		}
	
	    protected override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
	    {
	        return this.Token(leading, (CalculatorSyntaxKind)kind, text, value, trailing);
	    }
	
	    public CalculatorGreenToken BadToken(GreenNode leading, string text, GreenNode trailing)
		{
		    return CalculatorGreenToken.WithText(CalculatorSyntaxKind.BadToken, leading, text, trailing);
		}
	
	
	    internal CalculatorGreenToken STRING(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.STRING, text, null);
	    }
	
	    internal CalculatorGreenToken STRING(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.STRING, text, value, null);
	    }
	
	    internal CalculatorGreenToken ID(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.ID, text, null);
	    }
	
	    internal CalculatorGreenToken ID(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.ID, text, value, null);
	    }
	
	    internal CalculatorGreenToken INT(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.INT, text, null);
	    }
	
	    internal CalculatorGreenToken INT(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.INT, text, value, null);
	    }
	
	    internal CalculatorGreenToken UTF8BOM(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.UTF8BOM, text, null);
	    }
	
	    internal CalculatorGreenToken UTF8BOM(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.UTF8BOM, text, value, null);
	    }
	
	    internal CalculatorGreenToken WHITESPACE(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.WHITESPACE, text, null);
	    }
	
	    internal CalculatorGreenToken WHITESPACE(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.WHITESPACE, text, value, null);
	    }
	
	    internal CalculatorGreenToken ENDL(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.ENDL, text, null);
	    }
	
	    internal CalculatorGreenToken ENDL(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.ENDL, text, value, null);
	    }
	
	    internal CalculatorGreenToken COMMENT(string text)
	    {
	        return Token(null, CalculatorSyntaxKind.COMMENT, text, null);
	    }
	
	    internal CalculatorGreenToken COMMENT(string text, object value)
	    {
	        return Token(null, CalculatorSyntaxKind.COMMENT, text, value, null);
	    }
	
		public MainGreen Main(InternalNodeList statementLine, InternalSyntaxToken eof, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (eof == null) throw new ArgumentNullException(nameof(eof));
				if (eof.RawKind != (int)CalculatorSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Main, statementLine, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(CalculatorSyntaxKind.Main, statementLine, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StatementLineGreen StatementLine(StatementGreen statement, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (statement == null) throw new ArgumentNullException(nameof(statement));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)CalculatorSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.StatementLine, statement, tSemicolon, out hash);
			if (cached != null) return (StatementLineGreen)cached;
			var result = new StatementLineGreen(CalculatorSyntaxKind.StatementLine, statement, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StatementGreen Statement(AssignmentGreen assignment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (assignment == null) throw new ArgumentNullException(nameof(assignment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Statement, assignment, out hash);
			if (cached != null) return (StatementGreen)cached;
			var result = new StatementGreen(CalculatorSyntaxKind.Statement, assignment, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StatementGreen Statement(ExpressionGreen expression, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (expression == null) throw new ArgumentNullException(nameof(expression));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Statement, expression, out hash);
			if (cached != null) return (StatementGreen)cached;
			var result = new StatementGreen(CalculatorSyntaxKind.Statement, null, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AssignmentGreen Assignment(IdentifierGreen identifier, InternalSyntaxToken tAssign, ExpressionGreen expression, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)CalculatorSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (expression == null) throw new ArgumentNullException(nameof(expression));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Assignment, identifier, tAssign, expression, out hash);
			if (cached != null) return (AssignmentGreen)cached;
			var result = new AssignmentGreen(CalculatorSyntaxKind.Assignment, identifier, tAssign, expression);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParenExpressionGreen ParenExpression(InternalSyntaxToken tOpenParen, ExpressionGreen expression, InternalSyntaxToken tCloseParen, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
				if (tOpenParen.RawKind != (int)CalculatorSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
				if (expression == null) throw new ArgumentNullException(nameof(expression));
				if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
				if (tCloseParen.RawKind != (int)CalculatorSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.ParenExpression, tOpenParen, expression, tCloseParen, out hash);
			if (cached != null) return (ParenExpressionGreen)cached;
			var result = new ParenExpressionGreen(CalculatorSyntaxKind.ParenExpression, tOpenParen, expression, tCloseParen);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public MulOrDivExpressionGreen MulOrDivExpression(ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (left == null) throw new ArgumentNullException(nameof(left));
				if (_operator == null) throw new ArgumentNullException(nameof(_operator));
				if (right == null) throw new ArgumentNullException(nameof(right));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.MulOrDivExpression, left, _operator, right, out hash);
			if (cached != null) return (MulOrDivExpressionGreen)cached;
			var result = new MulOrDivExpressionGreen(CalculatorSyntaxKind.MulOrDivExpression, left, _operator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public AddOrSubExpressionGreen AddOrSubExpression(ExpressionGreen left, InternalSyntaxToken _operator, ExpressionGreen right, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (left == null) throw new ArgumentNullException(nameof(left));
				if (_operator == null) throw new ArgumentNullException(nameof(_operator));
				if (right == null) throw new ArgumentNullException(nameof(right));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.AddOrSubExpression, left, _operator, right, out hash);
			if (cached != null) return (AddOrSubExpressionGreen)cached;
			var result = new AddOrSubExpressionGreen(CalculatorSyntaxKind.AddOrSubExpression, left, _operator, right);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PrintExpressionGreen PrintExpression(InternalSyntaxToken kPrint, ArgsGreen args, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kPrint == null) throw new ArgumentNullException(nameof(kPrint));
				if (kPrint.RawKind != (int)CalculatorSyntaxKind.KPrint) throw new ArgumentException(nameof(kPrint));
				if (args == null) throw new ArgumentNullException(nameof(args));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.PrintExpression, kPrint, args, out hash);
			if (cached != null) return (PrintExpressionGreen)cached;
			var result = new PrintExpressionGreen(CalculatorSyntaxKind.PrintExpression, kPrint, args);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ValueExpressionGreen ValueExpression(ValueGreen value, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (value == null) throw new ArgumentNullException(nameof(value));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.ValueExpression, value, out hash);
			if (cached != null) return (ValueExpressionGreen)cached;
			var result = new ValueExpressionGreen(CalculatorSyntaxKind.ValueExpression, value);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArgsGreen Args(InternalSeparatedNodeList arg, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Args, arg, out hash);
			if (cached != null) return (ArgsGreen)cached;
			var result = new ArgsGreen(CalculatorSyntaxKind.Args, arg);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ValueGreen Value(IdentifierGreen identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Value, identifier, out hash);
			if (cached != null) return (ValueGreen)cached;
			var result = new ValueGreen(CalculatorSyntaxKind.Value, identifier, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ValueGreen Value(StringGreen _string, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (_string == null) throw new ArgumentNullException(nameof(_string));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Value, _string, out hash);
			if (cached != null) return (ValueGreen)cached;
			var result = new ValueGreen(CalculatorSyntaxKind.Value, null, _string, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ValueGreen Value(IntegerGreen integer, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (integer == null) throw new ArgumentNullException(nameof(integer));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Value, integer, out hash);
			if (cached != null) return (ValueGreen)cached;
			var result = new ValueGreen(CalculatorSyntaxKind.Value, null, null, integer);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken id, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (id == null) throw new ArgumentNullException(nameof(id));
				if (id.RawKind != (int)CalculatorSyntaxKind.ID) throw new ArgumentException(nameof(id));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Identifier, id, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(CalculatorSyntaxKind.Identifier, id);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringGreen String(InternalSyntaxToken _string, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (_string == null) throw new ArgumentNullException(nameof(_string));
				if (_string.RawKind != (int)CalculatorSyntaxKind.STRING) throw new ArgumentException(nameof(_string));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.String, _string, out hash);
			if (cached != null) return (StringGreen)cached;
			var result = new StringGreen(CalculatorSyntaxKind.String, _string);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IntegerGreen Integer(InternalSyntaxToken _int, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (_int == null) throw new ArgumentNullException(nameof(_int));
				if (_int.RawKind != (int)CalculatorSyntaxKind.INT) throw new ArgumentException(nameof(_int));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Integer, _int, out hash);
			if (cached != null) return (IntegerGreen)cached;
			var result = new IntegerGreen(CalculatorSyntaxKind.Integer, _int);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ArgGreen Arg(ValueGreen value, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (value == null) throw new ArgumentNullException(nameof(value));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)CalculatorSyntaxKind.Arg, value, out hash);
			if (cached != null) return (ArgGreen)cached;
			var result = new ArgGreen(CalculatorSyntaxKind.Arg, value);
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
				typeof(StatementLineGreen),
				typeof(StatementGreen),
				typeof(AssignmentGreen),
				typeof(ParenExpressionGreen),
				typeof(MulOrDivExpressionGreen),
				typeof(AddOrSubExpressionGreen),
				typeof(PrintExpressionGreen),
				typeof(ValueExpressionGreen),
				typeof(ArgsGreen),
				typeof(ValueGreen),
				typeof(IdentifierGreen),
				typeof(StringGreen),
				typeof(IntegerGreen),
				typeof(ArgGreen),
			};
		}
	}
}


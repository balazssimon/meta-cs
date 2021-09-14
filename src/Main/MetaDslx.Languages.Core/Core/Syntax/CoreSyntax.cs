// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Core.Syntax
{
    public abstract class CoreSyntaxNode : LanguageSyntaxNode
    {
        protected CoreSyntaxNode(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected CoreSyntaxNode(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new CoreLanguage Language => CoreLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new CoreSyntaxKind Kind => (CoreSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return CoreSyntaxTree.CreateWithoutClone(this, ParseData.Empty);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is ICoreSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is ICoreSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is ICoreSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(ICoreSyntaxVisitor visitor);
    }

    /// <summary>
    /// It's a non terminal Trivia CoreSyntaxNode that has a tree underneath it.
    /// </summary>
    public abstract partial class CoreStructuredTriviaSyntax : CoreSyntaxNode, IStructuredTriviaSyntax
    {
        private SyntaxTrivia _parent;
        internal CoreStructuredTriviaSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
            : base(green, parent == null ? null : (CoreSyntaxTree)parent.SyntaxTree, position)
        {
            System.Diagnostics.Debug.Assert(parent == null || position >= 0);
        }
		internal static CoreStructuredTriviaSyntax Create(SyntaxTrivia trivia)
		{
			var red = (CoreStructuredTriviaSyntax)CoreLanguage.Instance.SyntaxFactory.CreateStructure(trivia);
			red._parent = trivia;
			return red;
		}
        /// <summary>
        /// Get parent trivia.
        /// </summary>
        public override SyntaxTrivia ParentTrivia => _parent;
    }

    public sealed partial class CoreSkippedTokensTriviaSyntax : CoreStructuredTriviaSyntax
    {
        internal CoreSkippedTokensTriviaSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SyntaxTokenList Tokens 
        {
            get
            {
				var slot = ((global::MetaDslx.Languages.Core.Syntax.InternalSyntax.GreenSkippedTokensTriviaSyntax)this.Green).Tokens;
				if (slot != null)
				{
					return new SyntaxTokenList(this, slot.Node, this.GetChildPosition(0), this.GetChildIndex(0));
				}
                return default;
            }
        }

        public override SyntaxNode GetNodeSlot(int index)
        {
            switch (index)
            {
                default: return null;
            }
        }

		public override SyntaxNode GetCachedSlot(int index)
        {
            switch (index)
            {
                default: return null;
            }
        }

		public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
		{
			return visitor.VisitSkippedTokensTrivia(this, argument);
		}

		public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitSkippedTokensTrivia(this);
        }

        public override void Accept(ICoreSyntaxVisitor visitor)
        {
            visitor.VisitSkippedTokensTrivia(this);
        }

        public CoreSkippedTokensTriviaSyntax Update(SyntaxTokenList tokens)
        {
            if (tokens != this.Tokens)
            {
                var newNode = (CoreSkippedTokensTriviaSyntax)Language.SyntaxFactory.SkippedTokensTrivia(tokens);
                var annotations = this.GetAnnotations();
                if (annotations != null && annotations.Length > 0)
                    return newNode.WithAnnotations(annotations);
                return newNode;
            }
            return this;
        }

        public CoreSkippedTokensTriviaSyntax WithTokens(SyntaxTokenList tokens)
        {
            return this.Update(tokens);
        }

        public CoreSkippedTokensTriviaSyntax AddTokens(params SyntaxToken[] items)
        {
            return this.WithTokens(this.Tokens.AddRange(items));
        }
    }

	
	public sealed class MainSyntax : CoreSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNode usingNamespace;
	    private SyntaxNode statement;
	
	    public MainSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceSyntax> UsingNamespace 
		{ 
			get
			{
				var red = this.GetRed(ref this.usingNamespace, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceSyntax>(red);
				return default;
			} 
		}
	    public Microsoft.CodeAnalysis.SyntaxList<StatementSyntax> Statement 
		{ 
			get
			{
				var red = this.GetRed(ref this.statement, 1);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<StatementSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.usingNamespace, 0);
				case 1: return this.GetRed(ref this.statement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.usingNamespace;
				case 1: return this.statement;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithUsingNamespace(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceSyntax> usingNamespace)
		{
			return this.Update(UsingNamespace, this.Statement, this.EndOfFileToken);
		}
	
	    public MainSyntax AddUsingNamespace(params UsingNamespaceSyntax[] usingNamespace)
		{
			return this.WithUsingNamespace(this.UsingNamespace.AddRange(usingNamespace));
		}
	
	    public MainSyntax WithStatement(Microsoft.CodeAnalysis.SyntaxList<StatementSyntax> statement)
		{
			return this.Update(this.UsingNamespace, Statement, this.EndOfFileToken);
		}
	
	    public MainSyntax AddStatement(params StatementSyntax[] statement)
		{
			return this.WithStatement(this.Statement.AddRange(statement));
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eOF)
		{
			return this.Update(this.UsingNamespace, this.Statement, EndOfFileToken);
		}
	
	    public MainSyntax Update(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceSyntax> usingNamespace, Microsoft.CodeAnalysis.SyntaxList<StatementSyntax> statement, SyntaxToken eOF)
	    {
	        if (this.UsingNamespace != usingNamespace ||
				this.Statement != statement ||
				this.EndOfFileToken != eOF)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Main(usingNamespace, statement, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class UsingNamespaceSyntax : CoreSyntaxNode
	{
	    private NameSyntax name;
	    private QualifierSyntax qualifier;
	
	    public UsingNamespaceSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingNamespaceSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUsing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UsingNamespaceGreen)this.Green;
				var greenToken = green.KUsing;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UsingNamespaceGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UsingNamespaceGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public UsingNamespaceSyntax WithKUsing(SyntaxToken kUsing)
		{
			return this.Update(KUsing, this.Name, this.TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KUsing, Name, this.TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.KUsing, this.Name, TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KUsing, this.Name, this.TAssign, Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KUsing, this.Name, this.TAssign, this.Qualifier, TSemicolon);
		}
	
	    public UsingNamespaceSyntax Update(SyntaxToken kUsing, NameSyntax name, SyntaxToken tAssign, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.Name != name ||
				this.TAssign != tAssign ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.UsingNamespace(kUsing, name, tAssign, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingNamespace(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingNamespace(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingNamespace(this);
	    }
	}
	
	public sealed class StatementSyntax : CoreSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public StatementSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.StatementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				default: return null;
	        }
	    }
	
	    public StatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.TSemicolon);
		}
	
	    public StatementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Expression, TSemicolon);
		}
	
	    public StatementSyntax Update(ExpressionSyntax expression, SyntaxToken tSemicolon)
	    {
	        if (this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Statement(expression, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatement(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitStatement(this);
	    }
	}
	
	public abstract class ExpressionSyntax : CoreSyntaxNode
	{
	    protected ExpressionSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ExpressionSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ParenthesizedExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public ParenthesizedExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParenthesizedExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ParenthesizedExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ParenthesizedExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public ParenthesizedExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public ParenthesizedExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TOpenParen, Expression, this.TCloseParen);
		}
	
	    public ParenthesizedExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.Expression, TCloseParen);
		}
	
	    public ParenthesizedExprSyntax Update(SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ParenthesizedExpr(tOpenParen, expression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenthesizedExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParenthesizedExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParenthesizedExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitParenthesizedExpr(this);
	    }
	}
	
	public sealed class DefaultExprSyntax : ExpressionSyntax
	{
	
	    public DefaultExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefaultExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KDefault 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.DefaultExprGreen)this.Green;
				var greenToken = green.KDefault;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public DefaultExprSyntax WithKDefault(SyntaxToken kDefault)
		{
			return this.Update(KDefault);
		}
	
	    public DefaultExprSyntax Update(SyntaxToken kDefault)
	    {
	        if (this.KDefault != kDefault)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.DefaultExpr(kDefault);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDefaultExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefaultExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitDefaultExpr(this);
	    }
	}
	
	public sealed class ThisExprSyntax : ExpressionSyntax
	{
	
	    public ThisExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ThisExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KThis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ThisExprGreen)this.Green;
				var greenToken = green.KThis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public ThisExprSyntax WithKThis(SyntaxToken kThis)
		{
			return this.Update(KThis);
		}
	
	    public ThisExprSyntax Update(SyntaxToken kThis)
	    {
	        if (this.KThis != kThis)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ThisExpr(kThis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThisExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitThisExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitThisExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitThisExpr(this);
	    }
	}
	
	public sealed class BaseExprSyntax : ExpressionSyntax
	{
	
	    public BaseExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BaseExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KBase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.BaseExprGreen)this.Green;
				var greenToken = green.KBase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public BaseExprSyntax WithKBase(SyntaxToken kBase)
		{
			return this.Update(KBase);
		}
	
	    public BaseExprSyntax Update(SyntaxToken kBase)
	    {
	        if (this.KBase != kBase)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.BaseExpr(kBase);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BaseExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBaseExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBaseExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitBaseExpr(this);
	    }
	}
	
	public sealed class LiteralExprSyntax : ExpressionSyntax
	{
	    private LiteralSyntax literal;
	
	    public LiteralExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LiteralSyntax Literal 
		{ 
			get { return this.GetRed(ref this.literal, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.literal, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.literal;
				default: return null;
	        }
	    }
	
	    public LiteralExprSyntax WithLiteral(LiteralSyntax literal)
		{
			return this.Update(Literal);
		}
	
	    public LiteralExprSyntax Update(LiteralSyntax literal)
	    {
	        if (this.Literal != literal)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.LiteralExpr(literal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteralExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteralExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteralExpr(this);
	    }
	}
	
	public sealed class IdentifierExprSyntax : ExpressionSyntax
	{
	    private IdentifierSyntax identifier;
	    private GenericTypeArgumentsSyntax genericTypeArguments;
	
	    public IdentifierExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public GenericTypeArgumentsSyntax GenericTypeArguments 
		{ 
			get { return this.GetRed(ref this.genericTypeArguments, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 1: return this.GetRed(ref this.genericTypeArguments, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 1: return this.genericTypeArguments;
				default: return null;
	        }
	    }
	
	    public IdentifierExprSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.GenericTypeArguments);
		}
	
	    public IdentifierExprSyntax WithGenericTypeArguments(GenericTypeArgumentsSyntax genericTypeArguments)
		{
			return this.Update(this.Identifier, GenericTypeArguments);
		}
	
	    public IdentifierExprSyntax Update(IdentifierSyntax identifier, GenericTypeArgumentsSyntax genericTypeArguments)
	    {
	        if (this.Identifier != identifier ||
				this.GenericTypeArguments != genericTypeArguments)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.IdentifierExpr(identifier, genericTypeArguments);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifierExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifierExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifierExpr(this);
	    }
	}
	
	public sealed class QualifierExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private DotOperatorSyntax dotOperator;
	    private IdentifierSyntax identifier;
	    private GenericTypeArgumentsSyntax genericTypeArguments;
	
	    public QualifierExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public DotOperatorSyntax DotOperator 
		{ 
			get { return this.GetRed(ref this.dotOperator, 1); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public GenericTypeArgumentsSyntax GenericTypeArguments 
		{ 
			get { return this.GetRed(ref this.genericTypeArguments, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 1: return this.GetRed(ref this.dotOperator, 1);
				case 2: return this.GetRed(ref this.identifier, 2);
				case 3: return this.GetRed(ref this.genericTypeArguments, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
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
	
	    public QualifierExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.DotOperator, this.Identifier, this.GenericTypeArguments);
		}
	
	    public QualifierExprSyntax WithDotOperator(DotOperatorSyntax dotOperator)
		{
			return this.Update(this.Expression, DotOperator, this.Identifier, this.GenericTypeArguments);
		}
	
	    public QualifierExprSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.Expression, this.DotOperator, Identifier, this.GenericTypeArguments);
		}
	
	    public QualifierExprSyntax WithGenericTypeArguments(GenericTypeArgumentsSyntax genericTypeArguments)
		{
			return this.Update(this.Expression, this.DotOperator, this.Identifier, GenericTypeArguments);
		}
	
	    public QualifierExprSyntax Update(ExpressionSyntax expression, DotOperatorSyntax dotOperator, IdentifierSyntax identifier, GenericTypeArgumentsSyntax genericTypeArguments)
	    {
	        if (this.Expression != expression ||
				this.DotOperator != dotOperator ||
				this.Identifier != identifier ||
				this.GenericTypeArguments != genericTypeArguments)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.QualifierExpr(expression, dotOperator, identifier, genericTypeArguments);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifierExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifierExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifierExpr(this);
	    }
	}
	
	public sealed class IndexerExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private IndexerOperatorSyntax indexerOperator;
	    private ArgumentListSyntax argumentList;
	
	    public IndexerExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IndexerExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public IndexerOperatorSyntax IndexerOperator 
		{ 
			get { return this.GetRed(ref this.indexerOperator, 1); } 
		}
	    public ArgumentListSyntax ArgumentList 
		{ 
			get { return this.GetRed(ref this.argumentList, 2); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.IndexerExprGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 1: return this.GetRed(ref this.indexerOperator, 1);
				case 2: return this.GetRed(ref this.argumentList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 1: return this.indexerOperator;
				case 2: return this.argumentList;
				default: return null;
	        }
	    }
	
	    public IndexerExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.IndexerOperator, this.ArgumentList, this.TCloseBracket);
		}
	
	    public IndexerExprSyntax WithIndexerOperator(IndexerOperatorSyntax indexerOperator)
		{
			return this.Update(this.Expression, IndexerOperator, this.ArgumentList, this.TCloseBracket);
		}
	
	    public IndexerExprSyntax WithArgumentList(ArgumentListSyntax argumentList)
		{
			return this.Update(this.Expression, this.IndexerOperator, ArgumentList, this.TCloseBracket);
		}
	
	    public IndexerExprSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.Expression, this.IndexerOperator, this.ArgumentList, TCloseBracket);
		}
	
	    public IndexerExprSyntax Update(ExpressionSyntax expression, IndexerOperatorSyntax indexerOperator, ArgumentListSyntax argumentList, SyntaxToken tCloseBracket)
	    {
	        if (this.Expression != expression ||
				this.IndexerOperator != indexerOperator ||
				this.ArgumentList != argumentList ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.IndexerExpr(expression, indexerOperator, argumentList, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IndexerExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIndexerExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIndexerExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitIndexerExpr(this);
	    }
	}
	
	public sealed class InvocationExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private ArgumentListSyntax argumentList;
	
	    public InvocationExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InvocationExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.InvocationExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ArgumentListSyntax ArgumentList 
		{ 
			get { return this.GetRed(ref this.argumentList, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.InvocationExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 2: return this.GetRed(ref this.argumentList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 2: return this.argumentList;
				default: return null;
	        }
	    }
	
	    public InvocationExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.TOpenParen, this.ArgumentList, this.TCloseParen);
		}
	
	    public InvocationExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Expression, TOpenParen, this.ArgumentList, this.TCloseParen);
		}
	
	    public InvocationExprSyntax WithArgumentList(ArgumentListSyntax argumentList)
		{
			return this.Update(this.Expression, this.TOpenParen, ArgumentList, this.TCloseParen);
		}
	
	    public InvocationExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Expression, this.TOpenParen, this.ArgumentList, TCloseParen);
		}
	
	    public InvocationExprSyntax Update(ExpressionSyntax expression, SyntaxToken tOpenParen, ArgumentListSyntax argumentList, SyntaxToken tCloseParen)
	    {
	        if (this.Expression != expression ||
				this.TOpenParen != tOpenParen ||
				this.ArgumentList != argumentList ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.InvocationExpr(expression, tOpenParen, argumentList, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InvocationExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInvocationExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInvocationExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitInvocationExpr(this);
	    }
	}
	
	public sealed class TypeofExprSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public TypeofExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeofExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeofExprGreen)this.Green;
				var greenToken = green.KTypeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeofExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeofExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypeofExprSyntax WithKTypeof(SyntaxToken kTypeof)
		{
			return this.Update(KTypeof, this.TOpenParen, this.TypeReference, this.TCloseParen);
		}
	
	    public TypeofExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KTypeof, TOpenParen, this.TypeReference, this.TCloseParen);
		}
	
	    public TypeofExprSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KTypeof, this.TOpenParen, TypeReference, this.TCloseParen);
		}
	
	    public TypeofExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KTypeof, this.TOpenParen, this.TypeReference, TCloseParen);
		}
	
	    public TypeofExprSyntax Update(SyntaxToken kTypeof, SyntaxToken tOpenParen, TypeReferenceSyntax typeReference, SyntaxToken tCloseParen)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParen != tOpenParen ||
				this.TypeReference != typeReference ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.TypeofExpr(kTypeof, tOpenParen, typeReference, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeofExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeofExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeofExpr(this);
	    }
	}
	
	public sealed class NameofExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public NameofExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameofExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNameof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NameofExprGreen)this.Green;
				var greenToken = green.KNameof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NameofExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NameofExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public NameofExprSyntax WithKNameof(SyntaxToken kNameof)
		{
			return this.Update(KNameof, this.TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public NameofExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KNameof, TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public NameofExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KNameof, this.TOpenParen, Expression, this.TCloseParen);
		}
	
	    public NameofExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KNameof, this.TOpenParen, this.Expression, TCloseParen);
		}
	
	    public NameofExprSyntax Update(SyntaxToken kNameof, SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
	    {
	        if (this.KNameof != kNameof ||
				this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.NameofExpr(kNameof, tOpenParen, expression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameofExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNameofExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNameofExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitNameofExpr(this);
	    }
	}
	
	public sealed class SizeofExprSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public SizeofExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SizeofExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KSizeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.SizeofExprGreen)this.Green;
				var greenToken = green.KSizeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.SizeofExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.SizeofExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public SizeofExprSyntax WithKSizeof(SyntaxToken kSizeof)
		{
			return this.Update(KSizeof, this.TOpenParen, this.TypeReference, this.TCloseParen);
		}
	
	    public SizeofExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KSizeof, TOpenParen, this.TypeReference, this.TCloseParen);
		}
	
	    public SizeofExprSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KSizeof, this.TOpenParen, TypeReference, this.TCloseParen);
		}
	
	    public SizeofExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KSizeof, this.TOpenParen, this.TypeReference, TCloseParen);
		}
	
	    public SizeofExprSyntax Update(SyntaxToken kSizeof, SyntaxToken tOpenParen, TypeReferenceSyntax typeReference, SyntaxToken tCloseParen)
	    {
	        if (this.KSizeof != kSizeof ||
				this.TOpenParen != tOpenParen ||
				this.TypeReference != typeReference ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.SizeofExpr(kSizeof, tOpenParen, typeReference, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SizeofExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSizeofExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSizeofExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitSizeofExpr(this);
	    }
	}
	
	public sealed class CheckedExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public CheckedExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CheckedExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KChecked 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CheckedExprGreen)this.Green;
				var greenToken = green.KChecked;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CheckedExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CheckedExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public CheckedExprSyntax WithKChecked(SyntaxToken kChecked)
		{
			return this.Update(KChecked, this.TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public CheckedExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KChecked, TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public CheckedExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KChecked, this.TOpenParen, Expression, this.TCloseParen);
		}
	
	    public CheckedExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KChecked, this.TOpenParen, this.Expression, TCloseParen);
		}
	
	    public CheckedExprSyntax Update(SyntaxToken kChecked, SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
	    {
	        if (this.KChecked != kChecked ||
				this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.CheckedExpr(kChecked, tOpenParen, expression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CheckedExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCheckedExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCheckedExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitCheckedExpr(this);
	    }
	}
	
	public sealed class UncheckedExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public UncheckedExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UncheckedExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUnchecked 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UncheckedExprGreen)this.Green;
				var greenToken = green.KUnchecked;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UncheckedExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UncheckedExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public UncheckedExprSyntax WithKUnchecked(SyntaxToken kUnchecked)
		{
			return this.Update(KUnchecked, this.TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public UncheckedExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KUnchecked, TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public UncheckedExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KUnchecked, this.TOpenParen, Expression, this.TCloseParen);
		}
	
	    public UncheckedExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KUnchecked, this.TOpenParen, this.Expression, TCloseParen);
		}
	
	    public UncheckedExprSyntax Update(SyntaxToken kUnchecked, SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
	    {
	        if (this.KUnchecked != kUnchecked ||
				this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.UncheckedExpr(kUnchecked, tOpenParen, expression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UncheckedExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUncheckedExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUncheckedExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitUncheckedExpr(this);
	    }
	}
	
	public sealed class NewExprSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	    private ArgumentListSyntax argumentList;
	    private InitializerExpressionSyntax initializerExpression;
	
	    public NewExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NewExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNew 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NewExprGreen)this.Green;
				var greenToken = green.KNew;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NewExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ArgumentListSyntax ArgumentList 
		{ 
			get { return this.GetRed(ref this.argumentList, 3); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NewExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public InitializerExpressionSyntax InitializerExpression 
		{ 
			get { return this.GetRed(ref this.initializerExpression, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 3: return this.GetRed(ref this.argumentList, 3);
				case 5: return this.GetRed(ref this.initializerExpression, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReference;
				case 3: return this.argumentList;
				case 5: return this.initializerExpression;
				default: return null;
	        }
	    }
	
	    public NewExprSyntax WithKNew(SyntaxToken kNew)
		{
			return this.Update(KNew, this.TypeReference, this.TOpenParen, this.ArgumentList, this.TCloseParen, this.InitializerExpression);
		}
	
	    public NewExprSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KNew, TypeReference, this.TOpenParen, this.ArgumentList, this.TCloseParen, this.InitializerExpression);
		}
	
	    public NewExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KNew, this.TypeReference, TOpenParen, this.ArgumentList, this.TCloseParen, this.InitializerExpression);
		}
	
	    public NewExprSyntax WithArgumentList(ArgumentListSyntax argumentList)
		{
			return this.Update(this.KNew, this.TypeReference, this.TOpenParen, ArgumentList, this.TCloseParen, this.InitializerExpression);
		}
	
	    public NewExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KNew, this.TypeReference, this.TOpenParen, this.ArgumentList, TCloseParen, this.InitializerExpression);
		}
	
	    public NewExprSyntax WithInitializerExpression(InitializerExpressionSyntax initializerExpression)
		{
			return this.Update(this.KNew, this.TypeReference, this.TOpenParen, this.ArgumentList, this.TCloseParen, InitializerExpression);
		}
	
	    public NewExprSyntax Update(SyntaxToken kNew, TypeReferenceSyntax typeReference, SyntaxToken tOpenParen, ArgumentListSyntax argumentList, SyntaxToken tCloseParen, InitializerExpressionSyntax initializerExpression)
	    {
	        if (this.KNew != kNew ||
				this.TypeReference != typeReference ||
				this.TOpenParen != tOpenParen ||
				this.ArgumentList != argumentList ||
				this.TCloseParen != tCloseParen ||
				this.InitializerExpression != initializerExpression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.NewExpr(kNew, typeReference, tOpenParen, argumentList, tCloseParen, initializerExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NewExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNewExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNewExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitNewExpr(this);
	    }
	}
	
	public sealed class PostfixUnaryExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private PostfixOperatorSyntax postfixOperator;
	
	    public PostfixUnaryExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PostfixUnaryExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public PostfixOperatorSyntax PostfixOperator 
		{ 
			get { return this.GetRed(ref this.postfixOperator, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 1: return this.GetRed(ref this.postfixOperator, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 1: return this.postfixOperator;
				default: return null;
	        }
	    }
	
	    public PostfixUnaryExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.PostfixOperator);
		}
	
	    public PostfixUnaryExprSyntax WithPostfixOperator(PostfixOperatorSyntax postfixOperator)
		{
			return this.Update(this.Expression, PostfixOperator);
		}
	
	    public PostfixUnaryExprSyntax Update(ExpressionSyntax expression, PostfixOperatorSyntax postfixOperator)
	    {
	        if (this.Expression != expression ||
				this.PostfixOperator != postfixOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.PostfixUnaryExpr(expression, postfixOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PostfixUnaryExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPostfixUnaryExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPostfixUnaryExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitPostfixUnaryExpr(this);
	    }
	}
	
	public sealed class UnaryExprSyntax : ExpressionSyntax
	{
	    private UnaryOperatorSyntax unaryOperator;
	    private ExpressionSyntax expression;
	
	    public UnaryExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UnaryExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public UnaryOperatorSyntax UnaryOperator 
		{ 
			get { return this.GetRed(ref this.unaryOperator, 0); } 
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.unaryOperator, 0);
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.unaryOperator;
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public UnaryExprSyntax WithUnaryOperator(UnaryOperatorSyntax unaryOperator)
		{
			return this.Update(UnaryOperator, this.Expression);
		}
	
	    public UnaryExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.UnaryOperator, Expression);
		}
	
	    public UnaryExprSyntax Update(UnaryOperatorSyntax unaryOperator, ExpressionSyntax expression)
	    {
	        if (this.UnaryOperator != unaryOperator ||
				this.Expression != expression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.UnaryExpr(unaryOperator, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnaryExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUnaryExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUnaryExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitUnaryExpr(this);
	    }
	}
	
	public sealed class TypeCastExprSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	    private ExpressionSyntax expression;
	
	    public TypeCastExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeCastExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeCastExprGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeCastExprGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 3: return this.GetRed(ref this.expression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReference;
				case 3: return this.expression;
				default: return null;
	        }
	    }
	
	    public TypeCastExprSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.TypeReference, this.TCloseParen, this.Expression);
		}
	
	    public TypeCastExprSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.TOpenParen, TypeReference, this.TCloseParen, this.Expression);
		}
	
	    public TypeCastExprSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.TypeReference, TCloseParen, this.Expression);
		}
	
	    public TypeCastExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TOpenParen, this.TypeReference, this.TCloseParen, Expression);
		}
	
	    public TypeCastExprSyntax Update(SyntaxToken tOpenParen, TypeReferenceSyntax typeReference, SyntaxToken tCloseParen, ExpressionSyntax expression)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.TypeReference != typeReference ||
				this.TCloseParen != tCloseParen ||
				this.Expression != expression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.TypeCastExpr(tOpenParen, typeReference, tCloseParen, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeCastExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeCastExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeCastExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeCastExpr(this);
	    }
	}
	
	public sealed class MultExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private MultiplicativeOperatorSyntax multiplicativeOperator;
	    private ExpressionSyntax right;
	
	    public MultExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MultExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public MultiplicativeOperatorSyntax MultiplicativeOperator 
		{ 
			get { return this.GetRed(ref this.multiplicativeOperator, 1); } 
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.multiplicativeOperator, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.multiplicativeOperator;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public MultExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.MultiplicativeOperator, this.Right);
		}
	
	    public MultExprSyntax WithMultiplicativeOperator(MultiplicativeOperatorSyntax multiplicativeOperator)
		{
			return this.Update(this.Left, MultiplicativeOperator, this.Right);
		}
	
	    public MultExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.MultiplicativeOperator, Right);
		}
	
	    public MultExprSyntax Update(ExpressionSyntax left, MultiplicativeOperatorSyntax multiplicativeOperator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.MultiplicativeOperator != multiplicativeOperator ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.MultExpr(left, multiplicativeOperator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMultExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMultExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitMultExpr(this);
	    }
	}
	
	public sealed class AddExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private AdditiveOperatorSyntax additiveOperator;
	    private ExpressionSyntax right;
	
	    public AddExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AddExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public AdditiveOperatorSyntax AdditiveOperator 
		{ 
			get { return this.GetRed(ref this.additiveOperator, 1); } 
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.additiveOperator, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.additiveOperator;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public AddExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.AdditiveOperator, this.Right);
		}
	
	    public AddExprSyntax WithAdditiveOperator(AdditiveOperatorSyntax additiveOperator)
		{
			return this.Update(this.Left, AdditiveOperator, this.Right);
		}
	
	    public AddExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.AdditiveOperator, Right);
		}
	
	    public AddExprSyntax Update(ExpressionSyntax left, AdditiveOperatorSyntax additiveOperator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.AdditiveOperator != additiveOperator ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.AddExpr(left, additiveOperator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AddExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAddExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAddExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitAddExpr(this);
	    }
	}
	
	public sealed class ShiftExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ShiftOperatorSyntax shiftOperator;
	    private ExpressionSyntax right;
	
	    public ShiftExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ShiftExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public ShiftOperatorSyntax ShiftOperator 
		{ 
			get { return this.GetRed(ref this.shiftOperator, 1); } 
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.shiftOperator, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.shiftOperator;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public ShiftExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.ShiftOperator, this.Right);
		}
	
	    public ShiftExprSyntax WithShiftOperator(ShiftOperatorSyntax shiftOperator)
		{
			return this.Update(this.Left, ShiftOperator, this.Right);
		}
	
	    public ShiftExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.ShiftOperator, Right);
		}
	
	    public ShiftExprSyntax Update(ExpressionSyntax left, ShiftOperatorSyntax shiftOperator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.ShiftOperator != shiftOperator ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ShiftExpr(left, shiftOperator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ShiftExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitShiftExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitShiftExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitShiftExpr(this);
	    }
	}
	
	public sealed class RelExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private RelationalOperatorSyntax relationalOperator;
	    private ExpressionSyntax right;
	
	    public RelExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RelExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public RelationalOperatorSyntax RelationalOperator 
		{ 
			get { return this.GetRed(ref this.relationalOperator, 1); } 
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.relationalOperator, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.relationalOperator;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public RelExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.RelationalOperator, this.Right);
		}
	
	    public RelExprSyntax WithRelationalOperator(RelationalOperatorSyntax relationalOperator)
		{
			return this.Update(this.Left, RelationalOperator, this.Right);
		}
	
	    public RelExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.RelationalOperator, Right);
		}
	
	    public RelExprSyntax Update(ExpressionSyntax left, RelationalOperatorSyntax relationalOperator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.RelationalOperator != relationalOperator ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.RelExpr(left, relationalOperator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RelExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRelExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRelExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitRelExpr(this);
	    }
	}
	
	public sealed class TypeIsExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private TypeReferenceSyntax typeReference;
	
	    public TypeIsExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeIsExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken KIs 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeIsExprGreen)this.Green;
				var greenToken = green.KIs;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken KNot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeIsExprGreen)this.Green;
				var greenToken = green.KNot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 3: return this.GetRed(ref this.typeReference, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 3: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypeIsExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.KIs, this.KNot, this.TypeReference);
		}
	
	    public TypeIsExprSyntax WithKIs(SyntaxToken kIs)
		{
			return this.Update(this.Expression, KIs, this.KNot, this.TypeReference);
		}
	
	    public TypeIsExprSyntax WithKNot(SyntaxToken kNot)
		{
			return this.Update(this.Expression, this.KIs, KNot, this.TypeReference);
		}
	
	    public TypeIsExprSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Expression, this.KIs, this.KNot, TypeReference);
		}
	
	    public TypeIsExprSyntax Update(ExpressionSyntax expression, SyntaxToken kIs, SyntaxToken kNot, TypeReferenceSyntax typeReference)
	    {
	        if (this.Expression != expression ||
				this.KIs != kIs ||
				this.KNot != kNot ||
				this.TypeReference != typeReference)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.TypeIsExpr(expression, kIs, kNot, typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeIsExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeIsExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeIsExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeIsExpr(this);
	    }
	}
	
	public sealed class TypeAsExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private TypeReferenceSyntax typeReference;
	
	    public TypeAsExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeAsExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken KAs 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.TypeAsExprGreen)this.Green;
				var greenToken = green.KAs;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypeAsExprSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.KAs, this.TypeReference);
		}
	
	    public TypeAsExprSyntax WithKAs(SyntaxToken kAs)
		{
			return this.Update(this.Expression, KAs, this.TypeReference);
		}
	
	    public TypeAsExprSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Expression, this.KAs, TypeReference);
		}
	
	    public TypeAsExprSyntax Update(ExpressionSyntax expression, SyntaxToken kAs, TypeReferenceSyntax typeReference)
	    {
	        if (this.Expression != expression ||
				this.KAs != kAs ||
				this.TypeReference != typeReference)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.TypeAsExpr(expression, kAs, typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeAsExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeAsExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeAsExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeAsExpr(this);
	    }
	}
	
	public sealed class EqExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private EqualityOperatorSyntax equalityOperator;
	    private ExpressionSyntax right;
	
	    public EqExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EqExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public EqualityOperatorSyntax EqualityOperator 
		{ 
			get { return this.GetRed(ref this.equalityOperator, 1); } 
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.equalityOperator, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.equalityOperator;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public EqExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.EqualityOperator, this.Right);
		}
	
	    public EqExprSyntax WithEqualityOperator(EqualityOperatorSyntax equalityOperator)
		{
			return this.Update(this.Left, EqualityOperator, this.Right);
		}
	
	    public EqExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.EqualityOperator, Right);
		}
	
	    public EqExprSyntax Update(ExpressionSyntax left, EqualityOperatorSyntax equalityOperator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.EqualityOperator != equalityOperator ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.EqExpr(left, equalityOperator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EqExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEqExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEqExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitEqExpr(this);
	    }
	}
	
	public sealed class AndExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public AndExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AndExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TAmpersand 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.AndExprGreen)this.Green;
				var greenToken = green.TAmpersand;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public AndExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TAmpersand, this.Right);
		}
	
	    public AndExprSyntax WithTAmpersand(SyntaxToken tAmpersand)
		{
			return this.Update(this.Left, TAmpersand, this.Right);
		}
	
	    public AndExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TAmpersand, Right);
		}
	
	    public AndExprSyntax Update(ExpressionSyntax left, SyntaxToken tAmpersand, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TAmpersand != tAmpersand ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.AndExpr(left, tAmpersand, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAndExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAndExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitAndExpr(this);
	    }
	}
	
	public sealed class XorExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public XorExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public XorExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken THat 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.XorExprGreen)this.Green;
				var greenToken = green.THat;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public XorExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.THat, this.Right);
		}
	
	    public XorExprSyntax WithTHat(SyntaxToken tHat)
		{
			return this.Update(this.Left, THat, this.Right);
		}
	
	    public XorExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.THat, Right);
		}
	
	    public XorExprSyntax Update(ExpressionSyntax left, SyntaxToken tHat, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.THat != tHat ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.XorExpr(left, tHat, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XorExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitXorExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitXorExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitXorExpr(this);
	    }
	}
	
	public sealed class OrExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public OrExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OrExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TBar 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.OrExprGreen)this.Green;
				var greenToken = green.TBar;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public OrExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TBar, this.Right);
		}
	
	    public OrExprSyntax WithTBar(SyntaxToken tBar)
		{
			return this.Update(this.Left, TBar, this.Right);
		}
	
	    public OrExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TBar, Right);
		}
	
	    public OrExprSyntax Update(ExpressionSyntax left, SyntaxToken tBar, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TBar != tBar ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.OrExpr(left, tBar, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOrExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOrExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitOrExpr(this);
	    }
	}
	
	public sealed class AndAlsoExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public AndAlsoExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AndAlsoExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TAndAlso 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.AndAlsoExprGreen)this.Green;
				var greenToken = green.TAndAlso;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public AndAlsoExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TAndAlso, this.Right);
		}
	
	    public AndAlsoExprSyntax WithTAndAlso(SyntaxToken tAndAlso)
		{
			return this.Update(this.Left, TAndAlso, this.Right);
		}
	
	    public AndAlsoExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TAndAlso, Right);
		}
	
	    public AndAlsoExprSyntax Update(ExpressionSyntax left, SyntaxToken tAndAlso, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TAndAlso != tAndAlso ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.AndAlsoExpr(left, tAndAlso, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndAlsoExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAndAlsoExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAndAlsoExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitAndAlsoExpr(this);
	    }
	}
	
	public sealed class OrElseExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public OrElseExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OrElseExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TOrElse 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.OrElseExprGreen)this.Green;
				var greenToken = green.TOrElse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public OrElseExprSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TOrElse, this.Right);
		}
	
	    public OrElseExprSyntax WithTOrElse(SyntaxToken tOrElse)
		{
			return this.Update(this.Left, TOrElse, this.Right);
		}
	
	    public OrElseExprSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TOrElse, Right);
		}
	
	    public OrElseExprSyntax Update(ExpressionSyntax left, SyntaxToken tOrElse, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TOrElse != tOrElse ||
				this.Right != right)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.OrElseExpr(left, tOrElse, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrElseExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOrElseExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOrElseExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitOrElseExpr(this);
	    }
	}
	
	public sealed class CoalExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax value;
	    private ExpressionSyntax whenNull;
	
	    public CoalExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CoalExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 0); } 
		}
	    public SyntaxToken TQuestionQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CoalExprGreen)this.Green;
				var greenToken = green.TQuestionQuestion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax WhenNull 
		{ 
			get { return this.GetRed(ref this.whenNull, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.value, 0);
				case 2: return this.GetRed(ref this.whenNull, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.value;
				case 2: return this.whenNull;
				default: return null;
	        }
	    }
	
	    public CoalExprSyntax WithValue(ExpressionSyntax value)
		{
			return this.Update(Value, this.TQuestionQuestion, this.WhenNull);
		}
	
	    public CoalExprSyntax WithTQuestionQuestion(SyntaxToken tQuestionQuestion)
		{
			return this.Update(this.Value, TQuestionQuestion, this.WhenNull);
		}
	
	    public CoalExprSyntax WithWhenNull(ExpressionSyntax whenNull)
		{
			return this.Update(this.Value, this.TQuestionQuestion, WhenNull);
		}
	
	    public CoalExprSyntax Update(ExpressionSyntax value, SyntaxToken tQuestionQuestion, ExpressionSyntax whenNull)
	    {
	        if (this.Value != value ||
				this.TQuestionQuestion != tQuestionQuestion ||
				this.WhenNull != whenNull)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.CoalExpr(value, tQuestionQuestion, whenNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CoalExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCoalExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCoalExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitCoalExpr(this);
	    }
	}
	
	public sealed class CondExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax condition;
	    private ExpressionSyntax whenTrue;
	    private ExpressionSyntax whenFalse;
	
	    public CondExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CondExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 0); } 
		}
	    public SyntaxToken TQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CondExprGreen)this.Green;
				var greenToken = green.TQuestion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax WhenTrue 
		{ 
			get { return this.GetRed(ref this.whenTrue, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CondExprGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public ExpressionSyntax WhenFalse 
		{ 
			get { return this.GetRed(ref this.whenFalse, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.condition, 0);
				case 2: return this.GetRed(ref this.whenTrue, 2);
				case 4: return this.GetRed(ref this.whenFalse, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.condition;
				case 2: return this.whenTrue;
				case 4: return this.whenFalse;
				default: return null;
	        }
	    }
	
	    public CondExprSyntax WithCondition(ExpressionSyntax condition)
		{
			return this.Update(Condition, this.TQuestion, this.WhenTrue, this.TColon, this.WhenFalse);
		}
	
	    public CondExprSyntax WithTQuestion(SyntaxToken tQuestion)
		{
			return this.Update(this.Condition, TQuestion, this.WhenTrue, this.TColon, this.WhenFalse);
		}
	
	    public CondExprSyntax WithWhenTrue(ExpressionSyntax whenTrue)
		{
			return this.Update(this.Condition, this.TQuestion, WhenTrue, this.TColon, this.WhenFalse);
		}
	
	    public CondExprSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Condition, this.TQuestion, this.WhenTrue, TColon, this.WhenFalse);
		}
	
	    public CondExprSyntax WithWhenFalse(ExpressionSyntax whenFalse)
		{
			return this.Update(this.Condition, this.TQuestion, this.WhenTrue, this.TColon, WhenFalse);
		}
	
	    public CondExprSyntax Update(ExpressionSyntax condition, SyntaxToken tQuestion, ExpressionSyntax whenTrue, SyntaxToken tColon, ExpressionSyntax whenFalse)
	    {
	        if (this.Condition != condition ||
				this.TQuestion != tQuestion ||
				this.WhenTrue != whenTrue ||
				this.TColon != tColon ||
				this.WhenFalse != whenFalse)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.CondExpr(condition, tQuestion, whenTrue, tColon, whenFalse);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CondExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCondExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCondExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitCondExpr(this);
	    }
	}
	
	public sealed class AssignExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax target;
	    private ExpressionSyntax value;
	
	    public AssignExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssignExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 0); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.AssignExprGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.target, 0);
				case 2: return this.GetRed(ref this.value, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.target;
				case 2: return this.value;
				default: return null;
	        }
	    }
	
	    public AssignExprSyntax WithTarget(ExpressionSyntax target)
		{
			return this.Update(Target, this.TAssign, this.Value);
		}
	
	    public AssignExprSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.Target, TAssign, this.Value);
		}
	
	    public AssignExprSyntax WithValue(ExpressionSyntax value)
		{
			return this.Update(this.Target, this.TAssign, Value);
		}
	
	    public AssignExprSyntax Update(ExpressionSyntax target, SyntaxToken tAssign, ExpressionSyntax value)
	    {
	        if (this.Target != target ||
				this.TAssign != tAssign ||
				this.Value != value)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.AssignExpr(target, tAssign, value);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssignExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssignExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitAssignExpr(this);
	    }
	}
	
	public sealed class CompAssignExprSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax target;
	    private CompoundAssignmentOperatorSyntax compoundAssignmentOperator;
	    private ExpressionSyntax value;
	
	    public CompAssignExprSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompAssignExprSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 0); } 
		}
	    public CompoundAssignmentOperatorSyntax CompoundAssignmentOperator 
		{ 
			get { return this.GetRed(ref this.compoundAssignmentOperator, 1); } 
		}
	    public ExpressionSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.target, 0);
				case 1: return this.GetRed(ref this.compoundAssignmentOperator, 1);
				case 2: return this.GetRed(ref this.value, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.target;
				case 1: return this.compoundAssignmentOperator;
				case 2: return this.value;
				default: return null;
	        }
	    }
	
	    public CompAssignExprSyntax WithTarget(ExpressionSyntax target)
		{
			return this.Update(Target, this.CompoundAssignmentOperator, this.Value);
		}
	
	    public CompAssignExprSyntax WithCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax compoundAssignmentOperator)
		{
			return this.Update(this.Target, CompoundAssignmentOperator, this.Value);
		}
	
	    public CompAssignExprSyntax WithValue(ExpressionSyntax value)
		{
			return this.Update(this.Target, this.CompoundAssignmentOperator, Value);
		}
	
	    public CompAssignExprSyntax Update(ExpressionSyntax target, CompoundAssignmentOperatorSyntax compoundAssignmentOperator, ExpressionSyntax value)
	    {
	        if (this.Target != target ||
				this.CompoundAssignmentOperator != compoundAssignmentOperator ||
				this.Value != value)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.CompAssignExpr(target, compoundAssignmentOperator, value);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompAssignExprSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompAssignExpr(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompAssignExpr(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitCompAssignExpr(this);
	    }
	}
	
	public sealed class ArgumentListSyntax : CoreSyntaxNode
	{
	    private SyntaxNode argumentExpression;
	
	    public ArgumentListSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArgumentListSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ArgumentExpressionSyntax> ArgumentExpression 
		{ 
			get
			{
				var red = this.GetRed(ref this.argumentExpression, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ArgumentExpressionSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.argumentExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.argumentExpression;
				default: return null;
	        }
	    }
	
	    public ArgumentListSyntax WithArgumentExpression(Microsoft.CodeAnalysis.SeparatedSyntaxList<ArgumentExpressionSyntax> argumentExpression)
		{
			return this.Update(ArgumentExpression);
		}
	
	    public ArgumentListSyntax AddArgumentExpression(params ArgumentExpressionSyntax[] argumentExpression)
		{
			return this.WithArgumentExpression(this.ArgumentExpression.AddRange(argumentExpression));
		}
	
	    public ArgumentListSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<ArgumentExpressionSyntax> argumentExpression)
	    {
	        if (this.ArgumentExpression != argumentExpression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ArgumentList(argumentExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgumentListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArgumentList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArgumentList(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitArgumentList(this);
	    }
	}
	
	public sealed class ArgumentExpressionSyntax : CoreSyntaxNode
	{
	    private NameSyntax name;
	    private ExpressionSyntax expression;
	
	    public ArgumentExpressionSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArgumentExpressionSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ArgumentExpressionGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public ArgumentExpressionSyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.TColon, this.Expression);
		}
	
	    public ArgumentExpressionSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Name, TColon, this.Expression);
		}
	
	    public ArgumentExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.Name, this.TColon, Expression);
		}
	
	    public ArgumentExpressionSyntax Update(NameSyntax name, SyntaxToken tColon, ExpressionSyntax expression)
	    {
	        if (this.Name != name ||
				this.TColon != tColon ||
				this.Expression != expression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ArgumentExpression(name, tColon, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgumentExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArgumentExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArgumentExpression(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitArgumentExpression(this);
	    }
	}
	
	public sealed class InitializerExpressionSyntax : CoreSyntaxNode
	{
	    private FieldInitializerExpressionsSyntax fieldInitializerExpressions;
	    private CollectionInitializerExpressionsSyntax collectionInitializerExpressions;
	    private DictionaryInitializerExpressionsSyntax dictionaryInitializerExpressions;
	
	    public InitializerExpressionSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InitializerExpressionSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FieldInitializerExpressionsSyntax FieldInitializerExpressions 
		{ 
			get { return this.GetRed(ref this.fieldInitializerExpressions, 0); } 
		}
	    public CollectionInitializerExpressionsSyntax CollectionInitializerExpressions 
		{ 
			get { return this.GetRed(ref this.collectionInitializerExpressions, 1); } 
		}
	    public DictionaryInitializerExpressionsSyntax DictionaryInitializerExpressions 
		{ 
			get { return this.GetRed(ref this.dictionaryInitializerExpressions, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.fieldInitializerExpressions, 0);
				case 1: return this.GetRed(ref this.collectionInitializerExpressions, 1);
				case 2: return this.GetRed(ref this.dictionaryInitializerExpressions, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.fieldInitializerExpressions;
				case 1: return this.collectionInitializerExpressions;
				case 2: return this.dictionaryInitializerExpressions;
				default: return null;
	        }
	    }
	
	    public InitializerExpressionSyntax WithFieldInitializerExpressions(FieldInitializerExpressionsSyntax fieldInitializerExpressions)
		{
			return this.Update(fieldInitializerExpressions);
		}
	
	    public InitializerExpressionSyntax WithCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax collectionInitializerExpressions)
		{
			return this.Update(collectionInitializerExpressions);
		}
	
	    public InitializerExpressionSyntax WithDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax dictionaryInitializerExpressions)
		{
			return this.Update(dictionaryInitializerExpressions);
		}
	
	    public InitializerExpressionSyntax Update(FieldInitializerExpressionsSyntax fieldInitializerExpressions)
	    {
	        if (this.FieldInitializerExpressions != fieldInitializerExpressions)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.InitializerExpression(fieldInitializerExpressions);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InitializerExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public InitializerExpressionSyntax Update(CollectionInitializerExpressionsSyntax collectionInitializerExpressions)
	    {
	        if (this.CollectionInitializerExpressions != collectionInitializerExpressions)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.InitializerExpression(collectionInitializerExpressions);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InitializerExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public InitializerExpressionSyntax Update(DictionaryInitializerExpressionsSyntax dictionaryInitializerExpressions)
	    {
	        if (this.DictionaryInitializerExpressions != dictionaryInitializerExpressions)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.InitializerExpression(dictionaryInitializerExpressions);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InitializerExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInitializerExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInitializerExpression(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitInitializerExpression(this);
	    }
	}
	
	public sealed class FieldInitializerExpressionsSyntax : CoreSyntaxNode
	{
	    private SyntaxNode fieldInitializerExpression;
	
	    public FieldInitializerExpressionsSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldInitializerExpressionsSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<FieldInitializerExpressionSyntax> FieldInitializerExpression 
		{ 
			get
			{
				var red = this.GetRed(ref this.fieldInitializerExpression, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<FieldInitializerExpressionSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.fieldInitializerExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.fieldInitializerExpression;
				default: return null;
	        }
	    }
	
	    public FieldInitializerExpressionsSyntax WithFieldInitializerExpression(Microsoft.CodeAnalysis.SeparatedSyntaxList<FieldInitializerExpressionSyntax> fieldInitializerExpression)
		{
			return this.Update(FieldInitializerExpression);
		}
	
	    public FieldInitializerExpressionsSyntax AddFieldInitializerExpression(params FieldInitializerExpressionSyntax[] fieldInitializerExpression)
		{
			return this.WithFieldInitializerExpression(this.FieldInitializerExpression.AddRange(fieldInitializerExpression));
		}
	
	    public FieldInitializerExpressionsSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<FieldInitializerExpressionSyntax> fieldInitializerExpression)
	    {
	        if (this.FieldInitializerExpression != fieldInitializerExpression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.FieldInitializerExpressions(fieldInitializerExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldInitializerExpressionsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldInitializerExpressions(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldInitializerExpressions(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldInitializerExpressions(this);
	    }
	}
	
	public sealed class FieldInitializerExpressionSyntax : CoreSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ExpressionSyntax expression;
	
	    public FieldInitializerExpressionSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldInitializerExpressionSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.FieldInitializerExpressionGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public FieldInitializerExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TAssign, this.Expression);
		}
	
	    public FieldInitializerExpressionSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.Identifier, TAssign, this.Expression);
		}
	
	    public FieldInitializerExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.Identifier, this.TAssign, Expression);
		}
	
	    public FieldInitializerExpressionSyntax Update(IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
	    {
	        if (this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.FieldInitializerExpression(identifier, tAssign, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldInitializerExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldInitializerExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldInitializerExpression(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldInitializerExpression(this);
	    }
	}
	
	public sealed class CollectionInitializerExpressionsSyntax : CoreSyntaxNode
	{
	    private SyntaxNode expression;
	
	    public CollectionInitializerExpressionsSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CollectionInitializerExpressionsSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ExpressionSyntax> Expression 
		{ 
			get
			{
				var red = this.GetRed(ref this.expression, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ExpressionSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				default: return null;
	        }
	    }
	
	    public CollectionInitializerExpressionsSyntax WithExpression(Microsoft.CodeAnalysis.SeparatedSyntaxList<ExpressionSyntax> expression)
		{
			return this.Update(Expression);
		}
	
	    public CollectionInitializerExpressionsSyntax AddExpression(params ExpressionSyntax[] expression)
		{
			return this.WithExpression(this.Expression.AddRange(expression));
		}
	
	    public CollectionInitializerExpressionsSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<ExpressionSyntax> expression)
	    {
	        if (this.Expression != expression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.CollectionInitializerExpressions(expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionInitializerExpressionsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCollectionInitializerExpressions(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCollectionInitializerExpressions(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitCollectionInitializerExpressions(this);
	    }
	}
	
	public sealed class DictionaryInitializerExpressionsSyntax : CoreSyntaxNode
	{
	    private SyntaxNode dictionaryInitializerExpression;
	
	    public DictionaryInitializerExpressionsSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DictionaryInitializerExpressionsSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<DictionaryInitializerExpressionSyntax> DictionaryInitializerExpression 
		{ 
			get
			{
				var red = this.GetRed(ref this.dictionaryInitializerExpression, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<DictionaryInitializerExpressionSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.dictionaryInitializerExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.dictionaryInitializerExpression;
				default: return null;
	        }
	    }
	
	    public DictionaryInitializerExpressionsSyntax WithDictionaryInitializerExpression(Microsoft.CodeAnalysis.SeparatedSyntaxList<DictionaryInitializerExpressionSyntax> dictionaryInitializerExpression)
		{
			return this.Update(DictionaryInitializerExpression);
		}
	
	    public DictionaryInitializerExpressionsSyntax AddDictionaryInitializerExpression(params DictionaryInitializerExpressionSyntax[] dictionaryInitializerExpression)
		{
			return this.WithDictionaryInitializerExpression(this.DictionaryInitializerExpression.AddRange(dictionaryInitializerExpression));
		}
	
	    public DictionaryInitializerExpressionsSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<DictionaryInitializerExpressionSyntax> dictionaryInitializerExpression)
	    {
	        if (this.DictionaryInitializerExpression != dictionaryInitializerExpression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.DictionaryInitializerExpressions(dictionaryInitializerExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DictionaryInitializerExpressionsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDictionaryInitializerExpressions(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDictionaryInitializerExpressions(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitDictionaryInitializerExpressions(this);
	    }
	}
	
	public sealed class DictionaryInitializerExpressionSyntax : CoreSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ExpressionSyntax expression;
	
	    public DictionaryInitializerExpressionSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DictionaryInitializerExpressionSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.DictionaryInitializerExpressionGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.DictionaryInitializerExpressionGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.DictionaryInitializerExpressionGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.identifier, 1);
				case 4: return this.GetRed(ref this.expression, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.identifier;
				case 4: return this.expression;
				default: return null;
	        }
	    }
	
	    public DictionaryInitializerExpressionSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.Identifier, this.TCloseBracket, this.TAssign, this.Expression);
		}
	
	    public DictionaryInitializerExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TOpenBracket, Identifier, this.TCloseBracket, this.TAssign, this.Expression);
		}
	
	    public DictionaryInitializerExpressionSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.Identifier, TCloseBracket, this.TAssign, this.Expression);
		}
	
	    public DictionaryInitializerExpressionSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.TOpenBracket, this.Identifier, this.TCloseBracket, TAssign, this.Expression);
		}
	
	    public DictionaryInitializerExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TOpenBracket, this.Identifier, this.TCloseBracket, this.TAssign, Expression);
		}
	
	    public DictionaryInitializerExpressionSyntax Update(SyntaxToken tOpenBracket, IdentifierSyntax identifier, SyntaxToken tCloseBracket, SyntaxToken tAssign, ExpressionSyntax expression)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.Identifier != identifier ||
				this.TCloseBracket != tCloseBracket ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.DictionaryInitializerExpression(tOpenBracket, identifier, tCloseBracket, tAssign, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DictionaryInitializerExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDictionaryInitializerExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDictionaryInitializerExpression(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitDictionaryInitializerExpression(this);
	    }
	}
	
	public sealed class DotOperatorSyntax : CoreSyntaxNode
	{
	
	    public DotOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DotOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken DotOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.DotOperatorGreen)this.Green;
				var greenToken = green.DotOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public DotOperatorSyntax WithDotOperator(SyntaxToken dotOperator)
		{
			return this.Update(DotOperator);
		}
	
	    public DotOperatorSyntax Update(SyntaxToken dotOperator)
	    {
	        if (this.DotOperator != dotOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.DotOperator(dotOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DotOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDotOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDotOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitDotOperator(this);
	    }
	}
	
	public sealed class IndexerOperatorSyntax : CoreSyntaxNode
	{
	
	    public IndexerOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IndexerOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IndexerOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.IndexerOperatorGreen)this.Green;
				var greenToken = green.IndexerOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public IndexerOperatorSyntax WithIndexerOperator(SyntaxToken indexerOperator)
		{
			return this.Update(IndexerOperator);
		}
	
	    public IndexerOperatorSyntax Update(SyntaxToken indexerOperator)
	    {
	        if (this.IndexerOperator != indexerOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.IndexerOperator(indexerOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IndexerOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIndexerOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIndexerOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitIndexerOperator(this);
	    }
	}
	
	public sealed class PostfixOperatorSyntax : CoreSyntaxNode
	{
	
	    public PostfixOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PostfixOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken PostfixOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.PostfixOperatorGreen)this.Green;
				var greenToken = green.PostfixOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public PostfixOperatorSyntax WithPostfixOperator(SyntaxToken postfixOperator)
		{
			return this.Update(PostfixOperator);
		}
	
	    public PostfixOperatorSyntax Update(SyntaxToken postfixOperator)
	    {
	        if (this.PostfixOperator != postfixOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.PostfixOperator(postfixOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PostfixOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPostfixOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPostfixOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitPostfixOperator(this);
	    }
	}
	
	public sealed class UnaryOperatorSyntax : CoreSyntaxNode
	{
	
	    public UnaryOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UnaryOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken UnaryOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.UnaryOperatorGreen)this.Green;
				var greenToken = green.UnaryOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public UnaryOperatorSyntax WithUnaryOperator(SyntaxToken unaryOperator)
		{
			return this.Update(UnaryOperator);
		}
	
	    public UnaryOperatorSyntax Update(SyntaxToken unaryOperator)
	    {
	        if (this.UnaryOperator != unaryOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.UnaryOperator(unaryOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnaryOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUnaryOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUnaryOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitUnaryOperator(this);
	    }
	}
	
	public sealed class MultiplicativeOperatorSyntax : CoreSyntaxNode
	{
	
	    public MultiplicativeOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MultiplicativeOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken MultiplicativeOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.MultiplicativeOperatorGreen)this.Green;
				var greenToken = green.MultiplicativeOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public MultiplicativeOperatorSyntax WithMultiplicativeOperator(SyntaxToken multiplicativeOperator)
		{
			return this.Update(MultiplicativeOperator);
		}
	
	    public MultiplicativeOperatorSyntax Update(SyntaxToken multiplicativeOperator)
	    {
	        if (this.MultiplicativeOperator != multiplicativeOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.MultiplicativeOperator(multiplicativeOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiplicativeOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMultiplicativeOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMultiplicativeOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitMultiplicativeOperator(this);
	    }
	}
	
	public sealed class AdditiveOperatorSyntax : CoreSyntaxNode
	{
	
	    public AdditiveOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AdditiveOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken AdditiveOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.AdditiveOperatorGreen)this.Green;
				var greenToken = green.AdditiveOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public AdditiveOperatorSyntax WithAdditiveOperator(SyntaxToken additiveOperator)
		{
			return this.Update(AdditiveOperator);
		}
	
	    public AdditiveOperatorSyntax Update(SyntaxToken additiveOperator)
	    {
	        if (this.AdditiveOperator != additiveOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.AdditiveOperator(additiveOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AdditiveOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAdditiveOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAdditiveOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitAdditiveOperator(this);
	    }
	}
	
	public sealed class ShiftOperatorSyntax : CoreSyntaxNode
	{
	    private LeftShiftOperatorSyntax leftShiftOperator;
	    private RightShiftOperatorSyntax rightShiftOperator;
	
	    public ShiftOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ShiftOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LeftShiftOperatorSyntax LeftShiftOperator 
		{ 
			get { return this.GetRed(ref this.leftShiftOperator, 0); } 
		}
	    public RightShiftOperatorSyntax RightShiftOperator 
		{ 
			get { return this.GetRed(ref this.rightShiftOperator, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leftShiftOperator, 0);
				case 1: return this.GetRed(ref this.rightShiftOperator, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leftShiftOperator;
				case 1: return this.rightShiftOperator;
				default: return null;
	        }
	    }
	
	    public ShiftOperatorSyntax WithLeftShiftOperator(LeftShiftOperatorSyntax leftShiftOperator)
		{
			return this.Update(leftShiftOperator);
		}
	
	    public ShiftOperatorSyntax WithRightShiftOperator(RightShiftOperatorSyntax rightShiftOperator)
		{
			return this.Update(rightShiftOperator);
		}
	
	    public ShiftOperatorSyntax Update(LeftShiftOperatorSyntax leftShiftOperator)
	    {
	        if (this.LeftShiftOperator != leftShiftOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ShiftOperator(leftShiftOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ShiftOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ShiftOperatorSyntax Update(RightShiftOperatorSyntax rightShiftOperator)
	    {
	        if (this.RightShiftOperator != rightShiftOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ShiftOperator(rightShiftOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ShiftOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitShiftOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitShiftOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitShiftOperator(this);
	    }
	}
	
	public sealed class LeftShiftOperatorSyntax : CoreSyntaxNode
	{
	
	    public LeftShiftOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LeftShiftOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken First 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.LeftShiftOperatorGreen)this.Green;
				var greenToken = green.First;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken Second 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.LeftShiftOperatorGreen)this.Green;
				var greenToken = green.Second;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public LeftShiftOperatorSyntax WithFirst(SyntaxToken first)
		{
			return this.Update(First, this.Second);
		}
	
	    public LeftShiftOperatorSyntax WithSecond(SyntaxToken second)
		{
			return this.Update(this.First, Second);
		}
	
	    public LeftShiftOperatorSyntax Update(SyntaxToken first, SyntaxToken second)
	    {
	        if (this.First != first ||
				this.Second != second)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.LeftShiftOperator(first, second);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LeftShiftOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLeftShiftOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLeftShiftOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitLeftShiftOperator(this);
	    }
	}
	
	public sealed class RightShiftOperatorSyntax : CoreSyntaxNode
	{
	
	    public RightShiftOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RightShiftOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken First 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.RightShiftOperatorGreen)this.Green;
				var greenToken = green.First;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken Second 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.RightShiftOperatorGreen)this.Green;
				var greenToken = green.Second;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public RightShiftOperatorSyntax WithFirst(SyntaxToken first)
		{
			return this.Update(First, this.Second);
		}
	
	    public RightShiftOperatorSyntax WithSecond(SyntaxToken second)
		{
			return this.Update(this.First, Second);
		}
	
	    public RightShiftOperatorSyntax Update(SyntaxToken first, SyntaxToken second)
	    {
	        if (this.First != first ||
				this.Second != second)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.RightShiftOperator(first, second);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RightShiftOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRightShiftOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRightShiftOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitRightShiftOperator(this);
	    }
	}
	
	public sealed class RelationalOperatorSyntax : CoreSyntaxNode
	{
	
	    public RelationalOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RelationalOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken RelationalOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.RelationalOperatorGreen)this.Green;
				var greenToken = green.RelationalOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public RelationalOperatorSyntax WithRelationalOperator(SyntaxToken relationalOperator)
		{
			return this.Update(RelationalOperator);
		}
	
	    public RelationalOperatorSyntax Update(SyntaxToken relationalOperator)
	    {
	        if (this.RelationalOperator != relationalOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.RelationalOperator(relationalOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RelationalOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRelationalOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRelationalOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitRelationalOperator(this);
	    }
	}
	
	public sealed class EqualityOperatorSyntax : CoreSyntaxNode
	{
	
	    public EqualityOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EqualityOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken EqualityOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.EqualityOperatorGreen)this.Green;
				var greenToken = green.EqualityOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public EqualityOperatorSyntax WithEqualityOperator(SyntaxToken equalityOperator)
		{
			return this.Update(EqualityOperator);
		}
	
	    public EqualityOperatorSyntax Update(SyntaxToken equalityOperator)
	    {
	        if (this.EqualityOperator != equalityOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.EqualityOperator(equalityOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EqualityOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEqualityOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEqualityOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitEqualityOperator(this);
	    }
	}
	
	public sealed class CompoundAssignmentOperatorSyntax : CoreSyntaxNode
	{
	
	    public CompoundAssignmentOperatorSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompoundAssignmentOperatorSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken CompoundAssignmentOperator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.CompoundAssignmentOperatorGreen)this.Green;
				var greenToken = green.CompoundAssignmentOperator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public CompoundAssignmentOperatorSyntax WithCompoundAssignmentOperator(SyntaxToken compoundAssignmentOperator)
		{
			return this.Update(CompoundAssignmentOperator);
		}
	
	    public CompoundAssignmentOperatorSyntax Update(SyntaxToken compoundAssignmentOperator)
	    {
	        if (this.CompoundAssignmentOperator != compoundAssignmentOperator)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.CompoundAssignmentOperator(compoundAssignmentOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompoundAssignmentOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompoundAssignmentOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompoundAssignmentOperator(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitCompoundAssignmentOperator(this);
	    }
	}
	
	public sealed class ReturnTypeSyntax : CoreSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private VoidTypeSyntax voidType;
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public VoidTypeSyntax VoidType 
		{ 
			get { return this.GetRed(ref this.voidType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.voidType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.voidType;
				default: return null;
	        }
	    }
	
	    public ReturnTypeSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(typeReference);
		}
	
	    public ReturnTypeSyntax WithVoidType(VoidTypeSyntax voidType)
		{
			return this.Update(voidType);
		}
	
	    public ReturnTypeSyntax Update(TypeReferenceSyntax typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ReturnType(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ReturnTypeSyntax Update(VoidTypeSyntax voidType)
	    {
	        if (this.VoidType != voidType)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnType(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnType(this);
	    }
	}
	
	public abstract class TypeReferenceSyntax : CoreSyntaxNode
	{
	    protected TypeReferenceSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected TypeReferenceSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class PrimitiveTypeRefSyntax : TypeReferenceSyntax
	{
	    private PrimitiveTypeSyntax primitiveType;
	
	    public PrimitiveTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PrimitiveTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax PrimitiveType 
		{ 
			get { return this.GetRed(ref this.primitiveType, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.primitiveType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.primitiveType;
				default: return null;
	        }
	    }
	
	    public PrimitiveTypeRefSyntax WithPrimitiveType(PrimitiveTypeSyntax primitiveType)
		{
			return this.Update(PrimitiveType);
		}
	
	    public PrimitiveTypeRefSyntax Update(PrimitiveTypeSyntax primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.PrimitiveTypeRef(primitiveType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPrimitiveTypeRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPrimitiveTypeRef(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitPrimitiveTypeRef(this);
	    }
	}
	
	public sealed class GenericTypeRefSyntax : TypeReferenceSyntax
	{
	    private NamedTypeSyntax namedType;
	    private GenericTypeArgumentsSyntax genericTypeArguments;
	
	    public GenericTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NamedTypeSyntax NamedType 
		{ 
			get { return this.GetRed(ref this.namedType, 0); } 
		}
	    public GenericTypeArgumentsSyntax GenericTypeArguments 
		{ 
			get { return this.GetRed(ref this.genericTypeArguments, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.namedType, 0);
				case 1: return this.GetRed(ref this.genericTypeArguments, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.namedType;
				case 1: return this.genericTypeArguments;
				default: return null;
	        }
	    }
	
	    public GenericTypeRefSyntax WithNamedType(NamedTypeSyntax namedType)
		{
			return this.Update(NamedType, this.GenericTypeArguments);
		}
	
	    public GenericTypeRefSyntax WithGenericTypeArguments(GenericTypeArgumentsSyntax genericTypeArguments)
		{
			return this.Update(this.NamedType, GenericTypeArguments);
		}
	
	    public GenericTypeRefSyntax Update(NamedTypeSyntax namedType, GenericTypeArgumentsSyntax genericTypeArguments)
	    {
	        if (this.NamedType != namedType ||
				this.GenericTypeArguments != genericTypeArguments)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.GenericTypeRef(namedType, genericTypeArguments);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericTypeRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericTypeRef(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericTypeRef(this);
	    }
	}
	
	public sealed class NamedTypeRefSyntax : TypeReferenceSyntax
	{
	    private QualifierSyntax qualifier;
	
	    public NamedTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamedTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public NamedTypeRefSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public NamedTypeRefSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.NamedTypeRef(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamedTypeRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamedTypeRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamedTypeRef(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitNamedTypeRef(this);
	    }
	}
	
	public sealed class ArrayTypeRefSyntax : TypeReferenceSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public ArrayTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrayTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ArrayTypeRefGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ArrayTypeRefGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public ArrayTypeRefSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.TOpenBracket, this.TCloseBracket);
		}
	
	    public ArrayTypeRefSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.TypeReference, TOpenBracket, this.TCloseBracket);
		}
	
	    public ArrayTypeRefSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TypeReference, this.TOpenBracket, TCloseBracket);
		}
	
	    public ArrayTypeRefSyntax Update(TypeReferenceSyntax typeReference, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
	    {
	        if (this.TypeReference != typeReference ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ArrayTypeRef(typeReference, tOpenBracket, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrayTypeRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrayTypeRef(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitArrayTypeRef(this);
	    }
	}
	
	public sealed class NullableTypeRefSyntax : TypeReferenceSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public NullableTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableTypeRefSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public SyntaxToken TQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NullableTypeRefGreen)this.Green;
				var greenToken = green.TQuestion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public NullableTypeRefSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.TQuestion);
		}
	
	    public NullableTypeRefSyntax WithTQuestion(SyntaxToken tQuestion)
		{
			return this.Update(this.TypeReference, TQuestion);
		}
	
	    public NullableTypeRefSyntax Update(TypeReferenceSyntax typeReference, SyntaxToken tQuestion)
	    {
	        if (this.TypeReference != typeReference ||
				this.TQuestion != tQuestion)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.NullableTypeRef(typeReference, tQuestion);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullableTypeRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableTypeRef(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableTypeRef(this);
	    }
	}
	
	public sealed class NamedTypeSyntax : CoreSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public NamedTypeSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamedTypeSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public NamedTypeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public NamedTypeSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.NamedType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamedTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamedType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamedType(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitNamedType(this);
	    }
	}
	
	public sealed class GenericTypeArgumentsSyntax : CoreSyntaxNode
	{
	    private SyntaxNode genericTypeArgument;
	
	    public GenericTypeArgumentsSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeArgumentsSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TLessThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.GenericTypeArgumentsGreen)this.Green;
				var greenToken = green.TLessThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<GenericTypeArgumentSyntax> GenericTypeArgument 
		{ 
			get
			{
				var red = this.GetRed(ref this.genericTypeArgument, 1);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<GenericTypeArgumentSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TGreaterThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.GenericTypeArgumentsGreen)this.Green;
				var greenToken = green.TGreaterThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.genericTypeArgument, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.genericTypeArgument;
				default: return null;
	        }
	    }
	
	    public GenericTypeArgumentsSyntax WithTLessThan(SyntaxToken tLessThan)
		{
			return this.Update(TLessThan, this.GenericTypeArgument, this.TGreaterThan);
		}
	
	    public GenericTypeArgumentsSyntax WithGenericTypeArgument(Microsoft.CodeAnalysis.SeparatedSyntaxList<GenericTypeArgumentSyntax> genericTypeArgument)
		{
			return this.Update(this.TLessThan, GenericTypeArgument, this.TGreaterThan);
		}
	
	    public GenericTypeArgumentsSyntax AddGenericTypeArgument(params GenericTypeArgumentSyntax[] genericTypeArgument)
		{
			return this.WithGenericTypeArgument(this.GenericTypeArgument.AddRange(genericTypeArgument));
		}
	
	    public GenericTypeArgumentsSyntax WithTGreaterThan(SyntaxToken tGreaterThan)
		{
			return this.Update(this.TLessThan, this.GenericTypeArgument, TGreaterThan);
		}
	
	    public GenericTypeArgumentsSyntax Update(SyntaxToken tLessThan, Microsoft.CodeAnalysis.SeparatedSyntaxList<GenericTypeArgumentSyntax> genericTypeArgument, SyntaxToken tGreaterThan)
	    {
	        if (this.TLessThan != tLessThan ||
				this.GenericTypeArgument != genericTypeArgument ||
				this.TGreaterThan != tGreaterThan)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.GenericTypeArguments(tLessThan, genericTypeArgument, tGreaterThan);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeArgumentsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericTypeArguments(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericTypeArguments(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericTypeArguments(this);
	    }
	}
	
	public sealed class GenericTypeArgumentSyntax : CoreSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	
	    public GenericTypeArgumentSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeArgumentSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public GenericTypeArgumentSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference);
		}
	
	    public GenericTypeArgumentSyntax Update(TypeReferenceSyntax typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.GenericTypeArgument(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeArgumentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericTypeArgument(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericTypeArgument(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericTypeArgument(this);
	    }
	}
	
	public sealed class PrimitiveTypeSyntax : CoreSyntaxNode
	{
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken PrimitiveType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.PrimitiveTypeGreen)this.Green;
				var greenToken = green.PrimitiveType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public PrimitiveTypeSyntax WithPrimitiveType(SyntaxToken primitiveType)
		{
			return this.Update(PrimitiveType);
		}
	
	    public PrimitiveTypeSyntax Update(SyntaxToken primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.PrimitiveType(primitiveType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPrimitiveType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPrimitiveType(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitPrimitiveType(this);
	    }
	}
	
	public sealed class VoidTypeSyntax : CoreSyntaxNode
	{
	
	    public VoidTypeSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidTypeSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.VoidTypeGreen)this.Green;
				var greenToken = green.KVoid;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public VoidTypeSyntax WithKVoid(SyntaxToken kVoid)
		{
			return this.Update(KVoid);
		}
	
	    public VoidTypeSyntax Update(SyntaxToken kVoid)
	    {
	        if (this.KVoid != kVoid)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.VoidType(kVoid);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVoidType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidType(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidType(this);
	    }
	}
	
	public sealed class NameSyntax : CoreSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public NameSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public NameSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : CoreSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public QualifiedNameSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public QualifiedNameSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : CoreSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> Identifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifier, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public QualifierSyntax WithIdentifier(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public QualifierSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public QualifierSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class IdentifierSyntax : CoreSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.Identifier;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public IdentifierSyntax WithIdentifier(SyntaxToken identifier)
		{
			return this.Update(Identifier);
		}
	
	    public IdentifierSyntax Update(SyntaxToken identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Identifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LiteralSyntax : CoreSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NullLiteralSyntax NullLiteral 
		{ 
			get { return this.GetRed(ref this.nullLiteral, 0); } 
		}
	    public BooleanLiteralSyntax BooleanLiteral 
		{ 
			get { return this.GetRed(ref this.booleanLiteral, 1); } 
		}
	    public IntegerLiteralSyntax IntegerLiteral 
		{ 
			get { return this.GetRed(ref this.integerLiteral, 2); } 
		}
	    public DecimalLiteralSyntax DecimalLiteral 
		{ 
			get { return this.GetRed(ref this.decimalLiteral, 3); } 
		}
	    public ScientificLiteralSyntax ScientificLiteral 
		{ 
			get { return this.GetRed(ref this.scientificLiteral, 4); } 
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nullLiteral, 0);
				case 1: return this.GetRed(ref this.booleanLiteral, 1);
				case 2: return this.GetRed(ref this.integerLiteral, 2);
				case 3: return this.GetRed(ref this.decimalLiteral, 3);
				case 4: return this.GetRed(ref this.scientificLiteral, 4);
				case 5: return this.GetRed(ref this.stringLiteral, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
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
	
	    public LiteralSyntax WithNullLiteral(NullLiteralSyntax nullLiteral)
		{
			return this.Update(nullLiteral);
		}
	
	    public LiteralSyntax WithBooleanLiteral(BooleanLiteralSyntax booleanLiteral)
		{
			return this.Update(booleanLiteral);
		}
	
	    public LiteralSyntax WithIntegerLiteral(IntegerLiteralSyntax integerLiteral)
		{
			return this.Update(integerLiteral);
		}
	
	    public LiteralSyntax WithDecimalLiteral(DecimalLiteralSyntax decimalLiteral)
		{
			return this.Update(decimalLiteral);
		}
	
	    public LiteralSyntax WithScientificLiteral(ScientificLiteralSyntax scientificLiteral)
		{
			return this.Update(scientificLiteral);
		}
	
	    public LiteralSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(stringLiteral);
		}
	
	    public LiteralSyntax Update(NullLiteralSyntax nullLiteral)
	    {
	        if (this.NullLiteral != nullLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(BooleanLiteralSyntax booleanLiteral)
	    {
	        if (this.BooleanLiteral != booleanLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(IntegerLiteralSyntax integerLiteral)
	    {
	        if (this.IntegerLiteral != integerLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(DecimalLiteralSyntax decimalLiteral)
	    {
	        if (this.DecimalLiteral != decimalLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(ScientificLiteralSyntax scientificLiteral)
	    {
	        if (this.ScientificLiteral != scientificLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(StringLiteralSyntax stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : CoreSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
				var greenToken = green.KNull;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public NullLiteralSyntax WithKNull(SyntaxToken kNull)
		{
			return this.Update(KNull);
		}
	
	    public NullLiteralSyntax Update(SyntaxToken kNull)
	    {
	        if (this.KNull != kNull)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : CoreSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
				var greenToken = green.BooleanLiteral;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public BooleanLiteralSyntax WithBooleanLiteral(SyntaxToken booleanLiteral)
		{
			return this.Update(BooleanLiteral);
		}
	
	    public BooleanLiteralSyntax Update(SyntaxToken booleanLiteral)
	    {
	        if (this.BooleanLiteral != booleanLiteral)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : CoreSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
				var greenToken = green.LInteger;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public IntegerLiteralSyntax WithLInteger(SyntaxToken lInteger)
		{
			return this.Update(LInteger);
		}
	
	    public IntegerLiteralSyntax Update(SyntaxToken lInteger)
	    {
	        if (this.LInteger != lInteger)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : CoreSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
				var greenToken = green.LDecimal;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public DecimalLiteralSyntax WithLDecimal(SyntaxToken lDecimal)
		{
			return this.Update(LDecimal);
		}
	
	    public DecimalLiteralSyntax Update(SyntaxToken lDecimal)
	    {
	        if (this.LDecimal != lDecimal)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : CoreSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
				var greenToken = green.LScientific;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public ScientificLiteralSyntax WithLScientific(SyntaxToken lScientific)
		{
			return this.Update(LScientific);
		}
	
	    public ScientificLiteralSyntax Update(SyntaxToken lScientific)
	    {
	        if (this.LScientific != lScientific)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : CoreSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, CoreSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, CoreSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LRegularString 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Core.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
				var greenToken = green.LRegularString;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public StringLiteralSyntax WithLRegularString(SyntaxToken lRegularString)
		{
			return this.Update(LRegularString);
		}
	
	    public StringLiteralSyntax Update(SyntaxToken lRegularString)
	    {
	        if (this.LRegularString != lRegularString)
	        {
	            var newNode = CoreLanguage.Instance.SyntaxFactory.StringLiteral(lRegularString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICoreSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICoreSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(ICoreSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
}

namespace MetaDslx.Languages.Core
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.Languages.Core.Syntax;
    using MetaDslx.Languages.Core.Syntax.InternalSyntax;

	public interface ICoreSyntaxVisitor
	{
	    void VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node);
		
		void VisitMain(MainSyntax node);
		
		void VisitUsingNamespace(UsingNamespaceSyntax node);
		
		void VisitStatement(StatementSyntax node);
		
		void VisitParenthesizedExpr(ParenthesizedExprSyntax node);
		
		void VisitDefaultExpr(DefaultExprSyntax node);
		
		void VisitThisExpr(ThisExprSyntax node);
		
		void VisitBaseExpr(BaseExprSyntax node);
		
		void VisitLiteralExpr(LiteralExprSyntax node);
		
		void VisitIdentifierExpr(IdentifierExprSyntax node);
		
		void VisitQualifierExpr(QualifierExprSyntax node);
		
		void VisitIndexerExpr(IndexerExprSyntax node);
		
		void VisitInvocationExpr(InvocationExprSyntax node);
		
		void VisitTypeofExpr(TypeofExprSyntax node);
		
		void VisitNameofExpr(NameofExprSyntax node);
		
		void VisitSizeofExpr(SizeofExprSyntax node);
		
		void VisitCheckedExpr(CheckedExprSyntax node);
		
		void VisitUncheckedExpr(UncheckedExprSyntax node);
		
		void VisitNewExpr(NewExprSyntax node);
		
		void VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node);
		
		void VisitUnaryExpr(UnaryExprSyntax node);
		
		void VisitTypeCastExpr(TypeCastExprSyntax node);
		
		void VisitMultExpr(MultExprSyntax node);
		
		void VisitAddExpr(AddExprSyntax node);
		
		void VisitShiftExpr(ShiftExprSyntax node);
		
		void VisitRelExpr(RelExprSyntax node);
		
		void VisitTypeIsExpr(TypeIsExprSyntax node);
		
		void VisitTypeAsExpr(TypeAsExprSyntax node);
		
		void VisitEqExpr(EqExprSyntax node);
		
		void VisitAndExpr(AndExprSyntax node);
		
		void VisitXorExpr(XorExprSyntax node);
		
		void VisitOrExpr(OrExprSyntax node);
		
		void VisitAndAlsoExpr(AndAlsoExprSyntax node);
		
		void VisitOrElseExpr(OrElseExprSyntax node);
		
		void VisitCoalExpr(CoalExprSyntax node);
		
		void VisitCondExpr(CondExprSyntax node);
		
		void VisitAssignExpr(AssignExprSyntax node);
		
		void VisitCompAssignExpr(CompAssignExprSyntax node);
		
		void VisitArgumentList(ArgumentListSyntax node);
		
		void VisitArgumentExpression(ArgumentExpressionSyntax node);
		
		void VisitInitializerExpression(InitializerExpressionSyntax node);
		
		void VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node);
		
		void VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node);
		
		void VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node);
		
		void VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node);
		
		void VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node);
		
		void VisitDotOperator(DotOperatorSyntax node);
		
		void VisitIndexerOperator(IndexerOperatorSyntax node);
		
		void VisitPostfixOperator(PostfixOperatorSyntax node);
		
		void VisitUnaryOperator(UnaryOperatorSyntax node);
		
		void VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node);
		
		void VisitAdditiveOperator(AdditiveOperatorSyntax node);
		
		void VisitShiftOperator(ShiftOperatorSyntax node);
		
		void VisitLeftShiftOperator(LeftShiftOperatorSyntax node);
		
		void VisitRightShiftOperator(RightShiftOperatorSyntax node);
		
		void VisitRelationalOperator(RelationalOperatorSyntax node);
		
		void VisitEqualityOperator(EqualityOperatorSyntax node);
		
		void VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node);
		
		void VisitReturnType(ReturnTypeSyntax node);
		
		void VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node);
		
		void VisitGenericTypeRef(GenericTypeRefSyntax node);
		
		void VisitNamedTypeRef(NamedTypeRefSyntax node);
		
		void VisitArrayTypeRef(ArrayTypeRefSyntax node);
		
		void VisitNullableTypeRef(NullableTypeRefSyntax node);
		
		void VisitNamedType(NamedTypeSyntax node);
		
		void VisitGenericTypeArguments(GenericTypeArgumentsSyntax node);
		
		void VisitGenericTypeArgument(GenericTypeArgumentSyntax node);
		
		void VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		void VisitVoidType(VoidTypeSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		void VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		void VisitScientificLiteral(ScientificLiteralSyntax node);
		
		void VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class CoreSyntaxVisitor : SyntaxVisitor, ICoreSyntaxVisitor
	{
	    public virtual void VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node)
	    {
	        this.DefaultVisit(node);
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingNamespace(UsingNamespaceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParenthesizedExpr(ParenthesizedExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefaultExpr(DefaultExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitThisExpr(ThisExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBaseExpr(BaseExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLiteralExpr(LiteralExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifierExpr(IdentifierExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifierExpr(QualifierExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIndexerExpr(IndexerExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInvocationExpr(InvocationExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeofExpr(TypeofExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNameofExpr(NameofExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSizeofExpr(SizeofExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCheckedExpr(CheckedExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUncheckedExpr(UncheckedExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNewExpr(NewExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUnaryExpr(UnaryExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeCastExpr(TypeCastExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMultExpr(MultExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAddExpr(AddExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitShiftExpr(ShiftExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRelExpr(RelExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeIsExpr(TypeIsExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeAsExpr(TypeAsExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEqExpr(EqExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAndExpr(AndExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitXorExpr(XorExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOrExpr(OrExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAndAlsoExpr(AndAlsoExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOrElseExpr(OrElseExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCoalExpr(CoalExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCondExpr(CondExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssignExpr(AssignExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompAssignExpr(CompAssignExprSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArgumentList(ArgumentListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArgumentExpression(ArgumentExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInitializerExpression(InitializerExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDotOperator(DotOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIndexerOperator(IndexerOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPostfixOperator(PostfixOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUnaryOperator(UnaryOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAdditiveOperator(AdditiveOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitShiftOperator(ShiftOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLeftShiftOperator(LeftShiftOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRightShiftOperator(RightShiftOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRelationalOperator(RelationalOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEqualityOperator(EqualityOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericTypeRef(GenericTypeRefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamedTypeRef(NamedTypeRefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrayTypeRef(ArrayTypeRefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullableTypeRef(NullableTypeRefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamedType(NamedTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericTypeArguments(GenericTypeArgumentsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericTypeArgument(GenericTypeArgumentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	//GenerateDetailedSyntaxVisitor()

	public interface ICoreSyntaxVisitor<TArg, TResult> 
	{
	    TResult VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node, TArg argument);
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitUsingNamespace(UsingNamespaceSyntax node, TArg argument);
		
		TResult VisitStatement(StatementSyntax node, TArg argument);
		
		TResult VisitParenthesizedExpr(ParenthesizedExprSyntax node, TArg argument);
		
		TResult VisitDefaultExpr(DefaultExprSyntax node, TArg argument);
		
		TResult VisitThisExpr(ThisExprSyntax node, TArg argument);
		
		TResult VisitBaseExpr(BaseExprSyntax node, TArg argument);
		
		TResult VisitLiteralExpr(LiteralExprSyntax node, TArg argument);
		
		TResult VisitIdentifierExpr(IdentifierExprSyntax node, TArg argument);
		
		TResult VisitQualifierExpr(QualifierExprSyntax node, TArg argument);
		
		TResult VisitIndexerExpr(IndexerExprSyntax node, TArg argument);
		
		TResult VisitInvocationExpr(InvocationExprSyntax node, TArg argument);
		
		TResult VisitTypeofExpr(TypeofExprSyntax node, TArg argument);
		
		TResult VisitNameofExpr(NameofExprSyntax node, TArg argument);
		
		TResult VisitSizeofExpr(SizeofExprSyntax node, TArg argument);
		
		TResult VisitCheckedExpr(CheckedExprSyntax node, TArg argument);
		
		TResult VisitUncheckedExpr(UncheckedExprSyntax node, TArg argument);
		
		TResult VisitNewExpr(NewExprSyntax node, TArg argument);
		
		TResult VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node, TArg argument);
		
		TResult VisitUnaryExpr(UnaryExprSyntax node, TArg argument);
		
		TResult VisitTypeCastExpr(TypeCastExprSyntax node, TArg argument);
		
		TResult VisitMultExpr(MultExprSyntax node, TArg argument);
		
		TResult VisitAddExpr(AddExprSyntax node, TArg argument);
		
		TResult VisitShiftExpr(ShiftExprSyntax node, TArg argument);
		
		TResult VisitRelExpr(RelExprSyntax node, TArg argument);
		
		TResult VisitTypeIsExpr(TypeIsExprSyntax node, TArg argument);
		
		TResult VisitTypeAsExpr(TypeAsExprSyntax node, TArg argument);
		
		TResult VisitEqExpr(EqExprSyntax node, TArg argument);
		
		TResult VisitAndExpr(AndExprSyntax node, TArg argument);
		
		TResult VisitXorExpr(XorExprSyntax node, TArg argument);
		
		TResult VisitOrExpr(OrExprSyntax node, TArg argument);
		
		TResult VisitAndAlsoExpr(AndAlsoExprSyntax node, TArg argument);
		
		TResult VisitOrElseExpr(OrElseExprSyntax node, TArg argument);
		
		TResult VisitCoalExpr(CoalExprSyntax node, TArg argument);
		
		TResult VisitCondExpr(CondExprSyntax node, TArg argument);
		
		TResult VisitAssignExpr(AssignExprSyntax node, TArg argument);
		
		TResult VisitCompAssignExpr(CompAssignExprSyntax node, TArg argument);
		
		TResult VisitArgumentList(ArgumentListSyntax node, TArg argument);
		
		TResult VisitArgumentExpression(ArgumentExpressionSyntax node, TArg argument);
		
		TResult VisitInitializerExpression(InitializerExpressionSyntax node, TArg argument);
		
		TResult VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node, TArg argument);
		
		TResult VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node, TArg argument);
		
		TResult VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node, TArg argument);
		
		TResult VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node, TArg argument);
		
		TResult VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node, TArg argument);
		
		TResult VisitDotOperator(DotOperatorSyntax node, TArg argument);
		
		TResult VisitIndexerOperator(IndexerOperatorSyntax node, TArg argument);
		
		TResult VisitPostfixOperator(PostfixOperatorSyntax node, TArg argument);
		
		TResult VisitUnaryOperator(UnaryOperatorSyntax node, TArg argument);
		
		TResult VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node, TArg argument);
		
		TResult VisitAdditiveOperator(AdditiveOperatorSyntax node, TArg argument);
		
		TResult VisitShiftOperator(ShiftOperatorSyntax node, TArg argument);
		
		TResult VisitLeftShiftOperator(LeftShiftOperatorSyntax node, TArg argument);
		
		TResult VisitRightShiftOperator(RightShiftOperatorSyntax node, TArg argument);
		
		TResult VisitRelationalOperator(RelationalOperatorSyntax node, TArg argument);
		
		TResult VisitEqualityOperator(EqualityOperatorSyntax node, TArg argument);
		
		TResult VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node, TArg argument);
		
		TResult VisitReturnType(ReturnTypeSyntax node, TArg argument);
		
		TResult VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node, TArg argument);
		
		TResult VisitGenericTypeRef(GenericTypeRefSyntax node, TArg argument);
		
		TResult VisitNamedTypeRef(NamedTypeRefSyntax node, TArg argument);
		
		TResult VisitArrayTypeRef(ArrayTypeRefSyntax node, TArg argument);
		
		TResult VisitNullableTypeRef(NullableTypeRefSyntax node, TArg argument);
		
		TResult VisitNamedType(NamedTypeSyntax node, TArg argument);
		
		TResult VisitGenericTypeArguments(GenericTypeArgumentsSyntax node, TArg argument);
		
		TResult VisitGenericTypeArgument(GenericTypeArgumentSyntax node, TArg argument);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node, TArg argument);
		
		TResult VisitVoidType(VoidTypeSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument);
		
		TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument);
	}
	
	public class CoreSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, ICoreSyntaxVisitor<TArg, TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node, TArg argument)
	    {
	        return this.DefaultVisit(node, argument);
	    }
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingNamespace(UsingNamespaceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParenthesizedExpr(ParenthesizedExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDefaultExpr(DefaultExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitThisExpr(ThisExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBaseExpr(BaseExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLiteralExpr(LiteralExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifierExpr(IdentifierExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifierExpr(QualifierExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIndexerExpr(IndexerExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInvocationExpr(InvocationExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeofExpr(TypeofExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNameofExpr(NameofExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSizeofExpr(SizeofExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCheckedExpr(CheckedExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUncheckedExpr(UncheckedExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNewExpr(NewExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUnaryExpr(UnaryExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeCastExpr(TypeCastExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMultExpr(MultExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAddExpr(AddExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitShiftExpr(ShiftExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRelExpr(RelExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeIsExpr(TypeIsExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeAsExpr(TypeAsExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEqExpr(EqExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAndExpr(AndExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitXorExpr(XorExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOrExpr(OrExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAndAlsoExpr(AndAlsoExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOrElseExpr(OrElseExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCoalExpr(CoalExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCondExpr(CondExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssignExpr(AssignExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompAssignExpr(CompAssignExprSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArgumentList(ArgumentListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArgumentExpression(ArgumentExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInitializerExpression(InitializerExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDotOperator(DotOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIndexerOperator(IndexerOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPostfixOperator(PostfixOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUnaryOperator(UnaryOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAdditiveOperator(AdditiveOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitShiftOperator(ShiftOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLeftShiftOperator(LeftShiftOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRightShiftOperator(RightShiftOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRelationalOperator(RelationalOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEqualityOperator(EqualityOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericTypeRef(GenericTypeRefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamedTypeRef(NamedTypeRefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrayTypeRef(ArrayTypeRefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullableTypeRef(NullableTypeRefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamedType(NamedTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericTypeArguments(GenericTypeArgumentsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericTypeArgument(GenericTypeArgumentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPrimitiveType(PrimitiveTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitName(NameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLiteral(LiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
	}

	public interface ICoreSyntaxVisitor<TResult> 
	{
	    TResult VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node);
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitUsingNamespace(UsingNamespaceSyntax node);
		
		TResult VisitStatement(StatementSyntax node);
		
		TResult VisitParenthesizedExpr(ParenthesizedExprSyntax node);
		
		TResult VisitDefaultExpr(DefaultExprSyntax node);
		
		TResult VisitThisExpr(ThisExprSyntax node);
		
		TResult VisitBaseExpr(BaseExprSyntax node);
		
		TResult VisitLiteralExpr(LiteralExprSyntax node);
		
		TResult VisitIdentifierExpr(IdentifierExprSyntax node);
		
		TResult VisitQualifierExpr(QualifierExprSyntax node);
		
		TResult VisitIndexerExpr(IndexerExprSyntax node);
		
		TResult VisitInvocationExpr(InvocationExprSyntax node);
		
		TResult VisitTypeofExpr(TypeofExprSyntax node);
		
		TResult VisitNameofExpr(NameofExprSyntax node);
		
		TResult VisitSizeofExpr(SizeofExprSyntax node);
		
		TResult VisitCheckedExpr(CheckedExprSyntax node);
		
		TResult VisitUncheckedExpr(UncheckedExprSyntax node);
		
		TResult VisitNewExpr(NewExprSyntax node);
		
		TResult VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node);
		
		TResult VisitUnaryExpr(UnaryExprSyntax node);
		
		TResult VisitTypeCastExpr(TypeCastExprSyntax node);
		
		TResult VisitMultExpr(MultExprSyntax node);
		
		TResult VisitAddExpr(AddExprSyntax node);
		
		TResult VisitShiftExpr(ShiftExprSyntax node);
		
		TResult VisitRelExpr(RelExprSyntax node);
		
		TResult VisitTypeIsExpr(TypeIsExprSyntax node);
		
		TResult VisitTypeAsExpr(TypeAsExprSyntax node);
		
		TResult VisitEqExpr(EqExprSyntax node);
		
		TResult VisitAndExpr(AndExprSyntax node);
		
		TResult VisitXorExpr(XorExprSyntax node);
		
		TResult VisitOrExpr(OrExprSyntax node);
		
		TResult VisitAndAlsoExpr(AndAlsoExprSyntax node);
		
		TResult VisitOrElseExpr(OrElseExprSyntax node);
		
		TResult VisitCoalExpr(CoalExprSyntax node);
		
		TResult VisitCondExpr(CondExprSyntax node);
		
		TResult VisitAssignExpr(AssignExprSyntax node);
		
		TResult VisitCompAssignExpr(CompAssignExprSyntax node);
		
		TResult VisitArgumentList(ArgumentListSyntax node);
		
		TResult VisitArgumentExpression(ArgumentExpressionSyntax node);
		
		TResult VisitInitializerExpression(InitializerExpressionSyntax node);
		
		TResult VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node);
		
		TResult VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node);
		
		TResult VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node);
		
		TResult VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node);
		
		TResult VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node);
		
		TResult VisitDotOperator(DotOperatorSyntax node);
		
		TResult VisitIndexerOperator(IndexerOperatorSyntax node);
		
		TResult VisitPostfixOperator(PostfixOperatorSyntax node);
		
		TResult VisitUnaryOperator(UnaryOperatorSyntax node);
		
		TResult VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node);
		
		TResult VisitAdditiveOperator(AdditiveOperatorSyntax node);
		
		TResult VisitShiftOperator(ShiftOperatorSyntax node);
		
		TResult VisitLeftShiftOperator(LeftShiftOperatorSyntax node);
		
		TResult VisitRightShiftOperator(RightShiftOperatorSyntax node);
		
		TResult VisitRelationalOperator(RelationalOperatorSyntax node);
		
		TResult VisitEqualityOperator(EqualityOperatorSyntax node);
		
		TResult VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node);
		
		TResult VisitReturnType(ReturnTypeSyntax node);
		
		TResult VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node);
		
		TResult VisitGenericTypeRef(GenericTypeRefSyntax node);
		
		TResult VisitNamedTypeRef(NamedTypeRefSyntax node);
		
		TResult VisitArrayTypeRef(ArrayTypeRefSyntax node);
		
		TResult VisitNullableTypeRef(NullableTypeRefSyntax node);
		
		TResult VisitNamedType(NamedTypeSyntax node);
		
		TResult VisitGenericTypeArguments(GenericTypeArgumentsSyntax node);
		
		TResult VisitGenericTypeArgument(GenericTypeArgumentSyntax node);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		TResult VisitVoidType(VoidTypeSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node);
		
		TResult VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class CoreSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ICoreSyntaxVisitor<TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node)
	    {
	        return this.DefaultVisit(node);
	    }
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingNamespace(UsingNamespaceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParenthesizedExpr(ParenthesizedExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefaultExpr(DefaultExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitThisExpr(ThisExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBaseExpr(BaseExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLiteralExpr(LiteralExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifierExpr(IdentifierExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifierExpr(QualifierExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIndexerExpr(IndexerExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInvocationExpr(InvocationExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeofExpr(TypeofExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNameofExpr(NameofExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSizeofExpr(SizeofExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCheckedExpr(CheckedExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUncheckedExpr(UncheckedExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNewExpr(NewExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUnaryExpr(UnaryExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeCastExpr(TypeCastExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMultExpr(MultExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAddExpr(AddExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitShiftExpr(ShiftExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRelExpr(RelExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeIsExpr(TypeIsExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeAsExpr(TypeAsExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEqExpr(EqExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAndExpr(AndExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitXorExpr(XorExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOrExpr(OrExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAndAlsoExpr(AndAlsoExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOrElseExpr(OrElseExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCoalExpr(CoalExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCondExpr(CondExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssignExpr(AssignExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompAssignExpr(CompAssignExprSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArgumentList(ArgumentListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArgumentExpression(ArgumentExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInitializerExpression(InitializerExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDotOperator(DotOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIndexerOperator(IndexerOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPostfixOperator(PostfixOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUnaryOperator(UnaryOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAdditiveOperator(AdditiveOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitShiftOperator(ShiftOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLeftShiftOperator(LeftShiftOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRightShiftOperator(RightShiftOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRelationalOperator(RelationalOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEqualityOperator(EqualityOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericTypeRef(GenericTypeRefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamedTypeRef(NamedTypeRefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrayTypeRef(ArrayTypeRefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullableTypeRef(NullableTypeRefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamedType(NamedTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericTypeArguments(GenericTypeArgumentsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericTypeArgument(GenericTypeArgumentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitName(NameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLiteral(LiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullLiteral(NullLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStringLiteral(StringLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class CoreSyntaxRewriter : SyntaxRewriter, ICoreSyntaxVisitor<SyntaxNode>
	{
	    public CoreSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(CoreLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
	
	    public virtual SyntaxNode VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node)
	    {
	      var tokens = this.VisitList(node.Tokens);
	      return node.Update(tokens);
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var usingNamespace = this.VisitList(node.UsingNamespace);
		    var statement = this.VisitList(node.Statement);
		    var eOF = this.VisitToken(node.EndOfFileToken);
			return node.Update(usingNamespace, statement, eOF);
		}
		
		public virtual SyntaxNode VisitUsingNamespace(UsingNamespaceSyntax node)
		{
		    var kUsing = this.VisitToken(node.KUsing);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tAssign = this.VisitToken(node.TAssign);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kUsing, name, tAssign, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitStatement(StatementSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(expression, tSemicolon);
		}
		
		public virtual SyntaxNode VisitParenthesizedExpr(ParenthesizedExprSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, expression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitDefaultExpr(DefaultExprSyntax node)
		{
		    var kDefault = this.VisitToken(node.KDefault);
			return node.Update(kDefault);
		}
		
		public virtual SyntaxNode VisitThisExpr(ThisExprSyntax node)
		{
		    var kThis = this.VisitToken(node.KThis);
			return node.Update(kThis);
		}
		
		public virtual SyntaxNode VisitBaseExpr(BaseExprSyntax node)
		{
		    var kBase = this.VisitToken(node.KBase);
			return node.Update(kBase);
		}
		
		public virtual SyntaxNode VisitLiteralExpr(LiteralExprSyntax node)
		{
		    var literal = (LiteralSyntax)this.Visit(node.Literal);
			return node.Update(literal);
		}
		
		public virtual SyntaxNode VisitIdentifierExpr(IdentifierExprSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var genericTypeArguments = (GenericTypeArgumentsSyntax)this.Visit(node.GenericTypeArguments);
			return node.Update(identifier, genericTypeArguments);
		}
		
		public virtual SyntaxNode VisitQualifierExpr(QualifierExprSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var dotOperator = (DotOperatorSyntax)this.Visit(node.DotOperator);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var genericTypeArguments = (GenericTypeArgumentsSyntax)this.Visit(node.GenericTypeArguments);
			return node.Update(expression, dotOperator, identifier, genericTypeArguments);
		}
		
		public virtual SyntaxNode VisitIndexerExpr(IndexerExprSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var indexerOperator = (IndexerOperatorSyntax)this.Visit(node.IndexerOperator);
		    var argumentList = (ArgumentListSyntax)this.Visit(node.ArgumentList);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(expression, indexerOperator, argumentList, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitInvocationExpr(InvocationExprSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var argumentList = (ArgumentListSyntax)this.Visit(node.ArgumentList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(expression, tOpenParen, argumentList, tCloseParen);
		}
		
		public virtual SyntaxNode VisitTypeofExpr(TypeofExprSyntax node)
		{
		    var kTypeof = this.VisitToken(node.KTypeof);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(kTypeof, tOpenParen, typeReference, tCloseParen);
		}
		
		public virtual SyntaxNode VisitNameofExpr(NameofExprSyntax node)
		{
		    var kNameof = this.VisitToken(node.KNameof);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(kNameof, tOpenParen, expression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitSizeofExpr(SizeofExprSyntax node)
		{
		    var kSizeof = this.VisitToken(node.KSizeof);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(kSizeof, tOpenParen, typeReference, tCloseParen);
		}
		
		public virtual SyntaxNode VisitCheckedExpr(CheckedExprSyntax node)
		{
		    var kChecked = this.VisitToken(node.KChecked);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(kChecked, tOpenParen, expression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitUncheckedExpr(UncheckedExprSyntax node)
		{
		    var kUnchecked = this.VisitToken(node.KUnchecked);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(kUnchecked, tOpenParen, expression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitNewExpr(NewExprSyntax node)
		{
		    var kNew = this.VisitToken(node.KNew);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var argumentList = (ArgumentListSyntax)this.Visit(node.ArgumentList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var initializerExpression = (InitializerExpressionSyntax)this.Visit(node.InitializerExpression);
			return node.Update(kNew, typeReference, tOpenParen, argumentList, tCloseParen, initializerExpression);
		}
		
		public virtual SyntaxNode VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var postfixOperator = (PostfixOperatorSyntax)this.Visit(node.PostfixOperator);
			return node.Update(expression, postfixOperator);
		}
		
		public virtual SyntaxNode VisitUnaryExpr(UnaryExprSyntax node)
		{
		    var unaryOperator = (UnaryOperatorSyntax)this.Visit(node.UnaryOperator);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(unaryOperator, expression);
		}
		
		public virtual SyntaxNode VisitTypeCastExpr(TypeCastExprSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(tOpenParen, typeReference, tCloseParen, expression);
		}
		
		public virtual SyntaxNode VisitMultExpr(MultExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var multiplicativeOperator = (MultiplicativeOperatorSyntax)this.Visit(node.MultiplicativeOperator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, multiplicativeOperator, right);
		}
		
		public virtual SyntaxNode VisitAddExpr(AddExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var additiveOperator = (AdditiveOperatorSyntax)this.Visit(node.AdditiveOperator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, additiveOperator, right);
		}
		
		public virtual SyntaxNode VisitShiftExpr(ShiftExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var shiftOperator = (ShiftOperatorSyntax)this.Visit(node.ShiftOperator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, shiftOperator, right);
		}
		
		public virtual SyntaxNode VisitRelExpr(RelExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var relationalOperator = (RelationalOperatorSyntax)this.Visit(node.RelationalOperator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, relationalOperator, right);
		}
		
		public virtual SyntaxNode VisitTypeIsExpr(TypeIsExprSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var kIs = this.VisitToken(node.KIs);
		    var kNot = this.VisitToken(node.KNot);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(expression, kIs, kNot, typeReference);
		}
		
		public virtual SyntaxNode VisitTypeAsExpr(TypeAsExprSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var kAs = this.VisitToken(node.KAs);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(expression, kAs, typeReference);
		}
		
		public virtual SyntaxNode VisitEqExpr(EqExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var equalityOperator = (EqualityOperatorSyntax)this.Visit(node.EqualityOperator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, equalityOperator, right);
		}
		
		public virtual SyntaxNode VisitAndExpr(AndExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tAmpersand = this.VisitToken(node.TAmpersand);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tAmpersand, right);
		}
		
		public virtual SyntaxNode VisitXorExpr(XorExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tHat = this.VisitToken(node.THat);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tHat, right);
		}
		
		public virtual SyntaxNode VisitOrExpr(OrExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tBar = this.VisitToken(node.TBar);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tBar, right);
		}
		
		public virtual SyntaxNode VisitAndAlsoExpr(AndAlsoExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tAndAlso = this.VisitToken(node.TAndAlso);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tAndAlso, right);
		}
		
		public virtual SyntaxNode VisitOrElseExpr(OrElseExprSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tOrElse = this.VisitToken(node.TOrElse);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tOrElse, right);
		}
		
		public virtual SyntaxNode VisitCoalExpr(CoalExprSyntax node)
		{
		    var value = (ExpressionSyntax)this.Visit(node.Value);
		    var tQuestionQuestion = this.VisitToken(node.TQuestionQuestion);
		    var whenNull = (ExpressionSyntax)this.Visit(node.WhenNull);
			return node.Update(value, tQuestionQuestion, whenNull);
		}
		
		public virtual SyntaxNode VisitCondExpr(CondExprSyntax node)
		{
		    var condition = (ExpressionSyntax)this.Visit(node.Condition);
		    var tQuestion = this.VisitToken(node.TQuestion);
		    var whenTrue = (ExpressionSyntax)this.Visit(node.WhenTrue);
		    var tColon = this.VisitToken(node.TColon);
		    var whenFalse = (ExpressionSyntax)this.Visit(node.WhenFalse);
			return node.Update(condition, tQuestion, whenTrue, tColon, whenFalse);
		}
		
		public virtual SyntaxNode VisitAssignExpr(AssignExprSyntax node)
		{
		    var target = (ExpressionSyntax)this.Visit(node.Target);
		    var tAssign = this.VisitToken(node.TAssign);
		    var value = (ExpressionSyntax)this.Visit(node.Value);
			return node.Update(target, tAssign, value);
		}
		
		public virtual SyntaxNode VisitCompAssignExpr(CompAssignExprSyntax node)
		{
		    var target = (ExpressionSyntax)this.Visit(node.Target);
		    var compoundAssignmentOperator = (CompoundAssignmentOperatorSyntax)this.Visit(node.CompoundAssignmentOperator);
		    var value = (ExpressionSyntax)this.Visit(node.Value);
			return node.Update(target, compoundAssignmentOperator, value);
		}
		
		public virtual SyntaxNode VisitArgumentList(ArgumentListSyntax node)
		{
		    var argumentExpression = this.VisitList(node.ArgumentExpression);
			return node.Update(argumentExpression);
		}
		
		public virtual SyntaxNode VisitArgumentExpression(ArgumentExpressionSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(name, tColon, expression);
		}
		
		public virtual SyntaxNode VisitInitializerExpression(InitializerExpressionSyntax node)
		{
			var oldFieldInitializerExpressions = node.FieldInitializerExpressions;
			if (oldFieldInitializerExpressions != null)
			{
			    var newFieldInitializerExpressions = (FieldInitializerExpressionsSyntax)this.Visit(oldFieldInitializerExpressions);
				return node.Update(newFieldInitializerExpressions);
			}
			var oldCollectionInitializerExpressions = node.CollectionInitializerExpressions;
			if (oldCollectionInitializerExpressions != null)
			{
			    var newCollectionInitializerExpressions = (CollectionInitializerExpressionsSyntax)this.Visit(oldCollectionInitializerExpressions);
				return node.Update(newCollectionInitializerExpressions);
			}
			var oldDictionaryInitializerExpressions = node.DictionaryInitializerExpressions;
			if (oldDictionaryInitializerExpressions != null)
			{
			    var newDictionaryInitializerExpressions = (DictionaryInitializerExpressionsSyntax)this.Visit(oldDictionaryInitializerExpressions);
				return node.Update(newDictionaryInitializerExpressions);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node)
		{
		    var fieldInitializerExpression = this.VisitList(node.FieldInitializerExpression);
			return node.Update(fieldInitializerExpression);
		}
		
		public virtual SyntaxNode VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(identifier, tAssign, expression);
		}
		
		public virtual SyntaxNode VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node)
		{
		    var expression = this.VisitList(node.Expression);
			return node.Update(expression);
		}
		
		public virtual SyntaxNode VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node)
		{
		    var dictionaryInitializerExpression = this.VisitList(node.DictionaryInitializerExpression);
			return node.Update(dictionaryInitializerExpression);
		}
		
		public virtual SyntaxNode VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(tOpenBracket, identifier, tCloseBracket, tAssign, expression);
		}
		
		public virtual SyntaxNode VisitDotOperator(DotOperatorSyntax node)
		{
		    var dotOperator = this.VisitToken(node.DotOperator);
			return node.Update(dotOperator);
		}
		
		public virtual SyntaxNode VisitIndexerOperator(IndexerOperatorSyntax node)
		{
		    var indexerOperator = this.VisitToken(node.IndexerOperator);
			return node.Update(indexerOperator);
		}
		
		public virtual SyntaxNode VisitPostfixOperator(PostfixOperatorSyntax node)
		{
		    var postfixOperator = this.VisitToken(node.PostfixOperator);
			return node.Update(postfixOperator);
		}
		
		public virtual SyntaxNode VisitUnaryOperator(UnaryOperatorSyntax node)
		{
		    var unaryOperator = this.VisitToken(node.UnaryOperator);
			return node.Update(unaryOperator);
		}
		
		public virtual SyntaxNode VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node)
		{
		    var multiplicativeOperator = this.VisitToken(node.MultiplicativeOperator);
			return node.Update(multiplicativeOperator);
		}
		
		public virtual SyntaxNode VisitAdditiveOperator(AdditiveOperatorSyntax node)
		{
		    var additiveOperator = this.VisitToken(node.AdditiveOperator);
			return node.Update(additiveOperator);
		}
		
		public virtual SyntaxNode VisitShiftOperator(ShiftOperatorSyntax node)
		{
			var oldLeftShiftOperator = node.LeftShiftOperator;
			if (oldLeftShiftOperator != null)
			{
			    var newLeftShiftOperator = (LeftShiftOperatorSyntax)this.Visit(oldLeftShiftOperator);
				return node.Update(newLeftShiftOperator);
			}
			var oldRightShiftOperator = node.RightShiftOperator;
			if (oldRightShiftOperator != null)
			{
			    var newRightShiftOperator = (RightShiftOperatorSyntax)this.Visit(oldRightShiftOperator);
				return node.Update(newRightShiftOperator);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitLeftShiftOperator(LeftShiftOperatorSyntax node)
		{
		    var first = this.VisitToken(node.First);
		    var second = this.VisitToken(node.Second);
			return node.Update(first, second);
		}
		
		public virtual SyntaxNode VisitRightShiftOperator(RightShiftOperatorSyntax node)
		{
		    var first = this.VisitToken(node.First);
		    var second = this.VisitToken(node.Second);
			return node.Update(first, second);
		}
		
		public virtual SyntaxNode VisitRelationalOperator(RelationalOperatorSyntax node)
		{
		    var relationalOperator = this.VisitToken(node.RelationalOperator);
			return node.Update(relationalOperator);
		}
		
		public virtual SyntaxNode VisitEqualityOperator(EqualityOperatorSyntax node)
		{
		    var equalityOperator = this.VisitToken(node.EqualityOperator);
			return node.Update(equalityOperator);
		}
		
		public virtual SyntaxNode VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node)
		{
		    var compoundAssignmentOperator = this.VisitToken(node.CompoundAssignmentOperator);
			return node.Update(compoundAssignmentOperator);
		}
		
		public virtual SyntaxNode VisitReturnType(ReturnTypeSyntax node)
		{
			var oldTypeReference = node.TypeReference;
			if (oldTypeReference != null)
			{
			    var newTypeReference = (TypeReferenceSyntax)this.Visit(oldTypeReference);
				return node.Update(newTypeReference);
			}
			var oldVoidType = node.VoidType;
			if (oldVoidType != null)
			{
			    var newVoidType = (VoidTypeSyntax)this.Visit(oldVoidType);
				return node.Update(newVoidType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node)
		{
		    var primitiveType = (PrimitiveTypeSyntax)this.Visit(node.PrimitiveType);
			return node.Update(primitiveType);
		}
		
		public virtual SyntaxNode VisitGenericTypeRef(GenericTypeRefSyntax node)
		{
		    var namedType = (NamedTypeSyntax)this.Visit(node.NamedType);
		    var genericTypeArguments = (GenericTypeArgumentsSyntax)this.Visit(node.GenericTypeArguments);
			return node.Update(namedType, genericTypeArguments);
		}
		
		public virtual SyntaxNode VisitNamedTypeRef(NamedTypeRefSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitArrayTypeRef(ArrayTypeRefSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(typeReference, tOpenBracket, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitNullableTypeRef(NullableTypeRefSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tQuestion = this.VisitToken(node.TQuestion);
			return node.Update(typeReference, tQuestion);
		}
		
		public virtual SyntaxNode VisitNamedType(NamedTypeSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitGenericTypeArguments(GenericTypeArgumentsSyntax node)
		{
		    var tLessThan = this.VisitToken(node.TLessThan);
		    var genericTypeArgument = this.VisitList(node.GenericTypeArgument);
		    var tGreaterThan = this.VisitToken(node.TGreaterThan);
			return node.Update(tLessThan, genericTypeArgument, tGreaterThan);
		}
		
		public virtual SyntaxNode VisitGenericTypeArgument(GenericTypeArgumentSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(typeReference);
		}
		
		public virtual SyntaxNode VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    var primitiveType = this.VisitToken(node.PrimitiveType);
			return node.Update(primitiveType);
		}
		
		public virtual SyntaxNode VisitVoidType(VoidTypeSyntax node)
		{
		    var kVoid = this.VisitToken(node.KVoid);
			return node.Update(kVoid);
		}
		
		public virtual SyntaxNode VisitName(NameSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitQualifier(QualifierSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var identifier = this.VisitToken(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitLiteral(LiteralSyntax node)
		{
			var oldNullLiteral = node.NullLiteral;
			if (oldNullLiteral != null)
			{
			    var newNullLiteral = (NullLiteralSyntax)this.Visit(oldNullLiteral);
				return node.Update(newNullLiteral);
			}
			var oldBooleanLiteral = node.BooleanLiteral;
			if (oldBooleanLiteral != null)
			{
			    var newBooleanLiteral = (BooleanLiteralSyntax)this.Visit(oldBooleanLiteral);
				return node.Update(newBooleanLiteral);
			}
			var oldIntegerLiteral = node.IntegerLiteral;
			if (oldIntegerLiteral != null)
			{
			    var newIntegerLiteral = (IntegerLiteralSyntax)this.Visit(oldIntegerLiteral);
				return node.Update(newIntegerLiteral);
			}
			var oldDecimalLiteral = node.DecimalLiteral;
			if (oldDecimalLiteral != null)
			{
			    var newDecimalLiteral = (DecimalLiteralSyntax)this.Visit(oldDecimalLiteral);
				return node.Update(newDecimalLiteral);
			}
			var oldScientificLiteral = node.ScientificLiteral;
			if (oldScientificLiteral != null)
			{
			    var newScientificLiteral = (ScientificLiteralSyntax)this.Visit(oldScientificLiteral);
				return node.Update(newScientificLiteral);
			}
			var oldStringLiteral = node.StringLiteral;
			if (oldStringLiteral != null)
			{
			    var newStringLiteral = (StringLiteralSyntax)this.Visit(oldStringLiteral);
				return node.Update(newStringLiteral);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNullLiteral(NullLiteralSyntax node)
		{
		    var kNull = this.VisitToken(node.KNull);
			return node.Update(kNull);
		}
		
		public virtual SyntaxNode VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    var booleanLiteral = this.VisitToken(node.BooleanLiteral);
			return node.Update(booleanLiteral);
		}
		
		public virtual SyntaxNode VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    var lInteger = this.VisitToken(node.LInteger);
			return node.Update(lInteger);
		}
		
		public virtual SyntaxNode VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    var lDecimal = this.VisitToken(node.LDecimal);
			return node.Update(lDecimal);
		}
		
		public virtual SyntaxNode VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    var lScientific = this.VisitToken(node.LScientific);
			return node.Update(lScientific);
		}
		
		public virtual SyntaxNode VisitStringLiteral(StringLiteralSyntax node)
		{
		    var lRegularString = this.VisitToken(node.LRegularString);
			return node.Update(lRegularString);
		}
	}

	public class CoreSyntaxFactory : SyntaxFactory
	{
		internal CoreSyntaxFactory(CoreInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
	    public new CoreLanguage Language => CoreLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => CoreParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public CoreSyntaxTree SyntaxTree(SyntaxNode root, CoreParseOptions? options = null, string? path = "", Encoding? encoding = null)
		{
			return CoreSyntaxTree.Create((CoreSyntaxNode)root, ParseData.Empty, options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public CoreSyntaxTree ParseSyntaxTree(
			string text,
			CoreParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (CoreSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public CoreSyntaxTree ParseSyntaxTree(
			SourceText text,
			CoreParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (CoreSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return CoreSyntaxTree.ParseText(text, (CoreParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return CoreSyntaxTree.Create((CoreSyntaxNode)root, ParseData.Empty, (CoreParseOptions)options, path, null, encoding);
		}
	
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.TAsterisk(text));
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value));
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text));
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text, value));
	    }
	
	    public SyntaxToken LDateTime(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDateTime(text));
	    }
	
	    public SyntaxToken LDateTime(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDateTime(text, value));
	    }
	
	    public SyntaxToken LDate(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDate(text));
	    }
	
	    public SyntaxToken LDate(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LDate(text, value));
	    }
	
	    public SyntaxToken LTime(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LTime(text));
	    }
	
	    public SyntaxToken LTime(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LTime(text, value));
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LRegularString(text));
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value));
	    }
	
	    public SyntaxToken LGuid(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LGuid(text));
	    }
	
	    public SyntaxToken LGuid(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LGuid(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LComment(text));
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return new SyntaxToken(CoreLanguage.Instance.InternalSyntaxFactory.LComment(text, value));
	    }
		
		public MainSyntax Main(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceSyntax> usingNamespace, Microsoft.CodeAnalysis.SyntaxList<StatementSyntax> statement, SyntaxToken eOF)
		{
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != CoreSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<UsingNamespaceGreen>(usingNamespace.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<StatementGreen>(statement.Node), (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public MainSyntax Main(SyntaxToken eOF)
		{
			return this.Main(default, default, eOF);
		}
		
		public UsingNamespaceSyntax UsingNamespace(SyntaxToken kUsing, NameSyntax name, SyntaxToken tAssign, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
		    if (kUsing.GetKind() != CoreSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
		    if (tAssign != null && tAssign.GetKind() != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CoreSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (UsingNamespaceSyntax)CoreLanguage.Instance.InternalSyntaxFactory.UsingNamespace((InternalSyntaxToken)kUsing.Node, name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public UsingNamespaceSyntax UsingNamespace(QualifierSyntax qualifier)
		{
			return this.UsingNamespace(this.Token(CoreSyntaxKind.KUsing), default, default, qualifier, this.Token(CoreSyntaxKind.TSemicolon));
		}
		
		public StatementSyntax Statement(ExpressionSyntax expression, SyntaxToken tSemicolon)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CoreSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (StatementSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public StatementSyntax Statement(ExpressionSyntax expression)
		{
			return this.Statement(expression, this.Token(CoreSyntaxKind.TSemicolon));
		}
		
		public ParenthesizedExprSyntax ParenthesizedExpr(SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ParenthesizedExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ParenthesizedExpr((InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public ParenthesizedExprSyntax ParenthesizedExpr(ExpressionSyntax expression)
		{
			return this.ParenthesizedExpr(this.Token(CoreSyntaxKind.TOpenParen), expression, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public DefaultExprSyntax DefaultExpr(SyntaxToken kDefault)
		{
		    if (kDefault == null) throw new ArgumentNullException(nameof(kDefault));
		    if (kDefault.GetKind() != CoreSyntaxKind.KDefault) throw new ArgumentException(nameof(kDefault));
		    return (DefaultExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.DefaultExpr((InternalSyntaxToken)kDefault.Node).CreateRed();
		}
		
		public DefaultExprSyntax DefaultExpr()
		{
			return this.DefaultExpr(this.Token(CoreSyntaxKind.KDefault));
		}
		
		public ThisExprSyntax ThisExpr(SyntaxToken kThis)
		{
		    if (kThis == null) throw new ArgumentNullException(nameof(kThis));
		    if (kThis.GetKind() != CoreSyntaxKind.KThis) throw new ArgumentException(nameof(kThis));
		    return (ThisExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ThisExpr((InternalSyntaxToken)kThis.Node).CreateRed();
		}
		
		public ThisExprSyntax ThisExpr()
		{
			return this.ThisExpr(this.Token(CoreSyntaxKind.KThis));
		}
		
		public BaseExprSyntax BaseExpr(SyntaxToken kBase)
		{
		    if (kBase == null) throw new ArgumentNullException(nameof(kBase));
		    if (kBase.GetKind() != CoreSyntaxKind.KBase) throw new ArgumentException(nameof(kBase));
		    return (BaseExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.BaseExpr((InternalSyntaxToken)kBase.Node).CreateRed();
		}
		
		public BaseExprSyntax BaseExpr()
		{
			return this.BaseExpr(this.Token(CoreSyntaxKind.KBase));
		}
		
		public LiteralExprSyntax LiteralExpr(LiteralSyntax literal)
		{
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
		    return (LiteralExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.LiteralExpr((Syntax.InternalSyntax.LiteralGreen)literal.Green).CreateRed();
		}
		
		public IdentifierExprSyntax IdentifierExpr(IdentifierSyntax identifier, GenericTypeArgumentsSyntax genericTypeArguments)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.IdentifierExpr((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, genericTypeArguments == null ? null : (Syntax.InternalSyntax.GenericTypeArgumentsGreen)genericTypeArguments.Green).CreateRed();
		}
		
		public IdentifierExprSyntax IdentifierExpr(IdentifierSyntax identifier)
		{
			return this.IdentifierExpr(identifier, default);
		}
		
		public QualifierExprSyntax QualifierExpr(ExpressionSyntax expression, DotOperatorSyntax dotOperator, IdentifierSyntax identifier, GenericTypeArgumentsSyntax genericTypeArguments)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (dotOperator == null) throw new ArgumentNullException(nameof(dotOperator));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.QualifierExpr((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (Syntax.InternalSyntax.DotOperatorGreen)dotOperator.Green, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, genericTypeArguments == null ? null : (Syntax.InternalSyntax.GenericTypeArgumentsGreen)genericTypeArguments.Green).CreateRed();
		}
		
		public QualifierExprSyntax QualifierExpr(ExpressionSyntax expression, DotOperatorSyntax dotOperator, IdentifierSyntax identifier)
		{
			return this.QualifierExpr(expression, dotOperator, identifier, default);
		}
		
		public IndexerExprSyntax IndexerExpr(ExpressionSyntax expression, IndexerOperatorSyntax indexerOperator, ArgumentListSyntax argumentList, SyntaxToken tCloseBracket)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (indexerOperator == null) throw new ArgumentNullException(nameof(indexerOperator));
		    if (argumentList == null) throw new ArgumentNullException(nameof(argumentList));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != CoreSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (IndexerExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.IndexerExpr((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (Syntax.InternalSyntax.IndexerOperatorGreen)indexerOperator.Green, (Syntax.InternalSyntax.ArgumentListGreen)argumentList.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public IndexerExprSyntax IndexerExpr(ExpressionSyntax expression, IndexerOperatorSyntax indexerOperator, ArgumentListSyntax argumentList)
		{
			return this.IndexerExpr(expression, indexerOperator, argumentList, this.Token(CoreSyntaxKind.TCloseBracket));
		}
		
		public InvocationExprSyntax InvocationExpr(ExpressionSyntax expression, SyntaxToken tOpenParen, ArgumentListSyntax argumentList, SyntaxToken tCloseParen)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (InvocationExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.InvocationExpr((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tOpenParen.Node, argumentList == null ? null : (Syntax.InternalSyntax.ArgumentListGreen)argumentList.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public InvocationExprSyntax InvocationExpr(ExpressionSyntax expression)
		{
			return this.InvocationExpr(expression, this.Token(CoreSyntaxKind.TOpenParen), default, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public TypeofExprSyntax TypeofExpr(SyntaxToken kTypeof, SyntaxToken tOpenParen, TypeReferenceSyntax typeReference, SyntaxToken tCloseParen)
		{
		    if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
		    if (kTypeof.GetKind() != CoreSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (TypeofExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.TypeofExpr((InternalSyntaxToken)kTypeof.Node, (InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public TypeofExprSyntax TypeofExpr(TypeReferenceSyntax typeReference)
		{
			return this.TypeofExpr(this.Token(CoreSyntaxKind.KTypeof), this.Token(CoreSyntaxKind.TOpenParen), typeReference, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public NameofExprSyntax NameofExpr(SyntaxToken kNameof, SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
		{
		    if (kNameof == null) throw new ArgumentNullException(nameof(kNameof));
		    if (kNameof.GetKind() != CoreSyntaxKind.KNameof) throw new ArgumentException(nameof(kNameof));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (NameofExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.NameofExpr((InternalSyntaxToken)kNameof.Node, (InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public NameofExprSyntax NameofExpr(ExpressionSyntax expression)
		{
			return this.NameofExpr(this.Token(CoreSyntaxKind.KNameof), this.Token(CoreSyntaxKind.TOpenParen), expression, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public SizeofExprSyntax SizeofExpr(SyntaxToken kSizeof, SyntaxToken tOpenParen, TypeReferenceSyntax typeReference, SyntaxToken tCloseParen)
		{
		    if (kSizeof == null) throw new ArgumentNullException(nameof(kSizeof));
		    if (kSizeof.GetKind() != CoreSyntaxKind.KSizeof) throw new ArgumentException(nameof(kSizeof));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (SizeofExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.SizeofExpr((InternalSyntaxToken)kSizeof.Node, (InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public SizeofExprSyntax SizeofExpr(TypeReferenceSyntax typeReference)
		{
			return this.SizeofExpr(this.Token(CoreSyntaxKind.KSizeof), this.Token(CoreSyntaxKind.TOpenParen), typeReference, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public CheckedExprSyntax CheckedExpr(SyntaxToken kChecked, SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
		{
		    if (kChecked == null) throw new ArgumentNullException(nameof(kChecked));
		    if (kChecked.GetKind() != CoreSyntaxKind.KChecked) throw new ArgumentException(nameof(kChecked));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (CheckedExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.CheckedExpr((InternalSyntaxToken)kChecked.Node, (InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public CheckedExprSyntax CheckedExpr(ExpressionSyntax expression)
		{
			return this.CheckedExpr(this.Token(CoreSyntaxKind.KChecked), this.Token(CoreSyntaxKind.TOpenParen), expression, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public UncheckedExprSyntax UncheckedExpr(SyntaxToken kUnchecked, SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
		{
		    if (kUnchecked == null) throw new ArgumentNullException(nameof(kUnchecked));
		    if (kUnchecked.GetKind() != CoreSyntaxKind.KUnchecked) throw new ArgumentException(nameof(kUnchecked));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (UncheckedExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.UncheckedExpr((InternalSyntaxToken)kUnchecked.Node, (InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public UncheckedExprSyntax UncheckedExpr(ExpressionSyntax expression)
		{
			return this.UncheckedExpr(this.Token(CoreSyntaxKind.KUnchecked), this.Token(CoreSyntaxKind.TOpenParen), expression, this.Token(CoreSyntaxKind.TCloseParen));
		}
		
		public NewExprSyntax NewExpr(SyntaxToken kNew, TypeReferenceSyntax typeReference, SyntaxToken tOpenParen, ArgumentListSyntax argumentList, SyntaxToken tCloseParen, InitializerExpressionSyntax initializerExpression)
		{
		    if (kNew == null) throw new ArgumentNullException(nameof(kNew));
		    if (kNew.GetKind() != CoreSyntaxKind.KNew) throw new ArgumentException(nameof(kNew));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (NewExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.NewExpr((InternalSyntaxToken)kNew.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tOpenParen.Node, argumentList == null ? null : (Syntax.InternalSyntax.ArgumentListGreen)argumentList.Green, (InternalSyntaxToken)tCloseParen.Node, initializerExpression == null ? null : (Syntax.InternalSyntax.InitializerExpressionGreen)initializerExpression.Green).CreateRed();
		}
		
		public NewExprSyntax NewExpr(TypeReferenceSyntax typeReference)
		{
			return this.NewExpr(this.Token(CoreSyntaxKind.KNew), typeReference, this.Token(CoreSyntaxKind.TOpenParen), default, this.Token(CoreSyntaxKind.TCloseParen), default);
		}
		
		public PostfixUnaryExprSyntax PostfixUnaryExpr(ExpressionSyntax expression, PostfixOperatorSyntax postfixOperator)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (postfixOperator == null) throw new ArgumentNullException(nameof(postfixOperator));
		    return (PostfixUnaryExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.PostfixUnaryExpr((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (Syntax.InternalSyntax.PostfixOperatorGreen)postfixOperator.Green).CreateRed();
		}
		
		public UnaryExprSyntax UnaryExpr(UnaryOperatorSyntax unaryOperator, ExpressionSyntax expression)
		{
		    if (unaryOperator == null) throw new ArgumentNullException(nameof(unaryOperator));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (UnaryExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.UnaryExpr((Syntax.InternalSyntax.UnaryOperatorGreen)unaryOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public TypeCastExprSyntax TypeCastExpr(SyntaxToken tOpenParen, TypeReferenceSyntax typeReference, SyntaxToken tCloseParen, ExpressionSyntax expression)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CoreSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CoreSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (TypeCastExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.TypeCastExpr((InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParen.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public TypeCastExprSyntax TypeCastExpr(TypeReferenceSyntax typeReference, ExpressionSyntax expression)
		{
			return this.TypeCastExpr(this.Token(CoreSyntaxKind.TOpenParen), typeReference, this.Token(CoreSyntaxKind.TCloseParen), expression);
		}
		
		public MultExprSyntax MultExpr(ExpressionSyntax left, MultiplicativeOperatorSyntax multiplicativeOperator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (multiplicativeOperator == null) throw new ArgumentNullException(nameof(multiplicativeOperator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (MultExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.MultExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (Syntax.InternalSyntax.MultiplicativeOperatorGreen)multiplicativeOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public AddExprSyntax AddExpr(ExpressionSyntax left, AdditiveOperatorSyntax additiveOperator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (additiveOperator == null) throw new ArgumentNullException(nameof(additiveOperator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AddExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.AddExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (Syntax.InternalSyntax.AdditiveOperatorGreen)additiveOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public ShiftExprSyntax ShiftExpr(ExpressionSyntax left, ShiftOperatorSyntax shiftOperator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (shiftOperator == null) throw new ArgumentNullException(nameof(shiftOperator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (ShiftExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ShiftExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (Syntax.InternalSyntax.ShiftOperatorGreen)shiftOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public RelExprSyntax RelExpr(ExpressionSyntax left, RelationalOperatorSyntax relationalOperator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (relationalOperator == null) throw new ArgumentNullException(nameof(relationalOperator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (RelExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.RelExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (Syntax.InternalSyntax.RelationalOperatorGreen)relationalOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public TypeIsExprSyntax TypeIsExpr(ExpressionSyntax expression, SyntaxToken kIs, SyntaxToken kNot, TypeReferenceSyntax typeReference)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (kIs == null) throw new ArgumentNullException(nameof(kIs));
		    if (kIs.GetKind() != CoreSyntaxKind.KIs) throw new ArgumentException(nameof(kIs));
		    if (kNot != null && kNot.GetKind() != CoreSyntaxKind.KNot) throw new ArgumentException(nameof(kNot));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeIsExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.TypeIsExpr((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)kIs.Node, (InternalSyntaxToken)kNot.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public TypeIsExprSyntax TypeIsExpr(ExpressionSyntax expression, TypeReferenceSyntax typeReference)
		{
			return this.TypeIsExpr(expression, this.Token(CoreSyntaxKind.KIs), default, typeReference);
		}
		
		public TypeAsExprSyntax TypeAsExpr(ExpressionSyntax expression, SyntaxToken kAs, TypeReferenceSyntax typeReference)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (kAs == null) throw new ArgumentNullException(nameof(kAs));
		    if (kAs.GetKind() != CoreSyntaxKind.KAs) throw new ArgumentException(nameof(kAs));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeAsExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.TypeAsExpr((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)kAs.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public TypeAsExprSyntax TypeAsExpr(ExpressionSyntax expression, TypeReferenceSyntax typeReference)
		{
			return this.TypeAsExpr(expression, this.Token(CoreSyntaxKind.KAs), typeReference);
		}
		
		public EqExprSyntax EqExpr(ExpressionSyntax left, EqualityOperatorSyntax equalityOperator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (equalityOperator == null) throw new ArgumentNullException(nameof(equalityOperator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (EqExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.EqExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (Syntax.InternalSyntax.EqualityOperatorGreen)equalityOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public AndExprSyntax AndExpr(ExpressionSyntax left, SyntaxToken tAmpersand, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tAmpersand == null) throw new ArgumentNullException(nameof(tAmpersand));
		    if (tAmpersand.GetKind() != CoreSyntaxKind.TAmpersand) throw new ArgumentException(nameof(tAmpersand));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AndExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.AndExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tAmpersand.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public AndExprSyntax AndExpr(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.AndExpr(left, this.Token(CoreSyntaxKind.TAmpersand), right);
		}
		
		public XorExprSyntax XorExpr(ExpressionSyntax left, SyntaxToken tHat, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tHat == null) throw new ArgumentNullException(nameof(tHat));
		    if (tHat.GetKind() != CoreSyntaxKind.THat) throw new ArgumentException(nameof(tHat));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (XorExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.XorExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tHat.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public XorExprSyntax XorExpr(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.XorExpr(left, this.Token(CoreSyntaxKind.THat), right);
		}
		
		public OrExprSyntax OrExpr(ExpressionSyntax left, SyntaxToken tBar, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tBar == null) throw new ArgumentNullException(nameof(tBar));
		    if (tBar.GetKind() != CoreSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (OrExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.OrExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tBar.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public OrExprSyntax OrExpr(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.OrExpr(left, this.Token(CoreSyntaxKind.TBar), right);
		}
		
		public AndAlsoExprSyntax AndAlsoExpr(ExpressionSyntax left, SyntaxToken tAndAlso, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tAndAlso == null) throw new ArgumentNullException(nameof(tAndAlso));
		    if (tAndAlso.GetKind() != CoreSyntaxKind.TAndAlso) throw new ArgumentException(nameof(tAndAlso));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AndAlsoExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.AndAlsoExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tAndAlso.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public AndAlsoExprSyntax AndAlsoExpr(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.AndAlsoExpr(left, this.Token(CoreSyntaxKind.TAndAlso), right);
		}
		
		public OrElseExprSyntax OrElseExpr(ExpressionSyntax left, SyntaxToken tOrElse, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tOrElse == null) throw new ArgumentNullException(nameof(tOrElse));
		    if (tOrElse.GetKind() != CoreSyntaxKind.TOrElse) throw new ArgumentException(nameof(tOrElse));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (OrElseExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.OrElseExpr((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tOrElse.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public OrElseExprSyntax OrElseExpr(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.OrElseExpr(left, this.Token(CoreSyntaxKind.TOrElse), right);
		}
		
		public CoalExprSyntax CoalExpr(ExpressionSyntax value, SyntaxToken tQuestionQuestion, ExpressionSyntax whenNull)
		{
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    if (tQuestionQuestion == null) throw new ArgumentNullException(nameof(tQuestionQuestion));
		    if (tQuestionQuestion.GetKind() != CoreSyntaxKind.TQuestionQuestion) throw new ArgumentException(nameof(tQuestionQuestion));
		    if (whenNull == null) throw new ArgumentNullException(nameof(whenNull));
		    return (CoalExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.CoalExpr((Syntax.InternalSyntax.ExpressionGreen)value.Green, (InternalSyntaxToken)tQuestionQuestion.Node, (Syntax.InternalSyntax.ExpressionGreen)whenNull.Green).CreateRed();
		}
		
		public CoalExprSyntax CoalExpr(ExpressionSyntax value, ExpressionSyntax whenNull)
		{
			return this.CoalExpr(value, this.Token(CoreSyntaxKind.TQuestionQuestion), whenNull);
		}
		
		public CondExprSyntax CondExpr(ExpressionSyntax condition, SyntaxToken tQuestion, ExpressionSyntax whenTrue, SyntaxToken tColon, ExpressionSyntax whenFalse)
		{
		    if (condition == null) throw new ArgumentNullException(nameof(condition));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != CoreSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    if (whenTrue == null) throw new ArgumentNullException(nameof(whenTrue));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != CoreSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (whenFalse == null) throw new ArgumentNullException(nameof(whenFalse));
		    return (CondExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.CondExpr((Syntax.InternalSyntax.ExpressionGreen)condition.Green, (InternalSyntaxToken)tQuestion.Node, (Syntax.InternalSyntax.ExpressionGreen)whenTrue.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.ExpressionGreen)whenFalse.Green).CreateRed();
		}
		
		public CondExprSyntax CondExpr(ExpressionSyntax condition, ExpressionSyntax whenTrue, ExpressionSyntax whenFalse)
		{
			return this.CondExpr(condition, this.Token(CoreSyntaxKind.TQuestion), whenTrue, this.Token(CoreSyntaxKind.TColon), whenFalse);
		}
		
		public AssignExprSyntax AssignExpr(ExpressionSyntax target, SyntaxToken tAssign, ExpressionSyntax value)
		{
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    return (AssignExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.AssignExpr((Syntax.InternalSyntax.ExpressionGreen)target.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.ExpressionGreen)value.Green).CreateRed();
		}
		
		public AssignExprSyntax AssignExpr(ExpressionSyntax target, ExpressionSyntax value)
		{
			return this.AssignExpr(target, this.Token(CoreSyntaxKind.TAssign), value);
		}
		
		public CompAssignExprSyntax CompAssignExpr(ExpressionSyntax target, CompoundAssignmentOperatorSyntax compoundAssignmentOperator, ExpressionSyntax value)
		{
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (compoundAssignmentOperator == null) throw new ArgumentNullException(nameof(compoundAssignmentOperator));
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    return (CompAssignExprSyntax)CoreLanguage.Instance.InternalSyntaxFactory.CompAssignExpr((Syntax.InternalSyntax.ExpressionGreen)target.Green, (Syntax.InternalSyntax.CompoundAssignmentOperatorGreen)compoundAssignmentOperator.Green, (Syntax.InternalSyntax.ExpressionGreen)value.Green).CreateRed();
		}
		
		public ArgumentListSyntax ArgumentList(Microsoft.CodeAnalysis.SeparatedSyntaxList<ArgumentExpressionSyntax> argumentExpression)
		{
		    if (argumentExpression == null) throw new ArgumentNullException(nameof(argumentExpression));
		    return (ArgumentListSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ArgumentList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ArgumentExpressionGreen>(argumentExpression.Node)).CreateRed();
		}
		
		public ArgumentExpressionSyntax ArgumentExpression(NameSyntax name, SyntaxToken tColon, ExpressionSyntax expression)
		{
		    if (tColon != null && tColon.GetKind() != CoreSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (ArgumentExpressionSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ArgumentExpression(name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public ArgumentExpressionSyntax ArgumentExpression(ExpressionSyntax expression)
		{
			return this.ArgumentExpression(default, default, expression);
		}
		
		public InitializerExpressionSyntax InitializerExpression(FieldInitializerExpressionsSyntax fieldInitializerExpressions)
		{
		    if (fieldInitializerExpressions == null) throw new ArgumentNullException(nameof(fieldInitializerExpressions));
		    return (InitializerExpressionSyntax)CoreLanguage.Instance.InternalSyntaxFactory.InitializerExpression((Syntax.InternalSyntax.FieldInitializerExpressionsGreen)fieldInitializerExpressions.Green).CreateRed();
		}
		
		public InitializerExpressionSyntax InitializerExpression(CollectionInitializerExpressionsSyntax collectionInitializerExpressions)
		{
		    if (collectionInitializerExpressions == null) throw new ArgumentNullException(nameof(collectionInitializerExpressions));
		    return (InitializerExpressionSyntax)CoreLanguage.Instance.InternalSyntaxFactory.InitializerExpression((Syntax.InternalSyntax.CollectionInitializerExpressionsGreen)collectionInitializerExpressions.Green).CreateRed();
		}
		
		public InitializerExpressionSyntax InitializerExpression(DictionaryInitializerExpressionsSyntax dictionaryInitializerExpressions)
		{
		    if (dictionaryInitializerExpressions == null) throw new ArgumentNullException(nameof(dictionaryInitializerExpressions));
		    return (InitializerExpressionSyntax)CoreLanguage.Instance.InternalSyntaxFactory.InitializerExpression((Syntax.InternalSyntax.DictionaryInitializerExpressionsGreen)dictionaryInitializerExpressions.Green).CreateRed();
		}
		
		public FieldInitializerExpressionsSyntax FieldInitializerExpressions(Microsoft.CodeAnalysis.SeparatedSyntaxList<FieldInitializerExpressionSyntax> fieldInitializerExpression)
		{
		    if (fieldInitializerExpression == null) throw new ArgumentNullException(nameof(fieldInitializerExpression));
		    return (FieldInitializerExpressionsSyntax)CoreLanguage.Instance.InternalSyntaxFactory.FieldInitializerExpressions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<FieldInitializerExpressionGreen>(fieldInitializerExpression.Node)).CreateRed();
		}
		
		public FieldInitializerExpressionSyntax FieldInitializerExpression(IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (FieldInitializerExpressionSyntax)CoreLanguage.Instance.InternalSyntaxFactory.FieldInitializerExpression((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public FieldInitializerExpressionSyntax FieldInitializerExpression(IdentifierSyntax identifier, ExpressionSyntax expression)
		{
			return this.FieldInitializerExpression(identifier, this.Token(CoreSyntaxKind.TAssign), expression);
		}
		
		public CollectionInitializerExpressionsSyntax CollectionInitializerExpressions(Microsoft.CodeAnalysis.SeparatedSyntaxList<ExpressionSyntax> expression)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (CollectionInitializerExpressionsSyntax)CoreLanguage.Instance.InternalSyntaxFactory.CollectionInitializerExpressions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ExpressionGreen>(expression.Node)).CreateRed();
		}
		
		public DictionaryInitializerExpressionsSyntax DictionaryInitializerExpressions(Microsoft.CodeAnalysis.SeparatedSyntaxList<DictionaryInitializerExpressionSyntax> dictionaryInitializerExpression)
		{
		    if (dictionaryInitializerExpression == null) throw new ArgumentNullException(nameof(dictionaryInitializerExpression));
		    return (DictionaryInitializerExpressionsSyntax)CoreLanguage.Instance.InternalSyntaxFactory.DictionaryInitializerExpressions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<DictionaryInitializerExpressionGreen>(dictionaryInitializerExpression.Node)).CreateRed();
		}
		
		public DictionaryInitializerExpressionSyntax DictionaryInitializerExpression(SyntaxToken tOpenBracket, IdentifierSyntax identifier, SyntaxToken tCloseBracket, SyntaxToken tAssign, ExpressionSyntax expression)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != CoreSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != CoreSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != CoreSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (DictionaryInitializerExpressionSyntax)CoreLanguage.Instance.InternalSyntaxFactory.DictionaryInitializerExpression((InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tCloseBracket.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public DictionaryInitializerExpressionSyntax DictionaryInitializerExpression(IdentifierSyntax identifier, ExpressionSyntax expression)
		{
			return this.DictionaryInitializerExpression(this.Token(CoreSyntaxKind.TOpenBracket), identifier, this.Token(CoreSyntaxKind.TCloseBracket), this.Token(CoreSyntaxKind.TAssign), expression);
		}
		
		public DotOperatorSyntax DotOperator(SyntaxToken dotOperator)
		{
		    if (dotOperator == null) throw new ArgumentNullException(nameof(dotOperator));
		    return (DotOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.DotOperator((InternalSyntaxToken)dotOperator.Node).CreateRed();
		}
		
		public IndexerOperatorSyntax IndexerOperator(SyntaxToken indexerOperator)
		{
		    if (indexerOperator == null) throw new ArgumentNullException(nameof(indexerOperator));
		    return (IndexerOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.IndexerOperator((InternalSyntaxToken)indexerOperator.Node).CreateRed();
		}
		
		public PostfixOperatorSyntax PostfixOperator(SyntaxToken postfixOperator)
		{
		    if (postfixOperator == null) throw new ArgumentNullException(nameof(postfixOperator));
		    return (PostfixOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.PostfixOperator((InternalSyntaxToken)postfixOperator.Node).CreateRed();
		}
		
		public UnaryOperatorSyntax UnaryOperator(SyntaxToken unaryOperator)
		{
		    if (unaryOperator == null) throw new ArgumentNullException(nameof(unaryOperator));
		    return (UnaryOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.UnaryOperator((InternalSyntaxToken)unaryOperator.Node).CreateRed();
		}
		
		public MultiplicativeOperatorSyntax MultiplicativeOperator(SyntaxToken multiplicativeOperator)
		{
		    if (multiplicativeOperator == null) throw new ArgumentNullException(nameof(multiplicativeOperator));
		    return (MultiplicativeOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.MultiplicativeOperator((InternalSyntaxToken)multiplicativeOperator.Node).CreateRed();
		}
		
		public AdditiveOperatorSyntax AdditiveOperator(SyntaxToken additiveOperator)
		{
		    if (additiveOperator == null) throw new ArgumentNullException(nameof(additiveOperator));
		    return (AdditiveOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.AdditiveOperator((InternalSyntaxToken)additiveOperator.Node).CreateRed();
		}
		
		public ShiftOperatorSyntax ShiftOperator(LeftShiftOperatorSyntax leftShiftOperator)
		{
		    if (leftShiftOperator == null) throw new ArgumentNullException(nameof(leftShiftOperator));
		    return (ShiftOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ShiftOperator((Syntax.InternalSyntax.LeftShiftOperatorGreen)leftShiftOperator.Green).CreateRed();
		}
		
		public ShiftOperatorSyntax ShiftOperator(RightShiftOperatorSyntax rightShiftOperator)
		{
		    if (rightShiftOperator == null) throw new ArgumentNullException(nameof(rightShiftOperator));
		    return (ShiftOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ShiftOperator((Syntax.InternalSyntax.RightShiftOperatorGreen)rightShiftOperator.Green).CreateRed();
		}
		
		public LeftShiftOperatorSyntax LeftShiftOperator(SyntaxToken first, SyntaxToken second)
		{
		    if (first == null) throw new ArgumentNullException(nameof(first));
		    if (first.GetKind() != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(first));
		    if (second == null) throw new ArgumentNullException(nameof(second));
		    if (second.GetKind() != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(second));
		    return (LeftShiftOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.LeftShiftOperator((InternalSyntaxToken)first.Node, (InternalSyntaxToken)second.Node).CreateRed();
		}
		
		public RightShiftOperatorSyntax RightShiftOperator(SyntaxToken first, SyntaxToken second)
		{
		    if (first == null) throw new ArgumentNullException(nameof(first));
		    if (first.GetKind() != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(first));
		    if (second == null) throw new ArgumentNullException(nameof(second));
		    if (second.GetKind() != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(second));
		    return (RightShiftOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.RightShiftOperator((InternalSyntaxToken)first.Node, (InternalSyntaxToken)second.Node).CreateRed();
		}
		
		public RelationalOperatorSyntax RelationalOperator(SyntaxToken relationalOperator)
		{
		    if (relationalOperator == null) throw new ArgumentNullException(nameof(relationalOperator));
		    return (RelationalOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.RelationalOperator((InternalSyntaxToken)relationalOperator.Node).CreateRed();
		}
		
		public EqualityOperatorSyntax EqualityOperator(SyntaxToken equalityOperator)
		{
		    if (equalityOperator == null) throw new ArgumentNullException(nameof(equalityOperator));
		    return (EqualityOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.EqualityOperator((InternalSyntaxToken)equalityOperator.Node).CreateRed();
		}
		
		public CompoundAssignmentOperatorSyntax CompoundAssignmentOperator(SyntaxToken compoundAssignmentOperator)
		{
		    if (compoundAssignmentOperator == null) throw new ArgumentNullException(nameof(compoundAssignmentOperator));
		    return (CompoundAssignmentOperatorSyntax)CoreLanguage.Instance.InternalSyntaxFactory.CompoundAssignmentOperator((InternalSyntaxToken)compoundAssignmentOperator.Node).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ReturnTypeSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (ReturnTypeSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public PrimitiveTypeRefSyntax PrimitiveTypeRef(PrimitiveTypeSyntax primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (PrimitiveTypeRefSyntax)CoreLanguage.Instance.InternalSyntaxFactory.PrimitiveTypeRef((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green).CreateRed();
		}
		
		public GenericTypeRefSyntax GenericTypeRef(NamedTypeSyntax namedType, GenericTypeArgumentsSyntax genericTypeArguments)
		{
		    if (namedType == null) throw new ArgumentNullException(nameof(namedType));
		    if (genericTypeArguments == null) throw new ArgumentNullException(nameof(genericTypeArguments));
		    return (GenericTypeRefSyntax)CoreLanguage.Instance.InternalSyntaxFactory.GenericTypeRef((Syntax.InternalSyntax.NamedTypeGreen)namedType.Green, (Syntax.InternalSyntax.GenericTypeArgumentsGreen)genericTypeArguments.Green).CreateRed();
		}
		
		public NamedTypeRefSyntax NamedTypeRef(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (NamedTypeRefSyntax)CoreLanguage.Instance.InternalSyntaxFactory.NamedTypeRef((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ArrayTypeRefSyntax ArrayTypeRef(TypeReferenceSyntax typeReference, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != CoreSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != CoreSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (ArrayTypeRefSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ArrayTypeRef((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public ArrayTypeRefSyntax ArrayTypeRef(TypeReferenceSyntax typeReference)
		{
			return this.ArrayTypeRef(typeReference, this.Token(CoreSyntaxKind.TOpenBracket), this.Token(CoreSyntaxKind.TCloseBracket));
		}
		
		public NullableTypeRefSyntax NullableTypeRef(TypeReferenceSyntax typeReference, SyntaxToken tQuestion)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != CoreSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    return (NullableTypeRefSyntax)CoreLanguage.Instance.InternalSyntaxFactory.NullableTypeRef((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tQuestion.Node).CreateRed();
		}
		
		public NullableTypeRefSyntax NullableTypeRef(TypeReferenceSyntax typeReference)
		{
			return this.NullableTypeRef(typeReference, this.Token(CoreSyntaxKind.TQuestion));
		}
		
		public NamedTypeSyntax NamedType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (NamedTypeSyntax)CoreLanguage.Instance.InternalSyntaxFactory.NamedType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public GenericTypeArgumentsSyntax GenericTypeArguments(SyntaxToken tLessThan, Microsoft.CodeAnalysis.SeparatedSyntaxList<GenericTypeArgumentSyntax> genericTypeArgument, SyntaxToken tGreaterThan)
		{
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.GetKind() != CoreSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (genericTypeArgument == null) throw new ArgumentNullException(nameof(genericTypeArgument));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.GetKind() != CoreSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (GenericTypeArgumentsSyntax)CoreLanguage.Instance.InternalSyntaxFactory.GenericTypeArguments((InternalSyntaxToken)tLessThan.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<GenericTypeArgumentGreen>(genericTypeArgument.Node), (InternalSyntaxToken)tGreaterThan.Node).CreateRed();
		}
		
		public GenericTypeArgumentsSyntax GenericTypeArguments(Microsoft.CodeAnalysis.SeparatedSyntaxList<GenericTypeArgumentSyntax> genericTypeArgument)
		{
			return this.GenericTypeArguments(this.Token(CoreSyntaxKind.TLessThan), genericTypeArgument, this.Token(CoreSyntaxKind.TGreaterThan));
		}
		
		public GenericTypeArgumentSyntax GenericTypeArgument(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (GenericTypeArgumentSyntax)CoreLanguage.Instance.InternalSyntaxFactory.GenericTypeArgument((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public PrimitiveTypeSyntax PrimitiveType(SyntaxToken primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (PrimitiveTypeSyntax)CoreLanguage.Instance.InternalSyntaxFactory.PrimitiveType((InternalSyntaxToken)primitiveType.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType(SyntaxToken kVoid)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != CoreSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    return (VoidTypeSyntax)CoreLanguage.Instance.InternalSyntaxFactory.VoidType((InternalSyntaxToken)kVoid.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType()
		{
			return this.VoidType(this.Token(CoreSyntaxKind.KVoid));
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)CoreLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifier.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != CoreSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(CoreSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.GetKind() != CoreSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Node).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.GetKind() != CoreSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Node).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.GetKind() != CoreSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Node).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken lRegularString)
		{
		    if (lRegularString == null) throw new ArgumentNullException(nameof(lRegularString));
		    if (lRegularString.GetKind() != CoreSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
		    return (StringLiteralSyntax)CoreLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)lRegularString.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(UsingNamespaceSyntax),
				typeof(StatementSyntax),
				typeof(ParenthesizedExprSyntax),
				typeof(DefaultExprSyntax),
				typeof(ThisExprSyntax),
				typeof(BaseExprSyntax),
				typeof(LiteralExprSyntax),
				typeof(IdentifierExprSyntax),
				typeof(QualifierExprSyntax),
				typeof(IndexerExprSyntax),
				typeof(InvocationExprSyntax),
				typeof(TypeofExprSyntax),
				typeof(NameofExprSyntax),
				typeof(SizeofExprSyntax),
				typeof(CheckedExprSyntax),
				typeof(UncheckedExprSyntax),
				typeof(NewExprSyntax),
				typeof(PostfixUnaryExprSyntax),
				typeof(UnaryExprSyntax),
				typeof(TypeCastExprSyntax),
				typeof(MultExprSyntax),
				typeof(AddExprSyntax),
				typeof(ShiftExprSyntax),
				typeof(RelExprSyntax),
				typeof(TypeIsExprSyntax),
				typeof(TypeAsExprSyntax),
				typeof(EqExprSyntax),
				typeof(AndExprSyntax),
				typeof(XorExprSyntax),
				typeof(OrExprSyntax),
				typeof(AndAlsoExprSyntax),
				typeof(OrElseExprSyntax),
				typeof(CoalExprSyntax),
				typeof(CondExprSyntax),
				typeof(AssignExprSyntax),
				typeof(CompAssignExprSyntax),
				typeof(ArgumentListSyntax),
				typeof(ArgumentExpressionSyntax),
				typeof(InitializerExpressionSyntax),
				typeof(FieldInitializerExpressionsSyntax),
				typeof(FieldInitializerExpressionSyntax),
				typeof(CollectionInitializerExpressionsSyntax),
				typeof(DictionaryInitializerExpressionsSyntax),
				typeof(DictionaryInitializerExpressionSyntax),
				typeof(DotOperatorSyntax),
				typeof(IndexerOperatorSyntax),
				typeof(PostfixOperatorSyntax),
				typeof(UnaryOperatorSyntax),
				typeof(MultiplicativeOperatorSyntax),
				typeof(AdditiveOperatorSyntax),
				typeof(ShiftOperatorSyntax),
				typeof(LeftShiftOperatorSyntax),
				typeof(RightShiftOperatorSyntax),
				typeof(RelationalOperatorSyntax),
				typeof(EqualityOperatorSyntax),
				typeof(CompoundAssignmentOperatorSyntax),
				typeof(ReturnTypeSyntax),
				typeof(PrimitiveTypeRefSyntax),
				typeof(GenericTypeRefSyntax),
				typeof(NamedTypeRefSyntax),
				typeof(ArrayTypeRefSyntax),
				typeof(NullableTypeRefSyntax),
				typeof(NamedTypeSyntax),
				typeof(GenericTypeArgumentsSyntax),
				typeof(GenericTypeArgumentSyntax),
				typeof(PrimitiveTypeSyntax),
				typeof(VoidTypeSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(IdentifierSyntax),
				typeof(LiteralSyntax),
				typeof(NullLiteralSyntax),
				typeof(BooleanLiteralSyntax),
				typeof(IntegerLiteralSyntax),
				typeof(DecimalLiteralSyntax),
				typeof(ScientificLiteralSyntax),
				typeof(StringLiteralSyntax),
			};
		}
	}
}


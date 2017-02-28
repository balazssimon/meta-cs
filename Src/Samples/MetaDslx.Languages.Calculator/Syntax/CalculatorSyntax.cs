// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Calculator.Syntax
{
	public enum CalculatorSyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		TSemicolon = 1,
		TOpenParen,
		TCloseParen,
		TComma,
		TAssign,
		TAdd,
		TSub,
		TMul,
		TDiv,
		KPrint,
		STRING,
		ID,
		INT,
		UTF8BOM,
		WHITESPACE,
		ENDL,
		COMMENT,

		// Rules:
		Main,
		StatementLine,
		Statement,
		Assignment,
		ParenExpression,
		MulOrDivExpression,
		AddOrSubExpression,
		PrintExpression,
		ValueExpression,
		Args,
		Value,
		Identifier,
		String,
		Integer,
		Arg,
	}

    public abstract class CalculatorSyntaxNode : SyntaxNode
    {
        protected CalculatorSyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected CalculatorSyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public CalculatorSyntaxKind Kind
        {
            get { return (CalculatorSyntaxKind)base.RawKind; }
        }

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            ICalculatorSyntaxVisitor<TResult> typedVisitor = visitor as ICalculatorSyntaxVisitor<TResult>;
            if (typedVisitor != null)
            {
                return this.Accept(typedVisitor);
            }
            return default(TResult);
        }

        public abstract TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            ICalculatorSyntaxVisitor typedVisitor = visitor as ICalculatorSyntaxVisitor;
            if (typedVisitor != null)
            {
                this.Accept(typedVisitor);
            }
        }
        public abstract void Accept(ICalculatorSyntaxVisitor visitor);
    }

    public class CalculatorSyntaxTrivia : SyntaxTrivia
    {
        public CalculatorSyntaxTrivia(InternalSyntaxTrivia green, SyntaxToken token, int position, int index)
            : base(green, token, position, index)
        {
        }

        public CalculatorSyntaxKind Kind
        {
            get { return (CalculatorSyntaxKind)base.RawKind; }
        }
    }

    public class CalculatorSyntaxToken : SyntaxToken
    {
        public CalculatorSyntaxToken(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        public CalculatorSyntaxKind Kind
        {
            get { return (CalculatorSyntaxKind)base.RawKind; }
        }

        protected override SyntaxToken WithLeadingTriviaCore(InternalSyntaxTrivia[] leading)
        {
            return new CalculatorSyntaxToken(this.GreenToken.WithLeadingTrivia(new InternalSyntaxTriviaList(leading, null, null)), null, 0, 0);
        }

        protected override SyntaxToken WithTrailingTriviaCore(InternalSyntaxTrivia[] trailing)
        {
            return new CalculatorSyntaxToken(this.GreenToken.WithTrailingTrivia(new InternalSyntaxTriviaList(trailing, null, null)), null, 0, 0);
        }
    }
	
	public sealed class MainSyntax : CalculatorSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNodeList statementLine;
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<StatementLineSyntax> StatementLine 
		{ 
			get
			{
				var red = this.GetRed(ref this.statementLine, 0);
				if (red != null)
				{
					return new SyntaxNodeList<StatementLineSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken Eof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.Eof;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.statementLine, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.statementLine;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithStatementLine(SyntaxNodeList<StatementLineSyntax> statementLine)
		{
			return this.Update(StatementLine, this.Eof);
		}
	
	    public MainSyntax AddStatementLine(params StatementLineSyntax[] statementLine)
		{
			return this.WithStatementLine(this.StatementLine.AddRange(statementLine));
		}
	
	    public MainSyntax WithEof(SyntaxToken eof)
		{
			return this.Update(this.StatementLine, Eof);
		}
	
	    public MainSyntax Update(SyntaxNodeList<StatementLineSyntax> statementLine, SyntaxToken eof)
	    {
	        if (this.StatementLine.Node != statementLine.Node ||
				this.Eof != eof)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Main(statementLine, eof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class StatementLineSyntax : CalculatorSyntaxNode
	{
	    private StatementSyntax statement;
	
	    public StatementLineSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementLineSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public StatementSyntax Statement 
		{ 
			get { return this.GetRed(ref this.statement, 0); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.StatementLineGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.statement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.statement;
				default: return null;
	        }
	    }
	
	    public StatementLineSyntax WithStatement(StatementSyntax statement)
		{
			return this.Update(Statement, this.TSemicolon);
		}
	
	    public StatementLineSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Statement, TSemicolon);
		}
	
	    public StatementLineSyntax Update(StatementSyntax statement, SyntaxToken tSemicolon)
	    {
	        if (this.Statement != statement ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.StatementLine(statement, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementLineSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatementLine(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitStatementLine(this);
	    }
	}
	
	public sealed class StatementSyntax : CalculatorSyntaxNode
	{
	    private AssignmentSyntax assignment;
	    private ExpressionSyntax expression;
	
	    public StatementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AssignmentSyntax Assignment 
		{ 
			get { return this.GetRed(ref this.assignment, 0); } 
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.assignment, 0);
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.assignment;
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public StatementSyntax WithAssignment(AssignmentSyntax assignment)
		{
			return this.Update(assignment);
		}
	
	    public StatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(expression);
		}
	
	    public StatementSyntax Update(AssignmentSyntax assignment)
	    {
	        if (this.Assignment != assignment)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Statement(assignment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(ExpressionSyntax expression)
	    {
	        if (this.Expression != expression)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Statement(expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatement(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitStatement(this);
	    }
	}
	
	public sealed class AssignmentSyntax : CalculatorSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ExpressionSyntax expression;
	
	    public AssignmentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssignmentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
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
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.AssignmentGreen)this.Green;
				var greenToken = green.TAssign;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
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
	
	    public AssignmentSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TAssign, this.Expression);
		}
	
	    public AssignmentSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.Identifier, TAssign, this.Expression);
		}
	
	    public AssignmentSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.Identifier, this.TAssign, Expression);
		}
	
	    public AssignmentSyntax Update(IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
	    {
	        if (this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Assignment(identifier, tAssign, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssignment(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitAssignment(this);
	    }
	}
	
	public abstract class ExpressionSyntax : CalculatorSyntaxNode
	{
	    protected ExpressionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ExpressionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ParenExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public ParenExpressionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParenExpressionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.ParenExpressionGreen)this.Green;
				var greenToken = green.TOpenParen;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.ParenExpressionGreen)this.Green;
				var greenToken = green.TCloseParen;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
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
	
	    public ParenExpressionSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.Expression, this.TCloseParen);
		}
	
	    public ParenExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TOpenParen, Expression, this.TCloseParen);
		}
	
	    public ParenExpressionSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.Expression, TCloseParen);
		}
	
	    public ParenExpressionSyntax Update(SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.Expression != expression ||
				this.TCloseParen != tCloseParen)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.ParenExpression(tOpenParen, expression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParenExpression(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitParenExpression(this);
	    }
	}
	
	public sealed class MulOrDivExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public MulOrDivExpressionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MulOrDivExpressionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Operator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.MulOrDivExpressionGreen)this.Green;
				var greenToken = green.Operator;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
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
	
	    public MulOrDivExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Operator, this.Right);
		}
	
	    public MulOrDivExpressionSyntax WithOperator(SyntaxToken _operator)
		{
			return this.Update(this.Left, Operator, this.Right);
		}
	
	    public MulOrDivExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Operator, Right);
		}
	
	    public MulOrDivExpressionSyntax Update(ExpressionSyntax left, SyntaxToken _operator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Operator != _operator ||
				this.Right != right)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.MulOrDivExpression(left, _operator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MulOrDivExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMulOrDivExpression(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitMulOrDivExpression(this);
	    }
	}
	
	public sealed class AddOrSubExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public AddOrSubExpressionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AddOrSubExpressionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Operator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.AddOrSubExpressionGreen)this.Green;
				var greenToken = green.Operator;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
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
	
	    public AddOrSubExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Operator, this.Right);
		}
	
	    public AddOrSubExpressionSyntax WithOperator(SyntaxToken _operator)
		{
			return this.Update(this.Left, Operator, this.Right);
		}
	
	    public AddOrSubExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Operator, Right);
		}
	
	    public AddOrSubExpressionSyntax Update(ExpressionSyntax left, SyntaxToken _operator, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Operator != _operator ||
				this.Right != right)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.AddOrSubExpression(left, _operator, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AddOrSubExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAddOrSubExpression(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitAddOrSubExpression(this);
	    }
	}
	
	public sealed class PrintExpressionSyntax : ExpressionSyntax
	{
	    private ArgsSyntax args;
	
	    public PrintExpressionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PrintExpressionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KPrint 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.PrintExpressionGreen)this.Green;
				var greenToken = green.KPrint;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public ArgsSyntax Args 
		{ 
			get { return this.GetRed(ref this.args, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.args, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.args;
				default: return null;
	        }
	    }
	
	    public PrintExpressionSyntax WithKPrint(SyntaxToken kPrint)
		{
			return this.Update(KPrint, this.Args);
		}
	
	    public PrintExpressionSyntax WithArgs(ArgsSyntax args)
		{
			return this.Update(this.KPrint, Args);
		}
	
	    public PrintExpressionSyntax Update(SyntaxToken kPrint, ArgsSyntax args)
	    {
	        if (this.KPrint != kPrint ||
				this.Args != args)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.PrintExpression(kPrint, args);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrintExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPrintExpression(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitPrintExpression(this);
	    }
	}
	
	public sealed class ValueExpressionSyntax : ExpressionSyntax
	{
	    private ValueSyntax value;
	
	    public ValueExpressionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ValueExpressionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ValueSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.value, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.value;
				default: return null;
	        }
	    }
	
	    public ValueExpressionSyntax WithValue(ValueSyntax value)
		{
			return this.Update(Value);
		}
	
	    public ValueExpressionSyntax Update(ValueSyntax value)
	    {
	        if (this.Value != value)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.ValueExpression(value);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitValueExpression(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitValueExpression(this);
	    }
	}
	
	public sealed class ArgsSyntax : CalculatorSyntaxNode
	{
	    private SeparatedSyntaxNodeList arg;
	
	    public ArgsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArgsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<ArgSyntax> Arg 
		{ 
			get
			{
				var red = this.GetRed(ref this.arg, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<ArgSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.arg, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.arg;
				default: return null;
	        }
	    }
	
	    public ArgsSyntax WithArg(SeparatedSyntaxNodeList<ArgSyntax> arg)
		{
			return this.Update(Arg);
		}
	
	    public ArgsSyntax AddArg(params ArgSyntax[] arg)
		{
			return this.WithArg(this.Arg.AddRange(arg));
		}
	
	    public ArgsSyntax Update(SeparatedSyntaxNodeList<ArgSyntax> arg)
	    {
	        if (this.Arg.Node != arg.Node)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Args(arg);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArgs(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitArgs(this);
	    }
	}
	
	public sealed class ValueSyntax : CalculatorSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private StringSyntax _string;
	    private IntegerSyntax integer;
	
	    public ValueSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ValueSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public StringSyntax String 
		{ 
			get { return this.GetRed(ref this._string, 1); } 
		}
	    public IntegerSyntax Integer 
		{ 
			get { return this.GetRed(ref this.integer, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 1: return this.GetRed(ref this._string, 1);
				case 2: return this.GetRed(ref this.integer, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 1: return this._string;
				case 2: return this.integer;
				default: return null;
	        }
	    }
	
	    public ValueSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(identifier);
		}
	
	    public ValueSyntax WithString(StringSyntax _string)
		{
			return this.Update(_string);
		}
	
	    public ValueSyntax WithInteger(IntegerSyntax integer)
		{
			return this.Update(integer);
		}
	
	    public ValueSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Value(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ValueSyntax Update(StringSyntax _string)
	    {
	        if (this.String != _string)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Value(_string);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ValueSyntax Update(IntegerSyntax integer)
	    {
	        if (this.Integer != integer)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Value(integer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitValue(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitValue(this);
	    }
	}
	
	public sealed class IdentifierSyntax : CalculatorSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ID 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.ID;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public IdentifierSyntax WithID(SyntaxToken id)
		{
			return this.Update(ID);
		}
	
	    public IdentifierSyntax Update(SyntaxToken id)
	    {
	        if (this.ID != id)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Identifier(id);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class StringSyntax : CalculatorSyntaxNode
	{
	
	    public StringSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken STRING 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.StringGreen)this.Green;
				var greenToken = green.STRING;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public StringSyntax WithSTRING(SyntaxToken _string)
		{
			return this.Update(STRING);
		}
	
	    public StringSyntax Update(SyntaxToken _string)
	    {
	        if (this.STRING != _string)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.String(_string);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitString(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitString(this);
	    }
	}
	
	public sealed class IntegerSyntax : CalculatorSyntaxNode
	{
	
	    public IntegerSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken INT 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Calculator.Syntax.InternalSyntax.IntegerGreen)this.Green;
				var greenToken = green.INT;
				return greenToken == null ? null : new CalculatorSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public IntegerSyntax WithINT(SyntaxToken _int)
		{
			return this.Update(INT);
		}
	
	    public IntegerSyntax Update(SyntaxToken _int)
	    {
	        if (this.INT != _int)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Integer(_int);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInteger(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitInteger(this);
	    }
	}
	
	public sealed class ArgSyntax : CalculatorSyntaxNode
	{
	    private ValueSyntax value;
	
	    public ArgSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArgSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ValueSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.value, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.value;
				default: return null;
	        }
	    }
	
	    public ArgSyntax WithValue(ValueSyntax value)
		{
			return this.Update(Value);
		}
	
	    public ArgSyntax Update(ValueSyntax value)
	    {
	        if (this.Value != value)
	        {
	            SyntaxNode newNode = CalculatorLanguage.Instance.SyntaxFactory.Arg(value);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArgSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ICalculatorSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArg(this);
	    }
	
	    public override void Accept(ICalculatorSyntaxVisitor visitor)
	    {
	        visitor.VisitArg(this);
	    }
	}
}

namespace MetaDslx.Languages.Calculator
{
    using System.Threading;
    using MetaDslx.Compiler;
    using MetaDslx.Compiler.Text;
	using MetaDslx.Languages.Calculator.Syntax;
    using MetaDslx.Languages.Calculator.Syntax.InternalSyntax;

	public interface ICalculatorSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitStatementLine(StatementLineSyntax node);
		
		void VisitStatement(StatementSyntax node);
		
		void VisitAssignment(AssignmentSyntax node);
		
		void VisitParenExpression(ParenExpressionSyntax node);
		
		void VisitMulOrDivExpression(MulOrDivExpressionSyntax node);
		
		void VisitAddOrSubExpression(AddOrSubExpressionSyntax node);
		
		void VisitPrintExpression(PrintExpressionSyntax node);
		
		void VisitValueExpression(ValueExpressionSyntax node);
		
		void VisitArgs(ArgsSyntax node);
		
		void VisitValue(ValueSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitString(StringSyntax node);
		
		void VisitInteger(IntegerSyntax node);
		
		void VisitArg(ArgSyntax node);
	}
	
	public class CalculatorSyntaxVisitor : SyntaxVisitor, ICalculatorSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatementLine(StatementLineSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssignment(AssignmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParenExpression(ParenExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMulOrDivExpression(MulOrDivExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAddOrSubExpression(AddOrSubExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPrintExpression(PrintExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitValueExpression(ValueExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArgs(ArgsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitValue(ValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitString(StringSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInteger(IntegerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArg(ArgSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	public class CalculatorDetailedSyntaxVisitor : DetailedSyntaxVisitor, ICalculatorSyntaxVisitor
	{
	    public CalculatorDetailedSyntaxVisitor(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.VisitList(node.StatementLine);
			this.VisitToken(node.Eof);
		}
		
		public virtual void VisitStatementLine(StatementLineSyntax node)
		{
			this.Visit(node.Statement);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
			this.Visit(node.Assignment);
			this.Visit(node.Expression);
		}
		
		public virtual void VisitAssignment(AssignmentSyntax node)
		{
			this.Visit(node.Identifier);
			this.VisitToken(node.TAssign);
			this.Visit(node.Expression);
		}
		
		public virtual void VisitParenExpression(ParenExpressionSyntax node)
		{
			this.VisitToken(node.TOpenParen);
			this.Visit(node.Expression);
			this.VisitToken(node.TCloseParen);
		}
		
		public virtual void VisitMulOrDivExpression(MulOrDivExpressionSyntax node)
		{
			this.Visit(node.Left);
			this.VisitToken(node.Operator);
			this.Visit(node.Right);
		}
		
		public virtual void VisitAddOrSubExpression(AddOrSubExpressionSyntax node)
		{
			this.Visit(node.Left);
			this.VisitToken(node.Operator);
			this.Visit(node.Right);
		}
		
		public virtual void VisitPrintExpression(PrintExpressionSyntax node)
		{
			this.VisitToken(node.KPrint);
			this.Visit(node.Args);
		}
		
		public virtual void VisitValueExpression(ValueExpressionSyntax node)
		{
			this.Visit(node.Value);
		}
		
		public virtual void VisitArgs(ArgsSyntax node)
		{
			this.VisitList(node.Arg);
		}
		
		public virtual void VisitValue(ValueSyntax node)
		{
			this.Visit(node.Identifier);
			this.Visit(node.String);
			this.Visit(node.Integer);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			this.VisitToken(node.ID);
		}
		
		public virtual void VisitString(StringSyntax node)
		{
			this.VisitToken(node.STRING);
		}
		
		public virtual void VisitInteger(IntegerSyntax node)
		{
			this.VisitToken(node.INT);
		}
		
		public virtual void VisitArg(ArgSyntax node)
		{
			this.Visit(node.Value);
		}
	}

	public interface ICalculatorSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitStatementLine(StatementLineSyntax node);
		
		TResult VisitStatement(StatementSyntax node);
		
		TResult VisitAssignment(AssignmentSyntax node);
		
		TResult VisitParenExpression(ParenExpressionSyntax node);
		
		TResult VisitMulOrDivExpression(MulOrDivExpressionSyntax node);
		
		TResult VisitAddOrSubExpression(AddOrSubExpressionSyntax node);
		
		TResult VisitPrintExpression(PrintExpressionSyntax node);
		
		TResult VisitValueExpression(ValueExpressionSyntax node);
		
		TResult VisitArgs(ArgsSyntax node);
		
		TResult VisitValue(ValueSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitString(StringSyntax node);
		
		TResult VisitInteger(IntegerSyntax node);
		
		TResult VisitArg(ArgSyntax node);
	}
	
	public class CalculatorSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ICalculatorSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatementLine(StatementLineSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssignment(AssignmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParenExpression(ParenExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMulOrDivExpression(MulOrDivExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAddOrSubExpression(AddOrSubExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPrintExpression(PrintExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitValueExpression(ValueExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArgs(ArgsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitValue(ValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitString(StringSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInteger(IntegerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArg(ArgSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class CalculatorSyntaxRewriter : SyntaxRewriter, ICalculatorSyntaxVisitor<SyntaxNode>
	{
	    public CalculatorSyntaxRewriter(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var statementLine = this.VisitList(node.StatementLine);
		    var eof = this.VisitToken(node.Eof);
			return node.Update(statementLine, eof);
		}
		
		public virtual SyntaxNode VisitStatementLine(StatementLineSyntax node)
		{
		    var statement = (StatementSyntax)this.Visit(node.Statement);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(statement, tSemicolon);
		}
		
		public virtual SyntaxNode VisitStatement(StatementSyntax node)
		{
			var oldAssignment = node.Assignment;
			if (oldAssignment != null)
			{
			    var newAssignment = (AssignmentSyntax)this.Visit(oldAssignment);
				return node.Update(newAssignment);
			}
			var oldExpression = node.Expression;
			if (oldExpression != null)
			{
			    var newExpression = (ExpressionSyntax)this.Visit(oldExpression);
				return node.Update(newExpression);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitAssignment(AssignmentSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(identifier, tAssign, expression);
		}
		
		public virtual SyntaxNode VisitParenExpression(ParenExpressionSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, expression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitMulOrDivExpression(MulOrDivExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var _operator = this.VisitToken(node.Operator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, _operator, right);
		}
		
		public virtual SyntaxNode VisitAddOrSubExpression(AddOrSubExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var _operator = this.VisitToken(node.Operator);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, _operator, right);
		}
		
		public virtual SyntaxNode VisitPrintExpression(PrintExpressionSyntax node)
		{
		    var kPrint = this.VisitToken(node.KPrint);
		    var args = (ArgsSyntax)this.Visit(node.Args);
			return node.Update(kPrint, args);
		}
		
		public virtual SyntaxNode VisitValueExpression(ValueExpressionSyntax node)
		{
		    var value = (ValueSyntax)this.Visit(node.Value);
			return node.Update(value);
		}
		
		public virtual SyntaxNode VisitArgs(ArgsSyntax node)
		{
		    var arg = this.VisitList(node.Arg);
			return node.Update(arg);
		}
		
		public virtual SyntaxNode VisitValue(ValueSyntax node)
		{
			var oldIdentifier = node.Identifier;
			if (oldIdentifier != null)
			{
			    var newIdentifier = (IdentifierSyntax)this.Visit(oldIdentifier);
				return node.Update(newIdentifier);
			}
			var oldString = node.String;
			if (oldString != null)
			{
			    var newString = (StringSyntax)this.Visit(oldString);
				return node.Update(newString);
			}
			var oldInteger = node.Integer;
			if (oldInteger != null)
			{
			    var newInteger = (IntegerSyntax)this.Visit(oldInteger);
				return node.Update(newInteger);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var id = this.VisitToken(node.ID);
			return node.Update(id);
		}
		
		public virtual SyntaxNode VisitString(StringSyntax node)
		{
		    var _string = this.VisitToken(node.STRING);
			return node.Update(_string);
		}
		
		public virtual SyntaxNode VisitInteger(IntegerSyntax node)
		{
		    var _int = this.VisitToken(node.INT);
			return node.Update(_int);
		}
		
		public virtual SyntaxNode VisitArg(ArgSyntax node)
		{
		    var value = (ValueSyntax)this.Visit(node.Value);
			return node.Update(value);
		}
	}

	public class CalculatorSyntaxFactory : SyntaxFactory
	{
	    internal static readonly CalculatorSyntaxFactory Instance = new CalculatorSyntaxFactory();
	
		public CalculatorSyntaxFactory() 
		{
			this.CarriageReturnLineFeed = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.CarriageReturnLineFeed.CreateRed();
			this.LineFeed = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.LineFeed.CreateRed();
			this.CarriageReturn = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.CarriageReturn.CreateRed();
			this.Space = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.Space.CreateRed();
			this.Tab = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.Tab.CreateRed();
			this.ElasticCarriageReturnLineFeed = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.ElasticCarriageReturnLineFeed.CreateRed();
			this.ElasticLineFeed = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.ElasticLineFeed.CreateRed();
			this.ElasticCarriageReturn = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.ElasticCarriageReturn.CreateRed();
			this.ElasticSpace = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.ElasticSpace.CreateRed();
			this.ElasticTab = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.ElasticTab.CreateRed();
			this.ElasticZeroSpace = (CalculatorSyntaxTrivia)CalculatorGreenFactory.Instance.ElasticZeroSpace.CreateRed();
		}
	
		public new CalculatorLanguage Language
		{
			get { return CalculatorLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
	    public CalculatorSyntaxTrivia CarriageReturnLineFeed { get; }
	    public CalculatorSyntaxTrivia LineFeed { get; }
	    public CalculatorSyntaxTrivia CarriageReturn { get; }
	    public CalculatorSyntaxTrivia Space { get; }
	    public CalculatorSyntaxTrivia Tab { get; }
	    public CalculatorSyntaxTrivia ElasticCarriageReturnLineFeed { get; }
	    public CalculatorSyntaxTrivia ElasticLineFeed { get; }
	    public CalculatorSyntaxTrivia ElasticCarriageReturn { get; }
	    public CalculatorSyntaxTrivia ElasticSpace { get; }
	    public CalculatorSyntaxTrivia ElasticTab { get; }
	    public CalculatorSyntaxTrivia ElasticZeroSpace { get; }
	
		private SyntaxToken defaultToken = null;
	    protected override SyntaxToken DefaultToken
	    {
	        get 
			{
				if (defaultToken != null) return defaultToken;
			    Interlocked.CompareExchange(ref defaultToken, this.Token(CalculatorSyntaxKind.None), null);
				return defaultToken;
			}
	    }
	
		private SyntaxTrivia defaultTrivia = null;
	    protected override SyntaxTrivia DefaultTrivia
	    {
	        get 
			{
				if (defaultTrivia != null) return defaultTrivia;
			    Interlocked.CompareExchange(ref defaultTrivia, this.Trivia(CalculatorSyntaxKind.None, string.Empty), null);
				return defaultTrivia;
			}
	    }
	
		private SyntaxToken defaultSeparator = null;
	    protected override SyntaxToken DefaultSeparator
	    {
	        get 
			{
				if (defaultSeparator != null) return defaultSeparator;
			    Interlocked.CompareExchange(ref defaultSeparator, this.Token(CalculatorSyntaxKind.TComma), null);
				return defaultSeparator;
			}
	    }
	
	    protected override SyntaxNode StructuredToken(SyntaxToken token)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxNode StructuredTrivia(SyntaxTrivia trivia)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxToken Token(SyntaxNode tokenStructure)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxTrivia Trivia(SyntaxNode triviaStructure)
	    {
	        throw new NotImplementedException();
	    }
	
		/// <summary>
		/// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
		/// can be inferred by the kind alone.
		/// </summary>
		/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
		/// <returns></returns>
		public SyntaxToken Token(CalculatorSyntaxKind kind)
		{
			return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.Token(kind).CreateRed();
		}
	
		public SyntaxTrivia Trivia(CalculatorSyntaxKind kind, string text)
		{
			return (SyntaxTrivia)CalculatorLanguage.Instance.InternalSyntaxFactory.Trivia(kind, text).CreateRed();
		}
	
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public CalculatorSyntaxTree SyntaxTree(SyntaxNode root, CalculatorParseOptions options = null, string path = "", Encoding encoding = null)
		{
		    return CalculatorSyntaxTree.Create((CalculatorSyntaxNode)root, (CalculatorParseOptions)options, path, encoding);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public CalculatorSyntaxTree ParseSyntaxTree(
		    string text,
		    CalculatorParseOptions options = null,
		    string path = "",
		    Encoding encoding = null,
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (CalculatorSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public CalculatorSyntaxTree ParseSyntaxTree(
		    SourceText text,
		    CalculatorParseOptions options = null,
		    string path = "",
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (CalculatorSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
	
		protected override SyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return CalculatorSyntaxTree.ParseText(text, (CalculatorParseOptions)options, path, cancellationToken);
		}
	
	    public MainSyntax ParseMain(string text)
	    {
	        // note that we do not need a "consumeFullText" parameter, because parsing a compilation unit always must
	        // consume input until the end-of-file
	        using (var parser = MakeParser(text))
	        {
	            var node = parser.Parse();
	            if (node == null) return null;
	            // if (consumeFullText) node = parser.ConsumeUnexpectedTokens(node);
	            return (MainSyntax)node.CreateRed();
	        }
	    }
	
		public override SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes)
		{
		    return new CalculatorSyntaxParser(text, (CalculatorParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new CalculatorSyntaxParser(SourceText.From(text, Encoding.UTF8), CalculatorParseOptions.Default, null, null);
		}
	
	    public SyntaxToken STRING(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.STRING(text).CreateRed();
	    }
	
	    public SyntaxToken STRING(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.STRING(text, value).CreateRed();
	    }
	
	    public SyntaxToken ID(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.ID(text).CreateRed();
	    }
	
	    public SyntaxToken ID(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.ID(text, value).CreateRed();
	    }
	
	    public SyntaxToken INT(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.INT(text).CreateRed();
	    }
	
	    public SyntaxToken INT(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.INT(text, value).CreateRed();
	    }
	
	    public SyntaxToken UTF8BOM(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.UTF8BOM(text).CreateRed();
	    }
	
	    public SyntaxToken UTF8BOM(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.UTF8BOM(text, value).CreateRed();
	    }
	
	    public SyntaxToken WHITESPACE(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.WHITESPACE(text).CreateRed();
	    }
	
	    public SyntaxToken WHITESPACE(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.WHITESPACE(text, value).CreateRed();
	    }
	
	    public SyntaxToken ENDL(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.ENDL(text).CreateRed();
	    }
	
	    public SyntaxToken ENDL(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.ENDL(text, value).CreateRed();
	    }
	
	    public SyntaxToken COMMENT(string text)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.COMMENT(text).CreateRed();
	    }
	
	    public SyntaxToken COMMENT(string text, object value)
	    {
	        return (SyntaxToken)CalculatorLanguage.Instance.InternalSyntaxFactory.COMMENT(text, value).CreateRed();
	    }
		
		public MainSyntax Main(SyntaxNodeList<StatementLineSyntax> statementLine, SyntaxToken eof)
		{
		    if (statementLine == null) throw new ArgumentNullException(nameof(statementLine));
		    if (eof == null) throw new ArgumentNullException(nameof(eof));
		    if (eof.RawKind != (int)CalculatorSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
		    return (MainSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Main(statementLine.Green, (InternalSyntaxToken)eof.Green).CreateRed();
		}
		
		public StatementLineSyntax StatementLine(StatementSyntax statement, SyntaxToken tSemicolon)
		{
		    if (statement == null) throw new ArgumentNullException(nameof(statement));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)CalculatorSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (StatementLineSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.StatementLine((Syntax.InternalSyntax.StatementGreen)statement.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public StatementLineSyntax StatementLine(StatementSyntax statement)
		{
			return this.StatementLine(statement, this.Token(CalculatorSyntaxKind.TSemicolon));
		}
		
		public StatementSyntax Statement(AssignmentSyntax assignment)
		{
		    if (assignment == null) throw new ArgumentNullException(nameof(assignment));
		    return (StatementSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.AssignmentGreen)assignment.Green).CreateRed();
		}
		
		public StatementSyntax Statement(ExpressionSyntax expression)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (StatementSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public AssignmentSyntax Assignment(IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.RawKind != (int)CalculatorSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (AssignmentSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Assignment((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tAssign.Green, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public AssignmentSyntax Assignment(IdentifierSyntax identifier, ExpressionSyntax expression)
		{
			return this.Assignment(identifier, this.Token(CalculatorSyntaxKind.TAssign), expression);
		}
		
		public ParenExpressionSyntax ParenExpression(SyntaxToken tOpenParen, ExpressionSyntax expression, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.RawKind != (int)CalculatorSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.RawKind != (int)CalculatorSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ParenExpressionSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.ParenExpression((InternalSyntaxToken)tOpenParen.Green, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParen.Green).CreateRed();
		}
		
		public ParenExpressionSyntax ParenExpression(ExpressionSyntax expression)
		{
			return this.ParenExpression(this.Token(CalculatorSyntaxKind.TOpenParen), expression, this.Token(CalculatorSyntaxKind.TCloseParen));
		}
		
		public MulOrDivExpressionSyntax MulOrDivExpression(ExpressionSyntax left, SyntaxToken _operator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (_operator == null) throw new ArgumentNullException(nameof(_operator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (MulOrDivExpressionSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.MulOrDivExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)_operator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public AddOrSubExpressionSyntax AddOrSubExpression(ExpressionSyntax left, SyntaxToken _operator, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (_operator == null) throw new ArgumentNullException(nameof(_operator));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AddOrSubExpressionSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.AddOrSubExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)_operator.Green, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public PrintExpressionSyntax PrintExpression(SyntaxToken kPrint, ArgsSyntax args)
		{
		    if (kPrint == null) throw new ArgumentNullException(nameof(kPrint));
		    if (kPrint.RawKind != (int)CalculatorSyntaxKind.KPrint) throw new ArgumentException(nameof(kPrint));
		    if (args == null) throw new ArgumentNullException(nameof(args));
		    return (PrintExpressionSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.PrintExpression((InternalSyntaxToken)kPrint.Green, (Syntax.InternalSyntax.ArgsGreen)args.Green).CreateRed();
		}
		
		public PrintExpressionSyntax PrintExpression(ArgsSyntax args)
		{
			return this.PrintExpression(this.Token(CalculatorSyntaxKind.KPrint), args);
		}
		
		public ValueExpressionSyntax ValueExpression(ValueSyntax value)
		{
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    return (ValueExpressionSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.ValueExpression((Syntax.InternalSyntax.ValueGreen)value.Green).CreateRed();
		}
		
		public ArgsSyntax Args(SeparatedSyntaxNodeList<ArgSyntax> arg)
		{
		    if (arg == null) throw new ArgumentNullException(nameof(arg));
		    return (ArgsSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Args(arg.Green).CreateRed();
		}
		
		public ValueSyntax Value(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ValueSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Value((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public ValueSyntax Value(StringSyntax _string)
		{
		    if (_string == null) throw new ArgumentNullException(nameof(_string));
		    return (ValueSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Value((Syntax.InternalSyntax.StringGreen)_string.Green).CreateRed();
		}
		
		public ValueSyntax Value(IntegerSyntax integer)
		{
		    if (integer == null) throw new ArgumentNullException(nameof(integer));
		    return (ValueSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Value((Syntax.InternalSyntax.IntegerGreen)integer.Green).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken id)
		{
		    if (id == null) throw new ArgumentNullException(nameof(id));
		    if (id.RawKind != (int)CalculatorSyntaxKind.ID) throw new ArgumentException(nameof(id));
		    return (IdentifierSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)id.Green).CreateRed();
		}
		
		public StringSyntax String(SyntaxToken _string)
		{
		    if (_string == null) throw new ArgumentNullException(nameof(_string));
		    if (_string.RawKind != (int)CalculatorSyntaxKind.STRING) throw new ArgumentException(nameof(_string));
		    return (StringSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.String((InternalSyntaxToken)_string.Green).CreateRed();
		}
		
		public IntegerSyntax Integer(SyntaxToken _int)
		{
		    if (_int == null) throw new ArgumentNullException(nameof(_int));
		    if (_int.RawKind != (int)CalculatorSyntaxKind.INT) throw new ArgumentException(nameof(_int));
		    return (IntegerSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Integer((InternalSyntaxToken)_int.Green).CreateRed();
		}
		
		public ArgSyntax Arg(ValueSyntax value)
		{
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    return (ArgSyntax)CalculatorLanguage.Instance.InternalSyntaxFactory.Arg((Syntax.InternalSyntax.ValueGreen)value.Green).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(StatementLineSyntax),
				typeof(StatementSyntax),
				typeof(AssignmentSyntax),
				typeof(ParenExpressionSyntax),
				typeof(MulOrDivExpressionSyntax),
				typeof(AddOrSubExpressionSyntax),
				typeof(PrintExpressionSyntax),
				typeof(ValueExpressionSyntax),
				typeof(ArgsSyntax),
				typeof(ValueSyntax),
				typeof(IdentifierSyntax),
				typeof(StringSyntax),
				typeof(IntegerSyntax),
				typeof(ArgSyntax),
			};
		}
	}
}


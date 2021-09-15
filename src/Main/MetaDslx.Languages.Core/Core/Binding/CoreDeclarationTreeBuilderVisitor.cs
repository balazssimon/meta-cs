// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Syntax;
using MetaDslx.Languages.Core.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Core.Model;

namespace MetaDslx.Languages.Core.Binding
{
	public class CoreDeclarationTreeBuilderVisitor : MetaDslx.CodeAnalysis.Declarations.DeclarationTreeBuilderVisitor, ICoreSyntaxVisitor
	{
        protected CoreDeclarationTreeBuilderVisitor(CoreSyntaxTree syntaxTree, MetaDslx.CodeAnalysis.Symbols.SymbolFacts symbolFacts, string scriptClassName, bool isSubmission)
            : base(syntaxTree, symbolFacts, scriptClassName, isSubmission)
        {
        }

        public static MetaDslx.CodeAnalysis.Declarations.RootSingleDeclaration ForTree(
            CoreSyntaxTree syntaxTree,
            MetaDslx.CodeAnalysis.Symbols.SymbolFacts symbolFacts,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new CoreDeclarationTreeBuilderVisitor(syntaxTree, symbolFacts, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }


		public virtual void VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.UsingNamespace != null)
			{
				foreach (var child in node.UsingNamespace)
				{
			        this.Visit(child);
				}
			}
			if (node.Statement != null)
			{
				foreach (var child in node.Statement)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitUsingNamespace(UsingNamespaceSyntax node)
		{
			this.BeginImport(node);
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndImport(node);
			}
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
			this.BeginDefine(node, type: typeof(ExpressionStatement));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Expression");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Expression");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ExpressionStatement));
			}
		}
		
		public virtual void VisitBlockStatement(BlockStatementSyntax node)
		{
			this.BeginDefine(node, type: typeof(BlockStatement));
			try
			{
				if (node.Statement != null)
				{
					foreach (var child in node.Statement)
					{
				        this.BeginProperty(child, name: "Statements");
				        try
				        {
				        	this.Visit(child);
				        }
				        finally
				        {
				        	this.EndProperty(child, name: "Statements");
				        }
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BlockStatement));
			}
		}
		
		public virtual void VisitParenthesizedExpr(ParenthesizedExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParenthesizedExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Operand");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Operand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ParenthesizedExpression));
			}
		}
		
		public virtual void VisitTupleExpr(TupleExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(TupleExpression));
			try
			{
				if (node.TupleArguments != null)
				{
				    this.Visit(node.TupleArguments);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(TupleExpression));
			}
		}
		
		public virtual void VisitDiscardExpr(DiscardExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(DiscardExpression));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(DiscardExpression));
			}
		}
		
		public virtual void VisitDefaultExpr(DefaultExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(DefaultValueExpression));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(DefaultValueExpression));
			}
		}
		
		public virtual void VisitThisExpr(ThisExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(InstanceReferenceExpression));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(InstanceReferenceExpression));
			}
		}
		
		public virtual void VisitBaseExpr(BaseExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(InstanceReferenceExpression));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(InstanceReferenceExpression));
			}
		}
		
		public virtual void VisitLiteralExpr(LiteralExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(LiteralExpression));
			try
			{
				if (node.Literal != null)
				{
				    this.BeginProperty(node.Literal, name: "Value");
				    try
				    {
				    	this.Visit(node.Literal);
				    }
				    finally
				    {
				    	this.EndProperty(node.Literal, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LiteralExpression));
			}
		}
		
		public virtual void VisitIdentifierExpr(IdentifierExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ReferenceExpression));
			try
			{
				if (node.Identifier != null)
				{
				    this.BeginProperty(node.Identifier, name: "ReferencedSymbol");
				    try
				    {
				    	this.BeginUse(node.Identifier, types: ImmutableArray.Create(typeof(Declaration)));
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Identifier, types: ImmutableArray.Create(typeof(Declaration)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "ReferencedSymbol");
				    }
				}
				if (node.GenericTypeArguments != null)
				{
				    this.Visit(node.GenericTypeArguments);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ReferenceExpression));
			}
		}
		
		public virtual void VisitQualifierExpr(QualifierExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ReferenceExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Qualifier");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Qualifier");
				    }
				}
				if (node.DotOperator != null)
				{
				    this.Visit(node.DotOperator);
				}
				if (node.Identifier != null)
				{
				    this.BeginProperty(node.Identifier, name: "ReferencedSymbol");
				    try
				    {
				    	this.BeginUse(node.Identifier, types: ImmutableArray.Create(typeof(Declaration)));
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Identifier, types: ImmutableArray.Create(typeof(Declaration)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "ReferencedSymbol");
				    }
				}
				if (node.GenericTypeArguments != null)
				{
				    this.Visit(node.GenericTypeArguments);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ReferenceExpression));
			}
		}
		
		public virtual void VisitIndexerExpr(IndexerExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(IndexerAccessExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Receiver");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Receiver");
				    }
				}
				if (node.IndexerOperator != null)
				{
				    this.Visit(node.IndexerOperator);
				}
				if (node.ArgumentList != null)
				{
				    this.Visit(node.ArgumentList);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(IndexerAccessExpression));
			}
		}
		
		public virtual void VisitInvocationExpr(InvocationExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(InvocationExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.Visit(node.Expression);
				}
				if (node.ArgumentList != null)
				{
				    this.Visit(node.ArgumentList);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(InvocationExpression));
			}
		}
		
		public virtual void VisitTypeofExpr(TypeofExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(TypeOfExpression));
			try
			{
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "TypeOperand");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "TypeOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(TypeOfExpression));
			}
		}
		
		public virtual void VisitNameofExpr(NameofExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(NameOfExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Argument");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Argument");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(NameOfExpression));
			}
		}
		
		public virtual void VisitSizeofExpr(SizeofExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(SizeOfExpression));
			try
			{
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "TypeOperand");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "TypeOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(SizeOfExpression));
			}
		}
		
		public virtual void VisitCheckedExpr(CheckedExprSyntax node)
		{
			if (node.Expression != null)
			{
			    this.Visit(node.Expression);
			}
		}
		
		public virtual void VisitUncheckedExpr(UncheckedExprSyntax node)
		{
			if (node.Expression != null)
			{
			    this.Visit(node.Expression);
			}
		}
		
		public virtual void VisitNewExpr(NewExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ObjectCreationExpression));
			try
			{
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "ObjectType");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "ObjectType");
				    }
				}
				if (node.ArgumentList != null)
				{
				    this.Visit(node.ArgumentList);
				}
				if (node.InitializerExpression != null)
				{
				    this.Visit(node.InitializerExpression);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ObjectCreationExpression));
			}
		}
		
		public virtual void VisitPostfixUnaryExpr(PostfixUnaryExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(UnaryExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Operand");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Operand");
				    }
				}
				if (node.PostfixOperator != null)
				{
				    this.BeginProperty(node.PostfixOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.PostfixOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.PostfixOperator, name: "OperatorKind");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(UnaryExpression));
			}
		}
		
		public virtual void VisitNullForgivingExpr(NullForgivingExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(NullForgivingExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Operand");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Operand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(NullForgivingExpression));
			}
		}
		
		public virtual void VisitUnaryExpr(UnaryExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(UnaryExpression));
			try
			{
				if (node.UnaryOperator != null)
				{
				    this.BeginProperty(node.UnaryOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.UnaryOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.UnaryOperator, name: "OperatorKind");
				    }
				}
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Operand");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Operand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(UnaryExpression));
			}
		}
		
		public virtual void VisitTypeCastExpr(TypeCastExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ConversionExpression));
			try
			{
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "TargetType");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "TargetType");
				    }
				}
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Operand");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Operand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ConversionExpression));
			}
		}
		
		public virtual void VisitAwaitExpr(AwaitExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(AwaitExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Operation");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Operation");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(AwaitExpression));
			}
		}
		
		public virtual void VisitRangeExpr(RangeExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.TDotDot.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.TDotDot, name: "OperatorKind");
				    try
				    {
				    	this.BeginValue(node.TDotDot, value: BinaryOperatorKind.Range);
				    	try
				    	{
				    		this.Visit(node.TDotDot);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.TDotDot, value: BinaryOperatorKind.Range);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.TDotDot, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitMultExpr(MultExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.MultiplicativeOperator != null)
				{
				    this.BeginProperty(node.MultiplicativeOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.MultiplicativeOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.MultiplicativeOperator, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitAddExpr(AddExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.AdditiveOperator != null)
				{
				    this.BeginProperty(node.AdditiveOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.AdditiveOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.AdditiveOperator, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitShiftExpr(ShiftExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.ShiftOperator != null)
				{
				    this.BeginProperty(node.ShiftOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.ShiftOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.ShiftOperator, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitRelExpr(RelExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.RelationalOperator != null)
				{
				    this.BeginProperty(node.RelationalOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.RelationalOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.RelationalOperator, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitTypeIsExpr(TypeIsExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(IsTypeExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "ValueOperand");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "ValueOperand");
				    }
				}
				if (node.KNot.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.KNot, name: "IsNegated", value: true);
				    try
				    {
				    	this.Visit(node.KNot);
				    }
				    finally
				    {
				    	this.EndProperty(node.KNot, name: "IsNegated", value: true);
				    }
				}
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "TypeOperand");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "TypeOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(IsTypeExpression));
			}
		}
		
		public virtual void VisitTypeAsExpr(TypeAsExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ConversionExpression));
			try
			{
				this.BeginProperty(node, name: "IsTryCast", value: true);
				try
				{
					if (node.Expression != null)
					{
					    this.BeginProperty(node.Expression, name: "Operand");
					    try
					    {
					    	this.Visit(node.Expression);
					    }
					    finally
					    {
					    	this.EndProperty(node.Expression, name: "Operand");
					    }
					}
					if (node.TypeReference != null)
					{
					    this.BeginProperty(node.TypeReference, name: "TargetType");
					    try
					    {
					    	this.Visit(node.TypeReference);
					    }
					    finally
					    {
					    	this.EndProperty(node.TypeReference, name: "TargetType");
					    }
					}
				}
				finally
				{
					this.EndProperty(node, name: "IsTryCast", value: true);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ConversionExpression));
			}
		}
		
		public virtual void VisitEqExpr(EqExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.EqualityOperator != null)
				{
				    this.BeginProperty(node.EqualityOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.EqualityOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.EqualityOperator, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitAndExpr(AndExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.TAmpersand.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.TAmpersand, name: "OperatorKind");
				    try
				    {
				    	this.BeginValue(node.TAmpersand, value: BinaryOperatorKind.BitwiseAnd);
				    	try
				    	{
				    		this.Visit(node.TAmpersand);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.TAmpersand, value: BinaryOperatorKind.BitwiseAnd);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.TAmpersand, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitXorExpr(XorExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.THat.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.THat, name: "OperatorKind");
				    try
				    {
				    	this.BeginValue(node.THat, value: BinaryOperatorKind.BitwiseXor);
				    	try
				    	{
				    		this.Visit(node.THat);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.THat, value: BinaryOperatorKind.BitwiseXor);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.THat, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitOrExpr(OrExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.TBar.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.TBar, name: "OperatorKind");
				    try
				    {
				    	this.BeginValue(node.TBar, value: BinaryOperatorKind.BitwiseOr);
				    	try
				    	{
				    		this.Visit(node.TBar);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.TBar, value: BinaryOperatorKind.BitwiseOr);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.TBar, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitAndAlsoExpr(AndAlsoExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.TAndAlso.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.TAndAlso, name: "OperatorKind");
				    try
				    {
				    	this.BeginValue(node.TAndAlso, value: BinaryOperatorKind.LogicalAnd);
				    	try
				    	{
				    		this.Visit(node.TAndAlso);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.TAndAlso, value: BinaryOperatorKind.LogicalAnd);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.TAndAlso, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitOrElseExpr(OrElseExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(BinaryExpression));
			try
			{
				if (node.Left != null)
				{
				    this.BeginProperty(node.Left, name: "LeftOperand");
				    try
				    {
				    	this.Visit(node.Left);
				    }
				    finally
				    {
				    	this.EndProperty(node.Left, name: "LeftOperand");
				    }
				}
				if (node.TOrElse.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.TOrElse, name: "OperatorKind");
				    try
				    {
				    	this.BeginValue(node.TOrElse, value: BinaryOperatorKind.LogicalOr);
				    	try
				    	{
				    		this.Visit(node.TOrElse);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.TOrElse, value: BinaryOperatorKind.LogicalOr);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.TOrElse, name: "OperatorKind");
				    }
				}
				if (node.Right != null)
				{
				    this.BeginProperty(node.Right, name: "RightOperand");
				    try
				    {
				    	this.Visit(node.Right);
				    }
				    finally
				    {
				    	this.EndProperty(node.Right, name: "RightOperand");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BinaryExpression));
			}
		}
		
		public virtual void VisitThrowExpr(ThrowExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ThrowExpression));
			try
			{
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Exception");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Exception");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ThrowExpression));
			}
		}
		
		public virtual void VisitCoalExpr(CoalExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(CoalesceExpression));
			try
			{
				if (node.Value != null)
				{
				    this.BeginProperty(node.Value, name: "Value");
				    try
				    {
				    	this.Visit(node.Value);
				    }
				    finally
				    {
				    	this.EndProperty(node.Value, name: "Value");
				    }
				}
				if (node.WhenNull != null)
				{
				    this.BeginProperty(node.WhenNull, name: "WhenNull");
				    try
				    {
				    	this.Visit(node.WhenNull);
				    }
				    finally
				    {
				    	this.EndProperty(node.WhenNull, name: "WhenNull");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(CoalesceExpression));
			}
		}
		
		public virtual void VisitCondExpr(CondExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(ConditionalExpression));
			try
			{
				if (node.Condition != null)
				{
				    this.BeginProperty(node.Condition, name: "Condition");
				    try
				    {
				    	this.Visit(node.Condition);
				    }
				    finally
				    {
				    	this.EndProperty(node.Condition, name: "Condition");
				    }
				}
				if (node.WhenTrue != null)
				{
				    this.BeginProperty(node.WhenTrue, name: "WhenTrue");
				    try
				    {
				    	this.Visit(node.WhenTrue);
				    }
				    finally
				    {
				    	this.EndProperty(node.WhenTrue, name: "WhenTrue");
				    }
				}
				if (node.WhenFalse != null)
				{
				    this.BeginProperty(node.WhenFalse, name: "WhenFalse");
				    try
				    {
				    	this.Visit(node.WhenFalse);
				    }
				    finally
				    {
				    	this.EndProperty(node.WhenFalse, name: "WhenFalse");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ConditionalExpression));
			}
		}
		
		public virtual void VisitAssignExpr(AssignExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(AssignmentExpression));
			try
			{
				if (node.Target != null)
				{
				    this.BeginProperty(node.Target, name: "Target");
				    try
				    {
				    	this.Visit(node.Target);
				    }
				    finally
				    {
				    	this.EndProperty(node.Target, name: "Target");
				    }
				}
				if (node.Value != null)
				{
				    this.BeginProperty(node.Value, name: "Value");
				    try
				    {
				    	this.Visit(node.Value);
				    }
				    finally
				    {
				    	this.EndProperty(node.Value, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(AssignmentExpression));
			}
		}
		
		public virtual void VisitCompAssignExpr(CompAssignExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(CompoundAssignmentExpression));
			try
			{
				if (node.Target != null)
				{
				    this.BeginProperty(node.Target, name: "Target");
				    try
				    {
				    	this.Visit(node.Target);
				    }
				    finally
				    {
				    	this.EndProperty(node.Target, name: "Target");
				    }
				}
				if (node.CompoundAssignmentOperator != null)
				{
				    this.BeginProperty(node.CompoundAssignmentOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.CompoundAssignmentOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.CompoundAssignmentOperator, name: "OperatorKind");
				    }
				}
				if (node.Value != null)
				{
				    this.BeginProperty(node.Value, name: "Value");
				    try
				    {
				    	this.Visit(node.Value);
				    }
				    finally
				    {
				    	this.EndProperty(node.Value, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(CompoundAssignmentExpression));
			}
		}
		
		public virtual void VisitLambdaExpr(LambdaExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(LambdaExpression));
			try
			{
				if (node.LambdaSignature != null)
				{
				    this.Visit(node.LambdaSignature);
				}
				if (node.LambdaBody != null)
				{
				    this.Visit(node.LambdaBody);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LambdaExpression));
			}
		}
		
		public virtual void VisitTupleArguments(TupleArgumentsSyntax node)
		{
			this.BeginProperty(node, name: "Arguments");
			try
			{
				if (node.ArgumentExpression != null)
				{
				    this.Visit(node.ArgumentExpression);
				}
				if (node.ArgumentList != null)
				{
				    this.Visit(node.ArgumentList);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Arguments");
			}
		}
		
		public virtual void VisitArgumentList(ArgumentListSyntax node)
		{
			this.BeginProperty(node, name: "Arguments");
			try
			{
				if (node.ArgumentExpression != null)
				{
					foreach (var child in node.ArgumentExpression)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty(node, name: "Arguments");
			}
		}
		
		public virtual void VisitArgumentExpression(ArgumentExpressionSyntax node)
		{
			this.BeginDefine(node, type: typeof(Argument));
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Value");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(Argument));
			}
		}
		
		public virtual void VisitInitializerExpression(InitializerExpressionSyntax node)
		{
			if (node.FieldInitializerExpressions != null)
			{
			    this.Visit(node.FieldInitializerExpressions);
			}
			if (node.CollectionInitializerExpressions != null)
			{
			    this.Visit(node.CollectionInitializerExpressions);
			}
			if (node.DictionaryInitializerExpressions != null)
			{
			    this.Visit(node.DictionaryInitializerExpressions);
			}
		}
		
		public virtual void VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax node)
		{
			if (node.FieldInitializerExpression != null)
			{
				foreach (var child in node.FieldInitializerExpression)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitFieldInitializerExpression(FieldInitializerExpressionSyntax node)
		{
			this.BeginDefine(node, type: typeof(AssignmentExpression));
			try
			{
				if (node.Identifier != null)
				{
				    this.BeginProperty(node.Identifier, name: "Target");
				    try
				    {
				    	this.BeginUse(node.Identifier, types: ImmutableArray.Create(typeof(FieldLikeMember)));
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Identifier, types: ImmutableArray.Create(typeof(FieldLikeMember)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "Target");
				    }
				}
				if (node.Expression != null)
				{
				    this.BeginProperty(node.Expression, name: "Value");
				    try
				    {
				    	this.Visit(node.Expression);
				    }
				    finally
				    {
				    	this.EndProperty(node.Expression, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(AssignmentExpression));
			}
		}
		
		public virtual void VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node)
		{
			if (node.Expression != null)
			{
				foreach (var child in node.Expression)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node)
		{
			if (node.DictionaryInitializerExpression != null)
			{
				foreach (var child in node.DictionaryInitializerExpression)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node)
		{
			if (node.Identifier != null)
			{
			    this.Visit(node.Identifier);
			}
			if (node.Expression != null)
			{
			    this.Visit(node.Expression);
			}
		}
		
		public virtual void VisitLambdaSignature(LambdaSignatureSyntax node)
		{
			if (node.ImplicitLambdaSignature != null)
			{
			    this.Visit(node.ImplicitLambdaSignature);
			}
			if (node.ExplicitLambdaSignature != null)
			{
			    this.Visit(node.ExplicitLambdaSignature);
			}
		}
		
		public virtual void VisitImplicitLambdaSignature(ImplicitLambdaSignatureSyntax node)
		{
			if (node.ImplicitParameter != null)
			{
			    this.Visit(node.ImplicitParameter);
			}
			if (node.ImplicitParameterList != null)
			{
			    this.Visit(node.ImplicitParameterList);
			}
		}
		
		public virtual void VisitImplicitParameterList(ImplicitParameterListSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				if (node.ImplicitParameter != null)
				{
					foreach (var child in node.ImplicitParameter)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty(node, name: "Parameters");
			}
		}
		
		public virtual void VisitImplicitParameter(ImplicitParameterSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				this.BeginDefine(node, type: typeof(Parameter));
				try
				{
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Parameter));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Parameters");
			}
		}
		
		public virtual void VisitExplicitLambdaSignature(ExplicitLambdaSignatureSyntax node)
		{
			if (node.ExplicitParameterList != null)
			{
			    this.Visit(node.ExplicitParameterList);
			}
		}
		
		public virtual void VisitExplicitParameterList(ExplicitParameterListSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				if (node.ExplicitParameter != null)
				{
					foreach (var child in node.ExplicitParameter)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty(node, name: "Parameters");
			}
		}
		
		public virtual void VisitExplicitParameter(ExplicitParameterSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				this.BeginDefine(node, type: typeof(Parameter));
				try
				{
					if (node.TypeReference != null)
					{
					    this.BeginProperty(node.TypeReference, name: "Type");
					    try
					    {
					    	this.Visit(node.TypeReference);
					    }
					    finally
					    {
					    	this.EndProperty(node.TypeReference, name: "Type");
					    }
					}
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Parameter));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Parameters");
			}
		}
		
		public virtual void VisitLambdaBody(LambdaBodySyntax node)
		{
			this.BeginProperty(node, name: "Body");
			try
			{
				if (node.Expression != null)
				{
				    this.BeginDefine(node.Expression, type: typeof(ExpressionStatement));
				    try
				    {
				    	this.BeginProperty(node.Expression, name: "Expression");
				    	try
				    	{
				    		this.Visit(node.Expression);
				    	}
				    	finally
				    	{
				    		this.EndProperty(node.Expression, name: "Expression");
				    	}
				    }
				    finally
				    {
				    	this.EndDefine(node.Expression, type: typeof(ExpressionStatement));
				    }
				}
				if (node.BlockStatement != null)
				{
				    this.Visit(node.BlockStatement);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Body");
			}
		}
		
		public virtual void VisitDotOperator(DotOperatorSyntax node)
		{
			if (node.DotOperator != null)
			{
			    switch (node.DotOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TDot:
			    		this.Visit(node.DotOperator);
			    		break;
			    	case CoreSyntaxKind.TQuestionDot:
			    		this.BeginProperty(node.DotOperator, name: "IsNullConditional", value: true);
			    		try
			    		{
			    			this.Visit(node.DotOperator);
			    		}
			    		finally
			    		{
			    			this.EndProperty(node.DotOperator, name: "IsNullConditional", value: true);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitIndexerOperator(IndexerOperatorSyntax node)
		{
			if (node.IndexerOperator != null)
			{
			    switch (node.IndexerOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TOpenBracket:
			    		this.Visit(node.IndexerOperator);
			    		break;
			    	case CoreSyntaxKind.TQuestionOpenBracket:
			    		this.BeginProperty(node.IndexerOperator, name: "IsNullConditional", value: true);
			    		try
			    		{
			    			this.Visit(node.IndexerOperator);
			    		}
			    		finally
			    		{
			    			this.EndProperty(node.IndexerOperator, name: "IsNullConditional", value: true);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitPostfixOperator(PostfixOperatorSyntax node)
		{
			if (node.PostfixOperator != null)
			{
			    switch (node.PostfixOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TPlusPlus:
			    		this.BeginValue(node.PostfixOperator, value: UnaryOperatorKind.PostfixIncrement);
			    		try
			    		{
			    			this.Visit(node.PostfixOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PostfixOperator, value: UnaryOperatorKind.PostfixIncrement);
			    		}
			    		break;
			    	case CoreSyntaxKind.TMinusMinus:
			    		this.BeginValue(node.PostfixOperator, value: UnaryOperatorKind.PostfixDecrement);
			    		try
			    		{
			    			this.Visit(node.PostfixOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PostfixOperator, value: UnaryOperatorKind.PostfixDecrement);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitUnaryOperator(UnaryOperatorSyntax node)
		{
			if (node.UnaryOperator != null)
			{
			    switch (node.UnaryOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TPlus:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.UnaryPlus);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.UnaryPlus);
			    		}
			    		break;
			    	case CoreSyntaxKind.TMinus:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.UnaryMinus);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.UnaryMinus);
			    		}
			    		break;
			    	case CoreSyntaxKind.TExclamation:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.LogicalNegation);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.LogicalNegation);
			    		}
			    		break;
			    	case CoreSyntaxKind.TTilde:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.BitwiseComplement);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.BitwiseComplement);
			    		}
			    		break;
			    	case CoreSyntaxKind.TPlusPlus:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.PrefixIncrement);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.PrefixIncrement);
			    		}
			    		break;
			    	case CoreSyntaxKind.TMinusMinus:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.PrefixDecrement);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.PrefixDecrement);
			    		}
			    		break;
			    	case CoreSyntaxKind.THat:
			    		this.BeginValue(node.UnaryOperator, value: UnaryOperatorKind.IndexFromEnd);
			    		try
			    		{
			    			this.Visit(node.UnaryOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.UnaryOperator, value: UnaryOperatorKind.IndexFromEnd);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitMultiplicativeOperator(MultiplicativeOperatorSyntax node)
		{
			if (node.MultiplicativeOperator != null)
			{
			    switch (node.MultiplicativeOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TAsterisk:
			    		this.BeginValue(node.MultiplicativeOperator, value: BinaryOperatorKind.Multiplication);
			    		try
			    		{
			    			this.Visit(node.MultiplicativeOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.MultiplicativeOperator, value: BinaryOperatorKind.Multiplication);
			    		}
			    		break;
			    	case CoreSyntaxKind.TSlash:
			    		this.BeginValue(node.MultiplicativeOperator, value: BinaryOperatorKind.Division);
			    		try
			    		{
			    			this.Visit(node.MultiplicativeOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.MultiplicativeOperator, value: BinaryOperatorKind.Division);
			    		}
			    		break;
			    	case CoreSyntaxKind.TPercent:
			    		this.BeginValue(node.MultiplicativeOperator, value: BinaryOperatorKind.Remainder);
			    		try
			    		{
			    			this.Visit(node.MultiplicativeOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.MultiplicativeOperator, value: BinaryOperatorKind.Remainder);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitAdditiveOperator(AdditiveOperatorSyntax node)
		{
			this.BeginProperty(node, name: "OperatorKind");
			try
			{
				if (node.AdditiveOperator != null)
				{
				    switch (node.AdditiveOperator.GetKind().Switch())
				    {
				    	case CoreSyntaxKind.TPlus:
				    		this.BeginValue(node.AdditiveOperator, value: BinaryOperatorKind.Addition);
				    		try
				    		{
				    			this.Visit(node.AdditiveOperator);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.AdditiveOperator, value: BinaryOperatorKind.Addition);
				    		}
				    		break;
				    	case CoreSyntaxKind.TMinus:
				    		this.BeginValue(node.AdditiveOperator, value: BinaryOperatorKind.Subtraction);
				    		try
				    		{
				    			this.Visit(node.AdditiveOperator);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.AdditiveOperator, value: BinaryOperatorKind.Subtraction);
				    		}
				    		break;
				    	default:
				    		break;
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "OperatorKind");
			}
		}
		
		public virtual void VisitShiftOperator(ShiftOperatorSyntax node)
		{
			if (node.LeftShiftOperator != null)
			{
			    this.Visit(node.LeftShiftOperator);
			}
			if (node.RightShiftOperator != null)
			{
			    this.Visit(node.RightShiftOperator);
			}
		}
		
		public virtual void VisitLeftShiftOperator(LeftShiftOperatorSyntax node)
		{
			this.BeginValue(node, value: BinaryOperatorKind.LeftShift);
			try
			{
			}
			finally
			{
				this.EndValue(node, value: BinaryOperatorKind.LeftShift);
			}
		}
		
		public virtual void VisitRightShiftOperator(RightShiftOperatorSyntax node)
		{
			this.BeginValue(node, value: BinaryOperatorKind.RightShift);
			try
			{
			}
			finally
			{
				this.EndValue(node, value: BinaryOperatorKind.RightShift);
			}
		}
		
		public virtual void VisitRelationalOperator(RelationalOperatorSyntax node)
		{
			if (node.RelationalOperator != null)
			{
			    switch (node.RelationalOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TLessThan:
			    		this.BeginValue(node.RelationalOperator, value: BinaryOperatorKind.LessThan);
			    		try
			    		{
			    			this.Visit(node.RelationalOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.RelationalOperator, value: BinaryOperatorKind.LessThan);
			    		}
			    		break;
			    	case CoreSyntaxKind.TGreaterThan:
			    		this.BeginValue(node.RelationalOperator, value: BinaryOperatorKind.GreaterThan);
			    		try
			    		{
			    			this.Visit(node.RelationalOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.RelationalOperator, value: BinaryOperatorKind.GreaterThan);
			    		}
			    		break;
			    	case CoreSyntaxKind.TLessThanOrEqual:
			    		this.BeginValue(node.RelationalOperator, value: BinaryOperatorKind.LessThanOrEqual);
			    		try
			    		{
			    			this.Visit(node.RelationalOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.RelationalOperator, value: BinaryOperatorKind.LessThanOrEqual);
			    		}
			    		break;
			    	case CoreSyntaxKind.TGreaterThanOrEqual:
			    		this.BeginValue(node.RelationalOperator, value: BinaryOperatorKind.GreaterThanOrEqual);
			    		try
			    		{
			    			this.Visit(node.RelationalOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.RelationalOperator, value: BinaryOperatorKind.GreaterThanOrEqual);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitEqualityOperator(EqualityOperatorSyntax node)
		{
			if (node.EqualityOperator != null)
			{
			    switch (node.EqualityOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TEqual:
			    		this.BeginValue(node.EqualityOperator, value: BinaryOperatorKind.Equal);
			    		try
			    		{
			    			this.Visit(node.EqualityOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.EqualityOperator, value: BinaryOperatorKind.Equal);
			    		}
			    		break;
			    	case CoreSyntaxKind.TNotEqual:
			    		this.BeginValue(node.EqualityOperator, value: BinaryOperatorKind.NotEqual);
			    		try
			    		{
			    			this.Visit(node.EqualityOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.EqualityOperator, value: BinaryOperatorKind.NotEqual);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node)
		{
			if (node.CompoundAssignmentOperator != null)
			{
			    switch (node.CompoundAssignmentOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TPlusAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Addition);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Addition);
			    		}
			    		break;
			    	case CoreSyntaxKind.TMinusAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Subtraction);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Subtraction);
			    		}
			    		break;
			    	case CoreSyntaxKind.TAsteriskAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Multiplication);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Multiplication);
			    		}
			    		break;
			    	case CoreSyntaxKind.TSlashAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Division);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Division);
			    		}
			    		break;
			    	case CoreSyntaxKind.TPercentAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Remainder);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.Remainder);
			    		}
			    		break;
			    	case CoreSyntaxKind.TAmpersandAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalAnd);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalAnd);
			    		}
			    		break;
			    	case CoreSyntaxKind.THatAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalXor);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalXor);
			    		}
			    		break;
			    	case CoreSyntaxKind.TBarAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalOr);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalOr);
			    		}
			    		break;
			    	case CoreSyntaxKind.TLeftShiftAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LeftShift);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.LeftShift);
			    		}
			    		break;
			    	case CoreSyntaxKind.TRightShiftAssign:
			    		this.BeginValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.RightShift);
			    		try
			    		{
			    			this.Visit(node.CompoundAssignmentOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.CompoundAssignmentOperator, value: BinaryOperatorKind.RightShift);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			if (node.TypeReference != null)
			{
			    this.Visit(node.TypeReference);
			}
			if (node.VoidType != null)
			{
			    this.Visit(node.VoidType);
			}
		}
		
		public virtual void VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				if (node.PrimitiveType != null)
				{
				    this.Visit(node.PrimitiveType);
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(DataType)));
			}
		}
		
		public virtual void VisitGenericTypeRef(GenericTypeRefSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.BeginDefine(node, type: typeof(GenericTypeReference));
				try
				{
					if (node.NamedType != null)
					{
					    this.BeginProperty(node.NamedType, name: "ReferencedType");
					    try
					    {
					    	this.Visit(node.NamedType);
					    }
					    finally
					    {
					    	this.EndProperty(node.NamedType, name: "ReferencedType");
					    }
					}
					if (node.GenericTypeArguments != null)
					{
					    this.Visit(node.GenericTypeArguments);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(GenericTypeReference));
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(DataType)));
			}
		}
		
		public virtual void VisitNamedTypeRef(NamedTypeRefSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.BeginUse(node, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)));
				try
				{
					if (node.Qualifier != null)
					{
					    this.Visit(node.Qualifier);
					}
				}
				finally
				{
					this.EndUse(node, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)));
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(DataType)));
			}
		}
		
		public virtual void VisitArrayTypeRef(ArrayTypeRefSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.BeginDefine(node, type: typeof(ArrayType));
				try
				{
					if (node.TypeReference != null)
					{
					    this.BeginProperty(node.TypeReference, name: "ElementType");
					    try
					    {
					    	this.Visit(node.TypeReference);
					    }
					    finally
					    {
					    	this.EndProperty(node.TypeReference, name: "ElementType");
					    }
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(ArrayType));
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(DataType)));
			}
		}
		
		public virtual void VisitNullableTypeRef(NullableTypeRefSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				if (node.TypeReference != null)
				{
				    this.BeginProperty(node.TypeReference, name: "InnerType");
				    try
				    {
				    	this.Visit(node.TypeReference);
				    }
				    finally
				    {
				    	this.EndProperty(node.TypeReference, name: "InnerType");
				    }
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(DataType)));
			}
		}
		
		public virtual void VisitNamedType(NamedTypeSyntax node)
		{
			this.BeginUse(node, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)));
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndUse(node, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)));
			}
		}
		
		public virtual void VisitGenericTypeArguments(GenericTypeArgumentsSyntax node)
		{
			this.BeginProperty(node, name: "TypeArguments");
			try
			{
				if (node.GenericTypeArgument != null)
				{
					foreach (var child in node.GenericTypeArgument)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty(node, name: "TypeArguments");
			}
		}
		
		public virtual void VisitGenericTypeArgument(GenericTypeArgumentSyntax node)
		{
			if (node.TypeReference != null)
			{
			    this.Visit(node.TypeReference);
			}
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			if (node.PrimitiveType != null)
			{
			    switch (node.PrimitiveType.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.KObject:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Object);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Object);
			    		}
			    		break;
			    	case CoreSyntaxKind.KBool:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Boolean);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Boolean);
			    		}
			    		break;
			    	case CoreSyntaxKind.KChar:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Char);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Char);
			    		}
			    		break;
			    	case CoreSyntaxKind.KSByte:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.SByte);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.SByte);
			    		}
			    		break;
			    	case CoreSyntaxKind.KByte:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Byte);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Byte);
			    		}
			    		break;
			    	case CoreSyntaxKind.KShort:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Int16);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Int16);
			    		}
			    		break;
			    	case CoreSyntaxKind.KUShort:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.UInt16);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.UInt16);
			    		}
			    		break;
			    	case CoreSyntaxKind.KInt:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Int32);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Int32);
			    		}
			    		break;
			    	case CoreSyntaxKind.KUInt:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.UInt32);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.UInt32);
			    		}
			    		break;
			    	case CoreSyntaxKind.KLong:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Int64);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Int64);
			    		}
			    		break;
			    	case CoreSyntaxKind.KULong:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.UInt64);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.UInt64);
			    		}
			    		break;
			    	case CoreSyntaxKind.KDecimal:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Decimal);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Decimal);
			    		}
			    		break;
			    	case CoreSyntaxKind.KFloat:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Single);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Single);
			    		}
			    		break;
			    	case CoreSyntaxKind.KDouble:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.Double);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.Double);
			    		}
			    		break;
			    	case CoreSyntaxKind.KString:
			    		this.BeginValue(node.PrimitiveType, value: CoreInstance.String);
			    		try
			    		{
			    			this.Visit(node.PrimitiveType);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrimitiveType, value: CoreInstance.String);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			this.BeginValue(node, value: CoreInstance.Void);
			try
			{
			}
			finally
			{
				this.EndValue(node, value: CoreInstance.Void);
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
				if (node.Identifier != null)
				{
				    this.Visit(node.Identifier);
				}
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.BeginQualifier(node);
			try
			{
				if (node.Identifier != null)
				{
					foreach (var child in node.Identifier)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndQualifier(node);
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			this.BeginIdentifier(node);
			try
			{
			}
			finally
			{
				this.EndIdentifier(node);
			}
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			if (node.NullLiteral != null)
			{
			    this.Visit(node.NullLiteral);
			}
			if (node.BooleanLiteral != null)
			{
			    this.Visit(node.BooleanLiteral);
			}
			if (node.IntegerLiteral != null)
			{
			    this.Visit(node.IntegerLiteral);
			}
			if (node.DecimalLiteral != null)
			{
			    this.Visit(node.DecimalLiteral);
			}
			if (node.ScientificLiteral != null)
			{
			    this.Visit(node.ScientificLiteral);
			}
			if (node.StringLiteral != null)
			{
			    this.Visit(node.StringLiteral);
			}
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			this.BeginProperty(node, name: "Type", value: CoreInstance.Boolean);
			try
			{
				this.BeginValue(node);
				try
				{
				}
				finally
				{
					this.EndValue(node);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Type", value: CoreInstance.Boolean);
			}
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			this.BeginProperty(node, name: "Type", value: CoreInstance.Int32);
			try
			{
				this.BeginValue(node);
				try
				{
				}
				finally
				{
					this.EndValue(node);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Type", value: CoreInstance.Int32);
			}
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			this.BeginProperty(node, name: "Type", value: CoreInstance.Decimal);
			try
			{
				this.BeginValue(node);
				try
				{
				}
				finally
				{
					this.EndValue(node);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Type", value: CoreInstance.Decimal);
			}
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			this.BeginProperty(node, name: "Type", value: CoreInstance.Double);
			try
			{
				this.BeginValue(node);
				try
				{
				}
				finally
				{
					this.EndValue(node);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Type", value: CoreInstance.Double);
			}
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
			this.BeginProperty(node, name: "Type", value: CoreInstance.String);
			try
			{
				this.BeginValue(node);
				try
				{
				}
				finally
				{
					this.EndValue(node);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Type", value: CoreInstance.String);
			}
		}
	}
}


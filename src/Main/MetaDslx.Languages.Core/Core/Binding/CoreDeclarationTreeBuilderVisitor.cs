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


        protected virtual void BeginLocalScope(SyntaxNodeOrToken syntax)
        {
        }

        protected virtual void EndLocalScope(SyntaxNodeOrToken syntax)
        {
        }

		public virtual void VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.BeginProperty(node, name: "Members");
			try
			{
				this.BeginDefine(node, type: typeof(Namespace));
				try
				{
					this.BeginScope(node);
					try
					{
						if (node.UsingNamespace != null)
						{
							foreach (var child in node.UsingNamespace)
							{
						        this.Visit(child);
							}
						}
						if (node.Declaration != null)
						{
							foreach (var child in node.Declaration)
							{
						        this.Visit(child);
							}
						}
						if (node.MainBlock != null)
						{
						    this.Visit(node.MainBlock);
						}
					}
					finally
					{
						this.EndScope(node);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Namespace));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Members");
			}
		}
		
		public virtual void VisitMainBlock(MainBlockSyntax node)
		{
			this.BeginDefine(node, type: typeof(BlockStatement));
			try
			{
				this.BeginLocalScope(node);
				try
				{
					this.BeginProperty(node, name: "Statements");
					try
					{
						if (node.Statement != null)
						{
							foreach (var child in node.Statement)
							{
						        this.Visit(child);
							}
						}
					}
					finally
					{
						this.EndProperty(node, name: "Statements");
					}
				}
				finally
				{
					this.EndLocalScope(node);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BlockStatement));
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
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Members");
			try
			{
				if (node.AliasDeclaration != null)
				{
				    this.Visit(node.AliasDeclaration);
				}
				if (node.EnumDeclaration != null)
				{
				    this.Visit(node.EnumDeclaration);
				}
				if (node.StructDeclaration != null)
				{
				    this.Visit(node.StructDeclaration);
				}
				if (node.FunctionDeclaration != null)
				{
				    this.Visit(node.FunctionDeclaration);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Members");
			}
		}
		
		public virtual void VisitAliasDeclaration(AliasDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(Alias));
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.Qualifier != null)
				{
				    this.BeginUse(node.Qualifier, types: ImmutableArray.Create(typeof(Declaration)));
				    try
				    {
				    	this.Visit(node.Qualifier);
				    }
				    finally
				    {
				    	this.EndUse(node.Qualifier, types: ImmutableArray.Create(typeof(Declaration)));
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(Alias));
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(EnumType));
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.EnumLiteralList != null)
				{
				    this.Visit(node.EnumLiteralList);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(EnumType));
			}
		}
		
		public virtual void VisitEnumLiteralList(EnumLiteralListSyntax node)
		{
			if (node.EnumLiteral != null)
			{
				foreach (var child in node.EnumLiteral)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			this.BeginProperty(node, name: "Members");
			try
			{
				this.BeginDefine(node, type: typeof(EnumLiteral));
				try
				{
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(EnumLiteral));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Members");
			}
		}
		
		public virtual void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(StructType));
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.StructField != null)
				{
					foreach (var child in node.StructField)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(StructType));
			}
		}
		
		public virtual void VisitStructField(StructFieldSyntax node)
		{
			this.BeginProperty(node, name: "Members");
			try
			{
				this.BeginDefine(node, type: typeof(Field));
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
					if (node.Expression != null)
					{
					    this.BeginProperty(node.Expression, name: "DeclaredInitializer");
					    try
					    {
					    	this.Visit(node.Expression);
					    }
					    finally
					    {
					    	this.EndProperty(node.Expression, name: "DeclaredInitializer");
					    }
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Field));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Members");
			}
		}
		
		public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(Function));
			try
			{
				if (node.FunctionResult != null)
				{
				    this.Visit(node.FunctionResult);
				}
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.FunctionParameterList != null)
				{
				    this.Visit(node.FunctionParameterList);
				}
				if (node.BlockStatement != null)
				{
				    this.BeginLocalScope(node.BlockStatement);
				    try
				    {
				    	this.BeginProperty(node.BlockStatement, name: "Body");
				    	try
				    	{
				    		this.Visit(node.BlockStatement);
				    	}
				    	finally
				    	{
				    		this.EndProperty(node.BlockStatement, name: "Body");
				    	}
				    }
				    finally
				    {
				    	this.EndLocalScope(node.BlockStatement);
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(Function));
			}
		}
		
		public virtual void VisitFunctionParameterList(FunctionParameterListSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				if (node.FunctionParameter != null)
				{
					foreach (var child in node.FunctionParameter)
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
		
		public virtual void VisitFunctionParameter(FunctionParameterSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				this.BeginDefine(node, type: typeof(Parameter));
				try
				{
					if (node.TypeReference != null)
					{
					    this.BeginProperty(node.TypeReference, name: "DeclaredType");
					    try
					    {
					    	this.Visit(node.TypeReference);
					    }
					    finally
					    {
					    	this.EndProperty(node.TypeReference, name: "DeclaredType");
					    }
					}
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
					if (node.Expression != null)
					{
					    this.BeginProperty(node.Expression, name: "DeclaredInitializer");
					    try
					    {
					    	this.Visit(node.Expression);
					    }
					    finally
					    {
					    	this.EndProperty(node.Expression, name: "DeclaredInitializer");
					    }
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
		
		public virtual void VisitFunctionResult(FunctionResultSyntax node)
		{
			this.BeginProperty(node, name: "Result");
			try
			{
				this.BeginDefine(node, type: typeof(Parameter));
				try
				{
					if (node.ReturnType != null)
					{
					    this.BeginProperty(node.ReturnType, name: "DeclaredType");
					    try
					    {
					    	this.Visit(node.ReturnType);
					    }
					    finally
					    {
					    	this.EndProperty(node.ReturnType, name: "DeclaredType");
					    }
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Parameter));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Result");
			}
		}
		
		public virtual void VisitEmptyStmt(EmptyStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(EmptyStatement));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(EmptyStatement));
			}
		}
		
		public virtual void VisitBlockStmt(BlockStmtSyntax node)
		{
			if (node.BlockStatement != null)
			{
			    this.Visit(node.BlockStatement);
			}
		}
		
		public virtual void VisitExprStmt(ExprStmtSyntax node)
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
		
		public virtual void VisitForeachStmt(ForeachStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(ForEachLoopStatement));
			try
			{
				if (node.Variable != null)
				{
				    this.BeginProperty(node.Variable, name: "LoopControlVariable");
				    try
				    {
				    	this.Visit(node.Variable);
				    }
				    finally
				    {
				    	this.EndProperty(node.Variable, name: "LoopControlVariable");
				    }
				}
				if (node.Collection != null)
				{
				    this.BeginProperty(node.Collection, name: "Collection");
				    try
				    {
				    	this.Visit(node.Collection);
				    }
				    finally
				    {
				    	this.EndProperty(node.Collection, name: "Collection");
				    }
				}
				if (node.Statement != null)
				{
				    this.BeginProperty(node.Statement, name: "Body");
				    try
				    {
				    	this.Visit(node.Statement);
				    }
				    finally
				    {
				    	this.EndProperty(node.Statement, name: "Body");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ForEachLoopStatement));
			}
		}
		
		public virtual void VisitForStmt(ForStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(ForLoopStatement));
			try
			{
				if (node.Before != null)
				{
				    this.BeginProperty(node.Before, name: "Before");
				    try
				    {
				    	this.Visit(node.Before);
				    }
				    finally
				    {
				    	this.EndProperty(node.Before, name: "Before");
				    }
				}
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
				if (node.AtLoopBottom != null)
				{
				    this.BeginProperty(node.AtLoopBottom, name: "AtLoopBottom");
				    try
				    {
				    	this.Visit(node.AtLoopBottom);
				    }
				    finally
				    {
				    	this.EndProperty(node.AtLoopBottom, name: "AtLoopBottom");
				    }
				}
				if (node.Statement != null)
				{
				    this.BeginProperty(node.Statement, name: "Body");
				    try
				    {
				    	this.Visit(node.Statement);
				    }
				    finally
				    {
				    	this.EndProperty(node.Statement, name: "Body");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ForLoopStatement));
			}
		}
		
		public virtual void VisitIfStmt(IfStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(IfStatement));
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
				if (node.IfTrue != null)
				{
				    this.BeginProperty(node.IfTrue, name: "IfTrue");
				    try
				    {
				    	this.Visit(node.IfTrue);
				    }
				    finally
				    {
				    	this.EndProperty(node.IfTrue, name: "IfTrue");
				    }
				}
				if (node.IfFalse != null)
				{
				    this.BeginProperty(node.IfFalse, name: "IfFalse");
				    try
				    {
				    	this.Visit(node.IfFalse);
				    }
				    finally
				    {
				    	this.EndProperty(node.IfFalse, name: "IfFalse");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(IfStatement));
			}
		}
		
		public virtual void VisitBreakStmt(BreakStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(JumpStatement));
			try
			{
				if (node.KBreak.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.KBreak, name: "JumpKind", value: JumpKind.Break);
				    try
				    {
				    	this.Visit(node.KBreak);
				    }
				    finally
				    {
				    	this.EndProperty(node.KBreak, name: "JumpKind", value: JumpKind.Break);
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(JumpStatement));
			}
		}
		
		public virtual void VisitContinueStmt(ContinueStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(JumpStatement));
			try
			{
				if (node.KContinue.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.KContinue, name: "JumpKind", value: JumpKind.Continue);
				    try
				    {
				    	this.Visit(node.KContinue);
				    }
				    finally
				    {
				    	this.EndProperty(node.KContinue, name: "JumpKind", value: JumpKind.Continue);
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(JumpStatement));
			}
		}
		
		public virtual void VisitGotoStmt(GotoStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(JumpStatement));
			try
			{
				if (node.KGoto.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.KGoto, name: "JumpKind", value: JumpKind.GoTo);
				    try
				    {
				    	this.Visit(node.KGoto);
				    }
				    finally
				    {
				    	this.EndProperty(node.KGoto, name: "JumpKind", value: JumpKind.GoTo);
				    }
				}
				if (node.Identifier != null)
				{
				    this.BeginProperty(node.Identifier, name: "Target");
				    try
				    {
				    	this.BeginUse(node.Identifier, types: ImmutableArray.Create(typeof(Label)));
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Identifier, types: ImmutableArray.Create(typeof(Label)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "Target");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(JumpStatement));
			}
		}
		
		public virtual void VisitLabeledStmt(LabeledStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(LabeledStatement));
			try
			{
				if (node.Name != null)
				{
				    this.BeginProperty(node.Name, name: "Label");
				    try
				    {
				    	this.BeginDefine(node.Name, type: typeof(Label));
				    	try
				    	{
				    		this.Visit(node.Name);
				    	}
				    	finally
				    	{
				    		this.EndDefine(node.Name, type: typeof(Label));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Name, name: "Label");
				    }
				}
				if (node.Statement != null)
				{
				    this.BeginProperty(node.Statement, name: "Statement");
				    try
				    {
				    	this.Visit(node.Statement);
				    }
				    finally
				    {
				    	this.EndProperty(node.Statement, name: "Statement");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LabeledStatement));
			}
		}
		
		public virtual void VisitLockStmt(LockStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(LockStatement));
			try
			{
				if (node.LockedValue != null)
				{
				    this.BeginProperty(node.LockedValue, name: "LockedValue");
				    try
				    {
				    	this.Visit(node.LockedValue);
				    }
				    finally
				    {
				    	this.EndProperty(node.LockedValue, name: "LockedValue");
				    }
				}
				if (node.Body != null)
				{
				    this.BeginProperty(node.Body, name: "Body");
				    try
				    {
				    	this.Visit(node.Body);
				    }
				    finally
				    {
				    	this.EndProperty(node.Body, name: "Body");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LockStatement));
			}
		}
		
		public virtual void VisitReturnStmt(ReturnStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(ReturnStatement));
			try
			{
				if (node.ReturnedValue != null)
				{
				    this.BeginProperty(node.ReturnedValue, name: "ReturnedValue");
				    try
				    {
				    	this.Visit(node.ReturnedValue);
				    }
				    finally
				    {
				    	this.EndProperty(node.ReturnedValue, name: "ReturnedValue");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ReturnStatement));
			}
		}
		
		public virtual void VisitSwitchStmt(SwitchStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(SwitchStatement));
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
				if (node.SwitchCase != null)
				{
					foreach (var child in node.SwitchCase)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(SwitchStatement));
			}
		}
		
		public virtual void VisitTryStmt(TryStmtSyntax node)
		{
			if (node.Body != null)
			{
			    this.BeginProperty(node.Body, name: "Body");
			    try
			    {
			    	this.Visit(node.Body);
			    }
			    finally
			    {
			    	this.EndProperty(node.Body, name: "Body");
			    }
			}
			if (node.CatchClause != null)
			{
				foreach (var child in node.CatchClause)
				{
			        this.Visit(child);
				}
			}
			if (node.FinallyClause != null)
			{
			    this.BeginProperty(node.FinallyClause, name: "Finally");
			    try
			    {
			    	this.Visit(node.FinallyClause);
			    }
			    finally
			    {
			    	this.EndProperty(node.FinallyClause, name: "Finally");
			    }
			}
		}
		
		public virtual void VisitUsingStmt(UsingStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(UsingStatement));
			try
			{
				if (node.UsingHeader != null)
				{
					foreach (var child in node.UsingHeader)
					{
				        this.Visit(child);
					}
				}
				if (node.Body != null)
				{
				    this.BeginProperty(node.Body, name: "Body");
				    try
				    {
				    	this.Visit(node.Body);
				    }
				    finally
				    {
				    	this.EndProperty(node.Body, name: "Body");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(UsingStatement));
			}
		}
		
		public virtual void VisitWhileStmt(WhileStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(WhileLoopStatement));
			try
			{
				if (node.Condition != null)
				{
				    this.BeginProperty(node.Condition, name: "ConditionIsTop", value: true);
				    try
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
				    finally
				    {
				    	this.EndProperty(node.Condition, name: "ConditionIsTop", value: true);
				    }
				}
				if (node.Body != null)
				{
				    this.BeginProperty(node.Body, name: "Body");
				    try
				    {
				    	this.Visit(node.Body);
				    }
				    finally
				    {
				    	this.EndProperty(node.Body, name: "Body");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(WhileLoopStatement));
			}
		}
		
		public virtual void VisitDoWhileStmt(DoWhileStmtSyntax node)
		{
			this.BeginDefine(node, type: typeof(WhileLoopStatement));
			try
			{
				if (node.Body != null)
				{
				    this.BeginProperty(node.Body, name: "Body");
				    try
				    {
				    	this.Visit(node.Body);
				    }
				    finally
				    {
				    	this.EndProperty(node.Body, name: "Body");
				    }
				}
				if (node.Condition != null)
				{
				    this.BeginProperty(node.Condition, name: "ConditionIsTop", value: false);
				    try
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
				    finally
				    {
				    	this.EndProperty(node.Condition, name: "ConditionIsTop", value: false);
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(WhileLoopStatement));
			}
		}
		
		public virtual void VisitBlockStatement(BlockStatementSyntax node)
		{
			this.BeginDefine(node, type: typeof(BlockStatement));
			try
			{
				this.BeginProperty(node, name: "Statements");
				try
				{
					if (node.Statement != null)
					{
						foreach (var child in node.Statement)
						{
					        this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndProperty(node, name: "Statements");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BlockStatement));
			}
		}
		
		public virtual void VisitBareBlockStatement(BareBlockStatementSyntax node)
		{
			this.BeginDefine(node, type: typeof(BlockStatement));
			try
			{
				this.BeginProperty(node, name: "Statements");
				try
				{
					if (node.Statement != null)
					{
						foreach (var child in node.Statement)
						{
					        this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndProperty(node, name: "Statements");
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(BlockStatement));
			}
		}
		
		public virtual void VisitSwitchCase(SwitchCaseSyntax node)
		{
			this.BeginProperty(node, name: "Cases");
			try
			{
				this.BeginDefine(node, type: typeof(SwitchCase));
				try
				{
					if (node.CaseClause != null)
					{
						foreach (var child in node.CaseClause)
						{
					        this.Visit(child);
						}
					}
					if (node.BareBlockStatement != null)
					{
					    this.BeginProperty(node.BareBlockStatement, name: "Body");
					    try
					    {
					    	this.Visit(node.BareBlockStatement);
					    }
					    finally
					    {
					    	this.EndProperty(node.BareBlockStatement, name: "Body");
					    }
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(SwitchCase));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Cases");
			}
		}
		
		public virtual void VisitCaseClause(CaseClauseSyntax node)
		{
			this.BeginProperty(node, name: "Clauses");
			try
			{
				if (node.SingleValueCaseClause != null)
				{
				    this.Visit(node.SingleValueCaseClause);
				}
				if (node.DefaultCaseClause != null)
				{
				    this.Visit(node.DefaultCaseClause);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Clauses");
			}
		}
		
		public virtual void VisitSingleValueCaseClause(SingleValueCaseClauseSyntax node)
		{
			this.BeginDefine(node, type: typeof(SingleValueCaseClause));
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
			}
			finally
			{
				this.EndDefine(node, type: typeof(SingleValueCaseClause));
			}
		}
		
		public virtual void VisitDefaultCaseClause(DefaultCaseClauseSyntax node)
		{
			this.BeginDefine(node, type: typeof(DefaultCaseClause));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(DefaultCaseClause));
			}
		}
		
		public virtual void VisitCatchClause(CatchClauseSyntax node)
		{
			this.BeginProperty(node, name: "Catches");
			try
			{
				this.BeginDefine(node, type: typeof(CatchClause));
				try
				{
					if (node.Value != null)
					{
					    this.BeginProperty(node.Value, name: "ExceptionDeclarationOrExpression");
					    try
					    {
					    	this.Visit(node.Value);
					    }
					    finally
					    {
					    	this.EndProperty(node.Value, name: "ExceptionDeclarationOrExpression");
					    }
					}
					if (node.CatchFilter != null)
					{
					    this.Visit(node.CatchFilter);
					}
					if (node.Handler != null)
					{
					    this.BeginProperty(node.Handler, name: "Handler");
					    try
					    {
					    	this.Visit(node.Handler);
					    }
					    finally
					    {
					    	this.EndProperty(node.Handler, name: "Handler");
					    }
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(CatchClause));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Catches");
			}
		}
		
		public virtual void VisitCatchFilter(CatchFilterSyntax node)
		{
			if (node.Filter != null)
			{
			    this.BeginProperty(node.Filter, name: "Filter");
			    try
			    {
			    	this.Visit(node.Filter);
			    }
			    finally
			    {
			    	this.EndProperty(node.Filter, name: "Filter");
			    }
			}
		}
		
		public virtual void VisitFinallyClause(FinallyClauseSyntax node)
		{
			if (node.Handler != null)
			{
			    this.Visit(node.Handler);
			}
		}
		
		public virtual void VisitUsingHeader(UsingHeaderSyntax node)
		{
			if (node.Resource != null)
			{
			    this.BeginProperty(node.Resource, name: "Resources");
			    try
			    {
			    	this.Visit(node.Resource);
			    }
			    finally
			    {
			    	this.EndProperty(node.Resource, name: "Resources");
			    }
			}
		}
		
		public virtual void VisitExpressionList(ExpressionListSyntax node)
		{
			if (node.Expression != null)
			{
				foreach (var child in node.Expression)
				{
			        this.Visit(child);
				}
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
				    this.BeginProperty(node.Identifier, name: "ReferencedName");
				    try
				    {
				    	this.BeginValue(node.Identifier);
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.Identifier);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "ReferencedName");
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
				    this.BeginProperty(node.Identifier, name: "ReferencedName");
				    try
				    {
				    	this.BeginValue(node.Identifier);
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.Identifier);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "ReferencedName");
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
		
		public virtual void VisitPostfixIncOrDecExpr(PostfixIncOrDecExprSyntax node)
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
				if (node.PostfixIncOrDecOperator != null)
				{
				    this.BeginProperty(node.PostfixIncOrDecOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.PostfixIncOrDecOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.PostfixIncOrDecOperator, name: "OperatorKind");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(UnaryExpression));
			}
		}
		
		public virtual void VisitPrefixIncOrDecExpr(PrefixIncOrDecExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(UnaryExpression));
			try
			{
				if (node.PrefixIncOrDecOperator != null)
				{
				    this.BeginProperty(node.PrefixIncOrDecOperator, name: "OperatorKind");
				    try
				    {
				    	this.Visit(node.PrefixIncOrDecOperator);
				    }
				    finally
				    {
				    	this.EndProperty(node.PrefixIncOrDecOperator, name: "OperatorKind");
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
				if (node.Name != null)
				{
				    this.BeginProperty(node.Name, name: "DeclaredVariable");
				    try
				    {
				    	this.BeginDefine(node.Name, type: typeof(Variable));
				    	try
				    	{
				    		this.Visit(node.Name);
				    	}
				    	finally
				    	{
				    		this.EndDefine(node.Name, type: typeof(Variable));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Name, name: "DeclaredVariable");
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
		
		public virtual void VisitVarDefExpr(VarDefExprSyntax node)
		{
			this.BeginDefine(node, type: typeof(VariableDeclarationExpression));
			try
			{
				if (node.KConst.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.KConst, name: "IsConst", value: true);
				    try
				    {
				    	this.Visit(node.KConst);
				    }
				    finally
				    {
				    	this.EndProperty(node.KConst, name: "IsConst", value: true);
				    }
				}
				if (node.VariableType != null)
				{
				    this.BeginProperty(node.VariableType, name: "DeclaredType");
				    try
				    {
				    	this.Visit(node.VariableType);
				    }
				    finally
				    {
				    	this.EndProperty(node.VariableType, name: "DeclaredType");
				    }
				}
				if (node.VariableDefList != null)
				{
				    this.Visit(node.VariableDefList);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(VariableDeclarationExpression));
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
		
		public virtual void VisitVariableDefList(VariableDefListSyntax node)
		{
			if (node.VariableDef != null)
			{
				foreach (var child in node.VariableDef)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitVariableDef(VariableDefSyntax node)
		{
			this.BeginProperty(node, name: "Variables");
			try
			{
				this.BeginDefine(node, type: typeof(Variable));
				try
				{
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
					if (node.Initializer != null)
					{
					    this.BeginProperty(node.Initializer, name: "DeclaredInitializer");
					    try
					    {
					    	this.Visit(node.Initializer);
					    }
					    finally
					    {
					    	this.EndProperty(node.Initializer, name: "DeclaredInitializer");
					    }
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Variable));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Variables");
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
		
		public virtual void VisitPostfixIncOrDecOperator(PostfixIncOrDecOperatorSyntax node)
		{
			if (node.PostfixIncOrDecOperator != null)
			{
			    switch (node.PostfixIncOrDecOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TPlusPlus:
			    		this.BeginValue(node.PostfixIncOrDecOperator, value: UnaryOperatorKind.PostfixIncrement);
			    		try
			    		{
			    			this.Visit(node.PostfixIncOrDecOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PostfixIncOrDecOperator, value: UnaryOperatorKind.PostfixIncrement);
			    		}
			    		break;
			    	case CoreSyntaxKind.TMinusMinus:
			    		this.BeginValue(node.PostfixIncOrDecOperator, value: UnaryOperatorKind.PostfixDecrement);
			    		try
			    		{
			    			this.Visit(node.PostfixIncOrDecOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PostfixIncOrDecOperator, value: UnaryOperatorKind.PostfixDecrement);
			    		}
			    		break;
			    	default:
			    		break;
			    }
			}
		}
		
		public virtual void VisitPrefixIncOrDecOperator(PrefixIncOrDecOperatorSyntax node)
		{
			if (node.PrefixIncOrDecOperator != null)
			{
			    switch (node.PrefixIncOrDecOperator.GetKind().Switch())
			    {
			    	case CoreSyntaxKind.TPlusPlus:
			    		this.BeginValue(node.PrefixIncOrDecOperator, value: UnaryOperatorKind.PrefixIncrement);
			    		try
			    		{
			    			this.Visit(node.PrefixIncOrDecOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrefixIncOrDecOperator, value: UnaryOperatorKind.PrefixIncrement);
			    		}
			    		break;
			    	case CoreSyntaxKind.TMinusMinus:
			    		this.BeginValue(node.PrefixIncOrDecOperator, value: UnaryOperatorKind.PrefixDecrement);
			    		try
			    		{
			    			this.Visit(node.PrefixIncOrDecOperator);
			    		}
			    		finally
			    		{
			    			this.EndValue(node.PrefixIncOrDecOperator, value: UnaryOperatorKind.PrefixDecrement);
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
		
		public virtual void VisitVariableType(VariableTypeSyntax node)
		{
			if (node.TypeReference != null)
			{
			    this.Visit(node.TypeReference);
			}
			if (node.VarType != null)
			{
			    this.Visit(node.VarType);
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
		
		public virtual void VisitVarType(VarTypeSyntax node)
		{
			this.BeginValue(node, value: CoreInstance.VarType);
			try
			{
			}
			finally
			{
				this.EndValue(node, value: CoreInstance.VarType);
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


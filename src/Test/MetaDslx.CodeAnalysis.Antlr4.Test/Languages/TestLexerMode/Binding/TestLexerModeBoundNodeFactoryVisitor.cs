// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Symbols;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Binding
{
	// Make sure to keep this in sync with TestLexerModeIsBindableNodeVisitor
    public class TestLexerModeBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, ITestLexerModeSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public TestLexerModeBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		public BoundNode VisitSkippedTokensTrivia(TestLexerModeSkippedTokensTriviaSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			return null;
		}

		
		public BoundNode VisitMain(MainSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitGeneratorDeclaration(GeneratorDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitConfigDeclaration(ConfigDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitMethodDeclaration(MethodDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitFunctionDeclaration(FunctionDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitFunctionSignature(FunctionSignatureSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitParamList(ParamListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitParameter(ParameterSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitBody(BodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitStatement(StatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSingleStatement(SingleStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVariableDeclarationItem(VariableDeclarationItemSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVoidStatement(VoidStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitReturnStatement(ReturnStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitExpressionStatement(ExpressionStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIfStatement(IfStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitElseIfStatementBody(ElseIfStatementBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIfStatementElseBody(IfStatementElseBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIfStatementBegin(IfStatementBeginSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitElseIfStatement(ElseIfStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIfStatementElse(IfStatementElseSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIfStatementEnd(IfStatementEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitForStatement(ForStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitForStatementBegin(ForStatementBeginSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitForStatementEnd(ForStatementEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitForInitStatement(ForInitStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitWhileStatement(WhileStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitWhileStatementBegin(WhileStatementBeginSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitWhileStatementEnd(WhileStatementEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitWhileRunExpression(WhileRunExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRepeatStatement(RepeatStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRepeatStatementBegin(RepeatStatementBeginSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRepeatStatementEnd(RepeatStatementEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRepeatRunExpression(RepeatRunExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopStatement(LoopStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopStatementBegin(LoopStatementBeginSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopStatementEnd(LoopStatementEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopChain(LoopChainSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopChainItem(LoopChainItemSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopWhereExpression(LoopWhereExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopRunExpression(LoopRunExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSeparatorStatement(SeparatorStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchStatement(SwitchStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchStatementBegin(SwitchStatementBeginSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchStatementEnd(SwitchStatementEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchBranchStatement(SwitchBranchStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateDeclaration(TemplateDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateSignature(TemplateSignatureSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateBody(TemplateBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateContentLine(TemplateContentLineSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateContent(TemplateContentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateOutput(TemplateOutputSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateLineEnd(TemplateLineEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTemplateStatement(TemplateStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypeArgumentList(TypeArgumentListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitPredefinedType(PredefinedTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypeReferenceList(TypeReferenceListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypeReference(TypeReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrayType(ArrayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrayItemType(ArrayItemTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNullableType(NullableTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNullableItemType(NullableItemTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitGenericType(GenericTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSimpleType(SimpleTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVoidType(VoidTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitReturnType(ReturnTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitExpressionList(ExpressionListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVariableReference(VariableReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRankSpecifiers(RankSpecifiersSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRankSpecifier(RankSpecifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitUnboundTypeName(UnboundTypeNameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitGenericDimensionItem(GenericDimensionItemSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitExplicitParameter(ExplicitParameterSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitImplicitParameter(ImplicitParameterSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitThisExpression(ThisExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLiteralExpression(LiteralExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDefaultValueExpression(DefaultValueExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIdentifierExpression(IdentifierExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitHasLoopExpression(HasLoopExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitParenthesizedExpression(ParenthesizedExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitElementAccessExpression(ElementAccessExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitFunctionCallExpression(FunctionCallExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypecastExpression(TypecastExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitUnaryExpression(UnaryExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitPostExpression(PostExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitMultiplicationExpression(MultiplicationExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitAdditionExpression(AdditionExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRelationalExpression(RelationalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTypecheckExpression(TypecheckExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitEqualityExpression(EqualityExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLogicalAndExpression(LogicalAndExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLogicalXorExpression(LogicalXorExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLogicalOrExpression(LogicalOrExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitConditionalExpression(ConditionalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitAssignmentExpression(AssignmentExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLambdaExpression(LambdaExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitQualifiedName(QualifiedNameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIdentifierList(IdentifierListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIdentifier(IdentifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLiteral(LiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNullLiteral(NullLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitBooleanLiteral(BooleanLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNumberLiteral(NumberLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIntegerLiteral(IntegerLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDecimalLiteral(DecimalLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitScientificLiteral(ScientificLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDateTimeOffsetLiteral(DateTimeOffsetLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDateTimeLiteral(DateTimeLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDateLiteral(DateLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTimeLiteral(TimeLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitCharLiteral(CharLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitStringLiteral(StringLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitGuidLiteral(GuidLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
    }
}


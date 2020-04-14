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
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne;
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax;
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Symbols;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Model;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Binding
{
	// Make sure to keep this in sync with TestLangOneIsBindableNodeVisitor
    public class TestLangOneBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, ITestLangOneSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public TestLangOneBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

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
				if (node.Test != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Test.Node))
					{
						foreach (var item in node.Test)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodesForParent);
							}
						}
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
		
		public BoundNode VisitTest(TestSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Test01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test01))
						{
							this.Visit(node.Test01, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test01, childBoundNodesForParent);
					}
				}
				if (node.Test02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test02))
						{
							this.Visit(node.Test02, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test02, childBoundNodesForParent);
					}
				}
				if (node.Test03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test03))
						{
							this.Visit(node.Test03, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test03, childBoundNodesForParent);
					}
				}
				if (node.Test04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test04))
						{
							this.Visit(node.Test04, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test04, childBoundNodesForParent);
					}
				}
				if (node.Test05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test05))
						{
							this.Visit(node.Test05, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test05, childBoundNodesForParent);
					}
				}
				if (node.Test06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test06))
						{
							this.Visit(node.Test06, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test06, childBoundNodesForParent);
					}
				}
				if (node.Test07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test07))
						{
							this.Visit(node.Test07, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test07, childBoundNodesForParent);
					}
				}
				if (node.Test08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test08))
						{
							this.Visit(node.Test08, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test08, childBoundNodesForParent);
					}
				}
				if (node.Test09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test09))
						{
							this.Visit(node.Test09, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test09, childBoundNodesForParent);
					}
				}
				if (node.Test10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test10))
						{
							this.Visit(node.Test10, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test10, childBoundNodesForParent);
					}
				}
				if (node.Test11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test11))
						{
							this.Visit(node.Test11, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Test11, childBoundNodesForParent);
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
		
		public BoundNode VisitTest01(Test01Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration01))
						{
							this.Visit(node.NamespaceDeclaration01, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration01, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody01))
						{
							this.Visit(node.NamespaceBody01, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody01, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody01(NamespaceBody01Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration01 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration01.Node))
					{
						foreach (var item in node.Declaration01)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Declarations", syntax: node, hasErrors: false);
					resultNode = this.CreateBoundScope(this.BoundTree, ImmutableArray.Create<object>(resultNode), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration01(Declaration01Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex01))
						{
							this.Visit(node.Vertex01, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex01, childBoundNodesForParent);
					}
				}
				if (node.Arrow01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow01))
						{
							this.Visit(node.Arrow01, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow01, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex01(Vertex01Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow01(Arrow01Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest02(Test02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration02))
						{
							this.Visit(node.NamespaceDeclaration02, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration02, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody02))
						{
							this.Visit(node.NamespaceBody02, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody02, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody02(NamespaceBody02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration02 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration02.Node))
					{
						foreach (var item in node.Declaration02)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration02(Declaration02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex02))
						{
							this.Visit(node.Vertex02, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex02, childBoundNodesForParent);
					}
				}
				if (node.Arrow02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow02))
						{
							this.Visit(node.Arrow02, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow02, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex02(Vertex02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow02(Arrow02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source02))
						{
							this.Visit(node.Source02, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Source02, childBoundNodes);
					}
				}
				if (node.Target02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target02))
						{
							this.Visit(node.Target02, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Target02, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSource02(Source02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							this.Visit(node.Qualifier, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Qualifier, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Source", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTarget02(Target02Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							this.Visit(node.Qualifier, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Qualifier, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Target", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest03(Test03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration03))
						{
							this.Visit(node.NamespaceDeclaration03, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration03, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody03))
						{
							this.Visit(node.NamespaceBody03, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody03, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody03(NamespaceBody03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration03 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration03.Node))
					{
						foreach (var item in node.Declaration03)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration03(Declaration03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex03))
						{
							this.Visit(node.Vertex03, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex03, childBoundNodesForParent);
					}
				}
				if (node.Arrow03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow03))
						{
							this.Visit(node.Arrow03, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow03, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex03(Vertex03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							var childBoundNodesOfName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Name, childBoundNodesOfName);
							BoundNode boundName;
							boundName = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfName.ToImmutableAndFree(), type: typeof(Vertex), syntax: node.Name, hasErrors: false);
							boundName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundName), name: "Declarations", syntax: node.Name, hasErrors: false);
							childBoundNodesForParent.Add(boundName);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Name);
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
		
		public BoundNode VisitArrow03(Arrow03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source03))
						{
							this.Visit(node.Source03, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Source03, childBoundNodes);
					}
				}
				if (node.Target03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target03))
						{
							this.Visit(node.Target03, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Target03, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSource03(Source03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Qualifier, childBoundNodesOfQualifier);
							BoundNode boundQualifier;
							boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Qualifier, hasErrors: false);
							boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), name: "Source", syntax: node.Qualifier, hasErrors: false);
							childBoundNodesForParent.Add(boundQualifier);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Qualifier);
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
		
		public BoundNode VisitTarget03(Target03Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Qualifier, childBoundNodesOfQualifier);
							BoundNode boundQualifier;
							boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Qualifier, hasErrors: false);
							boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), name: "Target", syntax: node.Qualifier, hasErrors: false);
							childBoundNodesForParent.Add(boundQualifier);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Qualifier);
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
		
		public BoundNode VisitTest04(Test04Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration04))
						{
							this.Visit(node.NamespaceDeclaration04, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration04, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody04))
						{
							this.Visit(node.NamespaceBody04, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody04, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody04(NamespaceBody04Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration04 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration04.Node))
					{
						foreach (var item in node.Declaration04)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration04(Declaration04Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Vertex04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex04))
						{
							this.Visit(node.Vertex04, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Vertex04, childBoundNodes);
					}
				}
				if (node.Arrow04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow04))
						{
							this.Visit(node.Arrow04, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Arrow04, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVertex04(Vertex04Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow04(Arrow04Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest05(Test05Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration05))
						{
							this.Visit(node.NamespaceDeclaration05, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration05, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody05))
						{
							var childBoundNodesOfNamespaceBody05 = ArrayBuilder<object>.GetInstance();
							this.Visit(node.NamespaceBody05, childBoundNodesOfNamespaceBody05);
							BoundNode boundNamespaceBody05;
							boundNamespaceBody05 = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNamespaceBody05.ToImmutableAndFree(), name: "Declarations", syntax: node.NamespaceBody05, hasErrors: false);
							boundNamespaceBody05 = this.CreateBoundScope(this.BoundTree, ImmutableArray.Create<object>(boundNamespaceBody05), syntax: node.NamespaceBody05, hasErrors: false);
							childBoundNodes.Add(boundNamespaceBody05);
						}
					}
					else
					{
						childBoundNodes.Add(node.NamespaceBody05);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody05(NamespaceBody05Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Declaration05 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration05.Node))
					{
						foreach (var item in node.Declaration05)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodesForParent);
							}
						}
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
		
		public BoundNode VisitDeclaration05(Declaration05Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex05))
						{
							this.Visit(node.Vertex05, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex05, childBoundNodesForParent);
					}
				}
				if (node.Arrow05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow05))
						{
							this.Visit(node.Arrow05, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow05, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex05(Vertex05Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow05(Arrow05Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest06(Test06Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration06))
						{
							this.Visit(node.NamespaceDeclaration06, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration06, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody06))
						{
							this.Visit(node.NamespaceBody06, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody06, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody06(NamespaceBody06Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration06 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration06.Node))
					{
						foreach (var item in node.Declaration06)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Declarations", syntax: node, hasErrors: false);
					resultNode = this.CreateBoundScope(this.BoundTree, ImmutableArray.Create<object>(resultNode), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration06(Declaration06Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex06))
						{
							this.Visit(node.Vertex06, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex06, childBoundNodesForParent);
					}
				}
				if (node.Arrow06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow06))
						{
							this.Visit(node.Arrow06, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow06, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex06(Vertex06Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow06(Arrow06Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest07(Test07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration07))
						{
							this.Visit(node.NamespaceDeclaration07, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration07, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody07))
						{
							this.Visit(node.NamespaceBody07, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody07, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody07(NamespaceBody07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration07 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration07.Node))
					{
						foreach (var item in node.Declaration07)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration07(Declaration07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex07))
						{
							this.Visit(node.Vertex07, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex07, childBoundNodesForParent);
					}
				}
				if (node.Arrow07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow07))
						{
							this.Visit(node.Arrow07, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow07, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex07(Vertex07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow07(Arrow07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source07))
						{
							this.Visit(node.Source07, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Source07, childBoundNodes);
					}
				}
				if (node.Target07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target07))
						{
							this.Visit(node.Target07, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Target07, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSource07(Source07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Source", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTarget07(Target07Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Target", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest08(Test08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration08))
						{
							this.Visit(node.NamespaceDeclaration08, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration08, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody08))
						{
							this.Visit(node.NamespaceBody08, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody08, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody08(NamespaceBody08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration08 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration08.Node))
					{
						foreach (var item in node.Declaration08)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration08(Declaration08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex08))
						{
							this.Visit(node.Vertex08, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex08, childBoundNodesForParent);
					}
				}
				if (node.Arrow08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow08))
						{
							this.Visit(node.Arrow08, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow08, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex08(Vertex08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							var childBoundNodesOfName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Name, childBoundNodesOfName);
							BoundNode boundName;
							boundName = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfName.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Name, hasErrors: false);
							boundName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundName), name: "Declarations", syntax: node.Name, hasErrors: false);
							childBoundNodesForParent.Add(boundName);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Name);
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
		
		public BoundNode VisitArrow08(Arrow08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source08))
						{
							this.Visit(node.Source08, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Source08, childBoundNodes);
					}
				}
				if (node.Target08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target08))
						{
							this.Visit(node.Target08, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Target08, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSource08(Source08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							var childBoundNodesOfName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Name, childBoundNodesOfName);
							BoundNode boundName;
							boundName = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfName.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Name, hasErrors: false);
							boundName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundName), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Name, hasErrors: false);
							boundName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundName), name: "Source", syntax: node.Name, hasErrors: false);
							childBoundNodesForParent.Add(boundName);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Name);
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
		
		public BoundNode VisitTarget08(Target08Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							var childBoundNodesOfName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Name, childBoundNodesOfName);
							BoundNode boundName;
							boundName = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfName.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Name, hasErrors: false);
							boundName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundName), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Name, hasErrors: false);
							boundName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundName), name: "Target", syntax: node.Name, hasErrors: false);
							childBoundNodesForParent.Add(boundName);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Name);
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
		
		public BoundNode VisitTest09(Test09Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration09))
						{
							this.Visit(node.NamespaceDeclaration09, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration09, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody09))
						{
							this.Visit(node.NamespaceBody09, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody09, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody09(NamespaceBody09Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration09 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration09.Node))
					{
						foreach (var item in node.Declaration09)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration09(Declaration09Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Vertex09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex09))
						{
							this.Visit(node.Vertex09, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Vertex09, childBoundNodes);
					}
				}
				if (node.Arrow09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow09))
						{
							this.Visit(node.Arrow09, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Arrow09, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitVertex09(Vertex09Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow09(Arrow09Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest10(Test10Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration10))
						{
							this.Visit(node.NamespaceDeclaration10, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration10, childBoundNodesForParent);
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
		
		public BoundNode VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody10))
						{
							var childBoundNodesOfNamespaceBody10 = ArrayBuilder<object>.GetInstance();
							this.Visit(node.NamespaceBody10, childBoundNodesOfNamespaceBody10);
							BoundNode boundNamespaceBody10;
							boundNamespaceBody10 = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNamespaceBody10.ToImmutableAndFree(), name: "Declarations", syntax: node.NamespaceBody10, hasErrors: false);
							boundNamespaceBody10 = this.CreateBoundScope(this.BoundTree, ImmutableArray.Create<object>(boundNamespaceBody10), syntax: node.NamespaceBody10, hasErrors: false);
							childBoundNodes.Add(boundNamespaceBody10);
						}
					}
					else
					{
						childBoundNodes.Add(node.NamespaceBody10);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody10(NamespaceBody10Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Declaration10 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration10.Node))
					{
						foreach (var item in node.Declaration10)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodesForParent);
							}
						}
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
		
		public BoundNode VisitDeclaration10(Declaration10Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex10))
						{
							this.Visit(node.Vertex10, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex10, childBoundNodesForParent);
					}
				}
				if (node.Arrow10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow10))
						{
							this.Visit(node.Arrow10, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow10, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex10(Vertex10Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow10(Arrow10Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), type: typeof(Vertex), merge: true, syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Declarations", owner: SymbolPropertyOwner.CurrentScope, syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTest11(Test11Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration11 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration11.Node))
					{
						foreach (var item in node.NamespaceDeclaration11)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodesForParent);
							}
						}
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
		
		public BoundNode VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							this.Visit(node.QualifiedName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QualifiedName, childBoundNodes);
					}
				}
				if (node.NamespaceBody11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody11))
						{
							this.Visit(node.NamespaceBody11, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody11, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Members", merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNamespaceBody11(NamespaceBody11Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Declaration11 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration11.Node))
					{
						foreach (var item in node.Declaration11)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Declarations", syntax: node, hasErrors: false);
					resultNode = this.CreateBoundScope(this.BoundTree, ImmutableArray.Create<object>(resultNode), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration11(Declaration11Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Vertex11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex11))
						{
							this.Visit(node.Vertex11, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Vertex11, childBoundNodesForParent);
					}
				}
				if (node.Arrow11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow11))
						{
							this.Visit(node.Arrow11, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Arrow11, childBoundNodesForParent);
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
		
		public BoundNode VisitVertex11(Vertex11Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Vertex), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow11(Arrow11Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Source, hasErrors: false);
							boundSource = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundSource), name: "Source", syntax: node.Source, hasErrors: false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Vertex)), syntax: node.Target, hasErrors: false);
							boundTarget = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundTarget), name: "Target", syntax: node.Target, hasErrors: false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Arrow), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitName(NameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							this.Visit(node.Identifier, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Identifier, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							this.Visit(node.Qualifier, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Qualifier, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitQualifier(QualifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Identifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundQualifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
				if (node.NullLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NullLiteral))
						{
							this.Visit(node.NullLiteral, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NullLiteral, childBoundNodesForParent);
					}
				}
				if (node.BooleanLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
						{
							this.Visit(node.BooleanLiteral, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.BooleanLiteral, childBoundNodesForParent);
					}
				}
				if (node.IntegerLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IntegerLiteral))
						{
							this.Visit(node.IntegerLiteral, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.IntegerLiteral, childBoundNodesForParent);
					}
				}
				if (node.DecimalLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DecimalLiteral))
						{
							this.Visit(node.DecimalLiteral, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.DecimalLiteral, childBoundNodesForParent);
					}
				}
				if (node.ScientificLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ScientificLiteral))
						{
							this.Visit(node.ScientificLiteral, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ScientificLiteral, childBoundNodesForParent);
					}
				}
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							this.Visit(node.StringLiteral, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.StringLiteral, childBoundNodesForParent);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
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


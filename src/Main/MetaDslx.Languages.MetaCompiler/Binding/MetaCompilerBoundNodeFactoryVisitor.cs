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
using MetaDslx.Languages.MetaCompiler;
using MetaDslx.Languages.MetaCompiler.Syntax;
using MetaDslx.Languages.MetaCompiler.Symbols;

using MetaDslx.Languages.MetaCompiler.Model;

namespace MetaDslx.Languages.MetaCompiler.Binding
{
	// Make sure to keep this in sync with MetaCompilerIsBindableNodeVisitor
    public class MetaCompilerBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, IMetaCompilerSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public MetaCompilerBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		public BoundNode VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.NamespaceDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration))
						{
							this.Visit(node.NamespaceDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.NamespaceDeclaration, childBoundNodesForParent);
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
		
		public BoundNode VisitAttribute(AttributeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Annotation)), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Annotations", syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
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
				if (node.NamespaceBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody))
						{
							this.Visit(node.NamespaceBody, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NamespaceBody, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Namespace), nestingProperty: "Declarations", merge: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitNamespaceBody(NamespaceBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Declaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration.Node))
					{
						foreach (var item in node.Declaration)
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
		
		public BoundNode VisitDeclaration(DeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.CompilerDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompilerDeclaration))
						{
							this.Visit(node.CompilerDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.CompilerDeclaration, childBoundNodes);
					}
				}
				if (node.PhaseDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseDeclaration))
						{
							this.Visit(node.PhaseDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.PhaseDeclaration, childBoundNodes);
					}
				}
				if (node.EnumDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumDeclaration))
						{
							this.Visit(node.EnumDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.EnumDeclaration, childBoundNodes);
					}
				}
				if (node.ClassDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassDeclaration))
						{
							this.Visit(node.ClassDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ClassDeclaration, childBoundNodes);
					}
				}
				if (node.TypedefDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypedefDeclaration))
						{
							this.Visit(node.TypedefDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.TypedefDeclaration, childBoundNodes);
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
		
		public BoundNode VisitCompilerDeclaration(CompilerDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(EnumType), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitPhaseDeclaration(PhaseDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.Locked != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Locked))
						{
							this.Visit(node.Locked, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Locked, childBoundNodes);
					}
				}
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
				if (node.PhaseJoin != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseJoin))
						{
							this.Visit(node.PhaseJoin, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.PhaseJoin, childBoundNodes);
					}
				}
				if (node.AfterPhases != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AfterPhases))
						{
							this.Visit(node.AfterPhases, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.AfterPhases, childBoundNodes);
					}
				}
				if (node.BeforePhases != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BeforePhases))
						{
							this.Visit(node.BeforePhases, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.BeforePhases, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Phase), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitLocked(LockedSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsLocked", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitPhaseJoin(PhaseJoinSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.PhaseRef != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseRef))
						{
							this.Visit(node.PhaseRef, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.PhaseRef, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "JoinsPhase", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitAfterPhases(AfterPhasesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.PhaseRef != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PhaseRef.Node))
					{
						foreach (var item in node.PhaseRef)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "AfterPhases", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitBeforePhases(BeforePhasesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.PhaseRef != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PhaseRef.Node))
					{
						foreach (var item in node.PhaseRef)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "BeforePhases", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitPhaseRef(PhaseRefSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
							boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Phase)), syntax: node.Qualifier, hasErrors: false);
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
		
		public BoundNode VisitEnumDeclaration(EnumDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
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
				if (node.EnumBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumBody))
						{
							this.Visit(node.EnumBody, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.EnumBody, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(EnumType), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitEnumBody(EnumBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.EnumValues != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumValues))
						{
							var childBoundNodesOfEnumValues = ArrayBuilder<object>.GetInstance();
							this.Visit(node.EnumValues, childBoundNodesOfEnumValues);
							BoundNode boundEnumValues;
							boundEnumValues = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfEnumValues.ToImmutableAndFree(), name: "EnumLiterals", syntax: node.EnumValues, hasErrors: false);
							childBoundNodes.Add(boundEnumValues);
						}
					}
					else
					{
						childBoundNodes.Add(node.EnumValues);
					}
				}
				if (node.EnumMemberDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumMemberDeclaration.Node))
					{
						foreach (var item in node.EnumMemberDeclaration)
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
		
		public BoundNode VisitEnumValues(EnumValuesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.EnumValue != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumValue.Node))
					{
						foreach (var item in node.EnumValue)
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
		
		public BoundNode VisitEnumValue(EnumValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(EnumLiteral), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.OperationDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
						{
							var childBoundNodesOfOperationDeclaration = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OperationDeclaration, childBoundNodesOfOperationDeclaration);
							BoundNode boundOperationDeclaration;
							boundOperationDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationDeclaration.ToImmutableAndFree(), name: "Operations", syntax: node.OperationDeclaration, hasErrors: false);
							childBoundNodesForParent.Add(boundOperationDeclaration);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.OperationDeclaration);
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
		
		public BoundNode VisitClassDeclaration(ClassDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.Abstract_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Abstract_))
						{
							this.Visit(node.Abstract_, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Abstract_, childBoundNodes);
					}
				}
				if (node.ClassKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassKind))
						{
							this.Visit(node.ClassKind, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ClassKind, childBoundNodes);
					}
				}
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
				if (node.ClassAncestors != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassAncestors))
						{
							var childBoundNodesOfClassAncestors = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ClassAncestors, childBoundNodesOfClassAncestors);
							BoundNode boundClassAncestors;
							boundClassAncestors = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfClassAncestors.ToImmutableAndFree(), name: "SuperClasses", syntax: node.ClassAncestors, hasErrors: false);
							childBoundNodes.Add(boundClassAncestors);
						}
					}
					else
					{
						childBoundNodes.Add(node.ClassAncestors);
					}
				}
				if (node.ClassBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassBody))
						{
							this.Visit(node.ClassBody, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ClassBody, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Class), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitAbstract_(Abstract_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsAbstract", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitClassAncestors(ClassAncestorsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.ClassAncestor != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassAncestor.Node))
					{
						foreach (var item in node.ClassAncestor)
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
		
		public BoundNode VisitClassAncestor(ClassAncestorSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
							boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Class)), syntax: node.Qualifier, hasErrors: false);
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
		
		public BoundNode VisitClassBody(ClassBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.ClassMemberDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassMemberDeclaration.Node))
					{
						foreach (var item in node.ClassMemberDeclaration)
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
		
		public BoundNode VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.FieldDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldDeclaration))
						{
							var childBoundNodesOfFieldDeclaration = ArrayBuilder<object>.GetInstance();
							this.Visit(node.FieldDeclaration, childBoundNodesOfFieldDeclaration);
							BoundNode boundFieldDeclaration;
							boundFieldDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfFieldDeclaration.ToImmutableAndFree(), name: "Properties", syntax: node.FieldDeclaration, hasErrors: false);
							childBoundNodesForParent.Add(boundFieldDeclaration);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.FieldDeclaration);
					}
				}
				if (node.OperationDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
						{
							var childBoundNodesOfOperationDeclaration = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OperationDeclaration, childBoundNodesOfOperationDeclaration);
							BoundNode boundOperationDeclaration;
							boundOperationDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationDeclaration.ToImmutableAndFree(), name: "Operations", syntax: node.OperationDeclaration, hasErrors: false);
							childBoundNodesForParent.Add(boundOperationDeclaration);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.OperationDeclaration);
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
		
		public BoundNode VisitClassKind(ClassKindSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.ClassKind)))
				{
					switch (node.ClassKind.GetKind().Switch())
					{
						case MetaCompilerSyntaxKind.KClass:
							BoundNode boundKClass;
							boundKClass = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ClassKind.Class, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKClass);
							break;
						case MetaCompilerSyntaxKind.KSymbol:
							BoundNode boundKSymbol;
							boundKSymbol = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ClassKind.Symbol, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKSymbol);
							break;
						case MetaCompilerSyntaxKind.KBinder:
							BoundNode boundKBinder;
							boundKBinder = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ClassKind.Binder, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKBinder);
							break;
						default:
							break;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitFieldDeclaration(FieldDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.FieldContainment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldContainment))
						{
							this.Visit(node.FieldContainment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FieldContainment, childBoundNodes);
					}
				}
				if (node.FieldModifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldModifier))
						{
							this.Visit(node.FieldModifier, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FieldModifier, childBoundNodes);
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							var childBoundNodesOfTypeReference = ArrayBuilder<object>.GetInstance();
							this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
							BoundNode boundTypeReference;
							boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), name: "Type", syntax: node.TypeReference, hasErrors: false);
							childBoundNodes.Add(boundTypeReference);
						}
					}
					else
					{
						childBoundNodes.Add(node.TypeReference);
					}
				}
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
				if (node.DefaultValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DefaultValue))
						{
							this.Visit(node.DefaultValue, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.DefaultValue, childBoundNodes);
					}
				}
				if (node.Phase != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Phase))
						{
							this.Visit(node.Phase, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Phase, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Property), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitFieldContainment(FieldContainmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsContainment", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitFieldModifier(FieldModifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.FieldModifier)))
				{
					switch (node.FieldModifier.GetKind().Switch())
					{
						case MetaCompilerSyntaxKind.KReadonly:
							BoundNode boundKReadonly;
							boundKReadonly = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: PropertyKind.Readonly, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKReadonly);
							break;
						case MetaCompilerSyntaxKind.KLazy:
							BoundNode boundKLazy;
							boundKLazy = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: PropertyKind.Lazy, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKLazy);
							break;
						case MetaCompilerSyntaxKind.KDerived:
							BoundNode boundKDerived;
							boundKDerived = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: PropertyKind.Derived, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKDerived);
							break;
						default:
							break;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitDefaultValue(DefaultValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							var childBoundNodesOfStringLiteral = ArrayBuilder<object>.GetInstance();
							this.Visit(node.StringLiteral, childBoundNodesOfStringLiteral);
							BoundNode boundStringLiteral;
							boundStringLiteral = this.CreateBoundValue(this.BoundTree, childBoundNodesOfStringLiteral.ToImmutableAndFree(), syntax: node.StringLiteral, hasErrors: false);
							childBoundNodes.Add(boundStringLiteral);
						}
					}
					else
					{
						childBoundNodes.Add(node.StringLiteral);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "DefaultValue", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitPhase(PhaseSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
							var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Qualifier, childBoundNodesOfQualifier);
							BoundNode boundQualifier;
							boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Phase)), syntax: node.Qualifier, hasErrors: false);
							childBoundNodes.Add(boundQualifier);
						}
					}
					else
					{
						childBoundNodes.Add(node.Qualifier);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Phase", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitNameUseList(NameUseListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier.Node))
					{
						foreach (var item in node.Qualifier)
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Property)), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTypedefDeclaration(TypedefDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.TypedefValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypedefValue))
						{
							this.Visit(node.TypedefValue, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.TypedefValue, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(TypeDefType), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTypedefValue(TypedefValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							var childBoundNodesOfStringLiteral = ArrayBuilder<object>.GetInstance();
							this.Visit(node.StringLiteral, childBoundNodesOfStringLiteral);
							BoundNode boundStringLiteral;
							boundStringLiteral = this.CreateBoundValue(this.BoundTree, childBoundNodesOfStringLiteral.ToImmutableAndFree(), syntax: node.StringLiteral, hasErrors: false);
							childBoundNodes.Add(boundStringLiteral);
						}
					}
					else
					{
						childBoundNodes.Add(node.StringLiteral);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "DotNetType", syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							this.Visit(node.TypeReference, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.TypeReference, childBoundNodes);
					}
				}
				if (node.VoidType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VoidType))
						{
							this.Visit(node.VoidType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.VoidType, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(DataType)), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTypeOfReference(TypeOfReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							this.Visit(node.TypeReference, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.TypeReference, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(DataType)), syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.GenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.GenericType))
						{
							this.Visit(node.GenericType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.GenericType, childBoundNodes);
					}
				}
				if (node.ArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArrayType))
						{
							this.Visit(node.ArrayType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ArrayType, childBoundNodes);
					}
				}
				if (node.SimpleType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleType))
						{
							this.Visit(node.SimpleType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.SimpleType, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(DataType)), syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.PrimitiveType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PrimitiveType))
						{
							this.Visit(node.PrimitiveType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.PrimitiveType, childBoundNodes);
					}
				}
				if (node.ObjectType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectType))
						{
							this.Visit(node.ObjectType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ObjectType, childBoundNodes);
					}
				}
				if (node.NullableType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NullableType))
						{
							this.Visit(node.NullableType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.NullableType, childBoundNodes);
					}
				}
				if (node.ClassType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassType))
						{
							this.Visit(node.ClassType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ClassType, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(DataType)), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitClassType(ClassTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(Class), typeof(EnumType), typeof(TypeDefType)), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitObjectType(ObjectTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
		
		public BoundNode VisitPrimitiveType(PrimitiveTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.PrimitiveType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PrimitiveType))
						{
							var childBoundNodesOfPrimitiveType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.PrimitiveType, childBoundNodesOfPrimitiveType);
							BoundNode boundPrimitiveType;
							boundPrimitiveType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfPrimitiveType.ToImmutableAndFree(), name: "InnerType", syntax: node.PrimitiveType, hasErrors: false);
							childBoundNodes.Add(boundPrimitiveType);
						}
					}
					else
					{
						childBoundNodes.Add(node.PrimitiveType);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(NullableType), syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.SimpleType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleType))
						{
							var childBoundNodesOfSimpleType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.SimpleType, childBoundNodesOfSimpleType);
							BoundNode boundSimpleType;
							boundSimpleType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSimpleType.ToImmutableAndFree(), name: "InnerType", syntax: node.SimpleType, hasErrors: false);
							childBoundNodes.Add(boundSimpleType);
						}
					}
					else
					{
						childBoundNodes.Add(node.SimpleType);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ArrayType), syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.ClassType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassType))
						{
							var childBoundNodesOfClassType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ClassType, childBoundNodesOfClassType);
							BoundNode boundClassType;
							boundClassType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfClassType.ToImmutableAndFree(), name: "Type", syntax: node.ClassType, hasErrors: false);
							childBoundNodes.Add(boundClassType);
						}
					}
					else
					{
						childBoundNodes.Add(node.ClassType);
					}
				}
				if (node.TypeArguments != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeArguments))
						{
							this.Visit(node.TypeArguments, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.TypeArguments, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(GenericType), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTypeArguments(TypeArgumentsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.TypeReference != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference.Node))
					{
						foreach (var item in node.TypeReference)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "TypeArguments", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitOperationDeclaration(OperationDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.ReturnType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ReturnType))
						{
							var childBoundNodesOfReturnType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ReturnType, childBoundNodesOfReturnType);
							BoundNode boundReturnType;
							boundReturnType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfReturnType.ToImmutableAndFree(), name: "ReturnType", syntax: node.ReturnType, hasErrors: false);
							childBoundNodes.Add(boundReturnType);
						}
					}
					else
					{
						childBoundNodes.Add(node.ReturnType);
					}
				}
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
				if (node.ParameterList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ParameterList))
						{
							var childBoundNodesOfParameterList = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ParameterList, childBoundNodesOfParameterList);
							BoundNode boundParameterList;
							boundParameterList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfParameterList.ToImmutableAndFree(), name: "Parameters", syntax: node.ParameterList, hasErrors: false);
							childBoundNodes.Add(boundParameterList);
						}
					}
					else
					{
						childBoundNodes.Add(node.ParameterList);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Operation), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitParameterList(ParameterListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Parameter != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Parameter.Node))
					{
						foreach (var item in node.Parameter)
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							var childBoundNodesOfTypeReference = ArrayBuilder<object>.GetInstance();
							this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
							BoundNode boundTypeReference;
							boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), name: "Type", syntax: node.TypeReference, hasErrors: false);
							childBoundNodes.Add(boundTypeReference);
						}
					}
					else
					{
						childBoundNodes.Add(node.TypeReference);
					}
				}
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Parameter), syntax: node, hasErrors: false);
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


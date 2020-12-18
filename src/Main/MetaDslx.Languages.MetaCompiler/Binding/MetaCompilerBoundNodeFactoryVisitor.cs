// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
				if (node.SymbolDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SymbolDeclaration))
						{
							this.Visit(node.SymbolDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.SymbolDeclaration, childBoundNodes);
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
		
		public BoundNode VisitVisibility(VisibilitySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.Visibility)))
				{
					switch (node.Visibility.GetKind().Switch())
					{
						case MetaCompilerSyntaxKind.KPrivate:
							BoundNode boundKPrivate;
							boundKPrivate = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: VisibilityKind.Private, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKPrivate);
							break;
						case MetaCompilerSyntaxKind.KProtected:
							BoundNode boundKProtected;
							boundKProtected = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: VisibilityKind.Protected, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKProtected);
							break;
						case MetaCompilerSyntaxKind.KPublic:
							BoundNode boundKPublic;
							boundKPublic = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: VisibilityKind.Public, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKPublic);
							break;
						case MetaCompilerSyntaxKind.KInternal:
							BoundNode boundKInternal;
							boundKInternal = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: VisibilityKind.Internal, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKInternal);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Visibility", syntax: node, hasErrors: false);
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
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							this.Visit(node.Visibility, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Visibility, childBoundNodes);
					}
				}
				if (node.ClassModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassModifier.Node))
					{
						foreach (var item in node.ClassModifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.Class_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Class_))
						{
							this.Visit(node.Class_, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Class_, childBoundNodes);
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
		
		public BoundNode VisitClassModifier(ClassModifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Abstract_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Abstract_))
						{
							this.Visit(node.Abstract_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Abstract_, childBoundNodesForParent);
					}
				}
				if (node.Sealed_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Sealed_))
						{
							this.Visit(node.Sealed_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Sealed_, childBoundNodesForParent);
					}
				}
				if (node.Partial_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Partial_))
						{
							this.Visit(node.Partial_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Partial_, childBoundNodesForParent);
					}
				}
				if (node.Static_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Static_))
						{
							this.Visit(node.Static_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Static_, childBoundNodesForParent);
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
				if (node.ClassPhases != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassPhases))
						{
							this.Visit(node.ClassPhases, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ClassPhases, childBoundNodes);
					}
				}
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
		
		public BoundNode VisitClassPhases(ClassPhasesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Phases", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitClass_(Class_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KClass)))
				{
					if (node.KClass.GetKind() == MetaCompilerSyntaxKind.KClass)
					{
						BoundNode boundKClass;
						boundKClass = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ClassKind.Class, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKClass);
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
		
		public BoundNode VisitSymbolDeclaration(SymbolDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							this.Visit(node.Visibility, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Visibility, childBoundNodes);
					}
				}
				if (node.Visit_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visit_))
						{
							this.Visit(node.Visit_, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Visit_, childBoundNodes);
					}
				}
				if (node.ClassModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassModifier.Node))
					{
						foreach (var item in node.ClassModifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.Symbol_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Symbol_))
						{
							this.Visit(node.Symbol_, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Symbol_, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Symbol), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitSymbol_(Symbol_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KSymbol)))
				{
					if (node.KSymbol.GetKind() == MetaCompilerSyntaxKind.KSymbol)
					{
						BoundNode boundKSymbol;
						boundKSymbol = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ClassKind.Symbol, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKSymbol);
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
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							this.Visit(node.Visibility, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Visibility, childBoundNodes);
					}
				}
				if (node.MemberModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MemberModifier.Node))
					{
						foreach (var item in node.MemberModifier)
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
				if (node.FieldKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldKind))
						{
							this.Visit(node.FieldKind, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FieldKind, childBoundNodes);
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
		
		public BoundNode VisitFieldKind(FieldKindSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.FieldKind)))
				{
					switch (node.FieldKind.GetKind().Switch())
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
		
		public BoundNode VisitMemberModifier(MemberModifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Partial_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Partial_))
						{
							this.Visit(node.Partial_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Partial_, childBoundNodesForParent);
					}
				}
				if (node.Static_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Static_))
						{
							this.Visit(node.Static_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Static_, childBoundNodesForParent);
					}
				}
				if (node.Virtual_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Virtual_))
						{
							this.Visit(node.Virtual_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Virtual_, childBoundNodesForParent);
					}
				}
				if (node.Abstract_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Abstract_))
						{
							this.Visit(node.Abstract_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Abstract_, childBoundNodesForParent);
					}
				}
				if (node.Sealed_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Sealed_))
						{
							this.Visit(node.Sealed_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Sealed_, childBoundNodesForParent);
					}
				}
				if (node.New_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.New_))
						{
							this.Visit(node.New_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.New_, childBoundNodesForParent);
					}
				}
				if (node.Override_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Override_))
						{
							this.Visit(node.Override_, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Override_, childBoundNodesForParent);
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
				if (node.SimpleOrDictionaryType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrDictionaryType))
						{
							this.Visit(node.SimpleOrDictionaryType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.SimpleOrDictionaryType, childBoundNodes);
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
		
		public BoundNode VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.SimpleOrArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrArrayType))
						{
							this.Visit(node.SimpleOrArrayType, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.SimpleOrArrayType, childBoundNodesForParent);
					}
				}
				if (node.DictionaryType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DictionaryType))
						{
							this.Visit(node.DictionaryType, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.DictionaryType, childBoundNodesForParent);
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
		
		public BoundNode VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.SimpleOrGenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrGenericType))
						{
							this.Visit(node.SimpleOrGenericType, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.SimpleOrGenericType, childBoundNodesForParent);
					}
				}
				if (node.ArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArrayType))
						{
							this.Visit(node.ArrayType, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ArrayType, childBoundNodesForParent);
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
		
		public BoundNode VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.SimpleType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleType))
						{
							this.Visit(node.SimpleType, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.SimpleType, childBoundNodesForParent);
					}
				}
				if (node.GenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.GenericType))
						{
							this.Visit(node.GenericType, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.GenericType, childBoundNodesForParent);
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
				if (node.SimpleOrGenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrGenericType))
						{
							var childBoundNodesOfSimpleOrGenericType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.SimpleOrGenericType, childBoundNodesOfSimpleOrGenericType);
							BoundNode boundSimpleOrGenericType;
							boundSimpleOrGenericType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSimpleOrGenericType.ToImmutableAndFree(), name: "InnerType", syntax: node.SimpleOrGenericType, hasErrors: false);
							childBoundNodes.Add(boundSimpleOrGenericType);
						}
					}
					else
					{
						childBoundNodes.Add(node.SimpleOrGenericType);
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
		
		public BoundNode VisitDictionaryType(DictionaryTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Key != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Key))
						{
							var childBoundNodesOfKey = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Key, childBoundNodesOfKey);
							BoundNode boundKey;
							boundKey = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfKey.ToImmutableAndFree(), name: "KeyType", syntax: node.Key, hasErrors: false);
							childBoundNodes.Add(boundKey);
						}
					}
					else
					{
						childBoundNodes.Add(node.Key);
					}
				}
				if (node.Value != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Value))
						{
							var childBoundNodesOfValue = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Value, childBoundNodesOfValue);
							BoundNode boundValue;
							boundValue = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfValue.ToImmutableAndFree(), name: "ValueType", syntax: node.Value, hasErrors: false);
							childBoundNodes.Add(boundValue);
						}
					}
					else
					{
						childBoundNodes.Add(node.Value);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(DictionaryType), syntax: node, hasErrors: false);
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
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							this.Visit(node.Visibility, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Visibility, childBoundNodes);
					}
				}
				if (node.MemberModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MemberModifier.Node))
					{
						foreach (var item in node.MemberModifier)
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
		
		public BoundNode VisitStatic_(Static_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsStatic", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitBase_(Base_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KBase)))
				{
					if (node.KBase.GetKind() == MetaCompilerSyntaxKind.KBase)
					{
						BoundNode boundKBase;
						boundKBase = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: SymbolModifierKind.Base, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKBase);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "SymbolModifier", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitMeta_(Meta_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KMeta)))
				{
					if (node.KMeta.GetKind() == MetaCompilerSyntaxKind.KMeta)
					{
						BoundNode boundKMeta;
						boundKMeta = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: SymbolModifierKind.Meta, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKMeta);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "SymbolModifier", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitSource_(Source_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KSource)))
				{
					if (node.KSource.GetKind() == MetaCompilerSyntaxKind.KSource)
					{
						BoundNode boundKSource;
						boundKSource = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: SymbolModifierKind.Source, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKSource);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "SymbolModifier", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitVisit_(Visit_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsVisit", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitPartial_(Partial_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsPartial", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitVirtual_(Virtual_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsVirtual", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitSealed_(Sealed_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsSealed", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitOverride_(Override_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsOverride", value: true, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitNew_(New_Syntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "IsNew", value: true, syntax: node, hasErrors: false);
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


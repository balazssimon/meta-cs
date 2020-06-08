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
using PilV2;
using PilV2.Syntax;
using PilV2.Symbols;

namespace PilV2.Binding
{
	// Make sure to keep this in sync with PilIsBindableNodeVisitor
    public class PilBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, IPilSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public PilBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		public BoundNode VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				if (node.Declaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration.Node))
					{
						foreach (var item in node.Declaration)
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
				}
				if (node.TypeDefDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeDefDeclaration))
						{
							this.Visit(node.TypeDefDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.TypeDefDeclaration, childBoundNodesForParent);
					}
				}
				if (node.ExternalParameterDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExternalParameterDeclaration))
						{
							this.Visit(node.ExternalParameterDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ExternalParameterDeclaration, childBoundNodesForParent);
					}
				}
				if (node.EnumDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumDeclaration))
						{
							this.Visit(node.EnumDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.EnumDeclaration, childBoundNodesForParent);
					}
				}
				if (node.ObjectDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectDeclaration))
						{
							this.Visit(node.ObjectDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ObjectDeclaration, childBoundNodesForParent);
					}
				}
				if (node.FunctionDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionDeclaration))
						{
							this.Visit(node.FunctionDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.FunctionDeclaration, childBoundNodesForParent);
					}
				}
				if (node.QueryDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryDeclaration))
						{
							this.Visit(node.QueryDeclaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.QueryDeclaration, childBoundNodesForParent);
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
		
		public BoundNode VisitTypeDefDeclaration(TypeDefDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							var childBoundNodesOfTypeReference = ArrayBuilder<object>.GetInstance();
							this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
							BoundNode boundTypeReference;
							boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), name: "TargetType", syntax: node.TypeReference, hasErrors: false);
							childBoundNodes.Add(boundTypeReference);
						}
					}
					else
					{
						childBoundNodes.Add(node.TypeReference);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(TypeAlias), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							var childBoundNodesOfExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Expression, childBoundNodesOfExpression);
							BoundNode boundExpression;
							boundExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfExpression.ToImmutableAndFree(), name: "DefaultValue", syntax: node.Expression, hasErrors: false);
							childBoundNodes.Add(boundExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.Expression);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ExternalParameter), syntax: node, hasErrors: false);
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
				if (node.EnumLiterals != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumLiterals))
						{
							this.Visit(node.EnumLiterals, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.EnumLiterals, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(PilEnum), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitEnumLiterals(EnumLiteralsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.EnumLiteral != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumLiteral.Node))
					{
						foreach (var item in node.EnumLiteral)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Literals", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitEnumLiteral(EnumLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitObjectDeclaration(ObjectDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ObjectHeader != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectHeader))
						{
							this.Visit(node.ObjectHeader, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ObjectHeader, childBoundNodes);
					}
				}
				if (node.ObjectExternalParameters != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectExternalParameters))
						{
							this.Visit(node.ObjectExternalParameters, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ObjectExternalParameters, childBoundNodes);
					}
				}
				if (node.ObjectFields != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectFields))
						{
							this.Visit(node.ObjectFields, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ObjectFields, childBoundNodes);
					}
				}
				if (node.ObjectFunctions != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectFunctions))
						{
							this.Visit(node.ObjectFunctions, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ObjectFunctions, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(PilObject), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitObjectHeader(ObjectHeaderSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
							this.Visit(node.Name, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodesForParent);
					}
				}
				if (node.Ports != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Ports))
						{
							this.Visit(node.Ports, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Ports, childBoundNodesForParent);
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
		
		public BoundNode VisitPorts(PortsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Port != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Port.Node))
					{
						foreach (var item in node.Port)
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
		
		public BoundNode VisitPort(PortSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Port), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Ports", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitObjectExternalParameters(ObjectExternalParametersSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ExternalParameterDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ExternalParameterDeclaration.Node))
					{
						foreach (var item in node.ExternalParameterDeclaration)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "ExternalParameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitObjectFields(ObjectFieldsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.VariableDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VariableDeclaration.Node))
					{
						foreach (var item in node.VariableDeclaration)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Fields", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitObjectFunctions(ObjectFunctionsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.FunctionDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FunctionDeclaration.Node))
					{
						foreach (var item in node.FunctionDeclaration)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Functions", syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.FunctionHeader != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionHeader))
						{
							this.Visit(node.FunctionHeader, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FunctionHeader, childBoundNodes);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Function), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitFunctionHeader(FunctionHeaderSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
							this.Visit(node.Name, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodesForParent);
					}
				}
				if (node.FunctionParams != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionParams))
						{
							this.Visit(node.FunctionParams, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.FunctionParams, childBoundNodesForParent);
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
							boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), name: "ReturnType", syntax: node.TypeReference, hasErrors: false);
							childBoundNodesForParent.Add(boundTypeReference);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.TypeReference);
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
		
		public BoundNode VisitFunctionParams(FunctionParamsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Parameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitParam(ParamSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Variable), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryDeclaration(QueryDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.QueryHeader != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryHeader))
						{
							this.Visit(node.QueryHeader, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.QueryHeader, childBoundNodes);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.QueryExternalParameters != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryExternalParameters.Node))
					{
						foreach (var item in node.QueryExternalParameters)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.QueryField != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryField.Node))
					{
						foreach (var item in node.QueryField)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.FunctionDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FunctionDeclaration.Node))
					{
						foreach (var item in node.FunctionDeclaration)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.QueryObject != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObject.Node))
					{
						foreach (var item in node.QueryObject)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.EndName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndName))
						{
							this.Visit(node.EndName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.EndName, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Query), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryHeader(QueryHeaderSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
							this.Visit(node.Name, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodesForParent);
					}
				}
				if (node.QueryRequestParams != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryRequestParams))
						{
							this.Visit(node.QueryRequestParams, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.QueryRequestParams, childBoundNodesForParent);
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
		
		public BoundNode VisitQueryRequestParams(QueryRequestParamsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "RequestParameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryAcceptParams(QueryAcceptParamsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "AcceptParameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryRefuseParams(QueryRefuseParamsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "RefuseParameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryCancelParams(QueryCancelParamsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "CancelParameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryExternalParameters(QueryExternalParametersSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ExternalParameterDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExternalParameterDeclaration))
						{
							this.Visit(node.ExternalParameterDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ExternalParameterDeclaration, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "ExternalParameters", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryField(QueryFieldSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.VariableDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclaration))
						{
							this.Visit(node.VariableDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.VariableDeclaration, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Fields", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryFunction(QueryFunctionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.FunctionDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionDeclaration))
						{
							this.Visit(node.FunctionDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FunctionDeclaration, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Functions", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryObject(QueryObjectSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.QueryObjectField != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObjectField.Node))
					{
						foreach (var item in node.QueryObjectField)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.QueryObjectFunction != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObjectFunction.Node))
					{
						foreach (var item in node.QueryObjectFunction)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.QueryObjectEvent != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObjectEvent.Node))
					{
						foreach (var item in node.QueryObjectEvent)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.EndName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndName))
						{
							this.Visit(node.EndName, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.EndName, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(QueryObject), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Objects", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryObjectField(QueryObjectFieldSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.VariableDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclaration))
						{
							this.Visit(node.VariableDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.VariableDeclaration, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Fields", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryObjectFunction(QueryObjectFunctionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.FunctionDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionDeclaration))
						{
							this.Visit(node.FunctionDeclaration, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FunctionDeclaration, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Functions", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitQueryObjectEvent(QueryObjectEventSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Input != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Input))
						{
							this.Visit(node.Input, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Input, childBoundNodes);
					}
				}
				if (node.Trigger != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Trigger))
						{
							this.Visit(node.Trigger, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Trigger, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Events", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitInput(InputSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.InputPortList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.InputPortList))
						{
							this.Visit(node.InputPortList, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.InputPortList, childBoundNodes);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(InputEvent), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitInputPortList(InputPortListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.InputPort != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.InputPort.Node))
					{
						foreach (var item in node.InputPort)
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
		
		public BoundNode VisitInputPort(InputPortSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.PortName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PortName))
						{
							var childBoundNodesOfPortName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.PortName, childBoundNodesOfPortName);
							BoundNode boundPortName;
							boundPortName = this.CreateBoundValue(this.BoundTree, childBoundNodesOfPortName.ToImmutableAndFree(), syntax: node.PortName, hasErrors: false);
							boundPortName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundPortName), name: "PortName", syntax: node.PortName, hasErrors: false);
							childBoundNodes.Add(boundPortName);
						}
					}
					else
					{
						childBoundNodes.Add(node.PortName);
					}
				}
				if (node.QueryName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryName))
						{
							var childBoundNodesOfQueryName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.QueryName, childBoundNodesOfQueryName);
							BoundNode boundQueryName;
							boundQueryName = this.CreateBoundValue(this.BoundTree, childBoundNodesOfQueryName.ToImmutableAndFree(), syntax: node.QueryName, hasErrors: false);
							boundQueryName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQueryName), name: "QueryName", syntax: node.QueryName, hasErrors: false);
							childBoundNodes.Add(boundQueryName);
						}
					}
					else
					{
						childBoundNodes.Add(node.QueryName);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(RequestPort), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Ports", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTrigger(TriggerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.TriggerVarList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TriggerVarList))
						{
							this.Visit(node.TriggerVarList, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.TriggerVarList, childBoundNodes);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Trigger), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTriggerVarList(TriggerVarListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.TriggerVar != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TriggerVar.Node))
					{
						foreach (var item in node.TriggerVar)
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
		
		public BoundNode VisitTriggerVar(TriggerVarSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Identifier, childBoundNodesOfIdentifier);
							BoundNode boundIdentifier;
							boundIdentifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), syntax: node.Identifier, hasErrors: false);
							boundIdentifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundIdentifier), name: "TriggerVariables", syntax: node.Identifier, hasErrors: false);
							childBoundNodesForParent.Add(boundIdentifier);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Identifier);
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
		
		public BoundNode VisitStatements(StatementsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Statement != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Statement.Node))
					{
						foreach (var item in node.Statement)
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Statements", syntax: node, hasErrors: false);
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
				if (node.VariableDeclarationStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclarationStatement))
						{
							this.Visit(node.VariableDeclarationStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.VariableDeclarationStatement, childBoundNodesForParent);
					}
				}
				if (node.RequestStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RequestStatement))
						{
							this.Visit(node.RequestStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.RequestStatement, childBoundNodesForParent);
					}
				}
				if (node.ForkStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkStatement))
						{
							this.Visit(node.ForkStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ForkStatement, childBoundNodesForParent);
					}
				}
				if (node.ForkRequestStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkRequestStatement))
						{
							this.Visit(node.ForkRequestStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ForkRequestStatement, childBoundNodesForParent);
					}
				}
				if (node.IfStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IfStatement))
						{
							this.Visit(node.IfStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.IfStatement, childBoundNodesForParent);
					}
				}
				if (node.ResponseStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ResponseStatement))
						{
							this.Visit(node.ResponseStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ResponseStatement, childBoundNodesForParent);
					}
				}
				if (node.CancelStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CancelStatement))
						{
							this.Visit(node.CancelStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.CancelStatement, childBoundNodesForParent);
					}
				}
				if (node.AssignmentStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AssignmentStatement))
						{
							this.Visit(node.AssignmentStatement, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.AssignmentStatement, childBoundNodesForParent);
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
		
		public BoundNode VisitForkStatement(ForkStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							var childBoundNodesOfExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Expression, childBoundNodesOfExpression);
							BoundNode boundExpression;
							boundExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfExpression.ToImmutableAndFree(), name: "SwitchValue", syntax: node.Expression, hasErrors: false);
							childBoundNodes.Add(boundExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.Expression);
					}
				}
				if (node.CaseBranch != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CaseBranch.Node))
					{
						foreach (var item in node.CaseBranch)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.ElseBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ElseBranch))
						{
							this.Visit(node.ElseBranch, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ElseBranch, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ForkStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitCaseBranch(CaseBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), name: "Value", syntax: node.Condition, hasErrors: false);
							childBoundNodes.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodes.Add(node.Condition);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Branch), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Branches", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitElseBranch(ElseBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Branch), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Branches", syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.IfBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IfBranch))
						{
							this.Visit(node.IfBranch, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.IfBranch, childBoundNodes);
					}
				}
				if (node.ElseIfBranch != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElseIfBranch.Node))
					{
						foreach (var item in node.ElseIfBranch)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (node.ElseBranch != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElseBranch.Node))
					{
						foreach (var item in node.ElseBranch)
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ForkStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitIfBranch(IfBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ConditionalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpression))
						{
							var childBoundNodesOfConditionalExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ConditionalExpression, childBoundNodesOfConditionalExpression);
							BoundNode boundConditionalExpression;
							boundConditionalExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfConditionalExpression.ToImmutableAndFree(), name: "Value", syntax: node.ConditionalExpression, hasErrors: false);
							childBoundNodes.Add(boundConditionalExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.ConditionalExpression);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Branch), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Branches", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitElseIfBranch(ElseIfBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.IfBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IfBranch))
						{
							this.Visit(node.IfBranch, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.IfBranch, childBoundNodesForParent);
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
		
		public BoundNode VisitRequestStatement(RequestStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.LeftSide != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.LeftSide))
						{
							var childBoundNodesOfLeftSide = ArrayBuilder<object>.GetInstance();
							this.Visit(node.LeftSide, childBoundNodesOfLeftSide);
							BoundNode boundLeftSide;
							boundLeftSide = this.CreateBoundValue(this.BoundTree, childBoundNodesOfLeftSide.ToImmutableAndFree(), syntax: node.LeftSide, hasErrors: false);
							boundLeftSide = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundLeftSide), name: "RequestVariable", syntax: node.LeftSide, hasErrors: false);
							childBoundNodes.Add(boundLeftSide);
						}
					}
					else
					{
						childBoundNodes.Add(node.LeftSide);
					}
				}
				if (node.CallRequest != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CallRequest))
						{
							this.Visit(node.CallRequest, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.CallRequest, childBoundNodes);
					}
				}
				if (node.Assertion != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Assertion))
						{
							var childBoundNodesOfAssertion = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Assertion, childBoundNodesOfAssertion);
							BoundNode boundAssertion;
							boundAssertion = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfAssertion.ToImmutableAndFree(), name: "Assertion", syntax: node.Assertion, hasErrors: false);
							childBoundNodes.Add(boundAssertion);
						}
					}
					else
					{
						childBoundNodes.Add(node.Assertion);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(RequestStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitCallRequest(CallRequestSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.PortName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PortName))
						{
							var childBoundNodesOfPortName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.PortName, childBoundNodesOfPortName);
							BoundNode boundPortName;
							boundPortName = this.CreateBoundValue(this.BoundTree, childBoundNodesOfPortName.ToImmutableAndFree(), syntax: node.PortName, hasErrors: false);
							boundPortName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundPortName), name: "PortName", syntax: node.PortName, hasErrors: false);
							childBoundNodesForParent.Add(boundPortName);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.PortName);
					}
				}
				if (node.QueryName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryName))
						{
							var childBoundNodesOfQueryName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.QueryName, childBoundNodesOfQueryName);
							BoundNode boundQueryName;
							boundQueryName = this.CreateBoundValue(this.BoundTree, childBoundNodesOfQueryName.ToImmutableAndFree(), syntax: node.QueryName, hasErrors: false);
							boundQueryName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQueryName), name: "QueryName", syntax: node.QueryName, hasErrors: false);
							childBoundNodesForParent.Add(boundQueryName);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.QueryName);
					}
				}
				if (node.RequestArguments != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RequestArguments))
						{
							this.Visit(node.RequestArguments, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.RequestArguments, childBoundNodesForParent);
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
		
		public BoundNode VisitRequestArguments(RequestArgumentsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ExpressionList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExpressionList))
						{
							this.Visit(node.ExpressionList, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ExpressionList, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Arguments", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitResponseStatement(ResponseStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ResponseStatementKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ResponseStatementKind))
						{
							this.Visit(node.ResponseStatementKind, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ResponseStatementKind, childBoundNodes);
					}
				}
				if (node.Assertion != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Assertion))
						{
							var childBoundNodesOfAssertion = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Assertion, childBoundNodesOfAssertion);
							BoundNode boundAssertion;
							boundAssertion = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfAssertion.ToImmutableAndFree(), name: "Assertion", syntax: node.Assertion, hasErrors: false);
							childBoundNodes.Add(boundAssertion);
						}
					}
					else
					{
						childBoundNodes.Add(node.Assertion);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ResponseStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitCancelStatement(CancelStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.CancelStatementKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CancelStatementKind))
						{
							this.Visit(node.CancelStatementKind, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.CancelStatementKind, childBoundNodes);
					}
				}
				if (node.PortName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PortName))
						{
							var childBoundNodesOfPortName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.PortName, childBoundNodesOfPortName);
							BoundNode boundPortName;
							boundPortName = this.CreateBoundValue(this.BoundTree, childBoundNodesOfPortName.ToImmutableAndFree(), syntax: node.PortName, hasErrors: false);
							boundPortName = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundPortName), name: "PortName", syntax: node.PortName, hasErrors: false);
							childBoundNodes.Add(boundPortName);
						}
					}
					else
					{
						childBoundNodes.Add(node.PortName);
					}
				}
				if (node.Assertion != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Assertion))
						{
							var childBoundNodesOfAssertion = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Assertion, childBoundNodesOfAssertion);
							BoundNode boundAssertion;
							boundAssertion = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfAssertion.ToImmutableAndFree(), name: "Assertion", syntax: node.Assertion, hasErrors: false);
							childBoundNodes.Add(boundAssertion);
						}
					}
					else
					{
						childBoundNodes.Add(node.Assertion);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ResponseStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitAssertion(AssertionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							this.Visit(node.Expression, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Expression, childBoundNodes);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Condition", syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), type: typeof(AssertStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitResponseStatementKind(ResponseStatementKindSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.ResponseStatementKind)))
				{
					switch (node.ResponseStatementKind.GetKind().Switch())
					{
						case PilSyntaxKind.KAccept:
							BoundNode boundKAccept;
							boundKAccept = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ResponseKind.Accept, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKAccept);
							break;
						case PilSyntaxKind.KRefuse:
							BoundNode boundKRefuse;
							boundKRefuse = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ResponseKind.Refuse, syntax: node, hasErrors: false);
							childBoundNodes.Add(boundKRefuse);
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
		
		public BoundNode VisitCancelStatementKind(CancelStatementKindSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KCancel)))
				{
					if (node.KCancel.GetKind() == PilSyntaxKind.KCancel)
					{
						BoundNode boundKCancel;
						boundKCancel = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: ResponseKind.Cancel, syntax: node, hasErrors: false);
						boundKCancel = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundKCancel), name: "Kind", syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKCancel);
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
		
		public BoundNode VisitForkRequestStatement(ForkRequestStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ForkRequestVariable != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkRequestVariable))
						{
							this.Visit(node.ForkRequestVariable, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ForkRequestVariable, childBoundNodes);
					}
				}
				if (node.AcceptBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AcceptBranch))
						{
							this.Visit(node.AcceptBranch, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.AcceptBranch, childBoundNodes);
					}
				}
				if (node.RefuseBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RefuseBranch))
						{
							this.Visit(node.RefuseBranch, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.RefuseBranch, childBoundNodes);
					}
				}
				if (node.CancelBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CancelBranch))
						{
							this.Visit(node.CancelBranch, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.CancelBranch, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ForkRequestStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitForkRequestVariable(ForkRequestVariableSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ForkRequestIdentifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkRequestIdentifier))
						{
							var childBoundNodesOfForkRequestIdentifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ForkRequestIdentifier, childBoundNodesOfForkRequestIdentifier);
							BoundNode boundForkRequestIdentifier;
							boundForkRequestIdentifier = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfForkRequestIdentifier.ToImmutableAndFree(), name: "SwitchVariable", syntax: node.ForkRequestIdentifier, hasErrors: false);
							childBoundNodesForParent.Add(boundForkRequestIdentifier);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.ForkRequestIdentifier);
					}
				}
				if (node.RequestStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RequestStatement))
						{
							var childBoundNodesOfRequestStatement = ArrayBuilder<object>.GetInstance();
							this.Visit(node.RequestStatement, childBoundNodesOfRequestStatement);
							BoundNode boundRequestStatement;
							boundRequestStatement = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfRequestStatement.ToImmutableAndFree(), name: "SwitchRequest", syntax: node.RequestStatement, hasErrors: false);
							childBoundNodesForParent.Add(boundRequestStatement);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.RequestStatement);
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
		
		public BoundNode VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Identifier, childBoundNodesOfIdentifier);
							BoundNode boundIdentifier;
							boundIdentifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), syntax: node.Identifier, hasErrors: false);
							childBoundNodesForParent.Add(boundIdentifier);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Identifier);
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
		
		public BoundNode VisitAcceptBranch(AcceptBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KAccept)))
				{
					if (node.KAccept.GetKind() == PilSyntaxKind.KAccept)
					{
						BoundNode boundKAccept;
						boundKAccept = this.CreateBoundProperty(this.BoundTree, ImmutableArray<object>.Empty, name: "Kind", value: ResponseKind.Accept, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKAccept);
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), name: "Condition", syntax: node.Condition, hasErrors: false);
							childBoundNodes.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodes.Add(node.Condition);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ForkRequestBranch), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Branches", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitRefuseBranch(RefuseBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KRefuse)))
				{
					if (node.KRefuse.GetKind() == PilSyntaxKind.KRefuse)
					{
						BoundNode boundKRefuse;
						boundKRefuse = this.CreateBoundProperty(this.BoundTree, ImmutableArray<object>.Empty, name: "Kind", value: ResponseKind.Refuse, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKRefuse);
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), name: "Condition", syntax: node.Condition, hasErrors: false);
							childBoundNodes.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodes.Add(node.Condition);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ForkRequestBranch), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Branches", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitCancelBranch(CancelBranchSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KCancel)))
				{
					if (node.KCancel.GetKind() == PilSyntaxKind.KCancel)
					{
						BoundNode boundKCancel;
						boundKCancel = this.CreateBoundProperty(this.BoundTree, ImmutableArray<object>.Empty, name: "Kind", value: ResponseKind.Cancel, syntax: node, hasErrors: false);
						childBoundNodes.Add(boundKCancel);
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), name: "Condition", syntax: node.Condition, hasErrors: false);
							childBoundNodes.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodes.Add(node.Condition);
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							this.Visit(node.Comment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Comment, childBoundNodes);
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							this.Visit(node.Statements, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Statements, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ForkRequestBranch), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Branches", syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.VariableDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclaration))
						{
							var childBoundNodesOfVariableDeclaration = ArrayBuilder<object>.GetInstance();
							this.Visit(node.VariableDeclaration, childBoundNodesOfVariableDeclaration);
							BoundNode boundVariableDeclaration;
							boundVariableDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfVariableDeclaration.ToImmutableAndFree(), name: "Variable", syntax: node.VariableDeclaration, hasErrors: false);
							childBoundNodes.Add(boundVariableDeclaration);
						}
					}
					else
					{
						childBoundNodes.Add(node.VariableDeclaration);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(VariableDeclarationStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitVariableDeclaration(VariableDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							var childBoundNodesOfExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Expression, childBoundNodesOfExpression);
							BoundNode boundExpression;
							boundExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfExpression.ToImmutableAndFree(), name: "DefaultValue", syntax: node.Expression, hasErrors: false);
							childBoundNodes.Add(boundExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.Expression);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(Variable), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitAssignmentStatement(AssignmentStatementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.LeftSide != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.LeftSide))
						{
							var childBoundNodesOfLeftSide = ArrayBuilder<object>.GetInstance();
							this.Visit(node.LeftSide, childBoundNodesOfLeftSide);
							BoundNode boundLeftSide;
							boundLeftSide = this.CreateBoundValue(this.BoundTree, childBoundNodesOfLeftSide.ToImmutableAndFree(), syntax: node.LeftSide, hasErrors: false);
							boundLeftSide = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundLeftSide), name: "LeftSide", syntax: node.LeftSide, hasErrors: false);
							childBoundNodes.Add(boundLeftSide);
						}
					}
					else
					{
						childBoundNodes.Add(node.LeftSide);
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
							boundValue = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfValue.ToImmutableAndFree(), name: "Value", syntax: node.Value, hasErrors: false);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(AssignmentStatement), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitLeftSide(LeftSideSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							this.Visit(node.Identifier, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Identifier, childBoundNodesForParent);
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
				if (node.Expression != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Expression.Node))
					{
						foreach (var item in node.Expression)
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
		
		public BoundNode VisitExpression(ExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ArithmeticExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpression))
						{
							this.Visit(node.ArithmeticExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ArithmeticExpression, childBoundNodesForParent);
					}
				}
				if (node.ConditionalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpression))
						{
							this.Visit(node.ConditionalExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ConditionalExpression, childBoundNodesForParent);
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
		
		public BoundNode VisitMulDivExpression(MulDivExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							var childBoundNodesOfLeft = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Left, childBoundNodesOfLeft);
							BoundNode boundLeft;
							boundLeft = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfLeft.ToImmutableAndFree(), name: "Left", syntax: node.Left, hasErrors: false);
							childBoundNodes.Add(boundLeft);
						}
					}
					else
					{
						childBoundNodes.Add(node.Left);
					}
				}
				if (node.OpMulDiv != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpMulDiv))
						{
							var childBoundNodesOfOpMulDiv = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OpMulDiv, childBoundNodesOfOpMulDiv);
							BoundNode boundOpMulDiv;
							boundOpMulDiv = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOpMulDiv.ToImmutableAndFree(), name: "Operator", syntax: node.OpMulDiv, hasErrors: false);
							childBoundNodes.Add(boundOpMulDiv);
						}
					}
					else
					{
						childBoundNodes.Add(node.OpMulDiv);
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							var childBoundNodesOfRight = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Right, childBoundNodesOfRight);
							BoundNode boundRight;
							boundRight = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfRight.ToImmutableAndFree(), name: "Right", syntax: node.Right, hasErrors: false);
							childBoundNodes.Add(boundRight);
						}
					}
					else
					{
						childBoundNodes.Add(node.Right);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(BinaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitPlusMinusExpression(PlusMinusExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							var childBoundNodesOfLeft = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Left, childBoundNodesOfLeft);
							BoundNode boundLeft;
							boundLeft = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfLeft.ToImmutableAndFree(), name: "Left", syntax: node.Left, hasErrors: false);
							childBoundNodes.Add(boundLeft);
						}
					}
					else
					{
						childBoundNodes.Add(node.Left);
					}
				}
				if (node.OpAddSub != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpAddSub))
						{
							var childBoundNodesOfOpAddSub = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OpAddSub, childBoundNodesOfOpAddSub);
							BoundNode boundOpAddSub;
							boundOpAddSub = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOpAddSub.ToImmutableAndFree(), name: "Operator", syntax: node.OpAddSub, hasErrors: false);
							childBoundNodes.Add(boundOpAddSub);
						}
					}
					else
					{
						childBoundNodes.Add(node.OpAddSub);
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							var childBoundNodesOfRight = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Right, childBoundNodesOfRight);
							BoundNode boundRight;
							boundRight = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfRight.ToImmutableAndFree(), name: "Right", syntax: node.Right, hasErrors: false);
							childBoundNodes.Add(boundRight);
						}
					}
					else
					{
						childBoundNodes.Add(node.Right);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(BinaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitNegateExpression(NegateExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.OpMinus != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpMinus))
						{
							var childBoundNodesOfOpMinus = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OpMinus, childBoundNodesOfOpMinus);
							BoundNode boundOpMinus;
							boundOpMinus = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOpMinus.ToImmutableAndFree(), name: "Operator", syntax: node.OpMinus, hasErrors: false);
							childBoundNodes.Add(boundOpMinus);
						}
					}
					else
					{
						childBoundNodes.Add(node.OpMinus);
					}
				}
				if (node.ArithmeticExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpressionTerminator))
						{
							var childBoundNodesOfArithmeticExpressionTerminator = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ArithmeticExpressionTerminator, childBoundNodesOfArithmeticExpressionTerminator);
							BoundNode boundArithmeticExpressionTerminator;
							boundArithmeticExpressionTerminator = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfArithmeticExpressionTerminator.ToImmutableAndFree(), name: "Inner", syntax: node.ArithmeticExpressionTerminator, hasErrors: false);
							childBoundNodes.Add(boundArithmeticExpressionTerminator);
						}
					}
					else
					{
						childBoundNodes.Add(node.ArithmeticExpressionTerminator);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(UnaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ArithmeticExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpressionTerminator))
						{
							this.Visit(node.ArithmeticExpressionTerminator, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ArithmeticExpressionTerminator, childBoundNodesForParent);
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
		
		public BoundNode VisitOpMulDiv(OpMulDivSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.OpMulDiv)))
				{
					switch (node.OpMulDiv.GetKind().Switch())
					{
						case PilSyntaxKind.TAsterisk:
							BoundNode boundTAsterisk;
							boundTAsterisk = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.Multiply, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTAsterisk);
							break;
						case PilSyntaxKind.TSlash:
							BoundNode boundTSlash;
							boundTSlash = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.Divide, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTSlash);
							break;
						default:
							break;
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
		
		public BoundNode VisitOpAddSub(OpAddSubSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.OpAddSub)))
				{
					switch (node.OpAddSub.GetKind().Switch())
					{
						case PilSyntaxKind.TPlus:
							BoundNode boundTPlus;
							boundTPlus = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.Add, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTPlus);
							break;
						case PilSyntaxKind.TMinus:
							BoundNode boundTMinus;
							boundTMinus = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.Subtract, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTMinus);
							break;
						default:
							break;
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
		
		public BoundNode VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ArithmeticExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpression))
						{
							var childBoundNodesOfArithmeticExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ArithmeticExpression, childBoundNodesOfArithmeticExpression);
							BoundNode boundArithmeticExpression;
							boundArithmeticExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfArithmeticExpression.ToImmutableAndFree(), name: "Inner", syntax: node.ArithmeticExpression, hasErrors: false);
							childBoundNodes.Add(boundArithmeticExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.ArithmeticExpression);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ParenthesizedExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.TerminalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TerminalExpression))
						{
							this.Visit(node.TerminalExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.TerminalExpression, childBoundNodesForParent);
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
		
		public BoundNode VisitOpMinus(OpMinusSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), value: UnaryOperator.Minus, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitAndExpression(AndExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							var childBoundNodesOfLeft = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Left, childBoundNodesOfLeft);
							BoundNode boundLeft;
							boundLeft = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfLeft.ToImmutableAndFree(), name: "Left", syntax: node.Left, hasErrors: false);
							childBoundNodes.Add(boundLeft);
						}
					}
					else
					{
						childBoundNodes.Add(node.Left);
					}
				}
				if (node.AndAlsoOp != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AndAlsoOp))
						{
							var childBoundNodesOfAndAlsoOp = ArrayBuilder<object>.GetInstance();
							this.Visit(node.AndAlsoOp, childBoundNodesOfAndAlsoOp);
							BoundNode boundAndAlsoOp;
							boundAndAlsoOp = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfAndAlsoOp.ToImmutableAndFree(), name: "Operator", syntax: node.AndAlsoOp, hasErrors: false);
							childBoundNodes.Add(boundAndAlsoOp);
						}
					}
					else
					{
						childBoundNodes.Add(node.AndAlsoOp);
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							var childBoundNodesOfRight = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Right, childBoundNodesOfRight);
							BoundNode boundRight;
							boundRight = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfRight.ToImmutableAndFree(), name: "Right", syntax: node.Right, hasErrors: false);
							childBoundNodes.Add(boundRight);
						}
					}
					else
					{
						childBoundNodes.Add(node.Right);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(BinaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitOrExpression(OrExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							var childBoundNodesOfLeft = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Left, childBoundNodesOfLeft);
							BoundNode boundLeft;
							boundLeft = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfLeft.ToImmutableAndFree(), name: "Left", syntax: node.Left, hasErrors: false);
							childBoundNodes.Add(boundLeft);
						}
					}
					else
					{
						childBoundNodes.Add(node.Left);
					}
				}
				if (node.OrElseOp != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OrElseOp))
						{
							var childBoundNodesOfOrElseOp = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OrElseOp, childBoundNodesOfOrElseOp);
							BoundNode boundOrElseOp;
							boundOrElseOp = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOrElseOp.ToImmutableAndFree(), name: "Operator", syntax: node.OrElseOp, hasErrors: false);
							childBoundNodes.Add(boundOrElseOp);
						}
					}
					else
					{
						childBoundNodes.Add(node.OrElseOp);
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							var childBoundNodesOfRight = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Right, childBoundNodesOfRight);
							BoundNode boundRight;
							boundRight = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfRight.ToImmutableAndFree(), name: "Right", syntax: node.Right, hasErrors: false);
							childBoundNodes.Add(boundRight);
						}
					}
					else
					{
						childBoundNodes.Add(node.Right);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(BinaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitNotExpression(NotExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.OpExcl != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpExcl))
						{
							var childBoundNodesOfOpExcl = ArrayBuilder<object>.GetInstance();
							this.Visit(node.OpExcl, childBoundNodesOfOpExcl);
							BoundNode boundOpExcl;
							boundOpExcl = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOpExcl.ToImmutableAndFree(), name: "Operator", syntax: node.OpExcl, hasErrors: false);
							childBoundNodes.Add(boundOpExcl);
						}
					}
					else
					{
						childBoundNodes.Add(node.OpExcl);
					}
				}
				if (node.ConditionalExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpressionTerminator))
						{
							var childBoundNodesOfConditionalExpressionTerminator = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ConditionalExpressionTerminator, childBoundNodesOfConditionalExpressionTerminator);
							BoundNode boundConditionalExpressionTerminator;
							boundConditionalExpressionTerminator = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfConditionalExpressionTerminator.ToImmutableAndFree(), name: "Inner", syntax: node.ConditionalExpressionTerminator, hasErrors: false);
							childBoundNodes.Add(boundConditionalExpressionTerminator);
						}
					}
					else
					{
						childBoundNodes.Add(node.ConditionalExpressionTerminator);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(UnaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ConditionalExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpressionTerminator))
						{
							this.Visit(node.ConditionalExpressionTerminator, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ConditionalExpressionTerminator, childBoundNodesForParent);
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
		
		public BoundNode VisitAndAlsoOp(AndAlsoOpSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), value: BinaryOperator.AndAlso, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitOrElseOp(OrElseOpSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), value: BinaryOperator.OrElse, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitOpExcl(OpExclSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), value: UnaryOperator.Negate, syntax: node, hasErrors: false);
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
		
		public BoundNode VisitParenConditionalExpression(ParenConditionalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ConditionalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpression))
						{
							var childBoundNodesOfConditionalExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ConditionalExpression, childBoundNodesOfConditionalExpression);
							BoundNode boundConditionalExpression;
							boundConditionalExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfConditionalExpression.ToImmutableAndFree(), name: "Inner", syntax: node.ConditionalExpression, hasErrors: false);
							childBoundNodes.Add(boundConditionalExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.ConditionalExpression);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ParenthesizedExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ElementOfExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ElementOfExpression))
						{
							this.Visit(node.ElementOfExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ElementOfExpression, childBoundNodesForParent);
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
		
		public BoundNode VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ComparisonExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComparisonExpression))
						{
							this.Visit(node.ComparisonExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.ComparisonExpression, childBoundNodesForParent);
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
		
		public BoundNode VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.TerminalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TerminalExpression))
						{
							this.Visit(node.TerminalExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.TerminalExpression, childBoundNodesForParent);
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
		
		public BoundNode VisitComparisonExpression(ComparisonExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							var childBoundNodesOfLeft = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Left, childBoundNodesOfLeft);
							BoundNode boundLeft;
							boundLeft = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfLeft.ToImmutableAndFree(), name: "Left", syntax: node.Left, hasErrors: false);
							childBoundNodes.Add(boundLeft);
						}
					}
					else
					{
						childBoundNodes.Add(node.Left);
					}
				}
				if (node.Op != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Op))
						{
							var childBoundNodesOfOp = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Op, childBoundNodesOfOp);
							BoundNode boundOp;
							boundOp = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOp.ToImmutableAndFree(), name: "Operator", syntax: node.Op, hasErrors: false);
							childBoundNodes.Add(boundOp);
						}
					}
					else
					{
						childBoundNodes.Add(node.Op);
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							var childBoundNodesOfRight = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Right, childBoundNodesOfRight);
							BoundNode boundRight;
							boundRight = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfRight.ToImmutableAndFree(), name: "Right", syntax: node.Right, hasErrors: false);
							childBoundNodes.Add(boundRight);
						}
					}
					else
					{
						childBoundNodes.Add(node.Right);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(BinaryExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitComparisonOperator(ComparisonOperatorSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.ComparisonOperator)))
				{
					switch (node.ComparisonOperator.GetKind().Switch())
					{
						case PilSyntaxKind.TEqual:
							BoundNode boundTEqual;
							boundTEqual = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.Equal, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTEqual);
							break;
						case PilSyntaxKind.TNotEqual:
							BoundNode boundTNotEqual;
							boundTNotEqual = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.NotEqual, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTNotEqual);
							break;
						case PilSyntaxKind.TLessThan:
							BoundNode boundTLessThan;
							boundTLessThan = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.LessThan, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTLessThan);
							break;
						case PilSyntaxKind.TGreaterThan:
							BoundNode boundTGreaterThan;
							boundTGreaterThan = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.GreaterThan, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTGreaterThan);
							break;
						case PilSyntaxKind.TLessThanOrEqual:
							BoundNode boundTLessThanOrEqual;
							boundTLessThanOrEqual = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.LessThanOrEqual, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTLessThanOrEqual);
							break;
						case PilSyntaxKind.TGreaterThanOrEqual:
							BoundNode boundTGreaterThanOrEqual;
							boundTGreaterThanOrEqual = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: BinaryOperator.GreaterThanOrEqual, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTGreaterThanOrEqual);
							break;
						default:
							break;
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
		
		public BoundNode VisitElementOfExpression(ElementOfExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.TerminalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TerminalExpression))
						{
							var childBoundNodesOfTerminalExpression = ArrayBuilder<object>.GetInstance();
							this.Visit(node.TerminalExpression, childBoundNodesOfTerminalExpression);
							BoundNode boundTerminalExpression;
							boundTerminalExpression = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTerminalExpression.ToImmutableAndFree(), name: "Value", syntax: node.TerminalExpression, hasErrors: false);
							childBoundNodes.Add(boundTerminalExpression);
						}
					}
					else
					{
						childBoundNodes.Add(node.TerminalExpression);
					}
				}
				if (node.ElementOfValueList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ElementOfValueList))
						{
							this.Visit(node.ElementOfValueList, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.ElementOfValueList, childBoundNodes);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ElementOfExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitElementOfValueList(ElementOfValueListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.ElementOfValue != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElementOfValue.Node))
					{
						foreach (var item in node.ElementOfValue)
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
		
		public BoundNode VisitElementOfValue(ElementOfValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Set", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitTerminalExpression(TerminalExpressionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (node.VariableReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableReference))
						{
							this.Visit(node.VariableReference, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.VariableReference, childBoundNodesForParent);
					}
				}
				if (node.FunctionCallExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionCallExpression))
						{
							this.Visit(node.FunctionCallExpression, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.FunctionCallExpression, childBoundNodesForParent);
					}
				}
				if (node.Literal != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Literal))
						{
							this.Visit(node.Literal, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Literal, childBoundNodesForParent);
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
							var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Identifier, childBoundNodesOfIdentifier);
							BoundNode boundIdentifier;
							boundIdentifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), syntax: node.Identifier, hasErrors: false);
							boundIdentifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundIdentifier), name: "Name", syntax: node.Identifier, hasErrors: false);
							childBoundNodes.Add(boundIdentifier);
						}
					}
					else
					{
						childBoundNodes.Add(node.Identifier);
					}
				}
				if (node.ExpressionList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExpressionList))
						{
							var childBoundNodesOfExpressionList = ArrayBuilder<object>.GetInstance();
							this.Visit(node.ExpressionList, childBoundNodesOfExpressionList);
							BoundNode boundExpressionList;
							boundExpressionList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfExpressionList.ToImmutableAndFree(), name: "Arguments", syntax: node.ExpressionList, hasErrors: false);
							childBoundNodes.Add(boundExpressionList);
						}
					}
					else
					{
						childBoundNodes.Add(node.ExpressionList);
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(FunctionCallExpression), syntax: node, hasErrors: false);
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
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.VariableReferenceIdentifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VariableReferenceIdentifier.Node))
					{
						foreach (var item in node.VariableReferenceIdentifier)
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
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), type: typeof(ReferenceExpression), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
							var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Identifier, childBoundNodesOfIdentifier);
							BoundNode boundIdentifier;
							boundIdentifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), syntax: node.Identifier, hasErrors: false);
							childBoundNodes.Add(boundIdentifier);
						}
					}
					else
					{
						childBoundNodes.Add(node.Identifier);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Qualifier", syntax: node, hasErrors: false);
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
		
		public BoundNode VisitComment(CommentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Comment", syntax: node, hasErrors: false);
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
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Value", syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), type: typeof(LiteralExpression), syntax: node, hasErrors: false);
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
				if (node.BuiltInType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BuiltInType))
						{
							this.Visit(node.BuiltInType, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.BuiltInType, childBoundNodes);
					}
				}
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
					resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), types: ImmutableArray.Create(typeof(NamedType)), syntax: node, hasErrors: false);
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
		
		public BoundNode VisitBuiltInType(BuiltInTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitQualifierList(QualifierListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier.Node))
					{
						foreach (var item in node.Qualifier)
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
				if (node.Identifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
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
		
		public BoundNode VisitResultIdentifier(ResultIdentifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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


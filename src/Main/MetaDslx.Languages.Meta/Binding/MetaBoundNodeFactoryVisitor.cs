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
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

namespace MetaDslx.Languages.Meta.Binding
{
	// Make sure to keep this in sync with MetaIsBindableNodeVisitor
    public class MetaBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, IMetaSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public MetaBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

        protected BoundNode CreateBoundOpposite(BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundOppositeCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundOppositeCore(BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundOpposite(MetaBoundKind.Opposite, boundTree, childBoundNodes, syntax, hasErrors);
        }

		
		public BoundNode VisitMain(MainSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.NamespaceDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration))
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
		
		public BoundNode VisitName(NameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Identifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitQualifiedName(QualifiedNameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitQualifier(QualifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundQualifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitAttribute(AttributeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaAttribute)), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Attributes", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QualifiedName))
				{
					this.Visit(node.QualifiedName, childBoundNodes);
				}
			}
			if (node.NamespaceBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceBody))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaNamespace), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNamespaceBody(NamespaceBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.MetamodelDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MetamodelDeclaration))
				{
					this.Visit(node.MetamodelDeclaration, childBoundNodes);
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitMetamodelDeclaration(MetamodelDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.MetamodelPropertyList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MetamodelPropertyList))
				{
					this.Visit(node.MetamodelPropertyList, childBoundNodes);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaModel), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "DefinedMetaModel", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitMetamodelPropertyList(MetamodelPropertyListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.MetamodelProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MetamodelProperty.Node))
				{
					foreach (var item in node.MetamodelProperty)
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
		
		public BoundNode VisitMetamodelProperty(MetamodelPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.MetamodelUriProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MetamodelUriProperty))
				{
					this.Visit(node.MetamodelUriProperty, childBoundNodesForParent);
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
		
		public BoundNode VisitMetamodelUriProperty(MetamodelUriPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.StringLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.StringLiteral))
				{
					var childBoundNodesOfStringLiteral = ArrayBuilder<object>.GetInstance();
					this.Visit(node.StringLiteral, childBoundNodesOfStringLiteral);
					BoundNode boundStringLiteral;
					boundStringLiteral = this.CreateBoundValue(this.BoundTree, childBoundNodesOfStringLiteral.ToImmutableAndFree(), node.StringLiteral, false);
					childBoundNodes.Add(boundStringLiteral);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Uri", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitDeclaration(DeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.EnumDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumDeclaration))
				{
					this.Visit(node.EnumDeclaration, childBoundNodes);
				}
			}
			if (node.ClassDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassDeclaration))
				{
					this.Visit(node.ClassDeclaration, childBoundNodes);
				}
			}
			if (node.AssociationDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AssociationDeclaration))
				{
					this.Visit(node.AssociationDeclaration, childBoundNodes);
				}
			}
			if (node.ConstDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ConstDeclaration))
				{
					this.Visit(node.ConstDeclaration, childBoundNodes);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Declarations", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEnumDeclaration(EnumDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.EnumBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumBody))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaEnum), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEnumBody(EnumBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.EnumValues != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumValues))
				{
					var childBoundNodesOfEnumValues = ArrayBuilder<object>.GetInstance();
					this.Visit(node.EnumValues, childBoundNodesOfEnumValues);
					BoundNode boundEnumValues;
					boundEnumValues = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfEnumValues.ToImmutableAndFree(), "EnumLiterals", node.EnumValues, false);
					childBoundNodes.Add(boundEnumValues);
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEnumValues(EnumValuesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitEnumValue(EnumValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaEnumLiteral), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.OperationDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
				{
					var childBoundNodesOfOperationDeclaration = ArrayBuilder<object>.GetInstance();
					this.Visit(node.OperationDeclaration, childBoundNodesOfOperationDeclaration);
					BoundNode boundOperationDeclaration;
					boundOperationDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationDeclaration.ToImmutableAndFree(), "Operations", node.OperationDeclaration, false);
					childBoundNodesForParent.Add(boundOperationDeclaration);
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
		
		public BoundNode VisitClassDeclaration(ClassDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
			if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.KAbstract))
			{
				if (node.KAbstract.GetKind() == MetaSyntaxKind.KAbstract)
				{
					BoundNode boundKAbstract;
					boundKAbstract = this.CreateBoundProperty(this.BoundTree, ImmutableArray<object>.Empty, "IsAbstract", true, node, false);
					childBoundNodes.Add(boundKAbstract);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.ClassAncestors != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassAncestors))
				{
					var childBoundNodesOfClassAncestors = ArrayBuilder<object>.GetInstance();
					this.Visit(node.ClassAncestors, childBoundNodesOfClassAncestors);
					BoundNode boundClassAncestors;
					boundClassAncestors = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfClassAncestors.ToImmutableAndFree(), "SuperClasses", node.ClassAncestors, false);
					childBoundNodes.Add(boundClassAncestors);
				}
			}
			if (node.ClassBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassBody))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaClass), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitClassBody(ClassBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitClassAncestors(ClassAncestorsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitClassAncestor(ClassAncestorSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaClass)), node.Qualifier, false);
					childBoundNodesForParent.Add(boundQualifier);
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
		
		public BoundNode VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.FieldDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FieldDeclaration))
				{
					var childBoundNodesOfFieldDeclaration = ArrayBuilder<object>.GetInstance();
					this.Visit(node.FieldDeclaration, childBoundNodesOfFieldDeclaration);
					BoundNode boundFieldDeclaration;
					boundFieldDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfFieldDeclaration.ToImmutableAndFree(), "Properties", node.FieldDeclaration, false);
					childBoundNodesForParent.Add(boundFieldDeclaration);
				}
			}
			if (node.OperationDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
				{
					var childBoundNodesOfOperationDeclaration = ArrayBuilder<object>.GetInstance();
					this.Visit(node.OperationDeclaration, childBoundNodesOfOperationDeclaration);
					BoundNode boundOperationDeclaration;
					boundOperationDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationDeclaration.ToImmutableAndFree(), "Operations", node.OperationDeclaration, false);
					childBoundNodesForParent.Add(boundOperationDeclaration);
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
		
		public BoundNode VisitFieldDeclaration(FieldDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
			if (node.FieldModifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FieldModifier))
				{
					var childBoundNodesOfFieldModifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.FieldModifier, childBoundNodesOfFieldModifier);
					BoundNode boundFieldModifier;
					boundFieldModifier = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfFieldModifier.ToImmutableAndFree(), "Kind", node.FieldModifier, false);
					childBoundNodes.Add(boundFieldModifier);
				}
			}
			if (node.TypeReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference))
				{
					var childBoundNodesOfTypeReference = ArrayBuilder<object>.GetInstance();
					this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
					BoundNode boundTypeReference;
					boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), "Type", node.TypeReference, false);
					childBoundNodes.Add(boundTypeReference);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.RedefinitionsOrSubsettings != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.RedefinitionsOrSubsettings))
				{
					this.Visit(node.RedefinitionsOrSubsettings, childBoundNodes);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaProperty), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitFieldModifier(FieldModifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FieldModifier))
			{
				switch (node.FieldModifier.GetKind().Switch())
				{
					case MetaSyntaxKind.KContainment:
						BoundNode boundKContainment;
						boundKContainment = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaPropertyKind.Containment, node, false);
						childBoundNodesForParent.Add(boundKContainment);
						break;
					case MetaSyntaxKind.KReadonly:
						BoundNode boundKReadonly;
						boundKReadonly = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaPropertyKind.Readonly, node, false);
						childBoundNodesForParent.Add(boundKReadonly);
						break;
					case MetaSyntaxKind.KLazy:
						BoundNode boundKLazy;
						boundKLazy = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaPropertyKind.Lazy, node, false);
						childBoundNodesForParent.Add(boundKLazy);
						break;
					case MetaSyntaxKind.KDerived:
						BoundNode boundKDerived;
						boundKDerived = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaPropertyKind.Derived, node, false);
						childBoundNodesForParent.Add(boundKDerived);
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
		
		public BoundNode VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Redefinitions != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Redefinitions))
				{
					this.Visit(node.Redefinitions, childBoundNodesForParent);
				}
			}
			if (node.Subsettings != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Subsettings))
				{
					this.Visit(node.Subsettings, childBoundNodesForParent);
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
		
		public BoundNode VisitRedefinitions(RedefinitionsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.NameUseList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NameUseList))
				{
					var childBoundNodesOfNameUseList = ArrayBuilder<object>.GetInstance();
					this.Visit(node.NameUseList, childBoundNodesOfNameUseList);
					BoundNode boundNameUseList;
					boundNameUseList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNameUseList.ToImmutableAndFree(), "RedefinedProperties", node.NameUseList, false);
					childBoundNodesForParent.Add(boundNameUseList);
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
		
		public BoundNode VisitSubsettings(SubsettingsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.NameUseList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NameUseList))
				{
					var childBoundNodesOfNameUseList = ArrayBuilder<object>.GetInstance();
					this.Visit(node.NameUseList, childBoundNodesOfNameUseList);
					BoundNode boundNameUseList;
					boundNameUseList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNameUseList.ToImmutableAndFree(), "SubsettedProperties", node.NameUseList, false);
					childBoundNodesForParent.Add(boundNameUseList);
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
		
		public BoundNode VisitNameUseList(NameUseListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaProperty)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitConstDeclaration(ConstDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.TypeReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference))
				{
					var childBoundNodesOfTypeReference = ArrayBuilder<object>.GetInstance();
					this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
					BoundNode boundTypeReference;
					boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), "Type", node.TypeReference, false);
					childBoundNodes.Add(boundTypeReference);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaConstant), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitReturnType(ReturnTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.TypeReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference))
				{
					this.Visit(node.TypeReference, childBoundNodes);
				}
			}
			if (node.VoidType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VoidType))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitTypeOfReference(TypeOfReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.TypeReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitTypeReference(TypeReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.CollectionType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CollectionType))
				{
					this.Visit(node.CollectionType, childBoundNodes);
				}
			}
			if (node.SimpleType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SimpleType))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitSimpleType(SimpleTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.PrimitiveType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PrimitiveType))
				{
					this.Visit(node.PrimitiveType, childBoundNodes);
				}
			}
			if (node.ObjectType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ObjectType))
				{
					this.Visit(node.ObjectType, childBoundNodes);
				}
			}
			if (node.NullableType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NullableType))
				{
					this.Visit(node.NullableType, childBoundNodes);
				}
			}
			if (node.ClassType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassType))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitClassType(ClassTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaClass), typeof(Symbols.MetaEnum)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitObjectType(ObjectTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitPrimitiveType(PrimitiveTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitVoidType(VoidTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNullableType(NullableTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.PrimitiveType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PrimitiveType))
				{
					var childBoundNodesOfPrimitiveType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.PrimitiveType, childBoundNodesOfPrimitiveType);
					BoundNode boundPrimitiveType;
					boundPrimitiveType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfPrimitiveType.ToImmutableAndFree(), "InnerType", node.PrimitiveType, false);
					childBoundNodes.Add(boundPrimitiveType);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaNullableType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitCollectionType(CollectionTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.CollectionKind != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CollectionKind))
				{
					var childBoundNodesOfCollectionKind = ArrayBuilder<object>.GetInstance();
					this.Visit(node.CollectionKind, childBoundNodesOfCollectionKind);
					BoundNode boundCollectionKind;
					boundCollectionKind = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfCollectionKind.ToImmutableAndFree(), "Kind", node.CollectionKind, false);
					childBoundNodes.Add(boundCollectionKind);
				}
			}
			if (node.SimpleType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SimpleType))
				{
					var childBoundNodesOfSimpleType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.SimpleType, childBoundNodesOfSimpleType);
					BoundNode boundSimpleType;
					boundSimpleType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSimpleType.ToImmutableAndFree(), "InnerType", node.SimpleType, false);
					childBoundNodes.Add(boundSimpleType);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaCollectionType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitCollectionKind(CollectionKindSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CollectionKind))
			{
				switch (node.CollectionKind.GetKind().Switch())
				{
					case MetaSyntaxKind.KSet:
						BoundNode boundKSet;
						boundKSet = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaCollectionKind.Set, node, false);
						childBoundNodesForParent.Add(boundKSet);
						break;
					case MetaSyntaxKind.KList:
						BoundNode boundKList;
						boundKList = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaCollectionKind.List, node, false);
						childBoundNodesForParent.Add(boundKList);
						break;
					case MetaSyntaxKind.KMultiSet:
						BoundNode boundKMultiSet;
						boundKMultiSet = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaCollectionKind.MultiSet, node, false);
						childBoundNodesForParent.Add(boundKMultiSet);
						break;
					case MetaSyntaxKind.KMultiList:
						BoundNode boundKMultiList;
						boundKMultiList = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, MetaCollectionKind.MultiList, node, false);
						childBoundNodesForParent.Add(boundKMultiList);
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
		
		public BoundNode VisitOperationDeclaration(OperationDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ReturnType))
				{
					var childBoundNodesOfReturnType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.ReturnType, childBoundNodesOfReturnType);
					BoundNode boundReturnType;
					boundReturnType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfReturnType.ToImmutableAndFree(), "ReturnType", node.ReturnType, false);
					childBoundNodes.Add(boundReturnType);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.ParameterList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ParameterList))
				{
					var childBoundNodesOfParameterList = ArrayBuilder<object>.GetInstance();
					this.Visit(node.ParameterList, childBoundNodesOfParameterList);
					BoundNode boundParameterList;
					boundParameterList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfParameterList.ToImmutableAndFree(), "Parameters", node.ParameterList, false);
					childBoundNodes.Add(boundParameterList);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaOperation), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitParameterList(ParameterListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitParameter(ParameterSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference))
				{
					var childBoundNodesOfTypeReference = ArrayBuilder<object>.GetInstance();
					this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
					BoundNode boundTypeReference;
					boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), "Type", node.TypeReference, false);
					childBoundNodes.Add(boundTypeReference);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaParameter), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitAssociationDeclaration(AssociationDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
			if (node.Source != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Source))
				{
					var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Source, childBoundNodesOfSource);
					BoundNode boundSource;
					boundSource = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaProperty)), node.Source, false);
					childBoundNodes.Add(boundSource);
				}
			}
			if (node.Target != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Target))
				{
					var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Target, childBoundNodesOfTarget);
					BoundNode boundTarget;
					boundTarget = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaProperty)), node.Target, false);
					childBoundNodes.Add(boundTarget);
				}
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundOpposite(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitIdentifier(IdentifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitLiteral(LiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.NullLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NullLiteral))
				{
					this.Visit(node.NullLiteral, childBoundNodesForParent);
				}
			}
			if (node.BooleanLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
				{
					this.Visit(node.BooleanLiteral, childBoundNodesForParent);
				}
			}
			if (node.IntegerLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.IntegerLiteral))
				{
					this.Visit(node.IntegerLiteral, childBoundNodesForParent);
				}
			}
			if (node.DecimalLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DecimalLiteral))
				{
					this.Visit(node.DecimalLiteral, childBoundNodesForParent);
				}
			}
			if (node.ScientificLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ScientificLiteral))
				{
					this.Visit(node.ScientificLiteral, childBoundNodesForParent);
				}
			}
			if (node.StringLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.StringLiteral))
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
		
		public BoundNode VisitNullLiteral(NullLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitBooleanLiteral(BooleanLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitIntegerLiteral(IntegerLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitDecimalLiteral(DecimalLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitScientificLiteral(ScientificLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitStringLiteral(StringLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			if (this.State != BoundNodeFactoryState.InParent && this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (this.State == BoundNodeFactoryState.InChild)
			{
				childBoundNodesForParent.Add(node);
				return null;
			}
			var childBoundNodes = ArrayBuilder<object>.GetInstance();
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
				if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
				else return null;
			}
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
    }
}


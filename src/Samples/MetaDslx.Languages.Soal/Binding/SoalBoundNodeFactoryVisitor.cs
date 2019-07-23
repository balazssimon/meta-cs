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
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal.Binding
{
	// Make sure to keep this in sync with SoalIsBindableNodeVisitor
    public class SoalBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, ISoalSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public SoalBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		
		public BoundNode VisitMain(MainSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.NamespaceDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration.Node))
				{
					foreach (var item in node.NamespaceDeclaration)
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
		
		public BoundNode VisitIdentifierList(IdentifierListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
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
		
		public BoundNode VisitQualifierList(QualifierListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
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
		
		public BoundNode VisitAnnotationList(AnnotationListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Annotation != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Annotation.Node))
				{
					foreach (var item in node.Annotation)
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
		
		public BoundNode VisitReturnAnnotationList(ReturnAnnotationListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ReturnAnnotation != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ReturnAnnotation.Node))
				{
					foreach (var item in node.ReturnAnnotation)
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
		
		public BoundNode VisitAnnotation(AnnotationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationHead != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationHead))
				{
					this.Visit(node.AnnotationHead, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Annotation), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Annotations", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitReturnAnnotation(ReturnAnnotationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationHead != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationHead))
				{
					this.Visit(node.AnnotationHead, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Annotation), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Annotations", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitAnnotationHead(AnnotationHeadSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodesForParent);
				}
			}
			if (node.AnnotationBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationBody))
				{
					this.Visit(node.AnnotationBody, childBoundNodesForParent);
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
		
		public BoundNode VisitAnnotationBody(AnnotationBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationPropertyList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationPropertyList))
				{
					this.Visit(node.AnnotationPropertyList, childBoundNodes);
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
		
		public BoundNode VisitAnnotationPropertyList(AnnotationPropertyListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.AnnotationProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationProperty.Node))
				{
					foreach (var item in node.AnnotationProperty)
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
		
		public BoundNode VisitAnnotationProperty(AnnotationPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.AnnotationPropertyValue != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationPropertyValue))
				{
					var childBoundNodesOfAnnotationPropertyValue = ArrayBuilder<object>.GetInstance();
					this.Visit(node.AnnotationPropertyValue, childBoundNodesOfAnnotationPropertyValue);
					BoundNode boundAnnotationPropertyValue;
					boundAnnotationPropertyValue = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfAnnotationPropertyValue.ToImmutableAndFree(), "Value", node.AnnotationPropertyValue, false);
					childBoundNodes.Add(boundAnnotationPropertyValue);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.AnnotationProperty), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Properties", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ConstantValue != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ConstantValue))
				{
					this.Visit(node.ConstantValue, childBoundNodesForParent);
				}
			}
			if (node.TypeofValue != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeofValue))
				{
					this.Visit(node.TypeofValue, childBoundNodesForParent);
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
				}
			}
			if (node.QualifiedName != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QualifiedName))
				{
					this.Visit(node.QualifiedName, childBoundNodes);
				}
			}
			if (node.NamespacePrefix != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespacePrefix))
				{
					this.Visit(node.NamespacePrefix, childBoundNodes);
				}
			}
			if (node.NamespaceUri != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceUri))
				{
					this.Visit(node.NamespaceUri, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Namespace), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNamespacePrefix(NamespacePrefixSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Identifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier))
				{
					var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Identifier, childBoundNodesOfIdentifier);
					BoundNode boundIdentifier;
					boundIdentifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), node.Identifier, false);
					boundIdentifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundIdentifier), "Prefix", node.Identifier, false);
					childBoundNodesForParent.Add(boundIdentifier);
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
		
		public BoundNode VisitNamespaceUri(NamespaceUriSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
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
					boundStringLiteral = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundStringLiteral), "Uri", node.StringLiteral, false);
					childBoundNodesForParent.Add(boundStringLiteral);
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
			if (node.StructDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.StructDeclaration))
				{
					this.Visit(node.StructDeclaration, childBoundNodes);
				}
			}
			if (node.DatabaseDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DatabaseDeclaration))
				{
					this.Visit(node.DatabaseDeclaration, childBoundNodes);
				}
			}
			if (node.InterfaceDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.InterfaceDeclaration))
				{
					this.Visit(node.InterfaceDeclaration, childBoundNodes);
				}
			}
			if (node.ComponentDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentDeclaration))
				{
					this.Visit(node.ComponentDeclaration, childBoundNodes);
				}
			}
			if (node.CompositeDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeDeclaration))
				{
					this.Visit(node.CompositeDeclaration, childBoundNodes);
				}
			}
			if (node.AssemblyDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AssemblyDeclaration))
				{
					this.Visit(node.AssemblyDeclaration, childBoundNodes);
				}
			}
			if (node.BindingDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BindingDeclaration))
				{
					this.Visit(node.BindingDeclaration, childBoundNodes);
				}
			}
			if (node.EndpointDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointDeclaration))
				{
					this.Visit(node.EndpointDeclaration, childBoundNodes);
				}
			}
			if (node.DeploymentDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DeploymentDeclaration))
				{
					this.Visit(node.DeploymentDeclaration, childBoundNodes);
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Enum)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "BaseType", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Enum), node, false);
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
			if (node.EnumLiterals != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumLiterals))
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
			else // InNode
			{
				BoundNode resultNode;
				resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEnumLiterals(EnumLiteralsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.EnumLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumLiteral.Node))
				{
					foreach (var item in node.EnumLiteral)
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
		
		public BoundNode VisitEnumLiteral(EnumLiteralSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.EnumLiteral), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "EnumLiterals", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitStructDeclaration(StructDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Struct)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "BaseType", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.StructBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.StructBody))
				{
					this.Visit(node.StructBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Struct), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitStructBody(StructBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.PropertyDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PropertyDeclaration.Node))
				{
					foreach (var item in node.PropertyDeclaration)
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
		
		public BoundNode VisitPropertyDeclaration(PropertyDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Property), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Properties", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitDatabaseDeclaration(DatabaseDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.DatabaseBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DatabaseBody))
				{
					this.Visit(node.DatabaseBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Database), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitDatabaseBody(DatabaseBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.EntityReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EntityReference.Node))
				{
					foreach (var item in node.EntityReference)
					{
						if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
						{
							this.Visit(item, childBoundNodes);
						}
					}
				}
			}
			if (node.OperationDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationDeclaration.Node))
				{
					foreach (var item in node.OperationDeclaration)
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
		
		public BoundNode VisitEntityReference(EntityReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Struct)), node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Entities", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.InterfaceBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.InterfaceBody))
				{
					this.Visit(node.InterfaceBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Interface), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitInterfaceBody(InterfaceBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.OperationDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationDeclaration.Node))
				{
					foreach (var item in node.OperationDeclaration)
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
			if (node.OperationHead != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationHead))
				{
					this.Visit(node.OperationHead, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Operation), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Operations", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitOperationHead(OperationHeadSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodesForParent);
				}
			}
			if (node.OperationResult != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationResult))
				{
					this.Visit(node.OperationResult, childBoundNodesForParent);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodesForParent);
				}
			}
			if (node.ParameterList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ParameterList))
				{
					this.Visit(node.ParameterList, childBoundNodesForParent);
				}
			}
			if (node.ThrowsList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ThrowsList))
				{
					this.Visit(node.ThrowsList, childBoundNodesForParent);
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
			if (node.AnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationList))
				{
					this.Visit(node.AnnotationList, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.InputParameter), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Parameters", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitOperationResult(OperationResultSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.ReturnAnnotationList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ReturnAnnotationList))
				{
					this.Visit(node.ReturnAnnotationList, childBoundNodes);
				}
			}
			if (node.OperationReturnType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationReturnType))
				{
					var childBoundNodesOfOperationReturnType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.OperationReturnType, childBoundNodesOfOperationReturnType);
					BoundNode boundOperationReturnType;
					boundOperationReturnType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationReturnType.ToImmutableAndFree(), "Type", node.OperationReturnType, false);
					childBoundNodes.Add(boundOperationReturnType);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.OutputParameter), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Result", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitThrowsList(ThrowsListSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.QualifierList != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QualifierList))
				{
					var childBoundNodesOfQualifierList = ArrayBuilder<object>.GetInstance();
					this.Visit(node.QualifierList, childBoundNodesOfQualifierList);
					BoundNode boundQualifierList;
					boundQualifierList = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifierList.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Struct)), node.QualifierList, false);
					boundQualifierList = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifierList), "Exceptions", node.QualifierList, false);
					childBoundNodesForParent.Add(boundQualifierList);
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
		
		public BoundNode VisitComponentDeclaration(ComponentDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.KAbstract))
			{
				if (node.KAbstract.GetKind() == SoalSyntaxKind.KAbstract)
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
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Component)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "BaseComponent", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.ComponentBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentBody))
				{
					this.Visit(node.ComponentBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Component), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitComponentBody(ComponentBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.ComponentElements != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentElements))
				{
					this.Visit(node.ComponentElements, childBoundNodes);
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
		
		public BoundNode VisitComponentElements(ComponentElementsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ComponentElement != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentElement.Node))
				{
					foreach (var item in node.ComponentElement)
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
		
		public BoundNode VisitComponentElement(ComponentElementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ComponentService != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentService))
				{
					this.Visit(node.ComponentService, childBoundNodesForParent);
				}
			}
			if (node.ComponentReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentReference))
				{
					this.Visit(node.ComponentReference, childBoundNodesForParent);
				}
			}
			if (node.ComponentProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentProperty))
				{
					this.Visit(node.ComponentProperty, childBoundNodesForParent);
				}
			}
			if (node.ComponentImplementation != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentImplementation))
				{
					this.Visit(node.ComponentImplementation, childBoundNodesForParent);
				}
			}
			if (node.ComponentLanguage != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentLanguage))
				{
					this.Visit(node.ComponentLanguage, childBoundNodesForParent);
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
		
		public BoundNode VisitComponentService(ComponentServiceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Interface)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Interface", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.ComponentServiceOrReferenceBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceBody))
				{
					this.Visit(node.ComponentServiceOrReferenceBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Service), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Services", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitComponentReference(ComponentReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Interface)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Interface", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.ComponentServiceOrReferenceBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceBody))
				{
					this.Visit(node.ComponentServiceOrReferenceBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Reference), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "References", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ComponentServiceOrReferenceElement != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceElement.Node))
				{
					foreach (var item in node.ComponentServiceOrReferenceElement)
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
		
		public BoundNode VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Binding)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Binding", node.Qualifier, false);
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
		
		public BoundNode VisitComponentProperty(ComponentPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Property), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Properties", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitComponentImplementation(ComponentImplementationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Implementation), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Implementation", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitComponentLanguage(ComponentLanguageSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.ProgrammingLanguage), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "ProgrammingLanguage", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitCompositeDeclaration(CompositeDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Component)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "BaseComponent", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.CompositeBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeBody))
				{
					this.Visit(node.CompositeBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Composite), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitCompositeBody(CompositeBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.CompositeElements != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeElements))
				{
					this.Visit(node.CompositeElements, childBoundNodes);
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
		
		public BoundNode VisitAssemblyDeclaration(AssemblyDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Component)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "BaseComponent", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.CompositeBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeBody))
				{
					this.Visit(node.CompositeBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Assembly), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitCompositeElements(CompositeElementsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.CompositeElement != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeElement.Node))
				{
					foreach (var item in node.CompositeElement)
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
		
		public BoundNode VisitCompositeElement(CompositeElementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ComponentService != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentService))
				{
					this.Visit(node.ComponentService, childBoundNodesForParent);
				}
			}
			if (node.ComponentReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentReference))
				{
					this.Visit(node.ComponentReference, childBoundNodesForParent);
				}
			}
			if (node.ComponentProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentProperty))
				{
					this.Visit(node.ComponentProperty, childBoundNodesForParent);
				}
			}
			if (node.ComponentImplementation != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentImplementation))
				{
					this.Visit(node.ComponentImplementation, childBoundNodesForParent);
				}
			}
			if (node.ComponentLanguage != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentLanguage))
				{
					this.Visit(node.ComponentLanguage, childBoundNodesForParent);
				}
			}
			if (node.CompositeComponent != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeComponent))
				{
					this.Visit(node.CompositeComponent, childBoundNodesForParent);
				}
			}
			if (node.CompositeWire != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeWire))
				{
					this.Visit(node.CompositeWire, childBoundNodesForParent);
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
		
		public BoundNode VisitCompositeComponent(CompositeComponentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Component)), node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Components", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitCompositeWire(CompositeWireSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.WireSource != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.WireSource))
				{
					this.Visit(node.WireSource, childBoundNodes);
				}
			}
			if (node.WireTarget != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.WireTarget))
				{
					this.Visit(node.WireTarget, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Wire), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Wires", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitWireSource(WireSourceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Port)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Source", node.Qualifier, false);
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
		
		public BoundNode VisitWireTarget(WireTargetSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Port)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Target", node.Qualifier, false);
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
		
		public BoundNode VisitDeploymentDeclaration(DeploymentDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.DeploymentBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DeploymentBody))
				{
					this.Visit(node.DeploymentBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Deployment), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitDeploymentBody(DeploymentBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.DeploymentElements != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DeploymentElements))
				{
					this.Visit(node.DeploymentElements, childBoundNodes);
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
		
		public BoundNode VisitDeploymentElements(DeploymentElementsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.DeploymentElement != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DeploymentElement.Node))
				{
					foreach (var item in node.DeploymentElement)
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
		
		public BoundNode VisitDeploymentElement(DeploymentElementSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.EnvironmentDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnvironmentDeclaration))
				{
					this.Visit(node.EnvironmentDeclaration, childBoundNodesForParent);
				}
			}
			if (node.CompositeWire != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeWire))
				{
					this.Visit(node.CompositeWire, childBoundNodesForParent);
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
		
		public BoundNode VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.EnvironmentBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnvironmentBody))
				{
					this.Visit(node.EnvironmentBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Environment), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Environments", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEnvironmentBody(EnvironmentBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.RuntimeDeclaration != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.RuntimeDeclaration))
				{
					this.Visit(node.RuntimeDeclaration, childBoundNodes);
				}
			}
			if (node.RuntimeReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.RuntimeReference.Node))
				{
					foreach (var item in node.RuntimeReference)
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
		
		public BoundNode VisitRuntimeDeclaration(RuntimeDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Runtime), node, false);
				resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), "Runtime", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitRuntimeReference(RuntimeReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.AssemblyReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AssemblyReference))
				{
					this.Visit(node.AssemblyReference, childBoundNodesForParent);
				}
			}
			if (node.DatabaseReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DatabaseReference))
				{
					this.Visit(node.DatabaseReference, childBoundNodesForParent);
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
		
		public BoundNode VisitAssemblyReference(AssemblyReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Assembly)), node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Assemblies", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitDatabaseReference(DatabaseReferenceSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Database)), node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Databases", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitBindingDeclaration(BindingDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.BindingBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BindingBody))
				{
					this.Visit(node.BindingBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Binding), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitBindingBody(BindingBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.BindingLayers != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BindingLayers))
				{
					this.Visit(node.BindingLayers, childBoundNodes);
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
		
		public BoundNode VisitBindingLayers(BindingLayersSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.TransportLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TransportLayer))
				{
					this.Visit(node.TransportLayer, childBoundNodesForParent);
				}
			}
			if (node.EncodingLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EncodingLayer.Node))
				{
					foreach (var item in node.EncodingLayer)
					{
						if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
						{
							this.Visit(item, childBoundNodesForParent);
						}
					}
				}
			}
			if (node.ProtocolLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ProtocolLayer.Node))
				{
					foreach (var item in node.ProtocolLayer)
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
		
		public BoundNode VisitTransportLayer(TransportLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.HttpTransportLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.HttpTransportLayer))
				{
					this.Visit(node.HttpTransportLayer, childBoundNodes);
				}
			}
			if (node.RestTransportLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.RestTransportLayer))
				{
					this.Visit(node.RestTransportLayer, childBoundNodes);
				}
			}
			if (node.WebSocketTransportLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.WebSocketTransportLayer))
				{
					this.Visit(node.WebSocketTransportLayer, childBoundNodes);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Transport", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitHttpTransportLayer(HttpTransportLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.HttpTransportLayerBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.HttpTransportLayerBody))
				{
					this.Visit(node.HttpTransportLayerBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.HttpTransportBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.HttpTransportLayerProperties != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.HttpTransportLayerProperties.Node))
				{
					foreach (var item in node.HttpTransportLayerProperties)
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
		
		public BoundNode VisitRestTransportLayer(RestTransportLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.RestTransportLayerBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.RestTransportLayerBody))
				{
					this.Visit(node.RestTransportLayerBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.RestTransportBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.WebSocketTransportLayerBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.WebSocketTransportLayerBody))
				{
					this.Visit(node.WebSocketTransportLayerBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.WebSocketTransportBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.HttpSslProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.HttpSslProperty))
				{
					this.Visit(node.HttpSslProperty, childBoundNodesForParent);
				}
			}
			if (node.HttpClientAuthenticationProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.HttpClientAuthenticationProperty))
				{
					this.Visit(node.HttpClientAuthenticationProperty, childBoundNodesForParent);
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
		
		public BoundNode VisitHttpSslProperty(HttpSslPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.BooleanLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
				{
					this.Visit(node.BooleanLiteral, childBoundNodes);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Ssl", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.BooleanLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
				{
					this.Visit(node.BooleanLiteral, childBoundNodes);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "ClientAuthentication", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEncodingLayer(EncodingLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.SoapEncodingLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapEncodingLayer))
				{
					this.Visit(node.SoapEncodingLayer, childBoundNodes);
				}
			}
			if (node.XmlEncodingLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.XmlEncodingLayer))
				{
					this.Visit(node.XmlEncodingLayer, childBoundNodes);
				}
			}
			if (node.JsonEncodingLayer != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.JsonEncodingLayer))
				{
					this.Visit(node.JsonEncodingLayer, childBoundNodes);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Encodings", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitSoapEncodingLayer(SoapEncodingLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.SoapEncodingLayerBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapEncodingLayerBody))
				{
					this.Visit(node.SoapEncodingLayerBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.SoapEncodingBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.SoapEncodingProperties != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapEncodingProperties.Node))
				{
					foreach (var item in node.SoapEncodingProperties)
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
		
		public BoundNode VisitXmlEncodingLayer(XmlEncodingLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.XmlEncodingLayerBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.XmlEncodingLayerBody))
				{
					this.Visit(node.XmlEncodingLayerBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.XmlEncodingBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitJsonEncodingLayer(JsonEncodingLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.JsonEncodingLayerBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.JsonEncodingLayerBody))
				{
					this.Visit(node.JsonEncodingLayerBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.JsonEncodingBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.SoapVersionProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapVersionProperty))
				{
					this.Visit(node.SoapVersionProperty, childBoundNodesForParent);
				}
			}
			if (node.SoapMtomProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapMtomProperty))
				{
					this.Visit(node.SoapMtomProperty, childBoundNodesForParent);
				}
			}
			if (node.SoapStyleProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapStyleProperty))
				{
					this.Visit(node.SoapStyleProperty, childBoundNodesForParent);
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
		
		public BoundNode VisitSoapVersionProperty(SoapVersionPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Identifier, childBoundNodesOfIdentifier);
					BoundNode boundIdentifier;
					boundIdentifier = this.CreateBoundEnumValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), typeof(Symbols.SoapVersion), node.Identifier, false);
					childBoundNodes.Add(boundIdentifier);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Version", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitSoapMtomProperty(SoapMtomPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.BooleanLiteral != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
				{
					this.Visit(node.BooleanLiteral, childBoundNodes);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Mtom", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitSoapStyleProperty(SoapStylePropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					var childBoundNodesOfIdentifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Identifier, childBoundNodesOfIdentifier);
					BoundNode boundIdentifier;
					boundIdentifier = this.CreateBoundEnumValue(this.BoundTree, childBoundNodesOfIdentifier.ToImmutableAndFree(), typeof(Symbols.SoapEncodingStyle), node.Identifier, false);
					childBoundNodes.Add(boundIdentifier);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Style", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitProtocolLayer(ProtocolLayerSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.ProtocolLayerKind != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ProtocolLayerKind))
				{
					this.Visit(node.ProtocolLayerKind, childBoundNodes);
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
				resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Protocols", node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitProtocolLayerKind(ProtocolLayerKindSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.WsAddressing != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.WsAddressing))
				{
					this.Visit(node.WsAddressing, childBoundNodesForParent);
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
		
		public BoundNode VisitWsAddressing(WsAddressingSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.WsAddressingBindingElement), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEndpointDeclaration(EndpointDeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.Name != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Name))
				{
					this.Visit(node.Name, childBoundNodes);
				}
			}
			if (node.Qualifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier))
				{
					var childBoundNodesOfQualifier = ArrayBuilder<object>.GetInstance();
					this.Visit(node.Qualifier, childBoundNodesOfQualifier);
					BoundNode boundQualifier;
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Interface)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Interface", node.Qualifier, false);
					childBoundNodes.Add(boundQualifier);
				}
			}
			if (node.EndpointBody != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointBody))
				{
					this.Visit(node.EndpointBody, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.Endpoint), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitEndpointBody(EndpointBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.EndpointProperties != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointProperties))
				{
					this.Visit(node.EndpointProperties, childBoundNodes);
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
		
		public BoundNode VisitEndpointProperties(EndpointPropertiesSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.EndpointProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointProperty.Node))
				{
					foreach (var item in node.EndpointProperty)
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
		
		public BoundNode VisitEndpointProperty(EndpointPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.EndpointBindingProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointBindingProperty))
				{
					this.Visit(node.EndpointBindingProperty, childBoundNodesForParent);
				}
			}
			if (node.EndpointAddressProperty != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointAddressProperty))
				{
					this.Visit(node.EndpointAddressProperty, childBoundNodesForParent);
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
		
		public BoundNode VisitEndpointBindingProperty(EndpointBindingPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
					boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.Binding)), node.Qualifier, false);
					boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundQualifier), "Binding", node.Qualifier, false);
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
		
		public BoundNode VisitEndpointAddressProperty(EndpointAddressPropertySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
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
					boundStringLiteral = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfStringLiteral.ToImmutableAndFree(), "Address", node.StringLiteral, false);
					childBoundNodesForParent.Add(boundStringLiteral);
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
			if (node.VoidType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VoidType))
				{
					this.Visit(node.VoidType, childBoundNodes);
				}
			}
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
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
			if (node.NonNullableArrayType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NonNullableArrayType))
				{
					this.Visit(node.NonNullableArrayType, childBoundNodes);
				}
			}
			if (node.ArrayType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ArrayType))
				{
					this.Visit(node.ArrayType, childBoundNodes);
				}
			}
			if (node.SimpleType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SimpleType))
				{
					this.Visit(node.SimpleType, childBoundNodes);
				}
			}
			if (node.NulledType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NulledType))
				{
					this.Visit(node.NulledType, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
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
			if (node.ValueType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ValueType))
				{
					this.Visit(node.ValueType, childBoundNodes);
				}
			}
			if (node.ObjectType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ObjectType))
				{
					this.Visit(node.ObjectType, childBoundNodes);
				}
			}
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNulledType(NulledTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.NullableType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NullableType))
				{
					this.Visit(node.NullableType, childBoundNodes);
				}
			}
			if (node.NonNullableType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NonNullableType))
				{
					this.Visit(node.NonNullableType, childBoundNodes);
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitReferenceType(ReferenceTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.ObjectType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ObjectType))
				{
					this.Visit(node.ObjectType, childBoundNodes);
				}
			}
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, ImmutableArray.Create<object>(resultNode), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitValueType(ValueTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, ImmutableArray.Create<object>(resultNode), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, ImmutableArray.Create<object>(resultNode), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitOnewayType(OnewayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolUse(this.BoundTree, ImmutableArray.Create<object>(resultNode), ImmutableArray.Create(typeof(Symbols.SoalType)), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitOperationReturnType(OperationReturnTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.OnewayType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OnewayType))
				{
					var childBoundNodesOfOnewayType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.OnewayType, childBoundNodesOfOnewayType);
					BoundNode boundOnewayType;
					boundOnewayType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOnewayType.ToImmutableAndFree(), "IsOneway", true, node.OnewayType, false);
					childBoundNodesForParent.Add(boundOnewayType);
				}
			}
			if (node.VoidType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VoidType))
				{
					this.Visit(node.VoidType, childBoundNodesForParent);
				}
			}
			if (node.TypeReference != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference))
				{
					this.Visit(node.TypeReference, childBoundNodesForParent);
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
			if (node.ValueType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ValueType))
				{
					var childBoundNodesOfValueType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.ValueType, childBoundNodesOfValueType);
					BoundNode boundValueType;
					boundValueType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfValueType.ToImmutableAndFree(), "InnerType", node.ValueType, false);
					childBoundNodes.Add(boundValueType);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.NullableType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNonNullableType(NonNullableTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.ReferenceType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ReferenceType))
				{
					var childBoundNodesOfReferenceType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.ReferenceType, childBoundNodesOfReferenceType);
					BoundNode boundReferenceType;
					boundReferenceType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfReferenceType.ToImmutableAndFree(), "InnerType", node.ReferenceType, false);
					childBoundNodes.Add(boundReferenceType);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.NonNullableType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNonNullableArrayType(NonNullableArrayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.ArrayType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ArrayType))
				{
					var childBoundNodesOfArrayType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.ArrayType, childBoundNodesOfArrayType);
					BoundNode boundArrayType;
					boundArrayType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfArrayType.ToImmutableAndFree(), "InnerType", node.ArrayType, false);
					childBoundNodes.Add(boundArrayType);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.NonNullableType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitArrayType(ArrayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.SimpleArrayType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SimpleArrayType))
				{
					this.Visit(node.SimpleArrayType, childBoundNodesForParent);
				}
			}
			if (node.NulledArrayType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NulledArrayType))
				{
					this.Visit(node.NulledArrayType, childBoundNodesForParent);
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
		
		public BoundNode VisitSimpleArrayType(SimpleArrayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.ArrayType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitNulledArrayType(NulledArrayTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
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
			if (node.NulledType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NulledType))
				{
					var childBoundNodesOfNulledType = ArrayBuilder<object>.GetInstance();
					this.Visit(node.NulledType, childBoundNodesOfNulledType);
					BoundNode boundNulledType;
					boundNulledType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNulledType.ToImmutableAndFree(), "InnerType", node.NulledType, false);
					childBoundNodes.Add(boundNulledType);
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
				resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.ArrayType), node, false);
				childBoundNodesForParent.Add(resultNode); 
				return resultNode;
			}
		}
		
		public BoundNode VisitConstantValue(ConstantValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.Literal != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Literal))
				{
					this.Visit(node.Literal, childBoundNodesForParent);
				}
			}
			if (node.Identifier != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier))
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
		
		public BoundNode VisitTypeofValue(TypeofValueSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (node.ReturnType != null)
			{
				if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ReturnType))
				{
					this.Visit(node.ReturnType, childBoundNodesForParent);
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
		
		public BoundNode VisitIdentifiers(IdentifiersSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
		
		public BoundNode VisitContextualKeywords(ContextualKeywordsSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
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
    }
}


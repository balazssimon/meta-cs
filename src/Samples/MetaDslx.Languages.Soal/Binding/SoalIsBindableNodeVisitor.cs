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
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal.Binding
{
	// Make sure to keep this in sync with SoalBoundNodeFactoryVisitor
    public class SoalIsBindableNodeVisitor : IsBindableNodeVisitor, ISoalSyntaxVisitor<bool>
    {
        public SoalIsBindableNodeVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		
		public bool VisitMain(MainSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration.Node))
					{
						foreach (var item in node.NamespaceDeclaration)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitName(NameSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							if (this.Visit(node.Identifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQualifiedName(QualifiedNameSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							if (this.Visit(node.Qualifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQualifier(QualifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Identifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIdentifierList(IdentifierListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Identifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQualifierList(QualifierListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier.Node))
					{
						foreach (var item in node.Qualifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotationList(AnnotationListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Annotation != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Annotation.Node))
					{
						foreach (var item in node.Annotation)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ReturnAnnotation != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ReturnAnnotation.Node))
					{
						foreach (var item in node.ReturnAnnotation)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotation(AnnotationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationHead != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationHead))
						{
							if (this.Visit(node.AnnotationHead)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationHead)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationHead != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationHead))
						{
							if (this.Visit(node.AnnotationHead)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationHead)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.AnnotationBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationBody))
						{
							if (this.Visit(node.AnnotationBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotationBody(AnnotationBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.AnnotationPropertyList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationPropertyList))
						{
							if (this.Visit(node.AnnotationPropertyList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationPropertyList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.AnnotationProperty != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.AnnotationProperty.Node))
					{
						foreach (var item in node.AnnotationProperty)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.AnnotationPropertyValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationPropertyValue))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationPropertyValue)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ConstantValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConstantValue))
						{
							if (this.Visit(node.ConstantValue)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ConstantValue)) return true;
					}
				}
				if (node.TypeofValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeofValue))
						{
							if (this.Visit(node.TypeofValue)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeofValue)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespacePrefix != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespacePrefix))
						{
							if (this.Visit(node.NamespacePrefix)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespacePrefix)) return true;
					}
				}
				if (node.NamespaceUri != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceUri))
						{
							if (this.Visit(node.NamespaceUri)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceUri)) return true;
					}
				}
				if (node.NamespaceBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody))
						{
							if (this.Visit(node.NamespaceBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespacePrefix(NamespacePrefixSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceUri(NamespaceUriSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.StringLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody(NamespaceBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration.Node))
					{
						foreach (var item in node.Declaration)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration(DeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.EnumDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumDeclaration))
						{
							if (this.Visit(node.EnumDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumDeclaration)) return true;
					}
				}
				if (node.StructDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StructDeclaration))
						{
							if (this.Visit(node.StructDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.StructDeclaration)) return true;
					}
				}
				if (node.DatabaseDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DatabaseDeclaration))
						{
							if (this.Visit(node.DatabaseDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DatabaseDeclaration)) return true;
					}
				}
				if (node.InterfaceDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.InterfaceDeclaration))
						{
							if (this.Visit(node.InterfaceDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.InterfaceDeclaration)) return true;
					}
				}
				if (node.ComponentDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentDeclaration))
						{
							if (this.Visit(node.ComponentDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentDeclaration)) return true;
					}
				}
				if (node.CompositeDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeDeclaration))
						{
							if (this.Visit(node.CompositeDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeDeclaration)) return true;
					}
				}
				if (node.AssemblyDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AssemblyDeclaration))
						{
							if (this.Visit(node.AssemblyDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AssemblyDeclaration)) return true;
					}
				}
				if (node.BindingDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BindingDeclaration))
						{
							if (this.Visit(node.BindingDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BindingDeclaration)) return true;
					}
				}
				if (node.EndpointDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndpointDeclaration))
						{
							if (this.Visit(node.EndpointDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndpointDeclaration)) return true;
					}
				}
				if (node.DeploymentDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DeploymentDeclaration))
						{
							if (this.Visit(node.DeploymentDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DeploymentDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.EnumBase != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumBase))
						{
							if (this.Visit(node.EnumBase)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumBase)) return true;
					}
				}
				if (node.EnumBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumBody))
						{
							if (this.Visit(node.EnumBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumBase(EnumBaseSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumBody(EnumBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.EnumLiterals != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumLiterals))
						{
							if (this.Visit(node.EnumLiterals)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumLiterals)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.EnumLiteral != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumLiteral.Node))
					{
						foreach (var item in node.EnumLiteral)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumLiteral(EnumLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitStructDeclaration(StructDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				if (node.StructBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StructBody))
						{
							if (this.Visit(node.StructBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.StructBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitStructBody(StructBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.PropertyDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PropertyDeclaration.Node))
					{
						foreach (var item in node.PropertyDeclaration)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.DatabaseBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DatabaseBody))
						{
							if (this.Visit(node.DatabaseBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DatabaseBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDatabaseBody(DatabaseBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.EntityReference != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EntityReference.Node))
					{
						foreach (var item in node.EntityReference)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
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
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEntityReference(EntityReferenceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.InterfaceBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.InterfaceBody))
						{
							if (this.Visit(node.InterfaceBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.InterfaceBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitInterfaceBody(InterfaceBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.OperationDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.OperationDeclaration.Node))
					{
						foreach (var item in node.OperationDeclaration)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.OperationHead != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationHead))
						{
							if (this.Visit(node.OperationHead)) return true;
						}
					}
					else
					{
						if (this.Visit(node.OperationHead)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOperationHead(OperationHeadSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.OperationResult != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationResult))
						{
							if (this.Visit(node.OperationResult)) return true;
						}
					}
					else
					{
						if (this.Visit(node.OperationResult)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.ParameterList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ParameterList))
						{
							if (this.Visit(node.ParameterList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ParameterList)) return true;
					}
				}
				if (node.ThrowsList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ThrowsList))
						{
							if (this.Visit(node.ThrowsList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ThrowsList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitParameterList(ParameterListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Parameter != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Parameter.Node))
					{
						foreach (var item in node.Parameter)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitParameter(ParameterSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.AnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
						{
							if (this.Visit(node.AnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AnnotationList)) return true;
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOperationResult(OperationResultSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ReturnAnnotationList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ReturnAnnotationList))
						{
							if (this.Visit(node.ReturnAnnotationList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ReturnAnnotationList)) return true;
					}
				}
				if (node.OperationReturnType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationReturnType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OperationReturnType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitThrowsList(ThrowsListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.QualifierList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifierList))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifierList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KAbstract)))
				{
					if (node.KAbstract.GetKind() == SoalSyntaxKind.KAbstract)
					{
						return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.ComponentBase != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentBase))
						{
							if (this.Visit(node.ComponentBase)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentBase)) return true;
					}
				}
				if (node.ComponentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentBody))
						{
							if (this.Visit(node.ComponentBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentBase(ComponentBaseSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentBody(ComponentBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ComponentElements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentElements))
						{
							if (this.Visit(node.ComponentElements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentElements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentElements(ComponentElementsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ComponentElement != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentElement.Node))
					{
						foreach (var item in node.ComponentElement)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentElement(ComponentElementSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ComponentService != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentService))
						{
							if (this.Visit(node.ComponentService)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentService)) return true;
					}
				}
				if (node.ComponentReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentReference))
						{
							if (this.Visit(node.ComponentReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentReference)) return true;
					}
				}
				if (node.ComponentProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentProperty))
						{
							if (this.Visit(node.ComponentProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentProperty)) return true;
					}
				}
				if (node.ComponentImplementation != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentImplementation))
						{
							if (this.Visit(node.ComponentImplementation)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentImplementation)) return true;
					}
				}
				if (node.ComponentLanguage != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentLanguage))
						{
							if (this.Visit(node.ComponentLanguage)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentLanguage)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentService(ComponentServiceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.ComponentServiceOrReferenceBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceBody))
						{
							if (this.Visit(node.ComponentServiceOrReferenceBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentServiceOrReferenceBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentReference(ComponentReferenceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.ComponentServiceOrReferenceBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceBody))
						{
							if (this.Visit(node.ComponentServiceOrReferenceBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentServiceOrReferenceBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ComponentServiceOrReferenceElement != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceElement.Node))
					{
						foreach (var item in node.ComponentServiceOrReferenceElement)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentProperty(ComponentPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.ComponentBase != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentBase))
						{
							if (this.Visit(node.ComponentBase)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentBase)) return true;
					}
				}
				if (node.CompositeBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeBody))
						{
							if (this.Visit(node.CompositeBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompositeBody(CompositeBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.CompositeElements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeElements))
						{
							if (this.Visit(node.CompositeElements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeElements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.ComponentBase != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentBase))
						{
							if (this.Visit(node.ComponentBase)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentBase)) return true;
					}
				}
				if (node.CompositeBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeBody))
						{
							if (this.Visit(node.CompositeBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompositeElements(CompositeElementsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.CompositeElement != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CompositeElement.Node))
					{
						foreach (var item in node.CompositeElement)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompositeElement(CompositeElementSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ComponentService != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentService))
						{
							if (this.Visit(node.ComponentService)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentService)) return true;
					}
				}
				if (node.ComponentReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentReference))
						{
							if (this.Visit(node.ComponentReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentReference)) return true;
					}
				}
				if (node.ComponentProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentProperty))
						{
							if (this.Visit(node.ComponentProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentProperty)) return true;
					}
				}
				if (node.ComponentImplementation != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentImplementation))
						{
							if (this.Visit(node.ComponentImplementation)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentImplementation)) return true;
					}
				}
				if (node.ComponentLanguage != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComponentLanguage))
						{
							if (this.Visit(node.ComponentLanguage)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComponentLanguage)) return true;
					}
				}
				if (node.CompositeComponent != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeComponent))
						{
							if (this.Visit(node.CompositeComponent)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeComponent)) return true;
					}
				}
				if (node.CompositeWire != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeWire))
						{
							if (this.Visit(node.CompositeWire)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeWire)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompositeComponent(CompositeComponentSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompositeWire(CompositeWireSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.WireSource != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.WireSource))
						{
							if (this.Visit(node.WireSource)) return true;
						}
					}
					else
					{
						if (this.Visit(node.WireSource)) return true;
					}
				}
				if (node.WireTarget != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.WireTarget))
						{
							if (this.Visit(node.WireTarget)) return true;
						}
					}
					else
					{
						if (this.Visit(node.WireTarget)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitWireSource(WireSourceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitWireTarget(WireTargetSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.DeploymentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DeploymentBody))
						{
							if (this.Visit(node.DeploymentBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DeploymentBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeploymentBody(DeploymentBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.DeploymentElements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DeploymentElements))
						{
							if (this.Visit(node.DeploymentElements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DeploymentElements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.DeploymentElement != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.DeploymentElement.Node))
					{
						foreach (var item in node.DeploymentElement)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeploymentElement(DeploymentElementSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.EnvironmentDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnvironmentDeclaration))
						{
							if (this.Visit(node.EnvironmentDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnvironmentDeclaration)) return true;
					}
				}
				if (node.CompositeWire != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompositeWire))
						{
							if (this.Visit(node.CompositeWire)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompositeWire)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.EnvironmentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnvironmentBody))
						{
							if (this.Visit(node.EnvironmentBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnvironmentBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.RuntimeDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RuntimeDeclaration))
						{
							if (this.Visit(node.RuntimeDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.RuntimeDeclaration)) return true;
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
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.AssemblyReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AssemblyReference))
						{
							if (this.Visit(node.AssemblyReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AssemblyReference)) return true;
					}
				}
				if (node.DatabaseReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DatabaseReference))
						{
							if (this.Visit(node.DatabaseReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DatabaseReference)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.BindingBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BindingBody))
						{
							if (this.Visit(node.BindingBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BindingBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitBindingBody(BindingBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.BindingLayers != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BindingLayers))
						{
							if (this.Visit(node.BindingLayers)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BindingLayers)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitBindingLayers(BindingLayersSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.TransportLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TransportLayer))
						{
							if (this.Visit(node.TransportLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TransportLayer)) return true;
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
								if (this.Visit(item)) return true;
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
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTransportLayer(TransportLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.HttpTransportLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.HttpTransportLayer))
						{
							if (this.Visit(node.HttpTransportLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.HttpTransportLayer)) return true;
					}
				}
				if (node.RestTransportLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RestTransportLayer))
						{
							if (this.Visit(node.RestTransportLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.RestTransportLayer)) return true;
					}
				}
				if (node.WebSocketTransportLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.WebSocketTransportLayer))
						{
							if (this.Visit(node.WebSocketTransportLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.WebSocketTransportLayer)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.HttpTransportLayerBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.HttpTransportLayerBody))
						{
							if (this.Visit(node.HttpTransportLayerBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.HttpTransportLayerBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.HttpTransportLayerProperties != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.HttpTransportLayerProperties.Node))
					{
						foreach (var item in node.HttpTransportLayerProperties)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.RestTransportLayerBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RestTransportLayerBody))
						{
							if (this.Visit(node.RestTransportLayerBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.RestTransportLayerBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.WebSocketTransportLayerBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.WebSocketTransportLayerBody))
						{
							if (this.Visit(node.WebSocketTransportLayerBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.WebSocketTransportLayerBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.HttpSslProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.HttpSslProperty))
						{
							if (this.Visit(node.HttpSslProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.HttpSslProperty)) return true;
					}
				}
				if (node.HttpClientAuthenticationProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.HttpClientAuthenticationProperty))
						{
							if (this.Visit(node.HttpClientAuthenticationProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.HttpClientAuthenticationProperty)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.BooleanLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
						{
							if (this.Visit(node.BooleanLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BooleanLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.BooleanLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
						{
							if (this.Visit(node.BooleanLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BooleanLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEncodingLayer(EncodingLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.SoapEncodingLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SoapEncodingLayer))
						{
							if (this.Visit(node.SoapEncodingLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SoapEncodingLayer)) return true;
					}
				}
				if (node.XmlEncodingLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.XmlEncodingLayer))
						{
							if (this.Visit(node.XmlEncodingLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.XmlEncodingLayer)) return true;
					}
				}
				if (node.JsonEncodingLayer != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.JsonEncodingLayer))
						{
							if (this.Visit(node.JsonEncodingLayer)) return true;
						}
					}
					else
					{
						if (this.Visit(node.JsonEncodingLayer)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.SoapEncodingLayerBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SoapEncodingLayerBody))
						{
							if (this.Visit(node.SoapEncodingLayerBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SoapEncodingLayerBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.SoapEncodingProperties != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.SoapEncodingProperties.Node))
					{
						foreach (var item in node.SoapEncodingProperties)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.XmlEncodingLayerBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.XmlEncodingLayerBody))
						{
							if (this.Visit(node.XmlEncodingLayerBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.XmlEncodingLayerBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.JsonEncodingLayerBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.JsonEncodingLayerBody))
						{
							if (this.Visit(node.JsonEncodingLayerBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.JsonEncodingLayerBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.SoapVersionProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SoapVersionProperty))
						{
							if (this.Visit(node.SoapVersionProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SoapVersionProperty)) return true;
					}
				}
				if (node.SoapMtomProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SoapMtomProperty))
						{
							if (this.Visit(node.SoapMtomProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SoapMtomProperty)) return true;
					}
				}
				if (node.SoapStyleProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SoapStyleProperty))
						{
							if (this.Visit(node.SoapStyleProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SoapStyleProperty)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.BooleanLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
						{
							if (this.Visit(node.BooleanLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BooleanLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ProtocolLayerKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ProtocolLayerKind))
						{
							if (this.Visit(node.ProtocolLayerKind)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ProtocolLayerKind)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.WsAddressing != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.WsAddressing))
						{
							if (this.Visit(node.WsAddressing)) return true;
						}
					}
					else
					{
						if (this.Visit(node.WsAddressing)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitWsAddressing(WsAddressingSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				if (node.EndpointBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndpointBody))
						{
							if (this.Visit(node.EndpointBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndpointBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEndpointBody(EndpointBodySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.EndpointProperties != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndpointProperties))
						{
							if (this.Visit(node.EndpointProperties)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndpointProperties)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.EndpointProperty != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EndpointProperty.Node))
					{
						foreach (var item in node.EndpointProperty)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEndpointProperty(EndpointPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.EndpointBindingProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndpointBindingProperty))
						{
							if (this.Visit(node.EndpointBindingProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndpointBindingProperty)) return true;
					}
				}
				if (node.EndpointAddressProperty != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndpointAddressProperty))
						{
							if (this.Visit(node.EndpointAddressProperty)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndpointAddressProperty)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.StringLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitReturnType(ReturnTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.VoidType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VoidType))
						{
							if (this.Visit(node.VoidType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VoidType)) return true;
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							if (this.Visit(node.TypeReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypeReference(TypeReferenceSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.NonNullableArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NonNullableArrayType))
						{
							if (this.Visit(node.NonNullableArrayType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NonNullableArrayType)) return true;
					}
				}
				if (node.ArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArrayType))
						{
							if (this.Visit(node.ArrayType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ArrayType)) return true;
					}
				}
				if (node.SimpleType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleType))
						{
							if (this.Visit(node.SimpleType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleType)) return true;
					}
				}
				if (node.NulledType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NulledType))
						{
							if (this.Visit(node.NulledType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NulledType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleType(SimpleTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ValueType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ValueType))
						{
							if (this.Visit(node.ValueType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ValueType)) return true;
					}
				}
				if (node.ObjectType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectType))
						{
							if (this.Visit(node.ObjectType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectType)) return true;
					}
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							if (this.Visit(node.Qualifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNulledType(NulledTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.NullableType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NullableType))
						{
							if (this.Visit(node.NullableType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NullableType)) return true;
					}
				}
				if (node.NonNullableType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NonNullableType))
						{
							if (this.Visit(node.NonNullableType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NonNullableType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitReferenceType(ReferenceTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ObjectType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectType))
						{
							if (this.Visit(node.ObjectType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectType)) return true;
					}
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							if (this.Visit(node.Qualifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitObjectType(ObjectTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitValueType(ValueTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVoidType(VoidTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOnewayType(OnewayTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.OnewayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OnewayType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OnewayType)) return true;
					}
				}
				if (node.VoidType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VoidType))
						{
							if (this.Visit(node.VoidType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VoidType)) return true;
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							if (this.Visit(node.TypeReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNullableType(NullableTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ValueType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ValueType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ValueType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNonNullableType(NonNullableTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ReferenceType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ReferenceType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ReferenceType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.ArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArrayType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ArrayType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrayType(ArrayTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.SimpleArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleArrayType))
						{
							if (this.Visit(node.SimpleArrayType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleArrayType)) return true;
					}
				}
				if (node.NulledArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NulledArrayType))
						{
							if (this.Visit(node.NulledArrayType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NulledArrayType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.SimpleType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.NulledType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NulledType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.NulledType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitConstantValue(ConstantValueSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Literal != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Literal))
						{
							if (this.Visit(node.Literal)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Literal)) return true;
					}
				}
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							if (this.Visit(node.Identifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypeofValue(TypeofValueSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ReturnType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ReturnType))
						{
							if (this.Visit(node.ReturnType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ReturnType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIdentifier(IdentifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIdentifiers(IdentifiersSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitLiteral(LiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NullLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NullLiteral))
						{
							if (this.Visit(node.NullLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NullLiteral)) return true;
					}
				}
				if (node.BooleanLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
						{
							if (this.Visit(node.BooleanLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BooleanLiteral)) return true;
					}
				}
				if (node.IntegerLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IntegerLiteral))
						{
							if (this.Visit(node.IntegerLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.IntegerLiteral)) return true;
					}
				}
				if (node.DecimalLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DecimalLiteral))
						{
							if (this.Visit(node.DecimalLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DecimalLiteral)) return true;
					}
				}
				if (node.ScientificLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ScientificLiteral))
						{
							if (this.Visit(node.ScientificLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ScientificLiteral)) return true;
					}
				}
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							if (this.Visit(node.StringLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.StringLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNullLiteral(NullLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitStringLiteral(StringLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
    }
}


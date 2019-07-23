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
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NamespaceDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration.Node))
					{
						foreach (var item in node.NamespaceDeclaration)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitName(NameSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier))
					{
						return this.Visit(node.Identifier);
					}
				}
			}
			return false;
		}
		
		public bool VisitQualifiedName(QualifiedNameSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return this.Visit(node.Qualifier);
					}
				}
			}
			return false;
		}
		
		public bool VisitQualifier(QualifierSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitIdentifierList(IdentifierListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitQualifierList(QualifierListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier.Node))
					{
						foreach (var item in node.Qualifier)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotationList(AnnotationListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Annotation != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Annotation.Node))
					{
						foreach (var item in node.Annotation)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ReturnAnnotation != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ReturnAnnotation.Node))
					{
						foreach (var item in node.ReturnAnnotation)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotation(AnnotationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationHead != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationHead))
					{
						return this.Visit(node.AnnotationHead);
					}
				}
			}
			return false;
		}
		
		public bool VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationHead != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationHead))
					{
						return this.Visit(node.AnnotationHead);
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.AnnotationBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationBody))
					{
						return this.Visit(node.AnnotationBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotationBody(AnnotationBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationPropertyList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationPropertyList))
					{
						return this.Visit(node.AnnotationPropertyList);
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationProperty.Node))
					{
						foreach (var item in node.AnnotationProperty)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.AnnotationPropertyValue != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationPropertyValue))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ConstantValue != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ConstantValue))
					{
						return this.Visit(node.ConstantValue);
					}
				}
				if (node.TypeofValue != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeofValue))
					{
						return this.Visit(node.TypeofValue);
					}
				}
			}
			return false;
		}
		
		public bool VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.QualifiedName != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
					{
						return this.Visit(node.QualifiedName);
					}
				}
				if (node.NamespacePrefix != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NamespacePrefix))
					{
						return this.Visit(node.NamespacePrefix);
					}
				}
				if (node.NamespaceUri != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NamespaceUri))
					{
						return this.Visit(node.NamespaceUri);
					}
				}
				if (node.NamespaceBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NamespaceBody))
					{
						return this.Visit(node.NamespaceBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitNamespacePrefix(NamespacePrefixSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitNamespaceUri(NamespaceUriSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.StringLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitNamespaceBody(NamespaceBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Declaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Declaration.Node))
					{
						foreach (var item in node.Declaration)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitDeclaration(DeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EnumDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumDeclaration))
					{
						return this.Visit(node.EnumDeclaration);
					}
				}
				if (node.StructDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.StructDeclaration))
					{
						return this.Visit(node.StructDeclaration);
					}
				}
				if (node.DatabaseDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DatabaseDeclaration))
					{
						return this.Visit(node.DatabaseDeclaration);
					}
				}
				if (node.InterfaceDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.InterfaceDeclaration))
					{
						return this.Visit(node.InterfaceDeclaration);
					}
				}
				if (node.ComponentDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentDeclaration))
					{
						return this.Visit(node.ComponentDeclaration);
					}
				}
				if (node.CompositeDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeDeclaration))
					{
						return this.Visit(node.CompositeDeclaration);
					}
				}
				if (node.AssemblyDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AssemblyDeclaration))
					{
						return this.Visit(node.AssemblyDeclaration);
					}
				}
				if (node.BindingDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BindingDeclaration))
					{
						return this.Visit(node.BindingDeclaration);
					}
				}
				if (node.EndpointDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EndpointDeclaration))
					{
						return this.Visit(node.EndpointDeclaration);
					}
				}
				if (node.DeploymentDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DeploymentDeclaration))
					{
						return this.Visit(node.DeploymentDeclaration);
					}
				}
			}
			return false;
		}
		
		public bool VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.EnumBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumBody))
					{
						return this.Visit(node.EnumBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitEnumBody(EnumBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EnumLiterals != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumLiterals))
					{
						return this.Visit(node.EnumLiterals);
					}
				}
			}
			return false;
		}
		
		public bool VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EnumLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumLiteral.Node))
					{
						foreach (var item in node.EnumLiteral)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitEnumLiteral(EnumLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitStructDeclaration(StructDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.StructBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.StructBody))
					{
						return this.Visit(node.StructBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitStructBody(StructBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.PropertyDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.PropertyDeclaration.Node))
					{
						foreach (var item in node.PropertyDeclaration)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.TypeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeReference))
					{
						return true;
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.DatabaseBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DatabaseBody))
					{
						return this.Visit(node.DatabaseBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitDatabaseBody(DatabaseBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EntityReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EntityReference.Node))
					{
						foreach (var item in node.EntityReference)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.OperationDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration.Node))
					{
						foreach (var item in node.OperationDeclaration)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitEntityReference(EntityReferenceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.InterfaceBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.InterfaceBody))
					{
						return this.Visit(node.InterfaceBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitInterfaceBody(InterfaceBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.OperationDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration.Node))
					{
						foreach (var item in node.OperationDeclaration)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.OperationHead != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationHead))
					{
						return this.Visit(node.OperationHead);
					}
				}
			}
			return false;
		}
		
		public bool VisitOperationHead(OperationHeadSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.OperationResult != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationResult))
					{
						return this.Visit(node.OperationResult);
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.ParameterList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ParameterList))
					{
						return this.Visit(node.ParameterList);
					}
				}
				if (node.ThrowsList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ThrowsList))
					{
						return this.Visit(node.ThrowsList);
					}
				}
			}
			return false;
		}
		
		public bool VisitParameterList(ParameterListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Parameter != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Parameter.Node))
					{
						foreach (var item in node.Parameter)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitParameter(ParameterSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AnnotationList))
					{
						return this.Visit(node.AnnotationList);
					}
				}
				if (node.TypeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeReference))
					{
						return true;
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitOperationResult(OperationResultSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ReturnAnnotationList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ReturnAnnotationList))
					{
						return this.Visit(node.ReturnAnnotationList);
					}
				}
				if (node.OperationReturnType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationReturnType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitThrowsList(ThrowsListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.QualifierList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.QualifierList))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (LookupPosition.IsInNode(this.Position, node.KAbstract))
				{
					return true;
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.ComponentBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentBody))
					{
						return this.Visit(node.ComponentBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentBody(ComponentBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ComponentElements != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentElements))
					{
						return this.Visit(node.ComponentElements);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentElements(ComponentElementsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ComponentElement != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentElement.Node))
					{
						foreach (var item in node.ComponentElement)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentElement(ComponentElementSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ComponentService != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentService))
					{
						return this.Visit(node.ComponentService);
					}
				}
				if (node.ComponentReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentReference))
					{
						return this.Visit(node.ComponentReference);
					}
				}
				if (node.ComponentProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentProperty))
					{
						return this.Visit(node.ComponentProperty);
					}
				}
				if (node.ComponentImplementation != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentImplementation))
					{
						return this.Visit(node.ComponentImplementation);
					}
				}
				if (node.ComponentLanguage != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentLanguage))
					{
						return this.Visit(node.ComponentLanguage);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentService(ComponentServiceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.ComponentServiceOrReferenceBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceBody))
					{
						return this.Visit(node.ComponentServiceOrReferenceBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentReference(ComponentReferenceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.ComponentServiceOrReferenceBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceBody))
					{
						return this.Visit(node.ComponentServiceOrReferenceBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ComponentServiceOrReferenceElement != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentServiceOrReferenceElement.Node))
					{
						foreach (var item in node.ComponentServiceOrReferenceElement)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentProperty(ComponentPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.TypeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeReference))
					{
						return true;
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.CompositeBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeBody))
					{
						return this.Visit(node.CompositeBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitCompositeBody(CompositeBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.CompositeElements != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeElements))
					{
						return this.Visit(node.CompositeElements);
					}
				}
			}
			return false;
		}
		
		public bool VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.CompositeBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeBody))
					{
						return this.Visit(node.CompositeBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitCompositeElements(CompositeElementsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.CompositeElement != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeElement.Node))
					{
						foreach (var item in node.CompositeElement)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitCompositeElement(CompositeElementSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ComponentService != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentService))
					{
						return this.Visit(node.ComponentService);
					}
				}
				if (node.ComponentReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentReference))
					{
						return this.Visit(node.ComponentReference);
					}
				}
				if (node.ComponentProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentProperty))
					{
						return this.Visit(node.ComponentProperty);
					}
				}
				if (node.ComponentImplementation != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentImplementation))
					{
						return this.Visit(node.ComponentImplementation);
					}
				}
				if (node.ComponentLanguage != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ComponentLanguage))
					{
						return this.Visit(node.ComponentLanguage);
					}
				}
				if (node.CompositeComponent != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeComponent))
					{
						return this.Visit(node.CompositeComponent);
					}
				}
				if (node.CompositeWire != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeWire))
					{
						return this.Visit(node.CompositeWire);
					}
				}
			}
			return false;
		}
		
		public bool VisitCompositeComponent(CompositeComponentSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitCompositeWire(CompositeWireSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.WireSource != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.WireSource))
					{
						return this.Visit(node.WireSource);
					}
				}
				if (node.WireTarget != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.WireTarget))
					{
						return this.Visit(node.WireTarget);
					}
				}
			}
			return false;
		}
		
		public bool VisitWireSource(WireSourceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitWireTarget(WireTargetSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.DeploymentBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DeploymentBody))
					{
						return this.Visit(node.DeploymentBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitDeploymentBody(DeploymentBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.DeploymentElements != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DeploymentElements))
					{
						return this.Visit(node.DeploymentElements);
					}
				}
			}
			return false;
		}
		
		public bool VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.DeploymentElement != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DeploymentElement.Node))
					{
						foreach (var item in node.DeploymentElement)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitDeploymentElement(DeploymentElementSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EnvironmentDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnvironmentDeclaration))
					{
						return this.Visit(node.EnvironmentDeclaration);
					}
				}
				if (node.CompositeWire != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CompositeWire))
					{
						return this.Visit(node.CompositeWire);
					}
				}
			}
			return false;
		}
		
		public bool VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.EnvironmentBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnvironmentBody))
					{
						return this.Visit(node.EnvironmentBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.RuntimeDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.RuntimeDeclaration))
					{
						return this.Visit(node.RuntimeDeclaration);
					}
				}
				if (node.RuntimeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.RuntimeReference.Node))
					{
						foreach (var item in node.RuntimeReference)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
			}
			return false;
		}
		
		public bool VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.AssemblyReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AssemblyReference))
					{
						return this.Visit(node.AssemblyReference);
					}
				}
				if (node.DatabaseReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DatabaseReference))
					{
						return this.Visit(node.DatabaseReference);
					}
				}
			}
			return false;
		}
		
		public bool VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.BindingBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BindingBody))
					{
						return this.Visit(node.BindingBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitBindingBody(BindingBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.BindingLayers != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BindingLayers))
					{
						return this.Visit(node.BindingLayers);
					}
				}
			}
			return false;
		}
		
		public bool VisitBindingLayers(BindingLayersSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.TransportLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TransportLayer))
					{
						return this.Visit(node.TransportLayer);
					}
				}
				if (node.EncodingLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EncodingLayer.Node))
					{
						foreach (var item in node.EncodingLayer)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.ProtocolLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ProtocolLayer.Node))
					{
						foreach (var item in node.ProtocolLayer)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitTransportLayer(TransportLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.HttpTransportLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.HttpTransportLayer))
					{
						return this.Visit(node.HttpTransportLayer);
					}
				}
				if (node.RestTransportLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.RestTransportLayer))
					{
						return this.Visit(node.RestTransportLayer);
					}
				}
				if (node.WebSocketTransportLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.WebSocketTransportLayer))
					{
						return this.Visit(node.WebSocketTransportLayer);
					}
				}
			}
			return false;
		}
		
		public bool VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.HttpTransportLayerBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.HttpTransportLayerBody))
					{
						return this.Visit(node.HttpTransportLayerBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.HttpTransportLayerProperties != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.HttpTransportLayerProperties.Node))
					{
						foreach (var item in node.HttpTransportLayerProperties)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.RestTransportLayerBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.RestTransportLayerBody))
					{
						return this.Visit(node.RestTransportLayerBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.WebSocketTransportLayerBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.WebSocketTransportLayerBody))
					{
						return this.Visit(node.WebSocketTransportLayerBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.HttpSslProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.HttpSslProperty))
					{
						return this.Visit(node.HttpSslProperty);
					}
				}
				if (node.HttpClientAuthenticationProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.HttpClientAuthenticationProperty))
					{
						return this.Visit(node.HttpClientAuthenticationProperty);
					}
				}
			}
			return false;
		}
		
		public bool VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.BooleanLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
					{
						return this.Visit(node.BooleanLiteral);
					}
				}
			}
			return false;
		}
		
		public bool VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.BooleanLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
					{
						return this.Visit(node.BooleanLiteral);
					}
				}
			}
			return false;
		}
		
		public bool VisitEncodingLayer(EncodingLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.SoapEncodingLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SoapEncodingLayer))
					{
						return this.Visit(node.SoapEncodingLayer);
					}
				}
				if (node.XmlEncodingLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.XmlEncodingLayer))
					{
						return this.Visit(node.XmlEncodingLayer);
					}
				}
				if (node.JsonEncodingLayer != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.JsonEncodingLayer))
					{
						return this.Visit(node.JsonEncodingLayer);
					}
				}
			}
			return false;
		}
		
		public bool VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.SoapEncodingLayerBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SoapEncodingLayerBody))
					{
						return this.Visit(node.SoapEncodingLayerBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.SoapEncodingProperties != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SoapEncodingProperties.Node))
					{
						foreach (var item in node.SoapEncodingProperties)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.XmlEncodingLayerBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.XmlEncodingLayerBody))
					{
						return this.Visit(node.XmlEncodingLayerBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.JsonEncodingLayerBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.JsonEncodingLayerBody))
					{
						return this.Visit(node.JsonEncodingLayerBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.SoapVersionProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SoapVersionProperty))
					{
						return this.Visit(node.SoapVersionProperty);
					}
				}
				if (node.SoapMtomProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SoapMtomProperty))
					{
						return this.Visit(node.SoapMtomProperty);
					}
				}
				if (node.SoapStyleProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SoapStyleProperty))
					{
						return this.Visit(node.SoapStyleProperty);
					}
				}
			}
			return false;
		}
		
		public bool VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.BooleanLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
					{
						return this.Visit(node.BooleanLiteral);
					}
				}
			}
			return false;
		}
		
		public bool VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ProtocolLayerKind != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ProtocolLayerKind))
					{
						return this.Visit(node.ProtocolLayerKind);
					}
				}
			}
			return false;
		}
		
		public bool VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.WsAddressing != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.WsAddressing))
					{
						return this.Visit(node.WsAddressing);
					}
				}
			}
			return false;
		}
		
		public bool VisitWsAddressing(WsAddressingSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
				if (node.EndpointBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EndpointBody))
					{
						return this.Visit(node.EndpointBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitEndpointBody(EndpointBodySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EndpointProperties != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EndpointProperties))
					{
						return this.Visit(node.EndpointProperties);
					}
				}
			}
			return false;
		}
		
		public bool VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EndpointProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EndpointProperty.Node))
					{
						foreach (var item in node.EndpointProperty)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
			}
			return false;
		}
		
		public bool VisitEndpointProperty(EndpointPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EndpointBindingProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EndpointBindingProperty))
					{
						return this.Visit(node.EndpointBindingProperty);
					}
				}
				if (node.EndpointAddressProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EndpointAddressProperty))
					{
						return this.Visit(node.EndpointAddressProperty);
					}
				}
			}
			return false;
		}
		
		public bool VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.StringLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitReturnType(ReturnTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.VoidType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.VoidType))
					{
						return this.Visit(node.VoidType);
					}
				}
				if (node.TypeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeReference))
					{
						return this.Visit(node.TypeReference);
					}
				}
			}
			return false;
		}
		
		public bool VisitTypeReference(TypeReferenceSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NonNullableArrayType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NonNullableArrayType))
					{
						return this.Visit(node.NonNullableArrayType);
					}
				}
				if (node.ArrayType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ArrayType))
					{
						return this.Visit(node.ArrayType);
					}
				}
				if (node.SimpleType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SimpleType))
					{
						return this.Visit(node.SimpleType);
					}
				}
				if (node.NulledType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NulledType))
					{
						return this.Visit(node.NulledType);
					}
				}
			}
			return false;
		}
		
		public bool VisitSimpleType(SimpleTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ValueType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ValueType))
					{
						return this.Visit(node.ValueType);
					}
				}
				if (node.ObjectType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ObjectType))
					{
						return this.Visit(node.ObjectType);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return this.Visit(node.Qualifier);
					}
				}
			}
			return false;
		}
		
		public bool VisitNulledType(NulledTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NullableType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NullableType))
					{
						return this.Visit(node.NullableType);
					}
				}
				if (node.NonNullableType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NonNullableType))
					{
						return this.Visit(node.NonNullableType);
					}
				}
			}
			return false;
		}
		
		public bool VisitReferenceType(ReferenceTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ObjectType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ObjectType))
					{
						return this.Visit(node.ObjectType);
					}
				}
				if (node.Qualifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Qualifier))
					{
						return this.Visit(node.Qualifier);
					}
				}
			}
			return false;
		}
		
		public bool VisitObjectType(ObjectTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitValueType(ValueTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitVoidType(VoidTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitOnewayType(OnewayTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.OnewayType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OnewayType))
					{
						return true;
					}
				}
				if (node.VoidType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.VoidType))
					{
						return this.Visit(node.VoidType);
					}
				}
				if (node.TypeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeReference))
					{
						return this.Visit(node.TypeReference);
					}
				}
			}
			return false;
		}
		
		public bool VisitNullableType(NullableTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ValueType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ValueType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitNonNullableType(NonNullableTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ReferenceType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ReferenceType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ArrayType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ArrayType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitArrayType(ArrayTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.SimpleArrayType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SimpleArrayType))
					{
						return this.Visit(node.SimpleArrayType);
					}
				}
				if (node.NulledArrayType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NulledArrayType))
					{
						return this.Visit(node.NulledArrayType);
					}
				}
			}
			return false;
		}
		
		public bool VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.SimpleType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SimpleType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NulledType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NulledType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitConstantValue(ConstantValueSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Literal != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Literal))
					{
						return this.Visit(node.Literal);
					}
				}
				if (node.Identifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Identifier))
					{
						return this.Visit(node.Identifier);
					}
				}
			}
			return false;
		}
		
		public bool VisitTypeofValue(TypeofValueSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ReturnType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ReturnType))
					{
						return this.Visit(node.ReturnType);
					}
				}
			}
			return false;
		}
		
		public bool VisitIdentifier(IdentifierSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitIdentifiers(IdentifiersSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitLiteral(LiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NullLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NullLiteral))
					{
						return this.Visit(node.NullLiteral);
					}
				}
				if (node.BooleanLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
					{
						return this.Visit(node.BooleanLiteral);
					}
				}
				if (node.IntegerLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.IntegerLiteral))
					{
						return this.Visit(node.IntegerLiteral);
					}
				}
				if (node.DecimalLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.DecimalLiteral))
					{
						return this.Visit(node.DecimalLiteral);
					}
				}
				if (node.ScientificLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ScientificLiteral))
					{
						return this.Visit(node.ScientificLiteral);
					}
				}
				if (node.StringLiteral != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
					{
						return this.Visit(node.StringLiteral);
					}
				}
			}
			return false;
		}
		
		public bool VisitNullLiteral(NullLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitStringLiteral(StringLiteralSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InNode) 
			{
				return true;
			}
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
		
		public bool VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
			}
			return false;
		}
    }
}


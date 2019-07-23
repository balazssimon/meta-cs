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
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

namespace MetaDslx.Languages.Meta.Binding
{
	// Make sure to keep this in sync with MetaBoundNodeFactoryVisitor
    public class MetaIsBindableNodeVisitor : IsBindableNodeVisitor, IMetaSyntaxVisitor<bool>
    {
        public MetaIsBindableNodeVisitor(BoundTree boundTree)
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
					if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration))
					{
						return this.Visit(node.NamespaceDeclaration);
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
		
		public bool VisitAttribute(AttributeSyntax node)
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.QualifiedName != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
					{
						return this.Visit(node.QualifiedName);
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
				if (node.MetamodelDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.MetamodelDeclaration))
					{
						return this.Visit(node.MetamodelDeclaration);
					}
				}
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
		
		public bool VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
					}
				}
				if (node.MetamodelPropertyList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.MetamodelPropertyList))
					{
						return this.Visit(node.MetamodelPropertyList);
					}
				}
			}
			return false;
		}
		
		public bool VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.MetamodelProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.MetamodelProperty.Node))
					{
						foreach (var item in node.MetamodelProperty)
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
		
		public bool VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.MetamodelUriProperty != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.MetamodelUriProperty))
					{
						return this.Visit(node.MetamodelUriProperty);
					}
				}
			}
			return false;
		}
		
		public bool VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
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
				if (node.ClassDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ClassDeclaration))
					{
						return this.Visit(node.ClassDeclaration);
					}
				}
				if (node.AssociationDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.AssociationDeclaration))
					{
						return this.Visit(node.AssociationDeclaration);
					}
				}
				if (node.ConstDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ConstDeclaration))
					{
						return this.Visit(node.ConstDeclaration);
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.Name != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Name))
					{
						return this.Visit(node.Name);
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
				if (node.EnumValues != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumValues))
					{
						return true;
					}
				}
				if (node.EnumMemberDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumMemberDeclaration.Node))
					{
						foreach (var item in node.EnumMemberDeclaration)
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
		
		public bool VisitEnumValues(EnumValuesSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.EnumValue != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.EnumValue.Node))
					{
						foreach (var item in node.EnumValue)
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
		
		public bool VisitEnumValue(EnumValueSyntax node)
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
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
		
		public bool VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.OperationDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitClassDeclaration(ClassDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
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
				if (node.ClassAncestors != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ClassAncestors))
					{
						return true;
					}
				}
				if (node.ClassBody != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ClassBody))
					{
						return this.Visit(node.ClassBody);
					}
				}
			}
			return false;
		}
		
		public bool VisitClassBody(ClassBodySyntax node)
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
				if (node.ClassMemberDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ClassMemberDeclaration.Node))
					{
						foreach (var item in node.ClassMemberDeclaration)
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
		
		public bool VisitClassAncestors(ClassAncestorsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.ClassAncestor != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ClassAncestor.Node))
					{
						foreach (var item in node.ClassAncestor)
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
		
		public bool VisitClassAncestor(ClassAncestorSyntax node)
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
		
		public bool VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.FieldDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.FieldDeclaration))
					{
						return true;
					}
				}
				if (node.OperationDeclaration != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitFieldDeclaration(FieldDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.FieldModifier != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.FieldModifier))
					{
						return true;
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
				if (node.RedefinitionsOrSubsettings != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.RedefinitionsOrSubsettings))
					{
						return this.Visit(node.RedefinitionsOrSubsettings);
					}
				}
			}
			return false;
		}
		
		public bool VisitFieldModifier(FieldModifierSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (LookupPosition.IsInNode(this.Position, node.FieldModifier))
				{
					switch (node.FieldModifier.GetKind().Switch())
					{
						case MetaSyntaxKind.KContainment:
						case MetaSyntaxKind.KReadonly:
						case MetaSyntaxKind.KLazy:
						case MetaSyntaxKind.KDerived:
							return true;
						default:
							return false;
					}
				}
			}
			return false;
		}
		
		public bool VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.Redefinitions != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Redefinitions))
					{
						return this.Visit(node.Redefinitions);
					}
				}
				if (node.Subsettings != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Subsettings))
					{
						return this.Visit(node.Subsettings);
					}
				}
			}
			return false;
		}
		
		public bool VisitRedefinitions(RedefinitionsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NameUseList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NameUseList))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitSubsettings(SubsettingsSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (node.NameUseList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NameUseList))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitNameUseList(NameUseListSyntax node)
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
		
		public bool VisitConstDeclaration(ConstDeclarationSyntax node)
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
				if (node.TypeReference != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.TypeReference))
					{
						return this.Visit(node.TypeReference);
					}
				}
				if (node.VoidType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.VoidType))
					{
						return this.Visit(node.VoidType);
					}
				}
			}
			return false;
		}
		
		public bool VisitTypeOfReference(TypeOfReferenceSyntax node)
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
				if (node.CollectionType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CollectionType))
					{
						return this.Visit(node.CollectionType);
					}
				}
				if (node.SimpleType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.SimpleType))
					{
						return this.Visit(node.SimpleType);
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
				if (node.PrimitiveType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.PrimitiveType))
					{
						return this.Visit(node.PrimitiveType);
					}
				}
				if (node.ObjectType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ObjectType))
					{
						return this.Visit(node.ObjectType);
					}
				}
				if (node.NullableType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.NullableType))
					{
						return this.Visit(node.NullableType);
					}
				}
				if (node.ClassType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ClassType))
					{
						return this.Visit(node.ClassType);
					}
				}
			}
			return false;
		}
		
		public bool VisitClassType(ClassTypeSyntax node)
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
		
		public bool VisitPrimitiveType(PrimitiveTypeSyntax node)
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
				if (node.PrimitiveType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.PrimitiveType))
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public bool VisitCollectionType(CollectionTypeSyntax node)
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
				if (node.CollectionKind != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.CollectionKind))
					{
						return true;
					}
				}
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
		
		public bool VisitCollectionKind(CollectionKindSyntax node)
		{
			var state = this.State;
			if (state == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (state == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			if (state == BoundNodeFactoryState.InParent)
			{
				if (LookupPosition.IsInNode(this.Position, node.CollectionKind))
				{
					switch (node.CollectionKind.GetKind().Switch())
					{
						case MetaSyntaxKind.KSet:
						case MetaSyntaxKind.KList:
						case MetaSyntaxKind.KMultiSet:
						case MetaSyntaxKind.KMultiList:
							return true;
						default:
							return false;
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.ReturnType != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ReturnType))
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
				if (node.ParameterList != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.ParameterList))
					{
						return true;
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
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
		
		public bool VisitAssociationDeclaration(AssociationDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (LookupPosition.IsInNode(this.Position, item))
							{
								return this.Visit(item);
							}
						}
					}
				}
				if (node.Source != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Source))
					{
						return true;
					}
				}
				if (node.Target != null)
				{
					if (LookupPosition.IsInNode(this.Position, node.Target))
					{
						return true;
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
    }
}


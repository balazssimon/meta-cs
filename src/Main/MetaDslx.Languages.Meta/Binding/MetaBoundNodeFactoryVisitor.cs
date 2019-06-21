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
    public class MetaBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, IMetaSyntaxVisitor<ArrayBuilder<BoundNode>, BoundNode>
    {
        public MetaBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

        protected virtual BoundNode CreateBoundAnnotation(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundAnnotationCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundAnnotationCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundAnnotation(MetaBoundKind.Annotation, boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundOpposite(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundOppositeCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundOppositeCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundOpposite(MetaBoundKind.Opposite, boundTree, childBoundNodes, syntax, hasErrors);
        }

		
		public BoundNode VisitMain(MainSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.NamespaceDeclaration != null)
			{
				this.Visit(node.NamespaceDeclaration, childBoundNodesForParent);
			}
			return null;
		}
		
		public BoundNode VisitName(NameSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Identifier != null)
			{
				this.Visit(node.Identifier, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitQualifiedName(QualifiedNameSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Qualifier != null)
			{
				this.Visit(node.Qualifier, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitQualifier(QualifierSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Identifier != null)
			{
				foreach (var item in node.Identifier)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundQualifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitAnnotation(AnnotationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Qualifier != null)
			{
				this.Visit(node.Qualifier, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundAnnotation(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create(resultNode), "Annotations", node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.QualifiedName != null)
			{
				this.Visit(node.QualifiedName, childBoundNodes);
			}
			if (node.NamespaceBody != null)
			{
				this.Visit(node.NamespaceBody, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaNamespace), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitNamespaceBody(NamespaceBodySyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.MetamodelDeclaration != null)
			{
				this.Visit(node.MetamodelDeclaration, childBoundNodesForParent);
			}
			if (node.Declaration != null)
			{
				foreach (var item in node.Declaration)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitMetamodelDeclaration(MetamodelDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			if (node.MetamodelPropertyList != null)
			{
				this.Visit(node.MetamodelPropertyList, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaModel), node, false);
			resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create(resultNode), "MetaModel", node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitMetamodelPropertyList(MetamodelPropertyListSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.MetamodelProperty != null)
			{
				foreach (var item in node.MetamodelProperty)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitMetamodelProperty(MetamodelPropertySyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.MetamodelUriProperty != null)
			{
				this.Visit(node.MetamodelUriProperty, childBoundNodesForParent);
			}
			return null;
		}
		
		public BoundNode VisitMetamodelUriProperty(MetamodelUriPropertySyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.StringLiteral != null)
			{
				var childBoundNodesOfStringLiteral = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.StringLiteral, childBoundNodesOfStringLiteral);
				BoundNode boundStringLiteral;
				boundStringLiteral = this.CreateBoundValue(this.BoundTree, childBoundNodesOfStringLiteral.ToImmutableAndFree(), node.StringLiteral, false);
				childBoundNodes.Add(boundStringLiteral);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Uri", node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitDeclaration(DeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.EnumDeclaration != null)
			{
				this.Visit(node.EnumDeclaration, childBoundNodes);
			}
			if (node.ClassDeclaration != null)
			{
				this.Visit(node.ClassDeclaration, childBoundNodes);
			}
			if (node.AssociationDeclaration != null)
			{
				this.Visit(node.AssociationDeclaration, childBoundNodes);
			}
			if (node.ConstDeclaration != null)
			{
				this.Visit(node.ConstDeclaration, childBoundNodes);
			}
			if (node.ExternTypeDeclaration != null)
			{
				this.Visit(node.ExternTypeDeclaration, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), "Declarations", node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitEnumDeclaration(EnumDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			if (node.EnumBody != null)
			{
				this.Visit(node.EnumBody, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaEnum), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitEnumBody(EnumBodySyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.EnumValues != null)
			{
				var childBoundNodesOfEnumValues = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.EnumValues, childBoundNodesOfEnumValues);
				BoundNode boundEnumValues;
				boundEnumValues = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfEnumValues.ToImmutableAndFree(), "EnumLiterals", node.EnumValues, false);
				childBoundNodesForParent.Add(boundEnumValues);
			}
			if (node.EnumMemberDeclaration != null)
			{
				foreach (var item in node.EnumMemberDeclaration)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitEnumValues(EnumValuesSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.EnumValue != null)
			{
				foreach (var item in node.EnumValue)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitEnumValue(EnumValueSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaEnumLiteral), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.OperationDeclaration != null)
			{
				var childBoundNodesOfOperationDeclaration = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.OperationDeclaration, childBoundNodesOfOperationDeclaration);
				BoundNode boundOperationDeclaration;
				boundOperationDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationDeclaration.ToImmutableAndFree(), "Operations", node.OperationDeclaration, false);
				childBoundNodesForParent.Add(boundOperationDeclaration);
			}
			return null;
		}
		
		public BoundNode VisitClassDeclaration(ClassDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.KAbstract.GetKind() == MetaSyntaxKind.KAbstract)
			{
				BoundNode boundKAbstract;
				boundKAbstract = this.CreateBoundProperty(this.BoundTree, ImmutableArray<BoundNode>.Empty, "IsAbstract", true, node, false);
				childBoundNodes.Add(boundKAbstract);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			if (node.ClassAncestors != null)
			{
				var childBoundNodesOfClassAncestors = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.ClassAncestors, childBoundNodesOfClassAncestors);
				BoundNode boundClassAncestors;
				boundClassAncestors = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfClassAncestors.ToImmutableAndFree(), "SuperClasses", node.ClassAncestors, false);
				childBoundNodes.Add(boundClassAncestors);
			}
			if (node.ClassBody != null)
			{
				this.Visit(node.ClassBody, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaClass), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitClassBody(ClassBodySyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.ClassMemberDeclaration != null)
			{
				foreach (var item in node.ClassMemberDeclaration)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitClassAncestors(ClassAncestorsSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.ClassAncestor != null)
			{
				foreach (var item in node.ClassAncestor)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitClassAncestor(ClassAncestorSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.Qualifier != null)
			{
				var childBoundNodesOfQualifier = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.Qualifier, childBoundNodesOfQualifier);
				BoundNode boundQualifier;
				boundQualifier = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaClass)), node.Qualifier, false);
				childBoundNodesForParent.Add(boundQualifier);
			}
			return null;
		}
		
		public BoundNode VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.FieldDeclaration != null)
			{
				var childBoundNodesOfFieldDeclaration = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.FieldDeclaration, childBoundNodesOfFieldDeclaration);
				BoundNode boundFieldDeclaration;
				boundFieldDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfFieldDeclaration.ToImmutableAndFree(), "Properties", node.FieldDeclaration, false);
				childBoundNodesForParent.Add(boundFieldDeclaration);
			}
			if (node.OperationDeclaration != null)
			{
				var childBoundNodesOfOperationDeclaration = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.OperationDeclaration, childBoundNodesOfOperationDeclaration);
				BoundNode boundOperationDeclaration;
				boundOperationDeclaration = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfOperationDeclaration.ToImmutableAndFree(), "Operations", node.OperationDeclaration, false);
				childBoundNodesForParent.Add(boundOperationDeclaration);
			}
			return null;
		}
		
		public BoundNode VisitFieldDeclaration(FieldDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.FieldModifier != null)
			{
				var childBoundNodesOfFieldModifier = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.FieldModifier, childBoundNodesOfFieldModifier);
				BoundNode boundFieldModifier;
				boundFieldModifier = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfFieldModifier.ToImmutableAndFree(), "Kind", node.FieldModifier, false);
				childBoundNodes.Add(boundFieldModifier);
			}
			if (node.TypeReference != null)
			{
				var childBoundNodesOfTypeReference = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
				BoundNode boundTypeReference;
				boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), "Type", node.TypeReference, false);
				childBoundNodes.Add(boundTypeReference);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			if (node.RedefinitionsOrSubsettings != null)
			{
				this.Visit(node.RedefinitionsOrSubsettings, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaProperty), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitFieldModifier(FieldModifierSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			switch (node.FieldModifier.GetKind().Switch())
			{
				case MetaSyntaxKind.KContainment:
					BoundNode boundKContainment;
					boundKContainment = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaPropertyKind.Containment, node, false);
					childBoundNodesForParent.Add(boundKContainment);
					break;
				case MetaSyntaxKind.KReadonly:
					BoundNode boundKReadonly;
					boundKReadonly = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaPropertyKind.Readonly, node, false);
					childBoundNodesForParent.Add(boundKReadonly);
					break;
				case MetaSyntaxKind.KLazy:
					BoundNode boundKLazy;
					boundKLazy = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaPropertyKind.Lazy, node, false);
					childBoundNodesForParent.Add(boundKLazy);
					break;
				case MetaSyntaxKind.KDerived:
					BoundNode boundKDerived;
					boundKDerived = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaPropertyKind.Derived, node, false);
					childBoundNodesForParent.Add(boundKDerived);
					break;
				default:
					break;
			}
			return null;
		}
		
		public BoundNode VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.Redefinitions != null)
			{
				this.Visit(node.Redefinitions, childBoundNodesForParent);
			}
			if (node.Subsettings != null)
			{
				this.Visit(node.Subsettings, childBoundNodesForParent);
			}
			return null;
		}
		
		public BoundNode VisitRedefinitions(RedefinitionsSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.NameUseList != null)
			{
				var childBoundNodesOfNameUseList = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.NameUseList, childBoundNodesOfNameUseList);
				BoundNode boundNameUseList;
				boundNameUseList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNameUseList.ToImmutableAndFree(), "RedefinedProperties", node.NameUseList, false);
				childBoundNodesForParent.Add(boundNameUseList);
			}
			return null;
		}
		
		public BoundNode VisitSubsettings(SubsettingsSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.NameUseList != null)
			{
				var childBoundNodesOfNameUseList = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.NameUseList, childBoundNodesOfNameUseList);
				BoundNode boundNameUseList;
				boundNameUseList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfNameUseList.ToImmutableAndFree(), "SubsettedProperties", node.NameUseList, false);
				childBoundNodesForParent.Add(boundNameUseList);
			}
			return null;
		}
		
		public BoundNode VisitNameUseList(NameUseListSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Qualifier != null)
			{
				foreach (var item in node.Qualifier)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaProperty)), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitConstDeclaration(ConstDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.TypeReference != null)
			{
				var childBoundNodesOfTypeReference = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
				BoundNode boundTypeReference;
				boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), "Type", node.TypeReference, false);
				childBoundNodes.Add(boundTypeReference);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaConstant), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitExternTypeDeclaration(ExternTypeDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.ExternClassTypeDeclaration != null)
			{
				this.Visit(node.ExternClassTypeDeclaration, childBoundNodesForParent);
			}
			if (node.ExternStructTypeDeclaration != null)
			{
				this.Visit(node.ExternStructTypeDeclaration, childBoundNodesForParent);
			}
			return null;
		}
		
		public BoundNode VisitExternClassTypeDeclaration(ExternClassTypeDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Qualifier != null)
			{
				var childBoundNodesOfQualifier = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.Qualifier, childBoundNodesOfQualifier);
				BoundNode boundQualifier;
				boundQualifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), node.Qualifier, false);
				boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create(boundQualifier), "ExternalName", node.Qualifier, false);
				childBoundNodes.Add(boundQualifier);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaExternalType), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitExternStructTypeDeclaration(ExternStructTypeDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.KStruct.GetKind() == MetaSyntaxKind.KStruct)
			{
				BoundNode boundKStruct;
				boundKStruct = this.CreateBoundProperty(this.BoundTree, ImmutableArray<BoundNode>.Empty, "IsValueType", true, node, false);
				childBoundNodes.Add(boundKStruct);
			}
			if (node.Qualifier != null)
			{
				var childBoundNodesOfQualifier = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.Qualifier, childBoundNodesOfQualifier);
				BoundNode boundQualifier;
				boundQualifier = this.CreateBoundValue(this.BoundTree, childBoundNodesOfQualifier.ToImmutableAndFree(), node.Qualifier, false);
				boundQualifier = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create(boundQualifier), "ExternalName", node.Qualifier, false);
				childBoundNodes.Add(boundQualifier);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaExternalType), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitReturnType(ReturnTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.TypeReference != null)
			{
				this.Visit(node.TypeReference, childBoundNodes);
			}
			if (node.VoidType != null)
			{
				this.Visit(node.VoidType, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitTypeOfReference(TypeOfReferenceSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.TypeReference != null)
			{
				this.Visit(node.TypeReference, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitTypeReference(TypeReferenceSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.CollectionType != null)
			{
				this.Visit(node.CollectionType, childBoundNodes);
			}
			if (node.SimpleType != null)
			{
				this.Visit(node.SimpleType, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitSimpleType(SimpleTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.PrimitiveType != null)
			{
				this.Visit(node.PrimitiveType, childBoundNodes);
			}
			if (node.ObjectType != null)
			{
				this.Visit(node.ObjectType, childBoundNodes);
			}
			if (node.NullableType != null)
			{
				this.Visit(node.NullableType, childBoundNodes);
			}
			if (node.ClassType != null)
			{
				this.Visit(node.ClassType, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaType)), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitClassType(ClassTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Qualifier != null)
			{
				this.Visit(node.Qualifier, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodes.ToImmutableAndFree(), ImmutableArray<Type>.Empty, node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitObjectType(ObjectTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitPrimitiveType(PrimitiveTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitVoidType(VoidTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitNullableType(NullableTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.PrimitiveType != null)
			{
				var childBoundNodesOfPrimitiveType = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.PrimitiveType, childBoundNodesOfPrimitiveType);
				BoundNode boundPrimitiveType;
				boundPrimitiveType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfPrimitiveType.ToImmutableAndFree(), "InnerType", node.PrimitiveType, false);
				childBoundNodes.Add(boundPrimitiveType);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolCtr(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaNullableType), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitCollectionType(CollectionTypeSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.CollectionKind != null)
			{
				var childBoundNodesOfCollectionKind = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.CollectionKind, childBoundNodesOfCollectionKind);
				BoundNode boundCollectionKind;
				boundCollectionKind = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfCollectionKind.ToImmutableAndFree(), "Kind", node.CollectionKind, false);
				childBoundNodes.Add(boundCollectionKind);
			}
			if (node.SimpleType != null)
			{
				var childBoundNodesOfSimpleType = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.SimpleType, childBoundNodesOfSimpleType);
				BoundNode boundSimpleType;
				boundSimpleType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSimpleType.ToImmutableAndFree(), "InnerType", node.SimpleType, false);
				childBoundNodes.Add(boundSimpleType);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolCtr(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaCollectionType), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitCollectionKind(CollectionKindSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			switch (node.CollectionKind.GetKind().Switch())
			{
				case MetaSyntaxKind.KSet:
					BoundNode boundKSet;
					boundKSet = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaCollectionKind.Set, node, false);
					childBoundNodesForParent.Add(boundKSet);
					break;
				case MetaSyntaxKind.KList:
					BoundNode boundKList;
					boundKList = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaCollectionKind.List, node, false);
					childBoundNodesForParent.Add(boundKList);
					break;
				case MetaSyntaxKind.KMultiSet:
					BoundNode boundKMultiSet;
					boundKMultiSet = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaCollectionKind.MultiSet, node, false);
					childBoundNodesForParent.Add(boundKMultiSet);
					break;
				case MetaSyntaxKind.KMultiList:
					BoundNode boundKMultiList;
					boundKMultiList = this.CreateBoundValue(this.BoundTree, ImmutableArray<BoundNode>.Empty, MetaCollectionKind.MultiList, node, false);
					childBoundNodesForParent.Add(boundKMultiList);
					break;
				default:
					break;
			}
			return null;
		}
		
		public BoundNode VisitOperationDeclaration(OperationDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.ReturnType != null)
			{
				var childBoundNodesOfReturnType = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.ReturnType, childBoundNodesOfReturnType);
				BoundNode boundReturnType;
				boundReturnType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfReturnType.ToImmutableAndFree(), "ReturnType", node.ReturnType, false);
				childBoundNodes.Add(boundReturnType);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			if (node.ParameterList != null)
			{
				var childBoundNodesOfParameterList = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.ParameterList, childBoundNodesOfParameterList);
				BoundNode boundParameterList;
				boundParameterList = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfParameterList.ToImmutableAndFree(), "Parameters", node.ParameterList, false);
				childBoundNodes.Add(boundParameterList);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaOperation), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitParameterList(ParameterListSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.Parameter != null)
			{
				foreach (var item in node.Parameter)
				{
					this.Visit(item, childBoundNodesForParent);
				}
			}
			return null;
		}
		
		public BoundNode VisitParameter(ParameterSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.TypeReference != null)
			{
				var childBoundNodesOfTypeReference = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.TypeReference, childBoundNodesOfTypeReference);
				BoundNode boundTypeReference;
				boundTypeReference = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTypeReference.ToImmutableAndFree(), "Type", node.TypeReference, false);
				childBoundNodes.Add(boundTypeReference);
			}
			if (node.Name != null)
			{
				this.Visit(node.Name, childBoundNodes);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), typeof(Symbols.MetaParameter), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitAssociationDeclaration(AssociationDeclarationSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			if (node.Annotation != null)
			{
				foreach (var item in node.Annotation)
				{
					this.Visit(item, childBoundNodes);
				}
			}
			if (node.Source != null)
			{
				var childBoundNodesOfSource = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.Source, childBoundNodesOfSource);
				BoundNode boundSource;
				boundSource = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaProperty)), node.Source, false);
				childBoundNodes.Add(boundSource);
			}
			if (node.Target != null)
			{
				var childBoundNodesOfTarget = ArrayBuilder<BoundNode>.GetInstance();
				this.Visit(node.Target, childBoundNodesOfTarget);
				BoundNode boundTarget;
				boundTarget = this.CreateBoundSymbolUse(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), ImmutableArray.Create(typeof(Symbols.MetaProperty)), node.Target, false);
				childBoundNodes.Add(boundTarget);
			}
			BoundNode resultNode;
			resultNode = this.CreateBoundOpposite(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitIdentifier(IdentifierSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitLiteral(LiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			if (node.NullLiteral != null)
			{
				this.Visit(node.NullLiteral, childBoundNodesForParent);
			}
			if (node.BooleanLiteral != null)
			{
				this.Visit(node.BooleanLiteral, childBoundNodesForParent);
			}
			if (node.IntegerLiteral != null)
			{
				this.Visit(node.IntegerLiteral, childBoundNodesForParent);
			}
			if (node.DecimalLiteral != null)
			{
				this.Visit(node.DecimalLiteral, childBoundNodesForParent);
			}
			if (node.ScientificLiteral != null)
			{
				this.Visit(node.ScientificLiteral, childBoundNodesForParent);
			}
			if (node.StringLiteral != null)
			{
				this.Visit(node.StringLiteral, childBoundNodesForParent);
			}
			return null;
		}
		
		public BoundNode VisitNullLiteral(NullLiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitBooleanLiteral(BooleanLiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitIntegerLiteral(IntegerLiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitDecimalLiteral(DecimalLiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitScientificLiteral(ScientificLiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
		
		public BoundNode VisitStringLiteral(StringLiteralSyntax node, ArrayBuilder<BoundNode> childBoundNodesForParent)
		{
			if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
			{
				childBoundNodesForParent.Add(cachedBoundNode);
				return cachedBoundNode;
			}
			var childBoundNodes = ArrayBuilder<BoundNode>.GetInstance();
			BoundNode resultNode;
			resultNode = this.CreateBoundValue(this.BoundTree, childBoundNodes.ToImmutableAndFree(), node, false);
			childBoundNodesForParent.Add(resultNode);
			return resultNode;
		}
    }
}


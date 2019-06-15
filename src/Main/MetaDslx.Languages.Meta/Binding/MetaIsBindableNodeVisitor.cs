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
			return false;
		}
		
		public bool VisitName(NameSyntax node)
		{
			return true;
		}
		
		public bool VisitQualifiedName(QualifiedNameSyntax node)
		{
			return true;
		}
		
		public bool VisitQualifier(QualifierSyntax node)
		{
			return true;
		}
		
		public bool VisitAnnotation(AnnotationSyntax node)
		{
			return true;
		}
		
		public bool VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitNamespaceBody(NamespaceBodySyntax node)
		{
			return false;
		}
		
		public bool VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
			return false;
		}
		
		public bool VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
			return false;
		}
		
		public bool VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			return true;
		}
		
		public bool VisitDeclaration(DeclarationSyntax node)
		{
			return false;
		}
		
		public bool VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitEnumBody(EnumBodySyntax node)
		{
			return true;
		}
		
		public bool VisitEnumValues(EnumValuesSyntax node)
		{
			return false;
		}
		
		public bool VisitEnumValue(EnumValueSyntax node)
		{
			return true;
		}
		
		public bool VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitClassBody(ClassBodySyntax node)
		{
			return false;
		}
		
		public bool VisitClassAncestors(ClassAncestorsSyntax node)
		{
			return false;
		}
		
		public bool VisitClassAncestor(ClassAncestorSyntax node)
		{
			return true;
		}
		
		public bool VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitFieldModifier(FieldModifierSyntax node)
		{
			return false;
		}
		
		public bool VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			return false;
		}
		
		public bool VisitRedefinitions(RedefinitionsSyntax node)
		{
			return true;
		}
		
		public bool VisitSubsettings(SubsettingsSyntax node)
		{
			return true;
		}
		
		public bool VisitNameUseList(NameUseListSyntax node)
		{
			return true;
		}
		
		public bool VisitConstDeclaration(ConstDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitExternTypeDeclaration(ExternTypeDeclarationSyntax node)
		{
			return false;
		}
		
		public bool VisitExternClassTypeDeclaration(ExternClassTypeDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitExternStructTypeDeclaration(ExternStructTypeDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitReturnType(ReturnTypeSyntax node)
		{
			return true;
		}
		
		public bool VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
			return true;
		}
		
		public bool VisitTypeReference(TypeReferenceSyntax node)
		{
			return true;
		}
		
		public bool VisitSimpleType(SimpleTypeSyntax node)
		{
			return true;
		}
		
		public bool VisitClassType(ClassTypeSyntax node)
		{
			return true;
		}
		
		public bool VisitObjectType(ObjectTypeSyntax node)
		{
			return false;
		}
		
		public bool VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			return false;
		}
		
		public bool VisitVoidType(VoidTypeSyntax node)
		{
			return true;
		}
		
		public bool VisitNullableType(NullableTypeSyntax node)
		{
			return true;
		}
		
		public bool VisitCollectionType(CollectionTypeSyntax node)
		{
			return true;
		}
		
		public bool VisitCollectionKind(CollectionKindSyntax node)
		{
			return false;
		}
		
		public bool VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitParameterList(ParameterListSyntax node)
		{
			return false;
		}
		
		public bool VisitParameter(ParameterSyntax node)
		{
			return true;
		}
		
		public bool VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			return true;
		}
		
		public bool VisitIdentifier(IdentifierSyntax node)
		{
			return true;
		}
		
		public bool VisitLiteral(LiteralSyntax node)
		{
			return false;
		}
		
		public bool VisitNullLiteral(NullLiteralSyntax node)
		{
			return true;
		}
		
		public bool VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			return true;
		}
		
		public bool VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			return true;
		}
		
		public bool VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			return true;
		}
		
		public bool VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			return true;
		}
		
		public bool VisitStringLiteral(StringLiteralSyntax node)
		{
			return true;
		}
    }
}


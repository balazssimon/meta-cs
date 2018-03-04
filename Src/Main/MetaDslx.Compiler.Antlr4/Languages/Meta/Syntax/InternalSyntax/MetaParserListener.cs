//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from MetaParser.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax {

using MetaDslx.Core;

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="MetaParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface IMetaParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMain([NotNull] MetaParser.MainContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMain([NotNull] MetaParser.MainContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterName([NotNull] MetaParser.NameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitName([NotNull] MetaParser.NameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedName([NotNull] MetaParser.QualifiedNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedName([NotNull] MetaParser.QualifiedNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifier([NotNull] MetaParser.QualifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifier([NotNull] MetaParser.QualifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotation([NotNull] MetaParser.AnnotationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotation([NotNull] MetaParser.AnnotationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.namespaceDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespaceDeclaration([NotNull] MetaParser.NamespaceDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.namespaceDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespaceDeclaration([NotNull] MetaParser.NamespaceDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.namespaceBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespaceBody([NotNull] MetaParser.NamespaceBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.namespaceBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespaceBody([NotNull] MetaParser.NamespaceBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMetamodelDeclaration([NotNull] MetaParser.MetamodelDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMetamodelDeclaration([NotNull] MetaParser.MetamodelDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelPropertyList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMetamodelPropertyList([NotNull] MetaParser.MetamodelPropertyListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelPropertyList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMetamodelPropertyList([NotNull] MetaParser.MetamodelPropertyListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMetamodelProperty([NotNull] MetaParser.MetamodelPropertyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMetamodelProperty([NotNull] MetaParser.MetamodelPropertyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.metamodelUriProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMetamodelUriProperty([NotNull] MetaParser.MetamodelUriPropertyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.metamodelUriProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMetamodelUriProperty([NotNull] MetaParser.MetamodelUriPropertyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] MetaParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] MetaParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumDeclaration([NotNull] MetaParser.EnumDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumDeclaration([NotNull] MetaParser.EnumDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumBody([NotNull] MetaParser.EnumBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumBody([NotNull] MetaParser.EnumBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumValues([NotNull] MetaParser.EnumValuesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumValues"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumValues([NotNull] MetaParser.EnumValuesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumValue([NotNull] MetaParser.EnumValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumValue([NotNull] MetaParser.EnumValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.enumMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnumMemberDeclaration([NotNull] MetaParser.EnumMemberDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.enumMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnumMemberDeclaration([NotNull] MetaParser.EnumMemberDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassDeclaration([NotNull] MetaParser.ClassDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassDeclaration([NotNull] MetaParser.ClassDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassBody([NotNull] MetaParser.ClassBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassBody([NotNull] MetaParser.ClassBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classAncestors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassAncestors([NotNull] MetaParser.ClassAncestorsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classAncestors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassAncestors([NotNull] MetaParser.ClassAncestorsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classAncestor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassAncestor([NotNull] MetaParser.ClassAncestorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classAncestor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassAncestor([NotNull] MetaParser.ClassAncestorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassMemberDeclaration([NotNull] MetaParser.ClassMemberDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classMemberDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassMemberDeclaration([NotNull] MetaParser.ClassMemberDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.fieldDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldDeclaration([NotNull] MetaParser.FieldDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.fieldDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldDeclaration([NotNull] MetaParser.FieldDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.fieldModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFieldModifier([NotNull] MetaParser.FieldModifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.fieldModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFieldModifier([NotNull] MetaParser.FieldModifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.redefinitionsOrSubsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRedefinitionsOrSubsettings([NotNull] MetaParser.RedefinitionsOrSubsettingsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.redefinitionsOrSubsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRedefinitionsOrSubsettings([NotNull] MetaParser.RedefinitionsOrSubsettingsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.redefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRedefinitions([NotNull] MetaParser.RedefinitionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.redefinitions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRedefinitions([NotNull] MetaParser.RedefinitionsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.subsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubsettings([NotNull] MetaParser.SubsettingsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.subsettings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubsettings([NotNull] MetaParser.SubsettingsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.nameUseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNameUseList([NotNull] MetaParser.NameUseListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.nameUseList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNameUseList([NotNull] MetaParser.NameUseListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.constDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstDeclaration([NotNull] MetaParser.ConstDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.constDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstDeclaration([NotNull] MetaParser.ConstDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.externTypeDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExternTypeDeclaration([NotNull] MetaParser.ExternTypeDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.externTypeDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExternTypeDeclaration([NotNull] MetaParser.ExternTypeDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.externClassTypeDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExternClassTypeDeclaration([NotNull] MetaParser.ExternClassTypeDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.externClassTypeDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExternClassTypeDeclaration([NotNull] MetaParser.ExternClassTypeDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.externStructTypeDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExternStructTypeDeclaration([NotNull] MetaParser.ExternStructTypeDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.externStructTypeDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExternStructTypeDeclaration([NotNull] MetaParser.ExternStructTypeDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturnType([NotNull] MetaParser.ReturnTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.returnType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturnType([NotNull] MetaParser.ReturnTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.typeOfReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeOfReference([NotNull] MetaParser.TypeOfReferenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.typeOfReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeOfReference([NotNull] MetaParser.TypeOfReferenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.typeReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeReference([NotNull] MetaParser.TypeReferenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.typeReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeReference([NotNull] MetaParser.TypeReferenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.simpleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleType([NotNull] MetaParser.SimpleTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.simpleType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleType([NotNull] MetaParser.SimpleTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.classType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassType([NotNull] MetaParser.ClassTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.classType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassType([NotNull] MetaParser.ClassTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.objectType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObjectType([NotNull] MetaParser.ObjectTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.objectType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObjectType([NotNull] MetaParser.ObjectTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimitiveType([NotNull] MetaParser.PrimitiveTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimitiveType([NotNull] MetaParser.PrimitiveTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.voidType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVoidType([NotNull] MetaParser.VoidTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.voidType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVoidType([NotNull] MetaParser.VoidTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.nullableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullableType([NotNull] MetaParser.NullableTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.nullableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullableType([NotNull] MetaParser.NullableTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.collectionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollectionType([NotNull] MetaParser.CollectionTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.collectionType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollectionType([NotNull] MetaParser.CollectionTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.collectionKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCollectionKind([NotNull] MetaParser.CollectionKindContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.collectionKind"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCollectionKind([NotNull] MetaParser.CollectionKindContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.operationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOperationDeclaration([NotNull] MetaParser.OperationDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.operationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOperationDeclaration([NotNull] MetaParser.OperationDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterList([NotNull] MetaParser.ParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterList([NotNull] MetaParser.ParameterListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] MetaParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] MetaParser.ParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.associationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssociationDeclaration([NotNull] MetaParser.AssociationDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.associationDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssociationDeclaration([NotNull] MetaParser.AssociationDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] MetaParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] MetaParser.IdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] MetaParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] MetaParser.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullLiteral([NotNull] MetaParser.NullLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullLiteral([NotNull] MetaParser.NullLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanLiteral([NotNull] MetaParser.BooleanLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanLiteral([NotNull] MetaParser.BooleanLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.integerLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntegerLiteral([NotNull] MetaParser.IntegerLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.integerLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntegerLiteral([NotNull] MetaParser.IntegerLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.decimalLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDecimalLiteral([NotNull] MetaParser.DecimalLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.decimalLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDecimalLiteral([NotNull] MetaParser.DecimalLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.scientificLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScientificLiteral([NotNull] MetaParser.ScientificLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.scientificLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScientificLiteral([NotNull] MetaParser.ScientificLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="MetaParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringLiteral([NotNull] MetaParser.StringLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="MetaParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringLiteral([NotNull] MetaParser.StringLiteralContext context);
}
} // namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax

